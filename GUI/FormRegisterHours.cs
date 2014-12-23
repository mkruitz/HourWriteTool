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
            ShowRecords,
            EditRecords,
            ClearAll
        }

        private readonly Dictionary<ViewState, UserControlWithStore> views;
        public IStore Store { set; private get; }

        public FormRegisterHours()
        {
            views = new Dictionary<ViewState, UserControlWithStore>
            {
                { ViewState.WriteHour, new UserControlAddWriteEvent() },
                { ViewState.ShowRecords, new UserControlShowRecords() },
                { ViewState.EditRecords, new UserControlEditRecords() }
            };

            InitializeComponent();
        }

        public void Init()
        {
            SetNextState(ViewState.WriteHour);   
        }

        private void SetNextState(ViewState nextState)
        {
            panelMain.Controls.Clear();
            var newView = views[nextState];
            Height += newView.SizeToStart.Height - panelMain.Height;
            Width += newView.SizeToStart.Width - panelMain.Width;
            newView.Parent = panelMain;
            newView.Dock = DockStyle.Fill;
            newView.Store = Store;
            panelMain.Controls.Add(newView);
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
            MessageBox.Show("Disabled");
            //Store.Clear();
        }

        private void showAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetNextState(ViewState.ShowRecords);
        }

        private void basicInputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetNextState(ViewState.WriteHour);
        }

        private void editAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetNextState(ViewState.EditRecords);
        }
    }
}
