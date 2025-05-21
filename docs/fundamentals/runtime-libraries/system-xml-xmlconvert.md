---
title: System.Xml.XmlConvert class
description: Learn about the System.Xml.XmlConvert class.
ms.date: 12/31/2023
ms.topic: article
---
# System.Xml.XmlConvert class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Xml.XmlConvert> class is functionally equivalent to the <xref:System.Convert> class, but it supports XML standards. The type system is based on the XML Schema definition language (XSD) schema type, and the values returned are always locale-independent.

## Encoding and decoding

Element and attribute names or ID values are limited to a range of XML characters according to the W3C [XML 1.0 recommendation](https://www.w3.org/TR/2006/REC-xml-20060816/). When names contain invalid characters, you can use the <xref:System.Xml.XmlConvert.EncodeName%2A> and <xref:System.Xml.XmlConvert.DecodeName%2A> methods in this class to translate them into valid XML names.

For example, if you want to use the column heading "Order Detail" in a database, the database allows the space between the two words. However, in XML, the space between "Order" and "Detail" is considered an invalid XML character. You have to convert it into an escaped hexadecimal encoding and decode it later.

You can use the <xref:System.Xml.XmlConvert.EncodeName%2A> method with the <xref:System.Xml.XmlWriter> class to ensure the names being written are valid XML names. The following C# code converts the name "Order Detail" into a valid XML name and writes the element `<Order_0x0020_Detail>My order</Order_0x0020_Detail>`.

```csharp
writer.WriteElementString(XmlConvert.EncodeName("Order Detail"),"My order");
```

The following <xref:System.Xml.XmlConvert> methods perform encoding and decoding.

|Method|Description|
|------------|-----------------|
|<xref:System.Xml.XmlConvert.EncodeName%2A>|Takes a name and returns the encoded name along with any invalid character that is replaced by an escape string. This method allows colons in any position, which means that the name may still be invalid according to the W3C [Namespaces in XML 1.0 recommendation](https://www.w3.org/TR/REC-xml-names/).|
|<xref:System.Xml.XmlConvert.EncodeNmToken%2A>|Takes a name and returns the encoded name.|
|<xref:System.Xml.XmlConvert.EncodeLocalName%2A>|Same as <xref:System.Xml.XmlConvert.EncodeName%2A> except that it also encodes the colon character, guaranteeing that the name can be used as the `LocalName` part of a namespace-qualified name.|
|<xref:System.Xml.XmlConvert.DecodeName%2A>|Reverses the transformation for all the encoding methods.|

## Name validation

The <xref:System.Xml.XmlConvert> class contains two methods that check the characters in an element or attribute name and verify that the name conforms to the rules set by the W3C [XML 1.0 recommendation](https://www.w3.org/TR/2006/REC-xml-20060816/):

- <xref:System.Xml.XmlConvert.VerifyName%2A> checks the characters and verifies that the name is valid. The method returns the name if it's valid, and throws an exception if it isn't.
- <xref:System.Xml.XmlConvert.VerifyNCName%2A> performs the same validation, but accepts non-qualified names.

The <xref:System.Xml.XmlConvert> contains additional methods that validate tokens, white-space characters, public IDs, and other strings.

## Data type conversion

<xref:System.Xml.XmlConvert> also provides methods that enable you to convert data from a string to a strongly typed data type. For example, the <xref:System.Xml.XmlConvert.ToDateTime%2A> method converts a string to its <xref:System.DateTime> equivalent. This is useful because most methods in the <xref:System.Xml.XmlReader> class return data as a string. After the data is read, it can be converted to the proper data type before being used. The <xref:System.Xml.XmlConvert.ToString%2A> overloads provide the complementary operation by converting strongly typed data to strings. For example, this is useful when you want to add the data to text boxes on a webpage. Locale settings are not taken into account during data conversion. The data types are based on the XML Schema (XSD) data types.
