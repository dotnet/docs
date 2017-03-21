    Private Sub CreateTabStopList()
        Dim listBox1 As New ListBox()
        listBox1.SetBounds(20, 20, 100, 100)

        Dim x As Integer
        For x = 1 To 19
            listBox1.Items.Add(("Item" + ControlChars.Tab + x.ToString()))
        Next x
        ' Make the ListBox display tabs within each item.
        listBox1.UseTabStops = True
        Me.Controls.Add(listBox1)
    End Sub