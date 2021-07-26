---
description: "Learn more about: One-Way"
title: "One-Way"
ms.date: "03/30/2017"
ms.assetid: 74e3e03d-cd15-4191-a6a5-1efa2dcb9e73
---
# One-Way

The [Oneway sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates a service contact with one-way service operations. The client does not wait for service operations to complete as is the case with two-way service operations. This sample is based on the [Getting Started](getting-started-sample.md) and uses the `wsHttpBinding` binding. The service in this sample is a self-hosted console application to enable you to observe the service that receives and processes requests. The client is also a console application.

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

To create a one-way service contract, define your service contract, apply the <xref:System.ServiceModel.OperationContractAttribute> class to each operation, and set <xref:System.ServiceModel.OperationContractAttribute.IsOneWay%2A> to `true` as shown in the following sample code:

```csharp
[ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]
public interface IOneWayCalculator
{
    [OperationContract(IsOneWay=true)]
    void Add(double n1, double n2);
    [OperationContract(IsOneWay = true)]
    void Subtract(double n1, double n2);
    [OperationContract(IsOneWay = true)]
    void Multiply(double n1, double n2);
    [OperationContract(IsOneWay = true)]
    void Divide(double n1, double n2);
}
```

To demonstrate that the client does not wait for the service operations to complete, the service code in this sample implements a five-second delay, as shown in the following sample code:

```csharp
// This service class implements the service contract.
// This code writes output to the console window.
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple,
    InstanceContextMode = InstanceContextMode.PerCall)]
public class CalculatorService : IOneWayCalculator
{
    public void Add(double n1, double n2)
    {
        Console.WriteLine("Received Add({0},{1}) - sleeping", n1, n2);
        System.Threading.Thread.Sleep(1000 * 5);
        double result = n1 + n2;
        Console.WriteLine("Processing Add({0},{1}) - result: {2}", n1, n2, result);
    }
    ...
}
```

When the client calls the service, the call returns without waiting for the service operation to complete.

When you run the sample, the client and service activities are displayed in both the service and client console windows. You can see the service receive messages from the client. Press ENTER in each console window to shut down both the service and the client.

The client finishes ahead of the service, demonstrating that a client does not wait for one-way service operations to complete. The client output is as follows:

```console
Add(100,15.99)
Subtract(145,76.54)
Multiply(9,81.25)
Divide(22,7)

Press <ENTER> to terminate client.
```

The following service output is shown:

```console
The service is ready.
Press <ENTER> to terminate service.

Received Add(100,15.99) - sleeping
Received Subtract(145,76.54) - sleeping
Received Multiply(9,81.25) - sleeping
Received Divide(22,7) - sleeping
Processing Add(100,15.99) - result: 115.99
Processing Subtract(145,76.54) - result: 68.46
Processing Multiply(9,81.25) - result: 731.25
Processing Divide(22,7) - result: 3.14285714285714
```

> [!NOTE]
> HTTP is, by definition, a request/response protocol; when a request is made, a response is returned. This is true even for a one-way service operation that is exposed over HTTP. When the operation is called, the service returns an HTTP status code of 202 before the service operation has executed. This status code means that the request has been accepted for processing, but the processing has not yet been completed. The client that called the operation blocks until it receives the 202 response from the service. This can cause some unexpected behavior when multiple one-way messages are sent using a binding that is configured to use sessions. The `wsHttpBinding` binding used in this sample is configured to use sessions by default to establish a security context. By default, messages in a session are guaranteed to arrive in the order in which they are sent. Because of this, when the second message in a session is sent, it is not processed until the first message has been processed. The result of this is that the client does not receive the 202 response for a message until the processing of the previous message has been completed. The client therefore appears to block on each subsequent operation call. To avoid this behavior, this sample configures the runtime to dispatch messages concurrently to distinct instances for processing. The sample sets <xref:System.ServiceModel.ServiceBehaviorAttribute.InstanceContextMode%2A> to `PerCall` so that each message can be processed by a different instance. <xref:System.ServiceModel.ServiceBehaviorAttribute.ConcurrencyMode%2A> is set to `Multiple` to allow more than one thread to dispatch messages at a time.

### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).

> [!NOTE]
> Run the service before you run the client and shut down the client before shutting down the service. This avoids a client exception when the client cannot close the security session cleanly because the service is gone.
