---
title: "WCF Service Host (WcfSvcHost.exe)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8643a63d-a357-4c39-bd6c-cdfdf71e370e
caps.latest.revision: 27
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WCF Service Host (WcfSvcHost.exe)
[!INCLUDE[indigo1](../../../includes/indigo1-md.md)] Service Host (WcfSvcHost.exe) allows you to launch the [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] debugger (F5) to automatically host and test a service you have implemented. You can then test the service using [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client (WcfTestClient.exe), or your own client, to find and fix any potential errors.  
  
## WCF Service Host  
 [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Host enumerates the services in a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service project, loads the project’s configuration, and instantiates a host for each service that it finds. The tool is integrated into [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] through the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service template and is invoked when you start to debug your project.  
  
 By using [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Host, you can host a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service (in a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service library project) without writing extra code or committing to a specific host during development.  
  
> [!NOTE]
>  [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Host does not support Partial Trust. If you want to use a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service in Partial Trust, do not use the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Library Project template in [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] to build your service. Instead, create a New WebSite in [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] by choosing the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service WebSite template, which can host the service in a WebServer on which [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Partial Trust is supported.  
  
## Project Types hosted by WCF Service Host  
 [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Host can host the following [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service library project types: [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Library, Sequential Workflow Service Library, State Machine Workflow Service Library and Syndication Service Library. [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Host can also host those services that can be added to a service library project using the **Add Item** functionality. This includes [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service, WF State Machine Service, WF Sequential Service, XAML WF State Machine Service and XAML WF Sequential Service.  
  
 You should note, however, that the tool will not help you to configure a host. For this task, you must manually edit the App.config file. The tool also does not validate user-defined configuration files.  
  
> [!CAUTION]
>  You should not use [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Host to host services in a production environment, as it was not engineered for this purpose.  [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Host does not support the reliability, security, and manageability requirements of such an environment. Instead, use IIS since it provides superior reliability and monitoring features, and is the preferred solution for hosting services. Once development of your services is complete, you should migrate the services from [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Host to IIS.  
  
## Scenarios for Using WCF Service Host inside Visual Studio  
 The following table lists all the parameters in the **Command line arguments** dialog box, which can be found by right-clicking your project in **Solutions Explorer** in [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)], selecting **Properties**, then selecting the **Debug** tab and clicking **Start Project**. These parameters are useful in configuring [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Host.  
  
|Parameter|Meaning|  
|---------------|-------------|  
|`/client`|An optional parameter that specifies the path to an executable to run after the services are hosted. This launches [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client following hosting.|  
|`/clientArg`|Specify a string as an argument that is passed to the custom client application.|  
|`/?`|Displays the help text.|  
  
#### Using WCF Test Client  
 After you create a new [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service project and press F5 to start the debugger, [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Host starts hosting all the services it finds in your project. [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client automatically opens and displays a list of service endpoints defined in the configuration file. From the main window, you can test the parameters and invoke your service.  
  
 To make sure that [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client is used, right-click your project in **Solutions Explorer** in [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)], select **Properties**, then select the **Debug** tab. Click **Start Project** and ensure that the following appears in the **Command line arguments** dialog box.  
  
 `/client:WcfTestClient.exe`  
  
#### Using a Custom Client  
 To use a custom client, right-click your project in **Solutions Explorer** in [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)], select **Properties**, then select the **Debug** tab. Click **Start Project** and edit the `/client` parameter in the **Command line arguments** dialog box to point to your custom client, as indicated in the following example.  
  
 `/client:"path/CustomClient.exe"`  
  
 When you press F5 to start the service again, [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Host automatically starts your custom client when you launch the debugger.  
  
 You can also use the `/clientArg:` parameter to specify a string as an argument that is passed to the custom client application, as indicated in the following example.  
  
 `/client:"path/CustomClient.exe" /clientArg:"arguments that are passed to Client"`  
  
 For example, if you are using the Syndication Service Library template, you can use the following command line arguments,  
  
 `/client:iexplore.exe /clientArgs:http://localhost:8731/Design_Time_Addresses/Feed1/`  
  
#### Specifying No Client  
 To specify that no client will be used after [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service hosting, right-click your project in **Solutions Explorer** in [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)], select **Properties**, then select the **Debug** tab. Click **Start Project** and leave the **Command line arguments** dialog box blank.  
  
#### Using a Custom Host  
 To use a custom host, right-click your project in **Solutions Explorer** in [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)], select **Properties**, then select the **Debug** tab. Click **Start External Program** and enter the full path to the custom host. You can also use the **Command line arguments** dialog box to specify arguments to be passed to the host.  
  
## WCF Service Host User Interface  
 When you initially invoke [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Host (by pressing F5 inside [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)]), the **WCF Service Host** window automatically opens. When [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Host is running, the program's icon appears in the notification area. Double-click the icon to open the **WCF Service Host** window  
  
 When errors occur during service hosting, [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Host dialog box will open to display relevant information.  
  
 The **WCF Service Host** main window contains two menus:  
  
-   **File**: Contains the **Close** and **Exit** commands. When you click **Close**, the **WCF Service Host** dialog box closes, but the services continue to be hosted. When you click **Exit**, [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Host is also shut down. This also stops all hosted services.  
  
-   **Help**: Contains the **About** command that contains version information. It also contains the **Help** command that can open a help file.  
  
 The main **WCF Service Host** window contains two areas:  
  
-   The first area is **Service**. It contains a list that displays basic information of all services. The information includes:  
  
    -   **Service**: Lists all the services.  
  
    -   **Status**: Lists the status of the service. Valid values are "Started", "Stopped," and "Error".  
  
    -   **Metadata Address**: Displays the metadata address of the services.  
  
-   The second area is **Additional Information**. It displays a detailed explanation of the service status when the specific service line is selected in the **Service** area. If the status is Error, you can view the full error message on the screen.  
  
## Stopping WCF Service Host  
 You can shut down [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Host in the following four ways:  
  
-   Stop the debugging session in [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)].  
  
-   Select **Exit** from the **File** menu in the **WCF Service Host** window.  
  
-   Select **Exit** from context menu of [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Host tray icon in the system notification area.  
  
-   Exit [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client if it is being used.  
  
## Using Service Host without Administrator privilege  
 To enable users without administrator privilege to develop [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] services, an ACL (Access Control List) is created for the namespace "http://+:8731/Design_Time_Addresses" during the installation of [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)]. The ACL is set to (UI), which includes all interactive users logged on to the machine. Administrators can add or remove users from this ACL, or open additional ports.This ACL enables users to use the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Auto Host (wcfSvcHost.exe) without granting them administrator privileges.  
  
 You can modify access using the netsh.exe tool in [!INCLUDE[wv](../../../includes/wv-md.md)] under the elevated administrator account. The following is an example of using netsh.exe.  
  
```  
netsh http add urlacl url=http://+:8001/MyService user=<domain>\<user>  
```  
  
 For more information on netsh.exe, see "[How to Use the Netsh.exe Tool and Command-Line Switches](http://go.microsoft.com/fwlink/?LinkId=97877)".  
  
## See Also  
 [WCF Test Client (WcfTestClient.exe)](../../../docs/framework/wcf/wcf-test-client-wcftestclient-exe.md)
