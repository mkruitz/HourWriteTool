using System;
using System.Windows.Forms;
using Core;

namespace GUI
{
    public partial class FormRegisterHours : Form
    {
        public IStore Store { set; private get; }

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

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Save(HourWriteType.StartWork);
        }

        private void checkBoxPauze_CheckedChanged(object sender, EventArgs e)
        {
            Save(checkBoxPauze.Checked
                ? HourWriteType.StartPauze
                : HourWriteType.StopPauze
                );
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Save(HourWriteType.StopWork);
        }

        private void Save(HourWriteType type)
        {
            Store.Save(new HourWriteEvent
            {
                HappendOn = DateTime.Now,
                Type = type,
                Remark = textBoxRemark.Text,
            });
            textBoxRemark.Clear();
        }
    }
}
