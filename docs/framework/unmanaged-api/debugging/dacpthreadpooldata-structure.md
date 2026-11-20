---
description: "Learn more about: DacpThreadpoolData Structure"
title: "DacpThreadpoolData Structure"
ms.date: "07/30/2026"
api.name:
  - "DacpThreadpoolData Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpThreadpoolData Structure"
helpviewer.keywords:
  - "DacpThreadpoolData Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# DacpThreadpoolData Structure

Defines a transport buffer for runtime thread pool information.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
struct DacpThreadpoolData : ZeroInit<DacpThreadpoolData>
{
    LONG cpuUtilization;    
    int NumIdleWorkerThreads;
    int NumWorkingWorkerThreads;
    int NumRetiredWorkerThreads;
    LONG MinLimitTotalWorkerThreads;
    LONG MaxLimitTotalWorkerThreads;

    CLRDATA_ADDRESS FirstUnmanagedWorkRequest;

    CLRDATA_ADDRESS HillClimbingLog;
    int HillClimbingLogFirstIndex;
    int HillClimbingLogSize;

    DWORD NumTimers;

    LONG   NumCPThreads;
    LONG   NumFreeCPThreads;
    LONG   MaxFreeCPThreads; 
    LONG   NumRetiredCPThreads;
    LONG   MaxLimitTotalCPThreads;
    LONG   CurrentLimitTotalCPThreads;
    LONG   MinLimitTotalCPThreads;

    CLRDATA_ADDRESS AsyncTimerCallbackCompletionFPtr;
    
    HRESULT Request(ISOSDacInterface *sos)
    {
        return sos->GetThreadpoolData(this);
    }
};
```

## Members

| Member | Description |
| ------ | ----------- |
| `cpuUtilization` | The CPU utilization value used by the thread pool. |
| `NumIdleWorkerThreads` | The number of idle worker threads. |
| `NumWorkingWorkerThreads` | The number of active worker threads. |
| `NumRetiredWorkerThreads` | The number of retired worker threads. |
| `MinLimitTotalWorkerThreads` | The minimum total worker thread limit. |
| `MaxLimitTotalWorkerThreads` | The maximum total worker thread limit. |
| `FirstUnmanagedWorkRequest` | The address of the first unmanaged work request. |
| `HillClimbingLog` | The address of the hill climbing log. |
| `HillClimbingLogFirstIndex` | The first index in the hill climbing log. |
| `HillClimbingLogSize` | The size of the hill climbing log. |
| `NumTimers` | The number of timers. |
| `NumCPThreads` | The number of completion port threads. |
| `NumFreeCPThreads` | The number of free completion port threads. |
| `MaxFreeCPThreads` | The maximum number of free completion port threads. |
| `NumRetiredCPThreads` | The number of retired completion port threads. |
| `MaxLimitTotalCPThreads` | The maximum total completion port thread limit. |
| `CurrentLimitTotalCPThreads` | The current total completion port thread limit. |
| `MinLimitTotalCPThreads` | The minimum total completion port thread limit. |
| `AsyncTimerCallbackCompletionFPtr` | The address of the asynchronous timer callback completion function pointer. |
| `Request` | Populates the structure by calling `ISOSDacInterface::GetThreadpoolData`. |

## Remarks

This structure lives inside the runtime and is not exposed through any headers or library files. To use it, define the structure as specified above.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [Debugging Structures](debugging-structures.md)
