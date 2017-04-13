' <Snippet1>
Imports System.Collections.Generic
Imports System.Linq
Imports System.Xml.Linq
Module Module1

    Private IDToFind As String = "bk109"

    Public Books As New List(Of Book)


    Sub Main()

        FillList()

        ' Find a book by its ID.
        Dim result As Book = Books.Find(AddressOf FindID)
        If result IsNot Nothing Then
            DisplayResult(result, "Find by ID: " & IDToFind)
        Else

            Console.WriteLine(vbCrLf & "Not found: " & IDToFind)
        End If
        Console.WriteLine()

        ' Find last book in collection that has a publish date before 2001.
        result = Books.FindLast(AddressOf PubBefore2001)
        If result IsNot Nothing Then
            DisplayResult(result, "Last book in collection published before 2001:")
        Else
            Console.WriteLine(vbCrLf & "Not found: " & IDToFind)
        End If
        Console.WriteLine()

        ' Find all computer books.
        Dim results As List(Of Book) = Books.FindAll(AddressOf FindComputer)
        If results.Count <> 0 Then
            DisplayResults(results, "All computer books:")
        Else
            Console.WriteLine(vbCrLf & "No books found.")
        End If
        Console.WriteLine()


        ' Find all books under $10.00.
        results = Books.FindAll(AddressOf FindUnderTen)
        If results.Count <> 0 Then
            DisplayResults(results, "Books under $10:")
        Else
            Console.WriteLine(vbCrLf & "No books found.")
        End If
        Console.WriteLine()

        ' Find index values.
        Console.WriteLine()
        Dim ndx As Integer = Books.FindIndex(AddressOf FindComputer)
        Console.WriteLine("Index of first computer book: " & ndx)
        ndx = Books.FindLastIndex(AddressOf FindComputer)
        Console.WriteLine("Index of last computer book: " & ndx)

        Dim mid As Integer = Books.Count / 2
        ndx = Books.FindIndex(mid, mid, AddressOf FindComputer)
        Console.WriteLine("Index of first computer book in the second half of the collection: " & ndx)



        ndx = Books.FindLastIndex(Books.Count - 1, mid, AddressOf FindComputer)
        Console.WriteLine("Index of last computer book in the second half of the collection: " & ndx)


    End Sub



    Private Sub FillList()

        ' Create XML elements from a source file.
        Dim xTree As XElement = XElement.Load("c:\temp\books.xml")

        ' Create an enumerable collection of the elements.
        Dim elements As IEnumerable(Of XElement) = xTree.Elements

        ' Evaluate each element and set values in the book object.
        For Each el As XElement In elements
            Dim Book As New Book()
            Book.ID = el.Attribute("id").Value
            Dim props As IEnumerable(Of XElement) = el.Elements
            For Each p As XElement In props
                If p.Name.ToString.ToLower = "author" Then
                    Book.Author = p.Value
                End If
                If p.Name.ToString.ToLower = "title" Then
                    Book.Title = p.Value
                End If
                If p.Name.ToString.ToLower = "genre" Then
                    Book.Genre = p.Value
                End If
                If p.Name.ToString.ToLower = "price" Then
                    Book.Price = Convert.ToDouble(p.Value)
                End If
                If p.Name.ToString.ToLower = "publish_date" Then
                    Book.Publish_date = Convert.ToDateTime(p.Value)
                End If
                If p.Name.ToString.ToLower = "description" Then
                    Book.Description = p.Value
                End If
            Next
            Books.Add(Book)
        Next

        DisplayResults(Books, "All books:")
        Console.WriteLine()

    End Sub

    ' Predicate delegates for
    ' Find and FindAll methods.
    Private Function FindID(ByVal bk As Book) As Boolean
        If bk.ID = IDToFind Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function FindComputer(ByVal bk As Book) As Boolean
        If bk.Genre = "Computer" Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function FindUnderTen(ByVal bk As Book) As Boolean
        Dim tendollars As Double = 10.0
        If bk.Price < tendollars Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function PubBefore2001(ByVal bk As Book) As Boolean
        Dim year2001 As DateTime = New DateTime(2001, 1, 1)
        Return bk.Publish_date < year2001
    End Function
    Private Sub DisplayResult(ByVal result As Book, ByVal title As String)
        Console.WriteLine()
        Console.WriteLine(title)
        Console.WriteLine(vbLf & result.ID & vbTab & result.Author & _
                          vbTab & result.Title & vbTab & result.Genre & _
                          vbTab & result.Publish_date & vbTab & result.Price)
        Console.WriteLine()
    End Sub
    Private Sub DisplayResults(ByVal results As List(Of Book), ByVal title As String)
        Console.WriteLine()
        Console.WriteLine(title)
        For Each b As Book In results
            Console.Write(vbLf & b.ID & vbTab & b.Author & _
                              vbTab & b.Title & vbTab & b.Genre & _
                              vbTab & b.Publish_date & vbTab & b.Price)
        Next
        Console.WriteLine()
    End Sub

    Public Class Book
        Public ID As String
        Public Author As String
        Public Title As String
        Public Genre As String
        Public Price As Double
        Public Publish_date As DateTime
        Public Description As String
    End Class


End Module
' </Snippet1>