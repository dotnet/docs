---
title: "Mitigation: New 64-bit JIT Compiler"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-bcl"
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "JIT compiler, 64-bit"
  - "JIT compilation, 64-bit"
  - "RyuJIT compiler"
ms.assetid: 0332dabc-72c5-4bdc-8975-20d717802b17
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Mitigation: New 64-bit JIT Compiler
Starting with the .NET Framework 4.6, the runtime includes a new 64-bit JIT compiler for just-in-time compilation. This change does not affect compilation with the  32-bit JIT compiler.  
  
## Unexpected behavior or exceptions  
 In some cases, compilation with the new 64-bit JIT compiler results in a runtime exception or in behavior that is not observed when executing code compiled by the older 64-bit JIT compiler. The known differences include the following:  
  
> [!IMPORTANT]
>  All of these known issues have been addressed in the new 64-bit compiler released with the .NET Framework 4.6.2. Most have also been addressed in service releases of the .NET Framework 4.6 and 4.6.1 that are included with Windows Update. You can eliminate these issues by ensuring that your version of Windows is up to date, or by upgrading to the .NET Framework 4.6.2.  
  
-   Under certain conditions, an unboxing operation may throw a <xref:System.NullReferenceException> in Release builds with optimization turned on.  
  
-   In some cases, execution of production code in a large method body may throw a <xref:System.StackOverflowException>.  
  
-   Under certain conditions, structures passed to a method are treated as reference types rather than value types in Release builds. One of the manifestations of this issue is that the individual items in a collection appear in an unexpected order.  
  
-   Under certain conditions, the comparison of <xref:System.UInt16> values with their high bit set is incorrect if optimization is enabled.  
  
-   Under certain conditions, particularly when initializing array values, memory initialization by the <xref:System.Reflection.Emit.OpCodes.Initblk?displayProperty=nameWithType> IL instruction may initialize memory with an incorrect value. This can result either in an unhandled exception or incorrect output.  
  
-   Under certain rare conditions, a conditional bit test can return the incorrect <xref:System.Boolean> value or throw an exception if compiler optimizations are enabled.  
  
-   Under certain conditions, if an `if` statement is used to test for a condition before entering  a `try` block and in the exit from the `try` block, and the same condition is evaluated in the `catch` or `finally` block, the new 64-bit JIT compiler removes the `if` condition from the `catch` or `finally` block when it optimizes code. As a result, code inside the `if` statement in the `catch` or `finally` block is executed unconditionally.  
  
<a name="General"></a>   
## Mitigation of known issues  
 If you encounter the issues listed above, you can address them by doing any of the following:  
  
-   Upgrade to the .NET Framework 4.6.2. The new 64-bit compiler included with the .NET Framework 4.6.2 addresses each of these known issues.  
  
-   Ensure that your version of Windows is up to date by running Windows Update. Service updates to the .NET Framework 4.6 and 4.6.1 address each of these issues except the <xref:System.NullReferenceException> in an unboxing operation.  
  
-   Compile with the older 64-bit JIT compiler. See the [Mitigation of other issues](#Other) section for more information on how to do this.  
  
<a name="Other"></a>   
## Mitigation of other issues  
 If you encounter any other difference in behavior between code compiled with the older 64-bit compiler and the new 64-bit JIT compiler, or between the debug and release versions of your app that are both compiled with the new 64-bit JIT compiler, you can do the following to compile your app with the older 64-bit JIT compiler:  
  
-   On a per-application basis, you can add the [\<useLegacyJit>](../../../docs/framework/configure-apps/file-schema/runtime/uselegacyjit-element.md) element to your application's configuration file. The following disables compilation with the new 64-bit JIT compiler and instead uses the legacy 64-bit JIT compiler.  
  
    ```xml  
    <?xml version ="1.0"?>  
    <configuration>  
        <runtime>  
           <useLegacyJit enabled="1" />  
        </runtime>  
    </configuration>  
    ```  
  
-   On a per-user basis, you can add a `REG_DWORD` value named `useLegacyJit` to the `HKEY_CURRENT_USER\SOFTWARE\Microsoft\.NETFramework` key of the registry. A value of 1 enables the legacy 64-bit JIT compiler; a value of 0 disables it and enables the new 64-bit JIT compiler.  
  
-   On a per-machine basis, you can add a `REG_DWORD` value named `useLegacyJit` to the `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\.NETFramework` key of the registry. A value of 1 enables the legacy 64-bit JIT compiler; a value of 0 disables it and enables the new 64-bit JIT compiler.  
  
 You can also let us know about the problem by reporting a bug on [Microsoft Connect](https://connect.microsoft.com/VisualStudio).  
  
## See Also  
 [Runtime Changes](../../../docs/framework/migration-guide/runtime-changes-in-the-net-framework-4-6.md)  
 [\<useLegacyJit> Element](../../../docs/framework/configure-apps/file-schema/runtime/uselegacyjit-element.md)
