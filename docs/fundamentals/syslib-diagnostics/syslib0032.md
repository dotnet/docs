---
title: SYSLIB0032 warning - Recovery from corrupted process state exceptions is not supported
description: Learn about the obsoletion of HandleProcessCorruptedStateExceptionsAttribute that generates compile-time warning SYSLIB0032.
ms.date: 09/07/2021
---
# SYSLIB0032: Recovery from corrupted process state exceptions is not supported

Recovery from corrupted process state exceptions is not supported, and the <xref:System.Runtime.ExceptionServices.HandleProcessCorruptedStateExceptionsAttribute> type is marked as obsolete, starting in .NET 6. Using this API in code generates warning `SYSLIB0032` at compile time.

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]
