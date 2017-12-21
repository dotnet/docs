---
title: "&lt;userDefinedType&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 0f70ec06-8249-4f0c-9f49-b4df59985fb8
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;userDefinedType&gt;
Represents a User Defined Type (UDT) that is to be included in the service contract.  
  
 \<system.ServiceModel>  
\<comContracts>  
\<comContract>  
\<userDefinedTypes>  
  
## Syntax  
  
```xml  
<comContracts>  
  <comContract>  
      <userDefinedTypes>  
         <userDefinedType name="string"  
            typeLibID="string"  
            typeLibVersion="string"  
            typeDefID="string">  
         </userDefinedType>  
      </userDefinedTypes>  
  </comContract>  
</comContracts>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`name`|An optional attribute that contains a string that provides the readable type name. This is not used by the runtime but helps a reader to distinguish the types.|  
|`TypeDefID`|A GUID string that identifies the specific UDT type within the registered type library.|  
|`TypeLibID`|A GUID string that identifies the registered type library that defines the type.|  
|`TypeLibVersion`|A string that identifies the type library version that defines the type.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`userDefinedTypes`|A collection of `userDefinedType` elements.|  
  
## Remarks  
 The COM+ integration runtime creates services by inspecting the type library. When a COM+ component contains methods that pass a VARIANT, the system cannot determine the actual types to be passed prior to runtime. Therefore, when you attempt to pass a User Defined Type (UDT) within a VARIANT, it fails because it is not a known type for serialization.  
  
 To circumvent this problem, you can add the UDTs to the configuration file so that they can be included as known types on the appropriate service contract. In order to do so, you have to uniquely identify the UDT and the contract(s), that is, the original COM interface(s) that uses it.  
  
 The following example demonstrates adding two specific UDTs to the <`userDefinedTypes`> section of the configuration file for this purpose.  
  
```xml  
<comContracts>  
  <comContract  
      contract="{5163B1E7-F0CF-4B6A-9A02-4AB654F34284}"  
      namespace="http://tempuri.org/5163B1E7-F0CF-4B6A-9A02-4AB654F34284"  
      name="_Broker"  
      requireSession="true">  
      <userDefinedTypes>  
         <userDefinedType name="CustomerType"  
            typeLibID="{91DC728C-4F1A-45de-A9B6-B538E209CEA6}"  
            typeLibVersion="1.0"  
            typeDefID="{D129765C-F211-434e-825A-9A63198C41F2}">  
         </userDefinedType>  
         <userDefinedType name="AddressType"  
            typeLibID="{91DC728C-4F1A-45de-A9B6-B538E209CEA6}"  
            typeLibVersion="1.0"  
            typeDefID="{4616AE0D-687A-43B7-BC63-141AE3DFD099}">  
         </userDefinedType>  
      </userDefinedTypes>  
      <exposedMethods>  
         <exposedMethod name="BuyStock" />  
         <exposedMethod name="SellStock" />  
         <exposedMethod name="ExecuteTransaction" />  
      </exposedMethods>  
  </comContract>  
</comContracts>  
```  
  
 When the service is initialized, the integration runtime looks up the specified types and adds them to the known types collection for the specified contracts.  
  
## See Also  
 <xref:System.ServiceModel.Configuration.ComContractElement.UserDefinedTypes%2A>  
 <xref:System.ServiceModel.Configuration.ComUdtElementCollection>  
 <xref:System.ServiceModel.Configuration.ComUdtElement>  
 [\<comContracts>](../../../../../docs/framework/configure-apps/file-schema/wcf/comcontracts.md)  
 [Integrating with COM+ Applications](../../../../../docs/framework/wcf/feature-details/integrating-with-com-plus-applications.md)  
 [How to: Configure COM+ Service Settings](../../../../../docs/framework/wcf/feature-details/how-to-configure-com-service-settings.md)
