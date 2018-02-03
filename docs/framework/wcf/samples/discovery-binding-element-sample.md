---
title: "Discovery Binding Element Sample"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: af513015-85bf-417b-8729-1bdff77ff6d6
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Discovery Binding Element Sample
This sample demonstrates how to use the discovery client binding element to discover a service. This feature enables developers to add a discovery client channel to their existing client channel stack, making the programming model very intuitive. When the associated channel is opened, the address of the service is resolved using discovery. This sample consists of the following projects:  
  
-   **CalculatorService**: A discoverable [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service.  
  
-   **CalculatorClient**: A [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client application that uses the discovery client channel to search for and call the CalculatorService.  
  
-   **DynamicCalculatorClient**: A [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client application that uses a dynamic endpoint to search for and call the CalculatorService.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Discovery\DiscoveryBindingElement`  
  
## CalculatorService  
 This project contains a simple calculator service that implements the `ICalculatorService` contract.  
  
 The following App.config file is used to add a `<serviceDiscovery>` behavior in the service behaviors as well as the discovery endpoint.  
  
```xml  
<system.serviceModel>  
    <services>  
      <service behaviorConfiguration="CalculatorBehavior" name="Microsoft.Samples.Discovery.CalculatorService">  
        <endpoint name="udpDiscoveryEpt" kind="udpDiscoveryEndpoint" />  
      </service>  
    </services>  
    <behaviors>  
      <!--Enable discovery through configuration.-->  
      <serviceBehaviors>  
        <behavior name="CalculatorBehavior">  
          <serviceDiscovery>  
          </serviceDiscovery>  
        </behavior>  
      </serviceBehaviors>  
    </behaviors>  
  </system.serviceModel>  
```  
  
 This makes the service and its endpoints discoverable. The CalculatorService is a self-hosted service that adds one endpoint using the NetTcpBinding binding. It also adds an `EndpointDiscoveryBehavior` to the endpoint and specifies a scope as shown in the following code.  
  
```  
// Add a NET.TCP endpoint and add a scope to that endpoint.  
ServiceEndpoint netTcpEndpoint = serviceHost.AddServiceEndpoint(typeof(ICalculatorService), new NetTcpBinding(), netTcpAddress);  
EndpointDiscoveryBehavior netTctEndpointBehavior = new EndpointDiscoveryBehavior();  
netTctEndpointBehavior.Scopes.Add(new Uri("ldap:///ou=engineering,o=exampleorg,c=us"));  
netTcpEndpoint.Behaviors.Add(netTctEndpointBehavior);  
serviceHost.Open();  
```  
  
## CalculatorClient  
 This project contains a client implementation that sends messages to the CalculatorService. This program uses the `CreateCustomBindingWithDiscoveryElement()` method to create a custom binding that uses the Discovery Client Channel.  
  
```  
static CustomBinding CreateCustomBindingWithDiscoveryElement()  
 {  
      DiscoveryClientBindingElement discoveryBindingElement = new DiscoveryClientBindingElement();  
  
            // Provide the search criteria and the endpoint over which the probe is sent  
            discoveryBindingElement.FindCriteria = new FindCriteria(typeof(ICalculatorService));  
            discoveryBindingElement.DiscoveryEndpointProvider = new UdpDiscoveryEndpointProvider();  
  
            CustomBinding customBinding = new CustomBinding(new NetTcpBinding());  
            // Insert DiscoveryClientBindingElement at the top of the BindingElement stack.  
            // An exception is thrown if this binding element is not at the top  
            customBinding.Elements.Insert(0, discoveryBindingElement);  
  
            return customBinding; }  
```  
  
 After the <xref:System.ServiceModel.Discovery.DiscoveryClientBindingElement> is instantiated, the developer specifies the criteria to use when searching for a service. In this case, the discovery find criterion is the `ICalculatorService` type. Additionally, the developer specifies a <xref:System.ServiceModel.Discovery.DiscoveryEndpointProvider> which returns a <xref:System.ServiceModel.Discovery.DiscoveryEndpoint> that specifies where to look for the services. The <xref:System.ServiceModel.Discovery.DiscoveryEndpointProvider> returns a new <xref:System.ServiceModel.Discovery.DiscoveryEndpoint> instance. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Using a Custom Binding with the Discovery Client Channel](../../../../docs/framework/wcf/feature-details/using-a-custom-binding-with-the-discovery-client-channel.md).  
  
```  
// Extend DiscoveryEndpointProvider class to change the default DiscoveryEndpoint  
    // to the DiscoveryClientBindingElement. The Discovery ClientChannel   
    // uses this endpoint to send Probe message.  
    public class UdpDiscoveryEndpointProvider : DiscoveryEndpointProvider  
    {  
        public override DiscoveryEndpoint GetDiscoveryEndpoint()  
        {  
            return new UdpDiscoveryEndpoint(DiscoveryVersion.WSDiscoveryApril2005);  
        }  
    }  
```  
  
 In this case, the client uses the UDP multicast mechanism defined by the Discovery protocol to search for services on the local subnet. The remainder of the method creates a custom binding and inserts the Discovery binding element at the top of the stack.  
  
> [!NOTE]
>  The <xref:System.ServiceModel.Discovery.DiscoveryClientBindingElement> must be placed on the top of the binding stack. Any <xref:System.ServiceModel.Channels.BindingElement> on top of <xref:System.ServiceModel.Discovery.DiscoveryClientBindingElement> must make sure that the channel factory or channel it creates does not use the `EndpointAddress` or `Via` properties, because the actual address is found only at the Discovery client channel.  
  
 Next, the `CalculatorClient` can be instantiated by passing in this custom binding as well as an endpoint address.  
  
```  
CalculatorServiceClient client = new CalculatorServiceClient(CreateCustomBindingWithDiscoveryElement(), DiscoveryClientBindingElement.DiscoveryEndpointAddress);  
```  
  
 When using the Discovery Client Channel, the constant endpoint address specified previously is passed in. Now at runtime, the Discovery Client Channel finds the service specified by the find criteria and connects to it. For the service and the client to establish a connection, they must also have the same underlying binding stack.  
  
#### To use this sample  
  
1.  Open the solution in [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)].  
  
2.  Build the solution.  
  
3.  Run the service application and each of the client applications.  
  
4.  Observe that the client was able to find the service without knowing its address.  
  
## See Also
