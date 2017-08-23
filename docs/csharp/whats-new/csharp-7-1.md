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

C# 7.1 is the first point release to the C# Language. This release is the
first step toward the next major release of the langauge. This increased
cadence enables you to use the new features sooner, ideally when
each features is ready. This release also adds the ability to configure
the compiler to match a specified version of the language. This feature
separates the decision to upgrade tools from the decision to upgrade language
versions.

This release adds the [language version selectionn](#language-version-selection)
configuration element, and four new language features.

The new language features in this release are:

* [`async` `Main` method](#async-main)
  - The entry point for a console application can have the `async` modifier.
* [`default` value expressions](#default-value-expressions)
  - The `default(T)` expression may omit the target type when that type can be inferred.
* [Inferred tuple element names](#inferred-tuple-element-names)
  - The names of tuple elements can be inferred from tuple initialization in many cases.
* [Reference assembly generation](#reference-assembly-generation)
  - The `/refout` and `/refonly` compiler options enable reference assembly generation.

## Langauge version selection

The C# compiler that ships with Visual Studio 2017 V15.3 or with
the .NET Core SDK 2.0 supports C# 7.1. However, the 7.1 features are turned
off by default. To enable 7.1 features, you need to change the language
version setting for your project.

In Visual Studio, right-click on the project node in Solution explorer and select
'Properties'. Select the "Build" tab and click on the "Advanced" button. In the dropdown,
select "C# latest minor version (latest)", or the specific version "C# 7.1"
as shwon in the image below. The 'latest' value means you want to use the latest
minor versio on the current machine. The 'C# 7.1' means that you want to use C# 7.1,
even after newer minor versions are released.

[Setting the language version](./csharp-7-1/media/advanced-build-settings.png)

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
> set the value the same in all build configurations.

Valid settings for "langVersion" element are:

* ISO-1
* ISO-2
* 3
* 4
* 5
* 6
* 7
* 7.1
* default
* latest

The special strings "default" and "latest" resolve to the latest major
and minor language versions installed on the build machine, respectively.

This setting decouples installing new versions of the SDK and tools
in your development environment from choosing to incorporate new language
features in a project. You can install the latest SDK and tools on your
build machine. Each project can be configured to use a specific version
of the language for its build.

## Async main

An *async main* method enables you to use `await` in your `Main` method.
Where previously you would need to write:

```csharp
static int Main()
{
    return DoAsyncWork().GetAwaiter().GetResult();
}
```

You can know write:

```csharp
static async Task<int> Main()
{
    // This could also be replaced with the body
    // DoAsyncWork, including its await expressions:
    return await DoAsyncWork();
}
```

If your program does not return an exit code, you can declare `Main` method
that returns a `Task`:

```csharp
static async Task Main()
{
    await SomeAsyncMethod();
}
```

You can read more about the details in the
[async main](../programming-guid/main-and-command-args/index.md) topic
in the programming guide.

## Default value expressions

When you initialize an object using a default value expression, you can
omit the type from the default expression. Where you previously needed to
type:

```csharp
Func<string, bool> whereClause = default(Func<string, bool>);
```

You can now write:

```csharp
Func<string, bool> whereClause = default;
```

There are many language constructs where default value expressions can make use
of this new syntax. You can learn more in the topic on default value expressions
in the topics on the [`default` keyword](../language-reference/keywords/default.md)
and the topic on [default value expressions](../programming-guide/statements-expressions-operators/default-value-expressions.md).

## Inferred tuple element names

This feature is a small enhancement to the tuples feature introduced in
C# 7.0. Many times that you initialize a tuple, the variables used for the
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

You can learn more about the details for this feature in the [Tuples](../tuples.md)) topic.

## Reference assembly generation

There are two new compiler options that generate *reference only assemblies*:
[/refout](../language-reference/compiler-options/refout-compiler-option.md)
and [/refonly](../language-reference/compiler-options/refonly-compiler-option.md).
The linked topics explain these options and reference assemblies in more detail.
