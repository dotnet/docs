---
description: "Learn more about: BasicBinding with Transport Security"
title: "BasicBinding with Transport Security"
ms.date: "03/30/2017"
ms.assetid: f49b1de6-0254-4362-8ef2-fccd8ff9688b
---
# BasicBinding with Transport Security

The [TransportSecurity sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates the use of SSL transport security with the basic binding. This sample is based on the [Getting Started](getting-started-sample.md) that implements a calculator service.

## Sample Details

By default, the basic binding supports HTTP communication. The sample shows how to enable transport security for the basic binding. Before you run the sample, you must create a certificate and assign it by using the Web Server Certificate Wizard.

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

The program code in the sample is identical to that of the [Getting Started](getting-started-sample.md) service. The endpoint definition and binding definition in the configuration file settings are modified to enable secure communication, as shown in the following sample configuration.

```xml
<system.serviceModel>
  <services>
    <service type="Microsoft.ServiceModel.Samples.CalculatorService"
             behaviorConfiguration="CalculatorServiceBehavior">
      <endpoint address=""
                binding="basicHttpBinding"
                bindingConfiguration="Binding1"
                contract="Microsoft.ServiceModel.Samples.ICalculator" />
    </service>
   </services>
  <bindings>
    <basicHttpBinding>
      <!-- Configure basicHttpBinding with Transport security -->
      <!-- mode and clientCredentialType set to None. -->
      <binding name="Binding1">
        <security mode="Transport">
          <transport clientCredentialType="None"/>
        </security>
      </binding>
    </basicHttpBinding>
  </bindings>
</system.serviceModel>
```

Because the certificate used in this sample is a test certificate created with Makecert.exe, a security alert appears when you try to access an HTTPS: address in your browser, such as `https://localhost/servicemodelsamples/service.svc`. To allow the Windows Communication Foundation (WCF) client to work with a test certificate, some additional code is added to the client to suppress the security alert. This code, and the accompanying class, is not necessary when using real certificates.

```csharp
// This code is required only for test certificates such as those
// created by Makecert.exe.
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

1. Install ASP.NET 4.0 using the following command:

    ```console
    %windir%\Microsoft.NET\Framework\v4.0.XXXXX\aspnet_regiis.exe /i /enable
    ```

2. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

3. Ensure that you have performed the [Internet Information Services (IIS) Server Certificate Installation Instructions](iis-server-certificate-installation-instructions.md).

4. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

5. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).
