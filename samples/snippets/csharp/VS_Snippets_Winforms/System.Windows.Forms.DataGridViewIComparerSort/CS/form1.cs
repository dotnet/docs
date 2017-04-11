//<snippet00>
#region Using directives

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion

class Form1 : Form
{
    private DataGridView DataGridView1 = new DataGridView();
    private FlowLayoutPanel FlowLayoutPanel1 = new FlowLayoutPanel();
    private Button Button1 = new Button();
    private RadioButton RadioButton1 = new RadioButton();
    private RadioButton RadioButton2 = new RadioButton();

    // Establish the main entry point for the application.
    [STAThreadAttribute()]
    public static void Main()
    {
        Application.Run(new Form1());
    }

    public Form1()
    {
        // Initialize the form.
        // This code can be replaced with designer generated code.
        AutoSize = true;
        Text = "DataGridView IComparer sort demo";

        FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
        FlowLayoutPanel1.Location = new System.Drawing.Point( 304, 0 );
        FlowLayoutPanel1.AutoSize = true;

        FlowLayoutPanel1.Controls.Add( RadioButton1 );
        FlowLayoutPanel1.Controls.Add( RadioButton2 );
        FlowLayoutPanel1.Controls.Add( Button1 );

        Button1.Text = "Sort";
        RadioButton1.Text = "Ascending";
        RadioButton2.Text = "Descending";
        RadioButton1.Checked = true;

        Controls.Add( FlowLayoutPanel1 );
        Controls.Add( DataGridView1 );
    }

    protected override void OnLoad( EventArgs e )
    {
        PopulateDataGridView();
        Button1.Click += new EventHandler(Button1_Click);

        base.OnLoad( e );
    }

    // Replace this with your own code to populate the DataGridView.
    private void PopulateDataGridView()
    {

        DataGridView1.Size = new Size(300, 300);

        // Add columns to the DataGridView.
        DataGridView1.ColumnCount = 2;

        // Set the properties of the DataGridView columns.
        DataGridView1.Columns[0].Name = "First";
        DataGridView1.Columns[1].Name = "Last";
        DataGridView1.Columns["First"].HeaderText = "First Name";
        DataGridView1.Columns["Last"].HeaderText = "Last Name";
        DataGridView1.Columns["First"].SortMode = 
            DataGridViewColumnSortMode.Programmatic;
        DataGridView1.Columns["Last"].SortMode = 
            DataGridViewColumnSortMode.Programmatic;

        // Add rows of data to the DataGridView.
        DataGridView1.Rows.Add(new string[] { "Peter", "Parker" });
        DataGridView1.Rows.Add(new string[] { "James", "Jameson" });
        DataGridView1.Rows.Add(new string[] { "May", "Parker" });
        DataGridView1.Rows.Add(new string[] { "Mary", "Watson" });
        DataGridView1.Rows.Add(new string[] { "Eddie", "Brock" });
    }

    //<snippet10>
    private void Button1_Click( object sender, EventArgs e )
    {
        if ( RadioButton1.Checked == true )
        {
            DataGridView1.Sort( new RowComparer( SortOrder.Ascending ) );
        }
        else if ( RadioButton2.Checked == true )
        {
            DataGridView1.Sort( new RowComparer( SortOrder.Descending ) );
        }
    }

    private class RowComparer : System.Collections.IComparer
    {
        private static int sortOrderModifier = 1;

        public RowComparer(SortOrder sortOrder)
        {
            if (sortOrder == SortOrder.Descending)
            {
                sortOrderModifier = -1;
            }
            else if (sortOrder == SortOrder.Ascending)
            {
                sortOrderModifier = 1;
            }
        }

        public int Compare(object x, object y)
        {
            DataGridViewRow DataGridViewRow1 = (DataGridViewRow)x;
            DataGridViewRow DataGridViewRow2 = (DataGridViewRow)y;

            // Try to sort based on the Last Name column.
            int CompareResult = System.String.Compare(
                DataGridViewRow1.Cells[1].Value.ToString(),
                DataGridViewRow2.Cells[1].Value.ToString());

            // If the Last Names are equal, sort based on the First Name.
            if ( CompareResult == 0 )
            {
                CompareResult = System.String.Compare(
                    DataGridViewRow1.Cells[0].Value.ToString(),
                    DataGridViewRow2.Cells[0].Value.ToString());
            }
            return CompareResult * sortOrderModifier;
        }
    }
    //</snippet10>
}
//</snippet00>