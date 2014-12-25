using System.Drawing;

namespace GUI
{
    public partial class UserControlShowRecords : UserControlWithStore
    {
        public UserControlShowRecords()
        {
            InitializeComponent();
            StoreChanged += OnStoreChanged;
        }

        public override string Title
        {
            get { return "Show Records"; }
        }

        public override Size SizeToStart
        {
            get { return new Size(246, 295); }
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
