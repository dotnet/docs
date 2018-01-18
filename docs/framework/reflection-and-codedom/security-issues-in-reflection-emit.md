---
title: "Security Issues in Reflection Emit"
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
  - "partially trusted code"
  - "emitting dynamic assemblies, security"
  - "reflection emit, security"
  - "reflection emit, partial trust scenarios"
  - "partial trust,emitting dynamic methods"
  - "anonymously hosted dynamic methods [.NET Framework]"
  - "emitting dynamic assemblies,partial trust scenarios"
  - "dynamic assemblies, security"
ms.assetid: 0f8bf8fa-b993-478f-87ab-1a1a7976d298
caps.latest.revision: 18
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Security Issues in Reflection Emit
The [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] provides three ways to emit Microsoft intermediate language (MSIL), each with its own security issues:  
  
-   [Dynamic assemblies](#Dynamic_Assemblies)  
  
-   [Anonymously hosted dynamic methods](#Anonymously_Hosted_Dynamic_Methods)  
  
-   [Dynamic methods associated with existing assemblies](#Dynamic_Methods_Associated_with_Existing_Assemblies)  
  
 Regardless of the way you generate dynamic code, executing the generated code requires all the permissions that are required by the types and methods the generated code uses.  
  
> [!NOTE]
>  The permissions that are required for reflecting on code and emitting code have changed with succeeding releases of the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)]. See [Version Information](#Version_Information), later in this topic.  
  
<a name="Dynamic_Assemblies"></a>   
## Dynamic Assemblies  
 Dynamic assemblies are created by using overloads of the <xref:System.AppDomain.DefineDynamicAssembly%2A?displayProperty=nameWithType> method. Most overloads of this method are deprecated in the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)], because of the elimination of machine-wide security policy. (See [Security Changes](../../../docs/framework/security/security-changes.md).) The remaining overloads can be executed by any code, regardless of trust level. These overloads fall into two groups: those that specify a list of attributes to apply to the dynamic assembly when it is created, and those that do not. If you do not specify the transparency model for the assembly, by applying the <xref:System.Security.SecurityRulesAttribute> attribute when you create it, the transparency model is inherited from the emitting assembly.  
  
> [!NOTE]
>  Attributes that you apply to the dynamic assembly after it is created, by using the <xref:System.Reflection.Emit.AssemblyBuilder.SetCustomAttribute%2A> method, do not take effect until the assembly has been saved to disk and loaded into memory again.  
  
 Code in a dynamic assembly can access visible types and members in other assemblies.  
  
> [!NOTE]
>  Dynamic assemblies do not use the <xref:System.Security.Permissions.ReflectionPermissionFlag.MemberAccess?displayProperty=nameWithType> and <xref:System.Security.Permissions.ReflectionPermissionFlag.RestrictedMemberAccess?displayProperty=nameWithType> flags that allow dynamic methods to access nonpublic types and members.  
  
 Transient dynamic assemblies are created in memory and never saved to disk, so they require no file access permissions. Saving a dynamic assembly to disk requires <xref:System.Security.Permissions.FileIOPermission> with the appropriate flags.  
  
### Generating Dynamic Assemblies from Partially Trusted Code  
 Consider the conditions in which an assembly with Internet permissions can generate a transient dynamic assembly and execute its code:  
  
-   The dynamic assembly uses only public types and members of other assemblies.  
  
-   The permissions demanded by those types and members are included in the grant set of the partially trusted assembly.  
  
-   The assembly is not saved to disk.  
  
-   Debug symbols are not generated. (`Internet` and `LocalIntranet` permission sets do not include the necessary permissions.)  
  
<a name="Anonymously_Hosted_Dynamic_Methods"></a>   
## Anonymously Hosted Dynamic Methods  
 Anonymously hosted dynamic methods are created by using the two <xref:System.Reflection.Emit.DynamicMethod> constructors that do not specify an associated type or module, <xref:System.Reflection.Emit.DynamicMethod.%23ctor%28System.String%2CSystem.Type%2CSystem.Type%5B%5D%29> and <xref:System.Reflection.Emit.DynamicMethod.%23ctor%28System.String%2CSystem.Type%2CSystem.Type%5B%5D%2CSystem.Boolean%29>. These constructors place the dynamic methods in a system-provided, fully trusted, security-transparent assembly. No permissions are required to use these constructors or to emit code for the dynamic methods.  
  
 Instead, when an anonymously hosted dynamic method is created, the call stack is captured. When the method is constructed, security demands are made against the captured call stack.  
  
> [!NOTE]
>  Conceptually, demands are made during the construction of the method. That is, demands could be made as each MSIL instruction is emitted. In the current implementation, all demands are made when the <xref:System.Reflection.Emit.DynamicMethod.CreateDelegate%2A?displayProperty=nameWithType> method is called or when the just-in-time (JIT) compiler is invoked, if the method is invoked without calling <xref:System.Reflection.Emit.DynamicMethod.CreateDelegate%2A>.  
  
 If the application domain permits it, anonymously hosted dynamic methods can skip JIT visibility checks, subject to the following restriction: The nonpublic types and members accessed by an anonymously hosted dynamic method must be in assemblies whose grant sets are equal to, or subsets of, the grant set of the emitting call stack. This restricted ability to skip JIT visibility checks is enabled if the application domain grants <xref:System.Security.Permissions.ReflectionPermission> with the <xref:System.Security.Permissions.ReflectionPermissionFlag.RestrictedMemberAccess?displayProperty=nameWithType> flag.  
  
-   If your method uses only public types and members, no permissions are required during construction.  
  
-   If you specify that JIT visibility checks should be skipped, the demand that is made when the method is constructed includes <xref:System.Security.Permissions.ReflectionPermission> with the <xref:System.Security.Permissions.ReflectionPermissionFlag.RestrictedMemberAccess?displayProperty=nameWithType> flag and the grant set of the assembly that contains the nonpublic member that is being accessed.  
  
 Because the grant set of the nonpublic member is taken into consideration, partially trusted code that has been granted <xref:System.Security.Permissions.ReflectionPermissionFlag.RestrictedMemberAccess?displayProperty=nameWithType> cannot elevate its privileges by executing nonpublic members of trusted assemblies.  
  
 As with any other emitted code, executing the dynamic method requires whatever permissions are demanded by the methods the dynamic method uses.  
  
 The system assembly that hosts anonymously-hosted dynamic methods uses the <xref:System.Security.SecurityRuleSet.Level1?displayProperty=nameWithType> transparency model, which is the transparency model that was used in the .NET Framework before the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)].  
  
 For more information, see the <xref:System.Reflection.Emit.DynamicMethod> class.  
  
### Generating Anonymously Hosted Dynamic Methods from Partially Trusted Code  
 Consider the conditions in which an assembly with Internet permissions can generate an anonymously hosted dynamic method and execute it:  
  
-   The dynamic method uses only public types and members. If its grant set includes <xref:System.Security.Permissions.ReflectionPermissionFlag.RestrictedMemberAccess?displayProperty=nameWithType>, it can use nonpublic types and members of any assembly whose grant set is equal to, or a subset of, the grant set of the emitting assembly.  
  
-   The permissions that are required by all the types and members used by the dynamic method are included in the grant set of the partially trusted assembly.  
  
> [!NOTE]
>  Dynamic methods do not support debug symbols.  
  
<a name="Dynamic_Methods_Associated_with_Existing_Assemblies"></a>   
## Dynamic Methods Associated with Existing Assemblies  
 To associate a dynamic method with a type or module in an existing assembly, use any of the <xref:System.Reflection.Emit.DynamicMethod> constructors that specify the associated type or module. The permissions that are required to call these constructors vary, because associating a dynamic method with an existing type or module gives the dynamic method access to nonpublic types and members:  
  
-   A dynamic method that is associated with a type has access to all members of that type, even private members, and to all internal types and members in the assembly that contains the associated type.  
  
-   A dynamic method that is associated with a module has access to all the `internal` types and members (`Friend` in Visual Basic, `assembly` in common language runtime metadata) in the module.  
  
 In addition, you can use a constructor that specifies the ability to skip the visibility checks of the JIT compiler. Doing so gives your dynamic method access to all types and members in all assemblies, regardless of access level.  
  
 The permissions demanded by the constructor depend on how much access you decide to give your dynamic method:  
  
-   If your method uses only public types and members, and you associate it with your own type or your own module, no permissions are required.  
  
-   If you specify that JIT visibility checks should be skipped, the constructor demands <xref:System.Security.Permissions.ReflectionPermission> with the <xref:System.Security.Permissions.ReflectionPermissionFlag.MemberAccess?displayProperty=nameWithType> flag.  
  
-   If you associate the dynamic method with another type, even another type in your own assembly, the constructor demands <xref:System.Security.Permissions.ReflectionPermission> with the <xref:System.Security.Permissions.ReflectionPermissionFlag.MemberAccess?displayProperty=nameWithType> flag and <xref:System.Security.Permissions.SecurityPermission> with the <xref:System.Security.Permissions.SecurityPermissionFlag.ControlEvidence?displayProperty=nameWithType> flag.  
  
-   If you associate the dynamic method with a type or module in another assembly, the constructor demands two things: <xref:System.Security.Permissions.ReflectionPermission> with the <xref:System.Security.Permissions.ReflectionPermissionFlag.RestrictedMemberAccess?displayProperty=nameWithType> flag, and the grant set of the assembly that contains the other module. That is, your call stack must include all the permissions in the grant set of the target module, plus <xref:System.Security.Permissions.ReflectionPermissionFlag.RestrictedMemberAccess?displayProperty=nameWithType>.  
  
    > [!NOTE]
    >  For backward compatibility, if the demand for the target grant set plus <xref:System.Security.Permissions.ReflectionPermissionFlag.RestrictedMemberAccess?displayProperty=nameWithType> fails, the constructor demands <xref:System.Security.Permissions.SecurityPermission> with the <xref:System.Security.Permissions.SecurityPermissionFlag.ControlEvidence?displayProperty=nameWithType> flag.  
  
 Although the items in this list are described in terms of the grant set of the emitting assembly, remember that the demands are made against the full call stack, including the application domain boundary.  
  
 For more information, see the <xref:System.Reflection.Emit.DynamicMethod> class.  
  
### Generating Dynamic Methods from Partially Trusted Code  
  
> [!NOTE]
>  The recommended way to generate dynamic methods from partially trusted code is to use [anonymously hosted dynamic methods](#Anonymously_Hosted_Dynamic_Methods).  
  
 Consider the conditions in which an assembly with Internet permissions can generate a dynamic method and execute it:  
  
-   Either the dynamic method is associated with the module or type that emits it, or its grant set includes <xref:System.Security.Permissions.ReflectionPermissionFlag.RestrictedMemberAccess?displayProperty=nameWithType> and it is associated with a module in an assembly whose grant set is equal to, or a subset of, the grant set of the emitting assembly.  
  
-   The dynamic method uses only public types and members. If its grant set includes <xref:System.Security.Permissions.ReflectionPermissionFlag.RestrictedMemberAccess?displayProperty=nameWithType> and it is associated with a module in an assembly whose grant set is equal to, or a subset of, the grant set of the emitting assembly, it can use types and members marked `internal` (`Friend` in Visual Basic, `assembly` in common language runtime metadata) in the associated module.  
  
-   The permissions demanded by all the types and members used by the dynamic method are included in the grant set of the partially trusted assembly.  
  
-   The dynamic method does not skip JIT visibility checks.  
  
> [!NOTE]
>  Dynamic methods do not support debug symbols.  
  
<a name="Version_Information"></a>   
## Version Information  
 Starting with the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)], machine-wide security policy is eliminated and security transparency becomes the default enforcement mechanism. See [Security Changes](../../../docs/framework/security/security-changes.md).  
  
 Starting with the [!INCLUDE[net_v20SP1_long](../../../includes/net-v20sp1-long-md.md)], <xref:System.Security.Permissions.ReflectionPermission> with the <xref:System.Security.Permissions.ReflectionPermissionFlag.ReflectionEmit?displayProperty=nameWithType> flag is no longer required when emitting dynamic assemblies and dynamic methods. This flag is required in all earlier versions of the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)].  
  
> [!NOTE]
>  <xref:System.Security.Permissions.ReflectionPermission> with the <xref:System.Security.Permissions.ReflectionPermissionFlag.ReflectionEmit?displayProperty=nameWithType> flag is included by default in the `FullTrust` and `LocalIntranet` named permission sets, but not in the `Internet` permission set. Therefore, in earlier versions of the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)], a library can be used with Internet permissions only if it executes an <xref:System.Security.PermissionSet.Assert%2A> for <xref:System.Security.Permissions.ReflectionPermissionFlag.ReflectionEmit>. Such libraries require careful security review because coding errors could result in security holes. The [!INCLUDE[net_v20SP1_short](../../../includes/net-v20sp1-short-md.md)] allows code to be emitted in partial trust scenarios without issuing any security demands, because generating code is not inherently a privileged operation. That is, the generated code has no more permissions than the assembly that emits it. This allows libraries that emit code to be security transparent and removes the need to assert <xref:System.Security.Permissions.ReflectionPermissionFlag.ReflectionEmit>, which simplifies the task of writing a secure library.  
  
 In addition, the [!INCLUDE[net_v20SP1_short](../../../includes/net-v20sp1-short-md.md)] introduces the <xref:System.Security.Permissions.ReflectionPermissionFlag.RestrictedMemberAccess?displayProperty=nameWithType> flag for accessing nonpublic types and members from partially trusted dynamic methods. Earlier versions of the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] require the <xref:System.Security.Permissions.ReflectionPermissionFlag.MemberAccess?displayProperty=nameWithType> flag for dynamic methods that access nonpublic types and members; this is a permission that should never be granted to partially trusted code.  
  
 Finally, the [!INCLUDE[net_v20SP1_short](../../../includes/net-v20sp1-short-md.md)] introduces anonymously hosted methods.  
  
### Obtaining Information on Types and Members  
 Starting with the [!INCLUDE[dnprdnlong](../../../includes/dnprdnlong-md.md)], no permissions are required to obtain information about nonpublic types and members. Reflection is used to obtain information needed to emit dynamic methods. For example, <xref:System.Reflection.MethodInfo> objects are used to emit method calls. Earlier versions of the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] require <xref:System.Security.Permissions.ReflectionPermission> with the <xref:System.Security.Permissions.ReflectionPermissionFlag.TypeInformation?displayProperty=nameWithType> flag. For more information, see [Security Considerations for Reflection](../../../docs/framework/reflection-and-codedom/security-considerations-for-reflection.md).  
  
## See Also  
 [Security Considerations for Reflection](../../../docs/framework/reflection-and-codedom/security-considerations-for-reflection.md)  
 [Emitting Dynamic Methods and Assemblies](../../../docs/framework/reflection-and-codedom/emitting-dynamic-methods-and-assemblies.md)
