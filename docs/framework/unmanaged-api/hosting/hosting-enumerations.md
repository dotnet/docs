---
description: "Learn more about: Hosting Enumerations"
title: "Hosting Enumerations"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "unmanaged enumerations [.NET Framework], hosting"
  - "enumerations [.NET Framework hosting]"
  - "hosting enumerations [.NET Framework]"
ms.assetid: e09131eb-1f7d-4f52-ae42-7393e9b62ef6
---
# Hosting Enumerations

This section describes the unmanaged enumerations that the hosting API uses.  
  
## In This Section  

 [CLSID_RESOLUTION_FLAGS Enumeration](clsid-resolution-flags-enumeration.md)  
 Contains values that indicate how the common language runtime (CLR) should resolve a `CLSID`.  
  
 [COR_GC_STAT_TYPES Enumeration](cor-gc-stat-types-enumeration.md)  
 Specifies the statistics to be recorded for a garbage collection.  
  
 [COR_GC_THREAD_STATS_TYPES Enumeration](cor-gc-thread-stats-types-enumeration.md)  
 Indicates the garbage collection statistics for a thread.  
  
 [EApiCategories Enumeration](eapicategories-enumeration.md)  
 Describes the categories of capabilities that the host can block from running in partially trusted code.  
  
 [EBindPolicyLevels Enumeration](ebindpolicylevels-enumeration.md)  
 Provides flags that specify the level at which to apply or modify assembly policy.  
  
 [ECLRAssemblyIdentityFlags Enumeration](eclrassemblyidentityflags-enumeration.md)  
 Indicates the type of an assembly's identity.  
  
 [EClrEvent Enumeration](eclrevent-enumeration.md)  
 Describes the CLR events for which the host can register callbacks.  
  
 [EClrFailure Enumeration](eclrfailure-enumeration.md)  
 Describes the set of failures for which a host can set policy actions.  
  
 [EClrOperation Enumeration](eclroperation-enumeration.md)  
 Describes the set of operations for which a host can apply policy actions.  
  
 [EClrUnhandledException Enumeration](eclrunhandledexception-enumeration.md)  
 Describes the available options for managing exceptions that are unhandled in user code.  
  
 [EContextType Enumeration](econtexttype-enumeration.md)  
 Describes the security context of the currently executing thread.  
  
 [ECustomDumpFlavor Enumeration](ecustomdumpflavor-enumeration.md)  
 Contains values that indicate which items to include in a custom subset of a heap dump when reporting errors.  
  
 [ECustomDumpItemKind Enumeration](ecustomdumpitemkind-enumeration.md)  
 Reserved for future extension of the [CustomDumpItem Structure](customdumpitem-structure.md) structure.  
  
 [EHostApplicationPolicy Enumeration](ehostapplicationpolicy-enumeration.md)  
 Indicates how to modify an [IHostAssemblyManager Interface](ihostassemblymanager-interface.md) interface object. This enumeration has been deprecated.  
  
 [EHostBindingPolicyModifyFlags Enumeration](ehostbindingpolicymodifyflags-enumeration.md)  
 Allows the host to specify the type of redirection the CLR should perform when applying policy modifications from a source assembly to a target assembly.  
  
 [EInitializeNewDomainFlags Enumeration](einitializenewdomainflags-enumeration.md)  
 Enables the host to provide the runtime with information about the initialization of an application domain.  
  
 [EMemoryAvailable Enumeration](ememoryavailable-enumeration.md)  
 Contains values that indicate the amount of free physical memory on the computer.  
  
 [EMemoryCriticalLevel Enumeration](ememorycriticallevel-enumeration.md)  
 Contains values that indicate the impact of a failure when a specific memory allocation has been requested but cannot be satisfied.  
  
 [EPolicyAction Enumeration](epolicyaction-enumeration.md)  
 Describes the policy actions the host can set for operations described by [EClrOperation Enumeration](eclroperation-enumeration.md) and failures described by [EClrFailure Enumeration](eclrfailure-enumeration.md).  
  
 [ESymbolReadingPolicy Enumeration](esymbolreadingpolicy-enumeration.md)  
 Contains values that set the policy for reading program database (PDB) files.  
  
 [ETaskType Enumeration](etasktype-enumeration.md)  
 Contains values that indicate the kind of task represented by an [ICLRTask Interface](iclrtask-interface.md) or an [IHostTask Interface](ihosttask-interface.md) interface.  
  
 [HOST_TYPE Enumeration](host-type-enumeration.md)  
 Contains values that specify the type of host that is launching an application.  
  
 [MALLOC_TYPE Enumeration](malloc-type-enumeration.md)  
 Contains values that specify the characteristics of the memory that is being allocated.  
  
 [METAHOST_CONFIG_FLAGS Enumeration](metahost-config-flags-enumeration.md)  
 Describes the possible flags returned in the `pdwConfigFlags` parameter of the [ICLRMetaHostPolicy::GetRequestedRuntime](iclrmetahostpolicy-getrequestedruntime-method.md) method.  
  
 [METAHOST_POLICY_FLAGS Enumeration](metahost-policy-flags-enumeration.md)  
 Provides binding policies that are common to most runtime hosts.  
  
 [RUNTIME_INFO_FLAGS Enumeration](runtime-info-flags-enumeration.md)  
 Contains values that indicate what information about the CLR should be returned.  
  
 [StackOverflowType Enumeration](stackoverflowtype-enumeration.md)  
 Contains values that indicate the underlying cause of a stack overflow event.  
  
 [STARTUP_FLAGS Enumeration](startup-flags-enumeration.md)  
 Contains values that indicate the startup behavior of the CLR.  
  
 [ValidatorFlags Enumeration](validatorflags-enumeration.md)  
 Contains values that indicate the type of validation that should be performed in a call to [Validate Method](iclrvalidator-validate-method.md).  
  
 [WAIT_OPTION Enumeration](wait-option-enumeration.md)  
 Indicates the action a host should take if an operation requested by the CLR blocks.  
  
## Related Sections  

 [Hosting Coclasses](hosting-coclasses.md)  
  
 [Hosting Interfaces](hosting-interfaces.md)  
  
 [Deprecated CLR Hosting Functions](deprecated-clr-hosting-functions.md)  
  
 [Hosting Structures](hosting-structures.md)
