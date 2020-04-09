' *****************************************************
Option Infer On
Imports System.Collections.Generic

Module Module1

    Sub Main()
        Dim customers = GetCustomers()

        '<Snippet1>
        Dim query = From cust In customers
        '           ...
        '</Snippet1>

        '<Snippet2>
        Dim londonCusts = From cust In customers
                          Where cust.City = "London"
        '                 ...
        '</Snippet2>

        ' Testing the Where lines
        Dim londonC1 = From cust In customers
                       Where cust.City = "London" And cust.Name = "Devon"
                       Select cust

        Dim londonC2 = From cust In customers
                       Where cust.City = "London" Or cust.City = "Paris"
                       Select cust

        '<Snippet3>
        Dim londonCusts1 = From cust In customers
                           Where cust.City = "London"
                           Order By cust.Name Ascending
        '                   ...
        '</Snippet3>

        '<Snippet4>
        Dim londonCusts2 = From cust In customers
                           Where cust.City = "London"
                           Order By cust.Name Ascending
                           Select cust
        '</Snippet4>

        '<Snippet5>
        Dim londonCusts3 = From cust In customers
                           Where cust.City = "London"
                           Order By cust.Name Ascending
                           Select cust.Name
        '</Snippet5>

        '<Snippet6>
        Dim londonCusts4 = From cust In customers
                           Where cust.City = "London"
                           Order By cust.Name Ascending
                           Select Name = cust.Name, Phone = cust.Phone

        For Each londonCust In londonCusts4
            Console.WriteLine(londonCust.Name & " " & londonCust.Phone)
        Next
        '</Snippet6>


        '<Snippet8>
        Dim londonCusts5 = From cust In customers
                           Where cust.City = "London"
                           Order By cust.Name Ascending
                           Select New NamePhone With {.Name = cust.Name,
                                                      .Phone = cust.Phone}
        '</Snippet8>

        Dim students = GetStudents()
        '<Snippet9>
        Dim vowels() As String = {"A", "E", "I", "O", "U"}
        Dim vowelNames = From student In students, vowel In vowels
                         Where student.Last.IndexOf(vowel) = 0
                         Select Name = student.First & " " &
                         student.Last, Initial = vowel
                         Order By Initial

        For Each vName In vowelNames
            Console.WriteLine(vName.Initial & ":  " & vName.Name)
        Next
        '</Snippet9>

        '<Snippet10>
        Dim vowelNames2 = From student In students
                          Join vowel In vowels
                          On student.Last(0) Equals vowel
                          Select Name = student.First & " " &
                          student.Last, Initial = vowel
                          Order By Initial
        '</Snippet10>

        '<Snippet11>
        Dim studentsByYear = From student In students
                             Select student
                             Group By year = student.Year
                             Into Classes = Group

        For Each yearGroup In studentsByYear
            Console.WriteLine(vbCrLf & "Year: " & yearGroup.year)
            For Each student In yearGroup.Classes
                Console.WriteLine("   " & student.Last & ", " & student.First)
            Next
        Next
        '</Snippet11>

        '<Snippet12>
        Dim studentsByYear2 = From student In students
                              Select student
                              Order By student.Year, student.Last
                              Group By year = student.Year
                              Into Classes = Group
        '</Snippet12>

    End Sub
    '<Snippet7>
    Public Class NamePhone
        Public Name As String
        Public Phone As String
        ' Additional class elements
    End Class
    '</Snippet7>


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
        Public Phone As String
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

    ' Call DisplayList to see the names of the students in the list.
    ' You can expand this method to see other student properties.
    Sub DisplayList(ByVal studentCol As List(Of Student))
        ' Dim studentCol = GetStudents()
        For Each st As Student In studentCol
            Console.WriteLine("First Name: " & st.First)
            Console.WriteLine(" Last Name: " & st.Last)
            Console.WriteLine()
        Next
    End Sub

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
        Private _first As String
        Public Property First() As String
            Get
                Return _first
            End Get
            Set(ByVal value As String)
                _first = value
            End Set
        End Property
        Private _last As String
        Public Property Last() As String
            Get
                Return _last
            End Get
            Set(ByVal value As String)
                _last = value
            End Set
        End Property
        Private _year As String
        Public Property Year() As String
            Get
                Return _year
            End Get
            Set(ByVal value As String)
                _year = value
            End Set
        End Property
        Private _rank As Integer
        Public Property Rank() As Integer
            Get
                Return _rank
            End Get
            Set(ByVal value As Integer)
                _rank = value
            End Set
        End Property
    End Class

End Module

