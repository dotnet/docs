---
title: Source Generators
description: Source Generators is a C# compiler feature that lets C# developers inspect user code as it is being compiled and generates new C# source files on the fly that are added to the user's compilation.
ms.date: 06/11/2021
ms.topic: tutorial
ms.custom: mvc, vs-dotnet, source-generators
---
# Source Generators

This article provides an overview of Source Generators that ships as part of the .NET Compiler Platform ("Roslyn") SDK. Source Generators is a C# compiler feature that lets C# developers inspect user code as it is being compiled and generates new C# source files on the fly that are added to the user's compilation.

A Source Generator is a piece of code that runs during compilation and can inspect your program to produce additional source files that are compiled together with the rest of your code.

A Source Generator is a new kind of component that C# developers can write that lets you do two major things:

1. Retrieve a *compilation object* that represents all user code that is being compiled. This object can be inspected, and you can write code that works with the syntax and semantic models for the code being compiled, just like with analyzers today.

2. Generate C# source files that can be added to a compilation object during the course of compilation. In other words, you can provide additional source code as input to a compilation while the code is being compiled.

When combined, these two things are what make Source Generators so useful. You can inspect user code with all of the rich metadata that the compiler builds up during compilation, then emit C# code back into the same compilation that is based on the data you've analyzed! If you're familiar with Roslyn Analyzers, you can think of Source Generators as analyzers that can emit C# source code.

Source generators run as a phase of compilation visualized below:

:::image type="content" source="media/source-generators/source-generator-visualization.png" alt-text="Graphic describing the different parts of source generation":::

A Source Generator is a .NET Standard 2.0 assembly that is loaded by the compiler along with any analyzers. It is usable in environments where .NET Standard components can be loaded and run.

## Common scenarios

Today, there are three general approaches to inspecting user code and generating information or code based on that analysis used by technologies today: runtime reflection, IL weaving, and juggling MSBuild tasks. Source Generators can be an improvement over each approach.
Runtime reflection is a powerful technology that was added to .NET a long time ago. There are countless scenarios for using it. A very common scenario is to perform some analysis of user code when an app starts up and use that data to generate things.

For example, ASP.NET Core uses reflection when your web service first runs to discover constructs you’ve defined so that it can “wire up” things like controllers and razor pages. Although this enables you to write straightforward code with powerful abstractions, it comes with a performance penalty at runtime: when your web service or app first starts up, it cannot accept any requests until all the runtime reflection code that discovers information about your code is finished running! Although this performance penalty is not enormous, it is somewhat of a fixed cost that you cannot improve yourself in your own app.

With a Source Generator, the controller discovery phase of startup could instead happen at compile time by analyzing your source code and emitting the code it needs to "wire up" your app. This could result in some faster startup times, since an action happening at runtime today could get pushed into compile time.
Source Generators can improve performance in ways that aren’t limited to reflection at runtime to discover types as well. Some scenarios involve calling the MSBuild C# task (called CSC) multiple times so they can inspect data from a compilation. As you might imagine, calling the compiler more than once affects the total time it takes to build your app! We’re investigating how Source Generators can be used to obviate the need for juggling MSBuild tasks like this, since Source generators don’t just offer some performance benefits, but also allows tools to operate at the right level of abstraction.

Another capability Source Generators can offer is obviating the use of some “stringly-typed” APIs, such as how ASP.NET Core routing between controllers and razor pages work. With a Source Generator, routing can be strongly typed with the necessary strings being generated as a compile-time detail. This would reduce the amount of times a mistyped string literal leads to a request not hitting the correct controller.

## Get started with source generators

In this guide, you'll explore the creation of a source generator using the <xref:Microsoft.CodeAnalysis.ISourceGenerator> API.

1. Create a .NET console application.

2. Replace the Program class with the following:

    ```csharp
    partial class Program
    {
        static void Main(string[] args)
        {
            HelloFrom("Generated Code");
        }

        static partial void HelloFrom(string name);
    }
    ```

    > [!NOTE]
    > You can run this sample as-is, but nothing will happen yet.

3. Next, we'll create a source generator that will fill in the contents of the `HelloFrom` method.

4. Create a .NET standard library project that looks like this:

    ```xml
    <Project Sdk="Microsoft.NET.Sdk">

      <PropertyGroup>
        <TargetFramework>netstandard2.0</TargetFramework>
      </PropertyGroup>

      <ItemGroup>
        <PackageReference Include="Microsoft.CodeAnalysis.CSharp" Version="3.9.0" PrivateAssets="all" />
        <PackageReference Include="Microsoft.CodeAnalysis.Analyzers" Version="3.0.0" PrivateAssets="all" />
      </ItemGroup>

    </Project>
    ```

5. Modify or create a C# file that specifies your own Source Generator like so:

    ```csharp
    using Microsoft.CodeAnalysis;

    namespace MyGenerator
    {
        [Generator]
        public class MySourceGenerator : ISourceGenerator
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

6. Replace the contents of the `Execute` method, so that it looks like the following:

    ```csharp
    public void Execute(GeneratorExecutionContext context)
    {
        // find the main method
        var mainMethod = context.Compilation.GetEntryPoint(context.CancellationToken);

        // build up the source code
        string source = $@"
    using System;

    namespace {mainMethod.ContainingNamespace.Name}
    {{
        public static partial class {mainMethod.ContainingType.Name}
        {{
            static partial void HelloFrom(string name)
            {{
                Console.WriteLine($""Generator says: Hi from '{{name}}'"");
            }}
        }}
    }}
    ";
        // add the source code to the compilation
        context.AddSource("generatedSource", source);
    }
    ```

7. We now have a functioning generator, but need to connect it to our console application. Edit the original console application project and add the following, replacing the project path with the one from the .NET Standard project you created above:

    ```xml
      <!-- Add this as a new ItemGroup, replacing paths and names appropriately -->
      <ItemGroup>
        <!-- Note that this is not a "normal" ProjectReference.
             It needs the additional 'OutputItemType' and 'ReferenceOutputAssembly' attributes. -->
        <ProjectReference Include="path-to-sourcegenerator-project.csproj"
                          OutputItemType="Analyzer"
                          ReferenceOutputAssembly="false" />
      </ItemGroup>
    ```

8. Now, when you run the console application, you should see that the generated code gets run and prints to the screen.

    > [!NOTE]
    > You will currently need to restart Visual Studio to see IntelliSense and get rid of errors with the early tooling experience.

## Next steps

The [Source Generators Cookbook](https://github.com/dotnet/roslyn/blob/main/docs/features/source-generators.cookbook.md) goes over some of these examples with some recommended approaches to solving them. Additionally, we have a [set of samples available on GitHub](https://github.com/dotnet/roslyn-sdk/tree/main/samples/CSharp/SourceGenerators) that you can try on your own.

You can learn more about Source Generators in these topics:

- [Source Generators design document](https://github.com/dotnet/roslyn/blob/main/docs/features/source-generators.md)
- [Source Generators cookbook](https://github.com/dotnet/roslyn/blob/main/docs/features/source-generators.cookbook.md)
