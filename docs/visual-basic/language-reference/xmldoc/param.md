---
title: "<param> (Visual Basic)"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "param XML tag"
  - "<param> XML tag"
ms.assetid: 4e32e86f-f6f3-4301-b7fc-2f321fb54368
---
# \<param> (Visual Basic)
Defines a parameter name and description.  
  
## Syntax  
  
```xml  
<param name="name">description</param>  
```  
  
## Parameters  
 `name`  
 The name of a method parameter. Enclose the name in double quotation marks (" ").  
  
 `description`  
 A description for the parameter.  
  
## Remarks  
 The `<param>` tag should be used in the comment for a method declaration to describe one of the parameters for the method.  
  
 The text for the `<param>` tag will appear in the following locations:  
  
- Parameter Info of IntelliSense. For more information, see [Using IntelliSense](/visualstudio/ide/using-intellisense).  
  
- Object Browser. For more information, see [Viewing the Structure of Code](/visualstudio/ide/viewing-the-structure-of-code).  
  
 Compile with [/doc](../../../visual-basic/reference/command-line-compiler/doc.md) to process documentation comments to a file.  
  
## Example  
 This example uses the `<param>` tag to describe the `id` parameter.  
  
 [!code-vb[VbVbcnXmlDocComments#6](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnXmlDocComments/VB/Class1.vb#6)]  
  
## See also

- [XML Comment Tags](../../../visual-basic/language-reference/xmldoc/index.md)
