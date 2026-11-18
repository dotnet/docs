---
title: Resolve errors for incorrect or missing assembly references
description: These compiler errors and warnings indicate incorrect or missing assembly references. These errors cause missing or incorrect definitions for types in your program.
f1_keywords:
 - "CS0012"
 - "CS0234"
 - "CS0246"
 - "CS0400"
 - "CS0731"
 - "CS1068"
 - "CS1069"
 - "CS1070"
 - "CS1509"
 - "CS1542"
 - "CS1683"
 - "CS1704"
 - "CS1714"
 - "CS1760"
 - "CS7008"
 - "CS7041"
 - "CS7068"
 - "CS7069"
 - "CS7071"
 - "CS7079"
 - "CS7086"
 - "CS7087"
 - "CS7098"
 - "CS8004"
 - "CS8005"
 - "CS8006"
 - "CS8007"
 - "CS8008"
 - "CS8014"
 - "CS8015"
 - "CS8090"
 - "CS8203"
 - "CS8206"
 - "CS8356"
 - "CS9286"
helpviewer_keywords:
 - "CS0012"
 - "CS0234"
 - "CS0246"
 - "CS0400"
 - "CS0731"
 - "CS1068"
 - "CS1069"
 - "CS1070"
 - "CS1509"
 - "CS1542"
 - "CS1683"
 - "CS1704"
 - "CS1714"
 - "CS1760"
 - "CS7008"
 - "CS7041"
 - "CS7068"
 - "CS7069"
 - "CS7071"
 - "CS7079"
 - "CS7086"
 - "CS7087"
 - "CS7098"
 - "CS8004"
 - "CS8005"
 - "CS8006"
 - "CS8007"
 - "CS8008"
 - "CS8014"
 - "CS8015"
 - "CS8090"
 - "CS8203"
 - "CS8206"
 - "CS8356"
 - "CS9286"
ms.date: 11/18/2026
ai-usage: ai-assisted
---
# Resolve errors and warnings related to assembly references

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error or warning for SEO purposes.
 -->
- [**CS0012**](#missing-references): *The type 'type' is defined in an assembly that is not referenced. You must add a reference to assembly 'assembly'.*
- [**CS0234**](#missing-references): *The type or namespace name does not exist in the namespace (are you missing an assembly reference?)*
- [**CS0246**](#missing-references): *The type or namespace name could not be found (are you missing a using directive or an assembly reference?)*
- [**CS0400**](#missing-references): *The type or namespace name could not be found in the global namespace (are you missing an assembly reference?)*
- [**CS0731**](#anchor-tbd): *The type forwarder for type 'type name' in assembly 'assembly name' causes a cycle*
- [**CS1068**](#type-forwarding): *The type name could not be found in the global namespace. This type has been forwarded to another assembly. Consider adding a reference to that assembly.*
- [**CS1069**](#type-forwarding): *The type name could not be found in the namespace. This type has been forwarded to another assembly. Consider adding a reference to that assembly.*
- [**CS1070**](#type-forwarding): *The type name could not be found. This type has been forwarded to another assembly. Consider adding a reference to that assembly.*
- [**CS1509**](#anchor-tbd): *The referenced file 'filename' is not an assembly*
- [**CS1542**](#anchor-tbd): *'filename' cannot be added to this assembly because it already is an assembly*
- [**CS1704**](#duplicate-references): *An assembly with the same simple name has already been imported. Try removing one of the references or sign them to enable side-by-side.*
- [**CS1714**](#missing-references): *The base class or interface of this type could not be resolved or is invalid.*
- [**CS1760**](#duplicate-references): *Multiple assemblies refer to the same metadata but only one is a linked reference (specified using /link option); consider removing one of the references.*
- [**CS7008**](#invalid-assembly-reference): *The assembly name is reserved and cannot be used as a reference in an interactive session.*
- [**CS7041**](#anchor-tbd): *Each linked resource and module must have a unique filename. Filename 'filename' is specified more than once in this assembly*
- [**CS7068**](#invalid-assembly-reference): *Reference to type claims it is defined in this assembly, but it is not defined in source or any added modules.*
- [**CS7069**](#invalid-assembly-reference): *Reference to type claims it is defined in another assembly, but it could not be found.*
- [**CS7071**](#invalid-assembly-reference): *Assembly reference is invalid and cannot be resolved.*
- [**CS7079**](#invalid-assembly-reference): *The type is defined in a module that has not been added. You must add the module.*
- [**CS7086**](#anchor-tbd): *Module name 'module name' stored in 'module filename' must match its filename.*
- [**CS7087**](#anchor-tbd): *Invalid module name: reason*
- [**CS7098**](#anchor-tbd): *Linked netmodule metadata must provide a full PE image: 'reference display name'.*
- [**CS8004**](#anchor-tbd): *Type 'type name' exported from module 'module name' conflicts with type declared in primary module of this assembly.*
- [**CS8005**](#anchor-tbd): *Type 'first type name' exported from module 'first module name' conflicts with type 'second type name' exported from module 'second module name'.*
- [**CS8006**](#anchor-tbd): *Forwarded type 'type name' conflicts with type declared in primary module of this assembly.*
- [**CS8007**](#anchor-tbd): *Type 'first type name' forwarded to assembly 'first assembly name' conflicts with type 'second type name' forwarded to assembly 'second assembly name'.*
- [**CS8008**](#anchor-tbd): *Type 'forwarded type name' forwarded to assembly 'assembly name' conflicts with type 'exported type name' exported from module 'module name'.*
- [**CS8014**](#anchor-tbd): *Reference to 'module name' netmodule missing.*
- [**CS8015**](#anchor-tbd): *Module 'module name' is already defined in this assembly. Each module must have a unique filename.*
- [**CS8090**](#invalid-assembly-reference): *There is an error in a referenced assembly.*
- [**CS8203**](#invalid-assembly-reference): *Invalid assembly name.*
- [**CS8206**](#type-forwarding): *Module 'module name' in assembly 'assembly name' is forwarding the type 'type name' to multiple assemblies: 'first assembly name' and 'second assembly name'.*
- [**CS8356**](#duplicate-references): *Predefined type 'type name' is declared in multiple referenced assemblies: 'first assembly name' and 'second assembly name'*
- [**CS9286**](#missing-references): *Type does not contain a definition and no accessible extension member for receiver type could be found (are you missing a using directive or an assembly reference?)*

In addition, this article covers the following warnings:

- [**CS1683**](#invalid-assembly-reference): *Reference to type 'Type Name' claims it is defined in this assembly, but it is not defined in source or any added modules.*

## Missing references

The following errors and warnings indicate that you're missing an assembly reference:

- **CS0012**: *The type 'type' is defined in an assembly that is not referenced. You must add a reference to assembly 'assembly'.*
- **CS0234**: *The type or namespace name does not exist in the namespace (are you missing an assembly reference?)*
- **CS0246**: *The type or namespace name could not be found (are you missing a using directive or an assembly reference?)*
- [**CS1714**](#missing-references): *The base class or interface of this type could not be resolved or is invalid.*
- **CS9286**: *Type does not contain a definition and no accessible extension member for receiver type could be found (are you missing a using directive or an assembly reference?)*

These compiler errors indicate one of these problems in your code:

- The project doesn't reference the required assembly. To fix this error, [add a reference to the required assembly](../../../standard/assembly/index.md#add-a-reference-to-an-assembly).
- You misspelled the name of a type. Check the name of the type.
- You used a variable name where the name of a <xref:System.Type?displayProperty=nameWithType> was expected, such as in the [`typeof` operator](../operators/type-testing-and-cast.md#the-typeof-operator) or the [`is` operator](../operators/type-testing-and-cast.md#the-is-operator).
- You used the [global scope operator, (`::`)](../operators/namespace-alias-qualifier.md) when the type isn't in the global namespace.
- You're accessing an extension member and either the namespace isn't specified in a `using` directive, or you're not referencing the assembly that contains the extension.

### When the assembly appears to be referenced

If the assembly appears to be referenced in your project but you still receive CS0012, try these troubleshooting steps:

- Restore packages: Run `dotnet restore` to ensure all package references are properly resolved, especially after installing or uninstalling NuGet packages.

- Clear the NuGet package cache and restore:

   ```console
   dotnet nuget locals all --clear
   dotnet restore
   ```

- Check for version conflicts: Verify that all referenced assemblies use compatible versions. Look for binding redirect warnings in the build output.

- Clean the solution and rebuild to ensure no stale references remain:

   ```console
   dotnet clean
   dotnet build
   ```

- Verify package integrity: If the error occurred after package operations, ensure the package was installed correctly by removing and reinstalling it:

   ```console
   dotnet remove package [PackageName]
   dotnet add package [PackageName]
   ```

## Type forwarding

- **CS1068**: *The type name could not be found in the global namespace. This type has been forwarded to another assembly. Consider adding a reference to that assembly.*
- **CS1069**: *The type name could not be found in the namespace. This type has been forwarded to another assembly. Consider adding a reference to that assembly.*
- **CS1070**: *The type name could not be found. This type has been forwarded to another assembly. Consider adding a reference to that assembly.*
- **CS8206**: *Module 'module name' in assembly 'assembly name' is forwarding the type 'type name' to multiple assemblies: 'first assembly name' and 'second assembly name'.*

CS1068, CS1069, and CS1070 indicate an error referencing a type forwarded to a different assembly. Add a reference to the assembly indicated in the error message.

CS8206 indicates conflicting type-forwarder metadata in a referenced assembly or module. The same type is forwarded to more than one destination assembly. Use corrected or rebuilt dependencies that forward the type to one destination. Ensure package and assembly versions are consistent, or remove the reference that introduces the conflicting metadata. Source aliases or unrelated changes to local type declarations don't correct the referenced metadata.

## Duplicate references

The following errors indicate a duplicate assembly reference:

- **CS1704**: *An assembly with the same simple name has already been imported. Try removing one of the references or sign them to enable side-by-side.*
- **CS1760**: *Multiple assemblies refer to the same metadata but only one is a linked reference (specified using /link option); consider removing one of the references.*
- **CS8356**: *Predefined type 'type name' is declared in multiple referenced assemblies: 'first assembly name' and 'second assembly name'*

To fix these errors, remove one of the references or resolve the duplication. Causes for duplication include:

- Multiple unsigned assemblies with the same name.
- Your project references multiple versions of the same assembly.

For CS8356, remove or replace the duplicate or incompatible reference that defines the same predefined runtime type. Ensure the project targets one coherent framework and reference-assembly set. Don't add another source definition of the predefined type.

## Invalid assembly reference

The following errors indicate that an assembly reference is invalid:

- **CS7008**: *The assembly name is reserved and cannot be used as a reference in an interactive session.*
- **CS7068**: *Reference to type claims it is defined in this assembly, but it is not defined in source or any added modules.*
- **CS7069**: *Reference to type claims it is defined in another assembly, but it could not be found.*
- **CS7071**: *Assembly reference is invalid and cannot be resolved.*
- **CS7079**: *The type is defined in a module that has not been added. You must add the module.*
- **CS8090**: *There is an error in a referenced assembly.*
- **CS8203**: *Invalid assembly name.*

The following warning also indicates an invalid reference assembly:

- **CS1683**: *Reference to type 'Type Name' claims it is defined in this assembly, but it is not defined in source or any added modules*

Check that you spelled the assembly name correctly. The referenced assembly file might be invalid.

## CS0731

- **CS0731**: *The type forwarder for type 'type name' in assembly 'assembly name' causes a cycle*

This error indicates a cycle in imported type-forwarding metadata. Correct or rebuild the referenced assemblies so the forwarding chain ends at an assembly that defines the type. Don't forward the type back to an earlier assembly in the chain. Source aliases don't repair this metadata.

### Example

This fixture requires the .NET Framework IL assembler (`ilasm.exe`) and a C# compiler with .NET Framework references. It uses `mscorlib` metadata and isn't a universal modern SDK project workflow.

The example consists of `Circular.il`, `Circular2.il`, and `CS0731.cs`. The two assemblies forward the same type to each other. First assemble the IL files as libraries, then compile the C# client with references to both libraries:

```console
ilasm /dll /output:Circular.dll Circular.il
ilasm /dll /output:Circular2.dll Circular2.il
csc /reference:Circular.dll /reference:Circular2.dll CS0731.cs
```

Save the following IL as `Circular.il`:

```il
// Circular.il
// compile with: /DLL /out=Circular.dll
.assembly extern circular2
{
  .ver 0:0:0:0
}
.assembly extern circular3
{
  .ver 0:0:0:0
}
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )   // .z\V.4..
  .ver 2:0:0:0
}
.assembly Circular
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 )
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.class extern forwarder Circular.Referenced.TypeForwarder
{
  .assembly extern circular2
}
.module Circular.dll
// MVID: {880C2329-C915-42A0-83E9-9D10C3E6DBD0}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x04E40000
// ======== CLASS MEMBERS DECLARATION =========
.class public abstract auto ansi sealed beforefieldinit User
       extends [mscorlib]System.Object
{
  .method public hidebysig static class [circular2]Circular.Referenced.TypeForwarder
          F() cil managed
  {
    .maxstack  1
    newobj     instance void [circular2]Circular.Referenced.TypeForwarder::.ctor()
    ret
  }
}
```

Save the following IL as `Circular2.il`:

```il
// Circular2.il
// compile with: /DLL /out=Circular2.dll
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )   // .z\V.4..
  .ver 2:0:0:0
}
.assembly extern Circular
{
  .ver 0:0:0:0
}
.assembly circular2
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 )
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.class extern forwarder Circular.Referenced.TypeForwarder
{
  .assembly extern Circular
}
.module circular2.dll
// MVID: {8B3BE5C8-DBE1-49C4-BC72-DF35F0387C21}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       //   WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x04E40000
```

Save the following C# code as `CS0731.cs`:

```csharp
// CS0731.cs
// compile with: /reference:circular.dll /reference:circular2.dll
// CS0731 expected
class A {
   public static void Main() {
      User.F();
   }
}
```

To correct this example, replace the forwarder in `Circular2.il` with a public definition of `Circular.Referenced.TypeForwarder` that has a public parameterless constructor. Rebuild the libraries and client. `Circular.dll` then forwards the type to its definition in `Circular2.dll`, rather than back into a cycle.

## CS1509

- **CS1509**: *The referenced file 'filename' is not an assembly*

A file built with the `module` value of [**OutputType**](../compiler-options/output.md#outputtype) is a netmodule without an assembly manifest. To add that module to the output assembly, supply it through [**AddModules**](../compiler-options/inputs.md#addmodules), not [**References**](../compiler-options/inputs.md#references).

For a direct compiler invocation, change `/reference:Input.netmodule` to `/addmodule:Input.netmodule`. Use a toolchain and target that support netmodules; this correction doesn't convert the module into a separately referenceable assembly.

## CS1542

- **CS1542**: *'filename' cannot be added to this assembly because it already is an assembly*

Supply an assembly through [**References**](../compiler-options/inputs.md#references), not [**AddModules**](../compiler-options/inputs.md#addmodules). For a direct compiler invocation, change `/addmodule:Input.dll` to `/reference:Input.dll`.

If you intend to link a module instead, rebuild the input with the `module` value of [**OutputType**](../compiler-options/output.md#outputtype) and supply the resulting netmodule through **AddModules**. Choose the input kind by whether the file contains an assembly manifest, not by its extension.
