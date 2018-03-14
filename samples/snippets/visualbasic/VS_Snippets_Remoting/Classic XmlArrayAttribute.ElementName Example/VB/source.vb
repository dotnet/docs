' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization


Public Class Library
    Private myBooks() As Book
    
    <XmlArray(ElementName := "My_Books")> _
    Public Property Books() As Book()
        Get
            Return myBooks
        End Get
        Set
            myBooks = value
        End Set
    End Property
End Class
 
Public Class Book
    Public Title As String
    Public Author As String
    Public ISBN As String
End Class


Public Class Run
    
    Public Shared Sub Main()
        Dim test As New Run()
        test.WriteBook("ArrayExample.xml")
    End Sub
    
    
    Public Sub WriteBook(ByVal filename As String)
        Dim mySerializer As New XmlSerializer(GetType(Library))
        Dim t As New StreamWriter(filename)
        Dim ns As New XmlSerializerNamespaces()
        ns.Add("bk", "http://wwww.contoso.com")
        
        Dim b1 As New Book()
        b1.Title = "MyBook Title"
        b1.Author = "An Author"
        b1.ISBN = "00000000"
        
        Dim b2 As New Book()
        b2.Title = "Another Title"
        b2.Author = "Another Author"
        b2.ISBN = "0000000"
        
        Dim myLibrary As New Library()
        Dim myBooks() As Book =  {b1, b2}
        myLibrary.Books = myBooks
        
        mySerializer.Serialize(t, myLibrary, ns)
        t.Close()
    End Sub
End Class

' </Snippet1>
