---
title: File globbing in .NET
author: IEvangelist
description: Learn how to use file globbing in .NET to match various files with the same partial names, extensions, or segments.
ms.author: dapine
ms.date: 08/23/2021
---

# File globbing in .NET

In this article you'll learn how to use file globbing with the [`Microsoft.Extensions.FileSystemGlobbing`](https://www.nuget.org/packages/Microsoft.Extensions.FileSystemGlobbing) NuGet package. A *glob* is a term used to define patterns for matching file and directory names based on wildcards. Globbing is that act of defining one or more glob pattern, and yielding files from either inclusive or exclusive matches.

## Patterns

To match files in the file system based on user-defined patterns, start by instantiating a <xref:Microsoft.Extensions.FileSystemGlobbing.Matcher> object. A `Matcher` can be instantiated with no parameters, or with a <xref:System.StringComparison?displayProperty=nameWithType> &mdash; which would be used for comparing patterns to file names. The `Matcher` exposes several additive methods:

- <xref:Microsoft.Extensions.FileSystemGlobbing.Matcher.AddExclude%2A?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.FileSystemGlobbing.Matcher.AddInclude%2A?displayProperty=nameWithType>

Both `AddExclude` and `AddInclude` methods can be called any number of times, to add various file name patterns to either exclude or include from results.

### Extensions

The `Matcher` object has several convenience-based extension methods available.

#### Multiple exclusions

To add multiple exclude patterns you can use:

```csharp
Matcher matcher = new();
matcher.AddExclude("*.txt");
matcher.AddExclude("*.asciidoc");
matcher.AddExclude("*.md");
```

Alternatively, you can use the <xref:Microsoft.Extensions.FileSystemGlobbing.MatcherExtensions.AddExcludePatterns(Microsoft.Extensions.FileSystemGlobbing.Matcher,System.Collections.Generic.IEnumerable{System.String}[])?displayProperty=nameWithType> to add multiple exclude patterns in a single call:

```csharp
Matcher matcher = new();
matcher.AddExcludePatterns(new [] { "*.txt", "*.asciidoc", "*.md" });
```

This extension method iterates over all of the provided patterns calling <xref:Microsoft.Extensions.FileSystemGlobbing.Matcher.AddExclude%2A> on your behalf.

#### Multiple inclusions

To add multiple include patterns you can use:

```csharp
Matcher matcher = new();
matcher.AddInclude("*.txt");
matcher.AddInclude("*.asciidoc");
matcher.AddInclude("*.md");
```

Alternatively, you can use the <xref:Microsoft.Extensions.FileSystemGlobbing.MatcherExtensions.AddIncludePatterns(Microsoft.Extensions.FileSystemGlobbing.Matcher,System.Collections.Generic.IEnumerable{System.String}[])?displayProperty=nameWithType> to add multiple include patterns in a single call:

```csharp
Matcher matcher = new();
matcher.AddIncludePatterns(new[] { "*.txt", "*.asciidoc", "*.md" });
```

This extension method iterates over all of the provided patterns calling <xref:Microsoft.Extensions.FileSystemGlobbing.Matcher.AddInclude%2A> on your behalf.



### Pattern formats

The patterns that are specified in the `AddExclude` and `AddInclude` methods can use the following formats to match multiple files or directories.

- Exact directory or file name
  
  - `some-file.txt`
  - `path/to/file.txt`

- Wildcards `*` in file and directory names that represent zero to many characters not including separator characters.

    | Value          | Description                                                            |
    |----------------|------------------------------------------------------------------------|
    | `*.txt`        | All files with *.txt* file extension.                                  |
    | `*.*`          | All files with an extension.                                           |
    | `*`            | All files in top-level directory.                                      |
    | `.*`           | File names beginning with '.'.                                         |
    | `*word*`       | All files with 'word' in the filename.                                 |
    | `readme.*`     | All files named 'readme' with any file extension.                      |
    | `styles/*.css` | All files with extension '.css' in the directory 'styles/'.            |
    | `scripts/*/*`  | All files in 'scripts/' or one level of subdirectory under 'scripts/'. |
    | `images*/*`    | All files in a folder with name that is or begins with 'images'.       |

- Arbitrary directory depth (`/**/`).

    | Value | Description |
    | --- | --- |
    | `**/*` | All files in any subdirectory. |
    | `dir/**/*` | All files in any subdirectory under 'dir/'. |

- Relative paths.

    To match all files in a directory named "shared" at the sibling level to the base directory given to <xref:Microsoft.Extensions.FileSystemGlobbing.Matcher.Execute(Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase)?displayProperty=nameWithType>, use `../shared/*`.

## Example

Consider the following example directory, and each file within its corresponding folder.

```Directory
📁 parent
│   file.txt
│
└───📁 child
    │   file.TXT
    │   more.txt
    │
    └───📁 grandchild
            file.txt
            sub.text
```
