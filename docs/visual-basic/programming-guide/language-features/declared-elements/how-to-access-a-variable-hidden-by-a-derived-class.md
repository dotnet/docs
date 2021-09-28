---
description: "Learn more about: How to: Access a Variable Hidden by a Derived Class (Visual Basic)"
title: "How to: Access a Variable Hidden by a Derived Class"
ms.date: 07/20/2015
helpviewer_keywords:
  - "qualification [Visual Basic], of element names"
  - "base classes [Visual Basic], accessing elements"
  - "element names [Visual Basic], qualification"
  - "references [Visual Basic], declared elements"
  - "declared elements [Visual Basic], referencing"
  - "variables [Visual Basic], accessing hidden"
ms.assetid: ae21a8ac-9cd4-4fba-a3ec-ecc4321ef93c
---
# How to: Access a Variable Hidden by a Derived Class (Visual Basic)

When code in a derived class accesses a variable, the compiler normally resolves the reference to the closest accessible version, that is, the accessible version the fewest derivational steps backward from the accessing class. If the variable is defined in the derived class, the code normally accesses that definition.

If the derived class variable shadows a variable in the base class, it hides the base class version. However, you can access the base class variable by qualifying it with the `MyBase` keyword.

### To access a base class variable hidden by a derived class

- In an expression or assignment statement, precede the variable name with the `MyBase` keyword and a period (`.`).

    The compiler resolves the reference to the base class version of the variable.

    The following example illustrates shadowing through inheritance. It makes two references, one that accesses the shadowing variable and one that bypasses the shadowing.

    ```vb
    Public Class shadowBaseClass
        Public shadowString As String = "This is the base class string."
    End Class
    Public Class shadowDerivedClass
        Inherits shadowBaseClass
        Public Shadows shadowString As String = "This is the derived class string."
        Public Sub showStrings()
            Dim s As String = "Unqualified shadowString: " & shadowString &
                vbCrLf & "MyBase.shadowString: " & MyBase.shadowString
            MsgBox(s)
        End Sub
    End Class
    ```

    The preceding example declares the variable `shadowString` in the base class and shadows it in the derived class. The procedure `showStrings` in the derived class displays the shadowing version of the string when the name `shadowString` is not qualified. It then displays the shadowed version when `shadowString` is qualified with the `MyBase`  keyword.

## Robust Programming

To lower the risk of referring to an unintended version of a shadowed variable, you can fully qualify all references to a shadowed variable. Shadowing introduces more than one version of a variable with the same name. When a code statement refers to the variable name, the version to which the compiler resolves the reference depends on factors such as the location of the code statement and the presence of a qualifying string. This can increase the risk of referring to the wrong version of the variable.

## See also

- [References to Declared Elements](references-to-declared-elements.md)
- [Shadowing in Visual Basic](shadowing.md)
- [Differences Between Shadowing and Overriding](differences-between-shadowing-and-overriding.md)
- [How to: Hide a Variable with the Same Name as Your Variable](how-to-hide-a-variable-with-the-same-name-as-your-variable.md)
- [How to: Hide an Inherited Variable](how-to-hide-an-inherited-variable.md)
- [Shadows](../../../language-reference/modifiers/shadows.md)
- [Overrides](../../../language-reference/modifiers/overrides.md)
- [Me, My, MyBase, and MyClass](../../program-structure/me-my-mybase-and-myclass.md)
- [Inheritance Basics](../objects-and-classes/inheritance-basics.md)
