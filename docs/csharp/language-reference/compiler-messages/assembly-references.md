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
 - "CS7061"
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
 - "CS7061"
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
- [**CS0012**](#missing-references): *The type 'type name' is defined in an assembly that is not referenced. You must add a reference to assembly 'assembly name'.*
- [**CS0234**](#missing-references): *The type or namespace name 'type or namespace name' does not exist in the namespace 'namespace name' (are you missing an assembly reference?)*
- [**CS0246**](#missing-references): *The type or namespace name 'type or namespace name' could not be found (are you missing a using directive or an assembly reference?)*
- [**CS0400**](#missing-references): *The type or namespace name 'type or namespace name' could not be found in the global namespace (are you missing an assembly reference?)*
- [**CS0731**](#type-forwarding): *The type forwarder for type 'type name' in assembly 'assembly name' causes a cycle*
- [**CS1068**](#type-forwarding): *The type name 'type name' could not be found in the global namespace. This type has been forwarded to assembly 'assembly name' Consider adding a reference to that assembly.*
- [**CS1069**](#type-forwarding): *The type name 'type name' could not be found in the namespace 'namespace name'. This type has been forwarded to assembly 'assembly name' Consider adding a reference to that assembly.*
- [**CS1070**](#type-forwarding): *The type name 'type name' could not be found. This type has been forwarded to assembly 'assembly name'. Consider adding a reference to that assembly.*
- [**CS1509**](#invalid-assembly-reference): *The referenced file 'filename' is not an assembly*
- [**CS1542**](#invalid-assembly-reference): *'filename' cannot be added to this assembly because it already is an assembly*
- [**CS1704**](#duplicate-references): *An assembly with the same simple name 'assembly simple name' has already been imported. Try removing one of the references (e.g. 'reference') or sign them to enable side-by-side.*
- [**CS1714**](#missing-references): *The base class or interface of this type could not be resolved or is invalid.* (Historical error.)
- [**CS1760**](#duplicate-references): *Assemblies 'first assembly reference' and 'second assembly reference' refer to the same metadata but only one is a linked reference (specified using /link option); consider removing one of the references.*
- [**CS7008**](#invalid-assembly-reference): *The assembly name 'assembly name' is reserved and cannot be used as a reference in an interactive session*
- [**CS7041**](#duplicate-references): *Each linked resource and module must have a unique filename. Filename 'filename' is specified more than once in this assembly*
- [**CS7061**](#duplicate-references): *Duplicate 'attribute name' attribute in 'netmodule name'*
- [**CS7068**](#invalid-assembly-reference): *Reference to type 'type name' claims it is defined in this assembly, but it is not defined in source or any added modules*
- [**CS7069**](#invalid-assembly-reference): *Reference to type 'type name' claims it is defined in 'assembly name', but it could not be found*
- [**CS7071**](#invalid-assembly-reference): *Assembly reference 'assembly name' is invalid and cannot be resolved*
- [**CS7079**](#invalid-assembly-reference): *The type 'type name' is defined in a module that has not been added. You must add the module 'module name'.*
- [**CS7086**](#invalid-assembly-reference): *Module name 'module name' stored in 'module filename' must match its filename.*
- [**CS7087**](#invalid-assembly-reference): *Invalid module name: reason*
- [**CS7098**](#invalid-assembly-reference): *Linked netmodule metadata must provide a full PE image: 'reference display name'.*
- [**CS8004**](#duplicate-references): *Type 'type name' exported from module 'module name' conflicts with type declared in primary module of this assembly.*
- [**CS8005**](#duplicate-references): *Type 'first type name' exported from module 'first module name' conflicts with type 'second type name' exported from module 'second module name'.*
- [**CS8006**](#type-forwarding): *Forwarded type 'type name' conflicts with type declared in primary module of this assembly.*
- [**CS8007**](#type-forwarding): *Type 'first type name' forwarded to assembly 'first assembly name' conflicts with type 'second type name' forwarded to assembly 'second assembly name'.*
- [**CS8008**](#type-forwarding): *Type 'forwarded type name' forwarded to assembly 'assembly name' conflicts with type 'exported type name' exported from module 'module name'.*
- [**CS8014**](#invalid-assembly-reference): *Reference to 'module name' netmodule missing.*
- [**CS8015**](#duplicate-references): *Module 'module name' is already defined in this assembly. Each module must have a unique filename.*
- [**CS8090**](#invalid-assembly-reference): *There is an error in a referenced assembly 'assembly name'.*
- [**CS8203**](#invalid-assembly-reference): *Invalid assembly name: reason*
- [**CS8206**](#type-forwarding): *Module 'module name' in assembly 'assembly name' is forwarding the type 'type name' to multiple assemblies: 'first assembly name' and 'second assembly name'.*
- [**CS8356**](#duplicate-references): *Predefined type 'type name' is declared in multiple referenced assemblies: 'first assembly name' and 'second assembly name'*
- [**CS9286**](#missing-references): *'receiver type' does not contain a definition for 'member name' and no accessible extension member 'member name' for receiver of type 'receiver type' could be found (are you missing a using directive or an assembly reference?)*

In addition, this article preserves the following historical warning:

- [**CS1683**](#invalid-assembly-reference): *Reference to type 'Type Name' claims it is defined in this assembly, but it is not defined in source or any added modules.* (Historical warning.)

## Missing references

- **CS0012**: *The type 'type name' is defined in an assembly that is not referenced. You must add a reference to assembly 'assembly name'.*
- **CS0234**: *The type or namespace name 'type or namespace name' does not exist in the namespace 'namespace name' (are you missing an assembly reference?)*
- **CS0246**: *The type or namespace name 'type or namespace name' could not be found (are you missing a using directive or an assembly reference?)*
- **CS0400**: *The type or namespace name 'type or namespace name' could not be found in the global namespace (are you missing an assembly reference?)*
- **CS1714**: *The base class or interface of this type could not be resolved or is invalid.* (Historical error.)
- **CS9286**: *'receiver type' does not contain a definition for 'member name' and no accessible extension member 'member name' for receiver of type 'receiver type' could be found (are you missing a using directive or an assembly reference?)*

[Add a reference to the assembly](../../../standard/assembly/index.md#add-a-reference-to-an-assembly) that defines the required type, including dependencies of referenced types (**CS0012**). Check the type's spelling, namespace, and accessibility, and add the appropriate `using` directive or qualified name (**CS0234**, **CS0246**). A `using` directive doesn't add an assembly reference.

Use the [global alias qualifier](../operators/namespace-alias-qualifier.md) only for a name that exists at that location; otherwise, qualify the type through its actual namespace (**CS0400**). Supply a type, not a variable holding a <xref:System.Type?displayProperty=nameWithType>, where operators such as [`typeof`](../operators/type-testing-and-cast.md#the-typeof-operator) or [`is`](../operators/type-testing-and-cast.md#the-is-operator) require a type.

Reference the assembly that declares the required extension member and import its namespace; check that the member applies to the receiver type (**CS9286**).

**CS1714** is a historical error with no current Roslyn message resource. Current Roslyn uses CS0012 instead; the quoted wording is retained for older compiler output.

<a id="when-the-assembly-appears-to-be-referenced"></a>

If a reference should already be present, restore packages with `dotnet restore` and check for incompatible package or assembly versions (**CS0012**). Inspect restore/build warnings before changing references. For stale outputs, run `dotnet clean` and `dotnet build`. If package files are corrupt, clear local caches with `dotnet nuget locals all --clear`, then restore. If an identified package installation is broken, remove and reinstall that package with `dotnet remove package PackageName` and `dotnet add package PackageName`.

## Type forwarding

- **CS0731**: *The type forwarder for type 'type name' in assembly 'assembly name' causes a cycle*
- **CS1068**: *The type name 'type name' could not be found in the global namespace. This type has been forwarded to assembly 'assembly name' Consider adding a reference to that assembly.*
- **CS1069**: *The type name 'type name' could not be found in the namespace 'namespace name'. This type has been forwarded to assembly 'assembly name' Consider adding a reference to that assembly.*
- **CS1070**: *The type name 'type name' could not be found. This type has been forwarded to assembly 'assembly name'. Consider adding a reference to that assembly.*
- **CS8006**: *Forwarded type 'type name' conflicts with type declared in primary module of this assembly.*
- **CS8007**: *Type 'first type name' forwarded to assembly 'first assembly name' conflicts with type 'second type name' forwarded to assembly 'second assembly name'.*
- **CS8008**: *Type 'forwarded type name' forwarded to assembly 'assembly name' conflicts with type 'exported type name' exported from module 'module name'.*
- **CS8206**: *Module 'module name' in assembly 'assembly name' is forwarding the type 'type name' to multiple assemblies: 'first assembly name' and 'second assembly name'.*

Add a reference to the assembly that defines the forwarded type, as identified by the diagnostic (**CS1068**, **CS1069**, **CS1070**).

Correct conflicting forwarding metadata in the output or its inputs:

- Choose whether the output defines the type locally or forwards it elsewhere. Remove the obsolete forwarder or local definition, and rebuild the affected source or module (**CS8006**).
- Make the contributing forwarders agree on one destination assembly. Remove or rebuild a module or forwarding declaration that selects a different destination (**CS8007**).
- Choose between exporting the type from an added module and forwarding it to another assembly. Remove the obsolete forwarder or the conflicting module definition, and rebuild the input (**CS8008**).
- Replace or rebuild a referenced assembly or module that forwards the same type to multiple destinations. Align dependency versions or remove the reference that introduces conflicting metadata (**CS8206**).

**CS8006** and **CS8008** are **build-only diagnostics**: these conflict checks run during emit and aren't returned by `SemanticModel.GetDiagnostics`. Source aliases change name lookup, not the conflicting exported or forwarded metadata.

<a id="cs0731"></a>

Break a forwarding cycle by making the chain end at an assembly that defines the type; don't forward it back to an earlier assembly (**CS0731**). Rebuild or replace the affected dependencies. Source aliases don't repair a cycle.

<a id="example"></a>

The following minimal fixture requires the .NET Framework IL assembler (`ilasm.exe`) and a C# compiler with .NET Framework references. It isn't a universal modern SDK/runtime workflow. Save these IL blocks as `Circular.il` and `Circular2.il`:

```il
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89)
  .ver 4:0:0:0
}
.assembly extern Circular2 {}
.assembly Circular {}
.module Circular.dll
.class extern forwarder Circular.Referenced.TypeForwarder
{
  .assembly extern Circular2
}
.class public abstract sealed User extends [mscorlib]System.Object
{
  .method public static class [Circular2]Circular.Referenced.TypeForwarder F() cil managed
  {
    .maxstack 1
    newobj instance void [Circular2]Circular.Referenced.TypeForwarder::.ctor()
    ret
  }
}
```

```il
.assembly extern Circular {}
.assembly Circular2 {}
.module Circular2.dll
.class extern forwarder Circular.Referenced.TypeForwarder
{
  .assembly extern Circular
}
```

Save the client as `CS0731.cs`:

```csharp
class Client
{
    static void Main()
    {
        User.F();
    }
}
```

With the required tools and references available, assemble the libraries and compile the client:

```console
ilasm /dll /output:Circular.dll Circular.il
ilasm /dll /output:Circular2.dll Circular2.il
csc /reference:Circular.dll /reference:Circular2.dll CS0731.cs
```

The two assemblies forward the same type to each other, so the client reports CS0731. To correct the fixture, replace `Circular2.il` with this definition, then rerun the same commands:

```il
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89)
  .ver 4:0:0:0
}
.assembly Circular2 {}
.module Circular2.dll
.class public auto ansi Circular.Referenced.TypeForwarder extends [mscorlib]System.Object
{
  .method public specialname rtspecialname instance void .ctor() cil managed
  {
    .maxstack 1
    ldarg.0
    call instance void [mscorlib]System.Object::.ctor()
    ret
  }
}
```

The forwarding chain now ends at the public type definition in `Circular2.dll`.

## Duplicate references

- **CS1704**: *An assembly with the same simple name 'assembly simple name' has already been imported. Try removing one of the references (e.g. 'reference') or sign them to enable side-by-side.*
- **CS1760**: *Assemblies 'first assembly reference' and 'second assembly reference' refer to the same metadata but only one is a linked reference (specified using /link option); consider removing one of the references.*
- **CS7041**: *Each linked resource and module must have a unique filename. Filename 'filename' is specified more than once in this assembly*
- **CS7061**: *Duplicate 'attribute name' attribute in 'netmodule name'*
- **CS8004**: *Type 'type name' exported from module 'module name' conflicts with type declared in primary module of this assembly.*
- **CS8005**: *Type 'first type name' exported from module 'first module name' conflicts with type 'second type name' exported from module 'second module name'.*
- **CS8015**: *Module 'module name' is already defined in this assembly. Each module must have a unique filename.*
- **CS8356**: *Predefined type 'type name' is declared in multiple referenced assemblies: 'first assembly name' and 'second assembly name'*

Remove redundant or incompatible assembly references rather than adding another copy of the same dependency (**CS1704**). Check for unsigned assemblies with the same simple name and for projects that reference multiple incompatible versions. If distinct signed identities are intentional, configure those identities consistently rather than renaming files to disguise a duplicate.

Choose one reference to the same metadata, with consistent interop-embedding settings (**CS1760**). Here `/link` means an assembly reference with embedded interop types, not an added netmodule.

Give each linked resource and added module a unique filename, or remove the redundant input (**CS7041**). Different resource names don't resolve duplicate linked-resource filenames, and a linked resource can also collide with a module filename. For duplicate stored module names, remove a repeated module or rebuild distinct modules with unique names and matching filenames (**CS8015**); moving copies to different directories doesn't change their stored names.

Resolve conflicting assembly attributes carried by an added netmodule (**CS7061**). Remove an unintended duplicate from source or rebuild the contributing module with the intended attribute value. For an attribute that doesn't permit multiple applications, different constructor/argument values can conflict; identical applications are deduplicated. Attributes whose usage permits multiple applications can have distinct values, and known assembly attributes have special handling, so don't assume every repeated attribute is an error. See [Global attributes](../attributes/global.md) and [Attribute specification](~/_csharpstandard/standard/attributes.md#233-attribute-specification).

Correct conflicting type definitions before emitting the assembly:

- Remove or rename a primary-module definition that conflicts with a public type exported by an added module, or rebuild the module without that conflicting definition (**CS8004**).
- Remove a redundant module or rebuild the inputs so two modules don't export conflicting type identities (**CS8005**).

**CS8004** and **CS8005** are **build-only diagnostics**: these conflict checks run during emit and aren't returned by `SemanticModel.GetDiagnostics`. Correct the definitions or module inputs; source aliases don't change their emitted metadata identities.

Use one coherent framework and reference-assembly set, removing or replacing an incompatible reference that defines the same predefined runtime type (**CS8356**). Don't add another source definition of that type.

## Invalid assembly reference

- **CS1509**: *The referenced file 'filename' is not an assembly*
- **CS1542**: *'filename' cannot be added to this assembly because it already is an assembly*
- **CS1683**: *Reference to type 'Type Name' claims it is defined in this assembly, but it is not defined in source or any added modules.* (Historical warning.)
- **CS7008**: *The assembly name 'assembly name' is reserved and cannot be used as a reference in an interactive session*
- **CS7068**: *Reference to type 'type name' claims it is defined in this assembly, but it is not defined in source or any added modules*
- **CS7069**: *Reference to type 'type name' claims it is defined in 'assembly name', but it could not be found*
- **CS7071**: *Assembly reference 'assembly name' is invalid and cannot be resolved*
- **CS7079**: *The type 'type name' is defined in a module that has not been added. You must add the module 'module name'.*
- **CS7086**: *Module name 'module name' stored in 'module filename' must match its filename.*
- **CS7087**: *Invalid module name: reason*
- **CS7098**: *Linked netmodule metadata must provide a full PE image: 'reference display name'.*
- **CS8014**: *Reference to 'module name' netmodule missing.*
- **CS8090**: *There is an error in a referenced assembly 'assembly name'.*
- **CS8203**: *Invalid assembly name: reason*

Validate both the assembly references and the linked-module inputs. Match input kinds to how they're supplied:

<a id="cs1509"></a>
<a id="cs1542"></a>

- Supply a netmodule through [**AddModules**](../compiler-options/inputs.md#addmodules), not [**References**](../compiler-options/inputs.md#references). For direct compiler arguments, change `/reference:Input.netmodule` to `/addmodule:Input.netmodule` (**CS1509**).
- Supply an assembly through **References**, not **AddModules**. Change `/addmodule:Input.dll` to `/reference:Input.dll` (**CS1542**).

Choose by whether the input contains an assembly manifest, not by its extension. If you intend to produce a module instead of an assembly, rebuild with the `module` value of [**OutputType**](../compiler-options/output.md#outputtype). Use a compiler toolchain and target that support netmodules; selecting another input option doesn't convert a netmodule into a separately referenceable assembly.

Restore a linked module's original filename, or rebuild it with a stored module name that matches the intended filename (**CS7086**). Renaming a file doesn't rewrite the name stored in its metadata.

When you set `CSharpCompilationOptions.ModuleName`, use a nonempty simple filename without leading whitespace, directory separators, a colon, NUL characters, or invalid Unicode (**CS7087**). Supply a module name, not a path; follow the reason in the diagnostic.

Add the module that defines the required type (**CS7079**). Explicitly supply all netmodules required by other added modules, not just the first module in the dependency chain (**CS8014**). Keep the required files' names consistent with the metadata that refers to them.

For Roslyn API inputs, supply the **full PE image** of each linked netmodule, not just its metadata directory (**CS7098**). For example, use `MetadataReference.CreateFromFile(path, MetadataReferenceProperties.Module)` or obtain a reference from `ModuleMetadata.CreateFromImage` with the complete image. If you create module metadata from a stream, retain access to the full image; `PEStreamOptions.PrefetchEntireImage` does so, whereas `PrefetchMetadata` alone doesn't. `ModuleMetadata.CreateFromMetadata` supplies only a metadata block and isn't sufficient for a linked netmodule. A filename, alias, or command-line option can't restore the missing PE data.

For an already assembled multi-module assembly, supply its constituent modules through `AssemblyMetadata`, with the actual manifest module first; don't substitute an unrelated same-named module for a missing constituent (**CS7079**). Wrapping a netmodule in `AssemblyMetadata` doesn't create an assembly manifest. Keep metadata objects and any lazily read streams alive while the compilation uses them, and dispose them afterward.

Correct unresolved type ownership in the input metadata: include the intended type in source or an added module when it claims to belong to the current assembly (**CS7068**), or replace/rebuild the referenced assembly that should define it (**CS7069**). **CS1683** is the historical warning for the first case; current Roslyn reports CS7068 instead. That warning has no current Roslyn message resource; its quoted wording is retained for older compiler output.

Choose a nonreserved assembly name for an interactive-session reference (**CS7008**). Correct malformed assembly identities (**CS7071**) or the output assembly name described by the diagnostic (**CS8203**). When you create a Roslyn compilation, supply a valid assembly name rather than a path. Check spelling and the actual referenced files rather than changing only source-level aliases.

Read the errors reported for the referenced assembly, then rebuild or replace that dependency (**CS8090**). Adding another reference doesn't correct errors already present in the dependency.
