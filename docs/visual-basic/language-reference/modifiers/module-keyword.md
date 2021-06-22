---
description: "Learn more about: Module <keyword> (Visual Basic)"
title: "Module <keyword>"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.ModuleAttribute"
helpviewer_keywords: 
  - "Module keyword [Visual Basic]"
  - "Module modifier"
  - "attribute blocks, Module keyword"
ms.assetid: d971b940-05ab-4d56-8485-e3b8a661906b
---
# Module \<keyword> (Visual Basic)

Specifies that an attribute at the beginning of a source file applies to the current assembly module.  
  
## Remarks  

 Many attributes pertain to an individual programming element, such as a class or property. You apply such an attribute by attaching the attribute block, within angle brackets (`< >`), directly to the declaration statement.  
  
 If an attribute pertains not only to the following element but to the current assembly module, you place the attribute block at the beginning of the source file and identify the attribute with the `Module` keyword. If it applies to the entire assembly, you use the [Assembly](assembly.md) keyword.  
  
 The `Module` modifier is not the same as the [Module Statement](../statements/module-statement.md).  
  
## See also

- [Assembly](assembly.md)
- [Module Statement](../statements/module-statement.md)
- [Attributes overview](../../programming-guide/concepts/attributes/index.md)
