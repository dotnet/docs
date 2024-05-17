---
description: "Learn more about: Load Balancing"
title: "Load Balancing"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "load balancing [WCF]"
ms.assetid: 148e0168-c08d-4886-8769-776d0953b80f
---
# Load Balancing

One way to increase the capacity of Windows Communication Foundation (WCF) applications is to scale them out by deploying them into a load-balanced server farm. WCF applications can be load balanced using standard load balancing techniques, including software load balancers such as Windows Network Load Balancing as well as hardware-based load balancing appliances.  
  
 The following sections discuss considerations for load balancing WCF applications built using various system-provided bindings.  
  
## Load Balancing with the Basic HTTP Binding  

 From the perspective of load balancing, WCF applications that communicate using the <xref:System.ServiceModel.BasicHttpBinding> are no different than other common types of HTTP network traffic (static HTML content, ASP.NET pages, or ASMX Web Services). WCF channels that use this binding are inherently stateless, and terminate their connections when the channel closes. As such, the <xref:System.ServiceModel.BasicHttpBinding> works well with existing HTTP load balancing techniques.  
  
 By default, the <xref:System.ServiceModel.BasicHttpBinding> sends a connection HTTP header in messages with a `Keep-Alive` value, which enables clients to establish persistent connections to the services that support them. This configuration offers enhanced throughput because previously established connections can be reused to send subsequent messages to the same server. However, connection reuse may cause clients to become strongly associated to a specific server within the load-balanced farm, which reduces the effectiveness of round-robin load balancing. If this behavior is undesirable, HTTP `Keep-Alive` can be disabled on the server using the <xref:System.ServiceModel.Channels.HttpTransportBindingElement.KeepAliveEnabled%2A> property with a <xref:System.ServiceModel.Channels.CustomBinding> or user-defined <xref:System.ServiceModel.Channels.Binding>. The following example shows how to do this using configuration.  
  
```xml  
<?xml version="1.0" encoding="utf-8" ?>  
<configuration>  
  
 <system.serviceModel>  
  <services>  
   <service
     name="Microsoft.ServiceModel.Samples.CalculatorService"  
     behaviorConfiguration="CalculatorServiceBehavior">  
     <host>  
      <baseAddresses>  
       <add baseAddress="http://localhost:8000/servicemodelsamples/service"/>  
      </baseAddresses>  
     </host>  
    <!-- configure http endpoint, use base address provided by host  
         And the customBinding -->  
     <endpoint address=""  
           binding="customBinding"  
           bindingConfiguration="HttpBinding"
           contract="Microsoft.ServiceModel.Samples.ICalculator" />  
   </service>  
  </services>  
  
  <bindings>  
    <customBinding>  
  
    <!-- Configure a CustomBinding that disables keepAliveEnabled-->  
      <binding name="HttpBinding" keepAliveEnabled="False"/>  
  
    </customBinding>  
  </bindings>  
 </system.serviceModel>  
</configuration>  
```  
  
 Using the simplified configuration introduced in .NET Framework 4, the same behavior can be accomplished using the following simplified configuration.  
  
```xml  
<?xml version="1.0" encoding="utf-8" ?>  
<configuration>  
 <system.serviceModel>  
    <protocolMapping>  
      <add scheme="http" binding="customBinding" />  
    </protocolMapping>  
    <bindings>  
      <customBinding>  
  
      <!-- Configure a CustomBinding that disables keepAliveEnabled-->  
        <binding keepAliveEnabled="False"/>  
  
      </customBinding>  
    </bindings>  
 </system.serviceModel>  
</configuration>  
```  
  
 For more information about default endpoints, bindings, and behaviors, see [Simplified Configuration](simplified-configuration.md) and [Simplified Configuration for WCF Services](./samples/simplified-configuration-for-wcf-services.md).  
  
## Load Balancing with the WSHttp Binding and the WSDualHttp Binding  

 Both the <xref:System.ServiceModel.WSHttpBinding> and the <xref:System.ServiceModel.WSDualHttpBinding> can be load balanced using HTTP load balancing techniques provided several modifications are made to the default binding configuration.  
  
- Turn off Security Context Establishment or use stateful security sessions. Security Context Establishment can be turned off by setting the <xref:System.ServiceModel.NonDualMessageSecurityOverHttp.EstablishSecurityContext%2A> property on the <xref:System.ServiceModel.WSHttpBinding> to `false`. If you are using <xref:System.ServiceModel.WSDualHttpBinding> or security sessions are required, it is possible to use stateful security sessions as described in [Secure Sessions](./feature-details/secure-sessions.md). Stateful security sessions enable the service to remain stateless, as all of the state for the security session is transmitted with each request as a part of the protection security token. To enable a stateful security session, you must use a <xref:System.ServiceModel.Channels.CustomBinding> or user-defined <xref:System.ServiceModel.Channels.Binding>, as the necessary configuration settings are not exposed on the system-provided <xref:System.ServiceModel.WSHttpBinding> and <xref:System.ServiceModel.WSDualHttpBinding>.

- If you turn off Security Context Establishment, you also need to turn off Service Credential Negotiation. To turn it off, set the <xref:System.ServiceModel.MessageSecurityOverHttp.NegotiateServiceCredential> property on the <xref:System.ServiceModel.WSHttpBinding> to `false`. To disable Service Credential Negotiation, you may need to explicitly specify the endpoint identity on the client.
  
- Do not use reliable sessions. This feature is off by default.  
  
## Load Balancing the Net.TCP Binding  

 The <xref:System.ServiceModel.NetTcpBinding> can be load balanced using IP-layer load balancing techniques. However, the <xref:System.ServiceModel.NetTcpBinding> pools TCP connections by default to reduce connection latency. This is an optimization that interferes with the basic mechanism of load balancing. The primary configuration value for optimizing the <xref:System.ServiceModel.NetTcpBinding> is the lease timeout, which is part of the Connection Pool Settings. Connection pooling causes client connections to become associated to specific servers within the farm. As the lifetime of those connections increase (a factor controlled by the lease timeout setting), the load distribution across various servers in the farm becomes unbalanced. As a result the average call time increases. So when using the <xref:System.ServiceModel.NetTcpBinding> in load-balanced scenarios, consider reducing the default lease timeout used by the binding. A 30-second lease timeout is a reasonable starting point for load-balanced scenarios, although the optimal value is application-dependent. For more information about the channel lease timeout and other transport quotas, see [Transport Quotas](./feature-details/transport-quotas.md).  
  
 For best performance in load-balanced scenarios, consider using <xref:System.ServiceModel.NetTcpSecurity> (either <xref:System.ServiceModel.SecurityMode.Transport> or <xref:System.ServiceModel.SecurityMode.TransportWithMessageCredential>).  
  
## See also

- [Internet Information Services Hosting Best Practices](./feature-details/internet-information-services-hosting-best-practices.md)
