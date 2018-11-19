using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DeletegateAndEventDiff.ClsPicture;

namespace DeletegateAndEventDiff
{
    /// <summary>
    /// an interface can declare event func attribute field
    /// </summary>
    public interface myInterface
    {
        event UpdateStatusHandle updateStatusText;
        event StartUpdateHandle startUpdataHandle;
    }
}
