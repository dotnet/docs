---
title: "&lt;AppContextSwitchOverrides&gt; Element | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-bcl"
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "AppContextSwitchOverrides"
  - "compatibility switches"
  - "configuration switches"
  - "configuration"
ms.assetid: 4ce07f47-7ddb-4d91-b067-501bd8b88752
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# &lt;AppContextSwitchOverrides&gt; Element
Defines one or more switches used by the <xref:System.AppContext> class to provide an opt-out mechanism for new functionality.  
  
 \<configuration>  
 \<runtime>  
\<AppContextSwitchOverrides>  
  
## Syntax  
  
```  
  
<AppContextSwitchOverrides value="name1=value1[[;name2=value2];...]" />  
  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`value`|Required attribute.<br /><br /> Defines one or more switch names and their associated Boolean values.|  
  
### value Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|"name=value"|A predefined switch name along with its value (`true` or `false`). Multiple switch name/value pairs are separated by semicolons (";"). For a list of predefined switch names supported by the .NET Framework, see the Remarks section.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about runtime initialization options.|  
  
## Remarks  
 Starting with the .NET Framework 4.6, the `<AppContextSwitchOverrides>` element in a configuration file allows callers of an API to determine whether their app can take advantage of new functionality or preserve compatibility with previous versions of a library. For example, if the behavior of an API has changed between two versions of a library, the `<AppContextSwitchOverrides>` element allows callers of that API to opt out of the new behavior on versions of the library that support the new functionality. For apps that call APIs in the .NET Framework, the `<AppContextSwitchOverrides>` element can also allow callers whose apps target an earlier version of the .NET Framework to opt into new functionality if their app is running on a version of the .NET Framework that includes that functionality.  
  
 The `value` attribute of the `<AppContextSwitchOverrides>` element consists of a single string that consists of one or more semicolon-delimited name/value pairs.  Each name identifies a compatibility switch, and its corresponding value is a Boolean (`true` or `false`) that indicates whether the switch is set. By default, the switch is `false`, and libraries  provide the new functionality. They only provide the previous functionality if the switch is set (that is, its value is `true`). This allows libraries to provide new behavior for an existing API while allowing callers who depend on the previous behavior to opt out of the new functionality.  
  
 The .NET Framework supports the following switches:  
  
|Switch name|Description|Introduced|  
|-----------------|-----------------|----------------|  
|`Switch.MS.Internal.`<br /><br /> `DoNotApplyLayoutRoundingToMarginsAndBorderThickness`|Controls whether Windows Presentation Foundation uses legacy a algorithm for control layout. For more information, see [Mitigation: WPF Layout](../../../../../docs/framework/migration-guide/mitigation-wpf-layout.md).|[!INCLUDE[net_v46](../../../../../includes/net-v46-md.md)]|  
|`Switch.System.Drawing.`<br /><br /> `DontSupportPngFramesInIcons`|Controls whether the <xref:System.Drawing.Icon.ToBitmap%2A?displayProperty=fullName> method throws an exception when an <xref:System.Drawing.Icon> object has PNG frames. For more information, see [Mitigation: PNG Frames in Icon Objects](../../../../../docs/framework/migration-guide/mitigation-png-frames-in-icon-objects.md).|[!INCLUDE[net_v46](../../../../../includes/net-v46-md.md)]|  
|`Switch.System.Globalization.NoAsyncCurrentCulture`|Controls whether asynchronous operations do not flow from the calling thread's context. For more information, see [Mitigation: Culture and Asynchronous Operations](../../../../../docs/framework/migration-guide/mitigation-culture-and-asynchronous-operations.md).||  
|`Switch.System.IdentityModel.`<br /><br /> `DisableMultipleDNSEntriesInSANCertificate`|Controls whether the <xref:System.IdentityModel.Claims.X509CertificateClaimSet.FindClaims%2A?displayProperty=fullName> method attempts to match the claim type only with the last DNS entry. For more information, see [Mitigation: X509CertificateClaimSet.FindClaims Method](../../../../../docs/framework/migration-guide/mitigation-x509certificateclaimset-findclaims-method.md).|[!INCLUDE[net_v461](../../../../../includes/net-v461-md.md)]|  
|`Switch.System.IO.`<br /><br /> `BlockLongPaths`|Controls whether paths longer than `MAX_PATH` (260 characters) throw a <xref:System.IO.PathTooLongException>. For more information, see [Mitigation: Long Path Support](../../../../../docs/framework/migration-guide/mitigation-long-path-support.md).|[!INCLUDE[net_v462](../../../../../includes/net-v462-md.md)]|  
|`Switch.System.IO.Compression.ZipFile.`<br /><br /> `UseBackslash`|Uses the backslash ("\\") rather than the forward slash ("/") as the path separator in the <xref:System.IO.Compression.ZipArchiveEntry.FullName%2A?displayProperty=fullName> property. For more information, see  [Mitigation: ZipArchiveEntry.FullName Path Separator](../../../../../docs/framework/migration-guide/mitigation-ziparchiveentry-fullname-path-separator.md).|[!INCLUDE[net_v461](../../../../../includes/net-v461-md.md)]|  
|`Switch.System.IO.`<br /><br /> `UseLegacyPathHandling`|Controls whether legacy path normalization is used and URI paths are supported by the <xref:System.IO.Path.GetDirectoryName%2A?displayProperty=fullName> and <xref:System.IO.Path.GetPathRoot%2A?displayProperty=fullName> methods. For more information, see [Mitigation: Path Normalization](../../../../../docs/framework/migration-guide/mitigation-path-normalization.md) and [Mitigation: Path Colon Checks](../../../../../docs/framework/migration-guide/mitigation-path-colon-checks.md).|[!INCLUDE[net_v462](../../../../../includes/net-v462-md.md)]|  
|`Switch.System.`<br /><br /> `MemberDescriptorEqualsReturnsFalseIfEquivalent`|Controls whether a test for equality compares the <xref:System.ComponentModel.MemberDescriptor.Category%2A?displayProperty=fullName> property of one object with the <xref:System.ComponentModel.MemberDescriptor.Description%2A?displayProperty=fullName> property of the second object. For more information, see [Mitigation: MemberDescriptor.Equals](../../../../../docs/framework/migration-guide/mitigation-memberdescriptor-equals.md).|[!INCLUDE[net_v462](../../../../../includes/net-v462-md.md)]|  
|`Switch.System.Net.`<br /><br /> `DontEnableSchUseStrongCrypto`|Controls whether the <xref:System.Net.ServicePointManager?displayProperty=fullName> and <xref:System.Net.Security.SslStream?displayProperty=fullName> classes can use the SSL 3.0 protocol. For more information, see [Mitigation: TLS Protocols](../../../../../docs/framework/migration-guide/mitigation-tls-protocols.md).|[!INCLUDE[net_v46](../../../../../includes/net-v46-md.md)]|  
|`Switch.System.Security.ClaimsIdentity.`<br /><br /> `SetActorAsReferenceWhenCopyingClaimsIdentity`|Controls whether the <xref:System.Security.Claims.ClaimsIdentity.%23ctor%28System.Security.Principal.IIdentity%29?displayProperty=fullName> constructor sets the  new object's <xref:System.Security.Claims.ClaimsIdentity.Actor%2A?displayProperty=fullName> property with an existing object reference. For more information, see [Mitigation: ClaimsIdentity Constructor](../../../../../docs/framework/migration-guide/mitigation-claimsidentity-constructor.md).|[!INCLUDE[net_v462](../../../../../includes/net-v462-md.md)]|  
|`Switch.System.Security.Cryptography.`<br /><br /> `AesCryptoServiceProvider.DontCorrectlyResetDecryptor`|Controls whether the attempt to reuse an <xref:System.Security.Cryptography.AesCryptoServiceProvider> decryptor throws a <xref:System.Security.Cryptography.CryptographicException>. For more information, see [Retargeting Changes in the .NET Framework 4.6.2](https://msdn.microsoft.com/library/mt712574.aspx#Core).|[!INCLUDE[net_v462](../../../../../includes/net-v462-md.md)]|  
|`Switch.System.ServiceModel.`<br /><br /> `AllowUnsignedToHeader`|Determines whether the `TransportWithMessageCredential` security mode allows messages with an unsigned "to" header. This is an opt-in switch. For more information, see [Runtime Changes in the .NET Framework 4.6.1](https://msdn.microsoft.com/library/mt592686.aspx#WCF).|[!INCLUDE[net_v461](../../../../../includes/net-v461-md.md)]|  
|`Switch.System.ServiceModel.`<br /><br /> `DisableCngCertificates`|Determines whether the attempt to use X509 certificates with a CSG key storage provider throws an exception. For more information, see [Windows Communication Foundation (WCF)](../../../../../docs/framework/migration-guide/retargeting-changes-in-the-net-framework-4-6-2.md#WCF).|[!INCLUDE[net_v461](../../../../../includes/net-v461-md.md)]|  
|`Switch.System.Windows.Forms.`<br /><br /> `DontSupportReentrantFilterMessage`|Opts out of the code that allows a custom <xref:System.Windows.Forms.IMessageFilter.PreFilterMessage%2A?displayProperty=fullName> implementation to safely filter messages without throwing an exception when the <xref:System.Windows.Forms.Application.FilterMessage%2A?displayProperty=fullName> method is called. For more information, see [Mitigation: Custom IMessageFilter.PreFilterMessage Implementations](../../../../../docs/framework/migration-guide/mitigation-custom-imessagefilter-prefiltermessage-implementations.md).|[!INCLUDE[net_v461](../../../../../includes/net-v461-md.md)]|  
|`System.Xml.`<br /><br /> `IgnoreEmptyKeySequences`|Controls whether empty key sequences in compound keys are ignored by XSD schema validation. For more information, see [Mitigation: XML Schema Validation](../../../../../docs/framework/migration-guide/mitigation-xml-schema-validation.md).|[!INCLUDE[net_v46](../../../../../includes/net-v46-md.md)]|  
  
> [!NOTE]
>  Instead of adding an `AppContextSwitchOverrides` element to an application configuration file, you can also set the switches programmatically by calling the `static` (in C#) or `Shared` (in Visual Basic) <xref:System.AppContext.SetSwitch%2A?displayProperty=fullName> method.  
  
 Library developers can also define custom switches to allow callers to opt out of changed functionality introduced  in later versions of their libraries. For more information, see the <xref:System.AppContext> class.  
  
## Example  
 The following example uses the `AppContextSwitchOverrides` element to define a single application  compatibility switch, `Switch.System.Globalization.NoAsyncCurrentCulture`, that prevents culture from flowing across threads in asynchronous method calls.  
  
```  
  
<configuration>  
   <runtime>  
      <AppContextSwitchOverrides value="Switch.System.Globalization.NoAsyncCurrentCulture=true" />  
   </runtime>  
</configuration>  
  
```  
  
 The following example uses the `AppContextSwitchOverrides` element to define two application  compatibility switches, `Switch.System.Globalization.NoAsyncCurrentCulture` and `Switch.System.IO.BlockLongPaths`. Note that a semicolon separates the two name/value pairs.  
  
```  
  
<configuration>  
    <runtime>  
       <AppContextSwitchOverrides   
          value="Switch.System.Globalization.NoAsyncCurrentCulture=true;Switch.System.IO.BlockLongPaths=true" />  
    </runtime>  
</configuration>  
  
```  
  
## See Also  
 <xref:System.AppContext>   
 [\<runtime> Element](../../../../../docs/framework/configure-apps/file-schema/runtime/runtime-element.md)   
 [\<configuration> Element](../../../../../docs/framework/configure-apps/file-schema/configuration-element.md)