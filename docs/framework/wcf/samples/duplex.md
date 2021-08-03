---
description: "Learn more about: Duplex"
title: "Duplex"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "Duplex Service Contract"
ms.assetid: bc5de6b6-1a63-42a3-919a-67d21bae24e0
---
# Duplex

The [Duplex sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how to define and implement a duplex contract. Duplex communication occurs when a client establishes a session with a service and gives the service a channel on which the service can send messages back to the client. This sample is based on the [Getting Started](getting-started-sample.md). A duplex contract is defined as a pair of interfaces—a primary interface from the client to the service and a callback interface from the service to the client. In this sample, the `ICalculatorDuplex` interface allows the client to perform math operations, calculating the result over a session. The service returns results on the `ICalculatorDuplexCallback` interface. A duplex contract requires a session, because a context must be established to correlate the set of messages being sent between the client and the service.

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

In this sample, the client is a console application (.exe) and the service is hosted by Internet Information Services (IIS). The duplex contract is defined as follows:

```csharp
[ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples", SessionMode=SessionMode.Required,
                 CallbackContract=typeof(ICalculatorDuplexCallback))]
public interface ICalculatorDuplex
{
    [OperationContract(IsOneWay = true)]
    void Clear();
    [OperationContract(IsOneWay = true)]
    void AddTo(double n);
    [OperationContract(IsOneWay = true)]
    void SubtractFrom(double n);
    [OperationContract(IsOneWay = true)]
    void MultiplyBy(double n);
    [OperationContract(IsOneWay = true)]
    void DivideBy(double n);
}

public interface ICalculatorDuplexCallback
{
    [OperationContract(IsOneWay = true)]
    void Result(double result);
    [OperationContract(IsOneWay = true)]
    void Equation(string eqn);
}
```

The `CalculatorService` class implements the primary `ICalculatorDuplex` interface. The service uses the <xref:System.ServiceModel.InstanceContextMode.PerSession> instance mode to maintain the result for each session. A private property named `Callback` is used to access the callback channel to the client. The service uses the callback for sending messages back to the client through the callback interface.

```csharp
[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
public class CalculatorService : ICalculatorDuplex
{
    double result = 0.0D;
    string equation;

    public CalculatorService()
    {
        equation = result.ToString();
    }

    public void Clear()
    {
        Callback.Equation($"{equation} = {result}");
        equation = result.ToString();
    }

    public void AddTo(double n)
    {
        result += n;
        equation += $" + {n}";
        Callback.Result(result);
    }

    //...

    ICalculatorDuplexCallback Callback
    {
        get
        {
            return OperationContext.Current.GetCallbackChannel<ICalculatorDuplexCallback>();
        }
    }
}
```

The client must provide a class that implements the callback interface of the duplex contract, for receiving messages from the service. In the sample, a `CallbackHandler` class is defined to implement the `ICalculatorDuplexCallback` interface.

```csharp
public class CallbackHandler : ICalculatorDuplexCallback
{
   public void Result(double result)
   {
      Console.WriteLine("Result({0})", result);
   }

   public void Equation(string equation)
   {
      Console.WriteLine("Equation({0}", equation);
   }
}
```

The proxy that is generated for a duplex contract requires a <xref:System.ServiceModel.InstanceContext> to be provided upon construction. This <xref:System.ServiceModel.InstanceContext> is used as the site for an object that implements the callback interface and handles messages that are sent back from the service. An <xref:System.ServiceModel.InstanceContext> is constructed with an instance of the `CallbackHandler` class. This object handles messages sent from the service to the client on the callback interface.

```csharp
// Construct InstanceContext to handle messages on callback interface.
InstanceContext instanceContext = new InstanceContext(new CallbackHandler());

// Create a client.
CalculatorDuplexClient client = new CalculatorDuplexClient(instanceContext);

Console.WriteLine("Press <ENTER> to terminate client once the output is displayed.");
Console.WriteLine();

// Call the AddTo service operation.
double value = 100.00D;
client.AddTo(value);

// Call the SubtractFrom service operation.
value = 50.00D;
client.SubtractFrom(value);

// Call the MultiplyBy service operation.
value = 17.65D;
client.MultiplyBy(value);

// Call the DivideBy service operation.
value = 2.00D;
client.DivideBy(value);

// Complete equation.
client.Clear();

Console.ReadLine();

//Closing the client gracefully closes the connection and cleans up resources.
client.Close();
```

The configuration has been modified to provide a binding that supports both session communication and duplex communication. The `wsDualHttpBinding` supports session communication and allows duplex communication by providing dual HTTP connections, one for each direction. On the service, the only difference in configuration is the binding that is used. On the client, you must configure an address that the server can use to connect to the client as shown in the following sample configuration.

```xml
<client>
  <endpoint name=""
            address="http://localhost/servicemodelsamples/service.svc"
            binding="wsDualHttpBinding"
            bindingConfiguration="DuplexBinding"
            contract="Microsoft.ServiceModel.Samples.ICalculatorDuplex" />
</client>

<bindings>
  <!-- Configure a binding that support duplex communication. -->
  <wsDualHttpBinding>
    <binding name="DuplexBinding"
             clientBaseAddress="http://localhost:8000/myClient/">
    </binding>
  </wsDualHttpBinding>
</bindings>
```

When you run the sample, you see the messages that are returned to the client on the callback interface that is sent from the service. Each intermediate result is displayed, followed by the entire equation upon the completion of all operations. Press ENTER to shut down the client.

### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C#, C++, or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).

    > [!IMPORTANT]
    > When running the client in a cross-machine configuration, be sure to replace "localhost" in both the `address` attribute of the [\<endpoint> of \<client>](../../configure-apps/file-schema/wcf/endpoint-of-client.md) element and the `clientBaseAddress` attribute of the [\<binding>](../../configure-apps/file-schema/wcf/bindings.md) element of the [\<wsDualHttpBinding>](../../configure-apps/file-schema/wcf/wsdualhttpbinding.md) element with the name of the appropriate machine, as shown in the following:

    ```xml
    <client>
        <endpoint name = ""
        address="http://service_machine_name/servicemodelsamples/service.svc"
        ... />
    </client>
    ...
    <wsDualHttpBinding>
        <binding name="DuplexBinding" clientBaseAddress="http://client_machine_name:8000/myClient/">
        </binding>
    </wsDualHttpBinding>
    ```
