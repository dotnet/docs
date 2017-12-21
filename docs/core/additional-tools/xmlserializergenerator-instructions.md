title: Using Microsoft XML Serializer Generator on .NET Core
description: An overview of the Microsoft XML Serializer Generator.
author: mlacouture
manager: wpickett
ms.author: johalex
ms.date: 12/20/2017
ms.topic: tutorial
ms.prod: .net-core
ms.custom: mvc
---
# Using Microsoft XML Serializer Generator on .NET Core

This tutorial teaches you how to use the Microsoft XML Serializer Generator in a C# .NET Core application. During the course of this tutorial, you learn:

> [!div class="checklist"]
> * How to create a .NET Core app.
> * How to add a reference to the Microsoft.XmlSerializer.Generator package
> * How to edit your MyApp.csproj to add dependencies.
> * How to add a class and an XmlSerializer
> * How to build and run the application 

Like the [Xml Serializer Generator (sgen.exe)](https://docs.microsoft.com/en-us/dotnet/standard/serialization/xml-serializer-generator-tool-sgen-exe) for .NET Framework, <xref:System.Xml.Serialization.XmlSerializer> NuGet package is the equivalent for .NET Core and .NET Standard Libraries. It creates an XML serialization assembly for types contained in an assembly to improve the startup performance of XML serialization when serializing or de-serializing objects of those types using XmlSerializer.

You can start using the tool today following the instructions below. 

## Prerequisites

To complete this tutorial:

* [.NET Core SDK 2.1.3 or later](https://www.microsoft.com/net/download/windows)
* Install your favorite code editor, if you haven't already.

> [!TIP]
> Need to install a code editor? Try [Visual Studio](https://visualstudio.com/downloads)!
  
## Use Microsoft XML Serializer Generator in a .NET Core console application 

Here are the step by step instructions on how to use XML Serializer Generator in a .NET Core console application.

### Create a .NET Core console application

Open a command prompt and create a folder named *MyApp*. Navigate to the folder you created and type the following commands:

```console
dotnet new console --name MyApp
```

### Add a reference to the Microsoft.XmlSerializer.Generator package in the MyApp project.

 Type:
 
 ```console
 dotnet add MyApp package Microsoft.XmlSerializer.Generator -v 1.0.0-preview1-25915-02
 ```
 
### Edit MyApp.csproj 

Open your text editor and let's get started! We're still working from the *MyApp* directory we built the app in.

Add the following lines in *MyApp.csproj*.

 ```xml
 <ItemGroup>
    <DotNetCliToolReference Include="Microsoft.XmlSerializer.Generator" Version="1.0.0-preview1-25915-02" />
 </ItemGroup>
 ```
 
### Add a class in the application. 

Open *Program.cs* in your text editor. Add the class named *MyClass* in *Program.cs*.

```c#
public class MyClass
 {
    public int Value;
 }
```    

### Create an `XmlSerializer` for MyClass.  

Add the following line inside *MyClass*

```c#
var serializer = new System.Xml.Serialization.XmlSerializer(typeof(MyClass));
```    

### Build and run the application

   [`dotnet run`](../tools/dotnet-run.md) calls [`dotnet build`](../tools/dotnet-build.md) to ensure that the build targets have been built, and then calls `dotnet <assembly.dll>` to run the target application.

Run the application and it will automatically load and use the pre-generated serializers at runtime.

 ```console
 $ dotnet run
 ```

If everything succeeds, an assembly named *MyApp.XmlSerializers.dll* will be generated in the output folder. You will see warnings in the build output if the tool failed to generate the assembly.

Congratulations! you have just:
> [!div class="checklist"]
> * Create a .NET Core app.
> * Added a reference to the Microsoft.XmlSerializer.Generator package
> * Edited your MyApp.csproj to add dependencies.
> * Added a class and an XmlSerializer
> * Built and ran the application 
