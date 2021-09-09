---
description: "Learn more about: Fault Contract"
title: "Fault Contract"
ms.date: "03/30/2017"
ms.assetid: b31b140e-dc3b-408b-b3c7-10b6fe769725
---
# Fault Contract

The [Faults sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how to communicate error information from a service to a client. The sample is based on the [Getting Started](getting-started-sample.md), with some additional code added to the service to convert an internal exception to a fault. The client attempts to perform division by zero to force an error condition on the service.

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

The calculator contract has been modified to include a <xref:System.ServiceModel.FaultContractAttribute> as shown in the following sample code.

```csharp
[ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]
public interface ICalculator
{
    [OperationContract]
    int Add(int n1, int n2);
    [OperationContract]
    int Subtract(int n1, int n2);
    [OperationContract]
    int Multiply(int n1, int n2);
    [OperationContract]
    [FaultContract(typeof(MathFault))]
    int Divide(int n1, int n2);
}
```

The <xref:System.ServiceModel.FaultContractAttribute> attribute indicates that the `Divide` operation may return a fault of type `MathFault`. A fault can be of any type that can be serialized. In this case, the `MathFault` is a data contract, as follows:

```csharp
[DataContract(Namespace="http://Microsoft.ServiceModel.Samples")]
public class MathFault
{
    private string operation;
    private string problemType;

    [DataMember]
    public string Operation
    {
        get { return operation; }
        set { operation = value; }
    }

    [DataMember]
    public string ProblemType
    {
        get { return problemType; }
        set { problemType = value; }
    }
}
```

The `Divide` method throws a <xref:System.ServiceModel.FaultException%601> exception when a divide by zero exception occurs as shown in the following sample code. This exception results in a fault being sent to the client.

```csharp
public int Divide(int n1, int n2)
{
    try
    {
        return n1 / n2;
    }
    catch (DivideByZeroException)
    {
        MathFault mf = new MathFault();
        mf.operation = "division";
        mf.problemType = "divide by zero";
        throw new FaultException<MathFault>(mf);
    }
}
```

The client code forces an error by requesting a division by zero. When you run the sample, the operation requests and responses are displayed in the client console window. You see the division by zero being reported as a fault. Press ENTER in the client window to shut down the client.

```console
Add(15,3) = 18
Subtract(145,76) = 69
Multiply(9,81) = 729
FaultException<MathFault>: Math fault while doing division. Problem: divide by zero

Press <ENTER> to terminate client.
```

The client does this by catching the appropriate `FaultException<MathFault>` exception:

```csharp
catch (FaultException<MathFault> e)
{
    Console.WriteLine("FaultException<MathFault>: Math fault while doing " + e.Detail.operation + ". Problem: " + e.Detail.problemType);
    client.Abort();
}
```

By default, the details of unexpected exceptions are not sent to the client to prevent details of the service implementation from escaping the secure boundary of the service. `FaultContract` provides a way to describe faults in a contract and mark certain types of exceptions as appropriate for transmission to the client. `FaultException<T>` provides the run-time mechanism for sending faults to consumers.

However, it is useful to see the internal details of a service failure when debugging. To turn off the secure behavior previously described, you can indicate that the details of every unhandled exception on the server should be included in the fault that is sent to the client. This is accomplished by setting <xref:System.ServiceModel.ServiceBehaviorAttribute.IncludeExceptionDetailInFaults%2A> to `true`. You can either set it in code, or in configuration as shown in the following sample.

```xml
<behaviors>
  <serviceBehaviors>
    <behavior name="CalculatorServiceBehavior">
      <serviceMetadata httpGetEnabled="True"/>
      <serviceDebug includeExceptionDetailInFaults="True" />
    </behavior>
  </serviceBehaviors>
</behaviors>
```

Further, the behavior must be associated with the service by setting the `behaviorConfiguration` attribute of the service in the configuration file to "CalculatorServiceBehavior".

To catch such faults on the client, the non-generic <xref:System.ServiceModel.FaultException> must be caught.

This behavior should only be used for debugging purposes and should never be enabled in production.

### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).
