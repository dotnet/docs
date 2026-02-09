---
title: Supported types in System.CommandLine
ms.date: 01/22/2026
description: "Learn about the types that System.CommandLine can parse automatically, including primitives, common .NET types, enums, and collections."
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
  - "type parsing"
  - "argument types"
ms.topic: conceptual
---

# Supported types in System.CommandLine

`System.CommandLine` provides built-in parsing support for a wide range of .NET types. This article describes which types are supported out of the box and how the library handles type conversion from command-line strings.

## Primitive types

The following primitive types are supported automatically:

### Integer types

- `byte` and `sbyte`
- `short` and `ushort`
- `int` and `uint`
- `long` and `ulong`

Integer values are parsed using the standard .NET `TryParse` methods. Parsing respects the current culture and accepts standard integer formats.

```csharp
var countOption = new Option<int>("--count", "Number of items");
// Command line: --count 42
```

### Floating-point types

- `float`
- `double`
- `decimal`

Floating-point values support standard decimal notation and scientific notation where applicable.

```csharp
var priceOption = new Option<decimal>("--price", "Item price");
// Command line: --price 19.99
```

### Boolean type

- `bool`

Boolean options can be specified with or without a value:

```csharp
var verboseOption = new Option<bool>("--verbose", "Enable verbose output");
// Command line: --verbose         (value is true)
// Command line: --verbose true    (value is true)
// Command line: --verbose false   (value is false)
```

For flag-style boolean options (where the option's presence means `true` and its absence means `false`), set the arity to zero:

```csharp
var debugOption = new Option<bool>("--debug", "Enable debug mode")
{
    Arity = ArgumentArity.Zero
};

// Command line: --debug            (value is true, flag is present)
// Command line:                    (value is false, flag is absent)
// This option cannot accept an explicit true/false value
```

Flag-style options are common for switches that enable features or modes. The default arity for `Option<bool>` is `ZeroOrOne`, which accepts both flag-style (`--verbose`) and explicit value (`--verbose true`) usage. Setting `Arity = ArgumentArity.Zero` restricts the option to flag-style only.

### String type

- `string`

String arguments accept any text value. Quotes can be used to include spaces:

```csharp
var nameOption = new Option<string>("--name", "User name");
// Command line: --name "John Doe"
```

## Date and time types

`System.CommandLine` supports parsing various date and time types:

### DateTime types

- `DateTime` - Date and time values
- `DateTimeOffset` - Date and time with time zone offset

```csharp
var startOption = new Option<DateTime>("--start", "Start date and time");
// Command line: --start "2026-01-22"
// Command line: --start "2026-01-22 14:30"
```

### .NET 6+ date and time types

Available when targeting .NET 6 or later:

- `DateOnly` - Date without time component
- `TimeOnly` - Time of day without date component

```csharp
var birthdayOption = new Option<DateOnly>("--birthday", "Date of birth");
// Command line: --birthday 1990-05-15
```

### Duration

- `TimeSpan` - Duration or time interval

```csharp
var timeoutOption = new Option<TimeSpan>("--timeout", "Request timeout");
// Command line: --timeout 00:01:30
// Command line: --timeout 1.5:30:00  (1.5 days)
```

## Other common types

### Unique identifier

- `Guid` - Globally unique identifier

```csharp
var idOption = new Option<Guid>("--id", "Entity identifier");
// Command line: --id a1b2c3d4-e5f6-7890-abcd-ef1234567890
```

### File system types

- <xref:System.IO.FileInfo> - Represents a file
- <xref:System.IO.DirectoryInfo> - Represents a directory
- <xref:System.IO.FileSystemInfo> - Base class for files and directories

These types automatically create `FileInfo` or `DirectoryInfo` objects from path strings. The file or directory doesn't need to exist unless you add validation.

```csharp
var inputOption = new Option<FileInfo>("--input", "Input file path");
var outputDirOption = new Option<DirectoryInfo>("--output-dir", "Output directory");

// Command line: --input data.txt --output-dir ./results
```

To require that files or directories exist, use the `AcceptExistingOnly()` method:

```csharp
var inputOption = new Option<FileInfo>("--input", "Input file path")
    .AcceptExistingOnly();
```

## Enum types

All enum types are supported with case-insensitive parsing:

```csharp
enum LogLevel
{
    Debug,
    Info,
    Warning,
    Error
}

var logLevelOption = new Option<LogLevel>("--log-level", "Logging level");
// Command line: --log-level info     (case-insensitive)
// Command line: --log-level INFO
// Command line: --log-level Info
```

Enum parsing uses the enum member names. If parsing fails, the error message suggests valid values.

## Nullable types

All value types listed above can be used as nullable types (`T?`). When no value is provided, the result is `null` instead of the type's default value:

```csharp
var ageOption = new Option<int?>("--age", "User age");
// If --age is not specified, the value is null (not 0)
```

## Collection types

`System.CommandLine` automatically supports collections of any supported type:

### Arrays

- `T[]` - Arrays of any supported type

```csharp
var namesOption = new Option<string[]>("--names", "List of names");
// Command line: --names Alice Bob Charlie
```

### Lists

- `List<T>` - Generic lists of any supported type
- `IEnumerable<T>` - Enumerable sequences (parsed as arrays)
- `IList<T>` - List interface (parsed as arrays)
- `ICollection<T>` - Collection interface (parsed as arrays)

```csharp
var portsOption = new Option<List<int>>("--ports", "Port numbers to listen on");
// Command line: --ports 8080 8081 8082
```

Collections support both space-separated and repeated option syntax:

```csharp
// Space-separated
// Command line: --tags alpha beta gamma

// Repeated option
// Command line: --tag alpha --tag beta --tag gamma
```

## How type conversion works

When `System.CommandLine` parses command-line input, it:

1. **Identifies the target type** from the generic parameter of `Option<T>` or `Argument<T>`
2. **Extracts string tokens** from the command line
3. **Calls the appropriate converter** based on the target type
4. **Validates the conversion** and reports errors if parsing fails
5. **Returns the typed value** or a collection of typed values

For example, with `Option<int>`:

```csharp
var countOption = new Option<int>("--count", "Number of items");
```

The command line `--count 42` is parsed as:
1. Token "42" is extracted
2. `int.TryParse("42", out var value)` is called
3. The result `42` is returned as an `int`

If parsing fails (for example, `--count abc`), an error message is automatically generated:

```
Cannot parse argument 'abc' for option '--count' as expected type 'System.Int32'.
```

## Custom types

For types not listed above, you need to provide a custom parser. See [How to customize parsing and validation](how-to-customize-parsing-and-validation.md) for details on parsing custom types.

## See also

- [How to customize parsing and validation](how-to-customize-parsing-and-validation.md)
- [Command-line syntax overview](syntax.md)
- [System.CommandLine overview](index.md)
