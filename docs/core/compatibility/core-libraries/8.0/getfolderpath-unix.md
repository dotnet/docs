---
title: ".NET 8 breaking change: GetFolderPath behavior on Unix"
description: Learn about the .NET 8 breaking change in core .NET libraries where the behavior of Environment.GetFolderPath has changed on Unix.
ms.date: 11/18/2022
---
# GetFolderPath behavior on Unix

Starting in .NET 8, the behavior of <xref:System.Environment.GetFolderPath%2A?displayProperty=nameWithType> on Unix operating systems has changed.

## Change description

The following tables show how the returned path value changes for each Unix operating system for various special folders.

### Linux

| SpecialFolder value | Path (.NET 7 and earlier) | Path (.NET 8 and later)                                            |
|---------------------|---------------------------|--------------------------------------------------------------------|
| `MyDocuments`       | `$HOME`                   | Uses `XDG_DOCUMENTS_DIR` if available; otherwise `$HOME/Documents` |
| `Personal`          | `$HOME`                   | Uses `XDG_DOCUMENTS_DIR` if available; otherwise `$HOME/Documents` |

### macOS

| SpecialFolder value | Path (.NET 7 and earlier) | Path (.NET 8 and later) |
|-|-|-|
| `MyDocuments` | `$HOME` | [NSDocumentDirectory](https://developer.apple.com/documentation/foundation/nssearchpathdirectory/nsdocumentdirectory)] (`$HOME/Documents`) |
| `Personal` | `$HOME` | [NSDocumentDirectory](https://developer.apple.com/documentation/foundation/nssearchpathdirectory/nsdocumentdirectory)] (`$HOME/Documents`) |
| `ApplicationData` | `$HOME/.config` | [NSApplicationSupportDirectory](https://developer.apple.com/documentation/foundation/nssearchpathdirectory/nsapplicationsupportdirectory) (Library/Application Support) |
| `LocalApplicationData` | `$HOME/.local/share` | [NSApplicationSupportDirectory](https://developer.apple.com/documentation/foundation/nssearchpathdirectory/nsapplicationsupportdirectory) (Library/Application Support) |
| `MyVideos` | `$HOME/Videos` | [NSMoviesDirectory](https://developer.apple.com/documentation/foundation/nssearchpathdirectory/nsmoviesdirectory) (`$HOME/Movies`) |

### Android

| SpecialFolder value | Path (.NET 7 and earlier) | Path (.NET 8 and later) |
|---------------------|---------------------------|-------------------------|
| `MyDocuments`       | `$HOME`                   | `$HOME/Documents`       |
| `Personal`          | `$HOME`                   | `$HOME/Documents`       |

## Version introduced

.NET 8 Preview 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The previous behavior was incorrect and not consistent with Linux, macOS, and Android users' expectations.

## Recommended action

The most common break is calling `Environment.GetFolderPath(Environment.SpecialFolder.Personal)` on Unix to get the `$HOME` directory. <xref:System.Environment.SpecialFolder.Personal?displayProperty=fullName> and <xref:System.Environment.SpecialFolder.MyDocuments?displayProperty=fullName> are aliases for the same underlying enumeration value. If you're using <xref:System.Environment.SpecialFolder.Personal?displayProperty=nameWithType> in this way, change your code to `Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)` instead.

For other breaks, the recommended action is to do one of the following:

- Migrate your application's files to the appropriate directory.
- Add a fallback check for the previous location to your code.

## Affected APIs

- <xref:System.Environment.GetFolderPath(System.Environment.SpecialFolder)?displayProperty=fullName>
- <xref:System.Environment.GetFolderPath(System.Environment.SpecialFolder,System.Environment.SpecialFolderOption)?displayProperty=fullName>
