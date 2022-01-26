---
title: "How to write to a text file - C# Programming Guide"
description: Learn how to write a text file with C#. See several code examples and view additional available resources.
ms.date: 02/11/2021
ms.topic: how-to
f1_keywords:
  - "TextWriter.WriteLine"
  - "StreamWriter.Close"
helpviewer_keywords:
  - "files [C#], text files"
  - "text, writing to files [C#]"
ms.assetid: 2e99f184-d88b-4719-a7f1-d9ec482aa809
ms.custom: contperf-fy21q3
---

# How to write to a text file (C# Programming Guide)

In this article, there are several examples showing various ways to write text to a file. The first two examples use static convenience methods on the <xref:System.IO.File?displayProperty=nameWithType> class to write each element of any `IEnumerable<string>` and a `string` to a text file. The third example shows how to add text to a file when you have to process each line individually as you write to the file. In the first three examples, you overwrite all existing content in the file. The final example shows how to append text to an existing file.

 These examples all write string literals to files. If you want to format text written to a file, use the <xref:System.String.Format%2A> method or C# [string interpolation](../../language-reference/tokens/interpolated.md) feature.

## Write a collection of strings to a file

:::code language="csharp" source="snippets/write-text/WriteAllLines.cs":::

The preceding source code example:

- Instantiates a string array with three values.
- Awaits a call to <xref:System.IO.File.WriteAllLinesAsync%2A?displayProperty=nameWithType> which:

  - Asynchronously creates a file name *WriteLines.txt*. If the file already exists, it is overwritten.
  - Writes the given lines to the file.
  - Closes the file, automatically flushing and disposing as needed.

## Write one string to a file

:::code language="csharp" source="snippets/write-text/WriteAllText.cs":::

The preceding source code example:

- Instantiates a string given the assigned string literal.
- Awaits a call to <xref:System.IO.File.WriteAllTextAsync%2A?displayProperty=nameWithType> which:

  - Asynchronously creates a file name *WriteText.txt*. If the file already exists, it is overwritten.
  - Writes the given text to the file.
  - Closes the file, automatically flushing and disposing as needed.

## Write selected strings from an array to a file

:::code language="csharp" source="snippets/write-text/StreamWriterOne.cs":::

The preceding source code example:

- Instantiates a string array with three values.
- Instantiates a <xref:System.IO.StreamWriter> with a file path of *WriteLines2.txt* as a [using declaration](../../whats-new/csharp-8.md#using-declarations).
- Iterates through all the lines.
- Conditionally awaits a call to <xref:System.IO.StreamWriter.WriteLineAsync(System.String)?displayProperty=nameWithType>, which writes the line to the file when the line doesn't contain `"Second"`.

## Append text to an existing file

:::code language="csharp" source="snippets/write-text/StreamWriterTwo.cs":::

The preceding source code example:

- Instantiates a string array with three values.
- Instantiates a <xref:System.IO.StreamWriter> with a file path of *WriteLines2.txt* as a [using declaration](../../whats-new/csharp-8.md#using-declarations), passing in `true` to append.
- Awaits a call to <xref:System.IO.StreamWriter.WriteLineAsync(System.String)?displayProperty=nameWithType>, which writes the string to the file as an appended line.

## Exceptions

The following conditions may cause an exception:

- <xref:System.InvalidOperationException>: The file exists and is read-only.
- <xref:System.IO.PathTooLongException>: The path name may be too long.
- <xref:System.IO.IOException>: The disk may be full.

There are additional conditions that may cause exceptions when working with the file system, it is best to program defensively.

## See also

- [C# Programming Guide](../index.md)
- [File System and the Registry (C# Programming Guide)](./index.md)
