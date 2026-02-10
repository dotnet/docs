---
title: "Resolve compiler errors and warnings related to using directives and using alias directives"
description: "These errors and warnings indicate problems with using directives and using directive aliases. This information helps diagnose and fix those issues."
ms.date: 02/10/2026
f1_keywords:
  - "CS0104"
  - "CS0105"
  - "CS0116"
  - "CS0138"
  - "CS0430"
  - "CS0431"
  - "CS0432"
  - "CS0434"
  - "CS0435"
  - "CS0436"
  - "CS0437"
  - "CS0438"
  - "CS0439"
  - "CS0440"
  - "CS0518"
  - "CS0576"
  - "CS0687"
  - "CS1022"
  - "CS1529"
  - "CS1537"
  - "CS1671"
  - "CS1679"
  - "CS1680"
  - "CS1681"
  - "CS1730"
  - "CS2034"
  - "CS7000"
  - "CS7007"
  - "CS7015"
  - "CS7021"
  - "CS8019"
  - "CS8020"
  - "CS8083"
  - "CS8085"
  - "CS8914"
  - "CS8915"
  - "CS8933"
  - "CS8954"
  - "CS8955"
  - "CS8956"
  - "CS9130"
  - "CS9131"
  - "CS9132"
  - "CS9133"
  - "CS9162"
helpviewer_keywords:
  - "CS0104"
  - "CS0105"
  - "CS0116"
  - "CS0138"
  - "CS0430"
  - "CS0431"
  - "CS0432"
  - "CS0434"
  - "CS0435"
  - "CS0436"
  - "CS0437"
  - "CS0438"
  - "CS0439"
  - "CS0440"
  - "CS0518"
  - "CS0576"
  - "CS0687"
  - "CS1022"
  - "CS1529"
  - "CS1537"
  - "CS1671"
  - "CS1679"
  - "CS1680"
  - "CS1681"
  - "CS1730"
  - "CS2034"
  - "CS7000"
  - "CS7007"
  - "CS7015"
  - "CS7021"
  - "CS8019"
  - "CS8020"
  - "CS8083"
  - "CS8085"
  - "CS8914"
  - "CS8915"
  - "CS8933"
  - "CS8954"
  - "CS8955"
  - "CS8956"
  - "CS9130"
  - "CS9131"
  - "CS9132"
  - "CS9133"
  - "CS9162"
---
# Resolve warnings related to using and declaring namespaces

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0104**](#cs0104): *Error: 'reference' is an ambiguous reference between 'identifier' and 'identifier'.*
- [**CS0116**](#cs0116): *Error: A namespace cannot directly contain members such as fields, methods or statements.*
- [**CS0138**](#using-static-directive): *Error: A using namespace directive can only be applied to namespaces; 'type' is a type not a namespace.*
- [**CS0430**](#using-directive): *Error: The extern alias 'alias' was not specified in a /reference option.*
- [**CS0431**](#alias-qualifier): *Error: Cannot use alias 'identifier' with `::` since the alias references a type. Use `.` instead*.
- [**CS0432**](#alias-qualifier): *Error: Alias 'identifier' not found.*
- [**CS0434**](#cs0434): *Error: The namespace NamespaceName1 in NamespaceName2 conflicts with the type TypeName1 in NamespaceName3.*
- [**CS0438**](#cs0438): *Error: The type 'type' in 'module_1' conflicts with the namespace 'namespace' in 'module_2'.*
- [**CS0439**](#using-directive): *Error: An extern alias declaration must precede all other elements defined in the namespace.*
- [**CS0518**](#cs0518): *Error: Predefined type 'type' is not defined or imported.*
- [**CS0576**](#using-alias-restrictions): *Error: Namespace 'namespace' contains a definition conflicting with alias 'identifier'.*
- [**CS0687**](#alias-qualifier): *Error: The namespace alias qualifier `::` always resolves to a type or namespace so is illegal here. Consider using `.` instead.*
- [**CS1529**](#using-directive): *Error: A using clause must precede all other elements defined in the namespace except extern alias declarations.*
- [**CS1537**](#using-alias-restrictions): *Error: The using alias 'alias' appeared previously in this namespace.*
- [**CS1671**](#file-scoped-namespace): *Error: A namespace declaration cannot have modifiers or attributes.*
- [**CS1679**](#using-directive): *Error: Invalid extern alias for '/reference'; 'identifier' is not a valid identifier.*
- [**CS1680**](#using-directive): *Error: Invalid reference alias option: 'alias=' -- missing filename.*
- [**CS1681**](#using-directive): *Error: You cannot redefine the global extern alias.*
- [**CS1730**](#using-directive): *Error: Assembly and module attributes must precede all other elements defined in a file except using clauses and extern alias declarations.*
- [**CS2034**](#using-directive): *Error: A /reference option that declares an extern alias can only have one filename. To specify multiple aliases or filenames, use multiple /reference options.*
- [**CS7000**](#alias-qualifier): *Error: Unexpected use of an aliased name.*
- [**CS7007**](#using-static-directive): *Error: A `using static` directive can only be applied to types. Consider a `using namespace` directive instead*
- [**CS7015**](#using-directive): *Error: 'extern alias' is not valid in this context.*
- [**CS8083**](#alias-qualifier): *Error: An alias-qualified name is not an expression.*
- [**CS8085**](#using-alias-restrictions): *Error: A 'using static' directive cannot be used to declare an alias.*
- [**CS8914**](#global-using-directive): *Error: A global using directive cannot be used in a namespace declaration.*
- [**CS8915**](#global-using-directive): *Error: A global using directive must precede all non-global using directives.*
- [**CS8954**](#file-scoped-namespace): *Error: Source file can only contain one file-scoped namespace declaration.*
- [**CS8955**](#file-scoped-namespace): *Error: Source file can not contain both file-scoped and normal namespace declarations.*
- [**CS8956**](#file-scoped-namespace): *Error: File-scoped namespace must precede all other members in a file.*
- [**CS1022**](#cs1022): *Error: Type or namespace definition, or end-of-file expected.*
- [**CS7021**](#cs7021): *Error: Cannot declare namespace in script code.*
- [**CS9130**](#using-alias-restrictions): *Error: Using alias cannot be a `ref` type.*
- [**CS9131**](#using-alias-restrictions): *Error: Only a using alias can be `unsafe`.*
- [**CS9132**](#using-alias-restrictions): *Error: Using alias cannot be a nullable reference type.*
- [**CS9133**](#using-static-directive): *Error: `static` modifier must precede `unsafe` modifier.*
- [**CS9162**](#using-static-directive): *Type is not valid for 'using static'. Only a class, struct, interface, enum, delegate, or namespace can be used.*

And the following compiler warnings:

- [**CS0105**](#using-directive): *Warning: The using directive for 'namespace' appeared previously in this namespace.*
- [**CS0440**](#alias-qualifier): *Warning: Defining an alias named `global` is ill-advised since `global::` always references the global namespace and not an alias.*
- [**CS0435**](#cs0435): *Warning: The namespace 'namespace' in 'assembly' conflicts with the imported type 'type' in 'assembly'. Using the namespace defined in 'assembly'.*
- [**CS0436**](#cs0436): *Warning: The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.*
- [**CS0437**](#cs0437): *Warning: The type 'type' in 'assembly2' conflicts with the imported namespace 'namespace' in 'assembly1'. Using the type defined in 'assembly'.*
- [**CS8019**](#using-directive): *Info: Unnecessary using directive.*
- [**CS8020**](#using-directive): *Info: Unused extern alias.*
- [**CS8933**](#using-directive): *Info: The using directive appeared previously as global using.*

These errors and warnings indicate your `using` directive isn't formed correctly. The following sections cover these errors and how to correct them.

## Using directive

The following errors relate to `using` directives:

- **CS0105**: *The using directive for 'namespace' appeared previously in this namespace.*
- **CS0430**: *The extern alias 'alias' was not specified in a /reference option.*
- **CS0439**: *An extern alias declaration must precede all other elements defined in the namespace.*
- **CS1529**: *A using clause must precede all other elements defined in the namespace except extern alias declarations.*
- **CS1679**: *Invalid extern alias for '/reference'; 'identifier' is not a valid identifier.*
- **CS1680**: *Invalid reference alias option: 'alias=' -- missing filename.*
- **CS1681**: *You cannot redefine the global extern alias.*
- **CS1730**: *Assembly and module attributes must precede all other elements defined in a file except using clauses and extern alias declarations.*
- **CS2034**: *A /reference option that declares an extern alias can only have one filename. To specify multiple aliases or filenames, use multiple /reference options.*
- **CS7015**: *'extern alias' is not valid in this context.*
- **CS8019**: *Unnecessary using directive.*
- **CS8020**: *Unused extern alias.*
- **CS8933**: *The using directive appeared previously as global using.*

See the [using directive](../keywords/using-directive.md) and [extern alias](../keywords/extern-alias.md) language reference for usage rules.

Move all `using` directives to the top of the file, or to the top of the namespace declaration, because the C# language requires `using` directives to come before other elements in a namespace (**CS1529**). Move all `extern alias` declarations before any `using` directives, because the language requires extern aliases to come before all other elements including `using` directives (**CS0439**, **CS7015**). Move all assembly and module level attributes after `using` clauses and `extern alias` declarations but before any type declarations, because attributes must follow directives but precede types (**CS1730**).

Ensure that every `extern alias` declaration in your source code has a corresponding alias defined in your project's [reference options](../compiler-options/inputs.md#references), because the compiler can't resolve an alias that wasn't specified (**CS0430**). Use a separate `/reference` option for each extern alias rather than combining multiple aliases in a single option, because the compiler requires one alias per reference option (**CS2034**). Ensure the alias in your `/reference` option is a valid C# identifier, because the alias must follow identifier naming rules (**CS1679**). Include a filename after the `=` sign in your alias reference option, because the compiler needs to know which assembly the alias refers to (**CS1680**). Don't attempt to redefine the `global` extern alias, because `global` is a predefined alias that refers to all unaliased references (**CS1681**).

Remove duplicate `using` directives, because the compiler warns when the same namespace is imported multiple times (**CS0105**, **CS8019**, **CS8933**). Remove unused `extern alias` declarations, because the compiler issues a diagnostic when an extern alias is declared but never referenced in your code (**CS8020**).

## Using static directive

The following errors relate to `using static` directives:

- **CS0138**: *A using namespace directive can only be applied to namespaces; 'type' is a type not a namespace.*
- **CS7007**: *A `using static` directive can only be applied to types. Consider a `using namespace` directive instead.*
- **CS9133**: *`static` modifier must precede `unsafe` modifier.*
- **CS9162**: *Type is not valid for 'using static'. Only a class, struct, interface, enum, delegate, or namespace can be used.*

See the [using static directive](../keywords/using-directive.md#the-static-modifier) language reference for usage rules.

Add the `static` modifier when importing a type's members directly, because omitting `static` tells the compiler you're importing a namespace rather than a type (**CS0138**). Remove the `static` modifier when importing a namespace, because `using static` can only be applied to types, not namespaces (**CS7007**). Ensure the target of a `using static` directive is a class, struct, interface, enum, or delegate, because other types aren't valid targets for static imports (**CS9162**). Place the `static` modifier before the `unsafe` modifier when combining both, because the language requires modifiers in a specific order (**CS9133**).

## Global using directive

The following errors relate to `global using` directives:

- **CS8914**: *A global using directive cannot be used in a namespace declaration.*
- **CS8915**: *A global using directive must precede all non-global using directives.*

See the [global using directive](../keywords/using-directive.md#the-global-modifier) language reference for usage rules.

Move `global using` directives outside of any namespace declaration to file scope, because global usings apply project-wide and can't be scoped to a namespace (**CS8914**). Place all `global using` directives before any non-global `using` directives in the file, because the language requires global directives to precede local ones (**CS8915**). Note that a `static global using` directive can't reference a [file-local](../keywords/file.md) type.

## File-scoped namespace

The following errors relate to file-scoped namespaces:

- **CS1671**: *A namespace declaration cannot have modifiers or attributes.*
- **CS8954**: *Source file can only contain one file-scoped namespace declaration.*
- **CS8955**: *Source file can not contain both file-scoped and normal namespace declarations.*
- **CS8956**: *File-scoped namespace must precede all other members in a file.*

See the [file-scoped namespace](../keywords/namespace.md) language reference for usage rules.

Use only one file-scoped namespace declaration per file, because the language allows only a single file-scoped namespace to set the namespace for all types in a file (**CS8954**). Choose either file-scoped or block-scoped namespace declarations within a single file, because the language doesn't allow mixing both styles (**CS8955**). Move the file-scoped namespace declaration before any type declarations, because the namespace must be established before types are declared (**CS8956**). Remove any access modifiers or attributes from namespace declarations, because namespaces can't have modifiers or attributes applied to them (**CS1671**).

## Alias qualifier

The following errors relate to the alias qualifier:

- **CS0431**: *Cannot use alias 'identifier' with `::` since the alias references a type. Use `.` instead.*
- **CS0432**: *Alias 'identifier' not found.*
- **CS0440**: *Defining an alias named `global` is ill-advised since `global::` always references the global namespace and not an alias.*
- **CS0687**: *The namespace alias qualifier `::` always resolves to a type or namespace so is illegal here. Consider using `.` instead.*
- **CS7000**: *Unexpected use of an aliased name.*
- **CS8083**: *An alias-qualified name is not an expression.*

See the [namespace alias qualifier](../operators/namespace-alias-qualifier.md) language reference for usage rules.

Replace the `::` operator with the `.` operator when you access members of a type alias, because the `::` qualifier is only valid for namespace aliases, not type aliases (**CS0431**, **CS0687**). Ensure the alias you're referencing is declared by using a `using` directive or `extern alias`, because the compiler can't resolve an undefined alias (**CS0432**). Use the alias qualifier only in contexts where a type or namespace name is expected, because alias-qualified names aren't valid as expressions (**CS7000**, **CS8083**). Choose a different name for your alias instead of `global`, because `global` is reserved to refer to the global namespace and can't be redefined (**CS0440**).

## Using alias restrictions

The following errors relate to restrictions on using aliases:

- **CS0576**: *Namespace 'namespace' contains a definition conflicting with alias 'identifier'.*
- **CS1537**: *The using alias 'alias' appeared previously in this namespace.*
- **CS8085**: *A 'using static' directive cannot be used to declare an alias.*
- **CS9130**: *Using alias cannot be a `ref` type.*
- **CS9131**: *Only a using alias can be `unsafe`.*
- **CS9132**: *Using alias cannot be a nullable reference type.*

See the [using alias](../keywords/using-directive.md#the-using-alias) language reference for usage rules.

Choose a unique name for your alias that doesn't conflict with existing type or namespace names in scope, because the compiler can't distinguish between the alias and the existing definition (**CS0576**). Use each alias name only once within a namespace, because duplicate alias declarations create ambiguity (**CS1537**). Remove the `static` modifier when declaring an alias, because aliases and static imports are mutually exclusive - use either `using static` to import members or `using Alias =` to create an alias, but not both together (**CS8085**).

Starting with C# 12, the following restrictions apply to using aliases: Don't use `ref`, `in`, or `out` modifiers in a using alias, because these parameter modifiers aren't valid in type alias contexts (**CS9130**). Use the `unsafe` modifier only with aliases that reference pointer types or with `using static` directives, because `unsafe` without an alias or static import isn't permitted (**CS9131**). Use a non-nullable reference type when creating an alias to a reference type, because nullable reference types can't be aliased directly (**CS9132**).

## CS0116

A namespace cannot directly contain members such as fields or methods.

A namespace can contain other namespaces, structs, and classes. For more information, see the [namespace keyword](../keywords/namespace.md) article.

### Example

The following sample will cause Visual Studio to flag parts of the code as being in violation of CS0116. Attempting to build this code will result in build failure:

```csharp
// CS0116.cs
namespace x
{
    // A namespace can be placed within another namespace.
    using System;

    // These variables trigger the CS0116 error as they are declared outside of a struct or class.
    public int latitude;
    public int longitude;
    Coordinate coord;

    // Auto-properties also fall under the definition of this rule.
    public string LocationName { get; set; }

    // This method as well: if it isn't in a class or a struct, it's violating CS0116.
    public void DisplayLatitude()
    {
        Console.WriteLine($"Lat: {latitude}");
    }

    public struct Coordinate
    {
    }

    public class CoordinatePrinter
    {
        public void DisplayLongitude()
        {
            Console.WriteLine($"Longitude: {longitude}");
        }

        public void DisplayLocation()
        {
            Console.WriteLine($"Location: {LocationName}");
        }
    }
}
```

Note that in C#, methods and variables must be declared and defined within a struct or class. For more information on program structure in C#, see the [General Structure of a C# Program](../../fundamentals/program-structure/index.md) article. To fix this error, rewrite your code such that all methods and fields are contained within either a struct or a class:

```csharp
namespace x
{
    // A namespace can be placed within another namespace.
    using System;

    // These variables are now placed within a struct, so CS0116 is no longer violated.
    public struct Coordinate
    {
        public int Latitude;
        public int Longitude;
    }

    // The methods and fields are now placed within a class, and the compiler is satisfied.
    public class CoordinatePrinter
    {
        Coordinate coord;
        public string LocationName { get; set; }

        public void DisplayLatitude()
        {
            Console.WriteLine($"Lat: {coord.Latitude}");
        }

        public void DisplayLongitude()
        {
            Console.WriteLine($"Longitude: {coord.Longitude}");
        }

        public void DisplayLocation()
        {
            Console.WriteLine($"Location: {LocationName}");
        }
    }
}
```

## CS0518

Predefined type 'type' is not defined or imported.

> [!NOTE]
> The resolution for this error depends on whether you're using a modern SDK-style project (`.csproj` files that start with `<Project Sdk="Microsoft.NET.Sdk">`) or legacy project formats. SDK-style projects manage runtime references automatically through the `<TargetFramework>` property.

The main cause for this problem is that the project cannot access the predefined types from the .NET runtime library. In modern SDK-style projects, this is typically due to an incorrect or missing `<TargetFramework>` specification. In legacy projects, this issue is caused by not importing mscorlib.dll, which defines the entire <xref:System> namespace. This can be caused by one of the following:

[!INCLUDE[csharp-build-only-diagnostic-note](~/includes/csharp-build-only-diagnostic-note.md)]

- The [**NoStandardLib**](../compiler-options/advanced.md#nostandardlib) option from the command line compiler has been specified. The **NoStandardLib** option prevents the import of mscorlib.dll. Use this option if you want to define or create a user-specific System namespace.

- An incorrect mscorlib.dll is referenced.

- A corrupt Visual Studio .NET or .NET Framework common language runtime installation exists.

- Residual components from an earlier installation that are incompatible with the latest installation remain.

To resolve this problem, take one of the following actions:

- Do not specify the /nostdlib option from the command line compiler.

- For modern SDK-style projects, ensure the project targets the correct .NET runtime. In your `.csproj` file, verify the `<TargetFramework>` property specifies the intended runtime:

  ```xml
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
  ```

  For multi-targeting projects, use `<TargetFrameworks>` (plural):

  ```xml
  <PropertyGroup>
    <TargetFrameworks>net8.0;net48</TargetFrameworks>
  </PropertyGroup>
  ```

- For legacy project formats, make sure that the project refers to the correct mscorlib.dll.

- Reinstall the .NET Framework common language runtime (if the previous solutions do not solve the problem).

- Reload the project in Visual Studio.

- Close Visual Studio, delete the `obj` and `bin` folders from your project directory, then reopen Visual Studio and rebuild the project.

## CS0104

'reference' is an ambiguous reference between 'identifier' and 'identifier'.

Your program contains [using](../keywords/using-directive.md) directives for two namespaces and your code references a name that appears in both namespaces.

The following sample generates CS0104:

```csharp
// CS0104.cs
using x;
using y;

namespace x
{
   public class Test
   {
   }
}

namespace y
{
   public class Test
   {
   }
}

public class a
{
   public static void Main()
   {
      Test test = new Test();   // CS0104, is Test in x or y namespace?
      // try the following line instead
      // y.Test test = new y.Test();
   }
}
```

## CS0434

The namespace NamespaceName1 in NamespaceName2 conflicts with the type TypeName1 in NamespaceName3.

This error occurs when an imported type and an imported nested namespace have the same fully qualified name. When that name is referenced, the compiler is unable to distinguish between the two. If you can change the imported source code, you can resolve the error by changing the name of either the type or the namespace so that both are unique within the assembly.

The following code generates error CS0434.

### Example 1

This code creates the first copy of the type with the identical fully qualified name.

```csharp
// CS0434_1.cs
// compile with: /t:library
namespace TypeBindConflicts
{
    namespace NsImpAggPubImp
    {
        public class X { }
    }
}
```

### Example 2

This code creates the second copy of the type with the identical fully qualified name.

```csharp
// CS0434_2.cs
// compile with: /t:library
namespace TypeBindConflicts {
    // Conflicts with another import (import2.cs).
    public class NsImpAggPubImp { }
    // Try this instead:
    // public class UniqueClassName { }
}
```

### Example 3

This code references the type with the identical fully qualified name.

```csharp
// CS0434.cs
// compile with: /r:cs0434_1.dll /r:cs0434_2.dll
using TypeBindConflicts;
public class Test
{
    public TypeBindConflicts.NsImpAggPubImp.X n2 = null; // CS0434
}
```

## CS0435

The namespace 'namespace' in 'assembly' conflicts with the imported type 'type' in 'assembly'. Using the namespace defined in 'assembly'.

This warning is issued when a namespace in a source file (file_2) conflicts with an imported type in file_1. The compiler uses the one in the source file.

The following example generates CS0435:

Compile this file first:

```csharp
// CS0435_1.cs
// compile with: /t:library
public class Util
{
   public class A { }
}
```

Then, compile this file:

```csharp
// CS0435_2.cs
// compile with: /r:CS0435_1.dll

using System;

namespace Util
{
   public class A { }
}

public class Test
{
   public static void Main()
   {
      Console.WriteLine(typeof(Util.A)); // CS0435
   }
}
```

## CS0436

The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.

This warning occurs when a type defined in your source code has the same fully qualified name (namespace and type name) as a type imported from a referenced assembly. When this name conflict occurs, the compiler uses the locally defined type from your source file and ignores the imported type.

### What constitutes a conflict

A conflict occurs when two types have identical fully qualified names, meaning:

- They have the same namespace
- They have the same type name
- They're both accessible in the current compilation context

The conflict is determined solely by the type's fully qualified name, not by its implementation details. Two types with the same name but different implementations (such as different methods, properties, or field values) still conflict. The compiler can't use both types simultaneously because they have the same identity.

### Example

The following example demonstrates CS0436. In this scenario, a type `A` is defined in an external library and also locally in the source file. Even though the two types have different implementations (they print different strings), they conflict because they share the same fully qualified name.

First, create a library that defines type `A`:

```csharp
// CS0436_a.cs
// compile with: /target:library
public class A {
   public void Test() {
      System.Console.WriteLine("CS0436_a");
   }
}
```

Then, compile the following code that defines another type `A` and references the library. The compiler issues CS0436 because both types have the fully qualified name `A` (in the global namespace):

```csharp
// CS0436_b.cs
// compile with: /reference:CS0436_a.dll
// CS0436 expected
public class A {
   public void Test() {
      System.Console.WriteLine("CS0436_b");
   }
}

public class Test
{
   public static void Main()
   {
      A x = new A();
      x.Test();
   }
}
```

When you compile and run this code, the compiler uses the locally defined `A` (from CS0436_b.cs) and issues a warning. The output is:

```console
CS0436_b
```

Note that the conflict exists even though the two `A` types have different implementations. The difference in the string literal (`"CS0436_a"` versus `"CS0436_b"`) doesn't prevent the conflict. What matters is that both types have the same fully qualified name `A`.

### How to resolve this warning

To resolve this warning, you can:

1. Rename one of the conflicting types.
1. Use a different namespace for one of the types.
1. Remove the reference to the assembly containing the conflicting type if it's not needed.
1. Use an extern alias to disambiguate between the two types if you need to use both (see [CS0433](../language-reference/compiler-messages/cs0433.md) for examples of using extern aliases).

## CS0437

The type 'type' in 'assembly2' conflicts with the imported namespace 'namespace' in 'assembly1'. Using the type defined in 'assembly'.

This warning is issued when a type in a source file, file_2, conflicts with an imported namespace in file_1. The compiler uses the type in the source file.

### Example 1

```csharp
// CS0437_a.cs
// compile with: /target:library
namespace Util
{
   public class A {
      public void Test() {
         System.Console.WriteLine("CS0437_a.cs");
      }
   }
}
```

### Example 2

The following sample generates CS0437.

```csharp
// CS0437_b.cs
// compile with: /reference:CS0437_a.dll /W:2
// CS0437 expected
class Util
{
   public class A {
      public void Test() {
         System.Console.WriteLine("CS0437_b.cs");
      }
   }
}

public class Test
{
   public static void Main()
   {
      Util.A x = new Util.A();
      x.Test();
   }
}
```

## CS0438

The type 'type' in 'module_1' conflicts with the namespace 'namespace' in 'module_2'.

This error occurs when a type in a source file conflicts with a namespace in another source file. This typically happens when one or both come from an added module. To resolve, rename the type or the namespace that caused the conflict.

The following example generates CS0438:

Compile this file first:

```csharp
// CS0438_1.cs
// compile with: /target:module
public class Util
{
   public class A { }
}
```

Then compile this file:

```csharp
// CS0438_2.cs
// compile with: /target:module
namespace Util
{
   public class A { }
}
```

And then compile this file:

```csharp
// CS0438_3.cs
// compile with: /addmodule:CS0438_1.netmodule /addmodule:CS0438_2.netmodule
using System;
public class Test
{
   public static void Main() {
      Console.WriteLine(typeof(Util.A));   // CS0438
   }
}
```

## CS1022

Type or namespace definition, or end-of-file expected.

A source-code file does not have a matching set of braces.

The following sample generates CS1022:

```csharp
// CS1022.cs
namespace x
{
}
}   // CS1022
```

## CS7021

You can't declare a namespace in script code.

C# script files (`.csx`) don't support namespace declarations. All code in a script file is evaluated in a single execution context. If you need to organize code into namespaces, move it into a regular C# source file (`.cs`).
