using System;
using System.Windows.Forms;

namespace ResultCounter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormResultCounter());
            //Application.Run(new FormCustomStage());
        }
    }
}
