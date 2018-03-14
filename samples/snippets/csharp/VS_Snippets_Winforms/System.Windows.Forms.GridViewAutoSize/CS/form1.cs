using System;
using System.Windows.Forms;
using System.Drawing;

public class Form1 : System.Windows.Forms.Form
{
    [STAThreadAttribute()]
    public static void Main()
    {
        Application.Run(new Form1());
    }

    private Button button1 = new Button();
    private DataGridView dataGridView1 = new DataGridView();    

    public Form1() : base()
    {
        dataGridView1.Dock = DockStyle.Fill;
        this.Controls.Add(dataGridView1);

        button1.Text = "Automatically Resize Cells";
        button1.Dock = DockStyle.Top;
        button1.Click += new System.EventHandler(button1_Click);
        this.Controls.Add(button1);

        this.Size = new Size(600, 300);
        this.Load += new System.EventHandler(this.Form1_Load);
    }

    private void Form1_Load(object sender, System.EventArgs e)
    {
        InitializeDataGridView();
        InitializeContextMenu();
    }

    //<snippet2>
    //<snippet1>
    private void InitializeDataGridView()
    {
        // Create an unbound DataGridView by declaring a column count.
        dataGridView1.ColumnCount = 4;
        dataGridView1.ColumnHeadersVisible = true;

        // Set the column header style.
        DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

        columnHeaderStyle.BackColor = Color.Beige;
        columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
        dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

        // Set the column header names.
        dataGridView1.Columns[0].Name = "Recipe";
        dataGridView1.Columns[1].Name = "Category";
        dataGridView1.Columns[2].Name = "Main Ingredients";
        dataGridView1.Columns[3].Name = "Rating";

        // Populate the rows.
        string[] row1 = new string[] { "Meatloaf", "Main Dish", "ground beef",
            "**" };
        string[] row2 = new string[] { "Key Lime Pie", "Dessert", 
            "lime juice, evaporated milk", "****" };
        string[] row3 = new string[] { "Orange-Salsa Pork Chops", "Main Dish", 
            "pork chops, salsa, orange juice", "****" };
        string[] row4 = new string[] { "Black Bean and Rice Salad", "Salad", 
            "black beans, brown rice", "****" };
        string[] row5 = new string[] { "Chocolate Cheesecake", "Dessert", 
            "cream cheese", "***" };
        string[] row6 = new string[] { "Black Bean Dip", "Appetizer", 
            "black beans, sour cream", "***" };
        object[] rows = new object[] { row1, row2, row3, row4, row5, row6 };

        foreach (string[] rowArray in rows)
        {
            dataGridView1.Rows.Add(rowArray);
        }
    }

    //<snippet3>
    private void button1_Click(object sender, System.EventArgs e)
    {
        // Resize the height of the column headers. 
        dataGridView1.AutoResizeColumnHeadersHeight();

        // Resize all the row heights to fit the contents of all non-header cells.
        dataGridView1.AutoResizeRows(
            DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
    }
    //</snippet3>
    //</snippet1>

    private void InitializeContextMenu()
    {
        // Create the menu item.
        ToolStripMenuItem getRecipe = new ToolStripMenuItem("Search for recipe", null,
            new System.EventHandler(ShortcutMenuClick));

        // Add the menu item to the shortcut menu.
        ContextMenuStrip recipeMenu = new ContextMenuStrip();
        recipeMenu.Items.Add(getRecipe); 

        // Set the shortcut menu for the first column.
        dataGridView1.Columns[0].ContextMenuStrip = recipeMenu;
        dataGridView1.MouseDown += new MouseEventHandler(dataGridView1_MouseDown);
    }

    //<snippet4>
    private DataGridViewCell clickedCell;

    private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
    {
	// If the user right-clicks a cell, store it for use by the shortcut menu.
        if (e.Button == MouseButtons.Right)
        {
            DataGridView.HitTestInfo hit = dataGridView1.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.Cell)
            {
                clickedCell =
                    dataGridView1.Rows[hit.RowIndex].Cells[hit.ColumnIndex];
            }
        }
    }
    //</snippet4>

    private void ShortcutMenuClick(object sender, System.EventArgs e)
    {
        if (clickedCell != null)
        {
            //Retrieve the recipe name.
            string recipeName = (string)clickedCell.Value;

            //Search for the recipe.
            System.Diagnostics.Process.Start(
                "http://search.msn.com/results.aspx?q=" + recipeName);
                //null);
        }
    }
    //</snippet2>

}

