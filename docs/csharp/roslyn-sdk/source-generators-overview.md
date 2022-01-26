---
title: Source Generators
description: Source Generators is a C# compiler feature that lets C# developers inspect user code as it is being compiled and generates new C# source files on the fly that are added to the user's compilation.
ms.date: 12/15/2021
ms.topic: tutorial
ms.custom: mvc, vs-dotnet, source-generators
---

# Source Generators

This article provides an overview of Source Generators that ships as part of the .NET Compiler Platform ("Roslyn") SDK. Source Generators are a C# compiler feature that lets C# developers inspect user code as it is being compiled and generate new C# source files on the fly that are added to the user's compilation. In this way, you can have code that runs during compilation and inspects your program to produce additional source files that are compiled together with the rest of your code.

A Source Generator is a new kind of component that C# developers can write that lets you do two major things:

1. Retrieve a *compilation object* that represents all user code that is being compiled. This object can be inspected, and you can write code that works with the syntax and semantic models for the code being compiled, just like with analyzers today.

1. Generate C# source files that can be added to a compilation object during the course of compilation. In other words, you can provide additional source code as input to a compilation while the code is being compiled.

When combined, these two things are what make Source Generators so useful. You can inspect user code with all of the rich metadata that the compiler builds up during compilation, then emit C# code back into the same compilation that is based on the data you've analyzed. If you're familiar with Roslyn Analyzers, you can think of Source Generators as analyzers that can emit C# source code.

Source generators run as a phase of compilation visualized below:

:::image type="content" source="media/source-generators/source-generator-visualization.png" lightbox="media/source-generators/source-generator-visualization.png" alt-text="Graphic describing the different parts of source generation":::

A Source Generator is a .NET Standard 2.0 assembly that is loaded by the compiler along with any analyzers. It is usable in environments where .NET Standard components can be loaded and run.

> [!IMPORTANT]
> Currently only .NET Standard 2.0 assemblies can be used as Source Generators.

## Common scenarios

There are three general approaches to inspecting user code and generating information or code based on that analysis used by technologies today:

- Runtime reflection.
- Juggling MSBuild tasks.
- Intermediate Language (IL) weaving (not discussed in this article).

Source Generators can be an improvement over each approach.

### Runtime reflection

Runtime reflection is a powerful technology that was added to .NET a long time ago. There are countless scenarios for using it. A very common scenario is to perform some analysis of user code when an app starts up and use that data to generate things.

For example, ASP.NET Core uses reflection when your web service first runs to discover constructs you've defined so that it can "wire up" things like controllers and razor pages. Although this enables you to write straightforward code with powerful abstractions, it comes with a performance penalty at run time: when your web service or app first starts up, it cannot accept any requests until all the runtime reflection code that discovers information about your code is finished running. Although this performance penalty is not enormous, it is somewhat of a fixed cost that you cannot improve yourself in your own app.

With a Source Generator, the controller discovery phase of startup could instead happen at compile time by analyzing your source code and emitting the code it needs to "wire up" your app. This could result in some faster startup times, since an action happening at run time today could get pushed into compile time.

### Juggling MSBuild tasks

Source Generators can improve performance in ways that aren't limited to reflection at run time to discover types as well. Some scenarios involve calling the MSBuild C# task (called CSC) multiple times so they can inspect data from a compilation. As you might imagine, calling the compiler more than once affects the total time it takes to build your app. We're investigating how Source Generators can be used to obviate the need for juggling MSBuild tasks like this, since Source generators don't just offer some performance benefits, but also allows tools to operate at the right level of abstraction.

Another capability Source Generators can offer is obviating the use of some "stringly-typed" APIs, such as how ASP.NET Core routing between controllers and razor pages work. With a Source Generator, routing can be strongly typed with the necessary strings being generated as a compile-time detail. This would reduce the amount of times a mistyped string literal leads to a request not hitting the correct controller.

## Get started with source generators

In this guide, you'll explore the creation of a source generator using the <xref:Microsoft.CodeAnalysis.ISourceGenerator> API.

1. Create a .NET console application. This example uses .NET 6.

1. Replace the `Program` class with the following:

    :::code source="snippets/source-generators/ConsoleApp/Program.cs":::

    > [!NOTE]
    > You can run this sample as-is, but nothing will happen yet.

1. Next, we'll create a source generator project that will implement the `partial void HelloFrom` method counterpart.

1. Create a .NET standard library project that targets the `netstandard2.0` target framework moniker (TFM):

    :::code language="xml" source="snippets/source-generators/SourceGenerator/SourceGenerator.csproj":::

    > [!TIP]
    > The source generator project needs to target the `netstandard2.0` TFM, otherwise it will not work.

1. Create a new C# file named _HelloSourceGenerator.cs_ that specifies your own Source Generator like so:

    ```csharp
    using Microsoft.CodeAnalysis;

    namespace SourceGenerator
    {
        [Generator]
        public class HelloSourceGenerator : ISourceGenerator
        {
            public void Execute(GeneratorExecutionContext context)
            {
                // Code generation goes here
            }

            public void Initialize(GeneratorInitializationContext context)
            {
                // No initialization required for this one
            }
        }
    }
    ```

    A source generator needs to both implement the <xref:Microsoft.CodeAnalysis.ISourceGenerator?displayProperty=nameWithType> interface, and have the <xref:Microsoft.CodeAnalysis.GeneratorAttribute?displayProperty=nameWithType>. Not all source generators require initialization, and that is the case with this example implemenation &mdash; where <xref:Microsoft.CodeAnalysis.ISourceGenerator.Initialize%2A?displayProperty=nameWithType> is empty.

1. Replace the contents of the <xref:Microsoft.CodeAnalysis.ISourceGenerator.Execute%2A?displayProperty=nameWithType> method, with the following implementation:

    :::code source="snippets/source-generators/SourceGenerator/HelloSourceGenerator.cs":::

    From the `context` object we can access the compilations' entry point, or `Main` method. The `mainMethod` instance is an <xref:Microsoft.CodeAnalysis.IMethodSymbol>, and it represents a method or method-like symbol (including constructor, destructor, operator, or property/event accessor). From this object we can reason about the containing namespace (if one is present) and the type. The `source` in this example is an interpolated string that templates the source code to be generated, where the interpolated wholes are filled with the containing namespace and type information. The `source` is added to the `context` with a hint name.

    > [!TIP]
    > The `hintName` parameter from the <xref:Microsoft.CodeAnalysis.GeneratorExecutionContext.AddSource%2A?displayProperty=nameWithType> method can be any unique name. It's common to provide an explicit C# file extension such as `".g.cs"` or `".generated.cs"` for the name. The file name helps identify the file as being source generated.

1. We now have a functioning generator, but need to connect it to our console application. Edit the original console application project and add the following, replacing the project path with the one from the .NET Standard project you created above:

    ```xml
    <!-- Add this as a new ItemGroup, replacing paths and names appropriately -->
    <ItemGroup>
        <ProjectReference Include="..\PathTo\SourceGenerator.csproj"
                          OutputItemType="Analyzer"
                          ReferenceOutputAssembly="false" />
    </ItemGroup>
    ```

    This is not a traditional project reference, and has to be manually edited to include the `OutputItemType` and `ReferenceOutputAssembly` attributes. For additional information on the `OutputItemType` and `ReferenceOutputAssembly` attributes of `ProjectReference`, see [Common MSBuild project items: ProjectReference](/visualstudio/msbuild/common-msbuild-project-items#projectreference).

1. Now, when you run the console application, you should see that the generated code gets run and prints to the screen. The console application itself doesn't implement the `HelloFrom` method, instead it is source generated during compilation from the Source Generator project. The following is an example output from the application:

    ```console
    Generator says: Hi from 'Generated Code'
    ```

    > [!NOTE]
    > You might need to restart Visual Studio to see IntelliSense and get rid of errors as the tooling experience is actively being improved.

1. If you're using Visual Studio, you can see the source generated files. From the **Solution Explorer** window expand the **Dependencies** > **Analyzers** > **SourceGenerator** > **SourceGenerator.HelloSourceGenerator**, and double-click the _Program.g.cs_ file.

    :::image type="content" source="media/source-generators/solution-explorer-program.png" lightbox="media/source-generators/solution-explorer-program.png" alt-text="Visual Studio: Solution Explorer source generated files.":::

    When you open this generated file, Visual Studio will indicate that the file is auto-generated and that it cannot be edited.

    :::image type="content" source="media/source-generators/source-generated-program.png" lightbox="media/source-generators/source-generated-program.png" alt-text="Visual Studio: Auto-generated Program.g.cs file.":::

## Next steps

The [Source Generators Cookbook](https://github.com/dotnet/roslyn/blob/main/docs/features/source-generators.cookbook.md) goes over some of these examples with some recommended approaches to solving them. Additionally, we have a [set of samples available on GitHub](https://github.com/dotnet/roslyn-sdk/tree/main/samples/CSharp/SourceGenerators) that you can try on your own.

You can learn more about Source Generators in these topics:

- [Source Generators design document](https://github.com/dotnet/roslyn/blob/main/docs/features/source-generators.md)
- [Source Generators cookbook](https://github.com/dotnet/roslyn/blob/main/docs/features/source-generators.cookbook.md)
