
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
      DateTimePicker dateTimePicker1 = new DateTimePicker();
      Controls.AddRange(new Control[] {dateTimePicker1}); 
      dateTimePicker1.CalendarForeColor = Color.Aqua;
   }
// </snippet1>
}
