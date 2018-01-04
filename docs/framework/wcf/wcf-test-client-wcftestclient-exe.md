---
title: "WCF Test Client (WcfTestClient.exe)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d4302855-677f-4640-aa90-c5d785d72fb7
caps.latest.revision: 45
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WCF Test Client (WcfTestClient.exe)
[!INCLUDE[indigo1](../../../includes/indigo1-md.md)] Test Client (WcfTestClient.exe) is a GUI tool that enables users to input test parameters, submit that input to the service, and view the response that the service sends back. It provides a seamless service testing experience when combined with [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Host.  
  
 You can typically find the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client (WcfTestClient.exe) in the following location: C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE - Community may be one of "Enterprise", "Professional" or "Community" depending on which level of Visual Studio is installed.
  
## Scenarios for Using Test Client  
 The following sections discuss the most common scenarios in which you can use [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client to streamline your development process.  
  
### Inside Visual Studio  
  
#### WCF Service Host Starts WCF Test Client with a Single Service  
 After you create a new [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service project and press F5 to start the debugger, the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Host begins to host the service in your project. Then, [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client opens and displays a list of service endpoints defined in the configuration file. You can test the parameters and invoke the service, and repeat this process to continuously test and validate your service.  
  
#### WCF Service Host Starts WCF Test Client with Multiple Services  
 You can also use [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client to help debug a service project that contains multiple services. When [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client opens, it automatically iterates the list of services in your project and opens them for testing.  
  
### Outside Visual Studio  
 You can also invoke the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client (WcfTestClient.exe) outside Visual Studio to test an arbitrary service on the Internet. To locate the tool, go to the following location:  
  
 C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\  
  
 To use the tool, double-click the file name to open it from this location, or launch it from a command line.  
  
 [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client takes an arbitrary number of URIs as command line arguments.  These are the URIs of services that can be tested.  
  
 `wcfTestClient.exe URI1 URI2 …`  
  
 After the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client window is opened, click **File**->**Add Service**, and enter the endpoint address of the service you want to open.  
  
## WCF Test Client User Interface  
 You can use [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client with a single service or multiple services.  
  
### Service Operations  
 The left pane of the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client main window lists all the available services, along with their respective endpoints and operations.  
  
 When you double-click an operation, you can view its content in the right pane inside a new tab with the operation's name.  
  
 The left pane also lists client configuration files. Double-click any of the items to display the content of the file in a new tabbed window in the right pane.  
  
### Entering Test Parameters  
 To view the test parameters, double-click an operation to open it in the right pane. The parameters are showed in **Formatted** view by default, and you can enter arbitrary values for the parameters to test the service.  
  
 To view the message's XML, click **XML**. To send them to the service, click **Invoke**.  
  
 For a DataSet parameter, click the **…** button next to **Edit…** to edit it in a new window showing the DataGrid. Notice the appearance of the **Copy DataSet** and **Paste DataSet** buttons. If the schema of the DataSet object is unknown upon the first edit, the DataGrid is empty. You have to paste a DataSet object with the same schema into the current object in the DataGrid. (Notice that you need to copy the schema from somewhere else before the paste operation.) You can also copy a Dataset object for future usage by clicking the **Copy DataSet** button.  
  
 The service's response appears below the test parameters.  
  
> [!NOTE]
>  If the expected return value is a string, the result will be displayed as a quoted string even though the input provided was not in quotes.  
  
 If you specified a particular operation as one-way when you created the contract for the service, no service response is displayed. As soon as the message is queued for delivery, a dialog box pops up to notify you that the message was successfully sent.  
  
### Session Support  
 The **Start a new proxy** check box in a service operation's tab enables you to toggle session support. This box is cleared by default.  
  
 When you enter test parameters for a specific operation (or another operation in the same service endpoint) and click **Invoke** multiple times with the check box cleared, these operations share one proxy and the service status is persisted across multiple operations.  
  
 If the **Start a new proxy** check box is checked, a new proxy is started for each **Invoke**, the previous session scenario is ended, and the service status is reset.  
  
### Editing Client Configuration  
 The left pane of the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client main window lists client configuration files. Double-click any of the items to display the contents of the file in the right pane.  
  
#### Edit with Service Configuration Editor  
 Right-click **Config File** in the left pane and select the context menu **Edit with SvcConfigEditor**. Service Configuration Editor is launched with the client configuration content. You can edit the configuration and save it within the tool.  
  
 After saving the file in Service Configuration Editor, [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client displays a warning message to inform you that the file has been modified outside and asks whether you would like to reload it.  
  
 If you select **Yes**, the configuration content in the "Client.dll.config" tab reflects the changes you made in the editor.  
  
 If you select **No**, the configuration content in the "Client.dll.config" tab remains unchanged and the modified content is automatically saved to the source file.  
  
#### Restore to Default Configuration  
 If you want to cancel all the changes and restore to the default client configuration, right-click **Config File** in the left pane and select the context menu **Restore to Default Config**. The default configuration value is loaded and content in "Client.dll.config" tab is restored.  
  
#### Validate Changes  
 When saved changes are being loaded in [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client, the configuration is checked for validity against [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] schema. If errors are found, a dialog box is displayed to show error details.  
  
 During proxy generation, binary compiling, or service invoking, menu items that support editing (that is, "Edit …", "Restore …", and so on) are disabled. Service invocation is also disabled when loading updated configuration to [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client.  
  
#### Persist Client Configuration  
 The **Tools**->**Options**->**Client Configuration** tab contains an **Always Regenerate Config When Launching Services** option, which is enabled by default. This option specifies that every time [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client loads a service, it regenerates a configuration file based on the latest service contract and service App.config files.  
  
 If you have edited the client configuration for your [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service and want to always use this updated file to debug your service, you can uncheck the **Regenerate** option. By doing so, even when you update the service and reopen [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client, the Client.dll.config file is the one you updated previously instead of a regenerated one based on the updated service.  
  
 However, you might need to edit the configuration file to make it consistent with the regenerated proxy. If the regenerated proxy and configuration file are mismatched due to an updated service, errors will occur when the service is invoked.  
  
> [!CAUTION]
>  If you have modified the client configuration file and select to reuse it in the future, you can find the file in the following location:  
>   
>  \Documents and Settings\\[User Account]\My Documents\Test Client Projects.  
>   
>  Any updated credential information stored to the client configuration file is protected by the Access Control List (ACL) of this folder.  
  
### Adding, Removing and Refreshing Services  
  
#### Add Service  
 Click **File**->**Add Service** to add a service to [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client. You are then required to type the URI (endpoint address) of the service to be added. The service’s address can be a mex address or WSDL address.  
  
 You can also find a list of 10 recently added services' endpoints in the **Recent Services** submenu. If you select one of them, the specified service is added to [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client.  
  
 You can also right-click the root of service tree **My Service Projects**, and select **Add Service** to achieve the same result.  
  
 During proxy generation, binary compiling, or service invocation, menu items that support adding a service are disabled. Service invocation is also disabled.  
  
#### Remove Service  
 Right-click the service root of the service to be removed, and select **Remove Service** to remove a service from [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client.  
  
 During proxy generation, binary compiling, or service invocation, menu items that support removing a service are disabled. Service invocation is also disabled.  
  
#### Refresh Service  
 If a change is made to the service while [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client is running and you want to ensure that the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client implementation for that service is up-to-date, right-click the service root of the service, and select **Refresh Service**. Note that after refreshing, the service status is reset.  
  
 During proxy generation, binary compiling, or service invocation, menu items that support refreshing a service are disabled. Service invocation is also disabled.  
  
## Location of Files Generated by the Test Client  
 By default, [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client stores generated client code and configuration files in the "%appdata%\Local\temp\Test Client Projects" folder. This folder is deleted after [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client exits. If a configuration file is modified in [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client and the **Always Regenerate Config When Launching Services** option is disabled, the modified file is copied to the "Cached Config" folder under "My Documents\Test Client Projects Documents\Test Client Projects" with a mapping (metadata-address-to-file-name) XML file as an index.  
  
 You can also start [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client in a command line, use the `/ProjectPath` switch to specify a new desired path for storing generated files, or use the `/RestoreProjectPath` switch to restore the default location. The syntax is as follows:  
  
 `wcfTestClient.exe /ProjectPath [desired location]`  
  
 Running this command does not open [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client. Only the folder location is changed. You can run this command whether [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client is running or not. The new location is applied when [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client is restarted. The location information can be saved in registry, or in the WcfTestClient.exe.option file in the "%appdata%\Local\temp\Test Client Projects" folder.  
  
## Features supported by WCF Test Client  
 The following is a list of features supported by [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client:  
  
-   Service Invocation: Request/Response and One-way message.  
  
-   Bindings: all bindings supported by Svcutil.exe.  
  
-   Controlling Session.  
  
-   Message Contract.  
  
-   XML serialization.  
  
 The following is a list of features not supported by [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client:  
  
-   Types: <xref:System.IO.Stream>, <xref:System.ServiceModel.Channels.Message>, <xref:System.Xml.XmlElement>, <xref:System.Xml.XmlAttribute>, <xref:System.Xml.XmlNode>, types that implement the <xref:System.Xml.Serialization.IXmlSerializable> interface, including the related <xref:System.Xml.Serialization.XmlSchemaProviderAttribute> attribute, and the <xref:System.Xml.Linq.XDocument> and <xref:System.Xml.Linq.XElement> types and the ADO.NET <xref:System.Data.DataTable> type.  
  
-   Duplex contract.  
  
-   Transaction.  
  
-   Security: [!INCLUDE[infocard](../../../includes/infocard-md.md)] , Certificate, and Username/Password.  
  
-   Bindings: WSFederationbinding, any Context bindings and Https binding, WebHttpbinding (Json response message support).  
  
## Closing WCF Test Client  
 You can close [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client in the following ways:  
  
-   On the **File** menu, click **Exit**. Alternatively, in the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client main window, click **Close**. Both of these actions also shut down [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Auto Host and stop the [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] debugging process if [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client was launched by [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)].  
  
-   Right-click the **WCF Service Host** icon in the notification area, and then click **Exit.** This shuts down both [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Auto Host and [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client and stops the [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] debugging process.  
  
## See Also  
 [WCF Service Host (WcfSvcHost.exe)](../../../docs/framework/wcf/wcf-service-host-wcfsvchost-exe.md)
