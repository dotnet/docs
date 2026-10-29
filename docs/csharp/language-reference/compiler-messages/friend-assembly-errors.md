---
title: "Resolve errors and warnings related to friend assembly identity and public keys"
description: "This article helps you diagnose and correct compiler errors and warnings related to friend assembly identity and public keys"
f1_keywords:
  - "CS0281"
  - "CS1700"
  - "CS1725"
  - "CS1726"
  - "CS7029"
  - "CS7030"
helpviewer_keywords:
  - "CS0281"
  - "CS1700"
  - "CS1725"
  - "CS1726"
  - "CS7029"
  - "CS7030"
ms.date: 10/29/2026
ai-usage: ai-assisted
---

# Resolve errors and warnings for friend assemblies

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->

- [**CS0281**](#anchor-tbd): *Friend access was granted by 'assembly', but the public key of the output assembly ('public key') does not match that specified by the InternalsVisibleTo attribute in the granting assembly.*
- [**CS1700**](#anchor-tbd): *Assembly reference 'assembly' is invalid and cannot be resolved*
- [**CS1725**](#anchor-tbd): *Friend assembly reference 'assembly' is invalid. InternalsVisibleTo declarations cannot have a version, culture, public key token, or processor architecture specified.*
- [**CS1726**](#anchor-tbd): *Friend assembly reference 'assembly' is invalid. Strong-name signed assemblies must specify a public key in their InternalsVisibleTo declarations.*
- [**CS7029**](#anchor-tbd): *Friend access was granted by 'assembly', but the strong name signing state of the output assembly does not match that of the granting assembly.*
- [**CS7030**](#anchor-tbd): *Cannot pass null for friend assembly name*

The examples use <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute> to grant access to internal types and members. The complete sample projects target .NET 10 and build with corrected code by default. To run the commands below, open a terminal in the article's `snippets/friend-assembly-errors` directory.

## CS0281

CS0281 occurs when the public key of the assembly that requests friend access doesn't match the public key in the granting assembly's `InternalsVisibleTo` declaration. Even when the assembly names match, different public keys prevent friend access.

To resolve CS0281, match the friend's assembly name and full public key to the identity in the granting assembly's attribute. If both assemblies are unsigned, omit the public key. If the output assembly has an unexpected name, set [**OutputAssembly**](../compiler-options/output.md#outputassembly) to match the friend declaration. For more information, see [Friend assemblies](../../../standard/assembly/friend.md).

### Example

The granting assembly, `FriendLibrary`, declares a public key for `FriendConsumer`:

:::code language="csharp" source="./snippets/friend-assembly-errors/granting-assembly/FriendLibrary.cs" id="MismatchedFriendKey":::

The granting assembly also defines an internal member:

:::code language="csharp" source="./snippets/friend-assembly-errors/granting-assembly/FriendLibrary.cs" id="FriendMember":::

The unsigned `FriendConsumer` assembly accesses that member:

:::code language="csharp" source="./snippets/friend-assembly-errors/public-key-mismatch/Program.cs" id="FriendAccess":::

To reproduce CS0281, build with the `DEMONSTRATE_CS0281` symbol. The compiler reports that the output assembly's public key is empty and doesn't match the declared key:

```powershell
dotnet build .\public-key-mismatch\FriendConsumer.csproj -p:DefineConstants=DEMONSTRATE_CS0281
```

Because both sample assemblies are unsigned, remove the public key from the friend declaration:

:::code language="csharp" source="./snippets/friend-assembly-errors/granting-assembly/FriendLibrary.cs" id="MatchingFriendIdentity":::

Without the diagnostic symbol, the sample uses the corrected attribute and prints `Friend access granted.`:

```powershell
dotnet run --project .\public-key-mismatch\FriendConsumer.csproj
```

## CS1700

CS1700 warns that an assembly reference in an attribute, such as `InternalsVisibleTo`, isn't valid. To resolve the warning, correct the assembly name and any identity components in the attribute.

### Example

The following declaration uses an invalid value for `Retargetable`:

:::code language="csharp" source="./snippets/friend-assembly-errors/invalid-friend-name/AssemblyInfo.cs" id="InvalidFriendName":::

To reproduce CS1700, build with the `DEMONSTRATE_CS1700` symbol. The build succeeds with the warning:

```powershell
dotnet build .\invalid-friend-name\InvalidFriendName.csproj -p:DefineConstants=DEMONSTRATE_CS1700
```

For an unsigned friend assembly, use its simple assembly name:

:::code language="csharp" source="./snippets/friend-assembly-errors/invalid-friend-name/AssemblyInfo.cs" id="ValidFriendName":::

Without the diagnostic symbol, the project builds without the warning.

## CS1725

CS1725 occurs when an `InternalsVisibleTo` declaration includes a version, culture, public key token, or processor architecture. Friend declarations don't permit these identity components.

To resolve CS1725, remove the unsupported components. Use the friend's simple assembly name and, when required, its full public key rather than its public key token.

### Example

The following declaration includes a version:

:::code language="csharp" source="./snippets/friend-assembly-errors/invalid-friend-identity/AssemblyInfo.cs" id="InvalidFriendIdentity":::

To reproduce CS1725, build with the `DEMONSTRATE_CS1725` symbol:

```powershell
dotnet build .\invalid-friend-identity\InvalidFriendIdentity.csproj -p:DefineConstants=DEMONSTRATE_CS1725
```

To correct the declaration for an unsigned friend, remove the version:

:::code language="csharp" source="./snippets/friend-assembly-errors/invalid-friend-identity/AssemblyInfo.cs" id="ValidFriendIdentity":::

Without the diagnostic symbol, the project builds successfully.

## CS1726

CS1726 occurs when a strong-name signed assembly grants friend access without the friend's full public key. A strong-name signed assembly can grant friend access only to another strong-name signed assembly.

To resolve CS1726, sign the friend assembly and include its full public key in the granting assembly's `InternalsVisibleTo` declaration. Signing the friend alone doesn't correct a declaration that omits its public key. If you don't need friend access, remove the declaration instead. For more information, see [Create signed friend assemblies](../../../standard/assembly/create-signed-friend.md).

### Example

The following declaration omits the friend's public key:

:::code language="csharp" source="./snippets/friend-assembly-errors/missing-friend-public-key/AssemblyInfo.cs" id="MissingFriendPublicKey":::

To reproduce CS1726, build with the `DEMONSTRATE_CS1726` symbol:

```powershell
dotnet build .\missing-friend-public-key\MissingFriendPublicKey.csproj -p:DefineConstants=DEMONSTRATE_CS1726
```

To correct the declaration, supply the friend's full public key:

:::code language="csharp" source="./snippets/friend-assembly-errors/missing-friend-public-key/AssemblyInfo.cs" id="FullFriendPublicKey":::

Without the diagnostic symbol, the project builds successfully. The sample uses [public signing](../compiler-options/security.md#publicsign) and the included public-only `public-key.snk` file to demonstrate the compiler's identity checks without a private key. Public signing doesn't create a cryptographic signature. Normal signing requires a private key. Strong names don't provide a security boundary.
