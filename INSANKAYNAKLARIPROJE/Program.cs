using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INSANKAYNAKLARIPROJE
{
    internal static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string procesname = Process.GetCurrentProcess().ProcessName;
            Process[] proccesByName = Process.GetProcessesByName(procesname);

            if (proccesByName.Length > 1)
            {
                MessageBox.Show("Program zaten açık");
                return;
            }

            Application.Run(new Giris());
        }
    }
}
