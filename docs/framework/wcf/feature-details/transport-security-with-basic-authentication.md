---
title: "Transport Security with Basic Authentication"
description: Review this WCF scenario, which shows basic authentication for a WCF service and client. The service needs a valid certificate that the client trusts.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: b54f491d-196b-4279-876c-76b83ec0442c
---
# Transport Security with Basic Authentication

The following illustration shows a Windows Communication Foundation (WCF) service and client. The server needs a valid X.509 certificate that can be used for Secure Sockets Layer (SSL), and the clients must trust the server’s certificate. Further, the Web service already has an SSL implementation that can be used. For more information about enabling basic authentication on Internet Information Services (IIS), see [Basic Authentication](/iis/configuration/system.webserver/security/authentication/basicauthentication).
  
 ![Screenshot that shows transport security with basic authentication.](./media/transport-security-with-basic-authentication/transport-security-basic-authentication.gif)  
  
|Characteristic|Description|  
|--------------------|-----------------|  
|Security Mode|Transport|  
|Interoperability|With existing Web service clients and services|  
|Authentication (Server)<br /><br /> Authentication (Client)|Yes (using HTTPS)<br /><br /> Yes (through User name/Password)|  
|Integrity|Yes|  
|Confidentiality|Yes|  
|Transport|HTTPS|  
|Binding|<xref:System.ServiceModel.WSHttpBinding>|  
  
## Service  

 The following code and configuration are meant to run independently. Do one of the following:  
  
- Create a stand-alone service using the code with no configuration.  
  
- Create a service using the supplied configuration, but do not define any endpoints.  
  
### Code  

 The following code shows how to create a service endpoint that uses a Windows domain user name and password for transfer security. Note that the service requires an X.509 certificate to authenticate to the client. For more information, see [Working with Certificates](working-with-certificates.md) and [How to: Configure a Port with an SSL Certificate](how-to-configure-a-port-with-an-ssl-certificate.md).  
  
 [!code-csharp[C_SecurityScenarios#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_securityscenarios/cs/source.cs#1)]
 [!code-vb[C_SecurityScenarios#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_securityscenarios/vb/source.vb#1)]  
  
## Configuration  

 The following configures a service to use basic authentication with transport-level security:  
  
```xml  
<?xml version="1.0" encoding="utf-8"?>  
<configuration>  
    <system.serviceModel>  
        <bindings>  
            <wsHttpBinding>  
                <binding name="UsernameWithTransport">  
                    <security mode="Transport">  
                        <transport clientCredentialType="Basic" />  
                    </security>  
                </binding>  
            </wsHttpBinding>  
        </bindings>  
        <services>  
            <service name="BasicAuthentication.Calculator">  
                <endpoint address="https://localhost/Calculator"  
                          binding="wsHttpBinding"
                          bindingConfiguration="UsernameWithTransport"  
                          name="BasicEndpoint"
                          contract="BasicAuthentication.ICalculator" />  
            </service>  
        </services>  
    </system.serviceModel>  
</configuration>  
```  
  
## Client  
  
### Code  

 The following code shows the client code that includes the user name and password. Note that the user must provide a valid Windows user name and password. The code to return the user name and password is not shown here. Use a dialog box or other interface to query the user for the information.  
  
> [!NOTE]
> User name and password can only be set using code.  
  
 [!code-csharp[C_SecurityScenarios#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_securityscenarios/cs/source.cs#2)]
 [!code-vb[C_SecurityScenarios#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_securityscenarios/vb/source.vb#2)]  
  
### Configuration  

 The following code shows the client configuration.  
  
> [!NOTE]
> You cannot use configuration to set the user name and password. The configuration shown here must be augmented using code to set the user name and password.  
  
```xml  
<?xml version="1.0" encoding="utf-8"?>  
<configuration>  
  <system.serviceModel>  
    <bindings>  
      <wsHttpBinding>  
        <binding name="WSHttpBinding_ICalculator" >  
          <security mode="Transport">  
            <transport clientCredentialType="Basic" />  
          </security>  
        </binding>  
      </wsHttpBinding>  
    </bindings>  
    <client>  
      <endpoint address="https://machineName/Calculator"
                binding="wsHttpBinding"  
                bindingConfiguration="WSHttpBinding_ICalculator"
                contract="ICalculator"  
                name="WSHttpBinding_ICalculator" />  
    </client>  
  </system.serviceModel>  
</configuration>  
```  
  
## See also

- <xref:System.ServiceModel.ClientBase%601.ClientCredentials%2A>
- <xref:System.ServiceModel.Security.UserNamePasswordClientCredential>
- [Working with Certificates](working-with-certificates.md)
- [How to: Configure a Port with an SSL Certificate](how-to-configure-a-port-with-an-ssl-certificate.md)
- [Security Overview](security-overview.md)
- [\<clientCredentials>](../../configure-apps/file-schema/wcf/clientcredentials.md)
- [Security Model for Windows Server App Fabric](/previous-versions/appfabric/ee677202(v=azure.10))
