---
title: "The XML Schema Definition Tool and XML Serialization | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
  - "CSharp"
  - "C++"
  - "jsharp"
helpviewer_keywords: 
  - "Xsd.exe"
  - "XML serialization, XML Schema Definition tool"
  - "XML Schema Definition tool"
  - "serialization, XML Schema Definition tool"
ms.assetid: 3c03f855-f931-47ff-bbc6-50c0367a16e4
caps.latest.revision: 7
author: "Erikre"
ms.author: "erikre"
manager: "erikre"
---
# The XML Schema Definition Tool and XML Serialization
The XML Schema Definition tool ([XML Schema Definition Tool (Xsd.exe)](../../../docs/framework/serialization/xml-schema-definition-tool-xsd-exe.md)) is installed along with the .NET Framework tools as part of the Windows® Software Development Kit (SDK). The tool is designed primarily for two purposes:  
  
-   To generate either C# or Visual Basic class files that conform to a specific XML Schema definition language (XSD) schema. The tool takes an XML Schema as an argument and outputs a file that contains a number of classes that, when serialized with the [XmlSerializer](https://msdn.microsoft.com/en-us/library/system.xml.serialization.xmlserializer.aspx), conform to the schema. For information about how to use the tool to generate classes that conform to a specific schema, see [How to: Use the XML Schema Definition Tool to Generate Classes and XML Schema Documents](../../../docs/framework/serialization/xml-schema-def-tool-gen.md).  
  
-   To generate an XML Schema document from a .dll file or .exe file. To see the schema of a set of files that you have either created or one that has been modified with attributes, pass the DLL or EXE as an argument to the tool to generate the XML schema. For information about how to use the tool to generate an XML Schema Document from a set of classes, see [How to: Use the XML Schema Definition Tool to Generate Classes and XML Schema Documents](../../../docs/framework/serialization/xml-schema-def-tool-gen.md).  
  
 For more information about this tool and others, see [Tools](../../../docs/framework/tools/index.md). For information about the tool's options, see [XML Schema Definition Tool (Xsd.exe)](../../../docs/framework/serialization/xml-schema-definition-tool-xsd-exe.md).  
  
## See Also  
 <xref:System.Data.DataSet>   
 [Introducing XML Serialization](../../../docs/framework/serialization/introducing-xml-serialization.md)   
 [XML Schema Definition Tool (Xsd.exe)](../../../docs/framework/serialization/xml-schema-definition-tool-xsd-exe.md)   
 [XmlSerializer](https://msdn.microsoft.com/en-us/library/system.xml.serialization.xmlserializer.aspx)   
 [How to: Serialize an Object](../../../docs/framework/serialization/how-to-serialize-an-object.md)   
 [How to: Deserialize an Object](../../../docs/framework/serialization/how-to-deserialize-an-object.md)   
 [How to: Use the XML Schema Definition Tool to Generate Classes and XML Schema Documents](../../../docs/framework/serialization/xml-schema-def-tool-gen.md)   
 [XML Schema Binding Support in the .NET Framework](http://msdn.microsoft.com/en-us/8f0619dd-f1fc-4895-ae21-6d45d0382cc1)