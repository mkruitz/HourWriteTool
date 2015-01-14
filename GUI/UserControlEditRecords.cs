using System.Drawing;
using Core;

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
            get { return new Size(462, 577); }
        }

        private void OnStoreChanged()
        {
            dataGridView.DataSource = Store.GetEvents();
        }

        private void dataGridView_CellValueChanged(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            var x = (dataGridView.CurrentRow.DataBoundItem as HourWriteEvent);
            Store.Save(x);
        }
    }
}
