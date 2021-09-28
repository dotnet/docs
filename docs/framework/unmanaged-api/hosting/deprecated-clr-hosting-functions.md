---
description: "Learn more about: Deprecated CLR Hosting Functions"
title: "Deprecated CLR Hosting Functions"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - ".NET Framework 1.1, hosting global static functions"
  - "global static functions [.NET Framework hosting], version 2.0"
  - ".NET Framework 2.0, hosting global static functions"
  - "hosting global static functions [.NET Framework], version 2.0"
ms.assetid: 91fbbb35-e543-4814-b806-371cebae8c5a
---
# Deprecated CLR Hosting Functions

This section describes the unmanaged global static functions that earlier versions of the hosting API used.  
  
 With the exception of the infrastructure functions (`_Cor*` functions), which are used only by the .NET Framework, these functions have been deprecated in the .NET Framework 4.  
  
## Activation functions  

 [ClrCreateManagedInstance Function](clrcreatemanagedinstance-function.md)  
 Deprecated. Creates an instance of the specified managed type.  
  
 [CoInitializeCor Function](coinitializecor-function.md)  
 Obsolete. To initialize the common language runtime (CLR), use either [CorBindToRuntimeEx](corbindtoruntimeex-function.md) or [CorBindToCurrentRuntime](corbindtocurrentruntime-function.md).  
  
 [CoInitializeEE Function](coinitializeee-function.md)  
 Deprecated. Ensures that the CLR execution engine is loaded into a process. Use the [ICLRRuntimeHost::Start](iclrruntimehost-start-method.md) method instead.  
  
 [CorBindToCurrentRuntime Function](corbindtocurrentruntime-function.md)  
 Deprecated. Loads the common language runtime (CLR) into a process by using version information stored in an XML file.  
  
 [CorBindToRuntime Function](corbindtoruntime-function.md)  
 Deprecated. Enables unmanaged hosts to load the CLR into a process.  
  
 [CorBindToRuntimeByCfg Function](corbindtoruntimebycfg-function.md)  
 Deprecated. Loads the CLR into a process by using version information that is read from an XML file.  
  
 [CorBindToRuntimeEx Function](corbindtoruntimeex-function.md)  
 Deprecated. Enables unmanaged hosts to load the CLR into a process, and allows you to set flags to specify the behavior of the CLR.  
  
 [CorBindToRuntimeHost Function](corbindtoruntimehost-function.md)  
 Deprecated. Enables hosts to load a specified version of the CLR into a process.  
  
 [GetCORRequiredVersion Function](getcorrequiredversion-function.md)  
 Deprecated. Gets the required CLR version number.  
  
 [GetCORSystemDirectory Function](getcorsystemdirectory-function.md)  
 Deprecated. Returns the installation directory of the CLR that is loaded into the process.  
  
 [GetRealProcAddress Function](getrealprocaddress-function.md)  
 Deprecated. Gets the address of the specified function that is exported from the latest installed version of the CLR.  
  
 [GetRequestedRuntimeInfo Function](getrequestedruntimeinfo-function.md)  
 Deprecated. Gets version and directory information about the CLR requested by an application.  
  
## CLR version functions  

 The functions in this section return a CLR version; they do not activate the CLR.  
  
 [GetCORVersion Function](getcorversion-function.md)  
 Deprecated. Returns the version number of the CLR that is running in the current process.  
  
 [GetFileVersion Function](getfileversion-function.md)  
 Deprecated. Gets the CLR version information of the specified file, using the specified buffer.  
  
 [GetRequestedRuntimeVersion Function](getrequestedruntimeversion-function.md)  
 Deprecated. Gets the version number of the CLR requested by the specified application. If that version is not installed, gets the most recent version that is installed before the requested version.  
  
 [GetRequestedRuntimeVersionForCLSID Function](getrequestedruntimeversionforclsid-function.md)  
 Deprecated. Gets the appropriate CLR version information for the class with the specified CLSID.  
  
 [GetVersionFromProcess Function](getversionfromprocess-function.md)  
 Deprecated. Gets the version number of the CLR that is associated with the specified process handle.  
  
 [LockClrVersion Function](lockclrversion-function.md)  
 Deprecated. Allows the host to determine which version of the CLR will be used within the process before explicitly initializing the CLR.  
  
## Hosting functions  

 [CallFunctionShim Function](callfunctionshim-function.md)  
 Deprecated. Makes a call to the function that has the specified name and parameters in the specified library.  
  
 [CoEEShutDownCOM Function](coeeshutdowncom-function.md)  
 Deprecated. Unloads a COM assembly from the process.  
  
 [CorExitProcess Function](corexitprocess-function.md)  
 Deprecated. Shuts down the current unmanaged process.  
  
 [CorLaunchApplication Function](corlaunchapplication-function.md)  
 Deprecated. Starts the application at the specified network path, using the specified manifests and other application data.  
  
 [CorMarkThreadInThreadPool Function](cormarkthreadinthreadpool-function.md)  
 Deprecated. Marks the currently executing thread-pool thread for the execution of managed code. Starting with the .NET Framework version 2.0, this function has no effect. It is not required, and can be removed from your code.  
  
 [CoUninitializeCor Function](couninitializecor-function.md)  
 Obsolete. The CLR cannot be unloaded from a process.  
  
 [CoUninitializeEE Function](couninitializeee-function.md)  
 Obsolete.  
  
 [CreateDebuggingInterfaceFromVersion Function](createdebugginginterfacefromversion-function.md)  
 Deprecated. Creates an [ICorDebug](../debugging/icordebug-interface.md) object based on the specified version information.  
  
 [CreateICeeFileGen Function](createiceefilegen-function.md)  
 Deprecated. Creates an [ICeeFileGen](iceefilegen-class.md) object.  
  
 [DestroyICeeFileGen Function](destroyiceefilegen-function.md)  
 Deprecated. Destroys an [ICeeFileGen](iceefilegen-class.md) object.  
  
 [FExecuteInAppDomainCallback Function Pointer](fexecuteinappdomaincallback-function-pointer.md)  
 Deprecated. Points to a function that the CLR calls to execute managed code.  
  
 [FLockClrVersionCallback Function Pointer](flockclrversioncallback-function-pointer.md)  
 Deprecated. Points to a function that the CLR calls to notify the host that initialization has either started or completed.  
  
 [GetCLRIdentityManager Function](getclridentitymanager-function.md)  
 Deprecated. Gets a pointer to an interface that allows the CLR to manage identities.  
  
 [LoadLibraryShim Function](loadlibraryshim-function.md)  
 Deprecated. Loads a specified version of a .NET Framework DLL.  
  
 [LoadStringRC Function](loadstringrc-function.md)  
 Deprecated. Translates an HRESULT value into an error message by using the default culture of the current thread.  
  
 [LoadStringRCEx Function](loadstringrcex-function.md)  
 Deprecated. Translates an HRESULT value to an appropriate error message for the specified culture.  
  
 [LPOVERLAPPED_COMPLETION_ROUTINE Function Pointer](lpoverlapped-completion-routine-function-pointer.md)  
 Deprecated. Points to a function that notifies the host when an overlapped (that is, asynchronous) I/O to a device has completed.  
  
 [LPTHREAD_START_ROUTINE Function Pointer](lpthread-start-routine-function-pointer.md)  
 Deprecated. Points to a function that notifies the host that a thread has started to execute.  
  
 [RunDll32ShimW Function](rundll32shimw-function.md)  
 Deprecated. Executes the specified command.  
  
 [WAITORTIMERCALLBACK Function Pointer](waitortimercallback-function-pointer.md)  
 Deprecated. Points to a function that notifies the host that a wait handle has either been signaled or timed out.  
  
## Infrastructure functions  

 The functions in this section are for use by the .NET Framework only.  
  
 [_CorDllMain Function](cordllmain-function.md)  
 Initializes the CLR, locates the managed entry point in the DLL assembly's CLR header, and begins execution.  
  
 [_CorExeMain Function](corexemain-function.md)  
 Initializes the CLR, locates the managed entry point in the executable assembly's CLR header, and begins execution.  
  
 [_CorExeMain2 Function](corexemain2-function.md)  
 Executes the entry point in the specified memory-mapped code. This function is called by the operating system loader.  
  
 [_CorImageUnloading Function](corimageunloading-function.md)  
 Notifies the loader when the managed module images are unloaded.  
  
 [_CorValidateImage Function](corvalidateimage-function.md)  
 Validates managed module images, and notifies the operating system loader after they have been loaded.  
  
## See also

- [.NET Framework 4 Hosting Global Static Functions](net-framework-4-hosting-global-static-functions.md)
