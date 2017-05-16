' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization


Public Class Run
    
    Public Shared Sub Main()
        Dim test As New Run()
        test.SerializeObject("XmlNamespaces.xml")
    End Sub    
    
    Public Sub SerializeObject(ByVal filename As String)
        Dim s As New XmlSerializer(GetType(Books))
        ' Writing a file requires a TextWriter.
        Dim t As New StreamWriter(filename)
        
        ' Create an XmlSerializerNamespaces object and add two
        ' prefix-namespace pairs. 
        Dim ns As New XmlSerializerNamespaces()
        ns.Add("books", "http://www.cpandl.com")
        ns.Add("money", "http://www.cohowinery.com")
        
        ' Create a Book instance.
        Dim b As New Book()
        b.TITLE = "A Book Title"
        Dim p As New Price()
        p.price = CDec(9.95)
        p.currency = "US Dollar"
        b.PRICE = p
        Dim bks As New Books()
        bks.Book = b
        s.Serialize(t, bks, ns)
        t.Close()
    End Sub
End Class

Public Class Books
    <XmlElement(Namespace := "http://www.cohowinery.com")> _
    Public Book As Book
End Class

<XmlType(Namespace := "http://www.cpandl.com")> _
Public Class Book
    <XmlElement(Namespace := "http://www.cpandl.com")> _
    Public TITLE As String

    <XmlElement(Namespace := "http://www.cohowinery.com")> _
    Public PRICE As Price
End Class

Public Class Price
    <XmlAttribute(Namespace := "http://www.cpandl.com")> _
    Public currency As String
    
    <XmlElement(Namespace := "http://www.cohowinery.com")> _
    Public price As Decimal
End Class

' </Snippet1>
