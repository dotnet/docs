---
title: "CorFlags.exe (CorFlags Conversion Tool)"
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
  - "CorFlags conversion tool"
  - "CorFlags.exe"
  - "portable executable files, CorFlags section"
ms.assetid: ef900f8f-71ca-4dde-9b8c-95ddb0d7d89c
caps.latest.revision: 17
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CorFlags.exe (CorFlags Conversion Tool)
The CorFlags Conversion tool allows you to configure the CorFlags section of the header of a portable executable image.  
  
 This tool is automatically installed with Visual Studio. To run the tool, use the Developer Command Prompt (or the Visual Studio Command Prompt in Windows 7). For more information, see [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md).  
  
 At the command prompt, type the following:  
  
## Syntax  
  
```  
CorFlags.exe assembly [options]  
```  
  
#### Parameters  
  
|Required parameter|Description|  
|------------------------|-----------------|  
|`assembly`|The name of the assembly for which to configure the CorFlags.|  
  
|Option|Description|  
|------------|-----------------|  
|**/32BIT[REQ]+**|Sets the 32BITREQUIRED flag.|  
|**/32BIT[REQ]-**|Clears the 32BITREQUIRED flag.|  
|**/32BITPREF+**|Sets the 32BITPREFERRED flag. The app runs as a 32-bit process even on 64-bit platforms. Set this flag only on EXE files. If the flag is set on a DLL, the DLL fails to load in 64-bit processes, and a <xref:System.BadImageFormatException> exception is thrown. An EXE file with this flag can be loaded into a 64-bit process.<br /><br /> New in the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)].|  
|**/32BITPREF-**|Clears the 32BITPREFERRED flag.<br /><br /> New in the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)].|  
|**/?**|Displays command syntax and options for the tool.|  
|**/Force**|Forces an update even if the assembly is strong-named. **Important:**  If you update a strong-named assembly, you must sign it again before executing its code.|  
|**/help**|Displays command syntax and options for the tool.|  
|**/ILONLY+**|Sets the ILONLY flag.|  
|**/ILONLY-**|Clears the ILONLY flag.|  
|**/nologo**|Suppresses the Microsoft startup banner display.|  
|**/RevertCLRHeader**|Reverts the CLR header version to 2.0.|  
|**/UpgradeCLRHeader**|Upgrades the CLR header version to 2.5. **Note:**  Assemblies must have a CLR header version of 2.5 or greater to run natively.|  
  
## Remarks  
 If no options are specified, the CorFlags Conversion tool displays the flags for the specified assembly.  
  
## See Also  
 [Tools](../../../docs/framework/tools/index.md)  
 [64-bit Applications](../../../docs/framework/64-bit-apps.md)  
 [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md)
