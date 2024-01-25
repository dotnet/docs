---
title: System.Xml.Serialization.CodeGenerationOptions enum
description: Learn about the System.Xml.Serialization.CodeGenerationOptions enum.
ms.date: 12/31/2023
---
# System.Xml.Serialization.CodeGenerationOptions enum

[!INCLUDE [context](includes/context.md)]

A Web Service Description Language (WSDL) file typically describes a class in XML schema language as an `xsd:complex` type composed of various primitive `xsd:complex` and `xsd:simple` types. When generating a .NET class that represents a given `xsd:complex` type, you must choose how to represent the various primitive types it contains.

By default, each primitive is implemented as a field. If you specify the `GenerateProperties` option, each primitive type is instead implemented as a property.

## Ordering of serialization code

The `GenerateOrder` member instructs the code generator to create the serialization code in a specific order as determined by the `Order` property of the following attributes:

- <xref:System.Xml.Serialization.XmlAnyElementAttribute>
- <xref:System.Xml.Serialization.XmlArrayAttribute>
- <xref:System.Xml.Serialization.XmlElementAttribute>

> [!NOTE]
> Once the `Order` property has been set on one public property or field in a type, it must be applied to all public properties and fields for that type and all inherited types.
