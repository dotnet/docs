// System.Windows.Forms.Control.BeginInvoke(Delegate, object[])
// System.Windows.Forms.Control.BeginInvoke(Delegate)

/*
   The following program demonstrates the 'BeginInvoke(Delegate)' and BeginInvoke(Delegate, object[])
   methods of 'Control' class.
   A 'TextBox' and  two 'Button' controls are added to the form. When the first 'Button'
   is clicked a delegate is called asynchronously using 'BeginInvoke' method of 'Control'
   class and an array of objects is passed as an arguments to the delegator which adds
   'Label' control to the form. When the second 'Button' control is
   clicked a delegate is called asynchronously using 'BeginInvoke' which will display
   a message in the 'TextBox'.
*/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

public class MyForm : Form
{
   private System.ComponentModel.Container components = null;
   private TextBox myTextBox;
   private Button myButton;
   private Button invokeButton;

   public MyForm()
   {
      // Required for Windows Form Designer support.
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
      // Set 'myTextBox' properties.
      this.myTextBox = new TextBox();
      myTextBox.Location = new Point(90,16);
      myTextBox.Size = new Size(160,25);
      // Set 'myButton' properties.
      this.myButton = new Button();
      myButton.Text = "Add Label";
      myButton.Location = new Point(45,50);
      myButton.Size = new Size(70,25);
      myButton.Click += new EventHandler(Button_Click);

      invokeButton = new Button();
      invokeButton.Text = "Invoke Delegate";
      invokeButton.Location = new Point(120,50);
      invokeButton.Size = new Size(100,25);
      invokeButton.Click += new EventHandler(Invoke_Click);

      this.ClientSize = new System.Drawing.Size(292, 273);
      this.Name = "MyForm";
      this.Text = "Invoke example";

      this.Controls.Add(myTextBox);
      this.Controls.Add(myButton);
      this.Controls.Add(invokeButton);
   }

   [STAThread]
   public static void Main()
   {
      Application.Run(new MyForm());
   }
// <Snippet1>
   public delegate void MyDelegate(Label myControl, string myArg2);

   private void Button_Click(object sender, EventArgs e)
   {
      object[] myArray = new object[2];

      myArray[0] = new Label();
      myArray[1] = "Enter a Value";
      myTextBox.BeginInvoke(new MyDelegate(DelegateMethod), myArray);
   }

   public void DelegateMethod(Label myControl, string myCaption)
   {
      myControl.Location = new Point(16,16);
      myControl.Size = new Size(80, 25);
      myControl.Text = myCaption;
      this.Controls.Add(myControl);
   }
// </Snippet1>

// <Snippet2>
   public delegate void InvokeDelegate();

   private void Invoke_Click(object sender, EventArgs e)
   {
      myTextBox.BeginInvoke(new InvokeDelegate(InvokeMethod));
   }
   public void InvokeMethod()
   {
      myTextBox.Text = "Executed the given delegate";
   }
// </Snippet2>
}
