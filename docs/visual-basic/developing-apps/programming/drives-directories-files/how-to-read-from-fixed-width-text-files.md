---
title: "How to: read from fixed-width text Files in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "fixed-width text file"
  - "reading text files [Visual Basic], fixed-width"
  - "files [Visual Basic], parsing"
  - "text files [Visual Basic], tasks"
  - "text files [Visual Basic], reading"
ms.assetid: 99be5692-967a-4e85-993e-cd18139a5a69
caps.latest.revision: 24
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: read from fixed-width text files in Visual Basic
The `TextFieldParser` object provides a way to easily and efficiently parse structured text files, such as logs.  
  
 The `TextFieldType` property defines whether the parsed file is a delimited file or one that has fixed-width fields of text. In a fixed-width text file, the field at the end can have a variable width. To specify that the field at the end has a variable width, define it to have a width less than or equal to zero.  
  
### To parse a fixed-width text file  
  
1.  Create a new `TextFieldParser`. The following code creates the `TextFieldParser` named `Reader` and opens the file `test.log`.  
  
     [!code-vb[VbFileIORead#9](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/how-to-read-from-fixed-width-text-files_1.vb)]  
  
2.  Define the `TextFieldType` property as `FixedWidth`, defining the width and format. The following code defines the columns of text; the first is 5 characters wide, the second 10, the third 11, and the fourth is of variable width.  
  
     [!code-vb[VbFileIORead#10](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/how-to-read-from-fixed-width-text-files_2.vb)]  
  
3.  Loop through the fields in the file. If any lines are corrupted, report an error and continue parsing.  
  
     [!code-vb[VbFileIORead#11](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/how-to-read-from-fixed-width-text-files_3.vb)]  
  
4.  Close the `While` and `Using` blocks with `End While` and `End Using`.  
  
     [!code-vb[VbFileIORead#12](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/how-to-read-from-fixed-width-text-files_4.vb)]  
  
## Example  
 This example reads from the file `test.log`.  
  
 [!code-vb[VbFileIORead#13](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/how-to-read-from-fixed-width-text-files_5.vb)]  
  
## Robust programming  
 The following conditions may cause an exception:  
  
-   A row cannot be parsed using the specified format (<xref:Microsoft.VisualBasic.FileIO.MalformedLineException>). The exception message specifies the line causing the exception, while the <xref:Microsoft.VisualBasic.FileIO.TextFieldParser.ErrorLine%2A> property is assigned to the text contained in the line.  
  
-   The specified file does not exist (<xref:System.IO.FileNotFoundException>).  
  
-   A partial-trust situation in which the user does not have sufficient permissions to access the file. (<xref:System.Security.SecurityException>).  
  
-   The path is too long (<xref:System.IO.PathTooLongException>).  
  
-   The user does not have sufficient permissions to access the file (<xref:System.UnauthorizedAccessException>).  
  
## See also  
 <xref:Microsoft.VisualBasic.FileIO.TextFieldParser?displayProperty=nameWithType>  
 [How to: Read From Comma-Delimited Text Files](../../../../visual-basic/developing-apps/programming/drives-directories-files/how-to-read-from-comma-delimited-text-files.md)  
 [How to: Read From Text Files with Multiple Formats](../../../../visual-basic/developing-apps/programming/drives-directories-files/how-to-read-from-text-files-with-multiple-formats.md)  
 [Parsing Text Files with the TextFieldParser Object](../../../../visual-basic/developing-apps/programming/drives-directories-files/parsing-text-files-with-the-textfieldparser-object.md)  
 [Walkthrough: Manipulating Files and Directories in Visual Basic](../../../../visual-basic/developing-apps/programming/drives-directories-files/walkthrough-manipulating-files-and-directories.md)  
 [Troubleshooting: Reading from and Writing to Text Files](../../../../visual-basic/developing-apps/programming/drives-directories-files/troubleshooting-reading-from-and-writing-to-text-files.md)  
 
