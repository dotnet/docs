---
title: "Visual Basic Naming Conventions"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "names [Visual Basic], Visual Basic rules"
  - "naming conventions"
  - "naming conventions [Visual Basic], Visual Basic"
  - "Visual Basic code, naming conventions"
  - "conventions [Visual Basic], Visual Basic coding"
  - "names [Visual Basic], naming conventions"
  - "naming conventions [Visual Basic], classes"
ms.assetid: 164949a4-2a7c-4736-9d82-9c3078e2e56c
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
---
# Visual Basic Naming Conventions
When you name an element in your Visual Basic application, the first character of that name must be an alphabetic character or an underscore. Note, however, that names beginning with an underscore are not compliant with the [Language Independence and Language-Independent Components](../../../standard/language-independence-and-language-independent-components.md) (CLS).  
  
 The following suggestions apply to naming.  
  
-   Begin each separate word in a name with a capital letter, as in `FindLastRecord` and `RedrawMyForm`.  
  
-   Begin function and method names with a verb, as in `InitNameArray` or `CloseDialog`.  
  
-   Begin class, structure, module, and property names with a noun, as in `EmployeeName` or `CarAccessory`.  
  
-   Begin interface names with the prefix "I", followed by a noun or a noun phrase, like `IComponent`, or with an adjective describing the interface's behavior, like `IPersistable`. Do not use the underscore, and use abbreviations sparingly, because abbreviations can cause confusion.  
  
-   Begin event handler names with a noun describing the type of event followed by the "`EventHandler`" suffix, as in "`MouseEventHandler`".  
  
-   In names of event argument classes, include the "`EventArgs`" suffix.  
  
-   If an event has a concept of "before" or "after," use a suffix in present or past tense, as in "`ControlAdd`" or "`ControlAdded`".  
  
-   For long or frequently used terms, use abbreviations to keep name lengths reasonable, for example, "HTML", instead of "Hypertext Markup Language". In general, variable names greater than 32 characters are difficult to read on a monitor set to a low resolution. Also, make sure your abbreviations are consistent throughout the entire application. Randomly switching in a project between "HTML" and "Hypertext Markup Language" can lead to confusion.  
  
-   Avoid using names in an inner scope that are the same as names in an outer scope. Errors can result if the wrong variable is accessed. If a conflict occurs between a variable and the keyword of the same name, you must identify the keyword by preceding it with the appropriate type library. For example, if you have a variable called `Date`, you can use the intrinsic `Date` function only by calling <xref:System.DateTime.Date%2A?displayProperty=nameWithType>.  
  
## See Also  
 [Keywords as Element Names in Code](../../../visual-basic/programming-guide/program-structure/keywords-as-element-names-in-code.md)  
 [Me, My, MyBase, and MyClass](../../../visual-basic/programming-guide/program-structure/me-my-mybase-and-myclass.md)  
 [Declared Element Names](../../../visual-basic/programming-guide/language-features/declared-elements/declared-element-names.md)  
 [Program Structure and Code Conventions](../../../visual-basic/programming-guide/program-structure/program-structure-and-code-conventions.md)  
 [Visual Basic Language Reference](../../../visual-basic/language-reference/index.md)
