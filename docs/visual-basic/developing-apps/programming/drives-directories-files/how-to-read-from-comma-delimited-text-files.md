---
description: "Learn more about: How to: read from comma-delimited text files in Visual Basic"
title: "How to: read from comma-delimited text files"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "files [Visual Basic], parsing"
  - "text files [Visual Basic], tasks"
  - "reading text files [Visual Basic], comma-delimited"
  - "text files [Visual Basic], reading"
ms.assetid: a8413fe4-0dba-49c8-8692-44fb67a9ec4f
---
# How to: read from comma-delimited text files in Visual Basic

The `TextFieldParser` object provides a way to easily and efficiently parse structured text files, such as logs. The `TextFieldType` property defines whether it is a delimited file or one with fixed-width fields of text.  
  
### To parse a comma delimited text file  
  
1. Create a new `TextFieldParser`. The following code creates the `TextFieldParser` named `MyReader` and opens the file `test.txt`.  
  
     [!code-vb[VbFileIORead#15](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbFileIORead/VB/Class1.vb#15)]  
  
2. Define the `TextField` type and delimiter. The following code defines the `TextFieldType` property as `Delimited` and the delimiter as ",".  
  
     [!code-vb[VbFileIORead#16](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbFileIORead/VB/Class1.vb#16)]  
  
3. Loop through the fields in the file. If any lines are corrupt, report an error and continue parsing. The following code loops through the file, displaying each field in turn and reporting any fields that are formatted incorrectly.  
  
     [!code-vb[VbFileIORead#17](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbFileIORead/VB/Class1.vb#17)]  
  
4. Close the `While` and `Using` blocks with `End While` and `End Using`.  
  
     [!code-vb[VbFileIORead#18](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbFileIORead/VB/Class1.vb#18)]  
  
## Example  

 This example reads from the file `test.txt`.  
  
 [!code-vb[VbFileIORead#19](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbFileIORead/VB/Class1.vb#19)]  
  
## Robust programming  

 The following conditions may cause an exception:  
  
- A row cannot be parsed using the specified format (<xref:Microsoft.VisualBasic.FileIO.MalformedLineException>). The exception message specifies the line causing the exception, while the <xref:Microsoft.VisualBasic.FileIO.TextFieldParser.ErrorLine%2A> property is assigned the text contained in the line.  
  
- The specified file does not exist (<xref:System.IO.FileNotFoundException>).  
  
- A partial-trust situation in which the user does not have sufficient permissions to access the file. (<xref:System.Security.SecurityException>).  
  
- The path is too long (<xref:System.IO.PathTooLongException>).  
  
- The user does not have sufficient permissions to access the file (<xref:System.UnauthorizedAccessException>).  
  
## See also

- <xref:Microsoft.VisualBasic.FileIO.TextFieldParser?displayProperty=nameWithType>
- [How to: Read From Fixed-width Text Files](how-to-read-from-fixed-width-text-files.md)
- [How to: Read From Text Files with Multiple Formats](how-to-read-from-text-files-with-multiple-formats.md)
- [Parsing Text Files with the TextFieldParser Object](parsing-text-files-with-the-textfieldparser-object.md)
- [Walkthrough: Manipulating Files and Directories in Visual Basic](walkthrough-manipulating-files-and-directories.md)
- [Troubleshooting: Reading from and Writing to Text Files](troubleshooting-reading-from-and-writing-to-text-files.md)
