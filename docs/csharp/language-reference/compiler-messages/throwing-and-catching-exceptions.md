---
title: "Resolve errors and warnings when throwing and catching exceptions"
description: "Learn about C# compiler errors and warnings related to throwing and catching exceptions."
f1_keywords:
  - "CS8359"
  - "CS8360"
helpviewer_keywords:
  - "CS8359"
  - "CS8360"
ms.date: 09/23/2026
ai-usage: ai-assisted
---
# Resolve errors and warnings when throwing and catching exceptions

This article covers compiler diagnostics related to throwing and catching exceptions. The following warnings are generated when an exception filter is a constant `false`:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error or warning for SEO purposes.
 -->

- [**CS8359**](#remove-a-constant-false-exception-filter): *Filter expression is a constant 'false', consider removing the catch clause*
- [**CS8360**](#remove-a-constant-false-exception-filter): *Filter expression is a constant 'false', consider removing the try-catch block*

## Remove a constant false exception filter

- **CS8359**: *Filter expression is a constant 'false', consider removing the catch clause*
- **CS8360**: *Filter expression is a constant 'false', consider removing the try-catch block*

A `catch` clause with a filter that is always `false` never handles an exception. The compiler reports **CS8360** when the `try` statement has exactly one `catch` clause and no `finally` clause. In that case, the entire `try`-`catch` statement is ineffective. The compiler reports **CS8359** when the `try` statement has another `catch` clause or a `finally` clause.

The following example produces **CS8359** on the filter because another `catch` clause can handle an exception. The compiler also reports unreachable code in the constant-false handler:

```csharp
using System;
using System.IO;

try
{
    Console.WriteLine(File.ReadAllText("data.txt"));
}
catch (InvalidOperationException ex) when (false) // CS8359
{
    Console.Error.WriteLine(ex.Message);
}
catch (IOException ex)
{
    Console.Error.WriteLine(ex.Message);
}
```

Remove the constant-false `catch` clause. If the clause should handle some exceptions, replace the constant expression with a meaningful runtime condition.

The following example produces **CS8360** on the filter because the constant-false filter is on the only `catch` clause and the statement has no `finally` clause. The compiler also reports unreachable code in the handler:

```csharp
using System;
using System.IO;

try
{
    Console.WriteLine(File.ReadAllText("data.txt"));
}
catch (InvalidOperationException ex) when (false) // CS8360
{
    Console.Error.WriteLine(ex.Message);
}
```

Remove the `try`-`catch` statement while preserving the statements from the `try` block. If the handler is required conditionally, replace the constant filter with a meaningful runtime condition.

For more information, see [Advantages of exception filters](../statements/exception-handling-statements.md#advantages-of-exception-filters).
