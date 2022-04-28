---
title: Debug Threadpool Starvation
description: A tutorial that walks you through debugging and fixing a threadpool starvation issue on .NET Core
ms.topic: tutorial
ms.date: 04/19/2022
---

# Debug Threadpool Starvation

**This article applies to: ✔️** .NET Core 3.1 and later versions

In this tutorial, you'll learn how to debug a threadpool starvation scenario. Threadpool starvation occurs when the threadpool has no available threads to process new work items and it often causes applications to respond very slowly. Using the provided example [ASP.NET Core web app](/samples/dotnet/samples/diagnostic-scenarios), you can cause threadpool starvation intentionally and learn how to diagnose it.

In this tutorial, you will:

> [!div class="checklist"]
>
> - Investigate an app that is responding to requests slowly
> - Use the dotnet-counters tool to identify threadpool starvation is likely occuring
> - Use the dotnet-stack tool to determine what work is keeping the threadpool threads busy

## Prerequisites

The tutorial uses:

- [.NET Core 6.0 SDK](https://dotnet.microsoft.com/download/dotnet) to build and run the sample app
- [Sample web app](/samples/dotnet/samples/diagnostic-scenarios) which will demonstrate threadpool starvation behavior
- [Bombadier](https://github.com/codesenberg/bombardier/releases) generates load for the sample web app
- [dotnet-counters](dotnet-counters.md) to observe performance counters
- [dotnet-stack](dotnet-stack.md) to examine thread stacks

## Running the sample app

1. Download the code for the [sample app](/samples/dotnet/samples/diagnostic-scenarios) and build it using the .NET SDK:

  ```dotnetcli
  E:\demo\DiagnosticScenarios>dotnet build
  Microsoft (R) Build Engine version 17.1.1+a02f73656 for .NET
  Copyright (C) Microsoft Corporation. All rights reserved.
  
    Determining projects to restore...
    All projects are up-to-date for restore.
    DiagnosticScenarios -> E:\demo\DiagnosticScenarios\bin\Debug\net6.0\DiagnosticScenarios.dll
  
  Build succeeded.
      0 Warning(s)
      0 Error(s)
  
  Time Elapsed 00:00:01.26
  ```

1. Run the app:

  ```dotnetcli
  E:\demo\DiagnosticScenarios>bin\Debug\net6.0\DiagnosticScenarios.exe
  info: Microsoft.Hosting.Lifetime[14]
        Now listening on: http://localhost:5000
  info: Microsoft.Hosting.Lifetime[14]
        Now listening on: https://localhost:5001
  info: Microsoft.Hosting.Lifetime[0]
        Application started. Press Ctrl+C to shut down.
  info: Microsoft.Hosting.Lifetime[0]
        Hosting environment: Production
  info: Microsoft.Hosting.Lifetime[0]
        Content root path: E:\demo\DiagnosticScenarios
  ```

If you use a web browser and send requests to `https://localhost:5001/api/diagscenario/taskwait` you should see the response "success:taskwait" returned after about 500ms. This shows the web server is serving traffic as expected.

## Observing slow performance

The demo web server has several endpoints which mock doing a database request and then returning a response to the user. Each of these endpoints has a delay of approximately 500ms when serving requests one at a time but the performance is much worse when the web server is subjected to some load. Download the [Bombadier](https://github.com/codesenberg/bombardier/releases) load testing tool and observe the difference in latency when 125 concurrent requests are sent to each endpoint.

```dotnetcli
>bombardier-windows-amd64.exe https://localhost:5001/api/diagscenario/taskwait
Bombarding https://localhost:5001/api/diagscenario/taskwait for 10s using 125 connection(s)
[=================================================================================================================] 10s
Done!
Statistics        Avg      Stdev        Max
  Reqs/sec        33.06     234.67    3313.54
  Latency         3.48s      1.39s     10.79s
  HTTP codes:
    1xx - 0, 2xx - 454, 3xx - 0, 4xx - 0, 5xx - 0
    others - 0
  Throughput:    75.37KB/s
```

```dotnetcli
>bombardier-windows-amd64.exe https://localhost:5001/api/diagscenario/tasksleepwait
Bombarding https://localhost:5001/api/diagscenario/tasksleepwait for 10s using 125 connection(s)
[=================================================================================================================] 10s
Done!
Statistics        Avg      Stdev        Max
  Reqs/sec         1.61      35.25     788.91
  Latency        15.42s      2.18s     18.30s
  HTTP codes:
    1xx - 0, 2xx - 140, 3xx - 0, 4xx - 0, 5xx - 0
    others - 0
  Throughput:    36.57KB/s
```

Both of these endpoints show dramatically more than the 500ms average latency when load is high (3.48s and 15.42s respectively). If you run this example on an older version of .NET Core you are likely to see both examples perform equally badly. .NET 6 has updated threadpool heuristics that reduce the performance impact of the bad coding pattern used in the first example.

## Detecting threadpool starvation

If you observed the behavior above on a real world service you would know it is responding slowly under load but you wouldn't know the cause. [dotnet-counters](dotnet-counters.md) is a tool that can show live performance counters. These counters can provide clues about certain problems and are often easy to get. In production environments you might have similar counters provided by remote monitoring tools and web dashboards. Install dotnet-counters and begin monitoring the web service:

```dotnetcli
>dotnet-counters monitor -n DiagnosticScenarios
Press p to pause, r to resume, q to quit.
    Status: Running

[System.Runtime]
    % Time in GC since last GC (%)                                 0
    Allocation Rate (B / 1 sec)                                    0
    CPU Usage (%)                                                  0
    Exception Count (Count / 1 sec)                                0
    GC Committed Bytes (MB)                                        0
    GC Fragmentation (%)                                           0
    GC Heap Size (MB)                                             34
    Gen 0 GC Count (Count / 1 sec)                                 0
    Gen 0 Size (B)                                                 0
    Gen 1 GC Count (Count / 1 sec)                                 0
    Gen 1 Size (B)                                                 0
    Gen 2 GC Count (Count / 1 sec)                                 0
    Gen 2 Size (B)                                                 0
    IL Bytes Jitted (B)                                      279,021
    LOH Size (B)                                                   0
    Monitor Lock Contention Count (Count / 1 sec)                  0
    Number of Active Timers                                        0
    Number of Assemblies Loaded                                  121
    Number of Methods Jitted                                   3,223
    POH (Pinned Object Heap) Size (B)                              0
    ThreadPool Completed Work Item Count (Count / 1 sec)           0
    ThreadPool Queue Length                                        0
    ThreadPool Thread Count                                        1
    Time spent in JIT (ms / 1 sec)                                 0.387
    Working Set (MB)                                              87
```

The counters above are an example while the web server was not serving any requests. Run Bombadier again with the `api/diagscenario/tasksleepwait` endpoint and sustained load for 2 minutes so there is plenty of time to observe what happens to the performance counters.

```dotnetcli
>bombardier-windows-amd64.exe https://localhost:5001/api/diagscenario/tasksleepwait -d 120s
```

Threadpool starvation occurs when there are no free threads to handle the queued workitems and the runtime responds by increasing the number of threadpool threads. You should observe the `ThreadPool Thread Count` rapidly increase to 2-3x the number of processor cores on your machine and then further threads are added 1-2 per second until eventually stabilizing somewhere above 125. The slow and steady increase of threadpool threads combined with CPU Usage much less than 100% are the key signals that threadpool starvation is currently a performance bottleneck. The thread count increase will continue until either the threadpool hits the maximum number of threads, enough threads have been created to satisfy all the incoming workitems, or the CPU has been saturated. Often, but not always, threadpool starvation will also show large values for `ThreadPool Queue Length` and low values for `ThreadPool Completed Work Item Count` showing that there is a large amount of pending work and very little work being completed. Here is an example of the counters while the thread count is still rising:

```dotnetcli
Press p to pause, r to resume, q to quit.
    Status: Running

[System.Runtime]
    % Time in GC since last GC (%)                                 0
    Allocation Rate (B / 1 sec)                               24,480
    CPU Usage (%)                                                  0
    Exception Count (Count / 1 sec)                                0
    GC Committed Bytes (MB)                                       56
    GC Fragmentation (%)                                          40.603
    GC Heap Size (MB)                                             89
    Gen 0 GC Count (Count / 1 sec)                                 0
    Gen 0 Size (B)                                         6,306,160
    Gen 1 GC Count (Count / 1 sec)                                 0
    Gen 1 Size (B)                                         8,061,400
    Gen 2 GC Count (Count / 1 sec)                                 0
    Gen 2 Size (B)                                               192
    IL Bytes Jitted (B)                                      279,263
    LOH Size (B)                                              98,576
    Monitor Lock Contention Count (Count / 1 sec)                  0
    Number of Active Timers                                      124
    Number of Assemblies Loaded                                  121
    Number of Methods Jitted                                   3,227
    POH (Pinned Object Heap) Size (B)                      1,197,336
    ThreadPool Completed Work Item Count (Count / 1 sec)           2
    ThreadPool Queue Length                                       29
    ThreadPool Thread Count                                       96
    Time spent in JIT (ms / 1 sec)                                 0
    Working Set (MB)                                             152
```

Once the count of threadpool threads stabilizes the threadpool is no longer starving, but if it stabilizes at a high value (more than ~3x the number of processor cores) that usually indicates the application code is blocking some threadpool threads and the threadpool is compensating by running with more threads. Running steady at high thread counts won't necessarily have large impacts on request latency, but if load varies dramatically over time or the app will be periodically restarted then each time the threadpool is likely to enter a period of starvation where it is slowly increasing threads and delivering poor request latency. Each thread also consumes memory which provides another benefit to reducing the total number of threads needed.

Starting in .NET 6 the threadpool heuristics were modified to scale up the number of threadpool threads much faster in response to certain blocking Task APIs. Threadpool starvation can still occur with these APIs, but the duration is much briefer than it was with older .NET versions because the runtime responds more quickly. Run Bombadier again with the `api/diagscenario/taskwait` endpoint:

```dotnetcli
>bombardier-windows-amd64.exe https://localhost:5001/api/diagscenario/taskwait -d 120s
```

On .NET 6 you should observe the threadpool increase the thread count more quickly than before and then stabilize at a high number of threads. Threadpool starvation is occuring while the thread count is climbing.

## Resolving threadpool starvation

To eliminate threadpool starvation threadpool threads need to remain unblocked so that they are available to handle incoming workitems. There are two ways to determine what each thread was doing, either using the [dotnet-stack](dotnet-stack.md) tool or capturing a dump with [dotnet-dump](dotnet-dump.md) that can be viewed in [Visual Studio](/visualstudio/debugger/using-dump-files). dotnet-stack can be faster because it shows the thread stacks immediately on the console, but Visual Studio dump debugging offers better visualizations that map frames to source, Just My Code can filter out runtime implementation frames, and the Parallel Stacks feature can help group large numbers of threads with similar stacks. This tutorial shows the dotnet-stack option. See the [diagnosing threadpool starvation tutorial video](/shows/on-net/diagnosing-thread-pool-exhaustion-issues-in-net-core-apps) for an example of investigating the thread stacks using Visual Studio.

Run Bombadier again to put the web server under load:

```dotnetcli
>bombardier-windows-amd64.exe https://localhost:5001/api/diagscenario/taskwait -d 120s
```

Then run dotnet-stack to see the thread stack traces:

```dotnetcli
>dotnet-stack report -n DiagnosticScenarios
```

You should see a long output containing a large number of stacks, many of which look like this:

```dotnetcli
Thread (0x25968):
  [Native Frames]
  System.Private.CoreLib.il!System.Threading.ManualResetEventSlim.Wait(int32,value class System.Threading.CancellationToken)
  System.Private.CoreLib.il!System.Threading.Tasks.Task.SpinThenBlockingWait(int32,value class System.Threading.CancellationToken)
  System.Private.CoreLib.il!System.Threading.Tasks.Task.InternalWaitCore(int32,value class System.Threading.CancellationToken)
  System.Private.CoreLib.il!System.Threading.Tasks.Task`1[System.__Canon].GetResultCore(bool)
  DiagnosticScenarios!testwebapi.Controllers.DiagScenarioController.TaskWait()
  Anonymously Hosted DynamicMethods Assembly!dynamicClass.lambda_method1(pMT: 00007FF7A8CBF658,class System.Object,class System.Object[])
  Microsoft.AspNetCore.Mvc.Core.il!Microsoft.AspNetCore.Mvc.Infrastructure.ActionMethodExecutor+SyncObjectResultExecutor.Execute(class Microsoft.AspNetCore.Mvc.Infrastructure.IActionResultTypeMapper,class Microsoft.Extensions.Internal.ObjectMethodExecutor,class System.Object,class System.Object[])
  Microsoft.AspNetCore.Mvc.Core.il!Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeActionMethodAsync()
  Microsoft.AspNetCore.Mvc.Core.il!Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(value class State&,value class Scope&,class System.Object&,bool&)
  Microsoft.AspNetCore.Mvc.Core.il!Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeNextActionFilterAsync()
  Microsoft.AspNetCore.Mvc.Core.il!Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(value class State&,value class Scope&,class System.Object&,bool&)
  Microsoft.AspNetCore.Mvc.Core.il!Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeNextActionFilterAsync()
  Microsoft.AspNetCore.Mvc.Core.il!Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(value class State&,value class Scope&,class System.Object&,bool&)
  Microsoft.AspNetCore.Mvc.Core.il!Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeInnerFilterAsync()
  Microsoft.AspNetCore.Mvc.Core.il!Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.Next(value class State&,value class Scope&,class System.Object&,bool&)
  Microsoft.AspNetCore.Mvc.Core.il!Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.InvokeFilterPipelineAsync()
  Microsoft.AspNetCore.Mvc.Core.il!Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.InvokeAsync()
  Microsoft.AspNetCore.Mvc.Core.il!Microsoft.AspNetCore.Mvc.Routing.ControllerRequestDelegateFactory+<>c__DisplayClass10_0.<CreateRequestDelegate>b__0(class Microsoft.AspNetCore.Http.HttpContext)
  Microsoft.AspNetCore.Routing.il!Microsoft.AspNetCore.Routing.EndpointMiddleware.Invoke(class Microsoft.AspNetCore.Http.HttpContext)
  Microsoft.AspNetCore.Authorization.Policy.il!Microsoft.AspNetCore.Authorization.AuthorizationMiddleware+<Invoke>d__6.MoveNext()
  System.Private.CoreLib.il!System.Runtime.CompilerServices.AsyncMethodBuilderCore.Start(!!0&)
  Microsoft.AspNetCore.Authorization.Policy.il!Microsoft.AspNetCore.Authorization.AuthorizationMiddleware.Invoke(class Microsoft.AspNetCore.Http.HttpContext)
  Microsoft.AspNetCore.HttpsPolicy.il!Microsoft.AspNetCore.HttpsPolicy.HttpsRedirectionMiddleware.Invoke(class Microsoft.AspNetCore.Http.HttpContext)
  Microsoft.AspNetCore.HttpsPolicy.il!Microsoft.AspNetCore.HttpsPolicy.HstsMiddleware.Invoke(class Microsoft.AspNetCore.Http.HttpContext)
  Microsoft.AspNetCore.HostFiltering.il!Microsoft.AspNetCore.HostFiltering.HostFilteringMiddleware.Invoke(class Microsoft.AspNetCore.Http.HttpContext)
  Microsoft.AspNetCore.Server.Kestrel.Core.il!Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpProtocol+<ProcessRequests>d__223`1[System.__Canon].MoveNext()
  System.Private.CoreLib.il!System.Threading.ExecutionContext.RunInternal(class System.Threading.ExecutionContext,class System.Threading.ContextCallback,class System.Object)
  System.Private.CoreLib.il!System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1+AsyncStateMachineBox`1[System.Threading.Tasks.VoidTaskResult,Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpProtocol+<ProcessRequests>d__223`1[System.__Canon]].MoveNext(class System.Threading.Thread)
  System.Private.CoreLib.il!System.Threading.Tasks.AwaitTaskContinuation.RunOrScheduleAction(class System.Runtime.CompilerServices.IAsyncStateMachineBox,bool)
  System.Private.CoreLib.il!System.Threading.Tasks.Task.RunContinuations(class System.Object)
  System.IO.Pipelines.il!System.IO.Pipelines.StreamPipeReader+<<ReadAsync>g__Core|36_0>d.MoveNext()
  System.Private.CoreLib.il!System.Threading.ExecutionContext.RunInternal(class System.Threading.ExecutionContext,class System.Threading.ContextCallback,class System.Object)
  System.Private.CoreLib.il!System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1+AsyncStateMachineBox`1[System.IO.Pipelines.ReadResult,System.IO.Pipelines.StreamPipeReader+<<ReadAsync>g__Core|36_0>d].MoveNext(class System.Threading.Thread)
  System.Private.CoreLib.il!System.Threading.Tasks.AwaitTaskContinuation.RunOrScheduleAction(class System.Runtime.CompilerServices.IAsyncStateMachineBox,bool)
  System.Private.CoreLib.il!System.Threading.Tasks.Task.RunContinuations(class System.Object)
  System.Private.CoreLib.il!System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1[System.Int32].SetExistingTaskResult(class System.Threading.Tasks.Task`1<!0>,!0)
  System.Net.Security.il!System.Net.Security.SslStream+<ReadAsyncInternal>d__186`1[System.Net.Security.AsyncReadWriteAdapter].MoveNext()
  System.Private.CoreLib.il!System.Threading.ExecutionContext.RunInternal(class System.Threading.ExecutionContext,class System.Threading.ContextCallback,class System.Object)
  System.Private.CoreLib.il!System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1+AsyncStateMachineBox`1[System.Int32,System.Net.Security.SslStream+<ReadAsyncInternal>d__186`1[System.Net.Security.AsyncReadWriteAdapter]].MoveNext(class System.Threading.Thread)
  Microsoft.AspNetCore.Server.Kestrel.Core.il!Microsoft.AspNetCore.Server.Kestrel.Core.Internal.DuplexPipeStream+<ReadAsyncInternal>d__27.MoveNext()
  System.Private.CoreLib.il!System.Threading.ExecutionContext.RunInternal(class System.Threading.ExecutionContext,class System.Threading.ContextCallback,class System.Object)
  System.Private.CoreLib.il!System.Threading.ThreadPoolWorkQueue.Dispatch()
  System.Private.CoreLib.il!System.Threading.PortableThreadPool+WorkerThread.WorkerThreadStart()
```

The frames at the bottom of these stacks indicate that these threads are threadpool threads:

```dotnetcli
  System.Private.CoreLib.il!System.Threading.ThreadPoolWorkQueue.Dispatch()
  System.Private.CoreLib.il!System.Threading.PortableThreadPool+WorkerThread.WorkerThreadStart()
```

And the frames near the top reveal that the thread is blocked on a call to `GetResultCore(bool)` from the DiagnosticScenarioController.TaskWait() function:

```dotnetcli
Thread (0x25968):
  [Native Frames]
  System.Private.CoreLib.il!System.Threading.ManualResetEventSlim.Wait(int32,value class System.Threading.CancellationToken)
  System.Private.CoreLib.il!System.Threading.Tasks.Task.SpinThenBlockingWait(int32,value class System.Threading.CancellationToken)
  System.Private.CoreLib.il!System.Threading.Tasks.Task.InternalWaitCore(int32,value class System.Threading.CancellationToken)
  System.Private.CoreLib.il!System.Threading.Tasks.Task`1[System.__Canon].GetResultCore(bool)
  DiagnosticScenarios!testwebapi.Controllers.DiagScenarioController.TaskWait()
```

Now you can navigate to the code for this controller in the sample app Controllers/DiagnosticScenarios.cs file to see that it is calling an async API without using await. This is the [sync-over-async](https://devblogs.microsoft.com/pfxteam/should-i-expose-synchronous-wrappers-for-asynchronous-methods/) code pattern which is known to block threads and is the most common cause of threadpool starvation.

```C#
        public ActionResult<string> TaskWait()
        {
            // ...
            Customer c = PretendQueryCustomerFromDbAsync("Dana").Result;
            return "success:taskwait";
        }
```

In this case the code can be readily changed to use the async/await instead as shown in the TaskAsyncWait() endpoint. Using await allows the current thread to service other workitems while the database query is in progress. When the database lookup is complete a thread from the threadpool will resume execution. This way no thread is blocked in the code during each request:

```C#
        public async Task<ActionResult<string>> TaskAsyncWait()
        {
            // ...
            Customer c = await PretendQueryCustomerFromDbAsync("Dana");
            return "success:taskasyncwait";
        }
```

Running Bombadier to send load to the `api/diagscenario/taskasyncwait` endpoint shows that the threadpool thread count stays much lower and average latency remains near 500ms when using the async/await approach:

```dotnetcli
>bombardier-windows-amd64.exe https://localhost:5001/api/diagscenario/taskasyncwait
Bombarding https://localhost:5001/api/diagscenario/taskasyncwait for 10s using 125 connection(s)
[=================================================================================================================] 10s
Done!
Statistics        Avg      Stdev        Max
  Reqs/sec       227.92     274.27    1263.48
  Latency      532.58ms    58.64ms      1.14s
  HTTP codes:
    1xx - 0, 2xx - 2390, 3xx - 0, 4xx - 0, 5xx - 0
    others - 0
  Throughput:    98.81KB/s
```
