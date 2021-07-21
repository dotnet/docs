---
description: "Learn more about: WS Reliable Session"
title: "WS Reliable Session"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "Reliable session"
ms.assetid: 86e914f2-060b-432b-bd17-333695317745
---
# WS Reliable Session

The [wsReliableSession sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates the use of reliable sessions. Reliable sessions provide support for reliable messaging and sessions. Reliable messaging retries communication on failure and allows delivery assurances to be specified, such as in-order arrival of messages. Sessions maintain state for clients between calls. The sample implements sessions for maintaining client state and specifies in-order delivery assurances.

This sample is based on the [Getting Started](getting-started-sample.md) that implements a calculator service. The reliable session features are enabled and configured in the application configuration files for the client and service.

In this sample, the service is hosted in Internet Information Services (IIS) and the client is a console application (.exe).

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

The sample uses the `wsHttpBinding`. The binding is specified in the configuration files for both the client and service. The binding type is specified in the endpoint element's `binding` attribute as shown in the following sample configuration.

```xml
<endpoint address=""
          binding="wsHttpBinding"
          bindingConfiguration="Binding1"
          contract="Microsoft.ServiceModel.Samples.ICalculator" />
```

The endpoint contains a `bindingConfiguration` attribute that references a binding configuration named "Binding1." The binding configuration enables reliable sessions by setting the `enabled` attribute of the [\<reliableSession>](../../configure-apps/file-schema/wcf/reliablesession.md) to `true`. Delivery assurances for ordered sessions are controlled by setting the ordered attribute to `true` or `false`. The default is `true`.

```xml
<bindings>
    <wsHttpBinding>
        <binding name="Binding1">
            <reliableSession enabled="true" />
        </binding>
    </wsHttpBinding>
</bindings>
```

The service implementation class implements <xref:System.ServiceModel.InstanceContextMode.PerSession> instancing to maintain a separate class instance for each client, as shown in the following sample code.

```csharp
[ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession)] public class CalculatorService : ICalculator
{
    ...
}
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

1. Install ASP.NET 4.0 using the following command.

    ```console
    %windir%\Microsoft.NET\Framework\v4.0.XXXXX\aspnet_regiis.exe /i /enable
    ```

2. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

3. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

4. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).
