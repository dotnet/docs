---
title: "WMI Provider"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 462f0db3-f4a4-4a4b-ac26-41fc25c670a4
caps.latest.revision: 35
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WMI Provider
This sample demonstrates how to gather data from [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] services at runtime by using the Windows Management Instrumentation (WMI) provider that is built into [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. Also, this sample demonstrates how to add a user-defined WMI object to a service. The sample activates the WMI provider for the [Getting Started](../../../../docs/framework/wcf/samples/getting-started-sample.md) and demonstrates how to gather data from the `ICalculator` service at runtime.  
  
 WMI is Microsoft's implementation of the Web-Based Enterprise Management (WBEM) standard. For more information about the WMI SDK, see [Windows Management Instrumentation](https://msdn.microsoft.com/library/aa394582.aspx). WBEM is an industry standard for how applications expose management instrumentation to external management tools.  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] implements a WMI provider, a component that exposes instrumentation at runtime through a WBEM-compatible interface. Management tools can connect to the services through the interface at runtime. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] exposes attributes of services such as addresses, bindings, behaviors, and listeners.  
  
 The built-in WMI provider is activated in the configuration file of the application. This is done through the `wmiProviderEnabled` attribute of the [\<diagnostics>](../../../../docs/framework/configure-apps/file-schema/wcf/diagnostics.md) in the [\<system.serviceModel>](../../../../docs/framework/configure-apps/file-schema/wcf/system-servicemodel.md) section, as shown in the following sample configuration:  
  
```xml  
<system.serviceModel>  
    ...  
    <diagnostics wmiProviderEnabled="true" />  
    ...  
</system.serviceModel>  
```  
  
 This configuration entry exposes a WMI interface. Management applications can now connect through this interface and access the management instrumentation of the application.  
  
## Custom WMI Object  
 Adding WMI objects to a service makes it possible to reveal user-defined information along with the built-in WMI provider information. This is accomplished by publishing the schema of the service to WMI by using the Installutil.exe application. Instructions to accomplish this, along with more details can be found in the setup instructions at the end of the topic.  
  
## Accessing WMI Information  
 WMI data can be accessed many different ways. Microsoft provides WMI APIs for scripts, [!INCLUDE[vbprvb](../../../../includes/vbprvb-md.md)] applications, C++ applications, and the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] (http://msdn.microsoft.com/library/default.asp?url=/library/wmisdk/wmi/using_wmi.asp).  
  
 This sample uses two Java scripts: one to enumerate services running on the computer along with some of their properties and the second to view user-defined WMI data. The script opens a connection to the WMI provider, parses data, and displays the data gathered.  
  
 Start the sample to create a running instance of a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service. While the service is running, run each Java script by using the following command at the command prompt:  
  
```  
cscript EnumerateServices.js  
```  
  
 The script accesses the instrumentation contained in the service and produces the following output:  
  
```  
Microsoft (R) Windows Script Host Version 5.6  
Copyright © Microsoft Corporation 1996-2001. All rights reserved.  
  
1 service(s) found.  
|-PID:           5776  
|-DistinguishedName:  CalculatorService@http://localhost/ServiceModelSamples/service.svc  
|-Endpoints:     1 endpoints  
  |-CalculatorService.ICalculator@http://localhost/ServiceModelSamples/service.svc  
    |-Address:                        http://localhost/ServiceModelSamples/service.svc  
    |-CounterInstanceName:  
    |-AddressHeaders:                 0  
    |-ContractType:                   Contract.Name='ICalculator'  
    |-BindingElements:                4 bindings  
      |-BindingElements[0]  
        |-Type:                       TransactionFlowBindingElement  
      |-BindingElements[1]  
        |-Type:                       SymmetricSecurityBindingElement  
      |-BindingElements[2]  
        |-Type:                       TextMessageEncodingBindingElement  
        |-MaxReadPoolSize:            64  
        |-MaxWritePoolSize:           16  
      |-BindingElements[3]  
        |-Type:                       HttpTransportBindingElement  
        |-ManualAddressing:           false  
        |-MaxBufferSize:              65536  
        |-AllowCookies:               false  
        |-AuthenticationScheme:       Anonymous  
        |-BypassProxyOnLocal:         false  
        |-HostNameComparisonMode:     StrongWildcard  
        |-ProxyAddress:               null  
        |-ProxyAuthenticationScheme:  Anonymous  
        |-Realm:  
        |-TransferMode:               Buffered  
        |-UseDefaultWebProxy:         true  
|-Behaviors:     5 behaviors  
      |-Behavior[0]  
      |-Type:                       ServiceBehaviorAttribute  
        |-AddressFilterMode:               Exact  
        |-AutomaticSessionShutdown:        true  
        |-ConcurrencyMode:                 Single  
        |-IncludeExceptionDetailInFaults:  false  
        |-InstanceContextMode:             PerSession  
        |-TransactionIsolationLevel:       Unspecified  
        |-TransactionTimeout:              null  
        |-ValidateMustUnderstand:          true  
      |-Behavior[1]  
      |-Type:                       AspNetCompatibilityRequirementsAttribute  
      |-Behavior[2]  
      |-Type:                       ServiceDebugBehavior  
      |-Behavior[3]  
      |-Type:                       ServiceAuthorizationBehavior  
      |-Behavior[4]  
      |-Type:                       Behavior  
```  
  
 Next, run the second Java Script to display the user-defined WMI data:  
  
```  
cscript EnumerateCustomObjects.js  
```  
  
 The script accesses the user-defined instrumentation contained in the services and produces the following output:  
  
```  
1 WMIObject(s) found.  
|-PID:           30285bfd-9d66-4c4e-9be2-310499c5cef5  
|-InstanceId:    3839  
|-WMIInfo:       User Defined WMI Information.  
```  
  
 The output shows that there is a single service running on the computer. The service exposes one endpoint that implements the `ICalculator` contract. The settings of the behavior and binding that are implemented by the endpoint are listed as the sum of individual elements of the messaging stack.  
  
 WMI is not limited to exposing the management instrumentation of the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] infrastructure. The application can expose its own domain-specific data items through the same mechanism. WMI is a unified mechanism for inspection and control of a Web service.  
  
#### To set up, build, and run the sample  
  
1.  Ensure you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
2.  To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
3.  Publish the services schema to WMI by running the InstallUtil.exe (the default locations for InstallUtil.exe is "%WINDIR%\Microsoft.NET\Framework\v4.0.30319") on the service.dll file in the hosting directory. This step only needs to be executed when changes have been made to the service.dll file. For more information, see Providing Management Information by Instrumenting Applications at: http://msdn2.microsoft.com/library/ms186147.aspx in the "How To: Publish the Scheme to WMI for an Instrumented Application" section.  
  
4.  To run the sample in a single- or cross-computer configuration, follow the instructions in [Running the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/running-the-samples.md).  
  
    > [!NOTE]
    >  If you installed [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] after installing ASP.NET, you may need to run "%WINDIR%\ Microsoft.Net\Framework\v3.0\Windows Communication Foundation\servicemodelreg.exe " -r -x to give the ASPNET account permission to publish WMI objects.  
  
5.  View data from the sample surfaced through WMI by using the commands: `cscript EnumerateServices.js` or `cscript EnumerateCustomObjects.js`.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Management\WMIProvider`  
  
## See Also  
 [AppFabric Monitoring Samples](http://go.microsoft.com/fwlink/?LinkId=193959)
