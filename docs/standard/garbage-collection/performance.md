---
title: "Garbage Collection and Performance"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "garbage collection, troubleshooting"
  - "garbage collection, performance"
ms.assetid: c203467b-e95c-4ccf-b30b-953eb3463134
caps.latest.revision: 35
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Garbage Collection and Performance
<a name="top"></a> This topic describes issues related to garbage collection and memory usage. It addresses issues that pertain to the managed heap and explains how to minimize the effect of garbage collection on your applications. Each issue has links to procedures that you can use to investigate problems.  
  
 This topic contains the following sections:  
  
-   [Performance Analysis Tools](#performance_analysis_tools)  
  
-   [Troubleshooting Performance Issues](#troubleshooting_performance_issues)  
  
-   [Troubleshooting Guidelines](#troubleshooting_guidelines)  
  
-   [Performance Check Procedures](#performance_check_procedures)  
  
<a name="performance_analysis_tools"></a>   
## Performance Analysis Tools  
 The following sections describe the tools that are available for investigating memory usage and garbage collection issues. The [procedures](#performance_check_procedures) provided later in this topic refer to these tools.  
  
<a name="perf_counters"></a>   
### Memory Performance Counters  
 You can use performance counters to gather performance data. For instructions, see [Runtime Profiling](../../../docs/framework/debug-trace-profile/runtime-profiling.md). The .NET CLR Memory category of performance counters, as described in [Performance Counters in the .NET Framework](../../../docs/framework/debug-trace-profile/performance-counters.md), provides information about the garbage collector.  
  
<a name="sos"></a>   
### Debugging with SOS  
 You can use the [Windows Debugger (WinDbg)](/windows-hardware/drivers/debugger/index) to inspect objects on the managed heap.  
  
 To install WinDbg, install Debugging Tools for Windows from the [WDK and Developer Tools Web site](http://go.microsoft.com/fwlink/?LinkID=103787).  
  
<a name="etw"></a>   
### Garbage Collection ETW Events  
 Event tracing for Windows (ETW) is a tracing system that supplements the profiling and debugging support provided by the .NET Framework. Starting with the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)], [garbage collection ETW events](../../../docs/framework/performance/garbage-collection-etw-events.md) capture useful information for analyzing the managed heap from a statistical point of view. For example, the `GCStart_V1` event, which is raised when a garbage collection is about to occur, provides the following information:  
  
-   Which generation of objects is being collected.  
  
-   What triggered the garbage collection.  
  
-   Type of garbage collection (concurrent or not concurrent).  
  
 ETW event logging is efficient and will not mask any performance problems associated with garbage collection. A process can provide its own events in conjunction with ETW events. When logged, both the application's events and the garbage collection events can be correlated to determine how and when heap problems occur. For example, a server application could provide events at the start and end of a client request.  
  
<a name="profiling_api"></a>   
### The Profiling API  
 The common language runtime (CLR) profiling interfaces provide detailed information about the objects that were affected during garbage collection. A profiler can be notified when a garbage collection starts and ends. It can provide reports about the objects on the managed heap, including an identification of objects in each generation. For more information, see [Profiling Overview](../../../docs/framework/unmanaged-api/profiling/profiling-overview.md).  
  
 Profilers can provide comprehensive information. However, complex profilers can potentially modify an application's behavior.  
  
### Application Domain Resource Monitoring  
 Starting with the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)], Application domain resource monitoring (ARM) enables hosts to monitor CPU and memory usage by application domain. For more information, see [Application Domain Resource Monitoring](../../../docs/standard/garbage-collection/app-domain-resource-monitoring.md).  
  
 [Back to top](#top)  
  
<a name="troubleshooting_performance_issues"></a>   
## Troubleshooting Performance Issues  
 The first step is to [determine whether the issue is actually garbage collection](#IsGC). If you determine that it is, select from the following list to troubleshoot the problem.  
  
-   [An out-of-memory exception is thrown](#Issue_OOM)  
  
-   [The process uses too much memory](#Issue_TooMuchMemory)  
  
-   [The garbage collector does not reclaim objects fast enough](#Issue_NotFastEnough)  
  
-   [The managed heap is too fragmented](#Issue_Fragmentation)  
  
-   [Garbage collection pauses are too long](#Issue_LongPauses)  
  
-   [Generation 0 is too big](#Issue_Gen0)  
  
-   [CPU usage during a garbage collection is too high](#Issue_HighCPU)  
  
<a name="Issue_OOM"></a>   
### Issue: An Out-of-Memory Exception Is Thrown  
 There are two legitimate cases for a managed <xref:System.OutOfMemoryException> to be thrown:  
  
-   Running out of virtual memory.  
  
     The garbage collector allocates memory from the system in segments of a pre-determined size. If an allocation requires an additional segment, but there is no contiguous free block left in the process's virtual memory space, the allocation for the managed heap will fail.  
  
-   Not having enough physical memory to allocate.  
  
|Performance checks|  
|------------------------|  
|[Determine whether the out-of-memory exception is managed.](#OOMIsManaged)<br /><br /> [Determine how much virtual memory can be reserved.](#GetVM)<br /><br /> [Determine whether there is enough physical memory.](#Physical)|  
  
 If you determine that the exception is not legitimate, contact Microsoft Customer Service and Support with the following information:  
  
-   The stack with the managed out-of-memory exception.  
  
-   Full memory dump.  
  
-   Data that proves that it is not a legitimate out-of-memory exception, including data that shows that virtual or physical memory is not an issue.  
  
<a name="Issue_TooMuchMemory"></a>   
### Issue: The Process Uses Too Much Memory  
 A common assumption is that the memory usage display on the **Performance** tab of Windows Task Manager can indicate when too much memory is being used. However, that display pertains to the working set; it does not provide information about virtual memory usage.  
  
 If you determine that the issue is caused by the managed heap, you must measure the managed heap over time to determine any patterns.  
  
 If you determine that the problem is not caused by the managed heap, you must use native debugging.  
  
|Performance checks|  
|------------------------|  
|[Determine how much virtual memory can be reserved.](#GetVM)<br /><br /> [Determine how much memory the managed heap is committing.](#ManagedHeapCommit)<br /><br /> [Determine how much memory the managed heap reserves.](#ManagedHeapReserve)<br /><br /> [Determine large objects in generation 2.](#ExamineGen2)<br /><br /> [Determine references to objects.](#ObjRef)|  
  
<a name="Issue_NotFastEnough"></a>   
### Issue: The Garbage Collector Does Not Reclaim Objects Fast Enough  
 When it appears as if objects are not being reclaimed as expected for garbage collection, you must determine if there are any strong references to those objects.  
  
 You may also encounter this issue if there has been no garbage collection for the generation that contains a dead object, which indicates that the finalizer for the dead object has not been run. For example, this is possible when you are running a single-threaded apartment (STA) application and the thread that services the finalizer queue cannot call into it.  
  
|Performance checks|  
|------------------------|  
|[Check references to objects.](#ObjRef)<br /><br /> [Determine whether a finalizer has been run.](#Induce)<br /><br /> [Determine whether there are objects waiting to be finalized.](#Finalize)|  
  
<a name="Issue_Fragmentation"></a>   
### Issue: The Managed Heap Is Too fragmented  
 The fragmentation level is calculated as the ratio of free space over the total allocated memory for the generation. For generation 2, an acceptable level of fragmentation is no more than 20%. Because generation 2 can get very big, the ratio of fragmentation is more important than the absolute value.  
  
 Having lots of free space in generation 0 is not a problem because this is the generation where new objects are allocated.  
  
 Fragmentation always occurs in the large object heap because it is not compacted. Free objects that are adjacent are naturally collapsed into a single space to satisfy large object allocation requests.  
  
 Fragmentation can become a problem in generation 1 and generation 2. If these generations have a large amount of free space after a garbage collection, an application's object usage may need modification, and you should consider re-evaluating the lifetime of long-term objects.  
  
 Excessive pinning of objects can increase fragmentation. If fragmentation is high, too many objects could be pinned.  
  
 If fragmentation of virtual memory is preventing the garbage collector from adding segments, the causes could be one of the following:  
  
-   Frequent loading and unloading of many small assemblies.  
  
-   Holding too many references to COM objects when interoperating with unmanaged code.  
  
-   Creation of large transient objects, which causes the large object heap to allocate and free heap segments frequently.  
  
     When hosting the CLR, an application can request that the garbage collector retain its segments. This reduces the frequency of segment allocations. This is accomplished by using the STARTUP_HOARD_GC_VM flag in the [STARTUP_FLAGS Enumeration](../../../docs/framework/unmanaged-api/hosting/startup-flags-enumeration.md).  
  
|Performance checks|  
|------------------------|  
|[Determine the amount of free space in the managed heap.](#Fragmented)<br /><br /> [Determine the number of pinned objects.](#Pinned)|  
  
 If you think that there is no legitimate cause for the fragmentation, contact Microsoft Customer Service and Support.  
  
<a name="Issue_LongPauses"></a>   
### Issue: Garbage Collection Pauses Are Too Long  
 Garbage collection operates in soft real time, so an application must be able to tolerate some pauses. A criterion for soft real time is that 95% of the operations must finish on time.  
  
 In concurrent garbage collection, managed threads are allowed to run during a collection, which means that pauses are very minimal.  
  
 Ephemeral garbage collections (generations 0 and 1) last only a few milliseconds, so decreasing pauses is usually not feasible. However, you can decrease the pauses in generation 2 collections by changing the pattern of allocation requests by an application.  
  
 Another, more accurate, method is to use [garbage collection ETW events](../../../docs/framework/performance/garbage-collection-etw-events.md). You can find the timings for collections by adding the time stamp differences for a sequence of events. The whole collection sequence includes suspension of the execution engine, the garbage collection itself, and the resumption of the execution engine.  
  
 You can use [Garbage Collection Notifications](../../../docs/standard/garbage-collection/notifications.md) to determine whether a server is about to have a generation 2 collection, and whether rerouting requests to another server could ease any problems with pauses.  
  
|Performance checks|  
|------------------------|  
|[Determine the length of time in a garbage collection.](#TimeInGC)<br /><br /> [Determine what caused a garbage collection.](#Triggered)|  
  
<a name="Issue_Gen0"></a>   
### Issue: Generation 0 Is Too Big  
 Generation 0 is likely to have a larger number of objects on a 64-bit system, especially when you use server garbage collection instead of workstation garbage collection. This is because the threshold to trigger a generation 0 garbage collection is higher in these environments, and generation 0 collections can get much bigger. Performance is improved when an application allocates more memory before a garbage collection is triggered.  
  
<a name="Issue_HighCPU"></a>   
### Issue: CPU Usage During a Garbage Collection Is Too High  
 CPU usage will be high during a garbage collection. If a significant amount of process time is spent in a garbage collection, the number of collections is too frequent or the collection is lasting too long. An increased allocation rate of objects on the managed heap causes garbage collection to occur more frequently. Decreasing the allocation rate reduces the frequency of garbage collections.  
  
 You can monitor allocation rates by using the `Allocated Bytes/second` performance counter. For more information, see [Performance Counters in the .NET Framework](../../../docs/framework/debug-trace-profile/performance-counters.md).  
  
 The duration of a collection is primarily a factor of the number of objects that survive after allocation. The garbage collector must go through a large amount of memory if many objects remain to be collected. The work to compact the survivors is time-consuming. To determine how many objects were handled during a collection, set a breakpoint in the debugger at the end of a garbage collection for a specified generation.  
  
|Performance checks|  
|------------------------|  
|[Determine if high CPU usage is caused by garbage collection.](#HighCPU)<br /><br /> [Set a breakpoint at the end of garbage collection.](#GenBreak)|  
  
 [Back to top](#top)  
  
<a name="troubleshooting_guidelines"></a>   
## Troubleshooting Guidelines  
 This section describes guidelines that you should consider as you begin your investigations.  
  
### Workstation or Server Garbage Collection  
 Determine if you are using the correct type of garbage collection. If your application uses multiple threads and object instances, use server garbage collection instead of workstation garbage collection. Server garbage collection operates on multiple threads, whereas workstation garbage collection requires multiple instances of an application to run their own garbage collection threads and compete for CPU time.  
  
 An application that has a low load and that performs tasks infrequently in the background, such as a service, could use workstation garbage collection with concurrent garbage collection disabled.  
  
### When to Measure the Managed Heap Size  
 Unless you are using a profiler, you will have to establish a consistent measuring pattern to effectively diagnose performance issues. Consider the following points to establish a schedule:  
  
-   If you measure after a generation 2 garbage collection, the entire managed heap will be free of garbage (dead objects).  
  
-   If you measure immediately after a generation 0 garbage collection, the objects in generations 1 and 2 will not be collected yet.  
  
-   If you measure immediately before a garbage collection, you will measure as much allocation as possible before the garbage collection starts.  
  
-   Measuring during a garbage collection is problematic, because the garbage collector data structures are not in a valid state for traversal and may not be able to give you the complete results. This is by design.  
  
-   When you are using workstation garbage collection with concurrent garbage collection, the reclaimed objects are not compacted, so the heap size can be the same or larger (fragmentation can make it appear to be larger).  
  
-   Concurrent garbage collection on generation 2 is delayed when the physical memory load is too high.  
  
 The following procedure describes how to set a breakpoint so that you can measure the managed heap.  
  
<a name="GenBreak"></a>   
##### To set a breakpoint at the end of garbage collection  
  
-   In WinDbg with the SOS debugger extension loaded, type the following command:  
  
     **bp mscorwks!WKS::GCHeap::RestartEE "j (dwo(mscorwks!WKS::GCHeap::GcCondemnedGeneration)==2) 'kb';'g'"**  
  
     where **GcCondemnedGeneration** is set to the desired generation. This command requires private symbols.  
  
     This command forces a break if **RestartEE** is executed after generation 2 objects have been reclaimed for garbage collection.  
  
     In server garbage collection, only one thread calls **RestartEE**, so the breakpoint will occur only once during a generation 2 garbage collection.  
  
 [Back to top](#top)  
  
<a name="performance_check_procedures"></a>   
## Performance Check Procedures  
 This section describes the following procedures to isolate the cause of your performance issue:  
  
-   [Determine whether the problem is caused by garbage collection.](#IsGC)  
  
-   [Determine whether the out-of-memory exception is managed.](#OOMIsManaged)  
  
-   [Determine how much virtual memory can be reserved.](#GetVM)  
  
-   [Determine whether there is enough physical memory.](#Physical)  
  
-   [Determine how much memory the managed heap is committing.](#ManagedHeapCommit)  
  
-   [Determine how much memory the managed heap reserves.](#ManagedHeapReserve)  
  
-   [Determine large objects in generation 2.](#ExamineGen2)  
  
-   [Determine references to objects.](#ObjRef)  
  
-   [Determine whether a finalizer has been run.](#Induce)  
  
-   [Determine whether there are objects waiting to be finalized.](#Finalize)  
  
-   [Determine the amount of free space in the managed heap.](#Fragmented)  
  
-   [Determine the number of pinned objects.](#Pinned)  
  
-   [Determine the length of time in a garbage collection.](#TimeInGC)  
  
-   [Determine what triggered a garbage collection.](#Triggered)  
  
-   [Determine whether high CPU usage is caused by garbage collection.](#HighCPU)  
  
<a name="IsGC"></a>   
##### To determine whether the problem is caused by garbage collection  
  
-   Examine the following two memory performance counters:  
  
    -   **% Time in GC**. Displays the percentage of elapsed time that was spent performing a garbage collection after the last garbage collection cycle. Use this counter to determine whether the garbage collector is spending too much time to make managed heap space available. If the time spent in garbage collection is relatively low, that could indicate a resource problem outside the managed heap. This counter may not be accurate when concurrent or background garbage collection is involved.  
  
    -   **# Total committed Bytes**. Displays the amount of virtual memory currently committed by the garbage collector. Use this counter to determine whether the memory consumed by the garbage collector is an excessive portion of the memory that your application uses.  
  
     Most of the memory performance counters are updated at the end of each garbage collection. Therefore, they may not reflect the current conditions that you want information about.  
  
<a name="OOMIsManaged"></a>   
##### To determine whether the out-of-memory exception is managed  
  
1.  In the WinDbg or Visual Studio debugger with the SOS debugger extension loaded, type the print exception (**pe**) command:  
  
     **!pe**  
  
     If the exception is managed, <xref:System.OutOfMemoryException> is displayed as the exception type, as shown in the following example.  
  
    ```  
    Exception object: 39594518  
    Exception type: System.OutOfMemoryException  
    Message: <none>  
    InnerException: <none>  
    StackTrace (generated):  
    ```  
  
2.  If the output does not specify an exception, you have to determine which thread the out-of-memory exception is from. Type the following command in the debugger to show all the threads with their call stacks:  
  
     **~\*kb**  
  
     The thread with the stack that has exception calls is indicated by the `RaiseTheException` argument. This is the managed exception object.  
  
    ```  
    28adfb44 7923918f 5b61f2b4 00000000 5b61f2b4 mscorwks!RaiseTheException+0xa0   
    ```  
  
3.  You can use the following command to dump nested exceptions.  
  
     **!pe -nested**  
  
     If you do not find any exceptions, the out-of-memory exception originated from unmanaged code.  
  
<a name="GetVM"></a>   
##### To determine how much virtual memory can be reserved  
  
-   In WinDbg with the SOS debugger extension loaded, type the following command to get the largest free region:  
  
     **!address -summary**  
  
     The largest free region is displayed as shown in the following output.  
  
    ```  
    Largest free region: Base 54000000 - Size 0003A980  
    ```  
  
     In this example, the size of the largest free region is approximately 24000 KB (3A980 in hexadecimal). This region is much smaller than what the garbage collector needs for a segment.  
  
     -or-  
  
-   Use the **vmstat** command:  
  
     **!vmstat**  
  
     The largest free region is the largest value in the MAXIMUM column, as shown in the following output.  
  
    ```  
    TYPE        MINIMUM   MAXIMUM     AVERAGE   BLK COUNT   TOTAL  
    ~~~~        ~~~~~~~   ~~~~~~~     ~~~~~~~   ~~~~~~~~~~  ~~~~  
    Free:  
    Small       8K        64K         46K       36          1,671K  
    Medium      80K       864K        349K      3           1,047K  
    Large       1,384K    1,278,848K  151,834K  12          1,822,015K  
    Summary     8K        1,278,848K  35,779K   51          1,824,735K  
    ```  
  
<a name="Physical"></a>   
##### To determine whether there is enough physical memory  
  
1.  Start Windows Task Manager.  
  
2.  On the **Performance** tab, look at the committed value. (In Windows 7, look at **Commit (KB)** in the **System group**.)  
  
     If the **Total** is close to the **Limit**, you are running low on physical memory.  
  
<a name="ManagedHeapCommit"></a>   
##### To determine how much memory the managed heap is committing  
  
-   Use the `# Total committed bytes` memory performance counter to get the number of bytes that the managed heap is committing. The garbage collector commits chunks on a segment as needed, not all at the same time.  
  
    > [!NOTE]
    >  Do not use the `# Bytes in all Heaps` performance counter, because it does not represent actual memory usage by the managed heap. The size of a generation is included in this value and is actually its threshold size, that is, the size that induces a garbage collection if the generation is filled with objects. Therefore, this value is usually zero.  
  
<a name="ManagedHeapReserve"></a>   
##### To determine how much memory the managed heap reserves  
  
-   Use the `# Total reserved bytes` memory performance counter.  
  
     The garbage collector reserves memory in segments, and you can determine where a segment starts by using the **eeheap** command.  
  
    > [!IMPORTANT]
    >  Although you can determine the amount of memory the garbage collector allocates for each segment, segment size is implementation-specific and is subject to change at any time, including in periodic updates. Your app should never make assumptions about or depend on a particular segment size, nor should it attempt to configure the amount of memory available for segment allocations.  
  
-   In the WinDbg or Visual Studio debugger with the SOS debugger extension loaded, type the following command:  
  
     **!eeheap -gc**  
  
     The result is as follows.  
  
    ```  
    Number of GC Heaps: 2  
    ------------------------------  
    Heap 0 (002db550)  
    generation 0 starts at 0x02abe29c  
    generation 1 starts at 0x02abdd08  
    generation 2 starts at 0x02ab0038  
    ephemeral segment allocation context: none  
     segment    begin allocated     size  
    02ab0000 02ab0038  02aceff4 0x0001efbc(126908)  
    Large object heap starts at 0x0aab0038  
     segment    begin allocated     size  
    0aab0000 0aab0038  0aab2278 0x00002240(8768)  
    Heap Size   0x211fc(135676)  
    ------------------------------  
    Heap 1 (002dc958)  
    generation 0 starts at 0x06ab1bd8  
    generation 1 starts at 0x06ab1bcc  
    generation 2 starts at 0x06ab0038  
    ephemeral segment allocation context: none  
     segment    begin allocated     size  
    06ab0000 06ab0038  06ab3be4 0x00003bac(15276)  
    Large object heap starts at 0x0cab0038  
     segment    begin allocated     size  
    0cab0000 0cab0038  0cab0048 0x00000010(16)  
    Heap Size    0x3bbc(15292)  
    ------------------------------  
    GC Heap Size   0x24db8(150968)  
    ```  
  
     The addresses indicated by "segment" are the starting addresses of the segments.  
  
<a name="ExamineGen2"></a>   
##### To determine large objects in generation 2  
  
-   In the WinDbg or Visual Studio debugger with the SOS debugger extension loaded, type the following command:  
  
     **!dumpheap –stat**  
  
     If the managed heap is big, **dumpheap** may take a while to finish.  
  
     You can start analyzing from the last few lines of the output, because they list the objects that use the most space. For example:  
  
    ```  
    2c6108d4   173712     14591808 DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo  
    00155f80      533     15216804      Free  
    7a747c78   791070     15821400 System.Collections.Specialized.ListDictionary+DictionaryNode  
    7a747bac   700930     19626040 System.Collections.Specialized.ListDictionary  
    2c64e36c    78644     20762016 DevExpress.XtraEditors.ViewInfo.TextEditViewInfo  
    79124228   121143     29064120 System.Object[]  
    035f0ee4    81626     35588936 Toolkit.TlkOrder  
    00fcae40     6193     44911636 WaveBasedStrategy.Tick_Snap[]  
    791242ec    40182     90664128 System.Collections.Hashtable+bucket[]  
    790fa3e0  3154024    137881448 System.String  
    Total 8454945 objects  
    ```  
  
     The last object listed is a string and occupies the most space. You can examine your application to see how your string objects can be optimized. To see strings that are between 150 and 200 bytes, type the following:  
  
     **!dumpheap -type System.String -min 150 -max 200**  
  
     An example of the results is as follows.  
  
    ```  
    Address  MT           Size  Gen  
    1875d2c0 790fa3e0      152    2 System.String HighlightNullStyle_Blotter_PendingOrder-11_Blotter_PendingOrder-11  
    …  
    ```  
  
     Using an integer instead of a string for an ID can be more efficient. If the same string is being repeated thousands of times, consider string interning. For more information about string interning, see the reference topic for the <xref:System.String.Intern%2A?displayProperty=nameWithType> method.  
  
<a name="ObjRef"></a>   
##### To determine references to objects  
  
-   In WinDbg with the SOS debugger extension loaded, type the following command to list references to objects:  
  
     **!gcroot**  
  
     `-or-`  
  
-   To determine the references for a specific object, include the address:  
  
     **!gcroot 1c37b2ac**  
  
     Roots found on stacks may be false positives. For more information, use the command `!help gcroot`.  
  
    ```  
    ebx:Root:19011c5c(System.Windows.Forms.Application+ThreadContext)->  
    19010b78(DemoApp.FormDemoApp)->  
    19011158(System.Windows.Forms.PropertyStore)->  
    … [omitted]  
    1c3745ec(System.Data.DataTable)->  
    1c3747a8(System.Data.DataColumnCollection)->  
    1c3747f8(System.Collections.Hashtable)->  
    1c376590(System.Collections.Hashtable+bucket[])->  
    1c376c98(System.Data.DataColumn)->  
    1c37b270(System.Data.Common.DoubleStorage)->  
    1c37b2ac(System.Double[])  
    Scan Thread 0 OSTHread 99c  
    Scan Thread 6 OSTHread 484  
    ```  
  
     The **gcroot** command can take a long time to finish. Any object that is not reclaimed by garbage collection is a live object. This means that some root is directly or indirectly holding onto the object, so **gcroot** should return path information to the object. You should examine the graphs returned and see why these objects are still referenced.  
  
<a name="Induce"></a>   
##### To determine whether a finalizer has been run  
  
-   Run a test program that contains the following code:  
  
    ```  
    GC.Collect();  
    GC.WaitForPendingFinalizers();  
    GC.Collect();  
    ```  
  
     If the test resolves the problem, this means that the garbage collector was not reclaiming objects, because the finalizers for those objects had been suspended. The <xref:System.GC.WaitForPendingFinalizers%2A?displayProperty=nameWithType> method enables the finalizers to complete their tasks, and fixes the problem.  
  
<a name="Finalize"></a>   
##### To determine whether there are objects waiting to be finalized  
  
1.  In the WinDbg or Visual Studio debugger with the SOS debugger extension loaded, type the following command:  
  
     **!finalizequeue**  
  
     Look at the number of objects that are ready for finalization. If the number is high, you must examine why these finalizers cannot progress at all or cannot progress fast enough.  
  
2.  To get an output of threads, type the following command:  
  
     **threads -special**  
  
     This command provides output such as the following.  
  
    ```  
       OSID     Special thread type  
    2    cd0    DbgHelper   
    3    c18    Finalizer   
    4    df0    GC SuspendEE   
    ```  
  
     The finalizer thread indicates which finalizer, if any, is currently being run. When a finalizer thread is not running any finalizers, it is waiting for an event to tell it to do its work. Most of the time you will see the finalizer thread in this state because it runs at THREAD_HIGHEST_PRIORITY and is supposed to finish running finalizers, if any, very quickly.  
  
<a name="Fragmented"></a>   
##### To determine the amount of free space in the managed heap  
  
-   In the WinDbg or Visual Studio debugger with the SOS debugger extension loaded, type the following command:  
  
     **!dumpheap -type Free -stat**  
  
     This command displays the total size of all the free objects on the managed heap, as shown in the following example.  
  
    ```  
    total 230 objects  
    Statistics:  
          MT    Count    TotalSize Class Name  
    00152b18      230     40958584      Free  
    Total 230 objects  
    ```  
  
-   To determine the free space in generation 0, type the following command for memory consumption information by generation:  
  
     **!eeheap -gc**  
  
     This command displays output similar to the following. The last line shows the ephemeral segment.  
  
    ```  
    Heap 0 (0015ad08)  
    generation 0 starts at 0x49521f8c  
    generation 1 starts at 0x494d7f64  
    generation 2 starts at 0x007f0038  
    ephemeral segment allocation context: none  
    segment  begin     allocated  size  
    00178250 7a80d84c  7a82f1cc   0x00021980(137600)  
    00161918 78c50e40  78c7056c   0x0001f72c(128812)  
    007f0000 007f0038  047eed28   0x03ffecf0(67103984)  
    3a120000 3a120038  3a3e84f8   0x002c84c0(2917568)  
    46120000 46120038  49e05d04   0x03ce5ccc(63855820)  
    ```  
  
-   Calculate the space used by generation 0:  
  
     **? 49e05d04-0x49521f8c**  
  
     The result is as follows. Generation 0 is approximately 9 MB.  
  
    ```  
    Evaluate expression: 9321848 = 008e3d78  
    ```  
  
-   The following command dumps the free space within the generation 0 range:  
  
     **!dumpheap -type Free -stat 0x49521f8c 49e05d04**  
  
     The result is as follows.  
  
    ```  
    ------------------------------  
    Heap 0  
    total 409 objects  
    ------------------------------  
    Heap 1  
    total 0 objects  
    ------------------------------  
    Heap 2  
    total 0 objects  
    ------------------------------  
    Heap 3  
    total 0 objects  
    ------------------------------  
    total 409 objects  
    Statistics:  
          MT    Count TotalSize Class Name  
    0015a498      409   7296540      Free  
    Total 409 objects  
    ```  
  
     This output shows that the generation 0 portion of the heap is using 9 MB of space for objects and has 7 MB free. This analysis shows the extent to which generation 0 contributes to fragmentation. This amount of heap usage should be discounted from the total amount as the cause of fragmentation by long-term objects.  
  
<a name="Pinned"></a>   
##### To determine the number of pinned objects  
  
-   In the WinDbg or Visual Studio debugger with the SOS debugger extension loaded, type the following command:  
  
     **!gchandles**  
  
     The statistics displayed includes the number of pinned handles, as the following example shows.  
  
    ```  
    GC Handle Statistics:  
    Strong Handles:      29  
    Pinned Handles:      10  
    ```  
  
<a name="TimeInGC"></a>   
##### To determine the length of time in a garbage collection  
  
-   Examine the `% Time in GC` memory performance counter.  
  
     The value is calculated by using a sample interval time. Because the counters are updated at the end of each garbage collection, the current sample will have the same value as the previous sample if no collections occurred during the interval.  
  
     Collection time is obtained by multiplying the sample interval time with the percentage value.  
  
     The following data shows four sampling intervals of two seconds, for an 8-second study. The `Gen0`, `Gen1`, and `Gen2` columns show the number of garbage collections that occurred during that interval for that generation.  
  
    ```  
    Interval    Gen0    Gen1    Gen2    % Time in GC  
           1       9       3       1              10  
           2      10       3       1               1  
           3      11       3       1               3  
           4      11       3       1               3  
    ```  
  
     This information does not show when the garbage collection occurred, but you can determine the number of garbage collections that occurred in an interval of time. Assuming the worst case, the tenth generation 0 garbage collection finished at the start of the second interval, and the eleventh generation 0 garbage collection finished at the end of the fifth interval. The time between the end of the tenth and the end of the eleventh garbage collection is about 2 seconds, and the performance counter shows 3%, so the duration of the eleventh generation 0 garbage collection was (2 seconds * 3% = 60ms).  
  
     In this example, there are 5 periods.  
  
    ```  
    Interval    Gen0    Gen1    Gen2     % Time in GC  
           1       9       3       1                3  
           2      10       3       1                1  
           3      11       4       2                1  
           4      11       4       2                1  
           5      11       4       2               20  
    ```  
  
     The second generation 2 garbage collection started during the third interval and finished at the fifth interval. Assuming the worst case, the last garbage collection was for a generation 0 collection that finished at the start of the second interval, and the generation 2 garbage collection finished at the end of the fifth interval. Therefore, the time between the end of the generation 0 garbage collection and the end of the generation 2 garbage collection is 4 seconds. Because the `% Time in GC` counter is 20%, the maximum amount of time the generation 2 garbage collection could have taken is (4 seconds * 20% = 800ms).  
  
-   Alternatively, you can determine the length of a garbage collection by using [garbage collection ETW events](../../../docs/framework/performance/garbage-collection-etw-events.md), and analyze the information to determine the duration of garbage collection.  
  
     For example, the following data shows an event sequence that occurred during a non-concurrent garbage collection.  
  
    ```  
    Timestamp    Event name  
    513052        GCSuspendEEBegin_V1  
    513078        GCSuspendEEEnd  
    513090        GCStart_V1  
    517890        GCEnd_V1  
    517894        GCHeapStats  
    517897        GCRestartEEBegin  
    517918        GCRestartEEEnd  
    ```  
  
     Suspending the managed thread took 26us (`GCSuspendEEEnd` – `GCSuspendEEBegin_V1`).  
  
     The actual garbage collection took 4.8ms (`GCEnd_V1` – `GCStart_V1`).  
  
     Resuming the managed threads took 21us (`GCRestartEEEnd` – `GCRestartEEBegin`).  
  
     The following output provides an example for background garbage collection, and includes the process, thread, and event fields. (Not all data is shown.)  
  
    ```  
    timestamp(us)    event name            process    thread    event field  
    42504385        GCSuspendEEBegin_V1    Test.exe    4372             1  
    42504648        GCSuspendEEEnd         Test.exe    4372          
    42504816        GCStart_V1             Test.exe    4372        102019  
    42504907        GCStart_V1             Test.exe    4372        102020  
    42514170        GCEnd_V1               Test.exe    4372          
    42514204        GCHeapStats            Test.exe    4372        102020  
    42832052        GCRestartEEBegin       Test.exe    4372          
    42832136        GCRestartEEEnd         Test.exe    4372          
    63685394        GCSuspendEEBegin_V1    Test.exe    4744             6  
    63686347        GCSuspendEEEnd         Test.exe    4744          
    63784294        GCRestartEEBegin       Test.exe    4744          
    63784407        GCRestartEEEnd         Test.exe    4744          
    89931423        GCEnd_V1               Test.exe    4372        102019  
    89931464        GCHeapStats            Test.exe    4372          
    ```  
  
     The `GCStart_V1` event at 42504816 indicates that this is a background garbage collection, because the last field is `1`. This becomes garbage collection No. 102019.  
  
     The `GCStart` event occurs because there is a need for an ephemeral garbage collection before you start a background garbage collection. This becomes garbage collection No. 102020.  
  
     At 42514170, garbage collection No. 102020 finishes. The managed threads are restarted at this point. This is completed on thread 4372, which triggered this background garbage collection.  
  
     On thread 4744, a suspension occurs. This is the only time at which the background garbage collection has to suspend managed threads. This duration is approximately 99ms ((63784407-63685394)/1000).  
  
     The `GCEnd` event for the background garbage collection is at 89931423. This means that the background garbage collection lasted for about 47seconds ((89931423-42504816)/1000).  
  
     While the managed threads are running, you can see any number of ephemeral garbage collections occurring.  
  
<a name="Triggered"></a>   
##### To determine what triggered a garbage collection  
  
-   In the WinDbg or Visual Studio debugger with the SOS debugger extension loaded, type the following command to show all the threads with their call stacks:  
  
     **~\*kb**  
  
     This command displays output similar to the following.  
  
    ```  
    0012f3b0 79ff0bf8 mscorwks!WKS::GCHeap::GarbageCollect   
    0012f454 30002894 mscorwks!GCInterface::CollectGeneration+0xa4  
    0012f490 79fa22bd fragment_ni!request.Main(System.String[])+0x48  
    ```  
  
     If the garbage collection was caused by a low memory notification from the operating system, the call stack is similar, except that the thread is the finalizer thread. The finalizer thread gets an asynchronous low memory notification and induces the garbage collection.  
  
     If the garbage collection was caused by memory allocation, the stack appears as follows:  
  
    ```  
    0012f230 7a07c551 mscorwks!WKS::GCHeap::GarbageCollectGeneration  
    0012f2b8 7a07cba8 mscorwks!WKS::gc_heap::try_allocate_more_space+0x1a1  
    0012f2d4 7a07cefb mscorwks!WKS::gc_heap::allocate_more_space+0x18  
    0012f2f4 7a02a51b mscorwks!WKS::GCHeap::Alloc+0x4b  
    0012f310 7a02ae4c mscorwks!Alloc+0x60  
    0012f364 7a030e46 mscorwks!FastAllocatePrimitiveArray+0xbd  
    0012f424 300027f4 mscorwks!JIT_NewArr1+0x148  
    000af70f 3000299f fragment_ni!request..ctor(Int32, Single)+0x20c  
    0000002a 79fa22bd fragment_ni!request.Main(System.String[])+0x153  
    ```  
  
     A just-in-time helper (`JIT_New*`) eventually calls `GCHeap::GarbageCollectGeneration`. If you determine that generation 2 garbage collections are caused by allocations, you must determine which objects are collected by a generation 2 garbage collection and how to avoid them. That is, you want to determine the difference between the start and the end of a generation 2 garbage collection, and the objects that caused the generation 2 collection.  
  
     For example, type the following command in the debugger to show the beginning of a generation 2 collection:  
  
     **!dumpheap –stat**  
  
     Example output (abridged to show the objects that use the most space):  
  
    ```  
    79124228    31857      9862328 System.Object[]  
    035f0384    25668     11601936 Toolkit.TlkPosition  
    00155f80    21248     12256296      Free  
    79103b6c   297003     13068132 System.Threading.ReaderWriterLock  
    7a747ad4   708732     14174640 System.Collections.Specialized.HybridDictionary  
    7a747c78   786498     15729960 System.Collections.Specialized.ListDictionary+DictionaryNode  
    7a747bac   700298     19608344 System.Collections.Specialized.ListDictionary  
    035f0ee4    89192     38887712 Toolkit.TlkOrder  
    00fcae40     6193     44911636 WaveBasedStrategy.Tick_Snap[]  
    7912c444    91616     71887080 System.Double[]  
    791242ec    32451     82462728 System.Collections.Hashtable+bucket[]  
    790fa3e0  2459154    112128436 System.String  
    Total 6471774 objects  
    ```  
  
     Repeat the command at the end of generation 2:  
  
     **!dumpheap –stat**  
  
     Example output (abridged to show the objects that use the most space):  
  
    ```  
    79124228    26648      9314256 System.Object[]  
    035f0384    25668     11601936 Toolkit.TlkPosition  
    79103b6c   296770     13057880 System.Threading.ReaderWriterLock  
    7a747ad4   708730     14174600 System.Collections.Specialized.HybridDictionary  
    7a747c78   786497     15729940 System.Collections.Specialized.ListDictionary+DictionaryNode  
    7a747bac   700298     19608344 System.Collections.Specialized.ListDictionary  
    00155f80    13806     34007212      Free  
    035f0ee4    89187     38885532 Toolkit.TlkOrder  
    00fcae40     6193     44911636 WaveBasedStrategy.Tick_Snap[]  
    791242ec    32370     82359768 System.Collections.Hashtable+bucket[]  
    790fa3e0  2440020    111341808 System.String  
    Total 6417525 objects  
    ```  
  
     The `double[]` objects disappeared from the end of the output, which means that they were collected. These objects account for approximately 70 MB. The remaining objects did not change much. Therefore, these `double[]` objects were the reason why this generation 2 garbage collection occurred. Your next step is to determine why the `double[]` objects are there and why they died. You can ask the code developer where these objects came from, or you can use the **gcroot** command.  
  
<a name="HighCPU"></a>   
##### To determine whether high CPU usage is caused by garbage collection  
  
-   Correlate the `% Time in GC` memory performance counter value with the process time.  
  
     If the `% Time in GC` value spikes at the same time as process time, garbage collection is causing a high CPU usage. Otherwise, profile the application to find where the high usage is occurring.  
  
## See Also  
 [Garbage Collection](../../../docs/standard/garbage-collection/index.md)
