' <Snippet1>
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO
Imports Microsoft.VisualBasic


' The XmlRootAttribute allows you to set an alternate name
' (PurchaseOrder) of the XML element, the element namespace; by
' default, the XmlSerializer uses the class name. The attribute
' also allows you to set the XML namespace for the element.  Lastly,
' the attribute sets the IsNullable property, which specifies whether
' the xsi:null attribute appears if the class instance is set to
' a null reference. 
<XmlRootAttribute("PurchaseOrder", _
 Namespace := "http://www.cpandl.com", IsNullable := False)> _
Public Class PurchaseOrder
    
    Public ShipTo As Address
    Public OrderDate As String
    ' The XmlArrayAttribute changes the XML element name
    ' from the default of "OrderedItems" to "Items". 
    <XmlArrayAttribute("Items")> _
    Public OrderedItems() As OrderedItem
    Public SubTotal As Decimal
    Public ShipCost As Decimal
    Public TotalCost As Decimal
End Class 'PurchaseOrder


Public Class Address
    ' The XmlAttribute instructs the XmlSerializer to serialize the Name
    ' field as an XML attribute instead of an XML element (the default
    ' behavior). 
    <XmlAttribute()> _
    Public Name As String
    Public Line1 As String
    
    ' Setting the IsNullable property to false instructs the
    ' XmlSerializer that the XML attribute will not appear if
    ' the City field is set to a null reference. 
    <XmlElementAttribute(IsNullable := False)> _
    Public City As String
    Public State As String
    Public Zip As String
End Class 'Address


Public Class OrderedItem
    Public ItemName As String
    Public Description As String
    Public UnitPrice As Decimal
    Public Quantity As Integer
    Public LineTotal As Decimal
    
    
    ' Calculate is a custom method that calculates the price per item,
    ' and stores the value in a field. 
    Public Sub Calculate()
        LineTotal = UnitPrice * Quantity
    End Sub 'Calculate
End Class 'OrderedItem


Public Class Test
    
   Public Shared Sub Main()
      ' Read and write purchase orders.
      Dim t As New Test()
      t.CreatePO("po.xml")
      t.ReadPO("po.xml")
   End Sub 'Main
    
   Private Sub CreatePO(filename As String)
      ' Create an instance of the XmlSerializer class;
      ' specify the type of object to serialize.
      Dim serializer As New XmlSerializer(GetType(PurchaseOrder))
      Dim writer As New StreamWriter(filename)
      Dim po As New PurchaseOrder()
        
      ' Create an address to ship and bill to.
      Dim billAddress As New Address()
      billAddress.Name = "Teresa Atkinson"
      billAddress.Line1 = "1 Main St."
      billAddress.City = "AnyTown"
      billAddress.State = "WA"
      billAddress.Zip = "00000"
      ' Set ShipTo and BillTo to the same addressee.
      po.ShipTo = billAddress
      po.OrderDate = System.DateTime.Now.ToLongDateString()
        
      ' Create an OrderedItem object.
      Dim i1 As New OrderedItem()
      i1.ItemName = "Widget S"
      i1.Description = "Small widget"
      i1.UnitPrice = CDec(5.23)
      i1.Quantity = 3
      i1.Calculate()
        
      ' Insert the item into the array.
      Dim items(0) As OrderedItem
      items(0) = i1
      po.OrderedItems = items
      ' Calculate the total cost.
      Dim subTotal As New Decimal()
      Dim oi As OrderedItem
      For Each oi In  items
         subTotal += oi.LineTotal
      Next oi
      po.SubTotal = subTotal
      po.ShipCost = CDec(12.51)
      po.TotalCost = po.SubTotal + po.ShipCost
      ' Serialize the purchase order, and close the TextWriter.
      serializer.Serialize(writer, po)
      writer.Close()
   End Sub 'CreatePO
    
   Protected Sub ReadPO(filename As String)
      ' Create an instance of the XmlSerializer class;
      ' specify the type of object to be deserialized.
      Dim serializer As New XmlSerializer(GetType(PurchaseOrder))
      ' If the XML document has been altered with unknown
      ' nodes or attributes, handle them with the
      ' UnknownNode and UnknownAttribute events.
      AddHandler serializer.UnknownNode, AddressOf serializer_UnknownNode
      AddHandler serializer.UnknownAttribute, AddressOf serializer_UnknownAttribute
      
      ' A FileStream is needed to read the XML document.
      Dim fs As New FileStream(filename, FileMode.Open)
      ' Declare an object variable of the type to be deserialized.
      Dim po As PurchaseOrder
      ' Use the Deserialize method to restore the object's state with
      ' data from the XML document. 
      po = CType(serializer.Deserialize(fs), PurchaseOrder)
      ' Read the order date.
      Console.WriteLine(("OrderDate: " & po.OrderDate))
        
      ' Read the shipping address.
      Dim shipTo As Address = po.ShipTo
      ReadAddress(shipTo, "Ship To:")
      ' Read the list of ordered items.
      Dim items As OrderedItem() = po.OrderedItems
      Console.WriteLine("Items to be shipped:")
      Dim oi As OrderedItem
      For Each oi In  items
         Console.WriteLine((ControlChars.Tab & oi.ItemName & ControlChars.Tab & _
         oi.Description & ControlChars.Tab & oi.UnitPrice & ControlChars.Tab & _
         oi.Quantity & ControlChars.Tab & oi.LineTotal))
      Next oi
      ' Read the subtotal, shipping cost, and total cost.
      Console.WriteLine(( New String(ControlChars.Tab, 5) & _
      " Subtotal"  & ControlChars.Tab & po.SubTotal))
      Console.WriteLine(New String(ControlChars.Tab, 5) & _
      " Shipping" & ControlChars.Tab & po.ShipCost )
      Console.WriteLine( New String(ControlChars.Tab, 5) & _
      " Total" &  New String(ControlChars.Tab, 2) & po.TotalCost)
    End Sub 'ReadPO
    
    Protected Sub ReadAddress(a As Address, label As String)
      ' Read the fields of the Address object.
      Console.WriteLine(label)
      Console.WriteLine(ControlChars.Tab & a.Name)
      Console.WriteLine(ControlChars.Tab & a.Line1)
      Console.WriteLine(ControlChars.Tab & a.City)
      Console.WriteLine(ControlChars.Tab & a.State)
      Console.WriteLine(ControlChars.Tab & a.Zip)
      Console.WriteLine()
    End Sub 'ReadAddress
        
    Private Sub serializer_UnknownNode(sender As Object, e As XmlNodeEventArgs)
        Console.WriteLine(("Unknown Node:" & e.Name & ControlChars.Tab & e.Text))
    End Sub 'serializer_UnknownNode
    
    
    Private Sub serializer_UnknownAttribute(sender As Object, e As XmlAttributeEventArgs)
        Dim attr As System.Xml.XmlAttribute = e.Attr
        Console.WriteLine(("Unknown attribute " & attr.Name & "='" & attr.Value & "'"))
    End Sub 'serializer_UnknownAttribute
End Class 'Test
' </Snippet1>

