---
title: "<runtime> Element"
ms.date: "03/30/2017"
f1_keywords:
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#runtime"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/runtime"
helpviewer_keywords:
  - "<runtime> element"
  - "runtime element"
  - "container tags, <runtime> element"
ms.assetid: 1eb2fae3-de4b-45b6-852f-517c39b751bd
---
# \<runtime> Element

Provides information used by the common language runtime to configure applications.

[\<configuration>](../configuration-element.md)\
&nbsp;&nbsp;\<runtime>

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
|[\<alwaysFlowImpersonationPolicy>](alwaysflowimpersonationpolicy-element.md)|Specifies that the Windows identity always flows across asynchronous points, regardless of how impersonation was performed.|
|[\<AppContextSwitchOverrides>](appcontextswitchoverrides-element.md)|Defines one or more switches used by the <xref:System.AppContext> class to provide an opt-out mechanism for new functionality.|
|[\<appDomainManagerAssembly>](appdomainmanagerassembly-element.md)|Specifies the assembly that provides the application domain manager for the default application domain in the process.|
|[\<appDomainManagerType>](appdomainmanagertype-element.md)|Specifies the type that serves as the application domain manager for the default application domain.|
|[\<appDomainResourceMonitoring>](appdomainresourcemonitoring-element.md)|Instructs the runtime to collect statistics on all application domains in the process for the life of the process.|
|[\<assemblyBinding>](assemblybinding-element-for-runtime.md)|Contains information about assembly version redirection and the locations of assemblies.|
|[\<bypassTrustedAppStrongNames>](bypasstrustedappstrongnames-element.md)|Specifies whether strong name verification for trusted assemblies should be bypassed.|
|[\<CompatSortNLSVersion>](compatsortnlsversion-element.md)|Specifies that the runtime should use legacy sorting behavior when performing string comparisons.|
|[\<developmentMode>](developmentmode-element.md)|Specifies whether the runtime searches for assemblies in directories specified by the DEVPATH environment variable.|
|[\<disableCachingBindingFailures>](disablecachingbindingfailures-element.md)|Specifies whether the caching of binding failures, which is the default behavior in the .NET Framework version 2.0, is disabled.|
|[\<disableCommitThreadStack>](disablecommitthreadstack-element.md)|Specifies whether the full thread stack is committed when a thread is started.|
|[\<disableFusionUpdatesFromADManager>](disablefusionupdatesfromadmanager-element.md)|Specifies whether the default behavior, which is to allow the runtime host to override configuration settings for an application domain, is disabled.|
|[\<EnableAmPmParseAdjustment>](enableampmparseadjustment-element.md)|Determines whether date and time parsing methods use an adjusted set of rules to parse date strings that contain only a day, month, hour, and AM/PM designator.|
|[\<enforceFIPSPolicy>](enforcefipspolicy-element.md)|Specifies whether to enforce a computer configuration requirement that cryptographic algorithms must comply with the Federal Information Processing Standards (FIPS).|
|[\<etwEnable>](etwenable-element.md)|Specifies whether to enable event tracing for Windows (ETW) for common language runtime events.|
|[\<forcePerformanceCounterUniqueSharedMemoryReads>](forceperformancecounteruniquesharedmemoryreads-element.md)|Specifies whether PerfCounter.dll uses the CategoryOptions registry setting in a .NET Framework version 1.1 application to determine whether to load performance counter data from category-specific shared memory or global memory.|
|[\<gcAllowVeryLargeObjects>](gcallowverylargeobjects-element.md)|On 64-bit platforms, enables arrays that are greater than 2 gigabytes (GB) in total size.|
|[\<gcConcurrent>](gcconcurrent-element.md)|Specifies whether the common language runtime runs garbage collection concurrently.|
|[\<GCCpuGroup>](gccpugroup-element.md)|Specifies whether garbage collection supports multiple CPU groups.|
|[\<GCHeapAffinitizeMask>](gcheapaffinitizemask-element.md)|Defines the affinity between garbage collection heaps and individual processors.|
|[\<GCHeapCount>](gcheapcount-element.md)|Specifies the number of heaps/threads to use for server garbage collection.|
|[\<GCLOHThreshold>](gclohthreshold-element.md)|Specifies the threshold size that causes the garbage collector to put objects on the large object heap.|
|[\<GCNoAffinitize>](gcnoaffinitize-element.md)|Specifies whether or not to affinitize server garbage collection threads with CPUs.|
|[\<gcServer>](gcserver-element.md)|Specifies whether the common language runtime runs server garbage collection.|
|[\<generatePublisherEvidence>](generatepublisherevidence-element.md)|Specifies whether the runtime uses code access security (CAS) publisher policy.|
|[\<legacyCorruptedStateExceptionsPolicy>](legacycorruptedstateexceptionspolicy-element.md)|Specifies whether the runtime allows managed code to catch access violations and other corrupted state exceptions.|
|[\<legacyImpersonationPolicy>](legacyimpersonationpolicy-element.md)|Specifies that the Windows identity does not flow across asynchronous points, regardless of the flow settings for the execution context on the current thread.|
|[\<loadfromRemoteSources>](loadfromremotesources-element.md)|Specifies whether assemblies from remote sources are loaded as full trust.|
|[\<NetFx40_LegacySecurityPolicy>](netfx40-legacysecuritypolicy-element.md)|Specifies whether the runtime uses legacy code access security (CAS) policy.|
|[\<NetFx40_PInvokeStackResilience>](netfx40-pinvokestackresilience-element.md)|Specifies whether the runtime automatically fixes incorrect platform invoke declarations at run time, at the cost of slower transitions between managed and unmanaged code.|
|[\<NetFx45_CultureAwareComparerGetHashCode_LongStrings>](netfx45-cultureawarecomparergethashcode-longstrings-element.md)|Specifies whether the runtime uses a fixed amount of memory to calculate hash codes for the <xref:System.StringComparer.GetHashCode%2A?displayProperty=nameWithType> method.|
|[\<PreferComInsteadOfRemoting>](prefercominsteadofmanagedremoting-element.md)|Specifies that the runtime will use COM interop instead of remoting across application domain boundaries.|
|[\<relativeBindForResources>](relativebindforresources-element.md)|Optimizes the probe for satellite assemblies.|
|[\<shadowCopyVerifyByTimeStamp>](shadowcopyverifybytimestamp-element.md)|Specifies whether shadow copying uses the default startup behavior introduced in the .NET Framework 4, or reverts to the startup behavior of earlier versions of the .NET Framework.|
|[\<supportPortability>](supportportability-element.md)|Specifies that an application can reference the same assembly in two different implementations of the .NET Framework, by disabling the default behavior that treats the assemblies as equivalent for application portability purposes.|
|[\<system.runtime.caching>](system-runtime-caching-element-cache-settings.md)|Provides configuration information for the default in-memory object cache.|
|[\<Thread_UseAllCpuGroups>](thread-useallcpugroups-element.md)|Specifies whether the runtime distributes managed threads across all CPU groups.|
|[\<ThrowUnobservedTaskExceptions>](throwunobservedtaskexceptions-element.md)|Specifies whether unhandled task exceptions should terminate a running process.|
|[\<TimeSpan_LegacyFormatMode>](timespan-legacyformatmode-element.md)|Specifies whether the runtime uses legacy formatting for <xref:System.TimeSpan> values.|
|[\<useLegacyJit>](uselegacyjit-element.md)|Determines whether the common language runtime uses the legacy 64-bit JIT compiler for just-in-time compilation.|
|[\<UseRandomizedStringHashAlgorithm>](userandomizedstringhashalgorithm-element.md)|Specifies whether the runtime calculates hash codes for strings on a per application domain basis.|
|[\<UseSmallInternalThreadStacks>](usesmallinternalthreadstacks-element.md)|Requests that the runtime use explicit stack sizes when it creates certain threads that it uses internally, instead of the default stack size.|

### Parent Elements

|Element|Description|
|-------------|-----------------|
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|

## Remarks

The child elements in the [\<runtime>](runtime-element.md) section of a configuration file are used by the common language runtime to configure how an application executes. For example, the [\<gcServer>](gcserver-element.md) element determines whether the garbage collector uses workstation garbage collection or server garbage collection, the [\<UseRandomizedStringHashAlgorithm>](userandomizedstringhashalgorithm-element.md) element determines whether the common language runtime calculates hash codes for string on a per-application or a per-application domain basis, and the `AppContextSwitchOverrides` element allows library users to opt in or opt out of changed  functionality provided by a library.

The elements in the [\<runtime>](runtime-element.md) section are read automatically by the common language runtime at application startup. You can also define the configuration file for a non-default application domain by supplying its name to the <xref:System.AppDomainSetup.ConfigurationFile%2A?displayProperty=nameWithType> property; its settings are read automatically when the application domain is loaded. You should rarely, if ever, have a need to directly read the settings in the [\<runtime>](runtime-element.md) section in your application's configuration file.

## See also

- [Runtime Settings Schema](index.md)
- [Configuration File Schema](../index.md)
