---
title: "&lt;para&gt; (Visual Basic)"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "<para> XML tag"
  - "para XML tag"
ms.assetid: a3a18b6c-6416-4358-94ec-37b22675fd37
---
# &lt;para&gt; (Visual Basic)
Specifies that the content is formatted as a paragraph.  
  
## Syntax  
  
```xml  
<para>content</para>  
```  
  
#### Parameters  
 `content`  
 The text of the paragraph.  
  
## Remarks  
 The `<para>` tag is for use inside a tag, such as [\<summary>](../../../visual-basic/language-reference/xmldoc/summary.md), [\<remarks>](../../../visual-basic/language-reference/xmldoc/remarks.md), or [\<returns>](../../../visual-basic/language-reference/xmldoc/returns.md), and lets you add structure to the text.  
  
 Compile with [/doc](../../../visual-basic/reference/command-line-compiler/doc.md) to process documentation comments to a file.  
  
## Example  
 This example uses the `<para>` tag to split the remarks section for the `UpdateRecord` method into two paragraphs.  
  
 [!code-vb[VbVbcnXmlDocComments#6](../../../visual-basic/language-reference/xmldoc/codesnippet/VisualBasic/para_1.vb)]  
  
## See also
 [XML Comment Tags](../../../visual-basic/language-reference/xmldoc/index.md)
