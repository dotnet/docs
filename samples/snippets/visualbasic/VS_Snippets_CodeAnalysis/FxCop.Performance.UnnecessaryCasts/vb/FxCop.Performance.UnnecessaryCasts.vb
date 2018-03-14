'<Snippet1>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace PerformanceLibrary

   Public Class SomeForm : Inherits Form

      Dim start, reset As Button

      Sub New()

         start = New Button()
         reset = New Button()
         AddHandler start.Click, AddressOf start_Click
         AddHandler reset.Click, AddressOf reset_Click
         Controls.Add(start)
         Controls.Add(reset)

      End Sub

      ' This method violates the rule.
      Private Sub start_Click(sender As Object, e As EventArgs)
      
         Dim controlSize As Size = DirectCast(sender, Control).Size
         Dim rightToLeftValue As RightToLeft = _ 
            DirectCast(sender, Control).RightToLeft
         Dim parent As Control = DirectCast(sender, Control)

      End Sub

      ' This method satisfies the rule.
      Private Sub reset_Click(sender As Object, e As EventArgs)
      
         Dim someControl As Control = DirectCast(sender, Control)
         Dim controlSize As Size = someControl.Size
         Dim rightToLeftValue As RightToLeft = someControl.RightToLeft
         Dim parent As Control = someControl

      End Sub

   End Class

End Namespace
'</Snippet1>
