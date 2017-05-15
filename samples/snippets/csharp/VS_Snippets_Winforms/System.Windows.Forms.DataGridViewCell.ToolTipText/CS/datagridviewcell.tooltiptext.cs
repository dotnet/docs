using System;
using System.Windows.Forms;

class Form1 : Form
{
    private DataGridView dataGridView1 = new DataGridView();

    [STAThreadAttribute()]
    public static void Main()
    {
        Application.Run(new Form1());
    }

    public Form1()
    {
        this.dataGridView1.Dock = DockStyle.Fill;
        // Set the column header names.
        this.dataGridView1.ColumnCount = 5;
        this.dataGridView1.Columns[0].Name = "Recipe";
        this.dataGridView1.Columns[1].Name = "Category";
        this.dataGridView1.Columns[2].Name = "Main Ingredients";
        this.dataGridView1.Columns[3].Name = "Last Fixed";
        this.dataGridView1.Columns[4].Name = "Rating";

        // Populate the rows.
        object[] row1 = new object[]{"Meatloaf", 
            "Main Dish", "ground beef", new DateTime(2000, 3, 23), "*"};
        object[] row2 = new object[]{"Key Lime Pie", 
            "Dessert", "lime juice, evaporated milk", new DateTime(2002, 4, 12), "****"};
        object[] row3 = new object[]{"Orange-Salsa Pork Chops", 
            "Main Dish", "pork chops, salsa, orange juice", new DateTime(2000, 8, 9), "****"};
        object[] row4 = new object[]{"Black Bean and Rice Salad", 
            "Salad", "black beans, brown rice", new DateTime(1999, 5, 7), "****"};
        object[] row5 = new object[]{"Chocolate Cheesecake", 
            "Dessert", "cream cheese", new DateTime(2003, 3, 12), "***"};
        object[] row6 = new object[]{"Black Bean Dip", "Appetizer",
            "black beans, sour cream", new DateTime(2003, 12, 23), "***"};
        object[] rows = new object[] { row1, row2, row3, row4, row5, row6 };

        foreach (object[] rowArray in rows)
        {
            this.dataGridView1.Rows.Add(rowArray);
        }
        this.Controls.Add(this.dataGridView1);
        this.Text = "DataGridView cell ToolTip demo";
        this.dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
    }


    //<Snippet1>
    // Sets the ToolTip text for cells in the Rating column.
    void dataGridView1_CellFormatting(object sender, 
        DataGridViewCellFormattingEventArgs e)
    {
        if ( (e.ColumnIndex == this.dataGridView1.Columns["Rating"].Index)
            && e.Value != null )
        {
            DataGridViewCell cell = 
                this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (e.Value.Equals("*"))
            {                
                cell.ToolTipText = "very bad";
            }
            else if (e.Value.Equals("**"))
            {
                cell.ToolTipText = "bad";
            }
            else if (e.Value.Equals("***"))
            {
                cell.ToolTipText = "good";
            }
            else if (e.Value.Equals("****"))
            {
                cell.ToolTipText = "very good";
            }
        }
    }
    //</Snippet1>
}
