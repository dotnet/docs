---
title: "Regsvcs.exe (.NET Services Installation Tool)"
description: Use Regsvcs.exe, the .NET Services Installation tool. Load and register an assembly, configure services you've added programmatically to a class, and more.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "Regsvcs.exe"
  - ".NET Services Installation tool"
  - "loading assemblies"
  - "assemblies [.NET Framework], registering"
  - "type libraries"
  - "registering assemblies"
ms.assetid: 5220fe58-5aaf-4e8e-8bc3-b78c63025804
---
# Regsvcs.exe (.NET Services Installation Tool)

The .NET Services Installation tool performs the following actions:  
  
- Loads and registers an assembly.  
  
- Generates, registers, and installs a type library into a specified COM+ application.  
  
- Configures services that you have added programmatically to your class.  
  
 To run the tool, use [Visual Studio Developer Command Prompt or Visual Studio Developer PowerShell](/visualstudio/ide/reference/command-prompt-powershell).  
  
 At the command prompt, type the following:  
  
## Syntax  
  
```console  
      regsvcs [/c | /fc | /u] [/tlb:typeLibraryFile] [/extlb]  
[/reconfig] [/componly] [/appname:applicationName]  
[/nologo] [/quiet]assemblyFile.dll
```  
  
## Parameters  
  
|Argument|Description|  
|--------------|-----------------|  
|*assemblyFile.dll*|The source assembly file. The assembly must be signed with a strong name. For more information, see [Signing an Assembly with a Strong Name](../../standard/assembly/sign-strong-name.md).|  
  
|Option|Description|  
|------------|-----------------|  
|**/appdir:** *path*|Specifies the root directory of the application.|  
|**/appname:** *applicationName*|Specifies the name of the COM+ application to either find or create.|  
|**/c**|Creates the target application.|  
|**/componly**|Configures components only; ignores methods and interfaces.|  
|**/exapp**|Specifies to the tool to expect an existing application.|  
|**/extlb**|Uses an existing type library.|  
|**/fc**|Finds or creates the target application.|  
|**/help**|Displays command syntax and options for the tool.|  
|**/noreconfig**|Does not reconfigure an existing target application.|  
|**/nologo**|Suppresses the Microsoft startup banner display.|  
|**/parname:** *name*|Specifies the name or id of the COM+ application to either find or create.|  
|**/reconfig**|Reconfigures an existing target application. This is the default.|  
|**/tlb:** *typelibraryfile*|Specifies the type library file to install.|  
|**/u**|Uninstalls the target application.|  
|**/quiet**|Specifies quiet mode; suppresses the logo and success message display.|  
|**/?**|Displays command syntax and options for the tool.|  
  
## Remarks  

 Regsvcs.exe requires a source assembly file specified by *assemblyFile.dll*. This assembly must be signed with a strong name. For more information on strong name signing, see [Signing an Assembly with a Strong Name](../../standard/assembly/sign-strong-name.md). The names of the target application and the type library file are optional. The *applicationName* argument can be generated from the source assembly file and will be created by Regsvcs.exe, if it does not already exist. The *typelibraryfile* argument can specify a type library name. If you do not specify a type library name, Regsvcs.exe uses the assembly name as the default.  
  
 When Regsvcs.exe registers a component's methods, it is subject to the [demands](/previous-versions/dotnet/netframework-4.0/9kc0c6st(v=vs.100)) and [link demands](/previous-versions/dotnet/framework/code-access-security/link-demands) on those methods. Because the tool executes in a fully-trusted environment, most demands for a permission succeed. However, Regsvcs.exe cannot register components with methods protected by a demand or link demand for the <xref:System.Security.Permissions.StrongNameIdentityPermission> or the <xref:System.Security.Permissions.PublisherIdentityPermission>.  
  
 You must have administrative privileges on the local computer to use Regsvcs.exe.  
  
 If Regsvcs.exe fails while performing any of these actions, it displays corresponding error messages.  
  
## Examples  

 The following command adds all public classes contained in `myTest.dll` to `myTargetApp` (an existing COM+ application) and produces the `myTest.tlb` type library.  
  
```console  
regsvcs /appname:myTargetApp myTest.dll  
```  
  
 The following command adds all public classes contained in `myTest.dll` to `myTargetApp` (an existing COM+ application) and produces the `newTest.tlb` type library.  
  
```console  
regsvcs /appname:myTargetApp /tlb:newTest.tlb myTest.dll  
```  
  
## See also

- [Tools](index.md)
- [How to: Sign an Assembly with a Strong Name](../../standard/assembly/sign-strong-name.md)
- [Developer command-line shells](/visualstudio/ide/reference/command-prompt-powershell)
