using System;

namespace SmartHome.Models
{
    public sealed class SmartKettle : SmartDevice
    {
        public int WaterTemperature { get; private set; }

        public SmartKettle(string name, int targetTemp = 100) : base(name)
        {
            WaterTemperature = Math.Max(40, Math.Min(100, targetTemp));
        }

        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine($"  Нагрев воды до {WaterTemperature}°C...");
        }

        public override string GetStatus()
        {
            string state = IsOn ? "вкл" : "выкл";
            return $"{Name} — {state}, целевая температура воды {WaterTemperature}°C";
        }

        public override double GetPowerConsumption()
        {
            return IsOn ? 2200.0 : 0;
        }
    }
}
