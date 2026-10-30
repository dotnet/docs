---
title: "Resolve errors and warnings related to jump statements"
description: "This article helps you diagnose and correct compiler errors and warnings related to the break, continue, goto, and return jump statements."
f1_keywords:
  - "CS0126"
  - "CS0127"
  - "CS0139"
  - "CS0140"
  - "CS0153"
  - "CS0157"
  - "CS0158"
  - "CS0159"
  - "CS0161"
  - "CS0162"
  - "CS0163"
  - "CS0164"
  - "CS0469"
  - "CS8070"
  - "CS9393"
  - "CS9394"
helpviewer_keywords:
  - "CS0126"
  - "CS0127"
  - "CS0139"
  - "CS0140"
  - "CS0153"
  - "CS0157"
  - "CS0158"
  - "CS0159"
  - "CS0161"
  - "CS0162"
  - "CS0163"
  - "CS0164"
  - "CS0469"
  - "CS8070"
  - "CS9393"
  - "CS9394"
ms.date: 10/30/2026
ai-usage: ai-assisted
---
# Resolve errors and warnings for jump statements

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->

The following errors occur when you use a `break`, `continue`, `goto`, or `return` statement in a way that doesn't match the surrounding control flow:

- [**CS0126**](#return-statement-values): *An object of a type convertible to 'type' is required*
- [**CS0127**](#return-statement-values): *Since 'method' returns void, a return keyword must not be followed by an object expression*
- [**CS0139**](#break-and-continue-targets): *No enclosing loop out of which to break or continue*
- [**CS0140**](#anchor-tbd): *The label 'label' is a duplicate*
- [**CS0153**](#goto-statement-targets): *A goto case is only valid inside a switch statement*
- [**CS0157**](#anchor-tbd): *Control cannot leave the body of a finally clause*
- [**CS0158**](#anchor-tbd): *The label 'label' shadows another label by the same name in a contained scope*
- [**CS0159**](#goto-statement-targets): *No such label 'label' within the scope of the goto statement*
- [**CS0161**](#return-statement-values): *'method': not all code paths return a value*
- [**CS0163**](#switch-section-termination): *Control cannot fall through from one case label ('label') to another*
- [**CS8070**](#anchor-tbd): *Control cannot fall out of switch from final case label ('label')*
- [**CS9393**](#break-and-continue-targets): *No enclosing loop or switch statement with the label 'label' out of which to break*
- [**CS9394**](#break-and-continue-targets): *No enclosing loop with the label 'label' out of which to continue*

The following warnings occur when code is unreachable, a label isn't referenced, or a `goto case` statement targets a value that requires a conversion:

- [**CS0162**](#anchor-tbd): *Unreachable code detected*
- [**CS0164**](#anchor-tbd): *This label has not been referenced*
- [**CS0469**](#goto-statement-targets): *The 'goto case' value is not implicitly convertible to type 'type'*

## Break and continue targets

- **CS0139**: *No enclosing loop out of which to break or continue*
- **CS9393**: *No enclosing loop or switch statement with the label 'label' out of which to break*
- **CS9394**: *No enclosing loop with the label 'label' out of which to continue*

The `break` statement transfers control out of the nearest enclosing loop or `switch` statement, and the `continue` statement starts the next iteration of the nearest enclosing loop. The compiler reports these diagnostics when it can't find that target.

To resolve these errors:

- Place the `break` or `continue` statement inside a `while`, `do`, `for`, or `foreach` loop. A `break` statement can also appear in a `switch` section. A bare `break` or `continue` that isn't nested in one of these statements has no target (**CS0139**).
- When you write a labeled `break` (`break label;`), apply the same label to an enclosing loop or `switch` statement. The label must name a loop or `switch` that contains the `break` statement (**CS9393**).
- When you write a labeled `continue` (`continue label;`), apply the same label to an enclosing loop. A labeled `continue` can target only a loop, not a `switch` statement, because `continue` starts the next loop iteration (**CS9394**).

For more information about these statements, see [The `break` statement](../statements/jump-statements.md#the-break-statement) and [The `continue` statement](../statements/jump-statements.md#the-continue-statement) in the jump statements article.

## Goto statement targets

- **CS0153**: *A goto case is only valid inside a switch statement*
- **CS0159**: *No such label 'label' within the scope of the goto statement*
- **CS0469**: *The 'goto case' value is not implicitly convertible to type 'type'*

The `goto` statement transfers control to a labeled statement, to a `case` label, or to the `default` label of a `switch` statement. The compiler reports these diagnostics when the target label doesn't exist or isn't reachable from the `goto` statement.

To resolve these errors:

- Use `goto case` and `goto default` only inside a `switch` statement. Both forms name a section of the enclosing `switch` statement, so they have no meaning outside one (**CS0153**).
- Add a label that matches the name in the `goto` statement, and confirm that the label is within the scope of the `goto` statement. A `goto` statement can't jump into a nested block, and `goto case` requires a matching `case` label in the same `switch` statement (**CS0159**).
- Give the `goto case` value the same type as the `switch` governing expression, or add an explicit cast so an implicit conversion exists. For example, use `goto case (char)127;` rather than `goto case 127;` when the `switch` governs a `char` value (**CS0469**).

For more information about the `goto` statement, see [The `goto` statement](../statements/jump-statements.md#the-goto-statement) in the jump statements article. For more information about `goto case` and `goto default`, see [The `switch` statement](../statements/selection-statements.md#the-switch-statement) in the selection statements article.

## Switch section termination

- **CS0163**: *Control cannot fall through from one case label ('label') to another*

C# doesn't allow control to fall through from one `switch` section to the next. When a `switch` statement contains more than one section, you must explicitly terminate each section, including the last one.

To resolve this error, end each `switch` section that contains statements with a jump statement, such as `break`, `return`, `goto case`, `goto default`, or `throw`. To run the same statements for more than one value, stack the `case` labels with no statements between them; that arrangement isn't fall-through. When you want one section to continue into another, use `goto case` or `goto default` to name the next section explicitly (**CS0163**).

For more information about the `switch` statement, see [The `switch` statement](../statements/selection-statements.md#the-switch-statement) in the selection statements article. For more information about the `throw` statement, see [The `throw` statement](../statements/exception-handling-statements.md#the-throw-statement) in the exception handling statements article.

## CS8070

Control cannot fall out of switch from final case label ('label')

This error occurs when the last `case` or `default` case of a [switch statement](../statements/selection-statements.md#the-switch-statement) doesn't end with a jump statement such as:

- [break](../statements/jump-statements.md#the-break-statement)
- [return](../statements/jump-statements.md#the-return-statement)
- [throw](../statements/exception-handling-statements.md#the-throw-statement)

The following sample generates CS8070:

```csharp
using System;

public class MyClass
{
    public static void Main()
    {
        int i = 2;
        int j = 0;

        switch (i)
        {
            case 1:
                i++;
                break;

            // Compiler error CS8070 is reported on the following line.
            case 2:
                i += 2;
            // To resolve the error, uncomment one of the following example statements.
            // break;
            // return;
            // throw new Exception("Fin");
        }

        switch (j)
        {
            case 1:
                j++;
                break;

            case 2:
                j += 2;
                break;

            // Compiler error CS8070 is reported on the following line.
            default:
                Console.WriteLine("Default");
            // To resolve the error, uncomment the following line:
            // break;
        }
    }
}
```

## Return statement values

- **CS0126**: *An object of a type convertible to 'type' is required*
- **CS0127**: *Since 'method' returns void, a return keyword must not be followed by an object expression*
- **CS0161**: *'method': not all code paths return a value*

The `return` statement ends execution of the containing member and returns control to the caller. A `return` statement can also return a value.

To resolve these errors:

- Supply a value in each `return` statement of a member that has a non-`void` return type, and make sure the value is convertible to that return type. A `get` accessor and a value-returning method both require a `return` statement that includes a value (**CS0126**).
- Remove the value from any `return` statement in a member that returns `void`, such as a `set` accessor or a method with a `void` return type. Use a bare `return;` statement to exit early (**CS0127**).
- Make sure every code path in a value-returning member ends with a `return` statement or a `throw` statement. A member returns on all code paths when each branch of every conditional statement returns a value, or when a final `return` statement follows the conditional logic (**CS0161**).

For more information about `return` statements in async methods and members that return `Task` or `ValueTask` types, see [Errors and warnings related to async and await](async-await-errors.md). For more information about `return` statements in iterators, see [Errors and warnings related to iterators](iterator-yield.md).

For more information about the `return` statement, see [The `return` statement](../statements/jump-statements.md#the-return-statement) in the jump statements article.

## CS0140

The label 'label' is a duplicate

A label with the same name appeared twice. For more information, see [goto](../statements/jump-statements.md#the-goto-statement).

The following sample generates CS0140:

```csharp
// CS0140.cs
namespace MyNamespace
{
   public class MyClass
   {
      public static void Main()
      {
         label1: int i = 0;
         label1: int j = 0;   // CS0140, comment this line to resolve
         goto label1;
      }
   }
}
```

## CS0157

Control cannot leave the body of a finally clause

A `return`, `break`, `continue`, or `goto` statement can't transfer control outside a [finally](../statements/exception-handling-statements.md#the-try-finally-statement) clause. For more information, see [Exceptions and Exception Handling](../../fundamentals/exceptions/index.md).

The following sample generates CS0157:

```csharp
// CS0157.cs
using System;
namespace MyNamespace
{
   public class MyClass2 : Exception
   {
   }

   public class MyClass
   {
      public static void Main()
      {
         try
         {
         }
         finally
         {
            return;   // CS0157, cannot leave finally clause
         }
      }
   }
}
```

## CS0158

The label 'label' shadows another label by the same name in a contained scope

Labels in nested scopes can't have the same name. For more information, see [goto](../statements/jump-statements.md#the-goto-statement).

The following sample generates CS0158:

```csharp
// CS0158.cs
namespace MyNamespace
{
   public class MyClass
   {
      public static void Main()
      {
         goto lab1;
         lab1:
         {
            lab1:   // CS0158
            goto lab1;
         }
      }
   }
}
```

## CS0162

Unreachable code detected

The compiler detected code that will never be executed.

### Example

The following example generates CS0162:

```csharp
// CS0162.cs
// compile with: /W:2
public class Program
{
    public static void Main()
    {
        goto lab1;
        {
            // The following statements cannot be reached:
            int i = 9;   // CS0162
            i++;
        }
    lab1:
        {
        }
    }
}
```

Another common example where this warning is generated is as follows:

```csharp
public static class Class1
{
    public static string Method1()
    {
        string x = "a";
        switch (x)
        {
            case "a":
                return "a";
                break;          // CS0162
        }
        return "";
    }
}
```

The `break` statement cannot be reached because it occurs after the `return` statement.
The `return` statement ends the enclosing `case` branch.

## CS0164

This label has not been referenced

A label was declared but never used.

The following sample generates CS0164:

```csharp
// CS0164.cs
// compile with: /W:2
public class Program
{
    public static void Main()
    {
        int i = 0;
    l1: // CS0164
        i++;
        // Uncomment the following lines to resolve this warning.
        // if (i < 10)
        //     goto l1;
    }
}
```

## C# language specification

For more information, see the [Jump statements](~/_csharpstandard/standard/statements.md#1310-jump-statements) section of the C# language specification.

## See also

- [C# jump statements](../statements/jump-statements.md)
- [C# selection statements](../statements/selection-statements.md)
