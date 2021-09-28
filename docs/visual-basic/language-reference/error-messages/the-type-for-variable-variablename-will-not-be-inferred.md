---
description: "Learn more about: BC42110: The type for variable '<variablename>' will not be inferred because it is bound to a field in an enclosing scope"
title: "The type for variable '<variablename>' will not be inferred because it is bound to a field in an enclosing scope"
ms.date: 07/20/2015
f1_keywords:
  - "vbc42110"
  - "bc42110"
helpviewer_keywords:
  - "BC42110"
ms.assetid: ef4442eb-08d1-434f-a03b-4aa2ed4e4414
---
# BC42110: The type for variable '\<variablename>' will not be inferred because it is bound to a field in an enclosing scope

The type for variable '\<variablename>' will not be inferred because it is bound to a field in an enclosing scope. Either change the name of '\<variablename>', or use the fully qualified name (for example, 'Me.variablename' or 'MyBase.variablename').

A loop control variable in your code has the same name as a field of the class or other enclosing scope. Because the control variable is used without an `As` clause, it is bound to the field in the enclosing scope, and the compiler does not create a new variable for it or infer its type.

In the following example, `Index`, the control variable in the `For` statement, is bound to the `Index` field in the `Customer` class. The compiler does not create a new variable for the control variable `Index` or infer its type.

```vb
Class Customer

    ' The class has a field named Index.
    Private Index As Integer

    Sub Main()

    ' The following line will raise this warning.
        For Index = 1 To 10
            ' ...
        Next

    End Sub
End Class
```

By default, this message is a warning. For information about how to hide warnings or how to treat warnings as errors, see [Configuring Warnings in Visual Basic](/visualstudio/ide/configuring-warnings-in-visual-basic).

**Error ID:** BC42110

## To address this warning

- Make the loop control variable local by changing its name to an identifier that is not also the name of a field of the class.

  ```vb
  For I = 1 To 10
  ```

- Clarify that the loop control variable binds to the class field by prefixing `Me.` to the variable name.

  ```vb
  For Me.Index = 1 To 10
  ```

- Instead of relying on local type inference, use an `As` clause to specify a type for the loop control variable.

  ```vb
  For Index As Integer = 1 To 10
  ```

## Example

 The following code shows the earlier example with the first correction in place.

```vb
Class Customer

    ' The class has a field named Index.
    Private Index As Integer

    Sub Main()

        For I = 1 To 10
            ' ...
        Next

    End Sub
End Class
```

## See also

- [Option Infer Statement](../statements/option-infer-statement.md)
- [For Each...Next Statement](../statements/for-each-next-statement.md)
- [For...Next Statement](../statements/for-next-statement.md)
- [How to: Refer to the Current Instance of an Object](../../programming-guide/language-features/variables/how-to-refer-to-the-current-instance-of-an-object.md)
- [Local Type Inference](../../programming-guide/language-features/variables/local-type-inference.md)
- [Me, My, MyBase, and MyClass](../../programming-guide/program-structure/me-my-mybase-and-myclass.md)
