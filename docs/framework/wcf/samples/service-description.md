---
description: "Learn more about: Service Description"
title: "Service Description"
ms.date: "03/30/2017"
ms.assetid: 7034b5d6-d608-45f3-b57d-ec135f83ff24
---
# Service Description

The [ServiceDescription sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how a service can retrieve its service description information at runtime. The sample is based on the [Getting Started](getting-started-sample.md), with an additional service operation defined to return descriptive information about the service. The information that is returned lists the base addresses and endpoints for the service. The service provides this information using the <xref:System.ServiceModel.OperationContext>, <xref:System.ServiceModel.ServiceHost>, and <xref:System.ServiceModel.Description.ServiceDescription> classes.

In this sample, the client is a console application (.exe) and the service is hosted by Internet Information Services (IIS).

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

This sample has a modified version of the calculator contract called `IServiceDescriptionCalculator`. The contract defines an additional service operation named `GetServiceDescriptionInfo` that returns a multi-line string to the client that describes the base address or addresses and service endpoint or endpoints for the service.

```csharp
[ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]
public interface IServiceDescriptionCalculator
{
    [OperationContract]
    int Add(int n1, int n2);
    [OperationContract]
    int Subtract(int n1, int n2);
    [OperationContract]
    int Multiply(int n1, int n2);
    [OperationContract]
    int Divide(int n1, int n2);
    [OperationContract]
    string GetServiceDescriptionInfo();
}
```

The implementation code for `GetServiceDescriptionInfo` uses the <xref:System.ServiceModel.Description.ServiceDescription> to list the service endpoints. Because service endpoints can have relative addresses, it first lists the base addresses for the service. To get all of this information, the code obtains its operation context using <xref:System.ServiceModel.OperationContext.Current%2A>. The <xref:System.ServiceModel.ServiceHost> and its <xref:System.ServiceModel.Description.ServiceDescription> object are retrieved from the operation context. To list the base endpoints for the service, the code iterates through the service host's <xref:System.ServiceModel.ServiceHostBase.BaseAddresses%2A> collection. To list the service endpoints for the service, the code iterates through the service description's endpoints collection.

```csharp
public string GetServiceDescriptionInfo()
{
    string info = "";
    OperationContext operationContext = OperationContext.Current;
    ServiceHost host = (ServiceHost)operationContext.Host;
    ServiceDescription desc = host.Description;
    // Enumerate the base addresses in the service host.
    info += "Base addresses:\n";
    foreach (Uri uri in host.BaseAddresses)
    {
        info += "    " + uri + "\n";
    }
    // Enumerate the service endpoints in the service description.
    info += "Service endpoints:\n";
    foreach (ServiceEndpoint endpoint in desc.Endpoints)
    {
        info += "    Address:  " + endpoint.Address + "\n";
        info += "    Binding:  " + endpoint.Binding.Name + "\n";
        info += "    Contract: " + endpoint.Contract.Name + "\n";
    }
     return info;
}
```

When you run the sample, you see the calculator operations and then the service information returned by the `GetServiceDescriptionInfo` operation. Press ENTER in the client window to shut down the client.

```console
Add(15,3) = 18
Subtract(145,76) = 69
Multiply(9,81) = 729
Divide(22,7) = 3
GetServiceDescriptionInfo
Base addresses:
    http://<machine-name>/ServiceModelSamples/service.svc
    https://<machine-name>/ServiceModelSamples/service.svc
Service endpoints:
    Address:  http://<machine-name>/ServiceModelSamples/service.svc
    Binding:  WSHttpBinding
    Contract: IServiceDescriptionCalculator
    Address:  http://<machine-name>/ServiceModelSamples/service.svc/mex
    Binding:  MetadataExchangeHttpBinding
    Contract: IMetadataExchange

Press <ENTER> to terminate client.
```

### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).
