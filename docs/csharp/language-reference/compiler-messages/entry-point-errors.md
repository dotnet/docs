---
title: Resolve errors related to constructor declarations
description: These compiler errors and warnings indicate violations when declaring constructors in classes or structs, including records. This article provides guidance on resolving those errors.
f1_keywords:
 - "CS0028"
 - "CS0402"
 - "CS1555"
 - "CS1556"
 - "CS1557"
 - "CS1558"
 - "CS1559"
 - "CS5001"
 - "CS8802"
 - "CS8803"
 - "CS8937"
helpviewer_keywords:
 - "CS0028"
 - "CS0402"
 - "CS1555"
 - "CS1556"
 - "CS1557"
 - "CS1558"
 - "CS1559"
 - "CS5001"
 - "CS8802"
 - "CS8803"
 - "CS8937"
ms.date: 03/23/2026
---
# Resolve errors and warnings related to a program entry poin

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0028**](#wrong-signature-for-entry-point): *'function declaration' has the wrong signature to be an entry point*
- [**CS0402**](#generic-entry-point): *'identifier': an entry point cannot be generic or in a generic type*
- [**CS1555**](#startup-object-not-found): *Could not find 'class' specified for Main method*
- [**CS1556**](#startup-object-not-valid): *'construct' specified for Main method must be a valid class or struct*
- [**CS1557**](#startup-object-in-different-output): *Cannot use 'class' for Main method because it is in a different output file*
- [**CS1558**](#no-suitable-main-method): *'class' does not have a suitable static Main method*
- [**CS1559**](#startup-object-is-imported): *Cannot use 'object' for Main method because it is imported*
- [**CS5001**](#no-static-main-method): *Program does not contain a static 'Main' method suitable for an entry point*
- [**CS8802**](#multiple-top-level-statements): *Only one compilation unit can have top-level statements.*
- [**CS8803**](#top-level-statements-order): *Top-level statements must precede namespace and type declarations.*
- [**CS8937**](#static-constructors): *At least one top-level statement must be non-empty.*

## Wrong signature for entry point

- **CS0028**: *'function declaration' has the wrong signature to be an entry point*

The method declaration for `Main` was invalid: it was declared with an invalid signature. `Main` must be declared as static and it must return either [int](../builtin-types/integral-numeric-types.md) or [void](../builtin-types/void.md). For more information, see [Main() and Command-Line Arguments](../../fundamentals/program-structure/main-command-line.md).

[!INCLUDE[csharp-build-only-diagnostic-note](~/includes/csharp-build-only-diagnostic-note.md)]

The following sample generates CS0028:

```csharp
// CS0028.cs
// compile with: /W:4 /warnaserror
public class a
{
    public static double Main(int i)   // CS0028
    // Try the following line instead:
    // public static void Main()
    {
    }
}
```

## Generic entry point

- **CS0402**: *'identifier': an entry point cannot be generic or in a generic type*

The entry point was found in a generic type. To remove this warning, implement Main in a non-generic class or struct.

[!INCLUDE[csharp-build-only-diagnostic-note](~/includes/csharp-build-only-diagnostic-note.md)]

```csharp
// CS0402.cs
// compile with: /W:4
class C<T>
{
   public static void Main()  // CS0402
   {

   }
}

class CMain
{
   public static void Main() {}
}
```

## Startup object not found

- **CS1555**: *Could not find 'class' specified for Main method*

A class was specified to the [**StartupObject**](../compiler-options/advanced.md#startupobject) compiler option, but the class name was not found in the source code.

[!INCLUDE[csharp-build-only-diagnostic-note](~/includes/csharp-build-only-diagnostic-note.md)]

## Startup object not valid

- **CS1556**: *'construct' specified for Main method must be a valid class or struct*

The [**StartupObject**](../compiler-options/advanced.md#startupobject) compiler option was passed an identifier that was not a class name.

[!INCLUDE[csharp-build-only-diagnostic-note](~/includes/csharp-build-only-diagnostic-note.md)]

## Startup object in different output

- **CS1557**: *Cannot use 'class' for Main method because it is in a different output file*

The [**StartupObject**](../compiler-options/advanced.md#startupobject) compiler option was specified for one output file in a multi-output file compilation. However, the class was not found in the source code for the /main compilation; it was found in a source code file for one of the other output files in the compilation.

## No suitable Main method

- **CS1558**: *'class' does not have a suitable static Main method*

The [**StartupObject**](../compiler-options/advanced.md#startupobject) compiler option specified a class in which to look for a **Main** method. However, the [Main](../../fundamentals/program-structure/main-command-line.md) method was not defined correctly.

[!INCLUDE[csharp-build-only-diagnostic-note](~/includes/csharp-build-only-diagnostic-note.md)]

The following example generates CS1558 because of invalid return type.

```csharp
// CS1558.cs
// compile with: /main:MyNamespace.MyClass

namespace MyNamespace
{
   public class MyClass
   {
      public static float Main()
      {
         return 0.0; // CS1558 because the return type is a float.
      }
   }
}
```

## Startup object is imported

- **CS1559**: *Cannot use 'object' for Main method because it is imported*

An invalid class was specified to the [**StartupObject**](../compiler-options/advanced.md#startupobject) compiler option; the class cannot be used as a location for the [Main](../../fundamentals/program-structure/main-command-line.md) method.

## No static Main method

- **CS5001**: *Program does not contain a static 'Main' method suitable for an entry point*

This error occurs when no static `Main` method with a correct signature is found in the code that produces an executable file. It also occurs if the entry point function, `Main`, is defined with the wrong case, such as lower-case `main`. For information about the rules that apply to the `Main` method, see [Main() and Command-Line Arguments](../../fundamentals/program-structure/main-command-line.md).

[!INCLUDE[csharp-build-only-diagnostic-note](~/includes/csharp-build-only-diagnostic-note.md)]

If the `Main` method has an `async` modifier, make sure that the [selected C# language version](../configure-language-version.md) is 7.1 or higher and to use `Task` or `Task<int>` as the return type.

The `Main` method is only required when compiling an executable file, that is, when the **exe** or **winexe** element of the [**OutputType**](../compiler-options/output.md#outputtype) compiler option is specified. The following Visual Studio project types specify one of these options by default:

- Console application
- ASP.NET Core application
- WPF application
- Windows Forms application

The following example generates CS5001:

```csharp
// CS5001.cs
// CS5001 expected when compiled with -target:exe or -target:winexe
public class Program
{
   // Uncomment the following line to resolve.
   // static void Main() {}
}
```

## Multiple top-level statements

- **CS8802**: *Only one compilation unit can have top-level statements.*

This error indicates that there are two or more [top-level statements](../../fundamentals/program-structure/top-level-statements.md) in a single compilation unit (single project or a single group of files compiled into a single binary file).

The following sample of single compilation unit generates CS8802:

```xml
<!-- SingleCompilationUnit.csproj -->
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
</Project>
```

```csharp
// EntryFile.cs

int a = 0;
```

```csharp
// SecondaryEntryFile.cs

int b = 1;    // CS8802: The top level statement already exists in EntryFile.cs
```

To correct this error, use only one top-level statement in the project. Top-level statements act as an entry point to the program, so only one file can have top-level statements. All other statements must be defined as members of classes or structs.

## Top-level statements order

- **CS8803**: *Top-level statements must precede namespace and type declarations.*

The following sample generates CS8803:

```csharp
// CS8803.cs (0,0)

public record Person
{
    public string? GivenName { get; set; }
    public string? FamilyName { get; set; }
}

int i = 0;
```

In a file with top-level statements, top-level statements must occur prior to any type declarations.

To correct this error, move the code before the namespace declaration:

```csharp

int i = 0;

public record Person
{
    public string? GivenName { get; set; }
    public string? FamilyName { get; set; }
}
```

It is common that types are declared within their own file, which would also correct this error by separating the type declaration from the top-level statements.

## Invalid top level statements

- **CS8937**: *At least one top-level statement must be non-empty.*

To correct these errors, ensure your static constructor declaration follows these rules:

- Add an executable statement to your app. (**CS8937**)
