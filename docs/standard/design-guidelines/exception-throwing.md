---
title: "Exception Throwing"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "exceptions, throwing"
  - "explicitly throwing exceptions"
  - "throwing exceptions, design guidelines"
ms.assetid: 5388e02b-52f5-460e-a2b5-eeafe60eeebe
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Exception Throwing
Exception-throwing guidelines described in this section require a good definition of the meaning of execution failure. Execution failure occurs whenever a member cannot do what it was designed to do (what the member name implies). For example, if the `OpenFile` method cannot return an opened file handle to the caller, it would be considered an execution failure.  
  
 Most developers have become comfortable with using exceptions for usage errors such as division by zero or null references. In the Framework, exceptions are used for all error conditions, including execution errors.  
  
 **X DO NOT** return error codes.  
  
 Exceptions are the primary means of reporting errors in frameworks.  
  
 **✓ DO** report execution failures by throwing exceptions.  
  
 **✓ CONSIDER** terminating the process by calling `System.Environment.FailFast` (.NET Framework 2.0 feature) instead of throwing an exception if your code encounters a situation where it is unsafe for further execution.  
  
 **X DO NOT** use exceptions for the normal flow of control, if possible.  
  
 Except for system failures and operations with potential race conditions, framework designers should design APIs so users can write code that does not throw exceptions. For example, you can provide a way to check preconditions before calling a member so users can write code that does not throw exceptions.  
  
 The member used to check preconditions of another member is often referred to as a tester, and the member that actually does the work is called a doer.  
  
 There are cases when the Tester-Doer Pattern can have an unacceptable performance overhead. In such cases, the so-called Try-Parse Pattern should be considered (see [Exceptions and Performance](../../../docs/standard/design-guidelines/exceptions-and-performance.md) for more information).  
  
 **✓ CONSIDER** the performance implications of throwing exceptions. Throw rates above 100 per second are likely to noticeably impact the performance of most applications.  
  
 **✓ DO** document all exceptions thrown by publicly callable members because of a violation of the member contract (rather than a system failure) and treat them as part of your contract.  
  
 Exceptions that are a part of the contract should not change from one version to the next (i.e., exception type should not change, and new exceptions should not be added).  
  
 **X DO NOT** have public members that can either throw or not based on some option.  
  
 **X DO NOT** have public members that return exceptions as the return value or an `out` parameter.  
  
 Returning exceptions from public APIs instead of throwing them defeats many of the benefits of exception-based error reporting.  
  
 **✓ CONSIDER** using exception builder methods.  
  
 It is common to throw the same exception from different places. To avoid code bloat, use helper methods that create exceptions and initialize their properties.  
  
 Also, members that throw exceptions are not getting inlined. Moving the throw statement inside the builder might allow the member to be inlined.  
  
 **X DO NOT** throw exceptions from exception filter blocks.  
  
 When an exception filter raises an exception, the exception is caught by the CLR, and the filter returns false. This behavior is indistinguishable from the filter executing and returning false explicitly and is therefore very difficult to debug.  
  
 **X AVOID** explicitly throwing exceptions from finally blocks. Implicitly thrown exceptions resulting from calling methods that throw are acceptable.  
  
 *Portions © 2005, 2009 Microsoft Corporation. All rights reserved.*  
  
 *Reprinted by permission of Pearson Education, Inc. from [Framework Design Guidelines: Conventions, Idioms, and Patterns for Reusable .NET Libraries, 2nd Edition](https://www.informit.com/store/framework-design-guidelines-conventions-idioms-and-9780321545619) by Krzysztof Cwalina and Brad Abrams, published Oct 22, 2008 by Addison-Wesley Professional as part of the Microsoft Windows Development Series.*  
  
## See Also  
 [Framework Design Guidelines](../../../docs/standard/design-guidelines/index.md)  
 [Design Guidelines for Exceptions](../../../docs/standard/design-guidelines/exceptions.md)
