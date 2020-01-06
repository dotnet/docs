---
title: "Create and use strong-named assemblies"
ms.date: "08/19/2019"
helpviewer_keywords:
  - "strong-name bypass feature"
  - "strong-named assemblies, about strong-named assemblies"
  - "strong-named assemblies"
  - "signing assemblies"
  - "assemblies [.NET Framework], signing"
  - "strong-named assemblies, scenarios"
  - "assemblies [.NET Framework], strong-named"
  - "strong-named assemblies, loading into trusted application domains"
  - "assembly binding, strong-named"
ms.assetid: ffbf6d9e-4a88-4a8a-9645-4ce0ee1ee5f9
---
# Create and use strong-named assemblies

A strong name consists of the assembly's identity—its simple text name, version number, and culture information (if provided)—plus a public key and a digital signature. It is generated from an assembly file using the corresponding private key. (The assembly file contains the assembly manifest, which contains the names and hashes of all the files that make up the assembly.)

> [!WARNING]
> Do not rely on strong names for security. They provide a unique identity only.

A strong-named assembly can only use types from other strong-named assemblies. Otherwise, the integrity of the strong-named assembly would be compromised.

> [!NOTE]
> Although .NET Core supports strong-named assemblies, and all assemblies in the .NET Core library are signed, the majority of third-party assemblies do not need strong names. For more information, see [Strong Name Signing](https://github.com/dotnet/corefx/blob/master/Documentation/project-docs/strong-name-signing.md) on GitHub.

## Strong name scenario

The following scenario outlines the process of signing an assembly with a strong name and later referencing it by that name.

1. Assembly A is created with a strong name using one of the following methods:

    - Using a development environment that supports creating strong names, such as Visual Studio.

    - Creating a cryptographic key pair using the [Strong Name tool (Sn.exe)](../../framework/tools/sn-exe-strong-name-tool.md) and assigning that key pair to the assembly using either a command-line compiler or the [Assembly Linker (Al.exe)](../../framework/tools/al-exe-assembly-linker.md). The Windows SDK provides both Sn.exe and Al.exe.

2. The development environment or tool signs the hash of the file containing the assembly's manifest with the developer's private key. This digital signature is stored in the portable executable (PE) file that contains Assembly A's manifest.

3. Assembly B is a consumer of Assembly A. The reference section of Assembly B's manifest includes a token that represents Assembly A's public key. A token is a portion of the full public key and is used rather than the key itself to save space.

4. The common language runtime verifies the strong name signature when the assembly is placed in the global assembly cache. When binding by strong name at run time, the common language runtime compares the key stored in Assembly B's manifest with the key used to generate the strong name for Assembly A. If the .NET Framework security checks pass and the bind succeeds, Assembly B has a guarantee that Assembly A's bits have not been tampered with and that these bits actually come from the developers of Assembly A.

> [!NOTE]
> This scenario doesn't address trust issues. Assemblies can carry full Microsoft Authenticode signatures in addition to a strong name. Authenticode signatures include a certificate that establishes trust. It's important to note that strong names don't require code to be signed in this way. Strong names only provide a unique identity.

## Bypass signature verification of trusted assemblies

Starting with the .NET Framework 3.5 Service Pack 1, strong-name signatures are not validated when an assembly is loaded into a full-trust application domain, such as the default application domain for the `MyComputer` zone. This is referred to as the strong-name bypass feature. In a full-trust environment, demands for <xref:System.Security.Permissions.StrongNameIdentityPermission> always succeed for signed, full-trust assemblies, regardless of their signature. The strong-name bypass feature avoids the unnecessary overhead of strong-name signature verification of full-trust assemblies in this situation, allowing the assemblies to load faster.

The bypass feature applies to any assembly that is signed with a strong name and that has the following characteristics:

- Fully trusted without <xref:System.Security.Policy.StrongName> evidence (for example, has `MyComputer` zone evidence).

- Loaded into a fully trusted <xref:System.AppDomain>.

- Loaded from a location under the <xref:System.AppDomainSetup.ApplicationBase%2A> property of that <xref:System.AppDomain>.

- Not delay-signed.

This feature can be disabled for individual applications or for a computer. See [How to: Disable the strong-name bypass feature](disable-strong-name-bypass-feature.md).

## Related topics

|Title|Description|
|-----------|-----------------|
|[How to: Create a public-private key pair](create-public-private-key-pair.md)|Describes how to create a cryptographic key pair for signing an assembly.|
|[How to: Sign an assembly with a strong name](sign-strong-name.md)|Describes how to create a strong-named assembly.|
|[Enhanced strong naming](enhanced-strong-naming.md)|Describes enhancements to strong-names in the .NET Framework 4.5.|
|[How to: Reference a strong-named assembly](reference-strong-named.md)|Describes how to reference types or resources in a strong-named assembly at compile time or run time.|
|[How to: Disable the strong-name bypass feature](disable-strong-name-bypass-feature.md)|Describes how to disable the feature that bypasses the validation of strong-name signatures. This feature can be disabled for all or for specific applications.|
|[Create assemblies](create.md)|Provides an overview of single-file and multifile assemblies.|
|[How to delay sign an assembly in Visual Studio](/visualstudio/ide/managing-assembly-and-manifest-signing#how-to-sign-an-assembly-in-visual-studio)|Explains how to sign an assembly with a strong name after the assembly has been created.|
|[Sn.exe (Strong Name tool)](../../framework/tools/sn-exe-strong-name-tool.md)|Describes the tool included in the .NET Framework that helps create assemblies with strong names. This tool provides options for key management, signature generation, and signature verification.|
|[Al.exe (Assembly linker)](../../framework/tools/al-exe-assembly-linker.md)|Describes the tool included in the .NET Framework that generates a file that has an assembly manifest from modules or resource files.|
