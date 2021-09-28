---
description: "Learn more about: How to: Create a Service that Employs a Custom Certificate Validator"
title: "How to: Create a Service that Employs a Custom Certificate Validator"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "WCF, authentication"
ms.assetid: bb0190ff-0738-4e54-8d22-c97d343708bf
---
# How to: Create a Service that Employs a Custom Certificate Validator

This topic shows how to implement a custom certificate validator and how to configure client or service credentials to replace the default certificate validation logic with the custom certificate validator.  
  
 If the X.509 certificate is used to authenticate a client or service, Windows Communication Foundation (WCF) by default uses the Windows certificate store and Crypto API to validate the certificate and to ensure that it is trusted. Sometimes the built-in certificate validation functionality is not enough and must be changed. WCF provides an easy way to change the validation logic by allowing users to add a custom certificate validator. If a custom certificate validator is specified, WCF does not use the built-in certificate validation logic but relies on the custom validator instead.  
  
## Procedures  
  
#### To create a custom certificate validator  
  
1. Define a new class derived from <xref:System.IdentityModel.Selectors.X509CertificateValidator>.  
  
2. Implement the abstract <xref:System.IdentityModel.Selectors.X509CertificateValidator.Validate%2A> method. The certificate that must be validated is passed as an argument to the method. If the passed certificate is not valid according to the validation logic, this method throws a <xref:System.IdentityModel.Tokens.SecurityTokenValidationException>. If the certificate is valid, the method returns to the caller.  
  
    > [!NOTE]
    > To return authentication errors back to the client, throw a <xref:System.ServiceModel.FaultException> in the <xref:System.IdentityModel.Selectors.UserNamePasswordValidator.Validate%2A> method.  
  
 [!code-csharp[c_CustomCertificateValidator#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customcertificatevalidator/cs/source.cs#2)]
 [!code-vb[c_CustomCertificateValidator#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customcertificatevalidator/vb/source.vb#2)]  
  
#### To specify a custom certificate validator in service configuration  
  
1. Add a [\<behaviors>](../../configure-apps/file-schema/wcf/behaviors.md) element and a [\<serviceBehaviors>](../../configure-apps/file-schema/wcf/servicebehaviors.md) to the [\<system.serviceModel>](../../configure-apps/file-schema/wcf/system-servicemodel.md) element.  
  
2. Add a [\<behavior>](../../configure-apps/file-schema/wcf/behavior-of-endpointbehaviors.md) and set the `name` attribute to an appropriate value.  
  
3. Add a [\<serviceCredentials>](../../configure-apps/file-schema/wcf/servicecredentials.md) to the `<behavior>` element.  
  
4. Add a `<clientCertificate>` element to the `<serviceCredentials>` element.  
  
5. Add an [\<authentication>](../../configure-apps/file-schema/wcf/authentication-of-clientcertificate-element.md) to the `<clientCertificate>` element.  
  
6. Set the `customCertificateValidatorType` attribute to the validator type. The following example sets the attribute to the namespace and name of the type.  
  
7. Set the `certificateValidationMode` attribute to `Custom`.  
  
    ```xml  
    <configuration>  
     <system.serviceModel>  
      <behaviors>  
       <serviceBehaviors>  
        <behavior name="ServiceBehavior">  
         <serviceCredentials>  
          <clientCertificate>  
          <authentication certificateValidationMode="Custom" customCertificateValidatorType="Samples.MyValidator, service" />  
          </clientCertificate>  
         </serviceCredentials>  
        </behavior>  
       </serviceBehaviors>  
      </behaviors>  
    </system.serviceModel>  
    </configuration>  
    ```  
  
#### To specify a custom certificate validator using configuration on the client  
  
1. Add a [\<behaviors>](../../configure-apps/file-schema/wcf/behaviors.md) element and a [\<serviceBehaviors>](../../configure-apps/file-schema/wcf/servicebehaviors.md) to the [\<system.serviceModel>](../../configure-apps/file-schema/wcf/system-servicemodel.md) element.  
  
2. Add an [\<endpointBehaviors>](../../configure-apps/file-schema/wcf/endpointbehaviors.md) element.  
  
3. Add a `<behavior>` element and set the `name` attribute to an appropriate value.  
  
4. Add a [\<clientCredentials>](../../configure-apps/file-schema/wcf/clientcredentials.md) element.  
  
5. Add a [\<serviceCertificate>](../../configure-apps/file-schema/wcf/servicecertificate-of-clientcredentials-element.md).  
  
6. Add an [\<authentication>](../../configure-apps/file-schema/wcf/authentication-of-servicecertificate-element.md) as shown on the following example.  
  
7. Set the `customCertificateValidatorType` attribute to the validator type.  
  
8. Set the `certificateValidationMode` attribute to `Custom`. The following example sets the attribute to the namespace and name of the type.  
  
    ```xml  
    <configuration>  
     <system.serviceModel>  
      <behaviors>  
       <endpointBehaviors>  
        <behavior name="clientBehavior">  
         <clientCredentials>  
          <serviceCertificate>  
           <authentication certificateValidationMode="Custom"
                  customCertificateValidatorType=  
             "Samples.CustomX509CertificateValidator, client"/>  
          </serviceCertificate>  
         </clientCredentials>  
        </behavior>  
       </endpointBehaviors>  
      </behaviors>  
     </system.serviceModel>  
    </configuration>  
    ```  
  
#### To specify a custom certificate validator using code on the service  
  
1. Specify the custom certificate validator on the <xref:System.ServiceModel.Description.ServiceCredentials.ClientCertificate%2A> property. You can access the service credentials using the <xref:System.ServiceModel.ServiceHostBase.Credentials%2A> property.  
  
2. Set the <xref:System.ServiceModel.Security.X509ClientCertificateAuthentication.CertificateValidationMode%2A> property to <xref:System.ServiceModel.Security.X509CertificateValidationMode.Custom>.  
  
 [!code-csharp[c_CustomCertificateValidator#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customcertificatevalidator/cs/source.cs#1)]
 [!code-vb[c_CustomCertificateValidator#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customcertificatevalidator/vb/source.vb#1)]  
  
#### To specify a custom certificate validator using code on the client  
  
1. Specify the custom certificate validator using the <xref:System.ServiceModel.Security.X509ServiceCertificateAuthentication.CustomCertificateValidator%2A> property. You can access the client credentials using the <xref:System.ServiceModel.ServiceHostBase.Credentials%2A> property. (The client class generated by [ServiceModel Metadata Utility Tool (Svcutil.exe)](../servicemodel-metadata-utility-tool-svcutil-exe.md) always derives from the <xref:System.ServiceModel.ClientBase%601> class.)  
  
2. Set the <xref:System.ServiceModel.Security.X509ServiceCertificateAuthentication.CertificateValidationMode%2A> property to <xref:System.ServiceModel.Security.X509CertificateValidationMode.Custom>.  
  
## Example  
  
### Description  

 The following sample shows an implementation of a custom certificate validator and its usage on the service.  
  
### Code  

 [!code-csharp[c_CustomCertificateValidator#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_customcertificatevalidator/cs/source.cs#3)]
 [!code-vb[c_CustomCertificateValidator#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_customcertificatevalidator/vb/source.vb#3)]  
  
## See also

- <xref:System.IdentityModel.Selectors.X509CertificateValidator>
