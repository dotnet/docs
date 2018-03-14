' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic


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
    
    ' A custom method used to calculate price per item.
    Public Sub Calculate()
        LineTotal = UnitPrice * Quantity
    End Sub
End Class

Public Class Test
        
    Public Shared Sub Main()
        Dim t As New Test()
        ' Write a purchase order.
        t.SerializeObject("simple.xml")
        t.DeserializeObject("simple.xml")
    End Sub    
    
    Private Sub SerializeObject(ByVal filename As String)
        Console.WriteLine("Writing With Stream")
        
        Dim serializer As New XmlSerializer(GetType(OrderedItem))
        
        Dim i As New OrderedItem()
        With i
            .ItemName = "Widget"
            .Description = "Regular Widget"
            .Quantity = 10
            .UnitPrice = CDec(2.3)
            .Calculate()
        End With
        
        ' Create an XmlSerializerNamespaces object.
        Dim ns As New XmlSerializerNamespaces()
        
        ' Add two prefix-namespace pairs.
        ns.Add("inventory", "http://www.cpandl.com")
        ns.Add("money", "http://www.cohowinery.com")
        
        ' Create a FileStream to write with.
        Dim writer As New FileStream(filename, FileMode.Create)
        
        ' Serialize the object, and close the TextWriter
        serializer.Serialize(writer, i, ns)
        writer.Close()
    End Sub
        
    Private Sub DeserializeObject(ByVal filename As String)
        Console.WriteLine("Reading with Stream")
        ' Create an instance of the XmlSerializer.
        Dim serializer As New XmlSerializer(GetType(OrderedItem))
        
        ' Writing the file requires a Stream.
        Dim reader As New FileStream(filename, FileMode.Open)
        
        ' Declare an object variable of the type to be deserialized.
        Dim i As OrderedItem
        
        ' Use the Deserialize method to restore the object's state
        ' using data from the XML document. 
        i = CType(serializer.Deserialize(reader), OrderedItem)
        
        ' Write out the properties of the object.
        Console.Write(i.ItemName & ControlChars.Tab & _
                      i.Description & ControlChars.Tab & _
                      i.UnitPrice & ControlChars.Tab & _
                      i.Quantity & ControlChars.Tab & _
                      i.LineTotal)
    End Sub
End Class

' </Snippet1>
