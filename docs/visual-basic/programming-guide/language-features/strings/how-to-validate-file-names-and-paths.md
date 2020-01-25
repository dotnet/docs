---
title: "How to: Validate File Names and Paths"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "file names [Visual Basic], validating"
  - "strings [Visual Basic], validating"
  - "Boolean values [Visual Basic]"
  - "paths [Visual Basic], validating"
ms.assetid: f673462d-57b7-4120-b13a-6a7592f7ab2c
---
# How to: Validate File Names and Paths in Visual Basic
This example returns a `Boolean` value that indicates whether a string represents a file name or path. The validation checks if the name contains characters that are not allowed by the file system.  
  
## Example  
 [!code-vb[VbVbcnRegEx#4](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnRegEx/VB/Class1.vb#4)]  
  
 This example does not check if the name has incorrectly placed colons, or directories with no name, or if the length of the name exceeds the system-defined maximum length. It also does not check if the application has permission to access the file-system resource with the specified name.  
  
## See also

- <xref:System.IO.Path.GetInvalidPathChars%2A>
- [Validating Strings in Visual Basic](../../../../visual-basic/programming-guide/language-features/strings/validating-strings.md)
