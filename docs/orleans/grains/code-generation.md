---
title: Code generation
description: Learn how to use code generation in .NET Orleans.
ms.date: 03/16/2022
---

# Orleans code generation

This article applies to: ✔️ Orleans 3.x and earlier versions

## Enable code generation

The Orleans runtime makes use of generated code to ensure proper serialization of types that are used across the cluster as well as for generating boilerplate, which abstracts away the implementation details of method shipping, exception propagation, and other internal runtime concepts. Code generation can be performed either when your projects are being built or when your application initializes.

### What happens during build?

The preferred method for performing code generation is at build time. Build time code generation could be enabled by using one of the following packages:

+ [Microsoft.Orleans.OrleansCodeGenerator.Build](https://www.nuget.org/packages/Microsoft.Orleans.OrleansCodeGenerator.Build/). A package that uses Roslyn for code generation and uses .NET Reflection for analysis.
+ [Microsoft.Orleans.CodeGenerator.MSBuild](https://www.nuget.org/packages/Microsoft.Orleans.CodeGenerator.MSBuild/). A new code generation package that leverages Roslyn both for code generation and code analysis. It does not load application binaries, and as a result, avoids issues caused by clashing dependency versions and differing target frameworks. The new code generator also improves support for incremental builds, which should result in shorter build times.

One of these packages should be installed into all projects which contain grains, grain interfaces, custom serializers, or types that are sent between grains. Installing a package injects a target into the project which will generate code at build time.

Both packages (`Microsoft.Orleans.CodeGenerator.MSBuild` and `Microsoft.Orleans.OrleansCodeGenerator.Build`) only support C# projects. Other languages are supported either using the `Microsoft.Orleans.OrleansCodeGenerator` package described below, or by creating a C# project which can act as the target for code generated from assemblies written in other languages.

Additional diagnostics can be emitted at build time by specifying a value for `OrleansCodeGenLogLevel` in the target project's *.csproj* file. For example, `<OrleansCodeGenLogLevel>Trace</OrleansCodeGenLogLevel>`.

### What happens during initialization?

Code generation can be performed during initialization on the client and silo by installing the `Microsoft.Orleans.OrleansCodeGenerator` package and using the <xref:Orleans.Hosting.ApplicationPartManagerCodeGenExtensions.WithCodeGeneration%2A?displayProperty=nameWithType> extension method:

```csharp
builder.ConfigureApplicationParts(
    parts => parts
        .AddApplicationPart(typeof(IRuntimeCodeGenGrain).Assembly)
        .WithCodeGeneration());
```

In the foregoing example, `builder` may be an instance of either <xref:Orleans.Hosting.ISiloHostBuilder> or <xref:Orleans.IClientBuilder>.
An optional <xref:Microsoft.Extensions.Logging.ILoggerFactory> instance can be passed to `WithCodeGeneration` to enable logging during code generation, for example:

```csharp
ILoggerFactory codeGenLoggerFactory = new LoggerFactory();
codeGenLoggerFactory.AddProvider(new ConsoleLoggerProvider());
    builder.ConfigureApplicationParts(
        parts => parts
            .AddApplicationPart(typeof(IRuntimeCodeGenGrain).Assembly)
            .WithCodeGeneration(codeGenLoggerFactory));
```

## Influence code generation

During code generation, you can influence generating code for a specific type. Code is automatically generated for grain interfaces, grain classes, grain state, and types passed as arguments in grain methods. If a type does not fit these criteria, the following methods can be used to further guide code generation.

Adding <xref:System.SerializableAttribute> to a type instructs the code generator to generate a serializer for that type.

Adding [`[assembly: GenerateSerializer(Type)]`](xref:Orleans.CodeGeneration.GenerateSerializerAttribute) to a project instructs the code generator to treat that type as serializable and will cause an error if a serializer could not be generated for that type, for example, because the type is not accessible. This error will halt a build if code generation is enabled. This attribute also allows generating code for specific types from another assembly.

[`[assembly: KnownType(Type)]`](xref:Orleans.CodeGeneration.KnownTypeAttribute) also instructs the code generator to include a specific type (which may be from a referenced assembly), but does not cause an exception if the type is inaccessible.

### Generate serializers for all subtypes

Adding <xref:Orleans.CodeGeneration.KnownBaseTypeAttribute> to an interface or class instructs the code generator to generate serialization code for all types which inherit/implement that type.

### Generate code for all types in another assembly

There are cases where generated code cannot be included in a particular assembly at build time. For example, this can include shared libraries that do not reference Orleans, assemblies written in languages other than C#, and assemblies in which the developer does not have the source code. In these cases, generated code for those assemblies can be placed into a separate assembly which is referenced during initialization.

To enable this for an assembly:

1. Create a C# project.
1. Install the `Microsoft.Orleans.CodeGenerator.MSBuild` or the `Microsoft.Orleans.OrleansCodeGenerator.Build` package.
1. Add a reference to the target assembly.
1. Add `[assembly: KnownAssembly("OtherAssembly")]` at the top level of a C# file.

The <xref:Orleans.CodeGeneration.KnownAssemblyAttribute> instructs the code generator to inspect the specified assembly and generate code for the types within it. The attribute can be used multiple times within a project.

The generated assembly must then be added to the client/silo during initialization:

```csharp
builder.ConfigureApplicationParts(
    parts => parts.AddApplicationPart("CodeGenAssembly"));
```

In the foregoing example, `builder` may be an instance of either <xref:Orleans.Hosting.ISiloHostBuilder> or <xref:Orleans.IClientBuilder>.

`KnownAssemblyAttribute` has an optional property, <xref:Orleans.CodeGeneration.KnownAssemblyAttribute.TreatTypesAsSerializable>, which can be set to `true` to instruct the code generator to act as though all types within that assembly are marked as serializable.
