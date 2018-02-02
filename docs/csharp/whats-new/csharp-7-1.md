---
title: What's new in C# 7.1
description: An overview of new features in C# 7.1.
keywords: C# language design, 7.1, Visual Studio 2017, 
author: billwagner
ms.author: wiwagn
ms.date: 08/16/2017
ms.topic: article
ms.prod: .net
ms.devlang: devlang-csharp
---
# What's new in C# 7.1

C# 7.1 is the first point release to the C# language. It marks an increased
release cadence for the language. You can use the new features sooner, ideally
when each new feature is ready. C# 7.1 adds the ability to configure
the compiler to match a specified version of the language. That enables you to
separate the decision to upgrade tools from the decision to upgrade language
versions.

C# 7.1 adds the [language version selection](#language-version-selection)
configuration element, three new language features and new compiler behavior.

The new language features in this release are:

* [`async` `Main` method](#async-main)
  - The entry point for an application can have the `async` modifier.
* [`default` literal expressions](#default-literal-expressions)
  - You can use default literal expressions in default value expressions when the target type can be inferred.
* [Inferred tuple element names](#inferred-tuple-element-names)
  - The names of tuple elements can be inferred from tuple initialization in many cases.

Finally, the compiler has two options `/refout` and `/refonly` that
control [reference assembly generation](#reference-assembly-generation).

## Language version selection

The C# compiler supports C# 7.1 starting with Visual Studio 2017 version 15.3, or
the .NET Core SDK 2.0. However, the 7.1 features are turned
off by default. To enable the 7.1 features, you need to change the language
version setting for your project.

In Visual Studio, right-click on the project node in Solution Explorer and select
**Properties**. Select the **Build** tab and select the **Advanced** button. In the dropdown,
select **C# latest minor version (latest)**, or the specific version **C# 7.1**
as shown in the image following. The `latest` value means you want to use the latest
minor version on the current machine. The `C# 7.1` means that you want to use C# 7.1,
even after newer minor versions are released.

![Setting the language version](./media/csharp-7-1/advanced-build-settings.png)

Alternatively, you can edit the "csproj" file and add or modify the
following lines:

```xml
<PropertyGroup>
  <LangVersion>latest</LangVersion>
</PropertyGroup>
```

> [!NOTE]
> If you use the Visual Studio IDE to update your csproj files, the IDE
> creates separate nodes for each build configuration. You'll typically
> set the value the same in all build configurations, but you need to
> set it explicitly for each build configuration, or select "All Configurations"
> when you modify this setting. You'll see the following in your csproj file:

```xml
<PropertyGroup Condition="'$(Configuration)|$(Platform)'=='Release|AnyCPU'">
  <LangVersion>latest</LangVersion>
</PropertyGroup>

<PropertyGroup Condition="'$(Configuration)|$(Platform)'=='Debug|AnyCPU'">
  <LangVersion>latest</LangVersion>
</PropertyGroup>
```

Valid settings for the `LangVersion` element are:

* `ISO-1`
* `ISO-2`
* `3`
* `4`
* `5`
* `6`
* `7`
* `7.1`
* `default`
* `latest`

The special strings `default` and `latest` resolve to the latest major
and minor language versions installed on the build machine, respectively.

This setting decouples installing new versions of the SDK and tools
in your development environment from choosing to incorporate new language
features in a project. You can install the latest SDK and tools on your
build machine. Each project can be configured to use a specific version
of the language for its build.

## Async main

An *async main* method enables you to use `await` in your `Main` method.
Previously you would need to write:

```csharp
static int Main()
{
    return DoAsyncWork().GetAwaiter().GetResult();
}
```

You can now write:

```csharp
static async Task<int> Main()
{
    // This could also be replaced with the body
    // DoAsyncWork, including its await expressions:
    return await DoAsyncWork();
}
```

If your program doesn't return an exit code, you can declare a `Main` method
that returns a <xref:System.Threading.Tasks.Task>:

```csharp
static async Task Main()
{
    await SomeAsyncMethod();
}
```

You can read more about the details in the
[async main](../programming-guide/main-and-command-args/index.md) topic
in the programming guide.

## Default literal expressions

Default literal expressions are an enhancement to default value expressions.
These expressions initialize a variable to the default value. Where you previously
would write:

```csharp
Func<string, bool> whereClause = default(Func<string, bool>);
```

You can now omit the type on the right-hand side of the initialization:

```csharp
Func<string, bool> whereClause = default;
```

You can learn more about this enhancement in the C# Programming Guide topic
on [default value expressions](../programming-guide/statements-expressions-operators/default-value-expressions.md).

This enhancement also changes some of the parsing rules for the [default keyword](../language-reference/keywords/default.md).

## Inferred tuple element names

This feature is a small enhancement to the tuples feature introduced in
C# 7.0. Many times when you initialize a tuple, the variables used for the
right side of the assignment are the same as the names you'd like for the
tuple elements:

```csharp
int count = 5;
string label = "Colors used in the map";
var pair = (count: count, label: label);
```

The names of tuple elements can be inferred from the variables used to initialize
the tuple in C# 7.1:

```csharp
int count = 5;
string label = "Colors used in the map";
var pair = (count, label); // element names are "count" and "label"
```

You can learn more about this feature in the [Tuples](../tuples.md) topic.

## Reference assembly generation

There are two new compiler options that generate *reference-only assemblies*:
[/refout](../language-reference/compiler-options/refout-compiler-option.md)
and [/refonly](../language-reference/compiler-options/refonly-compiler-option.md).
The linked topics explain these options and reference assemblies in more detail.
