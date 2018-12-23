---
title: "WCF Service Host (WcfSvcHost.exe)"
ms.date: "03/30/2017"
ms.assetid: 8643a63d-a357-4c39-bd6c-cdfdf71e370e
---
# WCF Service Host (WcfSvcHost.exe)
Windows Communication Foundation (WCF) Service Host (WcfSvcHost.exe) allows you to launch the Visual Studio debugger (F5) to automatically host and test a service you have implemented. You can then test the service using WCF Test Client (WcfTestClient.exe), or your own client, to find and fix any potential errors.  
  
## WCF Service Host  
 WCF Service Host enumerates the services in a WCF service project, loads the project’s configuration, and instantiates a host for each service that it finds. The tool is integrated into Visual Studio through the WCF Service template and is invoked when you start to debug your project.  
  
 By using WCF Service Host, you can host a WCF service (in a WCF service library project) without writing extra code or committing to a specific host during development.  
  
> [!NOTE]
>  WCF Service Host does not support Partial Trust. If you want to use a WCF Service in Partial Trust, do not use the WCF Service Library Project template in Visual Studio to build your service. Instead, create a New WebSite in Visual Studio by choosing the WCF Service WebSite template, which can host the service in a WebServer on which WCF Partial Trust is supported.  
  
## Project Types hosted by WCF Service Host  
 WCF Service Host can host the following WCF service library project types: WCF Service Library, Sequential Workflow Service Library, State Machine Workflow Service Library and Syndication Service Library. WCF Service Host can also host those services that can be added to a service library project using the **Add Item** functionality. This includes WCF Service, WF State Machine Service, WF Sequential Service, XAML WF State Machine Service and XAML WF Sequential Service.  
  
 You should note, however, that the tool will not help you to configure a host. For this task, you must manually edit the App.config file. The tool also does not validate user-defined configuration files.  
  
> [!CAUTION]
>  You should not use WCF Service Host to host services in a production environment, as it was not engineered for this purpose.  WCF Service Host does not support the reliability, security, and manageability requirements of such an environment. Instead, use IIS since it provides superior reliability and monitoring features, and is the preferred solution for hosting services. Once development of your services is complete, you should migrate the services from WCF Service Host to IIS.  
  
## Scenarios for Using WCF Service Host inside Visual Studio  
 The following table lists all the parameters in the **Command line arguments** dialog box, which can be found by right-clicking your project in **Solutions Explorer** in Visual Studio, selecting **Properties**, then selecting the **Debug** tab and clicking **Start Project**. These parameters are useful in configuring WCF Service Host.  
  
|Parameter|Meaning|  
|---------------|-------------|  
|`/client`|An optional parameter that specifies the path to an executable to run after the services are hosted. This launches WCF Test Client following hosting.|  
|`/clientArg`|Specify a string as an argument that is passed to the custom client application.|  
|`/?`|Displays the help text.|  
  
#### Using WCF Test Client  
 After you create a new WCF service project and press F5 to start the debugger, WCF Service Host starts hosting all the services it finds in your project. WCF Test Client automatically opens and displays a list of service endpoints defined in the configuration file. From the main window, you can test the parameters and invoke your service.  
  
 To make sure that WCF Test Client is used, right-click your project in **Solutions Explorer** in Visual Studio, select **Properties**, then select the **Debug** tab. Click **Start Project** and ensure that the following appears in the **Command line arguments** dialog box.  
  
 `/client:WcfTestClient.exe`  
  
#### Using a Custom Client  
 To use a custom client, right-click your project in **Solutions Explorer** in Visual Studio, select **Properties**, then select the **Debug** tab. Click **Start Project** and edit the `/client` parameter in the **Command line arguments** dialog box to point to your custom client, as indicated in the following example.  
  
 `/client:"path/CustomClient.exe"`  
  
 When you press F5 to start the service again, WCF Service Host automatically starts your custom client when you launch the debugger.  
  
 You can also use the `/clientArg:` parameter to specify a string as an argument that is passed to the custom client application, as indicated in the following example.  
  
 `/client:"path/CustomClient.exe" /clientArg:"arguments that are passed to Client"`  
  
 For example, if you are using the Syndication Service Library template, you can use the following command line arguments,  
  
 `/client:iexplore.exe /clientArgs:http://localhost:8731/Design_Time_Addresses/Feed1/`  
  
#### Specifying No Client  
 To specify that no client will be used after WCF service hosting, right-click your project in **Solutions Explorer** in Visual Studio, select **Properties**, then select the **Debug** tab. Click **Start Project** and leave the **Command line arguments** dialog box blank.  
  
#### Using a Custom Host  
 To use a custom host, right-click your project in **Solutions Explorer** in Visual Studio, select **Properties**, then select the **Debug** tab. Click **Start External Program** and enter the full path to the custom host. You can also use the **Command line arguments** dialog box to specify arguments to be passed to the host.  
  
## WCF Service Host User Interface  
 When you initially invoke WCF Service Host (by pressing F5 inside Visual Studio), the **WCF Service Host** window automatically opens. When WCF Service Host is running, the program's icon appears in the notification area. Double-click the icon to open the **WCF Service Host** window  
  
 When errors occur during service hosting, WCF Service Host dialog box will open to display relevant information.  
  
 The **WCF Service Host** main window contains two menus:  
  
-   **File**: Contains the **Close** and **Exit** commands. When you click **Close**, the **WCF Service Host** dialog box closes, but the services continue to be hosted. When you click **Exit**, WCF Service Host is also shut down. This also stops all hosted services.  
  
-   **Help**: Contains the **About** command that contains version information. It also contains the **Help** command that can open a help file.  
  
 The main **WCF Service Host** window contains two areas:  
  
-   The first area is **Service**. It contains a list that displays basic information of all services. The information includes:  
  
    -   **Service**: Lists all the services.  
  
    -   **Status**: Lists the status of the service. Valid values are "Started", "Stopped," and "Error".  
  
    -   **Metadata Address**: Displays the metadata address of the services.  
  
-   The second area is **Additional Information**. It displays a detailed explanation of the service status when the specific service line is selected in the **Service** area. If the status is Error, you can view the full error message on the screen.  
  
## Stopping WCF Service Host  
 You can shut down WCF Service Host in the following four ways:  
  
-   Stop the debugging session in Visual Studio.  
  
-   Select **Exit** from the **File** menu in the **WCF Service Host** window.  
  
-   Select **Exit** from context menu of WCF Service Host tray icon in the system notification area.  
  
-   Exit WCF Test Client if it is being used.  
  
## Using Service Host without Administrator privilege  
 To enable users without administrator privilege to develop WCF services, an ACL (Access Control List) is created for the namespace "http://+:8731/Design_Time_Addresses" during the installation of Visual Studio. The ACL is set to (UI), which includes all interactive users logged on to the machine. Administrators can add or remove users from this ACL, or open additional ports.This ACL enables users to use the WCF Service Auto Host (wcfSvcHost.exe) without granting them administrator privileges.  
  
 You can modify access using the netsh.exe tool in [!INCLUDE[wv](../../../includes/wv-md.md)] under the elevated administrator account. The following is an example of using netsh.exe.  
  
```  
netsh http add urlacl url=http://+:8001/MyService user=<domain>\<user>  
```  
  
 For more information on netsh.exe, see "[How to Use the Netsh.exe Tool and Command-Line Switches](https://go.microsoft.com/fwlink/?LinkId=97877)".  
  
## See Also  
 [WCF Test Client (WcfTestClient.exe)](../../../docs/framework/wcf/wcf-test-client-wcftestclient-exe.md)
