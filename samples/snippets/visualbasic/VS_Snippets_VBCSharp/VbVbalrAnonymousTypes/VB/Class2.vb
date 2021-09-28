' **************************************************************************
Option Infer On
Imports System.Collections.Generic

Module Module1

    Sub Main()
        '<Snippet19>
        ' Variable product1 is an instance of an anonymous type.
        Dim product1 = New With {.Name = "paperclips", .Price = 1.29}
        '</Snippet19>

        '<Snippet20>
        ' Variable product2 is an instance of Product.
        Dim product2 = New Product With {.Name = "paperclips", .Price = 1.29}
        '</Snippet20>

        '<Snippet21>
        Dim product2a As New Product With {.Name = "paperclips", .Price = 1.29}
        '</Snippet21>

        '<Snippet22>
        Dim product2b As New Product("paperclips", 1.29)
        '</Snippet22>

        '<Snippet23>
        Dim product2c As New Product
        product2c.Name = "paperclips"
        product2c.Price = 1.29
        '</Snippet23>

        '<Snippet24>
        Dim employee01 = New With {Key .Name = "Bob", Key .Category = 3, .InOffice = False}

        ' employee02 has no InOffice property.
        Dim employee02 = New With {Key .Name = "Bob", Key .Category = 3}

        ' The first property has a different name.
        Dim employee03 = New With {Key .FirstName = "Bob", Key .Category = 3, .InOffice = False}

        ' Property Category has a different value.
        Dim employee04 = New With {Key .Name = "Bob", Key .Category = 2, .InOffice = False}

        ' Property Category has a different type.
        Dim employee05 = New With {Key .Name = "Bob", Key .Category = 3.2, .InOffice = False}

        ' The properties are declared in a different order.
        Dim employee06 = New With {Key .Category = 3, Key .Name = "Bob", .InOffice = False}

        ' Property Category is not a key property.
        Dim employee07 = New With {Key .Name = "Bob", .Category = 3, .InOffice = False}

        ' employee01 and employee 08 meet all conditions for equality. Note 
        ' that the values of the non-key field need not be the same.
        Dim employee08 = New With {Key .Name = "Bob", Key .Category = 2 + 1, .InOffice = True}

        ' Equals returns True only for employee01 and employee08.
        Console.WriteLine(employee01.Equals(employee08))
        '</Snippet24>

        '<Snippet25>
        ' Variable product is an instance of an anonymous type.
        Dim product = New With {Key .Name = "paperclips", Key .Price = 1.29, .OnHand = 24}
        '</Snippet25>

        'Snippets from Key topic start here.

        '<Snippet26>
        Dim flight1 = New With {Key .Airline = "Blue Yonder Airlines",
                                Key .FlightNo = 3554, .Gate = "C33"}
        '</Snippet26>

        '<Snippet27>
        Dim flight2 = New With {Key .Airline = "Blue Yonder Airlines",
                                Key .FlightNo = 3554, .Gate = "D14"}
        ' The following statement displays True. The values of the non-key 
        ' property, Gate, do not have to be equal.
        Console.WriteLine(flight1.Equals(flight2))

        Dim flight3 = New With {Key .Airline = "Blue Yonder Airlines",
                                Key .FlightNo = 431, .Gate = "C33"}
        ' The following statement displays False, because flight3 has a
        ' different value for key property FlightNo.
        Console.WriteLine(flight1.Equals(flight3))

        Dim flight4 = New With {Key .Airline = "Blue Yonder Airlines",
                                .FlightNo = 3554, .Gate = "C33"}
        ' The following statement displays False. Instance flight4 is not the 
        ' same type as flight1 because they have different key properties. 
        ' FlightNo is a key property of flight1 but not of flight4.
        Console.WriteLine(flight1.Equals(flight4))
        '</Snippet27>

        '<Snippet28>
        ' The following statement will not compile, because FlightNo is a key
        ' property and cannot be changed.
        ' flight1.FlightNo = 1234
        '
        ' Gate is not a key property. Its value can be changed.
        flight1.Gate = "C5"
        '</Snippet28>

        '<Snippet37>
        Console.WriteLine(flight1.GetHashCode = flight2.GetHashCode)
        '</Snippet37>

        '<Snippet38>
        Console.WriteLine(flight1.GetHashCode = flight3.GetHashCode)
        '</Snippet38>

        '<Snippet39>
        Console.WriteLine(flight1.GetHashCode = flight4.GetHashCode)
        '</Snippet39>

        '<Snippet29>
        Console.WriteLine(employee01.ToString())
        Console.WriteLine(employee01)
        ' The preceding statements both display the following:
        ' { Name = Bob, Category = 3, InOffice = False }
        '</Snippet29>

        Dim customers = GetCustomers()
        '<Snippet30>
        Dim custs1 = From cust In customers
                     Select cust.Name
        '</Snippet30>

        '<Snippet31>
        Dim custs2 = From cust In customers
                     Select cust
        '</Snippet31>

        '<Snippet32>
        Dim custs3 = From cust In customers
                     Select cust.Name, cust.ID
        '</Snippet32>

        '<Snippet33>
        For Each selectedCust In custs3
            Console.WriteLine(selectedCust.ID & ": " & selectedCust.Name)
        Next
        '</Snippet33>

    End Sub

    Function listProducts() As IEnumerable(Of Product)
        Dim productList As New System.Collections.Generic.List(Of Product)
        Dim product0 As New Product With {.Name = "Michael",
                                          .Price = 1.23,
                                          .OnHand = 123}
        Dim product1 As New Product With {.Name = "Svetlana",
                                          .Price = 6.99,
                                          .OnHand = 456}
        Dim product2 As New Product With {.Name = "Michiko",
                                          .Price = 4.59,
                                          .OnHand = 34}
        Dim product3 As New Product With {.Name = "Sven",
                                          .Price = 14.99,
                                          .OnHand = 70}
        Dim product4 As New Product With {.Name = "Hugo",
                                          .Price = 399.98,
                                          .OnHand = 789}
        Dim product5 As New Product With {.Name = "Cesar",
                                          .Price = 1.99,
                                          .OnHand = 890}
        Dim product6 As New Product With {.Name = "Fadi",
                                          .Price = 59.99,
                                          .OnHand = 65}
        productList.Add(product0)
        productList.Add(product1)
        productList.Add(product2)
        productList.Add(product3)
        productList.Add(product4)
        productList.Add(product5)
        productList.Add(product6)
        Return productList
    End Function
    Class Product

        Private _name As String
        Private _price As Double
        Private _onHand As Integer
        Sub New()

        End Sub
        Sub New(ByVal newName As String, ByVal newPrice As Double)
            _name = newName
            _price = newPrice
        End Sub
        Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property
        Property Price() As Double
            Get
                Return _price
            End Get
            Set(ByVal value As Double)
                _price = value
            End Set
        End Property
        Property OnHand() As Integer
            Get
                Return _onHand
            End Get
            Set(ByVal value As Integer)
                _onHand = value
            End Set
        End Property
    End Class


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

