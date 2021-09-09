---
description: "Learn more about: Custom Binding Transport and Encoding"
title: "Custom Binding Transport and Encoding"
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: 6c0b353d-79ee-4e61-b348-be49ad0e9a16
---
# Custom Binding Transport and Encoding

The [Transport sample](https://github.com/dotnet/samples/tree/main/framework/wcf/Basic/Binding/Custom/Transport) demonstrates how to configure a custom binding with various transport and message encoding elements. A custom binding is defined by an ordered list of discrete binding elements.

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

This sample is based on the [Self-Host](self-host.md), and has been modified to configure three endpoints to support HTTP, TCP, and NamedPipe transports with custom bindings. The client configuration was similarly modified, and the client code changed to communicate with each of the three endpoints.

The sample demonstrates a how to configure a custom binding that supports a particular transport and message encoding. This is accomplished by configuring a transport and a message encoding for the `binding` element. The ordering of binding elements is important in defining a custom binding, because each represents a layer in the channel stack (see [Custom Bindings](../extending/custom-bindings.md)). This sample configures three custom bindings: an HTTP transport with text encoding, a TCP transport with text encoding, and a NamedPipe transport with a binary encoding.

The service configuration defines the custom bindings as follows:

```xml
<bindings>
    <customBinding>
        <binding name="HttpBinding" >
            <textMessageEncoding
                messageVersion="Soap12Addressing10"/>
            <httpTransport />
        </binding>
        <binding name="TcpBinding" >
            <textMessageEncoding />
            <tcpTransport />
        </binding>
        <binding name="NamedPipeBinding" >
            <binaryMessageEncoding />
            <namedPipeTransport />
        </binding>
    </customBinding>
</bindings>
```

When you run the sample, the operation requests and responses are displayed in both the service and client console window. The client communicates with each of the three endpoints, accessing first HTTP, then TCP, and finally NamedPipe. Press ENTER in each console window to shut down the service and client.

The `namedPipeTransport` binding does not support machine-to-machine operations. It is used only for communication on the same machine. Therefore, when running the sample in a cross-machine scenario, comment out the following lines in the client code file:

```csharp
CalculatorClient client = new CalculatorClient("default");
Console.WriteLine("Communicate with named pipe endpoint.");
// Call operations.
DoCalculations(client);
//Closing the client gracefully closes the connection and cleans up resources
client.Close();
```

```vb
Dim client As New CalculatorClient("default")
Console.WriteLine("Communicate with named pipe endpoint.")
' call operations
DoCalculations(client)
'Closing the client gracefully closes the connection and cleans up resources
client.Close()
```

> [!NOTE]
> If you use Svcutil.exe to regenerate the configuration for this sample, be sure to modify the endpoint name in the client configuration to match the client code.

### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C#, C++, or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).
