
' compile with: -r:system.dll -r:system.windows.forms.dll
Imports System.Windows.Forms
Public Class [MyClass]
   Inherits Form
   
   <STAThread()> Public Shared Sub Main()
      Application.Run(New [MyClass]())
   End Sub
 ' <snippet1>  
   Public Sub New()
      ' Create a new DateTimePicker
      Dim dateTimePicker1 As New DateTimePicker()
      Controls.AddRange(New Control() {dateTimePicker1})
      MessageBox.Show(dateTimePicker1.Value.ToString())
      
      dateTimePicker1.Value = DateTime.Now.AddDays(1)
      MessageBox.Show(dateTimePicker1.Value.ToString())
   End Sub
' </snippet1>
End Class
