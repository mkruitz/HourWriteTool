using System.Data;
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
        }

        public override string Title
        {
            get { return "Edit Records"; }
        }

        public override Size SizeToStart
        {
            get { return new Size(564, 577); }
        }

        private void OnStoreChanged()
        {
            dataGridView.DataSource = Store.GetEvents();
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var updatedEvent = (dataGridView.CurrentRow.DataBoundItem as HourWriteEvent);
            if(updatedEvent != null)
                Store.Save(updatedEvent);
        }
    }
}
