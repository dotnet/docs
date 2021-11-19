---
title: "Breaking change: System.Security.SecurityContext is marked obsolete"
description: Learn about the .NET 6 breaking change where the System.Security.SecurityContext type is marked obsolete.
ms.date: 08/16/2021
---
# System.Security.SecurityContext is marked obsolete

<xref:System.Security.SecurityContext> is marked obsolete *with a custom diagnostic ID*. Using any `SecurityContext` APIs generates warning `SYSLIB0003` at compile time.

> [!NOTE]
> Suppressing the default obsoletion diagnostic ID, which is [CS0618](../../../../csharp/language-reference/compiler-messages/cs0618.md) for the C# compiler, does not suppress the warnings that the compiler generates when these APIs are used.

## Old behavior

Prior to .NET 6, the <xref:System.Security.SecurityContext> type was not marked obsolete, however, all of its public members throw a <xref:System.PlatformNotSupportedException> at run time.

## New behavior

Starting in .NET 6, the <xref:System.Security.SecurityContext> is marked obsolete.

## Version introduced

.NET 6 RC 1

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

All of the public members of <xref:System.Security.SecurityContext> throw a <xref:System.PlatformNotSupportedException> at run time. The <xref:System.Security.SecurityContext> is part of [Code access security (CAS)](/previous-versions/dotnet/framework/code-access-security/code-access-security), which is an unsupported legacy technology.

## Recommended action

Remove any use of these APIs from your code.

## Affected APIs

- <xref:System.Security.SecurityContext?displayProperty=fullName>

## See also

- [Most code access security APIs are obsolete](../5.0/code-access-security-apis-obsolete.md)
