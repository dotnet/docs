---
description: "Learn more about: Multiple Contracts"
title: "Multiple Contracts"
ms.date: "03/30/2017"
ms.assetid: 2bef319b-fe9c-4d49-ac6c-dfb23eb35099
---
# Multiple Contracts

The [MultipleContracts sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how to implement more than one contract on a service and how to configure endpoints for communicating with each of the implemented contracts. This sample is based on the [Getting Started](getting-started-sample.md). The service has been modified to define two contracts, the `ICalculator` contract and the `ICalculatorSession` contract.

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

The service class implements both the `ICalculator` and `ICalculatorSession` contracts. Because one of the contracts requires a session, the service uses the <xref:System.ServiceModel.InstanceContextMode.PerSession> instance mode to maintain the state over the lifetime of the session.

The service configuration has been modified to define two endpoints to expose each contract. The `ICalculator` endpoint is exposed at the base address using a `basicHttpBinding`. The `ICalculatorSession` endpoint is exposed at the baseaddress/session using a `wsHttpBinding` with the `bindingConfiguration` attribute set to `BindingWithSession`, as shown in the following sample configuration.

```xml
<service
    name="Microsoft.ServiceModel.Samples.CalculatorService"
    behaviorConfiguration="CalculatorServiceBehavior">
  <!-- ICalculator endpoint is exposed using BasicBinding at the base
       address provided by host:
       http://localhost/servicemodelsamples/service.svc  -->
  <endpoint address=""
            binding="basicHttpBinding"
            contract="Microsoft.ServiceModel.Samples.ICalculator" />
  <!-- ICalculatorSession endpoint is exposed using BindingWithSession
       at {baseaddress}/session:
       http://localhost/servicemodelsamples/service.svc/session -->
  <endpoint address="session"
            binding="wsHttpBinding"
            bindingConfiguration="BindingWithSession"
           contract="Microsoft.ServiceModel.Samples.ICalculatorSession" />
  ...
</service>
```

The generated client code now includes a client class for both the original `ICalculator` contract and the new `ICalculatorSession` contract. The client configuration and code have been modified to communicate with each contract at the appropriate service endpoint.

The client is a console windows application (.exe). The service is hosted by Internet Information Services (IIS).

The client console window displays the operations sent to each of the endpoints, first the basic endpoint, followed by the secure endpoint.

### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).
