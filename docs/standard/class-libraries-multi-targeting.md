---
title: .NET Class Library Multi-Targeting
description: Learn how to create .NET class libraries for multiple .NET platforms that can access and wrap platform-specific functionality.
keywords: .NET, .NET Core
author: immol
ms.author: mairaw
ms.date: 03/19/2018
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 375da522-3520-4735-b1de-68c7b71719d5
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---

# Introduction

.NET Standard 2.0 offers an extensive API surface that can be shared across .NET
applications. There are situations where you may need to access platform
specific APIs that are not part of .NET Standard (for instance, you might want
to pop UI for starting an OAuth flow). In those cases you often want to build a
.NET Standard wrapper to encapsulate framework- or OS-specific functionality
(for example, the geolocation APIs).

You can do this via [multi-targeting](frameworks.md) which builds your project
for multiple framework from a single project. This enables you to use
conditional compilation with `#if` to call framework specific APIs.

Please note that this topic is primarily about libraries. For application
development we generally recommend to use multiple projects (one per
application) and sharing code via Shared Projects.

# Multi-targeting

.NET Standard projects start as targeting a single framework, namely a specific
version of .NET Standard:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>netstandard2.0</TargetFramework>
  </PropertyGroup>

</Project>
```

In order to target multiple frameworks, you need to change the name of the
property from `TargetFramework` to the plural form `TargetFrameworks`. Then you
can add all the desired frameworks as a semicolon separated list:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFrameworks>netstandard2.0;net461;netcoreapp2.0</TargetFrameworks>
  </PropertyGroup>

</Project>
```

Please note that you can also target multiple versions of the same framework.
For example, you can target both `netstandard1.0` and `netstandard2.0`. This
way, your library can be consumed from frameworks that only support .NET
Standard 1.0 while you can still offer more features for customers having access
to a framework that implements a later version of the standard.

For a list of all supported frameworks see [Target frameworks](frameworks.md).

In this configuration the project will be built multiple times, once per each
target framework. This means the project is actually producing multiple output
binaries, one per target framework. This allows you to configure the project
independently for each target framework, including properties, references, and
source files.

> [!NOTE]
> Multi-targeting is very powerful in that allows you to have different
> conditional compilation symbols for `#if`, different source files, and also
> different references. But that also means that inside of Visual Studio the
> overhead of each target framework is about the same as for a regular project.
> Thus, only add as many target frameworks as you actually need.

## Compile different code using `#if`

One of the primary reasons to multi-target is to use different code for
different frameworks. In C# this can be done using *conditional compilation*.
When you use multi-targeting the build automatically defined conditional
compilation symbols you can use from C#:

```csharp
public class MyClass
{
    static void Main()
    {
#if NETSTANDARD2_0
        Console.WriteLine("Target framework: .NET Standard 2.0");
#elif NET461  
        Console.WriteLine("Target framework: .NET Framework 4.6.1");
#elif NETCOREAPP2_0  
        Console.WriteLine("Target framework: .NET Core 2.0");
#else    
    #error Unknown target framework.
#endif
    }
}
```

For a list of automatically configured conditional compilation symbols see
[How to specify target frameworks](frameworks.md#how-to-specify-target-frameworks).

## Configuring different references

When writing different code for different framework you often find yourself
needing to reference different assemblies and/or package as well. You can do
this in the project file by adding conditions that constrain it to a specific
target framework:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFrameworks>netstandard2.0;net461;netcoreapp2.0</TargetFrameworks>
  </PropertyGroup>

  <!-- Package reference for all target frameworks -->

  <ItemGroup>
    <PackageReference Include="Newtonsoft.Json" Version="11.0.1" />
  <ItemGroup>

  <!-- Assembly reference just for .NET Framework -->

  <ItemGroup Condition="'$(TargetFramework)' == 'net461'">
    <Reference Include="System.Device" />
  <ItemGroup>

  <!-- Package reference just for .NET Core -->

  <ItemGroup Condition="'$(TargetFramework)' == 'netcoreapp2.0'">
    <PackageReference Include="Microsoft.Windows.CompatibilityDevice" Version="2.0.0-preview1-26216-02" />
  <ItemGroup>

</Project>
```

> [!NOTE]
> You can also put the `Condition` attribute directly on the `Reference` and
> `PackageReference` elements but to allow adding multiple references per
> framework it's often easier to maintain if you put them on the `ItemGroup`
> instead. This way, the condition isn't duplicated and all framework-specific
> references are unified under a single node.

## Compile different code using partial classes

Since multi-targeting is really just fancy way to say that your project is built
multiple times you can also define your own conventions in your project file
using conditions. For instance, you could configure it so that depending on the
platform you're building fir you include different source files, for example
like this:

```xml
  <!-- Disable default compile items -->

  <PropertyGroup>
    <EnableDefaultCompileItems>false</EnableDefaultCompileItems>
  </PropertyGroup>

  <!-- Include all source files except the framework specific ones -->

  <ItemGroup>
    <Compile Include="**\*.cs"
             Exclude="**\*.netstandard.cs;**\*.netfx.cs;**\*.netcore.cs" />
  </ItemGroup>

  <!-- Conditionally include framework specific source files -->

  <ItemGroup Condition=" $(TargetFramework.StartsWith('netstandard')) ">
    <Compile Include="**\*.netstandard.cs" />
  </ItemGroup>
  <ItemGroup Condition=" $(TargetFramework.StartsWith('net4')) ">
    <Compile Include="**\*.netfx.cs" />
  </ItemGroup>
  <ItemGroup Condition=" $(TargetFramework.StartsWith('netcoreapp')) ">
    <Compile Include="**\*.netcore.cs" />
  </ItemGroup>
```

Instead of using `#if` you can now use `partial` classes and indicate via the
filename which target framework it's applicable too:

```csharp
// MyClass.netstandard.cs
public partial class MyClass
{
    static void SayHello()
    {
        Console.WriteLine("Hello from .NET Standard!");
    }
}
```

```csharp
// MyClass.netfx.cs
public partial class MyClass
{
    static void SayHello()
    {
        Console.WriteLine("Hello from .NET Framework!");
    }
}
```

```csharp
// MyClass.netcore.cs
public partial class MyClass
{
    static void SayHello()
    {
        Console.WriteLine("Hello from .NET Core");
    }
}
```

This is similar to what [Project Caboodle](https://github.com/xamarin/Caboodle)
is doing. Project Caboodle provides developers essential cross-platform APIs for
their mobile applications via a .NET Standard-based wrapper.

## NuGet Packages

Multi-targeting has to produce one binary per framework. If you only use project
references within your solution you don't need to worry about that -- it's
basically an implementation detail.

But if you need to share your library outside of your solution this becomes a
problem as consumers have to pick the correct one. To solve this problem we
recommend that you produce a NuGet package. This will produce a single package
containing all the binaries. Consumers simply reference the package and during
build the appropriate binary is selected, depending on the target framework of
the consuming project.

To produce a NuGet package you need to configure your project accordingly. You
can do this in Visual Studio by right clicking the project and selecting
**Properties**. On the **Package** tab you need to check the box labelled
**Generate NuGet package on build**.

You can also enable package generation by editing the project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <GeneratePackageOnBuild>true</GeneratePackageOnBuild>
  </PropertyGroup>

</Project>
```

# Best practices

When doing multiple targeting it's important to follow a set of rules in order
to ensure you and the consumers of your code have a great experience:

* **DO** start with .NET Standard 2.0. Most general purpose libraries will not
  need APIs outside this set.

* **CONSIDER** adding framework specific implementations if you need to call
  APIs outside the .NET Standard API set.

* **CONSIDER** using multi-targeting over multiple projects when you need to add
  platform specific outputs in libraries.

* **CONSIDER** using the community package `MSBuild.Sdk.Extras` when using
  multi-targeting. It adds a bunch of properties and targets that don't exist in
  MSBuild and keeps your project files lean & clean.

* **CONSIDER** using multiple projects over multi-targeting when you need to add
  platform specific outputs for applications.

* **DO NOT** drop support for .NET Standard when producing libraries for
  multiple frameworks. Instead, throw from the implementation and offer
  capability APIs. This shields your consumers from having to target multiple
  frameworks as well. And should you add support for new frameworks later on,
  your consumers run in more places without having to change their code.

* **DO** throw `PlatformNotSupportedException` when you cannot provide a
  meaningful implementation for .NET Standard.

* **DO** provide capability APIs for features that can throw
  `PlatformNotSupportedException`. This allows consumers to use optional
  features without having to catch exceptions.

* **DO** share your component using a single NuGet package. It shields consumers
  from having to choose the appropriate binary.

## Not dropping support for .NET Standard

As a library author your goal is generally to encapsulate a piece of
functionality. As mentioned earlier, when doing multi-targeting you don't want
your customers having to understand which binary to select, which is why
recommend that you generate a NuGet package.

This also means you generally want to produce a .NET Standard output when you
use multi-targeting. This allows your consumers to be .NET Standard without
having to use multi-targeting. In other words, from your customer's point of
view they don't even have to be aware that you used multi-targeting -- it's
an implementation detail of your library.

This practice is often called *bait & switch*:

* **Bait**. The bait is offering a .NET Standard API. Your customer's library
  is compiled against this.

* **Switch**. Depending on the consuming application, the framework-specific
  library is being deployed.

Let's look at an project targeting .NET Standard 2.0, .NET Framework 4.6.1 and .NET 

* Ensure that the platform-specific implementation is a superset of .NET
  Standard
* That means you need to be binary compatible (do not use target-specific
  output names and keep the same namespace)
* It's OK to multi-target between versions too. This way, one doesn't drop
  platform support

---

**WORK IN PROGRESS**


## Capability checks

* Explain why they are useful

# Sample

* GPS sensor example
* Link to my video