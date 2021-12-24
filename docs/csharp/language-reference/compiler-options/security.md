---
description: "C# Compiler Options for security. These options control signing assemblies or address space layout."
title: "C# Compiler Options - security options"
ms.date: 03/12/2021
f1_keywords: 
  - "cs.build.options"
helpviewer_keywords: 
  - "PublicSign compiler option [C#]"
  - "DelaySign compiler option [C#]"
  - "KeyFile compiler option [C#]"
  - "KeyContainer compiler option [C#]"
  - "HighEntropyVA compiler option [C#]"
---
# C# compiler options for security

The following options control compiler security options. The new MSBuild syntax is shown in **Bold**. The older *csc.exe* syntax is shown in `code style`.

- **PublicSign** / `-publicsign`: Publicly sign the assembly.
- **DelaySign** / `-delaysign`: Delay-sign the assembly using only the public portion of the strong name key.
- **KeyFile** / `-keyfile` : Specify a strong name key file.
- **KeyContainer** / `-keycontainer`: Specify a strong name key container.
- **HighEntropyVA** / `-highentropyva`: Enable high-entropy Address Space Layout Randomization (ASLR)

## PublicSign

This option causes the compiler to apply a public key but doesn't actually sign the assembly. The **PublicSign** option also sets a bit in the assembly that tells the runtime that the file is signed.

```xml
<PublicSign>true</PublicSign>
```

The **PublicSign** option requires the use of the [**KeyFile**](#keyfile) or [**KeyContainer**](#keycontainer) option. The **keyFile** and **KeyContainer** options specify the public key. The **PublicSign** and **DelaySign** options are mutually exclusive. Sometimes called "fake sign" or "OSS sign", public signing includes the public key in an output assembly and sets the "signed" flag. Public signing doesn't actually sign the assembly with a private key. Developers use public sign for open-source projects.  People build assemblies that are compatible with the released "fully signed" assemblies when they don't have access to the private key used to sign the assemblies. Since few consumers actually need to check if the assembly is fully signed, these publicly built assemblies are useable in almost every scenario where the fully signed one would be used.

## DelaySign

This option causes the compiler to reserve space in the output file so that a digital signature can be added later.

```xml
<DelaySign>true</DelaySign>
```

Use **DelaySign-** if you want a fully signed assembly. Use **DelaySign** if you only want to place the public key in the assembly. The **DelaySign** option has no effect unless used with [**KeyFile**](#keyfile) or [**KeyContainer**](#keycontainer). The [**KeyContainer**](#keycontainer) and [**PublicSign**](#publicsign) options are mutually exclusive. When you request a fully signed assembly, the compiler hashes the file that contains the manifest (assembly metadata) and signs that hash with the private key. That operation creates a digital signature that is stored in the file that contains the manifest. When an assembly is delay signed, the compiler doesn't compute and store the signature. Instead, the compiler but reserves space in the file so the signature can be added later.

Using **DelaySign** allows a tester to put the assembly in the global cache. After testing, you can fully sign the assembly by placing the private key in the assembly using the [Assembly Linker](../../../framework/tools/al-exe-assembly-linker.md) utility. For more information, see [Creating and Using Strong-Named Assemblies](../../../standard/assembly/create-use-strong-named.md) and [Delay Signing an Assembly](../../../standard/assembly/delay-sign.md).

## KeyFile

Specifies the filename containing the cryptographic key.

```xml
<KeyFile>filename</KeyFile>
```

`file` is the name of the file containing the strong name key. When this option is used, the compiler inserts the public key from the specified file into the assembly manifest and then signs the final assembly with the private key. To generate a key file, type `sn -k file` at the command line. If you compile with [**-target:module**](output.md#targettype), the name of the key file is held in the module and incorporated into the assembly created when you compile an assembly with [**AddModules**](inputs.md#addmodules). You can also pass your encryption information to the compiler with [**KeyContainer**](#keycontainer). Use [**DelaySign**](#delaysign) if you want a partially signed assembly. In case both **KeyFile** and **KeyContainer** are specified in the same compilation, the compiler will first try the key container. If that succeeds, then the assembly is signed with the information in the key container. If the compiler doesn't find the key container, it will try the file specified with [**KeyFile**](#keyfile). If that succeeds, the assembly is signed with the information in the key file and the key information will be installed in the key container. On the next compilation, the key container will be valid. A key file might contain only the public key. For more information, see [Creating and Using Strong-Named Assemblies](../../../standard/assembly/create-use-strong-named.md) and [Delay Signing an Assembly](../../../standard/assembly/delay-sign.md).

## KeyContainer

Specifies the name of the cryptographic key container.

```xml
<KeyContainer>container</KeyContainer>
```

`container` is the name of the strong name key container. When the **KeyContainer** option is used, the compiler creates a sharable component. The compiler inserts a public key from the specified container into the assembly manifest and signs the final assembly with the private key. To generate a key file, type `sn -k file` at the command line. `sn -i` installs the key pair into a container. This option isn't supported when the compiler runs on CoreCLR. To sign an assembly when building on CoreCLR, use the [**KeyFile**](#keyfile) option. If you compile with [**TargetType**](output.md#targettype), the name of the key file is held in the module and incorporated into the assembly when you compile this module into an assembly with [**AddModules**](inputs.md#addmodules). You can also specify this option as a custom attribute (<xref:System.Reflection.AssemblyKeyNameAttribute?displayProperty=nameWithType>) in the source code for any Microsoft intermediate language (MSIL) module. You can also pass your encryption information to the compiler with [**KeyFile**](#keyfile). Use [**DelaySign**](#delaysign) to add the public key  to the assembly manifest but signing the assembly until it has been tested. For more information, see [Creating and Using Strong-Named Assemblies](../../../standard/assembly/create-use-strong-named.md) and [Delay Signing an Assembly](../../../standard/assembly/delay-sign.md).

## HighEntropyVA

The **HighEntropyVA** compiler option tells the Windows kernel whether a particular executable supports high entropy Address Space Layout Randomization (ASLR).

```xml
<HighEntropyVA>true</HighEntropyVA>
```

This option specifies that a 64-bit executable or an executable that is marked by the [**PlatformTarget**](output.md#platformtarget) compiler option supports a high entropy virtual address space. The option is disabled by default. Use **HighEntropyVA** to enable it.

The **HighEntropyVA** option enables compatible versions of the Windows kernel to use higher degrees of entropy when randomizing the address space layout of a process as part of ASLR. Using higher degrees of entropy means a larger number of addresses can be allocated to memory regions such as stacks and heaps. As a result, it's more difficult to guess the location of a particular memory region. The **HighEntropyVA** compiler option requires the target executable and any modules that it depends on can handle pointer values larger than 4 gigabytes (GB) when they're running as a 64-bit process.
