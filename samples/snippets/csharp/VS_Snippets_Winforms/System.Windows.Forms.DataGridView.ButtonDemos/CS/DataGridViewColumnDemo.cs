//<snippet100>
using System.Windows.Forms;
using System;
using System.Drawing;

public class DataGridViewColumnDemo : Form
{
    #region "set up form"
    public DataGridViewColumnDemo()
    {
        InitializeComponent();

        AddButton(Button1, "Reset",
            new EventHandler(ResetToDisorder));
        AddButton(Button2, "Change Column 3 Header",
            new EventHandler(ChangeColumn3Header));
        AddButton(Button3, "Change Meatloaf Recipe",
            new EventHandler(ChangeMeatloafRecipe));
        AddAdditionalButtons();

        InitializeDataGridView();
    }

    DataGridView dataGridView;
    Button Button1 = new Button();
    Button Button2 = new Button();
    Button Button3 = new Button();
    Button Button4 = new Button();
    Button Button5 = new Button();
    Button Button6 = new Button();
    Button Button7 = new Button();
    Button Button8 = new Button();
    Button Button9 = new Button();
    Button Button10 = new Button();
    FlowLayoutPanel FlowLayoutPanel1 = new FlowLayoutPanel();

    private void InitializeComponent()
    {
        FlowLayoutPanel1.Location = new Point(454, 0);
        FlowLayoutPanel1.AutoSize = true;
        FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
        FlowLayoutPanel1.Name = "flowlayoutpanel";
        ClientSize = new System.Drawing.Size(614, 360);
        Controls.Add(this.FlowLayoutPanel1);
        Text = this.GetType().Name;
        AutoSize = true;
    }
    #endregion

    #region "set up DataGridView"

    private string thirdColumnHeader = "Main Ingredients";
    private string boringMeatloaf = "ground beef";
    private string boringMeatloafRanking = "*";
    private bool boringRecipe;
    private bool shortMode;

    private void InitializeDataGridView()
    {
        dataGridView = new System.Windows.Forms.DataGridView();
        Controls.Add(dataGridView);
        dataGridView.Size = new Size(300, 200);

        // Create an unbound DataGridView by declaring a
        // column count.
        dataGridView.ColumnCount = 4;
        AdjustDataGridViewSizing();

        // Set the column header style.
        DataGridViewCellStyle columnHeaderStyle =
            new DataGridViewCellStyle();
        columnHeaderStyle.BackColor = Color.Aqua;
        columnHeaderStyle.Font =
            new Font("Verdana", 10, FontStyle.Bold);
        dataGridView.ColumnHeadersDefaultCellStyle =
            columnHeaderStyle;

        // Set the column header names.
        dataGridView.Columns[0].Name = "Recipe";
        dataGridView.Columns[1].Name = "Category";
        dataGridView.Columns[2].Name = thirdColumnHeader;
        dataGridView.Columns[3].Name = "Rating";

        PostColumnCreation();

        // Populate the rows.
        string[] row1 = new string[]{"Meatloaf", 
                                        "Main Dish", boringMeatloaf, boringMeatloafRanking};
        string[] row2 = new string[]{"Key Lime Pie", 
                                        "Dessert", "lime juice, evaporated milk", "****"};
        string[] row3 = new string[]{"Orange-Salsa Pork Chops", 
                                        "Main Dish", "pork chops, salsa, orange juice", "****"};
        string[] row4 = new string[]{"Black Bean and Rice Salad", 
                                        "Salad", "black beans, brown rice", "****"};
        string[] row5 = new string[]{"Chocolate Cheesecake", 
                                        "Dessert", "cream cheese", "***"};
        string[] row6 = new string[]{"Black Bean Dip", "Appetizer",
                                        "black beans, sour cream", "***"};
        object[] rows = new object[] { row1, row2, row3, row4, row5, row6 };

        foreach (string[] rowArray in rows)
        {
            dataGridView.Rows.Add(rowArray);
        }

        shortMode = false;
        boringRecipe = true;
    }

    private void AddButton(Button button, string buttonLabel,
        EventHandler handler)
    {
        FlowLayoutPanel1.Controls.Add(button);
        button.TabIndex = FlowLayoutPanel1.Controls.Count;
        button.Text = buttonLabel;
        button.AutoSize = true;
        button.Click += handler;
    }

    private void ResetToDisorder(object sender, System.EventArgs e)
    {
        Controls.Remove(dataGridView);
        dataGridView.Dispose();
        InitializeDataGridView();
    }

    private void ChangeColumn3Header(object sender,
        System.EventArgs e)
    {
        Toggle(ref shortMode);
        if (shortMode)
        { dataGridView.Columns[2].HeaderText = "S"; }
        else
        { dataGridView.Columns[2].HeaderText = thirdColumnHeader; }
    }

    private static void Toggle(ref bool toggleThis)
    {
        toggleThis = !toggleThis;
    }

    private void ChangeMeatloafRecipe(object sender,
        System.EventArgs e)
    {
        Toggle(ref boringRecipe);
        if (boringRecipe)
        {
            SetMeatloaf(boringMeatloaf, boringMeatloafRanking);
        }
        else
        {
            string greatMeatloafRecipe =
                "1 lb. lean ground beef, " +
                "1/2 cup bread crumbs, 1/4 cup ketchup," +
                "1/3 tsp onion powder, " +
                "1 clove of garlic, 1/2 pack onion soup mix " +
                " dash of your favorite BBQ Sauce";
            SetMeatloaf(greatMeatloafRecipe, "***");
        }
    }

    private void SetMeatloaf(string recipe, string rating)
    {
        dataGridView.Rows[0].Cells[2].Value = recipe;
        dataGridView.Rows[0].Cells[3].Value = rating;
    }
    #endregion

    #region "demonstration code"
    private void PostColumnCreation()
    {
        AddContextLabel();
        AddCriteriaLabel();
        CustomizeCellsInThirdColumn();
        AddContextMenu();
        SetDefaultCellInFirstColumn();
        ToolTips();

        dataGridView.CellMouseEnter +=
            dataGridView_CellMouseEnter;
        dataGridView.AutoSizeColumnModeChanged +=
            dataGridView_AutoSizeColumnModeChanged;
    }

    private string criteriaLabel = "Column 3 sizing criteria: ";
    private void AddCriteriaLabel()
    {
        AddLabelToPanelIfNotAlreadyThere(criteriaLabel,
            criteriaLabel +
            dataGridView.Columns[2].AutoSizeMode.ToString() +
            ".");
    }

    private void AddContextLabel()
    {
        string labelName = "label";
        AddLabelToPanelIfNotAlreadyThere(labelName,
            "Use shortcut menu to change cell color.");
    }

    private void AddLabelToPanelIfNotAlreadyThere(
        string labelName, string labelText)
    {
        Label label;
        if (FlowLayoutPanel1.Controls[labelName] == null)
        {
            label = new Label();
            label.AutoSize = true;
            label.Name = labelName;
            label.BackColor = Color.Bisque;
            FlowLayoutPanel1.Controls.Add(label);
        }
        else
        {
            label = (Label)FlowLayoutPanel1.Controls[labelName];
        }
        label.Text = labelText;
    }

    //<snippet120>
    private void CustomizeCellsInThirdColumn()
    {
        int thirdColumn = 2;
        DataGridViewColumn column =
            dataGridView.Columns[thirdColumn];
        DataGridViewCell cell = new DataGridViewTextBoxCell();

        cell.Style.BackColor = Color.Wheat;
        column.CellTemplate = cell;
    }
    //</snippet120>

    //<snippet130>
    ToolStripMenuItem toolStripItem1 = new ToolStripMenuItem();

    private void AddContextMenu()
    {
        toolStripItem1.Text = "Redden";
        toolStripItem1.Click += new EventHandler(toolStripItem1_Click);
        ContextMenuStrip strip = new ContextMenuStrip();
        foreach (DataGridViewColumn column in dataGridView.Columns)
        {

            column.ContextMenuStrip = strip;
            column.ContextMenuStrip.Items.Add(toolStripItem1);
        }
    }

    private DataGridViewCellEventArgs mouseLocation;

    // Change the cell's color.
    private void toolStripItem1_Click(object sender, EventArgs args)
    {
        dataGridView.Rows[mouseLocation.RowIndex]
            .Cells[mouseLocation.ColumnIndex].Style.BackColor
            = Color.Red;
    }

    // Deal with hovering over a cell.
    private void dataGridView_CellMouseEnter(object sender,
        DataGridViewCellEventArgs location)
    {
        mouseLocation = location;
    }
    //</snippet130>

    //<snippet140>
    private void SetDefaultCellInFirstColumn()
    {
        DataGridViewColumn firstColumn = dataGridView.Columns[0];
        DataGridViewCellStyle cellStyle =
            new DataGridViewCellStyle();
        cellStyle.BackColor = Color.Thistle;

        firstColumn.DefaultCellStyle = cellStyle;
    }
    //</snippet140>


    //<snippet145>
    private void ToolTips()
    {
        DataGridViewColumn firstColumn = dataGridView.Columns[0];
        DataGridViewColumn thirdColumn = dataGridView.Columns[2];
        firstColumn.ToolTipText =
            "This column uses a default cell.";
        thirdColumn.ToolTipText =
            "This column uses a template cell." +
            " Style changes to one cell apply to all cells.";
    }
    //</snippet145>

    private void AddAdditionalButtons()
    {
        AddButton(Button4, "Set Minimum Width of Column Two",
            new EventHandler(Button4_Click));
        AddButton(Button5, "Set Width of Column One",
            new EventHandler(Button5_Click));
        AddButton(Button6, "Autosize Third Column",
            new EventHandler(Button6_Click));
        AddButton(Button7, "Add Thick Vertical Edge",
            new EventHandler(Button7_Click));
        AddButton(Button8, "Style and Number Columns",
            new EventHandler(Button8_Click));
        AddButton(Button9, "Change Column Header Text",
            new EventHandler(Button9_Click));
        AddButton(Button10, "Swap First and Last Columns",
            new EventHandler(Button10_Click));
    }

    private void AdjustDataGridViewSizing()
    {
        dataGridView.ColumnHeadersHeightSizeMode = 
            DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    }

    //<snippet107>
    //Set the minimum width.
    private void Button4_Click(object sender,
        System.EventArgs e)
    {
        DataGridViewColumn column = dataGridView.Columns[1];
        column.MinimumWidth = 40;
    }
    //</snippet107> 

    //<snippet108>
    // Set the width.
    private void Button5_Click(object sender, System.EventArgs e)
    {
        DataGridViewColumn column = dataGridView.Columns[0];
        column.Width = 60;
    }
    //</snippet108>


    //<snippet109>
    // AutoSize the third column.
    private void Button6_Click(object sender,
        System.EventArgs e)
    {
        DataGridViewColumn column = dataGridView.Columns[2];
        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
    }
    //</snippet109>

    //<snippet110>
    // Set the vertical edge.
    private void Button7_Click(object sender,
        System.EventArgs e)
    {
        int thirdColumn = 2;
        DataGridViewColumn column =
            dataGridView.Columns[thirdColumn];
        column.DividerWidth = 10;
    }
    //</snippet110>

    //<snippet150>
    // Style and number columns.
    private void Button8_Click(object sender,
        EventArgs args)
    {
        DataGridViewCellStyle style = new DataGridViewCellStyle();
        style.Alignment =
            DataGridViewContentAlignment.MiddleCenter;
        style.ForeColor = Color.IndianRed;
        style.BackColor = Color.Ivory;

        foreach (DataGridViewColumn column in dataGridView.Columns)
        {
            column.HeaderCell.Value = column.Index.ToString();
            column.HeaderCell.Style = style;
        }
    }
    //</snippet150>

    //<snippet160>
    // Change the text in the column header.
    private void Button9_Click(object sender,
        EventArgs args)
    {
        foreach (DataGridViewColumn column in dataGridView.Columns)
        {

            column.HeaderText = String.Concat("Column ",
                column.Index.ToString());
        }
    }
    //</snippet160>

    //<snippet170>
    // Swap the last column with the first.
    private void Button10_Click(object sender, EventArgs args)
    {
        DataGridViewColumnCollection columnCollection = dataGridView.Columns;

        DataGridViewColumn firstVisibleColumn =
            columnCollection.GetFirstColumn(DataGridViewElementStates.Visible);
        DataGridViewColumn lastVisibleColumn =
            columnCollection.GetLastColumn(
                DataGridViewElementStates.Visible, DataGridViewElementStates.None);

        int firstColumn_sIndex = firstVisibleColumn.DisplayIndex;
        firstVisibleColumn.DisplayIndex = lastVisibleColumn.DisplayIndex;
        lastVisibleColumn.DisplayIndex = firstColumn_sIndex;
    }
    //</snippet170>

    //<snippet180>
    // Updated the criteria label.
    private void dataGridView_AutoSizeColumnModeChanged(object sender,
        DataGridViewAutoSizeColumnModeEventArgs args)
    {
        args.Column.DataGridView.Parent.
            Controls["flowlayoutpanel"].Controls[criteriaLabel].
            Text = criteriaLabel
            + args.Column.AutoSizeMode.ToString();
    }
    //</snippet180>
    #endregion

    [STAThreadAttribute()]
    public static void Main()
    {
        Application.Run(new DataGridViewColumnDemo());
    }

}
//</snippet100>