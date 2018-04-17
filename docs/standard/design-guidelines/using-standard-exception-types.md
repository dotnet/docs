---
title: "Using Standard Exception Types"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "throwing exceptions, standard types"
  - "catching exceptions"
  - "exceptions, catching"
  - "exceptions, throwing"
ms.assetid: ab22ce03-78f9-4dca-8824-c7ed3bdccc27
caps.latest.revision: 17
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Using Standard Exception Types
This section describes the standard exceptions provided by the Framework and the details of their usage. The list is by no means exhaustive. Please refer to the .NET Framework reference documentation for usage of other Framework exception types.  
  
## Exception and SystemException  
 **X DO NOT** throw <xref:System.Exception?displayProperty=nameWithType> or <xref:System.SystemException?displayProperty=nameWithType>.  
  
 **X DO NOT** catch `System.Exception` or `System.SystemException` in framework code, unless you intend to rethrow.  
  
 **X AVOID** catching `System.Exception` or `System.SystemException`, except in top-level exception handlers.  
  
## ApplicationException  
 **X DO NOT** throw or derive from <xref:System.ApplicationException>.  
  
## InvalidOperationException  
 **✓ DO** throw an <xref:System.InvalidOperationException> if the object is in an inappropriate state.  
  
## ArgumentException, ArgumentNullException, and ArgumentOutOfRangeException  
 **✓ DO** throw <xref:System.ArgumentException> or one of its subtypes if bad arguments are passed to a member. Prefer the most derived exception type, if applicable.  
  
 **✓ DO** set the `ParamName` property when throwing one of the subclasses of `ArgumentException`.  
  
 This property represents the name of the parameter that caused the exception to be thrown. Note that the property can be set using one of the constructor overloads.  
  
 **✓ DO** use `value` for the name of the implicit value parameter of property setters.  
  
## NullReferenceException, IndexOutOfRangeException, and AccessViolationException  
 **X DO NOT** allow publicly callable APIs to explicitly or implicitly throw <xref:System.NullReferenceException>, <xref:System.AccessViolationException>, or <xref:System.IndexOutOfRangeException>. These exceptions are reserved and thrown by the execution engine and in most cases indicate a bug.  
  
 Do argument checking to avoid throwing these exceptions. Throwing these exceptions exposes implementation details of your method that might change over time.  
  
## StackOverflowException  
 **X DO NOT** explicitly throw <xref:System.StackOverflowException>. The exception should be explicitly thrown only by the CLR.  
  
 **X DO NOT** catch `StackOverflowException`.  
  
 It is almost impossible to write managed code that remains consistent in the presence of arbitrary stack overflows. The unmanaged parts of the CLR remain consistent by using probes to move stack overflows to well-defined places rather than by backing out from arbitrary stack overflows.  
  
## OutOfMemoryException  
 **X DO NOT** explicitly throw <xref:System.OutOfMemoryException>. This exception is to be thrown only by the CLR infrastructure.  
  
## ComException, SEHException, and ExecutionEngineException  
 **X DO NOT** explicitly throw <xref:System.Runtime.InteropServices.COMException>,  <xref:System.ExecutionEngineException>, and <xref:System.Runtime.InteropServices.SEHException>. These exceptions are to be thrown only by the CLR infrastructure.  
  
 *Portions © 2005, 2009 Microsoft Corporation. All rights reserved.*  
  
 *Reprinted by permission of Pearson Education, Inc. from [Framework Design Guidelines: Conventions, Idioms, and Patterns for Reusable .NET Libraries, 2nd Edition](https://www.informit.com/store/framework-design-guidelines-conventions-idioms-and-9780321545619) by Krzysztof Cwalina and Brad Abrams, published Oct 22, 2008 by Addison-Wesley Professional as part of the Microsoft Windows Development Series.*  
  
## See Also  
 [Framework Design Guidelines](../../../docs/standard/design-guidelines/index.md)  
 [Design Guidelines for Exceptions](../../../docs/standard/design-guidelines/exceptions.md)
