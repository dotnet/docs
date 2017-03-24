---
title: "COM Interoperability in .NET Framework Applications (Visual Basic) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "interoperability, COM and .NET framework objects"
  - "COM interop"
  - "shared components"
ms.assetid: f5a72143-c268-4dff-a019-974ad940e17d
caps.latest.revision: 15
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# COM Interoperability in .NET Framework Applications (Visual Basic)
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

When you want to use COM objects and .NET Framework objects in the same application, you need to address the differences in how the objects exist in memory. A .NET Framework object is located in managed memory—the memory controlled by the common language runtime—and may be moved by the runtime as needed. A COM object is located in unmanaged memory and is not expected to move to another memory location. [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] and the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] provide tools to control the interaction of these managed and unmanaged components. For more information about managed code, see [Common Language Runtime](../Topic/Common%20Language%20Runtime%20\(CLR\).md).  
  
 In addition to using COM objects in .NET applications, you may also want to use [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)] to develop objects accessible from unmanaged code through COM.  
  
 The links on this page provide details on the interactions between COM and .NET Framework objects.  
  
## Related Sections  
 [COM Interop](../../../visual-basic/programming-guide/com-interop/index.md)  
 Provides links to topics covering COM interoperability in Visual Basic, including COM objects, ActiveX controls, Win32 DLLs, managed objects, and inheritance of COM objects.  
  
 [COM Interop Wrapper Error](/visual-cpp/misc/com-interop-wrapper-error)  
 Describes the consequences and options if the project system cannot create a COM interoperability wrapper for a particular component.  
  
 [Interoperating with Unmanaged Code](../Topic/Interoperating%20with%20Unmanaged%20Code.md)  
 Briefly describes some of the interaction issues between managed and unmanaged code, and provides links for further study.  
  
 [COM Wrappers](../Topic/COM%20Wrappers.md)  
 Discusses runtime callable wrappers, which allow managed code to call COM methods, and COM callable wrappers, which allow COM clients to call .NET object methods.  
  
 [Advanced COM Interoperability](http://msdn.microsoft.com/en-us/3ada36e5-2390-4d70-b490-6ad8de92f2fb)  
 Provides links to topics covering COM interoperability with respect to wrappers, exceptions, inheritance, threading, events, conversions, and marshaling.  
  
 [Tlbimp.exe (Type Library Importer)](../Topic/Tlbimp.exe%20\(Type%20Library%20Importer\).md)  
 Discusses the tool you can use to convert the type definitions found within a COM type library into equivalent definitions in a common language runtime assembly.