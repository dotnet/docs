---
title: "The XML Schema Definition Tool and XML Serialization"
description: The XML Schema Definition tool generates C# or Visual Basic class files for an XSD schema and generates an XML schema from a library or executable file.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "Xsd.exe"
  - "XML serialization, XML Schema Definition tool"
  - "XML Schema Definition tool"
  - "serialization, XML Schema Definition tool"
ms.assetid: 3c03f855-f931-47ff-bbc6-50c0367a16e4
ms.topic: article
---
# The XML Schema Definition Tool and XML Serialization

The XML Schema Definition tool ([XML Schema Definition Tool (Xsd.exe)](xml-schema-definition-tool-xsd-exe.md)) is installed along with the .NET Framework tools as part of the Windows&reg; Software Development Kit (SDK). The tool is designed primarily for two purposes:  
  
- To generate either C# or Visual Basic class files that conform to a specific XML Schema definition language (XSD) schema. The tool takes an XML Schema as an argument and outputs a file that contains a number of classes that, when serialized with the <xref:System.Xml.Serialization.XmlSerializer>, conform to the schema. For information about how to use the tool to generate classes that conform to a specific schema, see [How to: Use the XML Schema Definition Tool to Generate Classes and XML Schema Documents](xml-schema-def-tool-gen.md).  
  
- To generate an XML Schema document from a .dll file or .exe file. To see the schema of a set of files that you have either created or one that has been modified with attributes, pass the DLL or EXE as an argument to the tool to generate the XML schema. For information about how to use the tool to generate an XML Schema Document from a set of classes, see [How to: Use the XML Schema Definition Tool to Generate Classes and XML Schema Documents](xml-schema-def-tool-gen.md).  
  
For more information about using the tool, see [XML Schema Definition Tool (Xsd.exe)](xml-schema-definition-tool-xsd-exe.md).  
  
## See also

- <xref:System.Data.DataSet>
- [Introducing XML Serialization](introducing-xml-serialization.md)
- [XML Schema Definition Tool (Xsd.exe)](xml-schema-definition-tool-xsd-exe.md)
- <xref:System.Xml.Serialization.XmlSerializer>
- [How to: Serialize an Object](how-to-serialize-an-object.md)
- [How to: Deserialize an Object](how-to-deserialize-an-object.md)
- [How to: Use the XML Schema Definition Tool to Generate Classes and XML Schema Documents](xml-schema-def-tool-gen.md)
- [XML Schema Binding Support](/previous-versions/dotnet/netframework-4.0/sh1e66zd(v=vs.100))
