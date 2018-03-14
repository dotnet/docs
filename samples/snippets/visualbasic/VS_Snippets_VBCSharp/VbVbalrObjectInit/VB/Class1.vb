'********************************************************************
Option Infer On
Imports System.Collections.Generic

Module Module1

    Sub Main()
        '<Snippet1>
        Dim namedCust = New Customer With {.Name = "Terry Adams"}
        '</Snippet1>

        '<Snippet2>
        Dim anonymousCust = New With {.Name = "Hugo Garcia"}
        '</Snippet2>

        '<Snippet3>
        Dim cust0 As Customer = New Customer With {.Name = "Toni Poe", 
                                                   .City = "Louisville"}
        '</Snippet3>


        '<Snippet4>
        Dim cust1 As New Customer With {.Name = "Toni Poe", 
                                        .City = "Louisville"}
        '</Snippet4>

        '<Snippet5>
        Dim cust2 As New Customer()
        With cust2
            .Name = "Toni Poe"
            .City = "Louisville"
        End With
        '</Snippet5>

        '<Snippet6>
        Dim cust3 As Customer = 
            New Customer("Toni Poe") With {.City = "Louisville"}
        ' --or--
        Dim cust4 As New Customer("Toni Poe") With {.City = "Louisville"}
        '</Snippet6>

        '<Snippet7>
        Dim cust5 As Customer = New Customer With {.Name = "Toni Poe"}
        '</Snippet7>

        '<Snippet8>
        Dim cust6 = New Customer With {.Name = "Toni Poe", 
                                       .City = "Louisville"}
        '</Snippet8>

        '<Snippet9>
        '' This code does not compile because Name is initialized twice.
        ' Dim cust7 = New Customer With {.Name = "Toni Poe", 
        '                                .City = "Louisville",
        '                                .Name = "Blue Yonder Airlines"}
        '</Snippet9>

        '<Snippet10>
        Dim cust8 = New Customer With {.Name = .Name & ", President"}
        Dim cust9 = New Customer With {.Name = "Toni Poe", 
                                       .Title = .Name & ", President"}
        '</Snippet10>
        Console.WriteLine(cust8.Name)
        Console.WriteLine(cust9.Title)

        '<Snippet11>
        Dim cust10 = New Customer("Toni Poe") With {.Name = .Name & ", President"}
        ' --or--
        Dim cust11 As New Customer("Toni Poe") With {.Name = .Name & ", President"}
        '</Snippet11>
        Console.WriteLine(cust10.Name)
        Console.WriteLine(cust11.Name)

        '<Snippet12>
        Dim cust12 = 
            New Customer With {.Name = "Toni Poe", 
                               .Address = 
                                   New AddressClass With {.City = "Louisville", 
                                                          .State = "Kentucky"}}
        Console.WriteLine(cust12.Address.State)
        '</Snippet12>

        '<Snippet13>
        Dim cust13 = New With {.Name = "Toni Poe", 
                               .City = "Louisville"}
        '</Snippet13>

        '<Snippet14>

        Dim anonymousCust1 = New With {Key .Name = "Hugo Garcia", 
                                       Key .City = "Louisville"}
        '</Snippet14>

        '<Snippet15>
        ' Create a variable, Name, and give it an initial value.
        Dim Name = "Hugo Garcia"

        ' Variable anonymousCust2 will have one property, Name, with 
        ' "Hugo Garcia" as its initial value.
        Dim anonymousCust2 = New With {Key Name}

        ' The next declaration uses a property from namedCust, defined
        ' in an earlier example. After the declaration, anonymousCust3 will
        ' have one property, Name, with "Terry Adams" as its value.
        Dim anonymousCust3 = New With {Key namedCust.Name}
        '</Snippet15>

        'Dim c1 = New Customer With {.OrderNumbers(0) = 148662}
        'Dim c2 = New Customer with {.Address.City = "Springfield"}

    End Sub

    ' Function GetCustomers returns a list of Customer objects.
    Function GetCustomers() As IEnumerable(Of Customer)
        Dim customerList As New System.Collections.Generic.List(Of Customer)
        Dim customer0 As New Customer With {.Name = "Michael", 
                                            .City = "Tucker", 
                                            .State = "Junior", 
                                            .ID = 123}
        Dim customer1 As New Customer With {.Name = "Svetlana", 
                                            .City = "Omelchenko", 
                                            .State = "Senior", 
                                            .ID = 456}
        Dim customer2 As New Customer With {.Name = "Michiko", 
                                            .City = "Osada", 
                                            .State = "Senior", 
                                            .ID = 789}
        Dim customer3 As New Customer With {.Name = "Sven", 
                                            .City = "Mortensen", 
                                            .State = "Freshman"}
        Dim customer4 As New Customer With {.Name = "Hugo", 
                                            .City = "Garcia", 
                                            .State = "Junior"}
        Dim customer5 As New Customer With {.Name = "Cesar", 
                                          .City = "Garcia", 
                                          .State = "Freshman", 
                                          .ID = 890}
        Dim customer6 As New Customer With {.Name = "Fadi", 
                                            .City = "Fakhouri", 
                                            .State = "Senior", 
                                            .ID = 765}
        customerList.Add(customer0)
        customerList.Add(customer1)
        customerList.Add(customer2)
        customerList.Add(customer3)
        customerList.Add(customer4)
        customerList.Add(customer5)
        customerList.Add(customer6)
        'customerList.Add(customer7)
        'customerList.Add(customer8)
        'customerList.Add(customer9)
        'customerList.Add(customer10)
        Return customerList
    End Function


    Public Class Customer
        Private _name, _city, _state, _title As String
        Private _id As Integer
        Public Address As AddressClass
        Public OrderNumbers() As Integer
        Public OrderNumber As Integer
        Sub New()

        End Sub
        Sub New(ByVal newName As String)
            _name = newName
        End Sub
        Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property
        Property City() As String
            Get
                Return _city
            End Get
            Set(ByVal value As String)
                _city = value
            End Set
        End Property
        Property State() As String
            Get
                Return _state
            End Get
            Set(ByVal value As String)
                _state = value
            End Set
        End Property
        Property Title() As String
            Get
                Return _title
            End Get
            Set(ByVal value As String)
                _title = value
            End Set
        End Property
        Property ID() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property
    End Class
    Class AddressClass
        Public City, State As String
    End Class
End Module
