﻿using System;
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

        public void Init()
        {
            SetNextState(new UserControlAddWriteEvent());   
        }

        private void SetNextState(UserControlWithStore newView)
        {
            panelMain.Controls.Clear();
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
            SetNextState(new UserControlShowRecords());
        }

        private void basicInputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetNextState(new UserControlAddWriteEvent());
        }

        private void editAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetNextState(new UserControlEditRecords());
        }
    }
}
