Public Class Form1


    '<Snippet1>
    Private Sub InsertButton_Click() Handles InsertButton.Click

        Dim newRegionID As Integer = 5
        Dim newRegionDescription As String = "NorthEastern"

        Try
            RegionTableAdapter1.Insert(newRegionID, newRegionDescription)

        Catch ex As Exception
            MessageBox.Show("Insert Failed")
        End Try

        RefreshDataset()
    End Sub


    Private Sub RefreshDataset()
        Me.RegionTableAdapter1.Fill(Me.NorthwindDataSet1._Region)
    End Sub
    '</Snippet1>


    '<Snippet2>
    Private Sub UpdateButton_Click() Handles UpdateButton.Click

        Dim newRegionID As Integer = 5

        Try
            RegionTableAdapter1.Update(newRegionID, "Updated Region Description", 5, "NorthEastern")

        Catch ex As Exception
            MessageBox.Show("Update Failed")
        End Try

        RefreshDataset()
    End Sub
    '</Snippet2>


    '<Snippet3>
    Private Sub DeleteButton_Click() Handles DeleteButton.Click

        Try
            RegionTableAdapter1.Delete(5, "Updated Region Description")

        Catch ex As Exception
            MessageBox.Show("Delete Failed")
        End Try

        RefreshDataset()
    End Sub
    '</Snippet3>


    Private Sub RegionBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Validate()
        Me.RegionBindingSource.EndEdit()
        Me.RegionTableAdapter1.Update(Me.NorthwindDataSet1._Region)
    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwindDataSet1._Region' table. You can move, or remove it, as needed.
        Me.RegionTableAdapter1.Fill(Me.NorthwindDataSet1._Region)
    End Sub

End Class
