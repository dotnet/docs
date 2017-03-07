---
title: Organizing and testing projects with the .NET Core command line | Microsoft Docs
description: This tutorial explains how to organize and test .NET Core projects from the command line.
keywords: .NET, .NET Core
author: cartermp
ms.author: mairaw
ms.date: 03/07/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 52ff1be3-d92e-4477-9c84-8c1771e87ab5
---

# Organizing and testing projects with the .NET Core command line

> [!WARNING]
> This topic hasn't been updated to the latest version of the tooling yet.

This tutorial follows [Getting started with .NET Core on Windows/Linux/macOS using the command line(./using-with-xplat-cli-msbuild.md) to show how to go beyond simple "Hello world!" scenarios and pave the way for more advanced and well-organized applications.

## Using folders to organize code

Say you wanted to introduce some new types to do work on. You can do this by adding more files and making sure to give them namespaces you can include in your *Program.cs* file.

```
/MyProject
|__Program.cs
|__AccountInformation.cs
|__MonthlyReportRecords.cs
|__MyProject.csproj
```

This works great when the size of your project is relatively small. However if you have a larger app with many different data types and potentially multiple layers, you may wish to organize things logically. This is where folders come into play. You can either follow along with [the NewTypes sample project](https://github.com/dotnet/docs/tree/master/samples/core/console-apps/NewTypesMsBuild) that this guide covers, or create your own files and folders.

To begin, create a new folder under the root of your project. `/Model` is chosen here.

```
/NewTypes
|__/Model
|__Program.cs
|__NewTypes.csproj
```

Now add some new types to the folder:

```
/NewTypes
|__/Model
   |__AccountInformation.cs
   |__MonthlyReportRecords.cs
|__Program.cs
|__NewTypes.csproj
```

Now, just as if they were files in the same directory, give them all the same namespace so you can include them in your `Program.cs`.

### Example: Pet Types

This example creates two new types, `Dog` and `Cat`, and has them implement a common interface, `IPet`.

Folder Structure:

```
/NewTypes
|__/Pets
   |__Dog.cs
   |__Cat.cs
   |__IPet.cs
|__Program.cs
|__NewTypes.csproj
```

`IPet.cs`:
```csharp
using System;

namespace Pets
{
	public interface IPet
	{
		string TalkToOwner();
	}
}
```

`Dog.cs`:
```csharp
using System;

namespace Pets
{
	public class Dog : IPet
	{
		public string TalkToOwner() => "Woof!";
	}
}
```

`Cat.cs`:
```csharp
using System;

namespace Pets
{
	public class Cat : IPet
	{
		public string TalkToOwner() => "Meow!";
	}
}
```

`Program.cs`:
```csharp
using System;
using Pets;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<IPet> pets = new List<IPet>
            {
                new Dog(),
                new Cat()  
            };
            
            foreach (var pet in pets)
            {
                Console.WriteLine(pet.TalkToOwner());
            }
        }
    }
}
```

`NewTypes.csproj`:
```xml
<Project ToolsVersion="15.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" />
  
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp1.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <Compile Include="**\*.cs" />
    <EmbeddedResource Include="**\*.resx" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.NETCore.App">
      <Version>1.0.1</Version>
    </PackageReference>
    <PackageReference Include="Microsoft.NET.Sdk">
      <Version>1.0.0-alpha-20161104-2</Version>
      <PrivateAssets>All</PrivateAssets>
    </PackageReference>
  </ItemGroup>
  
  <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
</Project>
```

And if you run this:

```
$ dotnet restore
$ dotnet run
Woof!
Meow!
```

New pet types can be added (such as a `Bird`), extending this project.

## Testing your Console App

You'll probably be wanting to test your projects at some point. Here's a good way to do it:

1. Move any source of your existing project into a new `src` folder.

   ```
   /Project
   |__/src
   ```

2. Create a `/test` directory, then `cd` into it.

   ```
   /Project
   |__/src
   |__/test
   ```

3. Initialize the directory with a `dotnet new xunit` command. This assumes xUnit, but you can also use MSTest by replacing `xunit` with `mstest`.
   
### Example: Extending the NewTypes project

Now that the project system is in place, you can create your test project and start writing tests! From here on out, this guide will use and extend [the sample Types project](https://github.com/dotnet/docs/tree/master/samples/core/console-apps/NewTypesMsBuild). Additionally, it will use the [Xunit](https://xunit.github.io/) test framework. Feel free to follow along or create your own multi-project system with tests.

The whole project structure should look like this:

```
/NewTypes
|__/src
   |__/NewTypes
      |__/Pets
         |__Dog.cs
         |__Cat.cs
         |__IPet.cs
      |__Program.cs
      |__NewTypes.csproj
|__/test
   |__NewTypesTests
      |__PetTests.cs
      |__NewTypesTests.csproj
```

There are two new things to make sure you have in your test project:

1. A correct *NewTypesTests.csproj* file with the following:

   * A reference to `xunit`
   * A reference to `dotnet-test-xunit`
   * A reference to the namespace corresponding to the code under test

   This can be built by typing `dotnet new xunit` at a command prompt in the *NewTypesTests* directory, then adding a project reference to the `NewTypes` project.

    `NewTypesTests/NewTypesTests.csproj`:
    ```xml
    <Project ToolsVersion="15.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
      <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" />

      <PropertyGroup>
        <OutputType>Exe</OutputType>
        <TargetFramework>netcoreapp1.0</TargetFramework>
      </PropertyGroup>

      <ItemGroup>
        <Compile Include="**\*.cs" />
        <EmbeddedResource Include="**\*.resx" />
      </ItemGroup>

      <ItemGroup>
        <PackageReference Include="Microsoft.NETCore.App">
          <Version>1.0.1</Version>
        </PackageReference>
        <PackageReference Include="Microsoft.NET.Sdk">
          <Version>1.0.0-alpha-20161104-2</Version>
          <PrivateAssets>All</PrivateAssets>
        </PackageReference>
        <PackageReference Include="Microsoft.NET.Test.Sdk">
          <Version>15.0.0-preview-20161024-02</Version>
        </PackageReference>
        <PackageReference Include="xunit">
          <Version>2.2.0-beta3-build3402</Version>
        </PackageReference>
        <PackageReference Include="xunit.runner.visualstudio">
          <Version>2.2.0-beta4-build1188</Version>
        </PackageReference>
        <ProjectReference Include="../../src/NewTypes/NewTypes.csproj"/>
      </ItemGroup>

      <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
    </Project>
    ```

2. An xUnit test class.

    `PetTests.cs`: 
    ```csharp
    using System;
    using Xunit;
    using Pets;
    public class PetTests
    {
        [Fact]
        public void DogTalkToOwnerTest()
        {
            string expected = "Woof!";
            string actual = new Dog().TalkToOwner();
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void CatTalkToOwnerTest()
        {
            string expected = "Meow!";
            string actual = new Cat().TalkToOwner();
            
            Assert.Equal(expected, actual);
        }
    }
    ```
   
Now you can run tests! The [`dotnet test`](../tools/dotnet-test.md) command runs the test runner you have specified in your project. Make sure you start at the top-level directory.
 
```
$ cd test/NewTypesTests
$ dotnet restore
$ dotnet test
```
 
Output should look like this:
 
```
xUnit.net .NET CLI test runner (64-bit win10-x64)
  Discovering: NewTypesTests
  Discovered:  NewTypesTests
  Starting:    NewTypesTests
  Finished:    NewTypesTests
=== TEST EXECUTION SUMMARY ===
   NewTypesTests  Total: 2, Errors: 0, Failed: 0, Skipped: 0, Time: 0.144s
SUMMARY: Total: 1 targets, Passed: 1, Failed: 0.
```
