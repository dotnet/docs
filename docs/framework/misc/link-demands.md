---
title: "Link Demands"
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
  - "security [.NET Framework], demands"
  - "demanded permissions"
  - "permissions [.NET Framework], demands"
  - "granting permissions, demands"
  - "code access security, demands"
  - "user demands for permission"
  - "caller security checks"
  - "link demands"
ms.assetid: a33fd5f9-2de9-4653-a4f0-d9df25082c4d
caps.latest.revision: 18
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Link Demands
[!INCLUDE[net_security_note](../../../includes/net-security-note-md.md)]  
  
 A link demand causes a security check during just-in-time compilation and checks only the immediate calling assembly of your code. Linking occurs when your code is bound to a type reference, including function pointer references and method calls. If the calling assembly does not have sufficient permission to link to your code, the link is not allowed and a runtime exception is thrown when the code is loaded and run. Link demands can be overridden in classes that inherit from your code.  
  
 Note that a full stack walk is not performed with this type of demand and that your code is still susceptible to luring attacks. For example, if a method in assembly A is protected by a link demand, a direct caller in assembly B is evaluated based on the permissions of Assembly B.  However, the link demand will not evaluate a method in assembly C if it indirectly calls the method in assembly A using the method in assembly B. The link demand specifies only the permissions direct callers in the immediate calling assembly must have to link to your code. It does not specify the permissions all callers must have to run your code.  
  
 The <xref:System.Security.CodeAccessPermission.Assert%2A>, <xref:System.Security.CodeAccessPermission.Deny%2A>, and <xref:System.Security.CodeAccessPermission.PermitOnly%2A> stack walk modifiers do not affect the evaluation of link demands.  Because link demands do not perform a stack walk, the stack walk modifiers have no effect on link demands.  
  
 If a method protected by a link demand is accessed through [Reflection](../../../docs/framework/reflection-and-codedom/reflection.md), then a link demand checks the immediate caller of the code accessed through reflection. This is true both for method discovery and for method invocation performed using reflection. For example, suppose code uses reflection to return a <xref:System.Reflection.MethodInfo> object representing a method protected by a link demand and then passes that **MethodInfo** object to some other code that uses the object to invoke the original method. In this case the link demand check occurs twice: once for the code that returns the **MethodInfo** object and once for the code that invokes it.  
  
> [!NOTE]
>  A link demand performed on a static class constructor does not protect the constructor because static constructors are called by the system, outside the application's code execution path. As a result, when a link demand is applied to an entire class, it cannot protect access to a static constructor, although it does protect the rest of the class.  
  
 The following code fragment declaratively specifies that any code linking to the `ReadData` method must have the `CustomPermission` permission. This permission is a hypothetical custom permission and does not exist in the .NET Framework. The demand is made by passing a **SecurityAction.LinkDemand** flag to the `CustomPermissionAttribute`.  
  
```vb  
<CustomPermissionAttribute(SecurityAction.LinkDemand)> _  
Public Shared Function ReadData() As String  
    ' Access a custom resource.  
End Function    
```  
  
```csharp  
[CustomPermissionAttribute(SecurityAction.LinkDemand)]  
public static string ReadData()  
{  
    // Access a custom resource.  
}  
```  
  
## See Also  
 [Attributes](../../../docs/standard/attributes/index.md)  
 [Code Access Security](../../../docs/framework/misc/code-access-security.md)
