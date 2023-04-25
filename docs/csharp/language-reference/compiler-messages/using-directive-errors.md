---
title: "Resolve compiler errors and warnings related to using directives and using alias directives"
description: "These errors and warnings indicate problems with using directives and using directive aliases. This information will help diagnose and fix those issues."
ms.date: 04/25/2023
f1_keywords:
  - "CS0105"
  - "CS0138"
  - "CS0431"
  - "CS0432"
  - "CS0440"
  - "CS0576"
  - "CS0687"
  - "CS1529"
  - "CS1537"
  - "CS7000"
  - "CS7007"
  - "CS8019"
  - "CS8083"
  - "CS8085"
  - "CS8914"
  - "CS8915"
  - "CS8933"
  - "CS9055"
  - "CS9130"
  - "CS9131"
  - "CS9132"
  - "CS9133"
helpviewer_keywords: 
  - "CS0105"
  - "CS0138"
  - "CS0431"
  - "CS0432"
  - "CS0440"
  - "CS0576"
  - "CS0687"
  - "CS1529"
  - "CS1537"
  - "CS7000"
  - "CS7007"
  - "CS8019"
  - "CS8083"
  - "CS8085"
  - "CS8914"
  - "CS8915"
  - "CS8933"
  - "CS9055"
  - "CS9130"
  - "CS9131"
  - "CS9132"
  - "CS9133"
---
# Resolve warnings related using namespaces

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's be design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0138**](#using-static-directive) - *Error: A using namespace directive can only be applied to namespaces; 'type' is a type not a namespace.*
- [**CS0431**](#incorrect-use-of-global-qualifier) - *Error: Cannot use alias 'identifier' with `::` since the alias references a type. Use `.` instead*.
- [**CS0432**](#incorrect-use-of-global-qualifier) - *Error: Alias 'identifier' not found.*
- [**CS0576**](#alias-name-conflicts) - *Error: Namespace 'namespace' contains a definition conflicting with alias 'identifier'.*
- [**CS0687**](#incorrect-use-of-global-qualifier) - *Error: The namespace alias qualifier `::` always resolves to a type or namespace so is illegal here. Consider using `.` instead.*
- [**CS1529**](#using-directive) - *Error: A using clause must precede all other elements defined in the namespace except extern alias declarations.*
- [**CS1537**](#alias-name-conflicts) - *Error: The using alias 'alias' appeared previously in this namespace.*
- [**CS7000**](#incorrect-use-of-global-qualifier) - *Error: Unexpected use of an aliased name.*
- [**CS7007**](#using-static-directive) - *Error: A `using static` directive can only be applied to types. Consider a `using namespace` directive instead*
- [**CS8083**](#incorrect-use-of-global-qualifier) - *Error: An alias-qualified name is not an expression.*
- [**CS8085**](#restrictions-on-using-aliases) - *Error: A 'using static' directive cannot be used to declare an alias.*
- [**CS8914**](#global-using-directive) - *Error: A global using directive cannot be used in a namespace declaration.*
- [**CS8915**](#global-using-directive) - *Error: A global using directive must precede all non-global using directives.*
- [**CS9055**](#global-using-directive) - *Error: A file-local type cannot be used in a 'global using static' directive.*
- [**CS9130**](#restrictions-on-using-aliases) - *Error: Using alias cannot be a `ref` type.*
- [**CS9131**](#restrictions-on-using-aliases) - *Error: Only a using alias can be `unsafe`.*
- [**CS9132**](#restrictions-on-using-aliases) - *Error: Using alias cannot be a nullable reference type.*
- [**CS9133**](#using-static-directive) - *Error: `static` modifier must precede `unsafe` modifier.*

And the following compiler warnings:

- [**CS0105**](#using-directive) - *Warning: The using directive for 'namespace' appeared previously in this namespace.*
- [**CS0440**](#incorrect-use-of-global-qualifier) - *Warning: Defining an alias named `global` is ill-advised since `global::` always references the global namespace and not an alias.*
- [**CS8019**](#using-directive) - *Info: Unnecessary using directive.*
- [**CS8933**](#global-using-directive) - *Info: The using directive appeared previously as global using.*

These errors and warnings indicate you're `using` directive isn't formed correctly. The sections below cover these errors and how to correct them.

## Using directive

### CS0105

A [namespace](../keywords/namespace.md), which should only be declared once, was declared more than once; remove all duplicate namespace declarations.

The following sample generates CS0105:

```csharp
// CS0105.cs
// compile with: /W:3
using System;
using System;   // CS0105

public class a
{
   public static void Main()
   {
   }
}
```

### CS1529

A [using](../keywords/using-directive.md) clause must appear first in a namespace.

The following sample generates CS1529:

```csharp
// CS1529.cs
namespace X
{
    namespace Subspace
    {
        using Microsoft;

        class SomeClass
        {
        };

        using Microsoft;      // CS1529, place before class definition
    }

    using System.Reflection;  // CS1529, place before namespace 'Subspace'
}

using System;                 // CS1529, place at the beginning of the file
```

### CS8019

The compiler provides an informational message when a `using` directive is unnecessary. This occurs when you don't use any of the types in declared in that namespace.

## Using static directive

### CS0138

A [using](../keywords/using-directive.md) directive can only take the name of a namespace as a parameter. For more information, see [Namespaces](../../fundamentals/types/namespaces.md).

The following sample generates CS0138:

```csharp
// CS0138.cs
using System.Object;   // CS0138
```

### CS9133

The `static` modifier must precede the `unsafe` modifier when you write a `using static unsafe` directive:

```csharp
using static unsafe UnsafeExamples.UnsafeType;
```

If the `unsafe` modifier appears first, the compiler issues an error.

### CS7007

The target of a `using static` isn't a type:

```csharp
using static System;
```

Consider removing the `static` modifier.

## Global using directive

### CS8914

A global using directive cannot be used in a namespace declaration.

### CS8915

A global using directive must precede all non-global using directives.

### CS9055

A `static global using` directive cannot reference a file-local type.

### CS8933

The using directive appeared previously as global using.

You can remove the using directive.

## Incorrect use of global qualifier

## CS0431

You used "::" with an alias that references a type. To resolve this error, use the "." operator.

The following sample generates CS0431:

```csharp
// CS0431.cs
using A = Outer;

public class Outer
{
   public class Inner
   {
      public static void Meth() {}
   }
}

public class MyClass
{
   public static void Main()
   {
      A::Inner.Meth();   // CS0431
      A.Inner.Meth();   // OK
   }
}
```

### CS0432

This error occurs when you use "::" to the right of an identifier that is not an alias. To resolve the error, use "." instead.

The following example generates CS0432:

```csharp
// CS0432.cs
namespace A {
    public class B {
        public static void Meth() { }
    }
}

public class Test
{
    public static void Main()
    {
        A::B.Meth();   // CS0432
       // To resolve, use the following line instead:
       // A.B.Meth();
    }
}
```

### CS0687

This error occurs if you used something which the parser interpreted as a type in an unexpected place. A type or namespace name is valid only in a member access expression, using the member access (**.**) operator. This could occur if you used the global scope operator (::) in another context.

The following sample generates CS0687:  

```csharp
// CS0687.cs

using M = Test;
using System;

public class Test
{
    public static int x = 77;

    public static void Main()
    {
        Console.WriteLine(M::x); // CS0687
        // To resolve use the following line instead:
        // Console.WriteLine(M.x);
    }
}
```

### CS7000

The following sample generates CS7000 because the alias qualifier (`::`) is not supported in a namespace declaration:

```csharp
using N = ClassLibrary1;

namespace N::A
{
    public class Goo
    {
    }
}
```

Either remove the unsupported use of the alias in the namespace declaration:

```csharp
namespace A
{
    void Goo()
    {
    }
}
```

Or, replace the alias with the fully qualified name:

```csharp
namespace ClassLibrary1.A
{
    void Goo()
    {
    }
}
```

### CS8083

You can't use the global alias qualifier in a nameof expression:

```csharp
var p = namoef("global::Program");
```

### CS0440 - Warning

This warning is issued when you define an alias named global.

The following example generates CS0440:

```csharp
// CS0440.cs
// Compile with: /W:1

using global = MyClass;   // CS0440
class MyClass
{
    static void Main()
    {
        // Note how global refers to the global namespace
        // even though it is redefined above.
        global::System.Console.WriteLine();
    }
}
```

## Alias name conflicts

### CS0576

An attempt was made to use the same namespace twice.

The following sample generates CS0576:

```csharp
// CS0576.cs
using SysIO = System.IO;
public class SysIO
{
   public void MyMethod() {}
}

public class Test
{
   public static void Main()
   {
      SysIO.Stream s;   // CS0576
   }
}
```

### CS1537

You defined a symbol twice as an alias for a namespace. A symbol can only be defined once.

The following sample generates CS1537:

```csharp
// CS1537.cs
namespace x
{
   using System;
   using Object = System.Object;
   using Object = System.Object;   // CS1537, delete this line to resolve
   using System = System;
}
```

## Restrictions on using aliases

Prior to C# 12, the language imposed these restrictions on `using` directives that create an alias for a type declaration:

- You can't create an alias with a `using static` directive:

   ```csharp
   using static con = System.Console;
   using static unsafe ip = int*;
   ```

Beginning with C# 12, these restrictions are introduced:

- You can't use the `in`, `ref`, or `out` modifiers in a using alias:

   ```csharp
   // All these are invalid
   using RefInt = ref int;
   using OutInt = out int;
   using InInt = in int;
   ```

- An `unsafe` using directive must specify an alias, or a `static using`:

   ```csharp
   // Elsewhere:
   public namespace UnsafeExamples
   {
      public unsafe static class UnsafeType
      {
          // ...
      }
   }

   // Using directives:
   using unsafe IntPointer = int*;
   using static unsafe UnsafeExamples.UnsafeType;
   using unsafe UnsafeExamples; // not allowed
   ```

- You can't create an alias to a nullable reference type:

   ```csharp
   using NullableInt = System.Int32?; // Allowed
   using NullableString = System.String?; // Not allowed
   ```

For these rules, you can't use the `using` alias feature.
