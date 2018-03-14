' <Snippet1>
Imports System
Imports System.IO
Imports System.Text
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic

' This is the class that will be deserialized.
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
        ' Read a purchase order.
        t.DeserializeObject("simple.xml")
    End Sub
    
    Private Sub DeserializeObject(filename As String)
        Console.WriteLine("Reading with TextReader")
        
        ' Create an instance of the XmlSerializer specifying type.
        Dim serializer As New XmlSerializer(GetType(OrderedItem))
        
        ' Create a TextReader to read the file. 
        Dim fs as New FileStream(filename, FileMode.OpenOrCreate)
        Dim reader As New StreamReader(fs)
        
        ' Declare an object variable of the type to be deserialized.
        Dim i As OrderedItem
        
        ' Use the Deserialize method to restore the object's state.
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