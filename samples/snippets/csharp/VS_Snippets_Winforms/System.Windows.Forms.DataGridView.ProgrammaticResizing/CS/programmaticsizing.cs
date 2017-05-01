//<snippet0>
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

public class ProgrammaticSizing : System.Windows.Forms.Form
{
    private FlowLayoutPanel flowLayoutPanel1;
    private Button button1 = new Button();
    private Button button2 = new Button();
    private Button button3 = new Button();
    private Button button4 = new Button();
    private Button button5 = new Button();
    private Button button6 = new Button();
    private Button button7 = new Button();
    private Button button8 = new Button();
    private Button button9 = new Button();
    private Button button10 = new Button();
    private Button button11 = new Button();

    public ProgrammaticSizing()
    {
        InitializeComponent();
        AddDirections();
        this.Load += new EventHandler(InitializeDataGridView);

        AddButton(button1, "Reset",
            new EventHandler(ResetToDisorder));
        AddButton(button2, "Change Column 3 Header",
            new EventHandler(ChangeColumn3Header));
        AddButton(button3, "Change Meatloaf Recipe",
            new EventHandler(ChangeMeatloafRecipe));
        AddButton(button10, "Change Restaurant 2",
            new EventHandler(ChangeRestaurant));
        AddButtonsForProgrammaticResizing();
    }

    #region form code
    private void InitializeComponent()
    {
        this.flowLayoutPanel1 = new FlowLayoutPanel();
        this.flowLayoutPanel1.FlowDirection
            = FlowDirection.TopDown;
        this.flowLayoutPanel1.Location = new Point(492, 0);
        this.flowLayoutPanel1.AutoSize = true;

        this.AutoSize = true;
        this.Controls.Add(this.flowLayoutPanel1);
        this.Text = this.GetType().Name;
    }

    private void AddDirections()
    {
        Label directions = new Label();
        directions.AutoSize = true;
        String newLine = Environment.NewLine;
        directions.Text = "Press the buttons that start " + newLine
            + "with 'Change' to see how different sizing " + newLine
            + "modes deal with content changes.";

        flowLayoutPanel1.Controls.Add(directions);
    }
    #endregion

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new ProgrammaticSizing());
    }

    private Size startingSize;
    private string thirdColumnHeader = "Main Ingredients";
    private string boringMeatloaf = "ground beef";
    private string boringMeatloafRanking = "*";
    private bool boringRecipe;
    private bool shortMode;
    private DataGridView dataGridView1;
    private string otherRestaurant = "Gomes's Saharan Sushi";

    private void InitializeDataGridView(Object sender,
        EventArgs ignoredToo)
    {
        this.dataGridView1 = new DataGridView();
        this.dataGridView1.Location = new Point(0, 0);
        this.dataGridView1.Size = new Size(292, 266);
        this.Controls.Add(this.dataGridView1);
        startingSize = new Size(450, 400);
        dataGridView1.Size = startingSize;

        AddColumns();
        PopulateRows();

        shortMode = false;
        boringRecipe = true;
    }

    private void AddColumns()
    {
        dataGridView1.ColumnCount = 4;
        dataGridView1.ColumnHeadersVisible = true;

        DataGridViewCellStyle columnHeaderStyle =
            new DataGridViewCellStyle();

        columnHeaderStyle.BackColor = Color.Aqua;
        columnHeaderStyle.Font = new Font("Verdana", 10,
            FontStyle.Bold);
        dataGridView1.ColumnHeadersDefaultCellStyle =
            columnHeaderStyle;

        dataGridView1.Columns[0].Name = "Recipe";
        dataGridView1.Columns[1].Name = "Category";
        dataGridView1.Columns[2].Name = thirdColumnHeader;
        dataGridView1.Columns[3].Name = "Rating";
    }

    private void PopulateRows()
    {
        string[] row1 = {
            "Meatloaf", "Main Dish", 
            boringMeatloaf, boringMeatloafRanking
        };
        string[] row2 = {
            "Key Lime Pie", "Dessert", 
            "lime juice, evaporated milk", "****"
        };
        string[] row3 = {
            "Orange-Salsa Pork Chops", "Main Dish", 
            "pork chops, salsa, orange juice", "****"
        };
        string[] row4 = {
            "Black Bean and Rice Salad", "Salad", 
            "black beans, brown rice", "****"
        };
        string[] row5 = {
            "Chocolate Cheesecake", "Dessert", 
            "cream cheese", "***"
        };
        string[] row6 = {
            "Black Bean Dip", 
            "Appetizer", "black beans, sour cream", "***"
        };
        object[] rows = new object[] {
            row1, row2, row3, row4, row5, row6
        };

        foreach (string[] row in rows)
            dataGridView1.Rows.Add(row);
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            if (row.IsNewRow) break;
            row.HeaderCell.Value = "Restaurant " + row.Index;
        }
    }

    private void AddButton(Button button, string buttonLabel,
        EventHandler handler)
    {
        button.Text = buttonLabel;
        button.AutoSize = true;
        flowLayoutPanel1.Controls.Add(button);
        button.Click += handler;
    }

    private void ResetToDisorder(Object sender, EventArgs e)
    {
        Controls.Remove(dataGridView1);
        dataGridView1.Size = startingSize;
        dataGridView1.Dispose();
        InitializeDataGridView(null, null);
    }

    private void ChangeColumn3Header(Object sender, EventArgs e)
    {
        Toggle(ref shortMode);
        if (shortMode)
            dataGridView1.Columns[2].HeaderText = "S";
        else
            dataGridView1.Columns[2].HeaderText =
                thirdColumnHeader;
    }

    private static void Toggle(ref Boolean toggleThis)
    {
        toggleThis = !toggleThis;
    }

    private void ChangeMeatloafRecipe(Object sender,
        EventArgs e)
    {
        Toggle(ref boringRecipe);

        if (boringRecipe)
            SetMeatloaf(boringMeatloaf, boringMeatloafRanking);
        else
        {
            string greatMeatloafRecipe =
                "1 lb. lean ground beef, "
                + "1/2 cup bread crumbs, 1/4 cup ketchup,"
                + "1/3 tsp onion powder, "
                + "1 clove of garlic, 1/2 pack onion soup mix "
                + " dash of your favorite BBQ Sauce";

            SetMeatloaf(greatMeatloafRecipe, "***");
        }
    }

    private void SetMeatloaf(string recipe, string rating)
    {
        dataGridView1.Rows[0].Cells[2].Value = recipe;
        dataGridView1.Rows[0].Cells[3].Value = rating;
    }

    private void ChangeRestaurant(Object sender,
        EventArgs ignored)
    {
        if (dataGridView1.Rows[2].HeaderCell.Value.Equals(otherRestaurant))
        {
            dataGridView1.Rows[2].HeaderCell.Value =
                "Restaurant 2";
        }
        else
        {
            dataGridView1.Rows[2].HeaderCell.Value = otherRestaurant;
        }
    }

    #region "programmatic resizing"

    private void AddButtonsForProgrammaticResizing()
    {
        AddButton(button4, "Size Third Column",
            new EventHandler(SizeThirdColumnHeader));
        AddButton(button5, "Size Column Headers",
            new EventHandler(SizeColumnHeaders));
        AddButton(button6, "Size All Columns",
            new EventHandler(SizeAllColumns));
        AddButton(button7, "Size Third Row",
            new EventHandler(SizeThirdRow));
        AddButton(button8, "Size First Row Header Using All Headers",
            new EventHandler(SizeFirstRowHeaderToAllHeaders));
        AddButton(button9, "Size All Rows and Row Headers",
            new EventHandler(SizeAllRowsAndTheirHeaders));
        AddButton(button11, "Size All Rows ",
            new EventHandler(SizeAllRows));
    }

    //<snippet1>
    private void SizeThirdColumnHeader(Object sender,
        EventArgs e)
    {
        dataGridView1.AutoResizeColumn(
            2, DataGridViewAutoSizeColumnMode.ColumnHeader);
    }
    //</snippet1>

    //<snippet2>
    private void SizeColumnHeaders(Object sender, EventArgs e)
    {
        dataGridView1.AutoResizeColumnHeadersHeight(2);
    }
    //</snippet2>

    //<snippet3>
    private void SizeAllColumns(Object sender, EventArgs e)
    {
        dataGridView1.AutoResizeColumns(
            DataGridViewAutoSizeColumnsMode.AllCells);
    }
    //</snippet3>

    //<snippet4>
    private void SizeThirdRow(Object sender, EventArgs e)
    {
        dataGridView1.AutoResizeRow(
            2, DataGridViewAutoSizeRowMode.AllCellsExceptHeader);
    }
    //</snippet4>

    //<snippet5>
    private void SizeFirstRowHeaderToAllHeaders(Object sender, EventArgs e)
    {
        dataGridView1.AutoResizeRowHeadersWidth(
            0, DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
    }
    //</snippet5>

    //<snippet6>
    private void SizeAllRowsAndTheirHeaders(Object sender, EventArgs e)
    {
        dataGridView1.AutoResizeRows(
            DataGridViewAutoSizeRowsMode.AllCells);
    }
    //</snippet6>

    //<snippet7>
    private void SizeAllRows(Object sender,
        EventArgs e)
    {
        dataGridView1.AutoResizeRows(
            DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
    }
    //</snippet7>
    #endregion
}
//</snippet0>