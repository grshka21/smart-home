using System;

namespace SmartHome.Models
{
    public class SmartLight : SmartDevice
    {
        public int Brightness { get; private set; }

        public SmartLight(string name, int brightness) : base(name)
        {
            Brightness = Math.Max(0, Math.Min(100, brightness));
        }

        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine($"  Яркость: {Brightness}%");
        }

        public override string GetStatus()
        {
            string state = IsOn ? "вкл" : "выкл";
            return $"{Name} — {state}, яркость {Brightness}%";
        }

        public override double GetPowerConsumption()
        {
            return IsOn ? 15.0 * (Brightness / 100.0) : 0;
        }
    }
}
