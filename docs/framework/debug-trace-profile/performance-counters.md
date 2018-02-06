---
title: "Performance Counters in the .NET Framework"
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
  - "performance, .NET Framework applications"
  - "performance counters"
  - "performance monitoring, counters"
ms.assetid: 06a4ae8c-eeb2-4d5a-817e-b1b95c0653e1
caps.latest.revision: 18
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Performance Counters in the .NET Framework
This topic provides a list of performance counters you can find in the [Performance Monitor](http://technet.microsoft.com/library/cc749249.aspx).  
  
-   [Exception performance counters](#exception)  
  
-   [Interop performance counters](#interop)  
  
-   [JIT performance counters](#jit)  
  
-   [Loading performance counters](#loading)  
  
-   [Lock and thread performance counters](#lockthread)  
  
-   [Memory performance counters](#memory)  
  
-   [Networking performance counters](#networking)  
  
-   [Security performance counters](#security)  
  
<a name="exception"></a>   
## Exception performance counters  
 The Performance console .NET CLR Exceptions category includes counters that provide information about the exceptions thrown by an application. The following table describes these performance counters.  
  
|Performance counter|Description|  
|-------------------------|-----------------|  
|**# of Exceps Thrown**|Displays the total number of exceptions thrown since the application started. This includes both .NET exceptions and unmanaged exceptions that are converted into .NET exceptions. For example, an HRESULT returned from unmanaged code is converted to an exception in managed code.<br /><br /> This counter includes both handled and unhandled exceptions. Exceptions that are rethrown are counted again.|  
|**# of Exceps Thrown / Sec**|Displays the number of exceptions thrown per second. This includes both .NET exceptions and unmanaged exceptions that are converted into .NET exceptions. For example, an HRESULT returned from unmanaged code is converted to an exception in managed code.<br /><br /> This counter includes both handled and unhandled exceptions. It is not an average over time; it displays the difference between the values observed in the last two samples divided by the duration of the sample interval. This counter is an indicator of potential performance problems if a large (>100s) number of exceptions are thrown.|  
|**# of Filters / Sec**|Displays the number of .NET exception filters executed per second. An exception filter evaluates regardless of whether an exception is handled.<br /><br /> This counter is not an average over time; it displays the difference between the values observed in the last two samples divided by the duration of the sample interval.|  
|**# of Finallys / Sec**|Displays the number of finally blocks executed per second. A finally block is guaranteed to be executed regardless of how the try block was exited.  Only the finally blocks executed for an exception are counted; finally blocks on normal code paths are not counted by this counter.<br /><br /> This counter is not an average over time; it displays the difference between the values observed in the last two samples divided by the duration of the sample interval.|  
|**Throw to Catch Depth / Sec**|Displays the number of stack frames traversed, from the frame that threw the exception to the frame that handled the exception, per second. This counter resets to zero when an exception handler is entered, so nested exceptions show the handler-to-handler stack depth.<br /><br /> This counter is not an average over time; it displays the difference between the values observed in the last two samples divided by the duration of the sample interval.|  
  
<a name="interop"></a>   
## Interop performance counters  
 The Performance console .NET CLR Interop category includes counters that provide information about an application's interaction with COM components, COM+ services, and external type libraries. The following table describes these performance counters.  
  
|Performance counter|Description|  
|-------------------------|-----------------|  
|**# of CCWs**|Displays the current number of COM callable wrappers (CCWs). A CCW is a proxy for a managed object being referenced from an unmanaged COM client. This counter indicates the number of managed objects referenced by unmanaged COM code.|  
|**# of marshaling**|Displays the total number of times arguments and return values have been marshaled from managed to unmanaged code, and vice versa, since the application started. This counter is not incremented if the stubs are inlined. (Stubs are responsible for marshaling arguments and return values). Stubs are usually inlined if the marshaling overhead is small.|  
|**# of Stubs**|Displays the current number of stubs created by the common language runtime. Stubs are responsible for marshaling arguments and return values from managed to unmanaged code, and vice versa, during a COM interop call or a platform invoke call.|  
|**# of TLB exports / sec**|Reserved for future use.|  
|**# of TLB imports / sec**|Reserved for future use.|  
  
<a name="jit"></a>   
## JIT performance counters  
 The Performance console .NET CLR JIT category includes counters that provide information about code that has been JIT-compiled. The following table describes these performance counters.  
  
|Performance counter|Description|  
|-------------------------|-----------------|  
|**# of IL Bytes JITted**|Displays the total number of Microsoft intermediate language (MSIL) bytes compiled by the just-in-time (JIT) compiler since the application started. This counter is equivalent to the **Total # of IL Bytes Jitted** counter.|  
|**# of Methods JITted**|Displays the total number of methods JIT-compiled since the application started. This counter does not include pre-JIT-compiled methods.|  
|**% Time in Jit**|Displays the percentage of elapsed time spent in JIT compilation since the last JIT compilation phase. This counter is updated at the end of every JIT compilation phase. A JIT compilation phase occurs when a method and its dependencies are compiled.|  
|**IL Bytes Jitted / sec**|Displays the number of MSIL bytes that are JIT-compiled per second. This counter is not an average over time; it displays the difference between the values observed in the last two samples divided by the duration of the sample interval.|  
|**Standard Jit Failures**|Displays the peak number of methods the JIT compiler has failed to compile since the application started. This failure can occur if the MSIL cannot be verified or if there is an internal error in the JIT compiler.|  
|**Total # of IL Bytes Jitted**|Displays the total MSIL bytes JIT-compiled since the application started. This counter is equivalent to the **# of IL Bytes Jitted** counter.|  
  
<a name="loading"></a>   
## Loading performance counters  
 The Performance console .NET CLR Loading category includes counters that provide information about assemblies, classes, and application domains that are loaded. The following table describes these performance counters.  
  
|Performance counter|Description|  
|-------------------------|-----------------|  
|**% Time Loading**|Reserved for future use.|  
|**Assembly Search Length**|Reserved for future use.|  
|**Bytes in Loader Heap**|Displays the current size, in bytes, of the memory committed by the class loader across all application domains. Committed memory is the physical space reserved in the disk paging file.|  
|**Current appdomains**|Displays the current number of application domains loaded in this application.|  
|**Current Assemblies**|Displays the current number of assemblies loaded across all application domains in the currently running application. If the assembly is loaded as domain-neutral from multiple application domains, this counter is incremented only once.|  
|**Current Classes Loaded**|Displays the current number of classes loaded in all assemblies.|  
|**Rate of appdomains**|Displays the number of application domains loaded per second. This counter is not an average over time; it displays the difference between the values observed in the last two samples divided by the duration of the sample interval.|  
|**Rate of appdomains unloaded**|Displays the number of application domains unloaded per second. This counter is not an average over time; it displays the difference between the values observed in the last two samples divided by the duration of the sample interval.|  
|**Rate of Assemblies**|Displays the number of assemblies loaded per second across all application domains. If the assembly is loaded as domain-neutral from multiple application domains, this counter is incremented only once.<br /><br /> This counter is not an average over time; it displays the difference between the values observed in the last two samples divided by the duration of the sample interval.|  
|**Rate of Classes Loaded**|Displays the number of classes loaded per second in all assemblies. This counter is not an average over time; it displays the difference between the values observed in the last two samples divided by the duration of the sample interval.|  
|**Rate of Load Failures**|Displays the number of classes that failed to load per second. This counter is not an average over time; it displays the difference between the values observed in the last two samples divided by the duration of the sample interval.<br /><br /> Load failures can occur for many reasons, such as inadequate security or invalid format. For details, see the profiling services Help.|  
|**Total # of Load Failures**|Displays the peak number of classes that have failed to load since the application started.<br /><br /> Load failures can occur for many reasons, such as inadequate security or invalid format. For details, see the profiling services Help.|  
|**Total Appdomains**|Displays the peak number of application domains loaded since the application started.|  
|**Total appdomains unloaded**|Displays the total number of application domains unloaded since the application started. If an application domain is loaded and unloaded multiple times, this counter increments each time the application domain is unloaded.|  
|**Total Assemblies**|Displays the total number of assemblies loaded since the application started. If the assembly is loaded as domain-neutral from multiple application domains, this counter is incremented only once.|  
|**Total Classes Loaded**|Displays the cumulative number of classes loaded in all assemblies since the application started.|  
  
<a name="lockthread"></a>   
## Lock and thread performance counters  
 The Performance console .NET CLR LocksAndThreads category includes counters that provide information about managed locks and threads that an application uses. The following table describes these performance counters.  
  
|Performance counter|Description|  
|-------------------------|-----------------|  
|**# of current logical Threads**|Displays the number of current managed thread objects in the application. This counter maintains the count of both running and stopped threads. This counter is not an average over time; it displays only the last observed value.|  
|**# of current physical Threads**|Displays the number of native operating system threads created and owned by the common language runtime to act as underlying threads for managed thread objects. This counter's value does not include the threads used by the runtime in its internal operations; it is a subset of the threads in the operating system process.|  
|**# of current recognized threads**|Displays the number of threads that are currently recognized by the runtime. These threads are associated with a corresponding managed thread object. The runtime does not create these threads, but they have run inside the runtime at least once.<br /><br /> Only unique threads are tracked; threads with the same thread ID that reenter the runtime or are recreated after the thread exits are not counted twice.|  
|**# of total recognized Threads**|Displays the total number of threads that have been recognized by the runtime since the application started. These threads are associated with a corresponding managed thread object. The runtime does not create these threads, but they have run inside the runtime at least once.<br /><br /> Only unique threads are tracked; threads with the same thread ID that reenter the runtime or are recreated after the thread exits are not counted twice.|  
|**Contention Rate / Sec**|Displays the rate at which threads in the runtime attempt to acquire a managed lock unsuccessfully.|  
|**Current Queue Length**|Displays the total number of threads that are currently waiting to acquire a managed lock in the application. This counter is not an average over time; it displays the last observed value.|  
|**Queue Length / sec**|Displays the number of threads per second that are waiting to acquire a lock in the application. This counter is not an average over time; it displays the difference between the values observed in the last two samples divided by the duration of the sample interval.|  
|**Queue Length Peak**|Displays the total number of threads that waited to acquire a managed lock since the application started.|  
|**rate of recognized threads / sec**|Displays the number of threads per second that have been recognized by the runtime. These threads are associated with a corresponding managed thread object. The runtime does not create these threads, but they have run inside the runtime at least once.<br /><br /> Only unique threads are tracked; threads with the same thread ID that reenter the runtime or are recreated after the thread exits are not counted twice.<br /><br /> This counter is not an average over time; it displays the difference between the values observed in the last two samples divided by the duration of the sample interval.|  
|**Total # of Contentions**|Displays the total number of times that threads in the runtime have attempted to acquire a managed lock unsuccessfully.|  
  
<a name="memory"></a>   
## Memory performance counters  
 The Performance console .NET CLR Memory category includes counters that provide information about the garbage collector. The following table describes these performance counters.  
  
|Performance counter|Description|  
|-------------------------|-----------------|  
|**# Bytes in all Heaps**|Displays the sum of the **Gen 1 Heap Size**, **Gen 2 Heap Size**, and **Large Object Heap Size** counters. This counter indicates the current memory allocated in bytes on the garbage collection heaps.|  
|**# GC Handles**|Displays the current number of garbage collection handles in use. Garbage collection handles are handles to resources external to the common language runtime and the managed environment.|  
|**# Gen 0 Collections**|Displays the number of times the generation 0 objects (that is, the youngest, most recently allocated objects) are garbage collected since the application started.<br /><br /> Generation 0 garbage collection occurs when the available memory in generation 0 is not sufficient to satisfy an allocation request. This counter is incremented at the end of a generation 0 garbage collection. Higher generation garbage collections include all lower generation collections. This counter is explicitly incremented when a higher generation (generation 1 or 2) garbage collection occurs.<br /><br /> This counter displays the last observed value. The **_Global\_** counter value is not accurate and should be ignored.|  
|**# Gen 1 Collections**|Displays the number of times the generation 1 objects are garbage collected since the application started.<br /><br /> The counter is incremented at the end of a generation 1 garbage collection. Higher generation garbage collections include all lower generation collections. This counter is explicitly incremented when a higher generation (generation 2) garbage collection occurs.<br /><br /> This counter displays the last observed value. The **_Global\_** counter value is not accurate and should be ignored.|  
|**# Gen 2 Collections**|Displays the number of times the generation 2 objects are garbage collected since the application started. The counter is incremented at the end of a generation 2 garbage collection (also called a full garbage collection).<br /><br /> This counter displays the last observed value. The **_Global\_** counter value is not accurate and should be ignored.|  
|**# Induced GC**|Displays the peak number of times garbage collection was performed because of an explicit call to <xref:System.GC.Collect%2A?displayProperty=nameWithType>. It is good practice to let the garbage collector tune the frequency of its collections.|  
|**# of Pinned Objects**|Displays the number of pinned objects encountered in the last garbage collection. A pinned object is an object that the garbage collector cannot move in memory. This counter tracks pinned objects only in the heaps that are garbage collected. For example, a generation 0 garbage collection causes enumeration of pinned objects only in the generation 0 heap.|  
|**# of Sink Blocks in use**|Displays the current number of synchronization blocks in use. Synchronization blocks are per-object data structures allocated for storing synchronization information. They hold weak references to managed objects and must be scanned by the garbage collector. Synchronization blocks are not limited to storing synchronization information; they can also store COM interop metadata. This counter indicates performance problems with heavy use of synchronization primitives.|  
|**# Total committed Bytes**|Displays the amount of virtual memory, in bytes, currently committed by the garbage collector. Committed memory is the physical memory for which space has been reserved in the disk paging file.|  
|**# Total reserved Bytes**|Displays the amount of virtual memory, in bytes, currently reserved by the garbage collector. Reserved memory is the virtual memory space reserved for the application when no disk or main memory pages have been used.|  
|**% Time in GC**|Displays the percentage of elapsed time that was spent performing a garbage collection since the last garbage collection cycle. This counter usually indicates the work done by the garbage collector to collect and compact memory on behalf of the application. This counter is updated only at the end of every garbage collection. This counter is not an average; its value reflects the last observed value.|  
|**Allocated Bytes/second**|Displays the number of bytes per second allocated on the garbage collection heap. This counter is updated at the end of every garbage collection, not at each allocation. This counter is not an average over time; it displays the difference between the values observed in the last two samples divided by the duration of the sample interval.|  
|**Finalization Survivors**|Displays the number of garbage-collected objects that survive a collection because they are waiting to be finalized. If these objects hold references to other objects, those objects also survive but are not counted by this counter. The **Promoted Finalization-Memory from Gen 0** counter represents all the memory that survived due to finalization.<br /><br /> This counter is not cumulative; it is updated at the end of every garbage collection with the count of the survivors during that particular collection only. This counter indicates the extra overhead that the application might incur because of finalization.|  
|**Gen 0 heap size**|Displays the maximum bytes that can be allocated in generation 0; it does not indicate the current number of bytes allocated in generation 0.<br /><br /> A generation 0 garbage collection occurs when the allocations since the last collection exceed this size. The generation 0 size is tuned by the garbage collector and can change during the execution of the application. At the end of a generation 0 collection the size of the generation 0 heap is 0 bytes. This counter displays the size, in bytes, of allocations that invokes the next generation 0 garbage collection.<br /><br /> This counter is updated at the end of a garbage collection, not at each allocation.|  
|**Gen 0 Promoted Bytes/Sec**|Displays the bytes per second that are promoted from generation 0 to generation 1. Memory is promoted when it survives a garbage collection. This counter is an indicator of relatively long-lived objects being created per second.<br /><br /> This counter displays the difference between the values observed in the last two samples divided by the duration of the sample interval.|  
|**Gen 1 heap size**|Displays the current number of bytes in generation 1; this counter does not display the maximum size of generation 1. Objects are not directly allocated in this generation; they are promoted from previous generation 0 garbage collections. This counter is updated at the end of a garbage collection, not at each allocation.|  
|**Gen 1 Promoted Bytes/Sec**|Displays the bytes per second that are promoted from generation 1 to generation 2. Objects that are promoted only because they are waiting to be finalized are not included in this counter.<br /><br /> Memory is promoted when it survives a garbage collection. Nothing is promoted from generation 2 because it is the oldest generation. This counter is an indicator of very long-lived objects being created per second.<br /><br /> This counter displays the difference between the values observed in the last two samples divided by the duration of the sample interval.|  
|**Gen 2 heap size**|Displays the current number of bytes in generation 2. Objects are not directly allocated in this generation; they are promoted from generation 1 during previous generation 1 garbage collections. This counter is updated at the end of a garbage collection, not at each allocation.|  
|**Large Object Heap size**|Displays the current size, in bytes, of the Large Object Heap. Objects that are greater than approximately 85,000 bytes are treated as large objects by the garbage collector and are directly allocated in a special heap; they are not promoted through the generations. This counter is updated at the end of a garbage collection, not at each allocation.|  
|**Process ID**|Displays the process ID of the CLR process instance that is being monitored.|  
|**Promoted Finalization-Memory from Gen 0**|Displays the bytes of memory that are promoted from generation 0 to generation 1 only because they are waiting to be finalized. This counter is not cumulative; it displays the value observed at the end of the last garbage collection.|  
|**Promoted Memory from Gen 0**|Displays the bytes of memory that survive garbage collection and are promoted from generation 0 to generation 1. Objects that are promoted only because they are waiting to be finalized are not included in this counter. This counter is not cumulative; it displays the value observed at the end of the last garbage collection.|  
|**Promoted Memory from Gen 1**|Displays the bytes of memory that survive garbage collection and are promoted from generation 1 to generation 2. Objects that are promoted only because they are waiting to be finalized are not included in this counter. This counter is not cumulative; it displays the value observed at the end of the last garbage collection. This counter is reset to 0 if the last garbage collection was a generation 0 collection only.|  
  
<a name="networking"></a>   
## Networking performance counters  
 The Performance console .NET CLR Networking category includes counters that provide information about data that an application sends and receives over the network. The following table describes these performance counters.  
  
|Performance counter|Description|  
|-------------------------|-----------------|  
|**Bytes Received**|The cumulative total number of bytes received by all <xref:System.Net.Sockets.Socket> objects within the <xref:System.AppDomain> since the process started. This number includes data and any protocol information that is not defined by TCP/IP.|  
|**Bytes Sent**|The cumulative number of bytes sent by all <xref:System.Net.Sockets.Socket> objects within the <xref:System.AppDomain> since the process started. This number includes data and any protocol information that is not defined by TCP/IP.|  
|**Connections Established**|The cumulative total number of <xref:System.Net.Sockets.Socket> objects for stream sockets that were ever connected within the <xref:System.AppDomain> since the process started.|  
|**Datagrams Received**|The cumulative total number of datagram packets received by all <xref:System.Net.Sockets.Socket> objects within the <xref:System.AppDomain> since the process started.|  
|**Datagrams Sent**|The cumulative total number of datagram packets sent by all <xref:System.Net.Sockets.Socket> objects within the <xref:System.AppDomain> since the process started.|  
|**HttpWebRequest Average Lifetime**|The average time to completion for all <xref:System.Net.HttpWebRequest> objects that ended in the last interval within the <xref:System.AppDomain> since the process started.|  
|**HttpWebRequest Average Queue Time**|The average time-on-queue for all <xref:System.Net.HttpWebRequest> objects that left the queue in the last interval within the <xref:System.AppDomain> since the process started.|  
|**HttpWebRequests Created/sec**|The number of <xref:System.Net.HttpWebRequest> objects created per second within the <xref:System.AppDomain>.|  
|**HttpWebRequests Queued/sec**|The number of <xref:System.Net.HttpWebRequest> objects that were added to the queue per second within the <xref:System.AppDomain>.|  
|**HttpWebRequests Aborted/sec**|The number of <xref:System.Net.HttpWebRequest> objects where the application called the <xref:System.Net.HttpWebRequest.Abort%2A> method per second within the <xref:System.AppDomain>.|  
|**HttpWebRequests Failed/sec**|The number of <xref:System.Net.HttpWebRequest> objects that received a failed status code from the server per second within the <xref:System.AppDomain>.|  
  
 There are several classes of networking performance counters supported:  
  
-   Event counters that measure the number of times some event occurred.  
  
-   Data counters that measure the quantity of data sent or received.  
  
-   Duration counters that measure how long different processes take. The times are measured on the objects each interval (usually in seconds) after they come out of different states.  
  
-   Per-Interval counters that measure the number of objects that are making a particular transition per interval (normally per second).  
  
 The networking performance counters for events include the following:  
  
-   **Connections Established**  
  
-   **Datagrams Received**  
  
-   **Datagrams Sent**  
  
 These performance counters provide counts since the process started. The counts of <xref:System.Net.Sockets.Socket> connections established includes explicit <xref:System.Net.Sockets.Socket> method calls by an application for a stream socket connection that was established as well as internal calls made by other classes (<xref:System.Net.HttpWebRequest>, <xref:System.Net.FtpWebRequest>, <xref:System.Net.WebClient>, and <xref:System.Net.Sockets.TcpClient>, for example) to <xref:System.Net.Sockets.Socket> class  
  
 The counts for **Datagrams Received** and **Datagrams Sent** includes datagram packets sent or received using explicit <xref:System.Net.Sockets.Socket> method calls by an application as well internal calls made by other classes (<xref:System.Net.Sockets.UdpClient>, for example) to <xref:System.Net.Sockets.Socket>. class. The counts **Datagrams Received** and **Datagrams Sent** may also be used to provide a very crude measure of how many bytes were sent or received using datagrams by assuming an average size for a datagram.  
  
 The networking performance counters for data include the following:  
  
-   **Bytes Received**  
  
-   **Bytes Sent**  
  
 The above counters provide counts of bytes since the process started.  
  
 There are two duration counters that measure how long it took for <xref:System.Net.HttpWebRequest> objects to pass through either their entire life cycle or just part of it:  
  
-   **HttpWebRequest Average Lifetime**  
  
-   **HttpWebRequest Average Queue Time**  
  
 For the **HttpWebRequest Average Lifetime** counter, the lifetime of most <xref:System.Net.HttpWebRequest> objects always starts with the time that the object is created up until the time that the response stream is closed by the application. There are two uncommon cases:  
  
-   If the application never calls the <xref:System.Net.HttpWebRequest.GetResponse%2A> or <xref:System.Net.HttpWebRequest.BeginGetResponse%2A> methods, then the lifetime of the <xref:System.Net.HttpWebRequest> object is ignored.  
  
-   If the <xref:System.Net.HttpWebRequest> object throws a <xref:System.Net.WebException> when calling the <xref:System.Net.HttpWebRequest.GetResponse%2A> or <xref:System.Net.HttpWebRequest.EndGetResponse%2A> methods, the lifetime ends when the exception is thrown. Technically, the underlying response stream is also closed at that point (the response stream returned to the user is really a memory stream containing a copy of the response stream).  
  
 There are four counters that track certain <xref:System.Net.HttpWebRequest> object issues per interval. These performance counters can help application developers, administrators, and support staff better understand what the <xref:System.Net.HttpWebRequest> objects are doing. The counters include the following:  
  
-   **HttpWebRequests Created/sec**  
  
-   **HttpWebRequests Queued/sec**  
  
-   **HttpWebRequests Aborted/sec**  
  
-   **HttpWebRequests Failed/sec**  
  
 For the **HttpWebRequests Aborted/sec** counter, internal calls to <xref:System.Net.HttpWebRequest.Abort%2A> are also counted. These internal calls are usually caused by timeouts that an application may want to measure.  
  
 The **HttpWebRequests Failed/sec** counter contains the number of <xref:System.Net.HttpWebRequest> objects that received a failed status code from the server per second. This means that the status code received from the Http server at the end of the request was not in the range between 200 to 299. Status codes that are handled and result in a new request (many of the 401 Unauthorized status codes, for example) will fail or not fail based on the result of the retry. If the application would see an error based on the retry, then this counter is incremented.  
  
 Networking performance counters can be accessed and managed using the <xref:System.Diagnostics.PerformanceCounter> and related classes in the <xref:System.Diagnostics> namespace. Networking performance counters can also be viewed with the Windows Performance Monitor console.  
  
 Networking performance counters need to be enabled in the configuration file to be used. All networking performance counters are enabled or disabled with a single setting in the configuration file. Individual networking performance counters cannot be enabled or disabled. For more information, see [\<performanceCounter> Element (Network Settings)](../../../docs/framework/configure-apps/file-schema/network/performancecounter-element-network-settings.md).  
  
 If networking counters are enabled, this will create and update both per-AppDomain and global performance counters. If disabled, the application will not provide any networking performance counter data.  
  
 Performance counters are grouped into Categories. An application can list all of the categories with the following example code:  
  
```  
PerformanceCounterCategory[] Array = PerformanceCounterCategory.GetCategories();  
for (int i = 0; i < Array.Length; i++)  
{  
    Console.Out.WriteLine("{0}. Name={1} Help={2}", i, Array[i].CategoryName, Array[i].CategoryHelp);  
}  
```  
  
 The networking performance counters are listed in two categories:  
  
-   ".NET CLR Networking" - the original performance counters introduced on .NET Framework Version 2 and supported on .NET Framework Version 2 and later.  
  
-   ".NET CLR Networking 4.0.0.0" - All of the above socket counters plus the new performance counters supported on .NET Framework Version 4 and later. These new counters provide performance information on <xref:System.Net.HttpWebRequest> objects.  
  
 For more information on accessing and managing performance counters in an application, see [Performance Counters](../../../docs/framework/debug-trace-profile/performance-counters.md).  
  
<a name="security"></a>   
## Security performance counters  
 The Performance console .NET CLR Security category includes counters that provide information about the security checks that the common language runtime performs for an application. The following table describes these performance counters.  
  
|Performance counter|Description|  
|-------------------------|-----------------|  
|**# Link Time Checks**|Displays the total number of link-time code access security checks since the application started. Link-time code access security checks are performed when a caller demands a particular permission at just-in-time (JIT) compile time. A link-time check is performed once per caller. This count is not indicative of serious performance issues; it is merely indicative of the security system activity.|  
|**% Time in RT checks**|Displays the percentage of elapsed time spent performing runtime code access security checks since the last sample. This counter is updated at the end of a .NET Framework security check. It is not an average; it represents the last observed value.|  
|**% Time Sig Authenticating**|Reserved for future use.|  
|**Stack Walk Depth**|Displays the depth of the stack during that last runtime code access security check. Runtime code access security checks are performed by walking the stack. This counter is not an average; it displays only the last observed value.|  
|**Total Runtime Checks**|Displays the total number of runtime code access security checks performed since the application started. Runtime code access security checks are performed when a caller demands a particular permission. The runtime check is made on every call by the caller and examines the current thread stack of the caller. When used with the **Stack Walk Depth** counter, this counter indicates the performance penalty that occurs for security checks.|  
  
## See Also  
 [Performance Counters](../../../docs/framework/debug-trace-profile/performance-counters.md)  
 [Runtime Profiling](../../../docs/framework/debug-trace-profile/runtime-profiling.md)
