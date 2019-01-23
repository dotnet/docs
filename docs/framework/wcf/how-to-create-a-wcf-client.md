---
title: "Tutorial: Create a Windows Communication Foundation client"
ms.dat8: 01/21/2019
helpviewer_keywords:
  - "clients [WCF], running"
  - "WCF clients [WCF], running"
ms.assetid: a67884cc-1c4b-416b-8c96-5c954099f19f
---
# Tutorial: Create a Windows Communication Foundation client

This tutorial describes the fourth of five tasks required to create a basic Windows Communication Foundation (WCF) application. For an overview of the tutorials, see [Tutorial: Get started with Windows Communication Foundation applications](getting-started-tutorial.md).

The next task for creating a WCF application is to retrieve metadata from a WCF service. You use this metadata to create a WCF proxy to access the service. To complete this task, use Visual Studio to add a service reference, which gets the metadata from the service’s MEX endpoint. Visual Studio then generates a managed source code file for a client proxy in the language you've chosen. It also creates the client configuration file, which enables the client application to connect to the service at an endpoint. 

> [!NOTE]
> If you call a WCF service from a class library project in Visual Studio, you can use the **Add Service Reference** feature to automatically generate a proxy and associated configuration file. However, because class library projects don't use this configuration file, you need to add the settings in the generated configuration file to the *App.config* file for the executable that calls the class library.

> [!NOTE]
> As an alternative, you can also use the [ServiceModel Metadata Utility tool](#servicemodel-metadata-utility-tool) instead of Visual Studio to generate the proxy class and configuration file.


The client application uses the generated proxy class to communicate with the service. This procedure is described in [Tutorial: Use a client](how-to-use-a-wcf-client.md).

## To create a Windows Communication Foundation client

1. Create a console application project in Visual Studio. 

    1. In the **Solution Explorer** window, right-click the **GettingStarted** solution (top node) and select **Add** > **New Project**. 
    
    2. In the **Add New Project** window, on the left side, select the **Windows Desktop** category under **Visual C#** or **Visual Basic**. 

    3. Select the **Console App (.NET Framework)** template, and enter *GettingStartedClient* for the **Name**. Select **OK**.

2. Add a reference in the **GettingStartedClient** project to the <xref:System.ServiceModel> assembly. 

    1.  In the **Solution Explorer** window, right-click the **References** folder under the **GettingStartedClient** project, and then select **Add Reference**. 

    2. In the **Add Reference** window, under **Assemblies** on the left side of the window, select **Framework**.
    
    3. Find and select **System.ServiceModel**, and then choose **OK**. 

    4. Save the solution by selecting **File** > **Save All**.

3. Add a service reference to the calculator service.

   1. In the **Solution Explorer** window, right-click the **References** folder under the **GettingStartedClient** project, and then select **Add Service Reference**.

   2. In the **Add Service Reference** window, enter the following URL for the **Address**: [http://localhost:8000/GettingStarted/CalculatorService](http://localhost:8000/GettingStarted/CalculatorService).

   3. Choose **Go**. 

      The CalculatorService service starts and Visual Studio displays the **CalculatorService** service in the **Services** box.

   4. Double-click **CalculatorService** to expand it and display the service contracts implemented by the service. Leave the default **Namespace** and choose **OK**.

      Visual Studio adds a new item under the **Connected Services** folder in the **GettingStartedClient** project. 


### ServiceModel Metadata Utility tool

The following examples show how to use the [ServiceModel Metadata Utility tool (Svcutil.exe)](servicemodel-metadata-utility-tool-svcutil-exe.md) to generate the proxy class and the *App.config* file. The examples generate the proxy in C# and Visual Basic, respectively:

```shell
svcutil.exe /language:cs /out:generatedProxy.cs /config:app.config http://localhost:8000/GettingStarted/CalculatorService
```

```shell
svcutil.exe /language:vb /out:generatedProxy.vb /config:app.config http://localhost:8000/GettingStarted/CalculatorService
```

### Client configuration file

After you've created the client, Visual Studio creates an *App.config* configuration file, which should be similar to the file in this example:

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

Under the [\<system.serviceModel>](../configure-apps/file-schema/wcf/system-servicemodel.md) section, find the [\<endpoint>](../configure-apps/file-schema/wcf/endpoint-element.md) element. This config file configures the endpoint that the client uses to access the service located at this address: `http://localhost:8000/GettingStarted/CalculatorService`.

The endpoint element specifies that the `ServiceReference1.ICalculator` service contract is used for communication between the WCF client and service. The WCF channel is configured with the system-provided <xref:System.ServiceModel.WSHttpBinding>. Visual Studio generated this contract when you used its **Add Service Reference** function. It's essentially a copy of the contract that you defined in the GettingStartedLib project. The <xref:System.ServiceModel.WSHttpBinding> binding specifies HTTP as the transport, interoperable security, and other configuration details.

## Next steps

You've created the proxy that the client application uses to call the calculator service. In the next task, you use the generated client.

> [!div class="nextstepaction"]
> [Tutorial: Use a WCF client](how-to-use-a-wcf-client.md)

## See also

- [ServiceModel Metadata Utility tool (Svcutil.exe)](servicemodel-metadata-utility-tool-svcutil-exe.md)
- [Getting started sample](samples/getting-started-sample.md)
- [Self-Host](samples/self-host.md)
- [How to: Publish metadata for a service using a configuration file](feature-details/how-to-publish-metadata-for-a-service-using-a-configuration-file.md)
- [How to: Use Svcutil.exe to download metadata documents](feature-details/how-to-use-svcutil-exe-to-download-metadata-documents.md)
- [Using bindings to configure services and clients](using-bindings-to-configure-services-and-clients.md)
