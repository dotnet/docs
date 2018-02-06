---
title: "WCF Performance Counters"
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
  - "performance counters [WCF]"
ms.assetid: f559b2bd-ed83-4988-97a1-e88f06646609
caps.latest.revision: 37
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WCF Performance Counters
[!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] includes a large set of performance counters to help you gauge your application's performance.  
  
## Enabling Performance Counters  
 You can enable performance counters for a [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] service through the app.config configuration file of the [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] service as follows:  
  
```xml  
<configuration>  
    <system.serviceModel>  
        <diagnostics performanceCounters="All" />  
    </system.serviceModel>  
</configuration>  
```  
  
 The `performanceCounters` attribute can be set to enable a specific type of performance counters. Valid values are  
  
-   All: All category counters (ServiceModelService, ServiceModelEndpoint and ServiceModelOperation) are enabled.  
  
-   ServiceOnly: Only ServiceModelService category counters are enabled. This is the default value.  
  
-   Off: ServiceModel* performance counters are disabled.  
  
 If you want to enable performance counters for all [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] applications, you can place the configuration settings in the Machine.config file.  Please see the **Increasing Memory Size for Performance Counters** section below for more information on configuring sufficient memory for performance counters on your machine.  
  
 If you use [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] extensibility points such as custom operation invokers, you should also emit your own performance counters. This is because if you implement an extensibility point, [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] may no longer emit the standard performance counter data in the default path. If you do not implement manual performance counter support, you may not see the performance counter data you expect.  
  
 You can also enable performance counters in your code as follows,  
  
```  
using System.Configuration;  
using System.ServiceModel.Configuration;  
using System.ServiceModel.Diagnostics;  
Configuration config = ConfigurationManager.OpenExeConfiguration(  
    ConfigurationUserLevel.None);  
ServiceModelSectionGroup sg = ServiceModelSectionGroup.GetSectionGroup(config);  
sg.Diagnostic.PerformanceCounters = PerformanceCounterScope.All;  
config.Save();  
```  
  
## Viewing Performance Data  
 To view data captured by the performance counters, you can use the Performance Monitor (Perfmon.exe) that comes with Windows. You can launch this tool by going to **Start**, and click **Run** and type `perfmon.exe` in the dialog box.  
  
> [!NOTE]
>  Performance counter instances may be released before the last messages have been processed by the endpoint dispatcher. This can result in performance data not being captured for a few messages.  
  
## Increasing Memory Size for Performance Counters  
 [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] uses separate shared memory for its performance counter categories.  
  
 By default, separate shared memory is set to a quarter the size of global performance counter memory. The default global performance counter memory is 524,288 bytes. Therefore, the three [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] performance counter categories have a default size of approximately 128KB each. Depending upon the runtime characteristics of the [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] applications on a machine, performance counter memory may be exhausted. When this happens, [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] writes an error to the application event log. The content of the error states that a performance counter was not loaded, and the entry contains the exception "System.InvalidOperationException: Custom counters file view is out of memory." If tracing is enabled at the error level, this failure is also traced. If performance counter memory is exhausted, continuing to run your [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] applications with performance counters enabled could result in performance degradation. If you are an administrator of the machine, you should configure it to allocate enough memory to support the maximum number of performance counters that can exist at any time.  
  
 You can change the amount of performance counter memory for [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] categories in the registry. To do so, you need to add a new DWORD value named `FileMappingSize` to the three following locations, and set it to the desired value in bytes. Reboot your machine so that these changes are taken into effect.  
  
-   HKLM\System\CurrentControlSet\Services\ServiceModelEndpoint 4.0.0.0\Performance  
  
-   HKLM\System\CurrentControlSet\Services\ServiceModelOperation 4.0.0.0\Performance  
  
-   HKLM\System\CurrentControlSet\Services\ServiceModelService 4.0.0.0\Performance  
  
 When a large number of objects (for example, ServiceHost) are disposed of but waiting to be garbage-collected, the `PrivateBytes` performance counter will register an unusually high number. To resolve this problem, you can either add your own application-specific counters, or use the `performanceCounters` attribute to enable only service-level counters.  
  
## Types of Performance Counters  
 Performance counters are scoped to three different levels: Service, Endpoint and Operation.  
  
 You can use WMI to retrieve the name of a performance counter instance. For example,  
  
-   Service counter instance name can be obtained through WMI [Service](../../../../../docs/framework/wcf/diagnostics/wmi/service.md) instance's "CounterInstanceName" property.  
  
-   Endpoint counter instance name can be obtained through WMI [Endpoint](../../../../../docs/framework/wcf/diagnostics/wmi/endpoint.md) instance's "CounterInstanceName" property.  
  
-   Operation counter instance name can be obtained through WMI [Endpoint](../../../../../docs/framework/wcf/diagnostics/wmi/endpoint.md) instance's "GetOperationCounterInstanceName" method.  
  
 For more information on WMI, see [Using Windows Management Instrumentation for Diagnostics](../../../../../docs/framework/wcf/diagnostics/wmi/index.md).  
  
### Service performance counters  
 Service performance counters measure the service behavior as a whole and can be used to diagnose the performance of the whole service. They can be found under the `ServiceModelService 4.0.0.0` performance object when viewing with Performance Monitor. The instances are named using the following pattern:  
  
```  
ServiceName@ServiceBaseAddress  
```  
  
 A counter in a service scope is aggregated from counter in a collection of endpoints.  
  
 Performance counters for service instance creation are incremented when a new InstanceContext is created. Note that a new InstanceContext is created even when you receive a non-activating message (with an existing service), or when you connect to an instance from one session, end the session, and then reconnect from another session.  
  
### Endpoint performance counters  
 Endpoint performance counters enable you to look at data reflecting how an endpoint is accepting messages. They can be found under the `ServiceModelEndpoint 4.0.0.0` performance object when viewing using the Performance Monitor. The instances are named using the following pattern:  
  
```  
(ServiceName).(ContractName)@(endpoint listener address)  
```  
  
 The data is similar to what is collected for individual operations, but is only aggregated across the endpoint.  
  
 A counter in an endpoint scope is aggregated from counters in a collection of operations.  
  
> [!NOTE]
>  If two endpoints have identical contract names and addresses, they are mapped to the same counter instance.  
  
### Operation performance counters  
 Operation performance counters are found under the `ServiceModelOperation 4.0.0.0` performance object when viewing with the Performance Monitor. Each operation has an individual instance. That is, if a given contract has 10 operations, 10 operation counter instances are associated with that contract. The object instances are named using the following pattern:  
  
```  
(ServiceName).(ContractName).(OperationName)@(first endpoint listener address)  
```  
  
 This counter enables you to measure how the call is being used and how well the operation is performing.  
  
 When counters are visible at multiple scopes, data gathered from a higher scope are aggregated with data from lower scopes. For example, `Calls` at an endpoint represents the sum of all operation calls within the endpoint; `Calls` at a service represents the sum of all calls to all endpoints within the service.  
  
> [!NOTE]
>  If you have duplicate operation names on a contract, you only get one counter instances for both operations.  
  
## Programming the WCF Performance Counters  
 Several files are installed in the SDK install folder so that you can access the [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] performance counters programmatically. These files are listed as follows.  
  
-   _ServiceModelEndpointPerfCounters.vrg  
  
-   _ServiceModelOperationPerfCounters.vrg  
  
-   _ServiceModelServicePerfCounters.vrg  
  
-   _SMSvcHostPerfCounters.vrg  
  
-   _TransactionBridgePerfCounters.vrg  
  
 For more information on how to access the counters programmatically, see [Performance Counter Programming Architecture](http://go.microsoft.com/fwlink/?LinkId=95179).  
  
## See Also  
 [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
