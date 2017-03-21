        ' Set the header font to Arial with size 20.
        Private Sub button6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button6.Click
            myDataGrid.HeaderFont = New Font("Arial", 20)
        End Sub 'button6_Click

        ' Reset the header font.
        Private Sub button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button5.Click
            myDataGrid.ResetHeaderFont()
        End Sub 'button5_Click
