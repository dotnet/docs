---
title: System.Xml.Serialization.XmlSerializer class
description: Learn about the System.Xml.Serialization.XmlSerializer class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - VB
ms.topic: article
---
# System.Xml.Serialization.XmlSerializer class

[!INCLUDE [context](includes/context.md)]

XML serialization is the process of converting an object's public properties and fields to a serial format (in this case, XML) for storage or transport. Deserialization re-creates the object in its original state from the XML output. You can think of serialization as a way of saving the state of an object into a stream or buffer. For example, ASP.NET uses the <xref:System.Xml.Serialization.XmlSerializer> class to encode XML Web service messages.

The data in your objects is described using programming language constructs like classes, fields, properties, primitive types, arrays, and even embedded XML in the form of <xref:System.Xml.XmlElement> or <xref:System.Xml.XmlAttribute> objects. You have the option of creating your own classes, annotated with attributes, or using the [XML Schema Definition Tool (Xsd.exe)](../../standard/serialization/xml-schema-definition-tool-xsd-exe.md) to generate the classes based on an existing XML Schema definition (XSD) document. If you have an XML Schema, you can run the Xsd.exe to produce a set of classes that are strongly typed to the schema and annotated with attributes to adhere to the schema when serialized.

To transfer data between objects and XML requires a mapping from the programming language constructs to XML schema and from the XML schema to the programming language constructs. The <xref:System.Xml.Serialization.XmlSerializer> and related tools like Xsd.exe provide the bridge between these two technologies at both design time and runtime. At design time, use the Xsd.exe to produce an XML schema document (.xsd) from your custom classes or to produce classes from a given schema. In either case, the classes are annotated with custom attributes to instruct the <xref:System.Xml.Serialization.XmlSerializer> how to map between the XML schema system and the common language runtime. At runtime, instances of the classes can be serialized into XML documents that follow the given schema. Likewise, these XML documents can be deserialized into runtime objects. Note that the XML schema is optional, and not required at design time or runtime.

## Control generated XML

To control the generated XML, you can apply special attributes to classes and members. For example, to specify a different XML element name, apply an <xref:System.Xml.Serialization.XmlElementAttribute> to a public field or property, and set the <xref:System.Xml.Serialization.XmlElementAttribute.ElementName> property. For a complete list of similar attributes, see [Attributes That Control XML Serialization](../../standard/serialization/attributes-that-control-xml-serialization.md). You can also implement the <xref:System.Xml.Serialization.IXmlSerializable> interface to control the XML output.

If the XML generated must conform to section 5 of the World Wide Consortium document, [Simple Object Access Protocol (SOAP) 1.1](https://www.w3.org/TR/2000/NOTE-SOAP-20000508/), you must construct the <xref:System.Xml.Serialization.XmlSerializer> with an <xref:System.Xml.Serialization.XmlTypeMapping>. To further control the encoded SOAP XML, use the attributes listed in [Attributes That Control Encoded SOAP Serialization](../../standard/serialization/attributes-that-control-encoded-soap-serialization.md).

With the <xref:System.Xml.Serialization.XmlSerializer> you can take advantage of working with strongly typed classes and still have the flexibility of XML. Using fields or properties of type <xref:System.Xml.XmlElement>, <xref:System.Xml.XmlAttribute> or <xref:System.Xml.XmlNode> in your strongly typed classes, you can read parts of the XML document directly into XML objects.

If you work with extensible XML schemas, you can also use the <xref:System.Xml.Serialization.XmlAnyElementAttribute> and <xref:System.Xml.Serialization.XmlAnyAttributeAttribute> attributes to serialize and deserialize elements or attributes that are not found in the original schema. To use the objects, apply an <xref:System.Xml.Serialization.XmlAnyElementAttribute> to a field that returns an array of <xref:System.Xml.XmlElement> objects, or apply an <xref:System.Xml.Serialization.XmlAnyAttributeAttribute> to a field that returns an array of <xref:System.Xml.XmlAttribute> objects.

If a property or field returns a complex object (such as an array or a class instance), the <xref:System.Xml.Serialization.XmlSerializer> converts it to an element nested within the main XML document. For example, the first class in the following code returns an instance of the second class.

```vb
Public Class MyClass
    Public MyObjectProperty As MyObject
End Class

Public Class MyObject
    Public ObjectName As String
End Class
```

```csharp
public class MyClass
{
    public MyObject MyObjectProperty;
}
public class MyObject
{
    public string ObjectName;
}
```

The serialized, XML output looks like this:

```xml
<MyClass>
  <MyObjectProperty>
  <ObjectName>My String</ObjectName>
  </MyObjectProperty>
</MyClass>
```

If a schema includes an element that is optional (minOccurs = '0'), or if the schema includes a default value, you have two options. One option is to use <xref:System.ComponentModel.DefaultValueAttribute?displayProperty=nameWithType> to specify the default value, as shown in the following code.

```vb
Public Class PurchaseOrder
    <System.ComponentModel.DefaultValueAttribute ("2002")> _
    Public Year As String
End Class
```

```csharp
public class PurchaseOrder
{
    [System.ComponentModel.DefaultValueAttribute ("2002")]
    public string Year;
}
```

Another option is to use a special pattern to create a Boolean field recognized by the <xref:System.Xml.Serialization.XmlSerializer>, and to apply the <xref:System.Xml.Serialization.XmlIgnoreAttribute> to the field. The pattern is created in the form of `propertyNameSpecified`. For example, if there is a field named "MyFirstName" you would also create a field named "MyFirstNameSpecified" that instructs the <xref:System.Xml.Serialization.XmlSerializer> whether to generate the XML element named "MyFirstName". This is shown in the following example.

```vb
Public Class OptionalOrder
    ' This field's value should not be serialized
    ' if it is uninitialized.
    Public FirstOrder As String

    ' Use the XmlIgnoreAttribute to ignore the
    ' special field named "FirstOrderSpecified".
    <System.Xml.Serialization.XmlIgnoreAttribute> _
    Public FirstOrderSpecified As Boolean
End Class
```

```csharp
public class OptionalOrder
{
    // This field should not be serialized
    // if it is uninitialized.
    public string FirstOrder;

    // Use the XmlIgnoreAttribute to ignore the
    // special field named "FirstOrderSpecified".
    [System.Xml.Serialization.XmlIgnoreAttribute]
    public bool FirstOrderSpecified;
}
```

## Override default serialization

You can also override the serialization of any set of objects and their fields and properties by creating one of the appropriate attributes, and adding it to an instance of the <xref:System.Xml.Serialization.XmlAttributes> class. Overriding serialization in this way has two uses: first, you can control and augment the serialization of objects found in a DLL, even if you do not have access to the source; second, you can create one set of serializable classes, but serialize the objects in multiple ways. For more details, see the <xref:System.Xml.Serialization.XmlAttributeOverrides> class and [How to: Control Serialization of Derived Classes](../../standard/serialization/how-to-control-serialization-of-derived-classes.md).

To serialize an object, call the <xref:System.Xml.Serialization.XmlSerializer.Serialize%2A> method. To deserialize an object, call the <xref:System.Xml.Serialization.XmlSerializer.Deserialize%2A> method.

To add XML namespaces to an XML document, see <xref:System.Xml.Serialization.XmlSerializerNamespaces>.

> [!NOTE]
> The <xref:System.Xml.Serialization.XmlSerializer> gives special treatment to classes that implement <xref:System.Collections.IEnumerable> or <xref:System.Collections.ICollection>. A class that implements <xref:System.Collections.IEnumerable> must implement a public `Add` method that takes a single parameter. The `Add` method's parameter must be of the same type as is returned from the `Current` property on the value returned from `GetEnumerator`, or one of that type's bases. A class that implements <xref:System.Collections.ICollection> (such as <xref:System.Collections.CollectionBase>) in addition to <xref:System.Collections.IEnumerable> must have a public `Item` indexed property (indexer in C#) that takes an integer, and it must have a public `Count` property of type integer. The parameter to the `Add` method must be the same type as is returned from the `Item` property, or one of that type's bases. For classes that implement <xref:System.Collections.ICollection>, values to be serialized are retrieved from the indexed `Item` property, not by calling `GetEnumerator`.

You must have permission to write to the temporary directory (as defined by the TEMP environment variable) to deserialize an object.

## Dynamically generated assemblies

To increase performance, the XML serialization infrastructure dynamically generates assemblies to serialize and deserialize specified types. The infrastructure finds and reuses those assemblies. This behavior occurs only when using the following constructors:

<xref:System.Xml.Serialization.XmlSerializer.%23ctor%28System.Type%29?displayProperty=nameWithType>

<xref:System.Xml.Serialization.XmlSerializer.%23ctor%28System.Type%2CSystem.String%29?displayProperty=nameWithType>

If you use any of the other constructors, multiple versions of the same assembly are generated and never unloaded, which results in a memory leak and poor performance. The easiest solution is to use one of the previously mentioned two constructors. Otherwise, you must cache the assemblies in a <xref:System.Collections.Hashtable>, as shown in the following example.

```csharp
Hashtable serializers = new Hashtable();

// Use the constructor that takes a type and XmlRootAttribute.
XmlSerializer s = new XmlSerializer(typeof(MyClass), myRoot);

// Implement a method named GenerateKey that creates unique keys
// for each instance of the XmlSerializer. The code should take
// into account all parameters passed to the XmlSerializer
// constructor.
object key = GenerateKey(typeof(MyClass), myRoot);

// Check the local cache for a matching serializer.
XmlSerializer ser = (XmlSerializer)serializers[key];
if (ser == null)
{
    ser = new XmlSerializer(typeof(MyClass), myRoot);
    // Cache the serializer.
    serializers[key] = ser;
}

// Use the serializer to serialize or deserialize.
```

```vb
Dim serializers As New Hashtable()

' Use the constructor that takes a type and XmlRootAttribute.
Dim s As New XmlSerializer(GetType([MyClass]), myRoot)

' Implement a method named GenerateKey that creates unique keys
' for each instance of the XmlSerializer. The code should take
' into account all parameters passed to the XmlSerializer
' constructor.
Dim key As Object = GenerateKey(GetType([MyClass]), myRoot)

' Check the local cache for a matching serializer.
Dim ser As XmlSerializer = CType(serializers(key), XmlSerializer)

If ser Is Nothing Then
    ser = New XmlSerializer(GetType([MyClass]), myRoot)
    ' Cache the serializer.
    serializers(key) = ser
End If

' Use the serializer to serialize or deserialize.
```

## Serialization of ArrayList and generic list

The <xref:System.Xml.Serialization.XmlSerializer> cannot serialize or deserialize the following:

- Arrays of <xref:System.Collections.ArrayList>
- Arrays of <xref:System.Collections.Generic.List%601>

## Serialization of enumerations of unsigned Long

The <xref:System.Xml.Serialization.XmlSerializer> cannot be instantiated to serialize an enumeration if the following conditions are true: The enumeration is of type unsigned long (`ulong` in C#) and the enumeration contains any member with a value larger than 9,223,372,036,854,775,807. For example, the following cannot be serialized.

```csharp
public enum LargeNumbers: ulong
{
    a = 9223372036854775808
}
// At run time, the following code will fail.
xmlSerializer mySerializer=new XmlSerializer(typeof(LargeNumbers));
```

## Obsolete types

The <xref:System.Xml.Serialization.XmlSerializer> class does not serializes objects that are marked as `[Obsolete]`.
