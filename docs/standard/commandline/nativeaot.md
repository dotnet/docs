---
title: How to use System.CommandLine with NativeAOT
ms.date: 01/22/2026
description: "Learn how to build trim-friendly and NativeAOT-compatible command-line applications using System.CommandLine."
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
  - "NativeAOT"
  - "AOT compilation"
  - "trimming"
ms.topic: how-to
---

# How to use System.CommandLine with NativeAOT

`System.CommandLine` is designed to be trim-friendly and compatible with Native AOT compilation, making it an excellent choice for building fast, lightweight command-line applications. This article explains how to use `System.CommandLine` in NativeAOT applications and what to consider.

## What is NativeAOT?

Native AOT (Ahead-Of-Time) compilation compiles your .NET application directly to native code, eliminating the need for the .NET runtime. Benefits include:

- **Faster startup** - No JIT compilation at runtime
- **Smaller deployment** - Self-contained native executable without runtime dependencies
- **Lower memory usage** - No JIT compiler overhead
- **Better performance** - Optimized native code

For more information, see [Native AOT deployment](../../core/deploying/native-aot/index.md).

## System.CommandLine and NativeAOT

`System.CommandLine` is specifically designed to work well with trimming and NativeAOT:

- Minimal use of reflection
- Trim-friendly API design
- Explicit type information through generics
- No dynamic code generation

This makes it a better choice for AOT scenarios compared to attribute-based libraries that rely heavily on reflection.

## Enable NativeAOT in your project

To enable NativeAOT compilation, add the following to your project file (`.csproj`):

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <PublishAot>true</PublishAot>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="System.CommandLine" Version="2.0.2" />
  </ItemGroup>
</Project>
```

The `<PublishAot>true</PublishAot>` property enables Native AOT compilation when you publish your application.

## Build and publish

Build and publish your NativeAOT application using:

```dotnetcli
dotnet publish -c Release
```

The output is a self-contained native executable with no external dependencies.

## Best practices for NativeAOT compatibility

### Use explicit types

Always use strongly-typed `Option<T>` and `Argument<T>` rather than non-generic versions:

```csharp
// Good - explicit type information
var countOption = new Option<int>("--count", "Number of items");

// Avoid - requires runtime type inspection
var option = new Option("--count");
```

### Avoid dynamic parsing

Stick to built-in type converters or provide explicit custom parsers:

```csharp
// Good - built-in type support
var inputOption = new Option<FileInfo>("--input", "Input file");

// Good - explicit custom parser
var personOption = new Option<Person>("--person", "Person data")
{
    CustomParser = result =>
    {
        var value = result.Tokens.Single().Value;
        var parts = value.Split(',');
        return new Person(parts[0], int.Parse(parts[1]));
    }
};
```

### Use simple validators

Custom validators work well with NativeAOT as long as they don't use reflection:

```csharp
var delayOption = new Option<int>("--delay", "Delay in milliseconds");
delayOption.Validators.Add(result =>
{
    if (result.GetValue<int>() < 0)
    {
        result.AddError("Delay must be non-negative.");
    }
});
```

### Avoid reflection-based binding

Don't use reflection to bind parsed values to properties. Instead, use the parsed values directly:

```csharp
// Good - direct value access
var rootCommand = new RootCommand("My application");
var nameOption = new Option<string>("--name", "User name");
rootCommand.Options.Add(nameOption);

rootCommand.SetAction((string name) =>
{
    Console.WriteLine($"Hello, {name}!");
}, nameOption);

// Avoid - reflection-based approaches
```

### Test trimming warnings

Before enabling `PublishAot`, test your application with trimming enabled:

```xml
<PropertyGroup>
  <PublishTrimmed>true</PublishTrimmed>
  <TrimMode>link</TrimMode>
</PropertyGroup>
```

Publish the application and check for trim warnings:

```dotnetcli
dotnet publish -c Release
```

Any warnings indicate potential runtime issues with NativeAOT.

## Example: NativeAOT-compatible CLI application

Here's a complete example of a NativeAOT-compatible application using `System.CommandLine`:

```csharp
using System;
using System.CommandLine;
using System.IO;

var rootCommand = new RootCommand("File processor");

var inputOption = new Option<FileInfo>("--input", "Input file path")
{
    Required = true
}.AcceptExistingOnly();

var outputOption = new Option<FileInfo>("--output", "Output file path")
{
    Required = true
};

var verboseOption = new Option<bool>("--verbose", "Enable verbose logging");

rootCommand.Options.Add(inputOption);
rootCommand.Options.Add(outputOption);
rootCommand.Options.Add(verboseOption);

rootCommand.SetAction((FileInfo input, FileInfo output, bool verbose) =>
{
    if (verbose)
    {
        Console.WriteLine($"Processing {input.FullName}...");
    }

    var content = File.ReadAllText(input.FullName);
    var processed = content.ToUpper(); // Example processing
    File.WriteAllText(output.FullName, processed);

    if (verbose)
    {
        Console.WriteLine($"Output written to {output.FullName}");
    }

    Console.WriteLine("Done.");
}, inputOption, outputOption, verboseOption);

return rootCommand.Invoke(args);
```

Project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <PublishAot>true</PublishAot>
    <InvariantGlobalization>true</InvariantGlobalization>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="System.CommandLine" Version="2.0.2" />
  </ItemGroup>
</Project>
```

> [!NOTE]
> `InvariantGlobalization` is set to `true` to reduce the application size by excluding culture-specific data. This is optional but common for NativeAOT applications.

## Performance characteristics

NativeAOT applications using `System.CommandLine` typically show:

- **Startup time:** 2-5x faster than JIT-compiled equivalents
- **Memory usage:** 50-70% lower runtime memory footprint
- **Binary size:** Comparable or larger than trimmed self-contained deployments, but with no runtime dependencies

## Limitations and considerations

### Reflection limitations

NativeAOT has limited reflection support. Avoid:

- Dynamic type discovery
- Attribute-based configuration
- Runtime code generation

### Startup size

NativeAOT binaries include all required code, which can make them larger than framework-dependent deployments. Use trimming optimizations to minimize size.

### Platform support

NativeAOT requires platform-specific toolchains:

- Windows: Visual Studio 2022+ or Build Tools
- Linux: clang and developer packages
- macOS: Xcode command-line tools

See [Native AOT deployment prerequisites](../../core/deploying/native-aot/index.md#prerequisites) for details.

## Troubleshooting

### Trim warnings

If you see trim warnings related to `System.CommandLine`, file an issue on the [command-line-api GitHub repository](https://github.com/dotnet/command-line-api/issues). The library is designed to be trim-safe, and warnings may indicate a bug.

### Runtime errors

If your application builds but fails at runtime:

1. Test with `PublishTrimmed=true` first to identify trim-related issues
2. Check that you're not using reflection-based patterns
3. Verify all custom parsers use explicit types
4. Review the [Native AOT compatibility docs](../../core/deploying/native-aot/index.md)

## See also

- [Native AOT deployment](../../core/deploying/native-aot/index.md)
- [Trim self-contained deployments](../../core/deploying/trimming/trim-self-contained.md)
- [System.CommandLine overview](index.md)
- [Supported types in System.CommandLine](supported-types.md)
