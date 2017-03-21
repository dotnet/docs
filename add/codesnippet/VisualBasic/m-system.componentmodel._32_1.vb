    ' Add the new part unless the part number contains
    ' spaces. In that case cancel the add.
    Private Sub button1_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles button1.Click

        Dim newPart As Part = listOfParts.AddNew()

        If newPart.PartName.Contains(" ") Then
            MessageBox.Show("Part names cannot contain spaces.")
            listOfParts.CancelNew(listOfParts.IndexOf(newPart))
        Else
            textBox2.Text = randomNumber.Next(9999).ToString()
            textBox1.Text = "Enter part name"
        End If

    End Sub