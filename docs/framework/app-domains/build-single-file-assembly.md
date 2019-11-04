---
title: "How to: Build a .NET Framework single-file assembly"
ms.date: "08/20/2019"
helpviewer_keywords:
  - "assembly manifest, single-file assemblies"
  - "library assemblies"
  - "command-line compilers"
  - "assemblies [.NET Framework], single-file"
  - "output file name for assemblies"
  - "code modules"
  - "single-file assemblies"
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: a6063221-43a5-4d3e-814c-288a4ec69aec
---
# How to: Build a .NET Framework single-file assembly

A single-file assembly, which is the simplest type of assembly, contains type information and implementation, as well as the [assembly manifest](../../standard/assembly/manifest.md). You can use command-line compilers or Visual Studio to create a single-file assembly that targets the .NET Framework. By default, the compiler creates an assembly file with an *.exe* extension.

> [!NOTE]
> Visual Studio for C# and Visual Basic can be used only to create single-file assemblies. If you want to create multifile assemblies, you must use command-line compilers or Visual C++.

The following procedures show how to create single-file assemblies using command-line compilers.

## Create an assembly with an .exe extension

At the command prompt, type the following command:

\<*compiler command*> \<*module name*>

In this command, *compiler command* is the compiler command for the language used in your code module, and *module name* is the name of the code module to compile into the assembly.

The following example creates an assembly named *myCode.exe* from a code module called `myCode`.

```csharp
csc myCode.cs
```

```vb
vbc myCode.vb
```

## Create an assembly with an .exe extension and specify the output file name

At the command prompt, type the following command:

\<*compiler command*> **/out:**\<*file name*> \<*module name*>

In this command, *compiler command* is the compiler command for the language used in your code module, *file name* is the output file name, and *module name* is the name of the code module to compile into the assembly.

The following example creates an assembly named *myAssembly.exe* from a code module called `myCode`.

```csharp
csc -out:myAssembly.exe myCode.cs
```

```vb
vbc -out:myAssembly.exe myCode.vb
```

## Create library assemblies
 A library assembly is similar to a class library. It contains types that will be referenced by other assemblies, but it has no entry point to begin execution.

To create a library assembly, at the command prompt, type the following command:

\<*compiler command*> **-t:library** \<*module name*>

In this command, *compiler command* is the compiler command for the language used in your code module, and *module name* is the name of the code module to compile into the assembly. You can also use other compiler options, such as the **-out:** option.

The following example creates a library assembly named *myCodeAssembly.dll* from a code module called `myCode`.

```csharp
csc -out:myCodeLibrary.dll -t:library myCode.cs
```

```vb
vbc -out:myCodeLibrary.dll -t:library myCode.vb
```

## See also

- [Create assemblies](../../standard/assembly/create.md)
- [Multifile assemblies](multifile-assemblies.md)
- [How to: Build a multifile assembly](build-multifile-assembly.md)
- [Program with assemblies](../../standard/assembly/program.md)
