    Private WithEvents ListBox1 As New ListBox()

    Private Sub InitializeListBox() 
        ListBox1.Items.AddRange(New Object() _
            {"Red Item", "Orange Item", "Purple Item"})
        ListBox1.Location = New System.Drawing.Point(81, 69)
        ListBox1.Size = New System.Drawing.Size(120, 95)
        ListBox1.DrawMode = DrawMode.OwnerDrawFixed
        Controls.Add(ListBox1)
    
    End Sub

    Private Sub ListBox1_DrawItem(ByVal sender As Object, _
     ByVal e As System.Windows.Forms.DrawItemEventArgs) _
     Handles ListBox1.DrawItem

        ' Draw the background of the ListBox control for each item.
        e.DrawBackground()

        ' Define the default color of the brush as black.
        Dim myBrush As Brush = Brushes.Black

        ' Determine the color of the brush to draw each item based on   
        ' the index of the item to draw.
        Select Case e.Index
            Case 0
                myBrush = Brushes.Red
            Case 1
                myBrush = Brushes.Orange
            Case 2
                myBrush = Brushes.Purple
        End Select

        ' Draw the current item text based on the current 
        ' Font and the custom brush settings.
        e.Graphics.DrawString(ListBox1.Items(e.Index).ToString(), _
            e.Font, myBrush, e.Bounds, StringFormat.GenericDefault)

        ' If the ListBox has focus, draw a focus rectangle around  _ 
        ' the selected item.
        e.DrawFocusRectangle()
    End Sub