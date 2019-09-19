---
title: Using dotnet-svcutil.xmlserializer on .NET Core
description: Learn how you can use the `dotnet-svcutil.xmlserializer` NuGet package to pre-generate a serialization assembly for .NET Core projects.
author: huanwu
ms.date: 11/27/2018
---
# Using dotnet-svcutil.xmlserializer on .NET Core

The `dotnet-svcutil.xmlserializer` NuGet package can pre-generate a serialization assembly for .NET Core projects. It pre-generates C# serialization code for the types in the client application that are used by the WCF Service Contract and that can be serialized by the XmlSerializer. This improves the startup performance of XML serialization when serializing or deserializing objects of those types.

## Prerequisites

* [.NET Core 2.1 SDK](https://dotnet.microsoft.com/download) or later
* Your favorite code editor

You can use the command `dotnet --info` to check which versions of .NET Core SDK and runtime you already have installed.

## Getting started

To use `dotnet-svcutil.xmlserializer` in a .NET Core console application:

1. Create a WCF Service named 'MyWCFService' using the default template 'WCF Service Application' in .NET Framework. Add `[XmlSerializerFormat]` attribute on the service method like the following:

   ```csharp
    [ServiceContract]
    public interface IService1
    {
        [XmlSerializerFormat]
        [OperationContract(Action = "http://tempuri.org/IService1/GetData", ReplyAction = "http://tempuri.org/IService1/GetDataResponse")]
        string GetData(int value);
    }
    ```

2. Create a .NET Core console application as WCF client application that targets at .NET Core 2.1 or later versions. For example, create an app named 'MyWCFClient' with the following command:

    ```dotnetcli
    dotnet new console --name MyWCFClient
    ```

    To ensure your project is targeting .NET Core 2.1 or later, inspect the `TargetFramework` XML element in your project file:

    ```xml
    <TargetFramework>netcoreapp2.1</TargetFramework>
    ```

3. Add a package reference to `System.ServiceModel.Http` by running the following command:

    ```dotnetcli
    dotnet add package System.ServiceModel.Http
    ```

4. Add the WCF Client code:

    ```csharp
    using System.ServiceModel;

        class Program
        {
            static void Main(string[] args)
            {
                var myBinding = new BasicHttpBinding();
                var myEndpoint = new EndpointAddress("http://localhost:2561/Service1.svc"); //Fill your service url here
                var myChannelFactory = new ChannelFactory<IService1>(myBinding, myEndpoint);
                IService1 client = myChannelFactory.CreateChannel();
                string s = client.GetData(1);
                ((ICommunicationObject)client).Close();
            }
        }

    [ServiceContract]
    public interface IService1
    {
        [XmlSerializerFormat]
        [OperationContract(Action = "http://tempuri.org/IService1/GetData", ReplyAction = "http://tempuri.org/IService1/GetDataResponse")]
        string GetData(int value);
    }
    ```

5. Add a reference to the `dotnet-svcutil.xmlserializer` package by running the following command:
  
    ```dotnetcli
    dotnet add package dotnet-svcutil.xmlserializer
    ```

    Running the command should add an entry to your project file similar to this:
  
    ```xml
    <ItemGroup>
      <DotNetCliToolReference Include="dotnet-svcutil.xmlserializer" Version="1.0.0" />
    </ItemGroup>
    ```

6. Build the application by running `dotnet build`. If everything succeeds, an assembly named *MyWCFClient.XmlSerializers.dll* is generated in the output folder. If the tool failed to generate the assembly, you'll see warnings in the build output.

7. Start the WCF service by, for example, running `http://localhost:2561/Service1.svc` in the browser. Then start the client application, and it will automatically load and use the pre-generated serializers at runtime.
