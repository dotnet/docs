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