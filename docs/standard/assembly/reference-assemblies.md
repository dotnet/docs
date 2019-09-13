---
title: "Reference assemblies"
description: "Learn about reference assemblies, a special type of assemblies in .NET that contain only the library's public API surface"
author: MSDN-WhiteKnight
ms.author: ronpet
ms.date: 09/12/2019
ms.technology: dotnet-standard
---
# Reference assemblies

*Reference assemblies* are a special type of assembly that contain only the minimum amount of metadata required to represent the library's public API surface. They include declarations for all members that are significant when referencing an assembly in build tools (hence the name), but exclude all member implementations as well as declarations of private members that have no observable impact on their API contract. In contrast, regular assemblies are called *implementation assemblies*. 

Reference assemblies cannot be loaded for execution, but they can be passed as  compiler input in the same way as implementation assemblies. Reference assemblies are usually distributed with the Software Development Kit (SDK) of a particular platform or library, a special software component installed only on developer machines.

Using a reference assembly enables developers to build programs that target a specific library version without having the full implementation assembly for that version. Suppose, you have only the latest version of some library on your machine, but you want to build a program that targets a machine with an earlier version of that library. If you compile directly against the implementation assembly, you might inadvertently use API members that aren't available in the earlier version, and you'll only find this mistake when testing the program on the target machine. If you compile against the reference assembly for the earlier version, you'll immediately get a compile-time error.

## Using reference assemblies

To use certain APIs from your project, you must add references to their assemblies. You can add references either to implementation assemblies directly or to reference assemblies. We strongly recommend that you use reference assemblies whenever they are available, because doing so ensures that you are using only API members that are supported in the target version and are meant to be used by API designers (in other words, not taking a dependency on implementation details).

Reference assemblies for the .NET Framework libraries are distributed with targeting packs. You can obtain them by downloading a standalone installer or by selecting a component in Visual Studio installer. For more information, see [Install the .NET Framework for developers](../../framework/install/guide-for-developers.md). Reference assemblies for .NET Core libraries are managed as NuGet packages. For example, the [Microsoft.NETCore.App](https://www.nuget.org/packages/Microsoft.NETCore.App) package contains reference assemblies that represent common .NET Core APIs. To import these packages, you must first install the SDK for the target platform version you plan to use. For more information, see [Packages, metapackages and frameworks](../../core/packages.md) in the .NET Core Guide.

When you add references to .NET Framework assemblies in Visual Studio using the **Add reference** dialog, you select an assembly from the list, and Visual Studio automatically finds reference assemblies that correspond to the target framework version selected in your project. When you add references to these assemblies in the command line by using the `-reference` compiler option ([in C#](../../csharp/language-reference/compiler-options/reference-compiler-option.md) and in [Visual Basic](../../visual-basic/reference/command-line-compiler/reference.md)) or by using the <xref:Microsoft.CodeAnalysis.Compilation.AddReferences%2A?displayProperty=nameWithType> method in the Roslyn API, you must manually specify reference assembly files for the correct target platform version. .NET Framework reference assembly files are located in the *%ProgramFiles(x86)%\\Reference Assemblies\\Microsoft\\Framework\\.NETFramework* directory. Local cached copies of .NET Core reference assembly files can be found in the NuGetFallbackFolder directory located under *%ProgramFiles%\\dotnet\\sdk\\* on Windows, */usr/share/dotnet/sdk/* on Linux, or */usr/local/share/dotnet/sdk* on MacOS. Using `DependencyContext` from [Microsoft.Extensions.DependencyModel](https://www.nuget.org/packages/Microsoft.Extensions.DependencyModel/) package can help locate reference assembly files for a particular target platform.

Because they contain no implementation, reference assemblies cannot be loaded for execution; trying to do so results in a <xref:System.BadImageFormatException?displayProperty=nameWithType>. However, they still can be loaded into the reflection-only context (using the 
<xref:System.Reflection.Assembly.ReflectionOnlyLoad%2A?displayProperty=nameWithType>) method, if you need to examine their contents.

## Generating reference assemblies

Generating reference assemblies for your libraries can be useful when your library consumers often need to build their programs against many different versions of the library (that is, when you need to implement a feature similar to .NET Framework Targeting Packs mentioned above for your own project). Distributing implementation assemblies for all these versions might be impractical due to their large size. Reference assemblies are smaller in size, so distributing them as a part of your library's SDK reduces download size and saves disk space.

IDEs and build tools also can take advantage of reference assemblies to reduce build times in case of large solutions consisting of multiple class libraries. Reference assembly doesn't change when programmer changes private implementation details of a class library without affecting its public API, so projects that take dependency on it via the reference assembly don't have to be rebuilt on each of these changes.

You can generate reference assemblies:

- In an MSBuild project, by using the [`ProduceReferenceAssembly` project property](/visualstudio/msbuild/common-msbuild-project-properties).
- When compiling program from command line, by specifiying `-refonly` ([in C#](../../csharp/language-reference/compiler-options/refonly-compiler-option.md), [in Visual Basic](../../visual-basic/reference/command-line-compiler/refonly-compiler-option.md) ) or `-refout` ([in C#](../../csharp/language-reference/compiler-options/refout-compiler-option.md), [in Visual Basic](../../visual-basic/reference/command-line-compiler/refout-compiler-option.md)) compiler options
- When using the Roslyn API, by setting <xref:Microsoft.CodeAnalysis.Emit.EmitOptions.EmitMetadataOnly?displayProperty=nameWithType> to `true` and <xref:Microsoft.CodeAnalysis.Emit.EmitOptions.IncludePrivateMembers?displayProperty=nameWithType> to `false` in an object passed to the <xref:Microsoft.CodeAnalysis.Compilation.Emit%2A?displayProperty=nameWithType> method.

If you want to distribute reference assemblies with NuGet packages, you must include them in the *ref\\* subdirectory under the package directory instead of in the *lib\\* subdirectory used for implementation assemblies.

## Reference assemblies structure

Reference assemblies is an expansion of the related concept, *metadata-only assemblies*. Metadata-only assemblies have their method bodies replaced with a single `throw null` body, but include all members except anonymous types. The reason for using `throw null` bodies (as opposed to no bodies) is so that PEVerify can run and pass (thus validating the completeness of the metadata).

Reference assemblies further remove metadata (private members) from metadata-only assemblies:

- A reference assembly only has references for what it needs in the API surface. The real assembly may have additional references related to specific implementations. For instance, the reference assembly for `class C { private void M() { dynamic d = 1; ... } }` does not reference any types required for `dynamic`.
- Private function-members (methods, properties, and events) are removed in cases where their removal doesn't observably impact compilation. If there are no [InternalsVisibleTo](xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute) attributes, internal function members are also removed.

The metadata in reference assemblies continues to retain information about the following:

- All types, including private and nested types.
- All attributes, even internal ones.
- All virtual methods.
- Explicit interface implementations. 
- Explicitly implemented properties and events, because their accessors are virtual.
- All fields of structures. 

Reference assemblies include an assembly-level [ReferenceAssembly](xref:System.Runtime.CompilerServices.ReferenceAssemblyAttribute) attribute. This attribute may be specified in source; then the compiler won't need to synthesize it. Because of this attribute, runtimes will refuse to load reference assemblies for execution (but they can still be loaded in reflection-only mode).

Exact reference assembly structure details depend on the compiler version. Newer versions may choose to exclude more metadata if it is determined as not affecting the public API surface.

> [!NOTE]
> Information in this section is applicable only to reference assemblies generated by Roslyn compilers starting from C# version 7.1 or Visual Basic version 15.3. The structure of reference assemblies for .NET Framework versions released before that time can differ in some details. For example, they might have totally empty method bodies instead of the `throw null` body. But the general principle still applies: they don't have usable method implementations and contain metadata only for members that have an observable impact from a public API perspective.

## See also

- [Assemblies in .NET](index.md)
- [Program with assemblies](program.md)
- [Framework targeting overview](/visualstudio/ide/visual-studio-multi-targeting-overview)
- [How to: Add or remove references by using the Reference Manager](/visualstudio/ide/how-to-add-or-remove-references-by-using-the-reference-manager)
