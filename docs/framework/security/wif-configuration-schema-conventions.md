---
title: "WIF Configuration Schema Conventions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f7864356-f72f-4cae-995c-18e0431f8a58
caps.latest.revision: 3
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# WIF Configuration Schema Conventions
This topic discusses conventions used throughout the Windows Identity Foundation (WIF) configuration topics and describes some common features and attributes used in the [\<system.identityModel>](../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/system-identitymodel.md) and the [\<system.identityModel.services>](../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/system-identitymodel-services.md) sections.  
  
<a name="BKMK_Modes"></a>   
## Modes  
 Many of the WIF configuration elements have a `mode` attribute. This attribute typically controls which class is used to do a particular part of the processing and which configuration elements are allowed as child elements of the current element. A configuration error will be raised if elements that are included in the configuration file are ignored because of the mode settings.  
  
<a name="BKMK_TimespanValues"></a>   
## Timespan Values  
 Where <xref:System.TimeSpan> is used as the type of an attribute, see the <xref:System.TimeSpan.Parse%28System.String%29> method to see the allowed format. This format conforms to the following specification.  
  
```  
[ws][-]{ d | [d.]hh:mm[:ss[.ff]] }[ws]  
```  
  
 For example, "30", "30.00:00", "30.00:00:00" all mean 30 days; and "00:05", "00:05:00", "0.00:05:00.00" all mean 5 minutes.  
  
<a name="BKMK_CertificateReferences"></a>   
## Certificate References  
 Several elements take references to certificates using the `<certificateReference>` element. When referencing a certificate, the following attributes are available.  
  
|||  
|-|-|  
|`storeLocation`|A value of the <xref:System.Security.Cryptography.X509Certificates.StoreLocation> enumeration: `CurrentUser` or `CurrentMachine`.|  
|`storeName`|A value of the <xref:System.Security.Cryptography.X509Certificates.StoreName> enumeration; the most useful for this context are `My` and `TrustedPeople`.|  
|`x509FindType`|A value of the <xref:System.Security.Cryptography.X509Certificates.X509FindType> enumeration; the most useful for this context are `FindBySubjectName` and `FindByThumbprint`. To eliminate the chance of error, it is recommended that the `FindByThumbprint` type be used in production environments.|  
|`findValue`|The value used to find the certificate, based on the `x509FindType` attribute. To eliminate the chance of error, it is recommended that the `FindByThumbprint` type be used in production environments. When `FindByThumbPrint` is specified, this attribute takes a value that is the hexadecimal-string form of the certificate thumbprint; for example, "97249e1a5fa6bee5e515b82111ef524a4c91583f".|  
  
<a name="BKMK_CustomTypeReferences"></a>   
## Custom Type References  
 Several elements reference custom types using the `type` attribute. This attribute should specify the name of the custom type. To reference a type from the Global Assembly Cache (GAC), a strong name should be used. To reference a type from an assembly in the Bin/ directory, a simple assembly-qualified reference may be used. Types defined in the App_Code/ directory may also be referenced by simply specifying the type name with no qualifying assembly.  
  
 Custom types must be derived from the type specified and they must provide a `public` default (0 argument) constructor.  
  
## See Also  
 [\<system.identityModel>](../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/system-identitymodel.md)  
 [\<system.identityModel.services>](../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/system-identitymodel-services.md)
