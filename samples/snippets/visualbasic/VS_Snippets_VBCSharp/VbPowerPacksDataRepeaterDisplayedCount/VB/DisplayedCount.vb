Public Class DisplayedCount

    Private Sub CustomersBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomersBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.CustomersBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.NorthwndDataSet)

    End Sub

    Private Sub DisplayedCount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwndDataSet.Customers' table. You can move, or remove it, as needed.
        Me.CustomersTableAdapter.Fill(Me.NorthwndDataSet.Customers)

    End Sub
    ' <Snippet1>
    Private Sub Button1_Click() Handles Button1.Click
        Dim msgString As String
        Dim intFull As Integer
        Dim intPartial As Integer
        ' Get the count without including partially displayed items.
        intFull = DataRepeater1.DisplayedItemCount(False)
        ' Get the count, including partially displayed items.
        intPartial = DataRepeater1.DisplayedItemCount(True)
        ' Create the message string.
        msgString = CStr(intFull)
        msgString &= " items are fully visible and "
        ' Subtract the full count from the partial count.
        msgString &= CStr(intPartial - intFull)
        msgString &= " items are partially visible."
        MsgBox(msgString)
    End Sub
    ' </Snippet1>

End Class
