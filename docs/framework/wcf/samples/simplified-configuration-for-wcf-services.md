---
title: "Simplified Configuration for WCF Services"
description: Learn how to implement and configure a typical service and client using WCF. The service communicates by using an endpoint specified in a configuration file.
ms.date: "03/30/2017"
ms.assetid: 1e39ec25-18a3-4fdc-b6a3-9dfafbd60112
---
# Simplified Configuration for WCF Services

The [ConfigSimplificationIn40 sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how to implement and configure a typical service and client using Windows Communication Foundation (WCF). This sample is the basis for all other basic technology samples.

This service, which exposes an endpoint for communicating with the service, uses the simplified configuration in .NET Framework 4. Prior to .NET Framework 4, the endpoint is typically defined in a configuration file (Web.config), as shown in the following example configuration code.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<!-- Copyright ©) Microsoft Corporation. All Rights Reserved. -->
<configuration>
  <system.serviceModel>
    <behaviors>
      <serviceBehaviors>
        <behavior name="CalculatorServiceBehavior">
          <serviceMetadata httpGetEnabled="True"/>
        </behavior>
      </serviceBehaviors>
    </behaviors>
    <services>
      <service name="Microsoft.Samples.GettingStarted.CalculatorService"
               behaviorConfiguration="CalculatorServiceBehavior">
        <endpoint address="" binding="basicHttpBinding" contract="ICalculator"/>
        <endpoint address="mex" binding="mexHttpBinding" contract="IMetadataExchange"/>
      </service>
    </services>
  </system.serviceModel>
</configuration>
```

In .NET Framework 4, the `<service>` element is optional. When a service does not define any endpoints, an endpoint for each base address and contract implemented are added to the service. The base address is appended to the contract name to determine the endpoint and the binding is determined by the address scheme. The following code example demonstrates a simplified configuration file. As configured, the service can be accessed at `http://localhost/servicemodelsamples/service.svc` by a client on the same computer. For clients on remote computers to access the service, a fully-qualified domain name must be specified instead of localhost. The service does not expose metadata by default. As such, the service turns on the <xref:System.ServiceModel.Description.ServiceMetadataBehavior> behavior.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<!-- Copyright © Microsoft Corporation. All Rights Reserved. -->
<configuration>
  <system.serviceModel>
    <behaviors>
      <serviceBehaviors>
        <behavior name="">
          <serviceMetadata httpGetEnabled="True"/>
        </behavior>
      </serviceBehaviors>
    </behaviors>
  </system.serviceModel>
</configuration>
```

### To use this sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. Run the sample by following these steps:

    1. Right click the **Service** project and select **Set as StartUp project**, then press ****Ctrl**+**F5****.

    2. Wait for the console output confirming that the service is up and running.

    3. Right click the **Client** project and select **Set as StartUp project**, then press ****Ctrl**+**F5****.

## See also

- [AppFabric Management Samples](/previous-versions/appfabric/ff383405(v=azure.10))
- [Simplified Configuration](../simplified-configuration.md)
