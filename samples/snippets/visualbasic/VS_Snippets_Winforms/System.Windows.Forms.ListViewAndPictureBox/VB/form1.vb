Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        PopulateListView()
        InitializePictureBox()
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
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        Me.ListView1 = New System.Windows.Forms.ListView
        Me.SuspendLayout()
        '
        'PictureBox1
        '

        '
        'ListView1
        '
        Me.ListView1.Location = New System.Drawing.Point(40, 32)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.TabIndex = 1
        Me.ListView1.View = System.Windows.Forms.View.Details
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

    Public Shared Sub main()
        Application.Run(New Form1)
    End Sub

    '<snippet1>
    '<snippet2>
    Private Sub PopulateListView()
        ListView1.Width = 270
        ListView1.Location = New System.Drawing.Point(10, 10)

        ' Declare and construct the ColumnHeader objects.
        Dim header1, header2 As ColumnHeader
        header1 = New ColumnHeader
        header2 = New ColumnHeader

        ' Set the text, alignment and width for each column header.
        header1.Text = "File name"
        header1.TextAlign = HorizontalAlignment.Left
        header1.Width = 70

        header2.TextAlign = HorizontalAlignment.Left
        header2.Text = "Location"
        header2.Width = 200

        ' Add the headers to the ListView control.
        ListView1.Columns.Add(header1)
        ListView1.Columns.Add(header2)

        ' Specify that each item appears on a separate line.
        ListView1.View = View.Details

        ' Populate the ListView.Items property.
        ' Set the directory to the sample picture directory.
        Dim dirInfo As New System.IO.DirectoryInfo _
            ("C:\Documents and Settings\All Users" _
            & "\Documents\My Pictures\Sample Pictures")
        Dim file As System.IO.FileInfo

        ' Get the .jpg files from the directory
        Dim files() As System.io.FileInfo = dirInfo.GetFiles("*.jpg")

        ' Add each file name and full name including path
        ' to the ListView.
        If (files IsNot Nothing) Then
            For Each file In files
                Dim item As New ListViewItem(file.Name)
                item.SubItems.Add(file.FullName)
                ListView1.Items.Add(item)
            Next
        End If
    End Sub
    '</snippet1>

    Private Sub InitializePictureBox()
        PictureBox1 = New PictureBox

        ' Set the location and size of the PictureBox control.
        Me.PictureBox1.Location = New System.Drawing.Point(70, 120)
        Me.PictureBox1.Size = New System.Drawing.Size(140, 140)
        Me.PictureBox1.TabStop = False

        ' Set the SizeMode property to the StretchImage value.  This
        ' will shrink or enlarge the image as needed to fit into
        ' the PictureBox.
        Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

        ' Set the border style to a three-dimensional border.
        Me.PictureBox1.BorderStyle = BorderStyle.Fixed3D

        ' Add the PictureBox to the form.
        Me.Controls.Add(Me.PictureBox1)

    End Sub


    Private Sub ListView1_MouseDown(ByVal sender As Object, _
        ByVal e As MouseEventArgs) Handles ListView1.MouseDown

        Dim selection As ListViewItem = ListView1.GetItemAt(e.X, e.Y)

        ' If the user selects an item in the ListView, display
        ' the image in the PictureBox.
        If (selection IsNot Nothing) Then
            PictureBox1.Image = System.Drawing.Image.FromFile _
                (selection.SubItems(1).Text)
        End If


    End Sub
    ' </snippet2>
End Class
