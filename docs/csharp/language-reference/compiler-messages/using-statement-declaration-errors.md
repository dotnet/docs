---
title: Resolve errors related to `using` statements and `using` declarations.
description: These errors indicate an incorrect use of the `using` statement or `using` declarations. Learn about the errors and how to fix them.
f1_keywords:
  - "CS1674"
  - "CS8410"
  - "CS8417"
  - "CS8418"
  - "CS8647"
  - "CS8648"
  - "CS8649"
  - "CS9229"
helpviewer_keywords:
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
- [**CS1674**](#type-must-be-disposable): *'T': type used in a using statement must be implicitly convertible to 'System.IDisposable'*
- [**CS8410**](#type-must-be-async-disposable): *'type': type used in an asynchronous `using` statement must be implicitly convertible to 'System.IAsyncDisposable' or implement a suitable 'DisposeAsync' method.*
- [**CS8417**](#async-disposable-type-used-with-using): *'type': type used in an asynchronous using statement must implement 'System.IAsyncDisposable' or implement a suitable 'DisposeAsync' method. Did you mean 'using' rather than 'await using'?*
- [**CS8418**](#disposable-type-used-with-await-using): *'type': type used in a using statement must implement 'System.IDisposable'. Did you mean 'await using' rather than 'using'?*
- [**CS8647**](#using-variable-in-switch-section): *A using variable cannot be used directly within a switch section (consider using braces).*
- [**CS8648**](#goto-forward-jump-over-using-declaration): *A goto cannot jump to a location after a using declaration.*
- [**CS8649**](#goto-backward-jump-over-using-declaration): *A goto cannot jump to a location before a using declaration within the same block.*
- [**CS9229**](#incorrect-using-declaration): *Modifiers cannot be placed on using declarations.*

## Type must be disposable

- **CS1674**: *'T': type used in a using statement must be implicitly convertible to 'System.IDisposable'*

The [using statement](../statements/using.md) ensures the disposal of an object at the end of the `using` block. Only types that are disposable can be used in such a statement. For example, value types aren't disposable, and type parameters that aren't constrained to be classes can't be assumed to be disposable.

The following sample generates CS1674:

```csharp
// CS1674.cs
class C
{
   public static void Main()
   {
      int a = 0;
      a++;

      using (a) {}   // CS1674
   }
}
```

The following sample generates CS1674:

```csharp
// CS1674_b.cs
using System;
class C {
   public void Test() {
      using (C c = new C()) {}   // CS1674
   }
}

// OK
class D : IDisposable {
   void IDisposable.Dispose() {}
   public void Dispose() {}

   public static void Main() {
      using (D d = new D()) {}
   }
}
```

The following case illustrates the need for a class type constraint to guarantee that an unknown type parameter is disposable. The following sample generates CS1674:

```csharp
// CS1674_c.cs
// compile with: /target:library
using System;
public class C<T>
// Add a class type constraint that specifies a disposable class.
// Uncomment the following line to resolve.
// public class C<T> where T : IDisposable
{
   public void F(T t)
   {
      using (t) {}   // CS1674
   }
}
```

## Type must be async disposable

- **CS8410**: *'type': type used in an asynchronous `using` statement must be implicitly convertible to 'System.IAsyncDisposable' or implement a suitable 'DisposeAsync' method.*

The expression inside an `await using` statement must have a `DisposeAsync` method.

To correct this error, remove the `await using` keywords, or implement a suitable `DisposeAsync` method.

The following example generates CS8410:

```csharp
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        // error CS8410: 'Example': type used in an asynchronous using statement
        // must be implicitly convertible to 'System.IAsyncDisposable' or implement
        // a suitable 'DisposeAsync' method.
        await using var example = new Example();
    }
}

class Example
{
}
```

For more information, see [Implement a DisposeAsync method](../../../standard/garbage-collection/implementing-disposeasync.md).

## Async disposable type used with `using`

- **CS8417**: *'type': type used in an asynchronous using statement must implement 'System.IAsyncDisposable' or implement a suitable 'DisposeAsync' method. Did you mean 'using' rather than 'await using'?*

You used `await using` with a type that implements <xref:System.IDisposable> but not <xref:System.IAsyncDisposable>. The compiler suggests you might have meant to use a synchronous `using` statement instead.

The following example generates CS8417:

```csharp
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        // error CS8417: 'Example': type used in an asynchronous using statement
        // must implement 'System.IAsyncDisposable' or implement a suitable
        // 'DisposeAsync' method. Did you mean 'using' rather than 'await using'?
        await using var example = new Example();
    }
}

class Example : IDisposable
{
    public void Dispose() { }
}
```

To correct this error, either:
- Change `await using` to `using` if synchronous disposal is appropriate
- Implement <xref:System.IAsyncDisposable> if asynchronous disposal is needed

For more information, see [Implement a DisposeAsync method](../../../standard/garbage-collection/implementing-disposeasync.md).

## Disposable type used with `await using`

- **CS8418**: *'type': type used in a using statement must implement 'System.IDisposable'. Did you mean 'await using' rather than 'using'?*

You used a synchronous `using` statement with a type that implements <xref:System.IAsyncDisposable> but not <xref:System.IDisposable>. The compiler suggests you might have meant to use `await using` instead.

The following example generates CS8418:

```csharp
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        // error CS8418: 'Example': type used in a using statement must implement
        // 'System.IDisposable'. Did you mean 'await using' rather than 'using'?
        using var example = new Example();
    }
}

class Example : IAsyncDisposable
{
    public ValueTask DisposeAsync() => ValueTask.CompletedTask;
}
```

To correct this error, either:
- Change `using` to `await using` if asynchronous disposal is appropriate
- Implement <xref:System.IDisposable> if synchronous disposal is needed

For more information, see [Implement a DisposeAsync method](../../../standard/garbage-collection/implementing-disposeasync.md).

## Using variable in switch section

- **CS8647**: *A using variable cannot be used directly within a switch section (consider using braces).*

A `using` declaration creates a variable that is disposed at the end of its scope. When used directly in a switch section without braces, the scope is ambiguous and can lead to errors.

The following example generates CS8647:

```csharp
using System;

class Program
{
    static void Main()
    {
        int choice = 1;
        switch (choice)
        {
            case 1:
                // error CS8647: A using variable cannot be used directly within
                // a switch section (consider using braces).
                using var resource = new Resource();
                Console.WriteLine("Case 1");
                break;
        }
    }
}

class Resource : IDisposable
{
    public void Dispose() { }
}
```

To correct this error, wrap the switch section content in braces:

```csharp
switch (choice)
{
    case 1:
    {
        using var resource = new Resource();
        Console.WriteLine("Case 1");
        break;
    }
}
```

For more information, see [using statement](../statements/using.md).

## Goto forward jump over using declaration

- **CS8648**: *A goto cannot jump to a location after a using declaration.*

You cannot use a `goto` statement to jump forward over a `using` declaration. The `using` declaration creates a resource that must be properly disposed, and jumping over it would skip the resource initialization.

The following example generates CS8648:

```csharp
using System;

class Program
{
    static void Main()
    {
        goto label;
        
        // error CS8648: A goto cannot jump to a location after a using declaration.
        using var resource = new Resource();
        
    label:
        Console.WriteLine("After label");
    }
}

class Resource : IDisposable
{
    public void Dispose() { }
}
```

To correct this error, restructure your code to avoid jumping over the `using` declaration. You can:
- Move the `using` declaration before the label
- Remove the `goto` statement and use structured control flow
- Place the `using` declaration in a separate scope

For more information, see [using statement](../statements/using.md).

## Goto backward jump over using declaration

- **CS8649**: *A goto cannot jump to a location before a using declaration within the same block.*

You cannot use a `goto` statement to jump backward to a location before a `using` declaration within the same block. This would create a control flow that could skip proper disposal of the resource.

The following example generates CS8649:

```csharp
using System;

class Program
{
    static void Main()
    {
    label:
        Console.WriteLine("At label");
        
        using var resource = new Resource();
        
        // error CS8649: A goto cannot jump to a location before a using
        // declaration within the same block.
        goto label;
    }
}

class Resource : IDisposable
{
    public void Dispose() { }
}
```

To correct this error, restructure your code to avoid jumping backward over the `using` declaration. You can:
- Remove the `goto` statement and use structured control flow like loops
- Place the `using` declaration in a separate scope outside the jump target
- Restructure the logic to avoid the backward jump

For more information, see [using statement](../statements/using.md).

## Incorrect `using` declaration

- **CS9229**: *Modifiers cannot be placed on using declarations.*

A variable declaration wrapped in a `using` declaration can't include any of the following modifiers:

- `const`
- `static`
- `volatile`
- `readonly`
- Acccessibility modifiers: `public`, `protected`, `internal`, `private`, `protected internal` or `private protected`
