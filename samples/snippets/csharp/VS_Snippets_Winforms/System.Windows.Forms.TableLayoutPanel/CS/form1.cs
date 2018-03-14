// <snippet1>
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using System.Diagnostics;

public class Form1 : System.Windows.Forms.Form
{
	private System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
	private System.Windows.Forms.Button Button1;
	private System.Windows.Forms.Button Button2;
	private System.Windows.Forms.Button Button3;
	private System.Windows.Forms.Button Button4;
	private System.Windows.Forms.Button enumerateChildrenBtn;
	private System.Windows.Forms.Button testGrowStyleBtn;
	private System.Windows.Forms.Button getColumnBtn;
	private System.Windows.Forms.Button getcontrolFromPosBtn;
	private System.Windows.Forms.Button getRowBtn;
	private System.Windows.Forms.Button swapControlsBtn;
	private System.Windows.Forms.RadioButton borderStyleNoneRadioBtn;
	private System.Windows.Forms.RadioButton borderStyleOutsetRadioBtn;
	private System.Windows.Forms.RadioButton borderStyleInsetRadioBtn;
	private System.Windows.Forms.RadioButton growStyleNoneBtn;
	private System.Windows.Forms.RadioButton growStyleAddRowBtn;
	private System.Windows.Forms.RadioButton growStyleAddColumnBtn;
	private System.Windows.Forms.Button toggleColumnStylesBtn;
	private DemoTableLayoutPanel DemoTableLayoutPanel1;
	private System.Windows.Forms.Button Button12;
	private System.Windows.Forms.Button Button10;
	private System.Windows.Forms.Button Button11;
	private System.Windows.Forms.Button toggleRowStylesBtn;
	private System.Windows.Forms.Button toggleSpanBtn;
	private System.Windows.Forms.Button swapRowsBtn;
	private System.Windows.Forms.Button toggleMarginsBtn;
	private System.Windows.Forms.Button togglePaddingBtn;

	//Required by the Windows Form Designer
	private System.ComponentModel.Container components;

	TableLayoutPanelGrowStyle tlpGrowStyle = TableLayoutPanelGrowStyle.AddRows;

	public Form1()
	{
		//This call is required by the Windows Form Designer.
		InitializeComponent();
	}

	//Form overrides dispose to clean up the component list.
	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (components != null)
			{
				components.Dispose();
			}
		}
		base.Dispose(disposing);
	}

	// <snippet2>
    private void enumerateChildrenBtn_Click(
		System.Object sender, 
		System.EventArgs e)
    {
        foreach ( Control c in this.TableLayoutPanel1.Controls )
        {
            Trace.WriteLine(c.ToString());
        }
    }
    // </snippet2>

    // <snippet3>
    private void getColumnBtn_Click(
		System.Object sender, 
		System.EventArgs e)
    {
        foreach ( Control c in this.TableLayoutPanel1.Controls )
        {
            Trace.WriteLine(this.TableLayoutPanel1.GetColumn(c));
        }
    }
    // </snippet3>


    // <snippet4>
    private void getRowBtn_Click(
		System.Object sender, 
		System.EventArgs e)
    {
        foreach ( Control c in this.TableLayoutPanel1.Controls )
        {
            Trace.WriteLine(this.TableLayoutPanel1.GetRow(c));
        }
    }
    // </snippet4>

    // <snippet5>
    private void getcontrolFromPosBtn_Click(
		System.Object sender, 
		System.EventArgs e)
    {
        int i = 0;
        int j = 0;
        Trace.WriteLine(this.TableLayoutPanel1.ColumnCount);
        Trace.WriteLine(this.TableLayoutPanel1.RowCount);

        for(i=0; i<=this.TableLayoutPanel1.ColumnCount; i++)
        {
            for(j=0; j<=this.TableLayoutPanel1.RowCount; j++)
            {
                Control c = this.TableLayoutPanel1.GetControlFromPosition(i, j);

                if( c != null )
                {
                    Trace.WriteLine(c.ToString());
                }
            }
        }
    }
    // </snippet5>

    // <snippet12>
    private void swapControlsBtn_Click(
		System.Object sender, 
		System.EventArgs e)
    {
        Control c1 = this.TableLayoutPanel1.GetControlFromPosition(0, 0);
        Control c2 = this.TableLayoutPanel1.GetControlFromPosition(0, 1);

        if( c1 != null && c2 != null )
        {
            this.TableLayoutPanel1.SetColumn(c2, 0);
            this.TableLayoutPanel1.SetColumn(c1, 1);
        }
    }
    // </snippet12>

    // <snippet13>
    private void swapRowsBtn_Click(
		System.Object sender, 
		System.EventArgs e)
    {

        Control c1 = this.TableLayoutPanel1.GetControlFromPosition(0, 0);
        Control c2 = this.TableLayoutPanel1.GetControlFromPosition(1, 0);

        if ( c1 !=null && c2 != null )
        {
            this.TableLayoutPanel1.SetRow(c2, 0);
            this.TableLayoutPanel1.SetRow(c1, 1);
        }
    }
    // </snippet13>

    // <snippet6>
    private void borderStyleOutsetRadioBtn_CheckedChanged(
		System.Object sender, 
		System.EventArgs e)
    {
        this.TableLayoutPanel1.CellBorderStyle = 
			TableLayoutPanelCellBorderStyle.Outset;
    }

    private void borderStyleNoneRadioBtn_CheckedChanged(
		System.Object sender, 
		System.EventArgs e)
    {
        this.TableLayoutPanel1.CellBorderStyle = 
			TableLayoutPanelCellBorderStyle.None;
    }

    private void borderStyleInsetRadioBtn_CheckedChanged(
		System.Object sender, 
		System.EventArgs e)
    {
        this.TableLayoutPanel1.CellBorderStyle = 
			TableLayoutPanelCellBorderStyle.Inset;
    }
    // </snippet6>

    // <snippet7>
    private void growStyleNoneBtn_CheckedChanged(
		System.Object sender, 
		System.EventArgs e)
    {
        this.tlpGrowStyle = TableLayoutPanelGrowStyle.FixedSize;
    }

    private void growStyleAddRowBtn_CheckedChanged(
		System.Object sender, 
		System.EventArgs e)
    {
        this.tlpGrowStyle = TableLayoutPanelGrowStyle.AddRows;
    }

    private void growStyleAddColumnBtn_CheckedChanged(
		System.Object sender, 
		System.EventArgs e)
    {
        this.tlpGrowStyle = TableLayoutPanelGrowStyle.AddColumns;
    }

    private void testGrowStyleBtn_Click(
		System.Object sender, 
		System.EventArgs e)
    {
        this.TableLayoutPanel1.GrowStyle = this.tlpGrowStyle;

        try
        {
            this.TableLayoutPanel1.Controls.Add(new Button());
        }
        catch(ArgumentException ex)
        {
            Trace.WriteLine(ex.Message);
        }
    }
    // </snippet7>

    // <snippet8>
    private void toggleColumnStylesBtn_Click(
		System.Object sender, 
		System.EventArgs e)
    {
		TableLayoutColumnStyleCollection styles = 
			this.TableLayoutPanel1.ColumnStyles;

        foreach( ColumnStyle style in styles )
        {
            if( style.SizeType == SizeType.Absolute )
            {
                style.SizeType = SizeType.AutoSize;
            }
            else if( style.SizeType == SizeType.AutoSize )
            {
                style.SizeType = SizeType.Percent;

                // Set the column width to be a percentage
                // of the TableLayoutPanel control's width.
                style.Width = 33;
            }
            else
            {
                // Set the column width to 50 pixels.
                style.SizeType = SizeType.Absolute;
                style.Width = 50;
            }
        }
    }
    // </snippet8>

    // <snippet9>
    private void toggleRowStylesBtn_Click(
		System.Object sender, 
		System.EventArgs e)
    {
		TableLayoutRowStyleCollection styles = 
			this.TableLayoutPanel1.RowStyles;

        foreach( RowStyle style in styles )
        {
            if (style.SizeType==SizeType.Absolute)
            {
                style.SizeType = SizeType.AutoSize;
            }
            else if(style.SizeType==SizeType.AutoSize)
            {
                style.SizeType = SizeType.Percent;

                // Set the row height to be a percentage
                // of the TableLayoutPanel control's height.
                style.Height = 33;
            }
            else
            {

                // Set the row height to 50 pixels.
                style.SizeType = SizeType.Absolute;
                style.Height = 50;
            }
        }
    }
    // </snippet9>

    // <snippet10>
    private void TableLayoutPanel1_PaintCell(
		object sender, 
		System.Windows.Forms.PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        g.FillEllipse( 
			Brushes.ForestGreen, 
			new Rectangle(
			    e.ClipRectangle.X+2, 
				e.ClipRectangle.Y+2, 
				e.ClipRectangle.Width-4, 
				e.ClipRectangle.Height-4));

        g.DrawRectangle(Pens.Red, new Rectangle(e.ClipRectangle.X+2, e.ClipRectangle.Y+2, e.ClipRectangle.Width-4, e.ClipRectangle.Height-4));
    }
    // </snippet10>

    // <snippet11>
    private void toggleSpanBtn_Click(
		System.Object sender, 
		System.EventArgs e)
    {
        Control c = this.TableLayoutPanel1.GetControlFromPosition(0, 0);

        if ( c != null )
        {
            int xSpan = this.TableLayoutPanel1.GetColumnSpan(c);
            int ySpan = this.TableLayoutPanel1.GetRowSpan(c);

            if (xSpan>1)
            {
                xSpan = 1;
                ySpan = 1;
            }
            else
            {
                xSpan = 2;
                ySpan = 2;
            }

            this.TableLayoutPanel1.SetColumnSpan(c, xSpan);
            this.TableLayoutPanel1.SetRowSpan(c, ySpan);
        }
    }
    // </snippet11>

    // <snippet14>
    private void toggleMarginsBtn_Click(
		System.Object sender, 
		System.EventArgs e)
    {
        foreach( Control c in this.TableLayoutPanel1.Controls )
        {
            if (c.Margin.All>5)
            {
                Padding m = c.Margin;
                m.All = 5;
                c.Margin = m;
            }
            else
            {

                Padding m = c.Margin;
                m.All = 10;
                c.Margin = m;
            }
        }
    }
    // </snippet14>

    // <snippet15>
    private void togglePaddingBtn_Click(
		System.Object sender, 
		System.EventArgs e)
    {
        if (this.TableLayoutPanel1.Padding.All>5)
        {
            Padding p = this.TableLayoutPanel1.Padding;
            p.All = 5;
            this.TableLayoutPanel1.Padding = p;
        }
        else
        {
            Padding p = this.TableLayoutPanel1.Padding;
            p.All = 10;
            this.TableLayoutPanel1.Padding = p;
        }
    }
    // </snippet15>


	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main()
	{
		Application.Run(new Form1());
	}

    #region Windows Form Designer generated code

    //NOTE: The following procedure is required by the Windows Form Designer
    //It can be modified using the Windows Form Designer.  
    //Do not modify it using the code editor.
    private void InitializeComponent()
    {
		this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.Button1 = new System.Windows.Forms.Button();
		this.Button2 = new System.Windows.Forms.Button();
		this.Button3 = new System.Windows.Forms.Button();
		this.Button4 = new System.Windows.Forms.Button();
		this.enumerateChildrenBtn = new System.Windows.Forms.Button();
		this.testGrowStyleBtn = new System.Windows.Forms.Button();
		this.getColumnBtn = new System.Windows.Forms.Button();
		this.getcontrolFromPosBtn = new System.Windows.Forms.Button();
		this.getRowBtn = new System.Windows.Forms.Button();
		this.swapControlsBtn = new System.Windows.Forms.Button();
		this.borderStyleNoneRadioBtn = new System.Windows.Forms.RadioButton();
		this.borderStyleOutsetRadioBtn = new System.Windows.Forms.RadioButton();
		this.borderStyleInsetRadioBtn = new System.Windows.Forms.RadioButton();
		this.growStyleNoneBtn = new System.Windows.Forms.RadioButton();
		this.growStyleAddRowBtn = new System.Windows.Forms.RadioButton();
		this.growStyleAddColumnBtn = new System.Windows.Forms.RadioButton();
		this.toggleColumnStylesBtn = new System.Windows.Forms.Button();
		this.DemoTableLayoutPanel1 = new DemoTableLayoutPanel();
		this.Button12 = new System.Windows.Forms.Button();
		this.Button10 = new System.Windows.Forms.Button();
		this.Button11 = new System.Windows.Forms.Button();
		this.toggleRowStylesBtn = new System.Windows.Forms.Button();
		this.toggleSpanBtn = new System.Windows.Forms.Button();
		this.swapRowsBtn = new System.Windows.Forms.Button();
		this.toggleMarginsBtn = new System.Windows.Forms.Button();
		this.togglePaddingBtn = new System.Windows.Forms.Button();
		this.TableLayoutPanel1.SuspendLayout();
		this.DemoTableLayoutPanel1.SuspendLayout();
		this.SuspendLayout();
// 
// TableLayoutPanel1
// 
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		this.TableLayoutPanel1.Controls.Add(this.Button1, 0, 0);
		this.TableLayoutPanel1.Controls.Add(this.Button2, 1, 0);
		this.TableLayoutPanel1.Controls.Add(this.Button3, 0, 0);
		this.TableLayoutPanel1.Controls.Add(this.Button4, 0, 0);
		this.TableLayoutPanel1.Location = new System.Drawing.Point(123, 24);
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.RowCount = 4;
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.TableLayoutPanel1.Size = new System.Drawing.Size(286, 230);
		this.TableLayoutPanel1.TabIndex = 0;
// 
// Button1
// 
		this.Button1.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Button1.Location = new System.Drawing.Point(105, 68);
		this.Button1.Name = "Button1";
		this.Button1.TabIndex = 1;
		this.Button1.Text = "Button1";
// 
// Button2
// 
		this.Button2.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Button2.Location = new System.Drawing.Point(105, 150);
		this.Button2.Name = "Button2";
		this.Button2.TabIndex = 2;
		this.Button2.Text = "Button2";
// 
// Button3
// 
		this.Button3.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Button3.Location = new System.Drawing.Point(105, 3);
		this.Button3.Name = "Button3";
		this.Button3.TabIndex = 3;
		this.Button3.Text = "Button3";
// 
// Button4
// 
		this.Button4.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.TableLayoutPanel1.SetColumnSpan(this.Button4, 3);
		this.Button4.Location = new System.Drawing.Point(26, 32);
		this.Button4.Name = "Button4";
		this.Button4.Size = new System.Drawing.Size(234, 30);
		this.Button4.TabIndex = 4;
		this.Button4.Text = "Button4";
// 
// enumerateChildrenBtn
// 
		this.enumerateChildrenBtn.AutoSize = true;
		this.enumerateChildrenBtn.Location = new System.Drawing.Point(629, 274);
		this.enumerateChildrenBtn.Name = "enumerateChildrenBtn";
		this.enumerateChildrenBtn.Size = new System.Drawing.Size(105, 23);
		this.enumerateChildrenBtn.TabIndex = 1;
		this.enumerateChildrenBtn.Text = "Enumerate Children";
		this.enumerateChildrenBtn.Click += new System.EventHandler(this.enumerateChildrenBtn_Click);
// 
// testGrowStyleBtn
// 
		this.testGrowStyleBtn.AutoSize = true;
		this.testGrowStyleBtn.Location = new System.Drawing.Point(67, 274);
		this.testGrowStyleBtn.Name = "testGrowStyleBtn";
		this.testGrowStyleBtn.Size = new System.Drawing.Size(88, 23);
		this.testGrowStyleBtn.TabIndex = 2;
		this.testGrowStyleBtn.Text = "Test GrowStyle";
		this.testGrowStyleBtn.Click += new System.EventHandler(this.testGrowStyleBtn_Click);
// 
// getColumnBtn
// 
		this.getColumnBtn.Location = new System.Drawing.Point(165, 274);
		this.getColumnBtn.Name = "getColumnBtn";
		this.getColumnBtn.TabIndex = 3;
		this.getColumnBtn.Text = "GetColumn";
		this.getColumnBtn.Click += new System.EventHandler(this.getColumnBtn_Click);
// 
// getcontrolFromPosBtn
// 
		this.getcontrolFromPosBtn.AutoSize = true;
		this.getcontrolFromPosBtn.Location = new System.Drawing.Point(329, 274);
		this.getcontrolFromPosBtn.Name = "getcontrolFromPosBtn";
		this.getcontrolFromPosBtn.Size = new System.Drawing.Size(123, 23);
		this.getcontrolFromPosBtn.TabIndex = 4;
		this.getcontrolFromPosBtn.Text = "GetControlFromPosition";
		this.getcontrolFromPosBtn.Click += new System.EventHandler(this.getcontrolFromPosBtn_Click);
// 
// getRowBtn
// 
		this.getRowBtn.Location = new System.Drawing.Point(247, 274);
		this.getRowBtn.Name = "getRowBtn";
		this.getRowBtn.TabIndex = 5;
		this.getRowBtn.Text = "GetRow";
		this.getRowBtn.Click += new System.EventHandler(this.getRowBtn_Click);
// 
// swapControlsBtn
// 
		this.swapControlsBtn.AutoSize = true;
		this.swapControlsBtn.Location = new System.Drawing.Point(459, 274);
		this.swapControlsBtn.Name = "swapControlsBtn";
		this.swapControlsBtn.Size = new System.Drawing.Size(81, 23);
		this.swapControlsBtn.TabIndex = 6;
		this.swapControlsBtn.Text = "Swap Controls";
		this.swapControlsBtn.Click += new System.EventHandler(this.swapControlsBtn_Click);
// 
// borderStyleNoneRadioBtn
// 
		this.borderStyleNoneRadioBtn.Location = new System.Drawing.Point(35, 26);
		this.borderStyleNoneRadioBtn.Name = "borderStyleNoneRadioBtn";
		this.borderStyleNoneRadioBtn.Size = new System.Drawing.Size(52, 30);
		this.borderStyleNoneRadioBtn.TabIndex = 8;
		this.borderStyleNoneRadioBtn.Text = "None";
		this.borderStyleNoneRadioBtn.Click += new System.EventHandler(this.borderStyleNoneRadioBtn_CheckedChanged);
// 
// borderStyleOutsetRadioBtn
// 
		this.borderStyleOutsetRadioBtn.AutoSize = true;
		this.borderStyleOutsetRadioBtn.Location = new System.Drawing.Point(35, 62);
		this.borderStyleOutsetRadioBtn.Name = "borderStyleOutsetRadioBtn";
		this.borderStyleOutsetRadioBtn.Size = new System.Drawing.Size(52, 25);
		this.borderStyleOutsetRadioBtn.TabIndex = 9;
		this.borderStyleOutsetRadioBtn.Text = "Outset";
		this.borderStyleOutsetRadioBtn.Click += new System.EventHandler(this.borderStyleOutsetRadioBtn_CheckedChanged);
// 
// borderStyleInsetRadioBtn
// 
		this.borderStyleInsetRadioBtn.Location = new System.Drawing.Point(35, 92);
		this.borderStyleInsetRadioBtn.Name = "borderStyleInsetRadioBtn";
		this.borderStyleInsetRadioBtn.Size = new System.Drawing.Size(52, 25);
		this.borderStyleInsetRadioBtn.TabIndex = 10;
		this.borderStyleInsetRadioBtn.Text = "Inset";
		this.borderStyleInsetRadioBtn.Click += new System.EventHandler(this.borderStyleInsetRadioBtn_CheckedChanged);
// 
// growStyleNoneBtn
// 
		this.growStyleNoneBtn.AutoSize = true;
		this.growStyleNoneBtn.Location = new System.Drawing.Point(67, 304);
		this.growStyleNoneBtn.Name = "growStyleNoneBtn";
		this.growStyleNoneBtn.TabIndex = 13;
		this.growStyleNoneBtn.Text = "Fixed";
		this.growStyleNoneBtn.Click += new System.EventHandler(this.growStyleNoneBtn_CheckedChanged);
// 
// growStyleAddRowBtn
// 
		this.growStyleAddRowBtn.AutoSize = true;
		this.growStyleAddRowBtn.Location = new System.Drawing.Point(67, 335);
		this.growStyleAddRowBtn.Name = "growStyleAddRowBtn";
		this.growStyleAddRowBtn.TabIndex = 14;
		this.growStyleAddRowBtn.Text = "Add Rows";
		this.growStyleAddRowBtn.Click += new System.EventHandler(this.growStyleAddRowBtn_CheckedChanged);
// 
// growStyleAddColumnBtn
// 
		this.growStyleAddColumnBtn.AutoSize = true;
		this.growStyleAddColumnBtn.Location = new System.Drawing.Point(67, 366);
		this.growStyleAddColumnBtn.Name = "growStyleAddColumnBtn";
		this.growStyleAddColumnBtn.TabIndex = 15;
		this.growStyleAddColumnBtn.Text = "Add Columns";
		this.growStyleAddColumnBtn.Click += new System.EventHandler(this.growStyleAddColumnBtn_CheckedChanged);
// 
// toggleColumnStylesBtn
// 
		this.toggleColumnStylesBtn.Location = new System.Drawing.Point(69, 397);
		this.toggleColumnStylesBtn.Name = "toggleColumnStylesBtn";
		this.toggleColumnStylesBtn.Size = new System.Drawing.Size(118, 24);
		this.toggleColumnStylesBtn.TabIndex = 16;
		this.toggleColumnStylesBtn.Text = "Toggle ColumnStyles";
		this.toggleColumnStylesBtn.Click += new System.EventHandler(this.toggleColumnStylesBtn_Click);
// 
// DemoTableLayoutPanel1
// 
		this.DemoTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
		this.DemoTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
		this.DemoTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
		this.DemoTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
		this.DemoTableLayoutPanel1.Controls.Add(this.Button12);
		this.DemoTableLayoutPanel1.Controls.Add(this.Button10, 0, 1);
		this.DemoTableLayoutPanel1.Controls.Add(this.Button11, 1, 1);
		this.DemoTableLayoutPanel1.Location = new System.Drawing.Point(446, 24);
		this.DemoTableLayoutPanel1.Name = "DemoTableLayoutPanel1";
		this.DemoTableLayoutPanel1.RowCount = 2;
		this.DemoTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
		this.DemoTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
		this.DemoTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
		this.DemoTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
		this.DemoTableLayoutPanel1.Size = new System.Drawing.Size(256, 230);
		this.DemoTableLayoutPanel1.TabIndex = 11;
// 
// Button12
// 
		this.Button12.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Button12.Location = new System.Drawing.Point(90, 13);
		this.Button12.Name = "Button12";
		this.Button12.TabIndex = 9;
		this.Button12.Text = "Button12";
// 
// Button10
// 
		this.Button10.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Button10.Location = new System.Drawing.Point(90, 63);
		this.Button10.Name = "Button10";
		this.Button10.TabIndex = 12;
		this.Button10.Text = "Button10";
// 
// Button11
// 
		this.Button11.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Button11.Location = new System.Drawing.Point(90, 153);
		this.Button11.Name = "Button11";
		this.Button11.TabIndex = 8;
		this.Button11.Text = "Button11";
// 
// toggleRowStylesBtn
// 
		this.toggleRowStylesBtn.Location = new System.Drawing.Point(67, 440);
		this.toggleRowStylesBtn.Name = "toggleRowStylesBtn";
		this.toggleRowStylesBtn.Size = new System.Drawing.Size(120, 22);
		this.toggleRowStylesBtn.TabIndex = 17;
		this.toggleRowStylesBtn.Text = "Toggle RowStyles";
		this.toggleRowStylesBtn.Click += new System.EventHandler(this.toggleRowStylesBtn_Click);
// 
// toggleSpanBtn
// 
		this.toggleSpanBtn.Location = new System.Drawing.Point(247, 398);
		this.toggleSpanBtn.Name = "toggleSpanBtn";
		this.toggleSpanBtn.TabIndex = 18;
		this.toggleSpanBtn.Text = "Toggle Span";
		this.toggleSpanBtn.Click += new System.EventHandler(this.toggleSpanBtn_Click);
// 
// swapRowsBtn
// 
		this.swapRowsBtn.Location = new System.Drawing.Point(458, 305);
		this.swapRowsBtn.Name = "swapRowsBtn";
		this.swapRowsBtn.Size = new System.Drawing.Size(82, 23);
		this.swapRowsBtn.TabIndex = 19;
		this.swapRowsBtn.Text = "Swap Rows";
		this.swapRowsBtn.Click += new System.EventHandler(this.swapRowsBtn_Click);
// 
// toggleMarginsBtn
// 
		this.toggleMarginsBtn.Location = new System.Drawing.Point(328, 397);
		this.toggleMarginsBtn.Name = "toggleMarginsBtn";
		this.toggleMarginsBtn.Size = new System.Drawing.Size(93, 24);
		this.toggleMarginsBtn.TabIndex = 20;
		this.toggleMarginsBtn.Text = "Toggle Margins";
		this.toggleMarginsBtn.Click += new System.EventHandler(this.toggleMarginsBtn_Click);
// 
// togglePaddingBtn
// 
		this.togglePaddingBtn.Location = new System.Drawing.Point(458, 396);
		this.togglePaddingBtn.Name = "togglePaddingBtn";
		this.togglePaddingBtn.Size = new System.Drawing.Size(94, 23);
		this.togglePaddingBtn.TabIndex = 21;
		this.togglePaddingBtn.Text = "Toggle Padding";
		this.togglePaddingBtn.Click += new System.EventHandler(this.togglePaddingBtn_Click);
// 
// Form1
// 		
		this.ClientSize = new System.Drawing.Size(773, 489);
		this.Controls.Add(this.togglePaddingBtn);
		this.Controls.Add(this.toggleMarginsBtn);
		this.Controls.Add(this.swapRowsBtn);
		this.Controls.Add(this.toggleSpanBtn);
		this.Controls.Add(this.toggleRowStylesBtn);
		this.Controls.Add(this.toggleColumnStylesBtn);
		this.Controls.Add(this.growStyleAddColumnBtn);
		this.Controls.Add(this.growStyleAddRowBtn);
		this.Controls.Add(this.growStyleNoneBtn);
		this.Controls.Add(this.DemoTableLayoutPanel1);
		this.Controls.Add(this.borderStyleInsetRadioBtn);
		this.Controls.Add(this.borderStyleOutsetRadioBtn);
		this.Controls.Add(this.borderStyleNoneRadioBtn);
		this.Controls.Add(this.swapControlsBtn);
		this.Controls.Add(this.getRowBtn);
		this.Controls.Add(this.getcontrolFromPosBtn);
		this.Controls.Add(this.getColumnBtn);
		this.Controls.Add(this.testGrowStyleBtn);
		this.Controls.Add(this.enumerateChildrenBtn);
		this.Controls.Add(this.TableLayoutPanel1);
		this.Name = "Form1";
		this.Text = "Form1";
		this.TableLayoutPanel1.ResumeLayout(false);
		this.DemoTableLayoutPanel1.ResumeLayout(false);
		this.ResumeLayout(false);
		this.PerformLayout();

	}

    #endregion
  
}

// <snippet100>
public class DemoTableLayoutPanel : TableLayoutPanel
{
	protected override void OnCellPaint(TableLayoutCellPaintEventArgs e)
	{
		base.OnCellPaint(e);

        Control c = this.GetControlFromPosition(e.Column, e.Row);

        if ( c != null )
        {
            Graphics g = e.Graphics;

            g.DrawRectangle(
				Pens.Red, 
				e.CellBounds.Location.X+1,
				e.CellBounds.Location.Y + 1,
				e.CellBounds.Width - 2, e.CellBounds.Height - 2);

			g.FillRectangle(
				Brushes.Blue, 
				e.CellBounds.Location.X + 1, 
				e.CellBounds.Location.Y + 1, 
				e.CellBounds.Width - 2, 
				e.CellBounds.Height - 2);
        };
	}
    
}
// </snippet100>
// </snippet1>


