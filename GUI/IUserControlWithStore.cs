using System.Drawing;
using System.Windows.Forms;
using Core;

namespace GUI
{
    public class UserControlWithStore : UserControl
    {
        private IStore store;
        public IStore Store
        {
            set
            {
                store = value;
                if(StoreChanged != null)
                    StoreChanged();
            }
            protected get { return store; }
        }

        public event StoreChangedEventHandler StoreChanged;

        public Size SizeToStart { get; set; }
    }

    public delegate void StoreChangedEventHandler();
}