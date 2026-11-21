---
title: "Controlling XML Serialization Using Attributes"
description: Attributes can be used to control the XML serialization of an object or to create an alternate XML stream from the same set of classes.
ms.date: 11/01/2026
ms.custom: devdivchpfy22
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
  - "attributes [.NET], XML serialization"
  - "serialization, examples"
  - "serialization, attributes"
ms.topic: how-to
---
# Control XML serialization using attributes

Attributes can be used to control the XML serialization of an object or to create an alternate XML stream from the same set of classes. For more information about creating an alternate XML stream, see [How to: Specify an Alternate Element Name for an XML Stream](how-to-specify-an-alternate-element-name-for-an-xml-stream.md).

> [!NOTE]
> If the XML generated must conform to section 5 of the World Wide Web Consortium (W3C) document titled [Simple Object Access Protocol (SOAP) 1.1](https://www.w3.org/TR/2000/NOTE-SOAP-20000508/), use the attributes listed in [Attributes That Control Encoded SOAP Serialization](attributes-that-control-encoded-soap-serialization.md).

By default, an XML element name is determined by the class or member name. In a class named `Book`, a field named **ISBN** will produce an XML element tag `<ISBN>`, as shown in the following example:

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

The default behavior can be changed if you want to give the element a new name. The following code shows how an attribute enables this functionality by setting the <xref:System.Xml.Serialization.XmlElementAttribute.ElementName> property of an <xref:System.Xml.Serialization.XmlElementAttribute>:

```vb
Public Class TaxRates
   < XmlElement(ElementName = "TaxRate")> _
    Public ReturnTaxRate As Decimal
End Class
```

```csharp
public class TaxRates {
    [XmlElement(ElementName = "TaxRate")]
    public decimal ReturnTaxRate;
}
```

For more information about attributes, see [Attributes](../attributes/index.md). For a list of attributes that control XML serialization, see [Attributes That Control XML Serialization](attributes-that-control-xml-serialization.md).

## Controlling Array Serialization

The <xref:System.Xml.Serialization.XmlArrayAttribute> and the <xref:System.Xml.Serialization.XmlArrayItemAttribute> attributes control the serialization of arrays. Using these attributes, you can control the element name, namespace, and XML Schema (XSD) data type as defined in the W3C document titled [XML Schema Part 2: Datatypes](https://www.w3.org/TR/xmlschema-2/). You can also specify the types that can be included in an array.

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
public class Group {
    public Employee[] Employees;
}
public class Employee {
    public string Name;
}
```

A serialized instance might resemble the following code:

```xml
<Group>
<Employees>
    <Employee>
        <Name>Haley</Name>
    </Employee>
</Employees>
</Group>
```

By applying a <xref:System.Xml.Serialization.XmlArrayAttribute>, you can change the name of the XML element, as follows:

```vb
Public Class Group
    <XmlArray("TeamMembers")> _
    Public Employees() As Employee
End Class
```

```csharp
public class Group {
    [XmlArray("TeamMembers")]
    public Employee[] Employees;
}
```

The resulting XML might resemble the following code:

```xml
<Group>
<TeamMembers>
    <Employee>
        <Name>Haley</Name>
    </Employee>
</TeamMembers>
</Group>
```

The <xref:System.Xml.Serialization.XmlArrayItemAttribute>, on the other hand, controls how the items contained in the array are serialized.

> [!NOTE]
> The attribute is applied to the field returning the array.

```vb
Public Class Group
    <XmlArrayItem("MemberName")> _
    Public Employee() As Employees
End Class
```

```csharp
public class Group {
    [XmlArrayItem("MemberName")]
    public Employee[] Employees;
}
```

The resulting XML might resemble the following code:

```xml
<Group>
<Employees>
    <MemberName>Haley</MemberName>
</Employees>
</Group>
```

## Serializing Derived Classes

Another use of the <xref:System.Xml.Serialization.XmlArrayItemAttribute> is to allow the serialization of derived classes. For example, another class named `Manager` that derives from `Employee` can be added to the previous example. If you don't apply the <xref:System.Xml.Serialization.XmlArrayItemAttribute>, the code will fail at runtime because the derived class type won't be recognized. To remedy this outcome, apply the attribute twice, each time setting the <xref:System.Xml.Serialization.XmlArrayItemAttribute.Type> property for each acceptable type (base and derived).

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
public class Group {
    [XmlArrayItem(Type = typeof(Employee)),
    XmlArrayItem(Type = typeof(Manager))]
    public Employee[] Employees;
}
public class Employee {
    public string Name;
}
public class Manager:Employee {
    public int Level;
}
```

A serialized instance might resemble the following code:

```xml
<Group>
<Employees>
    <Employee>
        <Name>Haley</Name>
    </Employee>
    <Employee xsi:type = "Manager">
        <Name>Ann</Name>
        <Level>3</Level>
    </Employee>
</Employees>
</Group>
```

## Serializing an Array as a Sequence of Elements

You can also serialize an array as a flat sequence of XML elements by applying a <xref:System.Xml.Serialization.XmlElementAttribute> to the field returning the array as follows:

```vb
Public Class Group
    <XmlElement> _
    Public Employees() As Employee
End Class
```

```csharp
public class Group {
    [XmlElement]
    public Employee[] Employees;
}
```

A serialized instance might resemble the following code:

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

Another way to differentiate the two XML streams is to use the XML Schema Definition tool to generate the XML Schema (XSD) document files from the compiled code. For more information on using the tool, see [The XML Schema Definition Tool and XML Serialization](the-xml-schema-definition-tool-and-xml-serialization.md). When no attribute is applied to the field, the schema describes the element in the following manner:

```xml
<xs:element minOccurs="0" maxOccurs ="1" name="Employees" type="ArrayOfEmployee" />
```

When the <xref:System.Xml.Serialization.XmlElementAttribute> is applied to the field, the resulting schema describes the element as follows:

```xml
<xs:element minOccurs="0" maxOccurs="unbounded" name="Employees" type="Employee" />
```

## Serializing an ArrayList

The <xref:System.Collections.ArrayList> class can contain a collection of diverse objects. You can therefore use an <xref:System.Collections.ArrayList> much as you use an array. Instead of creating a field that returns an array of typed objects, however, you can create a field that returns a single <xref:System.Collections.ArrayList>. However, as with arrays, you must inform the <xref:System.Xml.Serialization.XmlSerializer> of the types of objects the <xref:System.Collections.ArrayList> contains. To accomplish this, assign multiple instances of the <xref:System.Xml.Serialization.XmlElementAttribute> to the field, as shown in the following example.

```vb
Public Class Group
    <XmlElement(Type:=GetType(Employee)), _
    XmlElement(Type:=GetType(Manager))> _
    Public Info As ArrayList
End Class
```

```csharp
public class Group {
    [XmlElement(Type = typeof(Employee)),
    XmlElement(Type = typeof(Manager))]
    public ArrayList Info;
}
```

## Controlling Serialization of Classes Using XmlRootAttribute and XmlTypeAttribute

You can apply two attributes to a class only: <xref:System.Xml.Serialization.XmlRootAttribute> and <xref:System.Xml.Serialization.XmlTypeAttribute>. These attributes are similar. The <xref:System.Xml.Serialization.XmlRootAttribute> can be applied to only one class: the class that, when serialized, represents the XML document's opening and closing element—in other words, the root element. The <xref:System.Xml.Serialization.XmlTypeAttribute>, on the other hand, can be applied to any class, including the root class.

For example, in the previous examples, the `Group` class is the root class, and all its public fields and properties become the XML elements found in the XML document. Therefore, you can have only one root class. By applying the <xref:System.Xml.Serialization.XmlRootAttribute>, you can control the XML stream generated by the <xref:System.Xml.Serialization.XmlSerializer>. For example, you can change the element name and namespace.

The <xref:System.Xml.Serialization.XmlTypeAttribute> allows you to control the schema of the generated XML. This capability is useful when you need to publish the schema through an XML Web service. The following example applies both the <xref:System.Xml.Serialization.XmlTypeAttribute> and the <xref:System.Xml.Serialization.XmlRootAttribute> to the same class:

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
public class Group {
    public Employee[] Employees;
}
```

If this class is compiled, and the XML Schema Definition tool is used to generate its schema, you would find the following XML describing `Group`:

```xml
<xs:element name="NewGroupName" type="NewTypeName" />
```

In contrast, if you were to serialize an instance of the class, only `NewGroupName` would be found in the XML document:

```xml
<NewGroupName>
    . . .
</NewGroupName>
```

## Preventing Serialization with the XmlIgnoreAttribute

You might come across a situation where a public property or field doesn't need to be serialized. For example, a field or property could be used to contain metadata. In such cases, apply the <xref:System.Xml.Serialization.XmlIgnoreAttribute> to the field or property and the <xref:System.Xml.Serialization.XmlSerializer> will skip over it.

## Conditionally serializing members

Instead of unconditionally ignoring a property with <xref:System.Xml.Serialization.XmlIgnoreAttribute>, you can conditionally control whether a property or field is serialized by using either of the following conventions:

- A `ShouldSerialize{PropertyName}()` method
- A companion `{PropertyName}Specified` property or field

### The ShouldSerialize pattern

To conditionally serialize a property based on runtime state (such as whether an array or collection is non-empty, or whether a value meets specific criteria), define a `public` parameterless method on the class that returns a `bool` and begins with the prefix `ShouldSerialize`, followed by the exact property name:

```csharp
public class InventoryItem
{
    public string Name { get; set; } = string.Empty;

    public string[] Tags { get; set; } = Array.Empty<string>();

    // The method must be public, return bool, take no parameters,
    // and match the pattern ShouldSerialize<PropertyName>().
    public bool ShouldSerializeTags()
    {
        return Tags is not null && Tags.Length > 0;
    }
}
```

```vb
Public Class InventoryItem
    Public Property Name As String = String.Empty

    Public Property Tags As String() = Array.Empty(Of String)()

    Public Function ShouldSerializeTags() As Boolean
        Return Tags IsNot Nothing AndAlso Tags.Length > 0
    End Function
End Class
```

When <xref:System.Xml.Serialization.XmlSerializer> serializes an instance of `InventoryItem`, it invokes `ShouldSerializeTags()`. If the method returns `false`, the `Tags` element is omitted from the serialized XML.

> [!IMPORTANT]
> The `ShouldSerialize{PropertyName}` method must be declared with `public` visibility. If the method is private or protected, `XmlSerializer` ignores it.

### The Specified pattern

For value types (such as `int`, <xref:System.DateTime>, or enum fields) where the property cannot be `null`, you can define a companion `public` boolean property or field named `{PropertyName}Specified`:

```csharp
public class Order
{
    public int OrderId { get; set; }

    public DateTime DeliveryDate { get; set; }

    // When DeliveryDateSpecified is false, DeliveryDate is not serialized.
    public bool DeliveryDateSpecified { get; set; }
}
```

```vb
Public Class Order
    Public Property OrderId As Integer

    Public Property DeliveryDate As DateTime

    Public Property DeliveryDateSpecified As Boolean
End Class
```

When `DeliveryDateSpecified` is `false`, the `DeliveryDate` element is omitted from the serialized output. When deserializing XML that lacks the `DeliveryDate` element, `XmlSerializer` automatically sets `DeliveryDateSpecified` to `false`. The [XML Schema Definition Tool (Xsd.exe)](xml-schema-definition-tool-xsd-exe.md) generates `{PropertyName}Specified` members automatically for optional schema elements (`minOccurs="0"`).

## See also

- [Attributes That Control XML Serialization](attributes-that-control-xml-serialization.md)
- [Attributes That Control Encoded SOAP Serialization](attributes-that-control-encoded-soap-serialization.md)
- [Introducing XML Serialization](introducing-xml-serialization.md)
- [Examples of XML Serialization](examples-of-xml-serialization.md)
- [How to: Specify an Alternate Element Name for an XML Stream](how-to-specify-an-alternate-element-name-for-an-xml-stream.md)
- [How to: Serialize an Object](how-to-serialize-an-object.md)
- [How to: Deserialize an Object](how-to-deserialize-an-object.md)
