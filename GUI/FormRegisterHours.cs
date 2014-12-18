using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Core;

namespace GUI
{
    public partial class FormRegisterHours : Form
    {
        private enum ViewState
        {
            WriteHour,
        }

        private void SetNextState(ViewState nextState)
        {
            panelMain.Controls.Clear();
            var newView = views[nextState];
            newView.Parent = panelMain;
            newView.Dock = DockStyle.Fill;
            panelMain.Controls.Add(newView);
            
            CurrentState = nextState;
        }

        private ViewState CurrentState { get; set; }
        private readonly Dictionary<ViewState, UserControlWithStore> views;
        public IStore Store { set; private get; }

        public FormRegisterHours()
        {
            views = new Dictionary<ViewState, UserControlWithStore>
            {
                {ViewState.WriteHour, new UserControlAddWriteEvent()}
            };

            InitializeComponent();
            SetNextState(ViewState.WriteHour);
            /*selectedUserControl = new UserControlAddWriteEvent {Parent = this, Dock = DockStyle.Fill};
            Controls.Remove(menuStrip);
            Controls.Add(selectedUserControl);
            Controls.Add(menuStrip);
             * */
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
