---
title: How to customize parsing and validation in System.CommandLine
ms.date: 06/16/2025
description: "Learn how to customize parsing and validation with the System.CommandLine library."
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
ms.topic: how-to
---

# How to customize parsing and validation in System.CommandLine

[!INCLUDE [scl-preview](../../../includes/scl-preview.md)]

By default, System.CommandLine provides a set of built-in parsers that can parse many common types:

* `bool`
* `byte` and `sbyte`
* `short` and `ushort`
* `int` and `uint`
* `long` and `ulong`
* `float` and `double`
* `decimal`
* `DateTime` and `DateTimeOffset`
* `DateOnly`and `TimeOnly`
* `Guid`
* <xref:System.IO.FileSystemInfo>, <xref:System.IO.FileInfo>, and <xref:System.IO.DirectoryInfo>
* enums
* **arrays and lists** of the listed types

Other types are not supported, but you can create custom parsers for them. You can also validate the parsed values, which is useful when you want to ensure that the input meets certain criteria.

## Validators

Every option, argument, and command can have one or more validators. Validators are used to ensure that the parsed value meets certain criteria. For example, you can validate that a number is positive, or that a string is not empty. You can also create complex validators that check against multiple conditions.

Every symbol type in System.CommandLine has a `Validators` property that contains a list of validators. The validators are executed after the input is parsed, and they can report an error if the validation fails.

To provide custom validation code, call <xref:System.CommandLine.Option.Validators.Add%2A> on your option or argument (or command), as shown in the following example:

:::code language="csharp" source="snippets/model-binding/csharp/AddValidator.cs" id="delayOption" :::

System.CommandLine provides a set of built-in validators that can be used to validate common types:

- `AcceptExistingOnly` - configures given option or argument to accept only values corresponding to an existing file or directory.
- `AcceptLegalFileNamesOnly` - configures given option or argument to accept only values representing legal file names.
- `AcceptOnlyFromAmong` - configures given option or argument to accept only values from a specified set of values.

## Custom parsers

Custom parsers are required to parse types with no default parser, such as complex types. They can also be used to parse supported types in a different way than the built-in parsers.

Suppose you have a `Person` type:

:::code language="csharp" source="snippets/model-binding/csharp/ComplexType.cs" id="persontype" :::

You can read the values and create an instance of `Person` in the command action:

:::code language="csharp" source="snippets/model-binding/csharp/ComplexType.cs" id="setaction" :::

With a custom parser, you can get a custom type the same way you get primitive values:

:::code language="csharp" source="snippets/model-binding/csharp/ParseArgument.cs" id="personoption" :::

If you want to parse as well as validate the input, use the `CustomParser` delegate, as shown in the following example:

:::code language="csharp" source="snippets/model-binding/csharp/ParseArgument.cs" id="delayOption" :::

Here are some examples of what you can do with `CustomParser` that you can't do with a validator:

* Parse other kinds of input strings (for example, parse "1,2,3" into `int[]`).
* Dynamic arity. For example, if you have two arguments that are defined as string arrays, and you have to handle a sequence of strings in the command-line input, the <xref:System.CommandLine.Parsing.ArgumentResult.OnlyTake%2A?displayProperty=nameWithType> method enables you to dynamically divide up the input strings between the arguments.

## See also

- [How to parse and invoke the result](parse-and-invoke.md)
- [System.CommandLine overview](index.md)
