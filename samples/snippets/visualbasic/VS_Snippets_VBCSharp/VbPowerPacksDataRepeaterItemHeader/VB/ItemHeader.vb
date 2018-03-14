Public Class ItemHeader

    Private Sub CustomersBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomersBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.CustomersBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.NorthwndDataSet)

    End Sub

    Private Sub ItemHeader_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwndDataSet.Customers' table. You can move, or remove it, as needed.
        Me.CustomersTableAdapter.Fill(Me.NorthwndDataSet.Customers)

    End Sub
    ' <Snippet1>
    Private Sub Button1_Click() Handles Button1.Click
        ' Change the orientation and set the ItemHeaderSize accordingly.
        If DataRepeater1.LayoutStyle = 
           PowerPacks.DataRepeaterLayoutStyles.Vertical Then

            DataRepeater1.LayoutStyle = 
                PowerPacks.DataRepeaterLayoutStyles.Horizontal
            DataRepeater1.ItemHeaderSize = 12
        Else
            DataRepeater1.LayoutStyle = 
                PowerPacks.DataRepeaterLayoutStyles.Vertical
            DataRepeater1.ItemHeaderSize = 18
        End If
    End Sub
    ' </Snippet1>
End Class
