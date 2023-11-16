using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_building
{
    public partial class Form1 : Form
    {
        private AzureConnection azureConnection;
        private SocketCommunication socketCommunication;


        public Form1()
        {
            InitializeComponent();

            TableTimer.Start();
            AlarmTimer.Start();
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (azureConnection != null)
            {
                string query = "SELECT * FROM [dbo].[SensorData] ORDER BY TimeStamp DESC";
                DataTable dataTable = azureConnection.ReadDataFromSql(query);
                dgvSQLDatabase.DataSource = dataTable;
                TableTimer.Interval = 50000;

                string alarmQuery = "Select * from SeeAlarms";
                DataTable alarmDataTable = azureConnection.ReadDataFromSql(alarmQuery);
                dgvLog.DataSource = alarmDataTable;
                TableTimer.Interval = 5000;
            }
        }

        private void btnAzureConnection_Click(object sender, EventArgs e)
        {
            azureConnection = new AzureConnection();
            if (azureConnection.Connect())
            {
                MessageBox.Show("Connected to Azure SQL Database");

            }
            else
            {
                MessageBox.Show("Failed to connect to Azure SQL Database");
            }

            TableTimer.Enabled = true;
        }


        private void btnAzureDisconnection_Click(object sender, EventArgs e)
        {
            if (azureConnection != null)
            {
                azureConnection.Disconnect();



                MessageBox.Show("Disconnected from Azure SQL Database");
                // Disable or reset UI elements for data retrieval
            }
            else
            {
                MessageBox.Show("No active connection to disconnect");
            }
        }

        public async void SensorTimer_Tick(object sender, EventArgs e)
        {
            Alarm alarm = new Alarm();
            string temperatureInside = string.Empty, temperatureOutside = string.Empty, 
                    pumpLevel = string.Empty,doorStatus = string.Empty;

            if (socketCommunication != null)
            {
                try
                {
                    temperatureInside = txtInsideTemprature.Text;
                    temperatureOutside = txtOutsideTemprature.Text;
                    doorStatus = txtDoorStatus.Text;
                    pumpLevel= txtHeatPumpStatus.Text;

                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                alarm.GenerateAlarm(temperatureInside, temperatureOutside,pumpLevel);
            }
        }

        public string ReturnDoorStatus(string value)
        {
            string doorStatus = string.Empty;
            if (value == "1")
            {
                doorStatus = "Open";
            }
            else
            {
                doorStatus = "Closed";
            }
            return doorStatus;
        }
        public void ChangeLight(string value)
        {
            if (value == "1")
            {
                picLightStatus.ImageLocation = "light_on.png";
            }
            else
            {
                picLightStatus.ImageLocation = "light_off.png";
            }
        }
        private async void btnStartLogging_Click(object sender, EventArgs e)
        {
            socketCommunication = new SocketCommunication();
            await socketCommunication.StartReceivingFromServerAsync();
            SocketTimer.Enabled = true;
        }

        private void btnStopLogging_Click(object sender, EventArgs e)
        {
            // Stop the message receiving loop
            socketCommunication?.StopReceivingFromServer();
            socketCommunication?.Dispose();
            socketCommunication = null;
            SocketTimer.Enabled = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string deviceName = string.Empty, alarmName = string.Empty;

            // If the "Acknowledge" button is clicked, update the alarm status.
            if (dgvLog.CurrentRow != null)
            {
                // Get the row index of the selected row.
                int rowIndex = dgvLog.CurrentRow.Index;
                // Get the alarm ID from the selected row.
                deviceName = dgvLog.Rows[rowIndex].Cells[0].Value.ToString();
                alarmName = dgvLog.Rows[rowIndex].Cells[1].Value.ToString();

                // Assuming azureConnection has a method ExecuteStoredProcedure
                if (azureConnection != null)
                {
                    // Call the stored procedure to acknowledge alarms
                    string storedProcedureName = "AcknowledgeAlarmsForAlarmName";
                    azureConnection.ExecuteStoredProcedure(storedProcedureName,
                        new SqlParameter("@DeviceName", deviceName),
                        new SqlParameter("@AlarmName", alarmName));

                    // Refresh the DataGridView to display the updated alarm status.
                    RefreshDataGridView();
                }
            }
        }

        private void RefreshDataGridView()
        {
            // Assuming you have a method to refresh your DataGridView
            string alarmQuery = "Select * from SeeAlarms";
            DataTable alarmDataTable = azureConnection.ReadDataFromSql(alarmQuery);
            dgvLog.DataSource = alarmDataTable;
            dgvLog.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string deviceName = string.Empty, alarmName = string.Empty;

            // If the "Acknowledge" button is clicked, update the alarm status.
            if (dgvLog.CurrentRow != null)
            {
                // Get the row index of the selected row.
                int rowIndex = dgvLog.CurrentRow.Index;
                // Get the alarm ID from the selected row.
                deviceName = dgvLog.Rows[rowIndex].Cells[0].Value.ToString();
                alarmName = dgvLog.Rows[rowIndex].Cells[1].Value.ToString();

                // Assuming azureConnection has a method ExecuteStoredProcedure
                if (azureConnection != null)
                {
                    // Call the stored procedure to acknowledge alarms
                    string storedProcedureName = "DeleteAcknowledgedAlarms";
                    azureConnection.ExecuteStoredProcedure(storedProcedureName,
                        new SqlParameter("@DeviceName", deviceName),
                        new SqlParameter("@AlarmName", alarmName));

                    // Refresh the DataGridView to display the updated alarm status.
                    RefreshDataGridView();
                }
            }
        }

        private async void timer1_Tick_2(object sender, EventArgs e)
        {

            if (socketCommunication != null)
            {
                try
                {
                    string[] text;
                    await socketCommunication.CollectValuesAsync();
                    text = socketCommunication.CurrentString.Split(',');

                    txtInsideTemprature.Text = text[0].Split(':')[1];
                    txtOutsideTemprature.Text = text[1].Split(':')[1];
                    txtDoorStatus.Text = ReturnDoorStatus(text[3].Split(':')[1]);
                    txtHeatPumpStatus.Text = text[5].Split(':')[1].Split('}')[0] + "%";

                    ChangeLight(text[2].Split(':')[1]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error collecting values: {ex.Message}");
                }
            }

        }

        private void btnOpenDoor_Click(object sender, EventArgs e)
        {
            azureConnection.SendToIoTHub("OPEN_DOOR");
        }

        private void btnTogglePorcheLight_Click(object sender, EventArgs e)
        {
            azureConnection.SendToIoTHub("LIGHT_ON");
        }
        public void CheckPorchStatus()
        {
            if (rbPorchLightLocal.Checked)
            {
                azureConnection.SendToIoTHub("LOCAL_LIGHT");
                btnPorcheLightOn.Enabled = true;
                btnPorceLightOff.Enabled = true;
            }
            else if (rbPorchLightAuto.Checked)
            {
                azureConnection.SendToIoTHub("AUTO_LIGHT");
                btnPorcheLightOn.Enabled = false;
                btnPorceLightOff.Enabled = false;
            }
        }

        private void btnPorceLightOff_Click(object sender, EventArgs e)
        {
            azureConnection.SendToIoTHub("LIGHT_OFF");
        }

        private void SendingTimer_Tick(object sender, EventArgs e)
        {
            CheckPorchStatus();
        }

        private void rbPorchLightLocal_CheckedChanged(object sender, EventArgs e)
        {
            SendingTimer.Enabled = true;
        }

        private void StartDoorTimer()
        {
           
        }
    }
}
