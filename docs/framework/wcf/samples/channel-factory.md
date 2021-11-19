---
description: "Learn more about: Channel Factory"
title: "Channel Factory"
ms.date: "03/30/2017"
ms.assetid: 09b53aa1-b13c-476c-a461-e82fcacd2a8b
---
# Channel Factory

The [ChannelFactory sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how a client application can create a channel with the <xref:System.ServiceModel.ChannelFactory> class instead of a generated client. This sample is based on the [Getting Started](getting-started-sample.md) that implements a calculator service.

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

This sample uses the <xref:System.ServiceModel.ChannelFactory%601> class to create a channel to a service endpoint. Typically, to create a channel to a service endpoint you generate a client type with the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../servicemodel-metadata-utility-tool-svcutil-exe.md) and create an instance of the generated type. You can also create a channel by using the <xref:System.ServiceModel.ChannelFactory%601> class, as demonstrated in this sample. The service created by the following sample code is identical to the service in the [Getting Started](getting-started-sample.md).

```csharp
EndpointAddress address = new EndpointAddress("http://localhost/servicemodelsamples/service.svc");
WSHttpBinding binding = new WSHttpBinding();
ChannelFactory<ICalculator> factory = new
                    ChannelFactory<ICalculator>(binding, address);
ICalculator channel = factory.CreateChannel();
```

> [!IMPORTANT]
> If you are running this sample in a cross-machine scenario, you must replace "localhost" in the preceding code with the fully-qualified name of the machine that is running the service. This sample does not use configuration to set the endpoint address, so this must be done in code.

Once the channel is created, service operations can be invoked just as with a generated client.

```csharp
// Call the Add service operation.
double value1 = 100.00D;
double value2 = 15.99D;
double result = channel.Add(value1, value2);
Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);
```

To close the channel, it must first be cast to an <xref:System.ServiceModel.IClientChannel> interface. This is because the channel as generated is declared in the client application using the `ICalculator` interface, which has methods like `Add` and `Subtract` but not `Close`. The `Close` method originates on the <xref:System.ServiceModel.ICommunicationObject> interface.

```csharp
// Close the channel.
 ((IClientChannel)client).Close();
```

When you run the sample, the operation requests and responses are displayed in the client console window. Press ENTER in the client window to shut down the client application.

```console
Add(100,15.99) = 115.99
Subtract(145,76.54) = 68.46
Multiply(9,81.25) = 731.25
Divide(22,7) = 3.14285714285714

Press <ENTER> to terminate client.
```

### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md). Note that this sample does not enable metadata publishing. You must first enable metadata publishing for this sample to regenerate the client type.

3. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).

### To run the sample cross machine

Replace "localhost" in the following code with the fully-qualified name of the machine that is running the service.

```csharp
EndpointAddress address = new EndpointAddress("http://localhost/servicemodelsamples/service.svc");
```
