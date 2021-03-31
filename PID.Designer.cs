
namespace PID_tanklevelcontrol
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbl_D = new System.Windows.Forms.Label();
            this.lbl_I = new System.Windows.Forms.Label();
            this.txt_I = new System.Windows.Forms.TextBox();
            this.lbl_PID = new System.Windows.Forms.Label();
            this.txt_D = new System.Windows.Forms.TextBox();
            this.txt_P = new System.Windows.Forms.TextBox();
            this.txt_apply = new System.Windows.Forms.Button();
            this.grp_PID = new System.Windows.Forms.GroupBox();
            this.lbl_P = new System.Windows.Forms.Label();
            this.lbl_percentage = new System.Windows.Forms.Label();
            this.grp_Tank = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_DV = new System.Windows.Forms.Label();
            this.lbl_FV = new System.Windows.Forms.Label();
            this.lbl_SP = new System.Windows.Forms.Label();
            this.lbl_PV = new System.Windows.Forms.Label();
            this.grp_Sim = new System.Windows.Forms.GroupBox();
            this.btn_startsim = new System.Windows.Forms.Button();
            this.btn_stopsim = new System.Windows.Forms.Button();
            this.pidchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataRateTimer = new System.Windows.Forms.Timer(this.components);
            this.chartUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.checkFacIO = new System.Windows.Forms.Timer(this.components);
            this.btn_FIO = new System.Windows.Forms.Button();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.bar1 = new PID_tanklevelcontrol.Bar();
            this.grp_PID.SuspendLayout();
            this.grp_Tank.SuspendLayout();
            this.grp_Sim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pidchart)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbl_D
            // 
            this.lbl_D.AutoSize = true;
            this.lbl_D.Location = new System.Drawing.Point(14, 78);
            this.lbl_D.Name = "lbl_D";
            this.lbl_D.Size = new System.Drawing.Size(55, 13);
            this.lbl_D.TabIndex = 2;
            this.lbl_D.Text = "Derivative";
            // 
            // lbl_I
            // 
            this.lbl_I.AutoSize = true;
            this.lbl_I.Location = new System.Drawing.Point(27, 52);
            this.lbl_I.Name = "lbl_I";
            this.lbl_I.Size = new System.Drawing.Size(42, 13);
            this.lbl_I.TabIndex = 2;
            this.lbl_I.Text = "Integral";
            // 
            // txt_I
            // 
            this.txt_I.Location = new System.Drawing.Point(75, 49);
            this.txt_I.Name = "txt_I";
            this.txt_I.Size = new System.Drawing.Size(53, 20);
            this.txt_I.TabIndex = 3;
            this.txt_I.Text = "1";
            this.txt_I.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_PID
            // 
            this.lbl_PID.Location = new System.Drawing.Point(0, 0);
            this.lbl_PID.Name = "lbl_PID";
            this.lbl_PID.Size = new System.Drawing.Size(100, 23);
            this.lbl_PID.TabIndex = 6;
            this.lbl_PID.Text = "PID parameters";
            // 
            // txt_D
            // 
            this.txt_D.Location = new System.Drawing.Point(75, 75);
            this.txt_D.Name = "txt_D";
            this.txt_D.Size = new System.Drawing.Size(53, 20);
            this.txt_D.TabIndex = 3;
            this.txt_D.Text = "0";
            this.txt_D.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_P
            // 
            this.txt_P.AccessibleName = "txt_P";
            this.txt_P.Location = new System.Drawing.Point(75, 23);
            this.txt_P.Name = "txt_P";
            this.txt_P.Size = new System.Drawing.Size(53, 20);
            this.txt_P.TabIndex = 3;
            this.txt_P.Text = "3";
            this.txt_P.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_apply
            // 
            this.txt_apply.Location = new System.Drawing.Point(9, 101);
            this.txt_apply.Name = "txt_apply";
            this.txt_apply.Size = new System.Drawing.Size(119, 23);
            this.txt_apply.TabIndex = 5;
            this.txt_apply.Text = "Apply";
            this.txt_apply.UseVisualStyleBackColor = true;
            this.txt_apply.Click += new System.EventHandler(this.txt_apply_Click);
            // 
            // grp_PID
            // 
            this.grp_PID.Controls.Add(this.lbl_P);
            this.grp_PID.Controls.Add(this.txt_apply);
            this.grp_PID.Controls.Add(this.txt_P);
            this.grp_PID.Controls.Add(this.txt_D);
            this.grp_PID.Controls.Add(this.lbl_PID);
            this.grp_PID.Controls.Add(this.txt_I);
            this.grp_PID.Controls.Add(this.lbl_I);
            this.grp_PID.Controls.Add(this.lbl_D);
            this.grp_PID.Location = new System.Drawing.Point(12, 12);
            this.grp_PID.Name = "grp_PID";
            this.grp_PID.Size = new System.Drawing.Size(142, 136);
            this.grp_PID.TabIndex = 4;
            this.grp_PID.TabStop = false;
            this.grp_PID.Text = "PID parameters";
            // 
            // lbl_P
            // 
            this.lbl_P.AutoSize = true;
            this.lbl_P.Location = new System.Drawing.Point(6, 26);
            this.lbl_P.Name = "lbl_P";
            this.lbl_P.Size = new System.Drawing.Size(63, 13);
            this.lbl_P.TabIndex = 7;
            this.lbl_P.Text = "Proportional";
            // 
            // lbl_percentage
            // 
            this.lbl_percentage.AutoSize = true;
            this.lbl_percentage.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_percentage.ForeColor = System.Drawing.SystemColors.Window;
            this.lbl_percentage.Location = new System.Drawing.Point(22, 61);
            this.lbl_percentage.Name = "lbl_percentage";
            this.lbl_percentage.Size = new System.Drawing.Size(15, 13);
            this.lbl_percentage.TabIndex = 6;
            this.lbl_percentage.Text = "%";
            // 
            // grp_Tank
            // 
            this.grp_Tank.Controls.Add(this.label1);
            this.grp_Tank.Controls.Add(this.lbl_DV);
            this.grp_Tank.Controls.Add(this.lbl_percentage);
            this.grp_Tank.Controls.Add(this.elementHost1);
            this.grp_Tank.Controls.Add(this.lbl_FV);
            this.grp_Tank.Controls.Add(this.lbl_SP);
            this.grp_Tank.Controls.Add(this.lbl_PV);
            this.grp_Tank.Location = new System.Drawing.Point(260, 12);
            this.grp_Tank.Name = "grp_Tank";
            this.grp_Tank.Size = new System.Drawing.Size(184, 136);
            this.grp_Tank.TabIndex = 7;
            this.grp_Tank.TabStop = false;
            this.grp_Tank.Text = "Tank Level";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "(0-10V)";
            // 
            // lbl_DV
            // 
            this.lbl_DV.AutoSize = true;
            this.lbl_DV.Location = new System.Drawing.Point(101, 79);
            this.lbl_DV.Name = "lbl_DV";
            this.lbl_DV.Size = new System.Drawing.Size(31, 13);
            this.lbl_DV.TabIndex = 10;
            this.lbl_DV.Text = "DV : ";
            // 
            // lbl_FV
            // 
            this.lbl_FV.AutoSize = true;
            this.lbl_FV.Location = new System.Drawing.Point(103, 66);
            this.lbl_FV.Name = "lbl_FV";
            this.lbl_FV.Size = new System.Drawing.Size(29, 13);
            this.lbl_FV.TabIndex = 9;
            this.lbl_FV.Text = "FV : ";
            // 
            // lbl_SP
            // 
            this.lbl_SP.AutoSize = true;
            this.lbl_SP.Location = new System.Drawing.Point(102, 40);
            this.lbl_SP.Name = "lbl_SP";
            this.lbl_SP.Size = new System.Drawing.Size(30, 13);
            this.lbl_SP.TabIndex = 7;
            this.lbl_SP.Text = "SP : ";
            // 
            // lbl_PV
            // 
            this.lbl_PV.AutoSize = true;
            this.lbl_PV.Location = new System.Drawing.Point(102, 53);
            this.lbl_PV.Name = "lbl_PV";
            this.lbl_PV.Size = new System.Drawing.Size(30, 13);
            this.lbl_PV.TabIndex = 9;
            this.lbl_PV.Text = "PV : ";
            // 
            // grp_Sim
            // 
            this.grp_Sim.Controls.Add(this.btn_startsim);
            this.grp_Sim.Controls.Add(this.btn_stopsim);
            this.grp_Sim.Location = new System.Drawing.Point(557, 12);
            this.grp_Sim.Name = "grp_Sim";
            this.grp_Sim.Size = new System.Drawing.Size(231, 136);
            this.grp_Sim.TabIndex = 8;
            this.grp_Sim.TabStop = false;
            this.grp_Sim.Text = "Simulation";
            // 
            // btn_startsim
            // 
            this.btn_startsim.Image = global::PID_tanklevelcontrol.Properties.Resources.button_play_basic_green;
            this.btn_startsim.Location = new System.Drawing.Point(15, 18);
            this.btn_startsim.Name = "btn_startsim";
            this.btn_startsim.Size = new System.Drawing.Size(98, 98);
            this.btn_startsim.TabIndex = 0;
            this.btn_startsim.Text = "Start Simulation";
            this.btn_startsim.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_startsim.UseVisualStyleBackColor = true;
            this.btn_startsim.Click += new System.EventHandler(this.btn_startsim_Click);
            // 
            // btn_stopsim
            // 
            this.btn_stopsim.Image = global::PID_tanklevelcontrol.Properties.Resources.button_pause_basic_red;
            this.btn_stopsim.Location = new System.Drawing.Point(119, 19);
            this.btn_stopsim.Name = "btn_stopsim";
            this.btn_stopsim.Size = new System.Drawing.Size(98, 98);
            this.btn_stopsim.TabIndex = 1;
            this.btn_stopsim.Text = "Stop Simulation";
            this.btn_stopsim.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_stopsim.UseVisualStyleBackColor = true;
            this.btn_stopsim.Click += new System.EventHandler(this.btn_stopsim_Click);
            // 
            // pidchart
            // 
            chartArea1.Name = "ChartArea1";
            this.pidchart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.pidchart.Legends.Add(legend1);
            this.pidchart.Location = new System.Drawing.Point(12, 154);
            this.pidchart.Name = "pidchart";
            this.pidchart.Size = new System.Drawing.Size(776, 284);
            this.pidchart.TabIndex = 9;
            this.pidchart.Text = "chart1";
            // 
            // dataRateTimer
            // 
            this.dataRateTimer.Tick += new System.EventHandler(this.dataRateTimer_Tick);
            // 
            // chartUpdateTimer
            // 
            this.chartUpdateTimer.Tick += new System.EventHandler(this.chartUpdateTimer_Tick);
            // 
            // checkFacIO
            // 
            this.checkFacIO.Enabled = true;
            this.checkFacIO.Tick += new System.EventHandler(this.checkFacIO_Tick);
            // 
            // btn_FIO
            // 
            this.btn_FIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_FIO.Location = new System.Drawing.Point(3, 3);
            this.btn_FIO.Name = "btn_FIO";
            this.btn_FIO.Size = new System.Drawing.Size(793, 443);
            this.btn_FIO.TabIndex = 10;
            this.btn_FIO.Text = "Start \"Factory IO\" first and Restart me!";
            this.btn_FIO.UseVisualStyleBackColor = true;
            this.btn_FIO.Visible = false;
            this.btn_FIO.Click += new System.EventHandler(this.btn_FIO_Click);
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(6, 19);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(70, 100);
            this.elementHost1.TabIndex = 5;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.bar1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_FIO);
            this.Controls.Add(this.pidchart);
            this.Controls.Add(this.grp_Sim);
            this.Controls.Add(this.grp_Tank);
            this.Controls.Add(this.grp_PID);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grp_PID.ResumeLayout(false);
            this.grp_PID.PerformLayout();
            this.grp_Tank.ResumeLayout(false);
            this.grp_Tank.PerformLayout();
            this.grp_Sim.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pidchart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_startsim;
        private System.Windows.Forms.Button btn_stopsim;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private Bar bar1;
        private System.Windows.Forms.Label lbl_D;
        private System.Windows.Forms.Label lbl_I;
        public System.Windows.Forms.TextBox txt_I;
        private System.Windows.Forms.Label lbl_PID;
        public System.Windows.Forms.TextBox txt_D;
        public System.Windows.Forms.TextBox txt_P;
        private System.Windows.Forms.Button txt_apply;
        private System.Windows.Forms.GroupBox grp_PID;
        private System.Windows.Forms.Label lbl_P;
        private System.Windows.Forms.Label lbl_percentage;
        private System.Windows.Forms.GroupBox grp_Tank;
        private System.Windows.Forms.GroupBox grp_Sim;
        private System.Windows.Forms.Label lbl_DV;
        private System.Windows.Forms.Label lbl_FV;
        private System.Windows.Forms.Label lbl_SP;
        private System.Windows.Forms.Label lbl_PV;
        private System.Windows.Forms.DataVisualization.Charting.Chart pidchart;
        private System.Windows.Forms.Timer dataRateTimer;
        private System.Windows.Forms.Timer chartUpdateTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer checkFacIO;
        private System.Windows.Forms.Button btn_FIO;
    }
}

