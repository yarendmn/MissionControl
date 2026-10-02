using System;
using System.Collections.Generic;
using System.Text;
using MissionControl.Models;

namespace MissionControl.InterFaces
{
    public interface IMissionCapable
    {
        void StartMission(Mission mission);
        void CompleteMission();
    }
}
