---
description: "Learn more about: Controlling Resource Consumption and Improving Performance"
title: "Controlling Resource Consumption and Improving Performance"
ms.date: "03/30/2017"
ms.assetid: 9a829669-5f76-4c88-80ec-92d0c62c0660
---
# Controlling Resource Consumption and Improving Performance

This topic describes various properties in different areas of the Windows Communication Foundation (WCF) architecture that work to control resource consumption and affect performance metrics.

## Properties that Constrain Resource Consumption in WCF

 Windows Communication Foundation (WCF) applies constraints on certain types of processes for either security or performance purposes. These constraints come in two main forms, either quotas and throttles. *Quotas* are limits that when reached or exceeded trigger an immediate exception at some point in the system. *Throttles* are limits that do not immediately cause an exception to be thrown. Instead, when a throttle limit is reached, processing continues but within the limits set by that throttle value. This limited processing might trigger an exception elsewhere, but this depends upon the application.

 In addition to the distinction between quotas and throttles, some constraining properties are located at the serialization level, some at the transport level, and some at the application level. For example, the quota <xref:System.ServiceModel.Channels.TransportBindingElement.MaxReceivedMessageSize%2A?displayProperty=nameWithType>, which is implemented by all system-supplied transport binding elements, is set to 65,536 bytes by default to hinder malicious clients from engaging in denial-of-service attacks against a service by causing excessive memory consumption. (Typically, you can increase performance by lowering this value.)

 An example of a serialization quota is the <xref:System.Runtime.Serialization.DataContractSerializer.MaxItemsInObjectGraph%2A?displayProperty=nameWithType> property, which specifies the maximum number of objects that the serializer serializes or deserializes in a single <xref:System.Runtime.Serialization.DataContractSerializer.ReadObject%2A> method call. An example of an application-level throttle is the <xref:System.ServiceModel.Dispatcher.ServiceThrottle.MaxConcurrentSessions%2A?displayProperty=nameWithType> property, which by default restricts the number of concurrent sessionful channel connections to 10. (Unlike the quotas, if this throttle value is reached, the application continues processing but accepts no new sessionful channels, which means that new clients cannot connect until one of the other sessionful channels is ended.)

 These controls are designed to provide an out-of-the-box mitigation against certain types of attacks or to improve performance metrics such as memory footprint, start-up time, and so on. However, depending on the application, these controls can impede service application performance or prevent the application from working at all. For example, an application designed to stream video can easily exceed the default <xref:System.ServiceModel.Channels.TransportBindingElement.MaxReceivedMessageSize%2A?displayProperty=nameWithType> property. This topic provides an overview of the various controls applied to applications at all levels of WCF, describes various ways to obtain more information about whether a setting is hindering your application, and describes ways to correct various problems. Most throttles and some quotas are available at the application level, even when the base property is a serialization or transport constraint. For example, you can set the <xref:System.Runtime.Serialization.DataContractSerializer.MaxItemsInObjectGraph%2A?displayProperty=nameWithType> property using the <xref:System.ServiceModel.ServiceBehaviorAttribute.MaxItemsInObjectGraph%2A?displayProperty=nameWithType> property on the service class.

> [!NOTE]
> If you have a particular problem, you should first read the [WCF Troubleshooting Quickstart](wcf-troubleshooting-quickstart.md) to see whether your problem (and a solution) is listed there.

 Properties that restrict serialization processes are listed in [Security Considerations for Data](./feature-details/security-considerations-for-data.md). Properties that restrict the consumption of resources related to transports are listed in [Transport Quotas](./feature-details/transport-quotas.md). Properties that restrict the consumption of resources at the application layer are the members of the <xref:System.ServiceModel.Dispatcher.ServiceThrottle> class.

## Detecting Application and Performance Issues Related to Quota Settings

 The defaults of the preceding values have been chosen to enable basic application functionality across a wide range of application types while providing basic protection against common security issues. However, different application designs might exceed one or more throttle settings although the application otherwise is secure and would work as designed. In these cases, you must identify which throttle values are being exceeded and at what level, and decide on the appropriate course of action to increase application throughput.

 Typically, when writing the application and debugging it, you set the <xref:System.ServiceModel.Description.ServiceDebugBehavior.IncludeExceptionDetailInFaults%2A?displayProperty=nameWithType> property to `true` in the configuration file or programmatically. This instructs WCF to return service exception stack traces to the client application for viewing. This feature reports most application-level exceptions in such a way as to display which quota settings might be involved, if that is the problem.

 Some exceptions happen at run time below the visibility of the application layer and are not returned using this mechanism, and they might not be handled by a custom <xref:System.ServiceModel.Dispatcher.IErrorHandler?displayProperty=nameWithType> implementation. If you are in a development environment like Microsoft Visual Studio, most of these exceptions are displayed automatically. However, some exceptions can be masked by development environment settings such as [Just My Code](/visualstudio/debugger/just-my-code) Visual Studio.

 Regardless of the capabilities of your development environment, you can use capabilities of WCF tracing and message logging to debug all exceptions and tune the performance of your applications. For more information, see [Using Tracing to Troubleshoot Your Application](./diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md).

## Performance Issues and XmlSerializer

 Services and client applications that use data types that are serializable using the <xref:System.Xml.Serialization.XmlSerializer> generate and compile serialization code for those data types at run time, which can result in slow start-up performance.

> [!NOTE]
> Pre-generated serialization code can be used only in client applications and not in services.

 The [ServiceModel Metadata Utility Tool (Svcutil.exe)](servicemodel-metadata-utility-tool-svcutil-exe.md) can improve start-up performance for these applications by generating the necessary serialization code from the compiled assemblies for the application. For more information, see [How to: Improve the Startup Time of WCF Client Applications using the XmlSerializer](./feature-details/startup-time-of-wcf-client-applications-using-the-xmlserializer.md).

## Performance Issues When Hosting WCF Services Under ASP.NET

When a WCF service is hosted under IIS and ASP.NET, the configuration settings of IIS and ASP.NET can affect the throughput and memory footprint of the WCF service.  For more information about ASP.NET performance, see [Improving ASP.NET Performance](/previous-versions/msp-n-p/ff647787(v=pandp.10)). One setting that might have unintended consequences is <xref:System.Web.Configuration.ProcessModelSection.MinWorkerThreads%2A>, which is a property of the <xref:System.Web.Configuration.ProcessModelSection>. If your application has a fixed or small number of clients, setting <xref:System.Web.Configuration.ProcessModelSection.MinWorkerThreads%2A> to 2 might provide a throughput boost on a multiprocessor machine that has a CPU utilization close to 100%. This increase in performance comes with a cost: it will also cause an increase in memory usage, which could reduce scalability.

## See also

- [Administration and Diagnostics](./diagnostics/index.md)
- [Large Data and Streaming](./feature-details/large-data-and-streaming.md)
