' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization



Public Class Library
    Private myBooks() As Book
    Private myPeriodicals() As Periodical
    
    ' This element will be qualified with the prefix
    ' that is associated with the namespace http://wwww.cpandl.com.    
    <XmlArray(ElementName := "Titles", _
        Namespace := "http://wwww.cpandl.com")> _ 
    Public Property Books() As Book()
        Get
            Return myBooks
        End Get
        Set
            myBooks = value
        End Set
    End Property

    ' This element will be qualified with the prefix that is
    ' associated with the namespace http://www.proseware.com.    
    <XmlArray(ElementName := "Titles", _
        Namespace := "http://www.proseware.com")> _
    Public Property Periodicals() As Periodical()
        Get
            Return myPeriodicals
        End Get
        Set
            myPeriodicals = value
        End Set
    End Property
End Class
 
Public Class Book
    Public Title As String
    Public Author As String
    Public ISBN As String
    <XmlAttribute()> Public Publisher As String
End Class

Public Class Periodical
    Private myTitle As String
    
    Public Property Title() As String
        Get
            Return myTitle
        End Get
        Set
            myTitle = value
        End Set
    End Property
End Class
 
Public Class Run
    
    Public Shared Sub Main()
        Dim test As New Run()
        test.WriteBook("MyLibrary.xml")
        test.ReadBook("MyLibrary.xml")
    End Sub
    
    
    Public Sub WriteBook(ByVal filename As String)
        ' Creates a new XmlSerializer.
        Dim mySerializer As New XmlSerializer(GetType(Library))
        ' Writing the file requires a StreamWriter.
        Dim myStreamWriter As New StreamWriter(filename)
        ' Creates an XmlSerializerNamespaces and adds prefixes and
        ' namespaces to be used. 
        Dim myNamespaces As New XmlSerializerNamespaces()
        myNamespaces.Add("books", "http://wwww.cpandl.com")
        myNamespaces.Add("magazines", "http://www.proseware.com")
        ' Create an instance of the class to be serialized.
        Dim myLibrary As New Library()
        
        ' Creates two book objects.
        Dim b1 As New Book()
        b1.Title = "My Book Title"
        b1.Author = "An Author"
        b1.ISBN = "000000000"
        b1.Publisher = "Microsoft Press"
        
        Dim b2 As New Book()
        b2.Title = "Another Book Title"
        b2.Author = "Another Author"
        b2.ISBN = "00000001"
        b2.Publisher = "Another Press"
        
        ' Creates an array using the objects, and sets the Books property
        ' to the array. 
        Dim myBooks As Book() =  {b1, b2}
        myLibrary.Books = myBooks
        
        ' Creates two Periodical objects.
        Dim per1 As New Periodical()
        per1.Title = "My Magazine Title"
        Dim per2 As New Periodical()
        per2.Title = "Another Magazine Title"
        
        ' Sets the Periodicals property to the array. 
        Dim myPeriodicals() As Periodical =  {per1, per2}
        myLibrary.Periodicals = myPeriodicals
        
        ' Serializes the myLibrary object.
        mySerializer.Serialize(myStreamWriter, myLibrary, myNamespaces)
        
        myStreamWriter.Close()
    End Sub
    
    
    Public Sub ReadBook(ByVal filename As String)
        ' Creates an instance of an XmlSerializer
        ' with the class used to read the document. 
        Dim mySerializer As New XmlSerializer(GetType(Library))
        
        ' A FileStream is needed to read the file.
        Dim myFileStream As New FileStream(filename, FileMode.Open)
        
        Dim myLibrary As Library = _
            CType(mySerializer.Deserialize(myFileStream), Library)
        
        ' Reads each book in the array returned by the Books property.      
        Dim i As Integer
        For i = 0 To myLibrary.Books.Length - 1
            Console.WriteLine(myLibrary.Books(i).Title)
            Console.WriteLine(myLibrary.Books(i).Author)
            Console.WriteLine(myLibrary.Books(i).ISBN)
            Console.WriteLine(myLibrary.Books(i).Publisher)
            Console.WriteLine()
        Next i
        
        ' Reads each Periodical returned by the Periodicals property.
        For i = 0 To myLibrary.Periodicals.Length - 1
            Console.WriteLine(myLibrary.Periodicals(i).Title)
        Next i
    End Sub
End Class

' </Snippet1>
