---
title: "How to: Read From Text Files with Multiple Formats in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "TextFieldParser object, reading from a file"
  - "TextFieldType enumeration"
  - "My.Computer.FileSystem.WriteAllText method, parsing structured text files"
  - "WriteAllText method [Visual Basic], parsing structured text files"
  - "PeekChars method [Visual Basic], determining format of text"
  - "reading text files [Visual Basic], multiple formats"
  - "I/O [Visual Basic], reading text files"
  - "text files [Visual Basic], reading"
ms.assetid: 8d185eb2-79ca-42cd-95a7-d3ff44a5a0f8
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Read From Text Files with Multiple Formats in Visual Basic
The <xref:Microsoft.VisualBasic.FileIO.TextFieldParser> object provides a way to easily and efficiently parse structured text files, such as logs. You can process a file with multiple formats by using the `PeekChars` method to determine the format of each line as you parse through the file.  
  
### To parse a text file with multiple formats  
  
1.  Add a text file named testfile.txt to your project. Add the following content to the text file.  
  
    ```  
    Err  1001 Cannot access resource.  
    Err  2014 Resource not found.  
    Acc  10/03/2009User1      Administrator.  
    Err  0323 Warning: Invalid access attempt.  
    Acc  10/03/2009User2      Standard user.  
    Acc  10/04/2009User2      Standard user.  
    ```  
  
2.  Define the expected format and the format used when an error is reported. The last entry in each array is -1, therefore the last field is assumed to be of variable width. This occurs when the last entry in the array is less than or equal to 0.  
  
     [!code-vb[VbFileIORead#4](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/how-to-read-from-text-files-with-multiple-formats_1.vb)]  
  
3.  Create a new <xref:Microsoft.VisualBasic.FileIO.TextFieldParser> object, defining the width and format.  
  
     [!code-vb[VbFileIORead#5](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/how-to-read-from-text-files-with-multiple-formats_2.vb)]  
  
4.  Loop through the rows, testing for format before reading.  
  
     [!code-vb[VbFileIORead#6](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/how-to-read-from-text-files-with-multiple-formats_3.vb)]  
  
5.  Write errors to the console.  
  
     [!code-vb[VbFileIORead#7](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/how-to-read-from-text-files-with-multiple-formats_4.vb)]  
  
## Example  
 Following is the complete example that reads from the file `testfile.txt`.  
  
 [!code-vb[VbFileIORead#8](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/how-to-read-from-text-files-with-multiple-formats_5.vb)]  
  
## Robust Programming  
 The following conditions may cause an exception:  
  
-   A row cannot be parsed using the specified format (<xref:Microsoft.VisualBasic.FileIO.MalformedLineException>). The exception message specifies the line causing the exception, while the <xref:Microsoft.VisualBasic.FileIO.TextFieldParser.ErrorLine%2A> property is assigned to the text contained in the line.  
  
-   The specified file does not exist (<xref:System.IO.FileNotFoundException>).  
  
-   A partial-trust situation in which the user does not have sufficient permissions to access the file. (<xref:System.Security.SecurityException>).  
  
-   The path is too long (<xref:System.IO.PathTooLongException>).  
  
-   The user does not have sufficient permissions to access the file (<xref:System.UnauthorizedAccessException>).  
  
## See Also  
 <xref:Microsoft.VisualBasic.FileIO.TextFieldParser?displayProperty=nameWithType>  
 <xref:Microsoft.VisualBasic.FileIO.TextFieldParser.PeekChars%2A>  
 <xref:Microsoft.VisualBasic.FileIO.MalformedLineException>  
 <xref:Microsoft.VisualBasic.FileIO.FileSystem.WriteAllText%2A>  
 <xref:Microsoft.VisualBasic.FileIO.TextFieldParser.EndOfData%2A>  
 <xref:Microsoft.VisualBasic.FileIO.TextFieldParser.TextFieldType%2A>  
 [How to: Read From Comma-Delimited Text Files](../../../../visual-basic/developing-apps/programming/drives-directories-files/how-to-read-from-comma-delimited-text-files.md)  
 [How to: Read From Fixed-width Text Files](../../../../visual-basic/developing-apps/programming/drives-directories-files/how-to-read-from-fixed-width-text-files.md)  
 [Parsing Text Files with the TextFieldParser Object](../../../../visual-basic/developing-apps/programming/drives-directories-files/parsing-text-files-with-the-textfieldparser-object.md)
