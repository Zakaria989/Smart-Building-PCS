using Microsoft.Azure.Devices.Client;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System;
using System.Net;
using System.Windows.Forms;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;

namespace Smart_building
{
    public class AzureConnection
    {
        // Azure SQL Database connection string
        private string sqlConnectionString = "";
        // Azure IoT Hub connection string
        private string iotHubConnectionString = "";

        private SqlConnection sqlConnection;
        private DeviceClient iotHubClient;
        private ServiceClient serviceClient;
        public string ValuesFromArduino = string.Empty;


        public AzureConnection()
        {
            sqlConnection = new SqlConnection(sqlConnectionString);
            iotHubClient = DeviceClient.CreateFromConnectionString(iotHubConnectionString, Microsoft.Azure.Devices.Client.TransportType.Mqtt);
            serviceClient = ServiceClient.CreateFromConnectionString(iotHubConnectionString);
        }

        public bool Connect()
        {
            try
            {
                sqlConnection.Open();
                // IoT Hub connection does not require explicit connection here
                return true;
            }
            catch (Exception ex)
            {
                // Handle connection error
                Console.WriteLine("Error connecting to Azure services: " + ex.Message);
                return false;
            }
        }

        public void Disconnect()
        {
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }

            if (iotHubClient != null)
            {
                iotHubClient.CloseAsync().Wait();
            }
        }

        // Other methods for reading from SQL and sending messages to IoT Hub can be added here.

        public DataTable ReadDataFromSql(string query)
        {
            DataTable dataTable = new DataTable();
            DataTable alarmDataTable = new DataTable();
            try
            {
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        adapter.Fill(alarmDataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving data from SQL: " + ex.Message);
            }
            return dataTable;
        }



        public async void SendToIoTHub(string message)
        {
            var payload = new Microsoft.Azure.Devices.Message(Encoding.UTF8.GetBytes(message));
            await serviceClient.SendAsync("Arduino",payload);

        }

        public void StoreAlarm(DateTime timestamp, string alarmName, string deviceName)
        {
            string alarmStatus = "Not Acknowledged"; // You can set an appropriate alarm status
            string alarmActive = "True"; // You can set whether the alarm is active

            // Store the alarm in the SQL database

            Connect();

            string sql = "INSERT INTO Alarm (Timestamp, AlarmName, DeviceName, AlarmStatus, AlarmActive) " +
                         "VALUES (@Timestamp, @AlarmName, @DeviceName, @AlarmStatus, @AlarmActive)";
            using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@Timestamp", timestamp);
                cmd.Parameters.AddWithValue("@AlarmName", alarmName);
                cmd.Parameters.AddWithValue("@DeviceName", deviceName);
                cmd.Parameters.AddWithValue("@AlarmStatus", alarmStatus);
                cmd.Parameters.AddWithValue("@AlarmActive", alarmActive);
                cmd.ExecuteNonQuery();
            }
        }
        public void ExecuteStoredProcedure(string storedProcedureName, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlCommand command = new SqlCommand(storedProcedureName, sqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters);

                    Connect(); // Assuming this method opens the SQL connection if not already open

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing stored procedure: " + ex.Message);
            }
        }

        public void updateAlarm(DateTime timestamp)
        {
            string alarmStatus = "Acknowledged"; // You can set an appropriate alarm status
            string alarmActive = "False"; // You can set whether the alarm is active

            // Store the alarm in the SQL database

            Connect();

            string sql = "INSERT INTO Alarm (Timestamp, AlarmName, DeviceName, AlarmStatus, AlarmActive) " +
                         "VALUES (@Timestamp, @AlarmName, @DeviceName, @AlarmStatus, @AlarmActive)";
            using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
            {

                cmd.Parameters.AddWithValue("@AlarmStatus", alarmStatus);
                cmd.Parameters.AddWithValue("@AlarmActive", alarmActive);
                cmd.ExecuteNonQuery();
            }

        }


    }
}
