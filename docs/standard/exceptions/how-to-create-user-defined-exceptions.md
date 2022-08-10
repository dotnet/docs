---
title: "How to: Create User-Defined Exceptions"
description: Learn how to create user-defined exceptions, which are an alternative to the hierarchy of exception classes derived from the Exception base class in .NET.
ms.date: "08/10/2022"
ms.custom: devdivchpfy22
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "user-defined exceptions"
  - "exceptions, examples"
  - "exceptions, user-defined"
ms.assetid: 25819a5a-f915-4fc8-b924-a76915674e04
---
# How to create user-defined exceptions

.NET provides a hierarchy of exception classes ultimately derived from the <xref:System.Exception> base class. However, if none of the predefined exceptions meet your needs, you can create your own exception classes by deriving from the <xref:System.Exception> class.

When creating your own exceptions, end the class name of the user-defined exception with the word "Exception", and implement the three common constructors, as shown in the following example. The example defines a new exception class named `EmployeeListNotFoundException`. The class is derived from the <xref:System.Exception> base class and includes three constructors.

[!code-cpp[dg_exceptionDesign#14](../../../samples/snippets/cpp/VS_Snippets_CLR/dg_exceptionDesign/cpp/example2.cpp#14)]
[!code-csharp[dg_exceptionDesign#14](../../../samples/snippets/csharp/VS_Snippets_CLR/dg_exceptionDesign/cs/example2.cs#14)]
[!code-vb[dg_exceptionDesign#14](../../../samples/snippets/visualbasic/VS_Snippets_CLR/dg_exceptionDesign/vb/example2.vb#14)]  

> [!NOTE]
> In situations where you're using remoting, you must ensure that the metadata for any user-defined exceptions is available at the server (callee) and to the client (the proxy object or caller). For more information, see [Best practices for exceptions](best-practices-for-exceptions.md).

## See also

- [Exceptions](index.md)
