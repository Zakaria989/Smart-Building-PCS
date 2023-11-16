using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_building
{
    internal class SimulationManager
    {
        public Sensor TemperatureSensor { get; }
        public Actuator LightActuator { get; }

        private double simulatedInsideTemperature;

        private double simulatedOutsideTemperature;

        private TextBox txtInsideTemprature;

        private TextBox txtOutsideTemprature;

        public SimulationManager(TextBox textBox, TextBox textBox2)
        {
            TemperatureSensor = new Sensor("TemperatureSensor");
            LightActuator = new Actuator("LightActuator");
            txtInsideTemprature = textBox;
            txtOutsideTemprature = textBox2;
            simulatedInsideTemperature = GenerateInitialInsideTemperature();
            simulatedOutsideTemperature = GenerateInitialOutsideTemperature();
        }

        public void Simulate()
        {
            simulatedInsideTemperature = GenerateSimulatedInsideTemperature();
            TemperatureSensor.UpdateValue(simulatedInsideTemperature);
            simulatedOutsideTemperature = GenerateSimulatedOutsideTemperature();
            TemperatureSensor.UpdateValue(simulatedOutsideTemperature);

            // Update the TextBox
            txtInsideTemprature.Invoke(new Action(() => txtInsideTemprature.Text = simulatedInsideTemperature.ToString("F2")));
            txtOutsideTemprature.Invoke(new Action(() => txtOutsideTemprature.Text = simulatedOutsideTemperature.ToString("F2")));
        }

        private double GenerateInitialInsideTemperature()
        {
            // Initialize the initial temperature value
            return 21.0;
        }

        private double GenerateSimulatedInsideTemperature()
        {
            double amplitude = 2.0;
            double offset = 21.0;
            double frequency = 0.1;
            double time = DateTime.Now.Second;
            return amplitude * Math.Sin(2 * Math.PI * frequency * time) + offset;
        }

        private double GenerateInitialOutsideTemperature()
        {
            // Initialize the initial temperature value
            return 15.0;
        }

        private double GenerateSimulatedOutsideTemperature()
        {
            double amplitude = 5.0;
            double offset = 15.0;
            double frequency = 0.1;
            double time = DateTime.Now.Second;
            return amplitude * Math.Sin(2 * Math.PI * frequency * time) + offset;
        }
    }
}

