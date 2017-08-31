Public Class DataRepeaterWalkthrough

    Private Sub CustomersBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomersBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.CustomersBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.NorthwndDataSet)

    End Sub

    Private Sub DataRepeaterWalkthrough_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwndDataSet.Orders' table. You can move, or remove it, as needed.
        Me.OrdersTableAdapter.Fill(Me.NorthwndDataSet.Orders)
        'TODO: This line of code loads data into the 'NorthwndDataSet.Customers' table. You can move, or remove it, as needed.
        Me.CustomersTableAdapter.Fill(Me.NorthwndDataSet.Customers)
        ' <Snippet3>
        DataRepeater1.AllowUserToAddItems = False
        DataRepeater1.AllowUserToDeleteItems = False
        BindingNavigatorAddNewItem.Enabled = False
        CustomersBindingSource.AllowNew = False
        BindingNavigatorDeleteItem.Enabled = False
        ' </Snippet3>
    End Sub

    

    Private Sub DataRepeater1_DrawItem(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs) Handles DataRepeater1.DrawItem
        ' <Snippet1>
        ' Alternate the back color.
        If (e.DataRepeaterItem.ItemIndex Mod 2) <> 0 Then
            ' Apply the secondary back color.
            e.DataRepeaterItem.BackColor = Color.AliceBlue
        Else
            ' Apply the default back color.
            e.DataRepeaterItem.BackColor = DataRepeater1.BackColor
        End If
        ' </Snippet1>
        ' <Snippet2>
        If e.DataRepeaterItem.Controls(RegionTextBox.Name).Text = "" Then
            e.DataRepeaterItem.Controls("RegionLabel").
             ForeColor = Color.Red
        Else
            e.DataRepeaterItem.Controls("RegionLabel").
             ForeColor = Color.Black
        End If
        ' </Snippet2>
    End Sub

    

    Private Sub BindingNavigatorDeleteItem_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BindingNavigatorDeleteItem.EnabledChanged
        ' <Snippet4>
        If BindingNavigatorDeleteItem.Enabled = True Then
            BindingNavigatorDeleteItem.Enabled = False
        End If
        ' </Snippet4>
    End Sub

    Private Sub SearchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchButton.Click
        ' <Snippet5>
        Dim foundIndex As Integer
        Dim searchString As String
        searchString = SearchTextBox.Text
        ' Search for the string in the CustomerID field.
        foundIndex = CustomersBindingSource.Find("CustomerID",
         searchString)
        If foundIndex > -1 Then
            DataRepeater1.CurrentItemIndex = foundIndex
        Else
            MsgBox("Item " & searchString & " not found.")
        End If
        ' </Snippet5>
    End Sub
End Class
