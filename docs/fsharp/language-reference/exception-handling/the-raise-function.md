---
title: "Exceptions: raise and reraise functions"
description: Learn how the F# 'raise' and 'reraise' functions are used to indicate that an error or exceptional condition has occurred.
ms.date: 07/23/2021
---
# Exceptions: raise and reraise functions

- The `raise` function is used to indicate that an error or exceptional condition has occurred. Information about the error is captured in an exception object.
- The `reraise` function is used to propagate a handled exception up the call chain.

## Syntax

```fsharp
raise (expression)
```

## Remarks

The `raise` function generates an exception object and initiates a stack unwinding process. The stack unwinding process is managed by the common language runtime (CLR), so the behavior of this process is the same as it is in any other .NET language. The stack unwinding process is a search for an exception handler that matches the generated exception. The search starts in the current `try...with` expression, if there is one. Each pattern in the `with` block is checked, in order. When a matching exception handler is found, the exception is considered handled; otherwise, the stack is unwound and `with` blocks up the call chain are checked until a matching handler is found. Any `finally` blocks that are encountered in the call chain are also executed in sequence as the stack unwinds.

The `raise` function is the equivalent of `throw` in C# or C++.

The following code examples illustrate the use of the `raise` function to generate an exception.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-2/snippet5801.fs)]

The `raise` function can also be used to raise .NET exceptions, as shown in the following example.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-2/snippet5802.fs)]

## Reraising an exception

The `reraise` function can be used in a `with` block to propagate a handled exception up the call chain.
`reraise` does not take an exception operand. It's most useful when a method passes on an
argument from a caller to some other library method, and the library method raises an exception that
must be passed on to the caller.

The `reraise` function may not be used on the `with` block of `try`/`with` constructs in computed lists,
arrays, sequences, or computation expressions including `task { .. }` or `async { .. }`.

```fsharp
open System

let getFirstCharacter(value: string) =
    try
        value.[0]
    with :? IndexOutOfRangeException as e ->
        reraise()

let s = getFirstCharacter("")
Console.WriteLine($"The first character is {s}")

// The example displays the following output:
//   System.IndexOutOfRangeException: Index was outside the bounds of the array.
//      at System.String.get_Chars(Int32 index)
//      at getFirstCharacter(String value)
//      at <StartupCode>.main@()
```

## See also

- [Exception Handling](index.md)
- [Exception Types](exception-types.md)
- [Exceptions: The `try...with` Expression](the-try-with-expression.md)
- [Exceptions: The `try...finally` Expression](the-try-finally-expression.md)
- [Exceptions: The `failwith` Function](the-failwith-function.md)
- [Exceptions: The `invalidArg` Function](the-invalidArg-function.md)
