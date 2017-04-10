//<Snippet1>
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

namespace MyListControlSample
{
    public class ListBoxSample3 : Form
    {
        private ListBox ListBox1 = new ListBox();
        private Label label1 = new Label();
        private TextBox textBox1 = new TextBox();

        [STAThread]
        static void Main()
        {
            Application.Run(new ListBoxSample3());
        }

        public ListBoxSample3()
        {
            this.ClientSize = new Size(307, 206);
            this.Text = "ListBox Sample3";

            ListBox1.Location = new Point(54, 16);
            ListBox1.Name = "ListBox1";
            ListBox1.Size = new Size(240, 130);

            label1.Location = new Point(14, 150);
            label1.Name = "label1";
            label1.Size = new Size(40, 24);
            label1.Text = "Value";

            textBox1.Location = new Point(54, 150);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(240, 24);
            
            this.Controls.AddRange(new Control[] { ListBox1, label1, textBox1 });

            // <Snippet2>
            // Populate the list box using an array as DataSource.
            ArrayList USStates = new ArrayList();
            USStates.Add(new USState("Alabama", "AL"));
            USStates.Add(new USState("Washington", "WA"));
            USStates.Add(new USState("West Virginia", "WV"));
            USStates.Add(new USState("Wisconsin", "WI"));
            USStates.Add(new USState("Wyoming", "WY"));
            ListBox1.DataSource = USStates;

            // Set the long name as the property to be displayed and the short
            // name as the value to be returned when a row is selected.  Here
            // these are properties; if we were binding to a database table or
            // query these could be column names.
            ListBox1.DisplayMember = "LongName";
            ListBox1.ValueMember = "ShortName";
            //</Snippet2>

            // Bind the SelectedValueChanged event to our handler for it.
            ListBox1.SelectedValueChanged += 
                new EventHandler(ListBox1_SelectedValueChanged);

            // Ensure the form opens with no rows selected.
            ListBox1.ClearSelected();
        }

        private void InitializeComponent()
        {
        }

        // <Snippet3>
        private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ListBox1.SelectedIndex != -1)
            {
                textBox1.Text = ListBox1.SelectedValue.ToString();
                // If we also wanted to get the displayed text we could use
                // the SelectedItem item property:
                // string s = ((USState)ListBox1.SelectedItem).LongName;
            }
        }
        // </Snippet3>
    }

    public class USState
    {
        private string myShortName;
        private string myLongName;

        public USState(string strLongName, string strShortName)
        {

            this.myShortName = strShortName;
            this.myLongName = strLongName;
        }

        public string ShortName
        {
            get
            {
                return myShortName;
            }
        }

        public string LongName
        {

            get
            {
                return myLongName;
            }
        }

    }
}
// </Snippet1>