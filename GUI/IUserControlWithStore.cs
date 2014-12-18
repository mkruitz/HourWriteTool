using System.Windows.Forms;
using Core;

namespace GUI
{
    public class UserControlWithStore : UserControl
    {
        public IStore Store { set; protected get; }
    }
}