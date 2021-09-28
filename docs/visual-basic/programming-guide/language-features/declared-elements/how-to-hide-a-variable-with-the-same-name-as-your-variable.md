---
description: "Learn more about: How to: Hide a Variable with the Same Name as Your Variable (Visual Basic)"
title: "How to: Hide a Variable with the Same Name as Your Variable"
ms.date: 07/20/2015
helpviewer_keywords:
  - "qualification [Visual Basic], of element names"
  - "declarations [Visual Basic], elements"
  - "element names [Visual Basic], qualification"
  - "references [Visual Basic], declared elements"
  - "declaration statements [Visual Basic], declared elements"
  - "declaring elements [Visual Basic]"
  - "referencing declared elements [Visual Basic]"
  - "declared elements [Visual Basic], referencing"
  - "declared elements [Visual Basic], about declared elements"
ms.assetid: e39c0752-f19f-4d2e-a453-00df1b5fc7ee
---
# How to: Hide a Variable with the Same Name as Your Variable (Visual Basic)

You can hide a variable by *shadowing* it, that is, by redefining it with a variable of the same name. You can shadow the variable you want to hide in two ways:

- **Shadowing Through Scope.** You can shadow it through scope by redeclaring it inside a subregion of the region containing the variable you want to hide.

- **Shadowing Through Inheritance.** If the variable you want to hide is defined at class level, you can shadow it through inheritance by redeclaring it with the [Shadows](../../../language-reference/modifiers/shadows.md) keyword in a derived class.

## Two Ways to Hide a Variable

#### To hide a variable by shadowing it through scope

1. Determine the region defining the variable you want to hide, and determine a subregion in which to redefine it with your variable.

    |Variable's region|Allowable subregion for redefining it|
    |-----------------------|-------------------------------------------|
    |Module|A class within the module|
    |Class|A subclass within the class<br /><br /> A procedure within the class|

    You cannot redefine a procedure variable in a block within that procedure, for example in an `If`...`End If` construction or a `For` loop.

2. Create the subregion if it does not already exist.

3. Within the subregion, write a [Dim Statement](../../../language-reference/statements/dim-statement.md) declaring the shadowing variable.

    When code inside the subregion refers to the variable name, the compiler resolves the reference to the shadowing variable.

    The following example illustrates shadowing through scope, as well as a reference that bypasses the shadowing.

    ```vb
    Module shadowByScope
        ' The following statement declares num as a module-level variable.
        Public num As Integer
        Sub show()
            ' The following statement declares num as a local variable.
            Dim num As Integer
            ' The following statement sets the value of the local variable.
            num = 2
            ' The following statement displays the module-level variable.
            MsgBox(CStr(shadowByScope.num))
        End Sub
        Sub useModuleLevelNum()
            ' The following statement sets the value of the module-level variable.
            num = 1
            show()
        End Sub
    End Module
    ```

    The preceding example declares the variable `num` both at module level and at procedure level (in the procedure `show`). The local variable `num` shadows the module-level variable `num` within `show`, so the local variable is set to 2. However, there is no local variable to shadow `num` in the `useModuleLevelNum` procedure. Therefore, `useModuleLevelNum` sets the value of the module-level variable to 1.

    The `MsgBox` call inside `show` bypasses the shadowing mechanism by qualifying `num` with the module name. Therefore, it displays the module-level variable instead of the local variable.

#### To hide a variable by shadowing it through inheritance

1. Be sure the variable you want to hide is declared in a class, and at class level (outside any procedure). Otherwise you cannot shadow it through inheritance.

2. Define a class derived from the variable's class if one does not already exist.

3. Inside the derived class, write a `Dim` statement declaring your variable. Include the [Shadows](../../../language-reference/modifiers/shadows.md) keyword in the declaration.

    When code in the derived class refers to the variable name, the compiler resolves the reference to your variable.

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

    The preceding example declares the variable `shadowString` in the base class and shadows it in the derived class. The procedure `showStrings` in the derived class displays the shadowing version of the string when the name `shadowString` is not qualified. It then displays the shadowed version when `shadowString` is qualified with the `MyBase` keyword.

## Robust Programming

Shadowing introduces more than one version of a variable with the same name. When a code statement refers to the variable name, the version to which the compiler resolves the reference depends on factors such as the location of the code statement and the presence of a qualifying string. This can increase the risk of referring to an unintended version of a shadowed variable. You can lower that risk by fully qualifying all references to a shadowed variable.

## See also

- [References to Declared Elements](references-to-declared-elements.md)
- [Shadowing in Visual Basic](shadowing.md)
- [Differences Between Shadowing and Overriding](differences-between-shadowing-and-overriding.md)
- [How to: Hide an Inherited Variable](how-to-hide-an-inherited-variable.md)
- [How to: Access a Variable Hidden by a Derived Class](how-to-access-a-variable-hidden-by-a-derived-class.md)
- [Overrides](../../../language-reference/modifiers/overrides.md)
- [Me, My, MyBase, and MyClass](../../program-structure/me-my-mybase-and-myclass.md)
- [Inheritance Basics](../objects-and-classes/inheritance-basics.md)
