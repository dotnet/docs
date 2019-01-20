---
title: "Tutorial: Create a Windows Communication Foundation client"
ms.dat8: 01/18/2019
helpviewer_keywords:
  - "clients [WCF], running"
  - "WCF clients [WCF], running"
ms.assetid: a67884cc-1c4b-416b-8c96-5c954099f19f
---
# Tutorial: Create a Windows Communication Foundation client

This tutorial describes the fourth of six tasks required to create a basic Windows Communication Foundation (WCF) application. For an overview of the tutorials, see [Tutorial: Get started with Windows Communication Foundation applications](getting-started-tutorial.md).

The next task for creating a WCF application is to retrieve metadata from a WCF service. You use this metadata to create a WCF proxy to access the service. To complete this task, use the **Add Service Reference** feature of Visual Studio to add a service reference, which gets the metadata from the service’s MEX endpoint. Visual Studio then generates a managed source code file for a client proxy in the language you've chosen. Visual Studio also creates and updates the client configuration file. The client configuration file enables the client application to connect to the service at one of its endpoints. 

> [!NOTE]
> If you call a WCF service from a class library project in Visual Studio, you can use the **Add Service Reference** feature to automatically generate a proxy and associated configuration file. However, because class library projects don't use this configuration file, you need to add the settings in the generated configuration file to the App.config file for the executable that calls the class library.

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

The following examples show how to use the [ServiceModel Metadata Utility tool (Svcutil.exe)](servicemodel-metadata-utility-tool-svcutil-exe.md) to generate the proxy class and the App.config file. The examples generate the proxy in C# and Visual Basic, respectively:

```shell
svcutil.exe /language:cs /out:generatedProxy.cs /config:app.config http://localhost:8000/GettingStarted/CalculatorService
```

```shell
svcutil.exe /language:vb /out:generatedProxy.vb /config:app.config http://localhost:8000/GettingStarted/CalculatorService
```

## Next steps

You've created the proxy that the client application uses to call the calculator service. In the next task, you configure a client.

> [!div class="nextstepaction"]
> [Tutorial: Configure a client](how-to-configure-a-basic-wcf-client.md)

## See also

- [ServiceModel Metadata Utility Tool (Svcutil.exe)](servicemodel-metadata-utility-tool-svcutil-exe.md)
- [Getting started sample](samples/getting-started-sample.md)
- [Self-Host](samples/self-host.md)
- [How to: Publish metadata for a service using a configuration file](feature-details/how-to-publish-metadata-for-a-service-using-a-configuration-file.md)
- [How to: Use Svcutil.exe to download metadata documents](feature-details/how-to-use-svcutil-exe-to-download-metadata-documents.md)
