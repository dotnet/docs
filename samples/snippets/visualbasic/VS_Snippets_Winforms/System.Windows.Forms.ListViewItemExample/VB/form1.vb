Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        InitializeListViewItems()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Location = New System.Drawing.Point(120, 72)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.TabIndex = 0
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.ListView1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region
    '<snippet1>
    Private Sub InitializeListViewItems()
        ListView1.View = View.List
        Dim aCursor As Cursor

        Dim favoriteCursors() As Cursor = New Cursor() _
                    {Cursors.Help, Cursors.Hand, Cursors.No, Cursors.Cross}

        ' Populate the ListView control with the array of Cursors.
        For Each aCursor In favoriteCursors

            ' Construct the ListViewItem object
            Dim item As New ListViewItem

            ' Set the Text property to the cursor name.
            item.Text = aCursor.ToString

            ' Set the Tag property to the cursor.
            item.Tag = aCursor

            ' Add the ListViewItem to the ListView.
            ListView1.Items.Add(item)
        Next
    End Sub
    '</snippet1>

    Public Shared Sub main()
        Application.Run(New Form1)
    End Sub

End Class
