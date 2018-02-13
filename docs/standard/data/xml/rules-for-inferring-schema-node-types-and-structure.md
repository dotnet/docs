---
title: "Rules for Inferring Schema Node Types and Structure"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d74ce896-717d-4871-8fd9-b070e2f53cb0
caps.latest.revision: 2
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Rules for Inferring Schema Node Types and Structure
This topic describes how the schema inference process translates the node types in an XML document to an XML Schema definition language (XSD) structure.  
  
## Element Inference Rules  
 This section describes the inference rules for element declarations. There are eight structures of element declarations that will be inferred:  
  
1.  Element of simple type  
  
2.  Empty element  
  
3.  Empty element with attributes  
  
4.  Element with attributes and simple content  
  
5.  Element with a sequence of child elements  
  
6.  Element with a sequence of child elements and attributes  
  
7.  Element with a sequence of choices of child elements  
  
8.  Element with a sequence of choices of child elements and attributes  
  
> [!NOTE]
>  All `complexType` declarations are inferred as anonymous types. The only global element inferred is the root element; all other elements are local.  
  
 For more information about the schema inference process, see [Inferring Schemas from XML Documents](../../../../docs/standard/data/xml/inferring-schemas-from-xml-documents.md).  
  
### Simple Typed Element  
 The following table shows the XML input to the <xref:System.Xml.Schema.XmlSchemaInference.InferSchema%2A> method, and the XML schema generated. The bolded element shows the schema inferred for the simple type element.  
  
 For more information about the schema inference process, see [Inferring Schemas from XML Documents](../../../../docs/standard/data/xml/inferring-schemas-from-xml-documents.md).  
  
|XML|Schema|  
|---------|------------|  
|`<?xml version="1.0"?>`<br /><br /> `<root>text</root>`|`<?xml version="1.0" encoding="utf-8"?>`<br /><br /> `<xs:schema attributeFormDefault="unqualified" elementFormDefault="qualified" xml`<br /><br /> `ns:xs="http://www.w3.org/2001/XMLSchema">`<br /><br /> `<xs:element name="root" type="xs:string" />`<br /><br /> `</xs:schema>`|  
  
### Empty Element  
 The following table shows the XML input to the <xref:System.Xml.Schema.XmlSchemaInference.InferSchema%2A> method, and the XML schema generated. The bolded element shows the schema inferred for the empty element.  
  
 For more information about the schema inference process, see [Inferring Schemas from XML Documents](../../../../docs/standard/data/xml/inferring-schemas-from-xml-documents.md).  
  
|XML|Schema|  
|---------|------------|  
|`<?xml version="1.0"?>`<br /><br /> `<empty/>`|`<?xml version="1.0" encoding="utf-8"?>`<br /><br /> `<xs:schema attributeFormDefault="unqualified" elementFormDefault="qualified" xml`<br /><br /> `ns:xs="http://www.w3.org/2001/XMLSchema">`<br /><br /> `<xs:element name="empty" />`<br /><br /> `</xs:schema>`|  
  
### Empty Element with Attributes  
 The following table shows the XML input to the <xref:System.Xml.Schema.XmlSchemaInference.InferSchema%2A> method, and the XML schema generated. The bolded elements show the schema inferred for the empty element with attributes.  
  
 For more information about the schema inference process, see [Inferring Schemas from XML Documents](../../../../docs/standard/data/xml/inferring-schemas-from-xml-documents.md).  
  
|XML|Schema|  
|---------|------------|  
|`<?xml version="1.0"?>`<br /><br /> `<empty attribute1="text"/>`|`<?xml version="1.0" encoding="utf-8"?>`<br /><br /> `<xs:schema attributeFormDefault="unqualified" elementFormDefault="qualified" xml`<br /><br /> `ns:xs="http://www.w3.org/2001/XMLSchema">`<br /><br /> `<xs:element name="empty">`<br /><br /> `<xs:complexType>`<br /><br /> `<xs:attribute name="attribute1" type="xs:string" use="required" />`<br /><br /> `</xs:complexType>`<br /><br /> `</xs:element>`<br /><br /> `</xs:schema>`|  
  
### Element with Attributes and Simple Content  
 The following table shows the XML input to the <xref:System.Xml.Schema.XmlSchemaInference.InferSchema%2A> method, and the XML schema generated. The bolded elements show the schema inferred for an element with attributes and simple content.  
  
 For more information about the schema inference process, see [Inferring Schemas from XML Documents](../../../../docs/standard/data/xml/inferring-schemas-from-xml-documents.md).  
  
|XML|Schema|  
|---------|------------|  
|`<?xml version="1.0"?>`<br /><br /> `<root attribute1="text">value</root>`|`<?xml version="1.0" encoding="utf-8"?>`<br /><br /> `<xs:schema attributeFormDefault="unqualified" elementFormDefault="qualified" xml`<br /><br /> `ns:xs="http://www.w3.org/2001/XMLSchema">`<br /><br /> `<xs:element name="root">`<br /><br /> `<xs:complexType>`<br /><br /> `<xs:simpleContent>`<br /><br /> `<xs:extension base="xs:string">`<br /><br /> `<xs:attribute name="attribute1" type="xs:string" use="required" />`<br /><br /> `</xs:extension>`<br /><br /> `</xs:simpleContent>`<br /><br /> `</xs:complexType>`<br /><br /> `</xs:element>`<br /><br /> `</xs:schema>`|  
  
### Element with a Sequence of Child Elements  
 The following table shows the XML input to the <xref:System.Xml.Schema.XmlSchemaInference.InferSchema%2A> method, and the XML schema generated. The bolded elements show the schema inferred for an element with a sequence of child elements.  
  
> [!NOTE]
>  Even if an element has only one child element, it is still treated as a sequence.  
  
 For more information about the schema inference process, see [Inferring Schemas from XML Documents](../../../../docs/standard/data/xml/inferring-schemas-from-xml-documents.md).  
  
|XML|Schema|  
|---------|------------|  
|`<?xml version="1.0"?>`<br /><br /> `<root>`<br /><br /> `<subElement/>`<br /><br /> `</root>`|`<?xml version="1.0" encoding="utf-8"?>`<br /><br /> `<xs:schema attributeFormDefault="unqualified" elementFormDefault="qualified" xml`<br /><br /> `ns:xs="http://www.w3.org/2001/XMLSchema">`<br /><br /> `<xs:element name="root">`<br /><br /> `<xs:complexType>`<br /><br /> `<xs:sequence>`<br /><br /> `<xs:element name="subElement" />`<br /><br /> `</xs:sequence>`<br /><br /> `</xs:complexType>`<br /><br /> `</xs:element>`<br /><br /> `</xs:schema>`|  
  
### Element with a Sequence of Child Elements and Attributes  
 The following table shows the XML input to the <xref:System.Xml.Schema.XmlSchemaInference.InferSchema%2A> method, and the XML schema generated. The bolded elements show the schema inferred for an element with a sequence of child elements and attributes.  
  
> [!NOTE]
>  Even if an element has only one child element, it is still treated as a sequence.  
  
 For more information about the schema inference process, see [Inferring Schemas from XML Documents](../../../../docs/standard/data/xml/inferring-schemas-from-xml-documents.md).  
  
|XML|Schema|  
|---------|------------|  
|`<?xml version="1.0"?>`<br /><br /> `<root attribute1="text">`<br /><br /> `<subElement1/>`<br /><br /> `<subElement2/>`<br /><br /> `</root>`|`<?xml version="1.0" encoding="utf-8"?>`<br /><br /> `<xs:schema attributeFormDefault="unqualified" elementFormDefault="qualified" xml`<br /><br /> `ns:xs="http://www.w3.org/2001/XMLSchema">`<br /><br /> `<xs:element name="root">`<br /><br /> `<xs:complexType>`<br /><br /> `<xs:sequence>`<br /><br /> `<xs:element name="subElement1" />`<br /><br /> `<xs:element name="subElement2" />`<br /><br /> `</xs:sequence>`<br /><br /> `<xs:attribute name="attribute1" type="xs:string" use="required" />`<br /><br /> `</xs:complexType>`<br /><br /> `</xs:element>`<br /><br /> `</xs:schema>`|  
  
### Element with a Sequence and Choices of Child Elements  
 The following table shows the XML input to the <xref:System.Xml.Schema.XmlSchemaInference.InferSchema%2A> method, and the XML schema generated. The bolded elements show the schema inferred for an element with a sequence and choice of child elements.  
  
> [!NOTE]
>  The `maxOccurs` attribute of the `xs:choice` element is set to `"unbounded"` in the inferred schema.  
  
 For more information about the schema inference process, see [Inferring Schemas from XML Documents](../../../../docs/standard/data/xml/inferring-schemas-from-xml-documents.md).  
  
|XML|Schema|  
|---------|------------|  
|`<?xml version="1.0"?>`<br /><br /> `<root>`<br /><br /> `<subElement1/>`<br /><br /> `<subElement2/>`<br /><br /> `<subElement1/>`<br /><br /> `</root>`|`<?xml version="1.0" encoding="utf-8"?>`<br /><br /> `<xs:schema attributeFormDefault="unqualified" elementFormDefault="qualified" xml`<br /><br /> `ns:xs="http://www.w3.org/2001/XMLSchema">`<br /><br /> `<xs:element name="root">`<br /><br /> `<xs:complexType>`<br /><br /> `<xs:sequence>`<br /><br /> `<xs:choice maxOccurs="unbounded">`<br /><br /> `<xs:element name="subElement1" />`<br /><br /> `<xs:element name="subElement2" />`<br /><br /> `</xs:choice>`<br /><br /> `</xs:sequence>`<br /><br /> `</xs:complexType>`<br /><br /> `</xs:element>`<br /><br /> `</xs:schema>`|  
  
### Element with a Sequence and Choice of Child Elements and Attributes  
 The following table shows the XML input to the <xref:System.Xml.Schema.XmlSchemaInference.InferSchema%2A> method, and the XML schema generated. The bolded elements show the schema inferred for an element with a sequence and choice of child elements and attributes.  
  
> [!NOTE]
>  The `maxOccurs` attribute of the `xs:choice` element is set to `"unbounded"` in the inferred schema.  
  
 For more information about the schema inference process, see [Inferring Schemas from XML Documents](../../../../docs/standard/data/xml/inferring-schemas-from-xml-documents.md).  
  
|XML|Schema|  
|---------|------------|  
|`<?xml version="1.0"?>`<br /><br /> `<root attribute1="text">`<br /><br /> `<subElement1/>`<br /><br /> `<subElement2/>`<br /><br /> `<subElement1/>`<br /><br /> `</root>`|`<?xml version="1.0" encoding="utf-8"?>`<br /><br /> `<xs:schema attributeFormDefault="unqualified" elementFormDefault="qualified" xml`<br /><br /> `ns:xs="http://www.w3.org/2001/XMLSchema">`<br /><br /> `<xs:element name="root">`<br /><br /> `<xs:complexType>`<br /><br /> `<xs:sequence>`<br /><br /> `<xs:choice maxOccurs="unbounded">`<br /><br /> `<xs:element name="subElement1" />`<br /><br /> `<xs:element name="subElement2" />`<br /><br /> `</xs:choice>`<br /><br /> `</xs:sequence>`<br /><br /> `<xs:attribute name="attribute1" type="xs:string" use="required" />`<br /><br /> `</xs:complexType>`<br /><br /> `</xs:element>`<br /><br /> `</xs:schema>`|  
  
### Attribute Processing  
 Whenever a new attribute is encountered within a node, it is added to the inferred definition of the node with `use="required"`. The next time the same node is found in the instance, the inference process will compare attributes of the current instance with the ones already inferred. If some of the already inferred ones are missing in the instance, `use="optional"` is added to the attribute definition. New attributes are added to existing declarations with `use="optional"`.  
  
### Occurrence Constraints  
 During the schema inference process, the `minOccurs` and `maxOccurs` attributes are generated, for inferred components of a schema, with the values `"0"` or `"1"` and `"1"` or `"unbounded"`. The values `"1"` and `"unbounded"` are used only when the values `"0"` and `"1"` cannot validate the XML document (for example, if `MinOccurs="0"` does not accurately describe an element, `minOccurs="1"` is used).  
  
### Mixed Content  
 If an element contains mixed content (for example text interspersed with elements), the `mixed="true"` attribute is generated for the inferred complex type definition.  
  
## Other Node Type Inference Rules  
 The following table describes the inference rules for processing instruction, comment, entity reference, CDATA, document type, and namespace nodes.  
  
|Node Type|Translation|  
|---------------|-----------------|  
|Processing instruction|Ignored.|  
|Comment|Ignored.|  
|Entity reference|The <xref:System.Xml.Schema.XmlSchemaInference> class does not handle entity references. If an XML document contains entity references, you need to use a reader that expands the entities. For example, you can pass an <xref:System.Xml.XmlTextReader> with the <xref:System.Xml.XmlTextReader.EntityHandling%2A> property set to <xref:System.Xml.EntityHandling.ExpandEntities> as a parameter. If entity references are encountered and the reader does not expand entities, an exception is throw.|  
|CDATA|Any `<![CDATA[ … ]]` sections in an XML document will be inferred as `xs:string`.|  
|Document type|Ignored.|  
|Namespaces|Ignored.|  
  
 For more information about the schema inference process, see [Inferring Schemas from XML Documents](../../../../docs/standard/data/xml/inferring-schemas-from-xml-documents.md).  
  
## See Also  
 <xref:System.Xml.Schema.XmlSchemaInference>  
 [XML Schema Object Model (SOM)](../../../../docs/standard/data/xml/xml-schema-object-model-som.md)  
 [Inferring an XML Schema](../../../../docs/standard/data/xml/inferring-an-xml-schema.md)  
 [Inferring Schemas from XML Documents](../../../../docs/standard/data/xml/inferring-schemas-from-xml-documents.md)  
 [Rules for Inferring Simple Types](../../../../docs/standard/data/xml/rules-for-inferring-simple-types.md)
