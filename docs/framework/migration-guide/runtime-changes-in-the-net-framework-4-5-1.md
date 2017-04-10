---
title: "Runtime Changes in the .NET Framework 4.5.1 | Microsoft Docs"
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
  - "application compatibility"
  - "runtime changes"
  - ".NET Framework 4.5.1"
ms.assetid: da880ad7-ba0a-4368-b340-705e3533c351
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Runtime Changes in the .NET Framework 4.5.1
In rare cases, runtime changes may affect existing apps that target the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)] or 4.5 but run on the 4.51 runtime. They include changes in the following areas:  
  
-   [Core](#Core)  
  
-   [Windows Communication Foundation (WCF)](#WCF)  
  
 The Scope column in the following tables specifies the significance of each change:  
  
-   Major. A significant change that affects a large number of apps or that requires substantial modification of code. Note that none of the runtime changes fall into this category.  
  
-   Minor. A change that either affects a small number of apps or that requires minor modification of code.  
  
-   Edge. A change that affects apps under very specific scenarios that are not common.  
  
-   Transparent. A change that has no noticeable effect on the app's developer or user. The app should not require modification because of this change.  
  
<a name="Core"></a>   
## Core runtime changes  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|<xref:System.Collections.Concurrent.ConcurrentDictionary%602?displayProperty=fullName> serialization|A <xref:System.Collections.Concurrent.ConcurrentDictionary%602> object serialized in the .NET Framework 4.5 with the <xref:System.Runtime.Serialization.NetDataContractSerializer> cannot be deserialized in the .NET Framework 4.5.1 and 4.5.2 only because of internal changes in the type.<br /><br /> This change does *not* apply in the following scenarios:<br /><br /> A <xref:System.Collections.Concurrent.ConcurrentDictionary%602> object serialized in the .NET Framework 4.5 and deserialized in the [!INCLUDE[net_v46](../../../includes/net-v46-md.md)]. The <xref:System.Runtime.Serialization.NetDataContractSerializer> in the [!INCLUDE[net_v46](../../../includes/net-v46-md.md)] is able to deserialize the object.<br /><br /> A <xref:System.Collections.Concurrent.ConcurrentDictionary%602> object serialized in a later version of the .NET Framework and deserialized in the .NET Framework 4.5. The <xref:System.Runtime.Serialization.NetDataContractSerializer> in the .NET Framework 4.5 is able to deserialize the object.<br /><br /> Inter-version serialization and deserialization of a <xref:System.Collections.Concurrent.ConcurrentDictionary%602> object between any version of the .NET Framework after the .NET Framework 4.5. This change applies to objects serialized with the .NET Framework 4.5 *only*.|Two workarounds are available if it is necessary to serialize a <xref:System.Collections.Concurrent.ConcurrentDictionary%602> object on the .NET Framework 4.5 and deserialize it on a later version of the .NET Framework:<br /><br /> Use an alternate serializer, such as the <xref:System.Runtime.Serialization.DataContractSerializer> or the <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter>.<br /><br /> Upgrade to the [!INCLUDE[net_v46](../../../includes/net-v46-md.md)], which supports deserialization of <xref:System.Collections.Concurrent.ConcurrentDictionary%602> object serialized with the .NET Framework 4.5.|Minor|  
|<xref:System.Diagnostics.Tracing.EventListener?displayProperty=fullName> class|<xref:System.Diagnostics.Tracing.EventListener> truncates strings with embedded nulls. Null characters are not supported by the <xref:System.Diagnostics.Tracing.EventSource> class.|The change only affects apps that use <xref:System.Diagnostics.Tracing.EventListener> to read <xref:System.Diagnostics.Tracing.EventSource> data in process and that use null characters as delimiters.|Edge|  
|<xref:System.Diagnostics.Tracing.EventSource?displayProperty=fullName> class|The runtime now enforces the contract that specifies the following: A class derived from <xref:System.Diagnostics.Tracing.EventSource> that defines an ETW event method must call the base class <xref:System.Diagnostics.Tracing.EventSource.WriteEvent%2A?displayProperty=fullName> method with the event ID followed by the same arguments that the ETW event method was passed.|An <xref:System.IndexOutOfRangeException> exception is thrown if an <xref:System.Diagnostics.Tracing.EventListener> reads <xref:System.Diagnostics.Tracing.EventSource> data in process for an event source that violates this contract.<br /><br /> See [Mitigation: EventSource.WriteEvent Method Calls](../../../docs/framework/migration-guide/mitigation-eventsource-writeevent-method-calls.md)|Minor|  
|Deserialization of objects across application domains|In some cases, when an app uses two or more app domains with different application bases, trying to deserialize objects in the logical call context across app domains throws an exception.|This issue arises in a highly specific scenario. For more information and mitigation, see [Mitigation: Deserialization of Objects Across App Domains](../../../docs/framework/migration-guide/mitigation-deserialization-of-objects-across-app-domains.md).|Edge|  
|<xref:System.IO.Stream.Dispose%2A?displayProperty=fullName> method|In [!INCLUDE[win8_appstore_long](../../../includes/win8-appstore-long-md.md)] apps, [!INCLUDE[wrt](../../../includes/wrt-md.md)] stream adapters no longer call the <xref:System.IO.Stream.FlushAsync%2A> method from the <xref:System.IO.Stream.Dispose%2A> method.|This change should be transparent. Developers can restore the previous behavior by writing code like this:<br /><br /> `using (System.IO.Stream stream = GetWindowsRuntimeStream() As Stream)  {     // do something     await stream.FlushAsync();   }`|Transparent|  
  
<a name="WCF"></a>   
## Windows Communication Foundation (WCF) runtime changes  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|[minFreeMemoryPercentageToActiveService](http://msdn.microsoft.com/library/ms731336.aspx) configuration setting|The setting establishes the minimum memory that must be available on the server before a WCF service can be activated. It is designed to prevent <xref:System.OutOfMemoryException> exceptions. In the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)], this setting had no effect. In the [!INCLUDE[net_v451](../../../includes/net-v451-md.md)], the setting is observed.|An exception occurs if the free memory available on the web server is less than the percentage defined by the configuration setting. Some WCF services that successfully started and ran in a constrained memory environment may now fail.<br /><br /> See [Mitigation: minFreeMemoryPercentageToActiveService Configuration Setting](../../../docs/framework/migration-guide/mitigation-minfreememorypercentagetoactiveservice-configuration-setting.md).|Minor|  
  
## See Also  
 [Retargeting Changes](../../../docs/framework/migration-guide/retargeting-changes-in-the-net-framework-4-5-1.md)   
 [Application Compatibility in 4.5](../../../docs/framework/migration-guide/application-compatibility-in-the-net-framework-4-5.md)   
 [Application Compatibility in 4.5.2](../../../docs/framework/migration-guide/application-compatibility-in-the-net-framework-4-5-2.md)