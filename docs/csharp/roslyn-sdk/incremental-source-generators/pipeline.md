---
title: Roslyn incremental source generator pipeline
description: Roslyn incremental generators use a pipeline approach. Learn how pipelines work and the specific steps available to the Roslyn incremental generator.
author: KathleenDollard
ms.author: kdollard
ms.date: 6/11/2022 
ms.topic: tutorial
---
# Incremental source generator pipeline

[[ @chsienki The spec shows RegisterExecutionPipeline. Is this an old form of pipeline registration? ]]

The Roslyn incremental source generator uses a pipeline. A pipeline is a set of functions where the output of each function is the input to the next function. This allows individual steps to be defined and combined for later execution. In many pipelines, including the Roslyn incremental source generator, the output of each function is a generic container allowing the infrastructure of the pipeline to be unaware of the contents within the container.

LINQ is an example of this type of pipeline where the container is an `IEnumerable<T1>` collection. The pipeline is created as a series of delegates passed to methods like `Where`. This LINQ pipeline is executed at a later time, and possibly executed multiple times, by iterating with `foreach` or calling a method like `ToList`. As you call methods of the LINQ pipeline like `Select` or `OfType`, a new `IEnumerable<T2>` container is returned. `T1` and `T2` may be of the same or different types.

There is a great deal of theoretical work around these types of containers within pipelines. You can explore this by searching for terms like "lambda calculus" or explore functional programming books, but you will not need a deeper understanding to create Roslyn incremental generators. You will only need to understand a few things: 

* The pipeline contains functions - delegates or lambda expressions.
* The pipeline does not execute until requested.
* The pipeline operates on a generic container.
* The pipeline does not need to know the contents of the containers, although the functions that make up the pipeline do.
* The pipeline can intervene after any step to provide features like cancellation and caching.

[[ @chsienki The spec refers to IValueProvider<T>, but I cannot find this interface. Is this now just a logical grouping of the ..Value.. and ..Values.. providers? (That is how I wrote this article) ]]

The incremental generator pipeline supports two container types: `IncrementalValueProvider<T>` and `IncrementalValuesProvider<T>`. Notice that the first is singular and the second plural of  `Value`. The operations to create these containers are [providers](#providers). The available [pipeline operations](#pipeline-operations) transform the containers, and the pipeline ends by creating source code using the `RegisterSourceOutput` method.

## Providers

The incremental generator pipeline is created in the generator's `Initialize` method. This is the only member of the `IIncrementalGenerator` interface. This method is passed a single parameter which is an `IncrementalGeneratorInitializationContext`.

 You get `IncrementalValueProvider<T>` and `IncrementalValuesProvider<T>` containers from the `IncrementalGeneratorInitializationContext`. The first allows creation of a specific syntax provider, and the others  are static properties on the context that are lazily created if you request them:

| Provider                        | Type                                                      |
|---------------------------------|-----------------------------------------------------------|
| `SyntaxValueProvider`           | *See text that follows this table*                                       |
| `CompilationProvider`           | `IncrementalValueProvider<Compilation>`                   |
| `AdditionalTextsProvider`       | `IncrementalValuesProvider<AdditionalText>`               |
| `AnalyzerConfigOptionsProvider` | `IncrementalValueProvider<AnalyzerConfigOptionsProvider>` |
| `MetadataReferencesProvider`    | `IncrementalValueProvider<MetadataReference>`             |
| `ParseOptionsProvider`          | `IncrementalValueProvider<ParseOptions>`                  |

[[ REVIEW; confirm the following with team ]]

The value providers for the properties (all of the above except the `SyntaxValueProvider`) contain instances of classes that cannot be cached. The next step for all of these should be to call [`Select`](#pipeline-operations) to extract the data you need into a model.
 
The `SyntaxValueProvider` contains a single method that allows your to create an `IncrementalValuesProvider` that returns a model based on two delegates. The signature is;

```csharp
public readonly struct SyntaxValueProvider
    {
        public IncrementalValuesProvider<T> CreateSyntaxProvider<TModel>(
            Func<SyntaxNode, CancellationToken, bool> predicate, 
            Func<GeneratorSyntaxContext, CancellationToken, TModel> transform);
    }
```

The first delegate is passed every `SyntaxNode` in the compilation and returns `true` if it should be considered further. Since this will be called a massive number of times, the test should be extremely fast, particularly when the `SyntaxNode` should be ignored.

The transform step is called for every `SyntaxNode` that matches the predicate. This step can use the `SemanticModel` of the `GeneratorSyntaxContext`. It can use this to access `IOperation` objects from the semantic model to perform common tasks such as finding the parameters of a method or the members of a class. Use this delegate to extract the information that you will need later in generation, rather than returning elements of the Roslyn syntactic tree or semantic model. This step can also do further filtering by returning `null` from the transform and then filtering the result. [Check out this tip to avoid a null-reference warning](tips.md#-wherenotnull--method).

Often the model created from the syntax value provider is ready for generation and further pipeline operations are not needed.

## Pipeline operations

For the properties of the `IncrementalGeneratorInitializationContext` (everything except the `SyntaxProvider`), classes instances are contained in the value provider and these instances cannot be cached. The next step of the pipeline when you use these properties should be to call `Select` to extract a model that can be cached.

Whether it is created from `SyntaxValueProvider.CreateSyntax` or via `Select`,  once the initial model is created,  you can further transform it. You might need to do this to summarize a collection of models, split a model into parts, or to combine two models.

As an example, you could combine information from a syntax provider with analyzer config options. To facilitate caching, separately create each model and then use `Combine` on the models.

As a more complex example, perhaps you want to create a single partial class that contains code for one or more attributed methods in the user's source. Extracting the syntax nodes for the attributed methods in the predicate of `SyntaxProvider.CreateSyntax` can be quite fast. As you process each node in the syntax provider's transform, accessing the class and adding information from it to the model would also be fast. But, now you have a model instance per method, where you need an model instance per class to create output. Using the `Collect` method you could create a single model with a collection containing one model per class where each class model had a collection of its methods. You could generate from this combined model, resulting in a single file that contains all of the generated partial classes. Alternatively, you could split the single model into individual class models using `SelectMany`, and then generate separate files.

The pipeline methods for incremental generators are extension methods on one or both of `IncrementalValueProvider<T>` and `IncrementalValuesProvider<T>`. This table abbreviates `IncrementalValueProvider` and `IncrementalValuesProvider` to make it easier to read:


| Method           | Input type                                 | Return type  | Comments                                       |
|------------------|--------------------------------------------|--------------|------------------------------------------------|
| Select           | `..Value..`                                | `..Value..`  |                                                |
| Select           | `..Values..`                               | `..Values..` |                                                |
| SelectMany       | `..Value..`                                | `..Values..` | @chsienki Why IEnumerable and  immutable array overloads here and not everywhere     |
| SelectMany       | `..Values..`                               | `..Values..` | IEnumerable and immutable array overloads           |
| Where            | `..Values..`                               | `..Values..` |                                                |
| Collect          | `..Values..`                               | `..Value..`  |                                                |
| Combine          | `..Value..`, `..Value..`                   | `..Value..`  |                                                |
| Combine          | `..Values..`, `..Value..                   | `..Values..` |                                                |
| WithComparer     | `..Value..`, `IEqualityComparer<TSource>`  | `..Value..`  |                                                |
| WithComparer     | `..Values..`, `IEqualityComparer<TSource>` | `..Values..` | Allows per transformation equality for caching |
| WithTrackingName | `..Values..`, `string`                     | `..Values..` |                                                |
| WithTrackingName | `..Value..`, `string`                      | `..Value..`  |                                                |


You can find out more about how these methods work in the [Incremental Generators spec](https://github.com/dotnet/roslyn/blob/main/docs/features/incremental-generators.md).

## Output

There are three methods to generate code: `RegisterSourceOutput`, `RegisterImplementationSourceOutput`, and `RegisterPostInitializationOutput`.

The pipeline ends when you generate code output using the `RegisterSourceOutput` method. There are two overloads of this method both of which take two parameters. One takes an `IncrementalValuesProvider` and a delegate that will create the output. The generator iterates over the `IncrementalValuesProvider` and calls the delegate for each member, passing a `SourceProductionContext` and the current member of the collection. Another overload of `RegisterSourceOutput` takes an `IncrementalValueProvider` and a delegate and supports generating code from for a single value.

The delegate passed to `RegisterSourceOutput` takes a `SourceProductionContext` and a single data model. Code in the delegate calls the `AddSource` method to add source code to the new compilation. This method has two parameters: the *hintname* and the new source code as a string. The *hintname* is the output filename.

Code in the delegate can also `ReportDiagnostic` to add diagnostics to the compilation.

If your output is complicated or includes an unbounded collection of data, check the `CancellationToken` on each iteration or before after slow operations to ensure you respond to cancellation.

`RegisterImplementationSourceOutput` is almost identical to `RegisterImplementationSourceOutput`, but also indicates that the source has no semantic impact. You can use this if the code you generate does not impact the IDE, such as providing IntelliSense entries or diagnostics like errors or warnings.

`RegisterPostInitializationOutput` allows you to output code that needs no inputs. This is useful for adding code that should always be in the user's compilation. This is especially useful for attributes and base classes. Although, also see the tip on [whether to user `RegisterPostInitializationOutput` or a separate runtime library](tips.md#attributes-in-registerpostinitializationoutput-or-a-separate-package)