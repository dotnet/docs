---
title: "XML Value Property (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.XmlPropertyExtensionValue"
helpviewer_keywords: 
  - "Value property [Visual Basic]"
  - "Visual Basic code, accessing XML"
  - "XML axis [Visual Basic], Value"
  - "XML Value property [Visual Basic]"
ms.assetid: 7ddd057a-a195-4e9b-ad8b-2ee0e615a20f
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
---
# XML Value Property (Visual Basic)
Provides access to the value of the first element of a collection of <xref:System.Xml.Linq.XElement> objects.  
  
## Syntax  
  
```  
object.Value  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`object`|Required. Collection of <xref:System.Xml.Linq.XElement> objects.|  
  
## Return Value  
 A `String` that contains the value of the first element of the collection, or `Nothing` if the collection is empty.  
  
## Remarks  
 The <xref:System.Xml.Linq.XElement.Value%2A> property makes it easy to access the value of the first element in a collection of <xref:System.Xml.Linq.XElement> objects. This property first checks whether the collection contains at least one object. If the collection is empty, this property returns `Nothing`. Otherwise, this property returns the value of the <xref:System.Xml.Linq.XElement.Value%2A> property of the first element in the collection.  
  
> [!NOTE]
>  When you access the value of an XML attribute using the '@' identifier, the attribute value is returned as a `String` and you do not need to explicitly specify the <xref:System.Xml.Linq.XAttribute.Value%2A> property.  
  
 To access other elements in a collection, you can use the XML extension indexer property. For more information, see [Extension Indexer Property](../../../visual-basic/language-reference/xml-axis/extension-indexer-property.md).  
  
## Inheritance  
 Most users will not have to implement <xref:System.Collections.Generic.IEnumerable%601>, and can therefore ignore this section.  
  
 The <xref:System.Xml.Linq.XElement.Value%2A> property is an extension property for types that implement `IEnumerable(Of XElement)`. The binding of this extension property is like the binding of extension methods: if a type implements one of the interfaces and defines a property that has the name "Value", that property has precedence over the extension property. In other words, this <xref:System.Xml.Linq.XElement.Value%2A> property can be overridden by defining a new property in a class that implements `IEnumerable(Of XElement)`.  
  
## Example  
 The following example shows how to use the <xref:System.Xml.Linq.XElement.Value%2A> property to access the first node in a collection of <xref:System.Xml.Linq.XElement> objects. The example uses the child axis property to get the collection of all child nodes named `phone` that are in the `contact` object.  
  
 [!code-vb[VbXMLSamples#15](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/xml-value-property_1.vb)]  
  
 This code displays the following text:  
  
 `Phone number: 206-555-0144`  
  
## Example  
 The following example shows how to get the value of an XML attribute from a collection of <xref:System.Xml.Linq.XAttribute> objects. The example uses the attribute axis property to display the value of the `type` attribute for all of the `phone` elements.  
  
 [!code-vb[VbXMLSamples#16](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/xml-value-property_2.vb)]  
  
 This code displays the following text:  
  
 `home`  
  
 `work`  
  
## See Also  
 <xref:System.Xml.Linq.XElement>  
 <xref:System.Collections.Generic.IEnumerable%601>  
 [XML Axis Properties](../../../visual-basic/language-reference/xml-axis/xml-axis-properties.md)  
 [XML Literals](../../../visual-basic/language-reference/xml-literals/index.md)  
 [Creating XML in Visual Basic](../../../visual-basic/programming-guide/language-features/xml/creating-xml.md)  
 [Extension Methods](../../../visual-basic/programming-guide/language-features/procedures/extension-methods.md)  
 [Extension Indexer Property](../../../visual-basic/language-reference/xml-axis/extension-indexer-property.md)  
 [XML Child Axis Property](../../../visual-basic/language-reference/xml-axis/xml-child-axis-property.md)  
 [XML Attribute Axis Property](../../../visual-basic/language-reference/xml-axis/xml-attribute-axis-property.md)
