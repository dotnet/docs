    Private Sub PopulateListBoxWithGraphicsResolution()
        Dim boxGraphics As Graphics = listBox1.CreateGraphics()
        Dim formGraphics As Graphics = Me.CreateGraphics()

        listBox1.Items.Add("ListBox horizontal resolution: " _
            & boxGraphics.DpiX)
        listBox1.Items.Add("ListBox vertical resolution: " _
            & boxGraphics.DpiY)

        boxGraphics.Dispose()
    End Sub