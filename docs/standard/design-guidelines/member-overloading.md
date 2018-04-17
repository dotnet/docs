---
title: "Member Overloading"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "default arguments"
  - "members [.NET Framework], overloaded"
  - "member design guidelines [.NET Framework], overloading"
  - "overloaded members"
  - "signatures, members"
ms.assetid: 964ba19e-8b94-4b5b-b1e3-5a0b531a0bb1
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Member Overloading
Member overloading means creating two or more members on the same type that differ only in the number or type of parameters but have the same name. For example, in the following, the `WriteLine` method is overloaded:  
  
```  
public static class Console {  
    public void WriteLine();  
    public void WriteLine(string value);  
    public void WriteLine(bool value);  
    ...  
}  
```  
  
 Because only methods, constructors, and indexed properties can have parameters, only those members can be overloaded.  
  
 Overloading is one of the most important techniques for improving usability, productivity, and readability of reusable libraries. Overloading on the number of parameters makes it possible to provide simpler versions of constructors and methods. Overloading on the parameter type makes it possible to use the same member name for members performing identical operations on a selected set of different types.  
  
 **✓ DO** try to use descriptive parameter names to indicate the default used by shorter overloads.  
  
 **X AVOID** arbitrarily varying parameter names in overloads. If a parameter in one overload represents the same input as a parameter in another overload, the parameters should have the same name.  
  
 **X AVOID** being inconsistent in the ordering of parameters in overloaded members. Parameters with the same name should appear in the same position in all overloads.  
  
 **✓ DO** make only the longest overload virtual (if extensibility is required). Shorter overloads should simply call through to a longer overload.  
  
 **X DO NOT** use `ref` or `out` modifiers to overload members.  
  
 Some languages cannot resolve calls to overloads like this. In addition, such overloads usually have completely different semantics and probably should not be overloads but two separate methods instead.  
  
 **X DO NOT** have overloads with parameters at the same position and similar types yet with different semantics.  
  
 **✓ DO**  allow `null` to be passed for optional arguments.  
  
 **✓ DO** use member overloading rather than defining members with default arguments.  
  
 Default arguments are not CLS compliant.  
  
 *Portions © 2005, 2009 Microsoft Corporation. All rights reserved.*  
  
 *Reprinted by permission of Pearson Education, Inc. from [Framework Design Guidelines: Conventions, Idioms, and Patterns for Reusable .NET Libraries, 2nd Edition](https://www.informit.com/store/framework-design-guidelines-conventions-idioms-and-9780321545619) by Krzysztof Cwalina and Brad Abrams, published Oct 22, 2008 by Addison-Wesley Professional as part of the Microsoft Windows Development Series.*  
  
## See Also  
 [Member Design Guidelines](../../../docs/standard/design-guidelines/member.md)  
 [Framework Design Guidelines](../../../docs/standard/design-guidelines/index.md)
