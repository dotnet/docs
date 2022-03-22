---
title: SYSLIB0040 warning - EncryptionPolicy.NoEncryption and EncryptionPolicy.AllowNoEncryption are obsolete
description: Learn about the obsoletion of the NoEncryption and AllowNoEncryption enumeration fields that generates compile-time warning SYSLIB0040.
ms.date: 03/21/2022
---
# SYSLIB0040: EncryptionPolicy.NoEncryption and EncryptionPolicy.AllowNoEncryption are obsolete

<xref:System.Net.Security.EncryptionPolicy.NoEncryption?displayProperty=nameWithType> and <xref:System.Net.Security.EncryptionPolicy.AllowNoEncryption?displayProperty=nameWithType> are marked as obsolete, starting in .NET 7. Using these enumeration fields in code generates warning `SYSLIB0040` at compile time.

Older SSL/TLS versions permitted no encryption, and while it may be useful for debugging, it shouldn't be used in production. In addition, NULL encryption is no longer available as of TLS 1.3.

## Workaround

N/A

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]
