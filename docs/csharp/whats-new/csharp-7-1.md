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
cadence enables you to use the new features sooner, ideally as soon as
each features is ready. This release also adds the ability to configure
the compiler to match a specified version of the language so that you
can upgrade tools and opt out of the latest langauge features on a 
project by project basis.

This release adds four new language features, and [language version selectionn](#language-version-selection) for project builds.

The new features in this release are:

* [Async `Main` method](#async-main)
    - The entry point for a console application can have the `async` modifier.
* [`default` value expressions](#default-value-expressions)
    - The `default(T)` expression can omit the target type when that type can be inferred.
* [Inferred tuple element names](#inferred-tuple-element-names)
    - The names of tuple elements can be inferred from the tuple initialization in many cases.
* [Reference assembly generation](#reference-assembly-generation)
    - The `refout` and `refonly` compiler options enable reference assembly generation.

## Langauge version selection

The C# compiler that ships with Visual Studio 2017 V15.3 or with
the .NET Core SDK 2.0 supports C# 7.1. However, the 7.1 features are turned
off by default. To enable 7.1 features, you need to change the language
version setting for your project.

In Visual Studio, right-click on the project node in Solution explorer and select
'Properties'. Select the "Build" tab and click on the "Advanced" button. In the dropdown,
select "C# latest minor version (latest)", or the specific version "C# 7.1"
as shwon in the image below.

[Setting the language version](./csharp-7-1/media/advanced-build-settings.png)

Alternatively, you can edit the "csproj" file and add or modify the
following lines:

```xml
<PropertyGroup Condition="'$(Configuration)|$(Platform)'=='Release|AnyCPU'">
<LangVersion>latest</LangVersion>
</PropertyGroup>

<PropertyGroup Condition="'$(Configuration)|$(Platform)'=='Debug|AnyCPU'">
<LangVersion>latest</LangVersion>
</PropertyGroup>
```

Note that you can specify different language versions for debug and release
builds. Valid settings for "langVersion" element are:

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
and minor language versions, respectively.

This setting decouples installing new versions of the SDK and tools
in your development environment from choosing to incorporate new language
features in a project.

## Async main

An async main method enables you to use `await` in your `Main` method.
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
    return await DoAsyncWork();
}
```

If your program does not return an exit code, you can declare `Main` method
that returns a `Task`:

```csharp
static async Task Main();
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
of this new syntax. You can learn more in the topic on default value expressions.

## Inferred tuple element names

This feature is a small enhancement to the tuples feature introduced in
C# 7.0. Many times that you initialize a tuple, the variable used for the
right side of the assignment is the same as the name you'd like for the
tuple element:

```csharp
int count = 5;
string label = "Colors used in the map";
var pair = (count: count, label: label);
```

The names of tuple elements can be inferred from the variables used to initialize
the tuple:

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
The linked topics explain these options in more details.