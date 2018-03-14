---
title: "Security-Transparent Code, Level 1"
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
  - "transparent"
  - "SecurityTreatAsSafeAttribute"
  - "SecurityTransparentAttribute"
  - "SecurityCriticalAttribute"
  - "security-transparent code"
  - "security [.NET Framework], security-transparent code"
ms.assetid: 5fd8f46d-3961-46a7-84af-2eb1f48e75cf
caps.latest.revision: 32
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Security-Transparent Code, Level 1
[!INCLUDE[net_security_note](../../../includes/net-security-note-md.md)]  
  
 Transparency helps developers write more secure .NET Framework libraries that expose functionality to partially trusted code. Level 1 transparency was introduced in the .NET Framework version 2.0 and was primarily used only within Microsoft. Starting with the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)], you can use [level 2 transparency](../../../docs/framework/misc/security-transparent-code-level-2.md). However, level 1 transparency has been retained so that you can identify legacy code that must run with the earlier security rules.  
  
> [!IMPORTANT]
>  You should specify level 1 transparency for compatibility only; that is, specify level 1 only for code that was developed with the .NET Framework 3.5 or earlier that uses the <xref:System.Security.AllowPartiallyTrustedCallersAttribute> or does not use the transparency model. For example, use level 1 transparency for .NET Framework 2.0 assemblies that allow calls from partially trusted callers (APTCA). For code that is developed for the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)], always use level 2 transparency.  
  
 This topic contains the following sections:  
  
-   [The Level 1 Transparency Model](#the_level_1_transparency_model)  
  
-   [Transparency Attributes](#transparency_attributes)  
  
-   [Security Transparency Examples](#security_transparency_examples)  
  
<a name="the_level_1_transparency_model"></a>   
## The Level 1 Transparency Model  
 When you use Level 1 transparency, you are using a security model that separates code into security-transparent, security-safe-critical, and security-critical methods.  
  
 You can mark a whole assembly, some classes in an assembly, or some methods in a class as security-transparent. Security-transparent code cannot elevate privileges. This restriction has three consequences:  
  
-   Security-transparent code cannot perform <xref:System.Security.Permissions.SecurityAction.Assert> actions.  
  
-   Any link demand that would be satisfied by security-transparent code becomes a full demand.  
  
-   Any unsafe (unverifiable) code that must execute in security-transparent code causes a full demand for the <xref:System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode> security permission.  
  
 These rules are enforced during execution by the common language runtime (CLR). Security-transparent code passes all the security requirements of the code it calls back to its callers. Demands that flow through the security-transparent code cannot elevate privileges. If a low-trust application calls security-transparent code and causes a demand for high privilege, the demand will flow back to the low-trust code and fail. The security-transparent code cannot stop the demand because it cannot perform assert actions. The same security-transparent code called from full-trust code results in a successful demand.  
  
 Security-critical is the opposite of security-transparent. Security-critical code executes with full trust and can perform all privileged operations. Security-safe-critical code is privileged code that has been through an extensive security audit to confirm that it does not allow partially trusted callers to use resources they do not have permission to access.  
  
 You have to apply transparency explicitly. The majority of your code that handles data manipulation and logic can typically be marked as security-transparent, whereas the lesser amount of code that performs elevations of privileges is marked as security-critical or security-safe-critical.  
  
> [!IMPORTANT]
>  Level 1 transparency is limited to assembly scope; it is not enforced between assemblies. Level 1 transparency was primarily used within Microsoft for security audit purposes. Security-critical types and members within a level 1 assembly can be accessed by security-transparent code in other assemblies. It is important that you perform link demands for full trust in all your level 1 security-critical types and members. Security-safe-critical types and members must also confirm that callers have permissions for protected resources that are accessed by the type or member.  
  
 For backward compatibility with earlier versions of the .NET Framework, all members that are not annotated with transparency attributes are considered to be security-safe-critical. All types that are not annotated are considered to be transparent. There are no static analysis rules to validate transparency. Therefore, you may need to debug transparency errors at run time.  
  
<a name="transparency_attributes"></a>   
## Transparency Attributes  
 The following table describes the three attributes that you use to annotate your code for transparency.  
  
|Attribute|Description|  
|---------------|-----------------|  
|<xref:System.Security.SecurityTransparentAttribute>|Allowed only at the assembly level. Identifies all types and members in the assembly as security-transparent. The assembly cannot contain any security-critical code.|  
|<xref:System.Security.SecurityCriticalAttribute>|When used at the assembly level without the <xref:System.Security.SecurityCriticalAttribute.Scope%2A> property, identifies all code in the assembly as security-transparent by default, but indicates that the assembly may contain security-critical code.<br /><br /> When used at the class level, identifies the class or method as security-critical, but not the members of the class. To make all the members security-critical, set the <xref:System.Security.SecurityCriticalAttribute.Scope%2A> property to <xref:System.Security.SecurityCriticalScope.Everything>.<br /><br /> When used at the member level, the attribute applies only to that member.<br /><br /> The class or member identified as security-critical can perform elevations of privilege. **Important:**  In level 1 transparency, security-critical types and members are treated as security-safe-critical when they are called from outside the assembly. You should protect security-critical types and members with a link demand for full trust to avoid unauthorized elevation of privilege.|  
|<xref:System.Security.SecuritySafeCriticalAttribute>|Identifies security-critical code that can be accessed by security-transparent code in the assembly. Otherwise, security-transparent code cannot access private or internal security-critical members in the same assembly. Doing so would influence security-critical code and make unexpected elevations of privilege possible. Security-safe-critical code should undergo a rigorous security audit. **Note:**  Security-safe-critical types and members must validate the permissions of callers to determine whether the caller has authority to access protected resources.|  
  
 The <xref:System.Security.SecuritySafeCriticalAttribute> attribute enables security-transparent code to access security-critical members in the same assembly. Consider the security-transparent and security-critical code in your assembly as separated into two assemblies. The security-transparent code would not be able to see the private or internal members of the security-critical code. Additionally, the security-critical code is generally audited for access to its public interface. You would not expect a private or internal state to be accessible outside the assembly; you would want to keep the state isolated. The <xref:System.Security.SecuritySafeCriticalAttribute> attribute maintains the isolation of state between security-transparent and security-critical code while providing the ability to override the isolation when it is necessary. Security-transparent code cannot access private or internal security-critical code unless those members have been marked with <xref:System.Security.SecuritySafeCriticalAttribute>. Before applying the <xref:System.Security.SecuritySafeCriticalAttribute>, audit that member as if it were publicly exposed.  
  
### Assembly-wide Annotation  
 The following table describes the effects of using security attributes at the assembly level.  
  
|Assembly attribute|Assembly state|  
|------------------------|--------------------|  
|No attribute on a partially trusted assembly|All types and members are transparent.|  
|No attribute on a fully trusted assembly (in the global assembly cache or identified as full trust in the `AppDomain`)|All types are transparent and all members are security-safe-critical.|  
|`SecurityTransparent`|All types and members are transparent.|  
|`SecurityCritical(SecurityCriticalScope.Everything)`|All types and members are security-critical.|  
|`SecurityCritical`|All code defaults to transparent. However, individual types and members can have other attributes.|  
  
<a name="security_transparency_examples"></a>   
## Security Transparency Examples  
 To use the .NET Framework 2.0 transparency rules (level 1 transparency), use the following assembly annotation:  
  
```  
[assembly: SecurityRules(SecurityRuleSet.Level1)]  
```  
  
 If you want to make a whole assembly transparent to indicate that the assembly does not contain any critical code and does not elevate privileges in any way, you can explicitly add transparency to the assembly with the following attribute:  
  
```  
[assembly: SecurityTransparent]  
```  
  
 If you want to mix critical and transparent code in the same assembly, start by marking the assembly with the <xref:System.Security.SecurityCriticalAttribute> attribute to indicate that the assembly can contain critical code, as follows:  
  
```  
[assembly: SecurityCritical]  
```  
  
 If you want to perform security-critical actions, you must explicitly mark the code that will perform the critical action with another <xref:System.Security.SecurityCriticalAttribute> attribute, as shown in the following code example:  
  
```  
[assembly: SecurityCritical]  
Public class A  
{  
    [SecurityCritical]  
    private void Critical()  
    {  
        // critical  
    }  
  
    public int SomeProperty  
    {  
        get {/* transparent */ }  
        set {/* transparent */ }  
    }  
}  
public class B  
{      
    internal string SomeOtherProperty  
    {  
        get { /* transparent */ }  
        set { /* transparent */ }  
    }  
}  
```  
  
 The previous code is transparent except for the `Critical` method, which is explicitly marked as security-critical. Transparency is the default setting, even with the assembly-level <xref:System.Security.SecurityCriticalAttribute> attribute.  
  
## See Also  
 [Security-Transparent Code, Level 2](../../../docs/framework/misc/security-transparent-code-level-2.md)  
 [Security Changes](../../../docs/framework/security/security-changes.md)
