---
title: "Mage.exe (Manifest Generation and Editing Tool)"
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
  - "Manifest Generation and Editing tool"
  - "Mage.exe"
ms.assetid: 77dfe576-2962-407e-af13-82255df725a1
caps.latest.revision: 68
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Mage.exe (Manifest Generation and Editing Tool)
The Manifest Generation and Editing Tool (Mage.exe) is a command-line tool that supports the creation and editing of application and deployment manifests. As a command-line tool, Mage.exe can be run from both batch scripts and other Windows-based applications, including [!INCLUDE[vstecasp](../../../includes/vstecasp-md.md)] applications.  
  
 You can also use MageUI.exe, a graphical application, instead of Mage.exe. For more information, see [MageUI.exe (Manifest Generation and Editing Tool, Graphical Client)](../../../docs/framework/tools/mageui-exe-manifest-generation-and-editing-tool-graphical-client.md).  
  
 This tool is automatically installed with Visual Studio. To run the tool, use the Developer Command Prompt (or the Visual Studio Command Prompt in Windows 7). For more information, see [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md).  
  
 Two versions of Mage.exe and MageUI.exe are included as a component of the [!INCLUDE[vs_dev10_long](../../../includes/vs-dev10-long-md.md)] setup. To see version information, run MageUI.exe, select **Help**, and select **About**. This documentation describes version 4.0.x.x of Mage.exe and MageUI.exe.  
  
 At the command prompt, type the following:  
  
## Syntax  
  
```  
Mage [commands] [commandOptions]  
```  
  
#### Parameters  
 The following table shows the commands supported by Mage.exe. For more information about the options supported by these commands, see [New and Update Command Options](#NewUpdate) and [Sign Command Options](#Sign).  
  
|Command|Description|  
|-------------|-----------------|  
|**-cc, ClearApplicationCache**|Clears the downloaded application cache of all online-only applications.|  
|**-n, -New** *fileType [newOptions]*|Creates a new file of the given type. Valid types are:<br /><br /> -   `Deployment`: Creates a new deployment manifest.<br />-   `Application`: Creates a new application manifest.<br /><br /> If you do not specify any additional parameters with this command, it will create a file of the appropriate type, with appropriate default tags and attribute values.<br /><br /> Use the **-ToFile** option (see in the following table) to specify the file name and path of the new file.<br /><br /> Use the **-FromDirectory** option (see in the following table) to create an application manifest with all of the assemblies for an application added to the \<dependency> section of the manifest.|  
|**-u, -Update** *[filePath] [updateOptions]*|Makes one or more changes to a manifest file. You do not have to specify the type of file that you are editing. Mage.exe will examine the file by using a set of heuristics and determine whether it is a deployment manifest or an application manifest.<br /><br /> If you have already signed a file with a certificate, **-Update** will remove the key signature block. This is because the key signature contains a hash of the file, and modifying the file renders the hash invalid.<br /><br /> Use the **-ToFile** option (see in the following table) to specify a new file name and path instead of overwriting the existing file.|  
|**-s, -Sign** `[signOptions]`|Uses a key pair or X509 certificate to sign a file. Signatures are inserted as XML elements inside of the files.<br /><br /> You must be connected to the Internet when signing a manifest that specifies a **-TimestampUri** value.|  
|**-h, -?, -Help** *[verbose]*|Describes all of the available commands and their options. Specify `verbose` to get detailed help.|  
  
<a name="NewUpdate"></a>   
## New and Update Command Options  
 The following table shows the options supported by the `-New` and `-Update` commands.  
  
|Options|Default Value|Applies To|Description|  
|-------------|-------------------|----------------|-----------------|  
|**-a, -Algorithm**|sha1RSA|Application manifests.<br /><br /> Deployment manifests.|Specifies the algorithm to generate dependency digests with. Value must be "sha256RSA" or "sha1RSA.<br /><br /> Use with the "-Update" option. This option is ignored when using the "-Sign" option|  
|**-appc, -AppCodeBase** `manifestReference`||Deployment manifests.|Inserts a URL or file path reference to the application manifest file. This value must be the full path to the application manifest.|  
|**-appm, -AppManifest** `manifestPath`||Deployment manifests.|Inserts a reference to a deployment's application manifest into its deployment manifest.<br /><br /> The file indicated by `manifestPath` must exist, or Mage.exe will issue an error. If the file referenced by `manifestPath` is not an application manifest, Mage.exe will issue an error.|  
|**-cf, -CertFile** `filePath`||All file types.|Specifies the location of an X509 digital certificate for signing a manifest. This option can be used in conjunction with the **-Password** option, if the certificate requires a password.|  
|**-ch, -CertHash** `hashSignature`||All file types.|The hash of a digital certificate stored in the personal certificate store of the client computer. This corresponds to the Thumbprint string of a digital certificate viewed in the Windows Certificates Console.<br /><br /> `hashSignature` can be either uppercase or lowercase, and can be supplied either as a single string, or with each octet of the Thumbprint separated by spaces and the entire Thumbprint enclosed in quotation marks.|  
|**-fd, -FromDirectory** `directoryPath`||Application manifests.|Populates the application manifest with descriptions of all assemblies and files found in `directoryPath`, including all subdirectories, where `directoryPath` is the directory that contains the application that you want to deploy. For each file in the directory, Mage.exe decides whether the file is an assembly or a static file. If it is an assembly, it adds a `<dependency>` tag and `installFrom` attribute to the application with the assembly's name, code base, and version. If it is a static file, it adds a `<file>` tag. Mage.exe will also use a simple set of heuristics to detect the main executable for the application, and will mark it as the ClickOnce application's entry point in the manifest.<br /><br /> Mage.exe will never automatically mark a file as a "data" file. You must do this manually. For more information, see [How to: Include a Data File in a ClickOnce Application](/visualstudio/deployment/how-to-include-a-data-file-in-a-clickonce-application).<br /><br /> Mage.exe also generates a hash for each file based on its size. ClickOnce uses these hashes to ensure that no one has tampered with the deployment's files since the manifest was created. If any of the files in your deployment change, you can run Mage.exe with the **-Update** command and the **-FromDirectory** option, and it will update the hashes and assembly versions of all referenced files.<br /><br /> **-FromDirectory** will include all files in all subdirectories found within `directoryPath`.<br /><br /> If you use **-FromDirectory** with the **-Update** command, Mage.exe will remove any files in the application manifest that no longer exist in the directory.|  
|**-if, -IconFile**  `filePath`||Application manifests.|Specifies the full path to an .ICO icon file. This icon appears beside your application name in the start menu, and in its Add-or-Remove Programs entry. If no icon is provided, a default icon is used.|  
|**-ip, -IncludeProviderURL**  `url`|true|Deployment manifests.|Indicates whether the deployment manifest includes the update location value set by **-ProviderURL**.|  
|**-i, -Install** `willInstall`|true|Deployment manifests.|Indicates whether or not the ClickOnce application should install onto the local computer, or whether it should run from the Web. Installing an application gives that application a presence in the Windows **Start** menu. Valid values are "true" or "t", and "false" or "f".<br /><br /> If you specify the **-MinVersion** option, and a user has a version less than **-MinVersion** installed, it will force the application to install, regardless of the value that you pass to **-Install**.<br /><br /> This option cannot be used with the **-BrowserHosted** option. Attempting to specify both for the same manifest will result in an error.|  
|**-mv, -MinVersion**  `[version]`|The version listed in the ClickOnce deployment manifest as specified by the **-Version** flag.|Deployment manifests.|The minimum version of this application a user can run. This flag makes the named version of your application a required update. If you release a version of your product with an update to a breaking change or a critical security flaw, you can use this flag to specify that this update must be installed, and that the user cannot continue to run earlier versions.<br /><br /> `version` has the same semantics as the argument to the **-Version** flag.|  
|**-n, -Name** `nameString`|Deploy|All file types.|The name that is used to identify the application. ClickOnce will use this name to identify the application in the **Start** menu (if the application is configured to install itself) and in Permission Elevation dialog boxes. **Note:**  If you are updating an existing manifest and you do not specify a publisher name with this option, Mage.exe updates the manifest with the organization name defined on the computer. To use a different name, make sure to use this option and specify the desired publisher name.|  
|**-pwd, -Password** `passwd`||All file types.|The password that is used for signing a manifest with a digital certificate. Must be used in conjunction with the **-CertFile** option.|  
|**-p, Processor** `processorValue`|Msil|Application manifests.<br /><br /> Deployment manifests.|The microprocessor architecture on which this distribution will run. This value is required if you are preparing one or more installations whose assemblies have been precompiled for a specific microprocessor. Valid values include `msil`, `x86`, `ia64`, and `amd64`. `msil` is Microsoft intermediate language, which means all of your assemblies are platform-independent, and the common language runtime (CLR) will just-in-time compile them when your application is first run.|  
|**-pu,** **-ProviderURL** `url`||Deployment manifests.|Specifies the URL which ClickOnce will examine for application updates.|  
|**-pub, -Publisher** `publisherName`||Application manifests.<br /><br /> Deployment manifests.|Adds the publisher name to the description element of either the deployment or application manifest. When used on an application manifest, **-UseManifestForTrust** must also be specified with a value of "true" or "t"; otherwise, this parameter will raise an error.|  
|**-s, -SupportURL**  `url`||Application manifests.<br /><br /> Deployment manifests.|Specifies the link that appears in Add or Remove Programs for the ClickOnce application.|  
|**-ti, -TimestampUri** `uri`||Application manifests.<br /><br /> Deployment manifests.|The URL of a digital timestamping service. Timestamping the manifests prevents you from having to re-sign the manifests should your digital certificate expire before you deploy the next version of your application. For more information, see [Windows root certificate program members](http://go.microsoft.com/fwlink/?LinkId=159000).|  
|**-t, -ToFile** `filePath`|-   New:<br />-   Deployment: deploy.application<br />-   Application: application.exe.manifest<br />-   Update:<br />-   The input file.|All file types.|Specifies the output path of the file that has been created or modified.<br /><br /> If **-ToFile** is not supplied when you use **-New**, the output is written to the current working directory. If **-ToFile** is not supplied when you use **-Update**, Mage.exe will write the file back to the input file.|  
|**-tr, -TrustLevel** `level`|Based on the zone in which the application URL resides.|Application manifests.|The level of trust to grant the application on client computers. Values include "Internet", "Intranet", and "FullTrust".|  
|**-um, -UseManifestForTrust** `willUseForTrust`|False|Application manifests.|Specifies whether the digital signature of the application manifest will be used for making trust decisions when the application runs on the client. Specifying "true" or "t" indicates that the application manifest will be used for trust decisions. Specifying "false" or "f" indicates that the signature of the deployment manifest will be used.|  
|**-v, -Version** `versionNumber`|1.0.0.0|Application manifests.<br /><br /> Deployment manifests.|The version of the deployment. The argument must be a valid version string of the format "*N.N.N.N*", where "*N*" is an unsigned 32-bit integer.|  
|**-wpf, -WPFBrowserApp**  `isWPFApp`|false|Application manifests.<br /><br /> Deployment manifests.|Use this flag only if the application is a Windows Presentation Foundation (WPF) application that will be hosted inside of Internet Explorer, and is not a stand-alone executable. Valid values are "true" or "t", and "false" or "f".<br /><br /> For application manifests, inserts the `hostInBrowser` attribute under the `entryPoint` element of the application manifest.<br /><br /> For deployment manifests, sets the `install` attribute on the `deployment` element to false, and saves the deployment manifest with a .xbap extension. Specifying this argument along with the **-Install** argument produces an error, because a browser-hosted application cannot be an installed, offline application.|  
  
<a name="Sign"></a>   
## Sign Command Options  
 The following table shows the options supported by the `-Sign` command, which apply to all types of files.  
  
|Options|Description|  
|-------------|-----------------|  
|**-cf, -CertFile** `filePath`|Specifies The location of a digital certificate for signing a manifest. This option can be used in conjunction with the **-Password** option.|  
|**-ch, -CertHash** `hashSignature`|The hash of a digital certificate stored in the personal certificate store of the client computer. This corresponds to the Thumbprint property of a digital certificate viewed in the Windows Certificates Console.<br /><br /> `hashSignature` can be either uppercase or lowercase, and can be supplied either as a single string or with each octet of the Thumbprint separated by spaces and the entire Thumbprint enclosed in quotation marks.|  
|**-pwd, -Password** `passwd`|The password that is used for signing a manifest with a digital certificate. Must be used in conjunction with the **-CertFile** option.|  
|**-t, -ToFile** `filePath`|Specifies the output path of the file that has been created or modified.|  
  
## Remarks  
 All arguments to Mage.exe are case-insensitive. Commands and options can be prefixed with a dash (-) or a forward slash (/).  
  
 All of the arguments used with the **-Sign** command can be used at any time with the **-New** or **-Update** commands as well. The following commands are equivalent.  
  
```  
mage -Sign c:\HelloWorldDeployment\HelloWorld.deploy -CertFile cert.pfx  
mage -Update c:\HelloWorldDeployment\HelloWorld.deploy -CertFile cert.pfx  
```  
  
> [!NOTE]
>  Beginning with .NET Framework version 4.6.2, CNG certificates are also supported.  
  
 Signing is the last task you should perform, because a signed document uses a hash of the file to verify that the signature is valid for the document. If you make any changes to a signed file, you must sign it again. If you sign a document that was previously signed, Mage.exe will replace the old signature with the new.  
  
 When you use the **-AppManifest** option to populate a deployment manifest, Mage.exe will assume that your application manifest will reside in the same directory as the deployment manifest within a subdirectory named after the current deployment version, and will configure your deployment manifest appropriately. If your application manifest will reside elsewhere, use the **-AppCodeBase** option to set the alternate location.  
  
 Your deployment and application manifest must be signed before you deploy your application. For guidance about signing manifests, see [Trusted Application Deployment Overview](/visualstudio/deployment/trusted-application-deployment-overview).  
  
 The **-TrustLevel** option for application manifests describes the permission set an application requires to run on the client computer. By default, applications are assigned a trust level based on the *zone* in which their URL resides. Applications deployed over a corporate network are generally placed in the Intranet zone, while those deployed over the Internet are placed in the Internet zone. Both security zones place restrictions on the application's access to local resources, with the Intranet zone slightly more permissive than the Internet zone. The FullTrust zone gives applications complete access to a computer's local resources. If you use the **-TrustLevel** option to place an application in this zone, the Trust Manager component of the CLR will prompt the user to decide whether he or she wants to grant this higher level of trust. If you are deploying your application over a corporate network, you can use Trusted Application Deployment to raise the trust level of the application without prompting the user.  
  
 Application manifests also support custom trust sections. This helps your application obey the security principle of requesting least permission, as you can configure the manifest to demand only those specific permissions that the application requires in order to execute. Mage.exe does not directly support adding a custom trust section. You can add one using a text editor, an XML parser, or the graphical tool MageUI.exe. For more information about how to use MageUI.exe to add custom trust sections, see [MageUI.exe (Manifest Generation and Editing Tool, Graphical Client)](../../../docs/framework/tools/mageui-exe-manifest-generation-and-editing-tool-graphical-client.md).  
  
 New manifests that are created with version 4 of Mage.exe, which is included with [!INCLUDE[vs_dev10_long](../../../includes/vs-dev10-long-md.md)], target the [!INCLUDE[net_client_v40_long](../../../includes/net-client-v40-long-md.md)]. To target earlier versions of the .NET Framework, you must use an earlier version of Mage.exe. When adding or removing assemblies from an existing manifest, or re-signing an existing manifest, Mage.exe does not update the manifest to target the [!INCLUDE[net_client_v40_long](../../../includes/net-client-v40-long-md.md)]. The following tables show these features and restrictions.  
  
|Manifest version|Operation|Mage v2.0|Mage v4.0|  
|----------------------|---------------|---------------|---------------|  
|Manifest for applications targeting version 2.0 or 3.x of the .NET Framework|Open|OK|OK|  
||Close|OK|OK|  
||Save|OK|OK|  
||Re-sign|OK|OK|  
||New|OK|Not supported|  
||Update (see below)|OK|OK|  
|Manifest for applications targeting version 4 of the .NET Framework|Open|OK|OK|  
||Close|OK|OK|  
||Save|OK|OK|  
||Re-sign|OK|OK|  
||New|Not supported|OK|  
||Update (see below)|Not supported|OK|  
  
|Manifest version|Update Operation Details|Mage v2.0|Mage v4.0|  
|----------------------|------------------------------|---------------|---------------|  
|Manifest for applications targeting version 2.0 or 3.x of the .NET Framework|Modify an assembly|OK|OK|  
||Add an assembly|OK|OK|  
||Remove an assembly|OK|OK|  
|Manifest for applications targeting version 4 of the .NET Framework|Modify an assembly|Not supported|OK|  
||Add an assembly|Not supported|OK|  
||Remove an assembly|Not supported|OK|  
  
 Mage.exe creates new manifests that target the [!INCLUDE[net_client_v40_long](../../../includes/net-client-v40-long-md.md)]. ClickOnce applications that target the [!INCLUDE[net_client_v40_long](../../../includes/net-client-v40-long-md.md)] can run on both the [!INCLUDE[net_client_v40_long](../../../includes/net-client-v40-long-md.md)] and the full version of the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)]. If your application targets the full version of the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)] and cannot run on the [!INCLUDE[net_client_v40_long](../../../includes/net-client-v40-long-md.md)], remove the client `<framework>` element by using a text editor and re-sign the manifest. The following is a sample `<framework>` element that targets the [!INCLUDE[net_client_v40_long](../../../includes/net-client-v40-long-md.md)].  
  
```xml  
<framework targetVersion="4.0" profile="client" supportedRuntime="4.0.20506" />  
```  
  
## Examples  
 The following example opens the user interface for Mage (MageUI.exe).  
  
```  
mage  
```  
  
 The following examples create a default deployment manifest and application manifest. These files are all created in the current working directory and are named deploy.application and application.exe.manifest, respectively.  
  
```  
mage -New Deployment  
mage -New Application  
```  
  
 The following example creates an application manifest populated with all of the assemblies and resource files from thecurrent directory.  
  
```  
mage -New Application -FromDirectory . -Version 1.0.0.0  
```  
  
 The following example continues the previous example by specifying the deployment name and target microprocessor. It also specifies a URL against which ClickOnce should check for updates.  
  
```  
mage -New Application -FromDirectory . -Name "Hello, World! Application" -Version 1.0.0.0 -Processor "x86" -ProviderUrl http://internalserver/HelloWorld/  
```  
  
 The following example demonstrates how to create a pair of manifests for deploying a WPF application that will be hosted in Internet Explorer.  
  
```  
mage -New Application -FromDirectory . -Version 1.0.0.0 -WPFBrowserApp true  
mage -New Deployment -AppManifest 1.0.0.0\application.manifest -WPFBrowserApp true  
```  
  
 The following example updates a deployment manifest with information from an application manifest, and sets the code base for the location of the application manifest.  
  
```  
mage -Update HelloWorld.deploy -AppManifest 1.0.0.0\application.manifest -AppCodeBase http://internalserver/HelloWorld.deploy  
```  
  
 The following example edits the deployment manifest to force an update of the user's installed version.  
  
```  
mage -Update c:\HelloWorldDeployment\HelloWorld.deploy -MinVersion 1.1.0.0  
```  
  
 The following example tells the deployment manifest to retrieve the application manifest from another directory.  
  
```  
mage -Update HelloWorld.deploy -AppCodeBase http://anotherserver/HelloWorld/1.1.0.0/  
```  
  
 The following example signs an existing deployment manifest using a digital certificate in the current working directory.  
  
```  
mage -Sign deploy.application -CertFile cert.pfx -Password <passwd>  
```  
  
## See Also  
 [ClickOnce Security and Deployment](/visualstudio/deployment/clickonce-security-and-deployment)  
 [Walkthrough: Manually Deploying a ClickOnce Application](/visualstudio/deployment/walkthrough-manually-deploying-a-clickonce-application)  
 [Trusted Application Deployment Overview](/visualstudio/deployment/trusted-application-deployment-overview)  
 [MageUI.exe (Manifest Generation and Editing Tool, Graphical Client)](../../../docs/framework/tools/mageui-exe-manifest-generation-and-editing-tool-graphical-client.md)  
 [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md)
