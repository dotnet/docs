---
description: "Learn more about: Troubleshooting: reading from and writing to text files (Visual Basic)"
title: "Troubleshooting: reading from and writing to text files"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "troubleshooting file I/O"
  - "writing text to files [Visual Basic], troubleshooting"
  - "troubleshooting Visual Basic, text files"
  - "I/O [Visual Basic], troubleshooting text files"
  - "writing to files [Visual Basic], troubleshooting"
  - "reading text files [Visual Basic], troubleshooting"
ms.assetid: a8e9b44d-facb-4718-8c0f-466537171182
---
# Troubleshooting: reading from and writing to text files (Visual Basic)

This topic discusses common problems encountered when working with text files and suggests an approach to each.  
  
## Common problems  

 The most common issues encountered when working with text files include security exceptions, file encodings, or invalid paths.  
  
### Security exceptions  

 A <xref:System.Security.SecurityException> is thrown when a security error occurs. This is often a result of the user lacking necessary permissions, which may be solved by adding permissions or working with files in isolated storage.  
  
### File encodings  

 File encodings, also known as character encodings, specify how to represent characters when text processing. Unexpected characters in a text file may result from incorrect encoding. For most files, one encoding may be preferable over another in terms of which language characters it can or cannot handle, although Unicode is usually preferred. For more information, see [File Encodings](file-encodings.md) and <xref:System.Text.Encoding>.  
  
### Incorrect paths  

 When parsing file paths, particularly relative paths, it is easy to supply the wrong data. Many problems can be corrected by making sure you are supplying the correct path. For more information, see [How to: Parse File Paths](how-to-parse-file-paths.md).  
  
## See also

- <xref:Microsoft.VisualBasic.FileIO.FileSystem>
- [Reading from Files](reading-from-files.md)
- [Writing to Files](writing-to-files.md)
- [Parsing Text Files with the TextFieldParser Object](parsing-text-files-with-the-textfieldparser-object.md)
