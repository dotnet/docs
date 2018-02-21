---
title: "XML Processing Instruction Literal (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.XmlLiteralProcessingInstruction"
helpviewer_keywords: 
  - "XML literals [Visual Basic], processing instruction"
  - "XML processing instruction literal [Visual Basic]"
  - "processing instruction literal [Visual Basic]"
ms.assetid: cef4f7f8-0011-4f64-8602-795077ad4f15
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
---
# XML Processing Instruction Literal (Visual Basic)
A literal representing an <xref:System.Xml.Linq.XProcessingInstruction> object.  
  
## Syntax  
  
```xml  
<?piName [ = piData ] ?>  
```  
  
## Parts  
 `<?`  
 Required. Denotes the start of the XML processing instruction literal.  
  
 `piName`  
 Required. Name indicating which application the processing instruction targets. Cannot begin with "xml" or "XML".  
  
 `piData`  
 Optional. String indicating how the application targeted by `piName` should process the XML document.  
  
 `?>`  
 Required. Denotes the end of the processing instruction.  
  
## Return Value  
 An <xref:System.Xml.Linq.XProcessingInstruction> object.  
  
## Remarks  
 XML processing instruction literals indicate how applications should process an XML document. When an application loads an XML document, the application can check the XML processing instructions to determine how to process the document. The application interprets the meaning of `piName` and `piData`.  
  
 The XML document literal uses syntax that is similar to that of the XML processing instruction. For more information, see [XML Document Literal](../../../visual-basic/language-reference/xml-literals/xml-document-literal.md).  
  
> [!NOTE]
>  The `piName` element cannot begin with the strings "xml" or "XML", because the XML 1.0 specification reserves those identifiers.  
  
 You can assign an XML processing instruction literal to a variable or include it in an XML document literal.  
  
> [!NOTE]
>  An XML literal can span multiple lines without needing line continuation characters. This enables you to copy content from an XML document and paste it directly into a [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] program.  
  
 The [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] compiler converts the XML processing instruction literal to a call to the <xref:System.Xml.Linq.XProcessingInstruction.%23ctor%2A> constructor.  
  
## Example  
 The following example creates a processing instruction identifying a style-sheet for an XML document.  
  
 [!code-vb[VbXMLSamples#28](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/xml-processing-instruction-literal_1.vb)]  
  
## See Also  
 <xref:System.Xml.Linq.XProcessingInstruction>  
 [XML Document Literal](../../../visual-basic/language-reference/xml-literals/xml-document-literal.md)  
 [XML Literals](../../../visual-basic/language-reference/xml-literals/index.md)  
 [Creating XML in Visual Basic](../../../visual-basic/programming-guide/language-features/xml/creating-xml.md)
