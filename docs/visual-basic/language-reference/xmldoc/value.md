---
description: "Learn more about: <value> (Visual Basic)"
title: "<value>"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "<value> XML tag"
  - "value XML tag"
ms.assetid: 0b84b02e-9e6d-41b5-a926-0d5dc76dacb5
---
# \<value> (Visual Basic)

Specifies the description of a property.  
  
## Syntax  
  
```xml  
<value>property-description</value>  
```  
  
## Parameters  

 `property-description`  
 A description for the property.  
  
## Remarks  

 Use the `<value>` tag to describe a property. Note that when you add a property using the code wizard in the Visual Studio development environment, it will add a [\<summary>](summary.md) tag for the new property. You should then manually add a `<value>` tag to describe the value that the property represents.  
  
 Compile with [-doc](../../reference/command-line-compiler/doc.md) to process documentation comments to a file.  
  
## Example  

 This example uses the `<value>` tag to describe what value the `Counter` property holds.  
  
 [!code-vb[VbVbcnXmlDocComments#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnXmlDocComments/VB/Class1.vb#1)]  
  
## See also

- [XML Comment Tags](index.md)
