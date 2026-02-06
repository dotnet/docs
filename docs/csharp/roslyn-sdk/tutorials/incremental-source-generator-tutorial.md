---
title: "Tutorial: Create an incremental source generator"
description: Build a complete incremental source generator step-by-step using the IIncrementalGenerator interface and the Roslyn APIs.
ms.date: 02/06/2026
ai-usage: ai-assisted
---

# Tutorial: Create an incremental source generator

In this tutorial, you build an incremental source generator that adds a `HelloFrom` method to any class decorated with a `[HelloFrom]` attribute. You'll learn how to:

- Set up a source generator project.
- Define a pipeline that finds classes with a specific attribute.
- Use the semantic model to verify attribute matches.
- Emit generated source code.
- Reference the generator from a consuming application.

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download) or later.
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
   dotnet new classlib -n MySourceGenerator
   ```

1. Replace the contents of `MySourceGenerator/MySourceGenerator.csproj` with the following project file:

   ```xml
   <Project Sdk="Microsoft.NET.Sdk">

     <PropertyGroup>
       <TargetFramework>netstandard2.0</TargetFramework>
       <LangVersion>latest</LangVersion>
       <Nullable>enable</Nullable>
       <EnforceExtendedAnalyzerRules>true</EnforceExtendedAnalyzerRules>
     </PropertyGroup>

     <ItemGroup>
       <PackageReference Include="Microsoft.CodeAnalysis.CSharp"
                         Version="4.12.0"
                         PrivateAssets="all" />
     </ItemGroup>

   </Project>
   ```

   Key settings:

   - **`netstandard2.0`**: Required because the compiler loads generators as .NET Standard 2.0 assemblies.
   - **`LangVersion latest`**: Lets you use modern C# features in the generator code itself.
   - **`EnforceExtendedAnalyzerRules`**: Enables extra compile-time checks that catch common source generator mistakes.
   - **`PrivateAssets="all"`**: Prevents the Roslyn package from flowing to consumers of the generator.

1. Delete the generated `Class1.cs` file:

   ```bash
   rm MySourceGenerator/Class1.cs
   ```

## Write the source generator

The generator has three responsibilities:

- Inject a marker attribute (`[HelloFrom]`) into the compilation.
- Find classes decorated with that attribute.
- Generate a `HelloFrom()` method for each matching class.

Create a file named `HelloFromGenerator.cs` in the `MySourceGenerator` folder and add the following code.

### Define the marker attribute

The generator injects its own marker attribute into the consuming project. This technique avoids requiring consumers to reference a separate shared library just for the attribute definition.

Add the attribute source as a constant string in the generator class:

:::code language="csharp" source="./snippets/incremental-source-generator-tutorial/csharp/MySourceGenerator/HelloFromGenerator.cs" id="AttributeSource":::

### Implement the Initialize method

The `Initialize` method defines the incremental pipeline. It runs once when the compiler loads the generator.

:::code language="csharp" source="./snippets/incremental-source-generator-tutorial/csharp/MySourceGenerator/HelloFromGenerator.cs" id="Initialize":::

The pipeline has three parts:

1. **`RegisterPostInitializationOutput`** injects the `HelloFromAttribute` into the compilation so consumers can reference it without an extra assembly.
1. **`CreateSyntaxProvider`** defines a two-stage filter. The `predicate` does a fast syntactic check, and the `transform` uses the semantic model for precise matching.
1. **`RegisterSourceOutput`** wires up the code generation step.

### Add the syntactic predicate

The predicate runs on every syntax node during compilation, so it needs to be fast. Check only whether the node is a class declaration with at least one attribute:

:::code language="csharp" source="./snippets/incremental-source-generator-tutorial/csharp/MySourceGenerator/HelloFromGenerator.cs" id="Predicate":::

This check is intentionally broad. It narrows the search cheaply—the transform stage handles the precise matching.

### Add the semantic transform

The transform stage receives nodes that passed the predicate. Use the semantic model to verify that the attribute is truly `HelloFromAttribute`:

:::code language="csharp" source="./snippets/incremental-source-generator-tutorial/csharp/MySourceGenerator/HelloFromGenerator.cs" id="Transform":::

This method loops through every attribute on the class and checks its fully qualified name against the semantic model. If none match, it returns `null`, and the `Where` clause in the pipeline filters it out.

### Add the code generation step

The `Execute` method receives the full compilation and the filtered list of class declarations. It generates a `partial class` with a `HelloFrom()` method for each match:

:::code language="csharp" source="./snippets/incremental-source-generator-tutorial/csharp/MySourceGenerator/HelloFromGenerator.cs" id="Execute":::

Key points:

- The generator checks `IsGlobalNamespace` to handle classes declared without a namespace.
- Each generated file uses a unique hint name (`{ClassName}.HelloFrom.g.cs`) to avoid conflicts.
- Generated code is wrapped in the same namespace as the user's class so the `partial` declaration merges correctly.

### Build the generator

Build the project to verify there are no errors:

```bash
dotnet build MySourceGenerator
```

## Create the consuming application

Now create a console application that uses the generator.

1. From the `SourceGeneratorDemo` folder, create a console application:

   ```bash
   dotnet new console -n MyApp
   ```

1. Replace the contents of `MyApp/MyApp.csproj` with the following:

   ```xml
   <Project Sdk="Microsoft.NET.Sdk">

     <PropertyGroup>
       <OutputType>Exe</OutputType>
       <TargetFramework>net9.0</TargetFramework>
       <ImplicitUsings>enable</ImplicitUsings>
       <Nullable>enable</Nullable>
     </PropertyGroup>

     <ItemGroup>
       <ProjectReference Include="../MySourceGenerator/MySourceGenerator.csproj"
                         OutputItemType="Analyzer"
                         ReferenceOutputAssembly="false" />
     </ItemGroup>

   </Project>
   ```

   The `ProjectReference` uses `OutputItemType="Analyzer"` to tell the compiler to load `MySourceGenerator` as a source generator. The `ReferenceOutputAssembly="false"` attribute prevents the consuming project from referencing the generator's types at runtime.

1. Create a file named `Greeter.cs` in the `MyApp` folder:

   :::code language="csharp" source="./snippets/incremental-source-generator-tutorial/csharp/MyApp/Greeter.cs" id="Greeter":::

   The class is marked `partial` so the compiler can merge it with the generated `partial class` that contains the `HelloFrom()` method.

1. Replace the contents of `MyApp/Program.cs`:

   :::code language="csharp" source="./snippets/incremental-source-generator-tutorial/csharp/MyApp/Program.cs" id="Program":::

## Run the application

Run the application from the `SourceGeneratorDemo` folder:

```bash
dotnet run --project MyApp
```

The output is:

```output
Hello from 'Greeter'
```

The `HelloFrom()` method doesn't exist in your source code—the source generator created it at compile time.

## Explore the generated code

To see the generated files, add the following property to `MyApp.csproj` inside the `<PropertyGroup>`:

```xml
<EmitCompilerGeneratedFiles>true</EmitCompilerGeneratedFiles>
```

Build the project again, and look in the `obj/Debug/net9.0/generated/` folder. You'll find:

- `HelloFromAttribute.g.cs`: The marker attribute injected by `RegisterPostInitializationOutput`.
- `Greeter.HelloFrom.g.cs`: The generated partial class with the `HelloFrom()` method.

## How the pipeline works

Understanding the incremental pipeline helps you write efficient generators:

1. **Predicate runs on every node.** The compiler calls `IsCandidateClass` on every syntax node in the compilation. Because it only checks `AttributeLists.Count > 0`, this step is fast.
1. **Transform runs on candidates.** `GetSemanticTarget` runs only on nodes that passed the predicate. It uses the semantic model—a more expensive operation—but runs on a much smaller set of nodes.
1. **Caching eliminates redundant work.** The compiler caches results at each stage. If a file that doesn't contain `[HelloFrom]` changes, the generator doesn't rerun the `Execute` step.
1. **Output runs only when inputs change.** The `Execute` method runs only when the list of matching classes changes, or when the compilation itself changes.

## Next steps

Here are some ideas for extending this generator:

- Generate additional members (properties, methods) based on attribute arguments.
- Use `ForAttributeWithMetadataName` for a more concise attribute filter (available in `Microsoft.CodeAnalysis` 4.3.1 and later).
- Add diagnostic reporting with `SourceProductionContext.ReportDiagnostic` for error cases.
- Read additional configuration from `.editorconfig` or MSBuild properties via `AnalyzerConfigOptionsProvider`.

For more information, see:

- [Source generators overview](../source-generators-overview.md)
- [Roslyn incremental generators specification](https://github.com/dotnet/roslyn/blob/main/docs/features/incremental-generators.md)
- [Tutorial: Write your first analyzer and code fix](how-to-write-csharp-analyzer-code-fix.md)
