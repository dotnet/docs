' *****************************************************************************
Option Infer On
Imports System.Diagnostics
Imports System.Collections.Generic

Module Module1

    Sub Main()

        '<Snippet2>
        ' Using explicit typing.
        Dim name1 As String = "Springfield"

        ' Using local type inference.
        Dim name2 = "Springfield"
        '</Snippet2>


        '<Snippet3>
        ' Using explicit typing.
        Dim someNumbers1() As Integer = New Integer() {4, 18, 11, 9, 8, 0, 5}

        ' Using local type inference.
        Dim someNumbers2 = New Integer() {4, 18, 11, 9, 8, 0, 5}
        '</Snippet3>

        '<Snippet4>
        Dim total = 0
        For Each number In someNumbers2
            total += number
        Next
        '</Snippet4>

        '<Snippet5>
        ' Using explicit typing.
        Dim pList1() As Process = Process.GetProcesses()

        ' Using local type inference.
        Dim pList2 = Process.GetProcesses()
        '</Snippet5>

        Dim CustomerList = GetCustomers()
        Dim customers = GetCustomers()

        ' 4ad3e6e9-8f5b-4209-a248-de22ef6e4652
        ' Option Infer Statement
        '<Snippet6>
        ' Enable Option Infer before trying these examples.

        ' Variable num is an Integer.
        Dim num = 5

        ' Variable dbl is a Double.
        Dim dbl = 4.113

        ' Variable str is a String.
        Dim str = "abc"

        ' Variable pList is an array of Process objects.
        Dim pList = Process.GetProcesses()

        ' Variable i is an Integer.
        For i = 1 To 10
            Console.WriteLine(i)
        Next

        ' Variable item is a string.
        Dim lst As New List(Of String) From {"abc", "def", "ghi"}

        For Each item In lst
            Console.WriteLine(item)
        Next

        ' Variable namedCust is an instance of the Customer class.
        Dim namedCust = New Customer With {.Name = "Blue Yonder Airlines",
                                           .City = "Snoqualmie"}

        ' Variable product is an instance of an anonymous type.
        Dim product = New With {Key .Name = "paperclips", .Price = 1.29}

        ' If customers is a collection of Customer objects in the following 
        ' query, the inferred type of cust is Customer, and the inferred type
        ' of custs is IEnumerable(Of Customer).
        Dim custs = From cust In customers 
                    Where cust.City = "Seattle" 
                    Select cust.Name, cust.ID
        '</Snippet6>

        '<Snippet7>
        Using proc = New System.Diagnostics.Process
            ' Insert code to work with the resource.
        End Using
        '</Snippet7>


        ' 4ad3e6e9-8f5b-4209-a248-de22ef6e4652
        ' Option Infer Statement
        '<Snippet11>
        ' Disable Option Infer when trying this example.

        Dim someVar = 5
        Console.WriteLine(someVar.GetType.ToString)

        ' If Option Infer is instead enabled, the following
        ' statement causes a run-time error. This is because
        ' someVar was implicitly defined as an integer.
        someVar = "abc"
        Console.WriteLine(someVar.GetType.ToString)

        ' Output:
        '  System.Int32
        '  System.String
        '</Snippet11>


    End Sub
    '<Snippet1>
    Public Sub inferenceExample()

        ' Using explicit typing.
        Dim num1 As Integer = 3

        ' Using local type inference.
        Dim num2 = 3

    End Sub
    '</Snippet1>

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
        Private _name, _city, _state As String
        Private _id As Integer


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
        Property ID() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property
    End Class


End Module
