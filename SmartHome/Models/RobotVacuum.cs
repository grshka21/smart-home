using System;

namespace SmartHome.Models
{
    public class RobotVacuum : SmartDevice
    {
        public int BatteryLevel { get; private set; }

        public RobotVacuum(string name, int batteryLevel) : base(name)
        {
            BatteryLevel = Math.Max(0, Math.Min(100, batteryLevel));
        }

        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine($"  Уровень заряда: {BatteryLevel}% — начинаю уборку");
        }

        public override string GetStatus()
        {
            string state = IsOn ? "вкл" : "выкл";
            return $"{Name} — {state}, заряд {BatteryLevel}%";
        }

        public override double GetPowerConsumption()
        {
            return IsOn ? 65.0 : 5.0;
        }
    }
}
