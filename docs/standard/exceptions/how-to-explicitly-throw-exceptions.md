---
title: "How to: Explicitly Throw Exceptions"
ms.date: "03/30/2017"
ms.technology: dotnet-standard
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "exceptions, try/catch blocks"
  - "FileNotFoundException class"
  - "try/catch blocks"
  - "exceptions, throwing"
  - "implicitly throwing exceptions"
ms.assetid: 72bdd157-caa9-4478-9ee3-cb4500b84528
author: "mairaw"
ms.author: "mairaw"
---
# How to explicitly throw exceptions

You can explicitly throw an exception using the [`throw` - C#](../../csharp/language-reference/keywords/throw.md) or the [`Throw` - Visual Basic](../../visual-basic/language-reference/statements/throw-statement.md) statement. You can also throw a caught exception again using the `throw` statement. It is good coding practice to add information to an exception that is re-thrown to provide more information when debugging.

The following code example uses a `try`/`catch` block to catch a possible <xref:System.IO.FileNotFoundException>. Following the `try` block is a `catch` block that catches the <xref:System.IO.FileNotFoundException> and writes a message to the console if the data file is not found. The next statement is the `throw` statement that throws a new <xref:System.IO.FileNotFoundException> and adds text information to the exception.

[!code-csharp[Exception.Throwing#1](~/samples/snippets/csharp/VS_Snippets_CLR/Exception.Throwing/CS/throw.cs#1)]
[!code-vb[Exception.Throwing#1](~/samples/snippets/visualbasic/VS_Snippets_CLR/Exception.Throwing/VB/throw.vb#1)]  

## See also

- [Exceptions](index.md)
