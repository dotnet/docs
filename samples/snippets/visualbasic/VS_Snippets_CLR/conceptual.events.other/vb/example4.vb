'<snippet40>

'<snippet44>
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing

Public Class MyForm
    Inherits Form
    Private box As TextBox
    Private WithEvents myButton As Button

    Public Sub New()
        box = New TextBox()
        box.BackColor = System.Drawing.Color.Cyan
        box.Size = New Size(100, 100)
        box.Location = New Point(50, 50)
        box.Text = "Hello"

        myButton = New Button()
        myButton.Location = New Point(50, 100)
        myButton.Text = "Click Me"

        AddHandler myButton.Click, AddressOf Me.Button_Click

        Controls.Add(box)
        Controls.Add(myButton)
    End Sub

    ' The event handler.
    Private Sub Button_Click(sender As Object, e As EventArgs)
        box.BackColor = System.Drawing.Color.Green
    End Sub

    ' The STAThreadAttribute indicates that Windows Forms uses the
    ' single-threaded apartment model.
    <STAThread> _
    Public Shared Sub Main()
        Application.Run(New MyForm())
    End Sub
End Class
'</snippet44>

Public Class SnippetForm
    Inherits Form

    '<snippet41>
    Private WithEvents myButton As Button
    '</snippet41>

    '<snippet42>
    Private Sub Button_Click(sender As Object, e As EventArgs)
        '...
    End Sub
    '</snippet42>


    Public Sub New()
        myButton = New Button()

        '<snippet43>
        AddHandler myButton.Click, AddressOf Me.Button_Click
        '</snippet43>
    End Sub
End Class

#If 0
'<snippet45>
vbc /r:System.DLL /r:System.Windows.Forms.dll /r:System.Drawing.dll WinEvents.vb
'</snippet45>
#End If
'</snippet40>
