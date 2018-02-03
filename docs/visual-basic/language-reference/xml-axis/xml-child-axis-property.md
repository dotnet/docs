---
title: "XML Child Axis Property (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.XmlPropertyChildAxis"
helpviewer_keywords: 
  - "Visual Basic code, accessing XML"
  - "XML axis [Visual Basic], child"
  - "child axis property [Visual Basic]"
  - "XML child axis property [Visual Basic]"
  - "XML [Visual Basic], accessing"
ms.assetid: 89a59d00-985e-4f5c-b59f-29b47bad11cb
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
---
# XML Child Axis Property (Visual Basic)
Provides access to the children of one of the following: an <xref:System.Xml.Linq.XElement> object, an <xref:System.Xml.Linq.XDocument> object, a collection of <xref:System.Xml.Linq.XElement> objects, or a collection of <xref:System.Xml.Linq.XDocument> objects.  
  
## Syntax  
  
```  
object.<child>  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`object`|Required. An <xref:System.Xml.Linq.XElement> object, an <xref:System.Xml.Linq.XDocument> object, a collection of <xref:System.Xml.Linq.XElement> objects, or a collection of <xref:System.Xml.Linq.XDocument> objects.|  
|.<|Required. Denotes the start of a child axis property.|  
|`child`|Required. Name of the child nodes to access, of the form [`prefix``:`]`name`.<br /><br /> -   `Prefix` - Optional. XML namespace prefix for the child node. Must be a global XML namespace defined with an `Imports` statement.<br />-   `Name` - Required. Local child node name. See [Names of Declared XML Elements and Attributes](../../../visual-basic/programming-guide/language-features/xml/names-of-declared-xml-elements-and-attributes.md).|  
|>|Required. Denotes the end of a child axis property.|  
  
## Return Value  
 A collection of <xref:System.Xml.Linq.XElement> objects.  
  
## Remarks  
 You can use an XML child axis property to access child nodes by name from an <xref:System.Xml.Linq.XElement> or <xref:System.Xml.Linq.XDocument> object, or from a collection of <xref:System.Xml.Linq.XElement> or <xref:System.Xml.Linq.XDocument> objects. Use the XML `Value` property to access the value of the first child node in the returned collection. For more information, see [XML Value Property](../../../visual-basic/language-reference/xml-axis/xml-value-property.md).  
  
 The [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] compiler converts child axis properties to calls to the <xref:System.Xml.Linq.XContainer.Elements%2A> method.  
  
## XML Namespaces  
 The name in a child axis property can use only XML namespace prefixes declared globally with the `Imports` statement. It cannot use XML namespace prefixes declared locally within XML element literals. For more information, see [Imports Statement (XML Namespace)](../../../visual-basic/language-reference/statements/imports-statement-xml-namespace.md).  
  
## Example  
 The following example shows how to access the child nodes named `phone` from the `contact` object.  
  
 [!code-vb[VbXMLSamples#17](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/xml-child-axis-property_1.vb)]  
  
 This code displays the following text:  
  
 `Home Phone = 206-555-0144`  
  
## Example  
 The following example shows how to access the child nodes named `phone` from the collection returned by the `contact` child axis property of the `contacts` object.  
  
 [!code-vb[VbXMLSamples#18](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/xml-child-axis-property_2.vb)]  
  
 This code displays the following text:  
  
 `Home Phone = 206-555-0144`  
  
## Example  
 The following example declares `ns` as an XML namespace prefix. It then uses the prefix of the namespace to create an XML literal and access the first child node with the qualified name `ns:name`.  
  
 [!code-vb[VbXMLSamples#19](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/xml-child-axis-property_3.vb)]  
  
 This code displays the following text:  
  
 `Patrick Hines`  
  
## See Also  
 <xref:System.Xml.Linq.XElement>  
 [XML Axis Properties](../../../visual-basic/language-reference/xml-axis/xml-axis-properties.md)  
 [XML Literals](../../../visual-basic/language-reference/xml-literals/index.md)  
 [Creating XML in Visual Basic](../../../visual-basic/programming-guide/language-features/xml/creating-xml.md)  
 [Names of Declared XML Elements and Attributes](../../../visual-basic/programming-guide/language-features/xml/names-of-declared-xml-elements-and-attributes.md)
