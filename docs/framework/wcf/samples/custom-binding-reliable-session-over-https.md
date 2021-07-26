---
description: "Learn more about: Custom Binding Reliable Session over HTTPS"
title: "Custom Binding Reliable Session over HTTPS"
ms.date: "03/30/2017"
ms.assetid: 16aaa80d-3ffe-47c4-8b16-ec65c4d25f8d
---
# Custom Binding Reliable Session over HTTPS

The [ReliableSessionOverHttps sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates the use of SSL transport security with Reliable Sessions. Reliable Sessions implements the WS-Reliable Messaging protocol. You can have a secure reliable session by composing WS-Security over Reliable Sessions. But sometimes, you may choose to instead use HTTP transport security with SSL.

## Sample Details

SSL ensures that the packets themselves are secured. It is important to note that this is different from securing the reliable session using WS-Secure Conversation.

To use reliable session over HTTPS, you must create a custom binding. This sample is based on the [Getting Started](getting-started-sample.md) that implements a calculator service. A custom binding is created using the reliable session binding element and the [\<httpsTransport>](../../configure-apps/file-schema/wcf/httpstransport.md). The following configuration is of the custom binding.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <system.serviceModel>
    <services>
      <service
          name="Microsoft.ServiceModel.Samples.CalculatorService"
          behaviorConfiguration="CalculatorServiceBehavior">
        <!-- use base address provided by host -->
        <endpoint address=""
                  binding="customBinding"
                  bindingConfiguration="reliableSessionOverHttps"
                  contract="Microsoft.ServiceModel.Samples.ICalculator" />
        <!-- the mex endpoint is exposed as http://localhost/servicemodelsamples/service.svc/mex-->
        <endpoint address="mex"
                  binding="mexHttpBinding"
                  contract="IMetadataExchange"/>
      </service>
    </services>

    <bindings>
      <customBinding>
        <binding name="reliableSessionOverHttps">
          <reliableSession />
          <httpsTransport />
        </binding>
      </customBinding>
    </bindings>

    <!--For debugging purposes set the includeExceptionDetailInFaults attribute to true-->
    <behaviors>
      <serviceBehaviors>
        <behavior name="CalculatorServiceBehavior">
          <serviceMetadata httpGetEnabled="true" />
          <serviceDebug includeExceptionDetailInFaults="False" />
        </behavior>
      </serviceBehaviors>
    </behaviors>

  </system.serviceModel>

</configuration>
```

The program code in the sample is identical to that of the [Getting Started](getting-started-sample.md) service. You must create a certificate and assign it by using the Web Server Certificate Wizard before building and running the sample. The endpoint definition and binding definition in the configuration file settings enable the use of custom binding as shown in the following sample configuration for the client.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <system.serviceModel>

    <client>
      <!-- this endpoint has an https: address -->
      <endpoint name=""
                address="https://localhost/servicemodelsamples/service.svc"
                binding="customBinding"
                bindingConfiguration="reliableSessionOverHttps"
                contract="Microsoft.ServiceModel.Samples.ICalculator" />
    </client>

      <bindings>
        <customBinding>
          <binding name="reliableSessionOverHttps">
            <reliableSession />
            <httpsTransport />
          </binding>
        </customBinding>
    </bindings>

  </system.serviceModel>

</configuration>
```

The address specified uses the `https://` scheme.

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

#### To set up, build, and run the sample

1. Install  ASP.NET 4.0 using the following command.

    ```console
    %windir%\Microsoft.NET\Framework\v4.0.XXXXX\aspnet_regiis.exe /i /enable
    ```

2. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

3. Ensure that you have performed the [Internet Information Services (IIS) Server Certificate Installation Instructions](iis-server-certificate-installation-instructions.md).

4. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

5. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).
