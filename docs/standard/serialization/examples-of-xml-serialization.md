---
title: "Examples of XML Serialization"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "XML serialization, examples"
  - "arrays, serializing"
  - "ICollection interface, serializing"
  - "XmlSerializer class, serializing"
  - "serialization, examples"
  - "DataSet class, serializing"
  - "XML Schema, serializing"
ms.assetid: eec46337-9696-435b-a375-dc5effae6992
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Examples of XML Serialization
XML serialization can take more than one form, from simple to complex. For example, you can serialize a class that simply consists of public fields and properties, as shown in [Introducing XML Serialization](../../../docs/standard/serialization/introducing-xml-serialization.md). The following code examples address various advanced scenarios, including how to use XML serialization to generate an XML stream that conforms to a specific XML Schema (XSD) document.  
  
## Serializing a DataSet  
 Besides serializing an instance of a public class, an instance of a <xref:System.Data.DataSet> can also be serialized, as shown in the following code example.  
  
```vb  
Private Sub SerializeDataSet(filename As String)  
    Dim ser As XmlSerializer = new XmlSerializer(GetType(DataSet))  
    ' Creates a DataSet; adds a table, column, and ten rows.  
    Dim ds As DataSet = new DataSet("myDataSet")  
    Dim t As DataTable = new DataTable("table1")  
    Dim c As DataColumn = new DataColumn("thing")  
    t.Columns.Add(c)  
    ds.Tables.Add(t)  
    Dim r As DataRow  
    Dim i As Integer  
    for i = 0 to 10  
        r = t.NewRow()  
        r(0) = "Thing " &  i  
        t.Rows.Add(r)  
    Next  
    Dim writer As TextWriter = new StreamWriter(filename)  
    ser.Serialize(writer, ds)  
    writer.Close()  
End Sub  
```  
  
```csharp  
private void SerializeDataSet(string filename){  
    XmlSerializer ser = new XmlSerializer(typeof(DataSet));  
  
    // Creates a DataSet; adds a table, column, and ten rows.  
    DataSet ds = new DataSet("myDataSet");  
    DataTable t = new DataTable("table1");  
    DataColumn c = new DataColumn("thing");  
    t.Columns.Add(c);  
    ds.Tables.Add(t);  
    DataRow r;  
    for(int i = 0; i<10;i++){  
        r = t.NewRow();  
        r[0] = "Thing " + i;  
        t.Rows.Add(r);  
    }  
    TextWriter writer = new StreamWriter(filename);  
    ser.Serialize(writer, ds);  
    writer.Close();  
}  
```  
  
## Serializing an XmlElement and XmlNode  
 You can also serialize instances of a <xref:System.Xml.XmlElement> or <xref:System.Xml.XmlNode> class, as shown in the following code example.  
  
```vb  
private Sub SerializeElement(filename As String)  
    Dim ser As XmlSerializer = new XmlSerializer(GetType(XmlElement))  
    Dim myElement As XmlElement = _  
    new XmlDocument().CreateElement("MyElement", "ns")  
    myElement.InnerText = "Hello World"  
    Dim writer As TextWriter = new StreamWriter(filename)  
    ser.Serialize(writer, myElement)  
    writer.Close()  
End Sub  
  
Private Sub SerializeNode(filename As String)  
    Dim ser As XmlSerializer = _  
    new XmlSerializer(GetType(XmlNode))  
    Dim myNode As XmlNode = new XmlDocument(). _  
    CreateNode(XmlNodeType.Element, "MyNode", "ns")  
    myNode.InnerText = "Hello Node"  
    Dim writer As TextWriter = new StreamWriter(filename)  
    ser.Serialize(writer, myNode)  
    writer.Close()  
End Sub  
```  
  
```csharp  
private void SerializeElement(string filename){  
    XmlSerializer ser = new XmlSerializer(typeof(XmlElement));  
    XmlElement myElement=   
    new XmlDocument().CreateElement("MyElement", "ns");  
    myElement.InnerText = "Hello World";  
    TextWriter writer = new StreamWriter(filename);  
    ser.Serialize(writer, myElement);  
    writer.Close();  
}  
  
private void SerializeNode(string filename){  
    XmlSerializer ser = new XmlSerializer(typeof(XmlNode));  
    XmlNode myNode= new XmlDocument().  
    CreateNode(XmlNodeType.Element, "MyNode", "ns");  
    myNode.InnerText = "Hello Node";  
    TextWriter writer = new StreamWriter(filename);  
    ser.Serialize(writer, myNode);  
    writer.Close();  
}  
```  
  
## Serializing a Class that Contains a Field Returning a Complex Object  
 If a property or field returns a complex object (such as an array or a class instance), the [XmlSerializer](https://msdn.microsoft.com/library/system.xml.serialization.xmlserializer.aspx) converts it to an element nested within the main XML document. For example, the first class in the following code example returns an instance of the second class.  
  
```vb  
Public Class PurchaseOrder  
    Public MyAdress As Address  
End Class  
  
Public Class Address  
    Public FirstName As String  
End Class  
```  
  
```csharp  
public class PurchaseOrder  
{  
    public Address MyAddress;  
}  
public class Address  
{  
    public string FirstName;  
}  
```  
  
 The serialized XML output might resemble the following.  
  
```xml  
<PurchaseOrder>  
    <Address>  
        <FirstName>George</FirstName>  
    </Address>  
</PurchaseOrder>  
```  
  
## Serializing an Array of Objects  
 You can also serialize a field that returns an array of objects, as shown in the following code example.  
  
```vb  
Public Class PurchaseOrder  
    public ItemsOrders () As Item  
End Class  
  
Public Class Item  
    Public ItemID As String  
    Public ItemPrice As decimal  
End Class  
```  
  
```csharp  
public class PurchaseOrder  
{  
    public Item [] ItemsOrders  
}  
  
public class Item  
{  
    public string ItemID  
    public decimal ItemPrice  
}  
```  
  
 The serialized class instance might resemble the following, if two items are ordered.  
  
```xml  
<PurchaseOrder xmlns:xsi=http://www.w3.org/2001/XMLSchema-instance xmlns:xsd="http://www.w3.org/2001/XMLSchema">  
    <Items>  
        <Item>  
            <ItemID>aaa111</ItemID>  
            <ItemPrice>34.22</ItemPrice>  
        <Item>  
        <Item>  
            <ItemID>bbb222</ItemID>  
            <ItemPrice>2.89</ItemPrice>  
        <Item>  
    </Items>  
</PurchaseOrder>  
```  
  
## Serializing a Class that Implements the ICollection Interface  
 You can create your own collection classes by implementing the <xref:System.Collections.ICollection> interface, and use the <xref:System.Xml.Serialization.XmlSerializer> to serialize instances of these classes. Note that when a class implements the <xref:System.Collections.ICollection> interface, only the collection contained by the class is serialized. Any public properties or fields added to the class will not be serialized. The class must include an **Add** method and an **Item** property (C# indexer) to be serialized.  
  
```vb  
Imports System  
Imports System.IO  
Imports System.Collections  
Imports System.Xml.Serialization  
  
Public Class Test  
    Shared Sub Main()  
        Dim t As Test= new Test()  
        t.SerializeCollection("coll.xml")  
    End Sub  
  
    Private Sub SerializeCollection(filename As String)  
        Dim Emps As Employees  = new Employees()  
        ' Note that only the collection is serialized -- not the   
        ' CollectionName or any other public property of the class.  
        Emps.CollectionName = "Employees"  
        Dim John100 As Employee = new Employee("John", "100xxx")  
        Emps.Add(John100)  
        Dim x As XmlSerializer = new XmlSerializer(GetType(Employees))  
        Dim writer As TextWriter = new StreamWriter(filename)  
        x.Serialize(writer, Emps)  
        writer.Close()  
    End Sub  
End Class  
  
Public Class Employees  
    Implements ICollection  
    Public CollectionName As String   
    Private empArray As ArrayList = new ArrayList()   
  
    Public ReadOnly Default Overloads _  
    Property Item(index As Integer) As Employee  
        get  
        return CType (empArray(index), Employee)  
        End Get  
    End Property  
  
    Public Sub CopyTo(a As Array, index As Integer) _  
    Implements ICollection.CopyTo  
        empArray.CopyTo(a, index)  
    End Sub  
  
    Public ReadOnly Property Count () As integer Implements _  
    ICollection.Count  
        get   
            Count = empArray.Count  
        End Get  
  
    End Property  
  
    Public ReadOnly Property SyncRoot ()As Object _  
    Implements ICollection.SyncRoot  
        get  
        return me  
        End Get  
    End Property  
  
    Public ReadOnly Property IsSynchronized () As Boolean _  
    Implements ICollection.IsSynchronized  
        get   
        return false  
        End Get  
    End Property  
  
    Public Function GetEnumerator() As IEnumerator _  
    Implements IEnumerable.GetEnumerator  
  
        return empArray.GetEnumerator()  
    End Function   
  
    Public Function Add(newEmployee As Employee) As Integer  
        empArray.Add(newEmployee)  
        return empArray.Count  
    End Function  
End Class  
  
Public Class Employee  
    Public EmpName As String   
    Public EmpID As String   
  
    Public Sub New ()  
    End Sub  
  
    Public Sub New (newName As String , newID As String )   
        EmpName = newName  
        EmpID = newID  
    End Sub  
End Class  
```  
  
```csharp  
using System;  
using System.IO;  
using System.Collections;  
using System.Xml.Serialization;  
  
public class Test{  
    static void Main(){  
        Test t = new Test();  
        t.SerializeCollection("coll.xml");  
    }  
  
    private void SerializeCollection(string filename){  
        Employees Emps = new Employees();  
        // Note that only the collection is serialized -- not the   
        // CollectionName or any other public property of the class.  
        Emps.CollectionName = "Employees";  
        Employee John100 = new Employee("John", "100xxx");  
        Emps.Add(John100);  
        XmlSerializer x = new XmlSerializer(typeof(Employees));  
        TextWriter writer = new StreamWriter(filename);  
        x.Serialize(writer, Emps);  
    }  
}  
public class Employees:ICollection{  
    public string CollectionName;  
    private ArrayList empArray = new ArrayList();   
  
    public Employee this[int index]{  
        get{return (Employee) empArray[index];}  
    }  
  
    public void CopyTo(Array a, int index){  
        empArray.CopyTo(a, index);  
    }  
    public int Count{  
        get{return empArray.Count;}  
    }  
    public object SyncRoot{  
        get{return this;}  
    }  
    public bool IsSynchronized{  
        get{return false;}  
    }  
    public IEnumerator GetEnumerator(){  
        return empArray.GetEnumerator();  
    }  
  
    public void Add(Employee newEmployee){  
        empArray.Add(newEmployee);  
    }  
}  
  
public class Employee{  
    public string EmpName;  
    public string EmpID;  
    public Employee(){}  
    public Employee(string empName, string empID){  
        EmpName = empName;  
        EmpID = empID;  
    }  
}  
```  
  
## Purchase Order Example  
 You can cut and paste the following example code into a text file renamed with a .cs or .vb file name extension. Use the C# or Visual Basic compiler to compile the file. Then run it using the name of the executable.  
  
 This example uses a simple scenario to demonstrate how an instance of an object is created and serialized into a file stream using the <xref:System.Xml.Serialization.XmlSerializer.Serialize%2A> method. The XML stream is saved to a file, and the same file is then read back and reconstructed into a copy of the original object using the <xref:System.Xml.Serialization.XmlSerializer.Deserialize%2A> method.  
  
 In this example, a class named `PurchaseOrder` is serialized and then deserialized. A second class named `Address` is also included because the public field named `ShipTo` must be set to an `Address`. Similarly, an `OrderedItem` class is included because an array of `OrderedItem` objects must be set to the `OrderedItems` field. Finally, a class named `Test` contains the code that serializes and deserializes the classes.  
  
 The `CreatePO` method creates the `PurchaseOrder`, `Address`, and `OrderedItem` class objects, and sets the public field values. The method also constructs an instance of the <xref:System.Xml.Serialization.XmlSerializer> class that is used to serialize and deserialize the `PurchaseOrder`. Note that the code passes the type of the class that will be serialized to the constructor. The code also creates a `FileStream` that is used to write the XML stream to an XML document.  
  
 The `ReadPo` method is a little simpler. It just creates objects to deserialize and reads out their values. As with the `CreatePo` method, you must first construct a <xref:System.Xml.Serialization.XmlSerializer>, passing the type of the class to be deserialized to the constructor. Also, a <xref:System.IO.FileStream> is required to read the XML document. To deserialize the objects, call the <xref:System.Xml.Serialization.XmlSerializer.Deserialize%2A> method with the <xref:System.IO.FileStream> as an argument. The deserialized object must be cast to an object variable of type `PurchaseOrder`. The code then reads the values of the deserialized `PurchaseOrder`. Note that you can also read the PO.xml file that is created to see the actual XML output.  
  
```vb  
Imports System  
Imports System.Xml  
Imports System.Xml.Serialization  
Imports System.IO  
Imports Microsoft.VisualBasic  
  
' The XmlRoot attribute allows you to set an alternate name  
' (PurchaseOrder) for the XML element and its namespace. By  
' default, the XmlSerializer uses the class name. The attribute  
' also allows you to set the XML namespace for the element. Lastly,  
' the attribute sets the IsNullable property, which specifies whether  
' the xsi:null attribute appears if the class instance is set to  
' a null reference.   
<XmlRoot("PurchaseOrder", _  
 Namespace := "http://www.cpandl.com", IsNullable := False)> _  
Public Class PurchaseOrder  
    Public ShipTo As Address  
    Public OrderDate As String  
    ' The XmlArrayAttribute changes the XML element name  
    ' from the default of "OrderedItems" to "Items".   
    <XmlArray("Items")> _  
    Public OrderedItems() As OrderedItem  
    Public SubTotal As Decimal  
    Public ShipCost As Decimal  
    Public TotalCost As Decimal  
End Class   
  
Public Class Address  
    ' The XmlAttribute attribute instructs the XmlSerializer to serialize the   
    ' Name field as an XML attribute instead of an XML element (the   
    ' default behavior).   
    <XmlAttribute()> _  
    Public Name As String  
    Public Line1 As String  
  
    ' Setting the IsNullable property to false instructs the  
    ' XmlSerializer that the XML attribute will not appear if  
    ' the City field is set to a null reference.   
    <XmlElement(IsNullable := False)> _  
    Public City As String  
    Public State As String  
    Public Zip As String  
End Class   
  
Public Class OrderedItem  
    Public ItemName As String  
    Public Description As String  
    Public UnitPrice As Decimal  
    Public Quantity As Integer  
    Public LineTotal As Decimal  
  
    ' Calculate is a custom method that calculates the price per item  
    ' and stores the value in a field.   
    Public Sub Calculate()  
    LineTotal = UnitPrice * Quantity  
    End Sub   
End Class   
  
Public Class Test  
        Public Shared Sub Main()  
    ' Read and write purchase orders.  
    Dim t As New Test()  
    t.CreatePO("po.xml")  
    t.ReadPO("po.xml")  
    End Sub   
  
    Private Sub CreatePO(filename As String)  
        ' Creates an instance of the XmlSerializer class;  
        ' specifies the type of object to serialize.  
        Dim serializer As New XmlSerializer(GetType(PurchaseOrder))  
        Dim writer As New StreamWriter(filename)  
        Dim po As New PurchaseOrder()  
  
        ' Creates an address to ship and bill to.  
        Dim billAddress As New Address()  
        billAddress.Name = "Teresa Atkinson"  
        billAddress.Line1 = "1 Main St."  
        billAddress.City = "AnyTown"  
        billAddress.State = "WA"  
        billAddress.Zip = "00000"  
        ' Set ShipTo and BillTo to the same addressee.  
        po.ShipTo = billAddress  
        po.OrderDate = System.DateTime.Now.ToLongDateString()  
  
        ' Creates an OrderedItem.  
        Dim i1 As New OrderedItem()  
        i1.ItemName = "Widget S"  
        i1.Description = "Small widget"  
        i1.UnitPrice = CDec(5.23)  
        i1.Quantity = 3  
        i1.Calculate()  
  
        ' Inserts the item into the array.  
        Dim items(0) As OrderedItem  
        items(0) = i1  
        po.OrderedItems = items  
        ' Calculates the total cost.  
        Dim subTotal As New Decimal()  
        Dim oi As OrderedItem  
        For Each oi In  items  
            subTotal += oi.LineTotal  
        Next oi  
        po.SubTotal = subTotal  
        po.ShipCost = CDec(12.51)  
        po.TotalCost = po.SubTotal + po.ShipCost  
        ' Serializes the purchase order, and close the TextWriter.  
        serializer.Serialize(writer, po)  
        writer.Close()  
    End Sub   
  
    Protected Sub ReadPO(filename As String)  
        ' Creates an instance of the XmlSerializer class;  
        ' specifies the type of object to be deserialized.  
        Dim serializer As New XmlSerializer(GetType(PurchaseOrder))  
        ' If the XML document has been altered with unknown  
        ' nodes or attributes, handles them with the  
        ' UnknownNode and UnknownAttribute events.  
        AddHandler serializer.UnknownNode, AddressOf serializer_UnknownNode  
        AddHandler serializer.UnknownAttribute, AddressOf _  
        serializer_UnknownAttribute  
  
        ' A FileStream is needed to read the XML document.  
        Dim fs As New FileStream(filename, FileMode.Open)  
        ' Declare an object variable of the type to be deserialized.  
        Dim po As PurchaseOrder  
        ' Uses the Deserialize method to restore the object's state   
        ' with data from the XML document.   
        po = CType(serializer.Deserialize(fs), PurchaseOrder)  
        ' Reads the order date.  
        Console.WriteLine(("OrderDate: " & po.OrderDate))  
  
        ' Reads the shipping address.  
        Dim shipTo As Address = po.ShipTo  
        ReadAddress(shipTo, "Ship To:")  
        ' Reads the list of ordered items.  
        Dim items As OrderedItem() = po.OrderedItems  
        Console.WriteLine("Items to be shipped:")  
        Dim oi As OrderedItem  
        For Each oi In items  
            Console.WriteLine((ControlChars.Tab & oi.ItemName & _  
            ControlChars.Tab & _  
                oi.Description & ControlChars.Tab & oi.UnitPrice & _  
                ControlChars.Tab & _  
                oi.Quantity & ControlChars.Tab & oi.LineTotal))  
        Next oi  
        ' Reads the subtotal, shipping cost, and total cost.  
        Console.WriteLine((ControlChars.Cr & New String _  
        (ControlChars.Tab, 5) & _  
        " Subtotal" & ControlChars.Tab & po.SubTotal & ControlChars.Cr & _  
        New String(ControlChars.Tab, 5) & " Shipping" & ControlChars.Tab & _  
        po.ShipCost & ControlChars.Cr &  New String(ControlChars.Tab, 5) & _  
        " Total" & New String(ControlChars.Tab, 2) & po.TotalCost))  
    End Sub   
  
    Protected Sub ReadAddress(a As Address, label As String)  
        ' Reads the fields of the Address.  
        Console.WriteLine(label)  
        Console.Write((ControlChars.Tab & a.Name & ControlChars.Cr & _  
        ControlChars.Tab & a.Line1 & ControlChars.Cr & ControlChars.Tab & _  
        a.City & ControlChars.Tab & a.State & ControlChars.Cr & _  
        ControlChars.Tab & a.Zip & ControlChars.Cr))  
    End Sub   
  
    Protected Sub serializer_UnknownNode(sender As Object, e As _  
    XmlNodeEventArgs)  
        Console.WriteLine(("Unknown Node:" & e.Name & _  
        ControlChars.Tab & e.Text))  
    End Sub   
  
    Protected Sub serializer_UnknownAttribute(sender As Object, _  
    e As XmlAttributeEventArgs)  
        Dim attr As System.Xml.XmlAttribute = e.Attr  
        Console.WriteLine(("Unknown attribute " & attr.Name & "='" & _  
        attr.Value & "'"))  
    End Sub 'serializer_UnknownAttribute  
End Class 'Test  
```  
  
```csharp  
using System;  
using System.Xml;  
using System.Xml.Serialization;  
using System.IO;  
  
// The XmlRoot attribute allows you to set an alternate name   
// (PurchaseOrder) for the XML element and its namespace. By   
// default, the XmlSerializer uses the class name. The attribute   
// also allows you to set the XML namespace for the element. Lastly,  
// the attribute sets the IsNullable property, which specifies whether   
// the xsi:null attribute appears if the class instance is set to   
// a null reference.  
[XmlRoot("PurchaseOrder", Namespace="http://www.cpandl.com",   
IsNullable = false)]  
public class PurchaseOrder  
{  
    public Address ShipTo;  
    public string OrderDate;   
    // The XmlArray attribute changes the XML element name  
    // from the default of "OrderedItems" to "Items".  
    [XmlArray("Items")]  
    public OrderedItem[] OrderedItems;  
    public decimal SubTotal;  
    public decimal ShipCost;  
    public decimal TotalCost;     
}  
  
public class Address  
{  
    // The XmlAttribute attribute instructs the XmlSerializer to serialize the   
    // Name field as an XML attribute instead of an XML element (the   
    // default behavior).  
    [XmlAttribute]  
    public string Name;  
    public string Line1;  
  
    // Setting the IsNullable property to false instructs the   
    // XmlSerializer that the XML attribute will not appear if   
    // the City field is set to a null reference.  
    [XmlElement(IsNullable = false)]  
    public string City;  
    public string State;  
    public string Zip;  
}  
  
public class OrderedItem  
{  
    public string ItemName;  
    public string Description;  
    public decimal UnitPrice;  
    public int Quantity;  
    public decimal LineTotal;  
  
    // Calculate is a custom method that calculates the price per item  
    // and stores the value in a field.  
    public void Calculate()  
    {  
        LineTotal = UnitPrice * Quantity;  
    }  
}  
  
public class Test  
{  
    public static void Main()  
    {  
        // Read and write purchase orders.  
        Test t = new Test();  
        t.CreatePO("po.xml");  
        t.ReadPO("po.xml");  
    }  
  
    private void CreatePO(string filename)  
    {  
        // Creates an instance of the XmlSerializer class;  
        // specifies the type of object to serialize.  
        XmlSerializer serializer =   
        new XmlSerializer(typeof(PurchaseOrder));  
        TextWriter writer = new StreamWriter(filename);  
        PurchaseOrder po=new PurchaseOrder();  
  
        // Creates an address to ship and bill to.  
        Address billAddress = new Address();  
        billAddress.Name = "Teresa Atkinson";  
        billAddress.Line1 = "1 Main St.";  
        billAddress.City = "AnyTown";  
        billAddress.State = "WA";  
        billAddress.Zip = "00000";  
        // Sets ShipTo and BillTo to the same addressee.  
        po.ShipTo = billAddress;  
        po.OrderDate = System.DateTime.Now.ToLongDateString();  
  
        // Creates an OrderedItem.  
        OrderedItem i1 = new OrderedItem();  
        i1.ItemName = "Widget S";  
        i1.Description = "Small widget";  
        i1.UnitPrice = (decimal) 5.23;  
        i1.Quantity = 3;  
        i1.Calculate();  
  
        // Inserts the item into the array.  
        OrderedItem [] items = {i1};  
        po.OrderedItems = items;  
        // Calculate the total cost.  
        decimal subTotal = new decimal();  
        foreach(OrderedItem oi in items)  
        {  
            subTotal += oi.LineTotal;  
        }  
        po.SubTotal = subTotal;  
        po.ShipCost = (decimal) 12.51;   
        po.TotalCost = po.SubTotal + po.ShipCost;   
        // Serializes the purchase order, and closes the TextWriter.  
        serializer.Serialize(writer, po);  
        writer.Close();  
    }  
  
    protected void ReadPO(string filename)  
    {  
        // Creates an instance of the XmlSerializer class;  
        // specifies the type of object to be deserialized.  
        XmlSerializer serializer = new XmlSerializer(typeof(PurchaseOrder));  
        // If the XML document has been altered with unknown   
        // nodes or attributes, handles them with the   
        // UnknownNode and UnknownAttribute events.  
        serializer.UnknownNode+= new   
        XmlNodeEventHandler(serializer_UnknownNode);  
        serializer.UnknownAttribute+= new   
        XmlAttributeEventHandler(serializer_UnknownAttribute);  
  
        // A FileStream is needed to read the XML document.  
        FileStream fs = new FileStream(filename, FileMode.Open);  
        // Declares an object variable of the type to be deserialized.  
        PurchaseOrder po;  
        // Uses the Deserialize method to restore the object's state   
        // with data from the XML document. */  
        po = (PurchaseOrder) serializer.Deserialize(fs);  
        // Reads the order date.  
        Console.WriteLine ("OrderDate: " + po.OrderDate);  
  
        // Reads the shipping address.  
        Address shipTo = po.ShipTo;  
        ReadAddress(shipTo, "Ship To:");  
        // Reads the list of ordered items.  
        OrderedItem [] items = po.OrderedItems;  
        Console.WriteLine("Items to be shipped:");  
        foreach(OrderedItem oi in items)  
        {  
            Console.WriteLine("\t"+  
            oi.ItemName + "\t" +   
            oi.Description + "\t" +  
            oi.UnitPrice + "\t" +  
            oi.Quantity + "\t" +  
            oi.LineTotal);  
        }  
        // Reads the subtotal, shipping cost, and total cost.  
        Console.WriteLine(  
        "\n\t\t\t\t\t Subtotal\t" + po.SubTotal +   
        "\n\t\t\t\t\t Shipping\t" + po.ShipCost +   
        "\n\t\t\t\t\t Total\t\t" + po.TotalCost  
        );  
    }  
  
    protected void ReadAddress(Address a, string label)  
    {  
        // Reads the fields of the Address.  
        Console.WriteLine(label);  
        Console.Write("\t"+  
        a.Name +"\n\t" +  
        a.Line1 +"\n\t" +  
        a.City +"\t" +  
        a.State +"\n\t" +  
        a.Zip +"\n");  
    }  
  
    protected void serializer_UnknownNode  
    (object sender, XmlNodeEventArgs e)  
    {  
        Console.WriteLine("Unknown Node:" +   e.Name + "\t" + e.Text);  
    }  
  
    protected void serializer_UnknownAttribute  
    (object sender, XmlAttributeEventArgs e)  
    {  
        System.Xml.XmlAttribute attr = e.Attr;  
        Console.WriteLine("Unknown attribute " +   
        attr.Name + "='" + attr.Value + "'");  
    }  
}  
```  
  
 The XML output might resemble the following.  
  
```xml  
<?xml version="1.0" encoding="utf-8"?>  
<PurchaseOrder xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.cpandl.com">  
    <ShipTo Name="Teresa Atkinson">  
        <Line1>1 Main St.</Line1>  
        <City>AnyTown</City>  
        <State>WA</State>  
        <Zip>00000</Zip>  
    </ShipTo>  
    <OrderDate>Wednesday, June 27, 2001</OrderDate>  
    <Items>  
        <OrderedItem>  
            <ItemName>Widget S</ItemName>  
            <Description>Small widget</Description>  
            <UnitPrice>5.23</UnitPrice>  
            <Quantity>3</Quantity>  
            <LineTotal>15.69</LineTotal>  
        </OrderedItem>  
    </Items>  
    <SubTotal>15.69</SubTotal>  
    <ShipCost>12.51</ShipCost>  
    <TotalCost>28.2</TotalCost>  
</PurchaseOrder>  
```  
  
## See Also  
 [Introducing XML Serialization](../../../docs/standard/serialization/introducing-xml-serialization.md)  
 [Controlling XML Serialization Using Attributes](../../../docs/standard/serialization/controlling-xml-serialization-using-attributes.md)  
 [Attributes That Control XML Serialization](../../../docs/standard/serialization/attributes-that-control-xml-serialization.md)  
 [XmlSerializer Class](https://msdn.microsoft.com/library/system.xml.serialization.xmlserializer.aspx)  
 [How to: Serialize an Object](../../../docs/standard/serialization/how-to-serialize-an-object.md)  
 [How to: Deserialize an Object](../../../docs/standard/serialization/how-to-deserialize-an-object.md)
