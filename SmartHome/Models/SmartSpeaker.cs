using System;

namespace SmartHome.Models
{
    public class SmartSpeaker : SmartDevice
    {
        public int Volume { get; private set; }

        public SmartSpeaker(string name, int volume) : base(name)
        {
            Volume = Math.Max(0, Math.Min(100, volume));
        }

        public override string GetStatus()
        {
            string state = IsOn ? "вкл" : "выкл";
            return $"{Name} — {state}, громкость {Volume}%";
        }

        public override double GetPowerConsumption()
        {
            return IsOn ? 25.0 : 1.5;
        }
    }
}
