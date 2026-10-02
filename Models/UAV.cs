using MissionControl.InterFaces;
using System;

namespace MissionControl.Models
{
    public class UAV : MissionUnit, IMissionCapable, ICommunicable, ISensorProvider, IRechargeable
    {
        public UAV(int id, string name) : base(id, name) { }

        public override void GetOperationalStatus()
        {
            Console.WriteLine(Name);
            Console.WriteLine($"Battery: {BatteryLevel}%");
            Console.WriteLine("Flight status: " + (IsAvailable ? "Ready" : "Active"));
        }

        public void StartMission(Mission mission)
        {
            if (this.BatteryLevel < mission.RequiredBattery)
            {
                Console.WriteLine("Mission cannot be started.");
                Console.WriteLine("Battery level is insufficient.");
            }
            else
            {
                this.BatteryLevel -= mission.RequiredBattery;
                this.IsAvailable = false;
                this.CurrentMission = mission;
                Console.WriteLine($"{Name}, {mission.MissionName} görevine başladı.");
            }
        }

        public void CompleteMission()
        {
            if (CurrentMission != null)
            {
                CurrentMission.IsCompleted = true;
                IsAvailable = true;
                Console.WriteLine($"{Name}, {CurrentMission.MissionName} görevini tamamladı.");
                CurrentMission = null;
            }
        }

        public void SendMessage() => Console.WriteLine($"{Name} mesaj iletiyor.");
        public void ReceiveMessage() => Console.WriteLine($"{Name} mesaj alıyor.");
        public void ReadSensor() => Console.WriteLine($"{Name} havadan termal sensör verilerini okuyor.");
        public void Recharge() => BatteryLevel = 100;
    }
}
