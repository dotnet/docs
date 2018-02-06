---
title: "&lt;runtime&gt; Element"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#runtime"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/runtime"
helpviewer_keywords: 
  - "<runtime> element"
  - "runtime element"
  - "container tags, <runtime> element"
ms.assetid: 1eb2fae3-de4b-45b6-852f-517c39b751bd
caps.latest.revision: 70
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;runtime&gt; Element
Provides information used by the common language runtime to configure applications.  
  
 \<configuration>  
\<runtime>  
  
## Syntax  
  
```xml  
<runtime>  
</runtime>  
```  
  
## Attributes and Elements  
 The following sections describe child elements and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<alwaysFlowImpersonationPolicy>](../../../../../docs/framework/configure-apps/file-schema/runtime/alwaysflowimpersonationpolicy-element.md)|Specifies that the Windows identity always flows across asynchronous points, regardless of how impersonation was performed.|  
|[\<AppContextSwitchOverrides>](../../../../../docs/framework/configure-apps/file-schema/runtime/appcontextswitchoverrides-element.md)|Defines one or more switches used by the <xref:System.AppContext> class to provide an opt-out mechanism for new functionality.|  
|[\<appDomainManagerAssembly>](../../../../../docs/framework/configure-apps/file-schema/runtime/appdomainmanagerassembly-element.md)|Specifies the assembly that provides the application domain manager for the default application domain in the process.|  
|[\<appDomainManagerType>](../../../../../docs/framework/configure-apps/file-schema/runtime/appdomainmanagertype-element.md)|Specifies the type that serves as the application domain manager for the default application domain.|  
|[\<appDomainResourceMonitoring>](../../../../../docs/framework/configure-apps/file-schema/runtime/appdomainresourcemonitoring-element.md)|Instructs the runtime to collect statistics on all application domains in the process for the life of the process.|  
|[\<assemblyBinding>](../../../../../docs/framework/configure-apps/file-schema/runtime/assemblybinding-element-for-runtime.md)|Contains information about assembly version redirection and the locations of assemblies.|  
|[\<bypassTrustedAppStrongNames>](../../../../../docs/framework/configure-apps/file-schema/runtime/bypasstrustedappstrongnames-element.md)|Specifies whether strong name verification for trusted assemblies should be bypassed.|  
|[\<CompatSortNLSVersion>](../../../../../docs/framework/configure-apps/file-schema/runtime/compatsortnlsversion-element.md)|Specifies that the runtime should use legacy sorting behavior when performing string comparisons.|  
|[\<developmentMode>](../../../../../docs/framework/configure-apps/file-schema/runtime/developmentmode-element.md)|Specifies whether the runtime searches for assemblies in directories specified by the DEVPATH environment variable.|  
|[\<disableCachingBindingFailures>](../../../../../docs/framework/configure-apps/file-schema/runtime/disablecachingbindingfailures-element.md)|Specifies whether the caching of binding failures, which is the default behavior in the .NET Framework version 2.0, is disabled.|  
|[\<disableCommitThreadStack>](../../../../../docs/framework/configure-apps/file-schema/runtime/disablecommitthreadstack-element.md)|Specifies whether the full thread stack is committed when a thread is started.|  
|[\<disableFusionUpdatesFromADManager>](../../../../../docs/framework/configure-apps/file-schema/runtime/disablefusionupdatesfromadmanager-element.md)|Specifies whether the default behavior, which is to allow the runtime host to override configuration settings for an application domain, is disabled.|  
|[\<EnableAmPmParseAdjustment>](../../../../../docs/framework/configure-apps/file-schema/runtime/enableampmparseadjustment-element.md)|Determines whether date and time parsing methods use an adjusted set of rules to parse date strings that contain only a day, month, hour, and AM/PM designator.|  
|[\<enforceFIPSPolicy>](../../../../../docs/framework/configure-apps/file-schema/runtime/enforcefipspolicy-element.md)|Specifies whether to enforce a computer configuration requirement that cryptographic algorithms must comply with the Federal Information Processing Standards (FIPS).|  
|[\<etwEnable>](../../../../../docs/framework/configure-apps/file-schema/runtime/etwenable-element.md)|Specifies whether to enable event tracing for Windows (ETW) for common language runtime events.|  
|[\<forcePerformanceCounterUniqueSharedMemoryReads>](../../../../../docs/framework/configure-apps/file-schema/runtime/forceperformancecounteruniquesharedmemoryreads-element.md)|Specifies whether PerfCounter.dll uses the CategoryOptions registry setting in a .NET Framework version 1.1 application to determine whether to load performance counter data from category-specific shared memory or global memory.|  
|[\<gcAllowVeryLargeObjects>](../../../../../docs/framework/configure-apps/file-schema/runtime/gcallowverylargeobjects-element.md)|On 64-bit platforms, enables arrays that are greater than 2 gigabytes (GB) in total size.|  
|[\<gcConcurrent>](../../../../../docs/framework/configure-apps/file-schema/runtime/gcconcurrent-element.md)|Specifies whether the common language runtime runs garbage collection concurrently.|  
|[\<GCCpuGroup>](../../../../../docs/framework/configure-apps/file-schema/runtime/gccpugroup-element.md)|Specifies whether garbage collection supports multiple CPU groups.|  
|[\<gcServer>](../../../../../docs/framework/configure-apps/file-schema/runtime/gcserver-element.md)|Specifies whether the common language runtime runs server garbage collection.|  
|[\<generatePublisherEvidence>](../../../../../docs/framework/configure-apps/file-schema/runtime/generatepublisherevidence-element.md)|Specifies whether the runtime uses code access security (CAS) publisher policy.|  
|[\<legacyCorruptedStateExceptionsPolicy>](../../../../../docs/framework/configure-apps/file-schema/runtime/legacycorruptedstateexceptionspolicy-element.md)|Specifies whether the runtime allows managed code to catch access violations and other corrupted state exceptions.|  
|[\<legacyImpersonationPolicy>](../../../../../docs/framework/configure-apps/file-schema/runtime/legacyimpersonationpolicy-element.md)|Specifies that the Windows identity does not flow across asynchronous points, regardless of the flow settings for the execution context on the current thread.|  
|[\<loadfromRemoteSources>](../../../../../docs/framework/configure-apps/file-schema/runtime/loadfromremotesources-element.md)|Specifies whether assemblies from remote sources are loaded as full trust.|  
|[<NetFx40_LegacySecurityPolicy>](../../../../../docs/framework/configure-apps/file-schema/runtime/netfx40-legacysecuritypolicy-element.md)|Specifies whether the runtime uses legacy code access security (CAS) policy.|  
|[<NetFx40_PInvokeStackResilience>](../../../../../docs/framework/configure-apps/file-schema/runtime/netfx40-pinvokestackresilience-element.md)|Specifies whether the runtime automatically fixes incorrect platform invoke declarations at run time, at the cost of slower transitions between managed and unmanaged code.|  
|[<NetFx45_CultureAwareComparerGetHashCode_LongStrings>](../../../../../docs/framework/configure-apps/file-schema/runtime/netfx45-cultureawarecomparergethashcode-longstrings-element.md)|Specifies whether the runtime uses a fixed amount of memory to calculate hash codes for the <xref:System.StringComparer.GetHashCode%2A?displayProperty=nameWithType> method.|  
|[\<PreferComInsteadOfRemoting>](../../../../../docs/framework/configure-apps/file-schema/runtime/prefercominsteadofmanagedremoting-element.md)|Specifies that the runtime will use COM interop instead of remoting across application domain boundaries.|  
|[\<relativeBindForResources>](../../../../../docs/framework/configure-apps/file-schema/runtime/relativebindforresources-element.md)|Optimizes the probe for satellite assemblies.|  
|[\<shadowCopyVerifyByTimeStamp>](../../../../../docs/framework/configure-apps/file-schema/runtime/shadowcopyverifybytimestamp-element.md)|Specifies whether shadow copying uses the default startup behavior introduced in the [!INCLUDE[net_v40_long](../../../../../includes/net-v40-long-md.md)], or reverts to the startup behavior of earlier versions of the .NET Framework.|  
|[\<supportPortability>](../../../../../docs/framework/configure-apps/file-schema/runtime/supportportability-element.md)|Specifies that an application can reference the same assembly in two different implementations of the .NET Framework, by disabling the default behavior that treats the assemblies as equivalent for application portability purposes.|  
|[\<system.runtime.caching>](../../../../../docs/framework/configure-apps/file-schema/runtime/system-runtime-caching-element-cache-settings.md)|Provides configuration information for the default in-memory object cache.|  
|[<Thread_UseAllCpuGroups>](../../../../../docs/framework/configure-apps/file-schema/runtime/thread-useallcpugroups-element.md)|Specifies whether the runtime distributes managed threads across all CPU groups.|  
|[\<ThrowUnobservedTaskExceptions>](../../../../../docs/framework/configure-apps/file-schema/runtime/throwunobservedtaskexceptions-element.md)|Specifies whether unhandled task exceptions should terminate a running process.|  
|[<TimeSpan_LegacyFormatMode>](../../../../../docs/framework/configure-apps/file-schema/runtime/timespan-legacyformatmode-element.md)|Specifies whether the runtime uses legacy formatting for <xref:System.TimeSpan> values.|  
|[\<useLegacyJit>](../../../../../docs/framework/configure-apps/file-schema/runtime/uselegacyjit-element.md)|Determines whether the common language runtime uses the legacy 64-bit JIT compiler for just-in-time compilation.|  
|[\<UseRandomizedStringHashAlgorithm>](../../../../../docs/framework/configure-apps/file-schema/runtime/userandomizedstringhashalgorithm-element.md)|Specifies whether the runtime calculates hash codes for strings on a per application domain basis.|  
|[\<UseSmallInternalThreadStacks>](../../../../../docs/framework/configure-apps/file-schema/runtime/usesmallinternalthreadstacks-element.md)|Requests that the runtime use explicit stack sizes when it creates certain threads that it uses internally, instead of the default stack size.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
  
## Remarks  
 The child elements in the [\<runtime>](../../../../../docs/framework/configure-apps/file-schema/runtime/runtime-element.md) section of a configuration file are used by the common language runtime to configure how an application executes. For example, the [\<gcServer>](../../../../../docs/framework/configure-apps/file-schema/runtime/gcserver-element.md) element determines whether the garbage collector uses workstation garbage collection or server garbage collection, the [\<UseRandomizedStringHashAlgorithm>](../../../../../docs/framework/configure-apps/file-schema/runtime/userandomizedstringhashalgorithm-element.md) element determines whether the common language runtime calculates hash codes for string on a per-application or a per-application domain basis, and the `AppContextSwitchOverrides` element allows library users to opt in or opt out of changed  functionality provided by a library.  
  
 The elements in the [\<runtime>](../../../../../docs/framework/configure-apps/file-schema/runtime/runtime-element.md) section are read automatically by the common language runtime at application startup. You can also define the configuration file for a non-default application domain by supplying its name to the <xref:System.AppDomainSetup.ConfigurationFile%2A?displayProperty=nameWithType> property; its settings are read automatically when the application domain is loaded. You should rarely, if ever, have a need to directly read the settings in the [\<runtime>](../../../../../docs/framework/configure-apps/file-schema/runtime/runtime-element.md) section in your application's configuration file.  
  
## See Also  
 [Runtime Settings Schema](../../../../../docs/framework/configure-apps/file-schema/runtime/index.md)  
 [Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)
