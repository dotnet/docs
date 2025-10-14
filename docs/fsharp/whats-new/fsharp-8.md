---
title: What's new in F# 8 - F# Guide
description: Find information on the new features available in F# 8.
ms.date: 11/17/2023
ms.topic: whats-new
ai-usage: ai-assisted
---
# What's new in F# 8

F# 8 focuses on making the language simpler, more consistent, and more performant. This article highlights the major changes in F# 8, developed in the [F# open source code repository](https://github.com/dotnet/fsharp).

F# 8 is available in .NET 8. You can download the latest .NET SDK from the [.NET downloads page](https://dotnet.microsoft.com/download).

## Simplified syntax

F# 8 introduces several syntax improvements that make code more concise and readable.

### Shortened lambda expressions

F# 8 introduces a shorthand syntax for lambda expressions using the underscore (`_`) character. Instead of writing `fun x -> x.Property`, you can now write `_.Property`:

Before F# 8:

```fsharp
let names = people |> List.map (fun person -> person.Name)
let ages = people |> List.map (fun person -> person.Age)
```

Starting with F# 8:

```fsharp
let names = people |> List.map _.Name
let ages = people |> List.map _.Age
```

This shorthand works for property access, method calls, and field access, making functional pipelines more concise and readable. The underscore represents the lambda parameter, and you can chain multiple accesses:

```fsharp
// Property access
customers |> List.map _.Address.City

// Method calls
numbers |> List.map _.ToString()

// Combining property access and method calls
items |> List.filter _.IsValid()
      |> List.map _.Name.ToLower()
```

### Nested record field updates

Building on the F# 7 feature, F# 8 continues to improve copy-and-update expressions for nested records. You can update deeply nested record fields using dot notation:

```fsharp
type Address = { Street: string; City: string; PostalCode: string }
type Person = { Name: string; Address: Address }
type Company = { Name: string; CEO: Person }

let company = 
    { Name = "Contoso"
      CEO = { Name = "Alice"
              Address = { Street = "123 Main St"
                         City = "Seattle"
                         PostalCode = "98101" } } }

// Update nested fields concisely
let updatedCompany = 
    { company with CEO.Address.City = "Portland" }
```

This syntax eliminates deeply nested `with` expressions and makes record updates more intuitive.

## Computation expressions

### `while!` in computation expressions

F# 8 introduces the `while!` keyword, which allows you to use asynchronous or computation expression operations directly in while loops. This reduces boilerplate and makes async code more readable.

Before F# 8:

```fsharp
let processStream (stream: Stream) = async {
    let buffer = Array.zeroCreate 1024
    let mutable continueReading = true
    while continueReading do
        let! bytesRead = stream.AsyncRead(buffer, 0, buffer.Length)
        if bytesRead = 0 then
            continueReading <- false
        else
            // Process buffer
            processBuffer buffer bytesRead
}
```

Starting with F# 8:

```fsharp
let processStream (stream: Stream) = async {
    let buffer = Array.zeroCreate 1024
    while! stream.AsyncRead(buffer, 0, buffer.Length) do
        // Process buffer
        processBuffer buffer bytesRead
}
```

The `while!` keyword automatically handles the computation expression binding, making the code more concise and eliminating the need for manual state management.

## Enhanced pattern matching

F# 8 includes improvements to pattern matching that enhance code clarity and reduce verbosity. These improvements make it easier to work with complex data structures and reduce the need for nested match expressions.

## Numeric literals

F# 8 allows you to use more flexible expressions for numeric literals. The compiler evaluates these expressions at compile time, enabling clearer code when working with numeric constants:

```fsharp
// You can now use expressions in numeric literals
let kilobyte = 1024
let megabyte = 1024 * kilobyte
let gigabyte = 1024 * megabyte

// This is evaluated at compile time
let bufferSize = 64 * 1024  // 64 KB
```

## Performance improvements

F# 8 includes various performance optimizations:

- **Faster compilation**: Improvements to the type checker and compiler infrastructure reduce build times for large projects.
- **Better code generation**: Enhanced optimization passes produce more efficient IL code.
- **Reduced allocations**: Several core library functions now allocate less memory, improving performance in allocation-heavy scenarios.

## Tooling enhancements

F# 8 brings improvements to the development experience:

- **Better error messages**: More helpful and actionable compiler errors and warnings guide you toward correct code.
- **Improved IDE support**: Enhanced IntelliSense, code completion, and tooltips in Visual Studio and Visual Studio Code.
- **Faster editing experience**: Reduced latency for common IDE operations like go-to-definition and find-all-references.

## See also

- [F# Language Reference](../language-reference/index.md)
- [What's new in F# 9](fsharp-9.md)
- [What's new in .NET 8](../../core/whats-new/dotnet-8/overview.md)
