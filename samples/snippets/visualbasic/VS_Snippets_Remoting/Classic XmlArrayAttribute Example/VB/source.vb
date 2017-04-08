' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml.Serialization
Imports System.Xml


Public Class Run
    
    Public Shared Sub Main()
        Dim test As New Run()
        test.SerializeDocument("books.xml")
    End Sub
    
    
    Public Sub SerializeDocument(ByVal filename As String)
        ' Creates a new XmlSerializer.
        Dim s As New XmlSerializer(GetType(MyRootClass))
        
        ' Writing the file requires a StreamWriter.
        Dim myWriter As New StreamWriter(filename)
        
        ' Creates an instance of the class to serialize. 
        Dim myRootClass As New MyRootClass()
        
        ' Uses a basic method of creating an XML array: Create and
        ' populate a string array, and assign it to the
        ' MyStringArray property. 
        
        Dim myString() As String =  {"Hello", "world", "!"}
        myRootClass.MyStringArray = myString
        
        ' Uses a more advanced method of creating an array:
        ' create instances of the Item and BookItem, where BookItem
        ' is derived from Item. 
        Dim item1 As New Item()
        Dim item2 As New BookItem()
        
        ' Sets the objects' properties.
        With item1
            .ItemName = "Widget1"
            .ItemCode = "w1"
            .ItemPrice = 231
            .ItemQuantity = 3
        End With

        With item2
            .ItemCode = "w2"
            .ItemPrice = 123
            .ItemQuantity = 7
            .ISBN = "34982333"
            .Title = "Book of Widgets"
            .Author = "John Smith"
        End With
        
        ' Fills the array with the items.
        Dim myItems() As Item =  {item1, item2}
        
        ' Set class's Items property to the array.
        myRootClass.Items = myItems
        
        ' Serializes the class, writes it to disk, and closes
        ' the TextWriter. 
        s.Serialize(myWriter, myRootClass)
        myWriter.Close()
    End Sub
End Class


' This is the class that will be serialized.
Public Class MyRootClass
    Private myItems() As Item
    
    ' Here is a simple way to serialize the array as XML. Using the
    ' XmlArrayAttribute, assign an element name and namespace. The
    ' IsNullable property determines whether the element will be
    ' generated if the field is set to a null value. If set to true,
    ' the default, setting it to a null value will cause the XML
    ' xsi:null attribute to be generated.
    <XmlArray(ElementName := "MyStrings", _
         Namespace := "http://www.cpandl.com", _
         IsNullable := True)> _
    Public MyStringArray() As String
    
    ' Here is a more complex example of applying an
    ' XmlArrayAttribute. The Items property can contain both Item
    ' and BookItem objects. Use the XmlArrayItemAttribute to specify
    ' that both types can be inserted into the array.
    <XmlArrayItem(ElementName := "Item", _
        IsNullable := True, _
        Type := GetType(Item), _
        Namespace := "http://www.cpandl.com"), _
     XmlArrayItem(ElementName := "BookItem", _
        IsNullable := True, _
        Type := GetType(BookItem), _
        Namespace := "http://www.cohowinery.com"), _
     XmlArray()> _
    Public Property Items As Item()
        Get
            Return myItems
        End Get
        Set
            myItems = value
        End Set
    End Property
End Class
 
Public Class Item
    <XmlElement(ElementName := "OrderItem")> _
    Public ItemName As String
    Public ItemCode As String
    Public ItemPrice As Decimal
    Public ItemQuantity As Integer
End Class

Public Class BookItem
    Inherits Item
    Public Title As String
    Public Author As String
    Public ISBN As String
End Class

' </Snippet1>
