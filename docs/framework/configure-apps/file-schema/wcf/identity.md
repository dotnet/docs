---
description: "Learn more about: <identity>"
title: "<identity>"
ms.date: "03/30/2017"
ms.assetid: c1d2ae56-e231-4a07-9c3f-9f13381dc0d8
---
# \<identity>

The identity element allows a client developer to specify at design time the expected identity of the service. In the handshake process between the client and service, the Windows Communication Foundation (WCF) infrastructure will ensure that the identity of the expected service matches the values of this element, and thus can be authenticated. For more information, see [Service Identity and Authentication](../../../wcf/feature-details/service-identity-and-authentication.md).  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<client>**](client.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<endpoint>**](endpoint-of-client.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<identity>**  
  
## Syntax  
  
```xml  
<identity>
  <certificate encodedValue="String" />
  <certificateReference findValue="String"
                        isChainIncluded="Boolean"
                        storeName="AddressBook/AuthRoot/CertificateAuthority/Disallowed/My/Root/TrustedPeople/TrustedPublisher"
                        storeLocation="LocalMachine/CurrentUser"
                        X509FindType="Enumeration" />
  <dns value="String" />
  <rsa value="String" />
  <servicePrincipalName value="String" />
  <userPrincipalName value="String" />
</identity>
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  

 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|certificate|Specifies settings of an X.509 certificate. This element is of type <xref:System.ServiceModel.Configuration.CertificateElement>. It contains an attribute `encodedValue` that is a string, which specifies the value encoded by this certificate.|  
|certificateReference|Specifies settings for X.509 certificate validation. This element is of type <xref:System.ServiceModel.Configuration.CertificateReferenceElement>.|  
|dns|Specifies the DNS of an X.509 certificate used to authenticate a service. This element contains an attribute `value` that is a string, and contains the actual identity.|  
|rsa|Specifies the value of the RSA field of an X.509 certificate used to authenticate a service to a client. This element contains an attribute `value` that is a string, and contains the actual identity|  
|servicePrincipalName|Specifies a server principal name (SPN) identity, which is the principal name used by a client to uniquely identify an instance of a service. This element contains an attribute `value` that is a string, and contains the actual principal name. This element is of type <xref:System.ServiceModel.Configuration.ServicePrincipalNameElement>.|  
|userPrincipalName|Specifies a user principal name (UPN) identity, which is the logon name type of a user on a network. The user principal name consists of the user object name used in Active Directory, followed by the at symbol (\@) and then, typically, the Domain Name System parent domain. For example, Jeff in the Fabrikam.com domain tree might have the user principal name [jeff@fabrikam.com](mailto:jeffsmith@fabrikam.com).  This element contains an attribute `value` that is a string, and contains the actual principal name. This element is of type <xref:System.ServiceModel.Configuration.UserPrincipalNameElement>.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<custom>](custom.md)|Specifies a custom peer resolver for a netPeerTcpBinding.|  
|[\<endpoint>](endpoint-element.md)|Configures service endpoints.|  
|[\<endpoint> of \<client>](endpoint-of-client.md)|Configures channel endpoints.|  
|[\<issuer>](issuer.md)|Specifies the Security Token Service (STS) for the federated service.|  
|[\<issuerMetadata>](issuermetadata.md)|Specifies the metadata endpoint for the Security Token Service (STS) of a federated service.|  
|[\<issuedTokenParameters>](issuedtokenparameters.md)|Defines parameters for an issued token in a custom binding.|  
|[\<localIssuer>](localissuer.md)|Specifies a local Security Token Service (STS).|  
  
## See also

- <xref:System.ServiceModel.Configuration.IdentityElement>
- <xref:System.ServiceModel.EndpointAddress>
- <xref:System.ServiceModel.EndpointAddress.Identity%2A>
- [Service Identity and Authentication](../../../wcf/feature-details/service-identity-and-authentication.md)
- [Endpoints: Addresses, Bindings, and Contracts](../../../wcf/feature-details/endpoints-addresses-bindings-and-contracts.md)
