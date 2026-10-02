using System;
using System.Collections.Generic;
using System.Text;

namespace MissionControl.InterFaces
{
    public interface ICommunicable
    {
        void SendMessage();
        void ReceiveMessage();
    }
}
