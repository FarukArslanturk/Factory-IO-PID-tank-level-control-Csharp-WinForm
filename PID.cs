using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EngineIO;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;  

namespace PID_tanklevelcontrol
{
    public partial class Form1 : Form
    {

        public const int CycleTime = 8;
        public Int32 P, D;
        public double I;

        public bool FIO_run;

        // The data arrays that store the visible data. The data arrays are updated in realtime. In
        // this demo, we plot the last 240 samples.
        private const int sampleSize = 240;
        private DateTime[] timeStamps = new DateTime[sampleSize];
        private double[] dataSetPoint = new double[sampleSize];
        private double[] dataLevelMeter = new double[sampleSize];
        
        // In this demo, we use a data generator driven by a timer to generate realtime data. The
        // nextDataTime is an internal variable used by the data generator to keep track of which
        // values to generate next.
        private DateTime nextDataTime = DateTime.Now;

        //Stopwatch used to measure elapsed time between cycles
        Stopwatch stopwatch = new Stopwatch();

        //MemoryBit used to switch FACTORY I/O between edit and run mode
        MemoryBit start = MemoryMap.Instance.GetBit(MemoryMap.BitCount - 16, MemoryType.Output);

        //MemoryBit used to detect if FACTORY I/O is edit or run mode
        MemoryBit running = MemoryMap.Instance.GetBit(MemoryMap.BitCount - 16, MemoryType.Input);
        //
        MemoryFloat fillValve = MemoryMap.Instance.GetFloat("Fill valve", MemoryType.Output);
        MemoryFloat dischargeValve = MemoryMap.Instance.GetFloat("Discharge valve", MemoryType.Output);
        MemoryInt spDisplay = MemoryMap.Instance.GetInt("SP", MemoryType.Output);
        MemoryInt pvDisplay = MemoryMap.Instance.GetInt("PV", MemoryType.Output);
        MemoryFloat levelMeter = MemoryMap.Instance.GetFloat("Level meter", MemoryType.Input);
        MemoryFloat setpoint = MemoryMap.Instance.GetFloat("Setpoint", MemoryType.Input);
        
        PID PIDcontroller;

        public Form1()
        {   
            InitializeComponent();

            pidchart.Series.Clear();
            pidchart.Series.Add("SetPoint");
            pidchart.Series.Add("LevelMeter");

            pidchart.Series["SetPoint"].ChartType = SeriesChartType.FastLine;
            pidchart.Series["LevelMeter"].ChartType = SeriesChartType.Spline;

            pidchart.ChartAreas[0].AxisY.Maximum = 300;
            pidchart.ChartAreas[0].AxisY.Minimum = 0;
            pidchart.ChartAreas[0].AxisX.Maximum = 240;
            pidchart.ChartAreas[0].AxisX.Minimum = 0;
            //
        }

        static void SwitchToRun(MemoryBit start)
        {
            
            start.Value = false;
            MemoryMap.Instance.Update();
            Thread.Sleep(500);

            start.Value = true;
            MemoryMap.Instance.Update();
            Thread.Sleep(500);

        }

        static void Shutdown(MemoryBit start)
        {
            start.Value = false;

            MemoryMap.Instance.Update();
        }

        public void btn_startsim_Click(object sender, EventArgs e)
        {
            //
            timer1.Enabled = true;
            //
            SwitchToRun(start);
            stopwatch.Start();
            Thread.Sleep(CycleTime);
            //
            btn_startsim.Text = "Restart";
            fillValve.Value = 0;
            dischargeValve.Value = 0;
            //
            dataRateTimer.Start();
            chartUpdateTimer.Start();
        }

        private void btn_stopsim_Click(object sender, EventArgs e)
        {
            
            if (running.Value)
            {
                timer1.Enabled = false;
                Shutdown(start);
                btn_startsim.Text = "Start";
                //
                dataRateTimer.Stop();
                chartUpdateTimer.Stop();
            }

        }
        public void Form1_Load(object sender, EventArgs e)
        {
            //Initialize with zeros
            PIDcontroller = new PID(P, I, D);
            PIDcontroller.CVLow = -10;
            PIDcontroller.CVHigh = 10;

            // Data generation rate
            dataRateTimer.Interval = 250;

            // Chart update rate, which can be different from the data generation rate.
            chartUpdateTimer.Interval = 2000;

            // Initialize data buffer to no data.
            //timeStamps[i] = DateTime.MinValue;
            for (int i = 0; i < timeStamps.Length; ++i)
                timeStamps[i] = DateTime.MinValue;

            checkFacIO.Interval = 100;
            checkFacIO.Enabled = true;

        }
        //
        // Utility to shift a double value into an array
        //

        private void shiftData(double[] data, double newValue)
        {
            for (int i = 1; i < data.Length; ++i)
                data[i - 1] = data[i];
            data[data.Length - 1] = newValue;
        }

        //
        // Utility to shift a DataTime value into an array
        //
        private void shiftData(DateTime[] data, DateTime newValue)
        {
            for (int i = 1; i < data.Length; ++i)
                data[i - 1] = data[i];
            data[data.Length - 1] = newValue;
        }
        private void dataRateTimer_Tick(object sender, EventArgs e)
        {
            do
            {
                //
                // In this demo, we use some formulas to generate new values. In real applications,
                // it may be replaced by some data acquisition code.
                //
                
                double dataA = spDisplay.Value;
                double dataB = pvDisplay.Value;
                
                // After obtaining the new values, we need to update the data arrays.
                shiftData(dataSetPoint, dataA);
                shiftData(dataLevelMeter, dataB);
                
                shiftData(timeStamps, nextDataTime);

                // Update nextDataTime. This is needed by our data generator. In real applications,
                // you may not need this variable or the associated do/while loop.
                nextDataTime = nextDataTime.AddMilliseconds(dataRateTimer.Interval);
            }
            while (nextDataTime < DateTime.Now);
        }

        private void chartUpdateTimer_Tick(object sender, EventArgs e)
        {
            pidchart.Series["SetPoint"].Points.Clear();
            pidchart.Series["LevelMeter"].Points.Clear();

            for (int i = 0; i< dataSetPoint.Length; i++)
            {
                pidchart.Series["SetPoint"].Points.AddXY(i, dataSetPoint[i]);
            }
            for (int j = 0; j < dataLevelMeter.Length; j++)
            {
                pidchart.Series["LevelMeter"].Points.AddXY(j, dataLevelMeter[j]);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                P = Convert.ToInt32(txt_P.Text);
                I = Convert.ToDouble(txt_I.Text);
                D = Convert.ToInt32(txt_D.Text);
            }
            catch(System.FormatException)
            {
                //do nothing
            }
            
            MemoryMap.Instance.Update();

            if (running.Value)
            {
                stopwatch.Stop();

                Execute((int)stopwatch.ElapsedMilliseconds);

                stopwatch.Restart();

                bar1.value = (int)(levelMeter.Value * 100 / 10);
                bar1.changeValue();
                lbl_percentage.Text = "%" + Convert.ToString(bar1.value);
                lbl_SP.Text = "SP : " + Convert.ToString(Math.Round(setpoint.Value,1));
                lbl_PV.Text = "PV : " + Convert.ToString(Math.Round(levelMeter.Value,1));
                lbl_FV.Text = "FV : " + Convert.ToString(Math.Round(fillValve.Value,1));
                lbl_DV.Text = "DV : " + Convert.ToString(Math.Round(dischargeValve.Value,1));

            }

            Thread.Sleep(CycleTime);

        }

        private void txt_apply_Click(object sender, EventArgs e)
        {
            
            PIDcontroller.Kp = Convert.ToDouble(P);
            PIDcontroller.Ki = Convert.ToDouble(I);
            PIDcontroller.Kd = Convert.ToDouble(D);

        }

        private bool checkFacIO_runs()
        {
            Process[] pname = Process.GetProcessesByName("Factory IO");
            if (pname.Length == 0)
                return false;
            else
                return true;
        }

        private void checkFacIO_Tick(object sender, EventArgs e)
        {
            FIO_run = checkFacIO_runs();

            if (!FIO_run)
            {
                btn_FIO.Visible = true;
            }
        }

        private void btn_FIO_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        public void Execute(int elapsedTime)
        {
            PIDcontroller.CLK(setpoint.Value, levelMeter.Value, elapsedTime);

            if ((float)PIDcontroller.OV >= 0)
            {
                fillValve.Value = (float)PIDcontroller.OV;
                dischargeValve.Value = 0;
            }
            else
            {
                fillValve.Value = 0;
                dischargeValve.Value = Math.Abs((float)PIDcontroller.OV);
            }

            spDisplay.Value = (int)(setpoint.Value * 300 / 10);
            pvDisplay.Value = (int)(levelMeter.Value * 300 / 10);

        }

    }

}

