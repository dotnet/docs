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

- [**CS0281**](#match-friend-public-keys-and-signing-states): *Friend access was granted by 'assembly', but the public key of the output assembly ('public key') does not match that specified by the InternalsVisibleTo attribute in the granting assembly.*
- [**CS1700**](#specify-valid-friend-assembly-names): *Assembly reference 'assembly' is invalid and cannot be resolved*
- [**CS1725**](#specify-valid-friend-assembly-names): *Friend assembly reference 'assembly' is invalid. InternalsVisibleTo declarations cannot have a version, culture, public key token, or processor architecture specified.*
- [**CS1726**](#match-friend-public-keys-and-signing-states): *Friend assembly reference 'assembly' is invalid. Strong-name signed assemblies must specify a public key in their InternalsVisibleTo declarations.*
- [**CS7029**](#match-friend-public-keys-and-signing-states): *Friend access was granted by 'assembly', but the strong name signing state of the output assembly does not match that of the granting assembly.*
- [**CS7030**](#specify-valid-friend-assembly-names): *Cannot pass null for friend assembly name*

The *granting assembly* declares <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute>. The *friend assembly* consumes its internal types and members. To resolve these diagnostics, correct the identity in the declaration and the signing configuration of the assemblies, rather than changing the members to public. For background, see [Friend assemblies](../../../standard/assembly/friend.md), the [`internal` modifier](../keywords/internal.md), and [Accessibility domains](~/_csharpstandard/standard/basic-concepts.md#743-accessibility-domains) in the C# language specification.

## Specify valid friend assembly names

- **CS1700**: *Assembly reference 'assembly' is invalid and cannot be resolved*
- **CS1725**: *Friend assembly reference 'assembly' is invalid. InternalsVisibleTo declarations cannot have a version, culture, public key token, or processor architecture specified.*
- **CS7030**: *Cannot pass null for friend assembly name*

Supply a non-null assembly name to `InternalsVisibleTo` (**CS7030**). Use the friend's simple assembly name, not a path or a filename with a `.dll` or `.exe` extension. Match the name produced by the friend's project or [**OutputAssembly**](../compiler-options/output.md#outputassembly) compiler option.

Correct malformed assembly identities and invalid identity-component values (**CS1700**). For example, `Retargetable=f` isn't a valid component value. For an unsigned friend, use a simple assembly name:

:::code language="csharp" source="./snippets/friend-assembly-errors/invalid-friend-name/AssemblyInfo.cs" id="ValidFriendName":::

Remove `Version`, `Culture`, and `ProcessorArchitecture` components from the friend declaration (**CS1725**). For a strong-named friend, include its full `PublicKey`, not a `PublicKeyToken`. For compatibility, Roslyn accepts some legacy public-key-token forms but ignores the token value; a token doesn't establish the friend's public key.

For assembly-level attribute syntax, see [Global attributes](../attributes/global.md) and [Attribute specification](~/_csharpstandard/standard/attributes.md#233-attribute-specification) in the C# language specification.

## Match friend public keys and signing states

- **CS0281**: *Friend access was granted by 'assembly', but the public key of the output assembly ('public key') does not match that specified by the InternalsVisibleTo attribute in the granting assembly.*
- **CS1726**: *Friend assembly reference 'assembly' is invalid. Strong-name signed assemblies must specify a public key in their InternalsVisibleTo declarations.*
- **CS7029**: *Friend access was granted by 'assembly', but the strong name signing state of the output assembly does not match that of the granting assembly.*

Match the full public key in the granting assembly's declaration to the public key of the friend assembly that you actually build (**CS0281**). Matching simple names alone doesn't resolve a key mismatch. If both assemblies are unsigned, remove a public key that was mistakenly included in the declaration:

:::code language="csharp" source="./snippets/friend-assembly-errors/granting-assembly/FriendLibrary.cs" id="MatchingFriendIdentity":::

When the granting assembly is strong named, sign the friend assembly and include the friend's full public key in the declaration (**CS1726**). Signing the friend alone doesn't repair a declaration that omits its key. If friend access isn't needed, remove the declaration instead.

The signed sample's corrected declaration includes a full public key:

:::code language="csharp" source="./snippets/friend-assembly-errors/missing-friend-public-key/AssemblyInfo.cs" id="FullFriendPublicKey":::

Use the public key from your own friend assembly rather than the sample key. The sample project uses [public signing](../compiler-options/security.md#publicsign) and a public-only key file to exercise the compiler's identity checks without a private key. Public signing doesn't create a cryptographic signature.

If the compiler reports incompatible signing states, rebuild the granting and consuming assemblies with compatible signing settings (**CS7029**). For an unsigned granting assembly and a strong-named consumer, either configure the granting assembly for strong naming and update its friend declaration, or stop signing the consumer if both assemblies should be unsigned. Configure the keys through build options so the compiler knows the intended identities before it resolves friend access.

For complete examples, see [Create signed friend assemblies](../../../standard/assembly/create-signed-friend.md) and [Create unsigned friend assemblies](../../../standard/assembly/create-unsigned-friend.md). For key-file and signing-mode failures, see [Assembly signing errors](assembly-signing-errors.md). Strong names identify assemblies; they don't provide a security boundary.
