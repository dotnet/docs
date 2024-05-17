---
description: "Learn more about: IIS Hosting Using Inline Code"
title: "IIS Hosting Using Inline Code"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "Web hosted service"
  - "IIS Hosting Using Inline Code Sample [Windows Communication Foundation]"
ms.assetid: 56fe3687-a34b-4661-8e30-b33770f413fa
---
# IIS Hosting Using Inline Code

The [InlineCode sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how to implement a service hosted by Internet Information Services (IIS), where the service code is contained in-line in a .svc file and is compiled on demand. Service code can also be implemented directly in source code files located in the application's \App_Code directory, or compiled into assembly deployed in \bin. This sample does not demonstrate these techniques.

> [!NOTE]
> The set-up procedure and build instructions for this sample are located at the end of this topic.

The sample demonstrates a typical service that implements a contract that defines a request-reply communication pattern. The service is hosted in IIS and the service code is entirely contained in the Service.svc file. The service is host-activated and compiled on-demand by the first message sent to the service. There is no pre-compilation necessary. The service implements an `ICalculator` contract as defined in the following code:

```csharp
// Define a service contract.
[ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]
    public interface ICalculator
{
    [OperationContract]
    double Add(double n1, double n2);
    [OperationContract]
    double Subtract(double n1, double n2);
    [OperationContract]
    double Multiply(double n1, double n2);
    [OperationContract]
    double Divide(double n1, double n2);
}
```

The service implementation calculates and returns the appropriate result.

`<%@ServiceHost language=c# Debug="true" Service="Microsoft.ServiceModel.Samples.CalculatorService" %>`

```csharp
// Service class that implements the service contract.
public class CalculatorService : ICalculator
{
    public double Add(double n1, double n2)
    {
        return n1 + n2;
    }
    public double Subtract(double n1, double n2)
    {
        return n1 - n2;
    }
    public double Multiply(double n1, double n2)
    {
        return n1 * n2;
    }
    public double Divide(double n1, double n2)
    {
        return n1 / n2;
    }
}
```

When you run the sample, the operation requests and responses are displayed in the client console window. Press ENTER in the client window to shut down the client.

```console
Add(100,15.99) = 115.99
Subtract(145,76.54) = 68.46
Multiply(9,81.25) = 731.25
Divide(22,7) = 3.14285714285714

Press <ENTER> to terminate client.
```

### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. After the solution has been built, run setup.bat to set up the ServiceModelSamples Application in IIS 7.0. The ServiceModelSamples directory should now appear as an IIS 7.0 Application.

4. To run the sample in a single- or cross-computer configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md). For an example on how to create a client application that can call this service, see [How to: Create a Client](../how-to-create-a-wcf-client.md).

## See also

- [AppFabric Hosting and Persistence Samples](/previous-versions/appfabric/ff383418(v=azure.10))
