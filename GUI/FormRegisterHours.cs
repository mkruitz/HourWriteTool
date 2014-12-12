using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormRegisterHours : Form
    {
        public FormRegisterHours()
        {
            InitializeComponent();
        }

        private void FormRegisterHours_Resize(object sender, EventArgs e)
        {
            ShowInTaskbar = WindowState != FormWindowState.Minimized;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }
    }
}
