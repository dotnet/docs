---
description: "Learn more about: NetNamedPipeBinding"
title: "NetNamedPipeBinding"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "Net Profile Named Pipe"
ms.assetid: e78e845f-c325-46e2-927d-81616f97f7d5
---
# NetNamedPipeBinding

The [NamedPipe sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates the `netNamedPipeBinding` binding, which provides cross-process communication on the same machine. Named pipes do not work across machines. This sample is based on The [Getting Started](getting-started-sample.md) calculator service.

In this sample, the service is self-hosted. Both the client and the service are console applications.

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

The binding is specified in the configuration files for the client and service. The binding type is specified in the `binding` attribute of the [\<endpoint>](../../configure-apps/file-schema/wcf/endpoint-element.md) or [\<endpoint> of \<client>](../../configure-apps/file-schema/wcf/endpoint-of-client.md) element, as shown in the following sample configuration:

```xml
<endpoint address="net.pipe://localhost/ServiceModelSamples/service"
          binding="netNamedPipeBinding"
          contract="Microsoft.ServiceModel.Samples.ICalculator" />
```

The previous sample shows how to configure an endpoint to use the `netNamedPipeBinding` binding with the default settings. If you want to configure the `netNamedPipeBinding` binding and change some of its settings, you must define a binding configuration. The endpoint must reference the binding configuration by name with a `bindingConfiguration` attribute.

```xml
<endpoint address="net.pipe://localhost/ServiceModelSamples/service"
          binding="netNamedPipeBinding"
          bindingConfiguration="Binding1"
          contract="Microsoft.ServiceModel.Samples.ICalculator" />
```

In this sample, the binding configuration is named `Binding1` and has the following definition:

```xml
<bindings>
  <!--
        Following is the expanded configuration section for a NetNamedPipeBinding.
        Each property is configured with the default value.
     -->
  <netNamedPipeBinding>
    <binding name="Binding1"
             closeTimeout="00:01:00"
             openTimeout="00:01:00"
             receiveTimeout="00:10:00"
             sendTimeout="00:01:00"
             transactionFlow="false"
             transferMode="Buffered"
             transactionProtocol="OleTransactions"
             hostNameComparisonMode="StrongWildcard"
             maxBufferPoolSize="524288"
             maxBufferSize="65536"
             maxConnections="10"
             maxReceivedMessageSize="65536">
      <security mode="Transport">
        <transport protectionLevel="EncryptAndSign" />
      </security>
    </binding>
  </netNamedPipeBinding>
</bindings>
```

When you run the sample, the operation requests and responses are displayed in the client console window. Press ENTER in the client window to shut down the client.

```console
Add(100,15.99) = 115.99
Subtract(145,76.54) = 68.46
Multiply(9,81.25) = 731.25
Divide(22,7) = 3.14285714285714

Press <ENTER> to terminate client.
```

### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. To run the sample in a single machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).
