---
title: "What's new in the .NET Framework"
ms.custom: "updateeachrelease"
ms.date: "05/02/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "what's new [.NET Framework]"
ms.assetid: 1d971dd7-10fc-4692-8dac-30ca308fc0fa
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---

# What's new in the .NET Framework
<a name="introduction"></a>This article summarizes key new features and improvements in the following versions of the .NET Framework:  
 
[.NET Framework 4.7.1](#v471)    
[.NET Framework 4.7](#v47)   
[.NET Framework 4.6.2](#v462)   
[.NET Framework 4.6.1](#v461)   
[.NET 2015 and .NET Framework 4.6](#v46)   
[.NET Framework 4.5.2](#v452)   
[.NET Framework 4.5.1](#v451)   
[.NET Framework 4.5](#v45)   

This article does not provide comprehensive information about each new feature and is subject to change. For general information about the .NET Framework, see [Getting Started](../../../docs/framework/get-started/index.md). For supported platforms, see [System Requirements](~/docs/framework/get-started/system-requirements.md). For download links and installation instructions, see [Installation Guide](../../../docs/framework/install/guide-for-developers.md).

> [!NOTE]
> The .NET Framework team also releases features out of band with NuGet to expand platform support and to introduce new functionality, such as immutable collections and SIMD-enabled vector types. For more information, see [Additional Class Libraries and APIs](../additional-apis/index.md) and [The .NET Framework and Out-of-Band Releases](~/docs/framework/get-started/the-net-framework-and-out-of-band-releases.md). See a [complete list of NuGet packages](https://blogs.msdn.microsoft.com/dotnet/p/nugetpackages/) for the .NET Framework, or subscribe to [our feed](https://nuget.org/api/v2/curated-feeds/dotnetframework/Packages/).

<a name="v471"></a> 
## Introducing the .NET Framework 4.7.1

The .NET Framework 4.7.1 builds on the .NET Framework 4.6, 4.6.1, 4.6.2, and 4.7 by adding many new fixes and several new features while remaining a very stable product.

### Downloading and installing the .NET Framework 4.7.1
 
You can download the .NET Framework 4.7.1  from the following locations:

- [.NET Framework 4.7.1 Web Installer](http://go.microsoft.com/fwlink/?LinkId=852095)

- [NET Framework 4.7.1 Offline Installer](http://go.microsoft.com/fwlink/?LinkId=852107)

The .NET Framework 4.7.1 can be installed on Windows 10, Windows 8.1, Windows 7 SP1, and the corresponding server platforms starting with Windows Server 2008 R2 SP1. You can install the .NET Framework 4.7.1 by using either the web installer or the offline installer. The recommended way for most users is to use the web installer.

You can target the .NET Framework 4.7.1 in Visual Studio 2012 or later by installing the [.NET Framework 4.7.1 Developer Pack](http://go.microsoft.com/fwlink/?LinkId=852105). 

### What's new in the .NET Framework 4.7.1

The .NET Framework 4.7.1 includes new features in the following areas:
 
- [Core](#core471)
- [Common language runtime (CLR)](#clr)
- [Networking](#net471)
- [ASP.NET](#asp-net471) 

In addition, a major focus in the .NET Framework 4.7.1 is improved accessibility, which allows an application to provide an appropriate experience for users of Assistive Technology. For information on accessibility improvements in the .NET Framework 4.7.1, see [What's new in accessibility in the .NET Framework](whats-new-in-accessibility.md). 

<a name="core471" />
#### Core

**Support for .NET Standard 2.0**

[.NET Standard](~/docs/standard/net-standard.md) defines a set of APIs that must be available on each .NET implementation that supports that version of the standard. The .NET Framework 4.7.1 fully supports .NET Standard 2.0 and adds [about 200 APIs](https://github.com/dotnet/standard/blob/master/netstandard/src/ApiCompatBaseline.net461.txt) that are defined in .NET Standard 2.0 and are missing from the .NET Framework 4.6.1, 4.6.2, and 4.7. (Note that these versions of the .NET Framework support .NET Standard 2.0 only if additional .NET Standard support files are also deployed on the target system.) For more information, see "BCL - .NET Standard 2.0 Support" in the [.NET Framework 4.7.1 Runtime and Compiler Features](https://blogs.msdn.microsoft.com/dotnet/2017/09/28/net-framework-4-7-1-runtime-and-compiler-features) blog post.

**Support for configuration builders**

Configuration builders allow developers to inject and build configuration settings for applications dynamically at run time. Custom configuration builders can be used to modify existing data in a configuration section or to build a configuration section entirely from scratch. Without configuration builders, .config files are static, and their settings are defined some time before an application is launched.

To create a custom configuration builder, you derive your builder from the abstract <xref:System.Configuration.ConfigurationBuilder> class and override its <xref:System.Configuration.ConfigurationBuilder.ProcessConfigurationSection%2A?displayProperty=nameWithType> and <xref:System.Configuration.ConfigurationBuilder.ProcessRawXml%2A?displayProperty=nameWithType>. You also define your builders in your .config file. For more information, see the "Configuration Builders" section in the [.NET Framework 4.7.1 ASP.NET and Configuration Features](https://blogs.msdn.microsoft.com/dotnet/2017/09/13/net-framework-4-7-1-asp-net-and-configuration-features) blog post. 

**Run-time feature detection**

The <xref:System.Runtime.CompilerServices.RuntimeFeature?displayProperty=nameWithType> class provides a mechanism for determine whether a predefined feature is supported on a given .NET implementation at compile time or run time. At compile time, a compiler can check whether a specified field exists to determine whether the feature is supported; if so, it can emit code that takes advantage of that feature. At run time, an application can call the <xref:System.Runtime.CompilerServices.RuntimeFeature.IsSupported%2A?displayProperty=nameWithType> method before emitting code at runtime. For more information, see [Add helper method to describe features supported by the runtime](https://github.com/dotnet/corefx/issues/17116).

**Value tuple types are serializable**

Starting with the .NET Framework 4.7.1, <xref:System.ValueTuple?displayProperty=nameWithType> and its associated generic types are marked as [Serializable](xref:System.SerializableAttribute), which allows binary serialization. This should make migrating Tuple types, such as <xref:System.Tuple%603> and <xref:System.Tuple%604>, to value tuple types easier. For more information, see "Compiler -- ValueTuple is Serializable" in the [.NET Framework 4.7.1 Runtime and Compiler Features](https://blogs.msdn.microsoft.com/dotnet/2017/09/28/net-framework-4-7-1-runtime-and-compiler-features) blog post.

**Support for read-only references**

The .NET Framework 4.7.1 adds the <xref:System.Runtime.CompilerServices.IsReadOnlyAttribute?displayProperty=nameWithType>. This attribute is used by language compilers to mark members that have read-only ref return types or parameters. For more information, see "Compiler -- Support for ReadOnlyReferences" in the [.NET Framework 4.7.1 Runtime and Compiler Features](https://blogs.msdn.microsoft.com/dotnet/2017/09/28/net-framework-4-7-1-runtime-and-compiler-features) blog post. For information on ref return values, see [Ref return values and ref locals (C# Guide)](~/docs/csharp/programming-guide/classes-and-structs/ref-returns.md) and [Ref return values (Visual Basic)](../../visual-basic/programming-guide/language-features/procedures/ref-return-values.md).

<a name="clr" />
#### Common language runtime (CLR)

**Garbage collection performance improvements**

Changes to garbage collection (GC) in the .NET Framework 4.7.1 improve overall performance, especially for Large Object Heap (LOH) allocations. In the .NET Framework 4.7.1, separate locks are used for Small Object Heap (SOH) and LOH allocations, which allows LOH allocations to occur when Background GC (BGC) is sweeping the SOH. As a result, applications that make a large number of LOH allocations should see a reduction in allocation lock contention and improved performance. For more information, see the "Runtime -- GC Performance Improvements" section in the [.NET Framework 4.7.1 Runtime and Compiler Features](https://blogs.msdn.microsoft.com/dotnet/2017/09/28/net-framework-4-7-1-runtime-and-compiler-features/) blog post. 

<a name="net471"/>
#### Networking

**SHA-2 support for Message.HashAlgorithm**

In the .NET Framework 4.7 and earlier versions, the <xref:System.Messaging.Message.HashAlgorithm%2A?displayProperty=nameWithType> property supported values of <xref:System.Messaging.HashAlgorithm.Md5?displayProperty=nameWithType> and <xref:System.Messaging.HashAlgorithm.Sha?displayProperty=nameWithType> only. Starting with the .NET Framework 4.7.1, <xref:System.Messaging.HashAlgorithm.Sha256?displayProperty=nameWithType>, <xref:System.Messaging.HashAlgorithm.Sha384?displayProperty=nameWithType>, and <xref:System.Messaging.HashAlgorithm.Sha512?displayProperty=nameWithType> are also supported. Whether this value is actually used depends on MSMQ, since the <xref:System.Messaging.Message> instance itself does no hashing but simply passes on values to MSMQ. For more information, see the "SHA-2 support for Message.HashAlgorithm" section in the [.NET Framework 4.7.1 ASP.NET and Configuration features](https://blogs.msdn.microsoft.com/dotnet/2017/09/13/net-framework-4-7-1-asp-net-and-configuration-features/) blog post.

<a name="asp-net471" />
#### ASP.NET

**Execution steps in ASP.NET applications**

ASP.NET processes requests in a predefined pipeline that includes 23 events. ASP.NET executes each event handler as an execution step. In versions of ASP.NET up to the .NET Framework 4.7, ASP.NET can't flow the execution context due to switching between native and managed threads. Instead, ASP.NET selectively flows only the <xref:System.Web.HttpContext>. Starting with the .NET Framework 4.7.1, the <xref:System.Web.HttpApplication.OnExecuteRequestStep(System.Action{System.Web.HttpContextBase,System.Action})?displayProperty=nameWithType> method also allows modules to restore ambient data. This feature is targeted at libraries concerned with tracing, profiling, diagnostics, or transactions, for example, that care about the execution flow of the application. For more information, see the "ASP.NET Execution Step Feature" in the [.NET Framework 4.7.1 ASP.NET and Configuration Features](https://blogs.msdn.microsoft.com/dotnet/2017/09/13/net-framework-4-7-1-asp-net-and-configuration-features) blog post. 

**ASP.NET HttpCookie parsing**

The .NET Framework 4.7.1 includes a new method, <xref:System.Web.HttpCookie.TryParse%2A?displayProperty=nameWithType>, that provides a standardized way to create an <xref:System.Web.HttpCookie> object from a string and accurately assign cookie values such as expiration date and path. For more information, see "ASP.NET HttpCookie parsing" in the [.NET Framework 4.7.1 ASP.NET and Configuration Features](https://blogs.msdn.microsoft.com/dotnet/2017/09/13/net-framework-4-7-1-asp-net-and-configuration-features) blog post. 

**SHA-2 hash options for ASP.NET forms authentication credentials**

In the .NET Framework 4.7 and earlier versions, ASP.NET allowed developers to store user credentials with hashed passwords in configuration files using either MD5 or SHA1. Starting with the .NET Framework 4.7.1, ASP.NET also supports new secure SHA-2 hash options such as SHA256, SHA384, and SHA512. SHA1 remains the default, and a non-default hash algorithm can be defined in the web configuration file. For example:

```xml
<system.web>
    <authentication mode="Forms">
        <forms loginUrl="~/login.aspx">
          <credentials passwordFormat="SHA512">
            <user name="jdoe" password="6D003E98EA1C7F04ABF8FCB375388907B7F3EE06F278DB966BE960E7CBBD103DF30CA6D61F7E7FD981B2E4E3A64D43C836A4BEDCA165C33B163E6BCDC538A664" />
          </credentials>
        </forms>
    </authentication>
</system.web>
```

<a name="v47"></a> 
### What's new in the .NET Framework 4.7

The .NET Framework 4.7 includes new features in the following areas:

- [Core](#Core47)
- [Networking](#net47)
- [ASP.NET](#ASP-NET47)
- [Windows Communication Foundation (WCF)](#wcf47)
- [Windows Forms](#wf47)
- [Windows Presentation Foundation (WPF)](#WPF47)

For a list of new APIs added to the .NET Framework 4.7, see [.NET Framework 4.7 API Changes](https://github.com/Microsoft/dotnet/blob/master/releases/net47/dotnet47-api-changes.md) on GitHub. For a list of feature improvements and bug fixes in the .NET Framework 4.7, see [.NET Framework 4.7 List of Changes](http://github.com/Microsoft/dotnet/blob/master/releases/net47/dotnet47-changes.md) on GitHub.  For additional information, see [Announcing the .NET Framework 4.7](https://blogs.msdn.microsoft.com/dotnet/2017/04/05/announcing-the-net-framework-4-7/) in the .NET blog.

<a name="Core47" />
#### Core

The .NET Framework 4.7 improves serialization by the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer>:

**Enhanced functionality with Elliptic Curve Cryptography (ECC)***

In the .NET Framework 4.7, `ImportParameters(ECParameters)` methods were added to the <xref:System.Security.Cryptography.ECDsa> and <xref:System.Security.Cryptography.ECDiffieHellman> classes to allow for an object to represent an already-established key. An `ExportParameters(Boolean)` method was also added for exporting the key using explicit curve parameters.

The .NET Framework 4.7 also adds support for additional curves (including the Brainpool curve suite), and has added predefined definitions for ease-of-creation through the new <xref:System.Security.Cryptography.ECDsa.Create%2A> and <xref:System.Security.Cryptography.ECDiffieHellman.Create%2A> factory methods.

You can see an [example of .NET Framework 4.7 cryptography improvements](https://gist.github.com/richlander/5a182899895a87a296c21ada97f7a54e) on GitHub.

**Better support for control characters by the DataContractJsonSerializer**

In the .NET Framework 4.7, the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer> serializes control characters in conformity with the ECMAScript 6 standard. This behavior is enabled by default for applications that target the .NET Framework 4.7, and is an opt-in feature for applications that are running under the .NET Framework 4.7 but target a previous version of the .NET Framework. For more information, see [Retargeting Changes in the .NET Framework 4.7](../../../docs/framework/migration-guide/retargeting-changes-in-the-net-framework-4-7.md).

<a name="net47" />
#### Networking

The .NET Framework 4.7 adds the following network-related feature:

**Default operating system support for TLS protocols***

The TLS stack, which is used by <xref:System.Net.Security.SslStream?displayProperty=nameWithType> and up-stack components such as HTTP, FTP, and SMTP, allows developers to use the default TLS protocols supported by the operating system. Developers need no longer hard-code a TLS version.

<a name="ASP-NET47" />
#### ASP.NET

In the .NET Framework 4.7, ASP.NET includes the following new features:

**Object Cache Extensibility**

Starting with the .NET Framework 4.7, ASP.NET adds a new set of APIs that allow developers to replace the default ASP.NET implementations for in-memory object caching and memory monitoring. Developers can now replace any of the following three components if the ASP.NET implementation is not adequate:

- **Object Cache Store**. By using the new cache providers configuration section, developers can plug in new implementations of an object cache for an ASP.NET application by using the new **ICacheStoreProvider** interface.
 
- **Memory monitoring**. The default memory monitor in ASP.NET notifies applications when they are running close to the configured private bytes limit for the process, or when the machine is low on total available physical RAM. When these limits are near, notifications are fired. For some applications, notifications are fired too close to the configured limits to allow for useful reactions. Developers can now write their own memory monitors to replace the default by using the <xref:System.Web.Hosting.ApplicationMonitors.MemoryMonitor%2A?displayProperty=nameWithType> property.

- **Memory Limit Reactions**. By default, ASP.NET attempts to trim the object cache and periodically call <xref:System.GC.Collect%2A?displayProperty=nameWithType> when the private byte process limit is near. For some applications, the frequency of calls to <xref:System.GC.Collect%2A?displayProperty=nameWithType> or the amount of cache that is trimmed are inefficient. Developers can now replace or supplement the default behavior by subscribing **IObserver** implementations to the application's memory monitor.

<a name="wcf47" />
#### Windows Communication Foundation (WCF)

Windows Communication Foundation (WCF) adds the following features and changes:

**Ability to configure the default message security settings to TLS 1.1 or TLS 1.2**

Starting with the .NET Framework 4.7, WCF allows you to configure TSL 1.1 or TLS 1.2 in addition to SSL 3.0 and TSL 1.0 as the default message security protocol. This is an opt-in setting; to enable it, you must add the following entry to your application configuration file:

```xml
<runtime>
   <AppContextSwitchOverrides value="Switch.System.ServiceModel.DisableUsingServicePointManagerSecurityProtocols=false;Switch.System.Net.DontEnableSchUseStrongCrypto=false" /> 
</runtime>
```

**Improved reliability of WCF applications and WCF serialization**

WCF includes a number of code changes that eliminate race conditions, thereby improving performance and the reliability of serialization options. These include:

- Better support for mixing asynchronous and synchronous code in calls to **SocketConnection.BeginRead** and **SocketConnection.Read**.
- Improved reliability when aborting a connection with **SharedConnectionListener** and **DuplexChannelBinder**.
- Improved reliability of serialization operations when calling the <xref:System.Runtime.Serialization.FormatterServices.GetSerializableMembers%28System.Type%29?displayProperty=nameWithType> method.
- Improved reliability when removing a waiter by calling the **ChannelSynchronizer.RemoveWaiter** method.

<a name="wf47" />
#### Windows Forms

In the .NET Framework 4.7, Windows Forms improves support for high DPI monitors.

**High DPI support**

Starting with applications that target the .NET Framework 4.7, the .NET Framework features high DPI and dynamic DPI support for Windows Forms applications. High DPI support improves the layout and appearance of forms and controls on high DPI monitors. Dynamic DPI changes the layout and appearance of forms and controls when the user changes the DPI or display scale factor of a running application.

High DPI support is an opt-in feature that you configure by defining a [\<System.Windows.Forms.ConfigurationSection>](../configure-apps/file-schema/winforms/index.md) section in your application configuration file. For more information on adding high DPI support and dynamic DPI support to your Windows Forms application, see [High DPI Support in Windows Forms](../winforms/high-dpi-support-in-windows-forms.md).

<a name="WPF47"></a> 
#### Windows Presentation Foundation (WPF)

In the .NET Framework 4.7, WPF includes the following enhancements:

**Support for a touch/stylus stack based on Windows WM_POINTER messages**

You now have the option of using a touch/stylus stack based on [WM_POINTER messages](https://msdn.microsoft.com/library/windows/desktop/hh454903.aspx) instead of the Windows Ink Services Platform (WISP). This is an opt-in feature in the .NET Framework. For more information, see [Retargeting Changes in the .NET Framework 4.7](../migration-guide/retargeting-changes-in-the-net-framework-4-7.md).

**New implementation for WPF printing APIs**

WPF's printing APIs in the <xref:System.Printing.PrintQueue?displayProperty=nameWithType> class call the Windows [Print Document Package API](https://msdn.microsoft.com/library/windows/desktop/hh448418(v=vs.85).aspx) instead of the deprecated [XPS Print API](https://msdn.microsoft.com/library/windows/desktop/ff686814(v=vs.85).aspx). For the impact of this change on application compatibility, see [Retargeting Changes in the .NET Framework 4.7](../migration-guide/retargeting-changes-in-the-net-framework-4-7.md). 

<a name="v462"></a> 
## What's new in the .NET Framework 4.6.2

The [!INCLUDE[net_v462](../../../includes/net-v462-md.md)] includes new features in the following areas:

- [ASP.NET](#ASPNET462)

- [Character categories](#Strings)

- [Cryptography](#Crypto462)

- [SqlClient](#SQLClient)

- [Windows Communication Foundation](#WCF)

- [Windows Presentation Foundation (WPF)](#WPF462)

- [Windows Workflow Foundation (WF)](#WF462)

- [ClickOnce](#ClickOnce)

- [Converting Windows Forms and WPF apps to UWP apps](#UWPConvert)

- [Debugging improvements](#Debug462)

For a list of new APIs added to the .NET Framework 4.6.2, see [.NET Framework 4.6.2 API Changes](https://github.com/Microsoft/dotnet/blob/master/releases/net462/dotnet462-api-changes.md) on GitHub. For a list of feature improvements and bug fixes in the .NET Framework 4.6.2, see [.NET Framework 4.6.2 List of Changes](http://go.microsoft.com/fwlink/?LinkId=708778) on GitHub.  For additional information, see [Announcing .NET Framework 4.6.2](https://blogs.msdn.microsoft.com/dotnet/2016/08/02/announcing-net-framework-4-6-2/) in the .NET blog.

<a name="ASPNET462"></a> 
### ASP.NET
 In the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], ASP.NET includes the following enhancements:

 **Improved support for localized error messages in data annotation validators**
 Data annotation validators enable you to perform validation by adding one or more attributes to a class property. The attribute's <xref:System.ComponentModel.DataAnnotations.ValidationAttribute.ErrorMessage%2A?displayProperty=nameWithType> element defines the text of the error message if validation fails. Starting with the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], ASP.NET makes it easy to localize error messages. Error messages will be localized if:

1.  The <xref:System.ComponentModel.DataAnnotations.ValidationAttribute.ErrorMessage%2A?displayProperty=nameWithType> is provided in the validation attribute.

2.  The resource file is stored in the App_LocalResources folder.

3.  The name of the localized resources file has the form `DataAnnotation.Localization.{`*name*`}.resx`, where *name* is a culture name in the format *languageCode*`-`*country/regionCode* or *languageCode*.

4.  The key name of the resource is the string assigned to the <xref:System.ComponentModel.DataAnnotations.ValidationAttribute.ErrorMessage%2A?displayProperty=nameWithType> attribute,  and its value is the localized error message.

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
   <Required(ErrorMessage = "The rating must be between 1 and 10.")>
   <Display(Name = "Your Rating")>
   Public Property Rating As Integer = 1
End Class
```

 You can then create a resource file, DataAnnotation.Localization.fr.resx, whose key is the error message string and whose value is the localized error message. The file must be found in the `App.LocalResources` folder. For example, the following is the key and its value in a localized French (fr) language error message:

| Name                                 | Value                                     |
| ------------------------------------ | ----------------------------------------- |
| The rating must be between 1 and 10. | La note doit être comprise entre 1 et 10. |

 This file can then

 In addition, data annotation localization is extensible. Developers can plug in their own string localizer provider by implementing the <xref:System.Web.Globalization.IStringLocalizerProvider> interface to store localization string somewhere other than in a resource file.

 **Async support with session-state store providers**
 ASP.NET now allows task-returning methods to be used with session-state store providers, thereby allowing ASP.NET apps to get the scalability benefits of async. To supports asynchronous operations with session state store providers, ASP.NET includes  a new interface, <xref:System.Web.SessionState.ISessionStateModule?displayProperty=nameWithType>, which inherits from <xref:System.Web.IHttpModule> and allows developers to implement their own session-state module and async session store providers. The interface is defined as follows:

```csharp
public interface ISessionStateModule : IHttpModule {
    void ReleaseSessionState(HttpContext context);
    Task ReleaseSessionStateAsync(HttpContext context);
}
```

 In addition, the <xref:System.Web.SessionState.SessionStateUtility> class includes two new methods, <xref:System.Web.SessionState.SessionStateUtility.IsSessionStateReadOnly%2A> and <xref:System.Web.SessionState.SessionStateUtility.IsSessionStateRequired%2A>, that can be used to support asynchronous operations.

 **Async support for output-cache providers**
 Starting with the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], task-returning methods can be used with output-cache providers to provide the scalability benefits of async.  Providers that implement these methods reduce thread-blocking on a web server and improve the scalability of an ASP.NET service.

 The following APIs have been added to support asynchronous output-cache providers:

- The <xref:System.Web.Caching.OutputCacheProviderAsync?displayProperty=nameWithType> class, which inherits from <xref:System.Web.Caching.OutputCacheProvider?displayProperty=nameWithType> and allows developers to implement an asynchronous output-cache provider.

- The <xref:System.Web.Caching.OutputCacheUtility> class, which provides helper methods for configuring the output cache.

- 18 new methods in the <xref:System.Web.HttpCachePolicy?displayProperty=nameWithType> class. These include <xref:System.Web.HttpCachePolicy.GetCacheability%2A>, <xref:System.Web.HttpCachePolicy.GetCacheExtensions%2A>, <xref:System.Web.HttpCachePolicy.GetETag%2A>, <xref:System.Web.HttpCachePolicy.GetETagFromFileDependencies%2A>, <xref:System.Web.HttpCachePolicy.GetMaxAge%2A>, <xref:System.Web.HttpCachePolicy.GetMaxAge%2A>, <xref:System.Web.HttpCachePolicy.GetNoStore%2A>, <xref:System.Web.HttpCachePolicy.GetNoTransforms%2A>, <xref:System.Web.HttpCachePolicy.GetOmitVaryStar%2A>, <xref:System.Web.HttpCachePolicy.GetProxyMaxAge%2A>, <xref:System.Web.HttpCachePolicy.GetRevalidation%2A>, <xref:System.Web.HttpCachePolicy.GetUtcLastModified%2A>, <xref:System.Web.HttpCachePolicy.GetVaryByCustom%2A>, <xref:System.Web.HttpCachePolicy.HasSlidingExpiration%2A>, and <xref:System.Web.HttpCachePolicy.IsValidUntilExpires%2A>.

- 2 new methods in the <xref:System.Web.HttpCacheVaryByContentEncodings?displayProperty=nameWithType> class:  <xref:System.Web.HttpCacheVaryByContentEncodings.GetContentEncodings%2A> and <xref:System.Web.HttpCacheVaryByContentEncodings.SetContentEncodings%2A>.

- 2 new methods in the <xref:System.Web.HttpCacheVaryByHeaders?displayProperty=nameWithType> class: <xref:System.Web.HttpCacheVaryByHeaders.GetHeaders%2A> and <xref:System.Web.HttpCacheVaryByHeaders.SetHeaders%2A>.

- 2 new methods in the <xref:System.Web.HttpCacheVaryByParams?displayProperty=nameWithType> class: <xref:System.Web.HttpCacheVaryByParams.GetParams%2A> and <xref:System.Web.HttpCacheVaryByParams.SetParams%2A>.

- In the <xref:System.Web.Caching.AggregateCacheDependency?displayProperty=nameWithType> class, the <xref:System.Web.Caching.AggregateCacheDependency.GetFileDependencies%2A> method.

- In the <xref:System.Web.Caching.CacheDependency>, the <xref:System.Web.Caching.CacheDependency.GetFileDependencies%2A> method.

<a name="Strings"></a> 
### Character categories
 Characters in the  [!INCLUDE[net_v462](../../../includes/net-v462-md.md)] are classified based on the [Unicode Standard, Version 8.0.0](http://www.unicode.org/versions/Unicode8.0.0/). In [!INCLUDE[net_v46](../../../includes/net-v46-md.md)] and [!INCLUDE[net_v461](../../../includes/net-v461-md.md)], characters were classified based on Unicode 6.3 character categories.

 Support for Unicode 8.0 is limited to the classification of characters by the <xref:System.Globalization.CharUnicodeInfo> class and to types and methods that rely on it. These include the <xref:System.Globalization.StringInfo> class, the overloaded <xref:System.Char.GetUnicodeCategory%2A?displayProperty=nameWithType> method, and the [character classes](../../../docs/standard/base-types/character-classes-in-regular-expressions.md) recognized by the .NET Framework regular expression engine.  Character and string comparison and sorting is unaffected by this change and continues to rely on the underlying operating system or, on Windows 7 systems, on character data provided by the .NET Framework.

 For changes in character categories from Unicode 6.0 to Unicode 7.0, see [The Unicode Standard, Version 7.0.0](http://www.unicode.org/versions/Unicode7.0.0/) at The Unicode Consortium website. For changes from Unicode 7.0 to Unicode 8.0, see [The Unicode Standard, Version 8.0.0](http://www.unicode.org/versions/Unicode8.0.0/) at The Unicode Consortium website.

<a name="Crypto462"></a> 
### Cryptography
 **Support for X509 certificates containing FIPS 186-3 DSA**
 The [!INCLUDE[net_v462](../../../includes/net-v462-md.md)] adds support for DSA (Digital Signature Algorithm) X509 certificates whose keys exceed the FIPS 186-2 1024-bit limit.

 In addition to supporting the larger key sizes of FIPS 186-3, the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)] allows computing signatures with the SHA-2 family of hash algorithms (SHA256, SHA384, and SHA512). FIPS 186-3 support is provided by the new <xref:System.Security.Cryptography.DSACng?displayProperty=nameWithType> class.

 In keeping with recent changes to the <xref:System.Security.Cryptography.RSA> class in the .NET Framework 4.6 and the <xref:System.Security.Cryptography.ECDsa> class in the .NET Framework 4.6.1, the <xref:System.Security.Cryptography.DSA> abstract base class in [!INCLUDE[net_v462](../../../includes/net-v462-md.md)] has additional methods to allow callers to use this functionality without casting. You can call the <xref:System.Security.Cryptography.X509Certificates.DSACertificateExtensions.GetDSAPrivateKey%2A?displayProperty=nameWithType> extension method to sign data, as the following example shows.

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

 And you can call the <xref:System.Security.Cryptography.X509Certificates.DSACertificateExtensions.GetDSAPublicKey%2A?displayProperty=nameWithType> extension method to verify signed data, as the following example shows.

```csharp
public static bool VerifyDataDsaSha384(byte[] data, byte[] signature, X509Certificate2 cert)
{
    using (DSA dsa = cert.GetDSAPublicKey())
    {
        return dsa.VerifyData(data, signature, HashAlgorithmName.SHA384);
    }
}
```

```vb
 Public Shared Function VerifyDataDsaSha384(data As Byte(), signature As Byte(), cert As X509Certificate2) As Boolean
    Using dsa As DSA = cert.GetDSAPublicKey()
        Return dsa.VerifyData(data, signature, HashAlgorithmName.SHA384)
    End Using
End Function
```

 **Increased clarity for inputs to ECDiffieHellman key derivation routines**
 The .NET Framework 3.5 added support for Ellipic Curve Diffie-Hellman Key Agreement with three different Key Derivation Function (KDF) routines. The inputs to the routines, and the routines themselves, were configured via properties on the <xref:System.Security.Cryptography.ECDiffieHellmanCng> object. But since not every routine read every input property, there was ample room for confusion on the past of the developer.

 To address this in the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], the following three methods have been added to the  <xref:System.Security.Cryptography.ECDiffieHellman> base class to more clearly represent these KDF routines and their inputs:

|ECDiffieHellman method|Description|
|----------------------------|-----------------|
|<xref:System.Security.Cryptography.ECDiffieHellman.DeriveKeyFromHash%28System.Security.Cryptography.ECDiffieHellmanPublicKey%2CSystem.Security.Cryptography.HashAlgorithmName%2CSystem.Byte%5B%5D%2CSystem.Byte%5B%5D%29>|Derives key material using the formula<br /><br /> HASH(secretPrepend &#124;&#124; *x* &#124;&#124; secretAppend)<br /><br /> HASH(secretPrepend OrElse *x* OrElse secretAppend)<br /><br /> where *x* is the computed result of the EC Diffie-Hellman algorithm.|
|<xref:System.Security.Cryptography.ECDiffieHellman.DeriveKeyFromHmac%28System.Security.Cryptography.ECDiffieHellmanPublicKey%2CSystem.Security.Cryptography.HashAlgorithmName%2CSystem.Byte%5B%5D%2CSystem.Byte%5B%5D%2CSystem.Byte%5B%5D%29>|Derives key material using the formula<br /><br /> HMAC(hmacKey, secretPrepend &#124;&#124; *x* &#124;&#124; secretAppend)<br /><br /> HMAC(hmacKey, secretPrepend OrElse *x* OrElse secretAppend)<br /><br /> where *x* is the computed result of the EC Diffie-Hellman algorithm.|
|<xref:System.Security.Cryptography.ECDiffieHellman.DeriveKeyTls%28System.Security.Cryptography.ECDiffieHellmanPublicKey%2CSystem.Byte%5B%5D%2CSystem.Byte%5B%5D%29>|Derives key material using the TLS pseudo-random function (PRF) derivation algorithm.|

 **Support for persisted-key symmetric encryption**
 The Windows cryptography library (CNG) added support for storing persisted symmetric keys and using hardware-stored symmetric keys, and the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)] mades it possible for developers to make use of this feature.  Since the notion of key names and key providers is implementation-specific, using this feature requires utilizing the constructor of the concrete implementation types instead of the preferred factory approach (such as calling `Aes.Create`).

 Persisted-key symmetric encryption support exists for the AES (<xref:System.Security.Cryptography.AesCng>) and 3DES (<xref:System.Security.Cryptography.TripleDESCng>) algorithms. For example:

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
 The [!INCLUDE[net_v462](../../../includes/net-v462-md.md)] adds support to  the <xref:System.Security.Cryptography.Xml.SignedXml> class for RSA-SHA256, RSA-SHA384, and RSA-SHA512 PKCS#1 signature methods, and SHA256, SHA384, and SHA512 reference digest algorithms.

 The URI constants are all exposed on <xref:System.Security.Cryptography.Xml.SignedXml>:

|SignedXml field|Constant|
|---------------------|--------------|
|<xref:System.Security.Cryptography.Xml.SignedXml.XmlDsigSHA256Url>|"http://www.w3.org/2001/04/xmlenc#sha256"|
|<xref:System.Security.Cryptography.Xml.SignedXml.XmlDsigRSASHA256Url>|"http://www.w3.org/2001/04/xmldsig-more#rsa-sha256"|
|<xref:System.Security.Cryptography.Xml.SignedXml.XmlDsigSHA384Url>|"http://www.w3.org/2001/04/xmldsig-more#sha384"|
|<xref:System.Security.Cryptography.Xml.SignedXml.XmlDsigRSASHA384Url>|"http://www.w3.org/2001/04/xmldsig-more#rsa-sha384"|
|<xref:System.Security.Cryptography.Xml.SignedXml.XmlDsigSHA512Url>|"http://www.w3.org/2001/04/xmlenc#sha512"|
|<xref:System.Security.Cryptography.Xml.SignedXml.XmlDsigRSASHA512Url>|"http://www.w3.org/2001/04/xmldsig-more#rsa-sha512"|

 Any programs that have registered a custom <xref:System.Security.Cryptography.SignatureDescription> handler into <xref:System.Security.Cryptography.CryptoConfig> to add support for these algorithms will continue to function as they did in the past, but since there are now platform defaults, the <xref:System.Security.Cryptography.CryptoConfig> registration is no longer necessary.

<a name="SQLClient"></a> 
### SqlClient
 .NET Framework Data Provider for SQL Server (<xref:System.Data.SqlClient?displayProperty=nameWithType>) includes the following new features in the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)]:

 **Connection pooling and timeouts with Azure SQL databases**
 When connection pooling is enabled and a timeout or other login error occurs, an exception is cached, and the cached exception is thrown on any subsequent connection attempt for the next 5 seconds  to 1 minute.  For more details, see [SQL Server Connection Pooling (ADO.NET)](../../../docs/framework/data/adonet/sql-server-connection-pooling.md).

 This behavior is not desirable when connecting to Azure SQL Databases, since connection attempts can fail with transient errors that are typically recovered quickly. To better optimize the connection retry experience, the connection pool blocking period behavior is removed when connections to Azure SQL Databases fail.

 The addition of the new `PoolBlockingPeriod` keyword lets you to select the blocking period best suited for your app. Values include:

 `Auto`
 The connection pool blocking period for an application that connects to an Azure SQL Database is disabled, and the connection pool blocking period for an application that connects to any other SQL Server instance is enabled. This is the default value. If the Server endpoint name ends with any of the following, they are considered Azure SQL Databases:

- .database.windows.net

- .database.chinacloudapi.cn

- .database.usgovcloudapi.net

- .database.cloudapi.de

 `AlwaysBlock`
 The connection pool blocking period is always enabled.

 `NeverBlock`
 The connection pool blocking period is always disabled.

 **Enhancements for Always Encrypted**
 SQLClient introduces two enhancements for Always Encrypted:

- To improve performance of parameterized queries against encrypted database columns, encryption metadata for query parameters is now cached. With the <xref:System.Data.SqlClient.SqlConnection.ColumnEncryptionQueryMetadataCacheEnabled%2A?displayProperty=nameWithType> property set to `true` (which is the default value), if the same query is called multiple times, the client retrieves parameter metadata from the server only once.

- Column encryption key entries in the key cache are now evicted after a configurable time interval, set using the <xref:System.Data.SqlClient.SqlConnection.ColumnEncryptionKeyCacheTtl%2A?displayProperty=nameWithType> property.

<a name="WCF"></a> 
### Windows Communication Foundation
 In the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], Windows Communication Foundation has been enhanced in the following areas:

 **WCF transport security support for certificates stored using CNG**
 WCF transport security supports certificates stored using the Windows cryptography library (CNG). In the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], this support is limited to using certificates with a public key that has an exponent no more than 32 bits in length. When an application targets the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], this feature is on by default.

 For applications that target the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)] and earlier but are running on the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], this feature can be enabled by adding the following line to the [\<runtime>](../../../docs/framework/configure-apps/file-schema/runtime/runtime-element.md) section of the app.config or web.config file.

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
 Customers can use an application configuration setting to determine whether the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer> class supports multiple adjustment rules for a single time zone. This is an opt-in feature. To enable it, add the following setting to your app.config file:

```xml
<runtime>
     <AppContextSwitchOverrides value="Switch.System.Runtime.Serialization.DoNotUseTimeZoneInfo=false" />
</runtime>
```

When this feature is enabled, a <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer> object uses the <xref:System.TimeZoneInfo> type instead of the <xref:System.TimeZone> type to deserialize date and time data. <xref:System.TimeZoneInfo> supports multiple adjustment rules, which makes it possible to work with historic time zone data;   <xref:System.TimeZone> does not.

For more information on the <xref:System.TimeZoneInfo> structure and time zone adjustments, see [Time Zone Overview](../../../docs/standard/datetime/time-zone-overview.md).

 **NetNamedPipeBinding best match**   
 WCF has a new app setting that can be set on client applications to ensure they always connect to the service listening on the URI that best matches the one that they request. With this app setting set to `false` (the default), it is possible for clients using <xref:System.ServiceModel.NetNamedPipeBinding> to attempt to connect to a service listening on a URI that is a substring of the requested URI.

 For example, a client tries to connect to a service listening at `net.pipe://localhost/Service1`, but a different service on that machine running with administrator privilege is listening at `net.pipe://localhost`. With this app setting set to `false`, the client would attempt to connect to the wrong service. After setting the app setting to `true`, the client will always connect to the best matching service.

> [!NOTE]
>  Clients using <xref:System.ServiceModel.NetNamedPipeBinding> find services based on the service's base address (if it exists) rather than the full endpoint address. To ensure this setting always works the service should use a unique base address.

 To enable this change, add the following app setting to your client application's App.config or Web.config file:

```xml
<configuration>
    <appSettings>
        <add key="wcf:useBestMatchNamedPipeUri" value="true" />
    </appSettings>
</configuration>
```

 **SSL 3.0 is not a default protocol**
 When using NetTcp with transport security and a credential type of certificate, SSL 3.0 is no longer a default protocol used for negotiating a secure connection. In most cases, there should be no impact to existing apps, because TLS 1.0 is included in the protocol list for NetTcp. All existing clients should be able to negotiate a connection using at least TLS 1.0. If Ssl3 is required, use one of the following configuration mechanisms to add it to the list of negotiated protocols.

- The <xref:System.ServiceModel.Channels.SslStreamSecurityBindingElement.SslProtocols%2A?displayProperty=nameWithType> property

- The <xref:System.ServiceModel.TcpTransportSecurity.SslProtocols%2A?displayProperty=nameWithType> property

- The [\<transport>](../../../docs/framework/configure-apps/file-schema/wcf/transport-of-nettcpbinding.md) section of the [\<netTcpBinding>](../../../docs/framework/configure-apps/file-schema/wcf/nettcpbinding.md) section

- The [\<sslStreamSecurity>](../../../docs/framework/configure-apps/file-schema/wcf/sslstreamsecurity.md) section of the [\<customBinding>](../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md) section

<a name="WPF462"></a> 
### Windows Presentation Foundation (WPF)
 In the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], Windows Presentation Foundation has been enhanced in the following areas:

 **Group sorting**
 An application that uses a <xref:System.Windows.Data.CollectionView> object to group data can now explicitly declare how to  sort the groups. Explicit sorting addresses the problem of non-intuitive ordering that occurs when an app dynamically adds or removes groups, or when it changes the value of item properties involved in grouping. It can also improve the performance of the group creation process by moving comparisons of the grouping properties from the sort of the full collection to the sort of the groups.

 To support group sorting, the new <xref:System.ComponentModel.GroupDescription.SortDescriptions%2A?displayProperty=nameWithType> and <xref:System.ComponentModel.GroupDescription.CustomSort%2A?displayProperty=nameWithType> properties describe how to sort the collection of groups produced by the <xref:System.ComponentModel.GroupDescription> object. This is analogous to the way the identically named <xref:System.Windows.Data.ListCollectionView> properties describe how to sort the data items.

 Two new static properties of the <xref:System.Windows.Data.PropertyGroupDescription> class,  <xref:System.Windows.Data.PropertyGroupDescription.CompareNameAscending%2A> and <xref:System.Windows.Data.PropertyGroupDescription.CompareNameDescending%2A>, can be used for the most common cases.

 For example, the following XAML groups data by age, sort the age groups in ascending order, and group the items within each age group by last name.

```xaml
<GroupDescriptions>
     <PropertyGroupDescription 
         PropertyName="Age" 
         CustomSort= 
              "{x:Static PropertyGroupDescription.CompareNamesAscending}"/>
     </PropertyGroupDescription>
</GroupDescriptions>

<SortDescriptions>
     <SortDescription PropertyName="LastName"/>
</SortDescriptions>
```

 **Soft keyboard support**
 Soft Keyboard support enables focus tracking in a WPF applications by automatically invoking and dismissing the new Soft Keyboard in Windows 10 when the touch input is received by a control that can take textual input.

 In previous versions of the .NET Framework, WPF applications cannot opt into the focus tracking without disabling WPF pen/touch gesture support.  As a result, WPF applications must choose between full WPF touch support or rely on Windows mouse promotion.

 **Per-monitor DPI**
 To support the recent proliferation of high-DPI and hybrid-DPI environments for WPF apps, WPF in the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)] enables per-monitor awareness. See the [samples and developer guide](https://github.com/Microsoft/WPF-Samples/tree/master/PerMonitorDPI) on GitHub for more information about how to enable your WPF app to become per-monitor DPI aware.

 In previous versions of the .NET Framework, WPF apps are system-DPI aware. In other words, the application's UI is scaled by the OS as appropriate, depending on the DPI of the monitor on which the app is rendered. ,

 For apps running under the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], you can disable per-monitor DPI changes in WPF apps by adding a configuration statement to the [\<runtime>](../../../docs/framework/configure-apps/file-schema/runtime/runtime-element.md) section of your application configuration file, as follows:

```xml
<runtime>
   <AppContextSwitchOverrides value="Switch.System.Windows.DoNotScaleForDpiChanges=false"/>
</runtime>
```

<a name="WF462"></a> 
### Windows Workflow Foundation (WF)
 In the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], Windows Workflow Foundation has been enhanced in the following area:

 **Support for C# expressions and IntelliSense in the Re-hosted WF Designer**
 Starting with the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)], WF supports C# expressions in both the Visual Studio Designer and in code workflows. The Re-hosted Workflow Designer is a key feature of WF that allows for the Workflow Designer to be in an application outside Visual Studio (for example, in WPF).  Windows Workflow Foundation provides the ability to support C# expressions and IntelliSense in the Re-hosted Workflow Designer. For more information, see the [Windows Workflow Foundation blog](http://go.microsoft.com/fwlink/?LinkID=809042&clcid=0x409).

 `Availability of IntelliSense when a customer rebuilds a workflow project from Visual Studio`
 In versions of the .NET Framework prior to the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], WF Designer IntelliSense is broken when a customer rebuilds a workflow project from Visual Studio. While the project build is successful, the workflow types are not found on the designer, and warnings from IntelliSense for the missing workflow types appear in the **Error List** window. The [!INCLUDE[net_v462](../../../includes/net-v462-md.md)] addresses this issue and makes IntelliSense available.

 **Workflow V1 applications with Workflow Tracking on now run under FIPS-mode**
 Machines with FIPS Compliance Mode enabled can now successfully run a workflow Version 1-style application with Workflow tracking on. To enable this scenario, you must make the following change to your app.config file:

```xml
<add key="microsoft:WorkflowRuntime:FIPSRequired" value="true" />
```

 If this scenario is not enabled, running the application continues to generate an exception with the message, "This implementation is not part of the Windows Platform FIPS validated cryptographic algorithms."

 **Workflow Improvements when using Dynamic Update with Visual Studio Workflow Designer**
 The Workflow Designer, FlowChart Activity Designer, and other Workflow Activity Designers now successfully load and display workflows that have been saved after calling  the <xref:System.Activities.DynamicUpdate.DynamicUpdateServices.PrepareForUpdate%2A?displayProperty=nameWithType> method. In versions of the .NET Framework before the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], loading a XAML file in Visual Studio for a workflow that has been saved after calling <xref:System.Activities.DynamicUpdate.DynamicUpdateServices.PrepareForUpdate%2A?displayProperty=nameWithType> can result in the following issues:

- The Workflow Designer can't load the XAML file correctly (when the <xref:System.Activities.Presentation.ViewState.ViewStateData.Id%2A?displayProperty=nameWithType> is at the end of the line).

- Flowchart Activity Designer or other Workflow Activity Designers may display all objects in their default locations as opposed to attached property values.

<a name="ClickOnce"></a> 
### ClickOnce
 ClickOnce has been updated to support TLS 1.1 and TLS 1.2 in addition to the 1.0 protocol, which it already supports. ClickOnce automatically detects which protocol is required; no extra steps within the ClickOnce application are required to enable TLS 1.1 and 1.2 support.

<a name="UWPConvert"></a> 
### Converting Windows Forms and WPF apps to  UWP apps
 Windows now offers capabilities to bring existing Windows desktop apps, including WPF and Windows Forms apps, to the Universal Windows Platform (UWP). This technology acts as a bridge by enabling you to gradually migrate your existing code base to UWP, thereby bringing your app to all Windows 10 devices.

 Converted desktop apps gain an app identity similar to the app identity of UWP apps, which makes UWP APIs accessible to enable features such as Live Tiles and notifications. The app continues to behave as before and runs as a full trust app. Once the app is converted, an app container process can be added to the existing full trust process to add an adaptive user interface. When all functionality is moved to the app container process, the full trust process can be removed and the new UWP app can be made available to all Windows 10 devices.

<a name="Debug462"></a> 
### Debugging improvements
 The *unmanaged debugging API* has been enhanced in the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)] to perform additional analysis when a <xref:System.NullReferenceException> is thrown so that it is possible to determine which variable in a single line of source code is `null`.   To support this scenario, the following APIs have been added to the unmanaged debugging API.

- The [ICorDebugCode4](../../../docs/framework/unmanaged-api/debugging/icordebugcode4-interface.md), [ICorDebugVariableHome](../../../docs/framework/unmanaged-api/debugging/icordebugvariablehome-interface.md), and [ICorDebugVariableHomeEnum](../../../docs/framework/unmanaged-api/debugging/icordebugvariablehomeenum-interface.md) interfaces, which expose the native homes of managed variables. This enables debuggers to do some code flow analysis when a  <xref:System.NullReferenceException> occurs and to work backwards to determine the managed variable that corresponds to the native location that was `null`.

- The [ICorDebugType2::GetTypeID](../../../docs/framework/unmanaged-api/debugging/icordebugtype2-gettypeid-method.md) method provides a mapping for ICorDebugType to [COR_TYPEID](../../../docs/framework/unmanaged-api/debugging/cor-typeid-structure.md), which allows the debugger to obtain a [COR_TYPEID](../../../docs/framework/unmanaged-api/debugging/cor-typeid-structure.md) without an instance of the ICorDebugType. Existing APIs on [COR_TYPEID](../../../docs/framework/unmanaged-api/debugging/cor-typeid-structure.md) can then be used to determine the class layout of the type.

<a name="v461"></a> 
## What's new in the .NET Framework 4.6.1
 The [!INCLUDE[net_v461](../../../includes/net-v461-md.md)] includes new features in the following areas:

- [Cryptography](#Crypto)

- [ADO.NET](#ADO.NET461)

- [Windows Presentation Foundation (WPF)](#WPF461)

- [Windows Workflow Foundation](#WWF461)

- [Profiling](#Profile461)

- [NGen](#NGEN461)

 For more information on the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)], see the following topics:

- The [.NET Framework 4.6.1 list of changes](http://go.microsoft.com/fwlink/?LinkId=622964)

- [Application Compatibility in 4.6.1](../../../docs/framework/migration-guide/application-compatibility-in-the-net-framework-4-6-1.md)

- [The .NET Framework API diff](http://go.microsoft.com/fwlink/?LinkId=622989) (on GitHub)

<a name="Crypto"></a> 
### Cryptography: Support for X509 certificates containing ECDSA
 The .NET Framework 4.6 added RSACng support for X509 certificates. The [!INCLUDE[net_v461](../../../includes/net-v461-md.md)] adds support for ECDSA (Elliptic Curve Digital Signature Algorithm) X509 certificates.

 ECDSA offers better performance and is a more secure cryptography algorithm than RSA, providing an excellent choice where Transport Layer Security (TLS) performance and scalability is a concern. The .NET Framework implementation wraps calls into existing Windows functionality.

 The following example code shows how easy it is to generate a signature for a byte stream by using the new  support for ECDSA  X509 certificates included in the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)].

 [!code-csharp[whatsnew.461.crypto#1](../../../samples/snippets/csharp/VS_Snippets_CLR/whatsnew.461.crypto/cs/Code46.cs#1)]
 [!code-vb[whatsnew.461.crypto#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/whatsnew.461.crypto/vb/Code461.vb#1)]

 This offers a marked contrast to the code needed to generate a signature in the .NET Framework 4.6.

 [!code-csharp[whatsnew.461.crypto#2](../../../samples/snippets/csharp/VS_Snippets_CLR/whatsnew.461.crypto/cs/Code46.cs#2)]
 [!code-vb[whatsnew.461.crypto#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/whatsnew.461.crypto/vb/Code46.vb#2)]

<a name="ADO.NET461"></a> 
### ADO.NET
 The following have been added to ADO.NET:

 Always Encrypted support for hardware protected keys
 ADO.NET now supports storing Always Encrypted column master keys natively in Hardware Security Modules (HSMs). With this support, customers can leverage asymmetric keys stored in HSMs without having to write custom column master key store providers and registering them in applications.

 Customers need to install the HSM vendor-provided CSP provider or CNG key store providers on the app servers or client computers in order to access Always Encrypted data protected with column master keys stored in a HSM.

 Improve <xref:System.Data.SqlClient.SqlConnectionStringBuilder.MultiSubnetFailover%2A> connection behavior for AlwaysOn
 SqlClient now automatically provides faster connection to an AlwaysOn Availability Group (AG). It transparently detects whether your application is connecting to an AlwaysOn availability group (AG) on a different subnet and quickly discovers the current active server and provides a connection to the server. Prior to this release, an application had to set the connection string to include `"MultisubnetFailover=true"` to indicate that it was connecting to an AlwaysOn Availability Group. Without setting the connection keyword to `true`, an application might experience a timeout while connecting to an AlwaysOn Availability Group. With this release, an application does *not* need to set <xref:System.Data.SqlClient.SqlConnectionStringBuilder.MultiSubnetFailover%2A> to `true` anymore. For more information about SqlClient support for Always On Availability Groups, see [SqlClient Support for High Availability, Disaster Recovery](../../../docs/framework/data/adonet/sql/sqlclient-support-for-high-availability-disaster-recovery.md).

<a name="WPF461"></a> 
### Windows Presentation Foundation (WPF)
 Windows Presentation Foundation includes a number of improvements and changes.

 Improved performance
 The delay in firing touch events has been fixed in the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)]. In addition, typing in a <xref:System.Windows.Controls.RichTextBox> control no longer ties up the render thread during fast input.

 Spell checking improvements
 The spell checker in WPF has been updated on Windows 8.1 and later versions to leverage operating system support for spell-checking additional languages.  There is no change in functionality on Windows versions prior to Windows 8.1.

 As in previous versions of the .NET Framework, the language for a <xref:System.Windows.Controls.TextBox> control ora <xref:System.Windows.Controls.RichTextBox> block is detected by looking for information in the following order:

- `xml:lang`, if it is present.

- Current input language.

- Current thread culture.

 For additional information on language support in WPF, see the [WPF blog post on .NET Framework 4.6.1 features](http://go.microsoft.com/fwlink/?LinkID=691819).

 Additional support for per-user custom dictionaries
 In [!INCLUDE[net_v461](../../../includes/net-v461-md.md)], WPF recognizes custom dictionaries that are registered globally. This capability is available in addition to the ability to register them per-control.

 In previous versions of WPF, custom dictionaries did not recognize Excluded Words and AutoCorrect lists. They are supported on Windows 8.1 and Windows 10 through the use of files that can be placed under the `%AppData%\Microsoft\Spelling\<language tag>` directory.  The following rules apply to these files:

- The files should have extensions of .dic (for added words), .exc (for excluded words), or .acl (for AutoCorrect).

- The files should be UTF-16 LE plaintext that starts with the Byte Order Mark (BOM).

- Each line should consist of a word (in the added and excluded word lists), or an autocorrect pair with the words separated by a vertical bar ("&#124;") (in the AutoCorrect word list).

- These files are considered read-only and are not modified by the system.

> [!NOTE]
>  These new file-formats are not directly supported by the WPF spell checking API’s, and the custom dictionaries supplied to WPF in applications should continue to use .lex files.

 Samples
 There are a number of [WPF Samples](https://msdn.microsoft.com/library/ms771633.aspx) on MSDN. More than 200 of the most popular samples (based on their usage) will be moved into an [Open Source GitHub repository](https://github.com/Microsoft/WPF-Samples). Help us improve our samples by sending us a pull-request or opening a [GitHub issue](https://github.com/Microsoft/WPF-Samples/issues).

 DirectX extensions
 WPF includes a [NuGet package](http://go.microsoft.com/fwlink/?LinkID=691342) that provides new implementations of <xref:System.Windows.Interop.D3DImage> that make it easy for you to interoperate with DX10 and Dx11 content. The code for this package has been open sourced and is available [on GitHub](https://github.com/Microsoft/WPFDXInterop).

<a name="WWF461"></a> 
### Windows Workflow Foundation: Transactions
 The <xref:System.Transactions.Transaction.EnlistPromotableSinglePhase%2A?displayProperty=nameWithType> method can now use a distributed transaction manager other than MSDTC to promote the transaction. You do this by specifying a GUID transaction promoter identifier to the  new <xref:System.Transactions.Transaction.EnlistPromotableSinglePhase%28System.Transactions.IPromotableSinglePhaseNotification%2CSystem.Guid%29?displayProperty=nameWithType> overload . If this operation is successful, there are limitations placed on the capabilities of the transaction. Once a non-MSDTC transaction promoter is enlisted, the following methods throw a <xref:System.Transactions.TransactionPromotionException> because these methods require promotion to MSDTC:

- <xref:System.Transactions.Transaction.EnlistDurable%2A?displayProperty=nameWithType>

- <xref:System.Transactions.TransactionInterop.GetDtcTransaction%2A?displayProperty=nameWithType>

- <xref:System.Transactions.TransactionInterop.GetExportCookie%2A?displayProperty=nameWithType>

- <xref:System.Transactions.TransactionInterop.GetTransmitterPropagationToken%2A?displayProperty=nameWithType>

 Once a non-MSDTC transaction promoter is enlisted, it must be used for future durable enlistments by using protocols that it defines. The <xref:System.Guid> of the transaction promoter can be obtained by using the <xref:System.Transactions.Transaction.PromoterType%2A> property. When the transaction promotes, the transaction promoter provides a <xref:System.Byte> array that represents the promoted token. An application can obtain the promoted token for a non-MSDTC promoted transaction with the <xref:System.Transactions.Transaction.GetPromotedToken%2A> method.

 Users of the new <xref:System.Transactions.Transaction.EnlistPromotableSinglePhase%28System.Transactions.IPromotableSinglePhaseNotification%2CSystem.Guid%29?displayProperty=nameWithType> overload must follow a specific call sequence in order for the promotion operation to complete successfully. These rules are documented in the method's documentation.

<a name="Profile461"></a> 
### Profiling
 The unmanaged profiling API has been enhanced follows:

 Better support for accessing PDBs in the [ICorProfilerInfo7](../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo7-interface.md) interface
 In ASP.Net 5, it is becoming much more common for assemblies to be compiled in-memory by Roslyn. For developers making profiling tools, this means that PDBs that historically were serialized on disk may no longer be present. Profiler tools often use PDBs to map code back to source lines for tasks such as code coverage or line-by-line performance analysis. The [ICorProfilerInfo7](../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo7-interface.md) interface now includes two new methods, [ICorProfilerInfo7::GetInMemorySymbolsLength](../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo7-getinmemorysymbolslength-method.md) and [ICorProfilerInfo7::ReadInMemorySymbols](../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo7-readinmemorysymbols.md), to provide these profiler tools with access to the in-memory PDB data, By using the new APIs, a profiler can obtain the contents of an in-memory PDB as a byte array and then process it or serialize it to disk.

 Better instrumentation with the ICorProfiler interface
 Profilers that are using the `ICorProfiler` API’s ReJit functionality for dynamic instrumentation can now modify some metadata. Previously such tools could instrument IL at any time, but metadata could only be modified at module load time. Because IL refers to metadata, this limited the kinds of instrumentation that could be done. We have lifted some of those limits by adding the [ICorProfilerInfo7::ApplyMetaData](../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo7-applymetadata-method.md) method to support a subset of metadata edits after the module loads, in particular by adding new `AssemblyRef`, `TypeRef`, `TypeSpec`, `MemberRef`, `MemberSpec`, and `UserString` records. This change makes a much broader range of on-the-fly instrumentation possible.

<a name="NGEN461"></a> 
### Native Image Generator (NGEN) PDBs
 Cross-machine event tracing allows customers to profile a program on Machine A and look at the profiling data with source line mapping on Machine B. Using previous versions of the .NET Framework, the user would copy all the modules and native images from the profiled machine to the analysis machine that contains the IL PDB to create the source-to-native mapping. While this process may work well when the files are relatively small, such as for phone applications, the files can be very large on desktop systems and require significant time to copy.

 With Ngen PDBs, NGen can create a PDB that contains the IL-to-native mapping without a dependency on the IL PDB. In our cross-machine event tracing scenario, all that is needed is to copy the native image PDB that is generated by Machine A to Machine B and to use [Debug Interface Access APIs](/visualstudio/debugger/debug-interface-access/debug-interface-access-sdk-reference) to read the IL PDB's source-to-IL mapping and the native image PDB's IL-to-native mapping. Combining both mappings provides a source-to-native mapping. Since the native image PDB is much smaller than all the modules and native images, the process of copying from Machine A to Machine B is much faster.

<a name="v46"></a> 
## What's new in .NET 2015
 .NET 2015 introduces the [!INCLUDE[net_v46](../../../includes/net-v46-md.md)] and .NET Core. Some new features apply to both, and other features are specific to [!INCLUDE[net_v46](../../../includes/net-v46-md.md)] or [!INCLUDE[net_core](../../../includes/net-core-md.md)].

- **ASP.NET 5**

     .NET 2015 includes ASP.NET 5, which is a lean .NET implementation for building modern cloud-based apps. ASP.NET 5 is modular so you can include only those features that are needed in your application. It can be hosted on IIS or self-hosted in a custom process, and you can run apps with different versions of the .NET Framework on the same server. It includes a new environment configuration system that is designed for cloud deployment.

     MVC, Web API, and Web Pages are unified into a single framework called MVC 6. You build ASP.NET 5 apps through the new tools in Visual Studio 2015. Your existing applications will work on the new .NET Framework; however to build an app that uses MVC 6 or SignalR 3, you must use the project system in Visual Studio 2015.

     For information, see [ASP.NET 5](http://go.microsoft.com/fwlink/?LinkId=518238).

- **ASP.NET Updates**

    - **Task-based API for Asynchronous Response Flushing**

         ASP.NET now provides a simple task-based API for asynchronous response flushing, <xref:System.Web.HttpResponse.FlushAsync%2A?displayProperty=nameWithType>, that allows responses to be flushed asynchronously by using your language's `async/await` support.

    - `Model binding supports task-returning methods`

         In the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)], ASP.NET added the Model Binding feature that enabled an extensible, code-focused approach to CRUD-based data operations in Web Forms pages and user controls. The Model Binding system now supports <xref:System.Threading.Tasks.Task>-returning model binding methods. This feature allows Web Forms developers to get the scalability benefits of async with the ease of the data-binding system when using newer versions of ORMs, including the Entity Framework.

         Async model binding is controlled by the `aspnet:EnableAsyncModelBinding` configuration setting.

        ```xml
        <appSettings>
           <add key=" aspnet:EnableAsyncModelBinding" value="true|false" />
        </appSettings>
        ```

         On apps the target the [!INCLUDE[net_v46](../../../includes/net-v46-md.md)], it defaults to `true`. On apps running on the [!INCLUDE[net_v46](../../../includes/net-v46-md.md)] that target an earlier version of the .NET Framework, it is `false` by default. It can be enabled by setting the configuration setting to `true`.

    - **HTTP/2 Support (Windows 10)**

         [HTTP/2](http://www.wikipedia.org/wiki/HTTP/2) is a new version of the HTTP protocol that provides much better connection utilization (fewer round-trips between client and server), resulting in lower latency web page loading for users.  Web pages (as opposed to services) benefit the most from HTTP/2, since the protocol optimizes for multiple artifacts being requested as part of a single experience. HTTP/2 support has been added to ASP.NET in the .NET Framework 4.6. Because networking functionality exists at multiple layers, new features were required in Windows, in IIS, and in ASP.NET to enable HTTP/2. You must be running on Windows 10 to use HTTP/2 with ASP.NET.

         HTTP/2 is also supported and on by default for Windows 10 Universal Windows Platform (UWP) apps that use the <xref:System.Net.Http.HttpClient?displayProperty=nameWithType> API.

         In order to provide a way to use the [PUSH_PROMISE](http://http2.github.io/http2-spec/#PUSH_PROMISE) feature in ASP.NET applications, a new method with two overloads, <xref:System.Web.HttpResponse.PushPromise%28System.String%29> and <xref:System.Web.HttpResponse.PushPromise%28System.String%2CSystem.String%2CSystem.Collections.Specialized.NameValueCollection%29>, has been added to the <xref:System.Web.HttpResponse> class.

        > [!NOTE]
        >  While ASP.NET 5 supports HTTP/2, support for the PUSH PROMISE feature has not yet been added.

         The browser and the web server (IIS on Windows) do all the work. You don't have to do any heavy-lifting for your users.

         Most of the [major browsers support HTTP/2](http://www.wikipedia.org/wiki/HTTP/2), so it's likely that your users will benefit from HTTP/2 support if your server supports it.

    - **Support for the Token Binding Protocol**

         Microsoft and Google have been collaborating on a new approach to authentication, called the [Token Binding Protocol](https://github.com/TokenBinding/Internet-Drafts). The premise is that authentication tokens (in your browser cache) can be stolen and used by criminals to access otherwise secure resources (e.g. your bank account) without requiring your password or any other privileged knowledge. The new protocol aims to mitigate this problem.

         The Token Binding Protocol will be implemented in Windows 10 as a browser feature. ASP.NET apps will participate in the protocol, so that authentication tokens are validated to be legitimate. The client and the server implementations establish the end-to-end protection specified by the protocol.

    - **Randomized string hash algorithms**

         The .NET Framework 4.5 introduced a [randomized string hash algorithm](../configure-apps/file-schema/runtime/userandomizedstringhashalgorithm-element.md). However, it was not supported by ASP.NET because of some ASP.NET features depended on a stable hash code. In [!INCLUDE[net_v46](../../../includes/net-v46-md.md)], randomized string hash algorithms are now supported. To enable this feature, use the `aspnet:UseRandomizedStringHashAlgorithm` config setting.

        ```xml
        <appSettings>
           <add key="aspnet:UseRandomizedStringHashAlgorithm" value="true|false" />
        </appSettings>
        ```

- **ADO.NET**

     ADO .NET now supports the Always Encrypted feature available in SQL Server 2016 Community Technology Preview 2 (CTP2). With Always Encrypted, SQL Server can perform operations on encrypted data, and best of all the encryption key resides with the application inside the customer’s trusted environment and not on the server. Always Encrypted secures customer data so DBAs do not have access to plain text data. Encryption and decryption of data happens transparently at the driver level, minimizing changes that have to be made to existing applications. For details, see [Always Encrypted (Database Engine)](/sql/relational-databases/security/encryption/always-encrypted-database-engine) and [Always Encrypted (client development)](/sql/relational-databases/security/encryption/always-encrypted-client-development).

- **64-bit JIT Compiler for managed code**

     The .NET Framework 4.6 features a new version of the 64-bit JIT compiler (originally code-named RyuJIT). The new 64-bit compiler provides significant performance improvements over the older 64-bit JIT compiler. The new 64-bit compiler is enabled for 64-bit processes running on top of the .NET Framework 4.6. Your app will run in a 64-bit process if it is compiled as 64-bit or AnyCPU and is running on a 64-bit operating system. While care has been taken to make the transition to the new compiler as transparent as possible, changes in behavior are possible. We would like to hear directly about any issues encountered when using the new JIT compiler. Please contact us through [Microsoft Connect](http://connect.microsoft.com/) if you encounter an issue that may be related to the new 64-bit JIT compiler.

     The new 64-bit JIT compiler also includes hardware SIMD acceleration features when coupled with SIMD-enabled types in the <xref:System.Numerics> namespace, which can yield good performance improvements.

- **Assembly loader improvements**

     The assembly loader now uses memory more efficiently by unloading IL assemblies after a corresponding NGEN image is loaded. This change decreases virtual memory, which is particularly beneficial for large 32-bit apps (such as Visual Studio), and also saves physical memory.

- **Base class library changes**

     Many new APIs have been added around to [!INCLUDE[net_v46](../../../includes/net-v46-md.md)] to enable key scenarios. These include the following changes and additions:

    - **IReadOnlyCollection\<T> implementations**

         Additional collections implement <xref:System.Collections.Generic.IReadOnlyCollection%601> such as <xref:System.Collections.Generic.Queue%601> and <xref:System.Collections.Generic.Stack%601>.

    - **CultureInfo.CurrentCulture and CultureInfo.CurrentUICulture**

         The <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=nameWithType> and <xref:System.Globalization.CultureInfo.CurrentUICulture%2A?displayProperty=nameWithType> properties are now read-write rather than read-only. If you assign a new <xref:System.Globalization.CultureInfo> object to these properties, the current thread culture defined by the `Thread.CurrentThread.CurrentCulture` property and the current UI thread culture defined by the `Thread.CurrentThread.CurrentUICulture` properties also change.

    - **Enhancements to garbage collection (GC)**

         The <xref:System.GC> class now includes <xref:System.GC.TryStartNoGCRegion%2A> and <xref:System.GC.EndNoGCRegion%2A> methods that allow you to disallow garbage collection during the execution of a critical path.

         A new overload of the <xref:System.GC.Collect%28System.Int32%2CSystem.GCCollectionMode%2CSystem.Boolean%2CSystem.Boolean%29?displayProperty=nameWithType> method allows you to control whether both the small object heap and the large object heap are swept and compacted or swept only.

    - **SIMD-enabled types**

         The <xref:System.Numerics> namespace now includes a number of SIMD-enabled types, such as <xref:System.Numerics.Matrix3x2>, <xref:System.Numerics.Matrix4x4>, <xref:System.Numerics.Plane>, <xref:System.Numerics.Quaternion>, <xref:System.Numerics.Vector2>, <xref:System.Numerics.Vector3>, and <xref:System.Numerics.Vector4>.

         Because the new 64-bit JIT compiler also includes hardware SIMD acceleration features, there are especially significant performance improvements when using the SIMD-enabled types with the new 64-bit JIT compiler.

    - **Cryptography updates**

         The <xref:System.Security.Cryptography?displayProperty=nameWithType> API is being updated to support the [Windows CNG cryptography APIs](https://msdn.microsoft.com/library/windows/desktop/aa376214.aspx). Previous versions of the .NET Framework have relied entirely on an [earlier version of the Windows Cryptography APIs](https://msdn.microsoft.com/library/windows/desktop/aa380255.aspx) as the basis for the <xref:System.Security.Cryptography?displayProperty=nameWithType> implementation. We have had requests to support the CNG API, since it supports [modern cryptography algorithms](https://msdn.microsoft.com/library/windows/desktop/bb204775.aspx#suite_b_support), which are important for certain categories of apps.

         The .NET Framework 4.6 includes the following new enhancements to support the Windows CNG cryptography APIs:

        - A set of extension methods for X509 Certificates, `System.Security.Cryptography.X509Certificates.RSACertificateExtensions.GetRSAPublicKey(System.Security.Cryptography.X509Certificates.X509Certificate2)` and `System.Security.Cryptography.X509Certificates.RSACertificateExtensions.GetRSAPrivateKey(System.Security.Cryptography.X509Certificates.X509Certificate2)`, that return a CNG-based implementation rather than a CAPI-based implementation when possible. (Some smartcards, etc., still require CAPI, and the APIs handle the fallback).

        - The <xref:System.Security.Cryptography.RSACng?displayProperty=nameWithType> class, which provides a CNG implementation of the RSA algorithm.

        - Enhancements to the RSA API so that common actions no longer require casting. For example, encrypting data using an <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> object requires code like the following in previous versions of the .NET Framework.

             [!code-csharp[WhatsNew.Casting#1](../../../samples/snippets/csharp/VS_Snippets_CLR/whatsnew.casting/cs/program.cs#1)]
             [!code-vb[WhatsNew.Casting#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/whatsnew.casting/vb/module1.vb#1)]

             Code that uses the new cryptography APIs in the .NET Framework 4.6 can be rewritten as follows to avoid the cast.

             [!code-csharp[WhatsNew.Casting#2](../../../samples/snippets/csharp/VS_Snippets_CLR/whatsnew.casting/cs/program.cs#2)]
             [!code-vb[WhatsNew.Casting#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/whatsnew.casting/vb/module1.vb#2)]

    - **Support for converting dates and times to or from Unix time**

         The following new methods have been added to the <xref:System.DateTimeOffset> structure to support converting date and time values to or from Unix time:

        - <xref:System.DateTimeOffset.FromUnixTimeSeconds%2A?displayProperty=nameWithType>

        - <xref:System.DateTimeOffset.FromUnixTimeMilliseconds%2A?displayProperty=nameWithType>

        - <xref:System.DateTimeOffset.ToUnixTimeSeconds%2A?displayProperty=nameWithType>

        - <xref:System.DateTimeOffset.ToUnixTimeMilliseconds%2A?displayProperty=nameWithType>

    - **Compatibility switches**

         The new <xref:System.AppContext> class adds a new compatibility feature that enables library writers to provide a uniform opt-out mechanism for new functionality for their users. It establishes a loosely-coupled contract between components in order to communicate an opt-out request. This capability is typically important when a change is made to existing functionality. Conversely, there is already an implicit opt-in for new functionality.

         With <xref:System.AppContext>, libraries define and expose compatibility switches, while code that depends on them can set those switches to affect the library behavior. By default, libraries provide the new functionality, and they only alter it (that is, they provide the previous functionality) if the switch is set.

         An application (or a library) can declare the value of a switch (which is always a <xref:System.Boolean> value) that a dependent library defines. The switch is always implicitly `false`. Setting the switch to `true` enables it. Explicitly setting the switch to `false` provides the new behavior.

        ```csharp
        AppContext.SetSwitch("Switch.AmazingLib.ThrowOnException", true);
        ```

         The library must check if a consumer has declared the value of the switch and then appropriately act on it.

        ```csharp
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

        - *Switch*.*namespace*.*switchname*

        - *Switch*.*library*.*switchname*

    - **Changes to the task-based asynchronous pattern (TAP)**

         For apps that target the [!INCLUDE[net_v46](../../../includes/net-v46-md.md)], <xref:System.Threading.Tasks.Task> and <xref:System.Threading.Tasks.Task%601> objects inherit the culture and UI culture of the calling thread. The behavior of apps that target previous versions of the .NET Framework, or that do not target a specific version of the .NET Framework, is unaffected. For more information, see the "Culture and task-based asynchronous operations" section of the <xref:System.Globalization.CultureInfo> class topic.

         The <xref:System.Threading.AsyncLocal%601?displayProperty=nameWithType> class allows you to represent ambient data that is local to a given asynchronous control flow, such as an `async` method. It can be used to persist data across threads. You can also define a callback method that is notified whenever the ambient data changes either because the <xref:System.Threading.AsyncLocal%601.Value%2A?displayProperty=nameWithType> property was explicitly changed, or because the thread encountered a context transition.

         Three convenience methods, <xref:System.Threading.Tasks.Task.CompletedTask%2A?displayProperty=nameWithType>, <xref:System.Threading.Tasks.Task.FromCanceled%2A?displayProperty=nameWithType>, and <xref:System.Threading.Tasks.Task.FromException%2A?displayProperty=nameWithType>, have been added to the task-based asynchronous pattern (TAP) to return completed tasks in a particular state.

         The <xref:System.IO.Pipes.NamedPipeClientStream> class now supports asynchronous communication with its new <xref:System.IO.Pipes.NamedPipeClientStream.ConnectAsync%2A>. method.

    - **EventSource now supports writing to the Event log**

         You now can use the <xref:System.Diagnostics.Tracing.EventSource> class to log administrative or operational messages to the event log, in addition to any existing ETW sessions created on the machine. In the past, you had to use the Microsoft.Diagnostics.Tracing.EventSource NuGet package for this functionality. This functionality is now built-into the .NET Framework 4.6.

         Both the NuGet package and the .NET Framework 4.6 have been updated with the following features:

        - **Dynamic events**

             Allows events defined "on the fly" without creating event methods.

        - **Rich payloads**

             Allows specially attributed classes and arrays as well as primitive types to be passed as a payload

        - **Activity tracking**

             Causes Start and Stop events to tag events between them with an ID that represents all currently active activities.

         To support these features, the overloaded <xref:System.Diagnostics.Tracing.EventSource.Write%2A> method has been added to the <xref:System.Diagnostics.Tracing.EventSource> class.

- **Windows Presentation Foundation (WPF)**

    - **HDPI improvements**

         HDPI support in WPF is now better in the [!INCLUDE[net_v46](../../../includes/net-v46-md.md)]. Changes have been made to layout rounding to reduce instances of clipping in controls with borders. By default, this feature is enabled only if your <xref:System.Runtime.Versioning.TargetFrameworkAttribute> is set to .NET 4.6.  Applications that target earlier versions of the framework but are running on the [!INCLUDE[net_v46](../../../includes/net-v46-md.md)] can opt in to the new behavior by adding the following line to the [\<runtime>](../../../docs/framework/configure-apps/file-schema/runtime/runtime-element.md) section of the app.config file:

        ```xml
        <AppContextSwitchOverrides
        value="Switch.MS.Internal.DoNotApplyLayoutRoundingToMarginsAndBorderThickness=false"
        />
        ```

         WPF windows straddling multiple monitors with different DPI settings (Multi-DPI setup) are now completely rendered without blacked-out regions. You can opt out of this behavior by adding the following line to the `<appSettings>` section of the app.config file to disable this new behavior:

        ```xml
        <add key="EnableMultiMonitorDisplayClipping" value="true"/>
        ```

         Support for automatically loading the right cursor based on DPI setting has been added to  <xref:System.Windows.Input.Cursor?displayProperty=nameWithType>.

    - **Touch is better**

         Customer reports on [Connect](https://connect.microsoft.com/VisualStudio/feedback/details/903760/) that touch produces unpredictable behavior have been addressed in the [!INCLUDE[net_v46](../../../includes/net-v46-md.md)]. The double tap threshold for Windows Store applications and WPF applications is now the same in Windows 8.1 and above.

    - **Transparent child window support**

         WPF in the [!INCLUDE[net_v46](../../../includes/net-v46-md.md)] supports transparent child windows in Windows 8.1 and above. This allows you to create non-rectangular and transparent child windows in your top-level windows. You can enable this feature by setting the <xref:System.Windows.Interop.HwndSourceParameters.UsesPerPixelTransparency%2A?displayProperty=nameWithType> property to `true`.

- **Windows Communication Foundation (WCF)**

    - **SSL support**

         WCF now supports SSL version TLS 1.1 and TLS 1.2, in addition to SSL 3.0 and TLS 1.0, when using NetTcp with transport security and client authentication. It is now possible to select which protocol to use, or to disable old lesser secure protocols. This can be done either by setting the <xref:System.ServiceModel.TcpTransportSecurity.SslProtocols%2A> property or by adding the following to a configuration file.

        ```xml
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

    - **Sending messages using different HTTP connections**

         WCF now allows users to ensure certain messages are sent using different underlying HTTP connections. There are two ways to do this:

        - **Using a connection group name prefix**

             Users can specify a string that WCF will use as a prefix for the connection group name. Two messages with different prefixes are sent using different underlying HTTP connections. You set the prefix by adding a key/value pair to the message's <xref:System.ServiceModel.Channels.Message.Properties%2A?displayProperty=nameWithType> property. The key is "HttpTransportConnectionGroupNamePrefix"; the value is the desired prefix.

        - **Using different channel factories**

             Users can also enable a feature that ensures that messages sent using channels created by different channel factories will use different underlying HTTP connections. To enable this feature, users must set the following `appSetting` to `true`:

            ```xml
            <appSettings>
               <add key="wcf:httpTransportBinding:useUniqueConnectionPoolPerFactory" value="true" />
            </appSettings>
            ```

- **Windows Workflow Foundation (WWF)**

     You can now specify the number of seconds a workflow service will hold on to an out-of-order operation request when there is an outstanding "non-protocol" bookmark before timing out the request. A "non-protocol" bookmark is a bookmark that is not related to outstanding Receive activities. Some activities create non-protocol bookmarks within their implementation, so it may not be obvious that a non-protocol bookmark exists. These include State and Pick. So if you have a workflow service implemented with a state machine or containing a Pick activity, you will most likely have non-protocol bookmarks. You specify the interval by adding a line like the following to the `appSettings` section of your app.config file:

    ```xml
    <add key="microsoft:WorkflowServices:FilterResumeTimeoutInSeconds" value="60"/>
    ```

     The default value is 60 seconds. If `value` is set to 0, out-of-order requests are immediately rejected with a fault with text that looks like this:

    ```
    Operation 'Request3|{http://tempuri.org/}IService' on service instance with identifier '2b0667b6-09c8-4093-9d02-f6c67d534292' cannot be performed at this time. Please ensure that the operations are performed in the correct order and that the binding in use provides ordered delivery guarantees. 
    ```

     This is the same message that you receive if an out-of-order operation message is received and there are no non-protocol bookmarks.

     If the value of the `FilterResumeTimeoutInSeconds` element is non-zero, there are non-protocol bookmarks, and the timeout interval expires, the operation fails with a timeout message.

- **Transactions**

     You can now include the distributed transaction identifier for the transaction that has caused an exception derived from <xref:System.Transactions.TransactionException> to be thrown. You do this by adding the following key to the `appSettings` section of your app.config file:

    ```xml
    <add key="Transactions:IncludeDistributedTransactionIdInExceptionMessage" value="true"/> 
    ```

     The default value is `false`.

- **Networking**

    - **Socket reuse**

         Windows 10 includes a new high-scalability networking algorithm that makes better use of machine resources by reusing local ports for outbound TCP connections. The .NET Framework 4.6 supports the new algorithm, enabling .NET apps to take advantage of the new behavior. In previous versions of Windows, there was an artificial concurrent connection limit (typically 16,384, the default size of the dynamic port range), which could limit the scalability of a service by causing port exhaustion when under load.

         In the [!INCLUDE[net_v46](../../../includes/net-v46-md.md)], two new APIs have been added to enable port reuse, which effectively removes the 64K limit on concurrent connections:

        - The <xref:System.Net.Sockets.SocketOptionName?displayProperty=nameWithType> enumeration value.

        - The <xref:System.Net.ServicePointManager.ReusePort%2A?displayProperty=nameWithType> property.

         By default, the <xref:System.Net.ServicePointManager.ReusePort%2A?displayProperty=nameWithType> property is `false` unless the `HWRPortReuseOnSocketBind` value of the `HKLM\SOFTWARE\Microsoft\.NETFramework\v4.0.30319` registry key is set to 0x1. To enable local port reuse on HTTP connections, set the <xref:System.Net.ServicePointManager.ReusePort%2A?displayProperty=nameWithType> property to `true`. This causes all outgoing TCP socket connections from <xref:System.Net.Http.HttpClient> and <xref:System.Net.HttpWebRequest> to use a new Windows 10 socket option, [SO_REUSE_UNICASTPORT](https://msdn.microsoft.com/library/windows/desktop/ms740532.aspx), that enables local port reuse.

         Developers writing a sockets-only application can specify the <xref:System.Net.Sockets.SocketOptionName?displayProperty=nameWithType> option when calling a method such as <xref:System.Net.Sockets.Socket.SetSocketOption%2A?displayProperty=nameWithType> so that outbound sockets reuse local ports during binding.

    - **Support for international domain names and PunyCode**

         A new property, <xref:System.Uri.IdnHost%2A>, has been added to the <xref:System.Uri> class to better support international domain names and PunyCode.

- **Resizing in Windows Forms controls.**

     This feature has been expanded in [!INCLUDE[net_v46](../../../includes/net-v46-md.md)] to include the <xref:System.Windows.Forms.DomainUpDown>, <xref:System.Windows.Forms.NumericUpDown>, <xref:System.Windows.Forms.DataGridViewComboBoxColumn>, <xref:System.Windows.Forms.DataGridViewColumn> and <xref:System.Windows.Forms.ToolStripSplitButton> types and the rectangle specified by the <xref:System.Drawing.Design.PaintValueEventArgs.Bounds%2A> property used when drawing a <xref:System.Drawing.Design.UITypeEditor>.

     This is an opt-in feature. To enable it, set the `EnableWindowsFormsHighDpiAutoResizing` element to `true` in the application configuration (app.config) file:

    ```xml
    <appSettings>
       <add key="EnableWindowsFormsHighDpiAutoResizing" value="true" />
    </appSettings>
    ```

- **Support for code page encodings**

      [!INCLUDE[net_core](../../../includes/net-core-md.md)] primarily supports the Unicode encodings and by default provides limited support for code page encodings. You can add support for code page encodings available in the .NET Framework but unsupported in [!INCLUDE[net_core](../../../includes/net-core-md.md)] by registering code page encodings with the <xref:System.Text.Encoding.RegisterProvider%2A?displayProperty=nameWithType> method. For more information, see <xref:System.Text.CodePagesEncodingProvider?displayProperty=nameWithType>.

- **.NET Native**

     Windows apps for Windows 10 that target [!INCLUDE[net_core](../../../includes/net-core-md.md)] and are written in C# or Visual Basic can take advantage of a new technology that compiles apps to native code rather than IL. They produce apps characterized by faster startup and execution times. For more information, see [Compiling Apps with .NET Native](../../../docs/framework/net-native/index.md). For an overview of .NET Native that examines how it differs from both JIT compilation and NGEN and what that means for your code, see [.NET Native and Compilation](../../../docs/framework/net-native/net-native-and-compilation.md).

     Your apps are compiled to native code by default when you compile them with Visual Studio 2015. For more information, see [Getting Started with .NET Native](../../../docs/framework/net-native/getting-started-with-net-native.md).

     To support debugging .NET Native apps, a number of new interfaces and enumerations have been added to the unmanaged debugging API. For more information, see the [Debugging (Unmanaged API Reference)](../../../docs/framework/unmanaged-api/debugging/index.md) topic.

- **Open-source .NET Framework packages**

      [!INCLUDE[net_core](../../../includes/net-core-md.md)] packages such as the immutable collections, [SIMD APIs](http://go.microsoft.com/fwlink/?LinkID=518639), and networking APIs such as those found in the <xref:System.Net.Http> namespace are now available as open source packages on [GitHub](https://github.com/). To access the code, see [NetFx on GitHub](http://go.microsoft.com/fwlink/?LinkID=518634). For more information and how to contribute to these packages, see [.NET Core and Open-Source](../../../docs/framework/get-started/net-core-and-open-source.md), [.NET Home Page on GitHub](http://go.microsoft.com/fwlink/?LinkID=518635).

 [Back to top](#introduction)

<a name="v452"></a> 
## What's new in the .NET Framework 4.5.2

- **New APIs for ASP.NET apps.** The new <xref:System.Web.HttpResponse.AddOnSendingHeaders%2A?displayProperty=nameWithType> and <xref:System.Web.HttpResponseBase.AddOnSendingHeaders%2A?displayProperty=nameWithType> methods let you inspect and modify response headers and status code as the response is being flushed to the client app. Consider using these methods instead of the <xref:System.Web.HttpApplication.PreSendRequestHeaders> and <xref:System.Web.HttpApplication.PreSendRequestContent> events; they are more efficient and reliable.

     The <xref:System.Web.Hosting.HostingEnvironment.QueueBackgroundWorkItem%2A?displayProperty=nameWithType> method lets you schedule small background work items. ASP.NET tracks these items and prevents IIS from abruptly terminating the worker process until all background work items have completed. This method can't be called outside an ASP.NET managed app domain.

     The new <xref:System.Web.HttpResponse.HeadersWritten?displayProperty=nameWithType> and <xref:System.Web.HttpResponseBase.HeadersWritten?displayProperty=nameWithType> properties return Boolean values that indicate whether the response headers have been written. You can use these properties to make sure that calls to APIs such as <xref:System.Web.HttpResponse.StatusCode%2A?displayProperty=nameWithType> (which throw exceptions if the headers have been written) will succeed.

- **Resizing in Windows Forms controls.** This feature has been expanded. You can now use the system DPI setting to resize components of the following additional controls (for example, the drop-down arrow in combo boxes):

     <xref:System.Windows.Forms.ComboBox> 
     <xref:System.Windows.Forms.ToolStripComboBox> 
     <xref:System.Windows.Forms.ToolStripMenuItem> 
     <xref:System.Windows.Forms.Cursor> 
     <xref:System.Windows.Forms.DataGridView> 
     <xref:System.Windows.Forms.DataGridViewComboBoxColumn>

     This is an opt-in feature. To enable it, set the `EnableWindowsFormsHighDpiAutoResizing` element to `true` in the application configuration (app.config) file:

    ```xml
    <appSettings>
       <add key="EnableWindowsFormsHighDpiAutoResizing" value="true" />
    </appSettings>
    ```

- **New workflow feature.** A resource manager that's using the <xref:System.Transactions.Transaction.EnlistPromotableSinglePhase%2A> method (and therefore implementing the <xref:System.Transactions.IPromotableSinglePhaseNotification> interface) can use the new <xref:System.Transactions.Transaction.PromoteAndEnlistDurable%2A?displayProperty=nameWithType> method to request the following:

    - Promote the transaction to a Microsoft Distributed Transaction Coordinator (MSDTC) transaction.

    - Replace <xref:System.Transactions.IPromotableSinglePhaseNotification> with an <xref:System.Transactions.ISinglePhaseNotification>, which is a durable enlistment that supports single phase commits.

     This can be done within the same app domain, and doesn't require any extra unmanaged code to interact with MSDTC to perform the promotion. The new method can be called only when there's an outstanding call from <xref:System.Transactions?displayProperty=nameWithType> to the <xref:System.Transactions.IPromotableSinglePhaseNotification>`Promote` method that's implemented by the promotable enlistment.

- **Profiling improvements.** The following new unmanaged profiling APIs provide more robust profiling:

     [COR_PRF_ASSEMBLY_REFERENCE_INFO Structure](../../../docs/framework/unmanaged-api/profiling/cor-prf-assembly-reference-info-structure.md) 
     [COR_PRF_HIGH_MONITOR Enumeration](../../../docs/framework/unmanaged-api/profiling/cor-prf-high-monitor-enumeration.md) 
     [GetAssemblyReferences Method](../../../docs/framework/unmanaged-api/profiling/icorprofilercallback6-getassemblyreferences-method.md) 
     [GetEventMask2 Method](../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo5-geteventmask2-method.md) 
     [SetEventMask2 Method](../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo5-seteventmask2-method.md) 
     [AddAssemblyReference Method](../../../docs/framework/unmanaged-api/profiling/icorprofilerassemblyreferenceprovider-addassemblyreference-method.md)

     Previous `ICorProfiler` implementations supported lazy loading of dependent assemblies. The new profiling APIs require dependent assemblies that are injected by the profiler to be loadable immediately, instead of being loaded after the app is fully initialized. This change doesn't affect users of the existing `ICorProfiler` APIs.

- **Debugging improvements.** The following new unmanaged debugging APIs provide better integration with a profiler. You can now access metadata inserted by the profiler as well as local variables and code produced by compiler ReJIT requests when dump debugging.

     [SetWriteableMetadataUpdateMode Method](../../../docs/framework/unmanaged-api/debugging/icordebugprocess7-setwriteablemetadataupdatemode-method.md) 
     [EnumerateLocalVariablesEx Method](../../../docs/framework/unmanaged-api/debugging/icordebugilframe4-enumeratelocalvariablesex-method.md) 
     [GetLocalVariableEx Method](../../../docs/framework/unmanaged-api/debugging/icordebugilframe4-getlocalvariableex-method.md) 
     [GetCodeEx Method](../../../docs/framework/unmanaged-api/debugging/icordebugilframe4-getcodeex-method.md) 
     [GetActiveReJitRequestILCode Method](../../../docs/framework/unmanaged-api/debugging/icordebugfunction3-getactiverejitrequestilcode-method.md) 
     [GetInstrumentedILMap Method](../../../docs/framework/unmanaged-api/debugging/icordebugilcode2-getinstrumentedilmap-method.md)

- **Event tracing changes.** The .NET Framework 4.5.2 enables out-of-process, Event Tracing for Windows (ETW)-based activity tracing for a larger surface area. This enables Advanced Power Management (APM) vendors to provide lightweight tools that accurately track the costs of individual requests and activities that cross threads.  These events are raised only when ETW controllers enable them; therefore, the changes don't affect previously written ETW code or code that runs with ETW disabled.

- **Promoting a transaction and converting it to a durable enlistment**

     <xref:System.Transactions.Transaction.PromoteAndEnlistDurable%2A?displayProperty=nameWithType> is a new API added to the .NET Framework 4.5.2 and 4.6:

    ```csharp
    [System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
    public Enlistment PromoteAndEnlistDurable(Guid resourceManagerIdentifier,
                                              IPromotableSinglePhaseNotification promotableNotification,
                                              ISinglePhaseNotification enlistmentNotification,
                                              EnlistmentOptions enlistmentOptions)
    ```

     The method may be used by an enlistment that was previously created by <xref:System.Transactions.Transaction.EnlistPromotableSinglePhase%2A?displayProperty=nameWithType> in response to the <xref:System.Transactions.ITransactionPromoter.Promote%2A?displayProperty=nameWithType> method. It asks `System.Transactions` to promote the transaction to an MSDTC transaction and to "convert" the promotable enlistment to a durable enlistment. After this method completes successfully, the <xref:System.Transactions.IPromotableSinglePhaseNotification> interface will no longer be referenced by `System.Transactions`, and any future notifications will arrive on the provided <xref:System.Transactions.ISinglePhaseNotification> interface. The enlistment in question must act as a durable enlistment, supporting transaction logging and recovery. Refer to <xref:System.Transactions.Transaction.EnlistDurable%2A?displayProperty=nameWithType> for details. In addition, the enlistment must support <xref:System.Transactions.ISinglePhaseNotification>.  This method can *only* be called while processing an <xref:System.Transactions.ITransactionPromoter.Promote%2A?displayProperty=nameWithType> call. If that is not the case, a <xref:System.Transactions.TransactionException> exception is thrown.

 [Back to top](#introduction)

<a name="v451"></a> 
## What's new in the .NET Framework 4.5.1
 **April 2014 updates**:

- [Visual Studio 2013 Update 2](http://go.microsoft.com/fwlink/p/?LinkId=393658) includes updates to the Portable Class Library templates to support these scenarios:

    - You can use Windows Runtime APIs in portable libraries that target Windows 8.1, Windows Phone 8.1, and Windows Phone Silverlight 8.1.

    - You can include XAML (Windows.UI.XAML types) in portable libraries when you target Windows 8.1 or Windows Phone 8.1. The following XAML templates are supported:  Blank Page, Resource Dictionary, Templated Control, and User Control.

    - You can create a portable Windows Runtime component (.winmd file) for use in Store apps that target Windows 8.1 and Windows Phone 8.1.

    - You can retarget a Windows Store or Windows Phone Store class library like a Portable Class Library.

     For more information about these changes, see [Portable Class Library](../../../docs/standard/cross-platform/cross-platform-development-with-the-portable-class-library.md).

- The .NET Framework content set now includes documentation for [!INCLUDE[net_native](../../../includes/net-native-md.md)], which is a precompilation technology for building and deploying Windows apps. [!INCLUDE[net_native](../../../includes/net-native-md.md)] compiles your apps directly to native code, rather than to intermediate language (IL), for better performance. For details, see [Compiling Apps with .NET Native](../../../docs/framework/net-native/index.md).

- The [.NET Framework Reference Source](http://referencesource.microsoft.com/) provides a new browsing experience and enhanced functionality. You can now browse through the .NET Framework source code online, [download the reference](http://referencesource.microsoft.com/download.html) for offline viewing, and step through the sources (including patches and updates) during debugging. For more information, see the blog entry [A new look for .NET Reference Source](https://blogs.msdn.microsoft.com/dotnet/2014/02/24/a-new-look-for-net-reference-source/).

 Core new features and enhancements in the .NET Framework 4.5.1 include:

- Automatic binding redirection for assemblies. Starting with [!INCLUDE[vs_dev12](../../../includes/vs-dev12-md.md)], when you compile an app that targets the [!INCLUDE[net_v451](../../../includes/net-v451-md.md)], binding redirects may be added to the app configuration file if your app or its components reference multiple versions of the same assembly. You can also enable this feature for projects that target older versions of the .NET Framework. For more information, see [How to: Enable and Disable Automatic Binding Redirection](../../../docs/framework/configure-apps/how-to-enable-and-disable-automatic-binding-redirection.md).

- Ability to collect diagnostics information to help developers improve the performance of server and cloud applications. For more information, see the <xref:System.Diagnostics.Tracing.EventSource.WriteEventWithRelatedActivityId%2A> and <xref:System.Diagnostics.Tracing.EventSource.WriteEventWithRelatedActivityIdCore%2A> methods in the <xref:System.Diagnostics.Tracing.EventSource> class.

- Ability to explicitly compact the large object heap (LOH) during garbage collection. For more information, see the <xref:System.Runtime.GCSettings.LargeObjectHeapCompactionMode%2A?displayProperty=nameWithType> property.

- Additional performance improvements such as ASP.NET app suspension, multi-core JIT improvements, and faster app startup after a .NET Framework update. For details, see the [.NET Framework 4.5.1 announcement](https://blogs.msdn.microsoft.com/dotnet/2013/06/26/announcing-the-net-framework-4-5-1-preview/) and the [ASP.NET app suspend](https://blogs.msdn.microsoft.com/dotnet/2013/10/09/asp-net-app-suspend-responsive-shared-net-web-hosting/) blog post.

 Improvements to Windows Forms include:

- Resizing in Windows Forms controls. You can use the system DPI setting to resize components of controls (for example, the icons that appear in a property grid) by opting in with an entry in the application configuration file (app.config) for your app. This feature is currently supported in the following Windows Forms controls:

     <xref:System.Windows.Forms.PropertyGrid> 
     <xref:System.Windows.Forms.TreeView> 
     Some aspects of the <xref:System.Windows.Forms.DataGridView> (see [new features in 4.5.2](#v452) for additional controls supported)

     To enable this feature, add a new \<appSettings> element to the configuration file (app.config) and set the `EnableWindowsFormsHighDpiAutoResizing` element to `true`:

    ```xml
    <appSettings>
       <add key="EnableWindowsFormsHighDpiAutoResizing" value="true" />
    </appSettings>
    ```

 Improvements when debugging your .NET Framework apps in [!INCLUDE[vs_dev12](../../../includes/vs-dev12-md.md)] include:

- Return values in the Visual Studio debugger. When you debug a managed app in [!INCLUDE[vs_dev12](../../../includes/vs-dev12-md.md)], the Autos window displays return types and values for methods. This information is available for desktop, Windows Store, and Windows Phone apps. For more information, see [Examine return values of method calls](http://msdn.microsoft.com/library/e3245b37-8e2e-4200-ba84-133726e95f1f\(v=vs.120\).aspx) in the MSDN Library.

- Edit and Continue for 64-bit apps. [!INCLUDE[vs_dev12](../../../includes/vs-dev12-md.md)] supports the Edit and Continue feature for 64-bit managed apps for desktop, Windows Store, and Windows Phone. The existing limitations remain in effect for both 32-bit and 64-bit apps (see the last section of the [Supported Code Changes (C#)](/visualstudio/debugger/supported-code-changes-csharp) article).

- Async-aware debugging. To make it easier to debug asynchronous apps in [!INCLUDE[vs_dev12](../../../includes/vs-dev12-md.md)], the call stack hides the infrastructure code provided by compilers to support asynchronous programming, and also chains in logical parent frames so you can follow logical program execution more clearly. A Tasks window replaces the Parallel Tasks window and displays tasks that relate to a particular breakpoint, and also displays any other tasks that are currently active or scheduled in the app. You can read about this feature in the "Async-aware debugging" section of the [.NET Framework 4.5.1 announcement](https://blogs.msdn.microsoft.com/dotnet/2013/06/26/announcing-the-net-framework-4-5-1-preview/).

- Better exception support for Windows Runtime components. In [!INCLUDE[win81](../../../includes/win81-md.md)], exceptions that arise from Windows Store apps preserve information about the error that caused the exception, even across language boundaries. You can read about this feature in the "Windows Store app development" section of the [.NET Framework 4.5.1 announcement](https://blogs.msdn.microsoft.com/dotnet/2013/06/26/announcing-the-net-framework-4-5-1-preview/). 

 Starting with [!INCLUDE[vs_dev12](../../../includes/vs-dev12-md.md)], you can use the [Managed Profile Guided Optimization Tool (Mpgo.exe)](../../../docs/framework/tools/mpgo-exe-managed-profile-guided-optimization-tool.md) to optimize [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps as well as desktop apps.

 For new features in ASP.NET 4.5.1, see [ASP.NET 4.5.1 and Visual Studio 2013](http://go.microsoft.com/fwlink/?LinkID=309094) on the ASP.NET site.

 [Back to top](#introduction)

<a name="v45"></a> 
## What's new in the .NET Framework 4.5

### Core new features and improvements

- Ability to reduce system restarts by detecting and closing .NET Framework 4 applications during deployment. See [Reducing System Restarts During .NET Framework 4.5 Installations](../../../docs/framework/deployment/reducing-system-restarts.md).

- Support for arrays that are larger than 2 gigabytes (GB) on 64-bit platforms. This feature can be enabled in the application configuration file. See the [\<gcAllowVeryLargeObjects> element](../../../docs/framework/configure-apps/file-schema/runtime/gcallowverylargeobjects-element.md), which also lists other restrictions on object size and array size.

- Better performance through background garbage collection for servers. When you use server garbage collection in the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)], background garbage collection is automatically enabled. See the Background Server Garbage Collection section of the [Fundamentals of Garbage Collection](../../../docs/standard/garbage-collection/fundamentals.md) topic.

- Background just-in-time (JIT) compilation, which is optionally available on multi-core processors to improve application performance. See <xref:System.Runtime.ProfileOptimization>.

- Ability to limit how long the regular expression engine will attempt to resolve a regular expression before it times out. See the <xref:System.Text.RegularExpressions.Regex.MatchTimeout%2A?displayProperty=nameWithType> property.

- Ability to define the default culture for an application domain. See the <xref:System.Globalization.CultureInfo> class.

- Console support for Unicode (UTF-16) encoding. See the <xref:System.Console> class.

- Support for versioning of cultural string ordering and comparison data. See the <xref:System.Globalization.SortVersion> class.

- Better performance when retrieving resources. See [Packaging and Deploying Resources](../../../docs/framework/resources/packaging-and-deploying-resources-in-desktop-apps.md).

- Zip compression improvements to reduce the size of a compressed file. See the <xref:System.IO.Compression?displayProperty=nameWithType> namespace.

- Ability to customize a reflection context to override default reflection behavior through the <xref:System.Reflection.Context.CustomReflectionContext> class.

- Support for the 2008 version of the Internationalized Domain Names in Applications (IDNA) standard when the <xref:System.Globalization.IdnMapping?displayProperty=nameWithType> class is used  on [!INCLUDE[win8](../../../includes/win8-md.md)].

- Delegation of string comparison to the operating system, which implements Unicode 6.0, when the .NET Framework is used on [!INCLUDE[win8](../../../includes/win8-md.md)]. When running on other platforms, the .NET Framework includes its own string comparison data, which implements Unicode 5.x. See the <xref:System.String> class and the Remarks section of the <xref:System.Globalization.SortVersion> class.

- Ability to compute the hash codes for strings on a per application domain basis. See [\<UseRandomizedStringHashAlgorithm> Element](../../../docs/framework/configure-apps/file-schema/runtime/userandomizedstringhashalgorithm-element.md).

- Type reflection support split between <xref:System.Type> and <xref:System.Reflection.TypeInfo> classes. See [Reflection in the .NET Framework for Windows Store Apps](../../../docs/framework/reflection-and-codedom/reflection-for-windows-store-apps.md).

### Managed Extensibility Framework (MEF)
 In the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)], the Managed Extensibility Framework (MEF) provides the following new features:

- Support for generic types.

- Convention-based programming model that enables you to create parts based on naming conventions rather than attributes.

- Multiple scopes.

- A subset of MEF that you can use when you create [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps. This subset is available as a [downloadable package](http://go.microsoft.com/fwlink/?LinkId=256238) from the NuGet Gallery. To install the package, open your project in Visual Studio, choose **Manage NuGet Packages** from the **Project** menu, and search online for the `Microsoft.Composition` package.

 For more information, see [Managed Extensibility Framework (MEF)](../../../docs/framework/mef/index.md).

### Asynchronous file operations
 In the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)], new asynchronous features were added to the C# and Visual Basic languages. These features add a task-based model for performing asynchronous operations. To use this new model, use the asynchronous methods in the I/O classes. See [Asynchronous File I/O](../../../docs/standard/io/asynchronous-file-i-o.md).

<a name="tools"></a> 
### Tools
 In the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)], Resource File Generator (Resgen.exe) enables you to create a .resw file for use in [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps from a .resources file embedded in a .NET Framework assembly. For more information, see [Resgen.exe (Resource File Generator)](../../../docs/framework/tools/resgen-exe-resource-file-generator.md).

 Managed Profile Guided Optimization (Mpgo.exe) enables you to improve application startup time, memory utilization (working set size), and throughput by optimizing native image assemblies. The command-line tool generates profile data for native image application assemblies. See [Mpgo.exe (Managed Profile Guided Optimization Tool)](../../../docs/framework/tools/mpgo-exe-managed-profile-guided-optimization-tool.md). Starting with [!INCLUDE[vs_dev12](../../../includes/vs-dev12-md.md)], you can use Mpgo.exe to optimize [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps as well as desktop apps.

<a name="parallel"></a> 
### Parallel computing
 The [!INCLUDE[net_v45](../../../includes/net-v45-md.md)] provides several new features and improvements for parallel computing. These include improved performance, increased control, improved support for asynchronous programming, a new dataflow library, and improved support for parallel debugging and performance analysis. See the entry [What’s New for Parallelism in .NET 4.5](http://go.microsoft.com/fwlink/?LinkId=235061) in the Parallel Programming with .NET blog.

<a name="web"></a> 
### Web
 ASP.NET 4.5 and 4.5.1 add model binding for Web Forms, WebSocket support, asynchronous handlers, performance enhancements, and many other features. For more information, see the following resources:

- [ASP.NET 4.5 and Visual Studio 2012](http://msdn.microsoft.com/library/ac9bb7f6-f094-4af7-bad0-acf49a5dbc55) in the MSDN Library.

- [ASP.NET 4.5.1 and Visual Studio 2013](http://go.microsoft.com/fwlink/?LinkID=309094) on the ASP.NET site.

<a name="networking"></a> 
### Networking
 The [!INCLUDE[net_v45](../../../includes/net-v45-md.md)] provides a new programming interface for HTTP applications. For more information, see the new <xref:System.Net.Http?displayProperty=nameWithType> and <xref:System.Net.Http.Headers?displayProperty=nameWithType> namespaces.

 Support is also included for a new programming interface for accepting and interacting with a WebSocket connection by using the existing <xref:System.Net.HttpListener> and related classes. For more information, see the new <xref:System.Net.WebSockets> namespace and the <xref:System.Net.HttpListener> class.

 In addition, the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)] includes the following networking improvements:

- RFC-compliant URI support. For more information, see <xref:System.Uri> and related classes.

- Support for Internationalized Domain Name (IDN) parsing. For more information, see <xref:System.Uri> and related classes.

- Support for Email Address Internationalization (EAI). For more information, see the <xref:System.Net.Mail> namespace.

- Improved IPv6 support. For more information, see the <xref:System.Net.NetworkInformation> namespace.

- Dual-mode socket support. For more information, see the <xref:System.Net.Sockets.Socket> and <xref:System.Net.Sockets.TcpListener> classes.

<a name="client"></a> 
### Windows Presentation Foundation (WPF)
 In the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)], Windows Presentation Foundation (WPF) contains changes and improvements in the following areas:

- The new <xref:System.Windows.Controls.Ribbon.Ribbon> control, which enables you to implement a ribbon user interface that hosts a Quick Access Toolbar, Application Menu, and tabs.

- The new <xref:System.ComponentModel.INotifyDataErrorInfo> interface, which supports synchronous and asynchronous data validation.

- New features for the <xref:System.Windows.Controls.VirtualizingPanel> and <xref:System.Windows.Threading.Dispatcher> classes.

- Improved performance when displaying large sets of grouped data, and by accessing collections on non-UI threads.

- Data binding to static properties, data binding to custom types that implement the <xref:System.Reflection.ICustomTypeProvider> interface, and retrieval of data binding information from a binding expression.

- Repositioning of data as the values change (live shaping).

- Ability to check whether the data context for an item container is disconnected.

- Ability to set the amount of time that should elapse between property changes and data source updates.

- Improved support for implementing weak event patterns. Also, events can now accept markup extensions.

<a name="windows_communication_foundation"></a> 
### Windows Communication Foundation (WCF)
 In the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)], the following features have been added to make it simpler to write and maintain Windows Communication Foundation (WCF) applications:

- Simplification of generated configuration files.

- Support for contract-first development.

- Ability to configure ASP.NET compatibility mode more easily.

- Changes in default transport property values to reduce the likelihood that you will have to set them.

- Updates to the <xref:System.Xml.XmlDictionaryReaderQuotas> class to reduce the likelihood that you will have to manually configure quotas for XML dictionary readers.

- Validation of WCF configuration files by Visual Studio as part of the build process, so you can detect configuration errors before you run your application.

- New asynchronous streaming support.

- New HTTPS protocol mapping to make it easier to expose an endpoint over HTTPS with Internet Information Services (IIS).

- Ability to generate metadata in a single WSDL document by appending `?singleWSDL` to the service URL.

- Websockets support to enable true bidirectional communication over ports 80 and 443 with performance characteristics similar to the TCP transport.

- Support for configuring services in code.

- XML Editor tooltips.

- <xref:System.ServiceModel.ChannelFactory> caching support.

- Binary encoder compression support.

- Support for a UDP transport that enables developers to write services that use "fire and forget" messaging. A client sends a message to a service and expects no response from the service.

- Ability to support multiple authentication modes on a single WCF endpoint when using the HTTP transport and transport security.

- Support for WCF services that use internationalized domain names (IDNs).

 For more information, see [What's New in Windows Communication Foundation](http://go.microsoft.com/fwlink/?LinkId=228173).

<a name="windows_workflow_foundation"></a> 
### Windows Workflow Foundation (WF)
 In the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)], several new features were added to Windows Workflow Foundation (WF), including:

- State machine workflows, which were first introduced as part of the .NET Framework 4.0.1 ([.NET Framework 4 Platform Update 1](http://go.microsoft.com/fwlink/?LinkID=215092)). This update included several new classes and activities that enabled developers to create state machine workflows. These classes and activities were updated for the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)] to include:

    - The ability to set breakpoints on states.

    - The ability to copy and paste transitions in the workflow designer.

    - Designer support for shared trigger transition creation.

    - Activities for creating state machine workflows, including: <xref:System.Activities.Statements.StateMachine>, <xref:System.Activities.Statements.State>, and <xref:System.Activities.Statements.Transition>.

- Enhanced Workflow Designer features such as the following:

    - Enhanced workflow search capabilities in Visual Studio, including **Quick Find** and **Find in Files**.

    - Ability to automatically create a Sequence activity when a second child activity is added to a container activity, and to include both activities in the Sequence activity.

    - Panning support, which enables the visible portion of a workflow to be changed without using the scroll bars.

    - A new **Document Outline** view that shows the components of a workflow in a tree-style outline view and lets you select a component in the **Document Outline** view.

    - Ability to add annotations to activities.

    - Ability to define and consume activity delegates by using the workflow designer.

    - Auto-connect and auto-insert for activities and transitions in state machine and flowchart workflows.

- Storage of the view state information for a workflow in a single element in the XAML file, so you can easily locate and edit the view state information.

- A NoPersistScope container activity to prevent child activities from persisting.

- Support for C# expressions:

    - Workflow projects that use Visual Basic will use Visual Basic expressions, and C# workflow projects will use C# expressions.

    - C# workflow projects that were created in Visual Studio 2010 and that have Visual Basic expressions are compatible with C# workflow projects that use C# expressions.

- Versioning enhancements:

    - The new  <xref:System.Activities.WorkflowIdentity> class, which provides a mapping between a persisted workflow instance and its workflow definition.

    - Side-by-side execution of multiple workflow versions in the same host, including <xref:System.ServiceModel.Activities.WorkflowServiceHost>.

    - In Dynamic Update, the ability to modify the definition of a persisted workflow instance.

- Contract-first workflow service development, which provides support for automatically generating activities to match an existing service contract.

 For more information, see [What's New in Windows Workflow Foundation](http://go.microsoft.com/fwlink/?LinkId=228176).

<a name="tailored"></a> 
### [!INCLUDE[net_win8_profile](../../../includes/net-win8-profile-md.md)]
 [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps are designed for specific form factors and leverage the power of the Windows operating system. A subset of the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)] or 4.5.1 is available for building [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps for Windows by using C# or Visual Basic. This subset is called [!INCLUDE[net_win8_profile](../../../includes/net-win8-profile-md.md)] and is discussed in an [overview](http://go.microsoft.com/fwlink/?LinkId=228491) in the Windows Dev Center.

<a name="portable"></a> 
### Portable Class Libraries
 The Portable Class Library project in [!INCLUDE[vs_dev11_long](../../../includes/vs-dev11-long-md.md)] (and later versions) enables you to write and build managed assemblies that work on multiple .NET Framework platforms. Using a Portable Class Library project, you choose the platforms (such as Windows Phone and [!INCLUDE[net_win8_profile](../../../includes/net-win8-profile-md.md)]) to target. The available types and members in your project are automatically restricted to the common types and members across these platforms. For more information, see [Portable Class Library](../../../docs/standard/cross-platform/cross-platform-development-with-the-portable-class-library.md).

## See Also
 [The .NET Framework and Out-of-Band Releases](../../../docs/framework/get-started/the-net-framework-and-out-of-band-releases.md)   
 [What's new in accessibility in the .NET Framework](whats-new-in-accessibility.md)   
 [What's New in Visual Studio 2017](/visualstudio/ide/whats-new-in-visual-studio)   
 [ASP.NET](/aspnet)   
 [What’s New in Visual C++](/cpp/what-s-new-for-visual-cpp-in-visual-studio) 
