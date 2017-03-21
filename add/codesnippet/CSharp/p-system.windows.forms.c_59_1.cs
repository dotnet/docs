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