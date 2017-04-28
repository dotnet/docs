---
title: "Runtime Changes in the .NET Framework 4.6 | Microsoft Docs"
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
  - "runtime changes, .NET Framework"
  - "runtime changes, .NET Framework 4.6"
  - "application compatibility"
ms.assetid: 5262bcfa-6e48-416b-8972-69cb4002d386
caps.latest.revision: 34
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Runtime Changes in the .NET Framework 4.6
In rare cases, runtime changes may affect existing apps that target the previous versions of the .NET Framework but run on a later version of the .NET Framework runtime. They also include differences in behavior between applications that run on different .NET Framework runtime environments. They include changes in the following areas:  
  
-   [Core](#Core)  
  
-   [Data](#Data)  
  
-   [Networking](#Networking)  
  
-   [Windows Communication Foundation (WCF)](#WCF)  
  
-   [Windows Presentation Foundation (WPF)](#WPF)  
  
-   [Setup and deployment](#Setup)  
  
-   [ClickOnce](#ClickOnce)  
  
-   [The new 64-bit JIT compiler](#RyuJIT)  
  
<a name="Core"></a>   
## Core  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|<xref:System.Globalization.PersianCalendar?displayProperty=fullName>|Starting with the [!INCLUDE[net_v46](../../../includes/net-v46-md.md)], the <xref:System.Globalization.PersianCalendar> class uses the Hijri solar algorithm.|The Hijri solar algorithm produces results identical to that of the Persian calendar currently in use in Iran and Afghanistan. It also produces results that are identical to the previous algorithm for dates from 1800 in the Gregorian calendar to 2023 in the Gregorian calendar. Dates outside that range may be affected if the <xref:System.Globalization.PersianCalendar> class is used for performing date conversions (for example, between dates in the Gregorian calendar and dates in the Persian calendar) or for determining whether a particular year is a leap year.<br /><br /> Because of the change, the <xref:System.Globalization.PersianCalendar.MinSupportedDateTime%2A?displayProperty=fullName> property value has changed from March 21, 0622 to March 22, 0622 for systems on which the [!INCLUDE[net_v46](../../../includes/net-v46-md.md)] is installed.<br /><br /> For more information, see the <xref:System.Globalization.PersianCalendar> topic.|Minor|  
|<xref:System.Runtime.Versioning.TargetFrameworkAttribute>|For the default application domain, the value of the <xref:System.AppDomainSetup.TargetFrameworkName%2A?displayProperty=fullName> property is derived from the  <xref:System.Runtime.Versioning.TargetFrameworkAttribute>, if one is present, unless it is explicitly defined by assigning a name to the <xref:System.AppDomainSetup.TargetFrameworkName%2A?displayProperty=fullName> property.  In previous versions of the .NET Framework, the value of the <xref:System.AppDomainSetup.TargetFrameworkName%2A?displayProperty=fullName> attribute is `null` unless a number of special code paths are executed or a non-default app domain is created without explicitly specifying its target framework in the <xref:System.AppDomainSetup.TargetFrameworkName%2A?displayProperty=fullName> property.<br /><br /> For non-default application domains, there is no change in the way that the value of the <xref:System.AppDomainSetup.TargetFrameworkName%2A?displayProperty=fullName> property is determined. If no value is explicitly assigned to the <xref:System.AppDomainSetup.TargetFrameworkName%2A?displayProperty=fullName> property, the non-default app domain inherits the target framework name from the default application domain.|For the default application domain, the <xref:System.AppDomainSetup.TargetFrameworkName%2A?displayProperty=fullName> may return a non-null value when it previously returned `null`. This is the desirable behavior.|Edge|  
|<xref:System.Security.Cryptography.X509Certificates.X509Certificate2.ToString%28System.Boolean%29?displayProperty=fullName>|If any certificates installed on the system are not supported by the .NET Framework, passing a value of `True` for the `verbose` argument returns a valid string. In previous versions of the .NET Framework, attempting to access public key information for unsupported certificates in some cases throws an exception.|This method is informational only; the documentation notes that output may not be consistent across .NET Framework versions. This change affects only apps that call the `ToString(True)` method and have installed certificates that are not supported by the .NET Framework. By returning a string rather than throwing an exception, this change makes the method more robust.|Edge|  
|Event Tracing for Windows (ETW)|In the [!INCLUDE[net_v46](../../../includes/net-v46-md.md)] and 4.6.1, the runtime throws a <xref:System.ArgumentException> when two event names differ only by a "Start" or "Stop" suffix (as when one event is named `LogUser` and another is named `LogUserStart`). In this case, the runtime cannot construct the event source, which cannot emit any logging.|Ensure that no two event names differ only by a "Start" or "Stop" suffix.<br /><br /> This requirement is removed starting with the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)]; the runtime can disambiguate event names that differ only by the  "Start" suffix.|Edge|  
|Reflection and Distributed COM (DCOM)|Reflection objects can no longer be passed from managed code to out-of-process DCOM clients. The following types are affected: <xref:System.Reflection.Assembly>; <xref:System.Reflection.MemberInfo> and its derived types, including <xref:System.Reflection.FieldInfo>, <xref:System.Reflection.MethodInfo>, <xref:System.Type>, and <xref:System.Reflection.TypeInfo>; <xref:System.Reflection.MethodBody>; <xref:System.Reflection.Module>; and <xref:System.Reflection.ParameterInfo>.|Calls to [IMarshal](http://msdn.microsoft.com/library/windows/desktop/dd542707.aspx) for the object return `E_NOINTERFACE`.|Minor|  
  
<a name="Data"></a>   
## Data  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|A TCP/IP connection to a SQL Server database that resolves to `localhost`|Starting with the [!INCLUDE[net_v46](../../../includes/net-v46-md.md)], the connection attempt fails with the error, "A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: SQL Network Interfaces, error: 26 - Error Locating Server/Instance Specified)"|This issue has been addressed, and the previous behavior restored, in the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)]. To connect to a SQL Server database that resolves to `localhost`, upgrade to the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)].|Minor|  
  
<a name="Networking"></a>   
## Networking  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|Date and time values in the <xref:System.Net.Mime.ContentDisposition?displayProperty=fullName> class.|To comply with [RFC822](http://www.ietf.org/rfc/rfc0822.txt) and [RFC2822](http://www.ietf.org/rfc/rfc2822.txt), a formatted date and time value now has a two-digit hour. Previously, it has a single-digit hour for values before 10:00 AM.|This change affects the following usage scenarios:<br /><br /> -   Comparing the lengths or hash codes of serialized <xref:System.Net.Mime.ContentDisposition> objects across .NET Framework versions.<br />-   Comparing the return value of the <xref:System.Net.Mime.ContentDisposition.ToString%2A> method or the string representation of <xref:System.Net.Mime.ContentDisposition> date and time property values across .NET Framework versions.|Minor|  
  
<a name="WCF"></a>   
## Windows Communication Foundation (WCF)  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|WCF services that use NETTCP with SSL security and certificate authentication|The .NET Framework 4.6 adds TLS 1.1 and TLS 1.2 to the WCF SSL default protocol list. When both client and server machines have  the .NET Framework 4.6 or later installed, TLS 1.2 is used for negotiation.|TLS 1.2 does not support MD5 certificate authentication. As a result, if a customer uses an MD5 certificate, the WCF client will fail to connect to the WCF service. For more information, see [Mitigation: WCF Services and Certificate Authentication](../../../docs/framework/migration-guide/mitigation-wcf-services-and-certificate-authentication.md).|Minor|  
  
<a name="WPF"></a>   
## Windows Presentation Foundation (WPF)  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|Window rendering in a multi-monitor scenario|The entire window is rendered without clipping when it extends outside of a display in a multi-monitor scenario.|See [Mitigation: WPF Window Rendering](../../../docs/framework/migration-guide/mitigation-wpf-window-rendering.md).|Minor|  
|The spell checker on WPF text-enabled controls|When running on Windows 10, the spell checker may not work because platform spell-checking capabilities are available only for languages present in the input languages list.|In Windows 10, when a language is added to the list of available keyboards, Windows automatically downloads and installs a corresponding Feature on Demand (FOD) package that provides spell-checking capabilities. By adding the language to the input languages list, the spell checker will be supported.|Minor|  
  
<a name="Setup"></a>   
## Setup and deployment  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|Product versioning|Product versioning has changed from the previous releases of the .NET Framework, and particularly the .NET Framework 4, 4.5, 4.5.1, and 4.5.2. For more information, see [Mitigation: Product Versioning](../../../docs/framework/migration-guide/mitigation-product-versioning.md).|See [Mitigation: Product Versioning](../../../docs/framework/migration-guide/mitigation-product-versioning.md).|Medium|  
  
<a name="ClickOnce"></a>   
## ClickOnce  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|Apps published with ClickOnce that use a SHA-256 code-signing certificate.|ClickOnce apps that target the [!INCLUDE[netfx40_short](../../../includes/netfx40-short-md.md)] or earlier versions and are signed with an SHA-256 certificate no longer have a runtime dependency on the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)] or a later version.|Previously, signing a ClickOnce app that targeted the [!INCLUDE[netfx40_short](../../../includes/netfx40-short-md.md)] or earlier versions with an SHA-256 certificate required that the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)] or a later version be present on the target system. This resulted in errors in cases in which it was not present. This change removes that dependency and allows SHA-256 certificates to be used to sign ClickOnce apps that target [!INCLUDE[netfx40_short](../../../includes/netfx40-short-md.md)] and earlier versions.|Minor|  
  
<a name="RyuJIT"></a>   
## The new 64-bit JIT compiler  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|64-bit JIT compilation|Starting with the .NET Framework 4.6, a new 64-bit JIT compiler is used for just-in-time compilation. This change does not affect the  32-bit JIT compiler.|In some cases, an unexpected exception is thrown or a different behavior is observed than if an app is run using 32-bit compiler or the older 64-bit JIT compiler. **Note:**  All of these issues have been addressed in the new 64-bit compiler released with the .NET Framework 4.6.2. Most have also been addressed in service releases of the .NET Framework 4.6 and 4.6.1 that are included with Windows Update. <br /><br /> For more information, see [Mitigation: New 64-bit JIT Compiler](../../../docs/framework/migration-guide/mitigation-new-64-bit-jit-compiler.md).|Edge|  
|Exception handling (returning from a `try` region)|Unlike the older JIT64 just-in-time compiler, the new 64-bit JIT compiler does not allow an IL `ret` instruction in a `try` region.|Returning from a `try` region is disallowed by the ECMA-335 specification, and no known managed compiler generates such IL. However, the JIT64 compiler will execute such IL if it is generated using reflection emit.<br /><br /> If your app generates IL that includes a `ret` opcode in a `try` region, you can:<br /><br /> -   Target the .NET Framework 4.5 or add the [\<useLegacyJit>](../../../docs/framework/configure-apps/file-schema/runtime/uselegacyjit-element.md) element to your application configuration file to use the old JIT compiler and avoid the change.<br />-   Update the generated IL to return after the `try` region.<br />-|Edge|