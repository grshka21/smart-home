using System;

namespace SmartHome.Models
{
    public class SecurityCamera : SmartDevice, IRecordable
    {
        public bool IsRecording { get; private set; }

        public SecurityCamera(string name) : base(name) { }

        public override void TurnOn()
        {
            base.TurnOn();
            StartRecording();
        }

        public override void TurnOff()
        {
            if (IsRecording) StopRecording();
            base.TurnOff();
        }

        public void StartRecording()
        {
            IsRecording = true;
            Console.WriteLine($"  {Name}: запись видео начата");
        }

        public void StopRecording()
        {
            IsRecording = false;
            Console.WriteLine($"  {Name}: запись видео остановлена");
        }

        public override string GetStatus()
        {
            string state = IsOn ? "вкл" : "выкл";
            string rec = IsRecording ? "идёт" : "нет";
            return $"{Name} — {state}, запись: {rec}";
        }

        public override double GetPowerConsumption()
        {
            return IsOn ? 12.0 : 0;
        }
    }
}
