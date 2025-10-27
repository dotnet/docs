---
title: Resolve errors related to `using` statements and `using` declarations.
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
- [**CS0245**](#implementing-idisposable-and-iasyncdisposable): *Destructors and object.Finalize cannot be called directly. Consider calling IDisposable.Dispose if available.*
- [**CS0728**](#using-variable-scope-and-control-flow): *Possibly incorrect assignment to local 'variable' which is the argument to a using or lock statement. The Dispose call or unlocking will happen on the original value of the local.*
- [**CS1674**](#implementing-idisposable-and-iasyncdisposable): *'T': type used in a using statement must be implicitly convertible to 'System.IDisposable'*
- [**CS8410**](#implementing-idisposable-and-iasyncdisposable): *'type': type used in an asynchronous `using` statement must be implicitly convertible to 'System.IAsyncDisposable' or implement a suitable 'DisposeAsync' method.*
- [**CS8417**](#implementing-idisposable-and-iasyncdisposable): *'type': type used in an asynchronous using statement must implement 'System.IAsyncDisposable' or implement a suitable 'DisposeAsync' method. Did you mean 'using' rather than 'await using'?*
- [**CS8418**](#implementing-idisposable-and-iasyncdisposable): *'type': type used in a using statement must implement 'System.IDisposable'. Did you mean 'await using' rather than 'using'?*
- [**CS8647**](#using-variable-scope-and-control-flow): *A using variable cannot be used directly within a switch section (consider using braces).*
- [**CS8648**](#using-variable-scope-and-control-flow): *A goto cannot jump to a location after a using declaration.*
- [**CS8649**](#using-variable-scope-and-control-flow): *A goto cannot jump to a location before a using declaration within the same block.*
- [**CS9229**](#incorrect-using-declaration): *Modifiers cannot be placed on using declarations.*

## Implementing IDisposable and IAsyncDisposable

The following compiler errors and warnings indicate issues with implementing or using the dispose pattern:

- **CS0245**: *Destructors and object.Finalize cannot be called directly. Consider calling IDisposable.Dispose if available.*
- **CS1674**: *'T': type used in a using statement must be implicitly convertible to 'System.IDisposable'*
- **CS8410**: *'type': type used in an asynchronous `using` statement must be implicitly convertible to 'System.IAsyncDisposable' or implement a suitable 'DisposeAsync' method.*
- **CS8417**: *'type': type used in an asynchronous using statement must implement 'System.IAsyncDisposable' or implement a suitable 'DisposeAsync' method. Did you mean 'using' rather than 'await using'?*
- **CS8418**: *'type': type used in a using statement must implement 'System.IDisposable'. Did you mean 'await using' rather than 'using'?*

The [using statement](../statements/using.md) ensures proper disposal of resources at the end of the `using` block. To use a type with a `using` statement, it must implement the appropriate disposal interface. For synchronous `using` statements, the type must implement <xref:System.IDisposable>. For asynchronous `await using` statements, the type must implement <xref:System.IAsyncDisposable>.

### Cannot call Finalize directly (CS0245)

You cannot directly call a destructor (finalizer) or the <xref:System.Object.Finalize%2A?displayProperty=nameWithType> method. The garbage collector automatically calls finalizers when an object is no longer referenced. If you need deterministic cleanup, implement the <xref:System.IDisposable> interface and call the `Dispose` method.

The following example generates CS0245:

```csharp
using System;

class MyClass
{
    void Method()
    {
        this.Finalize();  // CS0245: cannot call Finalize directly
    }

    public static void Main() { }
}
```

To correct this error, implement <xref:System.IDisposable> and call `Dispose`:

```csharp
using System;

class MyClass : IDisposable
{
    public void Dispose()
    {
        // Cleanup code goes here
        GC.SuppressFinalize(this);
    }

    void Method()
    {
        this.Dispose();  // Correct: call Dispose instead
    }

    public static void Main() { }
}
```

### Type must implement IDisposable (CS1674)

Only types that are disposable can be used in a `using` statement. For example, value types aren't disposable, and type parameters that aren't constrained to be classes can't be assumed to be disposable.

The following sample generates CS1674:

```csharp
class C
{
   public static void Main()
   {
      int a = 0;
      a++;
      using (a) {}   // CS1674: int doesn't implement IDisposable
   }
}
```

The following sample also generates CS1674:

```csharp
using System;

class C {
   public void Test() {
      using (C c = new C()) {}   // CS1674: C doesn't implement IDisposable
   }
}

// OK - implements IDisposable
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
using System;

public class C<T>
// Add a class type constraint that specifies a disposable class.
// Uncomment the following line to resolve.
// public class C<T> where T : IDisposable
{
   public void F(T t)
   {
      using (t) {}   // CS1674: T might not implement IDisposable
   }
}
```

### Type must implement IAsyncDisposable (CS8410)

The expression inside an `await using` statement must have a `DisposeAsync` method. Types used with `await using` must implement <xref:System.IAsyncDisposable> or provide a suitable `DisposeAsync` method.

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

To correct this error, remove the `await using` keywords, or implement a suitable `DisposeAsync` method.

### Mismatched disposal pattern (CS8417, CS8418)

These errors occur when you use the wrong disposal keyword for a type. CS8417 occurs when you use `await using` with a type that only implements <xref:System.IDisposable> (not <xref:System.IAsyncDisposable>). CS8418 occurs when you use synchronous `using` with a type that only implements <xref:System.IAsyncDisposable> (not <xref:System.IDisposable>).

The following example generates CS8417:

```csharp
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        // error CS8417: type implements IDisposable, not IAsyncDisposable
        await using var example = new Example();
    }
}

class Example : IDisposable
{
    public void Dispose() { }
}
```

The following example generates CS8418:

```csharp
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        // error CS8418: type implements IAsyncDisposable, not IDisposable
        using var example = new Example();
    }
}

class Example : IAsyncDisposable
{
    public ValueTask DisposeAsync() => ValueTask.CompletedTask;
}
```

To correct these errors, use the appropriate disposal pattern:
- Use synchronous `using` for types that implement <xref:System.IDisposable>
- Use `await using` for types that implement <xref:System.IAsyncDisposable>
- If both patterns are needed, implement both interfaces

For more information, see [Finalizers](../../programming-guide/classes-and-structs/finalizers.md), [Implement a Dispose method](../../../standard/garbage-collection/implementing-dispose.md), and [Implement a DisposeAsync method](../../../standard/garbage-collection/implementing-disposeasync.md).

## Using variable scope and control flow

The following compiler errors and warnings relate to incorrect usage of `using` variables within control flow statements:

- CS0728
- CS8647
- CS8648
- CS8649

Variables declared with `using` have specific scoping rules that prevent resource leaks. The compiler enforces these rules to ensure proper disposal.

### Assignment to using variable (CS0728)

This warning indicates that you assigned a new value to a variable that is the resource in a `using` statement. The dispose call will occur on the original value, not the newly assigned value, which can lead to resource leaks.

The following example generates CS0728:

```csharp
using System;

public class ValidBase : IDisposable
{
    public void Dispose() { }
}

public class Program
{
    public static void Main()
    {
        ValidBase vb = null;
        using (vb)
        {
            vb = new ValidBase();  // CS0728: assignment to using variable
        }
        // The Dispose call happens on null, not on the newly created ValidBase object
    }
}
```

To correct this error, initialize the resource in the `using` statement declaration:

```csharp
using (ValidBase vb = new ValidBase())
{
    // Use vb
}
```

Or with a `using` declaration:

```csharp
using ValidBase vb = new ValidBase();
// Use vb
```

### Using variable in switch section (CS8647)

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

### Goto statements and using declarations (CS8648, CS8649)

You can't use `goto` statements to jump over `using` declarations. The `using` declaration creates a resource that must be properly disposed, and jumping over it would skip proper resource management.

The following example generates CS8648 when jumping forward over a `using` declaration:

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

The following example generates CS8649 when jumping backward to a location before a `using` declaration:

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

To correct these errors, restructure your code to avoid jumping over `using` declarations:
- Remove the `goto` statement and use structured control flow like loops
- Move the `using` declaration before jump labels or to a separate scope
- Restructure the logic to avoid jumps across resource declarations

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
