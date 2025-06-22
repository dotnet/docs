---
title: File globbing
author: IEvangelist
description: Learn how to use file globbing in .NET to match various files with the same partial names, extensions, or segments.
ms.author: dapine
ms.date: 03/13/2023
---

# File globbing in .NET

In this article, you'll learn how to use file globbing with the [`Microsoft.Extensions.FileSystemGlobbing`](https://www.nuget.org/packages/Microsoft.Extensions.FileSystemGlobbing) NuGet package. A *glob* is a term used to define patterns for matching file and directory names based on wildcards. Globbing is the act of defining one or more glob patterns, and yielding files from either inclusive or exclusive matches.

## Patterns

To match files in the file system based on user-defined patterns, start by instantiating a <xref:Microsoft.Extensions.FileSystemGlobbing.Matcher> object. A `Matcher` can be instantiated with no parameters, or with a <xref:System.StringComparison?displayProperty=nameWithType> parameter, which is used internally for comparing patterns to file names. The `Matcher` exposes the following additive methods:

- <xref:Microsoft.Extensions.FileSystemGlobbing.Matcher.AddExclude%2A?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.FileSystemGlobbing.Matcher.AddInclude%2A?displayProperty=nameWithType>

Both `AddExclude` and `AddInclude` methods can be called any number of times, to add various file name patterns to either exclude or include from results. Once you've instantiated a `Matcher` and added patterns, it's then used to evaluate matches from a starting directory with the <xref:Microsoft.Extensions.FileSystemGlobbing.Matcher.Execute%2A?displayProperty=nameWithType> method.

## Extension methods

The `Matcher` object has several extension methods.

### Multiple exclusions

To add multiple exclude patterns, you can use:

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

### Multiple inclusions

To add multiple include patterns, you can use:

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

### Get all matching files

To get all matching files, you have to call <xref:Microsoft.Extensions.FileSystemGlobbing.Matcher.Execute(Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase)?displayProperty=nameWithType> either directly or indirectly. To call it directly, you need a search directory:

```csharp
Matcher matcher = new();
matcher.AddIncludePatterns(new[] { "*.txt", "*.asciidoc", "*.md" });

string searchDirectory = "../starting-folder/";

PatternMatchingResult result = matcher.Execute(
    new DirectoryInfoWrapper(
        new DirectoryInfo(searchDirectory)));

// Use result.HasMatches and results.Files.
// The files in the results object are file paths relative to the search directory.
```

The preceding C# code:

- Instantiates a <xref:Microsoft.Extensions.FileSystemGlobbing.Matcher> object.
- Calls <xref:Microsoft.Extensions.FileSystemGlobbing.MatcherExtensions.AddIncludePatterns(Microsoft.Extensions.FileSystemGlobbing.Matcher,System.Collections.Generic.IEnumerable{System.String}[])> to add several file name patterns to include.
- Declares and assigns the search directory value.
- Instantiates a <xref:System.IO.DirectoryInfo> from the given `searchDirectory`.
- Instantiates a <xref:Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoWrapper> from the `DirectoryInfo` it wraps.
- Calls `Execute` given the `DirectoryInfoWrapper` instance to yield a <xref:Microsoft.Extensions.FileSystemGlobbing.PatternMatchingResult> object.

> [!NOTE]
> The `DirectoryInfoWrapper` type is defined in the `Microsoft.Extensions.FileSystemGlobbing.Abstractions` namespace, and the `DirectoryInfo` type is defined in the `System.IO` namespace. To avoid unnecessary `using` directives, you can use the provided extension methods.

There is another extension method that yields an `IEnumerable<string>` representing the matching files:

```csharp
Matcher matcher = new();
matcher.AddIncludePatterns(new[] { "*.txt", "*.asciidoc", "*.md" });

string searchDirectory = "../starting-folder/";

IEnumerable<string> matchingFiles = matcher.GetResultsInFullPath(searchDirectory);

// Use matchingFiles if there are any found.
// The files in this collection are fully qualified file system paths.
```

The preceding C# code:

- Instantiates a <xref:Microsoft.Extensions.FileSystemGlobbing.Matcher> object.
- Calls <xref:Microsoft.Extensions.FileSystemGlobbing.MatcherExtensions.AddIncludePatterns(Microsoft.Extensions.FileSystemGlobbing.Matcher,System.Collections.Generic.IEnumerable{System.String}[])> to add several file name patterns to include.
- Declares and assigns the search directory value.
- Calls `GetResultsInFullPath` given the `searchDirectory` value to yield all matching files as a `IEnumerable<string>`.

### Match overloads

The <xref:Microsoft.Extensions.FileSystemGlobbing.PatternMatchingResult> object represents a collection of <xref:Microsoft.Extensions.FileSystemGlobbing.FilePatternMatch> instances, and exposes a `boolean` value indicating whether the result has matches&mdash;<xref:Microsoft.Extensions.FileSystemGlobbing.PatternMatchingResult.HasMatches?displayProperty=nameWithType>.

With a `Matcher` instance, you can call any of the various `Match` overloads to get a pattern matching result. The `Match` methods invert the responsibility on the caller to provide a file or a collection of files in which to evaluate for matches. In other words, the caller is responsible for passing the file to match on.

> [!IMPORTANT]
> When using any of the `Match` overloads, there is no file system I/O involved. All of the file globbing is done in memory with the include and exclude patterns of the `matcher` instance. The parameters of the `Match` overloads do not have to be fully qualified paths. The current directory (<xref:System.IO.Directory.GetCurrentDirectory?displayProperty=nameWithType>) is used when not specified.

To match a single file:

```csharp
Matcher matcher = new();
matcher.AddInclude("**/*.md");

PatternMatchingResult result = matcher.Match("file.md");
```

The preceding C# code:

- Matches any file with the *.md* file extension, at an arbitrary directory depth.
- If a file named *file.md* exists in a subdirectory from the current directory:
  - `result.HasMatches` would be `true`.
  - and `result.Files` would have one match.

The additional `Match` overloads work in similar ways.

### Ordered evaluation of include/exclude

By default, the matcher evaluates **all** include patterns first, then applies **all** exclude patterns—regardless of the order in which you added them. This means you cannot re-include files that were previously excluded.

Starting with version 10, you can opt into *ordered* evaluation so that includes and excludes are processed exactly in the sequence they were added:

```csharp
using Microsoft.Extensions.FileSystemGlobbing;

// preserve the order of patterns when matching
Matcher matcher = new(preserveFilterOrder: true);

matcher.AddInclude("**/*");                // include everything
matcher.AddExclude("logs/**/*");           // exclude logs
matcher.AddInclude("logs/important/**/*"); // re-include important logs

var result = matcher.Execute(new DirectoryInfoWrapper(new DirectoryInfo(root)));
foreach (var file in result.Files)
{
    Console.WriteLine(file.Path);
}
```

In this mode, patterns are applied one after another:  
- `**/*` adds all files  
- `logs/**/*` filters out anything in `logs/`  
- `logs/important/**/*` adds back only files under `logs/important/`  

Existing code that uses the default constructor will continue to run with the original “all includes, then all excludes” behavior.

## Pattern formats

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
    | `dir/` | All files in any subdirectory under 'dir/'. |
    | `dir/**/*` | All files in any subdirectory under 'dir/'. |

- Relative paths.

    To match all files in a directory named "shared" at the sibling level to the base directory given to <xref:Microsoft.Extensions.FileSystemGlobbing.Matcher.Execute(Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase)?displayProperty=nameWithType>, use `../shared/*`.

## Examples

Consider the following example directory, and each file within its corresponding folder.

```Directory
📁 parent
│    file.md
│    README.md
│
└───📁 child
    │    file.MD
    │    index.js
    │    more.md
    │    sample.mtext
    │
    ├───📁 assets
    │        image.png
    │        image.svg
    │
    └───📁 grandchild
             file.md
             style.css
             sub.text
```

> [!TIP]
> Some file extensions are in uppercase, while others are in lowercase. By default, <xref:System.StringComparer.OrdinalIgnoreCase?displayProperty=nameWithType> is used. To specify different string comparison behavior, use the <xref:Microsoft.Extensions.FileSystemGlobbing.Matcher.%23ctor(System.StringComparison)?displayProperty=nameWithType> constructor.

To get all of the markdown files, where the file extension is either *.md* or *.mtext*, regardless of character case:

:::code source="snippets/fileglobbing/example/Example.MarkdownFiles.cs" id="MarkdownFiles":::

Running the application would output results similar to the following:

```Console
C:\app\parent\file.md
C:\app\parent\README.md
C:\app\parent\child\file.MD
C:\app\parent\child\more.md
C:\app\parent\child\sample.mtext
C:\app\parent\child\grandchild\file.md
```

To get any files in an *assets* directory at an arbitrary depth:

:::code source="snippets/fileglobbing/example/Example.AssetsDirectory.cs" id="AssetsDirectory":::

Running the application would output results similar to the following:

```Console
C:\app\parent\child\assets\image.png
C:\app\parent\child\assets\image.svg
```

To get any files where the directory name contains the word *child* at an arbitrary depth, and the file extensions are not *.md*, *.text*, or *.mtext*:

:::code source="snippets/fileglobbing/example/Example.ChildDirectoriesWeb.cs" id="ChildDirectoriesWeb":::

Running the application would output results similar to the following:

```Console
C:\app\parent\child\index.js
C:\app\parent\child\assets\image.png
C:\app\parent\child\assets\image.svg
C:\app\parent\child\grandchild\style.css
```

## See also

- [Runtime libraries overview](../../standard/runtime-libraries-overview.md)
- [File and Stream I/O](../../standard/io/index.md)
