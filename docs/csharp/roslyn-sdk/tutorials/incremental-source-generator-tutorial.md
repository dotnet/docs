---
title: "Tutorial: Create an incremental source generator"
description: Build a complete incremental source generator step-by-step using the IIncrementalGenerator interface and the Roslyn APIs.
ms.date: 02/06/2026
ai-usage: ai-assisted
---

# Tutorial: Create an incremental source generator

In this tutorial, you build an incremental source generator that generates new members inside a `partial` class when a marker attribute is applied. You'll learn how to:

- Set up a source generator project.
- Inject a marker attribute into the compilation with `RegisterPostInitializationOutput`.
- Use `ForAttributeWithMetadataName` to find types with a specific attribute.
- Extract type metadata from the semantic model.
- Emit generated source code with `RegisterSourceOutput`.
- Reference the generator from a consuming application.

The generator you build creates a `Describe()` method and a `PropertyNames` list for any class or struct decorated with `[GenerateMembers]`.

> [!TIP]
> The complete sample code for this tutorial is available in the [dotnet/samples](https://github.com/dotnet/samples/tree/main/csharp/roslyn-sdk/SourceGenerators/GenerateMembers) repository.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download) or later.
- A code editor such as [Visual Studio](https://visualstudio.microsoft.com/downloads/), [Visual Studio Code](https://code.visualstudio.com/), or any text editor.

## Create the generator project

Start by creating a class library for the source generator. Source generators must target .NET Standard 2.0 because the compiler loads them as .NET Standard assemblies.

1. Create a folder for the solution and navigate into it:

   ```bash
   mkdir SourceGeneratorDemo
   cd SourceGeneratorDemo
   ```

1. Create the source generator class library:

   ```bash
   dotnet new classlib -n GenerateMembersGenerator
   ```

1. Replace the contents of `GenerateMembersGenerator/GenerateMembersGenerator.csproj` with the following project file:

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

   Key settings:

   - **`netstandard2.0`**: Required because the compiler loads generators as .NET Standard 2.0 assemblies.
   - **`LangVersion latest`**: Lets you use modern C# features in the generator code itself.
   - **`EnforceExtendedAnalyzerRules`**: Enables extra compile-time checks that catch common source generator mistakes.
   - **`PrivateAssets="all"`**: Prevents the Roslyn packages from flowing to consumers of the generator.
   - **`Microsoft.CodeAnalysis.Analyzers`**: Provides analyzer rules that help you author correct generators.

1. Delete the generated `Class1.cs` file:

   ```bash
   rm GenerateMembersGenerator/Class1.cs
   ```

## Write the source generator

The generator has three responsibilities:

- Inject a marker attribute (`[GenerateMembers]`) into the compilation.
- Find types decorated with that attribute and extract their property metadata.
- Generate a `Describe()` method and a `PropertyNames` list for each matching type.

Create a file named `GenerateMembersIncrementalGenerator.cs` in the `GenerateMembersGenerator` folder and add the following code.

### Define the marker attribute

The generator injects its own marker attribute into the consuming project at compile time. This technique avoids requiring consumers to reference a separate shared library just for the attribute definition.

Define the attribute source as a constant string in the generator class:

:::code language="csharp" source="../snippets/incremental-source-generator-tutorial/csharp/GenerateMembersGenerator/GenerateMembersIncrementalGenerator.cs" id="AttributeSource":::

The attribute targets both classes and structs, and uses fully qualified type names (prefixed with `global::`) to avoid namespace conflicts in the consuming project.

### Implement the Initialize method

The `Initialize` method defines the incremental pipeline. It runs once when the compiler loads the generator.

:::code language="csharp" source="../snippets/incremental-source-generator-tutorial/csharp/GenerateMembersGenerator/GenerateMembersIncrementalGenerator.cs" id="Initialize":::

The pipeline has three parts:

1. **`RegisterPostInitializationOutput`** injects the `GenerateMembersAttribute` into the compilation so consumers can reference it without an extra assembly.
1. **`ForAttributeWithMetadataName`** combines the syntactic predicate and semantic matching into a single call. It filters for type declarations that carry the `[GenerateMembers]` attribute, then calls `GetTypeInfo` to extract metadata. This approach is simpler and more efficient than writing a separate `CreateSyntaxProvider` with manual attribute-name checking.
1. **`RegisterSourceOutput`** wires up the code generation step.

### Extract type metadata

The `GetTypeInfo` method receives a `GeneratorAttributeSyntaxContext` and extracts the information needed to generate code—the namespace, type name, type keyword (`class` or `struct`), and a list of instance properties:

:::code language="csharp" source="../snippets/incremental-source-generator-tutorial/csharp/GenerateMembersGenerator/GenerateMembersIncrementalGenerator.cs" id="GetTypeInfo":::

This method:

- Checks `IsGlobalNamespace` so the generator handles types declared without a namespace.
- Filters out `static` and indexer properties, keeping only instance properties.
- Returns an immutable data object (`TypeInfo`) that the pipeline can cache and compare between runs.

### Define the TypeInfo data class

The `TypeInfo` class holds the extracted metadata. It's an immutable container that the pipeline uses for caching:

:::code language="csharp" source="../snippets/incremental-source-generator-tutorial/csharp/GenerateMembersGenerator/GenerateMembersIncrementalGenerator.cs" id="TypeInfoClass":::

### Add the code generation step

The `GenerateSource` method takes a `TypeInfo` and builds the generated source code as a string. It emits a `partial` type with two members:

:::code language="csharp" source="../snippets/incremental-source-generator-tutorial/csharp/GenerateMembersGenerator/GenerateMembersIncrementalGenerator.cs" id="GenerateSource":::

Key points:

- **`PropertyNames`** is a `static IReadOnlyList<string>` containing the names of all instance properties.
- **`Describe()`** is an instance method that returns a human-readable description of the object using `StringBuilder`.
- Generated types use fully qualified names (for example, `global::System.Text.StringBuilder`) to avoid `using` conflicts.
- Each generated file starts with `// <auto-generated />` so code analysis tools skip it.

### Build the generator

Build the project to verify there are no errors:

```bash
dotnet build GenerateMembersGenerator
```

## Create the consuming application

Now create a console application that uses the generator.

1. From the `SourceGeneratorDemo` folder, create a console application:

   ```bash
   dotnet new console -n GenerateMembersDemo
   ```

1. Replace the contents of `GenerateMembersDemo/GenerateMembersDemo.csproj` with the following:

   ```xml
   <Project Sdk="Microsoft.NET.Sdk">

     <PropertyGroup>
       <OutputType>Exe</OutputType>
       <TargetFramework>net8.0</TargetFramework>
       <Nullable>enable</Nullable>
       <ImplicitUsings>enable</ImplicitUsings>
     </PropertyGroup>

     <ItemGroup>
       <ProjectReference Include="../GenerateMembersGenerator/GenerateMembersGenerator.csproj"
                         OutputItemType="Analyzer"
                         ReferenceOutputAssembly="false" />
     </ItemGroup>

   </Project>
   ```

   The `ProjectReference` uses `OutputItemType="Analyzer"` to tell the compiler to load `GenerateMembersGenerator` as a source generator. The `ReferenceOutputAssembly="false"` attribute prevents the consuming project from referencing the generator assembly at runtime.

1. Replace the contents of `GenerateMembersDemo/Program.cs`:

   :::code language="csharp" source="../snippets/incremental-source-generator-tutorial/csharp/GenerateMembersDemo/Program.cs" id="Program":::

   The `Person` class is marked `partial` so the compiler can merge it with the generated `partial class` that contains the `Describe()` method and `PropertyNames` property.

## Run the application

Run the application from the `SourceGeneratorDemo` folder:

```bash
dotnet run --project GenerateMembersDemo
```

The output is:

```output
Person
  FirstName = Alice
  LastName = Smith
  Age = 30

Properties:
  FirstName
  LastName
  Age
```

The `Describe()` method and `PropertyNames` list don't exist in your source code—the source generator created them at compile time.

## Explore the generated code

To see the generated files, add the following property to `GenerateMembersDemo.csproj` inside the `<PropertyGroup>`:

```xml
<EmitCompilerGeneratedFiles>true</EmitCompilerGeneratedFiles>
```

Build the project again, and look in the `obj/Debug/net8.0/generated/` folder. You'll find:

- `GenerateMembersAttribute.g.cs`: The marker attribute injected by `RegisterPostInitializationOutput`.
- `Person.GeneratedMembers.g.cs`: The generated partial class with `Describe()` and `PropertyNames`.

## How the pipeline works

Understanding the incremental pipeline helps you write efficient generators:

1. **`ForAttributeWithMetadataName` combines filtering and matching.** The compiler resolves attribute metadata internally, so you don't need a separate syntactic predicate and semantic transform. The `predicate` parameter receives only the syntax node type check.
1. **`GetTypeInfo` extracts only what's needed.** By returning a small, immutable data object, you keep the pipeline cacheable. The compiler compares `TypeInfo` outputs between runs and skips code generation when nothing changed.
1. **Caching eliminates redundant work.** If a file that doesn't contain `[GenerateMembers]` changes, the generator doesn't rerun the `GenerateSource` step.
1. **Output runs only when inputs change.** The `RegisterSourceOutput` callback runs only when the `TypeInfo` value differs from the previous compilation.

## Next steps

Try extending this generator or exploring other source generator patterns:

- Add diagnostic reporting with `SourceProductionContext.ReportDiagnostic` for error cases (for example, when `[GenerateMembers]` is applied to a non-partial type).
- Build a generator that reads non-C# files using `AdditionalTextsProvider`—see the [CsvGenerator sample](https://github.com/dotnet/samples/tree/main/csharp/roslyn-sdk/SourceGenerators/CsvGenerator) for an example that turns `.csv` files into strongly-typed C# classes.
- Read additional configuration from `.editorconfig` or MSBuild properties via `AnalyzerConfigOptionsProvider`.

For more information, see:

- [Source generators overview](../source-generators-overview.md)
- [Roslyn incremental generators specification](https://github.com/dotnet/roslyn/blob/main/docs/features/incremental-generators.md)
- [Tutorial: Write your first analyzer and code fix](how-to-write-csharp-analyzer-code-fix.md)
