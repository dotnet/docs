---
description: "Learn more about: How to: Hide an Inherited Variable (Visual Basic)"
title: "How to: Hide an Inherited Variable"
ms.date: 07/20/2015
helpviewer_keywords:
  - "qualification [Visual Basic], of element names"
  - "element names [Visual Basic], qualification"
  - "references [Visual Basic], declared elements"
  - "declaration statements [Visual Basic], declared elements"
  - "referencing declared elements [Visual Basic]"
  - "declared elements [Visual Basic], referencing"
  - "declared elements [Visual Basic], about declared elements"
  - "variables [Visual Basic], hiding inherited"
ms.assetid: 765728d9-7351-4a30-999d-b5f34f024412
---
# How to: Hide an Inherited Variable (Visual Basic)

A derived class inherits all the definitions of its base class. If you want to define a variable using the same name as an element of the base class, you can hide, or *shadow*, that base class element when you define your variable in the derived class. If you do this, code in the derived class accesses your variable unless it explicitly bypasses the shadowing mechanism.

Another reason you might want to hide an inherited variable is to protect against base class revision. The base class might undergo a change that alters the element you are inheriting. If this happens, the `Shadows` modifier forces references from the derived class to be resolved to your variable, instead of to the base class element.

## To hide an inherited variable

1. Be sure the variable you want to hide is declared at class level (outside any procedure). Otherwise, you do not need to hide it.
  
2. Inside your derived class, write a [Dim Statement](../../../language-reference/statements/dim-statement.md) declaring your variable. Use the same name as that of the inherited variable.

3. Include the [Shadows](../../../language-reference/modifiers/shadows.md) keyword in the declaration.

     When code in the derived class refers to the variable name, the compiler resolves the reference to your variable.

     The following example illustrates shadowing of an inherited variable:
  
    ```vb  
    Public Class ShadowBaseClass  
        Public shadowString As String = "This is the base class string."  
    End Class  
    Public Class ShadowDerivedClass  
        Inherits ShadowBaseClass  
        Public Shadows shadowString As String = "This is the derived class string."  
        Public Sub ShowStrings()  
            Dim s As String = $"Unqualified shadowString: {shadowString}{vbCrLf}MyBase.shadowString: {MyBase.shadowString}"
            MsgBox(s)  
        End Sub  
    End Class  
    ```  
  
     The preceding example declares the variable `shadowString` in the base class and shadows it in the derived class. The procedure `ShowStrings` in the derived class displays the shadowing version of the string when the name `shadowString` is not qualified. It then displays the shadowed version when `shadowString` is qualified with the `MyBase` keyword.  
  
## Robust programming

Shadowing introduces more than one version of a variable with the same name. When a code statement refers to the variable name, the version to which the compiler resolves the reference depends on factors such as the location of the code statement and the presence of a qualifying string. This can increase the risk of referring to an unintended version of a shadowed variable. You can lower that risk by fully qualifying all references to a shadowed variable.

## See also

- [References to Declared Elements](references-to-declared-elements.md)
- [Shadowing in Visual Basic](shadowing.md)
- [Differences Between Shadowing and Overriding](differences-between-shadowing-and-overriding.md)
- [How to: Hide a Variable with the Same Name as Your Variable](how-to-hide-a-variable-with-the-same-name-as-your-variable.md)
- [How to: Access a Variable Hidden by a Derived Class](how-to-access-a-variable-hidden-by-a-derived-class.md)
- [Overrides](../../../language-reference/modifiers/overrides.md)
- [Me, My, MyBase, and MyClass](../../program-structure/me-my-mybase-and-myclass.md)
- [Inheritance Basics](../objects-and-classes/inheritance-basics.md)
