using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

public class MouseSizing : Form
{
    private FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Button button5;
    private System.Windows.Forms.Button button6;
    private System.Windows.Forms.Button button7;
    private System.Windows.Forms.Button button8;
    private System.Windows.Forms.Button button9;

    public MouseSizing()
    {
        InitializeComponent();
        this.Load += new EventHandler(InitializeDataGridView);
    }

    #region form set up

    private void InitializeComponent()
    {
        this.flowLayoutPanel1 = new FlowLayoutPanel();
        this.button4 = new System.Windows.Forms.Button();
        this.button5 = new System.Windows.Forms.Button();
        this.button6 = new System.Windows.Forms.Button();
        this.button7 = new System.Windows.Forms.Button();
        this.button8 = new System.Windows.Forms.Button();
        this.button9 = new System.Windows.Forms.Button();
        this.button1 = new System.Windows.Forms.Button();
        this.button2 = new System.Windows.Forms.Button();
        this.button3 = new System.Windows.Forms.Button();
        this.flowLayoutPanel1.SuspendLayout();
        this.SuspendLayout();

        this.flowLayoutPanel1.Controls.Add(this.button4);
        this.flowLayoutPanel1.Controls.Add(this.button5);
        this.flowLayoutPanel1.Controls.Add(this.button6);
        this.flowLayoutPanel1.Controls.Add(this.button7);
        this.flowLayoutPanel1.Controls.Add(this.button8);
        this.flowLayoutPanel1.Controls.Add(this.button9);
        this.flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
        this.flowLayoutPanel1.Location = new Point(492, 103);
        this.flowLayoutPanel1.Name = "flowLayoutPanel1";
        this.flowLayoutPanel1.AutoSize = true;
        this.flowLayoutPanel1.TabIndex = 1;

        this.button4.Location = new System.Drawing.Point(3, 3);
        this.button4.Name = "button4";
        this.button4.TabIndex = 3;
        this.button4.Text = "button4";

        this.button5.Location = new System.Drawing.Point(3, 32);
        this.button5.Name = "button5";
        this.button5.TabIndex = 4;
        this.button5.Text = "button5";

        this.button6.Location = new System.Drawing.Point(3, 61);
        this.button6.Name = "button6";
        this.button6.TabIndex = 5;
        this.button6.Text = "button6";

        this.button7.Location = new System.Drawing.Point(3, 90);
        this.button7.Name = "button7";
        this.button7.TabIndex = 6;
        this.button7.Text = "button7";

        this.button8.Location = new System.Drawing.Point(3, 119);
        this.button8.Name = "button8";
        this.button8.TabIndex = 7;
        this.button8.Text = "button8";

        this.button9.Location = new System.Drawing.Point(3, 148);
        this.button9.Name = "button9";
        this.button9.TabIndex = 8;
        this.button9.Text = "button9";

        this.button1.Location = new System.Drawing.Point(492, 3);
        this.button1.Name = "button1";
        this.button1.TabIndex = 0;
        this.button1.Text = "button1";

        this.button2.Location = new System.Drawing.Point(492, 33);
        this.button2.Name = "button2";
        this.button2.TabIndex = 1;
        this.button2.Text = "button2";

        this.button3.Location = new System.Drawing.Point(492, 63);
        this.button3.Name = "button3";
        this.button3.TabIndex = 2;
        this.button3.Text = "button3";

        this.AutoSize = true;
        this.Controls.Add(this.flowLayoutPanel1);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.button2);
        this.Controls.Add(this.button3);

        InitializeButton(button1, "Reset");
        InitializeButton(button2, "Change Column 3 Header");
        InitializeButton(button3, "Change Meatloaf Recipe");
        button1.Click += new EventHandler(ResetToDisorder);
        button2.Click += new EventHandler(ChangeColumn3Header);
        button3.Click += new EventHandler(ChangeMeatloafRecipe);

        InitializeButtonsForAffectingMouseResizing();

        this.Name = "MouseSizing";
        this.Text = "Mouse Sizing";
        this.flowLayoutPanel1.ResumeLayout(false);
        this.ResumeLayout(false);
    }
    #endregion

    [STAThreadAttribute()]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new MouseSizing());
    }

    private Size startingSize;
    private string thirdColumnHeader = "Main Ingredients";
    private string boringMeatloaf = "ground beef";
    private string boringMeatloafRanking = "*";
    private bool boringRecipe;
    private bool shortMode;
    private DataGridView dataGridView1;

    private void InitializeDataGridView(Object ignored,
        EventArgs ignoredToo)
    {
        this.dataGridView1 = new DataGridView();
        this.Controls.Add(this.dataGridView1);
        startingSize = new Size(450, 400);
        dataGridView1.Size = startingSize;

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
        "Meatloaf", "Main Dish", boringMeatloaf, 
        boringMeatloafRanking
    };
        string[] row2 = {
        "Key Lime Pie", "Dessert", 
        "lime juice,    evaporated milk", 
        "****"
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
        "Chocolate Cheesecake", "Dessert", "cream cheese", 
        "***"
    };
        string[] row6 = {
        "Black Bean Dip", "Appetizer", 
        "black beans, sour cream", "***"
    };
        object[] rows = new object[] {
        row1, row2, row3, row4, row5, row6
    };

        foreach (string[] row in rows)
            dataGridView1.Rows.Add(row);
    }

    private static void InitializeButton(Button button, string buttonLabel)
    {
        button.Text = buttonLabel;
        button.AutoSize = true;
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
            dataGridView1.Columns[2].HeaderText =
                thirdColumnHeader;
    }

    private static void Toggle(ref bool toggleThis)
    {
        toggleThis = !toggleThis;
    }
    
    private void ChangeMeatloafRecipe(Object sender, EventArgs e)
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

    #region "prevent mouse resizing"
    private void InitializeButtonsForAffectingMouseResizing()
    {
        InitializeButton(button4, "Fix Column Header Height");
        InitializeButton(button5, "Fix Row Header Width");
        InitializeButton(button6, "Fix Third Column");
        InitializeButton(button7,
            "Allow Mouse Resizing of Third Column");
        InitializeButton(button8,
            "Default Sizing Behavior For Third Column");
        InitializeButton(button9, "Fix Fourth Row");

        button4.Click += new EventHandler(FixColumnHeaderHeight);
        button5.Click += new EventHandler(FixRowHeadersWidth);
        button6.Click += new EventHandler(FixThirdColumn);
        button7.Click += new EventHandler(AllowThirdColumnToResize);
        button8.Click += new EventHandler(FixFourthRow);
        button9.Click +=
            new EventHandler(SetThirdColumnToDefaultBehavior);
    }

    private void FixColumnHeaderHeight(Object sender,
        EventArgs e)
    {
        //<snippet10>
        dataGridView1.ColumnHeadersHeightSizeMode = 
            DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        //</snippet10>
    }

    private void FixRowHeadersWidth(Object sender,
        EventArgs e)
    {
        //<snippet11>
        dataGridView1.RowHeadersWidthSizeMode = 
            DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        //</snippet11>
    }

    private void FixThirdColumn(Object sender, EventArgs e)
    {
        //<snippet12>
        dataGridView1.Columns[2].Resizable =
            DataGridViewTriState.False;
        //</snippet12>
    }

    private void AllowThirdColumnToResize(Object sender,
        EventArgs e)
    {
        //<snippet13>
        dataGridView1.Columns[2].Resizable =
            DataGridViewTriState.True;
        //</snippet13>
    }

    private void SetThirdColumnToDefaultBehavior(Object sender,
        EventArgs e)
    {
        //<snippet14>
        dataGridView1.Columns[2].Resizable =
            DataGridViewTriState.NotSet;
        //</snippet14>
    }

    private void FixFourthRow(Object sender, EventArgs e)
    {
        //<snippet15>
        dataGridView1.Rows[3].Resizable =
            DataGridViewTriState.False;
        //</snippet15>
    }
    #endregion
}
