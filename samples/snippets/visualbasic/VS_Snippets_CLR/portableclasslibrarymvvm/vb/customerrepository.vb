' <snippet2>
Namespace SimpleMVVM.Model
    Public Class CustomerRepository
        Private _customers As List(Of Customer)

        Public Sub New()
            _customers = New List(Of Customer) From
            {
                New Customer() With {.CustomerID = 1, .FullName = "Dana Birkby", .Phone = "394-555-0181"},
                New Customer() With {.CustomerID = 2, .FullName = "Adriana Giorgi", .Phone = "117-555-0119"},
                New Customer() With {.CustomerID = 3, .FullName = "Wei Yu", .Phone = "798-555-0118"}
            }
        End Sub

        Public Function GetCustomers() As List(Of Customer)
            Return _customers
        End Function

        Public Sub UpdateCustomer(SelectedCustomer As Customer)
            Dim customerToChange = _customers.Single(Function(c) c.CustomerID = SelectedCustomer.CustomerID)
            customerToChange = SelectedCustomer
        End Sub
    End Class
End Namespace
' </snippet2>