---
description: "Learn more about: Shared (Visual Basic)"
title: "Shared"
ms.date: 07/20/2015
f1_keywords:
  - "vb.Shared"
helpviewer_keywords:
  - "Shared keyword [Visual Basic]"
  - "members [Visual Basic], shared"
  - "shared members"
  - "nonshared"
  - "shared [elements VB]"
  - "elements [Visual Basic], shared"
ms.assetid: 2bf7cf2c-b0dd-485e-8749-b5d674dab4cd
---
# Shared (Visual Basic)

Specifies that one or more declared programming elements are associated with a class or structure at large, and not with a specific instance of the class or structure.

## When to Use Shared

Sharing a member of a class or structure makes it available to every instance, rather than *non-shared*, where each instance keeps its own copy. Sharing is useful, for example, if the value of a variable applies to the entire application. If you declare that variable to be `Shared`, then all instances access the same storage location, and if one instance changes the variable's value, all instances access the updated value.

Sharing does not alter the access level of a member. For example, a class member can be shared and private (accessible only from within the class), or non-shared and public. For more information, see [Access levels in Visual Basic](../../programming-guide/language-features/declared-elements/access-levels.md).

## Rules

- **Declaration Context.** You can use `Shared` only at module level. This means the declaration context for a `Shared` element must be a class or structure, and cannot be a source file, namespace, or procedure.

- **Combined Modifiers.** You cannot specify `Shared` together with [Overrides](overrides.md), [Overridable](overridable.md), [NotOverridable](notoverridable.md), [MustOverride](mustoverride.md), or [Static](static.md) in the same declaration.

- **Accessing.** You access a shared element by qualifying it with its class or structure name, not with the variable name of a specific instance of its class or structure. You do not even have to create an instance of a class or structure to access its shared members.

     The following example calls the shared procedure <xref:System.Double.IsNaN%2A> exposed by the <xref:System.Double> structure.

     ```vb
     If Double.IsNaN(result) Then Console.WriteLine("Result is mathematically undefined.")
     ```

- **Implicit Sharing.** You cannot use the `Shared` modifier in a [Const Statement](../statements/const-statement.md), but constants are implicitly shared. Similarly, you cannot declare a member of a module or an interface to be `Shared`, but they are implicitly shared.

## Behavior

- **Storage.** A shared variable or event is stored in memory only once, no matter how many or few instances you create of its class or structure. Similarly, a shared procedure or property holds only one set of local variables.

- **Accessing through an Instance Variable.** It is possible to access a shared element by qualifying it with the name of a variable that contains a specific instance of its class or structure. Although this usually works as expected, the compiler generates a warning message and makes the access through the class or structure name instead of the variable.

- **Accessing through an Instance Expression.** If you access a shared element through an expression that returns an instance of its class or structure, the compiler makes the access through the class or structure name instead of evaluating the expression. This access produces unexpected results if you intended the expression to perform other actions as well as returning the instance. The following example illustrates this situation.
  
    ```vb
    Sub Main()
        ' The following line is the preferred way to access Total.
        ShareTotal.Total = 10

        ' The following line generates a compiler warning message and
        ' accesses total through class ShareTotal instead of through
        ' the variable instanceVar. This works as expected and adds
        ' 100 to Total.
        Dim instanceVar As New ShareTotal
        instanceVar.Total += 100

        ' The following line generates a compiler warning message and
        ' accesses total through class ShareTotal instead of calling
        ' ReturnClass(). This adds 1000 to total but does not work as
        ' expected, because the WriteLine in ReturnClass() does not run.
        Console.WriteLine("Value of total is " & CStr(ShareTotal.Total))
        ReturnClass().Total += 1000
    End Sub

    Public Function ReturnClass() As ShareTotal
        Console.WriteLine("Function ReturnClass() called")
        Return New ShareTotal
    End Function

    Public Class ShareTotal
        Public Shared Property Total As Integer
    End Class
    ```

     In the preceding example, the compiler generates a warning message both times the code accesses the shared property `Total` through an instance. In each case, it makes the access directly through the class `ShareTotal` and does not make use of any instance. In the case of the intended call to the procedure `ReturnClass`, this means it does not even generate a call to `ReturnClass`, so the additional action of displaying "Function ReturnClass() called" is not performed.

The `Shared` modifier can be used in these contexts:

- [Dim Statement](../statements/dim-statement.md)
- [Event Statement](../statements/event-statement.md)
- [Function Statement](../statements/function-statement.md)
- [Operator Statement](../statements/operator-statement.md)
- [Property Statement](../statements/property-statement.md)
- [Sub Statement](../statements/sub-statement.md)
  
## See also

- [Shadows](shadows.md)
- [Static](static.md)
- [Lifetime in Visual Basic](../../programming-guide/language-features/declared-elements/lifetime.md)
- [Procedures](../../programming-guide/language-features/procedures/index.md)
- [Structures](../../programming-guide/language-features/data-types/structures.md)
- [Objects and Classes](../../programming-guide/language-features/objects-and-classes/index.md)
