//<snippet0>
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

public class AutoSizing : System.Windows.Forms.Form
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
    private DataGridView dataGridView1;

    public AutoSizing()
    {
        InitializeComponent();
        this.Load += new EventHandler(InitializeDataGridView);

        AddDirections();
        AddButton(button1, "Reset",
            new EventHandler(ResetToDisorder));
        AddButton(button2, "Change Column 3 Header",
            new EventHandler(ChangeColumn3Header));
        AddButton(button3, "Change Meatloaf Recipe",
            new EventHandler(ChangeMeatloafRecipe));
        AddButton(button4, "Change Restaurant 2",
            new EventHandler(ChangeRestaurant));
        AddButtonsForAutomaticResizing();
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

    private void InitializeComponent()
    {
        flowLayoutPanel1 = new FlowLayoutPanel();
        flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
        flowLayoutPanel1.Location = new System.Drawing.Point(492, 0);
        flowLayoutPanel1.AutoSize = true;
        flowLayoutPanel1.TabIndex = 1;

        ClientSize = new System.Drawing.Size(674, 419);
        Controls.Add(flowLayoutPanel1);
        Text = this.GetType().Name;
        AutoSize = true;
    }

    [STAThreadAttribute()]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new AutoSizing());
    }

    private Size startingSize;
    private string thirdColumnHeader = "Main Ingredients";
    private string boringMeatloaf = "ground beef";
    private string boringMeatloafRanking = "*";
    private bool boringRecipe;
    private bool shortMode;
    private string otherRestaurant = "Gomes's Saharan Sushi";

    private void InitializeDataGridView(Object ignored,
        EventArgs ignoredToo)
    {
        dataGridView1 = new System.Windows.Forms.DataGridView();
        Controls.Add(dataGridView1);
        startingSize = new Size(450, 400);
        dataGridView1.Size = startingSize;
        dataGridView1.AutoSizeRowsModeChanged +=
            new DataGridViewAutoSizeModeEventHandler
                (WatchRowsModeChanges);
        AddLabels();

        SetUpColumns();
        PopulateRows();

        shortMode = false;
        boringRecipe = true;
    }

    private void SetUpColumns()
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
            "Meatloaf", "Main Dish", boringMeatloaf, boringMeatloafRanking
        };
        string[] row2 = {
            "Key Lime Pie", "Dessert", "lime juice, evaporated milk", "****"
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
            "Chocolate Cheesecake", "Dessert", "cream cheese", "***"
        };
        string[] row6 = {
            "Black Bean Dip", "Appetizer", "black beans, sour cream", "***"
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
        button.Click += handler;
        button.Text = buttonLabel;
        button.AutoSize = true;
        button.TabIndex = flowLayoutPanel1.Controls.Count;
        flowLayoutPanel1.Controls.Add(button);
    }

    private void ResetToDisorder(Object sender, EventArgs e)
    {
        Controls.Remove(dataGridView1);
        dataGridView1.Dispose();
        InitializeDataGridView(null, null);
    }

    private void ChangeColumn3Header(Object sender, EventArgs e)
    {
        Toggle(ref shortMode);
        if (shortMode) dataGridView1.Columns[2].HeaderText = "S";
        else
            dataGridView1.Columns[2].HeaderText = thirdColumnHeader;
    }

    private static Boolean Toggle(ref Boolean toggleThis)
    {
        toggleThis = !toggleThis;
        return toggleThis;
    }

    private void ChangeMeatloafRecipe(Object sender, EventArgs e)
    {
        Toggle(ref boringRecipe);
        if (boringRecipe)
            SetMeatloaf(boringMeatloaf, boringMeatloafRanking);
        else
        {
            string greatMeatloafRecipe = "1 lb. lean ground beef, "
                + "1/2 cup bread crumbs, 1/4 cup ketchup,"
                + "1/3 tsp onion powder, "
                + "1 clove of garlic, 1/2 pack onion soup mix,"
                + " dash of your favorite BBQ Sauce";

            SetMeatloaf(greatMeatloafRecipe, "***");
        }
    }

    private void ChangeRestaurant(Object sender, EventArgs ignored)
    {
        if (dataGridView1.Rows[2].HeaderCell.Value.ToString() ==
            otherRestaurant)
            dataGridView1.Rows[2].HeaderCell.Value =
                "Restaurant 2";
        else
            dataGridView1.Rows[2].HeaderCell.Value =
            otherRestaurant;
    }

    private void SetMeatloaf(string recipe, string rating)
    {
        dataGridView1.Rows[0].Cells[2].Value = recipe;
        dataGridView1.Rows[0].Cells[3].Value = rating;
    }

    private string currentLayoutName =
        "DataGridView.AutoSizeRowsMode is currently: ";
    private void AddLabels()
    {
        Label current = (Label)
            flowLayoutPanel1.Controls[currentLayoutName];
        if (current == null)
        {
            current = new Label();
            current.AutoSize = true;
            current.Name = currentLayoutName;
            current.Text = currentLayoutName +
            dataGridView1.AutoSizeRowsMode.ToString();
            flowLayoutPanel1.Controls.Add(current);
        }
    }

    #region "Automatic Resizing"
    private void AddButtonsForAutomaticResizing()
    {
        AddButton(button5, "Keep Column Headers Sized",
            new EventHandler(ColumnHeadersHeightSizeMode));
        AddButton(button6, "Keep Row Headers Sized",
            new EventHandler(RowHeadersWidthSizeMode));
        AddButton(button7, "Keep Rows Sized",
            new EventHandler(AutoSizeRowsMode));
        AddButton(button8, "Keep Row Headers Sized with RowsMode",
            new EventHandler(AutoSizeRowHeadersUsingAllHeadersMode));
        AddButton(button9, "Disable AutoSizeRowsMode",
            new EventHandler(DisableAutoSizeRowsMode));
        AddButton(button10, "AutoSize third column by rows",
            new EventHandler(AutoSizeOneColumn));
        AddButton(button11, "AutoSize third column by rows and headers",
            new EventHandler(AutoSizeOneColumnIncludingHeaders));
    }

    //<snippet7>
    private void ColumnHeadersHeightSizeMode(Object sender, EventArgs e)
    {
        dataGridView1.ColumnHeadersHeightSizeMode = 
            DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    }
    //</snippet7>

    //<snippet8>
    private void RowHeadersWidthSizeMode(Object sender, EventArgs e)
    {
        dataGridView1.RowHeadersWidthSizeMode = 
            DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
    }
    //</snippet8>

    //<snippet9>
    private void AutoSizeRowsMode(Object sender, EventArgs es)
    {
        dataGridView1.AutoSizeRowsMode =
            DataGridViewAutoSizeRowsMode.AllCells;
    }
    //</snippet9>

    private void AutoSizeRowHeadersUsingAllHeadersMode(
        Object sender, System.EventArgs e)
    {
        dataGridView1.AutoSizeRowsMode =
            DataGridViewAutoSizeRowsMode.AllHeaders;
    }

    //<snippet10>
    private void WatchRowsModeChanges(object sender,
        DataGridViewAutoSizeModeEventArgs modeEvent)
    {
        Label label =
            (Label)flowLayoutPanel1.Controls[currentLayoutName];

        if (modeEvent.PreviousModeAutoSized)
        {
            label.Text = "changed to a different " +
                label.Name +
                dataGridView1.AutoSizeRowsMode.ToString();
        }
        else
        {
            label.Text = label.Name +
                dataGridView1.AutoSizeRowsMode.ToString();
        }
    }
    //</snippet10>

    private void DisableAutoSizeRowsMode(object sender,
        EventArgs modeEvent)
    {
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
    }

    //<snippet11>
    private void AutoSizeOneColumn(object sender,
        EventArgs theEvent)
    {
        DataGridViewColumn column = dataGridView1.Columns[2];
        column.AutoSizeMode = 
            DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
    }
    //</snippet11>

    private void AutoSizeOneColumnIncludingHeaders(
        object sender, EventArgs theEvent)
    {
        DataGridViewColumn column = dataGridView1.Columns[2];
        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
    }
    #endregion
}
//</snippet0>