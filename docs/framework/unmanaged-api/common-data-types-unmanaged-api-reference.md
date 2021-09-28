---
description: "Learn more about: Common Data Types (Unmanaged API Reference)"
title: "Common Data Types (Unmanaged API Reference)"
ms.date: "03/30/2017"
ms.assetid: e4ab2c4c-9433-4eba-9e9a-096de406cafb
---
# Common Data Types (Unmanaged API Reference)

This topic lists simple data types used by the unmanaged APIs for the .NET Framework that are defined by C/C++ `typedef` statements. These data types are typically aliases for C/C++ primitive data types. Typically, the values of these data types are opaque; that is, they are returned by a particular function or method so that they can be passed to other functions or methods without modification.  
  
|Data type|Definition|Defined in|Description|  
|---------------|----------------|----------------|-----------------|  
|AppDomainID|`typedef UINT_PTR AppDomainID;`|corprof.h|The identifier of an application domain.|  
|AssemblyID|`typedef UINT_PTR AssemblyID;`|corprof.h|The identifier of an assembly.|  
|ClassID|`typedef UINT_PTR ClassID;`|corprof.h|The identifier of a managed class.|  
|CLRDATA_ADDRESS|`typedef ULONG64 CLRDATA_ADDRESS;`|clrdata.h|A 64-bit memory address.|
|CLRDATA_ENUM|`typedef ULONG64 CLRDATA_ADDRESS;`|Not Available|A 64-bit memory address.|
|CONNID|`typedef DWORD CONNID;`|cordebug.h, mscoree.h|The connection identifier for a thread that is connected to an instance of Microsoft SQL Server.|  
|ContextID|`typedef UINT_PTR ContextID;`|corprof.h|The identifier of the context associated with a particular managed thread.|  
|COR_PRF_ELT_INFO|`typedef UINT_PTR COR_PRF_ELT_INFO;`|corprof.h|An opaque handle that represents information about a particular stack frame.|  
|COR_PRF_FRAME_INFO|`typedef UINT_PTR COR_PRF_FRAME_INFO;`|corprof.h|An opaque handle that points to a stack frame. It is valid only during the callback to which it is passed.|  
|CORDB_ADDRESS|`typedef ULONG64 CORDB_ADDRESS;`|cordebug.h|An address in memory.|  
|CORDB_CONTINUE_STATUS|`typedef DWORD CORDB_CONTINUE_STATUS;`|cordebug.h|The continuation status.|  
|CORDB_REGISTER|`typedef ULONG64 CORDB_REGISTER;`|cordebug.h|The value of a CPU register.|
|FunctionID|`typedef UINT_PTR FunctionID;`|corprof.h|The identifier of a function or method.|  
|GCHandleID|`typedef UINT_PTR GCHandleID;`|corprof.h|A garbage collection handle.|  
|mdMethodDef|`typedef mdToken mdMethodDef;`|cordebug.h|A method definition token.|
|mdToken|`typedef UINT32 mdToken;`|corprof.h|A metadata token (a row in a metadata table).|  
|ModuleID|`typedef UINT_PTR ModuleID;`|corprof.h|The identifier of an assembly module.|  
|ObjectID|`typedef UINT_PTR ObjectID;`|corprof.h|The identifier of an object.|  
|PCCOR_SIGNATURE|`typedef SIZE_T PCCOR_SIGNATURE;`|cordebug.h|A pointer to a member or metadata signature.|
|ProcessID|`typedef UINT_PTR ProcessID;`|corprof.h|The identifier of a managed process.|  
|ReJITID|`typedef UINT_PTR ReJITID;`|corprof.h|The identifier of a jitted function.|  
|SIZE_T|`typedef ULONG_PTR SIZE_T;`|corsym.h|A pointer to a 64-bit memory address.|
|TASKID|`typedef UINT64 TASKID;`|cordebug.h, mscoree.h|The identifier of an [ICLRTask](./hosting/iclrtask-interface.md) instance.|  
|ThreadID|`typedef UINT_PTR ThreadID;`|corprof.h|The identifier of a managed thread.|  
  
## See also

- [Unmanaged API Reference](index.md)
