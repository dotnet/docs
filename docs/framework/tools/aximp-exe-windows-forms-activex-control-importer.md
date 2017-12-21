---
title: "Aximp.exe (Windows Forms ActiveX Control Importer)"
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
  - "ActiveX controls, hosting in Windows Forms"
  - "ActiveX Control Importer"
  - "type definitions, converting"
  - "Aximp.exe"
  - "Windows Forms ActiveX Control Importer"
ms.assetid: 482c0d83-7144-4497-b626-87d2351b78d0
caps.latest.revision: 13
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Aximp.exe (Windows Forms ActiveX Control Importer)
The ActiveX Control Importer converts type definitions in a COM type library for an ActiveX control into a Windows Forms control.  
  
 Windows Forms can only host Windows Forms controls — that is, classes that are derived from <xref:System.Windows.Forms.Control>. Aximp.exe generates a wrapper class for an ActiveX control that can be hosted on a Windows Form. This allows you to use the same design-time support and programming methodology applicable to other Windows Forms controls.  
  
 To host the ActiveX control, you must generate a wrapper control that derives from <xref:System.Windows.Forms.AxHost>. This wrapper control contains an instance of the underlying ActiveX control. It knows how to communicate with the ActiveX control, but it appears as a Windows Forms control. This generated control hosts the ActiveX control and exposes its properties, methods, and events as those of the generated control.  
  
 This tool is automatically installed with Visual Studio. To run the tool, use the Developer Command Prompt (or the Visual Studio Command Prompt in Windows 7). For more information, see [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md).  
  
 At the command prompt, type the following:  
  
## Syntax  
  
```  
aximp [options]{file.dll | file.ocx}  
```  
  
## Remarks  
  
|Argument|Description|  
|--------------|-----------------|  
|*file*|The name of the source file that contains the ActiveX control to convert. The file argument must have the extension .dll or .ocx.|  
  
|Option|Description|  
|------------|-----------------|  
|`/delaysign`|Specifies to Aximp.exe to sign the resulting control using delayed signing. You must specify this option with either the `/keycontainer:`, `/keyfile:`, or `/publickey:` option. For more information on the delayed signing process, see [Delay Signing an Assembly](../../../docs/framework/app-domains/delay-sign-assembly.md).|  
|`/help`|Displays command syntax and options for the tool.|  
|`/keycontainer:` *containerName*|Signs the resulting control with a strong name using the public/private key pair found in the key container specified by *containerName*.|  
|`/keyfile:` *filename*|Signs the resulting control with a strong name using the publisher's official public/private key pair found in *filename*.|  
|`/nologo`|Suppresses the Microsoft startup banner display.|  
|`/out:` *filename*|Specifies the name of the assembly to create.|  
|`/publickey:` *filename*|Signs the resulting control with a strong name using the public key found in the file specified by *filename*.|  
|`/rcw:` *filename*|Uses the specified runtime callable wrapper instead of generating a new one. You may specify multiple instances. The current directory is used for relative paths. For more information, see [Runtime Callable Wrapper](../../../docs/framework/interop/runtime-callable-wrapper.md).|  
|`/silent`|Suppresses the display of success messages.|  
|`/source`|Generates C# source code for the Windows Forms wrapper.|  
|`/verbose`|Specifies verbose mode; displays additional progress information.|  
|`/?`|Displays command syntax and options for the tool.|  
  
 Aximp.exe converts an entire ActiveX Control type library at one time and produces a set of assemblies that contain the common language runtime metadata and control implementation for the types defined in the original type library. The generated files are named according to the following pattern:  
  
 common language runtime proxy for COM types: *progid*.dll  
  
 Windows Forms proxy for ActiveX controls (where Ax signifies ActiveX): Ax*progid*.dll  
  
> [!NOTE]
>  If the name of a member of the ActiveX control matches a name defined in the .NET Framework, Aximp.exe will prefix the member name with "Ctl" when it creates the AxHost derived class. For example, if your ActiveX control has a member named "Layout," it is renamed "CtlLayout" in the AxHost derived class because the Layout event is defined within the .NET Framework.  
  
 You can examine these generated files with tools such as [Ildasm.exe (IL Disassembler)](../../../docs/framework/tools/ildasm-exe-il-disassembler.md).  
  
 Using Aximp.exe to generate a .NET assembly for the ActiveX WebBrowser control (shdocvw.dll) is not supported.  
  
 When you run Aximp.exe over shdocvw.dll, it will always create another file named shdocvw.dll in the directory from which the tool is run. If this generated file is placed in the Documents and Settings directory, it causes problems for Microsoft Internet Explorer and Windows Explorer. When the computer is rebooted, Windows looks in the Documents and Settings directory before the system32 directory to find a copy of shdocvw.dll. It will use the copy it finds in Documents and Settings and attempt to load the managed wrappers. Internet Explorer and Windows Explorer will not function properly because they rely on the rendering engine in the version of shdocvw.dll located in the system32 directory. If this problem occurs, delete the copy of shdocvw.dll in the Documents and Settings directory and reboot the computer.  
  
 Using Aximp.exe with shdocvw.dll to create a .NET assembly for use in application development can also cause problems. In this case, your application will load both the system version of shdocvw.dll and the generated version, and may give the system version priority. In this case, when you attempt to load a Web page inside the WebBrowser ActiveX control, users may be prompted with an Open/Save dialog box. When the user clicks **Open**, the Web page will be opened in Internet Explorer. This occurs only with computers that are running Internet Explorer version 6 or earlier. To prevent this problem, use the managed <xref:System.Windows.Forms.WebBrowser> control or use [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] to generate the managed shdocvw.dll as described in [How to: Add References to Type Libraries](../../../docs/framework/interop/how-to-add-references-to-type-libraries.md).  
  
## Example  
 The following command generates MediaPlayer.dll and AxMediaPlayer.dll for the Media Player control `msdxm.ocx`.  
  
```  
aximp c:\systemroot\system32\msdxm.ocx  
```  
  
## See Also  
 [Tools](../../../docs/framework/tools/index.md)  
 [Ildasm.exe (IL Disassembler)](../../../docs/framework/tools/ildasm-exe-il-disassembler.md)
