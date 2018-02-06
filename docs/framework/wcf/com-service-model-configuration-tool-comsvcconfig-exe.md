---
title: "COM+ Service Model Configuration Tool (ComSvcConfig.exe)"
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
  - "Windows Communication Foundation, COM+ integration"
  - "WCF, COM+ integration"
ms.assetid: 7717c6c2-85fc-418b-a8ed-bad8e61cec5c
caps.latest.revision: 15
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# COM+ Service Model Configuration Tool (ComSvcConfig.exe)
The COM+ Service Model Configuration command-line tool (ComSvcConfig.exe) enables you to configure COM+ interfaces to be exposed as Web services.  
  
## Syntax  
  
```  
ComSvcConfig.exe /install | /uninstall | /list [/application:<ApplicationID | ApplicationName>] [/contract:<ClassID | ProgID | *,InterfaceID | InterfaceName | *>] [/hosting:<complus | was>] [/webSite:<WebsiteName>] [/webDirectory:<WebDirectoryName>] [/mex] [/id] [/nologo] [/verbose] [/help] [/partial]  
```  
  
## Remarks  
  
> [!NOTE]
>  You must be an administrator on the local computer to use ComSvcConfig.exe.  
  
 The tool can be found in the following location  
  
 %SystemRoot%\Microsoft.Net\Framework\v3.0\Windows Communication Foundation\  
  
 For more information about ComSvcConfig.exe, see [How to: Use the COM+ Service Model Configuration Tool](../../../docs/framework/wcf/feature-details/how-to-use-the-com-service-model-configuration-tool.md).  
  
 The following table describes the modes that can be used with ComSvcConfig.exe.  
  
|Option|Description|  
|------------|-----------------|  
|`install`|Installs a configuration for a COM+ interface for Service Model integration.<br /><br /> Short form `/i`.|  
|`uninstall`|Uninstalls a configuration for a COM+ interface from Service Model integration.<br /><br /> Short form `/u`.|  
|`list`|Lists information about COM+ applications and components that have interfaces that are configured for Service Model integration.<br /><br /> Short form `/l`.|  
  
 The following table describes the flags that can be used with ComSvcConfig.exe.  
  
|Option|Description|  
|------------|-----------------|  
|`/application:` \<*ApplicationID* &#124; *ApplicationName*\>|Specifies the COM+ application to configure.<br /><br /> Short form `/a`.|  
|`/contract:` \<*ClassID*  &#124; *ProgID*  &#124; \*,*InterfaceID* &#124; *InterfaceName* &#124; \*\>|Specifies the COM+ component and interface that will be configured as the contract for the service.<br /><br /> Short form `/c`.<br /><br /> While the wildcard character (\*) can be used when you specify the component and interface names, we recommend that you do not use it, because you might expose interfaces that you did not intend to.|  
|`/hosting:` \<*complus*  &#124; *was*\>|Specifies whether to use the COM+ hosting mode or the Web hosting mode.<br /><br /> Short form `/h`.<br /><br /> Using the COM+ hosting mode requires explicit activation of the COM+ application. Using the Web hosting mode allows the COM+ application to be automatically activated as required. If the COM+ application is a library application, it runs in the Internet Information Services (IIS) process. If the COM+ application is a server application, it runs in the Dllhost.exe process.|  
|`/webSite:` \<*WebsiteName*\>|Specifies the Web site for hosting when Web hosting mode is used (see the `/hosting` flag).<br /><br /> Short form `/w`.<br /><br /> If no Web site is specified, the default Web site is used.|  
|`/webDirectory:` \<*WebDirectoryName*\>|Specifies the virtual directory for hosting when Web hosting is used (see the `/hosting` flag).<br /><br /> Short form `/d`.|  
|`/mex`|Adds a Metadata Exchange (MEX) service endpoint to the default service configuration to support clients that want to retrieve a contract definition from the service.<br /><br /> Short form `/x`.|  
|`/id`|Displays the application, component, and interface information as IDs.<br /><br /> Short form `/k`.|  
|`/nologo`|Prevents ComSvcConfig.exe from displaying its logo.<br /><br /> Short form `/n`.|  
|`/verbose`|Outputs all warnings or informational text in addition to any errors encountered.<br /><br /> Short form `/v`.|  
|`/help`|Displays the usage message.<br /><br /> Short form `/?`.|  
|`/partial`|Generates a service configuration when the specified interface includes one or more method signatures that can be exposed. At service initialization time, compatible methods appear as operations on the service contract, and non-compatible methods are ignored and absent from the service contract.<br /><br /> If this flag is missing, the tool will not generate a service configuration when the specified interface includes one or more incompatible methods.|  
  
## Examples  
  
### Description  
 The following example adds the `IFinances` interface of the `ItemOrders.IFinancial` component (from the OnlineStore COM+ application) to the set of interfaces that are exposed as Web services, using the COM+ hosting mode. All warnings will be output in addition to any errors encountered.  
  
### Code  
  
```  
ComSvcConfig.exe /install /application:OnlineStore /contract:ItemOrders.Financial,IFinances /hosting:complus /verbose  
```  
  
### Description  
 The following example adds the `IStockLevels` interface of the `ItemInventory.Warehouse` component (from the OnlineWarehouse COM+ application) to the set of interfaces that are exposed as Web services, using the Web hosting mode. The Web service is Web hosted in the OnlineWarehouse virtual directory of IIS.  
  
### Code  
  
```  
ComSvcConfig.exe /install /application:OnlineWarehouse /contract:ItemInventory.Warehouse,IStockLevels /hosting:was /webDirectory:root/OnlineWarehouse  
```  
  
### Description  
 The following example removes the `IFinances` interface of the `ItemOrders.Financial` component (from the OnlineStore COM+ application) from the set of interfaces that are exposed as Web services.  
  
### Code  
  
```  
ComSvcConfig.exe /uninstall /application:OnlineStore /interface:ItemOrders.Financial,IFinances /hosting:complus  
```  
  
### Description  
 The following example lists currently exposed COM+ hosted interfaces, along with the corresponding address and binding details, for the OnlineStore COM+ application on the local machine.  
  
### Code  
  
```  
ComSvcConfig.exe /list /application:OnlineStore /hosting:complus  
```  
  
## See Also  
 [How to: Use the COM+ Service Model Configuration Tool](../../../docs/framework/wcf/feature-details/how-to-use-the-com-service-model-configuration-tool.md)
