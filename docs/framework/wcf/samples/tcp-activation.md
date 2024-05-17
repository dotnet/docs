---
description: "Learn more about: TCP Activation"
title: "TCP Activation"
ms.date: "03/30/2017"
ms.assetid: bf8c215c-0228-4f4f-85c2-e33794ec09a7
---

# TCP Activation

The [TCPActivation sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates hosting a service that uses Windows Process Activation Services (WAS) to activate a service that communicates over the net.tcp protocol. This sample is based on the [Getting Started](getting-started-sample.md).

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

The sample consists of a client console program (.exe) and a service library (.dll) hosted in a worker process activated by WAS. Client activity is visible in the console window.

The service implements a contract that defines a request-reply communication pattern. The contract is defined by the `ICalculator` interface, which exposes math operations (Add, Subtract, Multiply, and Divide), as shown in the following sample code:

```csharp
[ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]
public interface ICalculator
{
    [OperationContract]
    double Add(double n1, double n2);
    [OperationContract]
    double Subtract(double n1, double n2);
    [OperationContract]
    double Multiply(double n1, double n2);
    [OperationContract]
    double Divide(double n1, double n2);
}
```

The service implementation calculates and returns the appropriate result:

```csharp
// Service class that implements the service contract.
public class CalculatorService : ICalculator
{
    public double Add(double n1, double n2)
    {
        return n1 + n2;
    }
    public double Subtract(double n1, double n2)
    {
        return n1 - n2;
    }
    public double Multiply(double n1, double n2)
    {
        return n1 * n2;
    }
    public double Divide(double n1, double n2)
    {
        return n1 / n2;
    }
}
```

The sample uses a variant of the net.tcp binding with TCP port sharing enabled and security turned off. If you want to use a secured TCP binding, change the server's security mode to the desired setting and re-run Svcutil.exe on the client to generate an update client configuration file.

The following sample shows the configuration for the service:

```xml
<system.serviceModel>

    <services>
      <service name="Microsoft.ServiceModel.Samples.CalculatorService"
               behaviorConfiguration="CalculatorServiceBehavior">
        <!-- This endpoint is exposed at the base address provided by host: net.tcp://localhost/servicemodelsamples/service.svc  -->
        <endpoint binding="netTcpBinding" bindingConfiguration="PortSharingBinding"
          contract="Microsoft.ServiceModel.Samples.ICalculator" />
        <!-- the mex endpoint is exposed at net.tcp://localhost/servicemodelsamples/service.svc/mex -->
        <endpoint address="mex"
                  binding="mexTcpBinding"
                  contract="IMetadataExchange" />
      </service>
    </services>
    <bindings>
      <netTcpBinding>
        <binding name="PortSharingBinding" portSharingEnabled="true">
          <security mode="None" />
        </binding>
      </netTcpBinding>
    </bindings>

    <!--For debugging purposes set the includeExceptionDetailInFaults attribute to true-->
    <behaviors>
      <serviceBehaviors>
        <behavior name="CalculatorServiceBehavior">
          <serviceMetadata />
          <serviceDebug includeExceptionDetailInFaults="False" />
        </behavior>
      </serviceBehaviors>
    </behaviors>

  </system.serviceModel>
```

The client's endpoint is configured as shown in the following sample code:

```xml
<system.serviceModel>
    <bindings>
        <netTcpBinding>
          <binding name="NetTcpBinding_ICalculator">
            <security mode="None"/>
          </binding>
        </netTcpBinding>
    </bindings>
    <client>
        <endpoint address="net.tcp://localhost/servicemodelsamples/service.svc"
            binding="netTcpBinding" bindingConfiguration="NetTcpBinding_ICalculator"
            contract="Microsoft.ServiceModel.Samples.ICalculator" name="NetTcpBinding_ICalculator" />
    </client>
</system.serviceModel>
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

1. Ensure that IIS 7.0 is installed. IIS 7.0 is required for WAS activation.

2. Be sure you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

    In addition, you must install the WCF non-HTTP activation components:

    1. From the **Start** menu, choose **Control Panel**.

    2. Select **Programs and Features**.

    3. Click **Turn Windows Components on or Off**.

    4. Expand the **Microsoft .NET Framework 3.0** node and check the **Windows Communication Foundation Non-HTTP Activation** feature.

3. Configure WAS to support TCP activation.

    As a convenience, the following two steps are implemented in a batch file called AddNetTcpSiteBinding.cmd located in the sample directory.

    1. To support net.tcp activation, the default Web site must first be bound to a net.tcp port. This can be done using Appcmd.exe, which is installed with the Internet Information Services 7.0 (IIS) management toolset. From an administrator-level command prompt, run the following command:

        ```console
        %windir%\system32\inetsrv\appcmd.exe set site "Default Web Site" -+bindings.[protocol='net.tcp',bindingInformation='808:*']
        ```

        > [!TIP]
        > This command is a single line of text. This command adds a net.tcp site binding to the default Web site listening on TCP port 808 with any hostname.

    2. Although all applications within a site share a common net.tcp binding, each application can enable net.tcp support individually. To enable net.tcp for the /servicemodelsamples application, run the following command from an administrator-level command prompt:

        ```console
        %windir%\system32\inetsrv\appcmd.exe set app
        "Default Web Site/servicemodelsamples" /enabledProtocols:http,net.tcp
        ```

        > [!NOTE]
        > This command is a single line of text. This command enables the /servicemodelsamples application to be accessed using both `http://localhost/servicemodelsamples` and `net.tcp://localhost/servicemodelsamples`.

4. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

5. To run the sample in a single- or cross-computer configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).

    Remove the net.tcp site binding you added for this sample.

    As a convenience, the following two steps are implemented in a batch file called RemoveNetTcpSiteBinding.cmd located in the sample directory.

    1. Remove net.tcp from the list of enabled protocols by running the following command from an administrator-level command prompt:

        ```console
        %windir%\system32\inetsrv\appcmd.exe set app
        "Default Web Site/servicemodelsamples" /enabledProtocols:http
        ```

        > [!NOTE]
        > This command must be entered as a single line of text.

    2. Remove the net.tcp site binding by running the following command from an administrator-level command prompt:

        ```console
        %windir%\system32\inetsrv\appcmd.exe set site "Default Web Site"
        --bindings.[protocol='net.tcp',bindingInformation='808:*']
        ```

        > [!NOTE]
        > This command must be typed in as a single line of text.

## See also

- [AppFabric Hosting and Persistence Samples](/previous-versions/appfabric/ff383418(v=azure.10))
