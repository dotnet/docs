---
title: Resolve errors related to `using` statements and `using` declarations
description: These errors indicate an incorrect use of the `using` statement or `using` declarations. Learn about the errors and how to fix them.
f1_keywords:
  - "CS0245"
  - "CS0728"
  - "CS1674"
  - "CS8410"
  - "CS8417"
  - "CS8418"
  - "CS8647"
  - "CS8648"
  - "CS8649"
  - "CS9229"
helpviewer_keywords:
  - "CS0245"
  - "CS0728"
  - "CS1674"
  - "CS8410"
  - "CS8417"
  - "CS8418"
  - "CS8647"
  - "CS8648"
  - "CS8649"
  - "CS9229"
ms.date: 10/27/2025
ai-usage: ai-assisted
---
# Resolve warnings related to the `using` statements and `using` declarations

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's be design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0245**](#implementing-idisposable-and-iasyncdisposable): *Destructors and `object.Finalize` cannot be called directly. Consider calling `IDisposable.Dispose` if available.*
- [**CS0728**](#using-variable-scope-and-control-flow): *Possibly incorrect assignment to local variable which is the argument to a using or `lock` statement. The `Dispose` call or unlocking will happen on the original value of the local.*
- [**CS1674**](#implementing-idisposable-and-iasyncdisposable): *Type used in a using statement must be implicitly convertible to '`System.IDisposable`'.*
- [**CS8410**](#implementing-idisposable-and-iasyncdisposable): *'Type used in an asynchronous `using` statement must be implicitly convertible to '`System.IAsyncDisposable`' or implement a suitable '`DisposeAsync`' method.*
- [**CS8417**](#implementing-idisposable-and-iasyncdisposable): *Type used in an asynchronous using statement must implement '`System.IAsyncDisposable`' or implement a suitable '`DisposeAsync`' method. Did you mean '`using`' rather than '`await using`'?*
- [**CS8418**](#implementing-idisposable-and-iasyncdisposable): *Type used in a using statement must implement '`System.IDisposable`'. Did you mean '`await using`' rather than 'using'?*
- [**CS8647**](#using-variable-scope-and-control-flow): *A using variable cannot be used directly within a switch section (consider using braces).*
- [**CS8648**](#using-variable-scope-and-control-flow): *A `goto` cannot jump to a location after a using declaration.*
- [**CS8649**](#using-variable-scope-and-control-flow): *A `goto` cannot jump to a location before a using declaration within the same block.*
- [**CS9229**](#incorrect-using-declaration): *Modifiers cannot be placed on using declarations.*

## Implementing IDisposable and IAsyncDisposable

The following compiler errors and warnings indicate issues with implementing or using the dispose pattern:

- **CS0245**: *Destructors and `object.Finalize` cannot be called directly. Consider calling `IDisposable.Dispose` if available.*
- **CS1674**: *Type used in a using statement must be implicitly convertible to '`System.IDisposable`'.*
- **CS8410**: *Type used in an asynchronous `using` statement must be implicitly convertible to '`System.IAsyncDisposable`' or implement a suitable 'DisposeAsync' method.*
- **CS8417**: *Type used in an asynchronous `using` statement must implement '`System.IAsyncDisposable`' or implement a suitable '`DisposeAsync`' method. Did you mean '`using`' rather than '`await using`'?*
- **CS8418**: *Type used in a using statement must implement '`System.IDisposable`'. Did you mean '`await using`' rather than '`using`'?*

The [using statement](../statements/using.md) ensures proper disposal of resources at the end of the `using` block. To use a type with a `using` statement, it must implement the appropriate disposal interface. For synchronous `using` statements, the type must implement <xref:System.IDisposable>. For asynchronous `await using` statements, the type must implement <xref:System.IAsyncDisposable>.

- **Cannot call Finalize directly (CS0245)**: You can't directly call a destructor or the <xref:System.Object.Finalize%2A?displayProperty=nameWithType> method. The garbage collector automatically invokes finalizers when objects are no longer referenced. For deterministic cleanup, implement <xref:System.IDisposable> and call the `Dispose` method instead.
- **Type must implement IDisposable (CS1674)**: Only types that implement <xref:System.IDisposable> can be used in a `using` statement. Value types don't implement this interface, and generic type parameters without proper constraints can't be assumed to be disposable. Apply a type constraint like `where T : IDisposable` when working with generic types.
- **Type must implement IAsyncDisposable (CS8410)**: Types used with `await using` must implement <xref:System.IAsyncDisposable> or provide a suitable `DisposeAsync` method. If your type doesn't support asynchronous disposal, use a synchronous `using` statement instead or implement the required interface.
- **Mismatched disposal pattern (CS8417, CS8418)**: CS8417 occurs when you use `await using` with a type that only implements <xref:System.IDisposable>. CS8418 occurs when you use synchronous `using` with a type that only implements <xref:System.IAsyncDisposable>. Match the `using` keyword to the interface your type implements, or implement both interfaces if you need to support both patterns.

For more information, see [Finalizers](../../programming-guide/classes-and-structs/finalizers.md), [Implement a Dispose method](../../../standard/garbage-collection/implementing-dispose.md), and [Implement a DisposeAsync method](../../../standard/garbage-collection/implementing-disposeasync.md).

## Using variable scope and control flow

The following compiler errors and warnings relate to incorrect usage of `using` variables within control flow statements:

- **CS0728**: *Possibly incorrect assignment to local variable which is the argument to a `using` or `lock` statement. The `Dispose` call or unlocking will happen on the original value of the local.*
- **CS8647**: *A using variable cannot be used directly within a switch section (consider using braces).*
- **CS8648**: *A `goto` cannot jump to a location after a using declaration.*
- **CS8649**: *A `goto` cannot jump to a location before a using declaration within the same block.*

Variables declared with `using` have specific scoping rules that prevent resource leaks. The compiler enforces these rules to ensure proper disposal.

- **Assignment to using variable (CS0728)**: This warning indicates you assigned a new value to a variable that's the resource in a `using` statement. The dispose call occurs on the original value, not the newly assigned value, which can lead to resource leaks. Initialize the resource in the `using` statement declaration instead of assigning to it later.

- **Using variable in switch section (CS8647)**: A `using` declaration creates a variable that's disposed at the end of its scope. When used directly in a switch section without braces, the scope is ambiguous and can lead to errors. Wrap the switch section content in braces to clearly define the scope.

- **Goto statements and using declarations (CS8648, CS8649)**: You can't use `goto` statements to jump over `using` declarations because jumping would skip proper resource management. CS8648 occurs when jumping forward over a `using` declaration, and CS8649 occurs when jumping backward to a location before a `using` declaration. Restructure your code to use structured control flow like loops, or move the `using` declaration outside the jump target.

For more information, see [using statement](../statements/using.md).

## Incorrect `using` declaration

- **CS9229**: *Modifiers cannot be placed on using declarations.*

A variable declaration wrapped in a `using` declaration can't include any of the following modifiers:

- `const`
- `static`
- `volatile`
- `readonly`
- Accessibility modifiers: `public`, `protected`, `internal`, `private`, `protected internal`, or `private protected`

The following example generates CS9229:

```csharp
using System;

class Program
{
    static void Main()
    {
        // error CS9229: Modifiers cannot be placed on using declarations.
        public using var resource = new Resource();
        
        // error CS9229: Modifiers cannot be placed on using declarations.
        static using var anotherResource = new Resource();
    }
}

class Resource : IDisposable
{
    public void Dispose() { }
}
```

To correct this error, remove the modifier from the `using` declaration:

```csharp
using var resource = new Resource();
```

For more information, see [using statement](../statements/using.md).
