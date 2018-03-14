---
title: "Certmgr.exe (Certificate Manager Tool)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "certificates, managing"
  - "CRLs"
  - "certificate trust lists"
  - "Certmgr.exe"
  - "Certificate Manager tool"
  - "CTLs"
  - "certificate revocation lists"
ms.assetid: 7e953b43-1374-4bbc-814f-53ca1b6b52bb
caps.latest.revision: 27
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Certmgr.exe (Certificate Manager Tool)
The Certificate Manager tool (Certmgr.exe) manages certificates, certificate trust lists (CTLs), and certificate revocation lists (CRLs).  
  
 The Certificate Manager is automatically installed with Visual Studio. To start the tool, use the [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md).  
  
> [!NOTE]
>  The Certificate Manager tool (Certmgr.exe) is a command-line utility, whereas Certificates (Certmgr.msc) is a Microsoft Management Console (MMC) snap-in. Because Certmgr.msc is usually found in the Windows System directory, entering `certmgr` at the command line may load the Certificates MMC snap-in even if you have opened the Visual Studio Command Prompt. This occurs because the path to the snap-in precedes the path to the Certificate Manager tool in the PATH environment variable. If you encounter this problem, you can execute Certmgr.exe commands by specifying the path to the executable.  
  
 This tool is automatically installed with Visual Studio. To run the tool, use the Developer Command Prompt (or the Visual Studio Command Prompt in Windows 7). For more information, see [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md).  
  
 For an overview of X.509 certificates, see [Working with Certificates](../../../docs/framework/wcf/feature-details/working-with-certificates.md).  
  
 At the command prompt, type the following:  
  
## Syntax  
  
```  
      certmgr [/add | /del | /put] [options]  
[/s[/r registryLocation]] [sourceStorename]  
[/s[/r registryLocation]] [destinationStorename]  
```  
  
#### Parameters  
  
|Argument|Description|  
|--------------|-----------------|  
|*sourceStorename*|The certificate store that contains the existing certificates, CTLs, or CRLs to add, delete, save, or display. This can be a store file or a systems store.|  
|*destinationStorename*|The output certificate store or file.|  
  
|Option|Description|  
|------------|-----------------|  
|**/add**|Adds certificates, CTLs, and CRLs to a certificate store.|  
|**/all**|Adds all entries when used with **/add**. Deletes all entries when used with **/del**. Displays all entries when used without the **/add** or **/del** options. The **/all** option cannot be used with **/put**.|  
|**/c**|Adds certificates when used with **/add**. Deletes certificates when used with **/del**. Saves certificates when used with **/put**. Displays certificates when used without the **/add**, **/del**, or **/put** option.|  
|**/CRL**|Adds CRLs when used with **/add**. Deletes CRLs when used with **/del**. Saves CRLs when used with **/put**. Displays CRLs when used without the **/add**, **/del**, or **/put** option.|  
|**/CTL**|Adds CTLs when used with **/add**. Deletes CTLs when used with **/del**. Saves CTLs when used with **/put**. Displays CTLs when used without the **/add**, **/del**, or **/put** option.|  
|**/del**|Deletes certificates, CTLs, and CRLs from a certificate store.|  
|**/e** *encodingType*|Specifies the certificate encoding type. The default is `X509_ASN_ENCODING`.|  
|**/f** *dwFlags*|Specifies the store open flag. This is the *dwFlags* parameter passed to **CertOpenStore**. The default value is CERT_SYSTEM_STORE_CURRENT_USER. This option is considered only if the **/y** option is used.|  
|**/h**[**elp**]|Displays command syntax and options for the tool.|  
|**/n** *nam*|Specifies the common name of the certificate to add, delete, or save. This option can only be used with certificates; it cannot be used with CTLs or CRLs.|  
|**/put**|Saves an X.509 certificate, CTL, or CRL from a certificate store to a file. The file is saved in X.509 format. You can use the **/7** option with the **/put** option to save the file in PKCS #7 format. The **/put** option must be followed by either **/c**, **/CTL**, or **/CRL**. The **/all** option cannot be used with **/put**.|  
|**/r** *location*|Identifies the registry location of the system store. This option is considered only if you specify the **/s** option. *location* must be one of the following:<br /><br /> -   `currentUser` indicates that the certificate store is under the HKEY_CURRENT_USER key. This is the default.<br />-   `localMachine` indicates that the certificate store is under the HKEY_LOCAL_MACHINE key.|  
|**/s**|Indicates that the certificate store is a system store. If you do not specify this option, the store is considered to be a **StoreFile**.|  
|**/sha1** *sha1Hash*|Specifies the SHA1 hash of the certificate, CTL, or CRL to add, delete, or save.|  
|**/v**|Specifies verbose mode; displays detailed information about certificates, CTLs, and CRLs. This option cannot be used with the **/add**, **/del**, or **/put** options.|  
|**/y** *provider*|Specifies the store provider name.|  
|**/7**|Saves the destination store as a PKCS #7 object.|  
|**/?**|Displays command syntax and options for the tool.|  
  
## Remarks  
 Certmgr.exe performs the following basic functions:  
  
-   Displays certificates, CTLs, and CRLs to the console.  
  
-   Adds certificates, CTLs, and CRLs to a certificate store.  
  
-   Deletes certificates, CTLs, and CRLs from a certificate store.  
  
-   Saves an X.509 certificate, CTL, or CRL from a certificate store to a file.  
  
 Certmgr.exe works with two types of certificate stores: **StoreFile** and system store. It is not necessary to specify the type of certificate store; Certmgr.exe can identify the store type and perform the appropriate operations.  
  
 Running Certmgr.exe without specifying any options launches the certmgr.msc snap-in, which has a GUI that helps with the certificate management tasks that are also available from the command line. The GUI provides an import wizard, which copies certificates, CTLs, and CRLs from your disk to a certificate store.  
  
 You can find the names of X509Certificate stores for the `sourceStorename` and `destinationStorename` parameters by compiling and running the following code.  
  
 [!code-csharp[Tools.CertMgr#1](../../../samples/snippets/csharp/VS_Snippets_CLR/tools.certmgr/cs/storenames1.cs#1)]
 [!code-vb[Tools.CertMgr#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/tools.certmgr/vb/storenames1.vb#1)]  
  
 For more information about certificates, see [Working with Certificates](../../../docs/framework/wcf/feature-details/working-with-certificates.md).  
  
## Examples  
 The following command displays a default system store called `my` with verbose output.  
  
```  
certmgr /v /s my  
```  
  
 The following command adds all the certificates in a file called `myFile.ext` to a new file called `newFile.ext`.  
  
```  
certmgr /add /all /c myFile.ext newFile.ext  
```  
  
 The following command adds the certificate in a file named `testcert.cer` to the `my` system store.  
  
```  
certmgr /add /c testcert.cer /s my  
```  
  
 The following command adds the certificate in a file named `TrustedCert.cer` to the root certificate store.  
  
```  
certmgr /c /add TrustedCert.cer /s root  
```  
  
 The following command saves a certificate with the common name `myCert` in the `my` system store to a file called `newCert.cer`.  
  
```  
certmgr /add /c /n myCert /s my newCert.cer  
```  
  
 The following command deletes all CTLs in the `my` system store and saves the resulting store to a file called `newStore.str`.  
  
```  
certmgr /del /all /ctl /s my newStore.str  
```  
  
 The following command saves a certificate in the `my` system store in the file `newFile`. You will be prompted to enter the certificate number from `my` to put in `newFile`.  
  
```  
certmgr /put /c /s my newFile  
```  
  
## See Also  
 [Tools](../../../docs/framework/tools/index.md)  
 [Makecert.exe (Certificate Creation Tool)](http://msdn.microsoft.com/library/b0343f8e-9c41-4852-a85c-f8a0c408cf0d)  
 [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md)
