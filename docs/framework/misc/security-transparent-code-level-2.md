---
title: "Security-Transparent Code, Level 2"
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
  - "transparency"
  - "level 2 transparency"
  - "security-transparent code"
  - "security-critical code"
ms.assetid: 4d05610a-0da6-4f08-acea-d54c9d6143c0
caps.latest.revision: 37
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Security-Transparent Code, Level 2
<a name="top"></a>
[!INCLUDE[net_security_note](../../../includes/net-security-note-md.md)]  
  
 Level 2 transparency was introduced in the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)]. The three tenets of this model are transparent code, security-safe-critical code, and security-critical code.  
  
-   Transparent code, including code that is running as full trust, can call other transparent code or security-safe-critical code only. It can only perform actions allowed by the domain’s partial trust permission set (if one exists). Transparent code cannot do the following:  
  
    -   Perform an <xref:System.Security.CodeAccessPermission.Assert%2A> or elevation of privilege.  
  
    -   Contain unsafe or unverifiable code.  
  
    -   Directly call critical code.  
  
    -   Call native code or code with the <xref:System.Security.SuppressUnmanagedCodeSecurityAttribute> attribute.  
  
    -   Call a member that is protected by a <xref:System.Security.Permissions.SecurityAction.LinkDemand>.  
  
    -   Inherit from critical types.  
  
     In addition, transparent methods cannot override critical virtual methods or implement critical interface methods.  
  
-   Safe-critical code is fully trusted but is callable by transparent code. It exposes a limited surface area of full-trust code; correctness and security verifications happen in safe-critical code.  
  
-   Security-critical code can call any code and is fully trusted, but it cannot be called by transparent code.  
  
 This topic contains the following sections:  
  
-   [Usage Examples and Behaviors](#examples)  
  
-   [Override Patterns](#override)  
  
-   [Inheritance Rules](#inheritance)  
  
-   [Additional Information and Rules](#additional)  
  
<a name="examples"></a>   
## Usage Examples and Behaviors  
 To specify [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)] rules (level 2 transparency), use the following annotation for an assembly:  
  
```  
[assembly: SecurityRules(SecurityRuleSet.Level2)]  
```  
  
 To lock into the .NET Framework 2.0 rules (level 1 transparency), use the following annotation:  
  
```  
[assembly: SecurityRules(SecurityRuleSet.Level1)]  
```  
  
 If you do not annotate an assembly, the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)] rules are used by default. However, the recommended best practice is to use the <xref:System.Security.SecurityRulesAttribute> attribute instead of depending on the default.  
  
### Assembly-wide Annotation  
 The following rules apply to the use of attributes at the assembly level:  
  
-   No attributes: If you do not specify any attributes, the runtime interprets all code as security-critical, except where being security-critical violates an inheritance rule (for example, when overriding or implementing a transparent virtual or interface method). In those cases, the methods are safe-critical. Specifying no attribute causes the common language runtime to determine the transparency rules for you.  
  
-   `SecurityTransparent`: All code is transparent; the entire assembly will not do anything privileged or unsafe.  
  
-   `SecurityCritical`: All code that is introduced by types in this assembly is critical; all other code is transparent. This scenario is similar to not specifying any attributes; however, the common language runtime does not automatically determine the transparency rules. For example, if you override a virtual or abstract method or implement an interface method, by default, that method is transparent. You must explicitly annotate the method as `SecurityCritical` or `SecuritySafeCritical`; otherwise, a <xref:System.TypeLoadException> will be thrown at load time. This rule also applies when both the base class and the derived class are in the same assembly.  
  
-   `AllowPartiallyTrustedCallers` (level 2 only): All code defaults to transparent. However, individual types and members can have other attributes.  
  
 The following table compares the assembly level behavior for Level 2 with Level 1.  
  
|Assembly attribute|Level 2|Level 1|  
|------------------------|-------------|-------------|  
|No attribute on a partially trusted assembly|Types and members are by default transparent, but can be security-critical or security-safe-critical.|All types and members are transparent.|  
|No attribute|Specifying no attribute causes the common language runtime to determine the transparency rules for you. All types and members are security-critical, except where being security-critical violates an inheritance rule.|On a fully trusted assembly (in the global assembly cache or identified as full trust in the `AppDomain`) all types are transparent and all members are security-safe-critical.|  
|`SecurityTransparent`|All types and members are transparent.|All types and members are transparent.|  
|`SecurityCritical(SecurityCriticalScope.Everything)`|Not applicable.|All types and members are security-critical.|  
|`SecurityCritical`|All code that is introduced by types in this assembly is critical; all other code is transparent. If you override a virtual or abstract method or implement an interface method, you must explicitly annotate the method as `SecurityCritical` or `SecuritySafeCritical`.|All code defaults to transparent. However, individual types and members can have other attributes.|  
  
### Type and Member Annotation  
 The security attributes that are applied to a type also apply to the members that are introduced by the type. However, they do not apply to virtual or abstract overrides of the base class or interface implementations. The following rules apply to the use of attributes at the type and member level:  
  
-   `SecurityCritical`: The type or member is critical and can be called only by full-trust code. Methods that are introduced in a security-critical type are critical.  
  
    > [!IMPORTANT]
    >  Virtual and abstract methods that are introduced in base classes or interfaces, and overridden or implemented in a security-critical class are transparent by default. They must be identified as either `SecuritySafeCritical` or `SecurityCritical`.  
  
-   `SecuritySafeCritical`: The type or member is safe-critical. However, the type or member can be called from transparent (partially trusted) code and is as capable as any other critical code. The code must be audited for security.  
  
 [Back to top](#top)  
  
<a name="override"></a>   
## Override Patterns  
 The following table shows the method overrides allowed for level 2 transparency.  
  
|Base virtual/interface member|Override/interface|  
|------------------------------------|-------------------------|  
|`Transparent`|`Transparent`|  
|`Transparent`|`SafeCritical`|  
|`SafeCritical`|`Transparent`|  
|`SafeCritical`|`SafeCritical`|  
|`Critical`|`Critical`|  
  
 [Back to top](#top)  
  
<a name="inheritance"></a>   
## Inheritance Rules  
 In this section, the following order is assigned to `Transparent`, `Critical`, and `SafeCritical` code based on access and capabilities:  
  
 `Transparent` < `SafeCritical` < `Critical`  
  
-   Rules for types: Going from left to right, access becomes more restrictive. Derived types must be at least as restrictive as the base type.  
  
-   Rules for methods: Derived methods cannot change accessibility from the base method. For default behavior, all derived methods that are not annotated are `Transparent`. Derivatives of critical types cause an exception to be thrown if the overridden method is not explicitly annotated as `SecurityCritical`.  
  
 The following table shows the allowed type inheritance patterns.  
  
|Base class|Derived class can be|  
|----------------|--------------------------|  
|`Transparent`|`Transparent`|  
|`Transparent`|`SafeCritical`|  
|`Transparent`|`Critical`|  
|`SafeCritical`|`SafeCritical`|  
|`SafeCritical`|`Critical`|  
|`Critical`|`Critical`|  
  
 The following table shows the disallowed type inheritance patterns.  
  
|Base class|Derived class cannot be|  
|----------------|-----------------------------|  
|`SafeCritical`|`Transparent`|  
|`Critical`|`Transparent`|  
|`Critical`|`SafeCritical`|  
  
 The following table shows the allowed method inheritance patterns.  
  
|Base method|Derived method can be|  
|-----------------|---------------------------|  
|`Transparent`|`Transparent`|  
|`Transparent`|`SafeCritical`|  
|`SafeCritical`|`Transparent`|  
|`SafeCritical`|`SafeCritical`|  
|`Critical`|`Critical`|  
  
 The following table shows the disallowed method inheritance patterns.  
  
|Base method|Derived method cannot be|  
|-----------------|------------------------------|  
|`Transparent`|`Critical`|  
|`SafeCritical`|`Critical`|  
|`Critical`|`Transparent`|  
|`Critical`|`SafeCritical`|  
  
> [!NOTE]
>  These inheritance rules apply to level 2 types and members. Types in level 1 assemblies can inherit from level 2 security-critical types and members. Therefore, level 2 types and members must have separate inheritance demands for level 1 inheritors.  
  
 [Back to top](#top)  
  
<a name="additional"></a>   
## Additional Information and Rules  
  
### LinkDemand Support  
 The level 2 transparency model replaces the <xref:System.Security.Permissions.SecurityAction.LinkDemand> with the <xref:System.Security.SecurityCriticalAttribute> attribute. In legacy (level 1) code, a <xref:System.Security.Permissions.SecurityAction.LinkDemand> is automatically treated as a <xref:System.Security.Permissions.SecurityAction.Demand>.  
  
### Reflection  
 Invoking a critical method or reading a critical field triggers a demand for full trust (just as if you were invoking a private method or field). Therefore, full-trust code can invoke a critical method, whereas partial-trust code cannot.  
  
 The following properties have been added to the <xref:System.Reflection> namespace to determine whether the type, method, or field is `SecurityCritical`, `SecuritySafeCritical`, or `SecurityTransparent`:  <xref:System.Type.IsSecurityCritical%2A>, <xref:System.Reflection.MethodBase.IsSecuritySafeCritical%2A>, and <xref:System.Reflection.MethodBase.IsSecurityTransparent%2A>. Use these properties to determine transparency by using reflection instead of checking for the presence of the attribute. The transparency rules are complex, and checking for the attribute may not be sufficient.  
  
> [!NOTE]
>  A `SafeCritical` method returns `true` for both <xref:System.Type.IsSecurityCritical%2A> and <xref:System.Reflection.MethodBase.IsSecuritySafeCritical%2A>, because `SafeCritical` is indeed critical (it has the same capabilities as critical code, but it can be called from transparent code).  
  
 Dynamic methods inherit the transparency of the modules they are attached to; they do not inherit the transparency of the type (if they are attached to a type).  
  
### Skip Verification in Full Trust  
 You can skip verification for fully trusted transparent assemblies by setting the <xref:System.Security.SecurityRulesAttribute.SkipVerificationInFullTrust%2A> property to `true` in the <xref:System.Security.SecurityRulesAttribute> attribute:  
  
 `[assembly: SecurityRules(SecurityRuleSet.Level2, SkipVerificationInFullTrust = true)]`  
  
 The <xref:System.Security.SecurityRulesAttribute.SkipVerificationInFullTrust%2A> property is `false` by default, so the property must be set to `true` to skip verification. This should be done for optimization purposes only. You should ensure that the transparent code in the assembly is verifiable by using the `transparent` option in the [PEVerify tool](../../../docs/framework/tools/peverify-exe-peverify-tool.md).  
  
## See Also  
 [Security-Transparent Code, Level 1](../../../docs/framework/misc/security-transparent-code-level-1.md)  
 [Security Changes](../../../docs/framework/security/security-changes.md)
