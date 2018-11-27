---
title: Using dotnet-svcutil.xmlserializer on .NET Core
description: 
author: huanwu
ms.date: 10/29/2018
---
# Using dotnet-svcutil.xmlserializer on .NET Core

## Prerequisites

The following is required for dotnet-svcutil.xmlserializer to work. 

* [.NET Core SDK 2.1 or later](https://www.microsoft.com/net/download/dotnet-core/sdk-2.1.300)
* [.NET Core Runtime 2.1 or later](https://www.microsoft.com/net/download/dotnet-core/runtime-2.1.0)

You can use the command `dotnet --info` to check which versions of .NET Core SDK and runtime you already have installed.

To use dotnet-svcutil.xmlserializer in a .NET Core console application:

1. Create a WCF Service named 'MyWCFService' using the default template 'WCF Service Application' in .NET Framework.  Add `[XmlSerializerFormat]` attribute on the service method like the following:

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
    
```console
dotnet new console --name MyWCFClient
```

Make sure your csproj targets a netcoreapp 2.1. This is done using the following XML element in your .csproj file:
    
```xml
<TargetFramework>netcoreapp2.1</TargetFramework>
```

3. Add a package reference to System.ServiceModel.Http by running the following command:
   
```console
dotnet add package System.ServiceModel.Http -v 4.5.0
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

5. Edit the .csproj file and add a reference to the dotnet-svcutil.xmlserializer package. For example:

  i. Run command: 
  
  ```console
  dotnet add package dotnet-svcutil.xmlserializer -v 1.0.0
  ```

  ii. Add the following lines in *MyWCFClient.csproj*:
  
  ```xml
  <ItemGroup>
    <DotNetCliToolReference Include="dotnet-svcutil.xmlserializer" Version="1.0.0" />
  </ItemGroup>
  ```

6. Build the application by running `dotnet build`. If everything succeeds, an assembly named *MyWCFClient.XmlSerializers.dll* is generated in the output folder. If the tool failed to generate the assembly, you'll see warnings in the build output.

7. Start the WCF service by, for example, running `http://localhost:2561/Service1.svc` in the browser. Then start the client application, and it'll automatically load and use the pre-generated serializers at runtime.
