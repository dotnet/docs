---
title: ".NET 7 breaking change: Legacy FileStream strategy removed"
description: Learn about the .NET 7 breaking change in core .NET libraries where the the ability to use the legacy `FileStream` implementation has been removed.
ms.date: 10/04/2022
---
# Legacy FileStream strategy removed

The `AppContext` switch `System.IO.UseNet5CompatFileStream` and the ability to use the legacy <xref:System.IO.FileStream> implementation were removed.

## Previous behavior

The legacy `FileStream` implementation was available and you could opt into it by using the `UseNet5CompatFileStream` switch or the `DOTNET_SYSTEM_IO_USENET5COMPATFILESTREAM` environment variable.

## New behavior

Starting in .NET 7, you can no longer opt in to use the legacy `FileStream` implementation.

## Version introduced

.NET 7 Preview 1

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

The `UseNet5CompatFileStream` switch and `DOTNET_SYSTEM_IO_USENET5COMPATFILESTREAM` environment variable were included in .NET 6 in case the new implementation caused breaking changes. Any breaking changes have now been fixed. Since there are no more bugs introduced by the `FileStream` changes, the compatibility mode was removed and with it all the legacy code, which makes the codebase easier to maintain.

## Recommended action

If you're currently using the switch (or the `DOTNET_SYSTEM_IO_USENET5COMPATFILESTREAM` environment variable) to opt into legacy code and are upgrading to .NET 7, the switch will no longer have any effect and you should remove it.

## Affected APIs

- <xref:System.IO.FileStream?displayProperty=fullName>
- <xref:System.IO.File.Create(System.String)?displayProperty=fullName>
- <xref:System.IO.File.Create(System.String,System.Int32)?displayProperty=fullName>
- <xref:System.IO.File.Create(System.String,System.Int32,System.IO.FileOptions)?displayProperty=fullName>
- <xref:System.IO.File.Create(System.String,System.Int32,System.IO.FileOptions,System.Security.AccessControl.FileSecurity)?displayProperty=fullName>
- <xref:System.IO.File.Open(System.String,System.IO.FileMode)?displayProperty=fullName>
- <xref:System.IO.File.Open(System.String,System.IO.FileStreamOptions)?displayProperty=fullName>
- <xref:System.IO.File.Open(System.String,System.IO.FileMode,System.IO.FileAccess)?displayProperty=fullName>
- <xref:System.IO.File.Open(System.String,System.IO.FileMode,System.IO.FileAccess,System.IO.FileShare)?displayProperty=fullName>
- <xref:System.IO.File.OpenRead(System.String)?displayProperty=fullName>
- <xref:System.IO.File.OpenWrite(System.String)?displayProperty=fullName>
- <xref:System.IO.FileSystemAclExtensions.Create(System.IO.FileInfo,System.IO.FileMode,System.Security.AccessControl.FileSystemRights,System.IO.FileShare,System.Int32,System.IO.FileOptions,System.Security.AccessControl.FileSecurity)?displayProperty=fullName>
- <xref:System.IO.FileInfo.Create?displayProperty=fullName>
- <xref:System.IO.FileInfo.Open%2A?displayProperty=fullName>
- <xref:System.IO.FileInfo.OpenRead?displayProperty=fullName>
- <xref:System.IO.FileInfo.OpenWrite?displayProperty=fullName>

## See also

- [FileStream no longer synchronizes file offset with OS (.NET 6)](../6.0/filestream-doesnt-sync-offset-with-os.md)
- [FileStream.Position updates after ReadAsync or WriteAsync completes (.NET 6)](../6.0/filestream-position-updates-after-readasync-writeasync-completion.md)
