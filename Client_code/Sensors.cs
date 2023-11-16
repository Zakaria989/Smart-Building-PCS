using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_building
{
    // Sensor class
    public class Sensor
    {
        public string Name { get; set; }
        public double Value { get; private set; }

        public Sensor(string name)
        {
            Name = name;
        }

        public void UpdateValue(double simulatedValue)
        {
            Value = simulatedValue;
        }
    }

    // Actuator class
    public class Actuator
    {
        public string Name { get; set; }
        public bool IsActive { get; private set; }

        public Actuator(string name)
        {
            Name = name;
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
