---
title: "Lc.exe (License Compiler)"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "Lc.exe"
  - ".licx file"
  - "License Compiler"
  - "control licenses [Windows Forms]"
  - "compiling licenses file"
  - "license file"
  - ".licenses file"
  - "Windows Forms, control licenses"
  - "licensed controls [Windows Forms]"
ms.assetid: 2de803b8-495e-4982-b209-19a72aba0460
---
# Lc.exe (License Compiler)
The License Compiler reads text files that contain licensing information and produces a binary file that can be embedded in a common language runtime executable as a resource.  
  
 A .licx text file is automatically generated or updated by the Windows Forms Designer whenever a licensed control is added to the form. As part of compilation, the project system will transform the .licx text file into a .licenses binary resource that provides support for .NET control licensing. The binary resource will then be embedded in the project output.  
  
 Cross compilation between 32-bit and 64-bit is not supported when you use the License Compiler when building your project. This is because the License Compiler has to load assemblies, and loading 64-bit assemblies from a 32-bit application is not allowed, and vice versa. In this case, use the License Compiler from the command line to compile the license manually, and specify the corresponding architecture.  
  
 This tool is automatically installed with Visual Studio. To run the tool, use the Developer Command Prompt for Visual Studio (or the Visual Studio Command Prompt in Windows 7). For more information, see [Command Prompts](developer-command-prompt-for-vs.md).  
  
 At the command prompt, type the following:  
  
## Syntax  
  
```console
      lc /target:  
targetPE /complist:filename [-outdir:path]  
/i:modules [/nologo] [/v]  
```  
  
|Option|Description|  
|------------|-----------------|  
|**/complist:** *filename*|Specifies the name of a file that contains the list of licensed components to include in the .licenses file. Each component is referenced using its full name with only one component per line.<br /><br /> Command-line users can specify a separate file for each form in the project. Lc.exe accepts multiple input files and produces a single .licenses file.|  
|**/h**[**elp**]|Displays command syntax and options for the tool.|  
|**/i:** *module*|Specifies the modules that contain the components listed in the **/complist** file. To specify more than one module, use multiple **/i** flags.|  
|**/nologo**|Suppresses the Microsoft startup banner display.|  
|**/outdir:** *path*|Specifies the directory in which to place the output .licenses file.|  
|**/target:** *targetPE*|Specifies the executable for which the .licenses file is being generated.|  
|**/v**|Specifies verbose mode; displays compilation progress information.|  
|**@** *file*|Specifies the response (.rsp) file.|  
|**/?**|Displays command syntax and options for the tool.|  
  
## Example  
  
1. If you are using a licensed control `MyCompany.Samples.LicControl1` contained in `Samples.DLL` in an application called `HostApp.exe`*,* you can create `HostAppLic.txt` that contains the following.  
  
    ```text
    MyCompany.Samples.LicControl1, Samples.DLL  
    ```  
  
2. Create the .licenses file called `HostApp.exe.licenses` using the following command.  
  
    ```console  
    lc /target:HostApp.exe /complist:hostapplic.txt /i:Samples.DLL /outdir:c:\bindir  
    ```  
  
3. Build `HostApp.exe` including the .licenses file as a resource. If you were building a C# application you would use the following command to build your application.  
  
    ```console
    csc /res:HostApp.exe.licenses /out:HostApp.exe *.cs  
    ```  
  
 The following command compiles `myApp.licenses` from the lists of licensed components specified by `hostapplic.txt`, `hostapplic2.txt` and `hostapplic3.txt`. The `modulesList` argument specifies the modules that contain the licensed components.  
  
```console  
lc /target:myApp /complist:hostapplic.txt /complist:hostapplic2.txt /complist: hostapplic3.txt /i:modulesList  
```  
  
## Response File Example  
 The following listing shows an example of a response file, `response.rsp`. For more information on response files, see [Response Files](/visualstudio/msbuild/msbuild-response-files).  
  
```text  
/target:hostapp.exe  
/complist:hostapplic.txt   
/i:WFCPrj.dll   
/outdir:"C:\My Folder"  
```  
  
 The following command line uses the `response.rsp` file.  
  
```console  
lc @response.rsp  
```  
  
## See also

- [Tools](index.md)
- [Al.exe (Assembly Linker)](al-exe-assembly-linker.md)
- [Command Prompts](developer-command-prompt-for-vs.md)
