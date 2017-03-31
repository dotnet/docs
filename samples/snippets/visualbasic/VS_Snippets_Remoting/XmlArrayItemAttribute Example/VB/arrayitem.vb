' <Snippet1>
Imports System
Imports System.Collections
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO
Imports System.Xml.Schema
Public Class PurchaseOrder
   <XmlArrayItem(DataType:= "gMonth", _
   ElementName:="MyMonths", _
   Namespace:= "http:'www.cohowinery.com")> _
   public Months() As String 

   <XmlArrayItem(GetType(Item)), XmlArrayItem(GetType(NewItem))> _
   public Items () As Item

   <XmlArray(IsNullable:= true), _
   XmlArrayItem(GetType(String)), _
   XmlArrayItem(GetType(double)), _
   XmlArrayItem(GetType(NewItem))> _
   public Things() As Object
End Class

Public Class Item
   public ItemID As String 

   public Sub New()
   End Sub
   
   public Sub New (id As String)
   	ItemID = id
   End Sub
End Class

Public Class NewItem
   Inherits Item
   public Category As String 
   
   public Sub New()
      
   End Sub

   public Sub New(id As String , cat As String )
   	me.ItemID = id
   	Category = cat
   End Sub
End Class
 
Public Class Test
   Shared Sub Main()
      ' Read and write purchase orders.
      Dim t As Test = New Test()
      t.SerializeObject("ArrayItemExVB.xml")
      t.DeserializeObject("ArrayItemExVB.xml")
   End Sub 

   private Sub SerializeObject(filename As String)
      ' Create an instance of the XmlSerializer class
      ' specify the type of object to serialize.
      Dim serializer As XmlSerializer = _
      New XmlSerializer(GetType(PurchaseOrder))
      Dim writer As TextWriter = New StreamWriter(filename)
      ' Create a PurchaseOrder and set its properties.
      Dim po As PurchaseOrder =New PurchaseOrder()
      po.Months = New String() { "March", "May", "August"}
      po.Items= New Item(){New Item("a1"), New NewItem("b1", "book")}
      po.Things= New Object() {"String", 2003.31, New NewItem("Item100", "book")}
      
      ' Serialize the purchase order, and close the TextWriter.
      serializer.Serialize(writer, po)
      writer.Close()
   End Sub
 
   protected Sub DeserializeObject(filename As String)
      ' Create an instance of the XmlSerializer class
      ' specify the type of object to be deserialized.
      Dim serializer As XmlSerializer = _
      New XmlSerializer(GetType(PurchaseOrder))
   
      ' A FileStream is needed to read the XML document.
      Dim fs As FileStream = New FileStream(filename, FileMode.Open)
      ' Declare an object variable of the type to be deserialized.
      Dim po As PurchaseOrder 
      ' Use the Deserialize method to restore the object's state with
      ' data from the XML document. 
      po = CType( serializer.Deserialize(fs), PurchaseOrder)
      Dim s As String
      Dim i As Item
      Dim thing As Object
      for each s in po.Months
      	  Console.WriteLine(s)
      Next 
      
      for each i in po.Items
         Console.WriteLine(i.ItemID)
      Next 
      
      for each thing in po.Things
         Console.WriteLine(thing) 
      Next
   End Sub
End Class


' </Snippet1>

