' *******************************************************************
Option Infer On
Imports System.Collections.Generic
Imports System.Runtime.CompilerServices

Module Module1

    Sub Main()

        Dim customers = GetCustomers()

        '<Snippet1>
        Dim londonCusts = From cust In customers
                          Where cust.City = "London"
                          Order By cust.Name Ascending
                          Select cust.Name, cust.Phone
        '</Snippet1>

        '<Snippet2>
        ' The variable aNumber will be typed as an integer.
        Dim aNumber = 5

        ' The variable aName will be typed as a String.
        Dim aName = "Virginia"
        '</Snippet2>

        Dim numbers() As Integer = {1, 5, 6, 8, 2, 3, 0}
        '<Snippet3>
        ' Query example.
        ' If numbers is a one-dimensional array of integers, num will be typed
        ' as an integer and numQuery will be typed as IEnumerable(Of Integer)--
        ' basically a collection of integers.

        Dim numQuery = From num In numbers
                       Where num Mod 2 = 0
                       Select num
        '</Snippet3>

        '<Snippet4>
        Dim aCust = New Customer With {.Name = "Mike",
                                       .Phone = "555-0212"}
        '</Snippet4>

        '<Snippet5>
        ' Outside a query.
        Dim product = New With {.Name = "paperclips", .Price = 1.29}

        ' Inside a query.
        ' You can use the existing member names of the selected fields, as was
        ' shown previously in the Query Expressions section of this topic.
        Dim londonCusts1 = From cust In customers
                           Where cust.City = "London"
                           Select cust.Name, cust.Phone

        ' Or you can specify new names for the selected fields.
        Dim londonCusts2 = From cust In customers
                           Where cust.City = "London"
                           Select CustomerName = cust.Name,
                           CustomerPhone = cust.Phone
        '</Snippet5>


        ' Do not forget the sub definition, below.

        '<Snippet7>
        Dim greeting As String = "Hello"
        greeting.Print()
        '</Snippet7>

        '<Snippet8>
        Console.WriteLine((Function(num As Integer) num + 1)(3))
        '</Snippet8>

        Dim students = GetStudents()

        '<Snippet12>
        Dim add1 = Function(num As Integer) num + 1
        Console.WriteLine(add1(3))
        '</Snippet12>

        '<Snippet9>
        Dim seniorsQuery = From stdnt In students
                           Where stdnt.Year = "Senior"
                           Select stdnt
        '</Snippet9>

        '<Snippet10>
        Dim seniorsQuery2 = students.
            Where(Function(st) st.Year = "Senior").
            Select(Function(s) s)
        '</Snippet10>

        '<Snippet11>
        For Each senior In seniorsQuery
            Console.WriteLine(senior.Last & ", " & senior.First)
        Next
        '</Snippet11>

    End Sub

    '<Snippet6>
    ' Import System.Runtime.CompilerServices to use the Extension attribute.
    <Extension()>
    Public Sub Print(ByVal str As String)
        Console.WriteLine(str)
    End Sub
    '</Snippet6>

    ' Function GetStudents returns a list of Student objects.
    Function GetStudents() As IEnumerable(Of Student)
        Dim studentList As New System.Collections.Generic.List(Of Student)
        Dim student0 As New Student With {.First = "Michael",
                                          .Last = "Tucker",
                                          .Year = "Junior",
                                          .Rank = 10}
        Dim student1 As New Student With {.First = "Svetlana",
                                          .Last = "Omelchenko",
                                          .Year = "Senior",
                                          .Rank = 2}
        Dim student2 As New Student With {.First = "Michiko",
                                          .Last = "Osada",
                                          .Year = "Senior",
                                          .Rank = 7}
        Dim student3 As New Student With {.First = "Sven",
                                          .Last = "Mortensen",
                                          .Year = "Freshman",
                                          .Rank = 53}
        Dim student4 As New Student With {.First = "Hugo",
                                          .Last = "Garcia",
                                          .Year = "Junior",
                                          .Rank = 16}
        Dim student5 As New Student With {.First = "Cesar",
                                          .Last = "Garcia",
                                          .Year = "Freshman",
                                          .Rank = 4}
        Dim student6 As New Student With {.First = "Fadi",
                                          .Last = "Fakhouri",
                                          .Year = "Senior",
                                          .Rank = 72}
        Dim student7 As New Student With {.First = "Hanying",
                                          .Last = "Feng",
                                          .Year = "Senior",
                                          .Rank = 11}
        Dim student8 As New Student With {.First = "Debra",
                                          .Last = "Garcia",
                                          .Year = "Junior",
                                          .Rank = 41}
        Dim student9 As New Student With {.First = "Lance",
                                          .Last = "Tucker",
                                          .Year = "Junior",
                                          .Rank = 60}
        Dim student10 As New Student With {.First = "Terry",
                                           .Last = "Adams",
                                           .Year = "Senior",
                                           .Rank = 6}
        studentList.Add(student0)
        studentList.Add(student1)
        studentList.Add(student2)
        studentList.Add(student3)
        studentList.Add(student4)
        studentList.Add(student5)
        studentList.Add(student6)
        studentList.Add(student7)
        studentList.Add(student8)
        studentList.Add(student9)
        studentList.Add(student10)
        Return studentList
    End Function

    ' Each student has a first name, a last name, a class year, and 
    ' a rank that indicates academic ranking in the student body.
    Public Class Student
        Public Property First As String
        Public Property Last As String
        Public Property Year As String
        Public Property Rank As Integer
    End Class

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
        Public Property Address As AddressClass
        Public Property Phone As String
        Public Property OrderNumbers As Integer()
        Public Property OrderNumber As Integer

        Sub New()

        End Sub

        Sub New(ByVal newName As String)
            Name = newName
        End Sub

        Public Property Name As String
        Public Property City As String
        Public Property State As String
        Public Property Title As String
        Public Property ID As Integer
    End Class
    Class AddressClass
        Public Property City As String
        Public Property State As String
    End Class

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
        Sub New()

        End Sub
        Sub New(ByVal newName As String, ByVal newPrice As Double)
            Name = newName
            Price = newPrice
        End Sub

        Public Property Name As String
        Public Property Price As Double
        Public Property OnHand As Integer
    End Class
End Module
