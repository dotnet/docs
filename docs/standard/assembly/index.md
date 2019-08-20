---
title: "Assemblies in .NET"
ms.date: 08/15/2019
ms.assetid: 149f5ca5-5b34-4746-9542-1ae43b2d0256
helpviewer_keywords: 
  - "dynamic assemblies"
  - "security [.NET Framework], boundaries"
  - "boundaries of assemblies"
  - "assemblies [.NET Framework], about"
  - "assemblies [.NET Framework], boundaries"
  - "reference scope boundaries"
  - "assemblies [.NET Framework]"
  - "version boundaries"
  - "type boundaries"
author: "rpetrusha"
ms.author: "ronpet"
---

# Assemblies in .NET

Assemblies form the fundamental units of deployment, version control, reuse, activation scoping, and security permissions for .NET-based applications. Assemblies take the form of executable (*.exe*) or dynamic link library (*.dll*) files, and are the building blocks of .NET applications. They provide the common language runtime with the information it needs to be aware of type implementations. You can think of an assembly as a collection of types and resources that form a logical unit of functionality and are built to work together.

In .NET Core and .NET Framework, you can build an assembly from one or more source code files. In .NET Framework, assemblies can contain one or more modules. This allows larger projects to be planned so that several developers can work on separate source code files or modules, which are combined to create a single assembly. For more information about modules, see [How to: Build a multifile assembly](build-multifile.md).

Assemblies have the following properties:

- Assemblies are implemented as *.exe* or *.dll* files.

- For libraries that target the .NET Framework, you can share assemblies between applications by putting them in the [global assembly cache (GAC)](../../framework/app-domains/gac.md). You must strong-name assemblies before you can include them in the GAC. For more information, see [Strong-named assemblies](strong-named.md).

- Assemblies are only loaded into memory if they are required. If they aren't used, they aren't loaded. This means that assemblies can be an efficient way to manage resources in larger projects.

- You can programmatically obtain information about an assembly by using reflection. For more information, see [Reflection (C#)](../../csharp/programming-guide/concepts/reflection.md) or [Reflection (Visual Basic)](../../visual-basic/programming-guide/concepts/reflection.md).

- You can load an assembly just to inspect it by calling the method <xref:System.Reflection.Assembly.ReflectionOnlyLoadFrom%2A?displayProperty=nameWithType>.

## Assemblies in the Common Language Runtime

Assemblies provide the common language runtime with the information it needs to be aware of type implementations. To the runtime, a type does not exist outside the context of an assembly. 

An assembly defines the following information:  
  
- Code that the common language runtime executes. Microsoft intermediate language (MSIL) code in a portable executable (PE) file won't be executed unless it has an associated [assembly manifest](#assembly-manifest). Note that each assembly can have only one entry point: `DllMain`, `WinMain`, or `Main`.  
  
- Security boundary. An assembly is the unit at which permissions are requested and granted. For more information about security boundaries in assemblies, see [Assembly security considerations](security-considerations.md).  
  
- Type boundary. Every type's identity includes the name of the assembly in which it resides. A type called `MyType` that is loaded in the scope of one assembly is not the same as a type called `MyType` that is loaded in the scope of another assembly. 
  
- Reference scope boundary. The [assembly manifest](#assembly-manifest) has metadata that is used for resolving types and satisfying resource requests. The manifest specifies the types and resources to expose outside the assembly, and enumerates other assemblies on which it depends.  
  
- Version boundary. The assembly is the smallest versionable unit in the common language runtime. All types and resources in the same assembly are versioned as a unit. The [assembly manifest](#assembly-manifest) describes the version dependencies you specify for any dependent assemblies. For more information about versioning, see [Assembly versioning](versioning.md).  
  
- Deployment unit. When an application starts, only the assemblies that the application initially calls must be present. Other assemblies, such as assemblies containing localization resources or utility classes, can be retrieved on demand. This allows apps to be simple and thin when first downloaded. For more information about deploying assemblies, see [Deploy applications](../../framework/deployment/index.md).  
  
- Side-by-side execution unit. For more information about running multiple versions of an assembly, see [Assemblies and side-by-side execution](side-by-side-execution.md).  

## Create an assembly

Assemblies can be static or dynamic. Static assemblies are stored on disk in portable executable (PE) files. Static assemblies can include interfaces, classes, and resources like bitmaps, JPEG files, and other resource files. You can also create dynamic assemblies, which are run directly from memory and aren't saved to disk before execution. You can save dynamic assemblies to disk after they have executed.  

There are several ways to create assemblies. You can use development tools, such as Visual Studio, that can create *.dll* or *.exe* files. You can use tools in the Windows SDK to create assemblies with modules from other development environments. You can also use common language runtime APIs, such as <xref:System.Reflection.Emit?displayProperty=nameWithType>, to create dynamic assemblies. 

Compile assemblies by building them in Visual Studio, building them with .NET Core command-line interface tools, or building .NET Framework assemblies with a command-line compiler. For more information about building assemblies using .NET Core command-line interface tools, see [.NET Core command-line interface tools](../../core/tools/index.md). For building assemblies with the command-line compilers, see [Command-line build with csc.exe](../../csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md) for C#, or [Build from the command line](../../visual-basic/reference/command-line-compiler/building-from-the-command-line.md) for Visual Basic.

> [!NOTE]
> To build an assembly in Visual Studio, on the **Build** menu, select **Build**.

## Assembly manifest

Every assembly has an *assembly manifest* file. Similar to a table of contents, the assembly manifest contains:

- The assembly's identity (its name and version).

- A file table describing all the other files that make up the assembly, such as other assemblies you created that your *.exe* or *.dll* file relies on, bitmap files, or Readme files.

- An *assembly reference list*, which is a list of all external dependencies, such as *.dll*s or other files. Assembly references contain references to both global and private objects. Global objects are available to all other applications. In .NET Core, global objects are coupled with a particular .NET Core runtime. In .NET Framework, global objects reside in the global assembly cache (GAC). *System.IO.dll* is an example of an assembly in the GAC. Private objects must be in a directory level at or below the directory in which your app is installed.

Because assemblies contain information about content, versioning, and dependencies, the applications that use them needn't rely on external sources, such as the registry on Windows systems, to function properly. Assemblies reduce *.dll* conflicts and make your applications more reliable and easier to deploy. In many cases, you can install a .NET-based application simply by copying its files to the target computer. For more information, see [Assembly manifest](manifest.md).

## Add a reference to an assembly

To use an assembly in an application, you must add a reference to it. Once an assembly is referenced, all the accessible types, properties, methods, and other members of its namespaces are available to your application as if their code were part of your source file.

> [!NOTE]
> Most assemblies from the .NET Class Library are referenced automatically. If a system assembly isn't automatically referenced, for .NET Core, you can add a reference to the NuGet package that contains the assembly. Either use the NuGet Package Manager in Visual Studio, or add a [\<PackageReference>](../../core/tools/dependencies.md#the-new-packagereference-element) element for the assembly to the *.csproj* or *.vbproj* project. In .NET Framework, you can add a reference to the assembly by using the **Add Reference** dialog in Visual Studio, or by using the `-reference` command line option for the [C#](../../csharp/language-reference/compiler-options/reference-compiler-option.md) or [Visual Basic](../../visual-basic/reference/command-line-compiler/reference.md) compilers.

In C#, you can use two versions of the same assembly in a single application. For more information, see [extern alias](../../csharp/language-reference/keywords/extern-alias.md).

## Related content
  
|Title|Description|  
|-----------|-----------------|  
|[Assembly contents](contents.md)|Elements that make up an assembly.|  
|[Assembly manifest](manifest.md)|Data in the assembly manifest, and how it is stored in assemblies.|  
|[Global assembly cache](../../framework/app-domains/gac.md)|How the GAC stores and uses assemblies.|  
|[Strong-named assemblies](strong-named.md)|Characteristics of strong-named assemblies.|  
|[Assembly security considerations](security-considerations.md)|How security works with assemblies.|  
|[Assembly versioning](versioning.md)|Overview of the .NET Framework versioning policy.|  
|[Assembly placement](../../framework/app-domains/assembly-placement.md)|Where to locate assemblies.|  
|[Assemblies and side-by-side execution](side-by-side-execution.md)|Use multiple versions of the runtime or an assembly simultaneously.|  
|[Program with assemblies](program.md)|How to create, sign, and set attributes on assemblies.|  
|[Emit dynamic methods and assemblies](../../../docs/framework/reflection-and-codedom/emitting-dynamic-methods-and-assemblies.md)|How to create dynamic assemblies.|  
|[How the runtime locates assemblies](../../../docs/framework/deployment/how-the-runtime-locates-assemblies.md)|How the .NET Framework resolves assembly references at run time.|  

## Reference  
 <xref:System.Reflection.Assembly?displayProperty=nameWithType>

## See also

- [.NET assembly file format](file-format.md)
- [Assemblies in .NET](index.md)
- [Friend assemblies](friend.md)
- [How to: Load and unload assemblies](load-unload.md)
- [How to: Use and debug assembly unloadability in .NET Core](unloadability.md)
- [How to: Determine if a file is an assembly](identify.md)
