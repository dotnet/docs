using System.Drawing;
using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

public class Form1:
    System.Windows.Forms.Form

{
    #region " Windows Form Designer generated code "

    public Form1() : base()
    {        

        //This call is required by the Windows Form Designer.
        InitializeComponent();
        PopulateListBoxWithFonts();
        PopulateListBoxWithGraphicsResolution();
        this.Paint += new PaintEventHandler(Form1_Paint);
        this.Button1.Click += new EventHandler(Button1_Click);
        
        //Add any initialization after the InitializeComponent() call

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

    //Required by the Windows Form Designer
    private System.ComponentModel.IContainer components;

    //NOTE: The following procedure is required by the Windows Form Designer
    //It can be modified using the Windows Form Designer.  
    //Do not modify it using the code editor.
    internal System.Windows.Forms.ListBox listBox1;
    internal System.Windows.Forms.Button Button1;
    [System.Diagnostics.DebuggerStepThrough]
    private void InitializeComponent()
    {
        this.listBox1 = new System.Windows.Forms.ListBox();
        this.Button1 = new System.Windows.Forms.Button();
        this.SuspendLayout();
        //
        //listBox1
        //
        this.listBox1.Location = new System.Drawing.Point(88, 112);
        this.listBox1.Name = "listBox1";
        this.listBox1.Size = new System.Drawing.Size(120, 95);
        this.listBox1.TabIndex = 0;
        //
        //Button1
        //
        this.Button1.Location = new System.Drawing.Point(120, 24);
        this.Button1.Name = "Button1";
        this.Button1.TabIndex = 1;
        this.Button1.Text = "Button1";
        //
        //Form1
        //
        this.ClientSize = new System.Drawing.Size(292, 266);
        this.Controls.Add(this.Button1);
        this.Controls.Add(this.listBox1);
        this.Name = "Form1";
        this.Text = "Form1";
        this.ResumeLayout(false);

    }

    #endregion

    // The following code example shows all the font families in the
    // Families property of the FontFamily class. This example is 
    // designed to be used with a Windows Form. To run this example, 
    // add a ListBox named listBox1 to a form and call the 
    // PopulateListBoxWithFonts method from the form's constructor.
    //<snippet1>
    private void PopulateListBoxWithFonts()
    {
        listBox1.Width = 200;
        listBox1.Location = new Point(40, 120);
        foreach ( FontFamily oneFontFamily in FontFamily.Families )
        {
            listBox1.Items.Add(oneFontFamily.Name);
        }
    }
    //</snippet1>

    // The following method shows the use of the DpiX and DpiY
    // properties. This example is designed for use with a Windows Form. 
    // To run this example, paste it into a form that contains a ListBox named 
    // listBox1 and call this method from the form's constructor or Load event.
    //<snippet4>
    private void PopulateListBoxWithGraphicsResolution()
    {
        Graphics boxGraphics = listBox1.CreateGraphics();
        Graphics formGraphics = this.CreateGraphics();

        listBox1.Items.Add("ListBox horizontal resolution: " 
            + boxGraphics.DpiX);
        listBox1.Items.Add("ListBox vertical resolution: " 
            + boxGraphics.DpiY);

        boxGraphics.Dispose();
    }
    //</snippet4>

    // The following code example shows how to set a keyboard shortcut
    // when drawing a string with the Graphics object. It also 
    // demonstrates how to use the SystemBrush.FromSystemColor method. To  
    // run this example, paste the code into a form, handle the form's 
    // Paint event, and call the following method, passing e as 
    // PaintEventArgs.
    //<snippet2>
    private void ShowHotKey(PaintEventArgs e)
    {

        // Declare the string with a keyboard shortcut.
        string text = "&Click Here";

        // Declare a new StringFormat.
        StringFormat format = new StringFormat();

        // Set the HotkeyPrefix property.
        format.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;

        // Draw the string.
        Brush theBrush = 
            SystemBrushes.FromSystemColor(SystemColors.Highlight);

        e.Graphics.DrawString(text, this.Font, theBrush, 30, 40, format);
    }
    //</snippet2>

    // The following code example adds a shadow to a ListBox using the
    // following members:
    //   Size.opImplicit
    //   SizeF.opAddition
    //   Point.opImplicit
    //   PointF.opAddition
    //   SolidBrush 

    // This example is designed to be used with a Windows Form. 
    // To run this example, paste this code into a form and call the
    // AddShadow method when handling the form's Paint event. Make
    // sure the form contains a ListBox named listBox1.

    //<snippet3>
    private void AddShadow(PaintEventArgs e)
    {

        // Create two SizeF objects.
        SizeF shadowSize = listBox1.Size;
        SizeF addSize = new SizeF(10.5F, 20.8F);

        // Add them together and save the result in shadowSize.
        shadowSize = shadowSize + addSize;

        // Get the location of the ListBox and convert it to a PointF.
        PointF shadowLocation = listBox1.Location;

        // Add two points to get a new location.
        shadowLocation = shadowLocation + new Size(5, 5);

        // Create a rectangleF. 
        RectangleF rectFToFill = 
            new RectangleF(shadowLocation, shadowSize);

        // Create a custom brush using a semi-transparent color, and 
        // then fill in the rectangle.
        Color customColor = Color.FromArgb(50, Color.Gray);
        SolidBrush shadowBrush = new SolidBrush(customColor);
        e.Graphics.FillRectangles(shadowBrush, new RectangleF[]{rectFToFill});

        // Dispose of the brush.
        shadowBrush.Dispose();
    }
    //</snippet3>

    // The following code example demonstrates using a Matrix
    // and the GraphicsPath.Transform method to rotate a string.
    // This example is designed to be used with Windows Forms.
    // Create a form and paste the following code into it. Call the
    // DrawVerticalStringFromBottomUp method in the form's Paint 
    // event-handling method, passing e as PaintEventArgs.
    //<snippet5>
    public void DrawVerticalStringFromBottomUp(PaintEventArgs e)
    {

        // Create the string to draw on the form.
        string text = "Can you read this?";

        // Create a GraphicsPath.
        System.Drawing.Drawing2D.GraphicsPath path = 
            new System.Drawing.Drawing2D.GraphicsPath();

        // Add the string to the path; declare the font, font style, size, and
        // vertical format for the string.
        path.AddString(text, this.Font.FontFamily, 1, 15, 
            new PointF(0.0F, 0.0F), 
            new StringFormat(StringFormatFlags.DirectionVertical));

        // Declare a matrix that will be used to rotate the text.
        System.Drawing.Drawing2D.Matrix rotateMatrix = 
            new System.Drawing.Drawing2D.Matrix();

        // Set the rotation angle and starting point for the text.
        rotateMatrix.RotateAt(180.0F, new PointF(10.0F, 100.0F));

        // Transform the text with the matrix.
        path.Transform(rotateMatrix);

        // Set the SmoothingMode to high quality for best readability.
        e.Graphics.SmoothingMode = 
            System.Drawing.Drawing2D.SmoothingMode.HighQuality;

        // Fill in the path to draw the string.
        e.Graphics.FillPath(Brushes.Red, path);

        // Dispose of the path.
        path.Dispose();

    }
    //</snippet5>


    // The following code example demonstrates how to use the KnownColor enum
    // to print out the name and colors of all its values. This example is 
    // designed to be used with Windows Forms. Create a form and paste
    // the following code into it.  Call the DisplayKnownColors method in the
    // form's Paint event-handling method, passing e as PaintEventArgs.
    //<snippet6>
    private void DisplayKnownColors(PaintEventArgs e)
    {
        this.Size = new Size(650, 550);
        
        // Get all the values from the KnownColor enumeration.
        System.Array colorsArray = Enum.GetValues(typeof(KnownColor));
        KnownColor[] allColors = new KnownColor[colorsArray.Length];

        Array.Copy(colorsArray, allColors, colorsArray.Length);

        // Loop through printing out the values' names in the colors 
        // they represent.
        float y = 0;
        float x = 10.0F;

        for(int i = 0; i < allColors.Length; i++)
        {

            // If x is a multiple of 30, start a new column.
            if (i > 0 && i % 30 == 0)
            {
                x += 105.0F;
                y = 15.0F;
            }
            else
            {
                // Otherwise, increment y by 15.
                y += 15.0F;
            }

            // Create a custom brush from the color and use it to draw
            // the brush's name.
            SolidBrush aBrush = 
                new SolidBrush(Color.FromName(allColors[i].ToString()));
            e.Graphics.DrawString(allColors[i].ToString(), 
                this.Font, aBrush, x, y);

            // Dispose of the custom brush.
            aBrush.Dispose();
        }

    }
    //</snippet6>

    // The following code example demonstrates how to use the MakeEmpty
    // method. This example is designed to be used with Windows Forms.
    // Create a form and paste the following code into it. Call the 
    // FillEmptyRegion method in the form's Paint event-handling method,
    // passing e as PaintEventArgs.
    //<snippet7>
    private void FillEmptyRegion(PaintEventArgs e)
    {

        // Create a region from a rectangle.
        Rectangle originalRectangle = new Rectangle(40, 40, 40, 50);
        Region smallRegion = new Region(originalRectangle);

        // Call MakeEmpty.
        smallRegion.MakeEmpty();

        // Fill the region in red and draw the original rectangle
        // in black. Note there is nothing filled in.
        e.Graphics.FillRegion(Brushes.Red, smallRegion);
        e.Graphics.DrawRectangle(Pens.Black, originalRectangle);

    }
    //</snippet7>

    // The following code example demonstrates how to use the MakeInfinite
    // method. This example is designed to be used with Windows Forms. 
    // Create a form and paste the following code into it. Call the
    // FillInfiniteRegion method in the form's Paint event-handling method, 
    // passing e as PaintEventArgs.
    //<snippet8>
    private void FillInfiniteRegion(PaintEventArgs e)
    {
        // Create a region from a rectangle.
        Rectangle originalRectangle = new Rectangle(40, 40, 40, 50);
        Region smallRegion = new Region(originalRectangle);

        // Call MakeInfinite.
        smallRegion.MakeInfinite();

        // Fill the region in red and draw the original rectangle
        // in black. Note that the entire form is filled in.
        e.Graphics.FillRegion(Brushes.Red, smallRegion);
        e.Graphics.DrawRectangle(Pens.Black, originalRectangle);

    }
    //</snippet8>

    // The following code example demonstrates how to use the ToBitmap
    // method. This example is designed to be used with Windows Forms. 
    // Create a form and paste the following code into it. Call the 
    // IconToBitmap method in the form's Paint event-handling method, 
    // passing e as PaintEventArgs.
    //<snippet9>
    private void IconToBitmap(PaintEventArgs e)
    {
        // Construct an Icon.
        Icon icon1 = new Icon(SystemIcons.Exclamation, 40, 40);

        // Call ToBitmap to convert it.
        Bitmap bmp = icon1.ToBitmap();

        // Draw the bitmap.
        e.Graphics.DrawImage(bmp, new Point(30, 30));
    }
    //</snippet9>
 


    // The following code example demonstrates how to use the 
    // TranslateTransform method. This example is designed to be used 
    // with Windows Forms.  Create a form and paste the following code 
    // into it. Call the TranslateAndTransform method in the form's 
    // Paint event-handling method, passing e as PaintEventArgs.
    //<snippet10>
    private void TranslateAndTransform(PaintEventArgs e)
    {

        // Create a GraphicsPath.
        System.Drawing.Drawing2D.GraphicsPath myPath =
            new System.Drawing.Drawing2D.GraphicsPath();

        // Create a rectangle.
        RectangleF layoutRectangle = 
            new RectangleF(20.0F, 20.0F, 40.0F, 50.0F);

        // Add the rectangle to the path.
        myPath.AddRectangle(layoutRectangle);

        // Add a string to the path.
        myPath.AddString("Path", this.Font.FontFamily, 2, 10.0F, 
            layoutRectangle, new StringFormat(StringFormatFlags.NoWrap));

        // Draw the path.
        e.Graphics.DrawPath(Pens.Black, myPath);

        // Call TranslateTransform and draw the path again.
        e.Graphics.TranslateTransform(10.0F, 10.0F);
        e.Graphics.DrawPath(Pens.Red, myPath);

    }
    //</snippet10>


   

    [STAThread]
    public static void Main()
    {
        Application.Run(new Form1());
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        //FillEmptyRegion(e)
        //SetAndFillClip(e)
        //FillInfiniteRegion(e)
        //ShowHotKey(e)
        //AddShadow(e)
        //IconToBitmap(e)
        //DisplayKnownColors(e)
        //DrawVerticalStringFromBottomUp(e)
        TranslateAndTransform(e);
       
    }

    // The following code example demonstrates how to set the Font property of 
    // a button to a new, bold-style Font. This example is designed to be
    // used with Windows Forms. Create a form containing a button named 
    // Button1 and paste the following code into it. Associate the 
    // Button1_Click method with the button's Click event.
    //<snippet11>
    private void Button1_Click(System.Object sender, System.EventArgs e)
    {
        if (Button1.Font.Style != FontStyle.Bold)
                Button1.Font = new Font(FontFamily.GenericSansSerif,
                12.0F, FontStyle.Bold);
    }
    //</snippet11>


// The following code example demonstrates how to construct a Region
    // using the RegionData class. This example is designed to be used with Windows
    // Forms. To run this example paste it into a form and handle the form's Paint event
    // by calling the DemonstrateRegionData method, passing e as PaintEventArgs.
    // <snippet12>
    private void DemonstrateRegionData(PaintEventArgs e)
    {

        //Create a simple region.
        Region region1 = new Region(new Rectangle(10, 10, 100, 100));

        // Extract the region data.
        System.Drawing.Drawing2D.RegionData region1Data =
            region1.GetRegionData();

        // Create a new region using the region data.
        Region region2 = new Region(region1Data);

        // Dispose of the first region.
        region1.Dispose();

        // Call ExcludeClip passing in the second region.
        e.Graphics.ExcludeClip(region2);

        // Fill in the client rectangle.
        e.Graphics.FillRectangle(Brushes.Red, this.ClientRectangle);

        region2.Dispose();

    }
    // </snippet12>

// The following code example demonstrates how use the Data from
    // one region to set the Data for another region. This example is designed 
    // to be used with Windows Forms. To run this example paste
    // it into a form and handle the form's Paint event
    // by calling the DemonstrateRegionData2 method, passing e as PaintEventArgs.
    // <snippet13>
    private void DemonstrateRegionData2(PaintEventArgs e)
    {

        //Create a simple region.
        Region region1 = new Region(new Rectangle(10, 10, 100, 100));

        // Extract the region data.
        System.Drawing.Drawing2D.RegionData region1Data = region1.GetRegionData();
        byte[] data1;
        data1 = region1Data.Data;

        // Create a second region.
        Region region2 = new Region();

        // Get the region data for the second region.
        System.Drawing.Drawing2D.RegionData region2Data = region2.GetRegionData();

        // Set the Data property for the second region to the Data from the first region.
        region2Data.Data = data1;

        // Construct a third region using the modified RegionData of the second region.
        Region region3 = new Region(region2Data);

        // Dispose of the first and second regions.
        region1.Dispose();
        region2.Dispose();

        // Call ExcludeClip passing in the third region.
        e.Graphics.ExcludeClip(region3);

        // Fill in the client rectangle.
        e.Graphics.FillRectangle(Brushes.Red, this.ClientRectangle);

        region3.Dispose();

    }
    // </snippet13>

 	//<snippetConstructor>
        private void BitmapConstructorEx(PaintEventArgs e)
        {

            // Create a bitmap.
            Bitmap bmp = new Bitmap("c:\\fakePhoto.jpg");
            
           // Retrieve the bitmap data from the the bitmap.
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), 
                ImageLockMode.ReadOnly, bmp.PixelFormat);

            //Create a new bitmap.
            Bitmap newBitmap = new Bitmap(200, 200, bmpData.Stride, bmp.PixelFormat, bmpData.Scan0);

            bmp.UnlockBits(bmpData);

            // Draw the new bitmap.
            e.Graphics.DrawImage(newBitmap, 10, 10);

        }
        //</snippetConstructor>
}





