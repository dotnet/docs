// System.Windows.Forms.Control.Font
// System.Windows.Forms.Control.FontChanged
// System.Windows.Forms.Control.Focused
// System.Windows.Forms.Control.Focus
/*
The following example demonstrates 'Font' & 'Focused' properties, 'Focus' 
method and 'FontChanged' event of 'Control' class.
A 'DateTimePicker' control and a 'Button' control are added to a form. The font 
property of 'DateTimePicker' control is changed to the font selected by user 
from 'FontDialog' control. An event handler function is attached
with 'FontChanged' event of 'DateTimePicker' control which sets the focus
on 'DateTimePicker' control.
*/

using System;
using System.Drawing;
using System.Windows.Forms;

public class MyFormControl : Form
{
   private FontDialog myFontDialog;
   private DateTimePicker myDateTimePicker;
   public Button myButton;
   public MyFormControl()
   {
      myDateTimePicker = new DateTimePicker();
      myFontDialog = new FontDialog();
      myButton = new Button();
      myDateTimePicker.Location = new Point(48, 24);
      myDateTimePicker.Name = "myDateTimePicker";
      myButton.Location = new Point(50, 150);
      myButton.Name = "myButton";
      myButton.Size = new Size(200, 40);
      myButton.Text = "Change Font of Date Time Picker";
      myButton.Click +=new EventHandler(myButton_Click);
      ClientSize = new Size(292, 273);
      Controls.AddRange(new Control[] {myDateTimePicker,myButton});
      Text = "Control Example";
      AddEventHandler();
   }
   static void Main() 
   {
      MyFormControl myForm = new MyFormControl();
      myForm.ShowDialog();
   }


// <Snippet1>
private void myButton_Click(object sender, EventArgs e)
{
   FontDialog myFontDialog = new FontDialog();
   if(myFontDialog.ShowDialog() == DialogResult.OK)
   {
      // Set the control's font.
      myDateTimePicker.Font = myFontDialog.Font;
   }
}
// </Snippet1>

// <Snippet2>
private void AddEventHandler()
{
   // Add the event handler for 'FontChanged' event.
   myDateTimePicker.FontChanged += 
                  new EventHandler(DateTimePicker_FontChanged);
}
private void DateTimePicker_FontChanged(object sender, EventArgs e)
{
// <Snippet3>
// <Snippet4>
   if(!myDateTimePicker.Focused)
   {
      // Set focus on 'DateTimePicker' control.
      myDateTimePicker.Focus();
   }
// </Snippet4>
// </Snippet3>
}
// </Snippet2>


}

