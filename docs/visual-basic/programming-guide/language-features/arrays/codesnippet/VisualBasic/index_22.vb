    ' Define the class for a customer.
    Public Class Customer
        Public Property Name As String
        ' Insert code for other members of customer structure.
    End Class

    ' Create a module-level collection that can hold 200 elements.
    Public CustomerList As New List(Of Customer)(200)

    ' Add a specified customer to the collection.
    Private Sub AddNewCustomer(ByVal newCust As Customer)
        ' Insert code to perform validity check on newCust.
        CustomerList.Add(newCust)
    End Sub

    ' Display the list of customers in the Debug window.
    Private Sub PrintCustomers()
        For Each cust As Customer In CustomerList
            Debug.WriteLine(cust)
        Next cust
    End Sub