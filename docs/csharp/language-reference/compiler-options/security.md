---
description: "C# Compiler Options for assembly signing and security. Learn about options that control strong-name signing and address space layout."
title: "Compiler Options - assembly signing and security options"
ms.date: 11/01/2026
f1_keywords:
  - "cs.build.options"
helpviewer_keywords:
  - "PublicSign compiler option [C#]"
  - "DelaySign compiler option [C#]"
  - "KeyFile compiler option [C#]"
  - "KeyContainer compiler option [C#]"
  - "HighEntropyVA compiler option [C#]"
---
# C# compiler options for assembly signing and security

The following options control assembly signing and security features. The new MSBuild syntax is shown in **Bold**. The older *csc.exe* syntax is shown in `code style`.

- **PublicSign** / `-publicsign`: Publicly sign the assembly.
- **DelaySign** / `-delaysign`: Delay-sign the assembly using only the public portion of the strong name key.
- **KeyFile** / `-keyfile`: Specify a strong name key file.
- **KeyContainer** / `-keycontainer`: Specify a strong name key container.
- **HighEntropyVA** / `-highentropyva`: Enable high-entropy Address Space Layout Randomization (ASLR).

> [!WARNING]
> Do not rely on strong naming for security. Strong naming provides a unique identity for an assembly so that other assemblies can reference it unambiguously. In modern .NET (.NET Core and .NET 5+), strong-name signatures are not validated at run time. For more information, see [Create and use strong-named assemblies](../../../standard/assembly/create-use-strong-named.md).

> [!NOTE]
> Refer to [Compiler options](index.md#how-to-set-options) for more information on configuring these options for your project.

## PublicSign

The **PublicSign** option causes the compiler to apply a public key to the assembly manifest without signing the assembly with a private key. This option also sets the signed flag in the assembly header.

```xml
<PublicSign>true</PublicSign>
```

The **PublicSign** option requires the [**KeyFile**](#keyfile) or [**KeyContainer**](#keycontainer) option to specify the public key. The **PublicSign** and **DelaySign** options are mutually exclusive.

Sometimes called *fake sign* or *OSS sign*, public signing includes the public key in an output assembly and marks the assembly as signed, but does not sign it with a private key. Open-source projects often use public signing so contributors can build assemblies compatible with release assemblies without needing access to private signing keys. Because modern .NET runtimes do not enforce strong-name signatures at run time, publicly signed assemblies work in almost every development and test scenario where a fully signed assembly is expected.

## DelaySign

The **DelaySign** option causes the compiler to reserve space in the output file so that a digital signature can be added later.

```xml
<DelaySign>true</DelaySign>
```

Use **DelaySign-** or omit the option for a fully signed assembly. Use **DelaySign** when you only want to place the public key in the assembly and defer signing. The **DelaySign** option has no effect unless used with [**KeyFile**](#keyfile) or [**KeyContainer**](#keycontainer). The **DelaySign** and [**PublicSign**](#publicsign) options are mutually exclusive.

When you request a fully signed assembly, the compiler hashes the file that contains the manifest (assembly metadata) and signs that hash with the private key, storing the resulting digital signature in the manifest file. When an assembly is delay signed, the compiler does not compute and store the signature, but reserves space in the file so the signature can be applied later (for example, by using the [Assembly Linker](../../../framework/tools/al-exe-assembly-linker.md) utility or a post-build signing tool). For more information, see [Create and use strong-named assemblies](../../../standard/assembly/create-use-strong-named.md) and [Delay-sign an assembly](../../../standard/assembly/delay-sign.md).

## KeyFile

Specifies the file name containing the strong-name key pair or public key.

```xml
<KeyFile>filename</KeyFile>
```

`filename` is the name of the file containing the strong-name key. When this option is used, the compiler inserts the public key from the specified file into the assembly manifest and then signs the final assembly with the private key. To generate a key file, run `sn -k <filename>` from the Developer Command Prompt.

If you compile with [**OutputType**](output.md#outputtype) set to `module`, the name of the key file is held in the module and incorporated into the assembly when you combine modules with [**AddModules**](inputs.md#addmodules).

You can also specify your key pair using [**KeyContainer**](#keycontainer). If both **KeyFile** and **KeyContainer** are specified in the same compilation, the compiler attempts to use the key container first. If the key container is found, the assembly is signed with that container. If the compiler does not find the key container, it uses the file specified with [**KeyFile**](#keyfile) and installs the key information into the key container for subsequent compilations.

A key file can contain only the public key when used with [**DelaySign**](#delaysign) or [**PublicSign**](#publicsign). For more information, see [Create and use strong-named assemblies](../../../standard/assembly/create-use-strong-named.md) and [Delay-sign an assembly](../../../standard/assembly/delay-sign.md).

## KeyContainer

Specifies the name of the strong-name cryptographic key container.

```xml
<KeyContainer>container</KeyContainer>
```

`container` is the name of the strong-name key container. When the **KeyContainer** option is used, the compiler creates a shareable component by inserting the public key from the specified container into the assembly manifest and signing the final assembly with the private key.

To generate a key pair and install it into a container, run `sn -k <filename>` followed by `sn -i <filename> <container>`.

> [!NOTE]
> The **KeyContainer** option is not supported when the compiler runs on .NET Core or .NET 5+. To sign an assembly when building on modern .NET SDKs, use the [**KeyFile**](#keyfile) option.

You can also specify a key container using the <xref:System.Reflection.AssemblyKeyNameAttribute?displayProperty=nameWithType> custom attribute in source code. Use [**DelaySign**](#delaysign) to place the public key in the assembly manifest and defer signing until after testing. For more information, see [Create and use strong-named assemblies](../../../standard/assembly/create-use-strong-named.md) and [Delay-sign an assembly](../../../standard/assembly/delay-sign.md).

## HighEntropyVA

The **HighEntropyVA** compiler option tells the 64-bit Windows kernel whether an executable supports high-entropy Address Space Layout Randomization (ASLR).

```xml
<HighEntropyVA>true</HighEntropyVA>
```

This option specifies that a 64-bit executable or an executable that is marked by the [**PlatformTarget**](output.md#platformtarget) compiler option supports a high-entropy virtual address space. The option is enabled by default for all .NET Standard, .NET Core, and .NET 5+ applications, and for .NET Framework versions starting with .NET Framework 4.5.

The **HighEntropyVA** option is a security feature that enables compatible versions of the Windows kernel to randomize the address space layout of a process using higher degrees of entropy. Higher degrees of entropy make it significantly more difficult for an attacker to predict memory addresses for stacks, heaps, and loaded modules. The **HighEntropyVA** compiler option requires the target executable and any modules that it depends on to handle pointer values larger than 4 gigabytes (GB) when running as a 64-bit process.
