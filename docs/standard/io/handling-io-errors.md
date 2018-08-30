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

.NET file system methods can throw the following exceptions:

- <xref:System.IO.IOException?displayProperty=nameWithType>, the base class of all <xref:System.IO> exception types. It is thrown for errors whose return codes from the operating system don't directly map to any other exception type.
- <xref:System.IO.FileNotFoundException?displayProperty=nameWithType>.
- <xref:System.IO.DirectoryNotFoundException?displayProperty=nameWithType>.
- <xref:System.IO.DriveNotFoundException??displayProperty=nameWithType>.
- <xref:System.IO.PathTooLongException?displayProperty=nameWithType>.
- <xref:System.OperationCancelledException?displayProperty=nameWithType>.
- <xref:System.UnauthorizedAccessException?displayProperty=nameWithType>.
- <xref:System.ArgumentException?displayProperty=nameWithType>, which is thrown for invalid path characters on .NET Framework and on .NET Core 2.0 and previous versions.
- <xref:System.NotSupportedException?displayProperty=nameWithType>, which is thrown for invalid colons in .NET Framework.
- <xref:System.Security.SecurityException?displayProperty=nameWithType>, which is thrown for applications running in limited trust that lack the necessary permissions on .NET Framework only. (Full trust is the default on .NET Framework.)

## Mapping error codes to exceptions

Because the file system is an operating system resource, I/O methods in both .NET Core and .NET Framework wrap calls to the underlying operating system. When an I/O error occurs in code executed by the operating system, the operating system returns error information to the .NET I/O method. The method then translates the error information, typically in the form of an error code, into a .NET exception type. In most cases, it does this by directly translating the error code into its corresponding exception type; it does not perform any special mapping of the error based on the context of the method call.

For example, on the Windows operating system, a method call that returns an error code of `ERROR_FILE_NOT_FOUND` (or 0x2) maps to a <xref:System.IO.FileNotFoundException>, and an error code of `ERROR_PATH_NOT_FOUND` (or 0x03) maps to a <xref:System.IO.DirectoryNotFoundException>.

However, the precise conditions under which the operating system returns particular error codes is often undocumented or poorly documented. As a result, unexpected exceptions can occur. For example, because you are working with a directory rather than a file, you would expect that providing an invalid directory path to the <xref:System.IO.DirectoryInfo.#ctor%6A?displayProperty=nameWithType> constructor throws a <xref:System.IO.DirectoryNotFoundException>. However, it may also throw a <xref:System.IO.FileNotFoundException>.

## Exception handling in I/O operations

Because of this reliance on the operating system, identical exception conditions (such as the directory not found error in our example) can result in an I/O method throwing any one of the entire class of I/O exceptions. This means that, when calling I/O APIs, your code should be prepared to most or all of these exceptions, as shown in the following table:

| Exception type | .NET Core | .NET Framework |
|---|---|---|
| <xref:System.IO.IOException> | Yes | Yes |
| <xref:System.IO.FileNotFoundException> | Yes | Yes |
| <xref:System.IO.DirectoryNotFoundException> | Yes | Yes |
| <xref:System.IO.DriveNotFoundException?> | Yes | Yes |
| <xref:System.IO.PathTooLongException> | Yes | Yes |
| <xref:System.OperationCancelledException> | Yes | Yes |
| <xref:System.UnauthorizedAccessException> | Yes | Yes |
| <xref:System.ArgumentException> | .NET Core 2.0 and earlier| Yes |
| <xref:System.NotSupportedException> | No | Yes |
| <xref:System.Security.SecurityException> | No | Limited trust only |

## Handling IOException

As the base class for exceptions in the <xref:System.IO> namespace, <xref:System.IO.IOException> is also thrown for any error code that does not map to a predefined exception type. This means that it can be thrown by any I/O operation.

> [!IMPORTANT]
> Because <xref:System.IO.IOException> is the base class of the other exception types in the <xref:System.IO> namespace, you should handle in a `catch` block after you've handled the other I/O-related exceptions.

In addition, starting with .NET Core 2.1, validation checks for path correctness (for example, to ensure that invalid characters are not present in a path) have been removed, and the runtime throws an exception mapped from an operating system error code rather than from its own validation code. The most likely exception to be thrown in this case is an <xref:System.IO.IOException>, although any other exception type could also be thrown.

## See also

- [Handling and throwing exceptions in .NET](../exceptions/index.md)
- [Exception handling (Task Parallel Library)](../parallel-programming/exception-handling-task-parallel-library.md)
- [Best practices for exceptions](../exceptions/best-practices-for-exceptions.md)
- [How to use specific exceptions in a catch block](../exceptions/how-to-use-specific-exceptions-in-a-catch-block.md)