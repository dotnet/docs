---
description: "Learn more about: Default NetTcpBinding"
title: "Default NetTcpBinding"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "Net profile TCP"
ms.assetid: e8475fe6-0ecd-407a-8e7e-45860561bb74
---
# Default NetTcpBinding

The [Default sample](https://github.com/dotnet/samples/tree/main/framework/wcf/Basic/Binding/Net/Tcp/Default/CS) demonstrates the use of the <xref:System.ServiceModel.NetTcpBinding> binding. This sample is based on the [Getting Started](getting-started-sample.md) that implements a calculator service. In this sample, the service is self-hosted. Both the client and service are console applications.

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

The binding is specified in the configuration files for the client and service. The binding type is specified in the `binding` attribute of the [\<endpoint>](../../configure-apps/file-schema/wcf/endpoint-element.md) element as shown in the following sample configuration.

```xml
<endpoint address=""
          binding="netTcpBinding"
          contract="Microsoft.ServiceModel.Samples.ICalculator" />
```

The previous sample shows how to configure an endpoint to use the `netTcpBinding` binding with the default settings. If you want to configure the `netTcpBinding` binding and change some of its settings, it is necessary to define a binding configuration. The endpoint must reference the binding configuration by name with a `bindingConfiguration` attribute. In this sample, the binding configuration is named `Binding1` and is defined as shown in the following sample configuration.

```xml
<services>
  <service name="Microsoft.ServiceModel.Samples.CalculatorService"
           behaviorConfiguration="CalculatorServiceBehavior">
    ...
    <endpoint address=""
              binding="netTcpBinding"
              bindingConfiguration="Binding1"
              contract="Microsoft.ServiceModel.Samples.ICalculator" />
    ...
  </service>
</services>

<bindings>
  <netTcpBinding>
    <binding name="Binding1"
             closeTimeout="00:01:00"
             openTimeout="00:01:00"
             receiveTimeout="00:10:00"
             sendTimeout="00:01:00"
             transactionFlow="false"
             transferMode="Buffered"
             transactionProtocol="OleTransactions"
             hostNameComparisonMode="StrongWildcard"
             listenBacklog="10"
             maxBufferPoolSize="524288"
             maxBufferSize="65536"
             maxConnections="10"
             maxReceivedMessageSize="65536">
      <readerQuotas maxDepth="32"
                    maxStringContentLength="8192"
                    maxArrayLength="16384"
                    maxBytesPerRead="4096"
                    maxNameTableCharCount="16384" />
      <reliableSession ordered="true"
                       inactivityTimeout="00:10:00"
                       enabled="false" />
      <security mode="Transport">
        <transport clientCredentialType="Windows" protectionLevel="EncryptAndSign" />
      </security>
    </binding>
  </netTcpBinding>
</bindings>
```

When you run the sample, the operation requests and responses are displayed in the client console window. Press ENTER in the client window to shut down the client.

```console
Add(100,15.99) = 115.99
Subtract(145,76.54) = 68.46
Multiply(9,81.25) = 731.25
Divide(22,7) = 3.14285714285714

Press ENTER to terminate client.
```

### To set up, build, and run the sample

1. Install ASP.NET 4.0 using the following command.

    ```console
    %windir%\Microsoft.NET\Framework\v4.0.XXXXX\aspnet_regiis.exe /i /enable
    ```

2. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

3. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

4. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).

    > [!NOTE]
    > Because the server is self-hosted, you must specify an identity in the client's App.config file to run the sample in a cross-machine configuration.

    ```xml
    <client>
      <endpoint name=""
          address="net.tcp://servername:9000/servicemodelsamples/service"
          binding="netTcpBinding"
          contract="Microsoft.ServiceModel.Samples.ICalculator">
            <identity>
              <userPrincipalName value = "user_name@service_domain"/>
            </identity>
      </endpoint>
    </client>
    ```
