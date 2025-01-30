---
title: "Breaking change: Rfc2898DeriveBytes constructors are obsolete"
description: Learn about the .NET 10 breaking change in core .NET libraries where Rfc2898DeriveBytes constructors are obsolete.
ms.date: 01/30/2025
---
# Rfc2898DeriveBytes constructors are obsolete

Starting in .NET 10, all of the constructors on `Rfc2898DeriveBytes` are obsolete.

## Previous behavior

The `Rfc2898DeriveBytes` had constructors that were not obsolete, or obsolete under a different diagnostic ID.

## New behavior

The `Rfc2898DeriveBytes` constructors are obsolete with SYSLIB0060 diagnostic ID and message:

> The constructors on Rfc2898DeriveBytes are obsolete. Use the static Pbkdf2 method instead.

## Version introduced

.NET 10 Preview 1

## Type of breaking change

This change can affect[source compatibility](../../categories.md#source-compatibility).

## Reason for change

The instance-based implementation of PBKDF2, which `Rfc2898DeriveBytes` provides, offers a non-standard usage by "streaming" bytes back by allowing successive calls to `GetBytes`. This is not the intended use of PBKDF2, the algorithm should be used as a one-shot. The one-shot functionality exists as the static method [`Rfc2898DeriveBytes.Pbkdf2`](https://learn.microsoft.com/dotnet/api/system.security.cryptography.rfc2898derivebytes.pbkdf2) and should be used instead of instantiating `Rfc2898DeriveBytes`.

## Recommended action

Change instances of `Rfc2898DeriveBytes` and calls to `GetBytes` to use the `Pkbdf2` one-shot static method instead.

For example, change:

```csharp
using System.Security.Cryptography;

Rfc2898DeriveBytes kdf = new Rfc2898DeriveBytes(password, salt, iterations, hashAlgorithm);
byte[] derivedKey = kdf.GetBytes(64);
```

to

```csharp
byte[] derivedKey = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithm, 64);
```

## Affected APIs

- <xref:System.Security.Cryptography.Rfc2898DeriveBytes.#ctor> (all overloads)
