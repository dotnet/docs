---
title: "&lt;supportedRuntime&gt; Element | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#supportedRuntime"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/startup/supportedRuntime"
dev_langs: 
  - "VB"
  - "CSharp"
  - "C++"
  - "jsharp"
helpviewer_keywords: 
  - "supportedRuntime element"
  - "<supportedRuntime> element"
ms.assetid: 1ae16e23-afbe-4de4-b413-bc457f37b69f
caps.latest.revision: 33
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
---
# &lt;supportedRuntime&gt; Element
Specifies which versions of the common language runtime the application supports. This element should be used by all applications built with version 1.1 or later of the .NET Framework.  
  
 [\<configuration>](../../../../../docs/framework/configure-apps/file-schema/configuration-element.md)  
  
 [\<startup>](../../../../../docs/framework/configure-apps/file-schema/startup/startup-element.md)  
  
 **\<supportedRuntime>**  
  
## Syntax  
  
```  
  
<supportedRuntime version="runtime version" sku="sku id"/>  
```  
  
## Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|**version**|Optional attribute.<br /><br /> A string value that specifies the version of the common language runtime (CLR) that this application supports. For valid values of the `version` attribute, see the ["runtime version" values](#version) section. **Note:**  Through the .NET Framework 3.5, the "*runtime version*" value takes the form *major*.*minor*.*build*. Beginning with the [!INCLUDE[net_v40_long](../../../../../includes/net-v40-long-md.md)], only the major and minor version numbers are required (that is, "v4.0" instead of "v4.0.30319"). The shorter string is recommended.|  
|**sku**|Optional attribute.<br /><br /> A string value that specifies the stock-keeping unit (SKU), which in turn specifies which .NET Framework release this application supports.<br /><br /> Starting with the .NET Framework 4.0, the use of the `sku` attribute is recommended.  When present, it indicates the version of the .NET Framework that the app targets.<br /><br /> For valid values of the sku attribute, see the ["sku id" values](#sku) section.|  
  
## Remarks  
 If the **\<supportedRuntime>** element is not present in the application configuration file, the version of the runtime used to build the application is used.  
  
 The **\<supportedRuntime>** element should be used by all applications built using version 1.1 or later of the runtime. Applications built to support only version 1.0 of the runtime must use the [\<requiredRuntime>](../../../../../docs/framework/configure-apps/file-schema/startup/requiredruntime-element.md) element.  
  
> [!NOTE]
>  If you use the [CorBindToRuntimeByCfg](../../../../../docs/framework/unmanaged-api/hosting/corbindtoruntimebycfg-function.md) function to specify the configuration file, you must use the `<requiredRuntime>` element for all versions of the runtime. The `<supportedRuntime>` element is ignored when you use [CorBindToRuntimeByCfg](../../../../../docs/framework/unmanaged-api/hosting/corbindtoruntimebycfg-function.md).  
  
 For apps that support versions of the runtime from the .NET Framework 1.1 through 3.5, when multiple versions of the runtime are supported, the first element should specify the most preferred version of the runtime, and the last element should specify the least preferred version. For apps that support the .NET Framework 4.0 or later versions, the `version` attribute indicates the CLR version, which is common to the .NET Framework 4 and later versions, and the `sku` attribute indicates single .NET Framework version that the app targets.  
  
> [!NOTE]
>  If your application uses legacy activation paths, such as the [CorBindToRuntimeEx function](../../../../../docs/framework/unmanaged-api/hosting/corbindtoruntimeex-function.md), and you want those paths to activate version 4 of the CLR instead of an earlier version, or if your application is built with the [!INCLUDE[net_v40_short](../../../../../includes/net-v40-short-md.md)] but has a dependency on a mixed-mode assembly built with an earlier version of the .NET Framework, it is not sufficient to specify the [!INCLUDE[net_v40_short](../../../../../includes/net-v40-short-md.md)] in the list of supported runtimes. In addition, in the [\<startup> element](../../../../../docs/framework/configure-apps/file-schema/startup/startup-element.md) in your configuration file, you must set the `useLegacyV2RuntimeActivationPolicy` attribute to `true`. However, setting this attribute to `true` means that all components built with earlier versions of the .NET Framework are run using the [!INCLUDE[net_v40_short](../../../../../includes/net-v40-short-md.md)] instead of the runtimes they were built with.  
  
 We recommend that you test applications with all the .NET Framework versions that they can run on.  
  
<a name="version"></a>   
## "runtime version" values  
 The following table lists valid values for the *runtime version* value of the `version` attribute.  
  
|.NET Framework version|`version` attribute|  
|----------------------------|-------------------------|  
|1.0|"v1.0.3705"|  
|1.1|"v1.1.4322"|  
|2.0|"v2.0.50727"|  
|3.0|"v2.0.50727"|  
|3.5|"v2.0.50727"|  
|4.0|"v4.0"|  
|4.5|"v4.0"|  
|4.5.1|"v4.0"|  
|4.5.2|"v4.0"|  
|4.6|"v4.0"|  
|4.6.1|"v4.0"|  
|4.6.2|"v4.0"| 
|4.7|"v4.7" | 
  
<a name="sku"></a>   
## "sku id" values  
 The following table lists the versions of the .NET Framework starting with the .NET Framework 4 that are supported by the `sku` attribute.  Note that the `sku` attribute starting with the .NET Framework 4 indicates the version of the .NET Framework that the app targets.  
  
|.NET Framework version|`sku` attribute|  
|----------------------------|---------------------|  
|4.0|".NETFramework,Version=v4.0"|  
|4.0, Client Profile|".NETFramework,Version=v4.0,Profile=Client"|  
|4.0, platform update 1|.NETFramework,Version=v4.0.1|  
|4.0, Client Profile, update 1|.NETFramework,Version=v4.0.1,Profile=Client|  
|4.0, platform update 2|.NETFramework,Version=v4.0.2|  
|4.0, Client Profile, update 2|.NETFramework,Version=v4.0.2,Profile=Client|  
|4.0, platform update 3|.NETFramework,Version=v4.0.3|  
|4.0, Client Profile, update 3|.NETFramework,Version=v4.0.3,Profile=Client|  
|4.5|".NETFramework,Version=v4.5"|  
|4.5.1|".NETFramework,Version=v4.5.1"|  
|4.5.2|".NETFramework,Version=v4.5.2"|  
|4.6|".NETFramework,Version=v4.6"|  
|4.6.1|".NETFramework,Version=v4.6.1"|  
|4.6.2|".NETFramework,Version=v4.6.2"|  
|4.7|".NETFramework,Version=4.7"|
  
 The following table shows which installed versions of the .NET Framework 4 an application will run on, for different values of the `sku` attribute, when the `version` attribute is v4.0 and the `sku` attribute identifies the .NET Framework 4 or one of its platform updates (PU).  
  
|Value of `sku` attribute|4.0 Client|4.0 Full|4.0 Client + PU 1|4.0 Full + PU 1|4.0 Client + PU 2|4.0 Full + PU 2|4.0 Client + PU 3|4.0 Full + PU 3|4.5 and later|  
|------------------------------|----------------|--------------|------------------------|----------------------|------------------------|----------------------|------------------------|----------------------|-------------------|  
|.NETFramework,Version=v4.0,Profile=Client|Yes|Yes|Yes|Yes|Yes|Yes|Yes|Yes|Yes|  
|.NETFramework,Version=v4.0||Yes||Yes||Yes||Yes|Yes|  
|.NETFramework,Version=v4.0.1,Profile=Client|||Yes|Yes|Yes|Yes|Yes|Yes|Yes|  
|.NETFramework,Version=v4.0.1||||Yes||Yes||Yes|Yes|  
|.NETFramework,Version=v4.0.2,Profile=Client|||||Yes|Yes|Yes|Yes|Yes|  
|.NETFramework,Version=v4.0.2||||||Yes||Yes|Yes|  
|.NETFramework,Version=v4.0.3,Profile=Client|||||||Yes|Yes|Yes|  
|.NETFramework,Version=v4.0.3||||||||Yes|Yes|  
  
## Example  
 The following example shows how to specify the supported runtime version in a configuration file. The configuration file indicates that the app targets the .NET Framework 4.6.  
  
```xml  
  
<configuration>  
   <startup>  
      <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.6" />  
   </startup>  
</configuration>  
  
```  
  
## Configuration File  
 This element can be used in the application configuration file.  
  
## See Also  
 [Startup Settings Schema](../../../../../docs/framework/configure-apps/file-schema/startup/index.md)   
 [Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)   
 [In-Process Side-by-Side Execution](../../../../../docs/framework/deployment/in-process-side-by-side-execution.md)