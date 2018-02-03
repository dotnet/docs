---
title: "Security Considerations for Reflection"
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
  - "permissions [.NET Framework], reflection"
  - "MethodInfo parameters"
  - "reflection, security"
  - "partial trust,reflection"
  - "nonpublic members"
  - "reflection,partial trust"
  - "link demands"
ms.assetid: 42d9dc2a-8fcc-4ff3-b002-4ff260ef3dc5
caps.latest.revision: 21
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Security Considerations for Reflection
Reflection provides the ability to obtain information about types and members, and to access members (that is, to call methods and constructors, to get and set property values, to add and remove event handlers, and so on). The use of reflection to obtain information about types and members is not restricted. All code can use reflection to perform the following tasks:  
  
-   Enumerate types and members, and examine their metadata.  
  
-   Enumerate and examine assemblies and modules.  
  
 Using reflection to access members, by contrast, is subject to restrictions. Beginning with the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)], only trusted code can use reflection to access security-critical members. Furthermore, only trusted code can use reflection to access nonpublic members that would not be directly accessible to compiled code. Finally, code that uses reflection to access a safe-critical member must have whatever permissions the safe-critical member demands, just as with compiled code.  
  
 Subject to necessary permissions, code can use reflection to perform the following kinds of access:  
  
-   Access public members that are not security-critical.  
  
-   Access nonpublic members that would be accessible to compiled code, if those members are not security-critical. Examples of such nonpublic members include:  
  
    -   Protected members of the calling code's base classes. (In reflection, this is referred to as family-level access.)  
  
    -   `internal` members (`Friend` members in Visual Basic) in the calling code's assembly. (In reflection, this is referred to as assembly-level access.)  
  
    -   Private members of other instances of the class that contains the calling code.  
  
 For example, code that is run in a sandboxed application domain is limited to the access described in this list, unless the application domain grants additional permissions.  
  
 Starting with the [!INCLUDE[net_v20SP1_long](../../../includes/net-v20sp1-long-md.md)], attempting to access members that are normally inaccessible generates a demand for the grant set of the target object plus <xref:System.Security.Permissions.ReflectionPermission> with the <xref:System.Security.Permissions.ReflectionPermissionFlag.MemberAccess?displayProperty=nameWithType> flag. Code that is running with full trust (for example, code in an application that is launched from the command line) can always satisfy these permissions. (This is subject to limitations in accessing security-critical members, as described later in this article.)  
  
 Optionally, a sandboxed application domain can grant <xref:System.Security.Permissions.ReflectionPermission> with the <xref:System.Security.Permissions.ReflectionPermissionFlag.MemberAccess?displayProperty=nameWithType> flag, as described in the section [Accessing Members That Are Normally Inaccessible](#accessingNormallyInaccessible), later in this article.  
  
<a name="accessingSecurityCritical"></a>   
## Accessing Security-Critical Members  
 A member is security-critical if it has the <xref:System.Security.SecurityCriticalAttribute>, if it belongs to a type that has the <xref:System.Security.SecurityCriticalAttribute>, or if it is in a security-critical assembly. Beginning with the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)], the rules for accessing security-critical members are as follows:  
  
-   Transparent code cannot use reflection to access security-critical members, even if the code is fully trusted. A <xref:System.MethodAccessException>, <xref:System.FieldAccessException>, or <xref:System.TypeAccessException> is thrown.  
  
-   Code that is running with partial trust is treated as transparent.  
  
 These rules are the same whether a security-critical member is accessed directly by compiled code, or accessed by using reflection.  
  
 Application code that is run from the command line runs with full trust. As long as it is not marked as transparent, it can use reflection to access security-critical members. When the same code is run with partial trust (for example, in a sandboxed application domain) the assembly's trust level determines whether it can access security-critical code: If the assembly has a strong name and is installed in the global assembly cache, it is a trusted assembly and can call security-critical members. If it is not trusted, it becomes transparent even though it was not marked as transparent, and it cannot access security-critical members.  
  
 For more information about the security model in the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)], see [Security Changes](../../../docs/framework/security/security-changes.md).  
  
## Reflection and Transparency  
 Beginning with the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)], the common language runtime determines the transparency level of a type or member from several factors, including the trust level of the assembly and the trust level of the application domain. Reflection provides the <xref:System.Type.IsSecurityCritical%2A>, <xref:System.Type.IsSecuritySafeCritical%2A>, and <xref:System.Type.IsSecurityTransparent%2A> properties to enable you to discover the transparency level of a type. The following table shows the valid combinations of these properties.  
  
|Security level|IsSecurityCritical|IsSecuritySafeCritical|IsSecurityTransparent|  
|--------------------|------------------------|----------------------------|---------------------------|  
|Critical|`true`|`false`|`false`|  
|Safe-critical|`true`|`true`|`false`|  
|Transparent|`false`|`false`|`true`|  
  
 Using these properties is much simpler than examining the security annotations of an assembly and its types, checking the current trust level, and attempting to duplicate the runtime's rules. For example, the same type can be security-critical when it is run from the command line, or security-transparent when it is run in a sandboxed application domain.  
  
 There are similar properties on the <xref:System.Reflection.MethodBase>, <xref:System.Reflection.FieldInfo>, <xref:System.Reflection.Emit.TypeBuilder>, <xref:System.Reflection.Emit.MethodBuilder>, and <xref:System.Reflection.Emit.DynamicMethod> classes. (For other reflection and reflection emit abstractions, security attributes are applied to the associated methods; for example, in the case of properties they are applied to the property accessors.)  
  
<a name="accessingNormallyInaccessible"></a>   
## Accessing Members That Are Normally Inaccessible  
 To use reflection to invoke members that are inaccessible according to the accessibility rules of the common language runtime, your code must be granted one of two permissions:  
  
-   To allow code to invoke any nonpublic member:Your code must be granted <xref:System.Security.Permissions.ReflectionPermission> with the <xref:System.Security.Permissions.ReflectionPermissionFlag.MemberAccess?displayProperty=nameWithType> flag.  
  
    > [!NOTE]
    >  By default, security policy denies this permission to code that originates from the Internet. This permission should never be granted to code that originates from the Internet.  
  
-   To allow code to invoke any nonpublic member, as long as the grant set of the assembly that contains the invoked member is the same as, or a subset of, the grant set of the assembly that contains the invoking code: Your code must be granted <xref:System.Security.Permissions.ReflectionPermission> with the <xref:System.Security.Permissions.ReflectionPermissionFlag.RestrictedMemberAccess?displayProperty=nameWithType> flag.  
  
 For example, suppose you grant an application domain Internet permissions plus <xref:System.Security.Permissions.ReflectionPermission> with the <xref:System.Security.Permissions.ReflectionPermissionFlag.RestrictedMemberAccess?displayProperty=nameWithType> flag, and then run an Internet application with two assemblies, A and B.  
  
-   Assembly A can use reflection to access private members of assembly B, because the grant set of assembly B does not include any permissions that A has not been granted.  
  
-   Assembly A cannot use reflection to access private members of [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] assemblies such as mscorlib.dll, because mscorlib.dll is fully trusted and therefore has permissions that have not been granted to assembly A. A <xref:System.MemberAccessException> is thrown when code access security walks the stack at run time.  
  
## Serialization  
 For serialization, <xref:System.Security.Permissions.SecurityPermission> with the <xref:System.Security.Permissions.SecurityPermissionAttribute.SerializationFormatter%2A?displayProperty=nameWithType> flag provides the ability to get and set members of serializable types, regardless of accessibility. This permission enables code to discover and change the private state of an instance. (In addition to being granted the appropriate permissions, the type must be [marked](../../../docs/standard/attributes/applying-attributes.md) as serializable in metadata.)  
  
## Parameters of Type MethodInfo  
 Avoid writing public members that take <xref:System.Reflection.MethodInfo> parameters, especially for trusted code. Such members might be more vulnerable to malicious code. For example, consider a public member in highly trusted code that takes a <xref:System.Reflection.MethodInfo> parameter. Assume that the public member indirectly calls the <xref:System.Reflection.MethodBase.Invoke%2A> method on the supplied parameter. If the public member does not perform the necessary permission checks, the call to the <xref:System.Reflection.MethodBase.Invoke%2A> method will always succeed, because the security system determines that the caller is highly trusted. Even if malicious code does not have the permission to directly invoke the method, it can still do so indirectly by calling the public member.  
  
## Version Information  
  
-   Beginning with the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)], transparent code cannot use reflection to access security-critical members.  
  
-   The <xref:System.Security.Permissions.ReflectionPermissionFlag.RestrictedMemberAccess?displayProperty=nameWithType> flag is introduced in the [!INCLUDE[net_v20SP1_long](../../../includes/net-v20sp1-long-md.md)]. Earlier versions of the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] require the <xref:System.Security.Permissions.ReflectionPermissionFlag.MemberAccess?displayProperty=nameWithType> flag for code that uses reflection to access nonpublic members. This is a permission that should never be granted to partially trusted code.  
  
-   Beginning with the [!INCLUDE[dnprdnlong](../../../includes/dnprdnlong-md.md)], using reflection to obtain information about nonpublic types and members does not require any permissions. In earlier versions, <xref:System.Security.Permissions.ReflectionPermission> with the <xref:System.Security.Permissions.ReflectionPermissionFlag.TypeInformation?displayProperty=nameWithType> flag is required.  
  
## See Also  
 <xref:System.Security.Permissions.ReflectionPermissionFlag>  
 <xref:System.Security.Permissions.ReflectionPermission>  
 <xref:System.Security.Permissions.SecurityPermission>  
 [Security Changes](../../../docs/framework/security/security-changes.md)  
 [Code Access Security](../../../docs/framework/misc/code-access-security.md)  
 [Security Issues in Reflection Emit](../../../docs/framework/reflection-and-codedom/security-issues-in-reflection-emit.md)  
 [Viewing Type Information](../../../docs/framework/reflection-and-codedom/viewing-type-information.md)  
 [Applying Attributes](../../../docs/standard/attributes/applying-attributes.md)  
 [Accessing Custom Attributes](../../../docs/framework/reflection-and-codedom/accessing-custom-attributes.md)
