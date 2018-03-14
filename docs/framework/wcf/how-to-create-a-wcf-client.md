---
title: "How to: Create a Windows Communication Foundation Client"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "clients [WCF], running"
  - "WCF clients [WCF], running"
ms.assetid: a67884cc-1c4b-416b-8c96-5c954099f19f
caps.latest.revision: 64
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Create a Windows Communication Foundation Client
This is the fourth of six tasks required to create a [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] application. For an overview of all six of the tasks, see the [Getting Started Tutorial](../../../docs/framework/wcf/getting-started-tutorial.md) topic.  
  
 This topic describes how to retrieve metadata from a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service and use it to create a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] proxy that can access the service. This task is completed by using the Add Service Reference functionality provided by Visual Studio . This tool obtains the metadata from the service’s MEX endpoint and generates a managed source code file for a client proxy in the language you have chosen (C# by default). In addition to creating the client proxy, the tool also creates or updates the client configuration file which enables the client application to connect to the service at one of its endpoints.  
  
> [!NOTE]
>  You can also use the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) tool to generate the proxy class and configuration instead of using Add Service Reference inside of Visual Studio.  
  
> [!WARNING]
>  When calling a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service from a class library project in [!INCLUDE[vs_current_long](../../../includes/vs-current-long-md.md)] you can use the Add Service Reference feature to automatically generate a proxy and associated configuration file.  The configuration file will not be used by the class library project. You will need to add the settings in the generated configuration file to the app.config file for the executable that will call the class library.  
  
 The client application uses the generated proxy class to communicate with the service. This procedure is described in [How to: Use a Client](../../../docs/framework/wcf/how-to-use-a-wcf-client.md).  
  
### To create a Windows Communication Foundation client  
  
1.  Create a new console application project by right-clicking on the Getting Started solution, selecting, **Add**, **New Project**. In the **Add New Project** dialog on the left hand side of the dialog select **Windows** under **C#** or **VB**. In the center section of the dialog select **Console Application**. Name the project `GettingStartedClient`.  
  
2.  Set the target framework of the GettingStartedClient project to .NET Framework 4.5 by right clicking on **GettingStartedClient** in the Solution Explorer and selecting **Properties**. In the dropdown box labeled **Target Framework** select **.NET Framework 4.5**. Setting the target framework for a VB project is a little different, in the GettingStartedClient project properties dialog, click the **Compile** tab on the left-hand side of the screen, and then click the **Advanced Compile Options** button at the lower left-hand corner of the dialog. Then select **.NET Framework 4.5** in the dropdown box labeled **Target Framework**.  
  
     Setting the target framework will cause Visual Studio 2011 to reload the solution, press **OK** when prompted.  
  
3.  Add a reference to System.ServiceModel to the GettingStartedClient project by right-clicking the **Reference** folder under the GettingStartedClient project in Solution Explorer and select **Add** Reference. In the **Add Reference** dialog select **Framework** on the left-hand side of the dialog. In the Search Assemblies textbox, type in `System.ServiceModel`. In the center section of the dialog select **System.ServiceModel**, click the **Add** button, and click the **Close** button. Save the solution by clicking the **Save All** button below the main menu.  
  
4.  Next you wlll add a service reference to the Calculator Service. Before you can do that, you must start up the GettingStartedHost console application. Once the host is running you can right click the References folder under the GettingStartedClient project in the Solution Explorer and select Add Service Reference and type in the following URL in the address box of the Add Service Reference dialog:  HYPERLINK "http://localhost:8000/ServiceModelSamples/Service" http://localhost:8000/ServiceModelSamples/Service and   click the **Go** button. The CalculatorService should then be displayed in the Services list box, Double click CalculatorService and it will expand and show the service contracts implemented by the service. Leave the default namespace as is and click the **OK** button.  
  
     When you add a reference to a service using Visual Studio a new item will appear in the Solution Explorer under the Service References folder under the GettingStartedClient project.  If you use the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) tool a source code file and app.config file will be generated.  
  
     You can also use the command-line tool [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) with the appropriate switches to create the client code. The following example generates a code file and a configuration file for the service. The first example shows how to generate the proxy in VB and the second shows how to generated the proxy in C#:  
  
    ```  
    svcutil.exe /language:vb /out:generatedProxy.vb /config:app.config http://localhost:8000/ServiceModelSamples/service  
    ```  
  
    ```csharp  
    svcutil.exe /language:cs /out:generatedProxy.cs /config:app.config http://localhost:8000/ServiceModelSamples/service  
    ```  
  
 You have now created the proxy that the client application will use to call the calculator service. Proceed to the next topic in the series: [How to: Configure a Client](../../../docs/framework/wcf/how-to-configure-a-basic-wcf-client.md)  
  
## See Also  
 [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md)  
 [Getting Started](../../../docs/framework/wcf/samples/getting-started-sample.md)  
 [Self-Host](../../../docs/framework/wcf/samples/self-host.md)  
 [How to: Publish Metadata for a Service Using a Configuration File](../../../docs/framework/wcf/feature-details/how-to-publish-metadata-for-a-service-using-a-configuration-file.md)  
 [How to: Use Svcutil.exe to Download Metadata Documents](../../../docs/framework/wcf/feature-details/how-to-use-svcutil-exe-to-download-metadata-documents.md)
