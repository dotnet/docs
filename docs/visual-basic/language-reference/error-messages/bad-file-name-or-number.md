---
description: "Learn more about: Bad file name or number"
title: "Bad file name or number"
ms.date: 07/20/2015
f1_keywords: 
  - "vbrID52"
ms.assetid: d0e96aea-7621-48f6-a78b-5d37d18aaa4e
---
# Bad file name or number

An error occurred while trying to access the specified file. Among the possible causes for this error are:  
  
- A statement refers to a file with a file name or number that was not specified in the `FileOpen` statement or that was specified in a `FileOpen` statement but was subsequently closed.  
  
- A statement refers to a file with a number that is out of the range of file numbers.  
  
- A statement refers to a file name or number that is not valid.  
  
## To correct this error  
  
1. Make sure the file name is specified in a `FileOpen` statement. Note that if you invoked the `FileClose` statement without arguments, you may have inadvertently closed all open files.  
  
2. If your code is generating file numbers algorithmically, make sure the numbers are valid.  
  
3. Check the file names to make sure they conform to operating system conventions.  
  
## See also

- <xref:Microsoft.VisualBasic.FileSystem.FileOpen%2A>
- [Visual Basic Naming Conventions](../../programming-guide/program-structure/naming-conventions.md)
