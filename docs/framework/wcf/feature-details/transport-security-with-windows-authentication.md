---
title: "Transport Security with Windows Authentication"
description: Review this scenario, which shows a WCF client/service secured by Windows security. In this example, an intranet service displays human resources information.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 96dd26e2-46e7-4de0-9a29-4fcb05bf187b
---
# Transport Security with Windows Authentication

The following scenario shows a Windows Communication Foundation (WCF) client and service secured by Windows security. For more information about programming, see [How to: Secure a Service with Windows Credentials](../how-to-secure-a-service-with-windows-credentials.md).  
  
 An intranet Web service displays human resources information. The client is a Windows Form application. The application is deployed in a domain with a Kerberos controller securing the domain.  
  
 ![Transport security with Windows authentication](./media/transport-security-with-windows-authentication/secured-windows-authentication.gif)  
  
|Characteristic|Description|  
|--------------------|-----------------|  
|Security Mode|Transport|  
|Interoperability|WCF only|  
|Authentication (Server)<br /><br /> Authentication (Client)|Yes (using Windows integrated authentication)<br /><br /> Yes (using Windows integrated authentication)|  
|Integrity|Yes|  
|Confidentiality|Yes|  
|Transport|NET.TCP|  
|Binding|<xref:System.ServiceModel.NetTcpBinding>|  
  
## Service  

 The following code and configuration are meant to run independently. Do one of the following:  
  
- Create a stand-alone service using the code with no configuration.  
  
- Create a service using the supplied configuration, but do not define any endpoints.  
  
### Code  

 The following code shows how to create a service endpoint that uses a Windows security.  
  
 [!code-csharp[C_SecurityScenarios#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_securityscenarios/cs/source.cs#3)]
 [!code-vb[C_SecurityScenarios#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_securityscenarios/vb/source.vb#3)]  
  
### Configuration  

 The following configuration can be used instead of the code to set up the service endpoint:  
  
```xml  
<?xml version="1.0" encoding="utf-8"?>  
<configuration>  
  <system.serviceModel>  
    <behaviors />  
    <services>  
      <service behaviorConfiguration="" name="ServiceModel.Calculator">  
        <endpoint address="net.tcp://localhost:8008/Calculator"
                  binding="netTcpBinding"  
          bindingConfiguration="WindowsClientOverTcp"
                  name="WindowsClientOverTcp"  
                  contract="ServiceModel.ICalculator" />  
      </service>  
    </services>  
    <bindings>  
      <netTcpBinding>  
        <binding name="WindowsClientOverTcp">  
          <security mode="Transport">  
            <transport clientCredentialType="Windows" />  
          </security>  
        </binding>  
      </netTcpBinding>  
    </bindings>  
    <client />  
  </system.serviceModel>  
</configuration>  
```  
  
## Client  

 The following code and configuration are meant to run independently. Do one of the following:  
  
- Create a stand-alone client using the code (and client code).  
  
- Create a client that does not define any endpoint addresses. Instead, use the client constructor that takes the configuration name as an argument. For example:  
  
     [!code-csharp[C_SecurityScenarios#0](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_securityscenarios/cs/source.cs#0)]
     [!code-vb[C_SecurityScenarios#0](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_securityscenarios/vb/source.vb#0)]  
  
### Code  

 The following code creates the client. The binding is configured to use the Transport mode security, with the TCP transport, with the client credential type set to Windows.  
  
 [!code-csharp[C_SecurityScenarios#4](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_securityscenarios/cs/source.cs#4)]
 [!code-vb[C_SecurityScenarios#4](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_securityscenarios/vb/source.vb#4)]  
  
### Configuration  

 The following configuration can be used instead of the code to create the client.  
  
```xml  
<?xml version="1.0" encoding="utf-8"?>  
<configuration>  
  <system.serviceModel>  
    <bindings>  
      <netTcpBinding>  
        <binding name="NetTcpBinding_ICalculator" >  
          <security mode="Transport">  
            <transport clientCredentialType="Windows" />  
          </security>  
        </binding>  
      </netTcpBinding>  
    </bindings>  
    <client>  
      <endpoint address="net.tcp://localhost:8008/Calculator"
                binding="netTcpBinding"
                bindingConfiguration="NetTcpBinding_ICalculator"
                contract="ICalculator"  
                name="NetTcpBinding_ICalculator">  
      </endpoint>  
    </client>  
  </system.serviceModel>  
</configuration>  
```  
  
## See also

- [Security Overview](security-overview.md)
- [How to: Secure a Service with Windows Credentials](../how-to-secure-a-service-with-windows-credentials.md)
- [Security Model for Windows Server App Fabric](/previous-versions/appfabric/ee677202(v=azure.10))
