---
title: Prepare .NET libraries for trimming
description: Learn how to prepare .NET libraries for trimming.
author: sbomer
ms.author: svbomer
ms.date: 06/12/2023
---

# Prepare .NET libraries for trimming

The .NET SDK makes it possible to reduce the size of self-contained apps by [trimming](trim-self-contained.md). Trimming removes unused code from the app and its dependencies. Not all code is compatible with trimming. .NET provides trim analysis warnings to detect patterns that may break trimmed apps. This article:

* Describes how to prepare libraries for trimming.
* Provides recommendations for [resolving common trimming warnings](#resolve-trim-warnings).

## Prerequisites

[.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet) or later.

## Enable library trim warnings

Trim warnings in a library can be found with either of the following methods:

* Enabling project-specific trimming using the `IsTrimmable` property.
* Creating a trimming test app that uses all the APIs in the library, and enabling trimming for the test app.

We recommend using both approaches. Project-specific trimming is convenient and shows trim warnings for one project, but relies on the references being marked trim-compatible to see all warnings. Trimming a test app is more work, but shows all warnings.

### Enable project-specific trimming

### [.NET 6](#tab/net6)

To get the latest version of the analyzer with the most coverage, install the [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet) or later. Installing the .NET 8 SDK or later:

* Updates the tooling used to build an app or library and enable trim warnings.
* Doesn't require targeting the .NET 7 or later runtime.

Set `<IsTrimmable>true</IsTrimmable>` in the project file.

### [.NET 7+](#tab/net7plus)

Set `<IsTrimmable>true</IsTrimmable>` in the project file.

---

:::code language="xml" source="~/docs/core/deploying/trimming/snippets/MyLibrary/MyLibrary.csproj.xml" id="snippet" highlight="2":::

Setting `<IsTrimmable>true</IsTrimmable>` marks the assembly as "trimmable" and enables trim warnings. "trimmable" means the project:

* Is considered compatible with trimming.
* Shouldn't generate trim related warnings when building. When used in a trimmed app, the assembly has its unused members trimmed in the final output.

The `IsTrimmable` property defaults to `true` when configuring a project as AOT-compatible with `<IsAotCompatible>true</IsAotCompatible>`. For more information, see [AOT-compatibility analyzers](../native-aot/index.md#aot-compatibility-analyzers).

To generate trim warnings without marking the project as trim-compatible, use `<EnableTrimAnalyzer>true</EnableTrimAnalyzer>` rather than `<IsTrimmable>true</IsTrimmable>`.

### Show all warnings with test app

To show all analysis warnings for a library, the trimmer must analyze the implementation:

* Of the library.
* All dependencies the library uses.

When building and publishing a library:

* The implementations of the dependencies aren't available.
* The available reference assemblies don't have enough information for the trimmer to determine if they're compatible with trimming.

Because of the dependency limitations, a self-contained test app which uses the library and its dependencies must be created. The test app executable includes all the information the trimmer requires to issue warning on trim incompatibilities in:

* The library code.
* The code that the library references from its dependencies.

***Note:*** If the library has different behavior depending on the target framework, create a trimming test app for each of the target frameworks. For example, if the library uses [conditional compilation](/dotnet/csharp/language-reference/preprocessor-directives#conditional-compilation) such as `#if NET7_0` to change behavior.

To create the trimming test app:

* Create a separate console application project.
* Add a reference to the library.
* Modify the project similar to the project shown below using the following list:

### [.NET 6](#tab/net6)

* Set the `TrimmerDefaultAction` property to `link` with `<TrimmerDefaultAction>link</TrimmerDefaultAction>` n a `<PropertyGroup>` element.  <!-- only diff with .NET7+ -->
* Add `<PublishTrimmed>true</PublishTrimmed>`.
* Add a reference to the library project with `<ProjectReference Include="/Path/To/YourLibrary.csproj" />`.
* Specify the library as a trimmer root assembly with `<TrimmerRootAssembly Include="YourLibraryName" />`.
  * `TrimmerRootAssembly` ensures that every part of the library is analyzed. It tells the trimmer that this assembly is a "root,  ". A "root," assembly means the trimmer analyzes every call in the library, and traverses all code paths that originate from   that assembly. `TrimmerRootAssembly` is necessary in case the library has `[AssemblyMetadata("IsTrimmable", "True")]`.  A   project using `[AssemblyMetadata("IsTrimmable", "True")]` without  `TrimmerRootAssembly` removes the unused library without analyzing it.

### .csproj file

:::code language="xml" source="~/docs/core/deploying/trimming/snippets/MyTestLib6app/MyTestLib6app.csproj":::

### [.NET 7+](#tab/net7plus)

* Add `<PublishTrimmed>true</PublishTrimmed>`.
* Add a reference to the library project with `<ProjectReference Include="/Path/To/YourLibrary.csproj" />`.
* Specify the library as a trimmer root assembly with `<TrimmerRootAssembly Include="YourLibraryName" />`.
  * `TrimmerRootAssembly` ensures that every part of the library is analyzed. It tells the trimmer that this assembly is a "root". A "root" assembly means the trimmer analyzes every call in the library, and traverses all code paths that originate from that assembly. `TrimmerRootAssembly` is necessary in case the library has `[AssemblyMetadata("IsTrimmable", "True")]`.  A project using `[AssemblyMetadata("IsTrimmable", "True")]` without `TrimmerRootAssembly` removes the unused library without analyzing it.

### .csproj file

:::code language="xml" source="~/docs/core/deploying/trimming/snippets/MyLibrary/MyLibrary.csproj.xml" id="snippet_full":::

**Notes:**

* In the preceding project file, when using .NET 7, replace `<TargetFramework>net8.0</TargetFramework>` with `<TargetFramework>net7.0</TargetFramework>`.
* The `<TrimMode>full</TrimMode>` setting:

  * Is the [default for .NET 7 and higher](../../../core/compatibility/deployment/7.0/trim-all-assemblies.md).
  * Ensures that the trimmer only analyzes the parts of the library's dependencies that are used.
  * Tells the trimmer that any code that isn't part of a "root" can be trimmed if it's unused. Without this   option:
    * Warnings are issued originating from ***any*** part of a dependency that doesn't set `[AssemblyMetadata  ("IsTrimmable", "Tue")]`
    * The preceding warnings can be issued for code that is unused by the library.

---

Once the project file is updated, run `dotnet publish` with the target [runtime identifier (RID)](../../rid-catalog.md).

```dotnetcli
dotnet publish -c Release -r <RID>
```

Follow the preceding pattern for multiple libraries. To see trim analysis warnings for more than one library at a time, add them all to the same project as `ProjectReference` and `TrimmerRootAssembly` items. Adding all the libraries to the same project with `ProjectReference` and `TrimmerRootAssembly` items warns about dependencies if ***any*** of the root libraries use a trim-unfriendly API in a dependency. To see warnings that have to do with only a particular library, reference that library only.

***Note:*** The analysis results depend on the implementation details of the dependencies. Updating to a new version of a dependency may introduce analysis warnings:

* If the new version added non-understood reflection patterns.
* Even if there were no API changes.
* Introducing trim analysis warnings is a breaking change when the library is used with `PublishTrimmed`.

## Resolve trim warnings

The preceding steps produce warnings about code that may cause problems when used in a trimmed app. The following examples show the most common warnings with recommendations for fixing them.

### RequiresUnreferencedCode

Consider the following code that uses [`[RequiresUnreferencedCode]`](xref:System.Diagnostics.CodeAnalysis.RequiresUnreferencedCodeAttribute) to indicate that the specified method requires dynamic access to code that is not referenced statically, for example, through <xref:System.Reflection?displayProperty=fullName>.

:::code language="csharp" source="~/docs/core/deploying/trimming/snippets/MyLibrary/Class1.cs" id="snippet_1" highlight="12-13":::

The preceding highlighted code indicates the library calls a method that has explicitly been annotated as incompatible with trimming. To get rid of the warning, consider whether `MyMethod` needs to call `DynamicBehavior`. If so, annotate the caller `MyMethod` with `[RequiresUnreferencedCode]` which propagates up the call stack the warning so that callers of `MyMethod` get a warning instead:

:::code language="csharp" source="~/docs/core/deploying/trimming/snippets/MyLibrary/Class2.cs" id="snippet_RequiresUnreferencedCode" highlight="9-10":::

Once you have propagated up the attribute all the way to public API, apps calling the library:

* Get warnings only for public methods that aren't trimmable.
* Don't get warnings like `IL2104: Assembly 'MyLibrary' produced trim warnings`.

### DynamicallyAccessedMembers

:::code language="csharp" source="~/docs/core/deploying/trimming/snippets/MyLibrary/Class1.cs" id="snippet_DAA1":::

In the preceding code, `UseMethods` is calling a reflection method that has a [`[DynamicallyAccessedMembers]`](xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute) requirement. The requirement states that the type's public methods are available. Satisfy the requirement by adding the same requirement to the parameter of `UseMethods`.

:::code language="csharp" source="~/docs/core/deploying/trimming/snippets/MyLibrary/Class1.cs" id="snippet_DAA2":::

Now any calls to `UseMethods` produce warnings if they pass in values that don't satisfy the <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.PublicMethods> requirement. Similar to `[RequiresUnreferencedCode]`, once you have propagated up such warnings to public APIs, you're done.

In the following example, an unknown [Type](/dotnet/api/system.type) flows into the annotated method parameter. The unknown `Type` is from a field:

:::code language="csharp" source="~/docs/core/deploying/trimming/snippets/MyLibrary/Class1.cs" id="snippet_UMH":::

Similarly, here the problem is that the field `type` is passed into a parameter with these requirements. It's fixed by adding  [`[DynamicallyAccessedMembers]`](xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute) to the field. `[DynamicallyAccessedMembers]` warns about code that assigns incompatible values to the field. Sometimes this process continues until a public API is annotated, and other times it ends when a concrete type flows into a location with these requirements. For example:

:::code language="csharp" source="~/docs/core/deploying/trimming/snippets/MyLibrary/Class1.cs" id="snippet_UMH2" highlight="1":::

In this case, the trim analysis keeps public methods of <xref:System.Tuple>, and produces further warnings.

## Recommendations

* ***Avoid*** reflection when possible. When using reflection, minimize reflection scope so that it's reachable only from a small part of the library.
* Annotate code with `DynamicallyAccessedMembers` to statically express the trimming requirements statically when possible.
* Consider reorganizing code to make it follow an analyzable pattern that can be annotated with `DynamicallyAccessedMembers`
* When code is incompatible with trimming, annotate it with `RequiresUnreferencedCode` and propagate this annotation to callers until the relevant public APIs are annotated.
* Avoid using code that uses reflection in a way not understood by the static analysis. For example, reflection in static constructors should be avoided. Using reflection in static constructors result in the warning propagating to all members of the class.
* Avoid annotating virtual methods or interface methods. Annotating virtual or interface methods requires all overrides to have matching annotations.
* If an API is mostly trim-incompatible, alternative coding approaches to the API may need to be considered. A common example is reflection-based serializers. In these cases, consider adopting other technology like source generators to produce code that is more easily statically analyzed. For example, see [How to use source generation in System.Text.Json](/dotnet/standard/serialization/system-text-json/source-generation)

<!--
* When using reflection, minimize reflection scope so that it's reachable only from a small part of the library.
* Avoid using code that uses reflection in a way not understood by the static analysis. For example, reflection in static constructors should be avoided. Using reflection in static constructors result in the warning propagating to all members of the class.
* Avoid annotating virtual methods or interface methods. Annotating virtual or interface methods requires all overrides to have matching annotations.
* When code is incompatible with trimming, propagate `RequiresUnreferencedCode` annotations up the call chain until the relevant public API is annotated. In some cases, adding attributes up the call chain resolves the warnings. Sometimes this results in much of the public API being annotated with [`[RequiresUnreferencedCode]`](xref:System.Diagnostics.CodeAnalysis.RequiresUnreferencedCodeAttribute). Annotating with `[RequiresUnreferencedCode]` is the best approach if the library behaves in ways that can't be understood statically by the trim analysis.
* Code that uses patterns that can't be expressed in terms of the `DynamicallyAccessedMembers` attributes:
  * Consider reorganizing that code to make it follow an analyzable pattern. This also applies to code that only uses reflection to operate on statically known types.  For example, consider using a factory pattern instead of reflection.
* If an API is mostly trim-incompatible, alternative coding approaches to the API may need to be considered. A common example is reflection-based serializers. In these cases, consider adopting other technology like source generators to produce code that is more easily statically analyzed. For example, see [How to use source generation in System.Text.Json](/dotnet/standard/serialization/system-text-json/source-generation)
-->

## Resolve warnings for non-analyzable patterns

It's better to resolve warnings by expressing the intent of your code using `[RequiresUnreferencedCode]` and `DynamicallyAccessedMembers` when possible. However, in some cases, you may be interested in enabling trimming of a library that uses patterns that can't be expressed with those attributes, or without refactoring existing code. This section describes some advanced ways to resolve trim analysis warnings.

> [!WARNING]
> These techniques might change the behavior or your code or result in run time exceptions if used incorrectly.

### UnconditionalSuppressMessage

Consider code that:

* The intent can't be expressed with the annotations.
* Generates a warning but doesn't represent a real issue at run time.

The warnings can be suppressed <xref:System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessageAttribute>. This is similar to `SuppressMessageAttribute`, but it's persisted in IL and respected during trim analysis.

> [!WARNING]
> When suppressing warnings, you are responsible for guaranteeing the trim compatibility of the code based on invariants that you know to be true by inspection and testing. Use caution with these annotations, because if they are incorrect, or if invariants of your code change, they might end up hiding incorrect code.

For example:

:::code language="csharp" source="~/docs/core/deploying/trimming/snippets/MyLibrary/Class1.cs" id="snippet_AD1":::

In the preceding code, the indexer property has been annotated so that the returned `Type` meets the requirements of `CreateInstance`. This ensures that the `TypeWithConstructor` constructor is kept, and that the call to `CreateInstance` doesn't warn. The indexer setter annotation ensures that any types stored in the `Type[]` have a constructor. However, the analysis isn't able to see this and produces a warning for the getter, because it doesn't know that the returned type has its constructor preserved.

If you're sure that the requirements are met, you can silence this warning by adding [`[UnconditionalSuppressMessage]`](xref:System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessageAttribute) to the getter:

:::code language="csharp" source="~/docs/core/deploying/trimming/snippets/MyLibrary/Class1.cs" id="snippet_AD2" highlight="9-10":::

It's important to underline that it's only valid to suppress a warning if there are annotations or code that ensure the reflected-on members are visible targets of reflection. It isn't sufficient that the member was a target of a call, field or property access. It may appear to be the case sometimes but such code is bound to break eventually as more trimming optimizations are added. Properties, fields, and methods that aren't visible targets of reflection could be inlined, have their names removed, get moved to different types, or otherwise optimized in ways that break reflecting on them. When suppressing a warning, it's only permissible to reflect on targets that were visible targets of reflection to the trimming analyzer elsewhere.

:::code language="csharp" source="~/docs/core/deploying/trimming/snippets/MyLibrary/Class1.cs" id="snippet_AD3" highlight="":::

### DynamicDependency

The [`[DynamicDependency]`](xref:System.Diagnostics.CodeAnalysis.DynamicDependencyAttribute) attribute can be used to indicate that a member has a dynamic dependency on other members. This results in the referenced members being kept whenever the member with the attribute is kept, but doesn't silence warnings on its own. Unlike the other attributes, which inform the trim analysis about the reflection behavior of the code, `[DynamicDependency]` only keeps other members. This can be used together with [`[UnconditionalSuppressMessage]`](xref:System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessageAttribute) to fix some analysis warnings.

> [!WARNING]
> Use `[DynamicDependency]` attribute only as a last resort when the other approaches aren't viable. It is preferable to express the reflection behavior using [`[RequiresUnreferencedCode]`](xref:System.Diagnostics.CodeAnalysis.RequiresUnreferencedCodeAttribute) or [`[DynamicallyAccessedMembers]`](xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute):

:::code language="csharp" source="~/docs/core/deploying/trimming/snippets/MyLibrary/Class1.cs" id="snippet_AD4" highlight="1":::

Without `DynamicDependency`, trimming might remove `Helper` from `MyAssembly` or remove `MyAssembly` completely if it's not referenced elsewhere, producing a warning that indicates a possible failure at run time. The attribute ensures that `Helper` is kept.

The attribute specifies the members to keep via a `string` or via `DynamicallyAccessedMemberTypes`. The type and assembly are either implicit in the attribute context, or explicitly specified in the attribute (by `Type`, or by `string`s for the type and assembly name).

The type and member strings use a variation of the C# documentation comment ID string [format](/dotnet/csharp/language-reference/language-specification/documentation-comments#id-string-format), without the member prefix. The member string shouldn't include the name of the declaring type, and may omit parameters to keep all members of the specified name. Some examples of the format are shown in the following code:

:::code language="csharp" source="~/docs/core/deploying/trimming/snippets/MyLibrary/Class1.cs" id="snippet_AD5":::

The `[DynamicDependency]` attribute is designed to be used in cases where a method contains reflection patterns that can't be analyzed even with the help of `DynamicallyAccessedMembersAttribute`.
