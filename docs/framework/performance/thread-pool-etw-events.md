---
title: "Thread Pool ETW Events"
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
  - "thread pool events [.NET Framework]"
  - "ETW, thread pool events (CLR)"
ms.assetid: f2a21e3a-3b6c-4433-97f3-47ff16855ecc
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Thread Pool ETW Events
<a name="top"></a> These events collect information about worker and I/O threads.  
  
 There are two groups of thread pool events:  
  
-   [Worker thread pool events](#worker), which provide information about how an application uses the thread pool, and the effect of workloads on concurrency control.  
  
-   [I/O thread pool events](#io), which provide information about I/O threads that are created, retired, unretired, or terminated in the thread pool.  
  
<a name="worker"></a>   
## Worker Thread Pool Events  
 These events relate to the runtime's worker thread pool and provide notifications for thread events (for example, when a thread is created or stopped). The worker thread pool uses an adaptive algorithm for concurrency control, where the number of threads is calculated based on the measured throughput. Worker thread pool events can be used to understand how an application is using the thread pool, and the effect that certain workloads may have on concurrency control.  
  
### ThreadPoolWorkerThreadStart and ThreadPoolWorkerThreadStop  
 The following table shows the keyword and level for these events. (For more information, see [CLR ETW Keywords and Levels](../../../docs/framework/performance/clr-etw-keywords-and-levels.md).)  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ThreadingKeyword` (0x10000)|Informational (4)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Raised when|  
|-|-|-|  
|`ThreadPoolWorkerThreadStart`|50|A worker thread is created.|  
|`ThreadPoolWorkerThreadStop`|51|A worker thread is stopped.|  
|`ThreadPoolWorkerThreadRetirementStart`|52|A worker thread retires.|  
|`ThreadPoolWorkerThreadRetirementStop`|53|A retired worker thread becomes active again.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|ActiveWorkerThreadCount|win:UInt32|Number of worker threads available to process work, including those that are already processing work.|  
|RetiredWorkerThreadCount|win:UInt32|Number of worker threads that are not available to process work, but that are being held in reserve in case more threads are needed later.|  
|ClrInstanceID|Win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
  
### ThreadPoolWorkerThreadAdjustment  
 These thread pool events provide information for understanding and debugging the behavior of the thread injection (concurrency control) algorithm. The information is used internally by the worker thread pool.  
  
#### ThreadPoolWorkerThreadAdjustmentSample  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ThreadingKeyword` (0x10000)|Informational (4)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Description|  
|-----------|--------------|-----------------|  
|`ThreadPoolWorkerThreadAdjustmentSample`|54|Refers to the collection of information for one sample; that is, a measurement of throughput with a certain concurrency level, in an instant of time.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|Throughput|win:Double|Number of completions per unit of time.|  
|ClrInstanceID|Win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
  
#### ThreadPoolWorkerThreadAdjustmentAdjustment  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ThreadingKeyword` (0x10000)|Informational (4)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Description|  
|-----------|--------------|-----------------|  
|`ThreadPoolWorkerThreadAdjustmentAdjustment`|55|Records a change in control, when the thread injection (hill-climbing) algorithm determines that a change in concurrency level is in place.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|AverageThroughput|win:Double|Average throughput of a sample of measurements.|  
|NewWorkerThreadCount|win:UInt32|New number of active worker threads.|  
|Reason|win:UInt32|Reason for the adjustment.<br /><br /> 0x00 - Warmup.<br /><br /> 0x01 - Initializing.<br /><br /> 0x02 - Random move.<br /><br /> 0x03 - Climbing move.<br /><br /> 0x04 - Change point.<br /><br /> 0x05 - Stabilizing.<br /><br /> 0x06 - Starvation.<br /><br /> 0x07 - Thread timed out.|  
|ClrInstanceID|Win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
  
#### ThreadPoolWorkerThreadAdjustmentStats  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ThreadingKeyword` (0x10000)|Informational (4)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Description|  
|-----------|--------------|-----------------|  
|`ThreadPoolWorkerThreadAdjustmentStats`|56|Gathers data on the thread pool.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|Duration|win:Double|Amount of time, in seconds, during which these statistics were collected.|  
|Throughput|win:Double|Average number of completions per second during this interval.|  
|ThreadWave|win:Double|Reserved for internal use.|  
|ThroughputWave|win:Double|Reserved for internal use.|  
|ThroughputErrorEstimate|win:Double|Reserved for internal use.|  
|AverageThroughputErrorEstimate|win:Double|Reserved for internal use.|  
|ThroughputRatio|win:Double|The relative improvement in throughput caused by variations in active worker thread count during this interval.|  
|Confidence|win:Double|A measure of the validity of the ThroughputRatio field.|  
|NewcontrolSetting|win:Double|The number of active worker threads that will serve as the baseline for future variations in active thread count.|  
|NewThreadWaveMagnitude|Win:UInt16|The magnitude of future variations in active thread count.|  
|ClrInstanceID|Win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
  
 [Back to top](#top)  
  
<a name="io"></a>   
## I/O Thread Events  
 These thread pool events occur for threads in the I/O thread pool (completion ports), which is asynchronous.  
  
### IOThreadCreate_V1  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ThreadingKeyword` (0x10000)|Informational (4)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Raised when|  
|-|-|-|  
|`IOThreadCreate_V1`|44|An I/O thread is created in the thread pool.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|Count|win:UInt64|Number of I/O threads, including the newly created thread.|  
|NumRetired|win:UInt64|Number of retired worker threads.|  
|ClrInstanceID|Win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
  
### IOThreadRetire_V1  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ThreadingKeyword` (0x10000)|Informational (4)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`IOThreadRetire_V1`|46|An I/O thread becomes a retirement candidate.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|Count|win:UInt64|Number of I/O threads remaining in the thread pool.|  
|NumRetired|win:UInt64|Number of retired I/O threads.|  
|ClrInstanceID|Win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
  
### IOThreadUnretire_V1  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ThreadingKeyword` (0x10000)|Informational (4)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`IOThreadUnretire_V1`|47|An I/O thread is unretired because of I/O that arrives within a waiting period after the thread becomes a retirement candidate.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|Count|win:UInt64|Number of I/O threads in the thread pool, including this one.|  
|NumRetired|win:UInt64|Number of retired I/O threads.|  
|ClrInstanceID|Win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
  
### IOThreadTerminate  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ThreadingKeyword` (0x10000)|Informational (4)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`IOThreadTerminate`|45|An I/O thread is created in the thread pool.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|Count|win:UInt64|Number of I/O threads remaining in the thread pool.|  
|NumRetired|win:UInt64|Number of retired I/O threads.|  
|ClrInstanceID|Win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
  
## See Also  
 [CLR ETW Events](../../../docs/framework/performance/clr-etw-events.md)
