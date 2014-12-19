using System;

namespace GUI
{
    public partial class UserControlShowRecords : UserControlWithStore
    {
        public UserControlShowRecords()
        {
            InitializeComponent();
            StoreChanged += OnStoreChanged;
        }

        private void OnStoreChanged()
        {
            listBoxRecords.DataSource = null;
            if (Store != null)
            {
                listBoxRecords.DataSource = Store.GetEvents();
            }
        }
    }
}
