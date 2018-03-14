Imports System
Imports System.Drawing
Imports System.Windows.Forms

Class TestForm
   Inherits Form

' <snippet1>
Public Sub InitMyForm()
   ' Adds a label to the form.
   Dim label1 As New Label()
   label1.Location = New System.Drawing.Point(54, 128)
   label1.Name = "label1"
   label1.Size = New System.Drawing.Size(220, 80)
   label1.Text = "Start Position Information"
   Me.Controls.Add(label1)
   
   ' Changes the windows state to Maximized.
   WindowState = FormWindowState.Maximized
   ' Displays the window information.
   label1.Text = "The Form Window is " + WindowState
End Sub 'InitMyForm
' </snippet1>

   Public Shared Sub Main()
      Application.Run(New TestForm())
   End Sub

End Class

