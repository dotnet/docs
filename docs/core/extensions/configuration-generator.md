---
title: Compile-time configuration source generation
description: Learn how to use the configuration source generator to intercept specific call sites and bypass reflection-based configuration binding.
author: IEvangelist
ms.author: dapine
ms.date: 10/09/2024
---

# Configuration source generator

Starting with .NET 8, a configuration binding source generator was introduced that intercepts specific call sites and generates their functionality. This feature provides a [Native ahead-of-time (AOT)](../deploying/native-aot/index.md) and [trim-friendly](../deploying/trimming/trim-self-contained.md) way to use the [configuration binder](configuration.md#binding), without the use of the reflection-based implementation. Reflection requires dynamic code generation, which isn't supported in AOT scenarios.

This feature is possible with the advent of [C# interceptors](/dotnet/csharp/whats-new/csharp-12#interceptors) that were introduced in C# 12. Interceptors allow the compiler to generate source code that intercepts specific calls and substitutes them with generated code.

## Enable the configuration source generator

To enable the configuration source generator, add the following property to your project file:

```xml
<PropertyGroup>
    <EnableConfigurationBindingGenerator>true</EnableConfigurationBindingGenerator>
</PropertyGroup>
```

When the configuration source generator is enabled, the compiler generates a source file that contains the configuration binding code. The generated source intercepts binding APIs from the following classes:

- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder?displayProperty=fullName>
- <xref:Microsoft.Extensions.DependencyInjection.OptionsBuilderConfigurationExtensions?displayProperty=fullName>
- <xref:Microsoft.Extensions.DependencyInjection.OptionsConfigurationServiceCollectionExtensions?displayProperty=nameWithType>

In other words, all APIs that eventually call into these various binding methods are intercepted and replaced with generated code.

## Example usage

Consider a .NET console application configured to publish as a native AOT app. The following code demonstrates how to use the configuration source generator to bind configuration settings:

:::code language="xml" source="snippets/configuration/console-binder-gen/console-binder-gen.csproj" highlight="9,11":::

The preceding project file enables the configuration source generator by setting the `EnableConfigurationBindingGenerator` property to `true`.

Next, consider a _Program.cs_ file:

:::code source="snippets/configuration/console-binder-gen/Program.cs" highlight="12-14":::

The preceding code:

- Instantiates a configuration builder instance.
- Calls <xref:Microsoft.Extensions.Configuration.MemoryConfigurationBuilderExtensions.AddInMemoryCollection%2A> and defines three configuration source values.
- Calls <xref:Microsoft.Extensions.Configuration.IConfigurationBuilder.Build> to build the configuration.
- Uses the <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.GetValue%2A?displayProperty=nameWithType> extension method to get the value for each configuration key.

When the application is built, the configuration source generator intercepts the call to `GetValue<T>` and generates the binding code.

> [!IMPORTANT]
> If the `PublishAot` property is set to `true` and the `EnabledConfigurationBindingGenerator` property is set to `false`, warning `IL2026` is raised. This warning indicates that members are attributed with [RequiresUnreferencedCode](xref:System.Diagnostics.CodeAnalysis.RequiresUnreferencedCodeAttribute) may break when trimming. For more information, see [IL2026](/dotnet/core/deploying/trimming/trim-warnings/il2026).

## See also

- [Roslyn: Interceptors feature](https://github.com/dotnet/roslyn/blob/main/docs/features/interceptors.md)
