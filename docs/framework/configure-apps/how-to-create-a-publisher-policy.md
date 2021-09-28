---
title: "How to: Create a Publisher Policy"
description: Learn how assembly vendors can create a publisher policy file with an upgraded assembly in .NET, to stipulate that applications should use the newer version.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "publisher policy assembly"
  - "publisher policy files"
  - "GAC (global assembly cache), publisher policy assembly"
  - "global assembly cache, publisher policy assembly"
ms.assetid: 8046bc5d-2fa9-4277-8a5e-6dcc96c281d9
---
# How to: Create a Publisher Policy

Vendors of assemblies can state that applications should use a newer version of an assembly by including a publisher policy file with the upgraded assembly. The publisher policy file specifies assembly redirection and code base settings, and uses the same format as an application configuration file. The publisher policy file is compiled into an assembly and placed in the global assembly cache.

There are three steps involved in creating a publisher policy:

1. Create a publisher policy file.

2. Create a publisher policy assembly.

3. Add the publisher policy assembly to the global assembly cache.

The schema for publisher policy is described in [Redirecting Assembly Versions](redirect-assembly-versions.md). The following example shows a publisher policy file that redirects one version of `myAssembly` to another.

```xml
<configuration>
   <runtime>
      <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
       <dependentAssembly>
         <assemblyIdentity name="myAssembly"
                           publicKeyToken="32ab4ba45e0a69a1"
                           culture="en-us" />
         <!-- Redirecting to version 2.0.0.0 of the assembly. -->
         <bindingRedirect oldVersion="1.0.0.0"
                          newVersion="2.0.0.0"/>
       </dependentAssembly>
      </assemblyBinding>
   </runtime>
</configuration>
```

To learn how to specify a code base, see [Specifying an Assembly's Location](specify-assembly-location.md).

## Creating the Publisher Policy Assembly

Use the [Assembly Linker (Al.exe)](../tools/al-exe-assembly-linker.md) to create the publisher policy assembly.

#### To create a publisher policy assembly

Type the following command at the command prompt:

```console
al /link:publisherPolicyFile /out:publisherPolicyAssemblyFile /keyfile:keyPairFile /platform:processorArchitecture
```

In this command:

- The `publisherPolicyFile` argument is the name of the publisher policy file.

- The `publisherPolicyAssemblyFile` argument is the name of the publisher policy assembly that results from this command. The assembly file name must follow the format:

  `policy.majorNumber.minorNumber.mainAssemblyName.dll'

- The `keyPairFile` argument is the name of the file containing the key pair. You must sign the assembly and publisher policy assembly with the same key pair.

- The `processorArchitecture` argument identifies the platform targeted by a processor-specific assembly.

  > [!NOTE]
  > The ability to target a specific processor architecture is available starting with .NET Framework 2.0.

The ability to target a specific processor architecture is available starting with .NET Framework 2.0. The following command creates a publisher policy assembly called `policy.1.0.myAssembly` from a publisher policy file called `pub.config`, assigns a strong name to the assembly using the key pair in the `sgKey.snk` file, and specifies that the assembly targets the x86 processor architecture.

```console
al /link:pub.config /out:policy.1.0.myAssembly.dll /keyfile:sgKey.snk /platform:x86
```

The publisher policy assembly must match the processor architecture of the assembly that it applies to. Thus, if your assembly has a <xref:System.Reflection.AssemblyName.ProcessorArchitecture%2A> value of <xref:System.Reflection.ProcessorArchitecture.MSIL>, the publisher policy assembly for that assembly must be created with `/platform:anycpu`. You must provide a separate publisher policy assembly for each processor-specific assembly.

A consequence of this rule is that in order to change the processor architecture for an assembly, you must change the major or minor component of the version number, so that you can supply a new publisher policy assembly with the correct processor architecture. The old publisher policy assembly cannot service your assembly once your assembly has a different processor architecture.

Another consequence is that the version 2.0 linker cannot be used to create a publisher policy assembly for an assembly compiled using earlier versions of the .NET Framework, because it always specifies processor architecture.

## Adding the Publisher Policy Assembly to the Global Assembly Cache

Use the [Global Assembly Cache tool (Gacutil.exe)](../tools/gacutil-exe-gac-tool.md) to add the publisher policy assembly to the global assembly cache.

### To add the publisher policy assembly to the global assembly cache

Type the following command at the command prompt:

```console
gacutil /i publisherPolicyAssemblyFile
```

The following command adds `policy.1.0.myAssembly.dll` to the global assembly cache.

```console
gacutil /i policy.1.0.myAssembly.dll
```

> [!IMPORTANT]
> The publisher policy assembly cannot be added to the global assembly cache unless the original publisher policy file specified in the `/link` argument is located in the same directory as the assembly.

## See also

- [Programming with Assemblies](../../standard/assembly/index.md)
- [How the Runtime Locates Assemblies](../deployment/how-the-runtime-locates-assemblies.md)
- [Configuring Apps by using Configuration Files](index.md)
- [Runtime Settings Schema](./file-schema/runtime/index.md)
- [Configuration File Schema](./file-schema/index.md)
- [Redirecting Assembly Versions](redirect-assembly-versions.md)
