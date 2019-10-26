---
title: WCF svcutil tool overview
description: An overview of the Microsoft WCF dotnet-svcutil tool that adds functionality for .NET Core and ASP.NET Core projects, similar to the WCF svcutil tool for .NET Framework projects.
author: mlacouture
ms.date: 02/22/2019
ms.custom: "seodec18"
---
# WCF dotnet-svcutil tool for .NET Core

The Windows Communication Foundation (WCF) **dotnet-svcutil** tool is a .NET Core CLI tool that retrieves metadata from a web service on a network location or from a WSDL file, and generates a WCF class containing client proxy methods that access the web service operations.

Similar to the [**Service Model Metadata - svcutil**](../../framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) tool for .NET Framework projects, the **dotnet-svcutil** is a command-line tool for generating a web service reference compatible with .NET Core and .NET Standard projects.

The **dotnet-svcutil** tool is an alternative option to the [**WCF Web Service Reference**](wcf-web-service-reference-guide.md) Visual Studio connected service provider that first shipped with Visual Studio 2017 version 15.5. The **dotnet-svcutil** tool as a .NET Core CLI tool, is available cross-platform on Linux, macOS, and Windows.

> [!IMPORTANT]
> You should only reference services from a trusted source. Adding references from an untrusted source may compromise security.

## Prerequisites

<!-- markdownlint-disable MD025 -->

# [dotnet-svcutil 2.x](#tab/dotnetsvcutil2x)

- [.NET Core 2.1 SDK](https://dotnet.microsoft.com/download) or later versions
- Your favorite code editor

# [dotnet-svcutil 1.x](#tab/dotnetsvcutil1x)

- [.NET Core 1.0.4 SDK](https://dotnet.microsoft.com/download) or later versions
- Your favorite code editor

---

## Getting started

The following example walks you through the steps required to add a web service reference to a .NET Core web project and invoke the service. You'll create a .NET Core web application named *HelloSvcutil* and add a reference to a web service that implements the following contract:

```csharp
[ServiceContract]
public interface ISayHello
{
    [OperationContract]
    string Hello(string name);
}
```

For this example, let's assume the web service will be hosted at the following address: `http://contoso.com/SayHello.svc`

From a Windows, macOS, or Linux command window perform the following steps:

1. Create a directory named _HelloSvcutil_ for your project and make it your current directory, as in the following example:

    ```console
    mkdir HelloSvcutil
    cd HelloSvcutil
    ```

2. Create a new C# web project in that directory using the [`dotnet new`](../tools/dotnet-new.md) command as follows:

    ```dotnetcli
    dotnet new web
    ```

3. Install the [`dotnet-svcutil` NuGet package](https://nuget.org/packages/dotnet-svcutil) as a CLI tool:
    <!-- markdownlint-disable MD023 -->
    # [dotnet-svcutil 2.x](#tab/dotnetsvcutil2x)

    ```dotnetcli
    dotnet tool install --global dotnet-svcutil
    ```

    # [dotnet-svcutil 1.x](#tab/dotnetsvcutil1x)
    Open the `HelloSvcutil.csproj` project file in your editor, edit the `Project` element, and add the [`dotnet-svcutil` NuGet package](https://nuget.org/packages/dotnet-svcutil) as a CLI tool reference, using the following code:

    ```xml
    <ItemGroup>
      <DotNetCliToolReference Include="dotnet-svcutil" Version="1.0.*" />
    </ItemGroup>
    ```

    Then restore the _dotnet-svcutil_ package using the [`dotnet restore`](../tools/dotnet-restore.md) command as follows:

    ```dotnetcli
    dotnet restore
    ```

    ---

4. Run the _dotnet-svcutil_ command to generate the web service reference file as follows:

    # [dotnet-svcutil 2.x](#tab/dotnetsvcutil2x)

    ```dotnetcli
    dotnet-svcutil http://contoso.com/SayHello.svc
    ```

    # [dotnet-svcutil 1.x](#tab/dotnetsvcutil1x)

    ```dotnetcli
    dotnet svcutil http://contoso.com/SayHello.svc
    ```

    ---

The generated file is saved as _HelloSvcutil/ServiceReference/Reference.cs_. The _dotnet-svcutil_ tool also adds to the project the appropriate WCF packages required by the proxy code as package references.

## Using the Service Reference

1. Restore the WCF packages using the [`dotnet restore`](../tools/dotnet-restore.md) command as follows:

    ```dotnetcli
    dotnet restore
    ```

2. Find the name of the client class and operation you want to use. `Reference.cs` will contain a class that inherits from `System.ServiceModel.ClientBase`, with methods that can be used to call operations on the service. In this example, you want to call the _SayHello_ service's _Hello_ operation. `ServiceReference.SayHelloClient` is the name of the client class, and has a method called `HelloAsync` that can be used to call the operation.

3. Open the `Startup.cs` file in your editor, and add a using statement for the service reference namespace at the top:

    ```csharp
    using ServiceReference;
    ```

4. Edit the `Configure` method to invoke the web service. You do this by creating an instance of the class that inherits from `ClientBase` and calling the method on the client object:

    ```csharp
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.Run(async (context) =>
        {
            var client = new SayHelloClient();
            var response = await client.HelloAsync();
            await context.Response.WriteAsync(response);
        });
    }

    ```

5. Run the application using the [`dotnet run`](../tools/dotnet-run.md) command as follows:

    ```dotnetcli
    dotnet run
    ```

6. Navigate to the URL listed in the console (for example, `http://localhost:5000`) in your web browser.

You should see the following output:
"Hello dotnet-svcutil!"

For a detailed description of the `dotnet-svcutil` tool parameters, invoke the tool passing the help parameter as follows:
# [dotnet-svcutil 2.x](#tab/dotnetsvcutil2x)

```dotnetcli
dotnet-svcutil --help
```

# [dotnet-svcutil 1.x](#tab/dotnetsvcutil1x)

```dotnetcli
dotnet svcutil --help
```

---

## Feedback & questions

If you have any questions or feedback, [open an issue on GitHub](https://github.com/dotnet/wcf/issues/new). You can also review any existing questions or issues [at the WCF repo on GitHub](https://github.com/dotnet/wcf/issues?utf8=%E2%9C%93&q=is:issue%20label:tooling).

## Release notes

- Refer to the [Release notes](https://github.com/dotnet/wcf/blob/master/release-notes/dotnet-svcutil-notes.md) for updated release information, including known issues.

## Information

- [dotnet-svcutil NuGet Package](https://nuget.org/packages/dotnet-svcutil)
