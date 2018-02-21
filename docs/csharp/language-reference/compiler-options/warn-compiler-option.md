---
title: "-warn (C# Compiler Options)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "/warn"
helpviewer_keywords: 
  - "warning level [C#]"
  - "/w compiler option [C#]"
  - "-w compiler option [C#]"
  - "-warn compiler option [C#]"
  - "/warn compiler option [C#]"
  - "w compiler option [C#]"
  - "warn compiler option [C#]"
ms.assetid: 5f80ff59-4991-4382-9f9a-77da18446e71
caps.latest.revision: 17
author: "BillWagner"
ms.author: "wiwagn"
---
# -warn (C# Compiler Options)
The **-warn** option specifies the warning level for the compiler to display.  
  
## Syntax  
  
```console  
-warn:option  
```  
  
## Arguments  
 `option`  
 The warning level you want displayed for the compilation: Lower numbers show only high severity warnings; higher numbers show more warnings. Valid values are 0-4:  
  
|Warning level|Meaning|  
|-------------------|-------------|  
|0|Turns off emission of all warning messages.|  
|1|Displays severe warning messages.|  
|2|Displays level 1 warnings plus certain, less-severe warnings, such as warnings about hiding class members.|  
|3|Displays level 2 warnings plus certain, less-severe warnings, such as warnings about expressions that always evaluate to `true` or `false`.|  
|4 (the default)|Displays all level 3 warnings plus informational warnings.|  
  
## Remarks  
 To get information about an error or warning, you can look up the error code in the Help Index. For other ways to get information about an error or warning, see [C# Compiler Errors](../../../csharp/language-reference/compiler-messages/index.md).  
  
 Use [-warnaserror](../../../csharp/language-reference/compiler-options/warnaserror-compiler-option.md) to treat all warnings as errors. Use [-nowarn](../../../csharp/language-reference/compiler-options/nowarn-compiler-option.md) to disable certain warnings.  
  
 **-w** is the short form of **-warn**.  
  
### To set this compiler option in the Visual Studio development environment  
  
1.  Open the project's **Properties** page.  
  
2.  Click the **Build** property page.  
  
3.  Modify the **Warning Level** property.  
  
 For information on how to set this compiler option programmatically, see <xref:VSLangProj80.CSharpProjectConfigurationProperties3.WarningLevel%2A>.  
  
## Example  
 Compile `in.cs` and have the compiler only display level 1 warnings:  
  
```console  
csc -warn:1 in.cs  
```  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)  
 [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)
