---
title: "SecAnnotate.exe (.NET Security Annotator Tool)"
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
  - "SecAnnotate.exe"
  - "Security Annotator tool"
ms.assetid: 8104d208-7813-4a1d-8a75-58f9a7bcb8c9
caps.latest.revision: 22
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# SecAnnotate.exe (.NET Security Annotator Tool)
The .NET Security Annotator tool (SecAnnotate.exe) is a command-line application that identifies the `SecurityCritical` and `SecuritySafeCritical` portions of one or more assemblies.  
  
 A Visual Studio extension, [Security Annotator](http://go.microsoft.com/fwlink/?LinkId=198007), provides a graphical user interface to SecAnnotate.exe and enables you to run the tool from Visual Studio.  
  
 This tool is automatically installed with Visual Studio. To run the tool, use the Developer Command Prompt (or the Visual Studio Command Prompt in Windows 7). For more information, see [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md).  
  
 At the command prompt, type the following, where *parameters* are described in the following section, and *assemblies* consist of one or more assembly names separated by blanks:  
  
## Syntax  
  
```  
SecAnnotate.exe [parameters] [assemblies]  
```  
  
#### Parameters  
  
|Option|Description|  
|------------|-----------------|  
|`/a`<br /><br /> or<br /><br /> `/showstatistics`|Shows statistics about the use of transparency in assemblies that are being analyzed.|  
|`/d:` *directory*<br /><br /> or<br /><br /> `/referencedir:` *directory*|Specifies a directory to search for dependent assemblies during annotation.|  
|`/i`<br /><br /> or<br /><br /> `/includesignatures`|Includes extended signature information in the annotation report file.|  
|`/n`<br /><br /> or<br /><br /> `/nogac`|Suppresses searching for referenced assemblies in the global assembly cache.|  
|`/o:` *output.xml*<br /><br /> or<br /><br /> `/out:` *output.xml*|Specifies the output annotation file.|  
|`/p:` *maxpasses*<br /><br /> or<br /><br /> `/maximumpasses:` *maxpasses*|Specifies the maximum number of annotation passes to make on assemblies before stopping the generation of new annotations.|  
|`/q`<br /><br /> or<br /><br /> `/quiet`|Specifies quiet mode, in which the annotator does not output status messages; it outputs only error information.|  
|`/r:` *assembly*<br /><br /> or<br /><br /> `/referenceassembly:` *assembly*|Includes the specified assembly when resolving dependent assemblies during annotation. Reference assemblies are given priority over assemblies that are found in the reference path.|  
|`/s:` *rulename*<br /><br /> or<br /><br /> `/suppressrule:` *rulename*|Suppresses running the specified transparency rule on the input assemblies.|  
|`/t`<br /><br /> or<br /><br /> `/forcetransparent`|Forces the Annotator tool to treat all assemblies that do not have any transparency annotations as if they were entirely transparent.|  
|`/t`:*assembly*<br /><br /> or<br /><br /> `/forcetransparent`:*assembly*|Force the given assembly to be transparent, regardless of its current assembly-level annotations.|  
|||  
|`/v`<br /><br /> or<br /><br /> `/verify`|Verifies only that an assembly's annotations are correct; does not attempt to make multiple passes to find all required annotations if the assembly does not verify.|  
|`/x`<br /><br /> or<br /><br /> `/verbose`|Specifies verbose output while annotating.|  
|`/y:` *directory*<br /><br /> or<br /><br /> `/symbolpath:` *directory*|Includes the specified directory when searching for symbol files during annotation.|  
  
## Remarks  
 Parameters and assemblies may also be provided in a response file that is specified on the command line and prefixed with an at sign (@). Each line in the response file should contain a single parameter or assembly name.  
  
 For more information about the .NET Security Annotator, see the entry [Using SecAnnotate to Analyze Your Assemblies for Transparency Violations](http://go.microsoft.com/fwlink/?LinkId=187648) in the .NET Security blog.  
  
## Examples
