---
description: "Learn more about: WS Transport Security"
title: "WS Transport Security"
ms.date: "03/30/2017"
ms.assetid: 33a20358-5e1b-458a-a6a9-15753bc7b99b
---
# WS Transport Security

The [wsTransportSecurity sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates the use of SSL transport security with the <xref:System.ServiceModel.WSHttpBinding> binding. By default, the `wsHttpBinding` binding provides HTTP communication. When configured for transport security, the binding supports HTTPS communication. This sample is based on the [Getting Started](getting-started-sample.md) that implements a calculator service. The `wsHttpBinding` is specified and configured in the application configuration files for the client and service.

> [!NOTE]
> The set-up procedure and build instructions for this sample are located at the end of this topic.

The program code in the sample is identical to that of the [Getting Started](getting-started-sample.md) service. You must create a certificate and assign it by using the Web Server Certificate Wizard before building and running the sample. The endpoint definition and binding definition in the configuration file settings enable `Transport` security mode, as shown in the following sample configuration for the client.

```xml
<system.serviceModel>

    <client>
      <!-- this endpoint has an https: address -->
      <endpoint address="https://localhost/servicemodelsamples/service.svc" binding="wsHttpBinding" bindingConfiguration="Binding1" contract="Microsoft.Samples.TransportSecurity.ICalculator"/>
    </client>

    <bindings>
      <wsHttpBinding>
        <!-- configure wsHttpbinding with Transport security mode
                   and clientCredentialType as None -->
        <binding name="Binding1">
          <security mode="Transport">
            <transport clientCredentialType="None"/>
          </security>
        </binding>
      </wsHttpBinding>
    </bindings>

  </system.serviceModel>
```

The address specified uses the `https://` scheme. The binding configuration sets the security mode to `Transport`. The same security mode must be specified in the service's Web.config file.

Because the certificate used in this sample is a test certificate created with Makecert.exe, a security alert appears when you try to access an https: address, such as `https://localhost/servicemodelsamples/service.svc`, from your browser. To allow the Windows Communication Foundation (WCF) client to work with a test certificate in place, some additional code has been added to the client to suppress the security alert. This code, and the accompanying class, is not required when using production certificates.

```csharp
// This code is required only for test certificates like those created by Makecert.exe.
PermissiveCertificatePolicy.Enact("CN=ServiceModelSamples-HTTPS-Server");
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

3. Ensure that you have performed the [Internet Information Services (IIS) Server Certificate Installation Instructions](iis-server-certificate-installation-instructions.md).

4. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

5. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).
