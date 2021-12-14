---
title: Migrate a WCF request-reply service to gRPC - gRPC for WCF developers
description: Learn how to migrate a simple request-reply service from WCF to gRPC.
ms.date: 12/14/2021
---

# Migrate a WCF request-reply service to a gRPC unary RPC

This section covers how to migrate a basic request-reply service in WCF to a unary RPC service in ASP.NET Core gRPC. These services are the simplest service types in both Windows Communication Foundation (WCF) and gRPC, so it's an excellent place to start. After migrating the service, you'll learn how to generate a client library from the same `.proto` file to consume the service from a .NET client application.

## The WCF solution

The [PortfoliosSample solution](https://github.com/dotnet-architecture/grpc-for-wcf-developers/tree/main/PortfoliosSample/wcf/TraderSys) includes a simple request-reply Portfolio service to download either a single portfolio or all portfolios for a given trader. The service is defined in the interface `IPortfolioService` with a `ServiceContract` attribute:

```csharp
[ServiceContract]
public interface IPortfolioService
{
    [OperationContract]
    Task<Portfolio> Get(Guid traderId, int portfolioId);

    [OperationContract]
    Task<List<Portfolio>> GetAll(Guid traderId);
}
```

The `Portfolio` model is a simple C# class marked with [DataContract](xref:System.Runtime.Serialization.DataContractAttribute) and including a list of `PortfolioItem` objects. These models are defined in the `TraderSys.PortfolioData` project along with a repository class that represents a data access abstraction.

```csharp
[DataContract]
public class Portfolio
{
    [DataMember]
    public int Id { get; set; }

    [DataMember]
    public Guid TraderId { get; set; }

    [DataMember]
    public List<PortfolioItem> Items { get; set; }
}

[DataContract]
public class PortfolioItem
{
    [DataMember]
    public int Id { get; set; }

    [DataMember]
    public int ShareId { get; set; }

    [DataMember]
    public int Holding { get; set; }

    [DataMember]
    public decimal Cost { get; set; }
}
```

The `ServiceContract` implementation uses a repository class provided via dependency injection that returns instances of the `DataContract` types:

```csharp
public class PortfolioService : Protos.Portfolios.PortfoliosBase
{
    private readonly IPortfolioRepository _repository;

    public PortfolioService(IPortfolioRepository repository)
    {
        _repository = repository;
    }

    public async Task<Portfolio> Get(Guid traderId, int portfolioId)
    {
        return await _repository.GetAsync(traderId, portfolioId);
    }

    public async Task<List<Portfolio>> GetAll(Guid traderId)
    {
        return await _repository.GetAllAsync(traderId);
    }
}
```

## The portfolios.proto file

If you followed the instructions in the previous section, you should have a gRPC project with a `portfolios.proto` file that looks like this:

```protobuf
syntax = "proto3";

option csharp_namespace = "TraderSys.Portfolios.Protos";

package PortfolioServer;

service Portfolios {
  // RPCs will go here
}
```

The first step is to migrate the `DataContract` classes to their Protobuf equivalents.

## Convert the DataContract classes to gRPC messages

The `PortfolioItem` class will be converted to a Protobuf message first, because the `Portfolio` class depends on it. The class is simple, and three of the properties map directly to gRPC data types. The `Cost` property, which represents the price paid for the shares at purchase, is a `decimal` field. gRPC supports only `float` or `double` for real numbers, which aren't suitable for currency. Because share prices vary by a minimum of one cent, the cost can be expressed as an `int32` of cents.

> [!NOTE]
> Remember to use `snake_case` for field names in your `.proto` file. The C# code generator will convert them to `PascalCase` for you, and users of other languages will thank you for respecting their different coding standards.

```protobuf
message PortfolioItem {
    int32 id = 1;
    int32 share_id = 2;
    int32 holding = 3;
    int32 cost_cents = 4;
}
```

The `Portfolio` class is a little more complicated. In the WCF code, the developer used a `Guid` for the `TraderId` property, and contains a `List<PortfolioItem>`. In Protobuf, which doesn't have a first-class `UUID` type, you should use a `string` for the `traderId` field and parse it in your own code. For the list of items, use the `repeated` keyword on the field.

```protobuf
message Portfolio {
    int32 id = 1;
    string trader_id = 2;
    repeated PortfolioItem items = 3;
}
```

Now that you have the data messages, you can declare the service RPC endpoints.

## Convert ServiceContract to a gRPC service

The WCF `Get` method takes two parameters: `Guid traderId` and `int portfolioId`. gRPC service methods can take only a single parameter, so you need to create a message to hold the two values. It's common practice to name these request objects with the same name as the method followed by the suffix `Request`. Again, `string` is being used for the `traderId` field instead of `Guid`.

The service could just return a `Portfolio` message directly, but again, this could affect backward compatibility in the future. It's a good practice to define separate `Request` and `Response` messages for every method in a service, even if many of them are the same right now. So declare a `GetResponse` message with a single `Portfolio` field.

This example shows the declaration of the gRPC service method with the `GetRequest` message:

```protobuf
message GetRequest {
    string trader_id = 1;
    int32 portfolio_id = 2;
}

message GetResponse {
    Portfolio portfolio = 1;
}

service Portfolios {
    rpc Get(GetRequest) returns (GetResponse);
}
```

The WCF `GetAll` method takes only a single parameter, `traderId`, so it might seem that you could specify `string` as the parameter type. But gRPC requires a defined message type. This requirement helps to enforce the practice of using custom messages for all inputs and outputs, for future backward compatibility.

The WCF method also returns a `List<Portfolio>`, but for the same reason it doesn't allow simple parameter types, gRPC won't allow `repeated Portfolio` as a return type. Instead, create a `GetAllResponse` type to wrap the list.

> [!WARNING]
> You might be tempted to create a `PortfolioList` message or something similar and use it across multiple service methods, but you should resist this temptation. It's impossible to know how the various methods on a service will evolve, so keep their messages specific and cleanly separated.

```protobuf
message GetAllRequest {
    string trader_id = 1;
}

message GetAllResponse {
    repeated Portfolio portfolios = 1;
}

service Portfolios {
    rpc Get(GetRequest) returns (Portfolio);
    rpc GetAll(GetAllRequest) returns (GetAllResponse);
}
```

If you save your project with these changes, the gRPC build target will run in the background and generate all the Protobuf message types and a base class that you can inherit to implement the service.

Open the `Services/GreeterService.cs` class and delete the example code. Now you can add the Portfolio service implementation. The generated base class will be in the `Protos` namespace and is generated as a nested class. gRPC creates a static class with the same name as the service in the `.proto` file and a base class with the suffix `Base` inside that static class, so the full identifier for the base type is `TraderSys.Portfolios.Protos.Portfolios.PortfoliosBase`.

```csharp
namespace TraderSys.Portfolios.Services;

public class PortfolioService : Protos.Portfolios.PortfoliosBase
{
}
```

The base class declares `virtual` methods for `Get` and `GetAll` that can be overridden to implement the service. The methods are `virtual` rather than `abstract` so that if you don't implement them, the service can return an explicit gRPC `Unimplemented` status code, much like you might throw a `NotImplementedException` in regular C# code.

The signature for all gRPC unary service methods in ASP.NET Core is consistent. There are two parameters: the first is the message type declared in the `.proto` file, and the second is a `ServerCallContext` that works similarly to the `HttpContext` from ASP.NET Core. In fact, there's an extension method called `GetHttpContext` on the `ServerCallContext` class that you can use to get the underlying `HttpContext`, although you shouldn't need to use it often. We'll take a look at `ServerCallContext` later in this chapter, and also in the chapter that discusses authentication.

The method's return type is a `Task<T>`, where `T` is the response message type. All gRPC service methods are asynchronous.

## Migrate the PortfolioData library to .NET

At this point, the project needs the Portfolio repository and models contained in the `TraderSys.PortfolioData` class library in the WCF solution. The easiest way to bring them across is to create a new class library by using either the Visual Studio **New project** dialog box with the Class Library (.NET Standard) template, or from the command line by using the .NET CLI, running these commands from the directory that contains the `TraderSys.sln` file:

```dotnetcli
dotnet new classlib -o src/TraderSys.PortfolioData
dotnet sln add src/TraderSys.PortfolioData
```

After you've created the library and added it to the solution, delete the generated `Class1.cs` file and copy the files from the WCF solution's library into the new class library's folder, keeping the folder structure:

```
Models
  Portfolio.cs
  PortfolioItem.cs
IPortfolioRepository.cs
PortfolioRepository.cs
```

SDK-style .NET projects automatically include any `.cs` files in or under their own directory, so you don't need to explicitly add them to the project. The only step remaining is to remove the `DataContract` and `DataMember` attributes from the `Portfolio` and `PortfolioItem` classes so they're plain old C# classes:

```csharp
public class Portfolio
{
    public int Id { get; set; }
    public Guid TraderId { get; set; }
    public List<PortfolioItem> Items { get; set; }
}

public class PortfolioItem
{
    public int Id { get; set; }
    public int ShareId { get; set; }
    public int Holding { get; set; }
    public decimal Cost { get; set; }
}
```

## Use ASP.NET Core dependency injection

Now you can add a reference to this library to the gRPC application project and consume the `PortfolioRepository` class by using dependency injection in the gRPC service implementation. In the WCF application, dependency injection was provided by the Autofac IoC container. ASP.NET Core has dependency injection baked in. You can register the repository in the _Program.cs_ itself:

```csharp
using TraderSys.Portfolios.Services;

var builder = WebApplication.CreateBuilder(args);

// Register the repository class as a scoped service (instance per request)
builder.Services.AddScoped<IPortfolioRepository, PortfolioRepository>();

builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<PortfolioService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
```

The `IPortfolioRepository` implementation can now be specified as a constructor parameter in the `PortfolioService` class, as follows:

```csharp
public class PortfolioService : Protos.Portfolios.PortfoliosBase
{
    private readonly IPortfolioRepository _repository;

    public PortfolioService(IPortfolioRepository repository)
    {
        _repository = repository;
    }
}
```

## Implement the gRPC service

Now that you've declared your messages and your service in the `portfolios.proto` file, you have to implement the service methods in the `PortfolioService` class that inherits from the gRPC-generated `Portfolios.PortfoliosBase` class. The methods are declared as `virtual` in the base class. If you don't override them, they'll return a gRPC "Not Implemented" status code by default.

Start by implementing the `Get` method. The default override looks like this example:

```csharp
public override Task<GetResponse> Get(GetRequest request, ServerCallContext context)
{
    return base.Get(request, context);
}
```

The first problem is that `request.TraderId` is a string, and the service requires a `Guid`. Even though the expected format for the string is `UUID`, the code has to deal with the possibility that a caller has sent an invalid value and respond appropriately. The service can respond with errors by throwing an `RpcException` and use the standard `InvalidArgument` status code to express the problem:

```csharp
public override Task<GetResponse> Get(GetRequest request, ServerCallContext context)
{
    if (!Guid.TryParse(request.TraderId, out var traderId))
    {
        throw new RpcException(new Status(StatusCode.InvalidArgument, "traderId must be a UUID"));
    }

    return base.Get(request, context);
}
```

After there's a proper `Guid` value for `traderId`, you can use the repository to retrieve the Portfolio and return it to the client:

```csharp
    var response = new GetResponse
    {
        Portfolio = await _repository.GetAsync(request.TraderId, request.PortfolioId)
    };
```

### Map internal models to gRPC messages

The previous code doesn't actually work because the repository is returning its own POCO model `Portfolio`, but gRPC needs its own Protobuf message `Portfolio`. As when you map Entity Framework types to data transfer types, the best solution is to provide a conversion between the two. A good place to put the code for this conversion is in the Protobuf-generated class, which is declared as a `partial` class so it can be extended:

```csharp
namespace TraderSys.Portfolios.Protos;

public partial class PortfolioItem
{
    public static PortfolioItem FromRepositoryModel(PortfolioData.Models.PortfolioItem source)
    {
        if (source is null) return null;

        return new PortfolioItem
        {
            Id = source.Id,
            ShareId = source.ShareId,
            Holding = source.Holding,
            CostCents = (int)(source.Cost * 100)
        };
    }
}

public partial class Portfolio
{
    public static Portfolio FromRepositoryModel(PortfolioData.Models.Portfolio source)
    {
        if (source is null) return null;

        var target = new Portfolio
        {
            Id = source.Id,
            TraderId = source.TraderId.ToString(),
        };

        target.Items.AddRange(source.Items.Select(PortfolioItem.FromRepositoryModel));

        return target;
    }
}
```

> [!NOTE]
> You could use a library like [AutoMapper](https://automapper.org/) to handle this conversion from internal model classes to Protobuf types, as long as you configure the lower-level type conversions like `string`/`Guid` or `decimal`/`double` and the list mapping.

Now that you have the conversion code in place, you can complete the `Get` method implementation:

```csharp
public override async Task<GetResponse> Get(GetRequest request, ServerCallContext context)
{
    if (!Guid.TryParse(request.TraderId, out var traderId))
    {
        throw new RpcException(new Status(StatusCode.InvalidArgument, "traderId must be a UUID"));
    }

    var portfolio = await _repository.GetAsync(traderId, request.PortfolioId);

    return new GetResponse
    {
        Portfolio = Portfolio.FromRepositoryModel(portfolio)
    };
}

```

The implementation of the `GetAll` method is similar. Note that the `repeated` fields on Protobuf messages are generated as `readonly` properties of type `RepeatedField<T>`, so you have to add items to them by using the `AddRange` method, like in this example:

```csharp
public override async Task<GetAllResponse> GetAll(GetAllRequest request, ServerCallContext context)
{
    if (!Guid.TryParse(request.TraderId, out var traderId))
    {
        throw new RpcException(new Status(StatusCode.InvalidArgument, "traderId must be a UUID"));
    }

    var portfolios = await _repository.GetAllAsync(traderId);

    var response = new GetAllResponse();
    response.Portfolios.AddRange(portfolios.Select(Portfolio.FromRepositoryModel));

    return response;
}
```

Having successfully migrated the WCF request-reply service to gRPC, let's look at creating a client for it from the `.proto` file.

## Generate client code

Create a .NET Standard class library in the same solution to contain the client. This is primarily an example of creating client code, but you could package such a library by using NuGet and distribute it on an internal repository for other .NET teams to consume. Go ahead and add a new .NET Standard class library called `TraderSys.Portfolios.Client` to the solution and delete the `Class1.cs` file.

> [!CAUTION]
> The [Grpc.Net.Client](https://www.nuget.org/packages/Grpc.Net.Client) NuGet package requires .NET Core 3.0 or later (or another .NET Standard 2.1-compliant runtime). Earlier versions of .NET Framework and .NET Core are supported by the [Grpc.Core](https://www.nuget.org/packages/Grpc.Core) NuGet package.

In Visual Studio 2022, you can add references to gRPC services in a way that's similar to how you'd add service references to WCF projects in earlier versions of Visual Studio. Service references and connected services are all managed under the same UI now. You can access the UI by right-clicking the **Dependencies** node in the `TraderSys.Portfolios.Client` project in Solution Explorer and selecting **Manage Connected Service**. In the tool window that appears, select the **Connected Services** section, then select **Add a service reference** in Service References section, select gRPC and click Next:

![Connected Services UI in Visual Studio 2022](media/migrate-request-reply/add-connected-service.png)

![GRPC Service Reference UI in Visual Studio 2022](media/migrate-request-reply/add-connected-service2.png)

Browse to the `portfolios.proto` file in the `TraderSys.Portfolios` project, leave **Client** under **Select the type of class to be generated**, and then select **OK**:

![Add new gRPC service reference dialog box in Visual Studio 2022](media/migrate-request-reply/add-new-grpc-service-reference.png)

> [!TIP]
> Notice that this dialog box also provides a URL field. If your organization maintains a web-accessible directory of `.proto` files, you can create clients just by setting this URL address.

When you use the Visual Studio **Add Connected Service** feature, the `portfolios.proto` file is added to the class library project as a *linked file* rather than copied, so changes to the file in the service project will automatically be applied in the client project. The `<Protobuf>` element in the `csproj` file looks like this:

```xml
<Protobuf Include="..\TraderSys.Portfolios\Protos\portfolios.proto" GrpcServices="Client">
  <Link>Protos\portfolios.proto</Link>
</Protobuf>
```

> [!TIP]
> If you're not using Visual Studio or prefer to work from the command line, you can use the `dotnet-grpc` global tool to manage Protobuf references in a .NET gRPC project. For more information, see the [`dotnet-grpc` documentation](/aspnet/core/grpc/dotnet-grpc).

### Use the Portfolios service from a client application

The following code is a brief example of how to use the generated client in a console application. A more detailed exploration of the gRPC client code is at the end of this chapter.

```csharp
public class Program
{
    public async Task Main(string[] args)
    {
        GetResponse response;

        using (var channel = GrpcChannel.ForAddress("https://localhost:5001"))
        {
            var client = new Protos.Portfolios.PortfoliosClient(channel);

            response = await client.GetAsync(new GetRequest
            {
                TraderId = args[0],
                PortfolioId = int.Parse(args[1])
            });
        }

        foreach (var item in response.Portfolio.Items)
        {
            Console.WriteLine($"Holding {item.Holding} of Share ID {item.ShareId}.");
        }
    }
}
```

You've now migrated a basic WCF application to an ASP.NET Core gRPC service and created a client to consume the service from a .NET application. The next section will cover the more involved duplex services.

>[!div class="step-by-step"]
>[Previous](create-project.md)
>[Next](migrate-duplex-services.md)
