---
title: "Security and Remoting Considerations"
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
  - "code security, remoting"
  - "remoting, security"
  - "security [.NET Framework], remoting"
  - "secure coding, remoting"
ms.assetid: 125d2ab8-55a4-4e5f-af36-a7d401a37ab0
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Security and Remoting Considerations
Remoting allows you to set up transparent calling between application domains, processes, or computers. However, the code access security stack walk cannot cross process or machine boundaries (it does apply between application domains of the same process).  
  
 Any class that is remotable (derived from a <xref:System.MarshalByRefObject> class) needs to take responsibility for security. Either the code should be used only in closed environments where the calling code can be implicitly trusted, or remoting calls should be designed so that they do not subject protected code to outside entry that could be used maliciously.  
  
 Generally, you should never expose methods, properties, or events that are protected by declarative [LinkDemand](../../../docs/framework/misc/link-demands.md) and <xref:System.Security.Permissions.SecurityAction.InheritanceDemand> security checks. With remoting, these checks are not enforced. Other security checks, such as <xref:System.Security.Permissions.SecurityAction.Demand>, [Assert](../../../docs/framework/misc/using-the-assert-method.md), and so on, work between application domains within a process but do not work in cross-process or cross-machine scenarios.  
  
## Protected objects  
 Some objects hold security state in themselves. These objects should not be passed to untrusted code, which would then acquire security authorization beyond its own permissions.  
  
 One example is creating a <xref:System.IO.FileStream> object. The <xref:System.Security.Permissions.FileIOPermission> is demanded at the time of creation and, if it succeeds, the file object is returned. However, if this object reference is passed to code without file permissions, the object will be able to read and write to this particular file.  
  
 The simplest defense for such an object is to demand the same **FileIOPermission** of any code that seeks to get the object reference through a public API element.  
  
## Application domain crossing issues  
 To isolate code in managed hosting environments, it is common to generate multiple child application domains with explicit policy reducing the permission levels for various assemblies. However, the policy for those assemblies remains unchanged in the default application domain. If one of the child application domains can force the default application domain to load an assembly, the effect of code isolation is lost and types in the forcibly loaded assembly will be able to run code at a higher level of trust.  
  
 An application domain can force another application domain to load an assembly and run code contained therein by calling a proxy to an object hosted in the other application domain. To obtain a cross-application-domain proxy, the application domain hosting the object must distribute one through a method call parameter or return value. Or, if the application domain was just created, the creator has a proxy to the <xref:System.AppDomain> object by default. Thus, to avoid breaking code isolation, an application domain with a higher level of trust should not distribute references to marshaled-by-reference objects (instances of classes derived from <xref:System.MarshalByRefObject>) in its domain to application domains with lower levels of trust.  
  
 Usually, the default application domain creates the child application domains with a control object in each one. The control object manages the new application domain and occasionally takes orders from the default application domain, but it cannot actually contact the domain directly. Occasionally, the default application domain calls its proxy to the control object. However, there might be cases in which it is necessary for the control object to call back to the default application domain. In these cases, the default application domain passes a marshal-by-reference callback object to the constructor of the control object. It is the responsibility of the control object to protect this proxy. If the control object were to place the proxy on a public static field of a public class, or otherwise publicly expose the proxy, this would open up a dangerous mechanism for other code to call back into the default application domain. For this reason, control objects are always implicitly trusted to keep the proxy private.  
  
## See Also  
 [Secure Coding Guidelines](../../../docs/standard/security/secure-coding-guidelines.md)
