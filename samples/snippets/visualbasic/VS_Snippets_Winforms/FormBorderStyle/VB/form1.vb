Imports System
Imports System.Drawing
Imports System.Windows.Forms

Class TestForm
   Inherits Form

   ' <snippet1>
   Public Sub InitMyForm()
      ' Adds a label to the form.
      Dim label1 As New Label()
      label1.Location = New System.Drawing.Point(80, 80)
      label1.Name = "label1"
      label1.Size = New System.Drawing.Size(132, 80)
      label1.Text = "Start Position Information"
      Me.Controls.Add(label1)
      
      ' Changes the border to Fixed3D.
      FormBorderStyle = FormBorderStyle.Fixed3D
      
      ' Displays the border information.
      label1.Text = "The border is " + FormBorderStyle
   End Sub 'InitMyForm
   ' </snippet1>

   Public Shared Sub Main()
      Application.Run(New TestForm())
   End Sub

End Class