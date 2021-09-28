---
description: "Learn more about: <list> (Visual Basic)"
title: "<list>"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "listheader XML tag"
  - "<item> XML tag"
  - "<list> XML tag"
  - "<listheader> XML tag"
  - "term XML tag"
  - "list XML tag"
  - "<description> XML tag"
  - "description XML tag"
  - "item XML tag"
  - "<term> XML tag"
ms.assetid: ec35fced-d58e-4520-a764-0691256e014b
---
# \<list> (Visual Basic)

Defines a list or table.  
  
## Syntax  
  
```xml  
<list type="type">  
   <listheader>  
      <term>term</term>  
      <description>description</description>  
   </listheader>  
   <item>  
      <term>term</term>  
      <description>description</description>  
   </item>  
</list>  
```  
  
## Parameters  

 `type`  
 The type of the list. Must be a "bullet" for a bulleted list, "number" for a numbered list, or "table" for a two-column table.  
  
 `term`  
 Only used when `type` is "table." A term to define, which is defined in the description tag.  
  
 `description`  
 When `type` is "bullet" or "number," `description` is an item in the list When `type` is "table," `description` is the definition of `term`.  
  
## Remarks  

 The `<listheader>` block defines the heading of either a table or definition list. When defining a table, you only have to supply an entry for `term` in the heading.  
  
 Each item in the list is specified with an `<item>` block. When creating a definition list, you must specify both `term` and `description`. However, for a table, bulleted list, or numbered list, you only have to supply an entry for `description`.  
  
 A list or table can have as many `<item>` blocks as needed.  
  
 Compile with [-doc](../../reference/command-line-compiler/doc.md) to process documentation comments to a file.  
  
## Example  

 This example uses the `<list>` tag to define a bulleted list in the remarks section.  
  
 [!code-vb[VbVbcnXmlDocComments#5](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnXmlDocComments/VB/Class1.vb#5)]  
  
## See also

- [XML Comment Tags](index.md)
