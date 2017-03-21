    Private Sub MySetButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Set the 'HeaderFont' property of DataGridTableStyle instance.
        myTableStyle.HeaderFont = New Font("Impact", 10)
        ' Add the DataGridTableStyle instance to the GridTableStylesCollection. 
        myDataGrid.TableStyles.Add(myTableStyle)
    End Sub 'MySetButton_Click
   
    Private Sub MyResetButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Reset the Header Font to its default value.
        myTableStyle.ResetHeaderFont()
    End Sub 'MyResetButton_Click