---
title: "Tutorial: Create a Windows Communication Foundation client"
ms.date: 01/16/2019
helpviewer_keywords:
  - "clients [WCF], running"
  - "WCF clients [WCF], running"
ms.assetid: a67884cc-1c4b-416b-8c96-5c954099f19f
---
# Tutorial: Create a Windows Communication Foundation client

This tutorial describes the fourth of six tasks required to create a basic Windows Communication Foundation (WCF) application. For an overview of the tutorials, see [Tutorial: Get started with Windows Communication Foundation applications](getting-started-tutorial.md).

The next task for creating a WCF application is to retrieve metadata from a WCF service and use it to create a WCF proxy that can access the service. To complete this task, you use Visual Studio to add a service reference, which gets the metadata from the service’s MEX endpoint. It then generates a managed source code file for a client proxy in the language you have chosen (C# by default). Visual Studio also creates and updates the client configuration file. The client configuration file enables the client application to connect to the service at one of its endpoints.

> [!NOTE]
> You can also use the [ServiceModel Metadata Utility Tool (Svcutil.exe)](servicemodel-metadata-utility-tool-svcutil-exe.md) tool to generate the proxy class and configuration instead of using Visual Studio to add a service reference.

> [!NOTE]
> When you call a WCF service from a class library project in Visual Studio, you can use the **Add Service Reference** feature to automatically generate a proxy and an associated configuration file. The configuration file won't be used by the class library project. Add the settings in the generated configuration file to the App.config file for the executable that calls the class library.

The client application uses the generated proxy class to communicate with the service. This procedure is described in [Tutorial: Use a client](how-to-use-a-wcf-client.md).

## To create a Windows Communication Foundation client

1. Create a console application project in Visual Studio. 

    1. In the **Solution Explorer** window, right-click the **GettingStarted** solution (top node) and select **Add** > **New Project**. 
    
    2. In the **Add New Project** window, on the left side, select the **Windows Desktop** category under **Visual C#** or **Visual Basic**. 

    3. Select the **Console App (.NET Framework)** template, and enter *GettingStartedClient* for the **Name**. Select **OK**.

2. Add a reference to System.ServiceModel to the GettingStartedClient project.

    1.  In the **Solution Explorer** window, right-click the **References** folder under the **GettingStartedClient** project, and then select **Add Reference**. 

    2. In the **Add Reference** dialog, select **Framework** on the left side of the dialog under **Assemblies**. 
    
    3. Find and select **System.ServiceModel**, and then choose **OK**. Save the solution by selecting **File** > **Save All**.

3. Add a service reference to the Calculator service.

   1. Start the GettingStartedHost console application.

   2. Once the host is running, right-click the **References** folder under the **GettingStartedClient** project in **Solution Explorer** and select **Add** > **Service Reference**.

   3. In the **Add Service Reference** window, enter the following URL for the **Address**: [http://localhost:8000/GettingStarted/CalculatorService](http://localhost:8000/GettingStarted/CalculatorService).

   4. Choose **Go**.

   The CalculatorService is displayed in the **Services** list box. Double-click CalculatorService to expand it and display the service contracts implemented by the service. Leave the default namespace as-is and choose **OK**.

    When you add a service reference with Visual Studio, a new item appears in **Solution Explorer** under the **Service References** folder under the **GettingStartedClient** project. If you use the [ServiceModel Metadata Utility Tool (Svcutil.exe)](servicemodel-metadata-utility-tool-svcutil-exe.md) tool, it generates a source code and an App.config file.

    You can also use the command-line tool [ServiceModel Metadata Utility Tool (Svcutil.exe)](servicemodel-metadata-utility-tool-svcutil-exe.md) with the appropriate switches to create the client code. The following example generates a code file and a configuration file for the service. The following examples show how to generate the proxy in VB and C#, respectively:

    ```shell
    svcutil.exe /language:vb /out:generatedProxy.vb /config:app.config http://localhost:8000/GettingStarted/CalculatorService
    ```

    ```shell
    svcutil.exe /language:cs /out:generatedProxy.cs /config:app.config http://localhost:8000/GettingStarted/CalculatorService
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
