---
title: "Tutorial: Configure a Basic Windows Communication Foundation client"
ms.date: 01/18/2019
helpviewer_keywords:
  - "WCF clients [WCF], configuring"
ms.assetid: d067b86d-afb0-47bf-94f6-45180a3d8d78
---
# Tutorial: Configure a basic Windows Communication Foundation client

This tutorial describes the fifth of six tasks required to create a basic Windows Communication Foundation (WCF) application. For an overview of the tutorials, see [Tutorial: Get started with Windows Communication Foundation applications](getting-started-tutorial.md).

This article describes the client configuration file. You generate this file with the **Add Service Reference** function in Visual Studio or the [ServiceModel Metadata Utility tool (Svcutil.exe)](servicemodel-metadata-utility-tool-svcutil-exe.md). When you configure the client, you specify the endpoint that the client uses to access the service. An endpoint has an address, a binding, and a contract. Specify each of these items when you configure the client.

## Configure a Windows Communication Foundation client

Open the client configuration file (App.config) in the GettingStartedClient project and verify it's similar to this example. Under the [\<system.serviceModel>](../../../docs/framework/configure-apps/file-schema/wcf/system-servicemodel.md) section, find the [\<endpoint>](../../../docs/framework/configure-apps/file-schema/wcf/endpoint-element.md) element.

```xml
    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
        <startup>
            <!-- specifies the version of WCF to use-->
            <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.6.1" />
        </startup>
        <system.serviceModel>
            <bindings>
                <!-- Uses wsHttpBinding-->
                <wsHttpBinding>
                    <binding name="WSHttpBinding_ICalculator" />
                </wsHttpBinding>
            </bindings>
            <client>
                <!-- specifies the endpoint to use when calling the service -->
                <endpoint address="http://localhost:8000/GettingStarted/CalculatorService"
                    binding="wsHttpBinding" bindingConfiguration="WSHttpBinding_ICalculator"
                    contract="ServiceReference1.ICalculator" name="WSHttpBinding_ICalculator">
                    <identity>
                        <dns value="localhost" />
                    </identity>
                </endpoint>
            </client>
        </system.serviceModel>
    </configuration>
```

This example configures the endpoint that the client uses to access the service that's located at the following address: `http://localhost:8000/GettingStarted/CalculatorService`.

The endpoint element specifies that the `ServiceReference1.ICalculator` service contract is used for communication between the WCF client and service. The WCF channel is configured with the system-provided <xref:System.ServiceModel.WSHttpBinding>. Visual Studio generated this contract when you used its **Add Service Reference** function. It's essentially a copy of the contract that you defined in the GettingStartedLib project. The <xref:System.ServiceModel.WSHttpBinding> binding specifies HTTP as the transport, interoperable security, and other configuration details.

For more info about how to use the generated client with this configuration, see [Tutorial: Use a client](how-to-use-a-wcf-client.md).

## Next steps

> [!div class="nextstepaction"]
> [Tutorial: Use a WCF client](how-to-use-a-wcf-client.md)

## See also

- [Using bindings to configure services and clients](using-bindings-to-configure-services-and-clients.md)
- [ServiceModel Metadata Utility Tool (Svcutil.exe)](servicemodel-metadata-utility-tool-svcutil-exe.md)
- [Tutorial: Create a client](how-to-create-a-wcf-client.md)
- [Getting started sample](samples/getting-started-sample.md)
- [Self-Host](samples/self-host.md)