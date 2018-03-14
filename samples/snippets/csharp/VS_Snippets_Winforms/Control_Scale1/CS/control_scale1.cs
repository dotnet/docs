// System.Windows.Forms.Control.Scale(float)
// System.Windows.Forms.Control.SizeChanged

/*
   The following example demonstrates the 'Scale(float)' method
   and 'SizeChanged' event of the 'Control' class. An instance of 
   a 'Button' control has been provided that can be scaled both 
   horizontally and vertically. A 'NumericUpDown' instance has been 
   provided that is used to provide for the horizontal and vertical 
   scale value. The 'Button' instance named 'OK' is used to set the 
   scale values for the 'Button' control instance. Whenever the size
   of the control changes the event handler associated with the 
   'SizeChanged' event of the control is called. This event handler 
   displays a message box indicating that the size of the control has 
   changed. 
*/

using System;
using System.ComponentModel;
using System.Windows.Forms;

public class MyForm : Form
{
   private Label myLabel1;
   private NumericUpDown myNumericUpDown1;
   private Button myButton1;
   private Button myButton2;

   private Container components = null;

   public MyForm()
   {
      InitializeComponent();
   }

   protected override void Dispose( bool disposing )
   {
      if( disposing )
      {
         if (components != null) 
         {
            components.Dispose();
         }
      }
      base.Dispose( disposing );
   }

   private void InitializeComponent()
   {
      this.myLabel1 = new System.Windows.Forms.Label();
      this.myButton1 = new System.Windows.Forms.Button();
      this.myButton2 = new System.Windows.Forms.Button();
      this.myNumericUpDown1 = new System.Windows.Forms.NumericUpDown();
      ((System.ComponentModel.ISupportInitialize)(this.myNumericUpDown1)).BeginInit();
      this.SuspendLayout();
      // Set the properties for 'myLabel1'.
      this.myLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.myLabel1.Location = new System.Drawing.Point(16, 168);
      this.myLabel1.Name = "myLabel1";
      this.myLabel1.Size = new System.Drawing.Size(152, 24);
      this.myLabel1.TabIndex = 1;
      this.myLabel1.Text = "Scale (Horizontal & Vertical):";
      this.myLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // Set the properties for 'myButton1'.
      this.myButton1.Location = new System.Drawing.Point(56, 32);
      this.myButton1.Name = "myButton1";
      this.myButton1.Size = new System.Drawing.Size(184, 80);
      this.myButton1.TabIndex = 0;
      this.myButton1.Text = "Scaleable Control";
      RegisterEventHandler();
      // Set the properties for 'myButton2'.
      this.myButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.myButton2.Location = new System.Drawing.Point(48, 216);
      this.myButton2.Name = "myButton2";
      this.myButton2.Size = new System.Drawing.Size(200, 32);
      this.myButton2.TabIndex = 7;
      this.myButton2.Text = "OK";
      this.myButton2.Click += new System.EventHandler(this.MyButton2_Click);
      // Set the properties for 'myNumericUpDown1'.
      this.myNumericUpDown1.DecimalPlaces = 1;
      this.myNumericUpDown1.Increment = new System.Decimal(0.1);
      this.myNumericUpDown1.Location = new System.Drawing.Point(192, 168);
      this.myNumericUpDown1.Maximum = new System.Decimal(10);
      this.myNumericUpDown1.Minimum = new System.Decimal(0);
      this.myNumericUpDown1.Name = "myNumericUpDown1";
      this.myNumericUpDown1.Size = new System.Drawing.Size(88, 20);
      this.myNumericUpDown1.TabIndex = 5;
      // Set the properties for 'MyForm'.
      this.ClientSize = new System.Drawing.Size(292, 261);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                   this.myButton2,
                                                                   this.myNumericUpDown1,
                                                                   this.myLabel1,
                                                                   this.myButton1});
      this.Name = "MyForm";
      this.Text = "MyForm";
      ((System.ComponentModel.ISupportInitialize)(this.myNumericUpDown1)).EndInit();
      this.ResumeLayout(false);

   }

   [STAThread]
   static void Main() 
   {
      Application.Run(new MyForm());
   }


// <Snippet2>
   private void RegisterEventHandler()
   {
      myButton1.SizeChanged += new EventHandler(this.MyButton1_SizeChanged);
   }

   private void MyButton2_Click(object sender, System.EventArgs e)
   {
// <Snippet1>
      // Set the scale for the control to the value provided.
      float scale = (float)myNumericUpDown1.Value;
      myButton1.Scale(scale);
// </Snippet1>
   }

   private void MyButton1_SizeChanged(object sender, System.EventArgs e)
   {
      MessageBox.Show("The size of the 'Button' control has changed");
   }
// </Snippet2>
}
