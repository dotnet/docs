---
description: "Learn more about: Scheduling threads"
title: "Scheduling threads"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "threading [.NET], scheduling"
  - "scheduling threads"
ms.assetid: 67e4a0eb-3095-4ea7-b20f-908faa476277
---
# Scheduling threads

Every thread has a thread priority assigned to it. Threads created within the common language runtime are initially assigned the priority of <xref:System.Threading.ThreadPriority.Normal?displayProperty=nameWithType>. Threads created outside the runtime retain the priority they had before they entered the managed environment. You can get or set the priority of any thread with the <xref:System.Threading.Thread.Priority?displayProperty=nameWithType> property.  
  
 Threads are scheduled for execution based on their priority. Even though threads are executing within the runtime, all threads are assigned processor time slices by the operating system. The details of the scheduling algorithm used to determine the order in which threads are executed vary with each operating system. Under some operating systems, the thread with the highest priority (of those threads that can be executed) is always scheduled to run first. If multiple threads with the same priority are all available, the scheduler cycles through the threads at that priority, giving each thread a fixed time slice in which to execute. As long as a thread with a higher priority is available to run, lower priority threads do not get to execute. When there are no more runnable threads at a given priority, the scheduler moves to the next lower priority and schedules the threads at that priority for execution. If a higher priority thread becomes runnable, the lower priority thread is preempted and the higher priority thread is allowed to execute once again. On top of all that, the operating system can also adjust thread priorities dynamically as an application's user interface is moved between foreground and background. Other operating systems might choose to use a different scheduling algorithm.  

## Example

Here is an example of the execution of 9 threads across all 5 priority levels from the <xref:System.Threading.Thread.Priority?displayProperty=nameWithType> enumeration where the last 5 are on highest priority level. Also, we have callback support from the previous article that in this context demonstrates that the order of thread initialization and prioritization may not always be reflected in subsequent code nor process executions start order. Meaning, we see here the parallel nature of code execution and demonstration of assigned processor time slices by the operating system for every thread. This highlights the influence and control of the environment in which threads are running. With that said, we certainly see that the highest priority threads are indeed receive priority in execution.

The following code will produce arbitrary results on each execution. However, common sequence patterns of priorities being run could be observed after running the code multiple times and analyzing the outputs.

:::code language="csharp" source="snippets/scheduling-threads/SchedulingThreads.cs":::

## See also

- [Using Threads and Threading](using-threads-and-threading.md)
- [Managed and Unmanaged Threading in Windows](managed-and-unmanaged-threading-in-windows.md)
