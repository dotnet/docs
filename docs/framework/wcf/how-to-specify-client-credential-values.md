---
title: "How to: Specify Client Credential Values"
description: Learn how a WCF service can specify how a client is authenticated to that service. This example specifies an X.509 certificate and Transport mode.
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: 82293d7f-471a-4549-8f19-0be890e7b074
---
# How to: Specify Client Credential Values

Using Windows Communication Foundation (WCF), the service can specify how a client is authenticated to the service. For example, a service can stipulate that the client be authenticated with a certificate.

## To determine the client credential type

1. Retrieve metadata from the service's metadata endpoint. The metadata typically consists of two files: the client code in the programming language of your choice (the default is Visual C#), and an XML configuration file. One way to retrieve metadata is to use the Svcutil.exe tool to return the client code and client configuration. For more information, see [Retrieving Metadata](./feature-details/retrieving-metadata.md) and [ServiceModel Metadata Utility Tool (Svcutil.exe)](servicemodel-metadata-utility-tool-svcutil-exe.md).

2. Open the XML configuration file. If you use the Svcutil.exe tool, the default name of the file is Output.config.

3. Find the **\<security>** element with the **mode** attribute (**\<security mode =**`MessageOrTransport`**>** where `MessageOrTransport` is set to one of the security modes.

4. Find the child element that matches the mode value. For example, if the mode is set to **Message**, find the **\<message>** element contained in the **\<security>** element.

5. Note the value assigned to the **clientCredentialType** attribute. The actual value depends on which mode is used, transport or message.

The following XML code shows configuration for a client using message security and requiring a certificate to authenticate the client.

```xml
<security mode="Message">
    <transport clientCredentialType="Windows" proxyCredentialType="None"
        realm="" />
     <message clientCredentialType="Certificate" negotiateServiceCredential="true"
    algorithmSuite="Default" establishSecurityContext="true" />
</security>
```

## Example: TCP Transport Mode with Certificate as Client Credential

This example sets the security mode to Transport mode and sets the client credential value to an X.509 certificate. The following procedures demonstrate how to set the client credential value on the client in code and configuration. This assumes that you have used the [ServiceModel Metadata Utility Tool (Svcutil.exe)](servicemodel-metadata-utility-tool-svcutil-exe.md) to return the metadata (code and configuration) from the service. For more information, see [How to: Create a Client](how-to-create-a-wcf-client.md).

### To specify the client credential value on the client in code

1. Use the [ServiceModel Metadata Utility Tool (Svcutil.exe)](servicemodel-metadata-utility-tool-svcutil-exe.md) to generate code and configuration from the service.

2. Create an instance of the WCF client using the generated code.

3. On the client class, set the <xref:System.ServiceModel.ClientBase%601.ClientCredentials%2A> property of the <xref:System.ServiceModel.ClientBase%601> class to an appropriate value. This example sets the property to an X.509 certificate using the <xref:System.ServiceModel.Security.X509CertificateInitiatorClientCredential.SetCertificate%2A> method of the <xref:System.ServiceModel.Security.X509CertificateInitiatorClientCredential> class.

     [!code-csharp[c_TcpService#4](../../../samples/snippets/csharp/VS_Snippets_CFX/c_tcpservice/cs/source.cs#4)]
     [!code-vb[c_TcpService#4](../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_tcpservice/vb/source.vb#4)]

     You can use any of the enumerations of the <xref:System.Security.Cryptography.X509Certificates.X509FindType> class. The subject name is used here in case the certificate is changed (due to an expiration date). Using the subject name enables the infrastructure to find the certificate again.

### To specify the client credential value on the client in configuration

1. Add a [\<behavior>](../configure-apps/file-schema/wcf/behavior-of-endpointbehaviors.md) element to the [\<behaviors>](../configure-apps/file-schema/wcf/behaviors.md) element.

2. Add a [\<clientCredentials>](../configure-apps/file-schema/wcf/clientcredentials.md) element to the [\<behaviors>](../configure-apps/file-schema/wcf/behaviors.md) element. Be sure to set the required `name` attribute to an appropriate value.

3. Add a [\<clientCertificate>](../configure-apps/file-schema/wcf/clientcertificate-of-servicecredentials.md) element to the [\<clientCredentials>](../configure-apps/file-schema/wcf/clientcredentials.md) element.

4. Set the following attributes to appropriate values: `storeLocation`, `storeName`, `x509FindType`, and `findValue`, as shown in the following code. For more information about certificates, see [Working with Certificates](./feature-details/working-with-certificates.md).

    ```xml
    <behaviors>
       <endpointBehaviors>
          <behavior name="endpointCredentialBehavior">
            <clientCredentials>
              <clientCertificate findValue="Contoso.com"
                                 storeLocation="LocalMachine"
                                 storeName="TrustedPeople"
                                 x509FindType="FindBySubjectName" />
            </clientCredentials>
          </behavior>
       </endpointBehaviors>
    </behaviors>
    ```

5. When configuring the client, specify the behavior by setting the `behaviorConfiguration` attribute of the `<endpoint>` element, as shown in the following code. The endpoint element is a child of the [\<client>](../configure-apps/file-schema/wcf/client.md) element. Also, specify the name of the binding configuration by setting the `bindingConfiguration` attribute to the binding for the client. If you are using a generated configuration file, the binding's name is automatically generated. In this example, the name is `"tcpBindingWithCredential"`.

    ```xml
    <client>
      <endpoint name =""
                address="net.tcp://contoso.com:8036/aloha"
                binding="netTcpBinding"
                bindingConfiguration="tcpBindingWithCredential"
                behaviorConfiguration="endpointCredentialBehavior" />
    </client>
    ```

## See also

- <xref:System.ServiceModel.NetTcpBinding>
- <xref:System.ServiceModel.Security.X509CertificateRecipientServiceCredential.SetCertificate%2A>
- <xref:System.ServiceModel.Security.X509CertificateRecipientServiceCredential>
- <xref:System.ServiceModel.ClientBase%601>
- <xref:System.ServiceModel.Security.X509CertificateInitiatorClientCredential>
- [Programming WCF Security](./feature-details/programming-wcf-security.md)
- [Selecting a Credential Type](./feature-details/selecting-a-credential-type.md)
- [ServiceModel Metadata Utility Tool (Svcutil.exe)](servicemodel-metadata-utility-tool-svcutil-exe.md)
- [Working with Certificates](./feature-details/working-with-certificates.md)
- [How to: Create a Client](how-to-create-a-wcf-client.md)
- [\<netTcpBinding>](../configure-apps/file-schema/wcf/nettcpbinding.md)
- [\<security>](../configure-apps/file-schema/wcf/security-of-nettcpbinding.md)
- [\<message>](../configure-apps/file-schema/wcf/message-element-of-nettcpbinding.md)
- [\<behavior>](../configure-apps/file-schema/wcf/behavior-of-endpointbehaviors.md)
- [\<behaviors>](../configure-apps/file-schema/wcf/behaviors.md)
- [\<clientCertificate>](../configure-apps/file-schema/wcf/clientcertificate-of-servicecredentials.md)
- [\<clientCredentials>](../configure-apps/file-schema/wcf/clientcredentials.md)
