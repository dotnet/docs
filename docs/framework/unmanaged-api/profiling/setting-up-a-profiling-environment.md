---
title: "Setting Up a Profiling Environment"
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
  - "environment variables, profiling API"
  - "profiling API [.NET Framework], setting up environment"
  - "COR_PROFILER environment variable"
  - "Windows Service applications, profiling"
  - "profiling API [.NET Framework], Windows Service applications"
  - "COR_ENABLE_PROFILING environment variable"
  - "profiling API [.NET Framework], enabling"
ms.assetid: fefca07f-7555-4e77-be86-3c542e928312
caps.latest.revision: 29
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Setting Up a Profiling Environment
> [!NOTE]
>  There have been substantial changes to profiling in the [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)].  
  
 When a managed process (application or service) starts, it loads the common language runtime (CLR). When the CLR is initialized, it evaluates the following two environmental variables to decide whether the process should connect to a profiler:  
  
-   COR_ENABLE_PROFILING: The CLR connects to a profiler only if this environment variable exists and is set to 1.  
  
-   COR_PROFILER: If the COR_ENABLE_PROFILING check passes, the CLR connects to the profiler that has this CLSID or ProgID, which must have been stored previously in the registry. The COR_PROFILER environment variable is defined as a string, as shown in the following two examples.  
  
    ```  
    set COR_PROFILER={32E2F4DA-1BEA-47ea-88F9-C5DAF691C94A}  
    set COR_PROFILER="MyProfiler"  
    ```  
  
 To profile a CLR application, you must set the COR_ENABLE_PROFILING and COR_PROFILER environment variables before you run the application. You must also make sure that the profiler DLL is registered.  
  
> [!NOTE]
>  Starting with the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)], profilers do not have to be registered.  
  
> [!NOTE]
>  To use .NET Framework versions 2.0, 3.0, and 3.5 profilers in the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)] and later versions, you must set the COMPLUS_ProfAPI_ProfilerCompatibilitySetting environment variable.  
  
## Environment Variable Scope  
 How you set the COR_ENABLE_PROFILING and COR_PROFILER environment variables will determine their scope of influence. You can set these variables in one of the following ways:  
  
-   If you set the variables in an [ICorDebug::CreateProcess](../../../../docs/framework/unmanaged-api/debugging/icordebug-createprocess-method.md) call, they will apply only to the application that you are running at the time. (They will also apply to other applications started by that application that inherit the environment.)  
  
-   If you set the variables in a Command Prompt window, they will apply to all applications that are started from that window.  
  
-   If you set the variables at the user level, they will apply to all applications that you start with File Explorer. A Command Prompt window that you open after you set the variables will have these environment settings, and so will any application that you start from that window. To set environment variables at the user level, right-click **My Computer**, click **Properties**, click the **Advanced** tab, click **Environment Variables**, and add the variables to the **User variables** list.  
  
-   If you set the variables at the computer level, they will apply to all applications that are started on that computer. A Command Prompt window that you open on that computer will have these environment settings, and so will any application that you start from that window. This means that every managed process on that computer will start with your profiler. To set environment variables at the computer level, right-click **My Computer**, click **Properties**, click the **Advanced** tab, click **Environment Variables**, add the variables to the **System variables** list, and then restart your computer. After restarting, the variables will be available system-wide.  
  
 If you are profiling a Windows Service, you must restart your computer after you set the environment variables and register the profiler DLL. For more information about these considerations, see the section [Profiling a Windows Service](#windows_service).  
  
## Additional Considerations  
  
-   The profiler class implements the [ICorProfilerCallback](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md) and [ICorProfilerCallback2](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback2-interface.md) interfaces. In the .NET Framework version 2.0, a profiler must implement `ICorProfilerCallback2`. If it does not, `ICorProfilerCallback2` will not be loaded.  
  
-   Only one profiler can profile a process at one time in a given environment. You can register two different profilers in different environments, but each must profile separate processes. The profiler must be implemented as an in-process COM server DLL, which is mapped into the same address space as the process that is being profiled. This means that the profiler runs in-process. The .NET Framework does not support any other type of COM server. For example, if a profiler wants to monitor applications from a remote computer, it must implement collector agents on each computer. These agents will batch results and communicate them to the central data collection computer.  
  
-   Because the profiler is a COM object that is instantiated in-process, each profiled application will have its own copy of the profiler. Therefore, a single profiler instance does not have to handle data from multiple applications. However, you will have to add logic to the profiler's logging code to prevent log file overwrites from other profiled applications.  
  
## Initializing the Profiler  
 When both environment variable checks pass, the CLR creates an instance of the profiler in a similar manner to the COM `CoCreateInstance` function. The profiler is not loaded through a direct call to `CoCreateInstance`. Therefore, a call to `CoInitialize`, which requires setting the threading model, is avoided. The CLR then calls the [ICorProfilerCallback::Initialize](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-initialize-method.md) method in the profiler. The signature of this method is as follows.  
  
```  
HRESULT Initialize(IUnknown *pICorProfilerInfoUnk)  
```  
  
 The profiler must query `pICorProfilerInfoUnk` for an [ICorProfilerInfo](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md) or [ICorProfilerInfo2](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo2-interface.md) interface pointer and save it so that it can request more information later during profiling.  
  
## Setting Event Notifications  
 The profiler then calls the [ICorProfilerInfo::SetEventMask](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-seteventmask-method.md) method to specify which categories of notifications it is interested in. For example, if the profiler is interested only in function enter and leave notifications and garbage collection notifications, it specifies the following.  
  
```  
ICorProfilerInfo* pInfo;  
pICorProfilerInfoUnk->QueryInterface(IID_ICorProfilerInfo, (void**)&pInfo);  
pInfo->SetEventMask(COR_PRF_MONITOR_ENTERLEAVE | COR_PRF_MONITOR_GC)  
```  
  
 By setting the notifications mask in this manner, the profiler can limit which notifications it receives. This approach helps the user build a simple or special-purpose profiler. It also reduces CPU time that would be wasted sending notifications that the profiler would just ignore.  
  
 Certain profiler events are immutable. This means that as soon as these events are set in the `ICorProfilerCallback::Initialize` callback, they cannot be turned off and new events cannot be turned on. Attempts to change an immutable event will result in `ICorProfilerInfo::SetEventMask` returning a failed HRESULT.  
  
<a name="windows_service"></a>   
## Profiling a Windows Service  
 Profiling a Windows Service is like profiling a common language runtime application. Both profiling operations are enabled through environment variables. Because a Windows Service is started when the operating system starts, the environment variables discussed previously in this topic must already be present and set to the required values before the system starts. In addition, the profiling DLL must already be registered on the system.  
  
 After you set the COR_ENABLE_PROFILING and COR_PROFILER environment variables and register the profiler DLL, you should restart the target computer so that the Windows Service can detect those changes.  
  
 Note that these changes will enable profiling on a system-wide basis. To prevent every managed application that subsequently runs from being profiled, you should delete the system environment variables after you restart the target computer.  
  
 This technique also leads to every CLR process getting profiled. The profiler should add logic to its [ICorProfilerCallback::Initialize](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-initialize-method.md) callback to detect whether the current process is of interest. If it is not, the profiler can fail the callback without performing the initialization.  
  
## See Also  
 [Profiling Overview](../../../../docs/framework/unmanaged-api/profiling/profiling-overview.md)
