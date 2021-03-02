---
description: "C# Compiler Options for security options"
title: "C# Compiler Options - security options"
ms.date: 02/28/2021
f1_keywords: 
  - "cs.build.options"
helpviewer_keywords: 
  - "DelaySign compiler option [C#]"
  - "KeyFile compiler option [C#]"
  - "KeyContainer compiler option [C#]"
---
# C# Compiler Options for security options

The following options control compiler inputs. The new MSBuild syntax is shown in **Bold**. The older `csc.exe` syntax is shown in `code style`.

- **DelaySign** / `-delaysign`: Delay-sign the assembly using only the public portion of the strong name key.
- **KeyFile** / `-keyfile` : Specify a strong name key file.
- **KeyContainer** / `-keycontainer`: Specify a strong name key container.
- **??** / `-highentropyva`: Enable high-entropy ASLR

## DelaySign

This option causes the compiler to reserve space in the output file so that a digital signature can be added later.

```xml
<DelaySign>true</DelaySign>
```

Use **DelaySign-** if you want a fully signed assembly. Use **DelaySign+** if you only want to place the public key in the assembly. The default is **DelaySign**. The **DelaySign** option has no effect unless used with **KeyFile** or **KeyContainer**. The **KeyContainer** and **PublicSign** options are mutually exclusive. When you request a fully signed assembly, the compiler hashes the file that contains the manifest (assembly metadata) and signs that hash with the private key. That operation creates a digital signature which is stored in the file that contains the manifest. When an assembly is delay signed, the compiler does not compute and store the signature, but reserves space in the file so the signature can be added later.

For example, using **Delaysign** allows a tester to put the assembly in the global cache. After testing, you can fully sign the assembly by placing the private key in the assembly using the [Assembly Linker](../../../framework/tools/al-exe-assembly-linker.md) utility. For more information, see [Creating and Using Strong-Named Assemblies](../../../standard/assembly/create-use-strong-named.md) and [Delay Signing an Assembly](../../../standard/assembly/delay-sign.md).

## KeyFile

Specifies the filename containing the cryptographic key.

```xml
<KeyFile>filename</KeyFile>
```

`file` is the name of the file containing the strong name key. When this option is used, the compiler inserts the public key from the specified file into the assembly manifest and then signs the final assembly with the private key. To generate a key file, type sn -k `file` at the command line. If you compile with **-target:module**, the name of the key file is held in the module and incorporated into the assembly that is created when you compile an assembly with [-addmodule](./addmodule-compiler-option.md). You can also pass your encryption information to the compiler with [-keycontainer](./keycontainer-compiler-option.md). Use [-delaysign](./delaysign-compiler-option.md) if you want a partially signed assembly. In case both **KeyFile** and **KeyContainer** are specified (either by command line option or by custom attribute) in the same compilation, the compiler will first try the key container. If that succeeds, then the assembly is signed with the information in the key container. If the compiler does not find the key container, it will try the file specified with **KeyFile**. If that succeeds, the assembly is signed with the information in the key file and the key information will be installed in the key container (similar to sn -i) so that on the next compilation, the key container will be valid. Note that a key file might contain only the public key. For more information, see [Creating and Using Strong-Named Assemblies](../../../standard/assembly/create-use-strong-named.md) and [Delay Signing an Assembly](../../../standard/assembly/delay-sign.md).

## KeyContainer

Specifies the name of the cryptographic key container.

```xml
<KeyContainer>container</KeyContainer>
```

`container` is the name of the strong name key container. When the **KeyContainer** option is used, the compiler creates a sharable component. The compiler inserts a public key from the specified container into the assembly manifest and signs the final assembly with the private key. To generate a key file, type `sn -k file` at the command line. `sn -i` installs the key pair into a container. This option is not supported when the compiler runs on CoreCLR. To sign an assembly when building on CoreCLR, use the **KeyFile** option. If you compile with [-target:module](./target-module-compiler-option.md), the name of the key file is held in the module and incorporated into the assembly when you compile this module into an assembly with [-addmodule](./addmodule-compiler-option.md). You can also specify this option as a custom attribute (<xref:System.Reflection.AssemblyKeyNameAttribute?displayProperty=nameWithType>) in the source code for any Microsoft intermediate language (MSIL) module. You can also pass your encryption information to the compiler with **KeyFile**. Use **DelaySign** if you want the public key added to the assembly manifest but want to delay signing the assembly until it has been tested. For more information, see [Creating and Using Strong-Named Assemblies](../../../standard/assembly/create-use-strong-named.md) and [Delay Signing an Assembly](../../../standard/assembly/delay-sign.md).

## highentropyva

The **-highentropyva** compiler option tells the Windows kernel whether a particular executable supports high entropy Address Space Layout Randomization (ASLR).

```console
-highentropyva[+ | -]
```

This option specifies that a 64-bit executable or an executable that is marked by the [-platform:anycpu](./platform-compiler-option.md) compiler option supports a high entropy virtual address space. The option is disabled by default. Use **-highentropyva+** or **-highentropyva** to enable it.

The **-highentropyva** option enables compatible versions of the Windows kernel to use higher degrees of entropy when randomizing the address space layout of a process as part of ASLR. Using higher degrees of entropy means that a larger number of addresses can be allocated to memory regions such as stacks and heaps. As a result, it is more difficult to guess the location of a particular memory region. When the **-highentropyva** compiler option is specified, the target executable and any modules that it depends on must be able to handle pointer values that are larger than 4 gigabytes (GB) when they are running as a 64-bit process.
