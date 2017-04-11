Imports System.Linq
Imports System.Collections.Generic
Imports System.Diagnostics

Class Customer
    Public Country As String
    Public City As String
    Public CompanyName As String
    Public CustomerID As String
    Public State As String
    Public Orders As List(Of Order)
    Public Subscriber As Boolean
End Class

Class Order
    Public CustomerID As String
    Public Amount As Double
    Public OrderDate As DateTime
End Class

Class Product
    Public ID As Integer
    Public Name As String
    Public Category As String
    Public UnitPrice As Decimal
End Class

Class Book
    Public price As Decimal
End Class

Class ProcessDescription
    Public ProcessName As String
    Public Description As String
End Class


Class Snippets

    Private customers As List(Of Customer) = GetCustomerList()
    Private domesticCustomers As List(Of Customer) = GetCustomerList()
    Private internationalCustomers As List(Of Customer) = GetCustomerList()
    Private orders As List(Of Order) = GetOrderList()
    Private products As List(Of Product) = GetProductList()
    Private books As List(Of Book) = GetBookList()
    Private processDescriptions As List(Of ProcessDescription) = GetProcessDescriptions()


    Function GetCustomerList() As List(Of Customer)
        Return New List(Of Customer)
    End Function

    Function GetOrderList() As List(Of Order)
        Return New List(Of Order)
    End Function

    Function GetProductList() As List(Of Product)
        Return New List(Of Product)
    End Function

    Function GetBookList() As List(Of Book)
        Return New List(Of Book)
    End Function

    Function GetProcessDescriptions() As List(Of ProcessDescription)
        Return New List(Of ProcessDescription)
    End Function


    Sub Query7()
        '<Snippet7>
        ' Returns the company name for all customers for which
        ' the Country is equal to "Canada".
        Dim names = From cust In customers
                    Where cust.Country = "Canada"
                    Select cust.CompanyName
        '</Snippet7>

        '<Snippet8>
        ' Returns the company name and ID value for each
        ' customer as a collection of a new anonymous type.
        Dim customerList = From cust In customers
                           Select cust.CompanyName, cust.CustomerID
        '</Snippet8>
    End Sub

    Sub Query9()
        '<Snippet9>
        ' Returns all product names for which the Category of
        ' the product is "Beverages".
        Dim names = From product In products
                    Where product.Category = "Beverages"
                    Select product.Name
        '</Snippet9>

        '<Snippet10>
        ' Returns a list of books sorted by price in 
        ' ascending order.
        Dim titlesAscendingPrice = From b In books
                                   Order By b.price
        '</Snippet10>

        '<Snippet11>
        ' Returns a combined collection of all of the 
        ' processes currently running and a descriptive
        ' name for the process taken from a list of 
        ' descriptive names.
        Dim processes = From proc In Process.GetProcesses
                        Join desc In processDescriptions
                          On proc.ProcessName Equals desc.ProcessName
                        Select proc.ProcessName, proc.Id, desc.Description
        '</Snippet11>

        '<Snippet12>
        ' Returns a list of orders grouped by the order date
        ' and sorted in ascending order by the order date.
        Dim orderList = From order In orders
                        Order By order.OrderDate
                        Group By OrderDate = order.OrderDate
                        Into OrdersByDate = Group
        '</Snippet12>

        '<Snippet13>
        ' Returns a combined collection of customers and
        ' customer orders.
        Dim customerList = From cust In customers
                           Group Join ord In orders On
                             cust.CustomerID Equals ord.CustomerID
                           Into CustomerOrders = Group,
                                TotalOfOrders = Sum(ord.Amount)
                           Select cust.CompanyName, cust.CustomerID,
                                  CustomerOrders, TotalOfOrders
        '</Snippet13>

        '<Snippet14>
        ' Returns the sum of all order amounts.
        Dim orderTotal = Aggregate order In orders
                         Into Sum(order.Amount)
        '</Snippet14>

        '<Snippet15>
        ' Returns the customer company name and largest 
        ' order amount for each customer.
        Dim customerMax = From cust In customers
                          Aggregate order In cust.Orders
                          Into MaxOrder = Max(order.Amount)
                          Select cust.CompanyName, MaxOrder
        '</Snippet15>

        '<Snippet16>
        ' Returns a list of products with a calculation of
        ' a ten percent discount.
        Dim discountedProducts = From prod In products
                                 Let Discount = prod.UnitPrice * 0.1
                                 Where Discount >= 50
                                 Select prod.Name, prod.UnitPrice, Discount
        '</Snippet16>

        '<Snippet17>
        ' Returns a list of cities with no duplicate entries.
        Dim cities = From item In customers
                     Select item.City
                     Distinct
        '</Snippet17>
    End Sub

    Sub Query10()
        '<Snippet18>
        ' Returns a list of customers. The first 10 customers
        ' are ignored and the remaining customers are
        ' returned.
        Dim customerList = From cust In customers
                           Skip 10
        '</Snippet18>
    End Sub

    Sub Query11()
        '<Snippet19>
        ' Returns a list of customers. The query ignores all
        ' customers until the first customer for whom
        ' IsSubscriber returns false. That customer and all
        ' remaining customers are returned.
        Dim customerList = From cust In customers
                           Skip While IsSubscriber(cust)
        '</Snippet19>
    End Sub

    Public Function IsSubscriber(ByVal cust As Customer) As Boolean
        Return cust.Subscriber
    End Function

    Sub Query12()
        '<Snippet20>
        ' Returns the first 10 customers.
        Dim customerList = From cust In customers
                           Take 10
        '</Snippet20>

        '<Snippet21>
        ' Returns a list of customers. The query returns
        ' customers until the first customer for whom 
        ' HasOrders returns false. That customer and all 
        ' remaining customers are ignored.
        Dim customersWithOrders = From cust In customers
                                  Order By cust.Orders.Count Descending
                                  Take While HasOrders(cust)
        '</Snippet21>
    End Sub

    Public Function HasOrders(ByVal cust As Customer) As Boolean
        Return cust.Orders.Count > 0
    End Function

    '<Snippet22> 
    Public Function GetAllCustomers() As List(Of Customer)
        Dim customers1 = From cust In domesticCustomers
        Dim customers2 = From cust In internationalCustomers

        Dim customerList = customers1.Union(customers2)

        Return customerList.ToList()
    End Function
    '</Snippet22>

End Class