using System;
using System.Windows.Forms;

namespace GUI
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
            var form = new FormRegisterHours
            {
                Store = new RavenStore()
            };

            var startView = new UserControlAddWriteEvent();
            form.AddView(startView);
            form.AddView(new UserControlShowRecords());
            form.AddView(new UserControlEditRecords());
            form.SetNextState(startView);
            
            Application.Run(form);
        }
    }
}