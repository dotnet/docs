---
title: "Mpgo.exe (Managed Profile Guided Optimization Tool)"
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
  - "Mpgo.exe"
  - "training scenarios, generating profiles with"
  - "Managed Profile Guided Optimization Tool"
  - "Ngen.exe"
  - "Ngen.exe, profilers and native images"
ms.assetid: f6976502-a000-4fbe-aaf5-a7aab9ce4ec2
caps.latest.revision: 31
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Mpgo.exe (Managed Profile Guided Optimization Tool)
The Managed Profile Guided Optimization Tool (Mpgo.exe) is a command-line tool that uses common end-user scenarios to optimize the native image assemblies that are created by the [Native Image Generator (Ngen.exe)](../../../docs/framework/tools/ngen-exe-native-image-generator.md). This tool enables you to run training scenarios that generate profile data. The [Native Image Generator (Ngen.exe)](../../../docs/framework/tools/ngen-exe-native-image-generator.md) uses this data to optimize its generated native image application assemblies. A training scenario is a trial run of an expected use of your application. Mpgo.exe is available in Visual Studio Ultimate 2012 and later versions. Starting with [!INCLUDE[vs_dev12](../../../includes/vs-dev12-md.md)], you can also use Mpgo.exe to optimize [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps.  
  
 Profile-guided optimization improves application startup time, memory utilization (working set size), and throughput by gathering data from training scenarios and using it to optimize the layout of native images.  
  
 When you encounter performance issues with startup time and working set size for Intermediate Language (IL) assemblies, we recommend that you first use Ngen.exe to eliminate just-in-time (JIT) compilation costs and to facilitate code sharing. If you need additional improvements, you can then use Mpgo.exe to further optimize your application. You can use the performance data from the un-optimized native image assemblies as a baseline to evaluate the performance gains. Using Mpgo.exe may result in faster cold startup times and a smaller working set size. Mpgo.exe adds information to IL assemblies that Ngen.exe uses to create optimized native image assemblies. For more information, see the entry [Improving Launch Performance for your Desktop Applications](http://go.microsoft.com/fwlink/p/?LinkId=248943) in the .NET blog.  
  
 This tool is automatically installed with Visual Studio. To run the tool, use the Developer Command Prompt (or the Visual Studio Command Prompt in Windows 7) with administrator credentials, and type the following at the command prompt. For more information, see [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md).  
  
 For desktop apps:  
  
```  
mpgo –Scenario <command> [-Import <directory>] –AssemblyList <assembly1>  <assembly2> ... -OutDir <directory> [options]  
```  
  
 For [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps:  
  
## Syntax  
  
```  
mpgo –Scenario <packageName> -AppID <appId> -Timeout <seconds>  
```  
  
#### Parameters  
 All arguments to Mpgo.exe are case-insensitive. Commands are prefixed with a dash.  
  
> [!NOTE]
>  You can use either `–Scenario` or `–Import` as a required command, but not both. None of the required parameters are used if you specify the `–Reset` option.  
  
|Required parameter|Description|  
|------------------------|-----------------|  
|`-Scenario` \<*command*><br /><br /> —or—<br /><br /> `-Scenario` \<*packageName*><br /><br /> -or-<br /><br /> `-Import` \<*directory*>|For desktop apps, use `–Scenario` to specify the command to run the application you want to optimize, including any command-line arguments. Use three sets of double quotation marks around *command* if it specifies a path that includes spaces; for example: `mpgo.exe -scenario """C:\My App\myapp.exe""" -assemblylist """C:\My App\myapp.exe""" -outdir "C:\optimized files"`. Do not use double quotation marks; they will not work correctly if *command* includes spaces.<br /><br /> -or-<br /><br /> For [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps, use `–Scenario` to specify the package that you want to generate profile information for. If you specify the package display name or the package family name instead of the full package name, Mpgo.exe will select the package that matches the name you provided if there is only one match. If multiple packages match the specified name, Mpgo.exe will prompt you to choose a package.<br /><br /> —or—<br /><br /> Use `-Import` to specify that optimization data from previously optimized assemblies should be used to optimize the assemblies in `-AssemblyList`. *directory* specifies the directory that contains the previously optimized files. The assemblies specified in `–AssemblyList` or `–AssemblyListFile` are the new versions of the assemblies to be optimized using the data from the imported files. Using optimization data from older version of assemblies enables you to optimize newer versions of assemblies without re-running the scenario.  However, if the imported and target assemblies include significantly different code, the optimization data will be ineffective. The assembly names specified in `–AssemblyList` or `–AssemblyListFile` must be present in the directory specified by `–Import`*directory*. Use three sets of double quotation marks around *directory* if it specifies a path that includes spaces.<br /><br /> You must specify either `–Scenario` or `–Import`, but not both parameters.|  
|`-OutDir` \<*directory*>|The directory in which to place the optimized assemblies. If an assembly already exists in the output directory folder, a new copy is created and an index number is appended to its name; for example: *assemblyname*-1.exe. Use double quotation marks around *directory* if it specifies a path that contains spaces.|  
|`-AssemblyList` \<*assembly1 assembly2 ...*><br /><br /> —or—<br /><br /> `-AssemblyListFile` \<*file*>|A list of assemblies (including .exe and .dll files), separated by spaces, that you want collect profile information about. You can specify `C:\Dir\*.dll` or `*.dll` to select all the assemblies in the designated or current working directory. See the Remarks section for more information.<br /><br /> —or—<br /><br /> A text file that contains the list of assemblies you want to collect profile information about, listed one assembly per line. If an assembly name begins with a hyphen (-), use an assembly file list or rename the assembly.|  
|`-AppID` \<*appId*>|The ID of the application in the specified package. If you use the wildcard (\*), Mpgo.exe will try to enumerate the AppIDs in the package and will fall back to \<*package_family_name*>!App if it fails. If you specify a string that is prefixed by an exclamation point (!), Mpgo.exe will concatenate the package family name with the argument provided.|  
|`-Timeout` \<*seconds*>|The amount of time to allow the [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] app to run before the app exits.|  
  
|Optional parameter|Description|  
|------------------------|-----------------|  
|`-64bit`|Instruments the assemblies for 64-bit systems.  You must specify this parameter for 64-bit assemblies, even if your assembly declares itself as 64 bit.|  
|`-ExeConfig` \<*filename*>|Specifies the configuration file that your scenario uses to provide version and loader information.|  
|`-f`|Forces the inclusion of the profile data in a binary assembly, even if it's signed.  If the assembly is signed, it must be re-signed; otherwise, the assembly will fail to load and run.|  
|`-Reset`|Resets the environment to make certain that an aborted profiling session doesn't affect your assemblies, and then quits. The environment is reset by default before and after a profiling session.|  
|`-Timeout` \<*time in seconds*>|Specifies the profiling duration in seconds. Use a value that is slightly more than your observed startup times for GUI applications. At the end of the time-out period, the profile data is recorded although the application continues to run. If you don't set this option, profiling will continue until application shutdown, at which time the data will be recorded.|  
|`-LeaveNativeImages`|Specifies that the instrumented native images shouldn't be removed after running the scenario. This option is primarily used when you're getting the application that you specified for the scenario running. It will prevent the recreation of native images for subsequent runs of Mpgo.exe. When you have finished running your application, there may be orphaned native images in the cache if you specify this option. In this case, run Mpgo.exe with the same scenario and assembly list and use the `–RemoveNativeImages` parameter to remove these native images.|  
|`-RemoveNativeImages`|Cleans up from a run where `–LeaveNativeImages` was specified. If you specify `-RemoveNativeImages`, Mpgo.exe ignores any arguments except `-64bit` and `–AssemblyList`, and exits after removing all instrumented native images.|  
  
## Remarks  
 You can use both `–AssemblyList` and `- AssemblyListFile` multiple times on the command line.  
  
 If you do not specify full path names when specifying assemblies, Mpgo.exe looks in the current directory. If you specify an incorrect path, Mpgo.exe displays an error message but continues to generate data for other assemblies. If you specify an assembly that is not loaded during the training scenario, no training data is generated for that assembly.  
  
 If an assembly in the list is in the global assembly cache, it will not be updated to contain the profile information.  Remove it from the global assembly cache to collect profile information.  
  
 The use of Ngen.exe and Mpgo.exe is recommended only for large managed applications, because the benefit of precompiled native images is typically seen only when it eliminates significant JIT compilation at run time. Running Mpgo.exe on "Hello World" style applications that aren’t working-set intensive will not provide any benefits, and Mpgo.exe may even fail to gather profile data.  
  
> [!NOTE]
>  Ngen.exe and Mpgo.exe are not recommended for ASP.NET applications and Windows Communication Foundation (WCF) services.  
  
## To Use Mpgo.exe  
  
1.  Use a computer that has the Visual Studio Ultimate 2012 and your application installed.  
  
2.  Run Mpgo.exe as an administrator with the necessary parameters.  See the next section for sample commands.  
  
     The optimized intermediate language (IL) assemblies are created in the folder specified by the `–OutDir` parameter (in the examples, this is the `C:\Optimized` folder).  
  
3.  Replace the IL assemblies you used for Ngen.exe  with the new IL assemblies that contain the profile information from the directory specified by `–OutDir`.  
  
4.  The application setup (using the images provided by Mpgo.exe) will install optimized native images.  
  
## Suggested Workflow  
  
1.  Create a set of optimized IL assemblies by using Mpgo.exe with the `–Scenario` parameter.  
  
2.  Check the optimized IL assemblies into source control.  
  
3.  In the build process, call Mpgo.exe with the `–Import` parameter as a post-build step to generate optimized IL images to pass to Ngen.exe.  
  
 This process ensures that all assemblies have optimization data. If you check in updated optimized assemblies (steps 1 and 2) more frequently, the performance numbers will be more consistent throughout product development.  
  
## Using Mpgo.exe from Visual Studio  
 You can run Mpgo.exe from Visual Studio (see the article [How to: Specify Build Events (C#)](http://msdn.microsoft.com/library/b4ce1ad9-5215-4b6f-b6a2-798b249aa335)) with the following restrictions:  
  
-   You cannot use quoted paths with trailing slash marks, because Visual Studio macros also use trailing slash marks by default. (For example, `–OutDir "C:\Output Folder\"` is invalid.) To work around this restriction, you can escape the trailing slash. (For example, use `-OutDir "$(OutDir)\"` instead.)  
  
-   By default, Mpgo.exe is not on the Visual Studio build path. You must either add the path to Visual Studio or specify the full path on the Mpgo command line. You can use either the `–Scenario` or the `–Import` parameter in the post-build event in Visual Studio. However, the typical process is to use `–Scenario` one time from a Visual Studio developer command prompt, and then use `–Import` to update the optimized assemblies after each build; for example:  `"C:\Program Files\Microsoft Visual Studio 11.0\Team Tools\Performance Tools\mpgo.exe" -import "$(OutDir)tmp" -assemblylist "$(TargetPath)" -outdir "$(OutDir)\"`.  
  
<a name="samples"></a>   
## Examples  
 The following Mpgo.exe command from a Visual Studio developer command prompt optimizes a tax application:  
  
```  
mpgo –scenario "C:\MyApp\MyTax.exe /params par" –AssemblyList Mytax.dll MyTaxUtil2011.dll –OutDir C:\Optimized –TimeOut 15  
```  
  
 The following Mpgo.exe command optimizes a sound application:  
  
```  
mpgo –scenario "C:\MyApp\wav2wma.exe –input song1.wav –output song1.wma" –AssemblyList transcode.dll –OutDir C:\Optimized –TimeOut 15  
```  
  
 The following Mpgo.exe command uses data from previously optimized assemblies to optimize newer versions of the assemblies:  
  
```  
mpgo.exe -import "C:\Optimized" -assemblylist "C:\MyApp\MyTax.dll" "C:\MyApp\MyTaxUtil2011.dll" -outdir C:\ReOptimized  
```  
  
## See Also  
 [Ngen.exe (Native Image Generator)](../../../docs/framework/tools/ngen-exe-native-image-generator.md)  
 [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md)  
 [Improving Launch Performance for your Desktop Applications](http://go.microsoft.com/fwlink/p/?LinkId=248943)  
 [An Overview of Performance Improvements in .NET 4.5](http://go.microsoft.com/fwlink/p/?LinkId=249131)
