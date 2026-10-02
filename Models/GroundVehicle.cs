using MissionControl.InterFaces;
using System;

namespace MissionControl.Models
{
    public class GroundVehicle : MissionUnit, IMissionCapable, ICommunicable, IRechargeable
    {
        public GroundVehicle(int id, string name) : base(id, name) { }

        public override void GetOperationalStatus()
        {
            Console.WriteLine(Name);
            Console.WriteLine($"Battery: {BatteryLevel}%");
            Console.WriteLine("Mobility status: " + (IsAvailable ? "Ready" : "Active"));
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

        public void SendMessage() => Console.WriteLine($"{Name} telsiz mesajı iletiyor.");
        public void ReceiveMessage() => Console.WriteLine($"{Name} telsiz mesajı alıyor.");
        public void Recharge() => BatteryLevel = 100;
    }
}
