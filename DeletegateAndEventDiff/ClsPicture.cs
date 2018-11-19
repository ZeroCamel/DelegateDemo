using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeletegateAndEventDiff
{
    public class ClsPicture : myInterface
    {
        public event UpdateStatusHandle updateStatusText; 
        public delegate void UpdateStatusHandle(string status);

        public event StartUpdateHandle startUpdataHandle;
        public delegate void StartUpdateHandle();
    }
}
