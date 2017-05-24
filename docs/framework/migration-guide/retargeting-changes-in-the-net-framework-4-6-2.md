---
title: "Retargeting Changes in the .NET Framework 4.6.2 | Microsoft Docs"
ms.custom: ""
ms.date: "04/07/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-bcl"
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "retargeting changes, .NET Framework"
  - "retargeting changes, .NET Framework 4.6.2"
  - "application compatibility"
ms.assetid: 76dc6849-8210-4e41-8731-20828c98b282
caps.latest.revision: 26
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Retargeting Changes in the .NET Framework 4.6.2
In rare cases, retargeting changes may affect apps that are recompiled to target the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)]. They do not affect binaries that target a previous version of the .NET Framework but are running under version 4.6.2. The [!INCLUDE[net_v462](../../../includes/net-v462-md.md)] includes retargeting changes in the following areas:  
  
-   [Core](#Core)  
  
-   [Windows Communication Foundation (WCF)](#WCF)  
  
-   [Windows Forms](#WinForms)  
  
 The Scope column in the following tables specifies the significance of each change:  
  
-   Major. A significant change that affects a large number of apps or that requires substantial modification of code. Note that none of the retargeting changes fall into this category.  
  
-   Minor. A change that either affects a small number of apps or that requires minor modification of code.  
  
-   Edge. A change that affects apps under very specific scenarios that are not common.  
  
-   Transparent. A change that has no noticeable effect on the app's developer or user. The app should not require modification because of this change.  
  
<a name="Core"></a>   
## Core  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|Long path support|Starting with apps that target the  [!INCLUDE[net_v462](../../../includes/net-v462-md.md)],  long paths (of up to 32K characters) are supported, and the 260-character (or `MAX_PATH`) limitation on path lengths has been removed.|For apps that target the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], code paths that previously threw a <xref:System.IO.PathTooLongException> may no longer throw an exception. For  more information, see [Mitigation: Long Path Support](~/docs/framework/migration-guide/mitigation-long-path-support.md).|Minor|  
|Path normalization|Starting with apps that target the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], the way in which paths are normalized has changed to defer to the operating system and to provide better access to DOS device paths.|The changes make it possible to access valid device paths that were previously not supported. For more information, see [Mitigation: Path Normalization](~/docs/framework/migration-guide/mitigation-path-normalization.md).|Minor|  
|<xref:System.IO.Path.GetDirectoryName%2A?displayProperty=fullName> and <xref:System.IO.Path.GetPathRoot%2A?displayProperty=fullName>|Starting with apps that target the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], a number of changes were made to support previously unsupported paths (both in terms of length and format). In particular, checks for the proper drive separator syntax (the colon) were made more correct.|These changes block some URI paths that these two methods previously supported. For more information, see [Mitigation: Path Colon Checks](~/docs/framework/migration-guide/mitigation-path-colon-checks.md).|Edge|  
|<xref:System.Security.Claims.ClaimsIdentity.%23ctor%28System.Security.Principal.IIdentity%29?displayProperty=fullName> constructor|Starting with the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], the <xref:System.Security.Claims.ClaimsIdentity.Actor%2A> property created by a call to <xref:System.Security.Claims.ClaimsIdentity.%23ctor%28System.Security.Principal.IIdentity%29?displayProperty=fullName> method is a new <xref:System.Security.Claims.ClaimsIdentity> instance. In previous versions of the .NET Framework, the <xref:System.Security.Claims.ClaimsIdentity.Actor%2A> is an existing reference.|In some cases, comparison of the <xref:System.Security.Claims.ClaimsIdentity.Actor%2A?displayProperty=fullName> property with the <xref:System.Security.Claims.ClaimsIdentity.Actor%2A?displayProperty=fullName> property of the constructor's <xref:System.Security.Principal.IIdentity> returns different results.<br /><br /> For more information, see [Mitigation: ClaimsIdentity Constructor](~/docs/framework/migration-guide/mitigation-claimsidentity-constructor.md).|Edge|  
|<xref:System.Security.Cryptography.AesCryptoServiceProvider.CreateDecryptor%2A?displayProperty=fullName>|Starting with apps that target the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], the <xref:System.Security.Cryptography.AesCryptoServiceProvider> decryptor provides a reusable transform.   After a call to <xref:System.Security.Cryptography.ICryptoTransform.TransformFinalBlock%2A>, the transform is reinitialized and can be reused.<br /><br /> For apps that target earlier versions of the .NET Framework, attempting to reuse the decryptor by calling <xref:System.Security.Cryptography.ICryptoTransform.TransformBlock%2A> after a call to  <xref:System.Security.Cryptography.ICryptoTransform.TransformFinalBlock%2A> throws a <xref:System.Security.Cryptography.CryptographicException> or produces corrupted data.|The impact should be minimal, since this is the expected behavior.<br /><br /> Applications that depend on the previous behavior can opt out of it using it by adding the following configuration setting to the [\<runtime>](~/docs/framework/configure-apps/file-schema/runtime/runtime-element.md) section of the application's configuration file:<br /><br /> `<runtime>    <AppContextSwitchOverrides value="Switch.System.Security.Cryptography.AesCryptoServiceProvider.DontCorrectlyResetDecryptor=true"/> </runtime>`<br /><br /> In addition, applications that target a previous version of the .NET Framework but are running under a version of the .NET Framework starting with [!INCLUDE[net_v462](../../../includes/net-v462-md.md)] can opt in to it by  adding the following configuration setting to the [\<runtime>](~/docs/framework/configure-apps/file-schema/runtime/runtime-element.md) section of the application's configuration file:<br /><br /> `<runtime>    <AppContextSwitchOverrides value="Switch.System.Security.Cryptography.AesCryptoServiceProvider.DontCorrectlyResetDecryptor=false"/> </runtime>`|Minor|  
  
<a name="WCF"></a>   
## Windows Communication Foundation (WCF)  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|WCF transport security support for certificates stored using CNG|Starting with apps that target the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], WCF transport security supports certificates stored using the Windows cryptography library (CNG). This support is limited to certificates with a public key that has an exponent no more than 32 bits in length. When an application targets the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], this feature is on by default.<br /><br /> In earlier versions of the .NET Framework, the attempt to use X509 certificates with a CSG key storage provider throws an exception.|Apps that target the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)] and earlier but are running on the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)] can enable support for CNG certificates by adding the following line to the runtime section of the app.config or web.config file.<br /><br /> `<AppContextSwitchOverrides     value="Switch.System.ServiceModel.DisableCngCertificates=false" />`<br /><br /> This can also be done programmatically with the following code:<br /><br /> `private const string DisableCngCertificates = @"Switch.System.ServiceModel.DisableCngCertificate"; AppContext.SetSwitch(disableCngCertificates, false);`<br /><br /> `Const DisableCngCertificates As String = "Switch.System.ServiceModel.DisableCngCertificates" AppContext.SetSwitch(disableCngCertificates, False)`<br /><br /> Note that, because of this change, any exception handling code that depends on the attempt to initiate secure communication with a CNG certificate to fail will no longer execute.|Minor|  
  
<a name="WinForms"></a>   
## Windows Forms  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|<xref:System.ComponentModel.MemberDescriptor.Equals%2A?displayProperty=fullName>, `System.ComponentModel.EventDescriptor.Equals`, and  `System.ComponentModel.PropertyDescriptor.Equals`|Starting with apps that target the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], the implementation of the  base class <xref:System.ComponentModel.MemberDescriptor.Equals%2A> method has changed.|Because the test for equality now produces the expected result, this change should have little effect.<br /><br /> However, apps that target the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)] and depend on the previous behavior can opt out of this change. Similarly, apps that target earlier versions of the .NET Framework but are running under the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], can opt into this change. For more information, see [Mitigation: MemberDescriptor.Equals](~/docs/framework/migration-guide/mitigation-memberdescriptor-equals.md).|Edge|  
  
## See Also  
 [Application Compatibility in 4.6.2](~/docs/framework/migration-guide/application-compatibility-in-the-net-framework-4-6-2.md)