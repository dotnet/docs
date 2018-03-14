
' compile with: /r:system.dll /r:system.windows.forms.dll /r:system.drawing.dll
Imports System.Windows.Forms
Imports System
Imports System.Drawing

Public Class [MyClass]
   Inherits Form
   
   <STAThread()> Public Shared Sub Main()
      Application.Run(New [MyClass]())
   End Sub 'Main   
' <snippet1>   
   Public Sub New()
      ' Create a new DateTimePicker.
      Dim dateTimePicker1 As New DateTimePicker()
      Controls.AddRange(New Control() {dateTimePicker1})
      dateTimePicker1.CalendarFont = New Font("Courier New", 8.25F, FontStyle.Italic, GraphicsUnit.Point, CType(0, [Byte]))
   End Sub
' </snippet1>
End Class '[MyClass]
