---
title: Trimming libraries
description: Learn how to prepare libraries for trimming.
author: sbomer
ms.author: svbomer
ms.date: 08/25/2020
---

# Trimming libraries

## Trim warnings in apps

When publishing an app, `PublishTrimmed` will produce trim analysis [warnings](trimming-options.md#analysis-warnings) (in .NET 6+) for patterns that are not statically understood to be compatible with trimming, including patterns in your code and in dependencies.

You will encounter detailed warnings originating from your own code and `ProjectReference` dependencies. You may also see warnings like `warning IL2104: Assembly 'SomeAssembly' produced trim warnings` for `PackageReference` libraries. This means that the library contained patterns which are not guaranteed to work in the context of the trimmed app, and may result in a broken app. Consider contacting the author to see if the library can be annotated for trimming.

To resolve warnings originating from the app code, jump ahead to the instructions below to [resolve trim warnings](resolving-trim-warnings.md). If you are interested in making your own `ProjectReference` libraries trim friendly, follow the instructions to [enable library trim warnings](enabling-library-trim-warnings).

If your app only uses parts of a library that are compatible with trimming, consider [enabling trimming](trimming-options.md#trim-additional-assemblies) of this library if it is not already being trimmed. This will only produce warnings if your app uses problematic parts of the library. (You can also [show detailed warnings](trimming-options.md#showing-detailed-warnings) for the library to see which parts of it are problematic.)

## Enabling library trim warnings

These instructions show how to enable and resolve static analysis warnings to prepare a library for trimming. Follow these steps if you are authoring a library and either want to proactively make your library trimmable, or have been contacted by app authors who encountered trim warnings from your library.

Use the .NET 6 SDK for the best experience. It is possible to [show analysis warnings](trimming-options.md#analysis-warnings) in .NET 5, but this will show detailed warnings for every library, including framework libraries. These instructions assume you are using the .NET 6 SDK.

### Incomplete Roslyn analyzer

During development, you may set `<EnableTrimAnalyzer>true</EnableTrimAnalyzer>` (in .NET 6+) in your library project to get a _limited_ set of warnings from the Roslyn analyzer. This analyzer is incomplete and should only be used as a convenience. It is important to follow the next steps to ensure that your library is compatible with trimming.

### Showing all warnings

To show all analysis warnings for your library, including warnings about dependencies, create a project like the following that references your library, and publish it with `PublishTrimmed`.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net6.0</TargetFramework>
    <!-- Use a RID of your choice. -->
    <RuntimeIdentifier>linux-x64</RuntimeIdentifier>
    <PublishTrimmed>true</PublishTrimmed>
    <TrimmerDefaultAction>link</TrimmerDefaultAction>
    <!-- Optional, for non-default workloads -->
    <SuppressTrimAnalysisWarnings>false</SuppressTrimAnalysisWarnings>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include="path/to/MyLibrary.csproj" />
    <TrimmerRootAssembly Include="MyLibrary" />
  </ItemGroup>

</Project>
```

```dotnetcli
dotnet publish -c Release
```

- Publishing a self-contained app ensures that the library is analyzed in a context where its dependencies are available, so that you are alerted if your library uses any code from dependencies that is incompatible with trimming.

- `TrimmerRootAssembly` ensures that every part of the library is analyzed. This is necessary in case the library has `[AssemblyMetadata("IsTrimmable", "True")]`, which would otherwise let trimming remove the unused library without analyzing it.

- `<TrimmerDefaultAction>link</TrimmerDefaultAction>` ensures that only used parts of dependencies are analyzed. Without this option, you would see warnings originating from _any_ part of a dependency that doesn't set `[AssemblyMetadata("IsTrimmable", "True")]`, including parts that are unused by your library.

- `<SuppressTrimAnalysisWarnings>link</SuppressTrimAnalysisWarnings>` is implied by `PublishTrimmed` in the .NET SDK. It is only needed if the app targets form factors like Android where the trim analysis warnings are disabled by default. Consult the documentation for your SDK.

You can also follow the same pattern for multiple libraries, adding them all to the same project as `ProjectReference` and `TrimmerRootAssembly` item to see trim analysis warnings for more than one library at a time, but note that this will warn about dependencies if _any_ of the root libraries use a trim-unfriendly API in a dependency. To see warnings that have to do with only a particular library, reference that library only.

Note that the analysis results depend on the implementation details of your dependencies. If you update to a new version of a dependency, this may introduce analysis warnings if the new version added non-understood reflection patterns, even if there were no API changes. In other words, introducing trim analysis warnings to a library is a breaking change when the library is used with `PublishTrimmed`.

## Resolving trim warnings

The above steps will produce warnings about code that may cause problems when used in a trimmed app. Here are a few examples of the most common kinds of warnings you may encounter, with recommendations for fixing them.

### RequiresUnreferencedCode

```csharp
using System.Diagnostics.CodeAnalysis;

public class MyLibrary
{
    public static void Foo()
    {
        // warning IL2026 : MyLibrary.Foo: Using method 'MyLibrary.Bar' which has
        // 'RequiresUnreferencedCodeAttribute' can break functionality
        // when trimming application code.
        Bar();
    }

    [RequiresUnreferencedCode("Bar does something incompatible with trimming.")]
    static void Bar()
    {
    }
}
```

This means the library calls a method which has explicitly been annotated as incompatible with trimming, using [`RequiresUnreferencedCodeAttribute`](
https://docs.microsoft.com/dotnet/api/system.diagnostics.codeanalysis.requiresunreferencedcodeattribute?view=net-5.0). To get rid of the warning, consider whether `Foo` needs to call `Bar` to do its job. If so, annotate the caller `Foo` with `RequiresUnreferencedCode` as well; this will "bubble up" the warning so that callers of `Foo` get a warning instead. Once you have "bubbled up" the attribute all the way to public APIs (so that these warnings are produced only for public methods, if at all), you are done. Apps which call your library will now get warnings if they call those public APIs, but these will no longer produce warnings like `IL2104: Assembly 'MyLibrary' produced trim warnings`.

### DynamicallyAccessedMembers

```csharp
using System.Diagnostics.CodeAnalysis;

public class MyLibrary
{
    public static void Foo(Type type)
    {
        // warning IL2067: MyLibrary.Foo(Type): 'type' argument does not satisfy
        // 'DynamicallyAccessedMemberTypes.PublicMethods' in call to 'MyLibrary.UseMethods(Type)'.
        // The parameter 't' of method 'MyLibrary.Foo(Type)' does not have matching annotations.
        UseMethods(type);
    }

    static void UseMethods(
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)]
        Type type)
    {
        foreach (var method in type.GetMethods())
        {
            // ...
        }
    }
}
```

Here, `Foo` is calling a method which takes a `Type` argument that is annotated with a [`DynamicallyAccessedMembers`](https://docs.microsoft.com/dotnet/api/system.diagnostics.codeanalysis.dynamicallyaccessedmembersattribute?view=net-5.0) requirement. The requirement states that the value passed in as this argument must represent a type whose public methods are available. In this case, you can fix this by adding the same requirement to the parameter of `Foo`. Like above, once you have bubbled up such warnings to public APIs, you are done.

```csharp
    static Type type;

    static void Bar()
    {
        // warning IL2077: MyLibrary.Bar(Type): 'type' argument does not satisfy
        // 'DynamicallyAccessedMemberTypes.PublicMethods' in call to 'MyLibrary.UseMethods(Type)'.
        // The field 'System.Type MyLibrary::type' does not have matching annotations.
        UseMethods(type);
    }
```

Similarly, here the problem is that the field `type` is passed into a parameter with these requinements. You can fix it by adding `DynamicallyAccessedMembers` to the field. This will warn about code that assigns incompatible values to the field instead. Sometimes this process will continue until a public API is annotated, and other times it will end when a concrete type flows into a location with these requirements. For example:

```csharp
    [DynamicallyAccessedMembers(DynamicallyAccessedMembers.PublicMethods)]
    static Type type;

    static void Baz()
    {
        MyLibrary.type = typeof(System.Tuple);
    }
```

In this case the trim analysis will simply keep public methods of `System.Tuple`, and will not produce further warnings.

### Recommendations

In general, try to avoid reflection if possible, and when using reflection limit it in scope so that it is reachable only from a small part of the library. For example, avoid using non-understood patterns in places like static constructors that will result in the warning propagating to all members of the class.

- In some cases, you will be able to mechanically propagate warnings through your code without issues. Sometimes this will result in much of your public API being annotated with `RequiresUnreferencedCode`, which is the right thing to do if the library indeed behaves in ways that can't be understood statically by the trim analysis.
- In other cases, you might discover that your code uses patterns which can't be expressed in terms of the `DynamicallyAccessedMembers` attributes, even if it only uses reflection to operate on statically-known types. In these cases, you may need to reorganize some of your code to make it follow an analyzable pattern.
- Sometimes the existing design of an API will render it mostly trim-incompatible, and you may need to find other ways to accomplish what it is doing. A common example is reflection-based serializers. In these cases, consider adopting other technology like source generators to produce code that is more easily statically analyzed.
