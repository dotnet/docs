---
title: "&lt;add&gt; of &lt;namespaceTable&gt; | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: cf7b5b75-63bd-49a6-abac-4bfdab377e36
caps.latest.revision: 2
author: "Erikre"
ms.author: "erikre"
manager: "erikre"
---
# &lt;add&gt; of &lt;namespaceTable&gt;
Represents a configuration element that contains a namespace to prefix mapping that can then be used in XPath filters for routing.  
  
 \<system.serviceModel>  
\<routing>  
\<namespaceTable>  
\<add>  
  
## Syntax  
  
```vb  
   <routing>   <namespaceTable>  
     <add namespace="String" prefix="String" />    </namespaceTable></routing>  
```  
  
```csharp  
  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|namespace|A string containing the namespace.|  
|prefix|A string containing the prefix for this namespace.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<namespaceTable>](../../../../../docs/framework/configure-apps/file-schema/wcf/namespacetable.md)|Represents a configuration section for defining a set of elements that contain namespace to prefix mappings that can then be used in XPath filters for routing.|  
  
## See Also  
 <xref:System.ServiceModel.Routing.Configuration.NamespaceElement?displayProperty=fullName>    
