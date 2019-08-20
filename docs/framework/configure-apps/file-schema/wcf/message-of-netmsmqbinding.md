---
title: "<message> of <netMsmqBinding>"
ms.date: "03/30/2017"
ms.assetid: 6ebf0240-d7be-4493-b0fe-f00fd5989d77
---

# \<message> of \<netMsmqBinding>

Defines the SOAP message security settings on this `netMsmqBinding` binding.

```xml
<system.ServiceModel>
  <bindings>
    <netMsmqBinding>
      <binding>
        <security>
          <message>
```

## Syntax

```xml
<netMsmqBinding>
  <binding>
    <security>
      <message algorithmSuite="Basic128/Basic192/Basic256/Basic128Rsa15/Basic256Rsa15/TripleDes/TripleDesRsa15/Basic128Sha256/Basic192Sha256/TripleDesSha256/Basic128Sha256Rsa15/Basic192Sha256Rsa15/Basic256Sha256Rsa15/TripleDesSha256Rsa15"
               clientCredentialType="None/Windows/UserName/Certificate/CardSpace" />
    </security>
  </binding>
</netMsmqBinding>
```

## Attributes and Elements

The following sections describe attributes, child elements, and parent elements.

### Attributes

|Attribute|Description|
|---------------|-----------------|
|algorithmSuite|Sets the message encryption and key-wrap algorithms that are used to achieve message-based security for messages sent over MSMQ transport.<br /><br /> The default value is `Aes256`. This attribute is of type <xref:System.ServiceModel.Security.SecurityAlgorithmSuite>.|
|clientCredentialType|Specifies the type of credential to be used when performing client authentication for messages sent over the MSMQ transport. Valid values include the following:<br /><br /> -   None: This allows the service to interact with anonymous clients. Neither the service nor the client requires a credential.<br />-   Windows: This enables the SOAP exchanges to be under the authenticated context of a Windows credential. This always performs Kerberos-based authentication.<br />-   UserName: This enables the service to require that the client be authenticated using a UserName credential. The credential in this case needs to be specified using the `clientCredentials` behavior **Caution:**  Windows Communication Foundation (WCF) does not support sending a password digest or deriving keys using password and using such keys for message security. Therefore, WCF enforces that the exchange is secured when using UserName credentials. This mode requires that the service certificate be specified on the client side using `clientCredential` behavior and `serviceCertificate`. <br /><br /> -   Certificate: This enables the service to require that the client be authenticated using a certificate. The client credential in this case needs to be specified using the `clientCredentials` behavior. The service credential in this case needs to be specified using the `clientCredentials` behavior by specifying the `serviceCertificate`.<br />-   CardSpace: This allows the service to require that the client be authenticated using a CardSpace. The `serviceCertificate` must be provisioned in the `clientCredential` behavior.<br /><br /> The default value is `Windows`. This attribute is of type <xref:System.ServiceModel.MessageCredentialType>.|

### Child Elements

None

### Parent Elements

|Element|Description|
|-------------|-----------------|
|[\<security>](security-of-netmsmqbinding.md)|Defines the security settings for a binding.|

## See also

- <xref:System.ServiceModel.Configuration.MessageSecurityOverMsmqElement>
- <xref:System.ServiceModel.Configuration.NetMsmqSecurityElement.Message%2A>
- <xref:System.ServiceModel.NetMsmqSecurity.Message%2A>
- <xref:System.ServiceModel.MessageSecurityOverMsmq>
- [Queues in WCF](../../feature-details/queues-in-wcf.md)
- [Securing Services and Clients](../../feature-details/securing-services-and-clients.md)
- [Bindings](../../bindings.md)
- [Configuring System-Provided Bindings](../../feature-details/configuring-system-provided-bindings.md)
- [Using Bindings to Configure Services and Clients](../../using-bindings-to-configure-services-and-clients.md)
- [\<binding>](../../../misc/binding.md)
