---
title: "Controlling XML Serialization Using Attributes"
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
  - "classes, serializing"
  - "XML serialization, examples"
  - "derived classes, serializing"
  - "arrays, serializing"
  - "XML serialization, attributes"
  - "preventing serialization"
  - "attributes [.NET Framework], XML serialization"
  - "serialization, examples"
  - "serialization, attributes"
ms.assetid: 47d4c39d-30e1-4c7b-8a2e-301325390647
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Controlling XML Serialization Using Attributes
Attributes can be used to control the XML serialization of an object or to create an alternate XML stream from the same set of classes. For more details about creating an alternate XML stream, see [How to: Specify an Alternate Element Name for an XML Stream](../../../docs/standard/serialization/how-to-specify-an-alternate-element-name-for-an-xml-stream.md).  
  
> [!NOTE]
>  If the XML generated must conform to section 5 of the World Wide Web Consortium (www.w3.org) document titled "Simple Object Access Protocol (SOAP) 1.1," use the attributes listed in [Attributes That Control Encoded SOAP Serialization](../../../docs/standard/serialization/attributes-that-control-encoded-soap-serialization.md).  
  
 By default, an XML element name is determined by the class or member name. In a simple class named `Book`, a field named `ISBN` will produce an XML element tag \<ISBN>, as shown in the following example.  
  
```vb  
Public Class Book  
    Public ISBN As String  
End Class  
' When an instance of the Book class is serialized, it might   
' produce this XML:  
' <ISBN>1234567890</ISBN>.  
```  
  
```csharp  
public class Book  
{  
    public string ISBN;  
}  
// When an instance of the Book class is serialized, it might   
// produce this XML:  
// <ISBN>1234567890</ISBN>.  
```  
  
 This default behavior can be changed if you want to give the element a new name. The following code shows how an attribute enables this by setting the <xref:System.Xml.Serialization.XmlElementAttribute.ElementName%2A> property of a <xref:System.Xml.Serialization.XmlElementAttribute>.  
  
```vb  
Public Class TaxRates  
   < XmlElement(ElementName = "TaxRate")> _  
    Public ReturnTaxRate As Decimal  
End Class  
```  
  
```csharp  
public class TaxRates{  
    [XmlElement(ElementName = "TaxRate")]  
    public decimal ReturnTaxRate;  
}  
```  
  
 For more information about attributes, see [Attributes](../../../docs/standard/attributes/index.md). For a list of attributes that control XML serialization, see [Attributes That Control XML Serialization](../../../docs/standard/serialization/attributes-that-control-xml-serialization.md).  
  
## Controlling Array Serialization  
 The <xref:System.Xml.Serialization.XmlArrayAttribute> and the <xref:System.Xml.Serialization.XmlArrayItemAttribute> attributes are designed to control the serialization of arrays. Using these attributes, you can control the element name, namespace, and XML Schema (XSD) data type (as defined in the World Wide Web Consortium [www.w3.org] document titled "XML Schema Part 2: Datatypes"). You can also specify the types that can be included in an array.  
  
 The <xref:System.Xml.Serialization.XmlArrayAttribute> will determine the properties of the enclosing XML element that results when an array is serialized. For example, by default, serializing the array below will result in an XML element named `Employees`. The `Employees` element will contain a series of elements named after the array type `Employee`.  
  
```vb  
Public Class Group  
    Public Employees() As Employee  
End Class  
Public Class Employee  
    Public Name As String  
End Class  
```  
  
```csharp  
public class Group{  
    public Employee[] Employees;  
}  
public class Employee{  
    public string Name;  
}  
```  
  
 A serialized instance might resemble the following.  
  
```xml  
<Group>  
<Employees>  
    <Employee>  
        <Name>Haley</Name>  
    </Employee>  
</Employees >  
</Group>  
```  
  
 By applying a <xref:System.Xml.Serialization.XmlArrayAttribute>, you can change the name of the XML element, as follows.  
  
```vb  
Public Class Group  
    <XmlArray("TeamMembers")> _  
    Public Employees() As Employee  
End Class  
```  
  
```csharp  
public class Group{  
    [XmlArray("TeamMembers")]  
    public Employee[] Employees;  
}  
```  
  
 The resulting XML might resemble the following.  
  
```xml  
<Group>  
<TeamMembers>  
    <Employee>  
        <Name>Haley</Name>  
    </Employee>  
</TeamMembers>  
```  
  
 The <xref:System.Xml.Serialization.XmlArrayItemAttribute>, on the other hand, controls how the items contained in the array are serialized. Note that the attribute is applied to the field returning the array.  
  
```vb  
Public Class Group  
    <XmlArrayItem("MemberName")> _  
    Public Employee() As Employees  
End Class  
```  
  
```csharp  
public class Group{  
    [XmlArrayItem("MemberName")]  
    public Employee[] Employees;  
}  
```  
  
 The resulting XML might resemble the following.  
  
```xml  
<Group>  
<Employees>  
    <MemberName>Haley</MemberName>  
</Employees>  
</Group>  
```  
  
## Serializing Derived Classes  
 Another use of the <xref:System.Xml.Serialization.XmlArrayItemAttribute> is to allow the serialization of derived classes. For example, another class named `Manager` that derives from `Employee` can be added to the previous example. If you do not apply the <xref:System.Xml.Serialization.XmlArrayItemAttribute>, the code will fail at run time because the derived class type will not be recognized. To remedy this, apply the attribute twice, each time setting the <xref:System.Xml.Serialization.XmlArrayItemAttribute.Type%2A> property for each acceptable type (base and derived).  
  
```vb  
Public Class Group  
    <XmlArrayItem(Type:=GetType(Employee)), _  
    XmlArrayItem(Type:=GetType(Manager))> _  
    Public Employees() As Employee  
End Class  
Public Class Employee  
    Public Name As String  
End Class  
Public Class Manager  
Inherits Employee  
    Public Level As Integer  
End Class  
```  
  
```csharp  
public class Group{  
    [XmlArrayItem(Type = typeof(Employee)),  
    XmlArrayItem(Type = typeof(Manager))]  
    public Employee[] Employees;  
}  
public class Employee{  
    public string Name;  
}  
public class Manager:Employee{  
    public int Level;  
}  
```  
  
 A serialized instance might resemble the following.  
  
```xml  
<Group>  
<Employees>  
    <Employee>  
        <Name>Haley</Name>  
    </Employee>  
    <Employee xsi:type = "Manager">  
        <Name>Ann</Name>  
        <Level>3</Level>  
    <Employee>  
</Employees >  
</Group>  
```  
  
## Serializing an Array as a Sequence of Elements  
 You can also serialize an array as a flat sequence of XML elements by applying a <xref:System.Xml.Serialization.XmlElementAttribute> to the field returning the array as follows.  
  
```vb  
Public Class Group  
    <XmlElement> _  
    Public Employees() As Employee  
End Class  
```  
  
```csharp  
public class Group{  
    [XmlElement]  
    public Employee[] Employees;  
}  
```  
  
 A serialized instance might resemble the following.  
  
```xml  
<Group>  
<Employees>  
    <Name>Haley</Name>  
</Employees>  
<Employees>  
    <Name>Noriko</Name>  
</Employees>  
<Employees>  
    <Name>Marco</Name>  
</Employees>  
</Group>  
```  
  
 Another way to differentiate the two XML streams is to use the XML Schema Definition tool to generate the XML Schema (XSD) document files from the compiled code. (For more details on using the tool, see [The XML Schema Definition Tool and XML Serialization](../../../docs/standard/serialization/the-xml-schema-definition-tool-and-xml-serialization.md).) When no attribute is applied to the field, the schema describes the element in the following manner.  
  
```xml  
<xs:element minOccurs="0" maxOccurs ="1" name="Employees" type="ArrayOfEmployee" />  
```  
  
 When the <xref:System.Xml.Serialization.XmlElementAttribute> is applied to the field, the resulting schema describes the element as follows.  
  
```xml  
<xs:element minOccurs="0" maxOccurs="unbounded" name="Employees" type="Employee" />   
```  
  
## Serializing an ArrayList  
 The <xref:System.Collections.ArrayList> class can contain a collection of diverse objects. You can therefore use a <xref:System.Collections.ArrayList> much as you use an array. Instead of creating a field that returns an array of typed objects, however, you can create a field that returns a single <xref:System.Collections.ArrayList>. However, as with arrays, you must inform the <xref:System.Xml.Serialization.XmlSerializer> of the types of objects the <xref:System.Collections.ArrayList> contains. To accomplish this, assign multiple instances of the <xref:System.Xml.Serialization.XmlElementAttribute> to the field, as shown in the following example.  
  
```vb  
Public Class Group  
    <XmlElement(Type:=GetType(Employee)), _  
    XmlElement(Type:=GetType(Manager))> _  
    Public Info As ArrayList  
End Class  
```  
  
```csharp  
public class Group{  
    [XmlElement(Type = typeof(Employee)),   
    XmlElement(Type = typeof(Manager))]  
    public ArrayList Info;  
}  
```  
  
## Controlling Serialization of Classes Using XmlRootAttribute and XmlTypeAttribute  
 There are two attributes that can be applied to a class (and only a class): <xref:System.Xml.Serialization.XmlRootAttribute> and <xref:System.Xml.Serialization.XmlTypeAttribute>. These attributes are very similar. The <xref:System.Xml.Serialization.XmlRootAttribute> can be applied to only one class: the class that, when serialized, represents the XML document's opening and closing element—in other words, the root element. The <xref:System.Xml.Serialization.XmlTypeAttribute>, on the other hand, can be applied to any class, including the root class.  
  
 For example, in the previous examples, the `Group` class is the root class, and all its public fields and properties become the XML elements found in the XML document. Therefore, there can be only one root class. By applying the <xref:System.Xml.Serialization.XmlRootAttribute>, you can control the XML stream generated by the <xref:System.Xml.Serialization.XmlSerializer>. For example, you can change the element name and namespace.  
  
 The <xref:System.Xml.Serialization.XmlTypeAttribute> allows you to control the schema of the generated XML. This capability is useful when you need to publish the schema through an XML Web service. The following example applies both the <xref:System.Xml.Serialization.XmlTypeAttribute> and the <xref:System.Xml.Serialization.XmlRootAttribute> to the same class.  
  
```vb  
<XmlRoot("NewGroupName"), _  
XmlType("NewTypeName")> _  
Public Class Group  
    Public Employees() As Employee  
End Class  
```  
  
```csharp  
[XmlRoot("NewGroupName")]  
[XmlType("NewTypeName")]  
public class Group{  
    public Employee[] Employees;  
}  
```  
  
 If this class is compiled, and the XML Schema Definition tool is used to generate its schema, you would find the following XML describing `Group`.  
  
```xml  
<xs:element name="NewGroupName" type="NewTypeName">  
```  
  
 In contrast, if you were to serialize an instance of the class, only `NewGroupName` would be found in the XML document.  
  
```xml  
<NewGroupName>  
    . . .  
</NewGroupName>  
```  
  
## Preventing Serialization with the XmlIgnoreAttribute  
 There might be situations when a public property or field does not need to be serialized. For example, a field or property could be used to contain metadata. In such cases, apply the <xref:System.Xml.Serialization.XmlIgnoreAttribute> to the field or property and the <xref:System.Xml.Serialization.XmlSerializer> will skip over it.  
  
## See Also  
 [Attributes That Control XML Serialization](../../../docs/standard/serialization/attributes-that-control-xml-serialization.md)  
 [Attributes That Control Encoded SOAP Serialization](../../../docs/standard/serialization/attributes-that-control-encoded-soap-serialization.md)  
 [Introducing XML Serialization](../../../docs/standard/serialization/introducing-xml-serialization.md)  
 [Examples of XML Serialization](../../../docs/standard/serialization/examples-of-xml-serialization.md)  
 [How to: Specify an Alternate Element Name for an XML Stream](../../../docs/standard/serialization/how-to-specify-an-alternate-element-name-for-an-xml-stream.md)  
 [How to: Serialize an Object](../../../docs/standard/serialization/how-to-serialize-an-object.md)  
 [How to: Deserialize an Object](../../../docs/standard/serialization/how-to-deserialize-an-object.md)
