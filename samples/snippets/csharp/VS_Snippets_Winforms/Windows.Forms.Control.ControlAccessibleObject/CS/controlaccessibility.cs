// <snippet1>
using System;
using System.Windows.Forms;
using Accessibility;
using System.Drawing;

namespace MyCustomControls
{
   public class MyCheckBox : CheckBox
   {
      public MyCheckBox()
      {
         // Make the check box appear like a toggle button.
         this.Appearance = Appearance.Button;
         // Center the text on the button.
         this.TextAlign = ContentAlignment.MiddleCenter;
	 // Set the AccessibleDescription text.
         this.AccessibleDescription = "A toggle style button.";
      }
      
      // Create an instance of the AccessibleObject 
      // defined for the 'MyCheckBox' control
      protected override AccessibleObject CreateAccessibilityInstance() 
      {
         return new MyCheckBoxAccessibleObject(this);
      }
   }

   // Accessible object for use with the 'MyCheckBox' control.
   internal class MyCheckBoxAccessibleObject : Control.ControlAccessibleObject 
   {
      public MyCheckBoxAccessibleObject(MyCheckBox owner) : base(owner) 
      {
        
      }
               
      public override string DefaultAction 
      {
         get
         {
            // Return the DefaultAction based upon 
            // the state of the control.
            if( ((MyCheckBox)Owner).Checked )
            {
               return "Toggle button up";
            }
            else
            {
               return "Toggle button down";
            }
         }
      }

      public override string Name 
      {
         get 
         {
            // Return the Text property of the control 
            // if the AccessibleName is null.
            string name = Owner.AccessibleName;
            if (name != null) 
            {
               return name;
            }
            return ((MyCheckBox)Owner).Text;
         }
         
         set
         {
            base.Name = value;
         }
      }            
               
      public override AccessibleRole Role 
      {
         get 
         {
            // Since the check box appears like a button,
            // make the Role the same as a button.
            return AccessibleRole.PushButton;
         }
      }
   }
}
// </snippet1>



namespace ControlAccessibility
{
   public class MyForm : System.Windows.Forms.Form
   {
      private System.ComponentModel.Container components = null;

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
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(292, 273);
         this.Name = "Form1";
         this.Text = "Form1";

      }

      [STAThread]
      static void Main() 
      {
         Application.Run(new MyForm());
      }

// <snippet2>
public MyForm()
{
   // Create a 'MyCheckBox' control and 
   // display an image on it.
   MyCustomControls.MyCheckBox myCheckBox = 
      new MyCustomControls.MyCheckBox();
   myCheckBox.Location = new Point(5,5);
   myCheckBox.Image = Image.FromFile(
     Application.CommonAppDataPath + "\\Preview.jpg");

   // Set the AccessibleName property
   // since there is no Text displayed.
   myCheckBox.AccessibleName = "Preview";
   myCheckBox.AccessibleDescription =
     "A toggle button used to show the document preview.";
   this.Controls.Add(myCheckBox);
}
// </snippet2>
   }

}