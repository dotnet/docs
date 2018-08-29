---
title: "Handling I/O errors in .NET"
ms.date: "08/27/2018"
ms.technology: dotnet-standard
ms.topic: "article"
helpviewer_keywords: 
  - "I/O, exception handling"
  - "I/O, errors"
author: "rpetrusha"
ms.author: "ronpet"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Handling I/O errors in .NET

Because the file system is an operating system resource, I/O methods in both .NET Core and .NET Framework wrap calls to the underlying operating system. When an I/O error occurs in code executed by the operating system, the operating system returns an error information to the .NET I/O method. The method then translates the error information, typically in the form of an error code, into a .NET exception type. In most cases, it does this by directly translating the error code into its corresponding exception type; it does not perform any special mapping of the error based on the context of the method call. 

For example, on the Windows operating system, a call to a <xref:System.IO.Directory?displayProperty=nameWithType> method such as <xref:System.IO.Directory.SetLastWriteTime%2A> with a directory path that does not exist can return either of two error codes to the method:

```cpp
ERROR_FILE_NOT_FOUND = 0x2;
ERROR_PATH_NOT_FOUND = 0x3;
```

The method in turn translates `ERROR_FILE_NOT_FOUND` to a <xref:System.IO.FileNotFoundException> and `ERROR_PATH_NOT_FOUND` to <xref:System.IO.DirectoryNotFoundException>. It does not perform any special mapping of `ERROR_FILE_NOT_FOUND` to <xref:System.IO.DirectoryNotFoundException> because the error relates to a bad directory path rather than a bad file path.

Because of this reliance on the operating system, identical exception conditions (such as the directory not found error in our example) can result in an I/O method throwing one of a class of exceptions. In this case, exception handling code should be prepared to handle each exception in the class. This applies particularly to <xref:System.IO.DirectoryNotFoundException> and <xref:System.IO.FileNotFoundException>.

For example, the following `IOLibrary.CountSubdirectories` method returns the number of subdirectories in a particular directory. Note that even though the method works with a directory, it handles both a <xref:System.IO.DirectoryNotFoundException> and a <xref:System.IO.FileNotFoundException>, since the runtime can throw either exception if a directory does not exist.





