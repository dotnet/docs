//<snippet0>
using System.Drawing;
using System.Windows.Forms;
using System;

public class DataGridViewBandDemo : Form
{
    #region "form setup"
    public DataGridViewBandDemo()
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

        PostRowCreation();

        shortMode = false;
        boringRecipe = true;
    }


    void AddButton(Button button, string buttonLabel,
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

    // Change the header in column three.
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

    // Change the meatloaf recipe.
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
        AddButton(Button4, "Freeze First Row",
            new EventHandler(Button4_Click));
        AddButton(Button5, "Freeze Second Column",
            new EventHandler(Button5_Click));
        AddButton(Button6, "Hide Salad Row",
            new EventHandler(Button6_Click));
        AddButton(Button7, "Disable First Column Resizing",
            new EventHandler(Button7_Click));
        AddButton(Button8, "Make ReadOnly",
            new EventHandler(Button8_Click));
        AddButton(Button9, "Style Using Tag",
            new EventHandler(Button9_Click));
    }

    private void AdjustDataGridViewSizing()
    {
        dataGridView.AutoSizeRowsMode =
            DataGridViewAutoSizeRowsMode.AllCells;
        dataGridView.ColumnHeadersHeightSizeMode = 
            DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    }

    //<snippet7>
    // Freeze the first row.
    private void Button4_Click(object sender, System.EventArgs e)
    {

        FreezeBand(dataGridView.Rows[0]);
    }

    private void Button5_Click(object sender, System.EventArgs e)
    {

        FreezeBand(dataGridView.Columns[1]);
    }

    private static void FreezeBand(DataGridViewBand band)
    {
        band.Frozen = true;
        DataGridViewCellStyle style = new DataGridViewCellStyle();
        style.BackColor = Color.WhiteSmoke;
        band.DefaultCellStyle = style;
    }
    //</snippet7>   

    //<snippet9>
    // Hide a band of cells.
    private void Button6_Click(object sender, System.EventArgs e)
    {

        DataGridViewBand band = dataGridView.Rows[3];
        band.Visible = false;
    }
    //</snippet9>

    //<snippet10>
    // Turn off user's ability to resize a column.
    private void Button7_Click(object sender, EventArgs e)
    {

        DataGridViewBand band = dataGridView.Columns[0];
        band.Resizable = DataGridViewTriState.False;
    }
    //</snippet10>

    //<snippet11>
    // Make the the entire DataGridView read only.
    private void Button8_Click(object sender, System.EventArgs e)
    {
        foreach (DataGridViewBand band in dataGridView.Columns)
        {
            band.ReadOnly = true;
        }
    }
    //</snippet11>

    //<snippet12>
    private void PostRowCreation()
    {
        SetBandColor(dataGridView.Columns[0], Color.CadetBlue);
        SetBandColor(dataGridView.Rows[1], Color.Coral);
        SetBandColor(dataGridView.Columns[2], Color.DodgerBlue);
    }

    private static void SetBandColor(DataGridViewBand band, Color color)
    {
        band.Tag = color;
    }

    // Color the bands by the value stored in their tag.
    private void Button9_Click(object sender, System.EventArgs e)
    {

        foreach (DataGridViewBand band in dataGridView.Columns)
        {
            if (band.Tag != null)
            {
                band.DefaultCellStyle.BackColor = (Color)band.Tag;
            }
        }

        foreach (DataGridViewBand band in dataGridView.Rows)
        {
            if (band.Tag != null)
            {
                band.DefaultCellStyle.BackColor = (Color)band.Tag;
            }
        }
    }
    //</snippet12>
    #endregion

    [STAThreadAttribute()]
    public static void Main()
    {
        Application.Run(new DataGridViewBandDemo());
    }
}
//</snippet0>