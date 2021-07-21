---
description: "Learn more about: Throttling"
title: "Throttling"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "service behaviors, throttling sample"
  - "Throttling Sample [Windows Communication Foundation]"
ms.assetid: 40bb3582-8ae9-4410-96f0-6c515bfaf47c
---
# Throttling

The [Throttling sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates the use of throttling controls. Throttling controls place limits on the number of concurrent calls, instances, or sessions to prevent over-consumption of resources. Throttling behavior is specified in service configuration file settings. This sample is based on the [Getting Started](getting-started-sample.md) that implements a calculator service.

In this sample, the client is a console application (.exe) and the service is hosted by Internet Information Services (IIS).

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

The service configuration file specifies throttling controls in a [\<serviceThrottling>](../../configure-apps/file-schema/wcf/servicethrottling.md), as shown in the following sample configuration.

```xml
<behaviors>
  <serviceBehaviors>
    <behavior name="CalculatorServiceBehavior">
      <serviceDebug includeExceptionDetailInFaults="False" />
      <serviceMetadata httpGetEnabled="True"/>
      <!-- Specify throttling behavior -->
    <serviceThrottling maxConcurrentCalls="2"
                       maxConcurrentInstances="10"/>
    </behavior>
  </serviceBehaviors>
</behaviors>
```

As configured, the service limits the maximum concurrent calls to 2, and the maximum number of concurrent instances to 10.

In order to demonstrate throttling we define a sleep time on the service methods as follows:

```csharp
public double Add(double n1, double n2)
{
    System.Threading.Thread.Sleep(2000);
    return n1 + n2;
}
```

When you run the sample, the operation requests and responses are displayed in the client console window. The Add and Subtract methods are executed concurrently and the Multiply and Divide methods are executed concurrently proving that not more than 2 methods can be executed concurrently thus demonstrating throttling.

```console
Press <ENTER> to terminate client.
Add(100,15.99)
Subtract(145,76.54)
Multiply(9,81.25)
Divide(22,7)

Add Result: 115.99
Subtract Result: 68.46
Multiply Result: 731.25
Divide Result: 3.14285714285714

Press any key to continue . . .
```

### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).
