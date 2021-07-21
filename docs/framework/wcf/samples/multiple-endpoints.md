---
description: "Learn more about: Multiple Endpoints"
title: "Multiple Endpoints"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "Multiple EndPoints"
ms.assetid: 8f0c2e1f-9aee-41c2-8301-c72b7f664412
---
# Multiple Endpoints

The [MultipleEndpoints sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how to configure multiple endpoints on a service and how to communicate with each endpoint from a client. This sample is based on the [Getting Started](getting-started-sample.md). The service configuration has been modified to define two endpoints that support the `ICalculator` contract, but each at a different address using a different binding. The client configuration and code have been modified to communicate with both of the service endpoints.

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

The service Web.config file has been modified to define two endpoints, each supporting the same `ICalculator` contract, but at different addresses using different bindings. The first endpoint is defined at the base address using a `basicHttpBinding` binding, which does not have security enabled. The second endpoint is defined at {baseaddress}/secure using a `wsHttpBinding` binding, which is secure by default, using WS-Security with Windows authentication.

```xml
<service
    name="Microsoft.ServiceModel.Samples.CalculatorService"
    behaviorConfiguration="CalculatorServiceBehavior">
  <!-- This endpoint is exposed at the base address provided by host:
       http://localhost/servicemodelsamples/service.svc  -->
  <endpoint address=""
            binding="basicHttpBinding"
            contract="Microsoft.ServiceModel.Samples.ICalculator" />
  <!-- secure endpoint exposed at {base address}/secure:
       http://localhost/servicemodelsamples/service.svc/secure -->
  <endpoint address="secure"
            binding="wsHttpBinding"
            contract="Microsoft.ServiceModel.Samples.ICalculator" />
  ...
</service>
```

Both endpoints are also configured on the client. These endpoints are given names so that the caller can pass the desired endpoint name into the constructor of the client.

```xml
<client>
  <!-- Passing "basic" into the constructor of the CalculatorClient
       class selects this endpoint.-->
  <endpoint name="basic"
            address="http://localhost/servicemodelsamples/service.svc"
            binding="basicHttpBinding"
            contract="Microsoft.ServiceModel.Samples.ICalculator" />
  <!-- Passing "secure" into the constructor of the CalculatorClient
       class selects this endpoint.-->
  <endpoint name="secure"
            address="http://localhost/servicemodelsamples/service.svc/secure"
            binding="wsHttpBinding"
            contract="Microsoft.ServiceModel.Samples.ICalculator" />
</client>
```

The client uses both endpoints as shown in the following code.

```csharp
static void Main()
{
    // Create a client to the basic endpoint configuration.
    CalculatorClient client = new CalculatorClient("basic");
    Console.WriteLine("Communicate with basic endpoint.");
    // call operations
    DoCalculations(client);

    // Close the client and release resources.
    client.Close();

    // Create a client to the secure endpoint configuration.
    client = new CalculatorClient("secure");
    Console.WriteLine("Communicate with secure endpoint.");
    // Call operations.
    DoCalculations(client);

    // Close the client and release resources.
    client.Close();

    Console.WriteLine();
    Console.WriteLine("Press <ENTER> to terminate client.");
    Console.ReadLine();
}
```

When you run the client, interactions with both endpoints are displayed.

```console
Communicate with basic endpoint.
Add(100,15.99) = 115.99
Subtract(145,76.54) = 68.46
Multiply(9,81.25) = 731.25
Divide(22,7) = 3.14285714285714
Communicate with secure endpoint.
Add(100,15.99) = 115.99
Subtract(145,76.54) = 68.46
Multiply(9,81.25) = 731.25
Divide(22,7) = 3.14285714285714

Press <ENTER> to terminate client.
```

### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).
