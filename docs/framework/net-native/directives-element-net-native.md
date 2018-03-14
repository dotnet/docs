---
title: "&lt;Directives&gt; Element (.NET Native)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 444846f3-48d5-4341-a43e-69f7221389eb
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;Directives&gt; Element (.NET Native)
The root element in every runtime directives file for [!INCLUDE[net_native](../../../includes/net-native-md.md)].  
  
 **\<Directives xmlns="http://schemas.microsoft.com/netfx/2013/01/metadata">**  
  
## Syntax  
  
```xml  
      <Directives xmlns="http://schemas.microsoft.com/netfx/2013/01/metadata">  
   <!-- child elements -->   
</Directives>  
```  
  
## Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`xmlns`|The XML namespace. Its value is always **"http://schemas.microsoft.com/netfx/2013/01/metadata"**.|  
  
## Child elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<Application>](../../../docs/framework/net-native/application-element-net-native.md)|Serves as a container for application-wide types and type members whose metadata is available for reflection.|  
|[\<Library>](../../../docs/framework/net-native/library-element-net-native.md)|Defines the assembly whose child types and type members require metadata at run time.|  
  
## Remarks  
 Each runtime directives file can contain only one `<Directives>` element.  
  
 The `<Directives>` element can contain zero or one [\<Application>](../../../docs/framework/net-native/application-element-net-native.md) element, and zero, one, or more [\<Library>](../../../docs/framework/net-native/library-element-net-native.md) elements.  
  
## See Also  
 [Runtime Directives (rd.xml) Configuration File Reference](../../../docs/framework/net-native/runtime-directives-rd-xml-configuration-file-reference.md)  
 [Runtime Directive Elements](../../../docs/framework/net-native/runtime-directive-elements.md)
