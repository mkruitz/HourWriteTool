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
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
            checkBoxPauze.Enabled = true;
        }

        private void checkBoxPauze_CheckedChanged(object sender, EventArgs e)
        {
            Save(checkBoxPauze.Checked
                ? HourWriteType.StartPauze
                : HourWriteType.StopPauze
                );
            buttonStop.Enabled = !checkBoxPauze.Checked;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Save(HourWriteType.StopWork);
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
            checkBoxPauze.Enabled = false;
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
            listBoxRecords.DataSource = Store.GetEvents();
        }

        private void FormRegisterHours_Load(object sender, EventArgs e)
        {
            listBoxRecords.DataSource = Store.GetEvents();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Store.Clear();
        }
    }
}
