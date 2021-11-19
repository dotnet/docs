---
description: "Learn more about: Data Binding in a Windows Forms Client"
title: "Data Binding in a Windows Forms Client"
ms.date: "03/30/2017"
ms.assetid: a2a30b37-d6e2-4552-820e-e60b2bbe8829
---
# Data Binding in a Windows Forms Client

The [WindowsForms sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how to bind to data returned by a Windows Communication Foundation (WCF) service in a Windows Forms application.

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this article.

This sample demonstrates a service that implements a contract that defines a request-reply communication pattern. The sample consists of a client Windows Forms application (.exe) and a WCF service hosted by Internet Information Services (IIS).

The contract is defined by the `IWeatherService` interface, which exposes an operation named `GetWeatherData`. This operation accepts an array of cities and returns an array of `WeatherData` objects that represent the high and low forecasted temperature for a city.

The data binding occurs on the client in the Windows Forms application. A `DataGridView` is defined in the Windows Forms designer, which is a graphical representation of the data. An intermediary named `BindingSource` is also created. The data source of `BindingSource` is set to the data array returned by the service. The purpose of the `BindingSource` is to provide a layer of indirection between the data and the data view. All interaction with the data, such as navigating, sorting, filtering, and updating, is accomplished with calls to the `BindingSource` component. To accomplish data binding to the `DataGridView`, the `datasource` of the `DataGridView` is then set to the `BindingSource` object. All of the data returned from the WCF service is then displayed graphically to the user. Every time the user clicks the button, the returned data is automatically updated in the data-bound `DataGridView`.

### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).
