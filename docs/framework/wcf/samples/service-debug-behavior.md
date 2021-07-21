---
description: "Learn more about: Service Debug Behavior"
title: "Service Debug Behavior"
ms.date: "03/30/2017"
ms.assetid: 9d8fd3fb-dc39-427a-8235-336a7e7162ba
---
# Service Debug Behavior

The [ServiceDebug sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how service debug behavior settings can be configured. The sample is based on the [Getting Started](getting-started-sample.md), which implements the `ICalculator` service contract. This sample explicitly defines service debug behavior in the configuration file. It can also be done imperatively in code.

In this sample, the client is a console application (.exe) and the service is hosted by Internet Information Services (IIS).

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

The Web.config file for the server defines the service debug behavior to enable the help page and exception handling as shown in the following sample.

```xml
<behaviors>
     <serviceBehaviors>
         <behavior name="CalculatorServiceBehavior">
         <!-- WARNING: Setting includeExceptionDetailInFaults = "True" could result in leaking secured server information to the client.-->
         <!-- Please set this to false when deploying -->
             <serviceDebug includeExceptionDetailInFaults="True" httpHelpPageEnabled="True"/>
         </behavior>
     </serviceBehaviors>
</behaviors>
```

[\<serviceDebug>](../../configure-apps/file-schema/wcf/servicedebug.md) is the configuration element that allows changing the service debug behavior properties. The user can modify this behavior to achieve the following:

- This allows the service to return any exception that is thrown by the application code even if the exception is not declared using the <xref:System.ServiceModel.FaultContractAttribute>. It is done by setting `includeExceptionDetailInFaults` to `true`. This setting is useful when debugging cases where the server is throwing an unexpected exception.

  > [!IMPORTANT]
  > It is not secure to turn this setting on in a production environment. An unexpected server exception may have some information that is not intended for the client and so setting `includeExceptionDetailsInFaults` to `true` might result in an information leak.

- The [\<serviceDebug>](../../configure-apps/file-schema/wcf/servicedebug.md) also allows a user to enable or disable the help page. Each service can optionally expose a help page that contains information about the service including the endpoint to get WSDL for the service. This can be enabled by setting `httpHelpPageEnabled` to `true`. This enables the help page to be returned to a GET request to the base address of the service. You can change this address by setting another attribute `httpHelpPageUrl`. You can make this secure by using HTTPS instead of HTTP. This can be done by setting `httpsHelpPageEnabled` and `httpsHelpPageUrl`.

When you run the sample, the operation requests and responses are displayed in the client console window. The first three operations (Add, Subtract and Multiply) must succeed. The last operation ("divide") fails with a division by zero exception.

### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).
