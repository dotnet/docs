---
title: "Breaking change: InMemoryDirectoryInfo prepends rootDir to files"
description: Learn about the .NET 9 breaking change in core .NET libraries where InMemoryDirectoryInfo prepends the root directory to its file paths.
ms.date: 02/12/2024
---
# InMemoryDirectoryInfo prepends rootDir to files

<xref:Microsoft.Extensions.FileSystemGlobbing.InMemoryDirectoryInfo> now prepends the specified root directory to its collection of files.

`InMemoryDirectoryInfo` is used by <xref:Microsoft.Extensions.FileSystemGlobbing.MatcherExtensions.Match%2A?displayProperty=nameWithType>, which enables the <xref:Microsoft.Extensions.FileSystemGlobbing.Matcher> to execute glob-matching patterns without accessing the disk.

## Previous behavior

Previously, relative paths in the `files` argument of the [constructor](xref:Microsoft.Extensions.FileSystemGlobbing.InMemoryDirectoryInfo.%23ctor(System.String,System.Collections.Generic.IEnumerable{System.String})) were prepended with the current working directory (CWD). This caused an unnecessary dependency on the CWD for a type that's supposed to work in-memory.

## New behavior

Starting in .NET 9, relative paths in the `files` argument of the constructor are prepended with the specified root directory.

## Version introduced

.NET 9 Preview 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

There were blocked scenarios with in-memory paths using a drive letter other than the one used by the current working directory. For example, see [dotnet/runtime issue 93107](https://github.com/dotnet/runtime/issues/93107).

## Recommended action

If you depended on the previous behavior, adjust your code to account for the files now being prepended with the root directory. For example:

```diff
// Since rootDir is also relative, it could've been used to filter the matching scope of `files`.
-string rootDir = "dir1";
// Now that's not possible; everything in `files` is under `root`.
+string rootDir = "root";
string[] files = ["dir1/test.0", "dir1/subdir/test.1", "dir2/test.2"];

-PatternMatchingResult result = new Matcher().AddInclude("**/*").Match(rootDir, files);
// Adjust the pattern if you want to scope down to dir1.
+PatternMatchingResult result = new Matcher().AddInclude("dir1/**/*").Match(rootDir, files);
Console.WriteLine(string.Join(", ", result.Files.Select(x => x.Path)));

// Output:
// dir1/test.0
// dir1/subdir/test.1
```

## Affected APIs

- <xref:Microsoft.Extensions.FileSystemGlobbing.InMemoryDirectoryInfo?displayProperty=fullName>
- <xref:Microsoft.Extensions.FileSystemGlobbing.MatcherExtensions.Match(Microsoft.Extensions.FileSystemGlobbing.Matcher,System.String,System.String)?displayProperty=fullName>
- <xref:Microsoft.Extensions.FileSystemGlobbing.MatcherExtensions.Match(Microsoft.Extensions.FileSystemGlobbing.Matcher,System.String,System.Collections.Generic.IEnumerable{System.String})?displayProperty=fullName>
