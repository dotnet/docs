' <Snippet1>
Imports System
Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic


' This is the class that will be deserialized.
Public Class OrderedItem
    Public ItemName As String
    Public Description As String
    Public UnitPrice As Decimal
    Public Quantity As Integer
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
      
    Private Sub DeserializeObject(ByVal filename As String)
        Console.WriteLine("Reading with XmlReader")
        
        ' Create an instance of the XmlSerializer specifying type and namespace.
        Dim serializer As New XmlSerializer(GetType(OrderedItem))
        
        ' A FileStream is needed to read the XML document.
        Dim fs As New FileStream(filename, FileMode.Open)
        Dim reader As XmlReader = XmlReader.Create(fs)
        
        ' Declare an object variable of the type to be deserialized.
        Dim i As OrderedItem
        
        ' Use the Deserialize method to restore the object's state.
        i = CType(serializer.Deserialize(reader), OrderedItem)
        fs.Close()

        ' Write out the properties of the object.
        Console.Write(i.ItemName & ControlChars.Tab & _
                      i.Description & ControlChars.Tab & _
                      i.UnitPrice & ControlChars.Tab & _
                      i.Quantity & ControlChars.Tab & _
                      i.LineTotal)
    End Sub
End Class

' </Snippet1>
