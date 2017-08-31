//<Snippet3>
using System.Windows.Forms;

namespace CS
{
    [System.ComponentModel.DefaultBindingProperty("PhoneNumber")]
    public partial class PhoneNumberBox : UserControl
    {
        public string PhoneNumber
        {
            get{ return maskedTextBox1.Text; }
            set{ maskedTextBox1.Text = value; }
        }

        public PhoneNumberBox()
        {
            InitializeComponent();
        }
    }
}
//</Snippet3>
