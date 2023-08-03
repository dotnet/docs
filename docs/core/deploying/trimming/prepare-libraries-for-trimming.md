---
title: Prepare .NET libraries for trimming
description: Learn how to prepare .NET libraries for trimming.
author: sbomer
ms.author: svbomer
ms.date: 06/12/2023
---

# Prepare .NET libraries for trimming

The .NET SDK makes it possible to reduce the size of self-contained apps by [trimming](trim-self-contained.md). Trimming removes unused code from the app and its dependencies. Not all code is compatible with trimming, so .NET provides trim analysis warnings to detect patterns that may break trimmed apps. To resolve warnings originating from the app code, see [resolving trim warnings](#resolve-trim-warnings). This article describes how to prepare libraries for trimming and provides recommendations for fixing some common cases.

## Prerequisites

[.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet) or later.

## Enable library trim warnings

Trim warnings in a library can be found with either of the following methods:

* Enabling project-specific trimming using the `IsTrimmable` property.
* Creating a sample app that uses the library, and enabling trimming for the sample app.

We recommend using both approaches. Project-specific trimming is convenient and shows trim warnings for one project, but relies on the references being marked trim-compatible to see all warnings. Trimming a sample app is more work, but shows all warnings.

### Enable project-specific trimming

### [.NET 6](#tab/net6)

To get the latest version of the analyzer with the most coverage, install the [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet) or later. Installing the .NET 8 SDK or later:

* Updates the tooling used to build an app or library and enable trim warnings.
* Doesn't require targeting the .NET 7 or later runtime.

Set `<IsTrimmable>true</IsTrimmable>` in the project file.

### [.NET 7+](#tab/net7plus)

Set `<IsTrimmable>true</IsTrimmable>` in the project file.

---

:::code language="xml" source="~/docs/core/deploying/trimming/snippets/MyLibrary/MyLibrary.csproj.txt" id="snippet" highlight="2":::

Setting `<IsTrimmable>true</IsTrimmable>` marks the assembly as "trimmable" and enables trim warnings. "trimmable" means the project:

* Is considered compatible with trimming.
* Shouldn't generate trim related warnings when building. When used in a trimmed app, the assembly has its unused members trimmed in the final output.

The `IsTrimmable` property defaults to `true` when configuring a project as AOT-compatible with `<IsAotCompatible>true</IsAotCompatible>`. For more information, see [AOT-compatibility analyzers](../native-aot/index.md#aot-compatibility-analyzers).

To generate trim warnings without marking the project as trim-compatible, use `<EnableTrimAnalyzer>true</EnableTrimAnalyzer>` rather than `<IsTrimmable>true</IsTrimmable>`.

### Show all warnings with sample app

To show all analysis warnings for a library, the trimmer must analyze the implementation:

* Of the library.
* All dependencies the library uses.

When building and publishing a library:

* The implementations of the dependencies aren't available.
* The available reference assemblies don't have enough information for the trimmer to determine if they're compatible with trimming.

Because of the dependency limitations, a self-contained sample app which uses the library and its dependencies must be created. The sample app executable includes all the information the trimmer requires to issue warning on trim incompatibilities in:

* The library code.
* The code that the library references from its dependencies.

***Note:*** If the library has different behavior depending on the target framework, create a  sample app for each of the target frameworks. For example, if the library uses [conditional compilation](/dotnet/csharp/language-reference/preprocessor-directives#conditional-compilation) such as `#if NET7_0` to change behavior.

To create the sample app, create a separate console application project with `dotnet new console` and modify the project similar to project shown below. You need to do the following in the project file:

* Add `<PublishTrimmed>true</PublishTrimmed>`.
* Add a reference to the library project with `<ProjectReference Include="/Path/To/YourLibrary.csproj" />`.
* Specify the library as a trimmer root assembly with `<TrimmerRootAssembly Include="YourLibraryName" />`.
  * `TrimmerRootAssembly` ensures that every part of the library is analyzed. It tells the trimmer that this assembly is a "root,". A "root," assembly means the trimmer analyzes every call in the library, and traverses all code paths that originate from that assembly. `TrimmerRootAssembly` is necessary in case the library has `[AssemblyMetadata("IsTrimmable", "True")]`.  A project using `[AssemblyMetadata("IsTrimmable", "True")]` without  `TrimmerRootAssembly` would remove the unused library without analyzing it.
* If your app targets .NET 6, set the `TrimmerDefaultAction` property to `link` with `<TrimmerDefaultAction>link</TrimmerDefaultAction>` in a `<PropertyGroup>` element.

##### .csproj file

### [.NET 6](#tab/net6)

Set the `TrimmerDefaultAction` property to `link` with `<TrimmerDefaultAction>link</TrimmerDefaultAction>` in a `<PropertyGroup>` element.

:::code language="xml" source="~/docs/core/deploying/trimming/snippets/MyTestLib6app/MyTestLib6app.csproj":::

### [.NET 7+](#tab/net7plus)

Use the [.NET 7 and higher default behavior](../../../core/compatibility/deployment/7.0/trim-all-assemblies.md), which can enforce the behavior by adding `<TrimMode>full</TrimMode>`.

`<TrimMode>full</TrimMode>`:

* Ensures that the trimmer only analyzes the parts of the library's dependencies that are used.
* Tells the trimmer that any code that isn't part of a "root" can be trimmed if it's unused. Without this option,  warnings are issued originating from ***any*** part of a dependency that doesn't set `[AssemblyMetadata("IsTrimmable", "Tue")]`, including parts that are unused by the library.

:::code language="xml" source="~/docs/core/deploying/trimming/snippets/MyLibrary/MyLibrary.csproj.txt":::

Note: In the preceding project file, when using .NET 8, replace `<TargetFramework>net7.0</TargetFramework>` with `<TargetFramework>net8.0</TargetFramework>`.

---

Once the project file is updated, run `dotnet publish` with the target [runtime identifier (RID)](../../rid-catalog.md).

```dotnetcli
dotnet publish -c Release -r <RID>
```

Follow the same pattern for multiple libraries. To see trim analysis warnings for more than one library at a time, add them all to the same project as `ProjectReference` and `TrimmerRootAssembly` items. Adding all the libraries to the same project with `ProjectReference` and `TrimmerRootAssembly` items warns about dependencies if ***any*** of the root libraries use a trim-unfriendly API in a dependency. To see warnings that have to do with only a particular library, reference that library only.

***Note:*** The analysis results depend on the implementation details of the dependencies. Updating to a new version of a dependency may introduce analysis warnings:

* If the new version added non-understood reflection patterns.
* Even if there were no API changes.

Introducing trim analysis warnings to a library is a breaking change when the library is used with `PublishTrimmed`.

## Resolve trim warnings

The preceding steps produce warnings about code that may cause problems when used in a trimmed app. The following examples show the most common warnings with recommendations for fixing them.

### RequiresUnreferencedCode

:::code language="csharp" source="~/docs/core/deploying/trimming/snippets/MyLibrary/Class1.cs" id="snippet_1" highlight="5-11":::

This means the library calls a method that has explicitly been annotated as incompatible with trimming, using <xref:System.Diagnostics.CodeAnalysis.RequiresUnreferencedCodeAttribute>. To get rid of the warning, consider whether `Method` needs to call `DynamicBehavior` to do its job. If so, annotate the caller `Method` with `RequiresUnreferencedCode` as well; this will "bubble up" the warning so that callers of `Method` get a warning instead:

:::code language="csharp" source="~/docs/core/deploying/trimming/snippets/MyLibrary/Class1.cs" id="snippet_RequiresUnreferencedCode" highlight="5":::

Once you have "bubbled up" the attribute all the way to public APIs (so that these warnings are produced only for public methods, if at all), you're done. Apps that call your library will now get warnings if they call those public APIs, but these will no longer produce warnings like `IL2104: Assembly 'MyLibrary' produced trim warnings`.

### DynamicallyAccessedMembers

:::code language="csharp" source="~/docs/core/deploying/trimming/snippets/MyLibrary/Class1.cs" id="snippet_DAA1" highlight="5":::

In the preceding code, `UseMethods` is calling a reflection method that has a <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute> requirement. The requirement states that the type's public methods are available. Satisfy the requirement by adding the same requirement to the parameter of `UseMethods`.

:::code language="csharp" source="~/docs/core/deploying/trimming/snippets/MyLibrary/Class1.cs" id="snippet_DAA2" highlight="8":::

Now any calls to `UseMethods` produce warnings if they pass in values that don't satisfy the `PublicMethods` requirement. Like with `RequiresUnreferencedCode`, once you have bubbled up such warnings to public APIs, you're done.

In the following example, an unknown `Type` flows into the annotated method parameter. The unknown `Type` is from a field:

:::code language="csharp" source="~/docs/core/deploying/trimming/snippets/MyLibrary/Class1.cs" id="snippet_UMH":::

Similarly, here the problem is that the field `type` is passed into a parameter with these requirements. You can fix it by adding `DynamicallyAccessedMembers` to the field. This warns about code that assigns incompatible values to the field instead. Sometimes this process continues until a public API is annotated, and other times it ends when a concrete type flows into a location with these requirements. For example:

:::code language="csharp" source="~/docs/core/deploying/trimming/snippets/MyLibrary/Class1.cs" id="snippet_UMH2" highlight="1":::

In this case, the trim analysis keeps public methods of <xref:System.Tuple>, and produces further warnings.

## Recommendations

Avoid reflection when possible. When using reflection, minimized reflection scope so that it's reachable only from a small part of the library.

* Avoid using non-understood patterns in places like static constructors. Static constructors result in the warning propagating to all members of the class.
* Avoid annotating virtual methods or interface methods, which requires all overrides to have matching annotations.
* In some cases, you're able to mechanically propagate warnings through your code without issues. <!--Review: What doesn't mechanically propagate mean? For sure it won't MT (Machine Translate) --> Sometimes this results in much of your public API being annotated with `RequiresUnreferencedCode`. Annotating with `RequiresUnreferencedCode` is the right thing to do if the library behaves in ways that can't be understood statically by the trim analysis.
<!-- Original run on, way too long for MT 
* In other cases, you might discover that your code uses patterns that can't be expressed in terms of the `DynamicallyAccessedMembers` attributes, even if it only uses reflection to operate on statically known types. In these cases, you may need to reorganize some of your code to make it follow an analyzable pattern. -->
* Code that uses patterns that can't be expressed in terms of the `DynamicallyAccessedMembers` attributes:
  * Consider reorganizing that code to make it follow an analyzable pattern. This also applies to code that only uses reflection to operate on statically known types. <!-- Dreaded one bullet -->
* If an API is mostly trim-incompatible, you may need to find other ways to write the API. A common example is reflection-based serializers. In these cases, consider adopting other technology like source generators to produce code that is more easily statically analyzed. For example, see [How to use source generation in System.Text.Json](/dotnet/standard/serialization/system-text-json/source-generation)

## Resolve warnings for non-analyzable patterns

It's better to resolve warnings by expressing the intent of your code using `RequiresUnreferencedCode` and `DynamicallyAccessedMembers` when possible. However, in some cases, you may be interested in enabling trimming of a library that uses patterns that can't be expressed with those attributes, or without refactoring existing code. This section describes some advanced ways to resolve trim analysis warnings.

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

:::code language="csharp" source="~/docs/core/deploying/trimming/snippets/MyLibrary/Class1.cs" id="snippet_AD2" highlight="1-9":::

It's important to underline that it's only valid to suppress a warning if there are annotations or code that ensure the reflected-on members are visible targets of reflection. It isn't sufficient that the member was a target of a call, field or property access. It may appear to be the case sometimes but such code is bound to break eventually as more trimming optimizations are added. Properties, fields, and methods that aren't visible targets of reflection could be inlined, have their names removed, get moved to different types, or otherwise optimized in ways that break reflecting on them. When suppressing a warning, it's only permissible to reflect on targets that were visible targets of reflection to the trimming analyzer elsewhere.

:::code language="csharp" source="~/docs/core/deploying/trimming/snippets/MyLibrary/Class1.cs" id="snippet_AD3" highlight="9-10":::

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
