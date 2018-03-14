
// compile with: /r:system.dll /r:system.windows.forms.dll /r:system.drawing.dll
using System.Windows.Forms;
using System;
using System.Drawing;
 
public class MyClass : Form
{
[STAThread]
   public static void Main() 
   {
       Application.Run(new MyClass());
   }
 // <snippet1>
   public MyClass()
   {
      // Create a new DateTimePicker.
      DateTimePicker dateTimePicker1 = new DateTimePicker();
      Controls.AddRange(new Control[] {dateTimePicker1}); 
      dateTimePicker1.CalendarFont = new Font("Courier New", 8.25F, FontStyle.Italic, GraphicsUnit.Point, ((Byte)(0)));
   }
// </snippet1>
}
