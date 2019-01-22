---
title: "&lt;add&gt; of &lt;namespaceTable&gt;"
ms.date: "03/30/2017"
ms.assetid: cf7b5b75-63bd-49a6-abac-4bfdab377e36
---
# &lt;add&gt; of &lt;namespaceTable&gt;
Represents a configuration element that contains a namespace to prefix mapping that can then be used in XPath filters for routing.  
  
 \<system.serviceModel>  
\<routing>  
\<namespaceTable>  
\<add>  
  
## Syntax  
  
```xml  
<routing>
  <namespaceTable>
    <add namespace="String"
         prefix="String" />
  </namespaceTable>
</routing>
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
  
## See also
 <xref:System.ServiceModel.Routing.Configuration.NamespaceElement?displayProperty=nameWithType>    
