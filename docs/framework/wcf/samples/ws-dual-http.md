---
description: "Learn more about: WS Dual Http"
title: "WS Dual Http"
ms.date: "03/30/2017"
ms.assetid: 9997eba5-29ec-48db-86f3-fa77b241fb1a
---
# WS Dual Http

The [DualHttp sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how to configure the `WSDualHttpBinding` binding. This sample consists of a client console program (.exe) and a service library (.dll) hosted by Internet Information Services (IIS). The service implements a duplex contract. The contract is defined by the `ICalculatorDuplex` interface, which exposes math operations (Add, Subtract, Multiply, and Divide). In this sample, the `ICalculatorDuplex` interface allows the client to perform math operations, calculating a running result over the session. Independently, the service returns results on the `ICalculatorDuplexCallback` interface. A duplex contract requires a session, because a context must be established to correlate the set of messages being sent between client and service. The `WSDualHttpBinding` binding supports duplex communication.

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

To configure a service endpoint with the `WSDualHttpBinding`, specify the binding in the endpoint configuration as shown.

```xml
<endpoint address=""
         binding="wsDualHttpBinding"
         contract="Microsoft.ServiceModel.Samples.ICalculatorDuplex" />
```

On the client, you must configure an address that the server can use to connect to the client as shown in the following sample configuration.

```xml
<system.serviceModel>
  <client>
    <endpoint address=
         "http://localhost/servicemodelsamples/service.svc"
         binding="wsDualHttpBinding"
         bindingConfiguration="Binding1"
         contract="Microsoft.ServiceModel.Samples.ICalculatorDuplex" />
  </client>

  <bindings>
    <!-- Configure a WSDualHttpBinding that supports duplex -->
    <!-- communication. -->
    <wsDualHttpBinding>
      <binding name="Binding1"
               clientBaseAddress="http://localhost:8000/myClient/"
               useDefaultWebProxy="true"
               bypassProxyOnLocal="false">
      </binding>
    </wsDualHttpBinding>
  </bindings>
</system.serviceModel>
```

When you run the sample, the operation requests and responses are displayed in the client console window. Press ENTER in the client window to shut down the client.

```console
Press <ENTER> to terminate client once the output is displayed.

Result(100)
Result(50)
Result(882.5)
Result(441.25)
Equation(0 + 100 - 50 * 17.65 / 2 = 441.25)
```

When you run the sample, you see the messages returned to the client on the callback interface sent from the service. Each intermediate result is displayed, followed by the entire equation upon completion of all operations. Press ENTER to shut down the client.

### To set up, build, and run the sample

1. Install ASP.NET 4.0 using the following command.

    ```console
    %windir%\Microsoft.NET\Framework\v4.0.XXXXX\aspnet_regiis.exe /i /enable
    ```

2. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

3. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

4. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).

    > [!IMPORTANT]
    > When running the client in a cross-machine configuration, be sure to replace localhost in both the `address` attribute of the [\<endpoint> of \<client>](../../configure-apps/file-schema/wcf/endpoint-of-client.md) element and the `clientBaseAddress` attribute of the [\<binding>](../../configure-apps/file-schema/wcf/bindings.md) element of the [\<wsDualHttpBinding>](../../configure-apps/file-schema/wcf/wsdualhttpbinding.md) element with the name of the appropriate machine, as shown:

    ```xml
    <client>
        <endpoint name = ""
          address=
         "http://service_machine_name/servicemodelsamples/service.svc"
        />
    </client>
    ...
    <wsDualHttpBinding>
        <binding name="DuplexBinding" clientBaseAddress=
            "http://client_machine_name:8000/myClient/">
        </binding>
    </wsDualHttpBinding>
    ```
