' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml.Serialization


' This is the class that will be serialized.
Public Class OrderedItem
    <XmlElement(Namespace := "http://www.cpandl.com")> _
    Public ItemName As String
    
    <XmlElement(Namespace := "http://www.cpandl.com")> _
    Public Description As String
    
    <XmlElement(Namespace := "http://www.cohowinery.com")> _
    Public UnitPrice As Decimal
    
    <XmlElement(Namespace := "http://www.cpandl.com")> _
    Public Quantity As Integer
    
    <XmlElement(Namespace := "http://www.cohowinery.com")> _
    Public LineTotal As Decimal
    
    'A custom method used to calculate price per item.
    Public Sub Calculate()
        LineTotal = UnitPrice * Quantity
    End Sub
End Class


Public Class Test
    
    Public Shared Sub Main()
        Dim t As New Test()
        ' Write a purchase order.
        t.SerializeObject("simple.xml")
    End Sub
    
    Private Sub SerializeObject(ByVal filename As String)
        Console.WriteLine("Writing With TextWriter")
        ' Create an XmlSerializer instance using the type.
        Dim serializer As New XmlSerializer(GetType(OrderedItem))
        Dim i As New OrderedItem()
        i.ItemName = "Widget"
        i.Description = "Regular Widget"
        i.Quantity = 10
        i.UnitPrice = CDec(2.3)
        i.Calculate()
        
        ' Create an XmlSerializerNamespaces object.
        Dim ns As New XmlSerializerNamespaces()
        ' Add two namespaces with prefixes.
        ns.Add("inventory", "http://www.cpandl.com")
        ns.Add("money", "http://www.cohowinery.com")
        ' Create a StreamWriter to write with.
        Dim writer As New StreamWriter(filename)
        ' Serialize using the object using the TextWriter
        ' and namespaces. 
        serializer.Serialize(writer, i, ns)
        writer.Close()
    End Sub
End Class

' </Snippet1>
