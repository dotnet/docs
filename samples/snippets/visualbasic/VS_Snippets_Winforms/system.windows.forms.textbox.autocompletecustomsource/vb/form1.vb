Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    '<snippet10>
    Private Sub Form1_Load(ByVal sender As System.Object, _
                           ByVal e As System.EventArgs) Handles MyBase.Load

        ' Create the list to use as the custom source.
        Dim MySource As New AutoCompleteStringCollection()
        MySource.AddRange(New String() _
                            { _
                                "January", _
                                "February", _
                                "March", _
                                "April", _
                                "May", _
                                "June", _
                                "July", _
                                "August", _
                                "September", _
                                "October", _
                                "November", _
                                "December" _
                            })

        ' Create and initialize the text box.
        Dim MyTextBox As New TextBox()
        With MyTextBox
            .AutoCompleteCustomSource = MySource
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.CustomSource
            .Location = New Point(20, 20)
            .Width = Me.ClientRectangle.Width - 40
            .Visible = True
        End With

        ' Add the text box to the form.
        Me.Controls.Add(MyTextBox)
    End Sub
    '</snippet10>

    ' <summary>
    ' The main entry point for the application.
    ' </summary>
    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1)
    End Sub
End Class
