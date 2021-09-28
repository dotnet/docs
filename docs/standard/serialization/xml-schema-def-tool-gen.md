---
title: "How to: Use the XML Schema Definition Tool to Generate Classes and XML Schema Documents"
description: Learn how to use the XML Schema Definition tool to generate an XML schema that describes a class or to generate the class defined by an XML schema.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "generating XML classes using XML Schema Definition tool"
  - "generating XML Schema Document using XML Schema Definition tool"
  - "XML Schema Definition tool, using to generate classes that conform to specific schema"
  - "XML Schema Definition tool, using to generate XML Schema Document"
ms.assetid: 51f0edc3-993d-4051-b7f2-77753694d3d1
---
# How to: Use the XML Schema Definition Tool to Generate Classes and XML Schema Documents

The XML Schema Definition tool (Xsd.exe) allows you to generate an XML schema that describes a class or to generate the class defined by an XML schema. The following procedures show how to perform these operations.

The XML Schema Definition tool (Xsd.exe) usually can be found in the following path:\
_C:\\Program Files (x86)\\Microsoft SDKs\\Windows\\{version}\\bin\\NETFX {version} Tools\\_

### To generate classes that conform to a specific schema  
  
1. Open a command prompt.  
  
2. Pass the XML Schema as an argument to the XML Schema Definition tool, which creates a set of classes that are precisely matched to the XML Schema, for example:  
  
    ```console  
    xsd mySchema.xsd  
    ```  
  
     The tool can only process schemas that reference the World Wide Web Consortium XML specification of March 16, 2001. In other words, the XML Schema namespace must be "http://www.w3.org/2001/XMLSchema" as shown in the following example.  
  
    ```xml  
    <?xml version="1.0" encoding="utf-8"?>  
    <xs:schema attributeFormDefault="qualified" elementFormDefault="qualified" targetNamespace="" xmlns:xs="http://www.w3.org/2001/XMLSchema" />  
    ```  
  
3. Modify the classes with methods, properties, or fields, as necessary. For more information about modifying a class with attributes, see [Controlling XML Serialization Using Attributes](controlling-xml-serialization-using-attributes.md) and [Attributes That Control Encoded SOAP Serialization](attributes-that-control-encoded-soap-serialization.md).  
  
 It is often useful to examine the schema of the XML stream that is generated when instances of a class (or classes) are serialized. For example, you might publish your schema for others to use, or you might compare it to a schema with which you are trying to achieve conformity.  
  
#### To generate an XML Schema document from a set of classes  
  
1. Compile the class or classes into a DLL.  
  
2. Open a command prompt.  
  
3. Pass the DLL as an argument to Xsd.exe, for example:  
  
    ```console  
    xsd MyFile.dll  
    ```  
  
     The schema (or schemas) will be written, beginning with the name "schema0.xsd".  
  
## See also

- <xref:System.Data.DataSet>
- [The XML Schema Definition Tool and XML Serialization](the-xml-schema-definition-tool-and-xml-serialization.md)
- [Introducing XML Serialization](introducing-xml-serialization.md)
- [XML Schema Definition Tool (Xsd.exe)](xml-schema-definition-tool-xsd-exe.md)
- <xref:System.Xml.Serialization.XmlSerializer>
- [How to: Serialize an Object](how-to-serialize-an-object.md)
- [How to: Deserialize an Object](how-to-deserialize-an-object.md)
