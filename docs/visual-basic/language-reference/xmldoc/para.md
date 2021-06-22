---
description: "Learn more about: <para> (Visual Basic)"
title: "<para>"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "<para> XML tag"
  - "para XML tag"
ms.assetid: a3a18b6c-6416-4358-94ec-37b22675fd37
---
# \<para> (Visual Basic)

Specifies that the content is formatted as a paragraph.  
  
## Syntax  
  
```xml  
<para>content</para>  
```  
  
## Parameters  

 `content`  
 The text of the paragraph.  
  
## Remarks  

 The `<para>` tag is for use inside a tag, such as [\<summary>](summary.md), [\<remarks>](remarks.md), or [\<returns>](returns.md), and lets you add structure to the text.  
  
 Compile with [-doc](../../reference/command-line-compiler/doc.md) to process documentation comments to a file.  
  
## Example  

 This example uses the `<para>` tag to split the remarks section for the `UpdateRecord` method into two paragraphs.  
  
 [!code-vb[VbVbcnXmlDocComments#6](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnXmlDocComments/VB/Class1.vb#6)]  
  
## See also

- [XML Comment Tags](index.md)
