---
title: "Microsoft XML Serializer Generator"
description: An overview of the Microsoft XML Serializer Generator. Use the XML Serializer Generator to generate an XML serialization assembly for the types contained in your project.
author: honggit
ms.date: 04/23/2024
ms.topic: tutorial
ms.custom: "mvc"
---
# Use Microsoft XML Serializer Generator on .NET Core

In this tutorial, you learn how to use the Microsoft XML Serializer Generator in a C# application. During the course of this tutorial, you learn:

> [!div class="checklist"]
>
> - How to create a .NET console app
> - How to add a reference to the Microsoft.XmlSerializer.Generator package
> - How to edit your MyApp.csproj to add dependencies
> - How to add a class and an XmlSerializer
> - How to build and run the application

Like the [Xml Serializer Generator (sgen.exe)](../../standard/serialization/xml-serializer-generator-tool-sgen-exe.md) for .NET Framework, the [Microsoft.XmlSerializer.Generator NuGet package](https://www.nuget.org/packages/Microsoft.XmlSerializer.Generator) is the equivalent for .NET Core/.NET 5+ and .NET Standard projects. It creates an XML serialization assembly for types contained in an assembly to improve the startup performance of XML serialization when serializing or de-serializing objects of those types using <xref:System.Xml.Serialization.XmlSerializer>.

## Prerequisites

To complete this tutorial:

- [.NET Core 2.1 SDK](https://dotnet.microsoft.com/download) or later.
- Your favorite code editor.

> [!TIP]
> Need to install a code editor? Try [Visual Studio](https://aka.ms/vsdownload?utm_source=mscom&utm_campaign=msdocs)!

The following instructions show you how to use XML Serializer Generator in a .NET Core console application.

## Create the app

1. Open a command prompt and create a folder named *MyApp*. Navigate to the folder you created and type the following command:

   ```dotnetcli
   dotnet new console
   ```

2. Use the [`dotnet package add`](../tools/dotnet-package-add.md) command to add a reference to the Microsoft.XmlSerializer.Generator package.

   ```dotnetcli
   dotnet package add Microsoft.XmlSerializer.Generator -v 8.0.0
   ```

   After running the [`dotnet package add`](../tools/dotnet-package-add.md) command, the following lines are added to your *MyApp.csproj* project file:

   ```xml
   <ItemGroup>
      <PackageReference Include="Microsoft.XmlSerializer.Generator" Version="8.0.0" />
   </ItemGroup>
   ```

3. Add a tool reference by adding the following `ItemGroup` section to your project file.

   ```xml
   <ItemGroup>
      <DotNetCliToolReference Include="Microsoft.XmlSerializer.Generator" Version="8.0.0" />
   </ItemGroup>
   ```

4. Open *Program.cs* in your text editor. Add a class named *MyClass* in *Program.cs*.

   ```csharp
   public class MyClass
   {
      public int Value;
   }
   ```

5. Create an `XmlSerializer` for `MyClass`. Add the following line to the *Program.cs* file:

   ```csharp
   var serializer = new System.Xml.Serialization.XmlSerializer(typeof(MyClass));
   ```

6. Build and run the application. Run the application via [`dotnet run`](../tools/dotnet-run.md):

   ```dotnetcli
   dotnet run
   ```

   The app automatically loads and uses the pre-generated serializers at run time.

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

- [Introducing XML Serialization](../../standard/serialization/introducing-xml-serialization.md)
- [How to serialize using XmlSerializer (C#)](../../standard/linq/serialize-xmlserializer.md)
- [How to: Serialize Using XmlSerializer (Visual Basic)](../../standard/linq/serialize-xmlserializer.md)
