'<snippet1>
Imports System
Imports System.Collections
Imports System.Runtime.Serialization
Imports System.IO
Imports System.Reflection
Imports System.Security.Permissions

<Assembly: SecurityPermission(SecurityAction.RequestMinimum)> 

' The SerializableAttribute specifies that instances of the class 
' can be serialized by the BinaryFormatter or SoapFormatter.
<Serializable()> _
Class Book
    Public Title As String
    Public Author As String

    ' Constructor for setting new values.
    Public Sub New(ByVal newTitle As String, _
    ByVal newAuthor As String)
        Title = newTitle
        Author = newAuthor

    End Sub
End Class

<SecurityPermission(SecurityAction.Demand)> _
               Public NotInheritable Class Test

    Public Shared Sub Main()
        Try
            Run()
        Catch exc As System.Exception
            Console.WriteLine("{0}: {1}", _
            exc.Message, exc.StackTrace)
        Finally
            Console.WriteLine("Press <Enter> to exit....")
            Console.ReadLine()
        End Try

    End Sub


    Shared Sub Run()
        ' Create an instance of a Book class 
        ' with a title and author.
        Dim Book1 As New Book("Book Title 1", "Masato Kawai")

        ' Store data about the serializable members in a 
        ' MemberInfo array. The MemberInfo type holds 
        ' only type data, not instance data.
        Dim members As MemberInfo() = _
           FormatterServices.GetSerializableMembers(GetType(Book))

        ' Copy the data from the first book into an 
        ' array of objects.
        Dim data As Object() = _
            FormatterServices.GetObjectData(Book1, members)

        ' Create an uninitialized instance of the Book class.
        Dim Book1Copy As Book = _
        CType(FormatterServices.GetSafeUninitializedObject _
           (GetType(Book)), Book)

        ' Call the PopuluateObjectMembers to copy the
        ' data into the new Book instance.
        FormatterServices.PopulateObjectMembers _
        (Book1Copy, members, data)

        ' Print the data from the copy.
        Console.WriteLine("Title: {0}", Book1Copy.Title)
        Console.WriteLine("Author: {0}", Book1Copy.Author)

    End Sub

    ' A private constructor is good practice on
    ' a class containing only static methods.
    Private Sub New()

    End Sub
End Class
'</snippet1>