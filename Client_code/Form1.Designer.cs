namespace Smart_building
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TableTimer = new System.Windows.Forms.Timer(this.components);
            this.AlarmTimer = new System.Windows.Forms.Timer(this.components);
            this.SocketTimer = new System.Windows.Forms.Timer(this.components);
            this.SendingTimer = new System.Windows.Forms.Timer(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvSQLDatabase = new System.Windows.Forms.DataGridView();
            this.tpPCS = new System.Windows.Forms.TabPage();
            this.btnPorceLightOff = new System.Windows.Forms.Button();
            this.picLightStatus = new System.Windows.Forms.PictureBox();
            this.btnStopLogging = new System.Windows.Forms.Button();
            this.btnStartLogging = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOutsideTemprature = new System.Windows.Forms.TextBox();
            this.txtInsideTemprature = new System.Windows.Forms.TextBox();
            this.txtHeatPumpStatus = new System.Windows.Forms.TextBox();
            this.txtDoorStatus = new System.Windows.Forms.TextBox();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.rbPorchLightLocal = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.rbPorchLightAuto = new System.Windows.Forms.RadioButton();
            this.btnAzureConnection = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAzureDisconnection = new System.Windows.Forms.Button();
            this.btnPorcheLightOn = new System.Windows.Forms.Button();
            this.btnOpenDoor = new System.Windows.Forms.Button();
            this.tabDatabase = new System.Windows.Forms.TabControl();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSQLDatabase)).BeginInit();
            this.tpPCS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLightStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.tabDatabase.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableTimer
            // 
            this.TableTimer.Interval = 1000;
            this.TableTimer.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // AlarmTimer
            // 
            this.AlarmTimer.Interval = 2000;
            this.AlarmTimer.Tick += new System.EventHandler(this.SensorTimer_Tick);
            // 
            // SocketTimer
            // 
            this.SocketTimer.Enabled = true;
            this.SocketTimer.Interval = 1000;
            this.SocketTimer.Tick += new System.EventHandler(this.timer1_Tick_2);
            // 
            // SendingTimer
            // 
            this.SendingTimer.Interval = 1000;
            this.SendingTimer.Tick += new System.EventHandler(this.SendingTimer_Tick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.dgvSQLDatabase);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(951, 470);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "PCS Database";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(824, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "Refreshes every 5 min";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "SQL Database in Azure:";
            // 
            // dgvSQLDatabase
            // 
            this.dgvSQLDatabase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSQLDatabase.Location = new System.Drawing.Point(16, 39);
            this.dgvSQLDatabase.Name = "dgvSQLDatabase";
            this.dgvSQLDatabase.RowHeadersWidth = 51;
            this.dgvSQLDatabase.Size = new System.Drawing.Size(929, 416);
            this.dgvSQLDatabase.TabIndex = 21;
            // 
            // tpPCS
            // 
            this.tpPCS.Controls.Add(this.btnPorceLightOff);
            this.tpPCS.Controls.Add(this.picLightStatus);
            this.tpPCS.Controls.Add(this.btnStopLogging);
            this.tpPCS.Controls.Add(this.btnStartLogging);
            this.tpPCS.Controls.Add(this.pictureBox5);
            this.tpPCS.Controls.Add(this.pictureBox4);
            this.tpPCS.Controls.Add(this.label10);
            this.tpPCS.Controls.Add(this.button3);
            this.tpPCS.Controls.Add(this.button1);
            this.tpPCS.Controls.Add(this.label9);
            this.tpPCS.Controls.Add(this.label8);
            this.tpPCS.Controls.Add(this.txtOutsideTemprature);
            this.tpPCS.Controls.Add(this.txtInsideTemprature);
            this.tpPCS.Controls.Add(this.txtHeatPumpStatus);
            this.tpPCS.Controls.Add(this.txtDoorStatus);
            this.tpPCS.Controls.Add(this.dgvLog);
            this.tpPCS.Controls.Add(this.label7);
            this.tpPCS.Controls.Add(this.rbPorchLightLocal);
            this.tpPCS.Controls.Add(this.label5);
            this.tpPCS.Controls.Add(this.rbPorchLightAuto);
            this.tpPCS.Controls.Add(this.btnAzureConnection);
            this.tpPCS.Controls.Add(this.label6);
            this.tpPCS.Controls.Add(this.btnAzureDisconnection);
            this.tpPCS.Controls.Add(this.btnPorcheLightOn);
            this.tpPCS.Controls.Add(this.btnOpenDoor);
            this.tpPCS.Location = new System.Drawing.Point(4, 22);
            this.tpPCS.Margin = new System.Windows.Forms.Padding(2);
            this.tpPCS.Name = "tpPCS";
            this.tpPCS.Padding = new System.Windows.Forms.Padding(2);
            this.tpPCS.Size = new System.Drawing.Size(951, 470);
            this.tpPCS.TabIndex = 0;
            this.tpPCS.Text = "PCS";
            this.tpPCS.UseVisualStyleBackColor = true;
            // 
            // btnPorceLightOff
            // 
            this.btnPorceLightOff.Enabled = false;
            this.btnPorceLightOff.Location = new System.Drawing.Point(87, 263);
            this.btnPorceLightOff.Name = "btnPorceLightOff";
            this.btnPorceLightOff.Size = new System.Drawing.Size(61, 23);
            this.btnPorceLightOff.TabIndex = 33;
            this.btnPorceLightOff.Text = "Light Off";
            this.btnPorceLightOff.UseVisualStyleBackColor = true;
            this.btnPorceLightOff.Click += new System.EventHandler(this.btnPorceLightOff_Click);
            // 
            // picLightStatus
            // 
            this.picLightStatus.Location = new System.Drawing.Point(183, 224);
            this.picLightStatus.Margin = new System.Windows.Forms.Padding(2);
            this.picLightStatus.Name = "picLightStatus";
            this.picLightStatus.Size = new System.Drawing.Size(56, 78);
            this.picLightStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLightStatus.TabIndex = 32;
            this.picLightStatus.TabStop = false;
            // 
            // btnStopLogging
            // 
            this.btnStopLogging.BackColor = System.Drawing.Color.PeachPuff;
            this.btnStopLogging.Location = new System.Drawing.Point(183, 89);
            this.btnStopLogging.Name = "btnStopLogging";
            this.btnStopLogging.Size = new System.Drawing.Size(138, 33);
            this.btnStopLogging.TabIndex = 31;
            this.btnStopLogging.Text = "Stop Logging";
            this.btnStopLogging.UseVisualStyleBackColor = false;
            this.btnStopLogging.Click += new System.EventHandler(this.btnStopLogging_Click);
            // 
            // btnStartLogging
            // 
            this.btnStartLogging.BackColor = System.Drawing.Color.PeachPuff;
            this.btnStartLogging.Location = new System.Drawing.Point(15, 89);
            this.btnStartLogging.Name = "btnStartLogging";
            this.btnStartLogging.Size = new System.Drawing.Size(138, 33);
            this.btnStartLogging.TabIndex = 30;
            this.btnStartLogging.Text = "Start Logging";
            this.btnStartLogging.UseVisualStyleBackColor = false;
            this.btnStartLogging.Click += new System.EventHandler(this.btnStartLogging_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(128, 422);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(67, 34);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 29;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(199, 366);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(100, 100);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 28;
            this.pictureBox4.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(428, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Alarm log:";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Coral;
            this.button3.Location = new System.Drawing.Point(681, 391);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(160, 51);
            this.button3.TabIndex = 26;
            this.button3.Text = "Delete Acknowledged Alarm";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.YellowGreen;
            this.button1.Location = new System.Drawing.Point(431, 391);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 51);
            this.button1.TabIndex = 25;
            this.button1.Text = "Acknowledge Alarm";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(180, 164);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Temprature Outside [C]:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Temprature Inside [C]:";
            // 
            // txtOutsideTemprature
            // 
            this.txtOutsideTemprature.Location = new System.Drawing.Point(183, 179);
            this.txtOutsideTemprature.Margin = new System.Windows.Forms.Padding(2);
            this.txtOutsideTemprature.Name = "txtOutsideTemprature";
            this.txtOutsideTemprature.Size = new System.Drawing.Size(91, 20);
            this.txtOutsideTemprature.TabIndex = 22;
            // 
            // txtInsideTemprature
            // 
            this.txtInsideTemprature.Location = new System.Drawing.Point(25, 179);
            this.txtInsideTemprature.Margin = new System.Windows.Forms.Padding(2);
            this.txtInsideTemprature.Name = "txtInsideTemprature";
            this.txtInsideTemprature.Size = new System.Drawing.Size(94, 20);
            this.txtInsideTemprature.TabIndex = 21;
            // 
            // txtHeatPumpStatus
            // 
            this.txtHeatPumpStatus.Location = new System.Drawing.Point(23, 407);
            this.txtHeatPumpStatus.Name = "txtHeatPumpStatus";
            this.txtHeatPumpStatus.Size = new System.Drawing.Size(100, 20);
            this.txtHeatPumpStatus.TabIndex = 4;
            // 
            // txtDoorStatus
            // 
            this.txtDoorStatus.Location = new System.Drawing.Point(23, 325);
            this.txtDoorStatus.Name = "txtDoorStatus";
            this.txtDoorStatus.Size = new System.Drawing.Size(100, 20);
            this.txtDoorStatus.TabIndex = 5;
            // 
            // dgvLog
            // 
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Location = new System.Drawing.Point(431, 36);
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.RowHeadersWidth = 51;
            this.dgvLog.Size = new System.Drawing.Size(515, 336);
            this.dgvLog.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Porch Light Auto/Local:";
            // 
            // rbPorchLightLocal
            // 
            this.rbPorchLightLocal.AutoSize = true;
            this.rbPorchLightLocal.Location = new System.Drawing.Point(87, 240);
            this.rbPorchLightLocal.Name = "rbPorchLightLocal";
            this.rbPorchLightLocal.Size = new System.Drawing.Size(51, 17);
            this.rbPorchLightLocal.TabIndex = 18;
            this.rbPorchLightLocal.Text = "Local";
            this.rbPorchLightLocal.UseVisualStyleBackColor = true;
            this.rbPorchLightLocal.CheckedChanged += new System.EventHandler(this.rbPorchLightLocal_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 391);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Outdoor unit Heating [%]:";
            // 
            // rbPorchLightAuto
            // 
            this.rbPorchLightAuto.AutoSize = true;
            this.rbPorchLightAuto.Checked = true;
            this.rbPorchLightAuto.Location = new System.Drawing.Point(29, 240);
            this.rbPorchLightAuto.Name = "rbPorchLightAuto";
            this.rbPorchLightAuto.Size = new System.Drawing.Size(47, 17);
            this.rbPorchLightAuto.TabIndex = 17;
            this.rbPorchLightAuto.TabStop = true;
            this.rbPorchLightAuto.Text = "Auto";
            this.rbPorchLightAuto.UseVisualStyleBackColor = true;
            // 
            // btnAzureConnection
            // 
            this.btnAzureConnection.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAzureConnection.Location = new System.Drawing.Point(15, 23);
            this.btnAzureConnection.Name = "btnAzureConnection";
            this.btnAzureConnection.Size = new System.Drawing.Size(138, 33);
            this.btnAzureConnection.TabIndex = 15;
            this.btnAzureConnection.Text = "Connect To Server";
            this.btnAzureConnection.UseVisualStyleBackColor = false;
            this.btnAzureConnection.Click += new System.EventHandler(this.btnAzureConnection_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 309);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Door Status:";
            // 
            // btnAzureDisconnection
            // 
            this.btnAzureDisconnection.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAzureDisconnection.Location = new System.Drawing.Point(183, 23);
            this.btnAzureDisconnection.Name = "btnAzureDisconnection";
            this.btnAzureDisconnection.Size = new System.Drawing.Size(138, 33);
            this.btnAzureDisconnection.TabIndex = 12;
            this.btnAzureDisconnection.Text = "Disconnect From Server";
            this.btnAzureDisconnection.UseVisualStyleBackColor = false;
            this.btnAzureDisconnection.Click += new System.EventHandler(this.btnAzureDisconnection_Click);
            // 
            // btnPorcheLightOn
            // 
            this.btnPorcheLightOn.Enabled = false;
            this.btnPorcheLightOn.Location = new System.Drawing.Point(25, 263);
            this.btnPorcheLightOn.Name = "btnPorcheLightOn";
            this.btnPorcheLightOn.Size = new System.Drawing.Size(61, 23);
            this.btnPorcheLightOn.TabIndex = 14;
            this.btnPorcheLightOn.Text = "Light On";
            this.btnPorcheLightOn.UseVisualStyleBackColor = true;
            this.btnPorcheLightOn.Click += new System.EventHandler(this.btnTogglePorcheLight_Click);
            // 
            // btnOpenDoor
            // 
            this.btnOpenDoor.Location = new System.Drawing.Point(131, 323);
            this.btnOpenDoor.Name = "btnOpenDoor";
            this.btnOpenDoor.Size = new System.Drawing.Size(75, 23);
            this.btnOpenDoor.TabIndex = 13;
            this.btnOpenDoor.Text = "Open Door";
            this.btnOpenDoor.UseVisualStyleBackColor = true;
            this.btnOpenDoor.Click += new System.EventHandler(this.btnOpenDoor_Click);
            // 
            // tabDatabase
            // 
            this.tabDatabase.Controls.Add(this.tpPCS);
            this.tabDatabase.Controls.Add(this.tabPage1);
            this.tabDatabase.Location = new System.Drawing.Point(16, 1);
            this.tabDatabase.Margin = new System.Windows.Forms.Padding(2);
            this.tabDatabase.Name = "tabDatabase";
            this.tabDatabase.SelectedIndex = 0;
            this.tabDatabase.Size = new System.Drawing.Size(959, 496);
            this.tabDatabase.TabIndex = 25;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 508);
            this.Controls.Add(this.tabDatabase);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSQLDatabase)).EndInit();
            this.tpPCS.ResumeLayout(false);
            this.tpPCS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLightStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.tabDatabase.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer TableTimer;
        private System.Windows.Forms.Timer AlarmTimer;
        private System.Windows.Forms.Timer SocketTimer;
        private System.Windows.Forms.Timer SendingTimer;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dgvSQLDatabase;
        private System.Windows.Forms.TabPage tpPCS;
        private System.Windows.Forms.Button btnPorceLightOff;
        private System.Windows.Forms.PictureBox picLightStatus;
        private System.Windows.Forms.Button btnStopLogging;
        private System.Windows.Forms.Button btnStartLogging;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtOutsideTemprature;
        private System.Windows.Forms.TextBox txtInsideTemprature;
        private System.Windows.Forms.TextBox txtHeatPumpStatus;
        private System.Windows.Forms.TextBox txtDoorStatus;
        private System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rbPorchLightLocal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbPorchLightAuto;
        private System.Windows.Forms.Button btnAzureConnection;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAzureDisconnection;
        private System.Windows.Forms.Button btnPorcheLightOn;
        private System.Windows.Forms.Button btnOpenDoor;
        private System.Windows.Forms.TabControl tabDatabase;
    }
}

