---
title: "Cert2spc.exe (Software Publisher Certificate Test Tool)"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "SPC"
  - "Software Publisher Certificate Test tool"
  - "Software Publisher Certificate"
  - "Cert2spc.exe"
  - "certificates, Software Publisher's Certificate"
ms.assetid: be434d7d-9c0d-46e7-8392-58a9b542d11d
author: "rpetrusha"
ms.author: "ronpet"
---
# Cert2spc.exe (Software Publisher Certificate Test Tool)
The Software Publisher Certificate Test tool creates a Software Publisher's Certificate (SPC) from one or more X.509 certificates. Cert2spc.exe is for test purposes only. You can obtain a valid SPC from a Certification Authority such as VeriSign or Thawte. For more information about creating X.509 certificates, see [Makecert.exe (Certificate Creation Tool)](/windows/desktop/SecCrypto/makecert).  
  
 This tool is automatically installed with Visual Studio. To run the tool, use the Developer Command Prompt (or the Visual Studio Command Prompt in Windows 7). For more information, see [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md).  
  
 At the command prompt, type the following:  
  
## Syntax  
  
```  
cert2spc cert1.cer | crl1.crl [... certN.cer | crlN.crl] outputSPCfile.spc  
```  
  
#### Parameters  
  
|Argument|Description|  
|--------------|-----------------|  
|`certN.cer`|The name of an X.509 certificate to include in the SPC file. You can specify multiple names separated by spaces.|  
|`crlN.crl`|The name of a certificate revocation list to include in the SPC file. You can specify multiple names separated by spaces.|  
|`outputSPCfile.spc`|The name of the PKCS #7 object that will contain the X.509 certificates.|  
  
|Option|Description|  
|------------|-----------------|  
|**/?**|Displays command syntax and options for the tool.|  
  
## Examples  
 The following command creates an SPC from `myCertificate.cer` and places it in `mySPCFile.spc`.  
  
```  
cert2spc myCertificate.cer mySPCFile.spc  
```  
  
 The following command creates an SPC from `oneCertificate.cer` and `twoCertificate.cer`, and places it in `mySPCFile.spc`.  
  
```  
cert2spc oneCertificate.cer twoCertificate.cer mySPCFile.spc  
```  
  
## See Also  
 [Tools](../../../docs/framework/tools/index.md)  
 [Makecert.exe (Certificate Creation Tool)](/windows/desktop/SecCrypto/makecert)  
 [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md)
