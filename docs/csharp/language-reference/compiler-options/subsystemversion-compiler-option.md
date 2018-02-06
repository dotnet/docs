---
title: "-subsystemversion (C# Compiler Options)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: a99fce81-9d92-4813-9874-bee777041445
caps.latest.revision: 19
author: "BillWagner"
ms.author: "wiwagn"
---
# -subsystemversion (C# Compiler Options)
Specifies the minimum version of the subsystem on which the generated executable file can run, thereby determining the versions of Windows on which the executable file can run. Most commonly, this option ensures that the executable file can leverage particular security features that aren’t available with older versions of Windows.  
  
> [!NOTE]
>  To specify the subsystem itself, use the [-target](../../../csharp/language-reference/compiler-options/target-compiler-option.md) compiler option.  
  
## Syntax  
  
```console  
-subsystemversion:major.minor  
```  
  
#### Parameters  
 `major.minor`  
 The minimum required version of the subsystem, as expressed in a dot notation for major and minor versions. For example, you can specify that an application can't run on an operating system that's older than Windows 7 if you set the value of this option to 6.01, as the table later in this topic describes. You must specify the values for `major` and `minor` as integers.  
  
 Leading zeroes in the `minor` version don't change the version, but trailing zeroes do. For example, 6.1 and 6.01 refer to the same version, but 6.10 refers to a different version. We recommend expressing the minor version as two digits to avoid confusion.  
  
## Remarks  
 The following table lists common subsystem versions of Windows.  
  
|Windows version|Subsystem version|  
|---------------------|-----------------------|  
|Windows 2000|5.00|  
|Windows XP|5.01|  
|Windows Server 2003|5.02|  
|Windows Vista|6.00|  
|Windows 7|6.01|  
|Windows Server 2008|6.01|  
|[!INCLUDE[win8](~/includes/win8-md.md)]|6.02|  
  
## Default values  
 The default value of the **-subsystemversion** compiler option depends on the conditions in the following list:  
  
-   The default value is 6.02 if any compiler option in the following list is set:  
  
    -   [-target:appcontainerexe](../../../csharp/language-reference/compiler-options/target-appcontainerexe-compiler-option.md)  
  
    -   [-target:winmdobj](../../../csharp/language-reference/compiler-options/target-winmdobj-compiler-option.md)  
  
    -   [-platform:arm](../../../csharp/language-reference/compiler-options/platform-compiler-option.md)  
  
-   The default value is 6.00 if you're using MSBuild, you're targeting [!INCLUDE[net_v45](~/includes/net-v45-md.md)], and you haven't set any of the compiler options that were specified earlier in this list.  
  
-   The default value is 4.00 if none of the previous conditions is true.  
  
## Setting this option  
 To set the **-subsystemversion** compiler option in Visual Studio, you must open the .csproj file and specify a value for the `SubsystemVersion` property in the MSBuild XML. You can't set this option in the Visual Studio IDE. For more information, see "Default values" earlier in this topic or [Common MSBuild Project Properties](/visualstudio/msbuild/common-msbuild-project-properties).  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)
