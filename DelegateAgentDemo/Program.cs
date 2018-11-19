using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventAgentDemo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// TODO:将子窗体数据通过事件代理传给主窗体
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
