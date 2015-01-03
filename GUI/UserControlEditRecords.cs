using System.Drawing;

namespace GUI
{
    public partial class UserControlEditRecords : UserControlWithStore
    {
        public UserControlEditRecords()
        {
            InitializeComponent();
            StoreChanged += OnStoreChanged;
        }

        public override string Title
        {
            get { return "Edit Records"; }
        }

        public override Size SizeToStart
        {
            get { return new Size(388, 273); }
        }

        private void OnStoreChanged()
        {
            dataGridView.DataSource = Store.GetEvents();
        }

        private void dataGridView_CellValueChanged(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
        }
    }
}
