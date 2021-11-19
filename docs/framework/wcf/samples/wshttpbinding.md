---
description: "Learn more about: WSHttpBinding"
title: "WSHttpBinding"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "WS Profile binding"
ms.assetid: 22d85b19-0135-4141-9179-a0e9c343ad73
---
# WSHttpBinding

The [wsHttp sample](https://github.com/dotnet/samples/tree/main/framework/wcf/Basic/Binding/WS/wsHttp/CS) demonstrates how to implement a typical service and a typical client using Windows Communication Foundation (WCF). This sample consists of a client console program (client.exe) and a service library hosted by Internet Information Services (IIS). The service implements a contract that defines a request-reply communication pattern. The contract is defined by the `ICalculator` interface, which exposes math operations (add, subtract, multiply, and divide). The client makes synchronous requests to a given math operation and the service replies with the result. Client activity is visible in the console window.

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

This sample exposes the `ICalculator` contract using the [\<wsHttpBinding>](../../configure-apps/file-schema/wcf/wshttpbinding.md). The configuration of this binding has been expanded in the Web.config file.

```xml
<bindings>
  <wsHttpBinding>
    <!--The following is the expanded configuration section for a-->
    <!--WSHttpBinding. Each property is configured with the default-->
    <!--value. See the ReliableSession, TransactionFlow, -->
    <!--TransportSecurity, and MessageSecurity samples in the WS -->
    <!--directory to learn how to configure these features. -->
    <binding name="Binding1"
              bypassProxyOnLocal="false"
              transactionFlow="false"
              hostNameComparisonMode="StrongWildcard"
              maxBufferPoolSize="524288"
              maxReceivedMessageSize="65536"
              messageEncoding="Text"
              textEncoding="utf-8"
              useDefaultWebProxy="true"
              allowCookies="false">
      <reliableSession ordered="true"
                       inactivityTimeout="00:10:00"
                       enabled="false" />
      <security mode="Message">
        <message clientCredentialType="Windows"
                 negotiateServiceCredential="true"
                 algorithmSuite="Default"
                 establishSecurityContext="true" />
      </security>
    </binding>
  </wsHttpBinding>
</bindings>
```

On the base `binding` element, the `maxReceivedMessageSize` value lets you configure the maximum size of an incoming message (in bytes). The `hostNameComparisonMode` value lets you configure whether the hostname is considered when de-multiplexing messages to the service. The `messageEncoding` value lets you configure whether to use Text or MTOM encoding for messages. The `textEncoding` value lets you configure the character encoding for messages. The `bypassProxyOnLocal` value lets you configure whether to use an HTTP proxy for local communication. The `transactionFlow` value configures whether the current transaction is flowed (if an operation is configured for transaction flow).

On the [\<reliableSession>](../../configure-apps/file-schema/wcf/reliablesession.md) element, the enabled Boolean value configures whether reliable sessions are enabled. The `ordered` value configures whether message ordering is preserved. The `inactivityTimeout` value configures how long a session can be idle before being faulted.

On the [\<security>](../../configure-apps/file-schema/wcf/security-of-wshttpbinding.md), the `mode` value configures which security mode should be used. In this sample, messages security is being used, which is why the [\<message>](../../configure-apps/file-schema/wcf/message-of-wshttpbinding.md) is specified inside the [\<security>](../../configure-apps/file-schema/wcf/security-of-wshttpbinding.md).

When you run the sample, the operation requests and responses are displayed in the client console window. Press ENTER in the client window to shut down the client.

```console
Add(100,15.99) = 115.99
Subtract(145,76.54) = 68.46
Multiply(9,81.25) = 731.25
Divide(22,7) = 3.14285714285714

Press <ENTER> to terminate client.
```

### To set up, build, and run the sample

1. Install ASP.NET 4.0 using the following command.

    ```console
    %windir%\Microsoft.NET\Framework\v4.0.XXXXX\aspnet_regiis.exe /i /enable
    ```

2. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

3. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

4. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).
