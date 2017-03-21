            Dim myPreferredRowHeight As Integer = Convert.ToInt32(myTextBox.Text.Trim())
            If myPreferredRowHeight < 18 Or myPreferredRowHeight > 134 Then
                MessageBox.Show("Enter the height between 18 and 134")
                Return
            End If
            ' Set the 'PreferredRowHeight' property of DataGridTableStyle instance.
            myTableStyle.PreferredRowHeight = myPreferredRowHeight
            ' Add the DataGridTableStyle instance to the GridTableStylesCollection. 
            myDataGrid.TableStyles.Add(myTableStyle)