using MissionControl.InterFaces;
using System;

namespace MissionControl.Models
{
    public class ObservationStation : MissionUnit, ICommunicable, ISensorProvider
    {
        public ObservationStation(int id, string name) : base(id, name) { }

        public override void GetOperationalStatus()
        {
            Console.WriteLine(Name);
            Console.WriteLine("Sensor status: Active");
        }

        public void SendMessage() => Console.WriteLine($"{Name} mesaj iletiyor.");
        public void ReceiveMessage() => Console.WriteLine($"{Name} mesaj alıyor.");
        public void ReadSensor() => Console.WriteLine($"{Name} radar taraması yapıyor.");
    }
}
