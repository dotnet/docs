    Private Sub PopulateListBoxWithFonts()
        listBox1.Width = 200
        listBox1.Location = New Point(40, 120)
        Dim oneFontFamily As FontFamily
        For Each oneFontFamily In FontFamily.Families
            listBox1.Items.Add(oneFontFamily.Name)
        Next
    End Sub