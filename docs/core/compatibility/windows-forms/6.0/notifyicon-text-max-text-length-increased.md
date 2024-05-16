---
title: "Breaking change: NotifyIcon.Text maximum text length increased"
description: Learn about the breaking change in .NET 6 where some the maximum text length for the NotifyIcon.Text property increased.
ms.date: 01/19/2021
---
# NotifyIcon.Text maximum text length increased

The maximum text length allowed for the <xref:System.Windows.Forms.NotifyIcon.Text?displayProperty=nameWithType> property increased from 63 to 127.

## Change description

In previous .NET versions, the maximum text length allowed for the <xref:System.Windows.Forms.NotifyIcon.Text?displayProperty=nameWithType> property is 63 characters. Starting in .NET 6, the maximum allowed text length is 127 characters. In any version, an <xref:System.ArgumentException> is thrown when you attempt to set a value that's longer than the limit.

## Change category

This change affects [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

The maximum allowed text length was increased to be in line with the [underlying Windows API](/windows/win32/api/shellapi/ns-shellapi-notifyicondataw#nif_showtip-0x00000080). The Windows API was updated in Windows 2000, but due to compatibility reasons, the size limit for this property wasn't updated in .NET Framework.

## Version introduced

.NET 6

## Recommended action

Review your code and relax any existing guard conditions, if necessary.

## Affected APIs

<xref:System.Windows.Forms.NotifyIcon.Text?displayProperty=fullName>

<!--

### Affected APIs

- `P:System.Windows.Forms.NotifyIcon.Text`

### Category

Windows Forms

-->
