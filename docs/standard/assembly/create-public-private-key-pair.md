---
title: "How to: Create a public-private key pair"
description: Learn how to create a public/private cryptographic key pair to use during compilation to create a strong-named assembly.
ms.date: "03/02/2026"
helpviewer_keywords:
  - "key pairs for strong-named assemblies"
  - "signing assemblies"
  - "assemblies [.NET], signing"
  - "cryptographic key pairs"
  - "snk files (key pair files)"
  - "public-private key pairs"
  - ".snk files"
  - "strong-named assemblies, key pairs"
dev_langs:
  - "csharp"
  - "vb"
  - "cpp"
ms.topic: how-to
ai-usage: ai-assisted
---
# How to: Create a public-private key pair

To sign an assembly with a strong name, you must have a public/private key pair. This public and private cryptographic key pair is used during compilation to create a strong-named assembly. You can create a key pair using the [Strong Name tool (Sn.exe)](../../framework/tools/sn-exe-strong-name-tool.md). Key pair files usually have an *.snk* extension.

> [!NOTE]
> On .NET (.NET Core and .NET 5 and later), strong names don't have runtime validation. Strong-name signing is mainly relevant for .NET Framework and .NET Standard 2.0 with .NET Framework interoperability scenarios. If you're not targeting .NET Framework, you typically don't need to strong name your assembly unless your organization or consumers require it.

> [!NOTE]
> In Visual Studio, the C# and Visual Basic project property pages include a **Signing** tab that enables you to select existing key files or to generate new key files without using *Sn.exe*. In Visual C++, you can specify the location of an existing key file in the **Advanced** property page in the **Linker** section of the **Configuration Properties** section of the **Property Pages** window. The use of the <xref:System.Reflection.AssemblyKeyFileAttribute> attribute to identify key file pairs was made obsolete beginning with Visual Studio 2005.

## Create a key pair

> [!NOTE]
> `Sn.exe` isn't included in the .NET SDK on any operating system. It's only available on Windows, where you get it by installing Visual Studio or the Windows SDK.

To create a key pair, at a command prompt, type the following command:

**sn –k** \<*file name*>

In this command, *file name* is the name of the output file containing the key pair.

The following example creates a key pair called *sgKey.snk*.

```cmd
sn -k sgKey.snk
```

If you intend to delay sign an assembly and you control the whole key pair (which is unlikely outside test scenarios), you can use the following commands to generate a key pair and then extract the public key from it into a separate file. First, create the key pair:

```cmd
sn -k keypair.snk
```

Next, extract the public key from the key pair and copy it to a separate file:

```cmd
sn -p keypair.snk public.snk
```

Once you create the key pair, you must put the file where the strong name signing tools can find it.

When signing an assembly with a strong name, the [Assembly Linker (Al.exe)](../../framework/tools/al-exe-assembly-linker.md) looks for the key file relative to the current directory and to the output directory. When using command-line compilers, you can simply copy the key to the current directory containing your code modules.

If you are using an earlier version of Visual Studio that does not have a **Signing** tab in the project properties, the recommended key file location is the project directory with the file attribute specified as follows:

```cpp
[assembly:AssemblyKeyFileAttribute("keyfile.snk")];
```

```csharp
[assembly:AssemblyKeyFileAttribute("keyfile.snk")]
```

```vb
<Assembly:AssemblyKeyFileAttribute("keyfile.snk")>
```

## See also

- [Create and use strong-named assemblies](create-use-strong-named.md)
