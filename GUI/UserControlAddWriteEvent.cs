using System;
using System.Drawing;
using Core;

namespace GUI
{
    public partial class UserControlAddWriteEvent : UserControlWithStore
    {
        public UserControlAddWriteEvent()
        {
            InitializeComponent();
        }

        public override string Title
        {
            get { return "Write hours"; }
        }

        public override Size SizeToStart
        {
            get { return new Size(246, 92); }
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
        }
    }
}
