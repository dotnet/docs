//<Snippet4>
using System.Windows.Forms;

namespace CS
{
    [System.ComponentModel.ComplexBindingProperties("DataSource", "DataMember")]
    public partial class ComplexDataGridView : UserControl
    {
        public object DataSource
        {
            get{ return dataGridView1.DataSource; }
            set{ dataGridView1.DataSource = value; }
        }

        public string DataMember
        {
            get{ return dataGridView1.DataMember; }
            set{ dataGridView1.DataMember = value; }
        }

        public ComplexDataGridView()
        {
            InitializeComponent();
        }
    }
}
//</Snippet4>
