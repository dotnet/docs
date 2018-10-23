---
title: "How to: Create a Windows Communication Foundation Client"
ms.date: 09/14/2018
helpviewer_keywords:
  - "clients [WCF], running"
  - "WCF clients [WCF], running"
ms.assetid: a67884cc-1c4b-416b-8c96-5c954099f19f
---
# How to: Create a Windows Communication Foundation Client

This is the fourth of six tasks required to create a Windows Communication Foundation (WCF) application. For an overview of all six of the tasks, see the [Getting Started Tutorial](../../../docs/framework/wcf/getting-started-tutorial.md) topic.

This topic describes how to retrieve metadata from a WCF service and use it to create a WCF proxy that can access the service. This task is completed by using the **Add Service Reference** functionality provided by Visual Studio. This tool obtains the metadata from the service’s MEX endpoint and generates a managed source code file for a client proxy in the language you have chosen (C# by default). In addition to creating the client proxy, the tool also creates or updates the client configuration file which enables the client application to connect to the service at one of its endpoints.

> [!NOTE]
> You can also use the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) tool to generate the proxy class and configuration instead of using **Add Service Reference** in Visual Studio.

> [!NOTE]
> When calling a WCF service from a class library project in Visual Studio, you can use the **Add Service Reference** feature to automatically generate a proxy and associated configuration file. The configuration file will not be used by the class library project. You need to add the settings in the generated configuration file to the app.config file for the executable that calls the class library.

The client application uses the generated proxy class to communicate with the service. This procedure is described in [How to: Use a Client](../../../docs/framework/wcf/how-to-use-a-wcf-client.md).

## To create a Windows Communication Foundation client

1. Create a new console application project in Visual Studio. Right-click on the Getting Started solution in **Solution Explorer** and select **Add** > **New Project**. In the **Add New Project** dialog, on the left-hand side, select the **Windows Desktop** category under **Visual C#** or **Visual Basic**. Select the **Console App (.NET Framework)** template, and then name the project **GettingStartedClient**.

2. Add a reference to System.ServiceModel to the GettingStartedClient project. Right-click on the **References** folder under the GettingStartedClient project in **Solution Explorer**, and then select **Add Reference**. In the **Add Reference** dialog, select **Framework** on the left-hand side of the dialog under **Assemblies**. Find and select **System.ServiceModel**, and then choose **OK**. Save the solution by selecting **File** > **Save All**.

3. Add a service reference to the Calculator Service.

   1. First, start up the GettingStartedHost console application.

   2. Once the host is running, right-click the **References** folder under the GettingStartedClient project in **Solution Explorer** and select **Add** > **Service Reference**.

   3. Enter the following URL in the address box of the **Add Service Reference** dialog: [http://localhost:8000/GettingStarted/CalculatorService](http://localhost:8000/GettingStarted/CalculatorService)

   4. Choose **Go**.

   The CalculatorService is displayed in the **Services** list box. Double-click CalculatorService to expand it and show the service contracts implemented by the service. Leave the default namespace as-is and choose **OK**.

    When you add a reference to a service using Visual Studio, a new item appears in **Solution Explorer** under the **Service References** folder under the GettingStartedClient project. If you use the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) tool, a source code file and app.config file are generated.

    You can also use the command-line tool [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) with the appropriate switches to create the client code. The following example generates a code file and a configuration file for the service. The first example shows how to generate the proxy in VB, and the second shows how to generate the proxy in C#:

    ```shell
    svcutil.exe /language:vb /out:generatedProxy.vb /config:app.config http://localhost:8000/GettingStarted/CalculatorService
    ```

    ```shell
    svcutil.exe /language:cs /out:generatedProxy.cs /config:app.config http://localhost:8000/GettingStarted/CalculatorService
    ```

## Next steps

You've created the proxy that the client application will use to call the calculator service. Proceed to the next topic in the series.

> [!div class="nextstepaction"]
> [How to: Configure a Client](../../../docs/framework/wcf/how-to-configure-a-basic-wcf-client.md)

## See also

- [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md)
- [Getting Started](../../../docs/framework/wcf/samples/getting-started-sample.md)
- [Self-Host](../../../docs/framework/wcf/samples/self-host.md)
- [How to: Publish Metadata for a Service Using a Configuration File](../../../docs/framework/wcf/feature-details/how-to-publish-metadata-for-a-service-using-a-configuration-file.md)
- [How to: Use Svcutil.exe to Download Metadata Documents](../../../docs/framework/wcf/feature-details/how-to-use-svcutil-exe-to-download-metadata-documents.md)
