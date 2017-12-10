---
title: "Declared Element Names (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "declared elements [Visual Basic], case sensitivity"
  - "names [Visual Basic], Visual Basic rules"
  - "naming conventions [Visual Basic]"
  - "element names [Visual Basic]"
  - "declared elements [Visual Basic], identifiers"
  - "declarations [Visual Basic], elements"
  - "declared elements [Visual Basic], valid names"
  - "[] escape characters [Visual Basic]"
  - "names [Visual Basic], elements"
  - "declaration statements [Visual Basic], declared elements"
  - "declaring elements [Visual Basic]"
  - "identifiers [Visual Basic], declared elements"
  - "case sensitivity, declared element names"
  - "escape characters [Visual Basic]"
  - "names [Visual Basic], declared elements"
  - "declared elements [Visual Basic], about declared elements"
  - "escaped names [Visual Basic]"
  - "declared elements [Visual Basic], names"
  - "names [Visual Basic], naming conventions"
  - "identifiers [Visual Basic], elements"
ms.assetid: 09d8843b-c0dc-4afe-9dab-87c439a69e66
caps.latest.revision: 27
author: dotnet-bot
ms.author: dotnetcontent
---
# Declared Element Names (Visual Basic)
Every declared element has a name, also called an *identifier*, which is what the code uses to refer to it.  
  
## Rules  
 An element name in [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] must observe the following rules:  
  
-   It must begin with an alphabetic character or an underscore (`_`).  
  
-   It must only contain alphabetic characters, decimal digits, and underscores.  
  
-   It must contain at least one alphabetic character or decimal digit if it begins with an underscore.  
  
-   It must not be more than 1023 characters long.  
  
 The length limit of 1023 characters also applies to the entire string of a fully qualified name, such as `outerNamespace.middleNamespace.innerNamespace.thisClass.thisElement`.  
  
 The following example shows some valid element names.  
  
 `aB123__45`  
  
 `_567`  
  
 The following example shows some invalid element names. The first contains only an underscore, the second begins with a decimal digit, and the third contains an invalid character ($).  
  
 `' Three INVALID element names`  
  
 `_`  
  
 `12ABC`  
  
 `xyz$wv`  
  
> [!CAUTION]
>  Element names starting with an underscore (`_`) are not part of the [Language Independence and Language-Independent Components](../../../../standard/language-independence-and-language-independent-components.md) (CLS), so CLS-compliant code cannot use a component that defines such names. However, an underscore in any other position in an element name is CLS-compliant.  
  
### Name Length Guidelines  
 As a practical matter, your name should be as short as possible while still clearly identifying the nature of the element. This improves the readability of your code and reduces line length and source-file size.  
  
 On the other hand, your name should not be so short that it does not adequately describe what the element represents and how your code uses it. This is important for the readability of your code. If somebody else is trying to understand it, or if you yourself are looking at it a long time after you wrote it, suitable element names can save a considerable amount of time.  
  
## Escaped Names  
 Generally, an element name must not match any of the keywords reserved by [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)], such as `Case` or `Friend`. However, you can define an *escaped name*, which is enclosed by brackets (`[ ]`). An escaped name can match any [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] keyword, since the brackets remove any ambiguity. You also use the brackets when you refer to the name later in your code.  
  
 In general, you should use escaped names only when:  
  
-   Your code has migrated from a previous version of [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] that did not reserve the keyword being used as a name; or  
  
-   You are working with code written in another language in which the given keyword is not reserved.  
  
 Otherwise, you should consider renaming the element if its name conflicts with a keyword. The integrated development environment (IDE) provides an easy way to do this. For more information, see [Refactoring](/visualstudio/vb-ide/refactoring-vb).  
  
## Case Sensitivity in Names  
 Element names in [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] are case-insensitive. This means that when the compiler compares two names that differ in alphabetic case only, it interprets them as the same name. For example, it considers `ABC` and `abc` to refer to the same declared element.  
  
 However, the common language runtime (CLR) uses case-sensitive binding. Therefore, when you produce an assembly or a DLL and make it available to other assemblies, your names are no longer case-insensitive. For example, if you define a class with an element called `ABC`, and other assemblies make use of your class through the common language runtime, they must refer to the element as `ABC`. If you subsequently recompile your class and change the element's name to `abc`, the other assemblies using your class could no longer access that element. Therefore, when you release an updated version of an assembly, you should not change the alphabetic case of any public elements.  
  
## Names and Locales  
 Comparison of names is independent of locale. If two names match in one locale, they are guaranteed to match in all locales.  
  
## See Also  
 [Declared Elements](../../../../visual-basic/programming-guide/language-features/declared-elements/index.md)  
 [Declared Element Characteristics](../../../../visual-basic/programming-guide/language-features/declared-elements/declared-element-characteristics.md)  
 [References to Declared Elements](../../../../visual-basic/programming-guide/language-features/declared-elements/references-to-declared-elements.md)  
 [Statements](../../../../visual-basic/language-reference/statements/index.md)
