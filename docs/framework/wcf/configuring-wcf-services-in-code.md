---
title: "Configuring WCF Services in Code"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 193c725d-134f-4d31-a8f8-4e575233bff6
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Configuring WCF Services in Code
[!INCLUDE[indigo1](../../../includes/indigo1-md.md)] allows developers to configure services using configuration files or code.  Configuration files are useful when a service needs to be configured after being deployed. When using configuration files, an IT professional only needs to update the configuration file, no recompilation is required. Configuration files, however, can be complex and difficult to maintain. There is no support for debugging configuration files and configuration elements are referenced by names which makes authoring configuration files error-prone and difficult. [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] also allows you to configure services in code. In earlier versions of [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] (4.0 and earlier) configuring services in code was easy in self-hosted scenarios, the <xref:System.ServiceModel.ServiceHost> class allowed you to configure endpoints and behaviors prior to calling ServiceHost.Open. In web hosted scenarios, however, you don’t have direct access to the <xref:System.ServiceModel.ServiceHost> class. To configure a web hosted service you were required to create a `System.ServiceModel.ServiceHostFactory` that created the <xref:System.ServiceModel.Activation.ServiceHostFactory> and performed any needed configuration. Starting with .NET 4.5, [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] provides an easier way to configure both self-hosted and web hosted services in code.  
  
## The Configure method  
 Simply define a public static method called `Configure` with the following signature in your service implementation class:  
  
```csharp  
public static void Configure(ServiceConfiguration config)  
```  
  
 The Configure method takes a <xref:System.ServiceModel.ServiceConfiguration> instance that enables the developer to add endpoints and behaviors. This method is called by [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] before the service host is opened. When defined, any service configuration settings specified in an app.config or web.config file will be ignored.  
  
 The following code snippet illustrates how to define the `Configure` method and add a service endpoint, an endpoint behavior and service behaviors:  
  
```csharp  
public class Service1 : IService1  
    {  
        public static void Configure(ServiceConfiguration config)  
        {  
            ServiceEndpoint se = new ServiceEndpoint(new ContractDescription("IService1"), new BasicHttpBinding(), new EndpointAddress("basic"));  
            se.Behaviors.Add(new MyEndpointBehavior());  
            config.AddServiceEndpoint(se);  
  
            config.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });  
            config.Description.Behaviors.Add(new ServiceDebugBehavior { IncludeExceptionDetailInFaults = true });  
        }  
  
        public string GetData(int value)  
        {  
            return string.Format("You entered: {0}", value);  
        }  
  
        public CompositeType GetDataUsingDataContract(CompositeType composite)  
        {  
            if (composite == null)  
            {  
                throw new ArgumentNullException("composite");  
            }  
            if (composite.BoolValue)  
            {  
                composite.StringValue += "Suffix";  
            }  
            return composite;  
        }  
    }  
```  
  
 To enable a protocol such as https for a service, you can either explicitly add an endpoint that uses the protocol or you can automatically add endpoints by calling ServiceConfiguration.EnableProtocol(Binding) which adds an endpoint for each base address compatible with the protocol and each service contract defined. The following code illustrates how to use the ServiceConfiguration.EnableProtocol method:  
  
```csharp  
public class Service1 : IService1   
{   
    public string GetData(int value);   
    public static void Configure(ServiceConfiguration config)   
    {   
        // Enable "Add Service Reference" support   
       config.Description.Behaviors.Add( new ServiceMetadataBehavior { HttpGetEnabled = true });   
       // set up support for http, https, net.tcp, net.pipe   
       config.EnableProtocol(new BasicHttpBinding());   
       config.EnableProtocol(new BasicHttpBinding());   
       config.EnableProtocol(new NetTcpBinding());   
       config.EnableProtocol(new NetNamedPipeBinding());   
       // add an extra BasicHttpBinding endpoint at http:///basic   
       config.AddServiceEndpoint(typeof(IService1), new BasicHttpBinding(),"basic");   
    }   
}   
```  
  
 The settings in the <`protocolMappings`> section are only used if no application endpoints are added to the <xref:System.ServiceModel.ServiceConfiguration> programmatically.You can optionally load the service configuration from the default application configuration file by calling <xref:System.ServiceModel.ServiceConfiguration.LoadFromConfiguration%2A> and then change the settings. The <xref:System.ServiceModel.ServiceConfiguration.LoadFromConfiguration> class also allows you to load configuration from a centralized configuration. The following code illustrates how to implement this:  
  
```  
public class Service1 : IService1   
{   
    public void DoWork();   
    public static void Configure(ServiceConfiguration config)   
    {   
          config.LoadFromConfiguration(ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap { ExeConfigFilename = @"c:\sharedConfig\MyConfig.config" }, ConfigurationUserLevel.None));   
    }   
}  
```  
  
> [!IMPORTANT]
>  Note that <xref:System.ServiceModel.ServiceConfiguration.LoadFromConfiguration%2A> ignores <`host`> settings within the <`service`> tag of <`system.serviceModel`>. Conceptually, <`host`> is about host configuration, not service configuration, and it gets loaded before the Configure method executes.  
  
## See Also  
 [Configuring Services Using Configuration Files](../../../docs/framework/wcf/configuring-services-using-configuration-files.md)  
 [Configuring Client Behaviors](../../../docs/framework/wcf/configuring-client-behaviors.md)  
 [Simplified Configuration](../../../docs/framework/wcf/simplified-configuration.md)  
 [Configuration-Based Activation](../../../docs/framework/wcf/samples/configuration-based-activation.md)  
 [Configuration](../../../docs/framework/wcf/samples/configuration-sample.md)  
 [Configuration-Based Activation in IIS and WAS](../../../docs/framework/wcf/feature-details/configuration-based-activation-in-iis-and-was.md)  
 [Configuration and Metadata Support](../../../docs/framework/wcf/extending/configuration-and-metadata-support.md)  
 [Configuration](../../../docs/framework/wcf/diagnostics/exceptions-reference/configuration.md)  
 [How to: Specify a Service Binding in Configuration](../../../docs/framework/wcf/how-to-specify-a-service-binding-in-configuration.md)  
 [How to: Create a Service Endpoint in Configuration](../../../docs/framework/wcf/feature-details/how-to-create-a-service-endpoint-in-configuration.md)  
 [How to: Publish Metadata for a Service Using a Configuration File](../../../docs/framework/wcf/feature-details/how-to-publish-metadata-for-a-service-using-a-configuration-file.md)  
 [How to: Specify a Client Binding in Configuration](../../../docs/framework/wcf/how-to-specify-a-client-binding-in-configuration.md)
