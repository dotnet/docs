//<Snippet1>
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

namespace ListViewSortFormNamespace
{
    
   
    public class ListViewSortForm : Form
    {
        private ListView listView1;
       
        public ListViewSortForm()
        {
            // Create ListView items to add to the control.
            ListViewItem listViewItem1 = new ListViewItem(new string[] {"Banana","a","b","c"}, -1, Color.Empty, Color.Yellow, null);
            ListViewItem listViewItem2 = new ListViewItem(new string[] {"Cherry","v","g","t"}, -1, Color.Empty, Color.Red, new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((System.Byte)(0))));
            ListViewItem listViewItem3 = new ListViewItem(new string[] {"Apple","h","j","n"}, -1, Color.Empty, Color.Lime, null);
            ListViewItem listViewItem4 = new ListViewItem(new string[] {"Pear","y","u","i"}, -1, Color.Empty, Color.FromArgb(((System.Byte)(192)), ((System.Byte)(128)), ((System.Byte)(156))), null);
     
            //Initialize the ListView control and add columns to it.
            this.listView1 = new ListView();

            // Set the initial sorting type for the ListView.
            this.listView1.Sorting = SortOrder.None;
            // Disable automatic sorting to enable manual sorting.
            this.listView1.View = View.Details;
            // Add columns and set their text.
            this.listView1.Columns.Add(new ColumnHeader());
            this.listView1.Columns[0].Text = "Column 1";
            this.listView1.Columns[0].Width = 100;
            listView1.Columns.Add(new ColumnHeader());
            listView1.Columns[1].Text = "Column 2";
            listView1.Columns.Add(new ColumnHeader());
            listView1.Columns[2].Text = "Column 3";
            listView1.Columns.Add(new ColumnHeader());
            listView1.Columns[3].Text = "Column 4";
            // Suspend control logic until form is done configuring form.
            this.SuspendLayout();
            // Add Items to the ListView control.
            this.listView1.Items.AddRange(new ListViewItem[] {listViewItem1,
                listViewItem2,
                listViewItem3,
                listViewItem4});
            // Set the location and size of the ListView control.
            this.listView1.Location = new Point(10, 10);
            this.listView1.Name = "listView1";
            this.listView1.Size = new Size(300, 100);
            this.listView1.TabIndex = 0;
            // Enable editing of the items in the ListView.
            this.listView1.LabelEdit = true;
            // Connect the ListView.ColumnClick event to the ColumnClick event handler.
            this.listView1.ColumnClick += new ColumnClickEventHandler(ColumnClick);
   			
            // Initialize the form.
            this.ClientSize = new Size(400, 400);
            this.Controls.AddRange(new Control[] {this.listView1});
            this.Name = "ListViewSortForm";
            this.Text = "Sorted ListView Control";
            // Resume layout of the form.
            this.ResumeLayout(false);
        }
        
	
        // ColumnClick event handler.
        private void ColumnClick(object o, ColumnClickEventArgs e)
        {
            // Set the ListViewItemSorter property to a new ListViewItemComparer 
            // object. Setting this property immediately sorts the 
            // ListView using the ListViewItemComparer object.
            this.listView1.ListViewItemSorter = new ListViewItemComparer(e.Column);
        }

        [System.STAThreadAttribute()]
        public static void Main()
        {
            Application.Run(new ListViewSortForm());
        }

    }

    // Implements the manual sorting of items by columns.
    class ListViewItemComparer : IComparer
    {
        private int col;
        public ListViewItemComparer()
        {
            col = 0;
        }
        public ListViewItemComparer(int column)
        {
            col = column;
        }
        public int Compare(object x, object y)
        {
            return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
        }
    }

}
//</Snippet1>
