---
description: "Learn more about: Loosely-Typed Extensions Sample"
title: "Loosely-Typed Extensions Sample"
ms.date: "03/30/2017"
ms.assetid: 56ce265b-8163-4b85-98e7-7692a12c4357
---
# Loosely typed extensions sample

The [LooselyTypedExtensions sample](https://github.com/dotnet/samples/tree/main/framework/wcf) illustrates the basic techniques for working with extension data.

The Syndication object model provides rich support for working with extension data—information that is present in a syndication feed's XML representation but not explicitly exposed by classes such as <xref:System.ServiceModel.Syndication.SyndicationFeed> and <xref:System.ServiceModel.Syndication.SyndicationItem>.

The sample uses the <xref:System.ServiceModel.Syndication.SyndicationFeed> class for the purposes of the example. However, the patterns demonstrated in this sample can be used with all of the Syndication classes that support extension data:

 <xref:System.ServiceModel.Syndication.SyndicationFeed>

 <xref:System.ServiceModel.Syndication.SyndicationItem>

 <xref:System.ServiceModel.Syndication.SyndicationCategory>

 <xref:System.ServiceModel.Syndication.SyndicationPerson>

 <xref:System.ServiceModel.Syndication.SyndicationLink>

## Sample XML

For reference, the following XML document is used in this sample.

```xml
<?xml version="1.0" encoding="IBM437"?>
<feed myAttribute="someValue" xmlns="http://www.w3.org/2005/Atom">
  <title type="text"></title>
  <id>uuid:8f60c7b3-a3c0-4de7-a642-2165d77ce3c1;id=1</id>
  <updated>2007-09-07T22:15:34Z</updated>
  <simpleString xmlns="">hello, world!</simpleString>
  <simpleString xmlns="">another simple string</simpleString>
  <DataContractExtension xmlns:i="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.d
atacontract.org/2004/07/Microsoft.Syndication.Samples">
    <Key>X</Key>
    <Value>4</Value>
  </DataContractExtension>
  <XmlSerializerExtension xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://ww
w.w3.org/2001/XMLSchema" xmlns="">
    <Key>Y</Key>
    <Value>8</Value>
  </XmlSerializerExtension>
  <xElementExtension xmlns="">
    <Key attr1="someValue">Z</Key>
    <Value attr1="someValue">15</Value>
  </xElementExtension>
</feed>
```

This document contains the following pieces of extension data:

- The `myAttribute` attribute of the `<feed>` element.

- `<simpleString>` element.

- `<DataContractExtension>` element.

- `<XmlSerializerExtension>` element.

- `<xElementExtension>` element.

## Writing Extension Data

Attribute extensions are created by adding entries to the <xref:System.ServiceModel.Syndication.SyndicationFeed.AttributeExtensions%2A> collection as shown in the following sample code.

```csharp
//Attribute extensions are stored in a dictionary indexed by
// XmlQualifiedName
feed.AttributeExtensions.Add(new XmlQualifiedName("myAttribute", ""), "someValue");
```

Element extensions are created by adding entries to the <xref:System.ServiceModel.Syndication.SyndicationFeed.ElementExtensions%2A> collection. These extensions can by basic values such as strings, XML serializations of .NET Framework objects, or XML nodes coded by hand.

The following sample code creates an extension element named `simpleString`.

```csharp
feed.ElementExtensions.Add("simpleString", "", "hello, world!");
```

The XML namespace for this element is the empty namespace ("") and its value is a text node that contains the string "hello, world!".

One way to create complex element extensions that consist of many nested elements is to use the .NET Framework APIs for serialization (both the <xref:System.Runtime.Serialization.DataContractSerializer> and the <xref:System.Xml.Serialization.XmlSerializer> are supported) as shown in the following examples.

```csharp
feed.ElementExtensions.Add( new DataContractExtension() { Key = "X", Value = 4 } );
feed.ElementExtensions.Add( new XmlSerializerExtension { Key = "Y", Value = 8 }, new XmlSerializer( typeof( XmlSerializerExtension ) ) );
```

In this example, the `DataContractExtension` and `XmlSerializerExtension` are custom types written for use with a serializer.

The <xref:System.ServiceModel.Syndication.SyndicationElementExtensionCollection> class can also be used to create element extensions from an <xref:System.Xml.XmlReader> instance. This allows for easy integration with XML processing APIs such as <xref:System.Xml.Linq.XElement> as shown in the following sample code.

```csharp
feed.ElementExtensions.Add(new XElement("xElementExtension",
        new XElement("Key", new XAttribute("attr1", "someValue"), "Z"),
        new XElement("Value", new XAttribute("attr1", "someValue"),
        "15")).CreateReader());
```

## Reading Extension Data

The values for attribute extensions can be obtained by looking up the attribute in the <xref:System.ServiceModel.Syndication.SyndicationFeed.AttributeExtensions%2A> collection by its <xref:System.Xml.XmlQualifiedName> as shown in the following sample code.

```csharp
Console.WriteLine( feed.AttributeExtensions[ new XmlQualifiedName( "myAttribute", "" )]);
```

Element extensions are accessed using the `ReadElementExtensions<T>` method.

```csharp
foreach( string s in feed2.ElementExtensions.ReadElementExtensions<string>("simpleString", ""))
{
    Console.WriteLine(s);
}

foreach (DataContractExtension dce in feed2.ElementExtensions.ReadElementExtensions<DataContractExtension>("DataContractExtension",
"http://schemas.datacontract.org/2004/07/SyndicationExtensions"))
{
    Console.WriteLine(dce.ToString());
}

foreach (XmlSerializerExtension xse in feed2.ElementExtensions.ReadElementExtensions<XmlSerializerExtension>("XmlSerializerExtension", "", new XmlSerializer(typeof(XmlSerializerExtension))))
{
    Console.WriteLine(xse.ToString());
}
```

It is also possible to obtain an `XmlReader` at individual element extensions by using the <xref:System.ServiceModel.Syndication.SyndicationElementExtension.GetReader> method.

```csharp
foreach (SyndicationElementExtension extension in feed2.ElementExtensions.Where<SyndicationElementExtension>(x => x.OuterName == "xElementExtension"))
{
    XNode xelement = XElement.ReadFrom(extension.GetReader());
    Console.WriteLine(xelement.ToString());
}
```

#### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).

## See also

- [Strongly typed Extensions](strongly-typed-extensions-sample.md)
- [WCF Syndication](../feature-details/wcf-syndication.md)
