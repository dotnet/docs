---
title: "64-bit Applications"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-bcl"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "applications [C++], 64-bit"
  - "64-bit applications [C++]"
  - "64-bit programming [C++]"
ms.assetid: fd4026bc-2c3d-4b27-86dc-ec5e96018181
caps.latest.revision: 53
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 64-bit Applications
When you compile an application, you can specify that it should run on a Windows 64-bit operating system either as a native application or under WOW64 (Windows 32-bit on Windows 64-bit). WOW64 is a compatibility environment that enables a 32-bit application to run on a 64-bit system. WOW64 is included in all 64-bit versions of the Windows operating system.  
  
## Running 32-bit vs. 64-bit Applications on Windows  
 All applications that are built on the .NET Framework 1.0 or 1.1 are treated as 32-bit applications on a 64-bit operating system and are always executed under WOW64 and the 32-bit common language runtime (CLR). 32-bit applications that are built on the [!INCLUDE[net_v40_long](../../includes/net-v40-long-md.md)] or later versions also run under WOW64 on 64-bit systems.  
  
 Visual Studio installs the 32-bit version of the CLR on an x86 computer, and both the 32-bit version and the appropriate 64-bit version of the CLR on a 64-bit Windows computer. (Because Visual Studio is a 32-bit application, when it is installed on a 64-bit system, it runs under WOW64.)  
  
> [!NOTE]
>  Because of the design of x86 emulation and the WOW64 subsystem for the Itanium processor family, applications are restricted to execution on one processor. These factors reduce the performance and scalability of 32-bit .NET Framework applications that run on Itanium-based systems. We recommend that you use the [!INCLUDE[net_v40_long](../../includes/net-v40-long-md.md)], which includes native 64-bit support for Itanium-based systems, for increased performance and scalability.  
  
 By default, when you run a 64-bit managed application on a 64-bit Windows operating system, you can create an object of no more than 2 gigabytes (GB). However, in the [!INCLUDE[net_v45](../../includes/net-v45-md.md)], you can increase this limit.  For more information, see the [\<gcAllowVeryLargeObjects> element](../../docs/framework/configure-apps/file-schema/runtime/gcallowverylargeobjects-element.md).  
  
 Many assemblies run identically on both the 32-bit CLR and the 64-bit CLR. However, some programs may behave differently, depending on the CLR, if they contain one or more of the following:  
  
-   Structures that contain members that change size depending on the platform (for example, any pointer type).  
  
-   Pointer arithmetic that includes constant sizes.  
  
-   Incorrect platform invoke or COM declarations that use `Int32` for handles instead of `IntPtr`.  
  
-   Code that casts `IntPtr` to `Int32`.  
  
 For more information about how to port a 32-bit application to run on the 64-bit CLR, see [Migrating 32-bit Managed Code to 64-bit](https://msdn.microsoft.com/library/ms973190.aspx).  
  
## General 64-Bit Programming Information  
 For general information about 64-bit programming, see the following documents:  
  
-   For more information about the 64-bit version of the CLR on a 64-bit Windows computer, see the [.NET Framework Developer Center](http://go.microsoft.com/fwlink/?LinkId=37079) on the MSDN website.  
  
-   In the [!INCLUDE[winsdkshort](../../includes/winsdkshort-md.md)] documentation, see [Programming Guide for 64-bit Windows](http://go.microsoft.com/fwlink/p/?LinkId=253512).  
  
-   For information about how to download a 64-bit version of the CLR, see [.NET Framework Developer Center Downloads](http://go.microsoft.com/fwlink/?LinkId=50953) on the MSDN website.  
  
-   For information about Visual Studio support for creating 64-bit applications, see [Visual Studio IDE 64-Bit Support](http://msdn.microsoft.com/library/b08ff3ad-c6fd-468f-94d5-01a61aab6833).  
  
## Compiler Support for Creating 64-Bit Applications  
 By default, when you use the .NET Framework to build an application on either a 32-bit or a 64-bit computer, the application will run on a 64-bit computer as a native application (that is, not under WOW64). The following table lists documents that explain how to use Visual Studio compilers to create 64-bit applications that will run as native, under WOW64, or both.  
  
|Compiler|Compiler option|  
|--------------|---------------------|  
|Visual Basic|[/platform (Visual Basic)](~/docs/visual-basic/reference/command-line-compiler/platform.md)|  
|Visual C#|[/platform (C# Compiler Options)](~/docs/csharp/language-reference/compiler-options/platform-compiler-option.md)|  
|Visual C++|You can create platform-agnostic, Microsoft intermediate language (MSIL) applications by using **/clr:safe**. For more information, see [/clr (Common Language Runtime Compilation)](/cpp/build/reference/clr-common-language-runtime-compilation).<br /><br /> Visual C++ includes a separate compiler for each 64-bit operating system. For more information about how to use Visual C++ to create native applications that run on a 64-bit Windows operating system, see [64-bit Programming](http://msdn.microsoft.com/library/h2k70f3s\(v=vs.80\)).|  
  
## Determining the Status of an .exe File or .dll File  
 To determine whether an .exe file or .dll file is meant to run only on a specific platform or under WOW64, use [CorFlags.exe (CorFlags Conversion Tool)](../../docs/framework/tools/corflags-exe-corflags-conversion-tool.md) with no options. You can also use CorFlags.exe to change the platform status of an .exe file or .dll file. The CLR header of a Visual Studio assembly has the major runtime version number set to 2 and the minor runtime version number set to 5. Applications that have the minor runtime version set to 0 are treated as legacy applications and are always executed under WOW64.  
  
 To programmatically query an .exe or .dll to see whether it is meant to run only on a specific platform or under WOW64, use the <xref:System.Reflection.Module.GetPEKind%2A?displayProperty=nameWithType> method.
