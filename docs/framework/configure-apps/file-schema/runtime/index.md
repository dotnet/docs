---
title: "Runtime Settings Schema"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "schema runtime settings"
  - "configuration schema [.NET Framework], runtime settings"
  - "runtime settings schema"
ms.assetid: f04816ab-110d-4e28-9283-845d6d9a4a68
---
# Run-time settings schema

Run-time settings are used by the common language runtime to configure applications that target the .NET Framework.

## The \<runtime> section and its parent and child elements

[\<configuration>](../configuration-element.md)\
&nbsp;&nbsp;[\<runtime>](runtime-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<alwaysFlowImpersonationPolicy>](alwaysflowimpersonationpolicy-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<AppContextSwitchOverrides>](appcontextswitchoverrides-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<appDomainManagerAssembly>](appdomainmanagerassembly-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<appDomainManagerType>](appdomainmanagertype-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<appDomainResourceMonitoring>](appdomainresourcemonitoring-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<assemblyBinding>](assemblybinding-element-for-runtime.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[\<dependentAssembly>](dependentassembly-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[\<assemblyIdentity>](assemblyidentity-element-for-runtime.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[\<bindingRedirect>](bindingredirect-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[\<codeBase>](codebase-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[\<publisherPolicy>](publisherpolicy-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[\<probing>](probing-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[\<qualifyAssembly>](qualifyassembly-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[\<supportPortability>](supportportability-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<bypassTrustedAppStrongNames>](bypasstrustedappstrongnames-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<CompatSortNLSVersion>](compatsortnlsversion-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<developmentMode>](developmentmode-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<disableCachingBindingFailures>](disablecachingbindingfailures-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<disableCommitThreadStack>](disablecommitthreadstack-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<disableFusionUpdatesFromADManager>](disablefusionupdatesfromadmanager-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<EnableAmPmParseAdjustment>](enableampmparseadjustment-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<enforceFIPSPolicy>](enforcefipspolicy-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<etwEnable>](etwenable-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<forcePerformanceCounterUniqueSharedMemoryReads>](forceperformancecounteruniquesharedmemoryreads-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<gcAllowVeryLargeObjects>](gcconcurrent-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<gcConcurrent>](gcconcurrent-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<GCCpuGroup>](gccpugroup-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<GCHeapAffinitizeMask>](gcheapaffinitizemask-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<GCHeapCount>](gcheapcount-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<GCLOHThreshold>](gclohthreshold-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<GCNoAffinitize>](gcnoaffinitize-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<gcServer>](gcserver-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<generatePublisherEvidence>](generatepublisherevidence-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<legacyCorruptedStateExceptionsPolicy>](legacycorruptedstateexceptionspolicy-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<legacyImpersonationPolicy>](legacyimpersonationpolicy-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<loadfromRemoteSources>](loadfromremotesources-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<NetFx40_LegacySecurityPolicy>](netfx40-legacysecuritypolicy-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<NetFx40_PInvokeStackResilience>](netfx40-pinvokestackresilience-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<NetFx45_CultureAwareComparerGetHashCode_LongStrings>](netfx45-cultureawarecomparergethashcode-longstrings-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<PreferComInsteadOfManagedRemoting>](prefercominsteadofmanagedremoting-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<relativeBindForResources>](relativebindforresources-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<shadowCopyVerifyByTimeStamp>](shadowcopyverifybytimestamp-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<Thread_UseAllCpuGroups>](thread-useallcpugroups-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<ThrowUnobservedTaskExceptions>](throwunobservedtaskexceptions-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<TimeSpan_LegacyFormatMode>](runtime-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<useLegacyJit>](uselegacyjit-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<UseRandomizedStringHashAlgorithm>](userandomizedstringhashalgorithm-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<UseSmallInternalThreadStacks>](usesmallinternalthreadstacks-element.md)\
&nbsp;&nbsp;[\<system.runtime.caching>](system-runtime-caching-element-cache-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<memoryCache>](memorycache-element-cache-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[\<namedCaches>](namedcaches-element-cache-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[\<add>](add-element-for-namedcaches.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[\<clear>](clear-element-for-namedcaches.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[\<remove>](remove-element-for-namedcaches.md)

## Alphabetical list of \<runtime> elements

|Element|Description|
|-------------|-----------------|
|[\<add>](add-element-for-namedcaches.md)|Adds a named cache to the `namedCaches` collection for a memory cache.|
|[\<alwaysFlowImpersonationPolicy>](alwaysflowimpersonationpolicy-element.md)|Specifies that the Windows identity always flows across asynchronous points, regardless of how impersonation was performed.|
|[\<AppContextSwitchOverrides>](appcontextswitchoverrides-element.md)|Defines one or more switches used by the <xref:System.AppContext> class to provide an opt-out mechanism for new functionality.|
|[\<appDomainManagerAssembly>](appdomainmanagerassembly-element.md)|Specifies the assembly that provides the application domain manager for the default application domain in the process.|
|[\<appDomainManagerType>](appdomainmanagertype-element.md)|Specifies the type that serves as the application domain manager for the default application domain.|
|[\<appDomainResourceMonitoring>](appdomainresourcemonitoring-element.md)|Instructs the runtime to collect statistics on all application domains in the process for the life of the process.|
|[\<assemblyBinding>](assemblybinding-element-for-runtime.md)|Contains information about assembly version redirection and the locations of assemblies.|
|[\<assemblyIdentity>](assemblyidentity-element-for-runtime.md)|Contains identifying information about an assembly.|
|[\<bindingRedirect>](bindingredirect-element.md)|Redirects one assembly version to another.|
|[\<bypassTrustedAppStrongNames>](bypasstrustedappstrongnames-element.md)|Specifies whether strong name verification for trusted assemblies should be bypassed.|
|[\<clear>](clear-element-for-namedcaches.md)|Clears the `namedCaches` collection for a memory cache.|
|[\<codeBase>](codebase-element.md)|Specifies where the runtime can find an assembly.|
|[\<CompatSortNLSVersion>](compatsortnlsversion-element.md)|Specifies that the runtime should use legacy sorting behavior when performing string comparisons|
|[\<dependentAssembly>](dependentassembly-element.md)|Encapsulates binding policy and assembly location for each assembly.|
|[\<developmentMode>](developmentmode-element.md)|Specifies whether the runtime searches for assemblies in directories specified by the DEVPATH environment variable.|
|[\<disableCachingBindingFailures>](disablecachingbindingfailures-element.md)|Specifies whether the caching of binding failures, which is the default behavior in the .NET Framework 2.0, is disabled.|
|[\<disableCommitThreadStack>](disablecommitthreadstack-element.md)|Specifies whether the full thread stack is committed when a thread starts.|
|[\<disableFusionUpdatesFromADManager>](disablefusionupdatesfromadmanager-element.md)|Specifies whether the default behavior, which is to allow the runtime host to override configuration settings for an application domain, is disabled.|
|[\<EnableAmPmParseAdjustment>](enableampmparseadjustment-element.md)|Determines whether date and time parsing methods use an adjusted set of rules to parse date strings that contain only a day, month, hour, and AM/PM designator.|
|[\<enforceFIPSPolicy>](enforcefipspolicy-element.md)|Specifies whether to enforce a computer configuration requirement that cryptographic algorithms must comply with the Federal Information Processing Standards (FIPS).|
|[\<etwEnable>](etwenable-element.md)|Specifies whether to enable event tracing for Windows (ETW) for common language runtime events.|
|[\<forcePerformanceCounterUniqueSharedMemoryReads>](forceperformancecounteruniquesharedmemoryreads-element.md)|Specifies whether PerfCounter.dll uses the CategoryOptions registry setting in a .NET Framework version 1.1 application to determine whether to load performance counter data from category-specific shared memory or global memory.|
|[\<gcAllowVeryLargeObjects>](gcallowverylargeobjects-element.md)|On 64-bit platforms, enables arrays that are greater than 2 gigabytes (GB) in total size.|
|[\<gcConcurrent>](gcconcurrent-element.md)|Specifies whether the runtime runs garbage collection concurrently.|
|[\<GCCpuGroup>](gccpugroup-element.md)|Specifies whether garbage collection supports multiple CPU groups.|
|[\<GCHeapAffinitizeMask>](gcheapaffinitizemask-element.md)|Defines the affinity between GC heaps and individual processors.|
|[\<GCHeapCount>](gcheapcount-element.md)|Specifies the number of heaps/threads to use for server garbage collection.  |
|[\<GCLOHThreshold>](gclohthreshold-element.md)|Specifies the threshold size that causes objects to go on the large object heap (LOH).|
|[\<GCNoAffinitize>](gcnoaffinitize-element.md)|Specifies whether or not to affinitize server GC threads with CPUs.|
|[\<gcServer>](gcserver-element.md)|Specifies whether the common language runtime runs server garbage collection.|
|[\<generatePublisherEvidence>](generatepublisherevidence-element.md)|Specifies whether the runtime uses code access security (CAS) publisher policy.|
|[\<legacyCorruptedStateExceptionsPolicy>](legacycorruptedstateexceptionspolicy-element.md)|Specifies whether the runtime allows managed code to catch access violations and other corrupted state exceptions.|
|[\<legacyImpersonationPolicy>](legacyimpersonationpolicy-element.md)|Specifies that the Windows identity does not flow across asynchronous points, regardless of the flow settings for the execution context on the current thread.|
|[\<loadfromRemoteSources>](loadfromremotesources-element.md)|Specifies whether assemblies from remote sources are loaded as full trust.|
|[\<memoryCache>](memorycache-element-cache-settings.md)|Defines an element that is used to configure a cache that is based on the <xref:System.Runtime.Caching.MemoryCache> class.|
|[\<namedCaches>](namedcaches-element-cache-settings.md)|Contains a collection of configuration settings for the `namedCache` instance.|
|[\<NetFx40_LegacySecurityPolicy>](netfx40-legacysecuritypolicy-element.md)|Specifies whether the runtime uses legacy code access security (CAS) policy.|
|[\<NetFx40_PInvokeStackResilience>](netfx40-pinvokestackresilience-element.md)|Specifies whether the runtime automatically fixes incorrect platform invoke declarations at run time, at the cost of slower transitions between managed and unmanaged code.|
|[\<NetFx45_CultureAwareComparerGetHashCode_LongStrings>](netfx45-cultureawarecomparergethashcode-longstrings-element.md)|Specifies whether the runtime uses a fixed amount of memory to calculate hash codes for the <xref:System.StringComparer.GetHashCode%2A?displayProperty=nameWithType> method.|
|[\<PreferComInsteadOfManagedRemoting>](prefercominsteadofmanagedremoting-element.md)|Specifies that the runtime will use COM interop instead of remoting across application domain boundaries.|
|[\<probing>](probing-element.md)|Specifies subdirectories that the runtime searches when loading assemblies.|
|[\<publisherPolicy>](publisherpolicy-element.md)|Specifies whether the runtime applies publisher policy.|
|[\<qualifyAssembly>](qualifyassembly-element.md)|Specifies the full name of the assembly that should be dynamically loaded when a partial name is used.|
|[\<relativeBindForResources>](relativebindforresources-element.md)|Optimizes the probe for satellite assemblies.|
|[\<remove>](remove-element-for-namedcaches.md)|Removes a named cache entry from the `namedCaches` collection for a memory cache.|
|[\<runtime>](runtime-element.md)|Contains information about assembly binding and the behavior of garbage collection.|
|[\<shadowCopyTimeStampVerification>](shadowcopyverifybytimestamp-element.md)|Specifies whether shadow copying uses the default startup behavior introduced in the .NET Framework 4, or reverts to the startup behavior of earlier versions of the .NET Framework.|
|[\<supportPortability>](supportportability-element.md)|Specifies that an application can reference the same assembly in two different implementations of the .NET Framework, by disabling the default behavior that treats the assemblies as equivalent for application portability purposes.|
|[\<system.runtime.caching>](system-runtime-caching-element-cache-settings.md)|Provides configuration information for the default in-memory object cache.|
|[\<Thread_UseAllCpuGroups>](thread-useallcpugroups-element.md)|Specifies whether the runtime distributes managed threads across all CPU groups.|
|[\<ThrowUnobservedTaskExceptions>](throwunobservedtaskexceptions-element.md)|Specifies whether unhandled task exceptions should terminate a running process.|
|[\<TimeSpan_LegacyFormatMode>](runtime-element.md)|Specifies whether the runtime uses legacy formatting for <xref:System.TimeSpan> values.|
|[\<useLegacyJit>](uselegacyjit-element.md)|Determines whether the common language runtime uses the legacy 64-bit JIT compiler for just-in-time compilation.|
|[\<UseRandomizedStringHashAlgorithm>](userandomizedstringhashalgorithm-element.md)|Specifies whether the runtime calculates hash codes for strings on a per application domain basis.|
|[\<UseSmallInternalThreadStacks>](usesmallinternalthreadstacks-element.md)|Requests that the runtime use explicit stack sizes when it creates certain threads that it uses internally, instead of the default stack size.|

## See also

- [Configuration File Schema](../index.md)
- [To disable concurrent garbage collection](gcconcurrent-element.md#to-disable-background-garbage-collection)
- [Redirecting Assembly Versions](../../redirect-assembly-versions.md)
