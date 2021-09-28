---
description: "Learn more about: Input past end of file"
title: "Input past end of file"
ms.date: 07/20/2015
f1_keywords: 
  - "vbrID62"
ms.assetid: 65292704-6e7d-4622-9f50-eb655a59b016
---
# Input past end of file

Either an `Input` statement is reading from a file that is empty or one in which all the data is used, or you used the `EOF` function with a file opened for binary access.  
  
## To correct this error  
  
1. Use the `EOF` function immediately before the `Input` statement to detect the end of the file.  
  
2. If the file is opened for binary access, use `Seek` and `Loc`.  
  
## See also

- <xref:Microsoft.VisualBasic.FileSystem.Input%2A>
- <xref:Microsoft.VisualBasic.FileSystem.EOF%2A>
- <xref:Microsoft.VisualBasic.FileSystem.Seek%2A>
- <xref:Microsoft.VisualBasic.FileSystem.Loc%2A>
