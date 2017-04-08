Public Class Form5

    '--------------------------------------------------------------------------
    Sub OtherSnips()

        '--------------------------------------------------
        '<Snippet14>
        ' Create a new row.
        Dim newRegionRow As NorthwindDataSet.RegionRow
        newRegionRow = Me.NorthwindDataSet._Region.NewRegionRow()
        newRegionRow.RegionID = 5
        newRegionRow.RegionDescription = "NorthWestern"

        ' Add the row to the Region table
        Me.NorthwindDataSet._Region.Rows.Add(newRegionRow)

        ' Save the new row to the database
        Me.RegionTableAdapter.Update(Me.NorthwindDataSet._Region)
        '</Snippet14>


        '--------------------------------------------------
        '<Snippet17>
        ' Locate the row you want to update.
        Dim regionRow As NorthwindDataSet.RegionRow
        regionRow = NorthwindDataSet._Region.FindByRegionID(1)

        ' Assign the new value to the desired column.
        regionRow.RegionDescription = "East"

        ' Save the updated row to the database
        Me.RegionTableAdapter.Update(Me.NorthwindDataSet._Region)
        '</Snippet17>


        '--------------------------------------------------
        '<Snippet20>
        ' Locate the row to delete.
        Dim oldRegionRow As NorthwindDataSet.RegionRow
        oldRegionRow = NorthwindDataSet._Region.FindByRegionID(5)

        ' Delete the row from the dataset
        oldRegionRow.Delete()

        ' Delete the row from the database
        Me.RegionTableAdapter.Update(Me.NorthwindDataSet._Region)
        '</Snippet20>
    End Sub


    '--------------------------------------------------------------------------
    Private Sub RegionBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegionBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.RegionBindingSource.EndEdit()
        Me.RegionTableAdapter.Update(Me.NorthwindDataSet._Region)

    End Sub


    '--------------------------------------------------------------------------
    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwindDataSet._Region' table. You can move, or remove it, as needed.
        Me.RegionTableAdapter.Fill(Me.NorthwindDataSet._Region)
    End Sub
End Class