---
title: "How to: Authenticate with a User Name and Password"
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
helpviewer_keywords: 
  - "authentication [WCF], user name and password"
ms.assetid: a5415be2-0ef3-464c-9f76-c255cb8165a4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Authenticate with a User Name and Password

This topic demonstrates how to enable a [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] service to authenticate a client with a Windows domain username and password. It assumes you have a working, self-hosted WCF service. For an example of creating a basic self-hosted WCF service see, [Getting Started Tutorial](../../../../docs/framework/wcf/getting-started-tutorial.md). This topic assumes the service is configured in code. If you would like to see an example of configuring a similar service using a configuration file see [Message Security User Name](../../../../docs/framework/wcf/samples/message-security-user-name.md)  
  
 To configure a service to authenticate its clients using Windows Domain username and passwords use the <xref:System.ServiceModel.WSHttpBinding> and set its `Security.Mode` property to `Message`. In addition you must specify an X509 certificate that will be used to encrypt the username and password as they are sent from the client to the service.  
  
 On the client, you must prompt the user for the username and password and specify the user’s credentials on the WCF client proxy.  
  
## To configure a WCF service to authenticate using Windows domain username and password
  
1.  Create an instance of the <xref:System.ServiceModel.WSHttpBinding>, set the security mode of the binding to `SecurityMode.Message`, set the `ClientCredentialType` of the binding to `MessageCredentialType.UserName`, and add a service endpoint using the configured binding to the service host as shown in the following code:  
  
    ```  
    // ...  
    WSHttpBinding userNameBinding = new WSHttpBinding();  
    userNameBinding.Security.Mode = SecurityMode.Message;  
    userNameBinding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;  
    svcHost.AddServiceEndpoint(typeof(IService1), userNameBinding, "");  
    // ...  
    ```  
  
2.  Specify the server certificate used to encrypt the username and password information sent over the wire. This code should immediately follow the code above. The following example uses the certificate that is created by the setup.bat file from the [Message Security User Name](../../../../docs/framework/wcf/samples/message-security-user-name.md) sample:  
  
    ```  
    // ...  
    svcHost.Credentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindBySubjectName, "localhost");  
    // ...  
    ```  
  
     You can use your own certificate, just modify the code to refer to your certificate. For more information about creating and using certificates see [Working with Certificates](../../../../docs/framework/wcf/feature-details/working-with-certificates.md). Make sure the certificate is in the Trusted People certificate store for the Local Machine. You can do this by running mmc.exe and selecting the **File**, **Add/Remove Snap-in...** menu item. In the **Add or Remove Snap-ins** dialog, select the **Certificates snap-in** and click **Add**. In the Certificates Snap-in dialog select **Computer account**. By default the certificate generated from the Message Security User name sample will be located in the Personal/Certificates folder.  It will be listed as "localhost" under the Issued to column in the MMC window. Drag and drop the certificate into the **Trusted People** folder. This will allow WCF to treat the certificate as a trusted certificate when performing authentication.  
  
## To call the service passing username and password  
  
1.  The client application must prompt the user for their username and password. The following code asks the user for username and password.  
  
    > [!WARNING]
    >  This code should not be used in production as the password is displayed while being entered.  
  
    ```  
    public static void GetPassword(out string username, out string password)  
            {  
                Console.WriteLine("Provide a valid machine or domain account. [domain\\user]");  
                Console.WriteLine("   Enter username:");  
                username = Console.ReadLine();  
                Console.WriteLine("   Enter password:");  
                password = Console.ReadLine();             
                return;  
            }  
    ```  
  
2.  Create an instance of the client proxy specifying the client’s credentials as shown in the following code:  
  
    ```  
    string username;  
    string password;  
  
    // Instantiate the proxy  
    Service1Client proxy = new Service1Client();  
  
    // Prompt the user for username & password  
    GetPassword(out username, out password);  
  
    // Set the user’s credentials on the proxy  
    proxy.ClientCredentials.UserName.UserName = username;  
    proxy.ClientCredentials.UserName.Password = password;  
  
    // Treat the test certificate as trusted  
    proxy.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.PeerOrChainTrust;  
    // Call the service operation using the proxy  
    ```  
  
## See Also  
 <xref:System.ServiceModel.WSHttpBinding>  
 <xref:System.ServiceModel.WSHttpSecurity>  
 <xref:System.ServiceModel.SecurityMode>  
 <xref:System.ServiceModel.Security.UserNamePasswordClientCredential.UserName%2A>  
 <xref:System.ServiceModel.Security.UserNamePasswordClientCredential.Password%2A>  
 <xref:System.ServiceModel.Security.UserNamePasswordClientCredential>  
 <xref:System.ServiceModel.WSHttpSecurity.Mode%2A>  
 <xref:System.ServiceModel.HttpTransportSecurity.ClientCredentialType%2A>  
 [Transport Security with Basic Authentication](../../../../docs/framework/wcf/feature-details/transport-security-with-basic-authentication.md)  
 [Distributed Application Security](../../../../docs/framework/wcf/feature-details/distributed-application-security.md)  
 [\<wsHttpBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/wshttpbinding.md)
