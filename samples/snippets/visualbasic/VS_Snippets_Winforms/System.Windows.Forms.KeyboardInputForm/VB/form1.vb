' This sample compiles a set of miscellaneous code snippets that demonstrate
' different levels of user input control.

' <Snippet0>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace KeyboardInputForm

     Class Form1
      Inherits Form

        Private WithEvents TextBox1 As New TextBox()

      <STAThread()> _
      Public Shared Sub Main()
         Application.EnableVisualStyles()
         Application.Run(New Form1())
      End Sub

      Public Sub New()
         Me.AutoSize = True

         Dim panel As New FlowLayoutPanel()
         panel.AutoSize = True
         panel.FlowDirection = FlowDirection.TopDown
         panel.Controls.Add(TextBox1)
         Me.Controls.Add(panel)

         Me.KeyPreview = True
        End Sub

        ' <Snippet10>
        ' Detect all numeric characters at the form level and consume 1, 
        ' 4, and 7. Note that Form.KeyPreview must be set to true for this
        ' event handler to be called.
        Sub Form1_KeyPress(ByVal sender As Object, _
            ByVal e As KeyPressEventArgs) Handles Me.KeyPress

            If e.KeyChar >= ChrW(48) And e.KeyChar <= ChrW(57) Then
                MessageBox.Show(("Form.KeyPress: '" + _
                    e.KeyChar.ToString() + "' pressed."))

                Select Case e.KeyChar
                    Case ChrW(49), ChrW(52), ChrW(55)
                        MessageBox.Show(("Form.KeyPress: '" + _
                            e.KeyChar.ToString() + "' consumed."))
                        e.Handled = True
                End Select
            End If
        End Sub
      ' </Snippet10>

      ' <Snippet15>
      ' Detect all numeric characters at the TextBox level and consume  
      ' 2, 5, and 8.
      Sub TextBox1_KeyPress(ByVal sender As Object, _
          ByVal e As KeyPressEventArgs) Handles TextBox1.KeyPress

         If e.KeyChar >= ChrW(48) And e.KeyChar <= ChrW(57) Then
            MessageBox.Show(("Control.KeyPress: '" + _
                e.KeyChar.ToString() + "' pressed."))

            Select Case e.KeyChar
               Case ChrW(50), ChrW(53), ChrW(56)
                  MessageBox.Show(("Control.KeyPress: '" + _
                      e.KeyChar.ToString() + "' consumed."))
                  e.Handled = True
            End Select
         End If
      End Sub
      ' </Snippet15>

   End Class
End Namespace
' </Snippet0>