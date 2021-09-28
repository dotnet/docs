---
description: "Learn more about: XML Document Literal (Visual Basic)"
title: "XML Document Literal"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.XmlLiteralDocument"
helpviewer_keywords: 
  - "XML document literal [Visual Basic]"
  - "XML literals [Visual Basic], document"
  - "XML documents [Visual Basic], creating"
  - "document literal [Visual Basic]"
ms.assetid: f7bbee56-0911-41de-b907-96f20450137b
---
# XML Document Literal (Visual Basic)

A literal representing an <xref:System.Xml.Linq.XDocument> object.  
  
## Syntax  
  
```xml  
<?xml version="1.0" [encoding="encoding"] [standalone="standalone"] ?>  
[ piCommentList ]  
rootElement  
[ piCommentList ]  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`encoding`|Optional. Literal text declaring which encoding the document uses.|  
|`standalone`|Optional. Literal text. Must be "yes" or "no".|  
|`piCommentList`|Optional. List of XML processing instructions and XML comments. Takes the following format:<br /><br /> `piComment [` `piComment` `... ]`<br /><br /> Each `piComment` can be one of the following:<br /><br /> -   [XML Processing Instruction Literal](xml-processing-instruction-literal.md).<br />-   [XML Comment Literal](xml-comment-literal.md).|  
|`rootElement`|Required. Root element of the document. The format is one of the following:<br /><br /> <ul><li>[XML Element Literal](xml-element-literal.md).</li><li>Embedded expression of the form `<%=` `elementExp` `%>`. The `elementExp` returns one of the following:<br /><br /> <ul><li>An <xref:System.Xml.Linq.XElement> object.</li><li>A collection that contains one <xref:System.Xml.Linq.XElement> object and any number of <xref:System.Xml.Linq.XProcessingInstruction> and <xref:System.Xml.Linq.XComment> objects.</li></ul></li></ul><br /> For more information, see [Embedded Expressions in XML](../../programming-guide/language-features/xml/embedded-expressions-in-xml.md).|  
  
## Return Value  

 An <xref:System.Xml.Linq.XDocument> object.  
  
## Remarks  

 An XML document literal is identified by the XML declaration at the start of the literal. Although each XML document literal must have exactly one root XML element, it can have any number of XML processing instructions and XML comments.  
  
 An XML document literal cannot appear in an XML element.  
  
> [!NOTE]
> An XML literal can span multiple lines without using line continuation characters. This enables you to copy content from an XML document and paste it directly into a Visual Basic program.  
  
 The Visual Basic compiler converts the XML document literal into calls to the <xref:System.Xml.Linq.XDocument.%23ctor%2A> and <xref:System.Xml.Linq.XDeclaration.%23ctor%2A> constructors.  
  
## Example  

 The following example creates an XML document that has an XML declaration, a processing instruction, a comment, and an element that contains another element.  
  
 [!code-vb[VbXMLSamples#30](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbXMLSamples/VB/XMLSamples13.vb#30)]  
  
## See also

- <xref:System.Xml.Linq.XElement>
- <xref:System.Xml.Linq.XProcessingInstruction>
- <xref:System.Xml.Linq.XComment>
- <xref:System.Xml.Linq.XDocument>
- [XML Processing Instruction Literal](xml-processing-instruction-literal.md)
- [XML Comment Literal](xml-comment-literal.md)
- [XML Element Literal](xml-element-literal.md)
- [XML Literals](index.md)
- [Creating XML in Visual Basic](../../programming-guide/language-features/xml/creating-xml.md)
- [Embedded Expressions in XML](../../programming-guide/language-features/xml/embedded-expressions-in-xml.md)
