---
title: Explore string interpolation handlers
description: This advanced tutorial shows how you can write a custom string interpolation handler that hooks into the runtime processing of an interpolated string.
ms.date: 10/19/2021
---
# Tutorial: Write a custom string interpolation handler

Explain what it is and why you would do it.

In this tutorial, you'll learn how to:

> [!div class="checklist"]
>
> - Implement the string interpolation handler pattern
> - Interact with the receiver in a string interpolation operation.
> - Add arguments to the string interpolation handler
> - Understand the new library features for string interpolation

## Prerequisites

You'll need to set up your machine to run .NET 6, including the C# 10.0 compiler. The C# 10 compiler is available starting with [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) or [.NET Core 6.0 SDK](https://dotnet.microsoft.com/download).

This tutorial assumes you're familiar with C# and .NET, including either Visual Studio or the .NET Core CLI.

## New outline

C# 10 adds support for a custom [*interpolated string handler*](~/_csharplang/proposals/csharp-10.0/improved-interpolated-strings.md#the-handler-pattern). An interpolated string handler is a type that processes the placeholder expression in an interpolated string. Without a custom handler, placeholders are processed similar to <xref:System.String.Format%2A?displayProperty=nameWithType>. Each placeholder is formatted as text, and then the components are concatenated to form the resulting string.

You can write a handler for any scenario where you use information about the resulting string. Will it be used? What constraints are on the format? Some examples include:

- You may require none of the resulting strings are greater than some limit, such as 80 characters. You can process the interpolated strings to fill a fixed-length buffer, and stop processing once that buffer length is reached.
- You may have a tabular format, and each placeholder must have a fixed length. A custom handler can enforce that, rather than forcing all client code to conform.

In this tutorial, you'll create a string interpolation handler for one of the core performance scenarios: logging libraries. Depending on the configured log level, the work to construct a log message isn't needed. If logging is off, the work to construct a string from an interpolated string expression isn't needed. The message is never printed, so any string concatenation can be skipped. In addition, any expressions used in the placeholder, including generating stack traces, doesn't need to be done.

An interpolated string handler can determine is the formatted string will be used, and only perform the necessary work if needed.

## Initial implementation

Let's start from a basic `Logger` class that supports different levels:

:::code language="csharp" source="./snippets/interpolated-string-handler/Logger-v1.cs" id="InitialLogger":::

This `Logger` supports six different levels. When a message won't pass the log level filter, there's no output. The public API for the logger accepts a (fully formatted) string as the message. All the work to create the string has already been done.

## Implement the handler pattern

The step is to build an *interpolated string handler* that recreates the current behavior. An interpolated string handler is a type that must have the following characteristics:

- The <xref:System.Runtime.CompilerServices.InterpolatedStringHandlerAttribute?displayProperty=fullName> applied to the type.
- A constructor that has two `int` parameters, `literalLength` and `formatCount`. (More parameters are allowed).
- A public `AppendLiteral` method with the signature: `public void AppendLiteral(string s)`.
- A generic public `AppendFormatted` method with the signature: `public void AppendFormatted<T>(T t)`.

Internally, the builder creates the formatted string, and provides a member for a client to retrieve that string. The following code shows a `CoreInterpolatedStringHandler` type that meets these requirements:

:::code language="csharp" source="./snippets/interpolated-string-handler/Logger-v2.cs" id="CoreInterpolatedStringHandler":::

You can now add an overload to `LogMessage` in the `Logger` class to try your new interpolated string handler:

:::code language="csharp" source="./snippets/interpolated-string-handler/Logger-v2.cs" id="LogMessageOverload":::

You don't need to remove the original `LogMessage` method, the compiler will prefer a method with an interpolated handler parameter over a method with a `string` parameter when the argument is an interpolated string expression.

You can verify that the new handler is invoked using the following code as the main program:

:::code language="csharp" source="./snippets/interpolated-string-handler/Version_2_Examples.cs" id="UseInterpolatedHandler":::

Running the application produces output similar to the following text:

```powershell
        literal length: 52, formattedCount: 1
        AppendLiteral called: {CurrentTime: }
        Appended the literal string
        AppendFormatted called: {10/19/2021 1:23:11 PM} is of type System.DateTime
        Appended the formatted object
        AppendLiteral called: {. This is an error. It will be printed.}
        Appended the literal string
CurrentTime: 10/19/2021 1:23:11 PM. This is an error. It will be printed.
        literal length: 37, formattedCount: 1
        AppendLiteral called: {CurrentTime: }
        Appended the literal string
        AppendFormatted called: {10/19/2021 1:23:11 PM} is of type System.DateTime
        Appended the formatted object
        AppendLiteral called: {. This won't be printed.}
        Appended the literal string
This warning is a string, not an interpolated string expression.
```

Tracing through the output, you can see how the compiler adds code to call the handler and build the string:

- The compiler adds a call to construct the handler, passing the total length of the literal text in the format string, and the number of placeholders.
- The compiler adds calls to `AppendLiteral` and `AppendFormatted` for each section of the literal string and for each placeholder.
- The compiler invokes the `LogMessage` method using the `CoreInterpolatedStringHandler` as the argument.

Finally, notice that the last warning doesn't invoke the interpolated string handler. The argument is a `string`, so that call invokes the other overload with a string parameter.

## Add more capabilities to the handler

The preceding version of the interpolated string handler implements the pattern. To avoid processing every placeholder expression, you'll need more information in the handler. In this section, you'll improve your handler so that it does less work when the constructed string won't be written to the log. You use <xref:System.Runtime.CompilerServices.InterpolatedStringHandlerArgumentAttribute?displayProperty=fullName> to specify a mapping between parameters to a public API and parameters to a handler's constructor. That provides the handler with the information needed to determine if the interpolated string should be evaluated.

Let's start with changes to the Handler. First, add a field to track if the handler is enabled. Add two parameters to the constructor: one to specify the log level for this message, and the other a reference to the log object:

:::code language="csharp" source="./snippets/interpolated-string-handler/logger-v3.cs" id="AddEnabledFlag":::

Next, use the field so that your handler only appends literals or formatted objects when the final string will be used:

:::code language="csharp" source="./snippets/interpolated-string-handler/logger-v3.cs" id="AppendWhenEnabled":::

Next, you'll need to update the `LogMessage` declaration so that the compiler passes the additional parameters to the handler's constructor. That's handled using the <xref:System.Runtime.CompilerServices.InterpolatedStringHandlerArgumentAttribute?displayProperty=nameWithType> on the handler argument:

:::code language="csharp" source="./snippets/interpolated-string-handler/logger-v3.cs" id="ArgumentsToHandlerConstructor":::

This attribute specifies the list of arguments to `LogMessage` that map to the parameters that follow the required `literalLength` and `formattedCount` parameters. The empty string (""), specifies the receiver. The compiler substitutes the value of the `Logger` object represented by `this` for the next argument to the handler's constructor. The compiler substitutes the value of `level` for the following argument. You can provide any number of arguments for any handler you write. You add additional string arguments.

You can run this version using the same test code. This time, you'll see the following results:

```powershell
        literal length: 52, formattedCount: 1
        AppendLiteral called: {CurrentTime: }
        Appended the literal string
        AppendFormatted called: {10/19/2021 1:23:11 PM} is of type System.DateTime
        Appended the formatted object
        AppendLiteral called: {. This is an error. It will be printed.}
        Appended the literal string
CurrentTime: 10/19/2021 1:23:11 PM. This is an error. It will be printed.
        literal length: 37, formattedCount: 1
        AppendLiteral called: {CurrentTime: }
        AppendFormatted called: {10/19/2021 1:23:11 PM} is of type System.DateTime
        AppendLiteral called: {. This won't be printed.}
This warning is a string, not an interpolated string expression.
```

You can see that the `AppendLiteral` and `AppendFormat` methods are being called, but they aren't doing any work. The handler has determined that the final string won't be needed, so the handler doesn't build it. There are still a couple of improvements to make.

First, you can add an overload of `AppendFormatted` that constrains the argument to a type that implements <xref:System.IFormattable?displayProperty=nameWithType>. This overload enables callers to add format strings in the placeholders:

:::code language="csharp" source="./snippets/interpolated-string-handler/logger-v4.cs" id="AppendIFormattable":::

With that addition, you can specify format strings in your interpolated string expression:

:::code language="csharp" source="./snippets/interpolated-string-handler/Version_4_Examples.cs" id="UseFormattable":::

The `:t` on the first message specifies the "short time format" for the current time.

You can make one final update to the handler's constructor that improves efficiency. The handler can add a final `out bool` parameter. Setting that parameter to `false` indicates that the handler shouldn't be called to process the interpolated string expression:

:::code language="csharp" source="./snippets/interpolated-string-handler/logger-v4.cs" id="UseOutParameter":::

Now, when you run the sample, you'll see the following output:

```powershell
        literal length: 47, formattedCount: 1
        AppendLiteral called: CurrentTime:
        Appended the literal string
        AppendFormatted called: 10/19/2021 1:23:11 PM is of type System.DateTime
        Appended the formatted object
        AppendLiteral called: . The time doesn't use formatting.
        Appended the literal string
CurrentTime: 10/19/2021 1:23:11 PM. The time doesn't use formatting.
        literal length: 52, formattedCount: 1
        AppendLiteral called: CurrentTime:
        Appended the literal string
        AppendFormatted (IFormattable version) called: 10/19/2021 1:23:11 PM with format {t} is of type System.DateTime,
        Appended the formatted object
        AppendLiteral called: . This is an error. It will be printed.
        Appended the literal string
CurrentTime: 1:23 PM. This is an error. It will be printed.
        literal length: 37, formattedCount: 1
This warning is a string, not an interpolated string expression.
```

The only output when `LogLevel.Trace` was specified is the output from the constructor. The handler indicated that it's not enabled, so none of the `Append` methods were invoked.

This example illustrates an important point for interpolated string handlers, especially when logging libraries are used. Any side-effects in the placeholders may not occur.  Add the following code to your main program and see this behavior in action:

:::code language="csharp" source="./snippets/interpolated-string-handler/Version_4_Examples.cs" id="TestSideeffects":::

You can see the `index` variable is incremented five times each iteration of the loop. Because the placeholders are evaluated only for `Critical`, `Error` and `Warning` levels, not for `Information` and `Trace`, the final value of `index` doesn't match the expectation:

```powershell
Critical
Critical: Increment index a few times 0, 1, 2, 3, 4
Error
Error: Increment index a few times 5, 6, 7, 8, 9
Warning
Warning: Increment index a few times 10, 11, 12, 13, 14
Information
Trace
Value of index 15, value of numberOfIncrements: 25
```

Interpolated string handlers provide greater control over how an interpolated string expression is converted to a string. The .NET runtime team has already used this feature to improve performance in several areas. You can make use of the same capability in your own libraries.
