---
title: SYSLIB0014 warning
description: Learn about the obsoletions that generate compile-time warning SYSLIB0014.
ms.topic: reference
ms.date: 04/24/2021
---
# SYSLIB0014:

The following APIs are marked as obsolete, starting in .NET 6. Using them in code generates warning `SYSLIB0014` at compile time.

- <xref:System.Net.WebRequest>
- <xref:System.Net.HttpWebRequest>
- <xref:System.Net.ServicePoint>
- <xref:System.Net.WebClient>

## Workarounds

Use <xref:System.Net.Http.HttpClient> instead.

[!INCLUDE [suppress-syslib-warning](../../../../includes/suppress-syslib-warning.md)]
