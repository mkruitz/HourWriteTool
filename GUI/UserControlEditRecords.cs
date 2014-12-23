using System;
using System.Drawing;
using System.Windows.Forms;
using Core;

namespace GUI
{
    public partial class UserControlEditRecords : UserControlWithStore
    {
        public UserControlEditRecords()
        {
            InitializeComponent();
            StoreChanged += OnStoreChanged;
            DefaultSize = new Size(388, 273);
        }

        private void OnStoreChanged()
        {
            dataGridView.DataSource = Store.GetEvents();
        }
    }
}
