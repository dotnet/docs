---
title: "Securing Wrapper Code"
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
  - "security [.NET Framework], wrapper code"
  - "wrapper code, securing"
  - "secure coding, wrapper code"
  - "code security, wrapper code"
ms.assetid: 1df6c516-5bba-48bd-b450-1070e04b7389
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Securing Wrapper Code
[!INCLUDE[net_security_note](../../../includes/net-security-note-md.md)]  
  
 Wrapper code, especially where the wrapper has higher trust than code that uses it, can open a unique set of security weaknesses. Anything done on behalf of a caller, where the caller's limited permissions are not included in the appropriate security check, is a potential weakness to be exploited.  
  
 Never enable something through the wrapper that the caller could not do itself. This is a special danger when doing something that involves a limited security check, as opposed to a full stack walk demand. When single-level checks are involved, interposing the wrapper code between the real caller and the API element in question can easily cause the security check to succeed when it should not, thereby weakening security.  
  
## Delegates  
 Delegate security differs between versions of the .NET Framework.  This section describes the different delegate behaviors and associated security considerations.  
  
### In version 1.0 and 1.1 of the .NET Framework  
 Version 1.0 and 1.1 of the .NET Framework perform the following security actions against a delegate creator and a delegate caller.  
  
-   When a delegate is created, security link demands on the delegate target method are performed against the grant set of the delegate creator.  Failure to satisfy the security action results in a <xref:System.Security.SecurityException>.  
  
-   When the delegate is invoked, any existing security demands on the delegate caller are performed.  
  
 Whenever your code takes a <xref:System.Delegate> from less-trusted code that might call it, make sure that you are not enabling the less-trusted code to escalate its permissions. If you take a delegate and use it later, the code that created the delegate is not on the call stack and its permissions will not be tested if code in or under the delegate attempts a protected operation. If your code and the caller code have higher privileges than the creator, the creator can orchestrate the call path without being part of the call stack.  
  
### In version 2.0 and later versions of the .NET Framework  
 Unlike previous versions, version 2.0 and later versions of the .NET Framework performs security action against the delegate creator when the delegate is created and called.  
  
-   When a delegate is created, security link demands on the delegate target method are performed against the grant set of the delegate creator.  Failure to satisfy the security action results in a <xref:System.Security.SecurityException>.  
  
-   The delegate creator's grant set is also captured during delegate creation and stored with the delegate.  
  
-   When the delegate is invoked, the delegate creator's captured grant set is first evaluated against any demands in the current context if the delegate creator and caller belong to different assemblies.  Next, any existing security demands on the delegate caller are performed.  
  
## Link demands and wrappers  
 A special protection case with link demands has been strengthened in the security infrastructure, but it is still a source of possible weakness in your code.  
  
 If fully trusted code calls a property, event, or method protected by a [LinkDemand](../../../docs/framework/misc/link-demands.md), the call succeeds if the **LinkDemand** permission check for the caller is satisfied. Additionally, if the fully trusted code exposes a class that takes the name of a property and calls its **get** accessor using reflection, that call to the **get** accessor succeeds even though the user code does not have the right to access this property. This is because the **LinkDemand** checks only the immediate caller, which is the fully trusted code. In essence, the fully trusted code is making a privileged call on behalf of user code without making sure that the user code has the right to make that call.  
  
 To help prevent such security holes, the common language runtime extends the check into a full stack-walking demand on any indirect call to a method, constructor, property, or event protected by a **LinkDemand**. This protection incurs some performance costs and changes the semantics of the security check; the full stack-walk demand might fail where the faster, one-level check would have passed.  
  
## Assembly loading wrappers  
 Several methods used to load managed code, including <xref:System.Reflection.Assembly.Load%2A?displayProperty=nameWithType>, load assemblies with the evidence of the caller. If you wrap any of these methods, the security system could use your code's permission grant, instead of the permissions of the caller to your wrapper, to load the assemblies. You should not allow less-trusted code to load code that is granted higher permissions than those of the caller to your wrapper.  
  
 Any code that has full trust or significantly higher trust than a potential caller (including an Internet-permissions-level caller) could weaken security in this way. If your code has a public method that takes a byte array and passes it to **Assembly.Load**, thereby creating an assembly on the caller's behalf, it might break security.  
  
 This issue applies to the following API elements:  
  
-   <xref:System.AppDomain.DefineDynamicAssembly%2A?displayProperty=nameWithType>  
  
-   <xref:System.AppDomain.Load%2A?displayProperty=nameWithType>  
  
-   <xref:System.Reflection.Assembly.LoadFrom%2A?displayProperty=nameWithType>  
  
-   <xref:System.Reflection.Assembly.Load%2A?displayProperty=nameWithType>  
  
## Demand vs. LinkDemand  
 Declarative security offers two kinds of security checks that are similar but perform very different checks. You should understand both forms because the wrong choice can result in weak security or performance loss.  
  
 Declarative security offers the following security checks:  
  
-   <xref:System.Security.Permissions.SecurityAction.Demand> specifies the code access security stack walk. All callers on the stack must have the specified permission or identity to pass. **Demand** occurs on every call because the stack might contain different callers. If you call a method repeatedly, this security check occurs each time. **Demand** is good protection against luring attacks; unauthorized code trying to get through it will be detected.  
  
-   [LinkDemand](../../../docs/framework/misc/link-demands.md) happens at just-in-time (JIT) compilation time and checks only the immediate caller. This security check does not check the caller's caller. Once this check passes, there is no additional security overhead no matter how many times the caller might call. However, there is also no protection from luring attacks. With **LinkDemand**, any code that passes the test and can reference your code can potentially break security by allowing malicious code to call using the authorized code. Therefore, do not use **LinkDemand** unless all the possible weaknesses can be thoroughly avoided.  
  
    > [!NOTE]
    >  In the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)], link demands have been replaced by the <xref:System.Security.SecurityCriticalAttribute> attribute in <xref:System.Security.SecurityRuleSet.Level2> assemblies. The <xref:System.Security.SecurityCriticalAttribute> is equivalent to a link demand for full trust; however, it also affects inheritance rules. For more information about this change, see [Security-Transparent Code, Level 2](../../../docs/framework/misc/security-transparent-code-level-2.md).  
  
 The extra precautions required when using **LinkDemand** must be programmed individually; the security system can help with enforcement. Any mistake opens a security weakness. All authorized code that uses your code must be responsible for implementing additional security by doing the following:  
  
-   Restricting the calling code's access to the class or assembly.  
  
-   Placing the same security checks on the calling code that appear on the code being called and obligating its callers to do so. For example, if you write code that calls a method that is protected with a **LinkDemand** for the <xref:System.Security.Permissions.SecurityPermission> with the <xref:System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode> flag specified, your method should also make a **LinkDemand** (or **Demand**, which is stronger) for this permission. The exception is if your code uses the **LinkDemand**-protected method in a limited way that you decide is safe, given other security protection mechanisms (such as demands) in your code. In this exceptional case, the caller takes responsibility in weakening the security protection on the underlying code.  
  
-   Ensuring that your code's callers cannot trick your code into calling the protected code on their behalf. In other words, callers cannot force the authorized code to pass specific parameters to the protected code, or to get results back from it.  
  
### Interfaces and Link Demands  
 If a virtual method, property, or event with **LinkDemand** overrides a base class method, the base class method must also have the same **LinkDemand** for the overridden method in order to be effective. It is possible for malicious code to cast back to the base type and call the base class method. Also note that link demands can be added implicitly to assemblies that do not have the <xref:System.Security.AllowPartiallyTrustedCallersAttribute> assembly-level attribute.  
  
 It is a good practice to protect method implementations with link demands when interface methods also have link demands. Note the following about using link demands with interfaces:  
  
-   If you place a **LinkDemand** on a public method of a class that implements an interface method, the **LinkDemand** will not be enforced if you then cast to the interface and call the method. In this case, because you linked against the interface, only the **LinkDemand** on the interface is honored.  
  
 Review the following items for security issues:  
  
-   Explicit link demands on interface methods. Make sure these link demands offer the expected protection. Determine whether malicious code can use a cast to get around the link demands as described previously.  
  
-   Virtual methods with link demands applied.  
  
-   Types and the interfaces they implement. These should use link demands consistently.  
  
## See Also  
 [Secure Coding Guidelines](../../../docs/standard/security/secure-coding-guidelines.md)
