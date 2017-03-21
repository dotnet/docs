    Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Me.Load

        ' Set the data source to the Brush type and populate
        ' BindingSource1 with some brushes.
        BindingSource1.DataSource = GetType(System.Drawing.Brush)
        BindingSource1.Add(New TextureBrush(New Bitmap(GetType(Button), _
            "Button.bmp")))
        BindingSource1.Add(New HatchBrush(HatchStyle.Cross, Color.Red))
        BindingSource1.Add(New SolidBrush(Color.Blue))

    End Sub



    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
         Handles button1.Click

        ' If you are not at the end of the list, move to the next item
        ' in the BindingSource.
        If BindingSource1.Position + 1 < BindingSource1.Count Then
            BindingSource1.MoveNext()

            ' Otherwise, move back to the first item.
        Else
            BindingSource1.MoveFirst()
        End If

        ' Force the form to repaint.
        Me.Invalidate()

    End Sub


    Sub Form1_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)

        ' Get the current item in the BindingSource.
        Dim item As Brush = CType(BindingSource1.Current, Brush)

        ' If the current type is a TextureBrush, fill an ellipse.
        If item.GetType().Equals(GetType(TextureBrush)) Then
            e.Graphics.FillEllipse(item, _
            e.ClipRectangle)

            ' If the current type is a HatchBrush, fill a triangle.
        ElseIf item.GetType().Equals(GetType(HatchBrush)) Then
            e.Graphics.FillPolygon(item, New Point() _
             {New Point(0, 0), New Point(0, 200), New Point(200, 0)})

            ' Otherwise, fill a rectangle.
        Else
            e.Graphics.FillRectangle(item, e.ClipRectangle)
        End If

    End Sub
