---
title: "How to: Use the COM+ Service Model Configuration Tool"
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
  - "COM+ [WCF], using service model configuration tool"
ms.assetid: 7e68cd8d-5fda-4641-b92f-290db874376e
caps.latest.revision: 13
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Use the COM+ Service Model Configuration Tool
Once you have selected an appropriate hosting mode, use the COM+ Service Model Configuration command-line tool (ComSvcConfig.exe) to configure the application interfaces that will be exposed as Web services.  
  
> [!NOTE]
>  You must be an administrator on the machine to perform any of the following tasks.  
  
 When using ComSvcConfig.exe on a Windows 7 machine to configure a web service to use the latest service model version (currently v4.5), perform the following steps:  
  
1.  Set the registry key  `[HKEY_LOCAL_COMPUTER\SOFTWARE\Microsoft\.NETFramework]\OnlyUseLatestCLR` to a DWORD value of 0x00000001  
  
2.  Run comsvcconfig.exe  
  
3.  Revert the registry key added in step 1 back to its original value, or delete it if did not exist.  
  
> [!IMPORTANT]
>  Reverting this registry key is important. This is a compatibility key. Not reverting this change may cause issues with other .NET applications running on the machine).  
  
> [!WARNING]
>  When using ComSvcConfig.exe  /install on a Windows 8 machine a dialog is displayed stating "An app on your PC needs the following Windows feature: .NET Framework 3.5 (includes .NET 2.0 and .NET 3.0" if .NET Framework 3.5 is not installed. This dialog may be ignored. Alternatively you can sed the OnlyUseLatestCLR registry key to a DWORD value of 0x00000001  
  
### To add an interface to the set of interfaces that are to be exposed as Web services, using the COM+ hosting mode  
  
-   Run ComSvcConfig using the `/install` and `/hosting:complus` options, as shown in the following example.  
  
    ```  
    ComSvcConfig.exe /install /application:OnlineStore /contract:ItemOrders.Financial,IFinances /hosting:complus /verbose  
    ```  
  
     The command adds the `IFinances` interface of the `ItemOrders.IFinancial` component (from the OnlineStore COM+ application) to the set of interfaces that will be exposed as Web services. The service uses the COM+ hosting mode and therefore requires explicit application activation.  
  
     While the wildcard asterisk (*) character can be used for the component and the interface, avoid using it because you might want to expose only selected functionality as a Web service. If run with a future version of this component, using the wildcard may unintentionally expose interfaces that may not have been present when the configuration syntax was determined.  
  
     The /verbose option instructs the tool to display warnings in addition to any errors.  
  
     The contract for the exposed service will contain all of the methods from the `IFinances` interface.  
  
### To add only specific methods from an interface to the set of interfaces that are to be exposed as Web services, using the COM+ hosting mode  
  
-   Run ComSvcConfig using the `/install` and `/hosting:complus` options with explicit naming of the required methods, as shown in the following example.  
  
    ```  
    ComSvcConfig.exe /install /application:OnlineStore /contract:ItemOrders.Financial,IFinances.{Credit,Debit} /hosting:complus /verbose  
    ```  
  
     The command adds only the `Credit` and `Debit` methods from the `IFinances` interface as operations to the exposed service contract. All other methods on the interface will be omitted from the contract and will not be callable from Web service clients.  
  
### To add an interface to the set of interfaces that are to be exposed as Web services, using the Web hosting mode  
  
-   Run ComSvcConfig using the `/install` option and the `/hosting:was` option, as shown in the following example.  
  
    ```  
    ComSvcConfig.exe /install /application:OnlineWarehouse /contract:ItemInventory.Warehouse,IStockLevels /hosting:was /webDirectory:root/OnlineWarehouse /mex /verbose  
    ```  
  
     The command adds the `IStockLevels` interface on the `ItemInventory.Warehouse` component (from the OnlineWarehouse COM+ application) to the set of interfaces that will be exposed as Web services. The service is Web hosted in the OnlineWarehouse virtual directory of IIS rather than in COM+, and thus the application is automatically activated as required.  
  
     To use the Web-hosted in-process configuration, the COM+ application must be configured to run as a Library application rather than a Server application using the Component Services administration console. Applications configured as Server applications use the standard Web-hosted mode and incur a process hop to process each request.  
  
     The `/mex` option adds an additional Metadata Exchange (MEX) service endpoint that uses the same transport as the application's service endpoint to support clients that want to retrieve a contract definition from the service.  
  
### To remove a Web service for a specified interface  
  
-   Run ComSvcConfig using the `/uninstall` option, as shown in the following example.  
  
    ```  
    ComSvcConfig.exe /uninstall /application:OnlineStore /contract:ItemOrders.Financial,IFinances /hosting:complus  
    ```  
  
     The command removes the `IFinances` interface on the `ItemOrders.Financial` component (from the OnlineStore COM+ application).  
  
### To list currently exposed interfaces  
  
-   Run ComSvcConfig using the `/list` option, as shown in the following example.  
  
    ```  
    ComSvcConfig.exe /list  
    ```  
  
     The command lists the currently exposed interfaces, along with the corresponding address and binding details, scoped to the local machine.  
  
### To list specific currently exposed interfaces  
  
-   Run ComSvcConfig using the `/list` option, as shown in the following example.  
  
    ```  
    ComSvcConfig.exe /list /application:OnlineStore /hosting:complus  
    ```  
  
     The command lists currently exposed COM+-hosted interfaces, along with the corresponding address and binding details, for the OnlineStore COM+ application on the local machine.  
  
### To display help on the options that can be used with the utility  
  
-   Run ComSvcConfig using the /? option, as shown in the following example.  
  
    ```  
    ComSvcConfig.exe /?  
    ```  
  
## See Also  
 [Integrating with COM+ Applications Overview](../../../../docs/framework/wcf/feature-details/integrating-with-com-plus-applications-overview.md)
