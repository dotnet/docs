---
title: Using Microsoft XML Serializer Generator on .NET Core
description: An overview of the Microsoft XML Serializer Generator.
author: mlacouture
manager: wpickett
ms.author: johalex
ms.date: 01/19/2017
ms.topic: tutorial
ms.prod: .net-core
ms.custom: mvc
---
# Using Microsoft XML Serializer Generator on .NET Core

This tutorial teaches you how to use the Microsoft XML Serializer Generator in a C# .NET Core application. During the course of this tutorial, you learn:

> [!div class="checklist"]
> * How to create a .NET Core app
> * How to add a reference to the Microsoft.XmlSerializer.Generator package
> * How to edit your MyApp.csproj to add dependencies
> * How to add a class and an XmlSerializer
> * How to build and run the application 

Like the [Xml Serializer Generator (sgen.exe)](../../standard/serialization/xml-serializer-generator-tool-sgen-exe.md) for the .NET Framework, the [Microsoft.XmlSerializer.Generator NuGet package](https://www.nuget.org/packages/Microsoft.XmlSerializer.Generator) is the equivalent for .NET Core and .NET Standard projects. It creates an XML serialization assembly for types contained in an assembly to improve the startup performance of XML serialization when serializing or de-serializing objects of those types using <xref:System.Xml.Serialization.XmlSerializer>.

## Prerequisites

To complete this tutorial:

* Install [.NET Core SDK 2.1.3 or later](https://www.microsoft.com/net/download)
* Install your favorite code editor, if you haven't already.

> [!TIP]
> Need to install a code editor? Try [Visual Studio](https://aka.ms/vsdownload?utm_source=mscom&utm_campaign=msdocs)!
  
## Use Microsoft XML Serializer Generator in a .NET Core console application 

The following instructions show you how to use XML Serializer Generator in a .NET Core console application.

### Create a .NET Core console application

Open a command prompt and create a folder named *MyApp*. Navigate to the folder you created and type the following command:

```console
dotnet new console
```

### Add a reference to the Microsoft.XmlSerializer.Generator package in the MyApp project

Use the [`dotnet add package`](../tools//dotnet-add-package.md) command to add the reference in your project. 

Type:
 
 ```console
 dotnet add package Microsoft.XmlSerializer.Generator -v 1.0.0
 ```
 
### Verify changes to MyApp.csproj after adding the package

Open your code editor and let's get started! We're still working from the *MyApp* directory we built the app in.

Open *MyApp.csproj* in your text editor.

After running the [`dotnet add package`](../tools//dotnet-add-package.md) command, the following lines are added to your *MyApp.csproj* project file:

 ```xml
 <ItemGroup>
    <PackageReference Include="Microsoft.XmlSerializer.Generator" Version="1.0.0" />
 </ItemGroup>
 ```
 
### Add another ItemGroup section for .NET Core CLI Tool support
 
 Add the following lines after the `ItemGroup` section that we inspected:
 
 ```xml
 <ItemGroup>
    <DotNetCliToolReference Include="Microsoft.XmlSerializer.Generator" Version="1.0.0" />
 </ItemGroup>
 ```
 
### Add a class in the application

Open *Program.cs* in your text editor. Add the class named *MyClass* in *Program.cs*.

```csharp
public class MyClass
{
   public int Value;
}
```

### Create an `XmlSerializer` for MyClass

Add the following line inside *Main* to create an `XmlSerializer` for MyClass:

```csharp
var serializer = new System.Xml.Serialization.XmlSerializer(typeof(MyClass));
```

### Build and run the application

Still within the *MyApp* folder, run the application via [`dotnet run`](../tools/dotnet-run.md) and it automatically loads and uses the pre-generated serializers at runtime.

Type the following command in your console window:

 ```console
 $ dotnet run
 ```
> [!NOTE]
> [`dotnet run`](../tools/dotnet-run.md) calls [`dotnet build`](../tools/dotnet-build.md) to ensure that the build targets have been built, and then calls `dotnet <assembly.dll>` to run the target application.

> [!IMPORTANT]
> The commands and steps shown in this tutorial to run your application are used during development time only. Once you're ready to deploy your app, take a look at the different [deployment strategies](../deploying/index.md) for .NET Core apps and the [`dotnet publish`](../tools/dotnet-publish.md) command.

If everything succeeds, an assembly named *MyApp.XmlSerializers.dll* is generated in the output folder. 



Congratulations! You have just:
> [!div class="checklist"]
> * Created a .NET Core app.
> * Added a reference to the Microsoft.XmlSerializer.Generator package.
> * Edited your MyApp.csproj to add dependencies.
> * Added a class and an XmlSerializer.
> * Built and ran the application. 

## Related Resources

* [Introducing XML Serialization](../../standard/serialization/introducing-xml-serialization.md)
* [How to: Serialize Using XmlSerializer (C#)](../../csharp/programming-guide/concepts/linq/how-to-serialize-using-xmlserializer.md)
* [How to: Serialize Using XmlSerializer (Visual Basic)](../../visual-basic/programming-guide/concepts/linq/how-to-serialize-using-xmlserializer.md)
