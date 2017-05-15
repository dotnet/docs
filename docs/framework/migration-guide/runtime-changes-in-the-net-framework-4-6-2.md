---
title: "Runtime Changes in the .NET Framework 4.6.2 | Microsoft Docs"
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
  - "runtime changes, .NET Framework"
  - "runtime changes, .NET Framework 4.6.2"
  - "application compatibility"
ms.assetid: 23bf3a87-6fa1-4b5e-b92c-a39867a06e7f
caps.latest.revision: 16
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Runtime Changes in the .NET Framework 4.6.2
In rare cases, runtime changes may affect existing apps that target the previous versions of the .NET Framework but run on a later version of the .NET Framework runtime. They also include differences in behavior between applications that run on different .NET Framework runtime environments. The [!INCLUDE[net_v462](../../../includes/net-v462-md.md)] includes changes in the following areas:  
  
-   [Core](#Core)  
  
-   [ASP.NET](#ASP)

-   [Data](#Data)  
  
-   [Windows Communication Foundation (WCF)](#WCF)  
  
-   [Windows Presentation Foundation (WPF)](#WPF)  
  
-   [XML signing and validation](#XML)  
  
<a name="Core"></a>   
## Core  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|<xref:System.Char.GetUnicodeCategory%2A?displayProperty=fullName><br /><br /> <xref:System.Globalization.CharUnicodeInfo.GetUnicodeCategory%2A?displayProperty=fullName>|Character categories in the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)] are based on Unicode Version 8.0. The .NET Framework versions 4.5 through 4.6.1 classified Unicode characters based on Unicode Version 6.3.<br /><br /> Character comparison and sorting are unaffected by this change. For more information, see the "Strings and the Unicode Standard" section of the <xref:System.String> class topic.|Character categories in the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)] may not match those of previous versions of the .NET Framework. This change primarily affects Cherokee syllables and New Tai Lue vowel signs and tone marks.<br /><br /> To address this change, you should review code and remove or change logic that depends on hard-coded Unicode character categories.|Minor|  
|<xref:System.Security.Cryptography.RSA.ImportParameters%2A?displayProperty=fullName>, <xref:System.Security.Cryptography.RSACng.ImportParameters%2A?displayProperty=fullName>, <xref:System.Security.Cryptography.X509Certificates.RSACertificateExtensions.GetRSAPrivateKey%2A?displayProperty=fullName>, <xref:System.Security.Cryptography.X509Certificates.RSACertificateExtensions.GetRSAPublicKey%2A?displayProperty=fullName>|Starting with the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], these methods are able to access keys with non-standard key sizes for RSA certificates. In the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)] and earlier versions,  attempting to access those keys threw a <xref:System.Security.Cryptography.CryptographicException>.|If any exception handling logic relies on a <xref:System.Security.Cryptography.CryptographicException> when non-standard key sizes are used, it should be removed.|Edge|  
|<xref:System.Security.Cryptography.RSACng.VerifyHash%2A?displayProperty=fullName>|Starting with  the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], this method returns `false` if the signature itself is badly formatted. It now returns `false` for any verification failure.<br /><br /> In the [!INCLUDE[net_v46](../../../includes/net-v46-md.md)] and 4.6.1,  the method throws a <xref:System.Security.Cryptography.CryptographicException> if the signature itself is badly formatted.|Any code whose execution depends on the <xref:System.Security.Cryptography.CryptographicException> should instead execute if validation fails and the method returns `false`.|Minor|  
  
## <a name="ASP" /> ASP.NET

|Feature|Change|Impact|Scope| 
|-------------|------------|------------|-----------|  
| <xref:System.Web.HttpRuntime.AppDomainApopPath%2A> | In the .NET Framework 4.6.2, the runtime throws a <xref:System.NullReferenceException> when retrieving an <xref:System.Web.HttpRuntime.AppDomainAppPath%2A> value that includes null characters. In the .NET Framework 4.6.1 and earlier versions, it throws an <xref:System.ArgumentNullException>.  | You can do the following to respond to this change: <br/> - Handle the <xref:System.NullReferenceException> if your application is running on the .NET Framework 4.6.2. <br /> - Upgrade to the .NET Framework 4.7, which restores the previous behavior and throws an <xref:System.ArgumentNullException>. | Edge |

<a name="Data"></a>   
## Data  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|Connection pool blocking period for Azure SQL databases|For connection open requests to known Azure SQL databases, the connection pool blocking period is removed.|Attempts to retry connection open requests will occur almost immediately after transient connection errors. For more information, see [Mitigation: Pool Blocking Period](~/docs/framework/migration-guide/mitigation-pool-blocking-period.md).|Minor|  
  
<a name="WCF"></a>   
## Windows Communication Foundation (WCF)  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|<xref:System.ServiceModel.Channels.SslStreamSecurityBindingElement.SslProtocols%2A?displayProperty=fullName> <br /> <xref:System.ServiceModel.TcpTransportSecurity.SslProtocols%2A?displayProperty=fullName>|When using NetTcp with transport security and a credential type of certificate, the SSL 3 protocol is no longer a default protocol used for negotiating a secure connection.|In most cases, there should be no impact to existing apps, since TLS 1.0 has always been included in the protocol list for NetTcp. All existing clients should be able to negotiate a connection using at least TLS1.0.<br /><br /> If Ssl3 is required, you can use one of the following configuration mechanisms to add Ssl3 to the list of negotiated protocols:<br /><br /> -   The <xref:System.ServiceModel.TcpTransportSecurity?displayProperty=fullName> property<br />-   The <xref:System.ServiceModel.Channels.SslStreamSecurityBindingElement.SslProtocols%2A?displayProperty=fullName> property<br />-   The [\<transport>](~/docs/framework/configure-apps/file-schema/wcf/security-of-nettcpbinding.md) section of [\<netTcpBinding>](~/docs/framework/configure-apps/file-schema/wcf/nettcpbinding.md)<br />-   The [\<sslStreamSecurity>](~/docs/framework/configure-apps/file-schema/wcf/sslstreamsecurity.md) section of [\<customBinding>](~/docs/framework/configure-apps/file-schema/wcf/custombinding.md)|Edge|  
  
<a name="WPF"></a>   
## Windows Presentation Foundation (WPF)  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|The `IsEnabled` property of the parent of a <xref:System.Windows.Controls.TextBlock> control|Starting with the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], changing the `IsEnabled` property of the parent of a <xref:System.Windows.Controls.TextBlock> control affects any child controls (such as hyperlinks and buttons) of the <xref:System.Windows.Controls.TextBlock> control.<br /><br /> In the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)] and earlier versions of the .NET Framework, controls inside a <xref:System.Windows.Controls.TextBlock> did not always reflect whether the state of the `IsEnabled` property of the <xref:System.Windows.Controls.TextBlock> parent.|This change conforms to the expected behavior for controls inside a <xref:System.Windows.Controls.TextBlock> control.|Minor|  
|Horizontal scrolling, virtualization, and <xref:System.Windows.Controls.Primitives.IScrollInfo.HorizontalOffset%2A?displayProperty=fullName>|The behavior of the scrolling operation for an <xref:System.Windows.Controls.ItemsControl> that does its own virtualization in the direction orthogonal to the main scrolling direction has changed.|The change produces a more predictable and intuitive experience for the end user, but it could affect any app that depends on the exact value of <xref:System.Windows.Controls.Primitives.IScrollInfo.HorizontalOffset%2A?displayProperty=fullName> after a horizontal scroll. For more information, see [Mitigation: Horizontal Scrolling and Virtualization](~/docs/framework/migration-guide/mitigation-horizontal-scrolling-and-virtualization.md).|Minor|  
|WPF Spell Checker (<xref:System.Windows.Controls.SpellCheck?displayProperty=fullName> class)|Three issues noted in WPF spell checking when running under the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)] have been addressed in the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)]:<br /><br /> -   In the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)], the spell checker sometimes throws a <xref:System.Runtime.InteropServices.COMException> when invoking [ISpellChecker](https://msdn.microsoft.com/library/windows/desktop/hh869767\(v=vs.85\).aspx) or [ISpellCheckerFactory](https://msdn.microsoft.com/library/windows/desktop/hh869770\(v=vs.85\).aspx) methods. In the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], these exceptions have been eliminated.<br />-   In the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)], the spell checker incorrectly identifies spelling errors in compound words, such as "Hausnummer" in German. In the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], the spell checker correctly handles compound words.<br />-   In the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)], the spell checker throws an <xref:System.UnauthorizedAccessException> when an application is launched using "run as different user." In the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], this scenario is not supported, and the spell checker is silently disabled.|These changes enhance the robustness of the spell checker.  They should not adversely affect an application unless application code depends on an exception being thrown.|Edge|  
| [DataGridCellsPanel.BringIndexIntoView](xref:System.Windows.Controls.DataGridCellsPanel.BringIndexInfoView(System.Int32)) method | In the .NET Framework 4.6.2, the **BringIndexIntoView** method will execute asynchronously when column virtualization is enabled but the column widths have not been determined. However, if columns are removed before the asynchronous operation completes, an [ArgumentOutOfRangeException](xref:System.ArgumentOutOfRangeException) can occur.<br/></br>Starting with the .NET Framework 4.7, the exception is no longer thrown in this scenario. | You can do any of the following to prevent the exception from occurring: <br/> - Upgrade to the .NET Framework 4.7. <br/> 1 Install the latest servicing patch for the .NET Framework 4.6.2. <br/> - Avoid removing columns until the asynchronous response to the [DataGrid.ScrollIntoView](xref:System.Windows.Controls.DataGrid.ScrollIntoView(System.Object)) method has completed. | Edge | 
  
<a name="XML"></a>   
## Signed XML verification requirements  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|<xref:System.Security.Cryptography.Xml.SignedXml?displayProperty=fullName> and <xref:System.Security.Cryptography.Xml.EncryptedXml?displayProperty=fullName>|External resource loading is disabled, and ambiguous id-targets are considered invalid.|An exception is thrown in a number of cases, including:<br /><br /> -   Identifying an element by an id attribute, and defining a second element with the same identifier,<br />-   Defining an identifier that is not a legal `NCName` value.<br />-   Referencing external URIs.<br /><br /> <xref:System.Security.Cryptography.Xml.SignedXml.CheckSignature%2A?displayProperty=fullName> always returns `false` for documents:<br /><br /> -   That use the XPath reference transform.<br />-   That use the XSLT reference transform.<br /><br /> Developers should review the usage of <xref:System.Security.Cryptography.Xml.XmlDsigXPathTransform?displayProperty=fullName> and , <xref:System.Security.Cryptography.Xml.XmlDsigXsltTransform> as well as types derived from <xref:System.Security.Cryptography.Xml.Transform?displayProperty=fullName>, since a document receiver may not be able to process it.<br /><br /> For more information, see [After you apply security update 3141780, .NET Framework applications encounter exception errors or unexpected failures while processing files that contain SignedXml](https://support.microsoft.com/en-us/kb/3148821).|Minor|  
  
## See Also  
 [Application Compatibility in 4.6.2](~/docs/framework/migration-guide/application-compatibility-in-the-net-framework-4-6-2.md)