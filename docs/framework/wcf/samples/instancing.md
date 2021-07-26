---
description: "Learn more about: Instancing"
title: "Instancing"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "service behaviors, instancing sample"
  - "Instancing Sample [Windows Communication Foundation]"
ms.assetid: c290fa54-f6ae-45a1-9186-d9504ebc6ee6
---
# Instancing

The [Instancing sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates the instancing behavior setting, which controls how instances of a service class are created in response to client requests. The sample is based on the [Getting Started](getting-started-sample.md), which implements the `ICalculator` service contract. This sample defines a new contract, `ICalculatorInstance`, which inherits from `ICalculator`. The contract specified by `ICalculatorInstance` provides three additional operations for inspecting the state of the service instance. By altering the instancing setting, you can observe the change in behavior by running the client.

In this sample, the client is a console application (.exe) and the service is hosted by Internet Information Services (IIS).

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

The following instancing modes are available:

- <xref:System.ServiceModel.InstanceContextMode.PerCall>: A new service instance is created for each client request.

- <xref:System.ServiceModel.InstanceContextMode.PerSession>: A new instance is created for each new client session, and maintained for the lifetime of that session (requires a binding that supports session).

- <xref:System.ServiceModel.InstanceContextMode.Single>: A single instance of the service class handles all client requests for the lifetime of the application.

The service class specifies instancing behavior with the `[ServiceBehavior(InstanceContextMode=<setting>)]` attribute as shown in the code sample that follows. By changing which lines are commented out, you can observe the behavior of each of the instance modes. Remember to rebuild the service after changing the instancing mode. There are no instancing-related settings to specify on the client.

```csharp
// Enable one of the following instance modes to compare instancing behaviors.
 [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession)]

// PerCall creates a new instance for each operation.
//[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]

// Singleton creates a single instance for application lifetime.
//[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
public class CalculatorService : ICalculatorInstance
{
    static Object syncObject = new object();
    static int instanceCount;
    int instanceId;
    int operationCount;

    public CalculatorService()
    {
        lock (syncObject)
        {
            instanceCount++;
            instanceId = instanceCount;
        }
    }

    public double Add(double n1, double n2)
    {
        operationCount++;
        return n1 + n2;
    }

    public double Subtract(double n1, double n2)
    {
        Interlocked.Increment(ref operationCount);
        return n1 - n2;
    }

    public double Multiply(double n1, double n2)
    {
        Interlocked.Increment(ref operationCount);
        return n1 * n2;
    }

    public double Divide(double n1, double n2)
    {
        Interlocked.Increment(ref operationCount);
        return n1 / n2;
    }

    public string GetInstanceContextMode()
    {   // Return the InstanceContextMode of the service
        ServiceHost host = (ServiceHost)OperationContext.Current.Host;
        ServiceBehaviorAttribute behavior = host.Description.Behaviors.Find<ServiceBehaviorAttribute>();
        return behavior.InstanceContextMode.ToString();
    }

    public int GetInstanceId()
    {   // Return the id for this instance
        return instanceId;
    }

    public int GetOperationCount()
    {   // Return the number of ICalculator operations performed
        // on this instance
        lock (syncObject)
        {
            return operationCount;
        }
    }
}

static void Main()
{
    // Create a client.
    CalculatorInstanceClient client = new CalculatorInstanceClient();
    string instanceMode = client.GetInstanceContextMode();
    Console.WriteLine("InstanceContextMode: {0}", instanceMode);
    DoCalculations(client);

    // Create a second client.
    CalculatorInstanceClient client2 = new CalculatorInstanceClient();

    DoCalculations(client2);

    Console.WriteLine();
    Console.WriteLine("Press <ENTER> to terminate client.");
    Console.ReadLine();
}
```

When you run the sample, the operation requests and responses are displayed in the client console window. The instance mode the service is running under is displayed. After each operation, the instance ID and operation count are displayed to reflect the behavior of the instancing mode. Press ENTER in the client window to shut down the client.

### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).
