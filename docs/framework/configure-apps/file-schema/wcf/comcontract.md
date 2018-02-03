---
title: "&lt;comContract&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 3f8e1c0c-cfdf-4c79-ac65-c64e9323a51c
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;comContract&gt;
Specifies a COM+ integration service contract.  
  
 \<system.ServiceModel>  
\<comContracts>  
  
## Syntax  
  
```xml  
<comContracts>  
  <comContract  
      contract="string"  
      namespace="string"  
      name="string"  
      requireSession="Boolean">  
      <exposedMethods>  
         <exposedMethod name="string" />  
      </exposedMethods>  
      <userDefinedTypes>  
         <userDefinedType name="string"  
            typeLibID="string"  
            typeLibVersion="string"  
            typeDefID="string">  
         </userDefinedType>  
      </userDefinedTypes>  
      <persistableTypes>  
         <persistableType id="string"  
            name="string">  
         </persistableType>  
      </persistableTypes>  
  </comContract>  
</comContracts>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|contract|A string that contains the contract type.|  
|name|A string that contains the contract name.|  
|namespace|A string that contains the contract namespace.|  
|requiresSession|A Boolean value that specifies whether the contract can only be used on sessionful bindings. When the service is initialized, the integration runtime ensures that this setting is consistent with the type of binding to be used. An exception is generated if one or more of the bindings for the contract are in conflict. If this property is `false`, and a one-way channel is in use and there are any [out] parameters, an exception is also generated.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|persistableTypes|All the persistable types.|  
|userDefinedTypes|A collection of User Defined Types (UDT) that is to be included in the service contract.|  
|exposedMethods|A collection of COM+ methods that are exposed when the interface on a COM+ component is exposed as a Web service.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|comContracts|Contains a collection of `comContract` elements.|  
  
## Remarks  
 COM+ integration service contracts are currently restricted to the "http://tempuri.org" namespace, and contract name is derived from the supporting COM interface. You can, however, specify alternatives by using the `comContracts` section, as well as the `comContract` element in the configuration file. For example, you can use the following configuration to specify the namespace, contract name, and user defined types to be included, as well as other settings for a service contract.  
  
```xml  
<comContracts>  
  <comContract  
      contract="{5163B1E7-F0CF-4B6A-9A02-4AB654F34284}"  
      namespace="http://tempuri.org/5163B1E7-F0CF-4B6A-9A02-4AB654F34284"  
      name="_Broker"  
      requireSession="true">  
      <exposedMethods>  
         <exposedMethod name="BuyStock" />  
         <exposedMethod name="SellStock" />  
         <exposedMethod name="ExecuteTransaction" />  
      </exposedMethods>  
  </comContract>  
</comContracts>  
```  
  
 When the service is initialized, the specified namespaces and contract names are applied to the generated service descriptions.  
  
## See Also  
 <xref:System.ServiceModel.Configuration.ComContractElementCollection>  
 <xref:System.ServiceModel.Configuration.ComContractElementCollection>  
 <xref:System.ServiceModel.Configuration.ComContractElement>  
 [\<comContracts>](../../../../../docs/framework/configure-apps/file-schema/wcf/comcontracts.md)  
 [Integrating with COM+ Applications](../../../../../docs/framework/wcf/feature-details/integrating-with-com-plus-applications.md)  
 [How to: Configure COM+ Service Settings](../../../../../docs/framework/wcf/feature-details/how-to-configure-com-service-settings.md)
