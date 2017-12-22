---
title: "&lt;comContracts&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 42e74148-223d-4888-a8ed-1d928527eb09
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;comContracts&gt;
The `comContracts` configuration section contains elements that allow you to specify various properties of a COM+ integration service contract.  
  
## Specifying Namespace and Contract  
 COM+ integration service contracts are currently restricted to the "http://tempuri.org" namespace, and contract name is derived from the supporting COM interface. You can, however, specify alternatives by using the `comContracts` section in the configuration file.  
  
 For example, you can use the following configuration to specify the namespace and contract name of the service contract, as well as an option to enforce usage on sessionful bindings.  
  
```xml  
<comContracts>  
  <comContract  
      contract="{5163B1E7-F0CF-4B6A-9A02-4AB654F34284}"  
      namespace="http://tempuri.org/5163B1E7-F0CF-4B6A-9A02-4AB654F34284"  
      name="_Broker"  
      requireSession="true">  
  </comContract>  
</comContracts>  
```  
  
 When the service is initialized, the specified namespaces and contract names are applied to the generated service descriptions.  
  
 When this section is empty, the service initialization applies a default namespace and contract name taken from the supporting COM interface ID.  
  
 In addition, you can use the [\<exposedMethod>](../../../../../docs/framework/configure-apps/file-schema/wcf/exposedmethod.md) element to specify COM+ methods that are exposed when the interface on a COM+ component is exposed as a Web service. You can also use the [\<persistableTypes>](../../../../../docs/framework/configure-apps/file-schema/wcf/persistabletypes.md) to specify persistable types used in integration. Finally, you can use the [\<userDefinedType>](../../../../../docs/framework/configure-apps/file-schema/wcf/userdefinedtype.md) element to include User Defined Types (UDT) that are to be included in the service contract.  
  
## See Also  
 <xref:System.ServiceModel.Configuration.ComContractElementCollection>  
 <xref:System.ServiceModel.Configuration.ComContractElement>  
 [\<exposedMethod>](../../../../../docs/framework/configure-apps/file-schema/wcf/exposedmethod.md)  
 [\<persistableTypes>](../../../../../docs/framework/configure-apps/file-schema/wcf/persistabletypes.md)  
 [\<userDefinedType>](../../../../../docs/framework/configure-apps/file-schema/wcf/userdefinedtype.md)  
 [\<comContract>](../../../../../docs/framework/configure-apps/file-schema/wcf/comcontract.md)  
 [Integrating with COM+ Applications](../../../../../docs/framework/wcf/feature-details/integrating-with-com-plus-applications.md)  
 [How to: Configure COM+ Service Settings](../../../../../docs/framework/wcf/feature-details/how-to-configure-com-service-settings.md)
