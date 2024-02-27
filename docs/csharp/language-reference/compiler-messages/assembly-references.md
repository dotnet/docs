---
title: Resolve errors for incorrect or missing assembly references
description: These compiler errors and warnings indicate incorrect or missing assembly references. These result in missing declarations for required types.
f1_keywords:
 - "CS0012"
 - "CS0234"
 - "CS0246"
 - "CS0400"
 - "CS0735"
 - "CS1068"
 - "CS1069"
 - "CS1070"
 - "CS1683"
 - "CS1704"
 - "CS1714"
 - "CS1760"
 - "CS7008"
 - "CS7068"
 - "CS7069"
 - "CS7071"
 - "CS7079"
 - "CS8090"
 - "CS8203"
helpviewer_keywords:
 - "CS0012"
 - "CS0234"
 - "CS0246"
 - "CS0400"
 - "CS0735"
 - "CS1068"
 - "CS1069"
 - "CS1070"
 - "CS1683"
 - "CS1704"
 - "CS1714"
 - "CS1760"
 - "CS7008"
 - "CS7068"
 - "CS7069"
 - "CS7071"
 - "CS7079"
 - "CS8090"
 - "CS8203"
ms.date: 02/26/2024
---
# Resolve errors and warnings related to assembly references

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0012**](#compiler-error-cs0012): *The type 'type' is defined in an assembly that is not referenced. You must add a reference to assembly 'assembly'.*
- [**CS0234**](#compiler-error-cs0234): *The type or namespace name does not exist in the namespace (are you missing an assembly reference?)*
- [**CS0246**](#compiler-error-cs0246): *The type or namespace name could not be found (are you missing a using directive or an assembly reference?)*
- [**CS0400**](#compiler-error-cs0400): *The type or namespace name could not be found in the global namespace (are you missing an assembly reference?)*
- [**CS0735**](#type-forwarding): *Invalid type specified as an argument for <xref:System.Runtime.CompilerServices.TypeForwardedToAttribute> attribute.*
- [**CS1068**](#type-forwarding): *The type name could not be found in the global namespace. This type has been forwarded to another assembly. Consider adding a reference to that assembly.*
- [**CS1069**](#type-forwarding): *The type name could not be found in the namespace. This type has been forwarded to another assembly. Consider adding a reference to that assembly.*
- [**CS1070**](#type-forwarding): *The type name could not be found. This type has been forwarded to another assembly. Consider adding a reference to that assembly.*
- [**CS1704**](#compiler-error-cs1704): *An assembly with the same simple name has already been imported. Try removing one of the references or sign them to enable side-by-side.*
- [**CS1714**](#compiler-error-cs1714-replaced-by-cs0012): *The base class or interface of this type could not be resolved or is invalid.*
- [**CS1760**](#not-found): *Multiple assemblies refer to the same metadata but only one is a linked reference (specified using /link option); consider removing one of the references.*
- [**CS7008**](#not-found): *The assembly name is reserved and cannot be used as a reference in an interactive session*
- [**CS7068**](#compiler-error-cs7068-warning-level-1-cs1683): *Reference to type claims it is defined in this assembly, but it is not defined in source or any added modules.*
- [**CS7069**](#not-found): *Reference to type claims it is defined in another assembly, but it could not be found.*
- [**CS7071**](#not-found): *Assembly reference is invalid and cannot be resolved*
- [**CS7079**](#resolve-errors-and-warnings-related-to-assembly-references): *The type is defined in a module that has not been added. You must add the module.*
- [**CS8090**](#not-found): *There is an error in a referenced assembly.*
- [**CS8203**](#not-found): *Invalid assembly name*

In addition, the following warnings are covered in this article:

- [**CS1683**](#compiler-error-cs7068-warning-level-1-cs1683) - *Reference to type 'Type Name' claims it is defined in this assembly, but it is not defined in source or any added modules*

## Type forwarding

- **CS0735**: *Invalid type specified as an argument for <xref:System.Runtime.CompilerServices.TypeForwardedToAttribute> attribute.*
- **CS1068**: *The type name could not be found in the global namespace. This type has been forwarded to another assembly. Consider adding a reference to that assembly.*
- **CS1069**: *The type name could not be found in the namespace. This type has been forwarded to another assembly. Consider adding a reference to that assembly.*
- **CS1070**: *The type name could not be found. This type has been forwarded to another assembly. Consider adding a reference to that assembly.*

This class of errors involves types that have been forwarded to a different assembly.

## Compiler Error CS0234

The type or namespace name 'name' does not exist in the namespace 'namespace' (are you missing an assembly reference?)

A type was expected. Possible causes for this error include the following:

- An assembly that contains the definition of a type was not referenced in the compilation; use [**References** (Import Metadata)](../compiler-options/inputs.md#references) to specify the assembly

- You passed a variable name to the [typeof](../operators/type-testing-and-cast.md#typeof-operator) operator.

- You tried to reference an assembly that is not part of your .NET target framework moniker (TFM). For more information, see [Troubleshooting .NET Targeting Errors](/visualstudio/msbuild/troubleshooting-dotnet-framework-targeting-errors).

If you see this error after moving code from one development machine to another, make sure that the project on the new machine has the correct references, and that the versions of the assemblies are the same as on the old machine. You can also use the Object Browser to inspect an assembly and verify whether it contains the types that you expect it to contain.

The following sample generates CS0234:

```csharp
// CS0234.cs
public class C
{
   public static void Main()
   {
      System.DateTime x = new System.DateTim();   // CS0234
      // try the following line instead
      // System.DateTime x = new System.DateTime();
   }
}
```

## Compiler Error CS0246

The type or namespace name 'type/namespace' could not be found (are you missing a using directive or an assembly reference?)

A type or namespace that is used in the program was not found. You might have forgotten to reference ([**References**](../compiler-options/inputs.md#references)) the assembly that contains the type, or you might not have added the required [using directive](../keywords/using-directive.md).  Or, there might be an issue with the assembly you are trying to reference.

The following situations cause compiler error CS0246.

Did you misspell the name of the type or namespace? Without the correct name, the compiler cannot find the definition for the type or namespace. This often occurs because the casing used in the name of the type is not correct. For example, `Dataset ds;` generates CS0246 because the s in Dataset must be capitalized.

- If the error is for a namespace name, did you add a reference ([**References**](../compiler-options/inputs.md#references)) to the assembly that contains the namespace? For example, your code might contain the directive `using Accessibility`. However, if your project does not reference the assembly Accessibility.dll, error CS0246 is reported. For more information, see [Managing references in a project](/visualstudio/ide/managing-references-in-a-project)
- If the error is for a type name, did you include the proper [using directive](../keywords/using-directive.md), or, alternatively, fully qualify the name of the type? Consider the following declaration: `DataSet ds`. To use the `DataSet` type, you need two things. First, you need a reference to the assembly that contains the definition for the `DataSet` type. Second, you need a `using` directive for the namespace where `DataSet` is located. For example, because `DataSet` is located in the **System.Data** namespace, you need the following directive at the beginning of your code: `using System.Data`.
   The `using` directive is not required. However, if you omit the directive, you must fully qualify the `DataSet` type when referring to it. Full qualification means that you specify both the namespace and the type each time you refer to the type in your code. If you omit the `using` directive in the previous example, you must write `System.Data.DataSet ds` to declare `ds` instead of `DataSet ds`.
- Did you use a variable or some other language element where a type was expected? For example, in an **is** statement, if you use a `Type` object instead of an actual type, you get error CS0246.
- Did you reference the assembly that was built against a higher framework version than the target framework of the program? Or did you reference the project that is targeting a higher framework version than the target framework of the program? For example, you work on the project that is targeting .NET Framework 4.6.1 and use the type from the project that is targeting .NET Framework 4.7.1. Then you get error CS0246.
- Are all referenced projects included in the selected build configuration and platform? Use the Visual Studio Configuration Manager to make sure all referenced projects are marked to be built with the selected configuration and platform.
- Did you use a *using alias directive* without fully qualifying the type name? A `using` alias directive does not use the `using` directives in the source code file to resolve types. The following example generates CS0246 because the type `List<int>` is not fully qualified. The `using` directive for `System.Collections.Generic` does not prevent the error.

   ```csharp
   using System.Collections.Generic;

   // The following declaration generates CS0246.
   using myAliasName = List<int>;

   // To avoid the error, fully qualify List.
   using myAliasName2 = System.Collections.Generic.List<int>;
   ```

   If you get this error in code that was previously working, first look for missing or unresolved references in Solution Explorer. Do you need to reinstall a [NuGet](https://www.nuget.org/) package? For information about how the build system searches for references, see [Resolving file references in team build](/archive/blogs/manishagarwal/resolving-file-references-in-team-build-part-2). If all references seem to be correct, look in your source control history to see what has changed in your .csproj file and/or your local source file.

   If you haven’t successfully accessed the reference yet, use the Object Browser to inspect the assembly that is supposed to contain this namespace and verify that the namespace is present. If you verify with Object Browser that the assembly contains the namespace, try removing the `using` directive for the namespace and see what else breaks. The root problem may be with some other type in another assembly.

The following example generates CS0246 because a necessary `using` directive is missing.

```csharp
// CS0246.cs
//using System.Diagnostics;

public class MyClass
{
    // The following line causes CS0246. To fix the error, uncomment
    // the using directive for the namespace for this attribute,
    // System.Diagnostics.
    [Conditional("A")]
    public void Test()
    {
    }

    public static void Main()
    {
    }
}
```

The following example causes CS0246 because an object of type `Type` was used where an actual type was expected.

```csharp
// CS0246b.cs
using System;

class ExampleClass
{
    public bool supports(object o, Type t)
    {
        // The following line causes CS0246. You must use an
        // actual type, such as ExampleClass, String, or Type.
        if (o is t)
        {
            return true;
        }
        return false;
    }
}

class Program
{
    public static void Main()
    {
        ExampleClass myC = new ExampleClass();
        myC.supports(myC, myC.GetType());
    }
}
```

## Compiler Error CS0400

The type or namespace name 'identifier' could not be found in the global namespace (are you missing an assembly reference?)

The identifier scoped with the global scope operator (`::`) was not found in the global namespace. You may be missing an assembly reference that contains the identifier, or the identifier may be declared in a class or namespace other than the global namespace. This error could also occur if a globally scoped identifier is not declared or is misspelled.

To avoid this error, locate the declaration of the identifier, verify the correct spelling, and if the declaration is in a separate assembly, make sure that you have the appropriate assembly reference. If the identifier is declared inside another type or namespace, use the fully-qualified name after the ::. The following sample generates CS0400:

```csharp
// CS0400.cs
class C
{
    public static void Main()
    {
        // CS0400 - D could not be found
        // in the global namespace.
        global::D d = new global::D();
   }
}
```

## CS0735

The following sample generates CS0735.

```csharp
// CS735.cs
// compile with: /target:library
using System.Runtime.CompilerServices;
[assembly:TypeForwardedTo(typeof(int[]))]   // CS0735
[assembly:TypeForwardedTo(typeof(string))]   // OK
```

## Compiler Error CS0012

The type 'type' is defined in an assembly that is not referenced. You must add a reference to assembly 'assembly'.

The definition for a referenced type was not found. This could occur if a required .DLL file is not included in the compilation. For more information, see [Add Reference Dialog Box](/visualstudio/ide/how-to-add-or-remove-references-by-using-the-reference-manager) and [**References** (C# Compiler Options)](../language-reference/compiler-options/inputs.md#references).

The following sequence of compilations will result in CS0012:

```csharp
// cs0012a.cs
// compile with: /target:library
public class A {}
```

Then:

```csharp
// cs0012b.cs
// compile with: /target:library /reference:cs0012a.dll
public class B
{
   public static A f()
   {
      return new A();
   }
}
```

Then:

```csharp
// cs0012c.cs
// compile with: /reference:cs0012b.dll
class C
{
   public static void Main()
   {
      object o = B.f();   // CS0012
   }
}
```

You could resolve this CS0012 by compiling with `/reference:cs0012b.dll;cs0012a.dll`, or in Visual Studio by using the [Add Reference Dialog Box](/visualstudio/ide/how-to-add-or-remove-references-by-using-the-reference-manager) to add a reference to cs0012a.dll in addition to cs0012b.dll.

## Compiler Error CS7068 Warning (level 1) CS1683

Reference to type 'Type Name' claims it is defined in this assembly, but it is not defined in source or any added modules  
  
 This error can occur when you are importing an assembly that contains a reference back to the assembly you are currently compiling, but the assembly being compiled contains nothing matching the reference. One way to get to this situation is to compile your assembly, which initially does contain the member that the assembly being imported is referencing. Then you update your assembly, mistakenly removing the members that the imported assembly is referencing.

## Compiler Error CS1704

An assembly with the same simple name 'Assembly Name' has already been imported. Try removing one of the references or sign them to enable side-by-side.

This error points out that two references have the same assembly identity because the assemblies in question lack strong names, they were not signed, and thus the compiler has no way of distinguishing between them in metadata. Thus, the runtime ignores the version and culture assembly name properties. The user should remove the redundant reference, rename one of the references, or provide a strong name for them.

This sample creates an assembly and saves it to the root directory.

```csharp
// CS1704_a.cs
// compile with: /target:library /out:c:\\cs1704.dll
public class A {}
```

This sample creates an assembly with the same name as the previous sample, but saves it to a different location.

```csharp
// CS1704_b.cs
// compile with: /target:library /out:cs1704.dll
public class A {}
```

This sample attempts to reference both assemblies. The following sample generates CS1704.

```csharp
// CS1704_c.cs
// compile with: /target:library /r:A2=cs1704.dll /r:A1=c:\\cs1704.dll
// CS1704 expected
extern alias A1;
extern alias A2;
```

## Compiler Error CS1714 (replaced by CS0012)

The base class or interface of TypeName1 could not be resolved or is invalid

You are implementing TypeName1 from a class or interface that either could not be resolved, for example, the compiler was unable to locate it, or is invalid. The solution is to determine which of these two cases it is, and either more correctly specify the location of the type, or fix any compiler errors in the base class.
