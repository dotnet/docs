---
title: Source generators overview
description: Learn about source generators in .NET, how they work, and when to use incremental source generators to generate code at compile time.
ms.date: 02/06/2026
ai-usage: ai-assisted
---

# Source generators overview

Source generators let you generate C# source code during compilation. A source generator reads your existing code, performs analysis, and produces new files that the compiler includes in the compilation. Unlike reflection-based approaches, source generators run at compile time, improving performance and enabling ahead-of-time (AOT) compilation scenarios.

## What source generators do

A source generator is a component that plugs into the C# compiler. It runs as part of compilation and can inspect the program being compiled. Based on what it finds, it produces additional C# source files that the compiler includes in the final output.

Source generators can:

- Read the source code of the project being compiled.
- Read additional files included in the compilation.
- Create new C# source files that become part of the compilation.
- Report diagnostics (warnings and errors) to the user.

Source generators *can't* modify existing source code. They can only *add* new source files.

## Why use source generators

Source generators solve several common problems in .NET development:

- **Replace runtime reflection.** Instead of inspecting types at runtime, generate strongly typed code at compile time. This improves startup performance and enables AOT compilation.
- **Eliminate boilerplate.** Automatically generate repetitive code patterns like `INotifyPropertyChanged` implementations, serialization logic, or dependency injection registrations.
- **Enforce patterns at compile time.** Generate code that conforms to specific patterns, catching issues during compilation instead of at runtime.
- **Improve performance.** Pre-compute work during compilation rather than at runtime, avoiding the overhead of runtime code generation or reflection.

## Source generators in the .NET platform

Several .NET libraries and frameworks use source generators. Some notable examples include:

- **System.Text.Json** generates serialization code for JSON processing, avoiding runtime reflection.
- **LoggerMessage** generates high-performance logging methods from partial method declarations.
- **Regex** generates optimized regular expression matching code at compile time.
- **LibraryImport** generates P/Invoke marshalling code for native interop.

## Incremental source generators

Incremental source generators implement the <xref:Microsoft.CodeAnalysis.IIncrementalGenerator> interface and represent the current recommended approach for building source generators. They replace the older `ISourceGenerator` interface.

Incremental generators use a *pipeline model* that filters and transforms data incrementally. The compiler caches intermediate results and only reruns the parts of the pipeline that are affected by changes. This design keeps the IDE responsive even in large projects.

### Pipeline stages

An incremental generator defines a pipeline in its `Initialize` method. The pipeline typically follows these stages:

1. **Select nodes.** Use a syntax provider to find candidate syntax nodes (for example, class declarations with a specific attribute).
1. **Filter with semantics.** Apply the semantic model to confirm the candidate matches your criteria.
1. **Generate output.** Produce new source code and add it to the compilation.

The following example shows a minimal incremental source generator that produces a static helper class:

:::code language="csharp" source="./snippets/source-generators-overview/csharp/MinimalGenerator.cs" id="MinimalGenerator":::

The `[Generator]` attribute marks the class as a source generator. The `Initialize` method registers a post-initialization output that injects the `GeneratedHelper` class into every compilation that references this generator.

### Common input providers

The `IncrementalGeneratorInitializationContext` exposes several providers that supply data to the pipeline:

- **`SyntaxProvider`**: Use `CreateSyntaxProvider` to select syntax nodes based on a fast predicate, then transform them with the semantic model. Use `ForAttributeWithMetadataName` when you need to find types or members that carry a specific attribute—it combines syntactic filtering and semantic resolution in a single call.
- **`AdditionalTextsProvider`**: Access non-C# files (for example, `.csv`, `.json`, or `.xml` files) that are included in the project as `AdditionalFiles`. This provider enables generators that compile external data into C# code at build time.
- **`CompilationProvider`**: Access the full `Compilation` object for advanced scenarios where you need global compilation information.
- **`AnalyzerConfigOptionsProvider`**: Read configuration from `.editorconfig` files or MSBuild properties.

### How the compiler caches results

The compiler tracks the inputs to each pipeline stage. When a file changes, the compiler reruns only the stages whose inputs were affected. If a stage produces the same output as before, downstream stages don't rerun. This caching behavior is automatic—you get it by structuring your generator as a pipeline.

## Create a source generator project

Source generator projects require a specific setup:

- **Target `netstandard2.0`.** The compiler host loads generators as .NET Standard 2.0 assemblies.
- **Reference `Microsoft.CodeAnalysis.CSharp`.** This package provides the Roslyn APIs for syntax analysis and code generation.
- **Reference `Microsoft.CodeAnalysis.Analyzers`.** This package provides analyzer rules that help you author correct generators.
- **Set `EnforceExtendedAnalyzerRules` to `true`.** This property enables additional rules that help you avoid common source generator pitfalls.

A typical source generator project file looks like this:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>netstandard2.0</TargetFramework>
    <LangVersion>latest</LangVersion>
    <EnforceExtendedAnalyzerRules>true</EnforceExtendedAnalyzerRules>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.CodeAnalysis.CSharp"
                      Version="4.10.0"
                      PrivateAssets="all" />
    <PackageReference Include="Microsoft.CodeAnalysis.Analyzers"
                      Version="3.3.4"
                      PrivateAssets="all" />
  </ItemGroup>

</Project>
```

### Reference a source generator from a consuming project

The consuming project references the generator as an analyzer, not as a regular project reference:

```xml
<ItemGroup>
  <ProjectReference Include="../MySourceGenerator/MySourceGenerator.csproj"
                    OutputItemType="Analyzer"
                    ReferenceOutputAssembly="false" />
</ItemGroup>
```

The `OutputItemType="Analyzer"` attribute tells the compiler to load the referenced project as an analyzer. The `ReferenceOutputAssembly="false"` attribute prevents the consuming project from referencing the generator's types directly at runtime.

### Expose additional files to a generator

To pass non-C# files to a source generator (for example, `.csv` data files), include them as `AdditionalFiles` in the consuming project:

```xml
<ItemGroup>
  <AdditionalFiles Include="Data\*.csv" />
</ItemGroup>
```

The generator accesses these files through `context.AdditionalTextsProvider` in its pipeline.

## Debug source generators

To debug a source generator, add the following code at the start of the `Initialize` method:

```csharp
#if DEBUG
if (!System.Diagnostics.Debugger.IsAttached)
{
    System.Diagnostics.Debugger.Launch();
}
#endif
```

When you build the consuming project, the debugger attach dialog appears, and you can step through the generator code.

## Best practices

Follow these guidelines when building source generators:

- **Use `ForAttributeWithMetadataName` for attribute-driven generators.** It's simpler and more efficient than manually filtering with `CreateSyntaxProvider`.
- **Keep the predicate fast.** The `predicate` callback in `CreateSyntaxProvider` or `ForAttributeWithMetadataName` runs on every syntax node. Perform only quick syntactic checks.
- **Use `static` lambdas.** Mark your pipeline callbacks as `static` to avoid accidental closures that prevent caching.
- **Return small, immutable data objects from transforms.** This lets the pipeline compare results between runs and skip downstream stages when nothing changed.
- **Handle the global namespace.** Types declared without a namespace need special handling in your output.
- **Generate `partial` types.** Emit `partial` classes and methods so your generated code integrates with user-written code.
- **Use fully qualified type names.** Prefix generated type references with `global::` (for example, `global::System.Text.StringBuilder`) to avoid namespace conflicts.
- **Include `auto-generated` comments.** Start generated files with `// <auto-generated/>` so code analysis tools skip them.
- **Report errors as diagnostics.** Use `SourceProductionContext.ReportDiagnostic` instead of throwing exceptions.

## Samples

Working source generator samples are available in the [dotnet/samples](https://github.com/dotnet/samples/tree/main/csharp/roslyn-sdk/SourceGenerators) repository:

- [**GenerateMembers**](https://github.com/dotnet/samples/tree/main/csharp/roslyn-sdk/SourceGenerators/GenerateMembers)—Uses `ForAttributeWithMetadataName` to add a `Describe()` method and a `PropertyNames` list to any type decorated with a marker attribute.
- [**CsvGenerator**](https://github.com/dotnet/samples/tree/main/csharp/roslyn-sdk/SourceGenerators/CsvGenerator)—Uses `AdditionalTextsProvider` to read `.csv` files at build time and generate strongly-typed C# classes from them.

## Next steps

- [Tutorial: Create an incremental source generator](tutorials/incremental-source-generator-tutorial.md)
- [Roslyn incremental generators specification](https://github.com/dotnet/roslyn/blob/main/docs/features/incremental-generators.md)
