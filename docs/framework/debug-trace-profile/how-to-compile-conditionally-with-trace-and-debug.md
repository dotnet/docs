---
title: "How to: Compile Conditionally with Trace and Debug"
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
  - "trace compiler options"
  - "trace statements"
  - "compiling source code, trace statements"
  - "tracing [.NET Framework], enabling or disabling"
  - "tracing [.NET Framework], compiling conditionally"
  - "TRACE directive"
  - "conditional compilation, tracing code"
ms.assetid: 56d051c3-012c-42c1-9a58-7270edc624aa
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Compile Conditionally with Trace and Debug
While you are debugging an application during development, both your tracing and debugging output go to the Output window in Visual Studio. However, to include tracing features in a deployed application, you must compile your instrumented applications with the **TRACE** compiler directive enabled. This allows tracing code to be compiled into the release version of your application. If you do not enable the **TRACE** directive, all tracing code is ignored during compilation and is not included in the executable code that you will deploy.  
  
 Both the tracing and debugging methods have associated conditional attributes. For example, if the conditional attribute for tracing is **true**, all trace statements are included within an assembly (a compiled .exe file or .dll); if the **Trace** conditional attribute is **false**, the trace statements are not included.  
  
 You can have either the **Trace** or **Debug** conditional attribute turned on for a build, or both, or neither. Thus, there are four types of build: **Debug**, **Trace**, both, or neither. Some release builds for production deployment might contain neither; most debugging builds contain both.  
  
 You can specify the compiler settings for your application in several ways:  
  
-   The property pages  
  
-   The command line  
  
-   **#CONST** (for Visual Basic) and **#define** (for C#)  
  
### To change compile settings from the property pages dialog box  
  
1.  Right-click the project node in **Solution Explorer**.  
  
2.  Choose **Properties** from the shortcut menu.  
  
    -   In Visual Basic, click the **Compile** tab in the left pane of the property page, then click the **Advanced Compile Options** button to display the **Advanced Compiler Settings** dialog box. Select the check boxes for the compiler settings you want to enable. Clear the check boxes for settings you want to disable.  
  
    -   In C#, click the **Build** tab in the left pane of the property page, then select the check boxes for the compiler settings you want to enable. Clear the check boxes for settings you want to disable.  
  
### To compile instrumented code using the command line  
  
1.  Set a conditional compiler switch on the command line. The compiler will include trace or debug code in the executable.  
  
     For example, the following compiler instruction entered on the command line would include your tracing code in a compiled executable:  
  
     For Visual Basic: **vbc -r:System.dll -d:TRACE=TRUE -d:DEBUG=FALSE MyApplication.vb**  
  
     For C#: **csc -r:System.dll -d:TRACE -d:DEBUG=FALSE MyApplication.cs**  
  
    > [!TIP]
    >  To compile more than one application file, leave a blank space between the file names, for example, **MyApplication1.vb MyApplication2.vb MyApplication3.vb** or **MyApplication1.cs MyApplication2.cs MyApplication3.cs**.  
  
     The meaning of the conditional-compilation directives used in the above examples is as follows:  
  
    |Directive|Meaning|  
    |---------------|-------------|  
    |`vbc`|Visual Basic compiler|  
    |`csc`|C# compiler|  
    |`-r:`|References an external assembly (EXE or DLL)|  
    |`-d:`|Defines a conditional compilation symbol|  
  
    > [!NOTE]
    >  You must spell TRACE or DEBUG with uppercase letters. For more information about the conditional compilation commands, enter `vbc /?` (for Visual Basic) or `csc /?` (for C#) at the command prompt. For more information, see [Building from the Command Line](~/docs/csharp/language-reference/compiler-options/how-to-set-environment-variables-for-the-visual-studio-command-line.md) (C#) or [Invoking the Command-Line Compiler](~/docs/visual-basic/reference/command-line-compiler/how-to-invoke-the-command-line-compiler.md) (Visual Basic).  
  
### To perform conditional compilation using #CONST or #define  
  
1.  Type the appropriate statement for your programming language at the top of the source code file.  
  
    |Language|Statement|Result|  
    |--------------|---------------|------------|  
    |**Visual Basic**|**#CONST TRACE = true**|Enables tracing|  
    ||**#CONST TRACE = false**|Disables tracing|  
    ||**#CONST DEBUG = true**|Enables debugging|  
    ||**#CONST DEBUG = false**|Disables debugging|  
    |**C#**|**#define TRACE**|Enables tracing|  
    ||**#undef TRACE**|Disables tracing|  
    ||**#define DEBUG**|Enables debugging|  
    ||**#undef DEBUG**|Disables debugging|  
  
### To disable tracing or debugging  
  
Delete the compiler directive from your source code.  
  
\- or -  
  
Comment out the compiler directive.  
  
> [!NOTE]
>  When you are ready to compile, you can either choose **Build** from the **Build** menu, or use the command line method but without typing the **d:** to define conditional compilation symbols.  
  
## See Also  
 [Tracing and Instrumenting Applications](../../../docs/framework/debug-trace-profile/tracing-and-instrumenting-applications.md)  
 [How to: Create, Initialize and Configure Trace Switches](../../../docs/framework/debug-trace-profile/how-to-create-initialize-and-configure-trace-switches.md)  
 [Trace Switches](../../../docs/framework/debug-trace-profile/trace-switches.md)  
 [Trace Listeners](../../../docs/framework/debug-trace-profile/trace-listeners.md)  
 [How to: Add Trace Statements to Application Code](../../../docs/framework/debug-trace-profile/how-to-add-trace-statements-to-application-code.md)  
 [How to: Set Environment Variables for the Visual Studio Command Line](~/docs/csharp/language-reference/compiler-options/how-to-set-environment-variables-for-the-visual-studio-command-line.md)  
 [How to: Invoke the Command-Line Compiler](~/docs/visual-basic/reference/command-line-compiler/how-to-invoke-the-command-line-compiler.md)
