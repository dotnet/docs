
// compile with: /r:system.dll /r:system.windows.forms.dll
using System.Windows.Forms;
using System;

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
      // Create a new DateTimePicker
      DateTimePicker dateTimePicker1 = new DateTimePicker();
      Controls.AddRange(new Control[] {dateTimePicker1});
      MessageBox.Show(dateTimePicker1.Value.ToString());

      dateTimePicker1.Value = DateTime.Now.AddDays(1);
      MessageBox.Show(dateTimePicker1.Value.ToString());
   } 
// </snippet1>
}
