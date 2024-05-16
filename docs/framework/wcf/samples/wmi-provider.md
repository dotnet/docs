---
description: "Learn more about: WMI Provider"
title: "WMI Provider"
ms.date: "03/30/2017"
ms.assetid: 462f0db3-f4a4-4a4b-ac26-41fc25c670a4
---
# WMI Provider

The [WMIProvider sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how to gather data from Windows Communication Foundation (WCF) services at run time by using the Windows Management Instrumentation (WMI) provider that is built into WCF. Also, this sample demonstrates how to add a user-defined WMI object to a service. The sample activates the WMI provider for the [Getting Started](getting-started-sample.md) and demonstrates how to gather data from the `ICalculator` service at run time.

WMI is Microsoft's implementation of the Web-Based Enterprise Management (WBEM) standard. For more information about the WMI SDK, see [Windows Management Instrumentation](/windows/desktop/WmiSdk/wmi-start-page). WBEM is an industry standard for how applications expose management instrumentation to external management tools.

WCF implements a WMI provider, a component that exposes instrumentation at run time through a WBEM-compatible interface. Management tools can connect to the services through the interface at run time. WCF exposes attributes of services such as addresses, bindings, behaviors, and listeners.

The built-in WMI provider is activated in the configuration file of the application. This is done through the `wmiProviderEnabled` attribute of the [\<diagnostics>](../../configure-apps/file-schema/wcf/diagnostics.md) in the [\<system.serviceModel>](../../configure-apps/file-schema/wcf/system-servicemodel.md) section, as shown in the following sample configuration:

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

WMI data can be accessed in many different ways. Microsoft provides WMI APIs for scripts, Visual Basic applications, C++ applications, and the .NET Framework. For more information, see [Using WMI](/windows/desktop/wmisdk/using-wmi).

This sample uses two Java scripts: one to enumerate services running on the computer along with some of their properties and the second to view user-defined WMI data. The script opens a connection to the WMI provider, parses data, and displays the data gathered.

Start the sample to create a running instance of a WCF service. While the service is running, run each Java script by using the following command at the command prompt:

```console
cscript EnumerateServices.js
```

The script accesses the instrumentation contained in the service and produces the following output:

```console
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

```console
cscript EnumerateCustomObjects.js
```

The script accesses the user-defined instrumentation contained in the services and produces the following output:

```console
1 WMIObject(s) found.
|-PID:           30285bfd-9d66-4c4e-9be2-310499c5cef5
|-InstanceId:    3839
|-WMIInfo:       User Defined WMI Information.
```

The output shows that there is a single service running on the computer. The service exposes one endpoint that implements the `ICalculator` contract. The settings of the behavior and binding that are implemented by the endpoint are listed as the sum of individual elements of the messaging stack.

WMI is not limited to exposing the management instrumentation of the WCF infrastructure. The application can expose its own domain-specific data items through the same mechanism. WMI is a unified mechanism for inspection and control of a Web service.

#### To set up, build, and run the sample

1. Ensure you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. Publish the services schema to WMI by running the InstallUtil.exe (the default locations for InstallUtil.exe is "%WINDIR%\Microsoft.NET\Framework\v4.0.30319") on the service.dll file in the hosting directory. This step only needs to be executed when changes have been made to the service.dll file.

4. To run the sample in a single- or cross-computer configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).

    > [!NOTE]
    > If you installed WCF after installing ASP.NET, you may need to run "%WINDIR%\ Microsoft.Net\Framework\v3.0\Windows Communication Foundation\servicemodelreg.exe " -r -x to give the ASPNET account permission to publish WMI objects.

5. View data from the sample surfaced through WMI by using the commands: `cscript EnumerateServices.js` or `cscript EnumerateCustomObjects.js`.

## See also

- [AppFabric Monitoring Samples](/previous-versions/appfabric/ff383407(v=azure.10))
