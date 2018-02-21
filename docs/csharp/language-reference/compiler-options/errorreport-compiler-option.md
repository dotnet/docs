---
title: "-errorreport (C# Compiler Options)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "/errorreport"
helpviewer_keywords: 
  - "-errorreport compiler option [C#]"
  - "errorreport compiler option [C#]"
  - "/errorreport compiler option [C#]"
ms.assetid: bd0e7493-b79d-4369-9c3f-ba26ebdfbedf
caps.latest.revision: 35
author: "BillWagner"
ms.author: "wiwagn"
---
# -errorreport (C# Compiler Options)
This option provides a convenient way to report a C# internal compiler error to Microsoft.  
  
> [!NOTE]
>  On Windows Vista and Windows Server 2008, the error reporting settings that you make for Visual Studio do not override the settings made through Windows Error Reporting (WER). WER settings always take precedence over Visual Studio error reporting settings.  
  
## Syntax  
  
```console  
-errorreport:{ none | prompt | queue | send }  
```  
  
## Arguments  
 **none**  
 Reports about internal compiler errors will not be collected or sent to Microsoft.  
  
 **prompt**  
 Prompts you to send a report when you receive an internal compiler error. **prompt** is the default when you compile an application in the development environment.  
  
 **queue**  
 Queues the error report. When you log on with administrative credentials, you can report any failures since the last time that you were logged on. You will not be prompted to send reports for failures more than once every three days. **queue** is the default when you compile an application at the command line.  
  
 **send**  
 Automatically sends reports of internal compiler errors to Microsoft. To enable this option, you must first agree to the Microsoft data collection policy. The first time that you specify **-errorreport:send** on a computer, a compiler message will refer you to a Web site that contains the Microsoft data collection policy.  
    
## Remarks  
 An internal compiler error (ICE) results when the compiler cannot process a source code file. When an ICE occurs, the compiler does not produce an output file or any useful diagnostic that you can use to fix your code.  
  
 In previous releases, when you received an ICE, you were encouraged to contact Microsoft Product Support Services to report the problem. By using **-errorreport**, you can provide ICE information to the Visual C# team. Your error reports can help improve future compiler releases.  
  
 A user's ability to send reports depends on computer and user policy permissions.  
  
 For more information about error debugger, see [Description of the Dr. Watson for Windows (Drwtsn32.exe) Tool](https://support.microsoft.com/help/308538/description-of-the-dr--watson-for-windows-drwtsn32-exe-tool).  
  
### To set this compiler option in the Visual Studio development environment  
  
1.  Open the project's **Properties** page. For more information, see [Build Page, Project Designer (C#)](/visualstudio/ide/reference/build-page-project-designer-csharp).  
  
2.  Click the **Build** property page.  
  
3.  Click the **Advanced** button.  
  
4.  Modify the **Internal Compiler Error Reporting** property.  
  
 For information about how to set this compiler option programmatically, see <xref:VSLangProj80.CSharpProjectConfigurationProperties3.ErrorReport%2A>.  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)
