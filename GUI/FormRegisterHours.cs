using System;
using System.Windows.Forms;
using Core;

namespace GUI
{
    public partial class FormRegisterHours : Form
    {
        private IStore _iStore;
        private UserControlAddWriteEvent _uc;

        public IStore Store {
            set
            {
                _iStore = value;
                _uc.Store = value;

            }
            private get { return _iStore;  } }

        public FormRegisterHours()
        {
            InitializeComponent();
            //this.SuspendLayout();
            _uc = new UserControlAddWriteEvent {Parent = this, Dock = DockStyle.Fill};
            Controls.Remove(menuStrip);
            Controls.Add(_uc);
            Controls.Add(menuStrip);
        }

        private void FormRegisterHours_Resize(object sender, EventArgs e)
        {
            ShowInTaskbar = WindowState != FormWindowState.Minimized;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
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
