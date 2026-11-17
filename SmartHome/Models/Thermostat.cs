using System;

namespace SmartHome.Models
{
    public class Thermostat : SmartDevice
    {
        public double TargetTemperature { get; private set; }

        public Thermostat(string name, double temperature) : base(name)
        {
            TargetTemperature = temperature;
        }

        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine($"  Целевая температура: {TargetTemperature}°C");
        }

        public override string GetStatus()
        {
            string state = IsOn ? "вкл" : "выкл";
            return $"{Name} — {state}, цель {TargetTemperature}°C";
        }

        public override double GetPowerConsumption()
        {
            return IsOn ? 1500.0 : 2.0;
        }
    }
}
