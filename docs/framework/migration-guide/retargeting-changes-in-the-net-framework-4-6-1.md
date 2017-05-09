---
title: "Retargeting Changes in the .NET Framework 4.6.1 | Microsoft Docs"
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
  - "retargeting changes, .NET Framework"
  - "retargeting changes, .NET Framework 4.6.1"
  - "application compatibility"
ms.assetid: 411ad548-30fa-43da-8716-10eccfc839e6
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Retargeting Changes in the .NET Framework 4.6.1
In rare cases, retargeting changes may affect apps that are recompiled to target the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)]. Unless specified otherwise, these changes do not affect binaries that target a previous version of the .NET Framework but are running under the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)].  
  
 The [!INCLUDE[net_v461](../../../includes/net-v461-md.md)] includes retargeting changes in the following areas:  
  
-   [Core](#Core)  
  
-   [Code Contracts](#Contracts)  
  
-   [Windows Communication Foundation](#WCF)  
  
-   [Windows Forms](#WinForms)  
  
<a name="Core"></a>   
## Core  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|<xref:System.IO.Compression.ZipFile.CreateFromDirectory%2A?displayProperty=fullName>|For apps that target the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)] and later versions, the path separator character has changed from a backslash ("\\") to a forward slash ("/") in the  <xref:System.IO.Compression.ZipArchiveEntry.FullName%2A> property of <xref:System.IO.Compression.ZipArchiveEntry> objects created by overloads of the <xref:System.IO.Compression.ZipFile.CreateFromDirectory%2A?displayProperty=fullName> method.|The change brings the .NET implementation into conformity with section 4.4.17.1 of the [.ZIP File Format Specification](https://pkware.cachefly.net/webdocs/casestudies/APPNOTE.TXT) and allows .ZIP archives to be decompressed on non-Windows systems.<br /><br /> However, it is possible for apps that target the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)] and later versions to opt out of this behavior. For more information, see [Mitigation: ZipArchiveEntry.FullName Path Separator](../../../docs/framework/migration-guide/mitigation-ziparchiveentry-fullname-path-separator.md).|Edge|  
  
<a name="Contracts"></a>   
## Code Contracts  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|<xref:System.Diagnostics.Contracts.Contract.Invariant%2A?displayProperty=fullName> and <xref:System.Diagnostics.Contracts.Contract.Requires%2A?displayProperty=fullName>, and calls to <xref:System.String.IsNullOrEmpty%2A?displayProperty=fullName>|For apps that target the .NET Framework 4.6.1, the rewriter emits compiler warning CC1036: "Detected call to method 'System.String.IsNullOrWhiteSpace(System.String)' without [Pure] in method..."|This is a compiler warning, rather than a compiler error.<br /><br /> This behavior was addressed in [GitHub Issue #339](https://github.com/Microsoft/CodeContracts/issues/339). To eliminate this warning, you can download and compile an updated version of the source code for the Code Contracts tools from [GitHub](https://github.com/Microsoft/CodeContracts/blob/master/README.md). Download information is found at the bottom of the page.|Minor|  
  
<a name="WCF"></a>   
## Windows Communication Foundation  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|<xref:System.IdentityModel.Claims.X509CertificateClaimSet.FindClaims%2A?displayProperty=fullName><br /><br /> (<xref:System.IdentityModel.Claims> namespace)|In apps that target the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)], if an X509 claim set is initialized from a certificate that has multiple DNS entries in its SAN field, the <xref:System.IdentityModel.Claims.X509CertificateClaimSet.FindClaims%2A> method attempts to match the `claimType` argument with all the DNS entries.<br /><br /> For apps that target previous versions of the .NET Framework, the <xref:System.IdentityModel.Claims.X509CertificateClaimSet.FindClaims%2A> method attempts to match the `claimType` argument only with the last DNS entry.|This change affects all apps that target the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)]. Apps that target previous versions of the .NET Framework are not affected.<br /><br /> However, it is possible for apps that target the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)] to opt out of this behavior. In addition, it is possible for apps that target previous versions of the .NET Framework but are running under the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)] to opt into this behavior. For more information, see [Mitigation: X509CertificateClaimSet.FindClaims Method](../../../docs/framework/migration-guide/mitigation-x509certificateclaimset-findclaims-method.md).|Minor|  
  
<a name="WinForms"></a>   
## Windows Forms  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|<xref:System.Windows.Forms.Application.FilterMessage%2A?displayProperty=fullName> method (<xref:System.Windows.Forms> namespace)|In Windows Forms apps that target the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)], a custom <xref:System.Windows.Forms.IMessageFilter.PreFilterMessage%2A?displayProperty=fullName> implementation can safely filter messages when the <xref:System.Windows.Forms.Application.FilterMessage%2A?displayProperty=fullName> method is called if the <xref:System.Windows.Forms.IMessageFilter.PreFilterMessage%2A?displayProperty=fullName> implementation:<br /><br /> <ul><li>Does one or both of the following:<br /><br /> <ul><li>Adds a message filter by calling the <xref:System.Windows.Forms.Application.AddMessageFilter%2A> method.</li><li>Removes a message filter by calling the <xref:System.Windows.Forms.Application.RemoveMessageFilter%2A>method. method.</li></ul></li><li>**And** pumps messages by calling the <xref:System.Windows.Forms.Application.DoEvents%2A?displayProperty=fullName> method.</li></ul><br /> Such implementations in Windows Forms apps that target previous versions of the .NET Framework in some cases throw an <xref:System.IndexOutOfRangeException> exception when the <xref:System.Windows.Forms.Application.FilterMessage%2A?displayProperty=fullName> method is called|This change affects all apps that target the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)]. Apps that target previous versions of the .NET Framework are not affected.<br /><br /> However, it is possible for apps that target the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)]to opt out of this behavior. In addition, it is possible for apps that target previous versions of the .NET Framework but are running under the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)] to opt into this behavior. For more information, see [Mitigation: Custom IMessageFilter.PreFilterMessage Implementations](../../../docs/framework/migration-guide/mitigation-custom-imessagefilter-prefiltermessage-implementations.md).|Edge|  
  
## See Also  
 [Application Compatibility in 4.6.1](../../../docs/framework/migration-guide/application-compatibility-in-the-net-framework-4-6-1.md)