---
description: "Learn more about: Visual Basic Limitations"
title: "Limitations"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "limits"
  - "limitations [Visual Basic]"
  - "limitations"
  - "limits, Visual Basic code"
  - "Visual Basic code, limitations"
ms.assetid: cf1646b7-5d24-48c6-9616-bda8a4849d91
---
# Visual Basic Limitations

Earlier versions of Visual Basic enforced boundaries in code, such as the length of variable names, the number of variables allowed in modules, and module size. In Visual Basic .NET, these restrictions have been relaxed, giving you greater freedom in writing and arranging your code.  
  
 Physical limits are dependent more on run-time memory than on compile-time considerations. If you use prudent programming practices, and divide large applications into multiple classes and modules, then there is very little chance of encountering an internal Visual Basic limitation.  
  
 The following are some limitations that you might encounter in extreme cases:  
  
- **Name Length.** There is a maximum number of characters for the name of every declared programming element. This maximum applies to an entire qualification string if the element name is qualified. See [Declared Element Names](../language-features/declared-elements/declared-element-names.md).  
  
- **Line Length.** There is a maximum of 65535 characters in a physical line of source code. The logical source code line can be longer if you use line continuation characters. See [How to: Break and Combine Statements in Code](how-to-break-and-combine-statements-in-code.md).  
  
- **Array Dimensions.** There is a maximum number of dimensions you can declare for an array. This limits how many indexes you can use to specify an array element. See [Array Dimensions in Visual Basic](../language-features/arrays/array-dimensions.md).  
  
- **String Length.** There is a maximum number of Unicode characters you can store in a single string. See [String Data Type](../../language-reference/data-types/string-data-type.md).  
  
- **Environment String Length.** There is a maximum of 32768 characters for any environment string used as a command-line argument. This is a limitation on all platforms.  
  
## See also

- [Program Structure and Code Conventions](program-structure-and-code-conventions.md)
- [Visual Basic Naming Conventions](naming-conventions.md)
