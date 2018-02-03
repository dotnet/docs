---
title: "&lt;UseRandomizedStringHashAlgorithm&gt; Element"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "UseRandomizedStringHashAlgorithm element"
  - "<UseRandomizedStringHashAlgorithm> element"
ms.assetid: c08125d6-56cc-4b23-b482-813ff85dc630
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;UseRandomizedStringHashAlgorithm&gt; Element
Determines whether the common language runtime calculates hash codes for strings on a per application domain basis.  
  
 \<configuration>  
\<runtime>  
\<UseRandomizedStringHashAlgorithm>  
  
## Syntax  
  
```xml  
<UseRandomizedStringHashAlgorithm   
   enabled=0|1 />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`enabled`|Required attribute.<br /><br /> Specifies whether hash codes for strings are calculated on a per application domain basis.|  
  
## enabled Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|`0`|The common language runtime does not compute hash codes for strings on a per application domain basis; a single algorithm is used to calculate string hash codes. This is the default.|  
|`1`|The common language runtime computes hash codes for strings on a per application domain basis. Identical strings in different application domains and in different processes will have different hash codes.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about runtime initialization options.|  
  
## Remarks  
 By default, the <xref:System.StringComparer> class and the <xref:System.String.GetHashCode%2A?displayProperty=nameWithType> method use a single hashing algorithm that produces a consistent hash code across application domains. This is equivalent to setting the `enabled` attribute of the `<UseRandomizedStringHashAlgorithm>` element to `0`. This is the hashing algorithm used in the [!INCLUDE[net_v40_short](../../../../../includes/net-v40-short-md.md)].  
  
 The <xref:System.StringComparer> class and the <xref:System.String.GetHashCode%2A?displayProperty=nameWithType> method can also use a different hashing algorithm that computes hash codes on a per application domain basis. As a result, hash codes for equivalent strings will differ across application domains. This is an opt-in feature; to take advantage of it, you must set the `enabled` attribute of the `<UseRandomizedStringHashAlgorithm>` element to `1`.  
  
 The string lookup in a hash table is typically an O(1) operation. However, when a large number of collisions occur, the lookup can become an O(n<sup>2</sup>) operation. You can use the `<UseRandomizedStringHashAlgorithm>` configuration element to generate a random hashing algorithm per application domain, which in turn limits the number of potential collisions, particularly when the keys from which the hash codes are calculated are based on data input by users.  
  
## Example  
 The following example defines a `DisplayString` class that includes a private string constant, `s`, whose value is "This is a string." It also includes a `ShowStringHashCode` method that displays the string value and its hash code along with the name of the application domain in which the method is executing.  
  
 [!code-csharp[System.String.GetHashCode#2](../../../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.String.GetHashCode/CS/perdomain.cs#2)]
 [!code-vb[System.String.GetHashCode#2](../../../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.String.GetHashCode/VB/perdomain.vb#2)]  
  
 When you run the example without supplying a configuration file, it displays output similar to the following. Note that the hash codes for the string are identical in the two application domains.  
  
```  
String 'This is a string.' in domain 'PerDomain.exe': 941BCEAC  
String 'This is a string.' in domain 'NewDomain': 941BCEAC  
```  
  
 However, if you add the following configuration file to the example's directory and then run the example, the hash codes for the same string will differ by application domain.  
  
```xml  
<?xml version ="1.0"?>  
<configuration>  
   <runtime>  
      <UseRandomizedStringHashAlgorithm enabled="1" />  
   </runtime>  
</configuration>  
```  
  
 When the configuration file is present, the example displays the following output:  
  
```  
String 'This is a string.' in domain 'PerDomain.exe': 5435776D  
String 'This is a string.' in domain 'NewDomain': 75CC8236  
```  
  
## See Also  
 <xref:System.StringComparer.GetHashCode%2A?displayProperty=nameWithType>  
 <xref:System.String.GetHashCode%2A?displayProperty=nameWithType>  
 <xref:System.Object.GetHashCode%2A?displayProperty=nameWithType>
