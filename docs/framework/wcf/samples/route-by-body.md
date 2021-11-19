---
description: "Learn more about: Route by Body"
title: "Route by Body"
ms.date: "03/30/2017"
ms.assetid: 07a6fc3b-c360-42e0-b663-3d0f22cf4502
---
# Route by Body

The [RouteByBody sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how to implement a service that accepts message objects with any SOAP action. This sample is based on the [Getting Started](getting-started-sample.md) that implements a calculator service. The service implements a single `Calculate` operation that accepts a <xref:System.ServiceModel.Channels.Message> request parameter and returns a <xref:System.ServiceModel.Channels.Message> response.

In this sample, the client is a console application (.exe) and the service is hosted in IIS.

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

The sample demonstrates message dispatch based on the body content. The built-in Windows Communication Foundation (WCF) service model message dispatch mechanism is based on message Actions. However, there are many existing Web services that define all of their operations with Action="". It is impossible to build a service based on WSDL that keeps dispatching request messages based on Action information. This sample demonstrates a service contract that is based on WSDL (the WSDL is contained in Service.wsdl that is included with the sample). The service contract is Calculator, similar to the one used in [Getting Started](getting-started-sample.md). However the `[OperationContract]` specifies `Action=""` for all operations.

```csharp
[ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples"),
                 XmlSerializerFormat, DispatchByBodyBehavior]
    public interface ICalculator
    {
        [OperationContract(Action="")]
        double Add(double n1, double n2);
        [OperationContract(Action = "")]
        double Subtract(double n1, double n2);
        [OperationContract(Action = "")]
        double Multiply(double n1, double n2);
        [OperationContract(Action = "")]
        double Divide(double n1, double n2);
    }
```

Given a contract, a service requires custom dispatch behavior `DispatchByBodyBehavior` to allow messages to be dispatched between operations. This dispatch behavior initializes the `DispatchByBodyElementOperationSelector` custom operation selector with a table of the operation names keyed by QName of respective wrapper elements. `DispatchByBodyElementOperationSelector` looks at the start tag of the first child of the Body and selects the operation using the table previously mentioned.

The client uses a proxy auto-generated from the WSDL exported by the service using [ServiceModel Metadata Utility Tool (Svcutil.exe)](../servicemodel-metadata-utility-tool-svcutil-exe.md).

```console
svcutil.exe  /n:http://Microsoft.ServiceModel.Samples,Microsoft.ServiceModel.Samples /uxs http://localhost/servicemodelsamples/service.svc?wsdl /out:generatedProxy.cs
```

The fact that actions of all operations are empty has no impact on the client code, except for the Action parameters in the auto-generated proxy.

The client code performs several calculations. When you run the sample, the operation requests and responses are displayed in the client console window. Press ENTER in the client window to shut down the client.

```console
Add(100, 15.99) = 115.99
Subtract(145, 76.54) = 68.46
Multiply(9, 81.25) = 731.25
Divide(22, 7) = 3.14285714285714

Press <ENTER> to terminate client.
```

### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).
