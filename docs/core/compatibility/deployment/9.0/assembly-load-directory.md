---
title: "Breaking change - Assembly load directory resolves through symbolic links on Windows"
description: "Learn about the breaking change in .NET 9 where the assembly load directory resolves through symbolic links."
ms.date: 4/3/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/45584
---

# Assembly load directory resolves through symbolic links on Windows

Starting in .NET 9, the .NET host resolves symbolic links before determining the assembly load directory when running on Windows.

## Version introduced

.NET 9

## Previous behavior

The .NET host did not resolve symbolic links before calculating load paths. Assembly loads were resolved relative to the symbolic link itself, not the destination of the link.

For example, if an application was laid out as follows:

```
/myapp/
  myapp.exe
  myapp.dll
```

And a symbolic link was created in another directory:

```
otherdir/
  myapp.exe -> /myapp/myapp.exe
```

Executing `otherdir/myapp.exe` would resolve loads relative to `otherdir/`, not `/myapp/`.

## New behavior

The .NET host now resolves the destination of a symbolic link before determining the assembly load directory. Assembly loads are resolved relative to the resolved location of the host file.

Using the same example:

```
/myapp/
  myapp.exe
  myapp.dll
```

With a symbolic link:

```
otherdir/
  myapp.exe -> /myapp/myapp.exe
```

Executing `otherdir/myapp.exe` resolves loads relative to `/myapp/`. Files in `otherdir/` are not considered.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The previous behavior on Windows was undocumented, inconsistent with non-Windows implementations, and prevented supported use of symbolic links to the .NET host. This change ensures consistent behavior and enables scenarios where symbolic links to the .NET host are used properly.

## Recommended action

If your application relied on the previous behavior, ensure that all relevant binaries are located in the directory behind the symbolic link, rather than next to it. Avoid constructing a file layout that depends on the symbolic link's location.

## Affected APIs

None.
