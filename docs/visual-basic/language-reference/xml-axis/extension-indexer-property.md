---
description: "Learn more about: Extension Indexer Property (Visual Basic)"
title: "Extension Indexer Property"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.XmlPropertyExtensionIndexer"
helpviewer_keywords: 
  - "Visual Basic code, accessing XML"
  - "XML extension indexer [Visual Basic]"
  - "extension indexer [Visual Basic]"
  - "XML [Visual Basic], accessing"
ms.assetid: a16a4b13-54be-432c-82b3-a87091464ada
---
# Extension Indexer Property (Visual Basic)

Provides access to individual elements in a collection.  
  
## Syntax  
  
```vb  
object(index)  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`object`|Required. A queryable collection. That is, a collection that implements <xref:System.Collections.Generic.IEnumerable%601> or <xref:System.Linq.IQueryable%601>.|  
|(|Required. Denotes the start of the indexer property.|  
|`index`|Required. An integer expression that specifies the zero-based position of an element of the collection.|  
|)|Required. Denotes the end of the indexer property.|  
  
## Return Value  

 The object from the specified location in the collection, or `Nothing` if the index is out of range.  
  
## Remarks  

 You can use the extension indexer property to access individual elements in a collection. This indexer property is typically used on the output of XML axis properties. The XML child and XML descendent axis properties return collections of <xref:System.Xml.Linq.XElement> objects or an attribute value.  
  
 The Visual Basic compiler converts extension indexer properties to calls to the `ElementAtOrDefault` method. Unlike an array indexer, the `ElementAtOrDefault` method returns `Nothing` if the index is out of range. This behavior is useful when you cannot easily determine the number of elements in a collection.  
  
 This indexer property is like an extension property for collections that implement <xref:System.Collections.Generic.IEnumerable%601> or <xref:System.Linq.IQueryable%601>: it is used only if the collection does not have an indexer or a default property.  
  
 To access the value of the first element in a collection of <xref:System.Xml.Linq.XElement> or <xref:System.Xml.Linq.XAttribute> objects, you can use the XML `Value` property. For more information, see [XML Value Property](xml-value-property.md).  
  
## Example  

 The following example shows how to use the extension indexer to access the second child node in a collection of <xref:System.Xml.Linq.XElement> objects. The collection is accessed by using the child axis property, which gets all child elements named `phone` in the `contact` object.  
  
 [!code-vb[VbXMLSamples#24](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbXMLSamples/VB/XMLSamples11.vb#24)]  
  
 This code displays the following text:  
  
 `Second phone number: 425-555-0145`  
  
## See also

- <xref:System.Xml.Linq.XElement>
- [XML Axis Properties](index.md)
- [XML Literals](../xml-literals/index.md)
- [Creating XML in Visual Basic](../../programming-guide/language-features/xml/creating-xml.md)
- [XML Value Property](xml-value-property.md)
