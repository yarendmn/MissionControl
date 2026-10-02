using System;
using System.Collections.Generic;
using System.Text;

namespace MissionControl.Models
{
    public class Mission
    {
        public int MissionId { get; set; }
        public string MissionName { get; set; }
        public string Location { get; set; }
        public double RequiredBattery { get; set; }
        public bool IsCompleted { get; set; }

        public Mission(int missionId, string missionName, string location, double requiredBattery)
        {
            MissionId = missionId;
            MissionName = missionName;
            Location = location;
            RequiredBattery = requiredBattery;
            IsCompleted = false;
        }
    }
}
