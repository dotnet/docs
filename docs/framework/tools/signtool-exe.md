---
title: "SignTool.exe (Sign Tool)"
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
  - "Sign tool"
  - "SignTool.exe"
ms.assetid: 0c25ff6c-bff3-422e-b017-146a3ee86cb9
caps.latest.revision: 33
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# SignTool.exe (Sign Tool)
Sign Tool is a command-line tool that digitally signs files, verifies signatures in files, and time-stamps files.  
  
 This tool is automatically installed with Visual Studio. To run the tool, use the Developer Command Prompt (or the Visual Studio Command Prompt in Windows 7). For more information, see [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md).  
  
 At the command prompt, type the following:  
  
## Syntax  
  
```  
signtool [command] [options] [file_name | ...]  
```  
  
#### Parameters  
  
|Argument|Description|  
|--------------|-----------------|  
|`command`|One of four commands (`catdb`, `sign`, `Timestamp`, or `Verify`) that specifies an operation to perform on a file. For a description of each command, see the next table.|  
|`options`|An option that modifies a command. In addition to the global `/q` and `/v` options, each command supports a unique set of options.|  
|`file_name`|The path to a file to sign.|  
  
 The following commands are supported by Sign Tool. Each command is used with distinct sets of options, which are listed in their respective sections.  
  
|Command|Description|  
|-------------|-----------------|  
|`catdb`|Adds a catalog file to, or removes it from, a catalog database. Catalog databases are used for automatic lookup of catalog files and are identified by GUID. For a list of the options supported by the `catdb` command, see [catdb Command Options](../../../docs/framework/tools/signtool-exe.md#catdb).|  
|`sign`|Digitally signs files. Digital signatures protect files from tampering, and enable users to verify the signer based on a signing certificate. For a list of the options supported by the `sign` command, see [sign Command Options](../../../docs/framework/tools/signtool-exe.md#sign).|  
|`Timestamp`|Time-stamps files. For a list of the options supported by the `TimeStamp` command, see [TimeStamp Command Options](../../../docs/framework/tools/signtool-exe.md#TimeStamp).|  
|`Verify`|Verifies the digital signature of files by determining whether the signing certificate was issued by a trusted authority, whether the signing certificate has been revoked, and, optionally, whether the signing certificate is valid for a specific policy. For a list of the options supported by the `Verify` command, see [Verify Command Options](../../../docs/framework/tools/signtool-exe.md#Verify).|  
  
 The following options apply to all Sign Tool commands.  
  
|Global option|Description|  
|-------------------|-----------------|  
|**/q**|Displays no output if the command runs successfully, and displays minimal output if the command fails.|  
|**/v**|Displays verbose output regardless of whether the command runs successfully or fails, and displays warning messages.|  
|**/debug**|Displays debugging information.|  
  
<a name="catdb"></a>   
## catdb Command Options  
 The following table lists the options that can be used with the `catdb` command.  
  
|Catdb option|Description|  
|------------------|-----------------|  
|`/d`|Specifies that the default catalog database is updated. If neither the `/d` nor the `/g` option is used, Sign Tool updates the system component and driver database.|  
|`/g` *GUID*|Specifies that the catalog database identified by the globally unique identifier *GUID* is updated.|  
|`/r`|Removes the specified catalogs from the catalog database. If this option is not specified, Sign Tool adds the specified catalogs to the catalog database.|  
|`/u`|Specifies that a unique name is automatically generated for the added catalog files. If necessary, the catalog files are renamed to prevent name conflicts with existing catalog files. If this option is not specified, Sign Tool overwrites any existing catalog that has the same name as the catalog being added.|  
  
<a name="sign"></a>   
## sign Command Options  
 The following table lists the options that can be used with the `sign` command.  
  
|Sign command option|Description|  
|-------------------------|-----------------|  
|`/a`|Automatically selects the best signing certificate. Sign Tool will find all valid certificates that satisfy all specified conditions and select the one that is valid for the longest time. If this option is not present, Sign Tool expects to find only one valid signing certificate.|  
|`/ac`  *file*|Adds an additional certificate from *file* to the signature block.|  
|`/as`|Appends this signature. If no primary signature is present, this signature is made the primary signature instead.|  
|`/c`  *CertTemplateName*|Specifies the Certificate Template Name (a Microsoft extension) for the signing certificate.|  
|`/csp`  *CSPName*|Specifies the cryptographic service provider (CSP) that contains the private key container.|  
|`/d`  *Desc*|Specifies a description of the signed content.|  
|`/du`  *URL*|Specifies a Uniform Resource Locator (URL) for the expanded description of the signed content.|  
|`/f`  *SignCertFile*|Specifies the signing certificate in a file. If the file is in Personal Information Exchange (PFX) format and protected by a password, use the `/p` option to specify the password. If the file does not contain private keys, use the `/csp` and `/kc` options to specify the CSP and private key container name.|  
|`/fd`|Specifies the file digest algorithm to use for creating file signatures. The default is SHA1.|  
|`/i`  *IssuerName*|Specifies the name of the issuer of the signing certificate. This value can be a substring of the entire issuer name.|  
|`/kc`  *PrivKeyContainerName*|Specifies the private key container name.|  
|`/n`  *SubjectName*|Specifies the name of the subject of the signing certificate. This value can be a substring of the entire subject name.|  
|`/nph`|If supported, suppresses page hashes for executable files. The default is determined by the SIGNTOOL_PAGE_HASHES environment variable and by the wintrust.dll version. This option is ignored for non-PE files.|  
|`/p`  *Password*|Specifies the password to use when opening a PFX file. (Use the `/f` option to specify a PFX file.)|  
|`/p7` *Path*|Specifies that a Public Key Cryptography Standards (PKCS) #7 file is produced for each specified content file. PKCS #7 files are named *path*\\*filename*.p7.|  
|`/p7ce` *Value*|Specifies options for the signed PKCS #7 content. Set *Value* to "Embedded" to embed the signed content in the PKCS #7 file, or to "DetachedSignedData" to produce the signed data portion of a detached PKCS #7 file. If the `/p7ce` option is not used, the signed content is embedded by default.|  
|`/p7co` *\<OID>*|Specifies the object identifier (OID) that identifies the signed PKCS #7 content.|  
|`/ph`|If supported, generates page hashes for executable files.|  
|`/r`  *RootSubjectName*|Specifies the name of the subject of the root certificate that the signing certificate must chain to. This value may be a substring of the entire subject name of the root certificate.|  
|`/s`  *StoreName*|Specifies the store to open when searching for the certificate. If this option is not specified, the `My` store is opened.|  
|`/sha1`  *Hash*|Specifies the SHA1 hash of the signing certificate. The SHA1 hash is commonly specified when multiple certificates satisfy the criteria specified by the remaining switches.|  
|`/sm`|Specifies that a machine store, instead of a user store, is used.|  
|`/t`  *URL*|Specifies the URL of the time stamp server. If this option (or `/tr`) is not present, the signed file will not be time stamped. A warning is generated if time stamping fails. This option cannot be used with the `/tr` option.|  
|`/td`  *alg*|Used with the `/tr` option to request a digest algorithm used by the RFC 3161 time stamp server.|  
|`/tr`  *URL*|Specifies the URL of the RFC 3161 time stamp server. If this option (or `/t`) is not present, the signed file will not be time stamped. A warning is generated if time stamping fails. This option cannot be used with the `/t` option.|  
|`/u`  *Usage*|Specifies the enhanced key usage (EKU) that must be present in the signing certificate. The usage value can be specified by OID or string. The default usage is "Code Signing" (1.3.6.1.5.5.7.3.3).|  
|`/uw`|Specifies usage of "Windows System Component Verification" (1.3.6.1.4.1.311.10.3.6).|  
  
 For usage examples, see [Using SignTool to Sign a File](http://msdn.microsoft.com/library/windows/desktop/aa388170.aspx).  
  
<a name="TimeStamp"></a>   
## TimeStamp Command Options  
 The following table lists the options that can be used with the `TimeStamp` command.  
  
|TimeStamp option|Description|  
|----------------------|-----------------|  
|`/p7`|Time stamps PKCS #7 files.|  
|`/t`  *URL*|Specifies the URL of the time stamp server. The file being time stamped must have previously been signed. Either the `/t` or the `/tr` option is required.|  
|`/td`  *alg*|Requests a digest algorithm used by the RFC 3161 time stamp server. `/td` is used with the `/tr` option.|  
|`/tp` *index*|Time stamps the signature at *index*.|  
|`/tr`  *URL*|Specifies the URL of the RFC 3161 time stamp server. The file being time stamped must have previously been signed. Either the `/tr` or the `/t` option is required.|  
  
 For a usage example, see [Adding Time Stamps to Previously Signed Files](http://msdn.microsoft.com/library/windows/desktop/aa375542.aspx).  
  
<a name="Verify"></a>   
## Verify Command Options  
  
|Verify option|Description|  
|-------------------|-----------------|  
|`/a`|Specifies that all methods can be used to verify the file. First, the catalog databases are searched to determine whether the file is signed in a catalog. If the file is not signed in any catalog, Sign Tool attempts to verify the file's embedded signature. This option is recommended when verifying files that may or may not be signed in a catalog. Examples of these files include Windows files or drivers.|  
|`/ad`|Finds the catalog by using the default catalog database.|  
|`/ag` *CatDBGUID*|Finds the catalog in the catalog database that is identified by the *CatDBGUID*.|  
|`/all`|Verifies all signatures in a file that includes multiple signatures.|  
|`/as`|Finds the catalog by using the system component (driver) catalog database.|  
|`/c` *CatFile*|Specifies the catalog file by name.|  
|`/d`|Specifies that Sign Tool should print the description and the description URL.|  
|`/ds`  *Index*|Verifies the signature at a specified position.|  
|`/hash` (`SHA1`&#124;`SHA256`)|Specifies an optional hash algorithm to use when searching for a file in a catalog.|  
|`/kp`|Specifies that verification should be performed with the kernel-mode driver signing policy.|  
|`/ms`|Uses multiple verification semantics. This is the default behavior of a [WinVerifyTrust](http://msdn.microsoft.com/library/windows/desktop/aa388208.aspx) call on [!INCLUDE[win8](../../../includes/win8-md.md)] and above.|  
|`/o` *Version*|Verifies the file by operating system version. *Version* has the following form: *PlatformID*:*VerMajor*.*VerMinor*.*BuildNumber*. *PlatformID* represents the underlying value of a <xref:System.PlatformID> enumeration member. **Important:**  The use of the `/o` switch is recommended. If `/o` is not specified, SignTool.exe may return unexpected results. For example, if you do not include the `/o` switch, system catalogs that validate correctly on an older operating system may not validate correctly on a newer operating system.|  
|`/p7`|Verifies PKCS #7 files. No existing policies are used for PKCS #7 validation. The signature is checked and a chain is built for the signing certificate.|  
|`/pa`|Specifies that the Default Authenticode Verification Policy should be used. If the `/pa` option is not specified, Sign Tool uses the Windows Driver Verification Policy. This option cannot be used with the `catdb` options.|  
|`/pg` *PolicyGUID*|Specifies a verification policy by GUID. The *PolicyGUID* corresponds to the ActionID of the verification policy. This option cannot be used with the `catdb` options.|  
|`/ph`|Specifies that Sign Tool should print and verify page hash values.|  
|`/r` *RootSubjectName*|Specifies the name of the subject of the root certificate that the signing certificate must chain to. This value can be a substring of the entire subject name of the root certificate.|  
|`/tw`|Specifies that a warning should be generated if the signature is not time stamped.|  
  
 For usage examples, see [Using SignTool to Verify a File Signature](http://msdn.microsoft.com/library/windows/desktop/aa388171.aspx).  
  
## Return Value  
 Sign Tool returns one of the following exit codes when it terminates.  
  
|Exit code|Description|  
|---------------|-----------------|  
|0|Execution was successful.|  
|1|Execution has failed.|  
|2|Execution has completed with warnings.|  
  
## Examples  
 The following command adds the catalog file MyCatalogFileName.cat to the system component and driver database. The `/u` option generates a unique name if necessary to prevent replacing an existing catalog file named `MyCatalogFileName.cat`.  
  
```  
signtool catdb /v /u MyCatalogFileName.cat  
```  
  
 The following command signs a file automatically by using the best certificate.  
  
```  
signtool sign /a MyFile.exe  
```  
  
 The following command digitally signs a file by using a certificate stored in a password-protected PFX file.  
  
```  
signtool sign /f MyCert.pfx /p MyPassword MyFile.exe  
```  
  
 The following command digitally signs and time-stamps a file. The certificate used to sign the file is stored in a PFX file.  
  
```  
signtool sign /f MyCert.pfx /t http://timestamp.verisign.com/scripts/timstamp.dll MyFile.exe  
```  
  
 The following command signs a file by using a certificate located in the `My` store that has a subject name of `My Company Certificate`.  
  
```  
signtool sign /n "My Company Certificate" MyFile.exe  
```  
  
 The following command signs an ActiveX control and provides information that is displayed by Internet Explorer when the user is prompted to install the control.  
  
```  
Signtool sign /f MyCert.pfx /d: "MyControl" /du http://www.example.com/MyControl/info.html MyControl.exe  
```  
  
 The following command time-stamps a file that has already been digitally signed.  
  
```  
signtool timestamp /t http://timestamp.verisign.com/scripts/timstamp.dll MyFile.exe  
```  
  
 The following command verifies that a file has been signed.  
  
```  
signtool verify MyFile.exe  
```  
  
 The following command verifies a system file that may be signed in a catalog.  
  
```  
signtool verify /a SystemFile.dll  
```  
  
 The following command verifies a system file that is signed in a catalog named `MyCatalog.cat`.  
  
```  
signtool verify /c MyCatalog.cat SystemFile.dll  
```  
  
## See Also  
 [Tools](../../../docs/framework/tools/index.md)  
 [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md)
