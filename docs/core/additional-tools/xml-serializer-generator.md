---
title: "Microsoft XML Serializer Generator"
description: An overview of the Microsoft XML Serializer Generator. Use the XML Serializer Generator to generate an XML serialization assembly for the types contained in your project.
author: adegeo
ms.date: 04/27/2026
ms.topic: tutorial
---
# Use Microsoft XML Serializer Generator on .NET

In this tutorial, you learn how to use the Microsoft XML Serializer Generator in a C# application. During the course of this tutorial, you learn:

> [!div class="checklist"]
>
> - How to create a .NET console app
> - How to add a reference to the Microsoft.XmlSerializer.Generator package
> - How to edit your MyApp.csproj to add dependencies
> - How to add a class and an XmlSerializer
> - How to build and run the application

Like the [XML Serializer Generator (sgen.exe)](../../standard/serialization/xml-serializer-generator-tool-sgen-exe.md) for .NET Framework, the [Microsoft.XmlSerializer.Generator NuGet package](https://www.nuget.org/packages/Microsoft.XmlSerializer.Generator) is the equivalent for modern .NET. It creates an XML serialization assembly for types contained in an assembly to improve the startup performance of XML serialization when serializing or deserializing objects of those types using <xref:System.Xml.Serialization.XmlSerializer>.

## Prerequisites

To complete this tutorial:

- [.NET 8 SDK](https://dotnet.microsoft.com/download) or later.
- Your favorite code editor.

> [!TIP]
> Need to install a code editor? Try [Visual Studio](https://aka.ms/vsdownload?utm_medium=microsoft&utm_source=learn.microsoft.com&utm_campaign=inline+link).

The following instructions show you how to use XML Serializer Generator in a .NET console application.

## Create the app

1. Open a command prompt and create a folder named *MyApp*. Navigate to the folder you created and type the following command:

   ```dotnetcli
   dotnet new console
   ```

1. Add a reference to the Microsoft.XmlSerializer.Generator package.

   ```dotnetcli
   dotnet add package Microsoft.XmlSerializer.Generator -v 10.0.0
   ```

   After running this command, the following lines are added to your *MyApp.csproj* project file:

   ```xml
   <ItemGroup>
      <PackageReference Include="Microsoft.XmlSerializer.Generator" Version="10.0.0" />
   </ItemGroup>
   ```

1. Open *Program.cs* in your text editor. Add a class named *MyClass* in *Program.cs*.

   ```csharp
   public class MyClass
   {
      public int Value;
   }
   ```

1. Create an `XmlSerializer` for `MyClass`. Add the following line to the *Program.cs* file:

   ```csharp
   var serializer = new System.Xml.Serialization.XmlSerializer(typeof(MyClass));
   ```

1. Build and run the application. Run the application via [`dotnet run`](../tools/dotnet-run.md):

   ```dotnetcli
   dotnet run
   ```

   The app automatically loads and uses the pregenerated serializers at runtime.

   > [!TIP]
   > [`dotnet run`](../tools/dotnet-run.md) calls [`dotnet build`](../tools/dotnet-build.md) to ensure that the build targets have been built, and then calls `dotnet <assembly.dll>` to run the target application.

> [!IMPORTANT]
> The commands and steps shown in this tutorial to run your application are used during development time only. Once you're ready to deploy your app, take a look at the different [deployment strategies](../deploying/index.md) for .NET apps and the [`dotnet publish`](../tools/dotnet-publish.md) command.

If everything succeeds, an assembly named *MyApp.XmlSerializers.dll* is generated in the output folder.

Congratulations! You have just:
> [!div class="checklist"]
>
> - Created a .NET console app.
> - Added a reference to the Microsoft.XmlSerializer.Generator package.
> - Edited your MyApp.csproj to add dependencies.
> - Added a class and an XmlSerializer.
> - Built and run the application.

## Further customize XML serialization assembly (optional)

Add the following XML to your *MyApp.csproj* to further customize assembly generation:

```xml
<PropertyGroup>
    <SGenReferences>C:\myfolder\abc.dll;C:\myfolder\def.dll</SGenReferences>
    <SGenTypes>MyApp.MyClass;MyApp.MyClass1</SGenTypes>
    <SGenProxyTypes>false</SGenProxyTypes>
    <SGenVerbose>true</SGenVerbose>
    <SGenKeyFile>mykey.snk</SGenKeyFile>
    <SGenDelaySign>true</SGenDelaySign>
</PropertyGroup>
```

## Related resources

- [Introducing XML serialization](../../standard/serialization/introducing-xml-serialization.md)
- [How to serialize using XmlSerializer](../../standard/linq/serialize-xmlserializer.md)
