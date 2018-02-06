---
title: "Clrver.exe (CLR Version Tool)"
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
  - "Clrver.exe"
  - "CLR Version tool"
ms.assetid: cbc2ee86-bdc8-4a65-a8f1-ba23bce3a699
caps.latest.revision: 13
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Clrver.exe (CLR Version Tool)
The CLR Version tool (Clrver.exe) reports all the installed versions of the common language runtime (CLR) on the computer.  
  
 This tool is automatically installed with Visual Studio. To run the tool, use the Developer Command Prompt (or the Visual Studio Command Prompt in Windows 7). For more information, see [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md).  
  
 At the command prompt, type the following:  
  
## Syntax  
  
```  
clrver [option]  
```  
  
## Options  
  
|Option|Description|  
|------------|-----------------|  
|`-all`|Displays all processes on the computer that are using the CLR.|  
|*pid*|Displays the version(s) of the CLR used by the process that has the specified process ID (PID).|  
|`-?`|Displays command syntax and options for the tool.|  
  
## Remarks  
 If you call Clrver.exe with no options, it displays all installed CLR versions. If you specify a PID for another user, you must have administrative permissions to obtain the version information.  
  
> [!NOTE]
>  In Windows Vista and later, User Account Control (UAC) determines the privileges of a user. If you are a member of the Built-in Administrators group, you are assigned two run-time access tokens: a standard user access token and an administrator access token. By default, you are in the standard user role. To execute code that requires administrative permission, you must first elevate your privileges from standard user to administrator. You can do this when you start the command prompt by right-clicking the command prompt icon and indicating that you want to run as an administrator.  
  
 Attempting to determine the CLR version for SYSTEM, LOCAL SERVICE, and NETWORK SERVICE processes results in a message indicating that the PID doesn't exist.  
  
## Examples  
 The following command displays all the versions of the CLR installed on the computer.  
  
 `clrver`  
  
 The following command displays the version of the CLR used by process 128.  
  
 `clrver 128`  
  
 The following command displays all the managed processes and the version of the CLR they are using.  
  
 `Clrver -all`  
  
## See Also  
 [Tools](../../../docs/framework/tools/index.md)  
 [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md)
