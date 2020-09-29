---
title: "ThreadPool Runtime Events"
description: Review thread pool ETW events, which collect information about threads in .NET Core. Thread pool events are worker thread pool events or I/O thread pool events.
ms.date: "09/27/2020"
helpviewer_keywords
  - "ThreadPool events [.NET Core]"
  - "ETW, thread pool events (CoreCLR)"
ms.assetid: f2a21e3a-3b6c-4433-97f3-47ff16855ecc
---
# Threading Events
These events collect information about worker and I/O threads.

|Keyword for raising the event|Level|
|-----------------------------------|-----------|-----------|
|`ThreadingKeyword` (0x10000)|Informational (4)|

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`WorkerThreadRetire`|151|Raised when a module is loaded for an application domain.|

|Field name|Data type|Description|

## IOThreadCreate_V1 Event
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

## IOThreadTerminate_V1 Event
 The following table shows the keyword and level

|Keyword for raising the event|Level
|-----------------------------------|-----------
|`ThreadingKeyword` (0x10000)|Informational (4)

 The following table shows the event information.

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`IOThreadTerminate`|45|An I/O thread is terminated in the thread pool.|

 The following table shows the event data.

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|Count|win:UInt64|Number of I/O threads remaining in the thread pool.|
|NumRetired|win:UInt64|Number of retired I/O threads.|
|ClrInstanceID|Win:UInt16|Unique ID for the instance of CLR or CoreCLR.|

## IOThreadRetire_V1 Event
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

## IOThreadUnretire_V1 Event
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

## ThreadPoolWorkerThreadStart Event

|Keyword for raising the event|Level|
|-----------------------------------|-----------|-----------|
|`ThreadingKeyword` (0x10000)|Informational (4)|

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`ThreadPoolWorkerThreadStart`|50|A worker thread is created.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|ActiveWorkerThreadCount|win:UInt32|Number of worker threads available to process work, including those that are already processing work.|
|RetiredWorkerThreadCount|win:UInt32|Number of worker threads that are not available to process work, but that are being held in reserve in case more threads are needed later.|
|ClrInstanceID|Win:UInt16|Unique ID for the instance of CLR or CoreCLR.|

## ThreadPoolWorkerThreadStop Event

|Keyword for raising the event|Level|
|-----------------------------------|-----------|-----------|
|`ThreadingKeyword` (0x10000)|Informational (4)|

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`ThreadPoolWorkerThreadStop`|51|A worker thread is stopped.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|ActiveWorkerThreadCount|win:UInt32|Number of worker threads available to process work, including those that are already processing work.|
|RetiredWorkerThreadCount|win:UInt32|Number of worker threads that are not available to process work, but that are being held in reserve in case more threads are needed later.|
|ClrInstanceID|Win:UInt16|Unique ID for the instance of CLR or CoreCLR.|

## ThreadPoolWorkerThreadWait Event

|Keyword for raising the event|Level|
|-----------------------------------|-----------|-----------|
|`ThreadingKeyword` (0x10000)|Informational (4)|

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`ThreadPoolWorkerThreadStop`|51|A worker thread is waiting for work.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|ActiveWorkerThreadCount|win:UInt32|Number of worker threads available to process work, including those that are already processing work.|
|RetiredWorkerThreadCount|win:UInt32|Number of worker threads that are not available to process work, but that are being held in reserve in case more threads are needed later.|
|ClrInstanceID|Win:UInt16|Unique ID for the instance of CLR or CoreCLR.|

## ThreadPoolWorkerThreadRetirementStart Event

|Keyword for raising the event|Level|
|-----------------------------------|-----------|-----------|
|`ThreadingKeyword` (0x10000)|Informational (4)|

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`ThreadPoolWorkerThreadRetirementStart`|52|A worker thread retires.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|ActiveWorkerThreadCount|win:UInt32|Number of worker threads available to process work, including those that are already processing work.|
|RetiredWorkerThreadCount|win:UInt32|Number of worker threads that are not available to process work, but that are being held in reserve in case more threads are needed later.|
|ClrInstanceID|Win:UInt16|Unique ID for the instance of CLR or CoreCLR.|

## ThreadPoolWorkerThreadRetirementStop Event

|Keyword for raising the event|Level|
|-----------------------------------|-----------|-----------|
|`ThreadingKeyword` (0x10000)|Informational (4)|

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`ThreadPoolWorkerThreadStop`|53|A retired worker thread becomes active again.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|ActiveWorkerThreadCount|win:UInt32|Number of worker threads available to process work, including those that are already processing work.|
|RetiredWorkerThreadCount|win:UInt32|Number of worker threads that are not available to process work, but that are being held in reserve in case more threads are needed later.|
|ClrInstanceID|Win:UInt16|Unique ID for the instance of CLR or CoreCLR.|

## ThreadPoolWorkerThreadAdjustmentSample Event
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

## ThreadPoolWorkerThreadAdjustmentAdjustment Event
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
|Reason|win:UInt32|Reason for the adjustment.<br /><br /> `0x0` - Warmup.<br /><br /> `0x1` - Initializing.<br /><br /> `0x2` - Random move.<br /><br /> `0x3` - Climbing move.<br /><br /> `0x4` - Change point.<br /><br /> `0x5` - Stabilizing.<br /><br /> `0x6` - Starvation.<br /><br /> `0x7` - Thread timed out.|
|ClrInstanceID|Win:UInt16|Unique ID for the instance of CLR or CoreCLR.|

## ThreadPoolWorkerThreadAdjustmentStats Event

 The following table shows the keyword and level.

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`ThreadingKeyword` (0x10000)|Verbose (5)

 The following table shows the event information.

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`ThreadPoolWorkerThreadAdjustmentStats`|56|Gathers data on the thread pool.|

 The following table shows the event data

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
