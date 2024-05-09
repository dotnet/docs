---
title: "How to: Read text from a file"
description: In this article, see examples of how to read text synchronously or asynchronously from a text file, using the StreamReader class in .NET for desktop apps.
ms.date: 05/09/2024
ms.custom: devdivchpfy22
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "streams, reading text from files"
  - "reading text files"
  - "reading data, text files"
  - "data streams, reading text from files"
  - "I/O [.NET], reading text from files"
ms.assetid: ed180baa-dfc6-4c69-a725-46e87edafb27
---
# How to: Read text from a file

The following examples show how to read text synchronously and asynchronously from a text file using .NET for desktop apps. In both examples, when you create the instance of the <xref:System.IO.StreamReader> class, you provide the relative or absolute path to the file.

> [!NOTE]
> These code examples don't apply to Universal Windows (UWP) apps because the Windows runtime provides different stream types for reading and writing to files. For more information, see [UWP work with files](/windows/uwp/get-started/fileio-learning-track). For examples that show how to convert between .NET Framework streams and Windows Runtime streams, see [How to: Convert between .NET Framework streams and Windows Runtime streams](how-to-convert-between-dotnet-streams-and-winrt-streams.md).

## Example: Synchronous read

The following example shows a synchronous read operation within a console app. This example opens the text file using a stream reader, copies the contents to a string, and outputs the string to the console.

> [!IMPORTANT]
> The example assumes that a file named *TestFile.txt* already exists in the same folder as the app.

:::code language="csharp" source="snippets/how-to-read-text-from-a-file/csharp/Program.cs" id="sync":::
:::code language="vb" source="snippets/how-to-read-text-from-a-file/vb/Program.vb" id="sync":::

## Example: Asynchronous read

The following example shows an asynchronous read operation within a console app. This example opens the text file using a stream reader, copies the contents to a string, and outputs the string to the console.

> [!IMPORTANT]
> The example assumes that a file named *TestFile.txt* already exists in the same folder as the app.

:::code language="csharp" source="snippets/how-to-read-text-from-a-file/csharp/Program.cs" id="async":::
:::code language="vb" source="snippets/how-to-read-text-from-a-file/vb/Program.vb" id="async":::

## See also

- [Common I/O Tasks](common-i-o-tasks.md)
- [Asynchronous file I/O](asynchronous-file-i-o.md)
- [How to: Write text to a file](how-to-write-text-to-a-file.md)
- <xref:System.IO.StreamReader>
- <xref:System.IO.File.OpenText%2A?displayProperty=nameWithType>
- <xref:System.IO.StreamReader.ReadLine%2A?displayProperty=nameWithType>
