using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineIO;


namespace PID_tanklevelcontrol
{
    
    public class LevelControl : Executer
    {
        MemoryFloat fillValve = MemoryMap.Instance.GetFloat("Fill valve", MemoryType.Output);
        MemoryFloat dischargeValve = MemoryMap.Instance.GetFloat("Discharge valve", MemoryType.Output);
        MemoryInt spDisplay = MemoryMap.Instance.GetInt("SP", MemoryType.Output);
        MemoryInt pvDisplay = MemoryMap.Instance.GetInt("PV", MemoryType.Output);
        MemoryFloat levelMeter = MemoryMap.Instance.GetFloat("Level meter", MemoryType.Input);
        MemoryFloat setpoint = MemoryMap.Instance.GetFloat("Setpoint", MemoryType.Input);

        

        PID controller;

        public LevelControl(Int32 P,double I, Int32 D)
        {
            controller = new PID(P, I, D);
            controller.CVLow = 0;
            controller.CVHigh = 10;

            fillValve.Value = 0;
            dischargeValve.Value = 0;
        }
        
        public override void Execute(int elapsedTime)
        {
            controller.CLK(setpoint.Value, levelMeter.Value, elapsedTime);

            
            fillValve.Value = (float)controller.OV;

            spDisplay.Value = (int)(setpoint.Value * 300 / 10);
            pvDisplay.Value = (int)(levelMeter.Value * 300 / 10);

            // buraya write text ile değiştir
            //Console.WriteLine("OV: " + controller.OV.ToString());
        }
    }
}
