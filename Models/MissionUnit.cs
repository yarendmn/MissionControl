using System;
using System.Collections.Generic;
using System.Text;

namespace MissionControl.Models
{
    public class MissionUnit
    {
        public int Id { get; set; }
        public string Name { get; set;}
       
        public bool IsAvailable { get; set; }
        public Mission CurrentMission { get; set; }

        private double batteryLevel;

        public double BatteryLevel
        {
            get { return batteryLevel; }
            set
            {
                if (value < 0)
                {
                    batteryLevel = 0;
                }
                else if(value > 100)
                {
                    batteryLevel = 100;
                }
                else
                {
                    batteryLevel = value;
                }
            }
        }

        public MissionUnit(int id, string name)
        {
            Id = id;
            Name = name;
            BatteryLevel = 100.0;
            CurrentMission = null;
        }

        public virtual void GetOperationalStatus()
        {
        }
    }
}
