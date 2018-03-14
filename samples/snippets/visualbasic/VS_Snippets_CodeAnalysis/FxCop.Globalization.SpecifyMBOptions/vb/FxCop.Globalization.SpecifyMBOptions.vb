'<Snippet1>
Imports System
Imports System.Globalization
Imports System.Resources
Imports System.Windows.Forms

Namespace GlobalizationLibrary
    Class Program
    
        <STAThread()> _
        Shared Sub Main()
            Dim myForm As New SomeForm()
            
            ' Uncomment the following line to test the right to left feature.
            ' myForm.RightToLeft = RightToLeft.Yes
            Application.Run(myForm)
        End Sub
    End Class

    Public Class SomeForm : Inherits Form
        Private _Resources As ResourceManager
        Private WithEvents _Button As Button

        Public Sub New()
            _Resources = New ResourceManager(GetType(SomeForm))
            _Button = New Button()
            Controls.Add(_Button)
        End Sub

        Private Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _Button.Click
            ' Switch the commenting on the following 4 lines to test the form.
            'Dim text As String = "Text"
            'Dim caption As String = "Caption"
            Dim text As String = _Resources.GetString("messageBox.Text")
            Dim caption As String = _Resources.GetString("messageBox.Caption")
            
            RtlAwareMessageBox.Show(CType(sender, Control), text, caption, _
            MessageBoxButtons.OK, MessageBoxIcon.Information, _
            MessageBoxDefaultButton.Button1, CType(0, MessageBoxOptions))
        End Sub
    End Class

    Public Module RtlAwareMessageBox

        Public Function Show(ByVal owner As IWin32Window, ByVal text As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal defaultButton As MessageBoxDefaultButton, ByVal options As MessageBoxOptions) As DialogResult
            If (IsRightToLeft(owner)) Then
                options = options Or MessageBoxOptions.RtlReading Or _
                MessageBoxOptions.RightAlign
            End If

            Return MessageBox.Show(owner, text, caption, _
            buttons, icon, defaultButton, options)
        End Function

        Private Function IsRightToLeft(ByVal owner As IWin32Window) As Boolean
            Dim control As Control = TryCast(owner, Control)

            If (control IsNot Nothing) Then
                Return control.RightToLeft = RightToLeft.Yes
            End If

            ' If no parent control is available, ask the CurrentUICulture
            ' if we are running under right-to-left.
            Return CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft
        End Function
    End Module
End Namespace
'</Snippet1>
