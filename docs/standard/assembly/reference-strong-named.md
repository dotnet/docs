---
title: "How to: Reference a strong-named assembly"
ms.date: "08/20/2019"
helpviewer_keywords:
  - "strong-named assemblies, compile-time references"
  - "compile-time assembly referencing"
  - "assemblies [.NET Framework], strong-named"
  - "assembly binding, strong-named"
ms.assetid: 4c6a406a-b5eb-44fa-b4ed-4e95bb95a813
author: "rpetrusha"
ms.author: "ronpet"
dev_langs:
  - "csharp"
  - "vb"
  - "cpp"
---
# How to: Reference a strong-named assembly

The process for referencing types or resources in a strong-named assembly is usually transparent. You can make the reference either at compile time (early binding) or at run time.

A compile-time reference occurs when you indicate to the compiler that the assembly to be compiled explicitly references another assembly. When you use compile-time referencing, the compiler automatically gets the public key of the targeted strong-named assembly and places it in the assembly reference of the assembly being compiled.

> [!NOTE]
> A strong-named assembly can only use types from other strong-named assemblies. Otherwise, the security of the strong-named assembly would be compromised.

## Make a compile-time reference to a strong-named assembly

At a command prompt, type the following command:

\<*compiler command*> **/reference:**\<*assembly name*>

In this command, *compiler command* is the compiler command for the language you are using, and *assembly name* is the name of the strong-named assembly being referenced. You can also use other compiler options, such as the **/t:library** option for creating a library assembly.

The following example creates an assembly called *myAssembly.dll* that references a strong-named assembly called *myLibAssembly.dll* from a code module called *myAssembly.cs*.

```console
csc /t:library myAssembly.cs /reference:myLibAssembly.dll
```

## Make a run-time reference to a strong-named assembly

When you make a run-time reference to a strong-named assembly, for example by using the <xref:System.Reflection.Assembly.Load%2A?displayProperty=nameWithType> or <xref:System.Reflection.Assembly.GetType%2A?displayProperty=nameWithType> method, you must use the display name of the referenced strong-named assembly. The syntax of a display name is as follows:

\<*assembly name*>**,** \<*version number*>**,** \<*culture*>**,** \<*public key token*>

For example:

```console
myDll, Version=1.1.0.0, Culture=en, PublicKeyToken=03689116d3a4ae33
```

In this example, `PublicKeyToken` is the hexadecimal form of the public key token. If there is no culture value, use `Culture=neutral`.

The following code example shows how to use this information with the <xref:System.Reflection.Assembly.Load%2A?displayProperty=nameWithType> method.

```cpp
Assembly^ myDll =
    Assembly::Load("myDll, Version=1.0.0.1, Culture=neutral, PublicKeyToken=9b35aa32c18d4fb1");
```

```csharp
Assembly myDll =
    Assembly.Load("myDll, Version=1.0.0.1, Culture=neutral, PublicKeyToken=9b35aa32c18d4fb1");
```

```vb
Dim myDll As Assembly = _
    Assembly.Load("myDll, Version=1.0.0.1, Culture=neutral, PublicKeyToken=9b35aa32c18d4fb1")
```

You can print the hexadecimal format of the public key and public key token for a specific assembly by using the following [Strong Name (Sn.exe)](../../framework/tools/sn-exe-strong-name-tool.md) command:

**sn -Tp \<** *assembly* **>**

If you have a public key file, you can use the following command instead (note the difference in case on the command-line option):

**sn -tp \<** *public key file* **>**

## See also

- [Create and use strong-named assemblies](create-use-strong-named.md)
