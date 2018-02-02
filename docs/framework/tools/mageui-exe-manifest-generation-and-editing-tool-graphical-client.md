---
title: "MageUI.exe (Manifest Generation and Editing Tool, Graphical Client)"
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
  - "MageUI.exe"
ms.assetid: f9e130a6-8117-49c4-839c-c988f641dc14
caps.latest.revision: 38
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# MageUI.exe (Manifest Generation and Editing Tool, Graphical Client)
MageUI.exe supports the same functionality as the command-line tool Mage.exe, but with a Windows-based user interface (UI). With this tool you can create, edit, and sign deployment and application manifests. New manifests that are created with MageUI.exe target the [!INCLUDE[net_client_v40_long](../../../includes/net-client-v40-long-md.md)]. Previous versions of MageUI.exe should be used to target previous .NET Framework versions. When adding or removing assemblies from a manifest, or re-signing existing manifests, MageUI.exe does not update the manifest to target [!INCLUDE[net_client_v40_long](../../../includes/net-client-v40-long-md.md)]. For more information, see [Mage.exe (Manifest Generation and Editing Tool)](../../../docs/framework/tools/mage-exe-manifest-generation-and-editing-tool.md).  
  
 This tool is automatically installed with Visual Studio. To run the tool, use the Developer Command Prompt (or the Visual Studio Command Prompt in Windows 7). For more information, see [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md).  
  
 Two versions of Mage.exe and MageUI.exe are included as a component of the [!INCLUDE[vs_dev10_long](../../../includes/vs-dev10-long-md.md)] setup. To see version information, run MageUI.exe, select **Help**, and select **About**. This documentation describes version 4.0.x.x of Mage.exe and MageUI.exe.  
  
> [!NOTE]
>  MageUI.exe does not support the [compatibleFrameworks](/visualstudio/deployment/compatibleframeworks-element-clickonce-deployment) element when saving an application manifest that has already been signed with a certificate using MageUI.exe. Instead, you must use [Mage.exe](../../../docs/framework/tools/mage-exe-manifest-generation-and-editing-tool.md).  
  
## UIElement List  
 The following table lists the menu and toolbar items that are available.  
  
|Command|Menu|Shortcut|Description|  
|-------------|----------|--------------|-----------------|  
|**Application Manifest**|**File, New**||Creates a new application manifest.|  
|**Deployment Manifest**|**File, New**||Creates a new deployment manifest.|  
|**Open**|**File**|CTRL+O|Opens an existing deployment manifest, application manifest, or trust license for editing.|  
|**Close**|**File**|CTRL+F4|Closes an open file.<br /><br /> If you modify a file before closing it, MageUI.exe prompts you to re-sign the file with a public key, key pair, or stored certificate.|  
|**Save**|**File**|CTRL+S|Saves to disk the document which currently has user input focus.|  
|**Save As**|**File**||Saves a file to disk, enabling you to supply a new file name and/or location.|  
|**Save All**|**File**||Saves the changes made to all files currently open within MageUI.exe.|  
|**Preferences**|**File**||Opens the **Preferences** dialog box. See the following section for more information.|  
|**Exit**|**File**|ALT+F4|Quits MageUI.exe.|  
|**Cut**|**Edit**|CTRL+X|Removes the currently selected text from the application and moves it to the system Clipboard.|  
|**Copy**|**Edit**|CTRL+C|Copies the currently selected text to the system Clipboard.|  
|**Paste**|**Edit**|CTRL+V|Pastes text from the system Clipboard into the currently active text element.|  
|**Delete**|**Edit**||Deletes an element currently selected in a list, such as a trust license on the **Deployment Manifest** tab.|  
|**Close All**|**Window**||Closes all files currently open in MageUI.exe. If one or more files need saving, MageUI.exe prompts you to save them. MageUI.exe also prompts you to select a signing key for each unsigned or changed file.|  
|**About**|**Help**||Displays version and copyright information about MageUI.exe.|  
  
## Preferences Dialog Box  
 The **Preferences** dialog box contains the following elements.  
  
|UI Element|Description|  
|----------------|-----------------|  
|**Sign on save**|Prompts you to sign a file whenever you save your modifications.|  
|**Use default signing certificate**|Uses the key entered in the **Certificate file** text box to sign all files. This eliminates the signing prompt that typically appears when you save a file and **Sign on Save** is selected. Use the ellipsis (**…**) button next to the **Certificate file** text box to select a key file.|  
|Digest algorithm|Specifies the algorithm to generate dependency digests with. Value must be "sha256RSA" or "sha1RSA". Uses SHA1 as the default. Used both in application and deployment manifests. If the user provides a certificate when saving the manifest, uses the algorithms in the certificate to generate dependency digests with.|  
  
## Signing Options Dialog Box  
 The **Signing Options** dialog box appears when you save a manifest or trust license for the first time, or when you change a manifest or trust license. It only appears if the **Sign on Save** option in the **Preferences** dialog box is selected. You must be connected to the Internet when signing a manifest that specifies a value in the **TimeStamping URI** text box.  
  
 This dialog box contains the following elements.  
  
|UI Element|Description|  
|----------------|-----------------|  
|**Sign with certificate file**|Signs the manifest with a digital certificate stored on the file system.|  
|**File**|Provides an area to type the path to the .pfx file representing the certificate.|  
|**...**|Opens a **Choose File** dialog box for selecting an existing .pfx file.|  
|**New**|Generates a new .pfx that is not verifiable through a Certificate Authority (CA). For more information about the types of certificates used for signing [!INCLUDE[ndptecclick](../../../includes/ndptecclick-md.md)] deployments, see [Trusted Application Deployment Overview](/visualstudio/deployment/trusted-application-deployment-overview).|  
|**Password**|Provides an area to type the password used for signing with this certificate. If not applicable, can be left blank.|  
|**Sign with stored certificate**|Displays a selectable list of digital certificates stored in your computer's certificate store.|  
|**TimeStamping URI**|Displays the Uniform Resource Locator (URI) of a digital timestamping service. Timestamping the manifests prevents you from having to re-sign the manifests if your digital certificate expires before you deploy the next version of your application. For more information, see [Windows root certificate program members](http://go.microsoft.com/fwlink/?LinkId=159000) and [ClickOnce and Authenticode](/visualstudio/deployment/clickonce-and-authenticode).|  
|**Don't Sign**|Allows you to save the manifest without adding a signature from a digital certificate.|  
  
## Tab and Panel Descriptions  
 When you open a document with MageUI.exe, it appears within its own tab page. Each tab contains a set of property panels. The panels contain grouped subsets of the document's data.  
  
### Application Manifest Tab  
 The **Application Manifest** tab displays the contents of an application manifest. The application manifest describes all files included with the deployment, and the permissions required for the application to run on the client.  
  
 The **Application Manifest** tab contains the following tabs.  
  
|UI Element|Description|  
|----------------|-----------------|  
|**Name**|Specifies identifying information about this deployment.|  
|**Description**|Specifies publisher, product, and support information.|  
|**Application Options**|Specifies whether this is a browser application, and whether this manifest is the source of trust information.|  
|**Files**|Specifies all of the files that constitute this deployment.|  
|**Permissions Required**|Specifies the minimum permission set required by the application to run on a client.|  
  
### Name Tab  
 The **Name** tab is displayed when you first create or open an application manifest. It uniquely identifies the deployment, and optionally specifies a valid target platform.  
  
|UI Element|Description|  
|----------------|-----------------|  
|**Name**|Required. The name of the application manifest. Usually the same as the file name.|  
|**Version**|Required. The version number of the deployment in the form *N.N.N.N*. Only the first major build number is required. For example, for version 1.0 of an application, valid values would include `1`, `1.0`, `1.0.0`, and `1.0.0.0`.|  
|**Processor**|Optional. The machine architecture on which this deployment can run. The default is `msil`, or Microsoft Intermediate Language, which is the default format of all managed assemblies. Change this field if you have pre-compiled the assemblies in your application for a specific architecture. For more information about pre-compilation, see [Ngen.exe (Native Image Generator)](../../../docs/framework/tools/ngen-exe-native-image-generator.md).|  
|**Culture**|Optional. The two-part ISO country and region code in which this application runs. The default is `neutral`.|  
|**Public key token**|Optional. The public key with which this application manifest has been signed. If this is a new or unsigned manifest, this field will appear as `Unsigned`.|  
  
### Description Tab  
 This information is usually provided within the deployment manifest. These fields can only be modified if the **Use Application Manifest Trust Information** check box is selected on the **Application Options** tab.  
  
|UI Element|Description|  
|----------------|-----------------|  
|**Publisher**|The name of the person or organization responsible for the application. This value is used as the Start menu folder name.|  
|**Product**|The full product name. If you selected **Install Locally** for the **Application Type** element on the **Deployment Options** tab of the deployment manifest, this name will be what appears in the **Start** menu link and in **Add or Remove Programs** for this application.|  
|**Support Location**|The URL from which customers can obtain help and support for the application.|  
  
### Application Options Tab  
  
|UI Element|Description|  
|----------------|-----------------|  
|**Windows Presentation Foundation Browser Application**|Specifies whether this is a WPF application that runs in the browser as a XAML browser application (XBAP).|  
|**Use Application Manifest Trust Information**|Specifies whether this manifest contains trust information.|  
  
### Files Tab  
  
|UI Element|Description|  
|----------------|-----------------|  
|**Application directory**|The directory in which the application's files reside. Use the ellipses (**…**) button to select the directory.|  
|**Populate**|Adds all of the files in the application directory and subdirectories to the application manifest. If MageUI.exe finds a single executable file in the directory, it automatically marks this as the Entry Point, which is the file first executed when the ClickOnce application is launched on the client.|  
|**Application Files**|Lists all of the files in the application. Each file has three editable attributes, discussed below.|  
|**File Type**|File Type can be one of four values:<br /><br /> -   None.<br />-   Entry Point. The application's primary executable. Only one executable file can be marked as the entry point.<br />-   Data File. A file, such as an XML file, that supplies data to the application.<br />-   Icon File. An application icon, such as appears on the desktop or in the corner of an application's window.|  
|**Optional**|Files marked optional are not downloaded on initial install or update, but may be downloaded at run time using the System.Deployment On-Demand API. For more information, see [Walkthrough: Downloading Assemblies on Demand with the ClickOnce Deployment API Using the Designer](/visualstudio/deployment/walkthrough-downloading-assemblies-on-demand-with-the-clickonce-deployment-api-using-the-designer).|  
|**Group**|A label for a set of optional files. You can apply a Group label to a set of files, and use the On-Demand API to download a batch of files with a single API call.|  
  
### Permissions Required Tab  
 Use the **Permissions Required** tab if you need to grant your application more access to the local computer than is granted by default. For more information, see [Securing ClickOnce Applications](/visualstudio/deployment/securing-clickonce-applications).  
  
|UI Element|Description|  
|----------------|-----------------|  
|**Permission set type**|The minimum permission set required by this application to run on the client. For a description of these permission sets and which permissions they do or do not demand, see [NIB: Named Permission Sets](http://msdn.microsoft.com/library/08250d67-c99d-4ab0-8d2b-b0e12019f6e3).|  
|**Details**|The XML created for the application manifest to represent the permission set. Unless you have a good understanding of the application manifest XML format, you should not edit this XML manually. For more information, see [ClickOnce Application Manifest](/visualstudio/deployment/clickonce-application-manifest).|  
  
### Deployment Manifest Tab  
 The **Deployment Manifest** tab contains the following tabs.  
  
|UI Element|Description|  
|----------------|-----------------|  
|**Name**|Specifies identifying information about this deployment.|  
|**Description**|Specifies publisher, product, and support information.|  
|**Deployment Options**|Specifies additional information about the deployment, such as the application type and the start location.|  
|**Update Options**|Specifies how often [!INCLUDE[ndptecclick](../../../includes/ndptecclick-md.md)] should check for application updates.|  
|**Application Reference**|Specifies the application manifest for this deployment.|  
  
### Name Tab  
 The **Name** tab is displayed when you first create or open a deployment manifest. It uniquely identifies the deployment, and optionally specifies a valid target platform.  
  
|UI Element|Description|  
|----------------|-----------------|  
|**Name**|Required. The name of the deployment manifest. Usually the same as the file name.|  
|**Version**|Required. The version number of the deployment in the form *N.N.N.N*. Only the first major build number is required. For example, for version 1.0 of an application, valid values would include `1`, `1.0`, `1.0.0`, and `1.0.0.0`.|  
|**Processor**|Optional. The machine architecture on which this deployment can run. The default is `msil`, or Microsoft Intermediate Language, the default format of all managed assemblies. Change this field if you have compiled the assemblies in your application for a specific architecture.|  
|**Culture**|Optional. The two-part ISO country/region code in which this application runs. The default is `neutral`.|  
|**Public key token**|Optional. The public key with which this deployment manifest has been signed. If this is a new or unsigned manifest, this field will appear as `Unsigned`.|  
  
### Description Tab  
  
|UI Element|Description|  
|----------------|-----------------|  
|**Publisher**|Required. The name of the person or organization responsible for the application. This value is used as the Start menu folder name.|  
|**Product**|Required. The full product name. If you selected **Install Locally** for the **Application Type** element on the **Deployment Options** tab, this name will be what appears in the **Start** menu link and in **Add or Remove Programs** for this application.|  
|**Support Location**|Optional. The URL from which customers can obtain help and support for the application.|  
  
### Deployment Options Tab  
  
|UI Element|Description|  
|----------------|-----------------|  
|**Application Type**|Optional. Specifies whether this application installs itself to the client computer (**Install Locally**), runs online (**Online Only**), or is a WPF application that runs in the browser (**WPF Browser Application**). The default is **Install Locally**.|  
|**Start Location**|Optional. The URL from which the application should actually be started. Useful when deploying an application from a CD that should update itself from the Web.|  
|**Include Start Location (ProviderURL) in the manifest**|Optional. Specifies the URL which [!INCLUDE[ndptecclick](../../../includes/ndptecclick-md.md)] will examine for application updates.|  
|**Automatically run application after installing**|Required. Specifies that the [!INCLUDE[ndptecclick](../../../includes/ndptecclick-md.md)] application should run immediately after the initial installation from a URL. The default is the check box is selected.|  
|**Allow URL parameters to be passed to application**|Required. Permits the transfer of parameter data to the [!INCLUDE[ndptecclick](../../../includes/ndptecclick-md.md)] application through a query string appended to the deployment manifest's URL. The default is the check box is cleared.|  
|**Use .deploy file extension**|Required. When selected, all files in the application manifest must have the .deploy extension. The default is the check box is cleared.|  
  
### Update Options Tab  
 The **Update Options** tab only contains options mentioned here when the **Application Type** selection box on the **Name** tab is set to **Install Locally**.  
  
|UI Element|Description|  
|----------------|-----------------|  
|**This application should check for updates**|Specifies whether [!INCLUDE[ndptecclick](../../../includes/ndptecclick-md.md)] should check for application updates. If this check box is not selected, the application will not check for updates unless you update it programmatically by using the APIs in the <xref:System.Deployment.Application> namespace.|  
|**Choose when the application should check for updates**|Provides two options for update checks:<br /><br /> -   **Before the application starts**. The update check is performed prior to application execution.<br />-   **After the application starts**. The update check begins once the main form of the application has initialized, and will run the next time the application starts.|  
|**Update check frequency**|Determines how often [!INCLUDE[ndptecclick](../../../includes/ndptecclick-md.md)] should check for updates:<br /><br /> -   **Check every time the application runs**. [!INCLUDE[ndptecclick](../../../includes/ndptecclick-md.md)] will perform an update check every time the user opens the application.<br />-   **Check every**: Select a time interval and a unit (hours, days, or weeks) that must elapse before checking for updates.|  
|**Specify a minimum required version for this application**|Optional. Specifies that a specific version of your application is a required installation, preventing your users from working with an earlier version.|  
|**Version**|Required if **Specify a minimum required version for this application** check box is selected. The version number supplied must be of the form *N.N.N.N*. Only the first major build number is required. For example, for version 1.0 of an application, valid values would include `1`, `1.0`, `1.0.0`, and `1.0.0.0`.|  
  
### Application Reference Tab  
 The **Application Reference** tab contains the same fields as the **Name** tab described earlier in this topic. The one exception is the following field.  
  
|UI Element|Description|  
|----------------|-----------------|  
|**Select Manifest**|Allows you to choose the application manifest. All of the other fields on this page will populate when you choose an application manifest.|  
  
## See Also  
 [ClickOnce Security and Deployment](/visualstudio/deployment/clickonce-security-and-deployment)  
 [Walkthrough: Manually Deploying a ClickOnce Application](/visualstudio/deployment/walkthrough-manually-deploying-a-clickonce-application)  
 [Mage.exe (Manifest Generation and Editing Tool)](../../../docs/framework/tools/mage-exe-manifest-generation-and-editing-tool.md)
