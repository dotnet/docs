---
description: "Learn more about: Session"
title: "Session"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "Sessions"
ms.assetid: 36e1db50-008c-4b32-8d09-b56e790b8417
---
# Session

The [Session sample](https://github.com/dotnet/samples/tree/main/framework/wcf/Basic/Contract/Service/Session/CS) demonstrates how to implement a contract that requires a session. A session provides context for performing multiple operations. This allows a service to associate state with a given session, such that subsequent operations can use the state of a previous operation. This sample is based on the [Getting Started](getting-started-sample.md), which implements a calculator service. The `ICalculator` contract has been modified to allow a set of arithmetic operations to be performed, while keeping a running result. This functionality is defined by the `ICalculatorSession` contract. The service maintains the state for a client as multiple service operations are called to perform a calculation. The client can retrieve the current result by calling `Result()` and clear the result to zero by calling `Clear()`.

In this sample, the client is a console application (.exe) and the service is hosted by Internet Information Services (IIS).

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

Setting the <xref:System.ServiceModel.SessionMode> of the contract to `Required` ensures that when the contract is exposed over a particular binding, the binding supports sessions. If the binding does not support sessions an exception is thrown. The `ICalculatorSession` interface is defined such that one or more operations can be called, which modifies a running result, as shown in the following sample code.

```csharp
[ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples", SessionMode=SessionMode.Required)]
public interface ICalculatorSession
{
    [OperationContract(IsOneWay=true)]
    void Clear();
    [OperationContract(IsOneWay = true)]
    void AddTo(double n);
    [OperationContract(IsOneWay = true)]
    void SubtractFrom(double n);
    [OperationContract(IsOneWay = true)]
    void MultiplyBy(double n);
    [OperationContract(IsOneWay = true)]
    void DivideBy(double n);
    [OperationContract]
    double Result();
}
```

The service uses a <xref:System.ServiceModel.InstanceContextMode> of <xref:System.ServiceModel.InstanceContextMode.PerSession> to bind a given service instance context to each incoming session. This allows the service to maintain the running result for each session in a local member variable.

```csharp
[ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession)]
public class CalculatorService : ICalculatorSession
{
    double result = 0.0D;

    public void Clear()
    {  result = 0.0D; }

    public void AddTo(double n)
    {  result += n;   }

    public void SubtractFrom(double n)
    {  result -= n;   }

    public void MultiplyBy(double n)
    {  result *= n;   }

    public void DivideBy(double n)
    {  result /= n;   }

    public double Result()
    {  return result; }
}
```

When you run the sample, the client makes several requests to the server and requests the result, which it then displays in the client console window. Press ENTER in the client window to shut down the client.

```console
(((0 + 100) - 50) * 17.65) / 2 = 441.25
Press <ENTER> to terminate client.
```

### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).
