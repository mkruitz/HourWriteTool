using System;
using System.Drawing;
using System.Windows.Forms;
using Core;

namespace GUI
{
    public abstract class UserControlWithStore : UserControl
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

        public abstract String Title { get; }
        public abstract Size SizeToStart { get; }
    }
}