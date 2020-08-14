---
title: "-publicsign (C# Compiler Options)"
ms.date: 05/15/2018
f1_keywords: 
  - "/publicsign"
helpviewer_keywords: 
  - "-publicsign compiler option [C#]"
  - "publicsign compiler option [C#]"
  - "/publicsign compiler option [C#]"
---
# -publicsign (C# Compiler Options)

This option causes the compiler to apply a public key but does not actually sign the assembly. The **-publicsign** option also sets a bit in the assembly that tells the runtime that the file is actually signed.

## Syntax

```console
-publicsign
```

## Arguments

None.

## Remarks

The **-publicsign** option requires the use of the [-keyfile](keyfile-compiler-option.md) or [-keycontainer](keycontainer-compiler-option.md). The **keyfile** or **keycontainer** options specify the public key.

The **-publicsign** and **-delaysign** options are mutually exclusive.

Sometimes called "fake sign" or "OSS sign", public signing includes the public key in an output assembly and sets the "signed" flag, but doesn't actually sign the assembly with a private key. This is useful for open source projects where people want to build assemblies which are compatible with the released "fully signed" assemblies, but don't have access to the private key used to sign the assemblies. Since almost no consumers actually need to check if the assembly is fully signed, these publicly built assemblies are useable in almost every scenario where the fully signed one would be used.

### To set this compiler option in a csproj file

Open the .csproj file for a project, and add the following element:

```xml
<PublicSign>true</PublicSign>
```

## See also

- [C# Compiler -delaysign option](delaysign-compiler-option.md)
- [C# Compiler -keyfile option](keyfile-compiler-option.md)
- [C# Compiler -keycontainer option](keycontainer-compiler-option.md)
- [C# Compiler Options](index.md)
- [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)
