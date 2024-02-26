---
title: Resolve errors related to incorrect or missing assembly references
description: These compiler errors and warnings indicate incorrect or missing assembly references. These result in missing declarations for required types.
f1_keywords:
 - "CS0012"
 - "CS0735"
 - "CS1068"
 - "CS1069"
 - "CS1070"
 - "CS1714"
 - "CS7079"
helpviewer_keywords:
 - "CS0012"
 - "CS0735"
 - "CS1068"
 - "CS1069"
 - "CS1070"
 - "CS1714"
 - "CS7079"
ms.date: 02/26/2024
---
# Resolve errors and warnings related to assembly references

Others to consider:

Assembly related:

- ERR_NoTypeDef:  The type '{0}' is defined in an assembly that is not referenced. You must add a reference to assembly '{1}'.
- ERR_ReservedAssemblyName: The assembly name '{0}' is reserved and cannot be used as a reference in an interactive session
- ERR_DottedTypeNameNotFoundInNS: The type or namespace name '{0}' does not exist in the namespace '{1}' (are you missing an assembly reference?)
- ERR_SingleTypeNameNotFound: The type or namespace name '{0}' could not be found (are you missing a using directive or an assembly reference?)
- ERR_GlobalSingleTypeNameNotFound: The type or namespace name '{0}' could not be found in the global namespace (are you missing an assembly reference?)
- ERR_ForwardedTypeInThisAssembly: Type '{0}' is defined in this assembly, but a type forwarder is specified for it
- ERR_CycleInTypeForwarder: The type forwarder for type '{0}' in assembly '{1}' causes a cycle
- ERR_InvalidAssemblyName: Assembly reference '{0}' is invalid and cannot be resolved
- ERR_ImportNonAssembly: The referenced file '{0}' is not an assembly
- ERR_AddModuleAssembly: '{0}' cannot be added to this assembly because it already is an assembly
- ERR_MissingTypeInSource: Reference to type '{0}' claims it is defined in this assembly, but it is not defined in source or any added modules
- ERR_MissingTypeInAssembly: Reference to type '{0}' claims it is defined in '{1}', but it could not be found
- WRN_InvalidAssemblyName: Assembly reference '{0}' is invalid and cannot be resolved
- ERR_DuplicateImportSimple: An assembly with the same simple name '{0}' has already been imported. Try removing one of the references (e.g. '{1}') or sign them to enable side-by-side.
- ERR_GlobalSingleTypeNameNotFoundFwd: The type name '{0}' could not be found in the global namespace. This type has been forwarded to assembly '{1}' Consider adding a reference to that assembly.
- ERR_DottedTypeNameNotFoundInNSFwd: The type name '{0}' could not be found in the namespace '{1}'. This type has been forwarded to assembly '{2}' Consider adding a reference to that assembly.
- ERR_SingleTypeNameNotFoundFwd: The type name '{0}' could not be found. This type has been forwarded to assembly '{1}'. Consider adding a reference to that assembly.
- ERR_AssemblySpecifiedForLinkAndRef: Assemblies '{0}' and '{1}' refer to the same metadata but only one is a linked reference (specified using /link option); consider removing one of the references.
- WRN_AssemblyAttributeFromModuleIsOverridden: Attribute '{0}' from module '{1}' will be ignored in favor of the instance appearing in source
- ERR_ExportedTypeConflictsWithDeclaration: Type '{0}' exported from module '{1}' conflicts with type declared in primary module of this assembly.
- ERR_ForwardedTypeConflictsWithDeclaration: Forwarded type '{0}' conflicts with type declared in primary module of this assembly.
- ERR_ForwardedTypesConflict: Type '{0}' forwarded to assembly '{1}' conflicts with type '{2}' forwarded to assembly '{3}'.
- ERR_ForwardedTypeConflictsWithExportedType: Type '{0}' forwarded to assembly '{1}' conflicts with type '{2}' exported from module '{3}'.
- ERR_NetModuleNameMustBeUnique: Module '{0}' is already defined in this assembly. Each module must have a unique filename.
- ERR_ErrorInReferencedAssembly: There is an error in a referenced assembly '{0}'.
- ERR_BadAssemblyName: Invalid assembly name: {0}
- ERR_TypeForwardedToMultipleAssemblies: Module '{0}' in assembly '{1}' is forwarding the type '{2}' to multiple assemblies: '{3}' and '{4}'.
- ERR_SymbolDefinedInAssembly: '{0}' is defined in assembly '{1}'.

Module related:

- ERR_NoTypeDefFromModule: The type '{0}' is defined in a module that has not been added. You must add the module '{1}'.
- ERR_MissingNetModuleReference: Reference to '{0}' netmodule missing.

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0012**](#compiler-error-cs0012): *The type 'type' is defined in an assembly that is not referenced. You must add a reference to assembly 'assembly'.*
- [**CS0735**](#type-forwarding): *Invalid type specified as an argument for <xref:System.Runtime.CompilerServices.TypeForwardedToAttribute> attribute.*
- [**CS1068**](#type-forwarding): *The type name could not be found in the global namespace. This type has been forwarded to another assembly. Consider adding a reference to that assembly.*
- [**CS1069**](#type-forwarding): *The type name could not be found in the namespace. This type has been forwarded to another assembly. Consider adding a reference to that assembly.*
- [**CS1070**](#type-forwarding): *The type name could not be found. This type has been forwarded to another assembly. Consider adding a reference to that assembly.*
- [**CS1714**](#compiler-error-cs1714-replaced-by-cs0012): *The base class or interface of this type could not be resolved or is invalid.*
- [**CS7079**](): *The type is defined in a module that has not been added. You must add the module.*

In addition, the following warnings are covered in this article:

## Type forwarding

- **CS0735**: *Invalid type specified as an argument for <xref:System.Runtime.CompilerServices.TypeForwardedToAttribute> attribute.*
- **CS1068**: *The type name could not be found in the global namespace. This type has been forwarded to another assembly. Consider adding a reference to that assembly.*
- **CS1069**: *The type name could not be found in the namespace. This type has been forwarded to another assembly. Consider adding a reference to that assembly.*
- **CS1070**: *The type name could not be found. This type has been forwarded to another assembly. Consider adding a reference to that assembly.*

This class of errors involves types that have been forwarded to a different assembly.

### CS0735

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

## Compiler Error CS1714 (replaced by CS0012)

The base class or interface of TypeName1 could not be resolved or is invalid

You are implementing TypeName1 from a class or interface that either could not be resolved, for example, the compiler was unable to locate it, or is invalid. The solution is to determine which of these two cases it is, and either more correctly specify the location of the type, or fix any compiler errors in the base class.
