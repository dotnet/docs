Public Class Form1

    '--------------------------------------------------------------------------
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwindDataSet.Customers' table. You can move, or remove it, as needed.

        '<Snippet1>
        Me.CustomersTableAdapter.Fill(Me.NorthwindDataSet.Customers)
        '</Snippet1>

        '<Snippet2>
        CustomersTableAdapter.Update(NorthwindDataSet.Customers)
        '</Snippet2>

        '<Snippet3>
        TextBox1.Text = NorthwindDataSet.Customers(3).ContactName
        '</Snippet3>


        '<Snippet6>
        Dim customerID As String = "ALFKI"
        Dim orders() As NorthwindDataSet.OrdersRow

        orders = CType(NorthwindDataSet.Customers.FindByCustomerID(customerID).
            GetChildRows("FK_Orders_Customers"), NorthwindDataSet.OrdersRow())

        MessageBox.Show(orders.Length.ToString())
        '</Snippet6>


        '<Snippet7>
        Dim orderID As Integer = 10707
        Dim customer As NorthwindDataSet.CustomersRow

        customer = CType(NorthwindDataSet.Orders.FindByOrderID(orderID).
            GetParentRow("FK_Orders_Customers"), NorthwindDataSet.CustomersRow)

        MessageBox.Show(customer.CompanyName)
        '</Snippet7>
    End Sub


    '--------------------------------------------------------------------------
    Sub TestTyped()

        '<Snippet4>
        ' This accesses the CustomerID column in the first row of the Customers table.
        Dim customerIDValue As String = NorthwindDataSet.Customers(0).CustomerID
        '</Snippet4>
    End Sub


    '--------------------------------------------------------------------------
    Sub TestUnTyped()
        Dim dataset1 As New DataSet

        '<Snippet5>
        Dim customerIDValue As String =
            CType(dataset1.Tables("Customers").Rows(0).Item("CustomerID"), String)
        '</Snippet5>
    End Sub


    '--------------------------------------------------------------------------
    Private Sub CustomersBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomersBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.CustomersBindingSource.EndEdit()
        Me.CustomersTableAdapter.Update(Me.NorthwindDataSet.Customers)
    End Sub
End Class
