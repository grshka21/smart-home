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
        public void SetBrightness(int level)
        {
            Brightness = Math.Max(0, Math.Min(100, level));
            Console.WriteLine($"{Name}: яркость установлена на {Brightness}%");
        }

        public void SetBrightness(string preset)
        {
            switch (preset.ToLower())
            {
                case "night":
                    Brightness = 15;
                    break;
                case "evening":
                    Brightness = 40;
                    break;
                case "day":
                    Brightness = 100;
                    break;
                default:
                    Console.WriteLine($"{Name}: неизвестный пресет \"{preset}\"");
                    return;
            }
            Console.WriteLine($"{Name}: применён пресет \"{preset}\" → {Brightness}%");
        }

    }
}
