---
title: "Peverify.exe (PEVerify Tool)"
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
  - "portable executable files, PEVerify"
  - "verifying MSIL and metadata"
  - "PEVerify tool"
  - "type safety requirements"
  - "MSIL"
  - "PEverify.exe"
  - "PE files, PEVerify"
ms.assetid: f4f46f9e-8d08-4e66-a94b-0c69c9b0bbfa
caps.latest.revision: 18
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Peverify.exe (PEVerify Tool)
The PEVerify tool helps developers who generate Microsoft intermediate language (MSIL) (such as compiler writers, script engine developers, and so on) to determine whether their MSIL code and associated metadata meet type safety requirements. Some compilers generate verifiably type-safe code only if you avoid using certain language constructs. If, as a developer, you are using such a compiler, you may want to verify that you have not compromised the type safety of your code. In this situation, you can run the PEVerify tool on your files to check the MSIL and metadata.  
  
 This tool is automatically installed with Visual Studio. To run the tool, use the Developer Command Prompt (or the Visual Studio Command Prompt in Windows 7). For more information, see [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md).  
  
 At the command prompt, type the following:  
  
## Syntax  
  
```  
peverify filename [options]  
```  
  
#### Parameters  
  
|Argument|Description|  
|--------------|-----------------|  
|*filename*|The portable executable (PE) file for which to check the MSIL and metadata.|  
  
|Option|Description|  
|------------|-----------------|  
|**/break=** *maxErrorCount*|Aborts verification after *maxErrorCount* errors.<br /><br /> This parameter is not supported in .NET Framework version 2.0 or later.|  
|**/clock**|Measures and reports the following verification times in milliseconds:<br /><br /> **MD Val. cycle**<br /> Metadata validation cycle<br /><br /> **MD Val. pure**<br /> Metadata validation pure<br /><br /> **IL Ver. cycle**<br /> Microsoft intermediate language (MSIL) verification cycle<br /><br /> **IL Ver pure**<br /> MSIL verification pure<br /><br /> The **MD Val. cycle** and **IL Ver. cycle** times include the time required to perform necessary startup and shutdown procedures. The **MD Val. pure** and **IL Ver pure** times reflect the time required to perform the validation or verification only.|  
|**/help**|Displays command syntax and options for the tool.|  
|**/hresult**|Displays error codes in hexadecimal format.|  
|**/ignore=** *hex.code* [, *hex.code*]|Ignores the specified error codes.|  
|**/ignore=@** *responseFile*|Ignores the error codes listed in the specified response file.|  
|**/il**|Performs MSIL type safety verification checks for methods implemented in the assembly specified by *filename*. The tool returns detailed descriptions for each problem found unless you specify the **/quiet** option.|  
|**/md**|Performs metadata validation checks on the assembly specified by *filename*. This walks the full metadata structure within the file and reports all validation problems encountered.|  
|**/nologo**|Suppresses the display of product version and copyright information.|  
|**/nosymbols**|In the .NET Framework version 2.0, suppresses line numbers for backward compatibility.|  
|**/quiet**|Specifies quiet mode; suppresses output of the verification problem reports. Peverify.exe still reports whether the file is type safe, but does not report information on problems preventing type safety verification.|  
|`/transparent`|Verify only the transparent methods.|  
|**/unique**|Ignores repeating error codes.|  
|**/verbose**|In the .NET Framework version 2.0, displays additional information in MSIL verification messages.|  
|**/?**|Displays command syntax and options for the tool.|  
  
## Remarks  
 The common language runtime relies on the type-safe execution of application code to help enforce security and isolation mechanisms. Normally, code that is not [verifiably type safe](http://msdn.microsoft.com/library/095cd1f6-d8db-4c0e-bce2-83ccb34dd5dc) cannot run, although you can set security policy to allow the execution of trusted but unverifiable code.  
  
 If neither the **/md** nor **/il** options are specified, Peverify.exe performs both types of checks. Peverify.exe performs **/md** checks first. If there are no errors, **/il** checks are made. If you specify both **/md** and **/il**, **/il** checks are made even if there are errors in the metadata. Thus, if there are no metadata errors, **peverify** *filename* is equivalent to **peverify** *filename* **/md** **/il**.  
  
 Peverify.exe performs comprehensive MSIL verification checks based on dataflow analysis plus a list of several hundred rules on valid metadata. For detailed information on the checks Peverify.exe performs, see the "Metadata Validation Specification" and the "MSIL Instruction Set Specification" in the Tools Developers Guide folder in the [!INCLUDE[winsdklong](../../../includes/winsdklong-md.md)].  
  
 Note that the .NET Framework version 2.0 or later supports verifiable `byref` returns specified using the following MSIL instructions: `dup`, `ldsflda`, `ldflda`, `ldelema`, `call` and `unbox`.  
  
## Examples  
 The following command performs metadata validation checks and MSIL type safety verification checks for methods implemented in the assembly `myAssembly.exe`.  
  
```  
peverify myAssembly.exe /md /il  
```  
  
 Upon successful completion of the above request, Peverify.exe displays the following message.  
  
```  
All classes and methods in myAssembly.exe Verified  
```  
  
 The following command performs metadata validation checks and MSIL type safety verification checks for methods implemented in the assembly `myAssembly.exe`. The tool displays the time required to perform these checks.  
  
```  
peverify myAssembly.exe /md /il /clock  
```  
  
 Upon successful completion of the above request, Peverify.exe displays the following message.  
  
```  
All classes and methods in myAssembly.exe Verified  
Timing: Total run     320 msec  
        MD Val.cycle  40 msec  
        MD Val.pure   10 msec  
        IL Ver.cycle  270 msec  
        IL Ver.pure   230 msec  
```  
  
 The following command performs metadata validation checks and MSIL type safety verification checks for methods implemented in the assembly `myAssembly.exe`. Peverify.exe stops, however, when it reaches the maximum error count of 100. The tool also ignores the specified error codes.  
  
```  
peverify myAssembly.exe /break=100 /ignore=0x12345678,0xABCD1234  
```  
  
 The following command produces the same result as the above previous example, but specifies the error codes to ignore in the response file `ignoreErrors.rsp`.  
  
```  
peverify myAssembly.exe /break=100 /ignore@ignoreErrors.rsp  
```  
  
 The response file can contain a comma-separated list of error codes.  
  
```  
0x12345678, 0xABCD1234  
```  
  
 Alternatively, the response file can be formatted with one error code per line.  
  
```  
0x12345678  
0xABCD1234  
```  
  
## See Also  
 [Tools](../../../docs/framework/tools/index.md)  
 [NIB: Writing Verifiably Type-Safe Code](http://msdn.microsoft.com/library/d18f10ef-3b48-4f47-8726-96714021547b)  
 [Type Safety and Security](http://msdn.microsoft.com/library/095cd1f6-d8db-4c0e-bce2-83ccb34dd5dc)  
 [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md)
