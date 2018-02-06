---
title: "Custom Service Host"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: fe16ff50-7156-4499-9c32-13d8a79dc100
caps.latest.revision: 16
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Custom Service Host
This sample demonstrates how to use a custom derivative of the <xref:System.ServiceModel.ServiceHost> class to alter the run-time behavior of a service. This approach provides a reusable alternative to configuring a large number of services in a common way. The sample also demonstrates how to use the <xref:System.ServiceModel.Activation.ServiceHostFactory> class to use a custom ServiceHost in the Internet Information Services (IIS) or Windows Process Activation Service (WAS) hosting environment.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Extensibility\Hosting\CustomServiceHost`  
  
## About the Scenario  
 To prevent unintentional disclosure of potentially sensitive service metadata, the default configuration for [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] services disables metadata publishing. This behavior is secure by default, but also means that you cannot use a metadata import tool (such as Svcutil.exe) to generate the client code required to call the service unless the service’s metadata publishing behavior is explicitly enabled in configuration.  
  
 Enabling metadata publishing for a large number of services involves adding the same configuration elements to each individual service, which results in a large amount of configuration information that is essentially the same. As an alternative to configuring each service individually, it is possible to write the imperative code that enables metadata publishing once and then reuse that code across several different services. This is accomplished by creating a new class that derives from <xref:System.ServiceModel.ServiceHost> and overrides the `ApplyConfiguration`() method to imperatively add the metadata publishing behavior.  
  
> [!IMPORTANT]
>  For clarity, this sample demonstrates how to create an unsecured metadata publishing endpoint. Such endpoints are potentially available to anonymous unauthenticated consumers and care must be taken before deploying such endpoints to ensure that publicly disclosing a service’s metadata is appropriate.  
  
## Implementing a Custom ServiceHost  
 The <xref:System.ServiceModel.ServiceHost> class exposes several useful virtual methods that inheritors can override to alter the run-time behavior of a service. For example, the `ApplyConfiguration`() method reads service configuration information from the configuration store and alters the host's <xref:System.ServiceModel.Description.ServiceDescription> accordingly. The default implementation reads configuration from the application’s configuration file. Custom implementations can override `ApplyConfiguration`() to further alter the <xref:System.ServiceModel.Description.ServiceDescription> using imperative code or even replace the default configuration store entirely. For example, to read a service’s endpoint configuration from a database instead of the application’s configuration file.  
  
 In this sample, we want to build a custom ServiceHost that adds the ServiceMetadataBehavior, (which enables metadata publishing), even if this behavior is not explicitly added in the service’s configuration file. To accomplish this, we create a new class that inherits from <xref:System.ServiceModel.ServiceHost> and overrides `ApplyConfiguration`().  
  
```  
class SelfDescribingServiceHost : ServiceHost  
{  
    public SelfDescribingServiceHost(Type serviceType, params Uri[] baseAddresses)  
        : base(serviceType, baseAddresses) { }  
  
    //Overriding ApplyConfiguration() allows us to   
    //alter the ServiceDescription prior to opening  
    //the service host.   
    protected override void ApplyConfiguration()  
    {  
        //First, we call base.ApplyConfiguration()  
        //to read any configuration that was provided for  
        //the service we're hosting. After this call,  
        //this.Description describes the service  
        //as it was configured.  
        base.ApplyConfiguration();       
  
        //(rest of implementation elided for clarity)  
    }  
}  
```  
  
 Because we do not want to ignore any configuration that has been provided in the application’s configuration file, the first thing our override of `ApplyConfiguration`() does is call the base implementation. Once this method completes, we can imperatively add the <xref:System.ServiceModel.Description.ServiceMetadataBehavior> to the description using the following imperative code.  
  
```  
ServiceMetadataBehavior mexBehavior = this.Description.Behaviors.Find<ServiceMetadataBehavior>();  
if (mexBehavior == null)  
{  
    mexBehavior = new ServiceMetadataBehavior();  
    this.Description.Behaviors.Add(mexBehavior);  
}  
else  
{  
    //Metadata behavior has already been configured,   
    //so we do not have any work to do.  
    return;  
}  
```  
  
 The last thing our `ApplyConfiguration`() override must do is add the default metadata endpoint. By convention, one metadata endpoint is created for each URI in the service host’s BaseAddresses collection.  
  
```  
//Add a metadata endpoint at each base address  
//using the "/mex" addressing convention  
foreach (Uri baseAddress in this.BaseAddresses)  
{  
    if (baseAddress.Scheme == Uri.UriSchemeHttp)  
    {  
        mexBehavior.HttpGetEnabled = true;  
        this.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName,  
                                MetadataExchangeBindings.CreateMexHttpBinding(),  
                                "mex");  
    }  
    else if (baseAddress.Scheme == Uri.UriSchemeHttps)  
    {  
        mexBehavior.HttpsGetEnabled = true;  
        this.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName,  
                                MetadataExchangeBindings.CreateMexHttpsBinding(),  
                                "mex");  
    }  
    else if (baseAddress.Scheme == Uri.UriSchemeNetPipe)  
    {  
        this.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName,  
                                MetadataExchangeBindings.CreateMexNamedPipeBinding(),  
                                "mex");  
    }  
    else if (baseAddress.Scheme == Uri.UriSchemeNetTcp)  
    {  
        this.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName,  
                                MetadataExchangeBindings.CreateMexTcpBinding(),  
                                "mex");  
    }  
}  
```  
  
## Using a custom ServiceHost in self-host  
 Now that we have completed our custom ServiceHost implementation, we can use it to add metadata publishing behavior to any service by hosting that service inside of an instance of our `SelfDescribingServiceHost`. The following code shows how to use it in the self-host scenario.  
  
```  
SelfDescribingServiceHost host =   
         new SelfDescribingServiceHost( typeof( Calculator ) );  
host.Open();  
```  
  
 Our custom host still reads the service’s endpoint configuration from the application’s configuration file, just as if we had used the default <xref:System.ServiceModel.ServiceHost> class to host the service. However, because we added the logic to enable metadata publishing inside of our custom host, we no longer must explicitly enable the metadata publishing behavior in configuration. This approach has a distinct advantage when you are building an application that contains several services and you want to enable metadata publishing on each of them without writing the same configuration elements over and over.  
  
## Using a Custom ServiceHost in IIS or WAS  
 Using a custom service host in self-host scenarios is straightforward, because it is your application code that is ultimately responsible for creating and opening the service host instance. In the IIS or WAS hosting environment, however, the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] infrastructure is dynamically instantiating your service’s host in response to incoming messages. Custom service hosts can also be used in this hosting environment, but they require some additional code in the form of a ServiceHostFactory. The following code shows a derivative of <xref:System.ServiceModel.Activation.ServiceHostFactory> that returns instances of our custom `SelfDescribingServiceHost`.  
  
```  
public class SelfDescribingServiceHostFactory : ServiceHostFactory  
{  
    protected override ServiceHost CreateServiceHost(Type serviceType,   
     Uri[] baseAddresses)  
    {  
        //All the custom factory does is return a new instance  
        //of our custom host class. The bulk of the custom logic should  
        //live in the custom host (as opposed to the factory)   
        //for maximum  
        //reuse value outside of the IIS/WAS hosting environment.  
        return new SelfDescribingServiceHost(serviceType,     
                                             baseAddresses);  
    }  
}  
```  
  
 As you can see, implementing a custom ServiceHostFactory is very straightforward. All of the custom logic resides inside of the ServiceHost implementation; the factory returns an instance of the derived class.  
  
 To use a custom factory with a service implementation, we must add some additional metadata to the service’s .svc file.  
  
```  
<%@ServiceHost Service="Microsoft.ServiceModel.Samples.CalculatorService"  
               Factory="Microsoft.ServiceModel.Samples.SelfDescribingServiceHostFactory"  
               language=c# Debug="true" %>  
```  
  
 Here we have added an additional `Factory` attribute to the `@ServiceHost` directive, and passed the CLR type name of our custom factory as the attribute’s value. When IIS or WAS receives a message for this service, the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] hosting infrastructure first creates an instance of the ServiceHostFactory and then instantiate the service host itself by calling `ServiceHostFactory.CreateServiceHost()`.  
  
## Running the Sample  
 Although this sample does provide a fully-functional client and service implementation, the point of the sample is to illustrate how to alter a service’s run-time behavior by means of a custom host., do the following steps:  
  
#### To observe the effect of the custom host  
  
1.  Open the service’s Web.config file and observe that there is no configuration explicitly enabling metadata for the service.  
  
2.  Open the service’s .svc file and observe that its @ServiceHost directive contains a Factory attribute that specifies the name of a custom ServiceHostFactory.  
  
#### To set up, build, and run the sample  
  
1.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
2.  To build the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
3.  After the solution has been built, run Setup.bat to set up the ServiceModelSamples Application in [!INCLUDE[iisver](../../../../includes/iisver-md.md)]. The ServiceModelSamples directory should now appear as an [!INCLUDE[iisver](../../../../includes/iisver-md.md)] Application.  
  
4.  To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/running-the-samples.md).  
  
5.  To remove the [!INCLUDE[iisver](../../../../includes/iisver-md.md)] application, run Cleanup.bat.  
  
## See Also  
 [How to: Host a WCF Service in IIS](../../../../docs/framework/wcf/feature-details/how-to-host-a-wcf-service-in-iis.md)
