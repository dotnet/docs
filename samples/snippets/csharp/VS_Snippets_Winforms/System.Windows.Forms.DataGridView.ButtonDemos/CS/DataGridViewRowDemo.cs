//<snippet200>
using System.Windows.Forms;
using System;
using System.Drawing;

public class DataGridViewRowDemo : Form
{
    #region "form setup"
    public DataGridViewRowDemo()
    {
        InitializeComponent();

        AddButton(Button1, "Reset",
            new EventHandler(Button1_Click));
        AddButton(Button2, "Change Column 3 Header",
            new EventHandler(Button2_Click));
        AddButton(Button3, "Change Meatloaf Recipe",
            new EventHandler(Button3_Click));
        AddAdditionalButtons();

        InitializeDataGridView();
    }

    private DataGridView dataGridView;
    private Button Button1 = new Button();
    private Button Button2 = new Button();
    private Button Button3 = new Button();
    private Button Button4 = new Button();
    private Button Button5 = new Button();
    private Button Button6 = new Button();
    private Button Button7 = new Button();
    private Button Button8 = new Button();
    private Button Button9 = new Button();
    private Button Button10 = new Button();
    private FlowLayoutPanel FlowLayoutPanel1 = new FlowLayoutPanel();

    private void InitializeComponent()
    {
        FlowLayoutPanel1.Location = new Point(454, 0);
        FlowLayoutPanel1.AutoSize = true;
        FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
        AutoSize = true;
        ClientSize = new System.Drawing.Size(614, 360);
        FlowLayoutPanel1.Name = "flowlayoutpanel";
        Controls.Add(this.FlowLayoutPanel1);
        Text = this.GetType().Name;
    }
    #endregion

    #region "setup DataGridView"

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
        dataGridView.ColumnHeadersVisible = true;
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

    // Reset columns to initial disorderly arrangement.
    private void Button1_Click(object sender, System.EventArgs e)
    {
        Controls.Remove(dataGridView);
        dataGridView.Dispose();
        InitializeDataGridView();
    }

    // Change column 3 header.
    private void Button2_Click(object sender,
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

    // Change meatloaf recipe.
    private void Button3_Click(object sender,
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
    private void AddAdditionalButtons()
    {
        AddButton(Button4, "Set Row Two Minimum Height",
            new EventHandler(Button4_Click));
        AddButton(Button5, "Set Row One Height",
            new EventHandler(Button5_Click));
        AddButton(Button6, "Label Rows",
            new EventHandler(Button6_Click));
        AddButton(Button7, "Turn on Extra Edge",
            new EventHandler(Button7_Click));
        AddButton(Button8, "Give Cheesecake an Excellent Rating",
            new EventHandler(Button8_Click));
    }

    private void AdjustDataGridViewSizing()
    {
        dataGridView.ColumnHeadersHeightSizeMode = 
            DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView.Columns[ratingColumn].Width = 50;
    }

    //<snippet207>
    // Set minimum height.
    private void Button4_Click(object sender, System.EventArgs e)
    {

        int secondRow = 1;
        DataGridViewRow row = dataGridView.Rows[secondRow];
        row.MinimumHeight = 40;
    }
    //</snippet207> 

    //<snippet208>
    // Set height.
    private void Button5_Click(object sender, System.EventArgs e)
    {

        DataGridViewRow row = dataGridView.Rows[0];
        row.Height = 15;
    }
    //</snippet208>

    //<snippet209>
    // Set row labels.
    private void Button6_Click(object sender, System.EventArgs e)
    {

        int rowNumber = 1;
        foreach (DataGridViewRow row in dataGridView.Rows)
        {
            if (row.IsNewRow) continue;
            row.HeaderCell.Value = "Row " + rowNumber;
            rowNumber = rowNumber + 1;
        }
        dataGridView.AutoResizeRowHeadersWidth(
            DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
    }
    //</snippet209>

    //<snippet210>
    // Set a thick horizontal edge.
    private void Button7_Click(object sender,
        System.EventArgs e)
    {
        int secondRow = 1;
        DataGridViewRow row = dataGridView.Rows[secondRow];
        row.DividerHeight = 10;
    }
    //</snippet210>

    //<snippet211>
    // Give cheescake excellent rating.
    private void Button8_Click(object sender,
        System.EventArgs e)
    {
        UpdateStars(dataGridView.Rows[4], "******************");
    }

    int ratingColumn = 3;

    private void UpdateStars(DataGridViewRow row, string stars)
    {

        row.Cells[ratingColumn].Value = stars;

        // Resize the column width to account for the new value.
        row.DataGridView.AutoResizeColumn(ratingColumn, 
            DataGridViewAutoSizeColumnMode.DisplayedCells);
    }
    //</snippet211>
    #endregion

    [STAThreadAttribute()]
    public static void Main()
    {
        Application.Run(new DataGridViewRowDemo());
    }
}
//</snippet200>