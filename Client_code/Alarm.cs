using Microsoft.Azure.Devices.Client;
using System;
using System.Data;
using System.Data.SqlClient;
namespace Smart_building
{
    public class Alarm
    {
        private const double TemperatureInsideHighThreshold = 25.0; 
        private const double TemperatureInsideLowThreshold = 16.0;  
        private const double TemperatureOutsideHighThreshold = 30.0; 
        private const double TemperatureOutsideLowThreshold = 5.0; 

        public AzureConnection azureConnection = new AzureConnection(); // Create an instance of AzureConnection

        public void CheckHeatPumpTemperature(double heatPumpTemperature)
        {
            DateTime currentTime = DateTime.Now;


        }
        public void GenerateAlarm(string temperatureInsideS, string temperatureOutsideS, string pumpLevelS)
        {
            DateTime currentTime = DateTime.Now;

            double temperatureInside = 0.0, temperatureOutside = 0.0;

            temperatureInside = Convert.ToDouble(temperatureInsideS.Replace('.', ','));
            temperatureOutside = Convert.ToDouble(temperatureOutsideS.Replace('.', ','));

            //Check temperature conditions
            if ((temperatureInside > TemperatureInsideHighThreshold))
            {
                azureConnection.StoreAlarm(currentTime, "Too hot inside", "TMP36");
            }

            if ((temperatureInside < TemperatureInsideLowThreshold))
            {
                azureConnection.StoreAlarm(currentTime, "Too cold inside", "TMP36");
            }

            if ((temperatureOutside > TemperatureOutsideHighThreshold))
            {
                azureConnection.StoreAlarm(currentTime, "Too hot outside", "Thermistor");
            }

            if ((temperatureInside < TemperatureInsideLowThreshold)) //TemperatureOutsideLowThreshold))
            {
                azureConnection.StoreAlarm(currentTime, "Too cold outside", "Thermistor");
            }

            if (Convert.ToInt32(pumpLevelS.Split('%')[0])>= 90)
            {
                azureConnection.StoreAlarm(currentTime, "Heat Pump Consumption", "Heat Pump");
            }
        }





    }



}