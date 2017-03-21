    Private Sub CreateMyLabel()

        ' Create a new label and bitmap.

        Dim Label1 As New Label()
        Dim Image1 As Image

        Image1 = Image.FromFile("c:\\MyImage.bmp")
       

        ' Set the size of the label to accommodate the bitmap size.

        Label1.Size = Image1.Size        

        ' Initialize the label control's Image property.

        Label1.Image = Image1

        ' ...Code to add the control to the form...

    End Sub