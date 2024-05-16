---
description: "Learn more about: Data Binding in an ASP.NET Client"
title: "Data Binding in an ASP.NET Client"
ms.date: "03/30/2017"
ms.assetid: 68b49fa6-94e7-4d4c-a34e-902a2b3770b6
---
# Data Binding in an ASP.NET Client

The [WebForms sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how to bind data returned by a typical Windows Communication Foundation (WCF) service in a Web Forms application.

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

This sample demonstrates a service that implements a contract that defines a request-reply communication pattern. The sample consists of a client Web Forms application accessible from a browser and a WCF service hosted by Internet Information Services (IIS).

The service implements a contract that defines a request-reply communication pattern. The contract is defined by the `IWeatherService` interface, which exposes an operation named `GetWeatherData`. This operation accepts an array of cities and returns an array of `WeatherData` objects that represent the high and low forecasted temperature for a city.

On the ASP.NET client .aspx page, a DataGrid Web control is defined, which contains the graphical representation of the data returned by the service. Code on the .aspx page calls the WCF service for weather data and returns the data to an array of `WeatherData` objects. The DataGrid specifies where to get its data from by setting its `DataSource` property to that array. The data binding occurs with a call to the DataGrid's `DataBind` method. All of this code is contained inside the .`aspx` page's `Page_Load` method, so every time the user refreshes the browser page, the data is updated in the DataGrid.

### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. This sample's client is a Web site that runs under a development Web server. To launch the development Web server, type the following at the command prompt: `%SystemDrive%\Program Files\Common Files\Microsoft Shared\DevServer\9.0\WebDev.WebServer.EXE" /port:8000 /path:<WebFormsSamplePath>\CS\client /vpath:/client`. Then browse to `http://localhost:8000/client`. To run this sample across computers, replace all references to `localhost` in the client's Web.config file with the computer name of the server.
