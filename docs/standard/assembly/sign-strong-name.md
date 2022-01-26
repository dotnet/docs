---
title: "How to: Sign an assembly with a strong name"
description: This article shows you how to sign a .NET assembly with a strong name by using the Signing tab, the Assembly Linker, assembly attributes, or compiler options.
ms.date: 01/05/2022
helpviewer_keywords:
  - "strong-named assemblies, signing with strong names"
  - "signing assemblies"
  - "assemblies [.NET], signing"
  - "assemblies [.NET], strong-named"
ms.topic: how-to
dev_langs:
  - "csharp"
  - "vb"
  - "cpp"
---

# How to: Sign an assembly with a strong name

> [!NOTE]
> Although .NET Core supports strong-named assemblies, and all assemblies in the .NET Core library are signed, the majority of third-party assemblies do not need strong names. For more information, see [Strong Name Signing](https://github.com/dotnet/runtime/blob/main/docs/project/strong-name-signing.md) on GitHub.

There are a number of ways to sign an assembly with a strong name:

- By using the **Signing** tab in a project's **Properties** dialog box in Visual Studio. This is the easiest and most convenient way to sign an assembly with a strong name.
- By using the [Assembly Linker (Al.exe)](../../framework/tools/al-exe-assembly-linker.md) to link a .NET Framework code module (a _.netmodule_ file) with a key file.
- By using assembly attributes to insert the strong name information into your code. You can use either the <xref:System.Reflection.AssemblyKeyFileAttribute> or the <xref:System.Reflection.AssemblyKeyNameAttribute> attribute, depending on where the key file to be used is located.
- By using compiler options.

You must have a cryptographic key pair to sign an assembly with a strong name. For more information about creating a key pair, see [How to: Create a public-private key pair](create-public-private-key-pair.md).

## Create and sign an assembly with a strong name by using Visual Studio

1. In **Solution Explorer**, open the shortcut menu for the project, and then choose **Properties**.
1. Under the **Build** tab you'll find a **Strong naming** node.
1. Select the **Sign the assembly** checkbox, which expands the options.
1. Select the **Browse** button to choose a **Strong name key file** path.

> [!NOTE]
> In order to [delay sign an assembly](delay-sign.md), choose a public key file.

:::image type="content" source="./media/strong-naming-properties.png" alt-text="Visual Studio 2022: Project properties, Build / Strong naming section.":::

### Create and sign an assembly with a strong name by using the Assembly Linker

Open [Visual Studio Developer Command Prompt or Visual Studio Developer PowerShell](/visualstudio/ide/reference/command-prompt-powershell), and enter the following command:

**al** **/out:**\<_assemblyName_> _\<moduleName>_ **/keyfile:**\<_keyfileName_>

Where:

- _assemblyName_ is the name of the strongly signed assembly (a _.dll_ or _.exe_ file) that Assembly Linker will emit.
- _moduleName_ is the name of a .NET Framework code module (a _.netmodule_ file) that includes one or more types. You can create a _.netmodule_ file by compiling your code with the `/target:module` switch in C# or Visual Basic.
- _keyfileName_ is the name of the container or file that contains the key pair. Assembly Linker interprets a relative path in relation to the current directory.

The following example signs the assembly _MyAssembly.dll_ with a strong name by using the key file _sgKey.snk_.

```console
al /out:MyAssembly.dll MyModule.netmodule /keyfile:sgKey.snk
```

For more information about this tool, see [Assembly Linker](../../framework/tools/al-exe-assembly-linker.md).

## Sign an assembly with a strong name by using attributes

1. Add the <xref:System.Reflection.AssemblyKeyFileAttribute?displayProperty=nameWithType> or <xref:System.Reflection.AssemblyKeyNameAttribute> attribute to your source code file, and specify the name of the file or container that contains the key pair to use when signing the assembly with a strong name.

2. Compile the source code file normally.

    > [!NOTE]
    > The C# and Visual Basic compilers issue compiler warnings (CS1699 and BC41008, respectively) when they encounter the <xref:System.Reflection.AssemblyKeyFileAttribute> or <xref:System.Reflection.AssemblyKeyNameAttribute> attribute in source code. You can ignore the warnings.

The following example uses the <xref:System.Reflection.AssemblyKeyFileAttribute> attribute with a key file called _keyfile.snk_, which is located in the directory where the assembly is compiled.

```cpp
[assembly:AssemblyKeyFileAttribute("keyfile.snk")];
```

```csharp
[assembly:AssemblyKeyFileAttribute("keyfile.snk")]
```

```vb
<Assembly:AssemblyKeyFileAttribute("keyfile.snk")>
```

You can also delay sign an assembly when compiling your source file. For more information, see [Delay-sign an assembly](delay-sign.md).

## Sign an assembly with a strong name by using the compiler

Compile your source code file or files with the `/keyfile` or `/delaysign` compiler option in C# and Visual Basic, or the `/KEYFILE` or `/DELAYSIGN` linker option in C++. After the option name, add a colon and the name of the key file. When using command-line compilers, you can copy the key file to the directory that contains your source code files.

For information on delay signing, see [Delay-sign an assembly](delay-sign.md).

The following example uses the C# compiler and signs the assembly _UtilityLibrary.dll_ with a strong name by using the key file _sgKey.snk_.

```cmd
csc /t:library UtilityLibrary.cs /keyfile:sgKey.snk
```

## See also

- [Create and use strong-named assemblies](create-use-strong-named.md)
- [How to: Create a public-private key pair](create-public-private-key-pair.md)
- [Al.exe (Assembly Linker)](../../framework/tools/al-exe-assembly-linker.md)
- [Delay-sign an assembly](delay-sign.md)
- [Manage assembly and manifest signing](/visualstudio/ide/managing-assembly-and-manifest-signing)
- [Signing page, Project Designer](/visualstudio/ide/reference/signing-page-project-designer)
