---
description: "Learn more about: Assembly (Visual Basic)"
title: "Assembly"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.Assembly"
  - "vb.AssemblyAttribute"
  - "Assembly"
helpviewer_keywords: 
  - "Assembly modifier"
  - "Assembly keyword [Visual Basic]"
  - "attribute blocks, Assembly keyword"
ms.assetid: 925e7471-3bdf-4b51-bb93-cbcfc6efc52f
---
# Assembly (Visual Basic)

Specifies that an attribute at the beginning of a source file applies to the entire assembly.  
  
## Remarks  

 Many attributes pertain to an individual programming element, such as a class or property. You apply such an attribute by attaching the attribute block, within angle brackets (`< >`), directly to the declaration statement.  
  
 If an attribute pertains not only to the following element but to the entire assembly, you place the attribute block at the beginning of the source file and identify the attribute with the `Assembly` keyword. If it applies to the current assembly module, you use the [Module](module-keyword.md) keyword.  
  
 You can also apply an attribute to an assembly in the AssemblyInfo.vb file, in which case you do not have to use an attribute block in your main source-code file.  
  
## See also

- [Module \<keyword>](module-keyword.md)
- [Attributes overview](../../programming-guide/concepts/attributes/index.md)
