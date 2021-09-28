---
description: "Learn more about: How to: Parse File Paths in Visual Basic"
title: "How to: Parse File Paths"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "file names [Visual Basic], parsing [Visual Basic]"
  - "parsing, file paths [Visual Basic]"
ms.assetid: c1bd99c9-8160-456a-b5ab-60a49139b923
---
# How to: Parse File Paths in Visual Basic

The <xref:Microsoft.VisualBasic.FileIO.FileSystem> object offers a number of useful methods when parsing file paths.  
  
- The <xref:Microsoft.VisualBasic.FileIO.FileSystem.CombinePath%2A> method takes two paths and returns a properly formatted combined path.  
  
- The <xref:Microsoft.VisualBasic.FileIO.FileSystem.GetParentPath%2A> method returns the absolute path of the parent of the provided path.  
  
- The <xref:Microsoft.VisualBasic.FileIO.FileSystem.GetFileInfo%2A> method returns a <xref:System.IO.FileInfo> object that can be queried to determine the file's properties, such as its name and path.  
  
 Do not make decisions about the contents of the file based on the file name extension. For example, the file Form1.vb may not be a Visual Basic source file.  
  
### To determine a file's name and path  
  
- Use the <xref:System.IO.FileInfo.DirectoryName%2A> and <xref:System.IO.FileInfo.Name%2A> properties of the <xref:System.IO.FileInfo> object to determine a file's name and path. This example determines the name and path and displays them.  
  
     [!code-vb[VbVbcnMyFileSystem#54](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnMyFileSystem/VB/Class1.vb#54)]  
  
### To combine a file's name and directory to create the full path  
  
- Use the `CombinePath` method, supplying the directory and name. This example takes the strings `folderPath` and `fileName` created in the previous example, combines them, and displays the result.  
  
     [!code-vb[VbVbcnMyFileSystem#55](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnMyFileSystem/VB/Class1.vb#55)]  
  
## See also

- <xref:Microsoft.VisualBasic.FileIO.FileSystem>
- <xref:Microsoft.VisualBasic.FileIO.FileSystem.CombinePath%2A>
- <xref:System.IO.FileInfo>
- <xref:Microsoft.VisualBasic.FileIO.FileSystem.GetFileInfo%2A>
- [How to: Get the Collection of Files in a Directory](how-to-get-the-collection-of-files-in-a-directory.md)
