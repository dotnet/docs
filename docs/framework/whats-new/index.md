---
title: "What&#39;s New in the .NET Framework | Microsoft Docs"
ms.custom: ""
ms.date: "05/02/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "what's new [.NET Framework]"
ms.assetid: 1d971dd7-10fc-4692-8dac-30ca308fc0fa
caps.latest.revision: 292
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# What&#39;s New in the .NET Framework
<a name="introduction"></a> This article summarizes key new features and improvements in the following versions of the .NET Framework:  
  
 [.NET Framework 4.7](#v47)   
 [.NET Framework 4.6.2](#v462)   
 [.NET Framework 4.6.1](#v461)   
 [.NET 2015 and .NET Framework 4.6](#v46)   
 [.NET Framework 4.5.2](#v452)   
 [.NET Framework 4.5.1](#v451)   
 [.NET Framework 4.5](#core)  
  
 This article does not provide comprehensive information about each new feature and is subject to change. For general information about the .NET Framework, see [Getting Started](http://msdn.microsoft.com/library/c693fd34-88fe-4d90-b332-19eeadf3b7e7). For supported platforms, see [System Requirements](~/docs/framework/get-started/system-requirements.md). For download links and installation instructions, see [Installation Guide](../../../docs/framework/install/guide-for-developers.md).  
  
> [!NOTE]
>  The .NET Framework team also releases features out of band with NuGet to expand platform support and to introduce new functionality, such as immutable collections and SIMD-enabled vector types. For more information, see [Additional Class Libraries and APIs](http://msdn.microsoft.com/library/cf2d9006-b631-4e5d-81cd-20aab78c60f1) and [The .NET Framework and Out-of-Band Releases](~/docs/framework/get-started/the-net-framework-and-out-of-band-releases.md). See a [complete list of NuGet packages](http://blogs.msdn.com/b/dotnet/p/nugetpackages.aspx) for the .NET Framework, or subscribe to [our feed](https://nuget.org/api/v2/curated-feeds/dotnetframework/Packages/).  
  
<a name="v47"></a>   
## Introducing the .NET Framework 4.7  
 The .NET Framework 4.7 builds on the .NET Framework 4.6, 4.6.1, and 4.6.2 by adding many new fixes and several new features while remaining a very stable product.  

### Downloading and installing the .NET Framework 4.7
 
You can download the .NET Framework 4.7  from the following locations:  
  
- [.NET Framework 4.7 Web Installer](http://go.microsoft.com/fwlink/?LinkId=825299)  
  
- [NET Framework 4.7 Offline Installer](http://go.microsoft.com/fwlink/?LinkId=825303)  
  
The .NET Framework 4.7 can be installed on Windows 10, Windows 8.1, Windows 7, and the corresponding server platforms starting with Windows Server 2008 R2 SP1. You can install the .NET Framework 4.7 by using either the web installer or the offline installer. The recommended way for most users is to use the web installer.  
  
You can target the .NET Framework 4.7 in Visual Studio 2012 or later by installing the [.NET Framework 4.7 Developer Pack](http://go.microsoft.com/fwlink/?LinkId=825319).  
  
### What's new in the .NET Framework 4.7

The .NET Framework 4.7 includes new features in the following areas:

- [Core](#Core47)
- [Networking](#net47)
- [ASP.NET](#ASP-NET47)
- [Windows Communication Foundation (WCF)](#wcf47)
- [Windows Forms](#wf47)
- [Windows Presentation Foundation (WPF)](#WPF47)

For a list of new APIs added to the .NET Framework 4.7, see [.NET Framework 4.7 API Changes](https://github.com/Microsoft/dotnet/blob/master/releases/net47/dotnet47-api-changes.md) on GitHub. For a list of feature improvements and bug fixes in the .NET Framework 4.7, see [.NET Framework 4.7 List of Changes](http://gutithub.com/Microsoft/dotnet/blob/master/releases/net47/dotnet47-changes.md) on GitHub.  For additional information, see [Announcing the .NET Framework 4.7](https://blogs.msdn.microsoft.com/dotnet/2017/04/05/announcing-the-net-framework-4-7/) in the .NET Blog.
  
<a name="Core47" />
### Core ###

The .NET Framework 4.7 improves serialization by the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer>:

**Enhanced functionality with Elliptic Curve Cryptography (ECC)***

In the .NET Framework 4.7, `ImportParameters(ECParameters)` methods were added to the <xref:System.Security.Cryptography.ECDsa> and <xref:System.Security.Cryptography.ECDiffieHellman> classes to allow for an object to represent an already-established key. An `ExportParameters(Boolean)` method was also added for exporting the key using explicit curve parameters.

The .NET Framework 4.7 also adds support for additional curves (including the Brainpool curve suite), and has added predefined definitions for ease-of-creation through the new <xref:System.Security.Cryptography.ECDsa.Create%2A> and <xref:System.Security.Cryptography.ECDiffieHellman.Create%2A> factory methods.

You can see an [example of .NET Framework 4.7 cryptography improvements](https://gist.github.com/richlander/5a182899895a87a296c21ada97f7a54e) on GitHub.

**Better support for control characters by the DataContractJsonSerializer**

In the .NET Framework 4.7, the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer> serializes control characters in conformity with the ECMAScript 6 standard. This behavior is enabled by default for applications that target the .NET Framework 4.7, and is an opt-in feature for applications that are running under the .NET Framework 4.7 but target a previous version of the .NET Framework. For more information, see [Retargeting Changes in the .NET Framework 4.7](../../../docs/framework/migration-guide/retargeting-changes-in-the-net-framework-4-7.md).

<a name="net47" />
### Networking ###

The .NET Framework 4.7 adds the following network-related feature:

**Default operating system support for TLS protocols***

The TLS stack, which is used by <xref:System.Net.Security.SslStream?displayProperty=fullName> and up-stack components such as HTTP, FTP, and SMTP, allows developers to use the default TLS protocols supported by the operating system. Developers need no longer hard-code a TLS version.

<a name="ASP-NET47" />
### ASP.NET ###

In the .NET Framework 4.7, ASP.NET includes the following new features:

**Object Cache Extensibility**

Starting with the .NET Framework 4.7, ASP.NET adds a new set of APIs that allow developers to replace the default ASP.NET implementations for in-memory object caching and memory monitoring. Developers can now replace any of the following three components if the ASP.NET implementation is not adequate:

- **Object Cache Store**. By using the new cache providers configuration section, developers can plug in new implementations of an object cache for an ASP.NET application by using the new **ICacheStoreProvider** interface.
 
- **Memory monitoring**. The default memory monitor in ASP.NET notifies applications when they are running close to the configured private bytes limit for the process, or when the machine is low on total available physical RAM. When these limits are near, notifications are fired. For some applications, notifications are fired too close to the configured limits to allow for useful reactions. Developers can now write their own memory monitors to replace the default by using the <xref:System.Web.Hosting.ApplicationMonitors.MemoryMonitor%2A?displayProperty=fullName> property.

- **Memory Limit Reactions**. By default, ASP.NET attempts to trim the object cache and periodically call <xref:System.GC.Collect%2A?displayProperty=fullName> when the private byte process limit is near. For some applications, the frequency of calls to <xref:System.GC.Collect%2A?displayProperty=fullName> or the amount of cache that is trimmed are inefficient. Developers can now replace or supplement the default behavior by subscribing **IObserver** implementations to the application's memory monitor.

<a name="wcf47" />
### Windows Communication Foundation (WCF) ###

Windows Communication Foundation (WFC) adds the following features and changes:

**Ability to configure the default message security settings to TLS 1.1 or TLS 1.2**

Starting with the .NET Framework 4.7, WCF allows you to configure TSL 1.1 or TLS 1.2 in addition to SSL 3.0 and TSL 1.0 as the default message security protocol. This is an opt-in setting; to enable it, you must add the following entry to your application configuration file:

```xml
<runtime>
   <AppContextSwitchOverrides value="Switch.System.ServiceModel.DisableUsingServicePointManagerSecurityProtocols=false;Switch.System.Net.DontEnableSchUseStrongCrypto=false" /> 
</runtime>
```

**Improved reliability of WCF applications and WCF serialization**

WCF includes a number of code changes that eliminate race conditions, thereby improving improving performance and the reliability of serialization options. These include:

- Better support for mixing asynchronous and synchronous code in calls to **SocketConnection.BeginRead** and **SocketConnection.Read**.
- Improved reliability when aborting a connection with **SharedConnectionListener** and **DuplexChannelBinder**.
- Improved reliability of serialization operations when calling the [FormatterServices.GetSerializableMembers](assetId:///System.Runtime.Serialization.FormatterServices.GetSerializableMembers(System.Type??qualifyHint=True&autoUpgrade=False) method.
- Improved reliability when removing a waiter by calling the **ChannelSynchronizer.RemoveWaiter** method.  

<a name="wf47" />
### Windows Forms ###

In the .NET Framework 4.7, Windows Forms improves support for high DPI monitors.

**High DPI support**

Starting with applications that target the .NET Framework 4.7, the .NET Framework features high DPI and dynamic DPI support for Windows Forms applications. High DPI support improves the layout and appearance of forms and controls on high DPI monitors. Dynamic DPI changes the layout and appearance of forms and controls when the user changes the DPI or display scale factor of a running application.

High DPI support is an opt-in feature that you configure by defining a [\<System.Windows.Forms.ConfigurationSection>](Windows%20Forms%20Configuration%20Section.md) section in your application configuration file. For more information on adding high DPI support and dynamic DPI support to your Windows Forms application, see [High DPI Support in Windows Forms](High%20DPI%20Support%20In%20Windows%20Forms.md).  

<a name="WPF47"></a>   
### Windows Presentation Foundation (WPF)

In the .NET Framework 4.7, WPF includes the following enhancements:

**Support for a touch/stylus stack based on Windows WM_POINTER messages**

You now have the option of using a touch/stylus stack based on [WM_POINTER messages](https://msdn.microsoft.com/library/windows/desktop/hh454903(v=vs.85).aspx) instead of the Windows Ink Services Platform (WISP). This is an opt-in feature in the .NET Framework. For more information, see [Retargeting Changes in the .NET Framework 4.7](Retargeting%20Changes%20in%20the%20.NET%20Framework%204.7.md).

**New implementation for WPF printing APIs**

WPF's printing APIs in the [System.Printing.PrintQueue](assetId:///T:System.Printing.PrintQueue?qualifyHint=True&autoUpgrade=True) class call the Windows [Print Document Package API](https://msdn.microsoft.com/library/windows/desktop/hh448418(v=vs.85).aspx) instead of the deprecated [XPS Print API](https://msdn.microsoft.com/library/windows/desktop/ff686814(v=vs.85).aspx). For the impact of this change on application compatibility, see [Retargeting Changes in the .NET Framework 4.7](Retargeting%20Changes%20in%20the%20.NET%20Framework%204.7.md). 

<a name="v462"></a>   
## What's new in the .NET Framework 4.6.2  
The .NET Framework 4.6.2 includes new features in the following areas:  
  
-   [ASP.NET](#ASPNET462)  
  
-   [Character categories](#Strings)  
  
-   [Cryptography](#Crypto462)  
  
-   [SqlClient](#SQLClient)  
  
-   [Windows Communication Foundation](#WCF)  
  
-   [Windows Presentation Foundation (WPF)](#WPF462)  
  
-   [Windows Workflow Foundation (WF)](#WF462)  
  
-   [ClickOnce](#ClickOnce)  
  
-   [Converting Windows Forms and WPF apps to UWP apps](#UWPConvert)  
  
-   [Debugging improvements](#Debug462)  
  
 For a list of new APIs added to the .NET Framework 4.6.2, see [.NET Framework 4.6.2 API Changes](https://github.com/Microsoft/dotnet/blob/master/releases/net462/dotnet462-api-changes.md) on GitHub. For a list of feature improvements and bug fixes in the .NET Framework 4.6.2, see [.NET Framework 4.6.2 List of Changes](http://go.microsoft.com/fwlink/?LinkId=708778) on GitHub.  For additional information, see [Announcing .NET Framework 4.6.2](https://blogs.msdn.microsoft.com/dotnet/2016/08/02/announcing-net-framework-4-6-2/) in the .NET Blog.  
  
<a name="ASPNET462"></a>   
### ASP.NET  
 In the .NET Framework 4.6.2, ASP.NET includes the following enhancements:  
  
 **Improved support for localized error messages in data annotation validators**  
 Data annotation validators enable you to perform validation by adding one or more attributes to a class property. The attribute's [ValidationAttribute.ErrorMessage](assetId:///P:System.ComponentModel.DataAnnotations.ValidationAttribute.ErrorMessage?qualifyHint=True&autoUpgrade=True) element defines the text of the error message if validation fails. Starting with the .NET Framework 4.6.2, ASP.NET makes it easy to localize error messages. Error messages will be localized if:  
  
1.  The [ValidationAttribute.ErrorMessage](assetId:///P:System.ComponentModel.DataAnnotations.ValidationAttribute.ErrorMessage?qualifyHint=True&autoUpgrade=True) is provided in the validation attribute.  
  
2.  The resource file is stored in the App_LocalResources folder.  
  
3.  The name of the localized resources file has the form `DataAnnotation.Localization.{`*name*`}.resx`, where *name* is a culture name in the format *languageCode*`-`*country/regionCode* or *languageCode*.  
  
4.  The key name of the resource is the string assigned to the [ValidationAttribute.ErrorMessage](assetId:///P:System.ComponentModel.DataAnnotations.ValidationAttribute.ErrorMessage?qualifyHint=True&autoUpgrade=True) attribute,  and its value is the localized error message.  
  
 For example, the following data annotation attribute defines the default culture's error message for an invalid rating.  
  
```csharp  
  
public class RatingInfo  
{  
   [Required(ErrorMessage = "The rating must be between 1 and 10.")]  
   [Display(Name = "Your Rating")]  
   public int Rating { get; set; }  
}  
  
```  
  
```vb  
  
Public Class RatingInfo  
   \<Required(ErrorMessage = "The rating must be between 1 and 10.")>  
   \<Display(Name = "Your Rating")>  
   Public Property Rating As Integer = 1  
End Class  
  
```  
  
 You can then create a resource file, DataAnnotation.Localization.fr.resx, whose key is the error message string and whose value is the localized error message. The file must be found in the `App.LocalResources` folder. For example, the following is the key and its value in a localized French (fr) language error message:  
  
|Name|Value|  
|----------|-----------|  
|The rating must be between 1 and 10.|La note doit être comprise entre 1 et 10.|  
  
 This file can then  
  
 In addition, data annotation localization is extensible. Developers can plug in their own string localizer provider by implementing the [IStringLocalizerProvider](assetId:///T:System.Web.Globalization.IStringLocalizerProvider?qualifyHint=False&autoUpgrade=True) interface to store localization string somewhere other than in a resource file.  
  
 **Async support with session-state store providers**  
 ASP.NET now allows task-returning methods to be used with session-state store providers, thereby allowing ASP.NET apps to get the scalability benefits of async. To supports asynchronous operations with session state store providers, ASP.NET includes  a new interface, [System.Web.SessionState.ISessionStateModule](assetId:///T:System.Web.SessionState.ISessionStateModule?qualifyHint=True&autoUpgrade=True), which inherits from [IHttpModule](assetId:///T:System.Web.IHttpModule?qualifyHint=False&autoUpgrade=True) and allows developers to implement their own session-state module and async session store providers. The interface is defined as follows:  
  
```csharp  
  
public interface ISessionStateModule : IHttpModule {  
    void ReleaseSessionState(HttpContext context);  
    Task ReleaseSessionStateAsync(HttpContext context);  
}  
  
```  
  
 In addition, the [SessionStateUtility](assetId:///T:System.Web.SessionState.SessionStateUtility?qualifyHint=False&autoUpgrade=True) class includes two new methods, [IsSessionStateReadOnly](assetId:///M:System.Web.SessionState.SessionStateUtility.IsSessionStateReadOnly(System.Web.HttpContext)?qualifyHint=False&autoUpgrade=True) and [IsSessionStateRequired](assetId:///M:System.Web.SessionState.SessionStateUtility.IsSessionStateRequired(System.Web.HttpContext)?qualifyHint=False&autoUpgrade=True), that can be used to support asynchronous operations.  
  
 **Async support for output-cache providers**  
 Starting with the .NET Framework 4.6.2, task-returning methods can be used with output-cache providers to provide the scalability benefits of async.  Providers that implement these methods reduce thread-blocking on a web server and improve the scalability of an ASP.NET service.  
  
 The following APIs have been added to support asynchronous output-cache providers:  
  
-   The [System.Web.Caching.OutputCacheProviderAsync](assetId:///T:System.Web.Caching.OutputCacheProviderAsync?qualifyHint=True&autoUpgrade=True) class, which inherits from [System.Web.Caching.OutputCacheProvider](assetId:///T:System.Web.Caching.OutputCacheProvider?qualifyHint=True&autoUpgrade=True) and allows developers to implement an asynchronous output-cache provider.  
  
-   The [OutputCacheUtility](assetId:///T:System.Web.Caching.OutputCacheUtility?qualifyHint=False&autoUpgrade=True) class, which provides helper methods for configuring the output cache.  
  
-   18 new methods in the [System.Web.HttpCachePolicy](assetId:///T:System.Web.HttpCachePolicy?qualifyHint=True&autoUpgrade=True)class. These include [GetCacheability](assetId:///M:System.Web.HttpCachePolicy.GetCacheability?qualifyHint=False&autoUpgrade=True), [GetCacheExtensions](assetId:///M:System.Web.HttpCachePolicy.GetCacheExtensions?qualifyHint=False&autoUpgrade=True), [GetETag](assetId:///M:System.Web.HttpCachePolicy.GetETag?qualifyHint=False&autoUpgrade=True), [GetETagFromFileDependencies](assetId:///M:System.Web.HttpCachePolicy.GetETagFromFileDependencies?qualifyHint=False&autoUpgrade=True), [GetMaxAge](assetId:///M:System.Web.HttpCachePolicy.GetMaxAge?qualifyHint=False&autoUpgrade=True), [GetMaxAge](assetId:///M:System.Web.HttpCachePolicy.GetMaxAge?qualifyHint=False&autoUpgrade=True), [GetNoStore](assetId:///M:System.Web.HttpCachePolicy.GetNoStore?qualifyHint=False&autoUpgrade=True), [GetNoTransforms](assetId:///M:System.Web.HttpCachePolicy.GetNoTransforms?qualifyHint=False&autoUpgrade=True), [GetOmitVaryStar](assetId:///M:System.Web.HttpCachePolicy.GetOmitVaryStar?qualifyHint=False&autoUpgrade=True), [GetProxyMaxAge](assetId:///M:System.Web.HttpCachePolicy.GetProxyMaxAge?qualifyHint=False&autoUpgrade=True), [GetRevalidation](assetId:///M:System.Web.HttpCachePolicy.GetRevalidation?qualifyHint=False&autoUpgrade=True), [GetUtcLastModified](assetId:///M:System.Web.HttpCachePolicy.GetUtcLastModified?qualifyHint=False&autoUpgrade=True), [GetVaryByCustom](assetId:///M:System.Web.HttpCachePolicy.GetVaryByCustom?qualifyHint=False&autoUpgrade=True), [HasSlidingExpiration](assetId:///M:System.Web.HttpCachePolicy.HasSlidingExpiration?qualifyHint=False&autoUpgrade=True), and [IsValidUntilExpires](assetId:///M:System.Web.HttpCachePolicy.IsValidUntilExpires?qualifyHint=False&autoUpgrade=True).  
  
-   2 new methods in the [System.Web.HttpCacheVaryByContentEncodings](assetId:///T:System.Web.HttpCacheVaryByContentEncodings?qualifyHint=True&autoUpgrade=True) class:  [GetContentEncodings](assetId:///M:System.Web.HttpCacheVaryByContentEncodings.GetContentEncodings?qualifyHint=False&autoUpgrade=True) and [SetContentEncodings](assetId:///M:System.Web.HttpCacheVaryByContentEncodings.SetContentEncodings(System.String[])?qualifyHint=False&autoUpgrade=True).  
  
-   2 new methods in the [System.Web.HttpCacheVaryByHeaders](assetId:///T:System.Web.HttpCacheVaryByHeaders?qualifyHint=True&autoUpgrade=True) class: [GetHeaders](assetId:///M:System.Web.HttpCacheVaryByHeaders.GetHeaders?qualifyHint=False&autoUpgrade=True) and [SetHeaders](assetId:///M:System.Web.HttpCacheVaryByHeaders.SetHeaders(System.String[])?qualifyHint=False&autoUpgrade=True).  
  
-   2 new methods in the [System.Web.HttpCacheVaryByParams](assetId:///T:System.Web.HttpCacheVaryByParams?qualifyHint=True&autoUpgrade=True) class: [GetParams](assetId:///M:System.Web.HttpCacheVaryByParams.GetParams?qualifyHint=False&autoUpgrade=True) and [SetParams](assetId:///M:System.Web.HttpCacheVaryByParams.SetParams(System.String[])?qualifyHint=False&autoUpgrade=True).  
  
-   In the [System.Web.Caching.AggregateCacheDependency](assetId:///T:System.Web.Caching.AggregateCacheDependency?qualifyHint=True&autoUpgrade=True) class, the [GetFileDependencies](assetId:///M:System.Web.Caching.AggregateCacheDependency.GetFileDependencies?qualifyHint=False&autoUpgrade=True) method.  
  
-   In the [CacheDependency](assetId:///T:System.Web.Caching.CacheDependency?qualifyHint=False&autoUpgrade=True), the [GetFileDependencies](assetId:///M:System.Web.Caching.CacheDependency.GetFileDependencies?qualifyHint=False&autoUpgrade=True) method.  
  
<a name="Strings"></a>   
### Character categories  
 Characters in the  .NET Framework 4.6.2 are classified based on the [Unicode Standard, Version 8.0.0](http://www.unicode.org/versions/Unicode8.0.0/). In .NET Framework 4.6 and .NET Framework 4.6.1, characters were classified based on Unicode 6.3 character categories.  
  
 Support for Unicode 8.0 is limited to the classification of characters by the [CharUnicodeInfo](assetId:///T:System.Globalization.CharUnicodeInfo?qualifyHint=False&autoUpgrade=True) class and to types and methods that rely on it. These include the [StringInfo](assetId:///T:System.Globalization.StringInfo?qualifyHint=False&autoUpgrade=True) class, the overloaded [Char.GetUnicodeCategory](assetId:///M:System.Char.GetUnicodeCategory(System.Char)?qualifyHint=True&autoUpgrade=True) method, and the [character classes](../Topic/Character%20Classes%20in%20Regular%20Expressions.md) recognized by the .NET Framework regular expression engine.  Character and string comparison and sorting is unaffected by this change and continues to rely on the underlying operating system or, on Windows 7 systems, on character data provided by the .NET Framework.  
  
 For changes in character categories from Unicode 6.0 to Unicode 7.0, see [The Unicode Standard, Version 7.0.0](http://www.unicode.org/versions/Unicode7.0.0/) at The Unicode Consortium website. For changes from Unicode 7.0 to Unicode 8.0, see [The Unicode Standard, Version 8.0.0](http://www.unicode.org/versions/Unicode8.0.0/) at The Unicode Consortium website.  
  
<a name="Crypto462"></a>   
### Cryptography  
 **Support for X509 certificates containing FIPS 186-3 DSA**  
 The .NET Framework 4.6.2 adds support for DSA (Digital Signature Algorithm) X509 certificates whose keys exceed the FIPS 186-2 1024-bit limit.  
  
 In addition to supporting the larger key sizes of FIPS 186-3, the .NET Framework 4.6.2 allows computing signatures with the SHA-2 family of hash algorithms (SHA256, SHA384, and SHA512). FIPS 186-3 support is provided by the new [System.Security.Cryptography.DSACng](assetId:///T:System.Security.Cryptography.DSACng?qualifyHint=True&autoUpgrade=True) class.  
  
 In keeping with recent changes to the [RSA](assetId:///T:System.Security.Cryptography.RSA?qualifyHint=False&autoUpgrade=True) class in the .NET Framework 4.6 and the [ECDsa](assetId:///T:System.Security.Cryptography.ECDsa?qualifyHint=False&autoUpgrade=True) class in the .NET Framework 4.6.1, the [DSA](assetId:///T:System.Security.Cryptography.DSA?qualifyHint=False&autoUpgrade=True) abstract base class in .NET Framework 4.6.2 has additional methods to allow callers to use this functionality without casting. You can call the [DSACertificateExtensions.GetDSAPrivateKey](assetId:///M:System.Security.Cryptography.X509Certificates.DSACertificateExtensions.GetDSAPrivateKey(System.Security.Cryptography.X509Certificates.X509Certificate2)?qualifyHint=True&autoUpgrade=True) extension method to sign data, as the following example shows.  
  
```csharp  
  
public static byte[] SignDataDsaSha384(byte[] data, X509Certificate2 cert)  
{  
    using (DSA dsa = cert.GetDSAPrivateKey())  
    {  
        return dsa.SignData(data, HashAlgorithmName.SHA384);  
    }  
}  
  
```  
  
```vb  
  
Public Shared Function SignDataDsaSha384(data As Byte(), cert As X509Certificate2) As Byte()  
    Using DSA As DSA = cert.GetDSAPrivateKey()  
        Return DSA.SignData(data, HashAlgorithmName.SHA384)  
    End Using  
End Function  
  
```  
  
 And you can call the [DSACertificateExtensions.GetDSAPublicKey](assetId:///M:System.Security.Cryptography.X509Certificates.DSACertificateExtensions.GetDSAPublicKey(System.Security.Cryptography.X509Certificates.X509Certificate2)?qualifyHint=True&autoUpgrade=True) extension method to verify signed data, as the following example shows.  
  
```csharp  
  
public static bool VerifyDataDsaSha384(byte[] data, byte[] signature, X509Certificate2 cert)  
{  
    using (DSA dsa = cert.GetDSAPublicKey())  
    {  
        return dsa.VerifyData(data, signature, HashAlgorithmName.SHA384);  
    }  
}  
  
```  
  
```  
  
 Public Shared Function VerifyDataDsaSha384(data As Byte(), signature As Byte(), cert As X509Certificate2) As Boolean  
    Using dsa As DSA = cert.GetDSAPublicKey()  
        Return dsa.VerifyData(data, signature, HashAlgorithmName.SHA384)  
    End Using  
End Function  
  
```  
  
 **Increased clarity for inputs to ECDiffieHellman key derivation routines**  
 The .NET Framework 3.5 added support for Ellipic Curve Diffie-Hellman Key Agreement with three different Key Derivation Function (KDF) routines. The inputs to the routines, and the routines themselves, were configured via properties on the [ECDiffieHellmanCng](assetId:///T:System.Security.Cryptography.ECDiffieHellmanCng?qualifyHint=False&autoUpgrade=True) object. But since not every routine read every input property, there was ample room for confusion on the past of the developer.  
  
 To address this in the .NET Framework 4.6.2, the following three methods have been added to the  [ECDiffieHellman](assetId:///T:System.Security.Cryptography.ECDiffieHellman?qualifyHint=False&autoUpgrade=True) base class to more clearly represent these KDF routines and their inputs:  
  
|ECDiffieHellman method|Description|  
|----------------------------|-----------------|  
|[DeriveKeyFromHash(ECDiffieHellmanPublicKey, HashAlgorithmName, Byte\[\], Byte\[\])](assetId:///M:System.Security.Cryptography.ECDiffieHellman.DeriveKeyFromHash(System.Security.Cryptography.ECDiffieHellmanPublicKey,System.Security.Cryptography.HashAlgorithmName,System.Byte[],System.Byte[])?qualifyHint=False&autoUpgrade=False)|Derives key material using the formula<br /><br /> HASH(secretPrepend &#124;&#124; *x* &#124;&#124; secretAppend)<br /><br /> HASH(secretPrepend OrElse *x* OrElse secretAppend)<br /><br /> where *x* is the computed result of the EC Diffie-Hellman algorithm.|  
|[DeriveKeyFromHmac(ECDiffieHellmanPublicKey, HashAlgorithmName, Byte\[\], Byte\[\], Byte\[\])](assetId:///M:System.Security.Cryptography.ECDiffieHellman.DeriveKeyFromHmac(System.Security.Cryptography.ECDiffieHellmanPublicKey,System.Security.Cryptography.HashAlgorithmName,System.Byte[],System.Byte[],System.Byte[])?qualifyHint=False&autoUpgrade=False)|Derives key material using the formula<br /><br /> HMAC(hmacKey, secretPrepend &#124;&#124; *x* &#124;&#124; secretAppend)<br /><br /> HMAC(hmacKey, secretPrepend OrElse *x* OrElse secretAppend)<br /><br /> where *x* is the computed result of the EC Diffie-Hellman algorithm.|  
|[DeriveKeyTls(ECDiffieHellmanPublicKey, Byte\[\], Byte\[\])](assetId:///M:System.Security.Cryptography.ECDiffieHellman.DeriveKeyTls(System.Security.Cryptography.ECDiffieHellmanPublicKey,System.Byte[],System.Byte[])?qualifyHint=False&autoUpgrade=False)|Derives key material using the TLS pseudo-random function (PRF) derivation algorithm.|  
  
 **Support for persisted-key symmetric encryption**  
 The Windows cryptography library (CNG) added support for storing persisted symmetric keys and using hardware-stored symmetric keys, and the .NET Framework 4.6.2 mades it possible for developers to make use of this feature.  Since the notion of key names and key providers is implementation-specific, using this feature requires utilizing the constructor of the concrete implementation types instead of the preferred factory approach (such as calling `Aes.Create`).  
  
 Persisted-key symmetric encryption support exists for the AES ([AesCng](assetId:///T:System.Security.Cryptography.AesCng?qualifyHint=False&autoUpgrade=True)) and 3DES ([TripleDESCng](assetId:///T:System.Security.Cryptography.TripleDESCng?qualifyHint=False&autoUpgrade=True)) algorithms. For example:  
  
```csharp  
  
public static byte[] EncryptDataWithPersistedKey(byte[] data, byte[] iv)  
{  
    using (Aes aes = new AesCng("AesDemoKey", CngProvider.MicrosoftSoftwareKeyStorageProvider))  
    {  
        aes.IV = iv;  
  
        // Using the zero-argument overload is required to make use of the persisted key  
        using (ICryptoTransform encryptor = aes.CreateEncryptor())  
        {  
            if (!encryptor.CanTransformMultipleBlocks)  
            {  
                throw new InvalidOperationException("This is a sample, this case wasn’t handled...");  
            }  
  
            return encryptor.TransformFinalBlock(data, 0, data.Length);  
        }  
    }  
}  
  
```  
  
```vb  
  
Public Shared Function EncryptDataWithPersistedKey(data As Byte(), iv As Byte()) As Byte()  
    Using Aes As Aes = New AesCng("AesDemoKey", CngProvider.MicrosoftSoftwareKeyStorageProvider)  
        Aes.IV = iv  
  
        ' Using the zero-argument overload Is required to make use of the persisted key  
        Using encryptor As ICryptoTransform = Aes.CreateEncryptor()  
            If Not encryptor.CanTransformMultipleBlocks Then  
                Throw New InvalidOperationException("This is a sample, this case wasn’t handled...")  
            End If  
            Return encryptor.TransformFinalBlock(data, 0, data.Length)  
        End Using  
    End Using  
End Function  
  
```  
  
 **SignedXml support for SHA-2 hashing**  
 The .NET Framework 4.6.2 adds support to  the [SignedXml](assetId:///T:System.Security.Cryptography.Xml.SignedXml?qualifyHint=False&autoUpgrade=True) class for RSA-SHA256, RSA-SHA384, and RSA-SHA512 PKCS#1 signature methods, and SHA256, SHA384, and SHA512 reference digest algorithms.  
  
 The URI constants are all exposed on [SignedXml](xref:System.Security.Cryptography.Xml.SignedXml?qualifyHint=False&autoUpgrade=True):  
  
|SignedXml field|Constant|  
|---------------------|--------------|  
|[XmlDsigSHA256Url](assetId:///F:System.Security.Cryptography.Xml.SignedXml.XmlDsigSHA256Url?qualifyHint=False&autoUpgrade=True)|"http://www.w3.org/2001/04/xmlenc#sha256"|  
|[XmlDsigRSASHA256Url](assetId:///F:System.Security.Cryptography.Xml.SignedXml.XmlDsigRSASHA256Url?qualifyHint=False&autoUpgrade=True)|"http://www.w3.org/2001/04/xmldsig-more#rsa-sha256"|  
|[XmlDsigSHA384Url](assetId:///F:System.Security.Cryptography.Xml.SignedXml.XmlDsigSHA384Url?qualifyHint=False&autoUpgrade=True)|"http://www.w3.org/2001/04/xmldsig-more#sha384"|  
|[XmlDsigRSASHA384Url](assetId:///F:System.Security.Cryptography.Xml.SignedXml.XmlDsigRSASHA384Url?qualifyHint=False&autoUpgrade=True)|"http://www.w3.org/2001/04/xmldsig-more#rsa-sha384"|  
|[XmlDsigSHA512Url](assetId:///F:System.Security.Cryptography.Xml.SignedXml.XmlDsigSHA512Url?qualifyHint=False&autoUpgrade=True)|"http://www.w3.org/2001/04/xmlenc#sha512"|  
|[XmlDsigRSASHA512Url](assetId:///F:System.Security.Cryptography.Xml.SignedXml.XmlDsigRSASHA512Url?qualifyHint=False&autoUpgrade=True)|"http://www.w3.org/2001/04/xmldsig-more#rsa-sha512"|  
  
 Any programs that have registered a custom [SignatureDescription](assetId:///T:System.Security.Cryptography.SignatureDescription?qualifyHint=False&autoUpgrade=True) handler into [CryptoConfig](assetId:///T:System.Security.Cryptography.CryptoConfig?qualifyHint=False&autoUpgrade=True) to add support for these algorithms will continue to function as they did in the past, but since there are now platform defaults, the [CryptoConfig](assetId:///T:System.Security.Cryptography.CryptoConfig?qualifyHint=False&autoUpgrade=True) registration is no longer necessary.  
  
<a name="SQLClient"></a>   
### SqlClient  
 .NET Framework Data Provider for SQL Server ([System.Data.SqlClient](assetId:///N:System.Data.SqlClient?qualifyHint=True&autoUpgrade=True)) includes the following new features in the .NET Framework 4.6.2:  
  
 **Connection pooling and timeouts with Azure SQL databases**  
 When connection pooling is enabled and a timeout or other login error occurs, an exception is cached, and the cached exception is thrown on any subsequent connection attempt for the next 5 seconds  to 1 minute.  For more details, see [SQL Server Connection Pooling (ADO.NET)](../Topic/SQL%20Server%20Connection%20Pooling%20\(ADO.NET\).md).  
  
 This behavior is not desirable when connecting to Azure SQL Databases, since connection attempts can fail with transient errors that are typically recovered quickly. To better optimize the connection retry experience, the connection pool blocking period behavior is removed when connections to Azure SQL Databases fail.  
  
 The addition of the new `PoolBlockingPeriod` keyword lets you to select the blocking period best suited for your app. Values include:  
  
 `Auto`  
 The connection pool blocking period for an application that connects to an Azure SQL Database is disabled, and the connection pool blocking period for an application that connects to any other SQL Server instance is enabled. This is the default value. If the Server endpoint name ends with any of the following, they are considered Azure SQL Databases:  
  
-   .database.windows.net  
  
-   .database.chinacloudapi.cn  
  
-   .database.usgovcloudapi.net  
  
-   .database.cloudapi.de  
  
 `AlwaysBlock`  
 The connection pool blocking period is always enabled.  
  
 `NeverBlock`  
 The connection pool blocking period is always disabled.  
  
 **Enhancements for Always Encrypted**  
 SQLClient introduces two enhancements for Always Encrypted:  
  
-   To improve performance of parameterized queries against encrypted database columns, encryption metadata for query parameters is now cached. With the [SqlConnection.ColumnEncryptionQueryMetadataCacheEnabled](assetId:///P:System.Data.SqlClient.SqlConnection.ColumnEncryptionQueryMetadataCacheEnabled?qualifyHint=True&autoUpgrade=True) property set to `true` (which is the default value), if the same query is called multiple times, the client retrieves parameter metadata from the server only once.  
  
-   Column encryption key entries in the key cache are now evicted after a configurable time interval, set using the [SqlConnection.ColumnEncryptionKeyCacheTtl](assetId:///P:System.Data.SqlClient.SqlConnection.ColumnEncryptionKeyCacheTtl?qualifyHint=True&autoUpgrade=True) property.  
  
<a name="WCF"></a>   
### Windows Communication Foundation  
 In the .NET Framework 4.6.2, Windows Communication Foundation has been enhanced in the following areas:  
  
 **WCF transport security support for certificates stored using CNG**  
 WCF transport security supports certificates stored using the Windows cryptography library (CNG). In the .NET Framework 4.6.2, this support is limited to using certificates with a public key that has an exponent no more than 32 bits in length. When an application targets the .NET Framework 4.6.2, this feature is on by default.  
  
 For applications that target the .NET Framework 4.6.1 and earlier but are running on the .NET Framework 4.6.2 or later, this feature can be enabled by adding the following line to the [\<runtime>](../Topic/%3Cruntime%3E%20Element.md) section of the app.config or web.config file.  
  
```xml  
  
<AppContextSwitchOverrides  
    value="Switch.System.ServiceModel.DisableCngCertificates=false"  
/>  
  
```  
  
 This can also be done programmatically with code like the following:  
  
```csharp  
  
private const string DisableCngCertificates = @"Switch.System.ServiceModel.DisableCngCertificates";  
AppContext.SetSwitch(disableCngCertificates, false);  
  
```  
  
```vb  
  
Const DisableCngCertificates As String = "Switch.System.ServiceModel.DisableCngCertificates"  
AppContext.SetSwitch(disableCngCertificates, False)  
  
```  
  
 **Better support for multiple daylight saving time adjustment rules by the DataContractJsonSerializer class**  
 Customers can use an application configuration setting to determine whether the [DataContractJsonSerializer](assetId:///T:System.Runtime.Serialization.Json.DataContractJsonSerializer?qualifyHint=False&autoUpgrade=True) class supports multiple adjustment rules for a single time zone. This is an opt-in feature. To enable it, add the following setting to your app.config file:  
  
```xml  
  
<runtime>  
     <AppContextSwitchOverrides value="Switch.System.Runtime.Serialization.DoNotUseTimeZoneInfo=false" />  
</runtime>  
  
```  
  
 When this feature is enabled, a [DataContractJsonSerializer](assetId:///T:System.Runtime.Serialization.Json.DataContractJsonSerializer?qualifyHint=False&autoUpgrade=True) object  uses the [TimeZoneInfo](assetId:///T:System.TimeZoneInfo?qualifyHint=False&autoUpgrade=True) type instead of the [TimeZone](assetId:///T:System.TimeZone?qualifyHint=False&autoUpgrade=True) type to deserialize date and time data. [TimeZoneInfo](assetId:///T:System.TimeZoneInfo?qualifyHint=False&autoUpgrade=True) supports multiple adjustment rules, which makes it possible to work with historic time zone data;   [TimeZone](assetId:///T:System.TimeZone?qualifyHint=False&autoUpgrade=True) does not.  
  
 For more information on the [TimeZoneInfo](assetId:///T:System.TimeZoneInfo?qualifyHint=False&autoUpgrade=True) structure and time zone adjustments, see [Time Zone Overview](../Topic/Time%20Zone%20Overview.md).  
  
 **Support for preserving a UTC time when serializing and deserializing with the XMLSerializer class**  
 Ordinarily, when the [XmlSerializer](assetId:///T:System.Xml.Serialization.XmlSerializer?qualifyHint=False&autoUpgrade=True) class is used to serialize a UTC [DateTime](assetId:///T:System.DateTime?qualifyHint=False&autoUpgrade=True) value, it creates a serialized time string that preserves the date and time but assumes the time is local.  For example, if you instantiate a UTC date and time by calling the following code:  
  
```csharp  
DateTime utc = new DateTime(2016, 11, 07, 3, 0, 0, DateTimeKind.Utc);  
```  
  
```vb  
Dim utc As New Date(2016, 11, 07, 3, 0, 0, DateTimeKind.Utc)  
```  
  
 the result is the serialized time string "03:00:00.0000000-08:00" for a system eight hours behind UTC.  And serialized values are always deserialized as local date and time values.  
  
 You can use an application configuration setting to determine whether the [XmlSerializer](assetId:///T:System.Xml.Serialization.XmlSerializer?qualifyHint=False&autoUpgrade=True) preserves UTC time zone information when serializing and deserializing [DateTime](assetId:///T:System.DateTime?qualifyHint=False&autoUpgrade=True) values:  
  
```xml  
  
<runtime>  
     <AppContextSwitchOverrides   
          value="Switch.System.Runtime.Serialization.DisableSerializeUTCDateTimeToTimeAndDeserializeUTCTimeToUTCDateTime=false" />  
</runtime>  
  
```  
  
 When this feature is enabled, a [DataContractJsonSerializer](assetId:///T:System.Runtime.Serialization.Json.DataContractJsonSerializer?qualifyHint=False&autoUpgrade=True) object  uses the [TimeZoneInfo](assetId:///T:System.TimeZoneInfo?qualifyHint=False&autoUpgrade=True) type instead of the [TimeZone](assetId:///T:System.TimeZone?qualifyHint=False&autoUpgrade=True) type to deserialize date and time data. [TimeZoneInfo](assetId:///T:System.TimeZoneInfo?qualifyHint=False&autoUpgrade=True) supports multiple adjustment rules, which makes it possible to work with historic time zone data;   [TimeZone](assetId:///T:System.TimeZone?qualifyHint=False&autoUpgrade=True) does not.  
  
 For more information on the [TimeZoneInfo](assetId:///T:System.TimeZoneInfo?qualifyHint=False&autoUpgrade=True) structure and time zone adjustments, see [Time Zone Overview](../Topic/Time%20Zone%20Overview.md).  
  
 **NetNamedPipeBinding best match**  
 WCF has a new app setting that can be set on client applications to ensure they always connect to the service listening on the URI that best matches the one that they request. With this app setting set to `false` (the default), it is possible for clients using [NetNamedPipeBinding](assetId:///T:System.ServiceModel.NetNamedPipeBinding?qualifyHint=False&autoUpgrade=True) to attempt to connect to a service listening on a URI that is a substring of the requested URI.  
  
 For example, a client tries to connect to a service listening at `net.pipe://localhost/Service1`, but a different service on that machine running with administrator privilege is listening at `net.pipe://localhost`. With this app setting set to `false`, the client would attempt to connect to the wrong service. After setting the app setting to `true`, the client will always connect to the best matching service.  
  
> [!NOTE]
>  Clients using [NetNamedPipeBinding](assetId:///T:System.ServiceModel.NetNamedPipeBinding?qualifyHint=False&autoUpgrade=True) find services based on the service's base address (if it exists) rather than the full endpoint address. To ensure this setting always works the service should use a unique base address.  
  
 To enable this change, add the following app setting to your client application's App.config or Web.config file:  
  
```xml  
  
<configuration>  
    <appSettings>  
        <add key="wcf:useBestMatchNamedPipeUri" value="true" />  
    </appSettings>  
</configuration>  
  
```  
  
 **SSL 3.0 is not a default protocol**  
 When using NetTcp with transport security and a credential type of certificate, SSL 3.0 is no longer a default protocol used for negotiating a secure connection. In most cases, there should be no impact to existing apps, because TLS 1.0 is included in the protocol list for NetTcp. All existing clients should be able to negotiate a connection using at least TLS 1.0.      If Ssl3 is required, use one of the following configuration mechanisms to add it to the list of negotiated protocols.  
  
-   The [SslStreamSecurityBindingElement.SslProtocols](assetId:///P:System.ServiceModel.Channels.SslStreamSecurityBindingElement.SslProtocols?qualifyHint=True&autoUpgrade=True) property  
  
-   The [TcpTransportSecurity.SslProtocols](assetId:///P:System.ServiceModel.TcpTransportSecurity.SslProtocols?qualifyHint=True&autoUpgrade=True) property  
  
-   The [\<transport>](../Topic/%3Ctransport%3E%20of%20%3CnetTcpBinding%3E.md) section of the [\<netTcpBinding>](../Topic/%3CnetTcpBinding%3E.md) section  
  
-   The [\<sslStreamSecurity>](../Topic/%3CsslStreamSecurity%3E.md) section of the [\<customBinding>](../Topic/%3CcustomBinding%3E.md) section  
  
<a name="WPF462"></a>   
### Windows Presentation Foundation (WPF)  
 In the .NET Framework 4.6.2, Windows Presentation Foundation has been enhanced in the following areas:  
  
 **Group sorting**  
 An application that uses a [CollectionView](assetId:///T:System.Windows.Data.CollectionView?qualifyHint=False&autoUpgrade=True) object to group data can now explicitly declare how to  sort the groups. Explicit sorting addresses the problem of non-intuitive ordering that occurs when an app dynamically adds or removes groups, or when it changes the value of item properties involved in grouping. It can also improve the performance of the group creation process by moving comparisons of the grouping properties from the sort of the full collection to the sort of the groups.  
  
 To support group sorting, the new [GroupDescription.SortDescriptions](assetId:///P:System.ComponentModel.GroupDescription.SortDescriptions?qualifyHint=True&autoUpgrade=True) and [GroupDescription.CustomSort](assetId:///P:System.ComponentModel.GroupDescription.CustomSort?qualifyHint=True&autoUpgrade=True) properties describe how to sort the collection of groups produced by the [GroupDescription](assetId:///T:System.ComponentModel.GroupDescription?qualifyHint=False&autoUpgrade=True) object. This is analogous to the way the identically named [ListCollectionView](assetId:///T:System.Windows.Data.ListCollectionView?qualifyHint=False&autoUpgrade=True) properties describe how to sort the data items.  
  
 Two new static properties of the [PropertyGroupDescription](assetId:///T:System.Windows.Data.PropertyGroupDescription?qualifyHint=False&autoUpgrade=True) class,  [CompareNameAscending](assetId:///P:System.Windows.Data.PropertyGroupDescription.CompareNameAscending?qualifyHint=False&autoUpgrade=True) and [CompareNameDescending](assetId:///P:System.Windows.Data.PropertyGroupDescription.CompareNameDescending?qualifyHint=False&autoUpgrade=True), can be used for the most common cases.  
  
 For example, the following XAML groups data by age, sort the age groups in ascending order, and group the items within each age group by last name.  
  
```xaml  
  
<GroupDescriptions>  
     \<PropertyGroupDescription   
         PropertyName=”Age”   
         CustomSort=   
              ”{x:Static PropertyGroupDescription.CompareNamesAscending}”/>  
     </PropertyGroupDescription>  
</GroupDescriptions>  
  
<SortDescriptions>  
     \<SortDescription PropertyName=”LastName”/>  
</SortDescriptions>  
  
```  
  
 **Soft keyboard support**  
 Soft Keyboard support enables focus tracking in a WPF applications by automatically invoking and dismissing the new Soft Keyboard in Windows 10 when the touch input is received by a control that can take textual input.  
  
 In previous versions of the .NET Framework, WPF applications cannot opt into the focus tracking without disabling WPF pen/touch gesture support.  As a result, WPF applications must choose between full WPF touch support or rely on Windows mouse promotion.  
  
 **Per-monitor DPI**  
 To support the recent proliferation of high-DPI and hybrid-DPI environments for WPF apps, WPF in the .NET Framework 4.6.2 enables per-monitor awareness. See the [samples and developer guide](https://github.com/Microsoft/WPF-Samples/tree/master/PerMonitorDPI) on GitHub for more information about how to enable your WPF app to become per-monitor DPI aware.  
  
 In previous versions of the .NET Framework, WPF apps are system-DPI aware. In other words, the application's UI is scaled by the OS as appropriate, depending on the DPI of the monitor on which the app is rendered. ,  
  
 For apps running under the .NET Framework 4.6.2, you can disable per-monitor DPI changes in WPF apps by adding a configuration statement to the [\<runtime>](../Topic/%3Cruntime%3E%20Element.md) section of your application configuration file, as follows:  
  
```xml  
  
<runtime>  
   \<AppContextSwitchOverrides value=”Switch.System.Windows.DoNotScaleForDpiChanges=false”/>  
</runtime>  
  
```  
  
<a name="WF462"></a>   
### Windows Workflow Foundation (WF)  
 In the .NET Framework 4.6.2, Windows Workflow Foundation has been enhanced in the following area:  
  
 **Support for C# expressions and IntelliSense in the Re-hosted WF Designer**  
 Starting with the .NET Framework 4.5, WF supports C# expressions in both the Visual Studio Designer and in code workflows. The Re-hosted Workflow Designer is a key feature of WF that allows for the Workflow Designer to be in an application outside Visual Studio (for example, in WPF).  Windows Workflow Foundation provides the ability to support C# expressions and IntelliSense in the Re-hosted Workflow Designer. For more information, see the [Windows Workflow Foundation blog](http://go.microsoft.com/fwlink/?LinkID=809042&clcid=0x409).  
  
 `Availability of IntelliSense when a customer rebuilds a workflow project from Visual Studio`  
 In versions of the .NET Framework prior to the .NET Framework 4.6.2, WF Designer IntelliSense is broken when a customer rebuilds a workflow project from Visual Studio. While the project build is successful, the workflow types are not found on the designer, and warnings from IntelliSense for the missing workflow types appear in the **Error List** window. The .NET Framework 4.6.2 addresses this issue and makes IntelliSense available.  
  
 **Workflow V1 applications with Workflow Tracking on now run under FIPS-mode**  
 Machines with FIPS Compliance Mode enabled can now successfully run a workflow Version 1-style application with Workflow tracking on. To enable this scenario, you must make the following change to your app.config file:  
  
```xml  
<add key="microsoft:WorkflowRuntime:FIPSRequired" value="true" />  
```  
  
 If this scenario is not enabled, running the application continues to generate an exception with the message, "This implementation is not part of the Windows Platform FIPS validated cryptographic algorithms."  
  
 **Workflow Improvements when using Dynamic Update with Visual Studio Workflow Designer**  
 The Workflow Designer, FlowChart Activity Designer, and other Workflow Activity Designers now successfully load and display workflows that have been saved after calling  the [DynamicUpdateServices.PrepareForUpdate](assetId:///M:System.Activities.DynamicUpdate.DynamicUpdateServices.PrepareForUpdate(System.Activities.Activity)?qualifyHint=True&autoUpgrade=True) method. In versions of the .NET Framework before the .NET Framework 4.6.2, loading a XAML file in Visual Studio for a workflow that has been saved after calling [DynamicUpdateServices.PrepareForUpdate](assetId:///M:System.Activities.DynamicUpdate.DynamicUpdateServices.PrepareForUpdate(System.Activities.Activity)?qualifyHint=True&autoUpgrade=True) can result in the following issues:  
  
-   The Workflow Designer can't load the XAML file correctly (when the [ViewStateData.Id](assetId:///P:System.Activities.Presentation.ViewState.ViewStateData.Id?qualifyHint=True&autoUpgrade=True) is at the end of the line).  
  
-   Flowchart Activity Designer or other Workflow Activity Designers may display all objects in their default locations as opposed to attached property values.  
  
<a name="ClickOnce"></a>   
### ClickOnce  
 ClickOnce has been updated to support TLS 1.1 and TLS 1.2 in addition to the 1.0 protocol, which it already supports. ClickOnce automatically detects which protocol is required; no extra steps within the ClickOnce application are required to enable TLS 1.1 and 1.2 support.  
  
<a name="UWPConvert"></a>   
### Converting Windows Forms and WPF apps to  UWP apps  
 Windows now offers capabilities to bring existing Windows desktop apps, including WPF and Windows Forms apps, to the Universal Windows Platform (UWP). This technology acts as a bridge by enabling you to gradually migrate your existing code base to UWP, thereby bringing your app to all Windows 10 devices.  
  
 Converted desktop apps gain an app identity similar to the app identity of UWP apps, which makes UWP APIs accessible to enable features such as Live Tiles and notifications. The app continues to behave as before and runs as a full trust app. Once the app is converted, an app container process can be added to the existing full trust process to add an adaptive user interface. When all functionality is moved to the app container process, the full trust process can be removed and the new UWP app can be made available to all Windows 10 devices.  
  
<a name="Debug462"></a>   
### Debugging improvements  
 The *unmanaged debugging API* has been enhanced in the .NET Framework 4.6.2 to perform additional analysis when a [NullReferenceException](assetId:///T:System.NullReferenceException?qualifyHint=False&autoUpgrade=True) is thrown so that it is possible to determine which variable in a single line of source code is `null`.   To support this scenario, the following APIs have been added to the unmanaged debugging API.  
  
-   The [ICorDebugCode4](../Topic/ICorDebugCode4%20Interface.md), [ICorDebugVariableHome](../Topic/ICorDebugVariableHome%20Interface.md), and [ICorDebugVariableHomeEnum](../Topic/ICorDebugVariableHomeEnum%20Interface.md) interfaces, which expose the native homes of managed variables. This enables debuggers to do some code flow analysis when a  [NullReferenceException](assetId:///T:System.NullReferenceException?qualifyHint=False&autoUpgrade=True) occurs and to work backwards to determine the managed variable that corresponds to the native location that was `null`.  
  
-   The [ICorDebugType2::GetTypeID](../Topic/ICorDebugType2::GetTypeID%20Method.md) method provides a mapping for ICorDebugType to [COR_TYPEID](../Topic/COR_TYPEID%20Structure.md), which allows the debugger to obtain a [COR_TYPEID](../Topic/COR_TYPEID%20Structure.md) without an instance of the ICorDebugType. Existing APIs on [COR_TYPEID](../Topic/COR_TYPEID%20Structure.md) can then be used to determine the class layout of the type.  
  
<a name="v461"></a>   
## What's new in the .NET Framework 4.6.1  
 The .NET Framework 4.6.1 includes new features in the following areas:  
  
-   [Cryptography](#Crypto)  
  
-   [ADO.NET](#ADO.NET461)  
  
-   [Windows Presentation Foundation (WPF)](#WPF461)  
  
-   [Windows Workflow Foundation](#WWF461)  
  
-   [Profiling](#Profile461)  
  
-   [NGen](#NGEN461)  
  
 For more information on the .NET Framework 4.6.1, see the following topics:  
  
-   The [.NET Framework 4.6.1 list of changes](http://go.microsoft.com/fwlink/?LinkId=622964)  
  
-   [Application Compatibility in 4.6.1](../Topic/Application%20Compatibility%20in%20the%20.NET%20Framework%204.6.1.md)  
  
-   [The .NET Framework API diff](http://go.microsoft.com/fwlink/?LinkId=622989) (on GitHub)  
  
<a name="Crypto"></a>   
### Cryptography: Support for X509 certificates containing ECDSA  
 The .NET Framework 4.6 added RSACng support for X509 certificates. The .NET Framework 4.6.1 adds support for ECDSA (Elliptic Curve Digital Signature Algorithm) X509 certificates.  
  
 ECDSA offers better performance and is a more secure cryptography algorithm than RSA, providing an excellent choice where Transport Layer Security (TLS) performance and scalability is a concern. The .NET Framework implementation wraps calls into existing Windows functionality.  
  
 The following example code shows how easy it is to generate a signature for a byte stream by using the new  support for ECDSA  X509 certificates included in the .NET Framework 4.6.1.  
  
<!-- TODO: review snippet reference  [!CODE [whatsnew.461.crypto#1](../CodeSnippet/VS_Snippets_CLR/whatsnew.461.crypto#1)]  -->  
  
 This offers a marked contrast to the code needed to generate a signature in the .NET Framework 4.6.  
  
<!-- TODO: review snippet reference  [!CODE [whatsnew.461.crypto#2](../CodeSnippet/VS_Snippets_CLR/whatsnew.461.crypto#2)]  -->  
  
<a name="ADO.NET461"></a>   
### ADO.NET  
 The following have been added to ADO.NET:  
  
 Always Encrypted support for hardware protected keys  
 ADO.NET now supports storing Always Encrypted column master keys natively in Hardware Security Modules (HSMs). With this support, customers can leverage asymmetric keys stored in HSMs without having to write custom column master key store providers and registering them in applications.  
  
 Customers need to install the HSM vendor-provided CSP provider or CNG key store providers on the app servers or client computers in order to access Always Encrypted data protected with column master keys stored in a HSM.  
  
 Improve [MultiSubnetFailover](assetId:///P:System.Data.SqlClient.SqlConnectionStringBuilder.MultiSubnetFailover?qualifyHint=False&autoUpgrade=True) connection behavior for AlwaysOn  
 SqlClient now automatically provides faster connection to an AlwaysOn Availability Group (AG). It transparently detects whether your application is connecting to an AlwaysOn availability group (AG) on a different subnet and quickly discovers the current active server and provides a connection to the server. Prior to this release, an application had to set the connection string to include `“MultisubnetFailover=true”` to indicate that it was connecting to an AlwaysOn Availability Group. Without setting the connection keyword to `true`, an application might experience a timeout while connecting to an AlwaysOn Availability Group. With this release, an application does *not* need to set [MultiSubnetFailover](assetId:///P:System.Data.SqlClient.SqlConnectionStringBuilder.MultiSubnetFailover?qualifyHint=False&autoUpgrade=True) to `true` anymore. For more information about SqlClient support for Always On Availability Groups, see [SqlClient Support for High Availability, Disaster Recovery](../Topic/SqlClient%20Support%20for%20High%20Availability,%20Disaster%20Recovery.md).  
  
<a name="WPF461"></a>   
### Windows Presentation Foundation (WPF)  
 Windows Presentation Foundation includes a number of improvements and changes.  
  
 Improved performance  
 The delay in firing touch events has been fixed in the .NET Framework 4.6.1. In addition, typing in a [RichTextBox](assetId:///T:System.Windows.Controls.RichTextBox?qualifyHint=False&autoUpgrade=True) control no longer ties up the render thread during fast input.  
  
 Spell checking improvements  
 The spell checker in WPF has been updated on Windows 8.1 and later versions to leverage operating system support for spell-checking additional languages.  There is no change in functionality on Windows versions prior to Windows 8.1.  
  
 As in previous versions of the .NET Framework, the language for a [TextBox](assetId:///T:System.Windows.Controls.TextBox?qualifyHint=False&autoUpgrade=True) control ora [RichTextBox](assetId:///T:System.Windows.Controls.RichTextBox?qualifyHint=False&autoUpgrade=True) block is detected by looking for information in the following order:  
  
-   `xml:lang`, if it is present.  
  
-   Current input language.  
  
-   Current thread culture.  
  
 For additional information on language support in WPF, see the [WPF blog post on .NET Framework 4.6.1 features](http://go.microsoft.com/fwlink/?LinkID=691819).  
  
 Additional support for per-user custom dictionaries  
 In .NET Framework 4.6.1, WPF recognizes custom dictionaries that are registered globally. This capability is available in addition to the ability to register them per-control.  
  
 In previous versions of WPF, custom dictionaries did not recognize Excluded Words and AutoCorrect lists. They are supported on Windows 8.1 and Windows 10 through the use of files that can be placed under the `%AppData%\Microsoft\Spelling\<language tag>` directory.  The following rules apply to these files:  
  
-   The files should have extensions of .dic (for added words), .exc (for excluded words), or .acl (for AutoCorrect).  
  
-   The files should be UTF-16 LE plaintext that starts with the Byte Order Mark (BOM).  
  
-   Each line should consist of a word (in the added and excluded word lists), or an autocorrect pair with the words separated by a vertical bar (“&#124;”) (in the AutoCorrect word list).  
  
-   These files are considered read-only and are not modified by the system.  
  
> [!NOTE]
>  These new file-formats are not directly supported by the WPF spell checking API’s, and the custom dictionaries supplied to WPF in applications should continue to use .lex files.  
  
 Samples  
 There are a number of [WPF Samples](https://msdn.microsoft.com/library/ms771633.aspx) on MSDN. More than 200 of the most popular samples (based on their usage) will be moved into an [Open Source GitHub repository](https://github.com/Microsoft/WPF-Samples). Help us improve our samples by sending us a pull-request or opening a [GitHub issue](https://github.com/Microsoft/WPF-Samples/issues).  
  
 DirectX extensions  
 WPF includes a [NuGet package](http://go.microsoft.com/fwlink/?LinkID=691342) that provides new implementations of [D3DImage](assetId:///T:System.Windows.Interop.D3DImage?qualifyHint=False&autoUpgrade=True) that make it easy for you to interoperate with DX10 and Dx11 content. The code for this package has been open sourced and is available [on GitHub](https://github.com/Microsoft/WPFDXInterop).  
  
<a name="WWF461"></a>   
### Windows Workflow Foundation: Transactions  
 The [Transaction.EnlistPromotableSinglePhase](assetId:///Overload:System.Transactions.Transaction.EnlistPromotableSinglePhase?qualifyHint=True&autoUpgrade=True) method can now use a distributed transaction manager other than MSDTC to promote the transaction. You do this by specifying a GUID transaction promoter identifier to the  new [Transaction.EnlistPromotableSinglePhase(IPromotableSinglePhaseNotification, Guid)](assetId:///M:System.Transactions.Transaction.EnlistPromotableSinglePhase(System.Transactions.IPromotableSinglePhaseNotification,System.Guid)?qualifyHint=True&autoUpgrade=False) overload . If this operation is successful, there are limitations placed on the capabilities of the transaction. Once a non-MSDTC transaction promoter is enlisted, the following methods throw a [TransactionPromotionException](assetId:///T:System.Transactions.TransactionPromotionException?qualifyHint=False&autoUpgrade=True) because these methods require promotion to MSDTC:  
  
-   [Transaction.EnlistDurable](assetId:///Overload:System.Transactions.Transaction.EnlistDurable?qualifyHint=True&autoUpgrade=True)  
  
-   [TransactionInterop.GetDtcTransaction](assetId:///M:System.Transactions.TransactionInterop.GetDtcTransaction(System.Transactions.Transaction)?qualifyHint=True&autoUpgrade=True)  
  
-   [TransactionInterop.GetExportCookie](assetId:///M:System.Transactions.TransactionInterop.GetExportCookie(System.Transactions.Transaction,System.Byte[])?qualifyHint=True&autoUpgrade=True)  
  
-   [TransactionInterop.GetTransmitterPropagationToken](assetId:///M:System.Transactions.TransactionInterop.GetTransmitterPropagationToken(System.Transactions.Transaction)?qualifyHint=True&autoUpgrade=True)  
  
 Once a non-MSDTC transaction promoter is enlisted, it must be used for future durable enlistments by using protocols that it defines. The [Guid](assetId:///T:System.Guid?qualifyHint=False&autoUpgrade=True) of the transaction promoter can be obtained by using the [PromoterType](assetId:///P:System.Transactions.Transaction.PromoterType?qualifyHint=False&autoUpgrade=True) property. When the transaction promotes, the transaction promoter provides a [Byte](assetId:///T:System.Byte?qualifyHint=False&autoUpgrade=True) array that represents the promoted token. An application can obtain the promoted token for a non-MSDTC promoted transaction with the [GetPromotedToken](assetId:///M:System.Transactions.Transaction.GetPromotedToken?qualifyHint=False&autoUpgrade=True) method.  
  
 Users of the new [Transaction.EnlistPromotableSinglePhase(IPromotableSinglePhaseNotification, Guid)](assetId:///M:System.Transactions.Transaction.EnlistPromotableSinglePhase(System.Transactions.IPromotableSinglePhaseNotification,System.Guid)?qualifyHint=True&autoUpgrade=False) overload must follow a specific call sequence in order for the promotion operation to complete successfully. These rules are documented in the method's documentation.  
  
<a name="Profile461"></a>   
### Profiling  
 The unmanaged profiling API has been enhanced follows:  
  
 Better support for accessing PDBs in the [ICorProfilerInfo7](../Topic/ICorProfilerInfo7%20Interface.md) interface  
 In ASP.Net 5, it is becoming much more common for assemblies to be compiled in-memory by Roslyn. For developers making profiling tools, this means that PDBs that historically were serialized on disk may no longer be present. Profiler tools often use PDBs to map code back to source lines for tasks such as code coverage or line-by-line performance analysis. The [ICorProfilerInfo7](../Topic/ICorProfilerInfo7%20Interface.md) interface now includes two new methods, [ICorProfilerInfo7::GetInMemorySymbolsLength](../Topic/ICorProfilerInfo7::GetInMemorySymbolsLength%20Method.md) and [ICorProfilerInfo7::ReadInMemorySymbols](../Topic/ICorProfilerInfo7::ReadInMemorySymbols.md), to provide these profiler tools with access to the in-memory PDB data, By using the new APIs, a profiler can obtain the contents of an in-memory PDB as a byte array and then process it or serialize it to disk.  
  
 Better instrumentation with the ICorProfiler interface  
 Profilers that are using the `ICorProfiler` API’s ReJit functionality for dynamic instrumentation can now modify some metadata. Previously such tools could instrument IL at any time, but metadata could only be modified at module load time. Because IL refers to metadata, this limited the kinds of instrumentation that could be done. We have lifted some of those limits by adding the [ICorProfilerInfo7::ApplyMetaData](../Topic/ICorProfilerInfo7::ApplyMetaData%20Method.md) method to support a subset of metadata edits after the module loads, in particular by adding new `AssemblyRef`, `TypeRef`, `TypeSpec`, `MemberRef`, `MemberSpec`, and `UserString` records. This change makes a much broader range of on-the-fly instrumentation possible.  
  
<a name="NGEN461"></a>   
### Native Image Generator (NGEN) PDBs  
 Cross-machine event tracing allows customers to profile a program on Machine A and look at the profiling data with source line mapping on Machine B. Using previous versions of the .NET Framework, the user would copy all the modules and native images from the profiled machine to the analysis machine that contains the IL PDB to create the source-to-native mapping. While this process may work well when the files are relatively small, such as for phone applications, the files can be very large on desktop systems and require significant time to copy.  
  
 With Ngen PDBs, NGen can create a PDB that contains the IL-to-native mapping without a dependency on the IL PDB. In our cross-machine event tracing scenario, all that is needed is to copy the native image PDB that is generated by Machine A to Machine B and to use [Debug Interface Access APIs](https://docs.microsoft.com/en-us/visualstudio/debugger/debug-interface-access/debug-interface-access-sdk-reference) to read the IL PDB's source-to-IL mapping and the native image PDB's IL-to-native mapping. Combining both mappings provides a source-to-native mapping. Since the native image PDB is much smaller than all the modules and native images, the process of copying from Machine A to Machine B is much faster.  
  
<a name="v46"></a>   
## What's new in .NET 2015  
 .NET 2015 introduces the .NET Framework 4.6 and .NET Core. Some new features apply to both, and other features are specific to .NET Framework 4.6 or .NET Core.  
  
-   **ASP.NET 5**  
  
     .NET 2015 includes ASP.NET 5, which is a lean .NET platform for building modern cloud-based apps. The platform is modular so you can include only those features that are needed in your application. It can be hosted on IIS or self-hosted in a custom process, and you can run apps with different versions of the .NET Framework on the same server. It includes a new environment configuration system that is designed for cloud deployment.  
  
     MVC, Web API, and Web Pages are unified into a single framework called MVC 6. You build ASP.NET 5 apps through the new tools in Visual Studio 2015. Your existing applications will work on the new .NET Framework; however to build an app that uses MVC 6 or SignalR 3, you must use the project system in Visual Studio 2015.  
  
     For information, see [ASP.NET 5](http://go.microsoft.com/fwlink/?LinkId=518238).  
  
-   **ASP.NET Updates**  
  
    -   **Task-based API for Asynchronous Response Flushing**  
  
         ASP.NET now provides a simple task-based API for asynchronous response flushing, [HttpResponse.FlushAsync](assetId:///M:System.Web.HttpResponse.FlushAsync?qualifyHint=True&autoUpgrade=True), that allows responses to be flushed asynchronously by using your language's `async/await` support.  
  
    -   `Model binding supports task-returning methods`  
  
         In the .NET Framework 4.5, ASP.NET added the Model Binding feature that enabled an extensible, code-focused approach to CRUD-based data operations in Web Forms pages and user controls. The Model Binding system now supports [Task](assetId:///T:System.Threading.Tasks.Task?qualifyHint=False&autoUpgrade=True)-returning model binding methods. This feature allows Web Forms developers to get the scalability benefits of async with the ease of the data-binding system when using newer versions of ORMs, including the Entity Framework.  
  
         Async model binding is controlled by the `aspnet:EnableAsyncModelBinding` configuration setting.  
  
        ```  
  
        <appSettings>  
           <add key=" aspnet:EnableAsyncModelBinding" value="true|false" />  
        </appSettings>  
  
        ```  
  
         On apps the target the .NET Framework 4.6, it defaults to `true`. On apps running on the .NET Framework 4.6 that target an earlier version of the .NET Framework, it is `false` by default. It can be enabled by setting the configuration setting to `true`.  
  
    -   **HTTP/2 Support (Windows 10)**  
  
         [HTTP/2](http://www.wikipedia.org/wiki/HTTP/2) is a new version of the HTTP protocol that provides much better connection utilization (fewer round-trips between client and server), resulting in lower latency web page loading for users.  Web pages (as opposed to services) benefit the most from HTTP/2, since the protocol optimizes for multiple artifacts being requested as part of a single experience. HTTP/2 support has been added to ASP.NET in the .NET Framework 4.6. Because networking functionality exists at multiple layers, new features were required in Windows, in IIS, and in ASP.NET to enable HTTP/2. You must be running on Windows 10 to use HTTP/2 with ASP.NET.  
  
         HTTP/2 is also supported and on by default for Windows 10 Universal Windows Platform (UWP) apps that use the [System.Net.Http.HttpClient](assetId:///T:System.Net.Http.HttpClient?qualifyHint=True&autoUpgrade=True) API.  
  
         In order to provide a way to use the [PUSH_PROMISE](http://http2.github.io/http2-spec/#PUSH_PROMISE) feature in ASP.NET applications, a new method with two overloads, [PushPromise(String)](assetId:///M:System.Web.HttpResponse.PushPromise(System.String)?qualifyHint=False&autoUpgrade=False) and [PushPromise(String, String, NameValueCollection)](assetId:///M:System.Web.HttpResponse.PushPromise(System.String,System.String,System.Collections.Specialized.NameValueCollection)?qualifyHint=False&autoUpgrade=False), has been added to the [HttpResponse](assetId:///T:System.Web.HttpResponse?qualifyHint=False&autoUpgrade=True) class.  
  
        > [!NOTE]
        >  While ASP.NET 5 supports HTTP/2, support for the PUSH PROMISE feature has not yet been added.  
  
         The browser and the web server (IIS on Windows) do all the work. You don't have to do any heavy-lifting for your users.  
  
         Most of the [major browsers support HTTP/2](http://www.wikipedia.org/wiki/HTTP/2), so it's likely that your users will benefit from HTTP/2 support if your server supports it.  
  
    -   **Support for the Token Binding Protocol**  
  
         Microsoft and Google have been collaborating on a new approach to authentication, called the [Token Binding Protocol](https://github.com/TokenBinding/Internet-Drafts). The premise is that authentication tokens (in your browser cache) can be stolen and used by criminals to access otherwise secure resources (e.g. your bank account) without requiring your password or any other privileged knowledge. The new protocol aims to mitigate this problem.  
  
         The Token Binding Protocol will be implemented in Windows 10 as a browser feature. ASP.NET apps will participate in the protocol, so that authentication tokens are validated to be legitimate. The client and the server implementations establish the end-to-end protection specified by the protocol.  
  
    -   **Randomized string hash algorithms**  
  
         The .NET Framework 4.5 introduced a [randomized string hash algorithm](https://msdn.microsoft.com/library/jj152924.aspx). However, it was not supported by ASP.NET because of some ASP.NET features depended on a stable hash code. In .NET Framework 4.6, randomized string hash algorithms are now supported. To enable this feature, use the `aspnet:UseRandomizedStringHashAlgorithm` config setting.  
  
        ```  
  
        <appSettings>  
           <add key="aspnet:UseRandomizedStringHashAlgorithm" value="true|false" />  
        </appSettings>  
  
        ```  
  
-   **ADO.NET**  
  
     ADO .NET now supports the Always Encrypted feature available in SQL Server 2016 Community Technology Preview 2 (CTP2). With Always Encrypted, SQL Server can perform operations on encrypted data, and best of all the encryption key resides with the application inside the customer’s trusted environment and not on the server. Always Encrypted secures customer data so DBAs do not have access to plain text data. Encryption and decryption of data happens transparently at the driver level, minimizing changes that have to be made to existing applications. For details, see [Always Encrypted (Database Engine)](https://msdn.microsoft.com/library/mt163865\(v=sql.130\).aspx) and [Always Encrypted (client development)](https://msdn.microsoft.com/library/mt147923\(v=sql.130\).aspx).  
  
-   **64-bit JIT Compiler for managed code**  
  
     The .NET Framework 4.6 features a new version of the 64-bit JIT compiler (originally code-named RyuJIT). The new 64-bit compiler provides significant performance improvements over the older 64-bit JIT compiler. The new 64-bit compiler is enabled for 64-bit processes running on top of the .NET Framework 4.6. Your app will run in a 64-bit process if it is compiled as 64-bit or AnyCPU and is running on a 64-bit operating system. While care has been taken to make the transition to the new compiler as transparent as possible, changes in behavior are possible. We would like to hear directly about any issues encountered when using the new JIT compiler. Please contact us through [Microsoft Connect](http://connect.microsoft.com/) if you encounter an issue that may be related to the new 64-bit JIT compiler.  
  
     The new 64-bit JIT compiler also includes hardware SIMD acceleration features when coupled with SIMD-enabled types in the [System.Numerics](assetId:///N:System.Numerics?qualifyHint=False&autoUpgrade=True) namespace, which can yield good performance improvements.  
  
-   **Assembly loader improvements**  
  
     The assembly loader now uses memory more efficiently by unloading IL assemblies after a corresponding NGEN image is loaded. This change decreases virtual memory, which is particularly beneficial for large 32-bit apps (such as Visual Studio), and also saves physical memory.  
  
-   **Base class library changes**  
  
     Many new APIs have been added around to .NET Framework 4.6 to enable key scenarios. These include the following changes and additions:  
  
    -   **IReadOnlyCollection\<T> implementations**  
  
         Additional collections implement [IReadOnlyCollection\<T>](assetId:///T:System.Collections.Generic.IReadOnlyCollection`1?qualifyHint=False&autoUpgrade=True) such as [Queue<T\>](assetId:///T:System.Collections.Generic.Queue`1?qualifyHint=False&autoUpgrade=True) and [Stack\<T>](assetId:///T:System.Collections.Generic.Stack`1?qualifyHint=False&autoUpgrade=True).  
  
    -   **CultureInfo.CurrentCulture and CultureInfo.CurrentUICulture**  
  
         The [CultureInfo.CurrentCulture](assetId:///P:System.Globalization.CultureInfo.CurrentCulture?qualifyHint=True&autoUpgrade=True) and [CultureInfo.CurrentUICulture](assetId:///P:System.Globalization.CultureInfo.CurrentUICulture?qualifyHint=True&autoUpgrade=True) properties are now read-write rather than read-only. If you assign a new [CultureInfo](assetId:///T:System.Globalization.CultureInfo?qualifyHint=False&autoUpgrade=True) object to these properties, the current thread culture defined by the `Thread.CurrentThread.CurrentCulture` property and the current UI thread culture defined by the `Thread.CurrentThread.CurrentUICulture` properties also change.  
  
    -   **Enhancements to garbage collection (GC)**  
  
         The [GC](assetId:///T:System.GC?qualifyHint=False&autoUpgrade=True) class now includes [TryStartNoGCRegion](assetId:///M:System.GC.TryStartNoGCRegion(System.Int64)?qualifyHint=False&autoUpgrade=True) and [EndNoGCRegion](assetId:///M:System.GC.EndNoGCRegion?qualifyHint=False&autoUpgrade=True) methods that allow you to disallow garbage collection during the execution of a critical path.  
  
         A new overload of the [GC.Collect(Int32, GCCollectionMode, Boolean, Boolean)](assetId:///M:System.GC.Collect(System.Int32,System.GCCollectionMode,System.Boolean,System.Boolean)?qualifyHint=True&autoUpgrade=False) method allows you to control whether both the small object heap and the large object heap are swept and compacted or swept only.  
  
    -   **SIMD-enabled types**  
  
         The [System.Numerics](assetId:///N:System.Numerics?qualifyHint=False&autoUpgrade=True) namespace now includes a number of SIMD-enabled types, such as [Matrix3x2](assetId:///T:System.Numerics.Matrix3x2?qualifyHint=False&autoUpgrade=True), [Matrix4x4](assetId:///T:System.Numerics.Matrix4x4?qualifyHint=False&autoUpgrade=True), [Plane](assetId:///T:System.Numerics.Plane?qualifyHint=False&autoUpgrade=True), [Quaternion](assetId:///T:System.Numerics.Quaternion?qualifyHint=False&autoUpgrade=True), [Vector2](assetId:///T:System.Numerics.Vector2?qualifyHint=False&autoUpgrade=True), [Vector3](assetId:///T:System.Numerics.Vector3?qualifyHint=False&autoUpgrade=True), and [Vector4](assetId:///T:System.Numerics.Vector4?qualifyHint=False&autoUpgrade=True).  
  
         Because the new 64-bit JIT compiler also includes hardware SIMD acceleration features, there are especially significant performance improvements when using the SIMD-enabled types with the new 64-bit JIT compiler.  
  
    -   **Cryptography updates**  
  
         The [System.Security.Cryptography](assetId:///N:System.Security.Cryptography?qualifyHint=True&autoUpgrade=True) API is being updated to support the [Windows CNG cryptography APIs](https://msdn.microsoft.com/library/windows/desktop/aa376214.aspx). Previous versions of the .NET Framework have relied entirely on an [earlier version of the Windows Cryptography APIs](https://msdn.microsoft.com/library/windows/desktop/aa380255.aspx) as the basis for the [System.Security.Cryptography](assetId:///N:System.Security.Cryptography?qualifyHint=True&autoUpgrade=True) implementation. We have had requests to support the CNG API, since it supports [modern cryptography algorithms](https://msdn.microsoft.com/library/windows/desktop/bb204775.aspx#suite_b_support), which are important for certain categories of apps.  
  
         The .NET Framework 4.6 includes the following new enhancements to support the Windows CNG cryptography APIs:  
  
        -   A set of extension methods for X509 Certificates, `System.Security.Cryptography.X509Certificates.RSACertificateExtensions.GetRSAPublicKey(System.Security.Cryptography.X509Certificates.X509Certificate2)` and `System.Security.Cryptography.X509Certificates.RSACertificateExtensions.GetRSAPrivateKey(System.Security.Cryptography.X509Certificates.X509Certificate2)`, that return a CNG-based implementation rather than a CAPI-based implementation when possible. (Some smartcards, etc., still require CAPI, and the APIs handle the fallback).  
  
        -   The [System.Security.Cryptography.RSACng](assetId:///T:System.Security.Cryptography.RSACng?qualifyHint=True&autoUpgrade=True) class, which provides a CNG implementation of the RSA algorithm.  
  
        -   Enhancements to the RSA API so that common actions no longer require casting. For example, encrypting data using an [X509Certificate2](assetId:///T:System.Security.Cryptography.X509Certificates.X509Certificate2?qualifyHint=False&autoUpgrade=True) object requires code like the following in previous versions of the .NET Framework.  
  
<!-- TODO: review snippet reference              [!CODE [WhatsNew.Casting#1](../CodeSnippet/VS_Snippets_CLR/whatsnew.casting#1)]  -->  
  
             Code that uses the new cryptography APIs in the .NET Framework 4.6 can be rewritten as follows to avoid the cast.  
  
<!-- TODO: review snippet reference              [!CODE [WhatsNew.Casting#2](../CodeSnippet/VS_Snippets_CLR/whatsnew.casting#2)]  -->  
  
    -   **Support for converting dates and times to or from Unix time**  
  
         The following new methods have been added to the [DateTimeOffset](assetId:///T:System.DateTimeOffset?qualifyHint=False&autoUpgrade=True) structure to support converting date and time values to or from Unix time:  
  
        -   [DateTimeOffset.FromUnixTimeSeconds](assetId:///M:System.DateTimeOffset.FromUnixTimeSeconds(System.Int64)?qualifyHint=True&autoUpgrade=True)  
  
        -   [DateTimeOffset.FromUnixTimeMilliseconds](assetId:///M:System.DateTimeOffset.FromUnixTimeMilliseconds(System.Int64)?qualifyHint=True&autoUpgrade=True)  
  
        -   [DateTimeOffset.ToUnixTimeSeconds](assetId:///M:System.DateTimeOffset.ToUnixTimeSeconds?qualifyHint=True&autoUpgrade=True)  
  
        -   [DateTimeOffset.ToUnixTimeMilliseconds](assetId:///M:System.DateTimeOffset.ToUnixTimeMilliseconds?qualifyHint=True&autoUpgrade=True)  
  
    -   **Compatibility switches**  
  
         The new [AppContext](assetId:///T:System.AppContext?qualifyHint=False&autoUpgrade=True) class adds a new compatibility feature that enables library writers to provide a uniform opt-out mechanism for new functionality for their users. It establishes a loosely-coupled contract between components in order to communicate an opt-out request. This capability is typically important when a change is made to existing functionality. Conversely, there is already an implicit opt-in for new functionality.  
  
         With [AppContext](assetId:///T:System.AppContext?qualifyHint=False&autoUpgrade=True), libraries define and expose compatibility switches, while code that depends on them can set those switches to affect the library behavior. By default, libraries provide the new functionality, and they only alter it (that is, they provide the previous functionality) if the switch is set.  
  
         An application (or a library) can declare the value of a switch (which is always a [Boolean](assetId:///T:System.Boolean?qualifyHint=False&autoUpgrade=True) value) that a dependent library defines. The switch is always implicitly `false`. Setting the switch to `true` enables it. Explicitly setting the switch to `false` provides the new behavior.  
  
        ```csharp  
        AppContext.SetSwitch("Switch.AmazingLib.ThrowOnException", true);  
        ```  
  
         The library must check if a consumer has declared the value of the switch and then appropriately act on it.  
  
        ```  
  
        if (!AppContext.TryGetSwitch("Switch.AmazingLib.ThrowOnException", out shouldThrow))   
        {  
           // This is the case where the switch value was not set by the application.   
           // The library can choose to get the value of shouldThrow by other means.   
           // If no overrides nor default values are specified, the value should be 'false'.   
           // A false value implies the latest behavior.  
        }  
  
           // The library can use the value of shouldThrow to throw exceptions or not.  
           if (shouldThrow)   
           {  
              // old code  
           }  
           else {  
              // new code  
           }  
        }  
  
        ```  
  
         It's beneficial to use a consistent format for switches, since they are a formal contract exposed by a library. The following are two obvious formats.  
  
        -   *Switch*.*namespace*.*switchname*  
  
        -   *Switch*.*library*.*switchname*  
  
    -   **Changes to the task-based asynchronous pattern (TAP)**  
  
         For apps that target the .NET Framework 4.6, [Task](assetId:///T:System.Threading.Tasks.Task?qualifyHint=False&autoUpgrade=True) and [Task\<TResult>](assetId:///T:System.Threading.Tasks.Task`1?qualifyHint=False&autoUpgrade=True) objects inherit the culture and UI culture of the calling thread. The behavior of apps that target previous versions of the .NET Framework, or that do not target a specific version of the .NET Framework, is unaffected. For more information, see the "Culture and task-based asynchronous operations” section of the [CultureInfo](assetId:///T:System.Globalization.CultureInfo?qualifyHint=False&autoUpgrade=True) class topic.  
  
         The [System.Threading.AsyncLocal\<T>](assetId:///T:System.Threading.AsyncLocal`1?qualifyHint=True&autoUpgrade=True) class allows you to represent ambient data that is local to a given asynchronous control flow, such as an `async` method. It can be used to persist data across threads. You can also define a callback method that is notified whenever the ambient data changes either because the [AsyncLocal<T\>.Value](assetId:///P:System.Threading.AsyncLocal`1.Value?qualifyHint=True&autoUpgrade=True) property was explicitly changed, or because the thread encountered a context transition.  
  
         Three convenience methods, [Task.CompletedTask](assetId:///P:System.Threading.Tasks.Task.CompletedTask?qualifyHint=True&autoUpgrade=True), [Task.FromCanceled](assetId:///M:System.Threading.Tasks.Task.FromCanceled(System.Threading.CancellationToken)?qualifyHint=True&autoUpgrade=True), and [Task.FromException](assetId:///M:System.Threading.Tasks.Task.FromException(System.Exception)?qualifyHint=True&autoUpgrade=True), have been added to the task-based asynchronous pattern (TAP) to return completed tasks in a particular state.  
  
         The [NamedPipeClientStream](assetId:///T:System.IO.Pipes.NamedPipeClientStream?qualifyHint=False&autoUpgrade=True) class now supports asynchronous communication with its new [ConnectAsync](assetId:///M:System.IO.Pipes.NamedPipeClientStream.ConnectAsync?qualifyHint=False&autoUpgrade=True). method.  
  
    -   **EventSource now supports writing to the Event log**  
  
         You now can use the [EventSource](assetId:///T:System.Diagnostics.Tracing.EventSource?qualifyHint=False&autoUpgrade=True) class to log administrative or operational messages to the event log, in addition to any existing ETW sessions created on the machine. In the past, you had to use the Microsoft.Diagnostics.Tracing.EventSource NuGet package for this functionality. This functionality is now built-into the .NET Framework 4.6.  
  
         Both the NuGet package and the .NET Framework 4.6 have been updated with the following features:  
  
        -   **Dynamic events**  
  
             Allows events defined "on the fly" without creating event methods.  
  
        -   **Rich payloads**  
  
             Allows specially attributed classes and arrays as well as primitive types to be passed as a payload  
  
        -   **Activity tracking**  
  
             Causes Start and Stop events to tag events between them with an ID that represents all currently active activities.  
  
         To support these features, the overloaded [Write](assetId:///M:System.Diagnostics.Tracing.EventSource.Write(System.String)?qualifyHint=False&autoUpgrade=True) method has been added to the [EventSource](assetId:///T:System.Diagnostics.Tracing.EventSource?qualifyHint=False&autoUpgrade=True) class.  
  
-   **Windows Presentation Foundation (WPF)**  
  
    -   **HDPI improvements**  
  
         HDPI support in WPF is now better in the .NET Framework 4.6. Changes have been made to layout rounding to reduce instances of clipping in controls with borders. By default, this feature is enabled only if your [TargetFrameworkAttribute](assetId:///T:System.Runtime.Versioning.TargetFrameworkAttribute?qualifyHint=False&autoUpgrade=True) is set to .NET 4.6.  Applications that target earlier versions of the framework but are running on the .NET Framework 4.6 can opt in to the new behavior by adding the following line to the [\<runtime>](../Topic/%3Cruntime%3E%20Element.md) section of the app.config file:  
  
        ```  
  
        <AppContextSwitchOverrides  
        value="Switch.MS.Internal.DoNotApplyLayoutRoundingToMarginsAndBorderThickness=false"  
        />  
  
        ```  
  
         WPF windows straddling multiple monitors with different DPI settings (Multi-DPI setup) are now completely rendered without blacked-out regions. You can opt out of this behavior by adding the following line to the `<appSettings>` section of the app.config file to disable this new behavior:  
  
        ```  
  
        <add key="EnableMultiMonitorDisplayClipping" value="true"/>  
  
        ```  
  
         Support for automatically loading the right cursor based on DPI setting has been added to  [System.Windows.Input.Cursor](assetId:///T:System.Windows.Input.Cursor?qualifyHint=True&autoUpgrade=True).  
  
    -   **Touch is better**  
  
         Customer reports on [Connect](https://connect.microsoft.com/VisualStudio/feedback/details/903760/) that touch produces unpredictable behavior have been addressed in the .NET Framework 4.6. The double tap threshold for Windows Store applications and WPF applications is now the same in Windows 8.1 and above.  
  
    -   **Transparent child window support**  
  
         WPF in the .NET Framework 4.6 supports transparent child windows in Windows 8.1 and above. This allows you to create non-rectangular and transparent child windows in your top-level windows. You can enable this feature by setting the [HwndSourceParameters.UsesPerPixelTransparency](assetId:///P:System.Windows.Interop.HwndSourceParameters.UsesPerPixelTransparency?qualifyHint=True&autoUpgrade=True) property to `true`.  
  
-   **Windows Communication Foundation (WCF)**  
  
    -   **SSL support**  
  
         WCF now supports SSL version TLS 1.1 and TLS 1.2, in addition to SSL 3.0 and TLS 1.0, when using NetTcp with transport security and client authentication. It is now possible to select which protocol to use, or to disable old lesser secure protocols. This can be done either by setting the [SslProtocols](assetId:///P:System.ServiceModel.TcpTransportSecurity.SslProtocols?qualifyHint=False&autoUpgrade=True) property or by adding the following to a configuration file.  
  
        ```  
        <netTcpBinding>  
           <binding>  
              <security mode= "None|Transport|Message|TransportWithMessageCredential" >  
                 <transport clientCredentialType="None|Windows|Certificate"  
                            protectionLevel="None|Sign|EncryptAndSign"  
                            sslProtocols="Ssl3|Tls1|Tls11|Tls12">  
                    </transport>  
              </security>  
           </binding>  
        </netTcpBinding>  
  
        ```  
  
    -   **Sending messages using different HTTP connections**  
  
         WCF now allows users to ensure certain messages are sent using different underlying HTTP connections. There are two ways to do this:  
  
        -   **Using a connection group name prefix**  
  
             Users can specify a string that WCF will use as a prefix achieve for the connection group name. Two messages with different prefixes are sent using different underlying HTTP connections. You set the prefix by adding a key/value pair to the message's [Message.Properties](assetId:///P:System.ServiceModel.Channels.Message.Properties?qualifyHint=True&autoUpgrade=True) property. The key is "HttpTransportConnectionGroupNamePrefix"; the value is the desired prefix.  
  
        -   **Using different channel factories**  
  
             Users can also enable a feature that ensures that messages sent using channels created by different channel factories will use different underlying HTTP connections. To enable this feature, users must set the following `appSetting` to `true`:  
  
            ```  
  
            <appSettings>  
               <add key="wcf:httpTransportBinding:useUniqueConnectionPoolPerFactory" value="true" />  
            </appSettings>  
  
            ```  
  
-   **Windows Workflow Foundation (WWF)**  
  
     You can now specify the number of seconds a workflow service will hold on to an out-of-order operation request when there is an outstanding “non-protocol” bookmark before timing out the request. A “non-protocol” bookmark is a bookmark that is not related to outstanding Receive activities. Some activities create non-protocol bookmarks within their implementation, so it may not be obvious that a non-protocol bookmark exists. These include State and Pick. So if you have a workflow service implemented with a state machine or containing a Pick activity, you will most likely have non-protocol bookmarks. You specify the interval by adding a line like the following to the `appSettings` section of your app.config file:  
  
    ```  
    <add key="microsoft:WorkflowServices:FilterResumeTimeoutInSeconds" value="60"/>  
    ```  
  
     The default value is 60 seconds. If `value` is set to 0, out-of-order requests are immediately rejected with a fault with text that looks like this:  
  
    ```Output  
    Operation 'Request3|{http://tempuri.org/}IService' on service instance with identifier '2b0667b6-09c8-4093-9d02-f6c67d534292' cannot be performed at this time. Please ensure that the operations are performed in the correct order and that the binding in use provides ordered delivery guarantees.   
    ```  
  
     This is the same message that you receive if an out-of-order operation message is received and there are no non-protocol bookmarks.  
  
     If the value of the `FilterResumeTimeoutInSeconds` element is non-zero, there are non-protocol bookmarks, and the timeout interval expires, the operation fails with a timeout message.  
  
-   **Transactions**  
  
     You can now include the distributed transaction identifier for the transaction that has caused an exception derived from [TransactionException](assetId:///T:System.Transactions.TransactionException?qualifyHint=False&autoUpgrade=True) to be thrown. You do this by adding the following key to the `appSettings` section of your app.config file:  
  
    ```  
    <add key="Transactions:IncludeDistributedTransactionIdInExceptionMessage" value="true"/>   
    ```  
  
     The default value is `false`.  
  
-   **Networking**  
  
    -   **Socket reuse**  
  
         Windows 10 includes a new high-scalability networking algorithm that makes better use of machine resources by reusing local ports for outbound TCP connections. The .NET Framework 4.6 supports the new algorithm, enabling .NET apps to take advantage of the new behavior. In previous versions of Windows, there was an artificial concurrent connection limit (typically 16,384, the default size of the dynamic port range), which could limit the scalability of a service by causing port exhaustion when under load.  
  
         In the .NET Framework 4.6, two new APIs have been added to enable port reuse, which effectively removes the 64K limit on concurrent connections:  
  
        -   The [SocketOptionName.ReuseUnicastPort](assetId:///T:System.Net.Sockets.SocketOptionName?qualifyHint=True&autoUpgrade=True) enumeration value.  
  
        -   The [ServicePointManager.ReusePort](assetId:///P:System.Net.ServicePointManager.ReusePort?qualifyHint=True&autoUpgrade=True) property.  
  
         By default, the [ServicePointManager.ReusePort](assetId:///P:System.Net.ServicePointManager.ReusePort?qualifyHint=True&autoUpgrade=True) property is `false` unless the `HWRPortReuseOnSocketBind` value of the `HKLM\SOFTWARE\Microsoft\.NETFramework\v4.0.30319` registry key is set to 0x1. To enable local port reuse on HTTP connections, set the [ServicePointManager.ReusePort](assetId:///P:System.Net.ServicePointManager.ReusePort?qualifyHint=True&autoUpgrade=True) property to `true`. This causes all outgoing TCP socket connections from [HttpClient](assetId:///T:System.Net.Http.HttpClient?qualifyHint=False&autoUpgrade=True) and [HttpWebRequest](assetId:///T:System.Net.HttpWebRequest?qualifyHint=False&autoUpgrade=True) to use a new Windows 10 socket option, [SO_REUSE_UNICASTPORT](https://msdn.microsoft.com/library/windows/desktop/ms740532.aspx), that enables local port reuse.  
  
         Developers writing a sockets-only application can specify the [SocketOptionName.ReuseUnicastPort](assetId:///T:System.Net.Sockets.SocketOptionName?qualifyHint=True&autoUpgrade=True) option when calling a method such as [Socket.SetSocketOption](assetId:///M:System.Net.Sockets.Socket.SetSocketOption(System.Net.Sockets.SocketOptionLevel,System.Net.Sockets.SocketOptionName,System.Byte[])?qualifyHint=True&autoUpgrade=True) so that outbound sockets reuse local ports during binding.  
  
    -   **Support for international domain names and PunyCode**  
  
         A new property, [IdnHost](assetId:///P:System.Uri.IdnHost?qualifyHint=False&autoUpgrade=True), has been added to the [Uri](assetId:///T:System.Uri?qualifyHint=False&autoUpgrade=True) class to better support international domain names and PunyCode.  
  
-   **Resizing in Windows Forms controls.**  
  
     This feature has been expanded in .NET Framework 4.6 to include the [DomainUpDown](assetId:///T:System.Windows.Forms.DomainUpDown?qualifyHint=False&autoUpgrade=True), [NumericUpDown](assetId:///T:System.Windows.Forms.NumericUpDown?qualifyHint=False&autoUpgrade=True), [DataGridViewComboBoxColumn](assetId:///T:System.Windows.Forms.DataGridViewComboBoxColumn?qualifyHint=False&autoUpgrade=True), [DataGridViewColumn](assetId:///T:System.Windows.Forms.DataGridViewColumn?qualifyHint=False&autoUpgrade=True) and [ToolStripSplitButton](assetId:///T:System.Windows.Forms.ToolStripSplitButton?qualifyHint=False&autoUpgrade=True) types and the rectangle specified by the [Bounds](assetId:///P:System.Drawing.Design.PaintValueEventArgs.Bounds?qualifyHint=False&autoUpgrade=True) property used when drawing a [UITypeEditor](assetId:///T:System.Drawing.Design.UITypeEditor?qualifyHint=False&autoUpgrade=True).  
  
     This is an opt-in feature. To enable it, set the `EnableWindowsFormsHighDpiAutoResizing` element to `true` in the application configuration (app.config) file:  
  
    ```  
  
    <appSettings>  
       <add key="EnableWindowsFormsHighDpiAutoResizing" value="true" />  
    </appSettings>  
  
    ```  
  
-   **Support for code page encodings**  
  
     .NET Core primarily supports the Unicode encodings and by default provides limited support for code page encodings. You can add support for code page encodings available in the .NET Framework but unsupported in .NET Core by registering code page encodings with the [Encoding.RegisterProvider](assetId:///M:System.Text.Encoding.RegisterProvider(System.Text.EncodingProvider)?qualifyHint=True&autoUpgrade=True) method. For more information, see the documentation for the [System.Text.CodePagesEncodingProvider](xref:System.Text.CodePagesEncodingProvider) class.  
  
-   **.NET Native**  
  
     Windows apps for Windows 10 that target .NET Core and are written in C# or Visual Basic can take advantage of a new technology that compiles apps to native code rather than IL. They produce apps characterized by faster startup and execution times. For more information, see [Compiling Apps with .NET Native](../Topic/Compiling%20Apps%20with%20.NET%20Native.md). For an overview of .NET Native that examines how it differs from both JIT compilation and NGEN and what that means for your code, see [.NET Native and Compilation](../Topic/.NET%20Native%20and%20Compilation.md).  
  
     Your apps are compiled to native code by default when you compile them with Visual Studio 2015. For more information, see [Getting Started with .NET Native](../Topic/Getting%20Started%20with%20.NET%20Native.md).  
  
     To support debugging .NET Native apps, a number of new interfaces and enumerations have been added to the unmanaged debugging API. For more information, see the [Debugging (Unmanaged API Reference)](../Topic/Debugging%20\(Unmanaged%20API%20Reference\).md) topic.  
  
-   **Open-source .NET Framework packages**  
  
     .NET Core packages such as the immutable collections, [SIMD APIs](http://go.microsoft.com/fwlink/?LinkID=518639), and networking APIs such as those found in the [System.Net.Http](assetId:///N:System.Net.Http?qualifyHint=False&autoUpgrade=True) namespace are now available as open source packages on [GitHub](https://github.com/). To access the code, see [NetFx on GitHub](http://go.microsoft.com/fwlink/?LinkID=518634). For more information and how to contribute to these packages, see [.NET Core and Open-Source](../Topic/.NET%20Core%20and%20Open-Source.md), [.NET Home Page on GitHub](http://go.microsoft.com/fwlink/?LinkID=518635).  
  
 [Back to top](#introduction)  
  
<a name="v452"></a>   
## What's new in the .NET Framework 4.5.2  
  
-   **New APIs for ASP.NET apps.** The new [HttpResponse.AddOnSendingHeaders](assetId:///M:System.Web.HttpResponse.AddOnSendingHeaders(System.Action{System.Web.HttpContext})?qualifyHint=True&autoUpgrade=True) and [HttpResponseBase.AddOnSendingHeaders](assetId:///M:System.Web.HttpResponseBase.AddOnSendingHeaders(System.Action{System.Web.HttpContextBase})?qualifyHint=True&autoUpgrade=True) methods let you inspect and modify response headers and status code as the response is being flushed to the client app. Consider using these methods instead of the [PreSendRequestHeaders](assetId:///E:System.Web.HttpApplication.PreSendRequestHeaders?qualifyHint=False&autoUpgrade=True) and [PreSendRequestContent](assetId:///E:System.Web.HttpApplication.PreSendRequestContent?qualifyHint=False&autoUpgrade=True) events; they are more efficient and reliable.  
  
     The [HostingEnvironment.QueueBackgroundWorkItem](assetId:///M:System.Web.Hosting.HostingEnvironment.QueueBackgroundWorkItem(System.Action{System.Threading.CancellationToken})?qualifyHint=True&autoUpgrade=True) method lets you schedule small background work items. ASP.NET tracks these items and prevents IIS from abruptly terminating the worker process until all background work items have completed. This method can't be called outside an ASP.NET managed app domain.  
  
     The new [HttpResponse.HeadersWritten](assetId:///P:System.Web.HttpResponse.HeadersWritten?qualifyHint=True&autoUpgrade=False) and [HttpResponseBase.HeadersWritten](assetId:///P:System.Web.HttpResponseBase.HeadersWritten?qualifyHint=True&autoUpgrade=False) properties return Boolean values that indicate whether the response headers have been written. You can use these properties to make sure that calls to APIs such as [HttpResponse.StatusCode](assetId:///P:System.Web.HttpResponse.StatusCode?qualifyHint=True&autoUpgrade=True) (which throw exceptions if the headers have been written) will succeed.  
  
-   **Resizing in Windows Forms controls.** This feature has been expanded. You can now use the system DPI setting to resize components of the following additional controls (for example, the drop-down arrow in combo boxes):  
  
     [ComboBox](assetId:///T:System.Windows.Forms.ComboBox?qualifyHint=False&autoUpgrade=True)   
     [ToolStripComboBox](assetId:///T:System.Windows.Forms.ToolStripComboBox?qualifyHint=False&autoUpgrade=True)   
     [ToolStripMenuItem](assetId:///T:System.Windows.Forms.ToolStripMenuItem?qualifyHint=False&autoUpgrade=True)   
     [Cursor](assetId:///T:System.Windows.Forms.Cursor?qualifyHint=False&autoUpgrade=True)   
     [DataGridView](assetId:///T:System.Windows.Forms.DataGridView?qualifyHint=False&autoUpgrade=True)   
     [DataGridViewComboBoxColumn](assetId:///T:System.Windows.Forms.DataGridViewComboBoxColumn?qualifyHint=False&autoUpgrade=True)  
  
     This is an opt-in feature. To enable it, set the `EnableWindowsFormsHighDpiAutoResizing` element to `true` in the application configuration (app.config) file:  
  
    ```  
    <appSettings>  
       <add key="EnableWindowsFormsHighDpiAutoResizing" value="true" />  
    </appSettings>  
    ```  
  
-   **New workflow feature.** A resource manager that's using the [EnlistPromotableSinglePhase](assetId:///M:System.Transactions.Transaction.EnlistPromotableSinglePhase(System.Transactions.IPromotableSinglePhaseNotification)?qualifyHint=False&autoUpgrade=True) method (and therefore implementing the [IPromotableSinglePhaseNotification](assetId:///T:System.Transactions.IPromotableSinglePhaseNotification?qualifyHint=False&autoUpgrade=True) interface) can use the new [Transaction.PromoteAndEnlistDurable](assetId:///M:System.Transactions.Transaction.PromoteAndEnlistDurable(System.Guid,System.Transactions.IPromotableSinglePhaseNotification,System.Transactions.ISinglePhaseNotification,System.Transactions.EnlistmentOptions)?qualifyHint=True&autoUpgrade=True) method to request the following:  
  
    -   Promote the transaction to a Microsoft Distributed Transaction Coordinator (MSDTC) transaction.  
  
    -   Replace [IPromotableSinglePhaseNotification](assetId:///T:System.Transactions.IPromotableSinglePhaseNotification?qualifyHint=False&autoUpgrade=True) with an [ISinglePhaseNotification](assetId:///T:System.Transactions.ISinglePhaseNotification?qualifyHint=False&autoUpgrade=True), which is a durable enlistment that supports single phase commits.  
  
     This can be done within the same app domain, and doesn't require any extra unmanaged code to interact with MSDTC to perform the promotion. The new method can be called only when there's an outstanding call from [System.Transactions](assetId:///N:System.Transactions?qualifyHint=True&autoUpgrade=True) to the [IPromotableSinglePhaseNotification](assetId:///T:System.Transactions.IPromotableSinglePhaseNotification?qualifyHint=False&autoUpgrade=True)`Promote` method that's implemented by the promotable enlistment.  
  
-   **Profiling improvements.** The following new unmanaged profiling APIs provide more robust profiling:  
  
     [COR_PRF_ASSEMBLY_REFERENCE_INFO Structure](../Topic/COR_PRF_ASSEMBLY_REFERENCE_INFO%20Structure.md)   
     [COR_PRF_HIGH_MONITOR Enumeration](../Topic/COR_PRF_HIGH_MONITOR%20Enumeration.md)   
     [GetAssemblyReferences Method](../Topic/ICorProfilerCallback6::GetAssemblyReferences%20Method.md)   
     [GetEventMask2 Method](../Topic/ICorProfilerInfo5::GetEventMask2%20Method.md)   
     [SetEventMask2 Method](../Topic/ICorProfilerInfo5::SetEventMask2%20Method.md)   
     [AddAssemblyReference Method](../Topic/ICorProfilerAssemblyReferenceProvider::AddAssemblyReference%20Method.md)  
  
     Previous `ICorProfiler` implementations supported lazy loading of dependent assemblies. The new profiling APIs require dependent assemblies that are injected by the profiler to be loadable immediately, instead of being loaded after the app is fully initialized. This change doesn't affect users of the existing `ICorProfiler` APIs.  
  
-   **Debugging improvements.** The following new unmanaged debugging APIs provide better integration with a profiler. You can now access metadata inserted by the profiler as well as local variables and code produced by compiler ReJIT requests when dump debugging.  
  
     [SetWriteableMetadataUpdateMode Method](../Topic/ICorDebugProcess7::SetWriteableMetadataUpdateMode%20Method.md)   
     [EnumerateLocalVariablesEx Method](../Topic/ICorDebugILFrame4::EnumerateLocalVariablesEx%20Method.md)   
     [GetLocalVariableEx Method](../Topic/ICorDebugILFrame4::GetLocalVariableEx%20Method.md)   
     [GetCodeEx Method](../Topic/ICorDebugILFrame4::GetCodeEx%20Method.md)   
     [GetActiveReJitRequestILCode Method](../Topic/ICorDebugFunction3::GetActiveReJitRequestILCode%20Method.md)   
     [GetInstrumentedILMap Method](../Topic/ICorDebugILCode2::GetInstrumentedILMap%20Method.md)  
  
-   **Event tracing changes.** The .NET Framework 4.5.2 enables out-of-process, Event Tracing for Windows (ETW)-based activity tracing for a larger surface area. This enables Advanced Power Management (APM) vendors to provide lightweight tools that accurately track the costs of individual requests and activities that cross threads.  These events are raised only when ETW controllers enable them; therefore, the changes don't affect previously written ETW code or code that runs with ETW disabled.  
  
-   **Promoting a transaction and converting it to a durable enlistment**  
  
     [Transaction.PromoteAndEnlistDurable](assetId:///M:System.Transactions.Transaction.PromoteAndEnlistDurable(System.Guid,System.Transactions.IPromotableSinglePhaseNotification,System.Transactions.ISinglePhaseNotification,System.Transactions.EnlistmentOptions)?qualifyHint=True&autoUpgrade=True) is a new API added to the .NET Framework 4.5.2 and 4.6:  
  
    ```  
  
    [System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]  
    public Enlistment PromoteAndEnlistDurable(Guid resourceManagerIdentifier,  
                                              IPromotableSinglePhaseNotification promotableNotification,  
                                              ISinglePhaseNotification enlistmentNotification,  
                                              EnlistmentOptions enlistmentOptions)  
  
    ```  
  
     The method may be used by an enlistment that was previously created by [Transaction.EnlistPromotableSinglePhase](assetId:///M:System.Transactions.Transaction.EnlistPromotableSinglePhase(System.Transactions.IPromotableSinglePhaseNotification)?qualifyHint=True&autoUpgrade=True) in response to the [ITransactionPromoter.Promote](assetId:///M:System.Transactions.ITransactionPromoter.Promote?qualifyHint=True&autoUpgrade=True) method. It asks `System.Transactions` to promote the transaction to an MSDTC transaction and to “convert” the promotable enlistment to a durable enlistment. After this method completes successfully, the [IPromotableSinglePhaseNotification](assetId:///T:System.Transactions.IPromotableSinglePhaseNotification?qualifyHint=False&autoUpgrade=True) interface will no longer be referenced by `System.Transactions`, and any future notifications will arrive on the provided [ISinglePhaseNotification](assetId:///T:System.Transactions.ISinglePhaseNotification?qualifyHint=False&autoUpgrade=True) interface. The enlistment in question must act as a durable enlistment, supporting transaction logging and recovery. Refer to [Transaction.EnlistDurable](assetId:///M:System.Transactions.Transaction.EnlistDurable(System.Guid,System.Transactions.IEnlistmentNotification,System.Transactions.EnlistmentOptions)?qualifyHint=True&autoUpgrade=True) for details. In addition, the enlistment must support [ISinglePhaseNotification](assetId:///T:System.Transactions.ISinglePhaseNotification?qualifyHint=False&autoUpgrade=True).  This method can *only* be called while processing an [ITransactionPromoter.Promote](assetId:///M:System.Transactions.ITransactionPromoter.Promote?qualifyHint=True&autoUpgrade=True) call. If that is not the case, a [TransactionException](assetId:///T:System.Transactions.TransactionException?qualifyHint=False&autoUpgrade=True) exception is thrown.  
  
 [Back to top](#introduction)  
  
<a name="v451"></a>   
## What's new in the .NET Framework 4.5.1  
 **April 2014 updates**:  
  
-   [Visual Studio 2013 Update 2](http://go.microsoft.com/fwlink/p/?LinkId=393658) includes updates to the Portable Class Library templates to support these scenarios:  
  
    -   You can use Windows Runtime APIs in portable libraries that target Windows 8.1, Windows Phone 8.1, and Windows Phone Silverlight 8.1.  
  
    -   You can include XAML (Windows.UI.XAML types) in portable libraries when you target Windows 8.1 or Windows Phone 8.1. The following XAML templates are supported:  Blank Page, Resource Dictionary, Templated Control, and User Control.  
  
    -   You can create a portable Windows Runtime component (.winmd file) for use in Store apps that target Windows 8.1 and Windows Phone 8.1.  
  
    -   You can retarget a Windows Store or Windows Phone Store class library like a Portable Class Library.  
  
     For more information about these changes, see [Portable Class Library](../Topic/Cross-Platform%20Development%20with%20the%20Portable%20Class%20Library.md).  
  
-   The .NET Framework content set now includes documentation for .NET Native, which is a precompilation technology for building and deploying Windows apps. .NET Native compiles your apps directly to native code, rather than to intermediate language (IL), for better performance. For details, see [Compiling Apps with .NET Native](../Topic/Compiling%20Apps%20with%20.NET%20Native.md).  
  
-   The [.NET Framework Reference Source](http://referencesource.microsoft.com/) provides a new browsing experience and enhanced functionality. You can now browse through the .NET Framework source code online, [download the reference](http://referencesource.microsoft.com/download.html) for offline viewing, and step through the sources (including patches and updates) during debugging. For more information, see the blog entry [A new look for .NET Reference Source](http://blogs.msdn.com/b/dotnet/archive/2014/02/24/a-new-look-for-net-reference-source.aspx).  
  
 Core new features and enhancements in the .NET Framework 4.5.1 include:  
  
-   Automatic binding redirection for assemblies. Starting with Visual Studio 2013, when you compile an app that targets the .NET Framework 4.5.1, binding redirects may be added to the app configuration file if your app or its components reference multiple versions of the same assembly. You can also enable this feature for projects that target older versions of the .NET Framework. For more information, see [How to: Enable and Disable Automatic Binding Redirection](../Topic/How%20to:%20Enable%20and%20Disable%20Automatic%20Binding%20Redirection.md).  
  
-   Ability to collect diagnostics information to help developers improve the performance of server and cloud applications. For more information, see the [WriteEventWithRelatedActivityId](assetId:///M:System.Diagnostics.Tracing.EventSource.WriteEventWithRelatedActivityId(System.Int32,System.Guid,System.Object[])?qualifyHint=False&autoUpgrade=True) and [WriteEventWithRelatedActivityIdCore](assetId:///M:System.Diagnostics.Tracing.EventSource.WriteEventWithRelatedActivityIdCore(System.Int32,System.Guid*,System.Int32,System.Diagnostics.Tracing.EventSource.EventData*)?qualifyHint=False&autoUpgrade=True) methods in the [EventSource](assetId:///T:System.Diagnostics.Tracing.EventSource?qualifyHint=False&autoUpgrade=True) class.  
  
-   Ability to explicitly compact the large object heap (LOH) during garbage collection. For more information, see the [GCSettings.LargeObjectHeapCompactionMode](assetId:///P:System.Runtime.GCSettings.LargeObjectHeapCompactionMode?qualifyHint=True&autoUpgrade=True) property.  
  
-   Additional performance improvements such as ASP.NET app suspension, multi-core JIT improvements, and faster app startup after a .NET Framework update. For details, see the [.NET Framework 4.5.1 announcement](http://blogs.msdn.com/b/dotnet/archive/2013/06/26/announcing-the-net-framework-4-5-1-preview.aspx) and the [ASP.NET app suspend](http://blogs.msdn.com/b/dotnet/archive/2013/10/09/asp-net-app-suspend-responsive-shared-net-web-hosting.aspx) blog post.  
  
 Improvements to Windows Forms include:  
  
-   Resizing in Windows Forms controls. You can use the system DPI setting to resize components of controls (for example, the icons that appear in a property grid) by opting in with an entry in the application configuration file (app.config) for your app. This feature is currently supported in the following Windows Forms controls:  
  
     [PropertyGrid](assetId:///T:System.Windows.Forms.PropertyGrid?qualifyHint=False&autoUpgrade=True)   
     [TreeView](assetId:///T:System.Windows.Forms.TreeView?qualifyHint=False&autoUpgrade=True)   
     Some aspects of the [DataGridView](assetId:///T:System.Windows.Forms.DataGridView?qualifyHint=False&autoUpgrade=True) (see [new features in 4.5.2](#v452) for additional controls supported)  
  
     To enable this feature, add a new \<appSettings> element to the configuration file (app.config) and set the `EnableWindowsFormsHighDpiAutoResizing` element to `true`:  
  
    ```  
    <appSettings>  
       <add key="EnableWindowsFormsHighDpiAutoResizing" value="true" />  
    </appSettings>  
    ```  
  
 Improvements when debugging your .NET Framework apps in Visual Studio 2013 include:  
  
-   Return values in the Visual Studio debugger. When you debug a managed app in Visual Studio 2013, the Autos window displays return types and values for methods. This information is available for desktop, Windows Store, and Windows Phone apps. For more information, see [Examine return values of method calls](http://msdn.microsoft.com/library/e3245b37-8e2e-4200-ba84-133726e95f1f\(v=vs.120\).aspx) in the MSDN Library.  
  
-   Edit and Continue for 64-bit apps. Visual Studio 2013 supports the Edit and Continue feature for 64-bit managed apps for desktop, Windows Store, and Windows Phone. The existing limitations remain in effect for both 32-bit and 64-bit apps (see the last section of the [Supported Code Changes (C#)](http://msdn.microsoft.com/library/ms164927\(v=vs.120\).aspx) article).  
  
-   Async-aware debugging. To make it easier to debug asynchronous apps in Visual Studio 2013, the call stack hides the infrastructure code provided by compilers to support asynchronous programming, and also chains in logical parent frames so you can follow logical program execution more clearly. A Tasks window replaces the Parallel Tasks window and displays tasks that relate to a particular breakpoint, and also displays any other tasks that are currently active or scheduled in the app. You can read about this feature in the "Async-aware debugging" section of the [.NET Framework 4.5.1 announcement](http://blogs.msdn.com/b/dotnet/archive/2013/06/26/announcing-the-net-framework-4-5-1-preview.aspx).  
  
-   Better exception support for Windows Runtime components. In Windows 8.1, exceptions that arise from Windows Store apps preserve information about the error that caused the exception, even across language boundaries. You can read about this feature in the "Windows Store app development" section of the [.NET Framework 4.5.1 announcement](http://blogs.msdn.com/b/dotnet/archive/2013/06/26/announcing-the-net-framework-4-5-1-preview.aspx).  
  
 Starting with Visual Studio 2013, you can use the [Managed Profile Guided Optimization Tool (Mpgo.exe)](../Topic/Mpgo.exe%20\(Managed%20Profile%20Guided%20Optimization%20Tool\).md) to optimize Windows 8.x Store apps as well as desktop apps.  
  
 For new features in ASP.NET 4.5.1, see [ASP.NET 4.5.1 and Visual Studio 2013](http://go.microsoft.com/fwlink/?LinkID=309094) on the ASP.NET site.  
  
 [Back to top](#introduction)  
  
<a name="core"></a>   
## What's new in the .NET Framework 4.5  
  
### Core new features and improvements  
  
-   Ability to reduce system restarts by detecting and closing .NET Framework 4 applications during deployment. See [Reducing System Restarts During .NET Framework 4.5 Installations](../Topic/Reducing%20System%20Restarts%20During%20.NET%20Framework%204.5%20Installations.md).  
  
-   Support for arrays that are larger than 2 gigabytes (GB) on 64-bit platforms. This feature can be enabled in the application configuration file. See the [\<gcAllowVeryLargeObjects> element](../Topic/%3CgcAllowVeryLargeObjects%3E%20Element.md), which also lists other restrictions on object size and array size.  
  
-   Better performance through background garbage collection for servers. When you use server garbage collection in the .NET Framework 4.5, background garbage collection is automatically enabled. See the Background Server Garbage Collection section of the [Fundamentals of Garbage Collection](../Topic/Fundamentals%20of%20Garbage%20Collection.md) topic.  
  
-   Background just-in-time (JIT) compilation, which is optionally available on multi-core processors to improve application performance. See [ProfileOptimization](assetId:///T:System.Runtime.ProfileOptimization?qualifyHint=False&autoUpgrade=True).  
  
-   Ability to limit how long the regular expression engine will attempt to resolve a regular expression before it times out. See the [Regex.MatchTimeout](assetId:///P:System.Text.RegularExpressions.Regex.MatchTimeout?qualifyHint=True&autoUpgrade=True) property.  
  
-   Ability to define the default culture for an application domain. See the [CultureInfo](assetId:///T:System.Globalization.CultureInfo?qualifyHint=False&autoUpgrade=True) class.  
  
-   Console support for Unicode (UTF-16) encoding. See the [Console](assetId:///T:System.Console?qualifyHint=False&autoUpgrade=True) class.  
  
-   Support for versioning of cultural string ordering and comparison data. See the [SortVersion](assetId:///T:System.Globalization.SortVersion?qualifyHint=False&autoUpgrade=True) class.  
  
-   Better performance when retrieving resources. See [Packaging and Deploying Resources](../Topic/Packaging%20and%20Deploying%20Resources%20in%20Desktop%20Apps.md).  
  
-   Zip compression improvements to reduce the size of a compressed file. See the [System.IO.Compression](assetId:///N:System.IO.Compression?qualifyHint=True&autoUpgrade=True) namespace.  
  
-   Ability to customize a reflection context to override default reflection behavior through the [CustomReflectionContext](assetId:///T:System.Reflection.Context.CustomReflectionContext?qualifyHint=False&autoUpgrade=True) class.  
  
-   Support for the 2008 version of the Internationalized Domain Names in Applications (IDNA) standard when the [System.Globalization.IdnMapping](assetId:///T:System.Globalization.IdnMapping?qualifyHint=True&autoUpgrade=True) class is used  on Windows 8.  
  
-   Delegation of string comparison to the operating system, which implements Unicode 6.0, when the .NET Framework is used on Windows 8. When running on other platforms, the .NET Framework includes its own string comparison data, which implements Unicode 5.x. See the [String](assetId:///T:System.String?qualifyHint=False&autoUpgrade=True) class and the Remarks section of the [SortVersion](assetId:///T:System.Globalization.SortVersion?qualifyHint=False&autoUpgrade=True) class.  
  
-   Ability to compute the hash codes for strings on a per application domain basis. See [\<UseRandomizedStringHashAlgorithm> Element](../Topic/%3CUseRandomizedStringHashAlgorithm%3E%20Element.md).  
  
-   Type reflection support split between [Type](assetId:///T:System.Type?qualifyHint=False&autoUpgrade=True) and [TypeInfo](assetId:///T:System.Reflection.TypeInfo?qualifyHint=False&autoUpgrade=True) classes. See [Reflection in the .NET Framework for Windows Store Apps](../Topic/Reflection%20in%20the%20.NET%20Framework%20for%20Windows%20Store%20Apps.md).  
  
### Managed Extensibility Framework (MEF)  
 In the .NET Framework 4.5, the Managed Extensibility Framework (MEF) provides the following new features:  
  
-   Support for generic types.  
  
-   Convention-based programming model that enables you to create parts based on naming conventions rather than attributes.  
  
-   Multiple scopes.  
  
-   A subset of MEF that you can use when you create Windows 8.x Store apps. This subset is available as a [downloadable package](http://go.microsoft.com/fwlink/?LinkId=256238) from the NuGet Gallery. To install the package, open your project in Visual Studio, choose **Manage NuGet Packages** from the **Project** menu, and search online for the `Microsoft.Composition` package.  
  
 For more information, see [Managed Extensibility Framework (MEF)](../Topic/Managed%20Extensibility%20Framework%20\(MEF\).md).  
  
### Asynchronous file operations  
 In the .NET Framework 4.5, new asynchronous features were added to the C# and Visual Basic languages. These features add a task-based model for performing asynchronous operations. To use this new model, use the asynchronous methods in the I/O classes. See [Asynchronous File I/O](../Topic/Asynchronous%20File%20I-O.md).  
  
<a name="tools"></a>   
### Tools  
 In the .NET Framework 4.5, Resource File Generator (Resgen.exe) enables you to create a .resw file for use in Windows 8.x Store apps from a .resources file embedded in a .NET Framework assembly. For more information, see [Resgen.exe (Resource File Generator)](../Topic/Resgen.exe%20\(Resource%20File%20Generator\).md).  
  
 Managed Profile Guided Optimization (Mpgo.exe) enables you to improve application startup time, memory utilization (working set size), and throughput by optimizing native image assemblies. The command-line tool generates profile data for native image application assemblies. See [Mpgo.exe (Managed Profile Guided Optimization Tool)](../Topic/Mpgo.exe%20\(Managed%20Profile%20Guided%20Optimization%20Tool\).md). Starting with Visual Studio 2013, you can use Mpgo.exe to optimize Windows 8.x Store apps as well as desktop apps.  
  
<a name="parallel"></a>   
### Parallel computing  
 The .NET Framework 4.5 provides several new features and improvements for parallel computing. These include improved performance, increased control, improved support for asynchronous programming, a new dataflow library, and improved support for parallel debugging and performance analysis. See the entry [What’s New for Parallelism in .NET 4.5](http://go.microsoft.com/fwlink/?LinkId=235061) in the Parallel Programming with .NET blog.  
  
<a name="web"></a>   
### Web  
 ASP.NET 4.5 and 4.5.1 add model binding for Web Forms, WebSocket support, asynchronous handlers, performance enhancements, and many other features. For more information, see the following resources:  
  
-   [ASP.NET 4.5 and Visual Studio 2012](../Topic/ASP.NET%20Core%20and%20Visual%20Studio%202015.md) in the MSDN Library.  
  
-   [ASP.NET 4.5.1 and Visual Studio 2013](http://go.microsoft.com/fwlink/?LinkID=309094) on the ASP.NET site.  
  
<a name="networking"></a>   
### Networking  
 The .NET Framework 4.5 provides a new programming interface for HTTP applications. For more information, see the new [System.Net.Http](assetId:///N:System.Net.Http?qualifyHint=True&autoUpgrade=True) and [System.Net.Http.Headers](assetId:///N:System.Net.Http.Headers?qualifyHint=True&autoUpgrade=True) namespaces.  
  
 Support is also included for a new programming interface for accepting and interacting with a WebSocket connection by using the existing [HttpListener](assetId:///T:System.Net.HttpListener?qualifyHint=False&autoUpgrade=True) and related classes. For more information, see the new [System.Net.WebSockets](assetId:///N:System.Net.WebSockets?qualifyHint=False&autoUpgrade=True) namespace and the [HttpListener](assetId:///T:System.Net.HttpListener?qualifyHint=False&autoUpgrade=True) class.  
  
 In addition, the .NET Framework 4.5 includes the following networking improvements:  
  
-   RFC-compliant URI support. For more information, see [Uri](assetId:///T:System.Uri?qualifyHint=False&autoUpgrade=True) and related classes.  
  
-   Support for Internationalized Domain Name (IDN) parsing. For more information, see [Uri](assetId:///T:System.Uri?qualifyHint=False&autoUpgrade=True) and related classes.  
  
-   Support for Email Address Internationalization (EAI). For more information, see the [System.Net.Mail](assetId:///N:System.Net.Mail?qualifyHint=False&autoUpgrade=True) namespace.  
  
-   Improved IPv6 support. For more information, see the [System.Net.NetworkInformation](assetId:///N:System.Net.NetworkInformation?qualifyHint=False&autoUpgrade=True) namespace.  
  
-   Dual-mode socket support. For more information, see the [Socket](assetId:///T:System.Net.Sockets.Socket?qualifyHint=False&autoUpgrade=True) and [TcpListener](assetId:///T:System.Net.Sockets.TcpListener?qualifyHint=False&autoUpgrade=True) classes.  
  
<a name="client"></a>   
### Windows Presentation Foundation (WPF)  
 In the .NET Framework 4.5, Windows Presentation Foundation (WPF) contains changes and improvements in the following areas:  
  
-   The new [Ribbon](assetId:///T:System.Windows.Controls.Ribbon.Ribbon?qualifyHint=False&autoUpgrade=True) control, which enables you to implement a ribbon user interface that hosts a Quick Access Toolbar, Application Menu, and tabs.  
  
-   The new [INotifyDataErrorInfo](assetId:///T:System.ComponentModel.INotifyDataErrorInfo?qualifyHint=False&autoUpgrade=True) interface, which supports synchronous and asynchronous data validation.  
  
-   New features for the [VirtualizingPanel](assetId:///T:System.Windows.Controls.VirtualizingPanel?qualifyHint=False&autoUpgrade=True) and [Dispatcher](assetId:///T:System.Windows.Threading.Dispatcher?qualifyHint=False&autoUpgrade=True) classes.  
  
-   Improved performance when displaying large sets of grouped data, and by accessing collections on non-UI threads.  
  
-   Data binding to static properties, data binding to custom types that implement the [ICustomTypeProvider](assetId:///T:System.Reflection.ICustomTypeProvider?qualifyHint=False&autoUpgrade=True) interface, and retrieval of data binding information from a binding expression.  
  
-   Repositioning of data as the values change (live shaping).  
  
-   Ability to check whether the data context for an item container is disconnected.  
  
-   Ability to set the amount of time that should elapse between property changes and data source updates.  
  
-   Improved support for implementing weak event patterns. Also, events can now accept markup extensions.  
  
<a name="windows_communication_foundation"></a>   
### Windows Communication Foundation (WCF)  
 In the .NET Framework 4.5, the following features have been added to make it simpler to write and maintain Windows Communication Foundation (WCF) applications:  
  
-   Simplification of generated configuration files.  
  
-   Support for contract-first development.  
  
-   Ability to configure ASP.NET compatibility mode more easily.  
  
-   Changes in default transport property values to reduce the likelihood that you will have to set them.  
  
-   Updates to the [XmlDictionaryReaderQuotas](assetId:///T:System.Xml.XmlDictionaryReaderQuotas?qualifyHint=False&autoUpgrade=True) class to reduce the likelihood that you will have to manually configure quotas for XML dictionary readers.  
  
-   Validation of WCF configuration files by Visual Studio as part of the build process, so you can detect configuration errors before you run your application.  
  
-   New asynchronous streaming support.  
  
-   New HTTPS protocol mapping to make it easier to expose an endpoint over HTTPS with Internet Information Services (IIS).  
  
-   Ability to generate metadata in a single WSDL document by appending `?singleWSDL` to the service URL.  
  
-   Websockets support to enable true bidirectional communication over ports 80 and 443 with performance characteristics similar to the TCP transport.  
  
-   Support for configuring services in code.  
  
-   XML Editor tooltips.  
  
-   [ChannelFactory](assetId:///T:System.ServiceModel.ChannelFactory?qualifyHint=False&autoUpgrade=True) caching support.  
  
-   Binary encoder compression support.  
  
-   Support for a UDP transport that enables developers to write services that use "fire and forget" messaging. A client sends a message to a service and expects no response from the service.  
  
-   Ability to support multiple authentication modes on a single WCF endpoint when using the HTTP transport and transport security.  
  
-   Support for WCF services that use internationalized domain names (IDNs).  
  
 For more information, see [What's New in Windows Communication Foundation](http://go.microsoft.com/fwlink/?LinkId=228173).  
  
<a name="windows_workflow_foundation"></a>   
### Windows Workflow Foundation (WF)  
 In the .NET Framework 4.5, several new features were added to Windows Workflow Foundation (WF), including:  
  
-   State machine workflows, which were first introduced as part of the .NET Framework 4.0.1 ([.NET Framework 4 Platform Update 1](http://go.microsoft.com/fwlink/?LinkID=215092)). This update included several new classes and activities that enabled developers to create state machine workflows. These classes and activities were updated for the .NET Framework 4.5 to include:  
  
    -   The ability to set breakpoints on states.  
  
    -   The ability to copy and paste transitions in the workflow designer.  
  
    -   Designer support for shared trigger transition creation.  
  
    -   Activities for creating state machine workflows, including: [StateMachine](assetId:///T:System.Activities.Statements.StateMachine?qualifyHint=False&autoUpgrade=True), [State](assetId:///T:System.Activities.Statements.State?qualifyHint=False&autoUpgrade=True), and [Transition](assetId:///T:System.Activities.Statements.Transition?qualifyHint=False&autoUpgrade=True).  
  
-   Enhanced Workflow Designer features such as the following:  
  
    -   Enhanced workflow search capabilities in Visual Studio, including **Quick Find** and **Find in Files**.  
  
    -   Ability to automatically create a Sequence activity when a second child activity is added to a container activity, and to include both activities in the Sequence activity.  
  
    -   Panning support, which enables the visible portion of a workflow to be changed without using the scroll bars.  
  
    -   A new **Document Outline** view that shows the components of a workflow in a tree-style outline view and lets you select a component in the **Document Outline** view.  
  
    -   Ability to add annotations to activities.  
  
    -   Ability to define and consume activity delegates by using the workflow designer.  
  
    -   Auto-connect and auto-insert for activities and transitions in state machine and flowchart workflows.  
  
-   Storage of the view state information for a workflow in a single element in the XAML file, so you can easily locate and edit the view state information.  
  
-   A NoPersistScope container activity to prevent child activities from persisting.  
  
-   Support for C# expressions:  
  
    -   Workflow projects that use Visual Basic will use Visual Basic expressions, and C# workflow projects will use C# expressions.  
  
    -   C# workflow projects that were created in Visual Studio 2010 and that have Visual Basic expressions are compatible with C# workflow projects that use C# expressions.  
  
-   Versioning enhancements:  
  
    -   The new  [WorkflowIdentity](assetId:///T:System.Activities.WorkflowIdentity?qualifyHint=False&autoUpgrade=True) class, which provides a mapping between a persisted workflow instance and its workflow definition.  
  
    -   Side-by-side execution of multiple workflow versions in the same host, including [WorkflowServiceHost](assetId:///T:System.ServiceModel.Activities.WorkflowServiceHost?qualifyHint=False&autoUpgrade=True).  
  
    -   In Dynamic Update, the ability to modify the definition of a persisted workflow instance.  
  
-   Contract-first workflow service development, which provides support for automatically generating activities to match an existing service contract.  
  
 For more information, see [What's New in Windows Workflow Foundation](http://go.microsoft.com/fwlink/?LinkId=228176).  
  
<a name="tailored"></a>   
### .NET for Windows 8.x Store Apps  
 Windows 8.x Store apps are designed for specific form factors and leverage the power of the Windows operating system. A subset of the .NET Framework 4.5 or 4.5.1 is available for building Windows 8.x Store apps for Windows by using C# or Visual Basic. This subset is called .NET for Windows 8.x Store apps and is discussed in an [overview](http://go.microsoft.com/fwlink/?LinkId=228491) in the Windows Dev Center.  
  
<a name="portable"></a>   
### Portable Class Libraries  
 The Portable Class Library project in Visual Studio 2012 (and later versions) enables you to write and build managed assemblies that work on multiple .NET Framework platforms. Using a Portable Class Library project, you choose the platforms (such as Windows Phone and .NET for Windows 8.x Store apps]) to target. The available types and members in your project are automatically restricted to the common types and members across these platforms. For more information, see [Portable Class Library](../Topic/Cross-Platform%20Development%20with%20the%20Portable%20Class%20Library.md).  
  
## See Also  
 [The .NET Framework and Out-of-Band Releases](~/docs/framework/get-started/the-net-framework-and-out-of-band-releases.md)   
 [What's New in Visual Studio 2013](http://msdn.microsoft.com/library/bb386063\(v=vs.120\).aspx)   
 [ASP.NET 4.5.1 and Web Tools for Visual Studio 2013](http://go.microsoft.com/fwlink/?LinkID=309094)   
 [ASP.NET and Visual Studio for Web](../Topic/ASP.NET%20and%20Visual%20Studio%20for%20Web.md)   
 [What's New in Windows Communication Foundation](http://go.microsoft.com/fwlink/?LinkId=228173)   
 [What's New in Windows Workflow Foundation](http://go.microsoft.com/fwlink/?LinkId=228176)   
 [What’s New in Visual C++](http://msdn.microsoft.com/library/hh409293\(v=vs.120\).aspx)
