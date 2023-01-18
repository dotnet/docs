---
title: Prepare .NET libraries for trimming
description: Learn how to prepare .NET libraries for trimming.
author: sbomer
ms.author: svbomer
ms.date: 04/16/2021
zone_pivot_groups: dotnet-version
---

# Prepare .NET libraries for trimming

The .NET SDK makes it possible to reduce the size of self-contained apps by [trimming](trim-self-contained.md), which removes unused code from the app and its dependencies. Not all code is compatible with trimming, so .NET 6 provides trim analysis warnings to detect patterns that may break trimmed apps. To resolve warnings originating from the app code, see [resolving trim warnings](#resolve-trim-warnings). This article describes how to prepare libraries for trimming with the aid of these warnings, including recommendations for fixing some common cases.

## Enable library trim warnings

> [!TIP]
> Ensure you're using the .NET 6 SDK or later for these steps. They will not work correctly in previous versions.

There are two ways to find trim warnings in your library:

  1. Enable project-specific trimming using the `IsTrimmable` property.
  2. Add your library as a reference to a sample app, and trim the sample app.

Consider doing both. Project-specific trimming is convenient and shows trim warnings for one project, but relies on the references being marked trim-compatible in order to see all warnings. Trimming a sample app is more work, but will always show all warnings.

### Enable project-specific trimming

> [!TIP]
> To get the latest version of the analyzer with the most coverage, use the [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet). Note this will only update the tooling used to build your app and doesn't require you to target the .NET 7 runtime.

Set `<IsTrimmable>true</IsTrimmable>` in a `<PropertyGroup>` tag in your library project file. This will mark your assembly as "trimmable" and enable trim warnings for that project. Being "trimmable" means your library is considered compatible with trimming and should have no trim warnings when building the library. When used in a trimmed application, the assembly will have its unused members trimmed in the final output.

If you want to see trim warnings, but don't want to mark your library as trim-compatible, you can add `<EnableTrimAnalyzer>true</EnableTrimAnalyzer>` instead.

### Show all warnings with sample application

To show all analysis warnings for your library, including warnings about dependencies, you need the trimmer to analyze the implementation of your library and the implementations of dependencies your library uses. When building and publishing a library, the implementations of the dependencies are not available, and the reference assemblies that are available do not have enough information for the trimmer to determine if they are compatible with trimming. Because of this, you'll need to create and publish a self-contained sample application which produces an executable that includes your library and the dependencies it relies on. This executable includes all the information the trimmer requires to warn you about all trim incompatibilities in your library code, as well as the code that your library references from its dependencies.

> [!NOTE]
> If your library has significantly different behavior or uses different APIs depending on the target framework of the consumer (for example, using `#if NET5_0_OR_GREATER`) which might impact trimming, you will need to create a new sample app for each of the target frameworks you want to support trimming for.

:::zone pivot="dotnet-7-0,dotnet-6-0,dotnet-5-0,dotnet-core-3-1"

To create your sample app, first create a separate console application project with `dotnet new console` and modify the project file to look like the following. No changes to the source code are necessary. You'll need to do the following in your project file:

- Set the PublishTrimmed property to `true` with `<PublishTrimmed>true</PublishTrimmed>` in a `<PropertyGroup>` tag.
- Add a reference to your library project with `<ProjectReference Include="/Path/To/YourLibrary.csproj" />` inside of an `<ItemGroup>` tag.
- Specify your library as a trimmer root assembly with `<TrimmerRootAssembly Include="YourLibraryName" />` in an `<ItemGroup>` tag.
  - This ensures that every part of the library is analyzed. It tells the trimmer that this assembly is a "root" which means the trimmer will analyze the assembly as if everything will be used, and traverses all possible code paths that originate from that assembly. This is necessary in case the library has `[AssemblyMetadata("IsTrimmable", "True")]`, which would otherwise let trimming remove the unused library without analyzing it.
:::zone-end
:::zone pivot="dotnet-6-0,dotnet-5-0,dotnet-core-3-1"
- Set the TrimmerDefaultAction property to `link` with `<TrimmerDefaultAction>link</TrimmerDefaultAction>` in a `<PropertyGroup>` tag.
:::zone-end
:::zone pivot="dotnet-7-0"
- The default behavior for the `TrimMode` property is what you want, but you can enforce the behavior by adding `<TrimMode>full</TrimMode>` in a `<PropertyGroup>` tag.
:::zone-end
:::zone pivot="dotnet-7-0,dotnet-6-0,dotnet-5-0,dotnet-core-3-1"
  - This ensures that the trimmer only analyzes the parts of the library's dependencies that are used. It tells the trimmer that any code that is not part of a "root" can be trimmed if it is unused. Without this option, you would see warnings originating from _any_ part of a dependency that doesn't set `[AssemblyMetadata("IsTrimmable", "True")]`, including parts that are unused by your library.
:::zone-end

:::zone pivot="dotnet-6-0,dotnet-5-0,dotnet-core-3-1"

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <!-- Replace with net5.0, or netcoreapp3.1 if testing for those frameworks -->
    <TargetFramework>net6.0</TargetFramework>
    <PublishTrimmed>true</PublishTrimmed>
    <!-- Prevent warnings from unused code in dependencies -->
    <TrimmerDefaultAction>link</TrimmerDefaultAction>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include="path/to/MyLibrary.csproj" />
    <!-- Analyze the whole library, even if attributed with "IsTrimmable" -->
    <TrimmerRootAssembly Include="MyLibrary" />
  </ItemGroup>

</Project>
```

:::zone-end

:::zone pivot="dotnet-7-0"

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net7.0</TargetFramework>
    <PublishTrimmed>true</PublishTrimmed>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include="path/to/MyLibrary.csproj" />
    <!-- Analyze the whole library -->
    <TrimmerRootAssembly Include="MyLibrary" />
  </ItemGroup>

</Project>
```

:::zone-end

Once your project file is updated, run `dotnet publish` with the [runtime identifier (RID)](../../rid-catalog.md) you want to target.

```dotnetcli
dotnet publish -c Release -r <RID>
```

You can also follow the same pattern for multiple libraries. To see trim analysis warnings for more than one library at a time, add them all to the same project as `ProjectReference` and `TrimmerRootAssembly` items. This will warn about dependencies if _any_ of the root libraries use a trim-unfriendly API in a dependency. To see warnings that have to do with only a particular library, reference that library only.

> [!NOTE]
> The analysis results depend on the implementation details of your dependencies. If you update to a new version of a dependency, this may introduce analysis warnings if the new version added non-understood reflection patterns, even if there were no API changes. In other words, introducing trim analysis warnings to a library is a breaking change when the library is used with `PublishTrimmed`.

## Resolve trim warnings

The above steps will produce warnings about code that may cause problems when used in a trimmed app. Here are a few examples of the most common kinds of warnings you may encounter, with recommendations for fixing them.

### RequiresUnreferencedCode

```csharp
using System.Diagnostics.CodeAnalysis;

public class MyLibrary
{
    public static void Method()
    {
        // warning IL2026 : MyLibrary.Method: Using method 'MyLibrary.DynamicBehavior' which has
        // 'RequiresUnreferencedCodeAttribute' can break functionality
        // when trimming application code.
        DynamicBehavior();
    }

    [RequiresUnreferencedCode("DynamicBehavior is incompatible with trimming.")]
    static void DynamicBehavior()
    {
    }
}
```

This means the library calls a method that has explicitly been annotated as incompatible with trimming, using <xref:System.Diagnostics.CodeAnalysis.RequiresUnreferencedCodeAttribute>. To get rid of the warning, consider whether `Method` needs to call `DynamicBehavior` to do its job. If so, annotate the caller `Method` with `RequiresUnreferencedCode` as well; this will "bubble up" the warning so that callers of `Method` get a warning instead:

```csharp
// Warn for calls to Method, but not for Method's call to DynamicBehavior.
[RequiresUnreferencedCode("Calls DynamicBehavior.")]
public static void Method()
{
    DynamicBehavior(); // OK. Doesn't warn now.
}
```

Once you have "bubbled up" the attribute all the way to public APIs (so that these warnings are produced only for public methods, if at all), you are done. Apps that call your library will now get warnings if they call those public APIs, but these will no longer produce warnings like `IL2104: Assembly 'MyLibrary' produced trim warnings`.

### DynamicallyAccessedMembers

```csharp
using System.Diagnostics.CodeAnalysis;

public class MyLibrary
{
    static void UseMethods(Type type)
    {
        // warning IL2070: MyLibrary.UseMethods(Type): 'this' argument does not satisfy
        // 'DynamicallyAccessedMemberTypes.PublicMethods' in call to 'System.Type.GetMethods()'.
        // The parameter 't' of method 'MyLibrary.UseMethods(Type)' does not have matching annotations.
        foreach (var method in type.GetMethods())
        {
            // ...
        }
    }
}
```

Here, `UseMethods` is calling a reflection method that has a <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute> requirement. The requirement states that the type's public methods are available. In this case, you can satisfy the requirement by adding the same requirement to the parameter of `UseMethods`.

```csharp
static void UseMethods(
    // State the requirement in the UseMethods parameter.
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)]
    Type type)
{
    // ...
}
```

Now any calls to `UseMethods` will produce warnings if they pass in values that don't satisfy the `PublicMethods` requirement. Like with `RequiresUnreferencedCode`, once you have bubbled up such warnings to public APIs, you are done.

Here is another example where an unknown `Type` flows into the annotated method parameter, this time from a field:

```csharp
static Type type;

static void UseMethodsHelper()
{
    // warning IL2077: MyLibrary.UseMethodsHelper(Type): 'type' argument does not satisfy
    // 'DynamicallyAccessedMemberTypes.PublicMethods' in call to 'MyLibrary.UseMethods(Type)'.
    // The field 'System.Type MyLibrary::type' does not have matching annotations.
    UseMethods(type);
}
```

Similarly, here the problem is that the field `type` is passed into a parameter with these requirements. You can fix it by adding `DynamicallyAccessedMembers` to the field. This will warn about code that assigns incompatible values to the field instead. Sometimes this process will continue until a public API is annotated, and other times it will end when a concrete type flows into a location with these requirements. For example:

```csharp
[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)]
static Type type;

static void InitializeTypeField()
{
    MyLibrary.type = typeof(System.Tuple);
}
```

In this case the trim analysis will simply keep public methods of `System.Tuple`, and will not produce further warnings.

## Recommendations

In general, try to avoid reflection if possible. When using reflection, limit it in scope so that it is reachable only from a small part of the library.

- Avoid using non-understood patterns in places like static constructors that will result in the warning propagating to all members of the class.
- Avoid annotating virtual methods or interface methods, which will require all overrides to have matching annotations.
- In some cases, you will be able to mechanically propagate warnings through your code without issues. Sometimes this will result in much of your public API being annotated with `RequiresUnreferencedCode`, which is the right thing to do if the library indeed behaves in ways that can't be understood statically by the trim analysis.
- In other cases, you might discover that your code uses patterns that can't be expressed in terms of the `DynamicallyAccessedMembers` attributes, even if it only uses reflection to operate on statically known types. In these cases, you may need to reorganize some of your code to make it follow an analyzable pattern.
- Sometimes the existing design of an API will render it mostly trim-incompatible, and you may need to find other ways to accomplish what it is doing. A common example is reflection-based serializers. In these cases, consider adopting other technology like source generators to produce code that is more easily statically analyzed.

## Resolve warnings for non-analyzable patterns

It's better to resolve warnings by expressing the intent of your code using `RequiresUnreferencedCode` and `DynamicallyAccessedMembers` when possible. However, in some cases you may be interested in enabling trimming of a library that uses patterns that can't be expressed with those attributes, or without refactoring existing code. This section describes some advanced ways to resolve trim analysis warnings.

> [!WARNING]
> These techniques might break your code if used incorrectly.

### UnconditionalSuppressMessage

If the intent of your code can't be expressed with the annotations, but you know that the warning doesn't represent a real issue at run time, you can suppress the warnings using <xref:System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessageAttribute>. This is similar to `SuppressMessageAttribute`, but it's persisted in IL and respected during trim analysis.

> [!WARNING]
> When suppressing warnings, you are responsible for guaranteeing the trim compatibility of your code based on invariants that you know to be true by inspection. Be careful with these annotations, because if they are incorrect, or if invariants of your code change, they might end up hiding real issues.

For example:

```csharp
class TypeCollection
{
    Type[] types;

    // Ensure that only types with preserved constructors are stored in the array
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)]
    public Type this[int i]
    {
        // warning IL2063: TypeCollection.Item.get: Value returned from method 'TypeCollection.Item.get'
        // can not be statically determined and may not meet 'DynamicallyAccessedMembersAttribute' requirements.
        get => types[i];
        set => types[i] = value;
    }
}

class TypeCreator
{
    TypeCollection types;

    public void CreateType(int i)
    {
        types[i] = typeof(TypeWithConstructor);
        Activator.CreateInstance(types[i]); // No warning!
    }
}

class TypeWithConstructor
{
}
```

Here, the indexer property has been annotated so that the returned `Type` meets the requirements of `CreateInstance`. This already ensures that the `TypeWithConstructor` constructor is kept, and that the call to `CreateInstance` doesn't warn. Furthermore, the indexer setter annotation ensures that any types stored in the `Type[]` have a constructor. However, the analysis isn't able to see this, and still produces a warning for the getter, because it doesn't know that the returned type has its constructor preserved.

If you are sure that the requirements are met, you can silence this warning by adding `UnconditionalSuppressMessage` to the getter:

```csharp
[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)]
public Type this[int i]
{
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2063",
        Justification = "The list only contains types stored through the annotated setter.")]
    get => types[i];
    set => types[i] = value;
}
```

It is important to underline that it is only valid to suppress a warning if there are annotations or code that ensure the reflected-on members are visible targets of reflection. It is not sufficient that the member was simply a target of a call, field or property access. It may appear to be the case sometimes but such code is bound to break eventually as more trimming optimizations are added. Properties, fields, and methods that are not visible targets of reflection could be inlined, have their names removed, get moved to different types, or otherwise optimized in ways that will break reflecting on them. When suppressing a warning, it's only permissible to reflect on targets that were visible targets of reflection to the trimming analyzer elsewhere.

```csharp
[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2063",
    // Invalid justification and suppression: property being non-reflectively
    // used by the app doesn't guarantee that the property will be available
    // for reflection. Properties that are not visible targets of reflection
    // are already optimized away with Native AOT trimming and may be
    // optimized away for non-native deployment in the future as well.
    Justification = "*INVALID* Only need to serialize properties that are used by the app. *INVALID*")]
public string Serialize(object o)
{
    StringBuilder sb = new StringBuilder();
    foreach (var property in o.GetType().GetProperties())
    {
        AppendProperty(sb, property, o);
    }
    return sb.ToString();
}
```

### DynamicDependency

This attribute can be used to indicate that a member has a dynamic dependency on other members. This results in the referenced members being kept whenever the member with the attribute is kept, but doesn't silence warnings on its own. Unlike the other attributes which teach the trim analysis about the reflection behavior of your code, `DynamicDependency` only keeps additional members. This can be used together with `UnconditionalSuppressMessageAttribute` to fix some analysis warnings.

> [!WARNING]
> Use `DynamicDependencyAttribute` only as a last resort when the other approaches aren't viable. It is preferable to express the reflection behavior of your code using `RequiresUnreferencedCodeAttribute` or `DynamicallyAccessedMembersAttribute`.

```csharp
[DynamicDependency("Helper", "MyType", "MyAssembly")]
static void RunHelper()
{
    var helper = Assembly.Load("MyAssembly").GetType("MyType").GetMethod("Helper");
    helper.Invoke(null, null);
}
```

Without `DynamicDependency`, trimming might remove `Helper` from `MyAssembly` or remove `MyAssembly` completely if it's not referenced elsewhere, producing a warning that indicates a possible failure at run time. The attribute ensures that `Helper` is kept.

The attribute specifies the members to keep via a `string` or via `DynamicallyAccessedMemberTypes`. The type and assembly are either implicit in the attribute context, or explicitly specified in the attribute (by `Type`, or by `string`s for the type and assembly name).

The type and member strings use a variation of the C# documentation comment ID string [format](/dotnet/csharp/language-reference/language-specification/documentation-comments#id-string-format), without the member prefix. The member string should not include the name of the declaring type, and may omit parameters to keep all members of the specified name. Some examples of the format follow:

```csharp
[DynamicDependency("Method()")]
[DynamicDependency("Method(System,Boolean,System.String)")]
[DynamicDependency("MethodOnDifferentType()", typeof(ContainingType))]
[DynamicDependency("MemberName")]
[DynamicDependency("MemberOnUnreferencedAssembly", "ContainingType", "UnreferencedAssembly")]
[DynamicDependency("MemberName", "Namespace.ContainingType.NestedType", "Assembly")]
// generics
[DynamicDependency("GenericMethodName``1")]
[DynamicDependency("GenericMethod``2(``0,``1)")]
[DynamicDependency("MethodWithGenericParameterTypes(System.Collections.Generic.List{System.String})")]
[DynamicDependency("MethodOnGenericType(`0)", "GenericType`1", "UnreferencedAssembly")]
[DynamicDependency("MethodOnGenericType(`0)", typeof(GenericType<>))]
```

This attribute is designed to be used in cases where a method contains reflection patterns that can not be analyzed even with the help of `DynamicallyAccessedMembersAttribute`.
