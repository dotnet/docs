---
title: "How to: Rename a File"
description: "Learn about how to rename a file with the Visual Basic Runtime Library or the .NET base class library."
ms.date: 01/14/2025
helpviewer_keywords: 
- "I/O [Visual Basic], renaming files"
- "files [Visual Basic], renaming"
ms.assetid: 0ea7e0c8-2cb2-4bf5-a00d-7b6e3c08a3bc
ms.topic: how-to
---
# How to: Rename a File in Visual Basic

In Visual Basic, there are two ways to rename a file. You can use the Visual Basic run-time object `My.Computer.FileSystem` or the .NET provided `System.IO.File` object to rename a file.

## Rename with .NET

The `System.IO.File` object doesn't contain a method to rename a file, instead, use the `Move` method to "move" the file to the same location but with a different file name. This method can also be used to move the file to a different location with a different name, performing a move and rename together.

The following example renames the file located in the `My Documents` folder from `TextFile.txt` to `NewName.txt`.

:::code language="vb" source="./snippets/how-to-rename-a-file/Form1.vb" id="BCLRename":::

## Rename with the Visual Basic run-time

Use the `RenameFile` method of the `My.Computer.FileSystem` object to rename a file by supplying the full path to the file and the new file name. This method can't be used to move a file to a different directory. To learn how to move a file, see [How to: Move a File in Visual Basic](how-to-move-a-file.md).

The following example renames the file located in the `My Documents` folder from `TextFile.txt` to `NewName.txt`.

:::code language="vb" source="./snippets/how-to-rename-a-file/Form1.vb" id="MyRename":::

Visual Studio provides an IntelliSense code snippet that uses `My.Computer.FileSystem.RenameFile`. The snippet is located in **File system - Processing Drives, Folders, and Files**. For more information, see [Code Snippets](/visualstudio/ide/code-snippets).

## Robust Programming

The following conditions might cause an exception:

- The path isn't valid for one of the following reasons: it's a zero-length string, it contains only white space, it contains invalid characters, or it's a device path (starts with \\\\.\\) (<xref:System.ArgumentException>).
- `newName` contains path information (<xref:System.ArgumentException>).
- The path isn't valid because it's `Nothing` (<xref:System.ArgumentNullException>).
- `newName` is `Nothing` or an empty string (<xref:System.ArgumentNullException>).
- The source file isn't valid or doesn't exist (<xref:System.IO.FileNotFoundException>).
- There's an existing file or directory with the name specified in `newName` (<xref:System.IO.IOException>).
- The path exceeds the system-defined maximum length (<xref:System.IO.PathTooLongException>).
- A file or directory name in the path contains a colon (:) or is in an invalid format (<xref:System.NotSupportedException>).
- The user lacks necessary permissions to view the path (<xref:System.Security.SecurityException>).
- The user doesn't have the required permission (<xref:System.UnauthorizedAccessException>).

## See also

- <xref:Microsoft.VisualBasic.FileIO.FileSystem.RenameFile%2A>
- <xref:System.IO.File.Move%2A>
- [How to: Move a File](how-to-move-a-file.md)
- [Creating, Deleting, and Moving Files and Directories](creating-deleting-and-moving-files-and-directories.md)
- [How to: Create a Copy of a File in the Same Directory](how-to-create-a-copy-of-a-file-in-the-same-directory.md)
- [How to: Create a Copy of a File in a Different Directory](how-to-create-a-copy-of-a-file-in-a-different-directory.md)
