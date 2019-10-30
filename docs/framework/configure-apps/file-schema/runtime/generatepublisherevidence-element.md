---
title: "<generatePublisherEvidence> Element"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "generatePublisherEvidence element"
  - "<generatePublisherEvidence> element"
ms.assetid: 7d208f50-e8d5-4a42-bc1a-1cf3590706a8
---
# \<generatePublisherEvidence> Element
Specifies whether the runtime creates <xref:System.Security.Policy.Publisher> evidence for code access security (CAS).  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<runtime>**](runtime-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;**\<generatePublisherEvidence>**  
  
## Syntax  
  
```xml  
<generatePublisherEvidence    
   enabled="true|false"/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`enabled`|Required attribute.<br /><br /> Specifies whether the runtime creates <xref:System.Security.Policy.Publisher> evidence.|  
  
## enabled Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|`false`|Does not create <xref:System.Security.Policy.Publisher> evidence.|  
|`true`|Creates <xref:System.Security.Policy.Publisher> evidence. This is the default.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about runtime initialization options.|  
  
## Remarks  
  
> [!NOTE]
> In the .NET Framework 4 and later, this element has no effect on assembly load times. For more information, see the "Security Policy Simplification" section in [Security Changes](../../../security/security-changes.md).  
  
 The common language runtime (CLR) tries to verify the Authenticode signature at load time to create <xref:System.Security.Policy.Publisher> evidence for the assembly. However, by default, most applications do not need <xref:System.Security.Policy.Publisher> evidence. Standard CAS policy does not rely on the <xref:System.Security.Policy.PublisherMembershipCondition>. You should avoid the unnecessary startup cost associated with verifying the publisher signature unless your application executes on a computer with custom CAS policy, or is intending to satisfy demands for <xref:System.Security.Permissions.PublisherIdentityPermission> in a partial-trust environment. (Demands for identity permissions always succeed in a full-trust environment.)  
  
> [!NOTE]
> We recommend that services use the `<generatePublisherEvidence>` element to improve startup performance.  Using this element can also help avoid delays that can cause a time-out and the cancellation of the service startup.  
  
## Configuration File  
 This element can be used only in the application configuration file.  
  
## Example  
 The following example shows how to use the `<generatePublisherEvidence>` element to disable checking for CAS publisher policy for an application.  
  
```xml  
<configuration>  
    <runtime>  
        <generatePublisherEvidence enabled="false"/>  
    </runtime>  
</configuration>  
```  
  
## See also

- [Runtime Settings Schema](index.md)
- [Configuration File Schema](../index.md)
