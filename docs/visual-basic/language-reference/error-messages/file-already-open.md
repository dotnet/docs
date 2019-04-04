---
title: "File already open"
ms.date: 07/20/2015
f1_keywords: 
  - "vbrID55"
ms.assetid: d674a0fb-ef16-4cc2-9da7-709a8a07dbea
---
# File already open
Sometimes a file must be closed before another `FileOpen` or other operation can occur. Among the possible causes of this error are:  
  
-   A sequential output mode `FileOpen` operation was executed for a file that is already open  
  
-   A statement refers to an open file.  
  
## To correct this error  
  
1.  Close the file before executing the statement.  
  
## See also

- <xref:Microsoft.VisualBasic.FileSystem.FileOpen%2A>
