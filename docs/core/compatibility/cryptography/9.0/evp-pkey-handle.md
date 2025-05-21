---
title: "Breaking change: SafeEvpPKeyHandle.DuplicateHandle up-refs the handle"
description: Learn about the .NET 9 breaking change in cryptography where SafeEvpPKeyHandle.DuplicateHandle now increments the reference count of the EVP_PKEY handle instead of creating a new instance.
ms.date: 08/05/2024
ms.topic: concept-article
---
# SafeEvpPKeyHandle.DuplicateHandle up-refs the handle

Along with work to enable OpenSSL providers support, a change was made to the <xref:System.Security.Cryptography.SafeEvpPKeyHandle.DuplicateHandle?displayProperty=nameWithType> method that impacts the <xref:System.Security.Cryptography.ECDsaOpenSsl> and <xref:System.Security.Cryptography.RSAOpenSsl> constructors that take a <xref:System.Security.Cryptography.SafeEvpPKeyHandle>. External modifications of the passed handle now also affect the handle stored in instances of those classes.

## Previous behavior

<xref:System.Security.Cryptography.SafeEvpPKeyHandle.DuplicateHandle> created a new `EVP_PKEY` instance. Modifications to the duplicated key (that is, through direct calls to OpenSSL APIs) did not impact the original key. `SafeEvpPKeyHandle.DuplicateHandle` was called by the constructors of <xref:System.Security.Cryptography.ECDsaOpenSsl> and <xref:System.Security.Cryptography.RSAOpenSsl> that take a <xref:System.Security.Cryptography.SafeEvpPKeyHandle>.

## New behavior

<xref:System.Security.Cryptography.SafeEvpPKeyHandle.DuplicateHandle> increments the reference count of the existing `EVP_PKEY` and returns a handle to the same key. That means external calls to OpenSSL APIs that modify `EVP_PKEY` now also affect instances of the duplicated <xref:System.Security.Cryptography.SafeEvpPKeyHandle>. Those APIs include <xref:System.Security.Cryptography.ECDsaOpenSsl> and <xref:System.Security.Cryptography.RSAOpenSsl> instances created from such handles.

## Version introduced

.NET 9 Preview 7

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change was made to enable OpenSSL providers support. As a side effect, there are also some performance improvements.

## Recommended action

Avoid modifications of `EVP_PKEY` passed in to .NET APIs. If you can't avoid modifications to `EVP_PKEY`, create a copy of `EVP_PKEY` yourself (that is, copy parameters into the new `EVP_PKEY` instance).

## Affected APIs

- <xref:System.Security.Cryptography.SafeEvpPKeyHandle.DuplicateHandle?displayProperty=fullName>
- <xref:System.Security.Cryptography.ECDsaOpenSsl.%23ctor(System.Security.Cryptography.SafeEvpPKeyHandle)>
- <xref:System.Security.Cryptography.RSAOpenSsl.%23ctor(System.Security.Cryptography.SafeEvpPKeyHandle)>

Every API that accepts an <Xref:System.Security.Cryptography.RSA> or <Xref:System.Security.Cryptography.ECDsa> instance that originates from <xref:System.Security.Cryptography.SafeEvpPKeyHandle> is also affected.
