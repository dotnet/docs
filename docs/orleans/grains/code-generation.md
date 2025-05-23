---
title: Code generation
description: Learn how to use code generation in .NET Orleans.
ms.date: 03/31/2025
ms.topic: conceptual
ms.service: orleans
zone_pivot_groups: orleans-version
---

# Orleans code generation

Before Orleans 7.0, source generation was more manual and required explicit developer intervention. Starting with Orleans 7.0, code generation is automatic and typically requires no intervention. However, cases still exist where influencing code generation might be desired, for example, to generate code for types not automatically generated or for types in another assembly.

## Enable code generation

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

Orleans generates C# source code for the app at build time. All projects, including the host, need the appropriate NuGet packages installed to enable code generation. The following packages are available:

- All clients should reference [Microsoft.Orleans.Client](https://nuget.org/packages/Microsoft.Orleans.Client).
- All silos (servers) should reference [Microsoft.Orleans.Server](https://nuget.org/packages/Microsoft.Orleans.Server).
- All other packages should reference [Microsoft.Orleans.Sdk](https://nuget.org/packages/Microsoft.Orleans.Sdk).

Use the <xref:Orleans.GenerateSerializerAttribute> to specify that the type is intended for serialization and that Orleans should generate serialization code for it. For more information, see [Use Orleans serialization](../host/configuration-guide/serialization.md#use-orleans-serialization).

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

The Orleans runtime uses generated code to ensure proper serialization of types used across the cluster and to generate boilerplate code. This boilerplate abstracts away implementation details of method dispatching, exception propagation, and other internal runtime concepts. Code generation can be performed either when building projects or when the application initializes.

:::zone-end

### Build-time code generation

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

At build time, Orleans generates code for all types marked with <xref:Orleans.GenerateSerializerAttribute>. If a type isn't marked with `GenerateSerializer`, Orleans won't serialize it.

If developing with F# or Visual Basic, code generation can also be used. For more information, see these samples:

- [Orleans F# sample app](/samples/dotnet/samples/orleans-fsharp-sample)
- [Orleans Visual Basic sample app](/samples/dotnet/samples/orleans-vb-sample)

These examples demonstrate using the <xref:Orleans.GenerateCodeForDeclaringAssemblyAttribute?displayProperty=nameWithType>, specifying types in the assembly for the source generator to inspect and generate source code.

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

The preferred method for code generation is at build time. Enable build-time code generation using one of the following packages:

- `Microsoft.Orleans.OrleansCodeGenerator.Build`: A package using Roslyn for code generation and .NET Reflection for analysis.
- `Microsoft.Orleans.CodeGenerator.MSBuild`: A newer code generation package leveraging Roslyn for both code generation and analysis. It doesn't load application binaries, avoiding issues caused by clashing dependency versions and differing target frameworks. This code generator also improves support for incremental builds, resulting in shorter build times.

Install one of these packages into all projects containing grains, grain interfaces, custom serializers, or types sent between grains. Installing a package injects a target into the project that generates code at build time.

Both packages (`Microsoft.Orleans.CodeGenerator.MSBuild` and `Microsoft.Orleans.OrleansCodeGenerator.Build`) only support C# projects. Support other languages either by using the `Microsoft.Orleans.OrleansCodeGenerator` package (described below) or by creating a C# project acting as the target for code generated from assemblies written in other languages.

Emit additional diagnostics at build time by specifying a value for `OrleansCodeGenLogLevel` in the target project's *.csproj* file. For example: `<OrleansCodeGenLogLevel>Trace</OrleansCodeGenLogLevel>`.

:::zone-end

### Initialization-time code generation

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

In Orleans 7+, nothing happens during initialization. Code generation occurs only at build time.

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

Code generation can be performed during initialization on the client and silo by installing the `Microsoft.Orleans.OrleansCodeGenerator` package and using the <xref:Orleans.Hosting.ApplicationPartManagerCodeGenExtensions.WithCodeGeneration%2A?displayProperty=nameWithType> extension method:

```csharp
builder.ConfigureApplicationParts(
    parts => parts
        .AddApplicationPart(typeof(IRuntimeCodeGenGrain).Assembly)
        .WithCodeGeneration());
```

In the preceding example, `builder` can be an instance of either <xref:Orleans.Hosting.ISiloHostBuilder> or <xref:Orleans.IClientBuilder>. Pass an optional <xref:Microsoft.Extensions.Logging.ILoggerFactory> instance to `WithCodeGeneration` to enable logging during code generation, for example:

```csharp
ILoggerFactory codeGenLoggerFactory = new LoggerFactory();
codeGenLoggerFactory.AddProvider(new ConsoleLoggerProvider());
    builder.ConfigureApplicationParts(
        parts => parts
            .AddApplicationPart(typeof(IRuntimeCodeGenGrain).Assembly)
            .WithCodeGeneration(codeGenLoggerFactory));
```

:::zone-end

## Influence code generation

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

When applying <xref:Orleans.GenerateSerializerAttribute> to a type, the <xref:Orleans.IdAttribute> can also be applied to uniquely identify the member. Likewise, an alias can be applied using the <xref:Orleans.AliasAttribute>. For more information on influencing code generation, see [Use Orleans serialization](../host/configuration-guide/serialization.md#use-orleans-serialization).

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

During code generation, the generation of code for a specific type can be influenced. Orleans automatically generates code for grain interfaces, grain classes, grain state, and types passed as arguments in grain methods. If a type doesn't fit these criteria, use the following methods to guide code generation further.

Adding <xref:System.SerializableAttribute> to a type instructs the code generator to generate a serializer for it.

Adding [`[assembly: GenerateSerializer(Type)]`](xref:Orleans.CodeGeneration.GenerateSerializerAttribute) to a project instructs the code generator to treat that type as serializable. It causes an error if a serializer cannot be generated for that type (e.g., because the type isn't accessible). This error halts the build if code generation is enabled. This attribute also allows generating code for specific types from another assembly.

[`[assembly: KnownType(Type)]`](xref:Orleans.CodeGeneration.KnownTypeAttribute) also instructs the code generator to include a specific type (which might be from a referenced assembly), but it doesn't cause an exception if the type is inaccessible.

### Generate serializers for all subtypes

Adding <xref:Orleans.CodeGeneration.KnownBaseTypeAttribute> to an interface or class instructs the code generator to generate serialization code for all types inheriting from or implementing that type.

### Generate code for all types in another assembly

Sometimes, generated code cannot be included in a particular assembly at build time. Examples include shared libraries not referencing Orleans, assemblies written in languages other than C#, and assemblies for which the source code isn't available. In these cases, place the generated code for those assemblies into a separate assembly referenced during initialization.

To enable this for an assembly:

1. Create a C# project.
2. Install the `Microsoft.Orleans.CodeGenerator.MSBuild` or `Microsoft.Orleans.OrleansCodeGenerator.Build` package.
3. Add a reference to the target assembly.
4. Add `[assembly: KnownAssembly("OtherAssembly")]` at the top level of a C# file.

The <xref:Orleans.CodeGeneration.KnownAssemblyAttribute> instructs the code generator to inspect the specified assembly and generate code for the types within it. This attribute can be used multiple times within a project.

Then, add the generated assembly to the client/silo during initialization:

```csharp
builder.ConfigureApplicationParts(
    parts => parts.AddApplicationPart("CodeGenAssembly"));
```

In the preceding example, `builder` can be an instance of either <xref:Orleans.Hosting.ISiloHostBuilder> or <xref:Orleans.IClientBuilder>.

`KnownAssemblyAttribute` has an optional property, <xref:Orleans.CodeGeneration.KnownAssemblyAttribute.TreatTypesAsSerializable>. Set this to `true` to instruct the code generator to act as though all types within that assembly are marked as serializable.

:::zone-end
