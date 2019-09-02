---
title: Migrating a Request-Reply service to gRPC
description: gRPC for WCF Developers | Migrating a Request-Reply service to gRPC
author: markrendle
ms.date: 09/02/2019
---

# Request-Reply Services

The TraderSys solution includes a simple Request-Reply Portfolio service to download a single Portfolio, or all Portfolios for a given Trader. The service is defined in the `interface IPortfolioService` with a `ServiceContract` attribute:

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

The `Portfolio` model is a simple C# class marked with `DataContract`, including a list of `PortfolioItem` objects. These models are defined in the `TraderSys.PortfolioData` project, along with a repository class representing a data access abstraction.

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

The `ServiceContract` implementation uses a repository class provided via Dependency Injection that returns instances of the `DataContract` types.

```csharp
public class PortfolioService : IPortfolioService
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

## Converting the DataContracts to gRPC Messages

The `PortfolioItem` class will be converted to a Protobuf message first, as the `Portfolio` class depends on it. The class is very simple, and three of the properties map directly to gRPC data types. The `Cost` property, representing the price paid for the shares at purchase, is a `decimal` field, and gRPC only supports `float` or `double` for real numbers, so this field type will be `double`.

> [!NOTE]
> Remember to use `camelCase` for field names in your `.proto` file; the C# code generator will convert them to `PascalCase` for you, and users of other languages will thank you for respecting their different coding standards.

```protobuf
message PortfolioItem {
    int32 id = 1;
    int32 shareId = 2;
    int32 holding = 3;
    double cost = 4;
}
```

The `Portfolio` class is a little more complicated. In the WCF code, the developer used a `Guid` for the `TraderId` property, and contains a `List<PortfolioItem>`. In Protobuf, which doesn't have a first-class `UUID` type, you should use a `string` for the `traderId` field and parse it in your own code. For the list of items, use the `repeated` keyword on the field.

```protobuf
message Portfolio {
    int32 id = 1;
    string traderId = 2;
    repeated PortfolioItem items = 3;
}
```

## Converting the ServiceContract to a gRPC Service

The WCF `Get` method takes two parameters: `Guid traderId` and `int portfolioId`. gRPC service methods take a single parameter, so a message must be created to hold the two values. It's common to name these request objects with the same name as the method and the suffix `Request`. Again, `string` is being used for the `traderId` field instead of `Guid`.

The service could just return a `Portfolio` message directly, but again, this could impact backward compatibility in the future. It's a good practice to define separate `Request` and `Response` messages for every method in a service, even if many of them are the same right now.

Here is the declaration of the gRPC service method using this `GetRequest` message.

```protobuf
message GetRequest {
    string traderId = 1;
    int32 portfolioId = 2;
}

message GetResponse {
    Portfolio portfolio = 1;
}

service Portfolios {
    rpc Get(GetRequest) returns (GetResponse);
}
```

The WCF `GetAll` method only takes a single parameter, `traderId`, so it might seem that one could specify `string` as the parameter type, but gRPC requires a defined message type. This requirement helps to enforce the practice of using custom messages for all inputs and outputs, for future backward compatibility.

The WCF method also returned a `List<Portfolio>`, but for the same reason it doesn't allow simple parameter types, gRPC won't allow `repeated Portfolio` as a return type. Instead, create a `GetAllResponse` type to wrap the list.

> [!WARNING]
> You may be tempted to create a `PortfolioList` message or similar and use it across multiple service methods, but you should resist this temptation. It's impossible to know how the various methods on a service may evolve in the future, so keep their messages specific and cleanly separated.

```protobuf
message GetAllRequest {
    string traderId = 1;
}

message PortfolioList {
    repeated Portfolio portfolios = 1;
}

service Portfolios {
    rpc Get(GetRequest) returns (Portfolio);
    rpc GetAll(GetAllRequest) returns (GetAllResponse);
}
```

If you save your project with these changes, the gRPC build target will run in the background and generate all the Protobuf message types, and a base class you can inherit to implement the service.

Open up the `Services/GreeterService.cs` class and delete the example code. Now you can add the Portfolio service implementation. The generated base class will be in the `Protos` namespace, and is actually generated as a nested class. gRPC creates a static class with the same name as the service in the `.proto` file, and then a base class with the suffix `Base` inside that static class, so the full identifier for the base type is `TraderSys.Portfolios.Protos.Portfolios.PortfoliosBase`.

```csharp
namespace TraderSys.Portfolios.Services
{
    public class PortfolioService : Protos.Portfolios.PortfoliosBase
    {
    }
}
```

The base class declares `virtual` methods for `Get` and `GetAll` that can be overridden to implement the service. The methods are `virtual` rather than `abstract` so that if you don't implement them, the service can return an explicit gRPC `Unimplemented` status code, much like you might throw a `NotImplementedException` in regular C# code.

The signature for all gRPC service methods in ASP.NET Core is consistent. There are two parameters: the first is the message type declared in the `.proto` file, and the second is a `ServerCallContext` that works similarly to the `HttpContext` from ASP.NET Core. (In fact, there is an extension method `GetHttpContext` on the `ServerCallContext` type that you can use to get the underlying `HttpContext`, although you shouldn't need to use it very often.) There will be a look at `ServerCallContext` later in the chapter, and also in the chapter on authentication.

The method's return type is a `Task<T>` where `T` is the response message type. All gRPC service methods are asynchronous.

## Migrating the PortfolioData library to .NET Core

At this point the project needs the Portfolio repository and models contained in the `TraderSys.PortfolioData` class library in the WCF solution. The easiest way to bring them across is to create a new class library using either the Visual Studio *New project* dialog with the *Class Library (.NET Standard)* template, or from the command line using the `dotnet` CLI, running the following commands from the directory containing the `TraderSys.sln` file.

```console
dotnet new classlib -o src/TraderSys.PortfolioData
dotnet sln add src/TraderSys.PortfolioData
```

Once the library has been created and added to the solution, delete the generated `Class1.cs` file and copy the files from the WCF solution's library into the new class library's folder, keeping the folder structure.

- `Models`
  - `Portfolio.cs`
  - `PortfolioItem.cs`
- `IPortfolioRepository.cs`
- `PortfolioRepository.cs`

Modern .NET project files automatically include any `.cs` files in or under their own directory, so there is no need to explicitly add them to the project. The only step remaining is to remove the `DataContract` and `DataMember` attributes from the `Portfolio` and `PortfolioItem` classes so they are just plain old C# classes.

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

## Dependency Injection

Now you can add a reference to this library to the gRPC application project and consume the `PortfolioRepository` class using dependency injection in the gRPC service implementation. In the WCF application, dependency injection was provided by the Autofac IoC container. ASP.NET Core has dependency injection baked in; the repository can be registered in the `ConfigureServices` method in the `Startup` class.

```csharp
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Register the repository class as a scoped service (instance per request)
        services.AddScoped<IPortfolioRepository, PortfolioRepository>();

        services.AddGrpc();
    }

    // ...
}
```

The `IPortfolioRepository` implementation can now be specified as a constructor parameter in the `PortfolioService` class.

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

## Implementing the gRPC service

Let's start by implementing the `Get` method. The default override looks like this:

```csharp
public override Task<GetResponse> Get(GetRequest request, ServerCallContext context)
{
    return base.Get(request, context);
}
```

The first issue is that `request.TraderId` is a string, and the service requires a `Guid`. Although it will certainly be documented somewhere that the string should be a properly formatted `UUID`, the code has to deal with the possibility that a caller has sent an invalid value and respond accordingly. The service can respond with errors by throwing an `RpcException`, and use the standard `InvalidArgument` status code to express the problem.

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

Once there is a proper `Guid` value for `traderId`, the repository can be used to retrieve the Portfolio and return it to the client.

```csharp
    var response = new GetResponse
    {
        Portfolio = await _repository.GetAsync(request.TraderId, request.PortfolioId)
    };
```

### Mapping internal models to gRPC messages

The above code doesn't actually work, because the repository is returning its own POCO `Portfolio`, but gRPC needs *its* own Protobuf message `Portfolio`. Much like mapping Entity Framework types to data transfer types, the best solution is just to provide conversion between the two. A good place to put the code for this is in the Protobuf-generated class, which is declared as `partial` precisely so it can be extended.

```csharp
namespace TraderSys.Portfolios.Protos
{
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
                Cost = Convert.ToDouble(source.Cost)
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
}
```

> [!NOTE]
> You could use a library like [AutoMapper](https://automapper.org/) to handle this conversion from internal model classes to Protobuf types, as long as you configure the lower-level type conversions like `string`/`Guid` or `decimal`/`double` and the list mapping.

With the conversion code in place, the `Get` method implementation can be completed.

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

The implementation of the `GetAll` method is similar. Note that the `repeated` fields on Protobuf messages are generated as `readonly` properties of type `RepeatedField<T>`, so you have to add items to them using the `AddRange` method.

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

Having successfully migrated the WCF application to gRPC, let's look at creating a client for it from the `.proto` file.

## Generating Client code

Create a .NET Standard class library in the same solution to contain the client. This is primarily as an example of creating client code, but such a library could be packaged using NuGet and distributed on an internal repository for other .NET teams to consume. Go ahead and add a new .NET Standard Class Library called `TraderSys.Portfolios.Client` to the solution and delete the `Class1.cs` file.

> [!CAUTION]
> The latest `Grpc.Net` NuGet packages (0.2.23 or later) require .NET Standard 2.1. You might need to change your Target Framework to `netstandard2.1` for the new class library.

In Visual Studio 2019, you can add references to gRPC services much like you could add Service References to WCF projects in earlier versions of VS. Service References and Connected Services are all managed under the same UI now, which you can access by right-clicking the *Dependencies* node in the `TraderSys.Portfolios.Client` project in Solution Explorer and selecting *Add Connected Service*. In the tool window that appears, select the *Service References* section and click *Add new gRPC service reference*.

![The Connected Services UI in Visual Studio 2019](images/add-connected-service.png)

Browse to the `portfolios.proto` file in the `TraderSys.Portfolios` project, leave the *type of class to be generated* as *Client*, and click *OK*.

![The Add new gRPC service reference dialog in Visual Studio 2019](images/add-new-grpc-service-reference.png)

> [!TIP]
> Notice that this dialog also provides a URL field. If your organization maintains a web-accessible directory of `.proto` files you can create clients just by setting this URL address.

When using the Visual Studio *Add Connected Service* feature, the `portfolios.proto` file is added to the Class Library project as a *linked file*, rather than copied, so changes to the file in the service project will automatically be applied in the client project. The `<Protobuf>` element in the `csproj` file looks like this:

```xml
<Protobuf Include="..\TraderSys.Portfolios\Protos\portfolios.proto" GrpcServices="Client">
  <Link>Protos\portfolios.proto</Link>
</Protobuf>
```

## Using the client

Here is a very brief example of using the generated client in a console application. A more detailed exploration of the gRPC client code is at the end of this chapter.

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

>[!div class="step-by-step"]
<!-->[Next](migrating-duplex-services.md)-->
