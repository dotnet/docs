---
title: "Hosting Enumerations"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
helpviewer_keywords: 
  - "unmanaged enumerations [.NET Framework], hosting"
  - "enumerations [.NET Framework hosting]"
  - "hosting enumerations [.NET Framework]"
ms.assetid: e09131eb-1f7d-4f52-ae42-7393e9b62ef6
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Hosting Enumerations
This section describes the unmanaged enumerations that the hosting API uses.  
  
## In This Section  
 [CLSID_RESOLUTION_FLAGS Enumeration](../../../../docs/framework/unmanaged-api/hosting/clsid-resolution-flags-enumeration.md)  
 Contains values that indicate how the common language runtime (CLR) should resolve a `CLSID`.  
  
 [COR_GC_STAT_TYPES Enumeration](../../../../docs/framework/unmanaged-api/hosting/cor-gc-stat-types-enumeration.md)  
 Specifies the statistics to be recorded for a garbage collection.  
  
 [COR_GC_THREAD_STATS_TYPES Enumeration](../../../../docs/framework/unmanaged-api/hosting/cor-gc-thread-stats-types-enumeration.md)  
 Indicates the garbage collection statistics for a thread.  
  
 [EApiCategories Enumeration](../../../../docs/framework/unmanaged-api/hosting/eapicategories-enumeration.md)  
 Describes the categories of capabilities that the host can block from running in partially trusted code.  
  
 [EBindPolicyLevels Enumeration](../../../../docs/framework/unmanaged-api/hosting/ebindpolicylevels-enumeration.md)  
 Provides flags that specify the level at which to apply or modify assembly policy.  
  
 [ECLRAssemblyIdentityFlags Enumeration](../../../../docs/framework/unmanaged-api/hosting/eclrassemblyidentityflags-enumeration.md)  
 Indicates the type of an assembly's identity.  
  
 [EClrEvent Enumeration](../../../../docs/framework/unmanaged-api/hosting/eclrevent-enumeration.md)  
 Describes the CLR events for which the host can register callbacks.  
  
 [EClrFailure Enumeration](../../../../docs/framework/unmanaged-api/hosting/eclrfailure-enumeration.md)  
 Describes the set of failures for which a host can set policy actions.  
  
 [EClrOperation Enumeration](../../../../docs/framework/unmanaged-api/hosting/eclroperation-enumeration.md)  
 Describes the set of operations for which a host can apply policy actions.  
  
 [EClrUnhandledException Enumeration](../../../../docs/framework/unmanaged-api/hosting/eclrunhandledexception-enumeration.md)  
 Describes the available options for managing exceptions that are unhandled in user code.  
  
 [EContextType Enumeration](../../../../docs/framework/unmanaged-api/hosting/econtexttype-enumeration.md)  
 Describes the security context of the currently executing thread.  
  
 [ECustomDumpFlavor Enumeration](../../../../docs/framework/unmanaged-api/hosting/ecustomdumpflavor-enumeration.md)  
 Contains values that indicate which items to include in a custom subset of a heap dump when reporting errors.  
  
 [ECustomDumpItemKind Enumeration](../../../../docs/framework/unmanaged-api/hosting/ecustomdumpitemkind-enumeration.md)  
 Reserved for future extension of the [CustomDumpItem Structure](../../../../docs/framework/unmanaged-api/hosting/customdumpitem-structure.md) structure.  
  
 [EHostApplicationPolicy Enumeration](../../../../docs/framework/unmanaged-api/hosting/ehostapplicationpolicy-enumeration.md)  
 Indicates how to modify an [IHostAssemblyManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostassemblymanager-interface.md) interface object. This enumeration has been deprecated.  
  
 [EHostBindingPolicyModifyFlags Enumeration](../../../../docs/framework/unmanaged-api/hosting/ehostbindingpolicymodifyflags-enumeration.md)  
 Allows the host to specify the type of redirection the CLR should perform when applying policy modifications from a source assembly to a target assembly.  
  
 [EInitializeNewDomainFlags Enumeration](../../../../docs/framework/unmanaged-api/hosting/einitializenewdomainflags-enumeration.md)  
 Enables the host to provide the runtime with information about the initialization of an application domain.  
  
 [EMemoryAvailable Enumeration](../../../../docs/framework/unmanaged-api/hosting/ememoryavailable-enumeration.md)  
 Contains values that indicate the amount of free physical memory on the computer.  
  
 [EMemoryCriticalLevel Enumeration](../../../../docs/framework/unmanaged-api/hosting/ememorycriticallevel-enumeration.md)  
 Contains values that indicate the impact of a failure when a specific memory allocation has been requested but cannot be satisfied.  
  
 [EPolicyAction Enumeration](../../../../docs/framework/unmanaged-api/hosting/epolicyaction-enumeration.md)  
 Describes the policy actions the host can set for operations described by [EClrOperation Enumeration](../../../../docs/framework/unmanaged-api/hosting/eclroperation-enumeration.md) and failures described by [EClrFailure Enumeration](../../../../docs/framework/unmanaged-api/hosting/eclrfailure-enumeration.md).  
  
 [ESymbolReadingPolicy Enumeration](../../../../docs/framework/unmanaged-api/hosting/esymbolreadingpolicy-enumeration.md)  
 Contains values that set the policy for reading program database (PDB) files.  
  
 [ETaskType Enumeration](../../../../docs/framework/unmanaged-api/hosting/etasktype-enumeration.md)  
 Contains values that indicate the kind of task represented by an [ICLRTask Interface](../../../../docs/framework/unmanaged-api/hosting/iclrtask-interface.md) or an [IHostTask Interface](../../../../docs/framework/unmanaged-api/hosting/ihosttask-interface.md) interface.  
  
 [HOST_TYPE Enumeration](../../../../docs/framework/unmanaged-api/hosting/host-type-enumeration.md)  
 Contains values that specify the type of host that is launching an application.  
  
 [MALLOC_TYPE Enumeration](../../../../docs/framework/unmanaged-api/hosting/malloc-type-enumeration.md)  
 Contains values that specify the characteristics of the memory that is being allocated.  
  
 [METAHOST_CONFIG_FLAGS Enumeration](../../../../docs/framework/unmanaged-api/hosting/metahost-config-flags-enumeration.md)  
 Describes the possible flags returned in the `pdwConfigFlags` parameter of the [ICLRMetaHostPolicy::GetRequestedRuntime](../../../../docs/framework/unmanaged-api/hosting/iclrmetahostpolicy-getrequestedruntime-method.md) method.  
  
 [METAHOST_POLICY_FLAGS Enumeration](../../../../docs/framework/unmanaged-api/hosting/metahost-policy-flags-enumeration.md)  
 Provides binding policies that are common to most runtime hosts.  
  
 [RUNTIME_INFO_FLAGS Enumeration](../../../../docs/framework/unmanaged-api/hosting/runtime-info-flags-enumeration.md)  
 Contains values that indicate what information about the CLR should be returned.  
  
 [StackOverflowType Enumeration](../../../../docs/framework/unmanaged-api/hosting/stackoverflowtype-enumeration.md)  
 Contains values that indicate the underlying cause of a stack overflow event.  
  
 [STARTUP_FLAGS Enumeration](../../../../docs/framework/unmanaged-api/hosting/startup-flags-enumeration.md)  
 Contains values that indicate the startup behavior of the CLR.  
  
 [ValidatorFlags Enumeration](../../../../docs/framework/unmanaged-api/hosting/validatorflags-enumeration.md)  
 Contains values that indicate the type of validation that should be performed in a call to [Validate Method](../../../../docs/framework/unmanaged-api/hosting/iclrvalidator-validate-method.md).  
  
 [WAIT_OPTION Enumeration](../../../../docs/framework/unmanaged-api/hosting/wait-option-enumeration.md)  
 Indicates the action a host should take if an operation requested by the CLR blocks.  
  
## Related Sections  
 [Hosting Coclasses](../../../../docs/framework/unmanaged-api/hosting/hosting-coclasses.md)  
  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)  
  
 [Deprecated CLR Hosting Functions](../../../../docs/framework/unmanaged-api/hosting/deprecated-clr-hosting-functions.md)  
  
 [Hosting Structures](../../../../docs/framework/unmanaged-api/hosting/hosting-structures.md)
