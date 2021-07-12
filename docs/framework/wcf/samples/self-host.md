---
description: "Learn more about: Self-Host"
title: "Self-Host"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "Self hosted service"
  - "Self Host Sample [Windows Communication Foundation]"
ms.assetid: 05e68661-1ddf-4abf-a899-9bb1b8272a5b
---
# Self-Host

The [SelfHost sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how to implement a self-hosted service in a console application. This sample is based on the [Getting Started](getting-started-sample.md). The service configuration file has been renamed from Web.config to App.config and modified to configure a base address, which the host uses. The service source code has been modified to implement a static `Main` function that creates and opens a service host that provides the configured base address. The service implementation has been modified to write output to the console for each operation. The client has been unmodified, except for configuring the correct endpoint address of the service.

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

The sample implements a static main function to create a <xref:System.ServiceModel.ServiceHost> for the given `CalculatorService` type, as shown in the following sample code.

```csharp
// Host the service within this EXE console application.
public static void Main()
{
    // Create a ServiceHost for the CalculatorService type.
    using (ServiceHost serviceHost =
           new ServiceHost(typeof(CalculatorService)))
    {
        // Open the ServiceHost to create listeners
        // and start listening for messages.
        serviceHost.Open();

        // The service can now be accessed.
        Console.WriteLine("The service is ready.");
        Console.WriteLine("Press <ENTER> to terminate service.");
        Console.WriteLine();
        Console.ReadLine();
    }
}
```

When a service is hosted in Internet Information Services (IIS) or Windows Process Activation Service (WAS), the base address of the service is provided by the hosting environment. In the self-hosted case, you must specify the base address yourself. This is done using the `add` element, child of [\<baseAddresses>](../../configure-apps/file-schema/wcf/baseaddresses.md), child of [\<host>](../../configure-apps/file-schema/wcf/host.md), child of [\<service>](../../configure-apps/file-schema/wcf/service.md) as demonstrated in the following sample configuration.

```xml
<service
    name="Microsoft.ServiceModel.Samples.CalculatorService"
    behaviorConfiguration="CalculatorServiceBehavior">
  <host>
    <baseAddresses>
      <add baseAddress="http://localhost:8000/ServiceModelSamples/service"/>
    </baseAddresses>
  </host>
  ...
</service>
```

When you run the sample, the operation requests and responses are displayed in both the service and client console windows. Press ENTER in each console window to shut down the service and client.

### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. To run the sample in a single- or cross-computer configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).

## See also

- [AppFabric Hosting and Persistence Samples](/previous-versions/appfabric/ff383418(v=azure.10))
