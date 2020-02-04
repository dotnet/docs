---
title: "How to: Specify the Client Credential Type"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "security credentials, adding to SOAP messages"
  - "WCF, security"
ms.assetid: 10f51bee-5f92-4c1a-9126-fa5418535d8f
---
# How to: Specify the Client Credential Type
After setting a security mode (either transport or message), you have the option of setting the client credential type. This property specifies what type of credential the client must provide to the service for authentication. For more information about setting the security mode (a necessary step before setting the client credential type), see [How to: Set the Security Mode](how-to-set-the-security-mode.md).  
  
### To set the client credential type in code  
  
1. Create an instance of the binding that the service will use. This example uses the <xref:System.ServiceModel.WSHttpBinding> binding.  
  
2. Set the <xref:System.ServiceModel.WSHttpSecurity.Mode%2A> property to an appropriate value. This example uses the Message mode.  
  
3. Set the <xref:System.ServiceModel.MessageSecurityOverHttp.ClientCredentialType%2A> property to an appropriate value. This example sets it to use Windows authentication (<xref:System.ServiceModel.MessageCredentialType.Windows>).  
  
     [!code-csharp[c_ProgrammingSecurity#14](../../../samples/snippets/csharp/VS_Snippets_CFX/c_programmingsecurity/cs/source.cs#14)]
     [!code-vb[c_ProgrammingSecurity#14](../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_programmingsecurity/vb/source.vb#14)]  
  
### To set the client credential type in configuration  
  
1. Add a [\<system.serviceModel>](../configure-apps/file-schema/wcf/system-servicemodel.md) element to the configuration file.  
  
2. As a child element, add a [\<bindings>](../configure-apps/file-schema/wcf/bindings.md) element.  
  
3. Add an appropriate binding. This example uses the [\<wsHttpBinding>](../configure-apps/file-schema/wcf/wshttpbinding.md) element.  
  
4. Add a [\<binding>](../configure-apps/file-schema/wcf/bindings.md) element and set the `name` attribute to an appropriate value. This example uses the name "SecureBinding".  
  
5. Add a `<security>` binding. Set the `mode` attribute to an appropriate value. This example sets it to `"Message"`.  
  
6. Add either a `<message>` or `<transport>` element, as determined by the security mode. Set the `clientCredentialType` attribute to an appropriate value. This example uses `"Windows"`.  
  
    ```xml  
    <system.serviceModel>  
      <bindings>  
        <wsHttpBinding>  
          <binding name="SecureBinding">  
            <security mode="Message">  
                 <message clientCredentialType="Windows" />  
             </security>  
          </binding>  
        </wsHttpBinding>  
      </bindings>  
    </system.serviceModel>  
    ```  
  
## See also

- [Securing Services](securing-services.md)
- [How to: Set the Security Mode](how-to-set-the-security-mode.md)
