---
title: "Resolve errors and warnings related to assembly signing configuration"
description: "This article helps you diagnose and correct compiler errors and warnings related to assembly signing configuration"
f1_keywords:
  - "CS7027"
  - "CS7028"
  - "CS7032"
  - "CS7033"
  - "CS7088"
  - "CS7090"
  - "CS7091"
  - "CS7102"
  - "CS8002"
  - "CS8003"
  - "CS8102"
  - "CS8105"
  - "CS8106"
helpviewer_keywords:
  - "CS7027"
  - "CS7028"
  - "CS7032"
  - "CS7033"
  - "CS7088"
  - "CS7090"
  - "CS7091"
  - "CS7102"
  - "CS8002"
  - "CS8003"
  - "CS8102"
  - "CS8105"
  - "CS8106"
ms.date: 10/29/2026
ai-usage: ai-assisted
---

# Resolve errors and warnings for assembly signing

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->

- [**CS7027**](#validate-key-sources-and-public-key-data): *Error signing output with public key from file 'key-file' -- error message*
- [**CS7028**](#validate-key-sources-and-public-key-data): *Error signing output with public key from container 'key-container' -- error message*
- [**CS7032**](#meet-the-requirements-of-the-selected-signing-mode): *Key file 'key-file' is missing the private key needed for signing*
- [**CS7033**](#meet-the-requirements-of-the-selected-signing-mode): *Delay signing was specified and requires a public key, but no public key was specified*
- [**CS7088**](#validate-key-sources-and-public-key-data): *Invalid 'option' value: 'value'.*
- [**CS7090**](#use-compatible-signing-options-and-attributes): *Attribute 'attribute' from module 'module' will be ignored in favor of the instance appearing in source*
- [**CS7091**](#use-compatible-signing-options-and-attributes): *Attribute 'attribute' given in a source file conflicts with option 'option'.*
- [**CS7102**](#use-compatible-signing-options-and-attributes): *Compilation options 'option' and 'other option' can't both be specified at the same time.*
- [**CS8002**](#meet-the-requirements-of-the-selected-signing-mode): *Referenced assembly 'assembly' does not have a strong name.*
- [**CS8003**](#validate-key-sources-and-public-key-data): *Invalid signature public key specified in AssemblySignatureKeyAttribute.*
- [**CS8102**](#meet-the-requirements-of-the-selected-signing-mode): *Public signing was specified and requires a public key, but no public key was specified.*
- [**CS8105**](#use-compatible-signing-options-and-attributes): *Attribute 'attribute' is ignored when public signing is specified.*
- [**CS8106**](#validate-key-sources-and-public-key-data): *Option 'option' must be an absolute path.*

These diagnostics concern assembly identity and signing configuration. Strong names don't provide a security boundary. For background and project configuration, see [Strong-named assemblies](../../../standard/assembly/strong-named.md) and [Sign an assembly with a strong name](../../../standard/assembly/sign-strong-name.md).

## Validate key sources and public-key data

- **CS7027**: *Error signing output with public key from file 'key-file' -- error message*
- **CS7028**: *Error signing output with public key from container 'key-container' -- error message*
- **CS7088**: *Invalid 'option' value: 'value'.*
- **CS8003**: *Invalid signature public key specified in AssemblySignatureKeyAttribute.*
- **CS8106**: *Option 'option' must be an absolute path.*

To identify the underlying failure, read the nested error after `--` (**CS7027**, **CS7028**). For a key file, check that the path resolves on the build host, the build account can read the file, and the file contains valid strong-name key material. For a key container, check that the container exists and is accessible to the build account.

Key-container support depends on Windows strong-name services and isn't portable to non-Windows build hosts. For cross-platform builds, use a key file with the [**KeyFile**](../compiler-options/security.md#keyfile) compiler option instead of [**KeyContainer**](../compiler-options/security.md#keycontainer). In an SDK-style project, set `AssemblyOriginatorKeyFile` to the key-file path.

When you configure signing through the Roslyn compiler API, supply a valid strong-name public-key blob for `CryptoPublicKey` (**CS7088**). A public key token or private-key blob isn't a substitute. This article covers the signing-related case of CS7088, not invalid values for unrelated compilation options.

Provide a valid full public-key string as the first argument of <xref:System.Reflection.AssemblySignatureKeyAttribute> (**CS8003**). Use the hexadecimal representation of the signature public key, not a file path or a public key token.

When you use public signing through the compiler API, resolve `CryptoKeyFile` to an absolute path before you create the compilation (**CS8106**). The command-line compiler resolves relative key-file paths before it constructs these options. This requirement doesn't mean that every project-relative `AssemblyOriginatorKeyFile` value must be rewritten as an absolute path.

## Meet the requirements of the selected signing mode

- **CS7032**: *Key file 'key-file' is missing the private key needed for signing*
- **CS7033**: *Delay signing was specified and requires a public key, but no public key was specified*
- **CS8002**: *Referenced assembly 'assembly' does not have a strong name.*
- **CS8102**: *Public signing was specified and requires a public key, but no public key was specified.*

Choose the signing mode you intend to use, then supply the key material that mode requires:

- For normal signing, provide a key pair that includes the private key (**CS7032**). A public-only key file can't create the cryptographic signature. If you intend to defer the signature or use public signing, configure that mode explicitly instead.
- For [delay signing](../compiler-options/security.md#delaysign), provide a public key through the key-file option (**CS7033**). Delay signing reserves space for a signature that you add later. If you don't intend to delay sign the output, remove the `DelaySign` setting.
- For [public signing](../compiler-options/security.md#publicsign), provide a public key through the key-file option (**CS8102**). Public signing includes the public key and sets the signed flag, but doesn't create a cryptographic signature with a private key.

To resolve an unsigned-reference warning, reference a strong-named build of the dependency or sign the dependency if you control its build (**CS8002**). If strong-name compatibility isn't required, reconsider whether the output assembly needs to be signed. Don't replace a dependency's key arbitrarily: a different key changes its assembly identity.

.NET Framework uses strong-name identity rules for assembly loading. Modern .NET doesn't validate strong-name signatures or use strong names for assembly binding. The compiler warning isn't evidence that a dependency is insecure. For the runtime distinctions, see [Strong-named assemblies](../../../standard/assembly/strong-named.md).

## Use compatible signing options and attributes

- **CS7090**: *Attribute 'attribute' from module 'module' will be ignored in favor of the instance appearing in source*
- **CS7091**: *Attribute 'attribute' given in a source file conflicts with option 'option'.*
- **CS7102**: *Compilation options 'option' and 'other option' can't both be specified at the same time.*
- **CS8105**: *Attribute 'attribute' is ignored when public signing is specified.*

Make the source and module signing attributes agree, or remove a redundant signing attribute from the module (**CS7090**). When a known assembly attribute in a referenced module conflicts with the instance in source, the compiler uses the source instance. This guidance applies to signing attributes such as `AssemblyKeyFile`, `AssemblyKeyName`, and `AssemblyDelaySign`, rather than unrelated assembly metadata.

For a `.netmodule` build, make the source signing attribute agree with the corresponding compiler option, or remove the redundant attribute (**CS7091**). For example, an `AssemblyKeyFile` attribute must not conflict with `CryptoKeyFile`. Configure the intended setting in one place instead of adding another conflicting attribute.

Remove mutually exclusive signing settings (**CS7102**). Don't combine `PublicSign` with `DelaySign=true` or a key container. Through the compiler API, don't combine `CryptoPublicKey` with `CryptoKeyFile` or `CryptoKeyContainer`.

For a public-signed assembly, supply the key through the key-file compiler option and remove ignored `AssemblyKeyFile` or `AssemblyKeyName` attributes (**CS8105**). These attributes don't select the key when public signing is enabled.

For the option rules, see [PublicSign](../compiler-options/security.md#publicsign) and [DelaySign](../compiler-options/security.md#delaysign). For assembly-attribute syntax and targets, see [Global attributes](../attributes/global.md) and [Attribute specification](~/_csharpstandard/standard/attributes.md#233-attribute-specification) in the C# language specification.
