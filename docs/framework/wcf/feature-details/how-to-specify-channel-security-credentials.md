---
title: "How to: Specify Channel Security Credentials"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f8e03f47-9c4f-4dd5-8f85-429e6d876119
caps.latest.revision: 18
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# How to: Specify Channel Security Credentials
The [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] Service Moniker allows COM applications to call [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services. Most [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services require the client to specify credentials for authentication and authorization. When calling a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service from a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client, you can specify these credentials in managed code or in an application configuration file. When calling a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service from a COM application, you can use the <xref:System.ServiceModel.ComIntegration.IChannelCredentials> interface to specify credentials. This topic will illustrate various ways to specify credentials using the <xref:System.ServiceModel.ComIntegration.IChannelCredentials> interface.  
  
> [!NOTE]
>  <xref:System.ServiceModel.ComIntegration.IChannelCredentials> is an IDispatch-based interface and you will not get IntelliSense functionality in the Visual Studio environment.  
  
 This article will use the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service defined in the [Message Security Sample](../../../../docs/framework/wcf/samples/message-security-sample.md).  
  
### To specify a client certificate  
  
1.  Run the Setup.bat file in the Message Security directory to create and install the required test certificates.  
  
2.  Open the Message Security project.  
  
3.  Add `[ServiceBehavior(Namespace=``http://Microsoft.ServiceModel.Samples``)]` to the `ICalculator` interface definition.  
  
4.  Add `bindingNamespace=``http://Microsoft.ServiceModel.Samples` to the endpoint tag in the App.config for the service.  
  
5.  Build the Message Security Sample and run Service.exe. Use Internet Explorer and browse to the service's URI (http://localhost:8000/ServiceModelSamples/Service) to ensure that the service is working.  
  
6.  Open Visual Basic 6.0 and create a new Standard .exe file. Add a button to the form and double-click the button to add the following code to the Click handler:  
  
    ```  
        monString = "service:mexAddress=http://localhost:8000/ServiceModelSamples/Service?wsdl"  
        monString = monString + ", address=http://localhost:8000/ServiceModelSamples/Service"  
        monString = monString + ", contract=ICalculator, contractNamespace=http://Microsoft.ServiceModel.Samples"  
        monString = monString + ", binding=BasicHttpBinding_ICalculator, bindingNamespace=http://Microsoft.ServiceModel.Samples"  
  
        Set monikerProxy = GetObject(monString)  
  
        'Set the Service Certificate.  
     monikerProxy.ChannelCredentials.SetServiceCertificateAuthentication "CurrentUser", "NoCheck", "PeerOrChainTrust"  
    monikerProxy.ChannelCredentials.SetDefaultServiceCertificateFromStore "CurrentUser", "TrustedPeople", "FindBySubjectName", "localhost"  
  
        'Set the Client Certificate.  
        monikerProxy.ChannelCredentials.SetClientCertificateFromStoreByName "CN=client.com", "CurrentUser", "My"  
        MsgBox monikerProxy.Add(3, 4)  
    ```  
  
7.  Run the Visual Basic application and verify the results.  
  
     The Visual Basic application will display a message box with the result from calling Add(3, 4). <xref:System.ServiceModel.ComIntegration.IChannelCredentials.SetClientCertificateFromFile%28System.String%2CSystem.String%2CSystem.String%29> or <xref:System.ServiceModel.ComIntegration.IChannelCredentials.SetClientCertificateFromStoreByName%28System.String%2CSystem.String%2CSystem.String%29> can also be used in place of <xref:System.ServiceModel.ComIntegration.IChannelCredentials.SetClientCertificateFromStore%28System.String%2CSystem.String%2CSystem.String%2CSystem.Object%29> to set the Client Certificate:  
  
    ```  
    monikerProxy.ChannelCredentials.SetClientCertificateFromFile "C:\MyClientCert.pfx", "password", "DefaultKeySet"  
    ```  
  
> [!NOTE]
>  For this call to work, the client certificate needs to be trusted on the machine the client is running on.  
  
> [!NOTE]
>  If the moniker is malformed or if the service is unavailable, the call to `GetObject` will return an error saying "Invalid Syntax." If you receive this error, make sure the moniker you are using is correct and the service is available.  
  
### To specify user name and password  
  
1.  Modify the Service App.config file to use the `wsHttpBinding`. This is required for user name and password validation:  
  
  
  
2.  Set the `clientCredentialType` to UserName:  
  
  
  
3.  Open Visual Basic 6.0 and create a new Standard .exe file. Add a button to the form and double-click the button to add the following code to the Click handler:  
  
    ```  
    monString = "service:mexAddress=http://localhost:8000/ServiceModelSamples/Service?wsdl"  
    monString = monString + ", address=http://localhost:8000/ServiceModelSamples/Service"  
    monString = monString + ", contract=ICalculator, contractNamespace=http://Microsoft.ServiceModel.Samples"  
    monString = monString + ", binding=WSHttpBinding_ICalculator, bindingNamespace=http://Microsoft.ServiceModel.Samples"  
  
    Set monikerProxy = GetObject(monString)  
  
    monikerProxy.ChannelCredentials.SetServiceCertificateAuthentication "CurrentUser", "NoCheck", "PeerOrChainTrust"  
    monikerProxy.ChannelCredentials.SetUserNameCredential "username", "password"  
  
    MsgBox monikerProxy.Add(3, 4)  
    ```  
  
4.  Run the Visual Basic application and verify the results. The Visual Basic application will display a message box with the result from calling Add(3, 4).  
  
    > [!NOTE]
    >  The binding specified in the service moniker in this sample has been changed to WSHttpBinding_ICalculator. Also note that you must supply a valid user name and password in the call to <xref:System.ServiceModel.ComIntegration.IChannelCredentials.SetUserNameCredential%28System.String%2CSystem.String%29>.  
  
### To specify Windows Credentials  
  
1.  Set `clientCredentialType` to Windows in the Service App.config file:  
  
  
  
2.  Open Visual Basic 6.0 and create a new Standard .exe file. Add a button to the form and double-click the button to add the following code to the Click handler:  
  
    ```  
    monString = "service:mexAddress=http://localhost:8000/ServiceModelSamples/Service?wsdl"  
    monString = monString + ", address=http://localhost:8000/ServiceModelSamples/Service"  
    monString = monString + ", contract=ICalculator, contractNamespace=http://Microsoft.ServiceModel.Samples"  
    monString = monString + ", binding=WSHttpBinding_ICalculator, bindingNamespace=http://Microsoft.ServiceModel.Samples"  
    monString = monString + ", upnidentity=domain\userID"  
  
    Set monikerProxy = GetObject(monString)  
     monikerProxy.ChannelCredentials.SetWindowsCredential "domain", "userID", "password", 1, True  
  
    MsgBox monikerProxy.Add(3, 4)  
    ```  
  
3.  Run the Visual Basic application and verify the results. The Visual Basic application will display a message box with the result from calling Add(3, 4).  
  
    > [!NOTE]
    >  You must replace "domain", "userID", and "password" with valid values.  
  
### To specify an issue token  
  
1.  Issue tokens are used only for applications using federated security. For more information about federated security, see [Federation and Issued Tokens](../../../../docs/framework/wcf/feature-details/federation-and-issued-tokens.md) and [Federation Sample](../../../../docs/framework/wcf/samples/federation-sample.md).  
  
     The following Visual Basic code example illustrates how to call the <xref:System.ServiceModel.ComIntegration.IChannelCredentials.SetIssuedToken%28System.String%2CSystem.String%2CSystem.String%29> method:  
  
    ```  
        monString = "service:mexAddress=http://localhost:8000/ServiceModelSamples/Service?wsdl"  
        monString = monString + ", address=http://localhost:8000/SomeService/Service"  
        monString = monString + ", contract=ICalculator, contractNamespace=http://SomeService.Samples"  
        monString = monString + ", binding=WSHttpBinding_ISomeContract, bindingNamespace=http://SomeService.Samples"  
  
        Set monikerProxy = GetObject(monString)  
    monikerProxy.SetIssuedToken("http://somemachine/sts", "bindingType", "binding")  
    ```  
  
     For more information about the parameters for this method, see <xref:System.ServiceModel.ComIntegration.IChannelCredentials.SetIssuedToken%28System.String%2CSystem.String%2CSystem.String%29>.  
  
## See Also  
 [Federation](../../../../docs/framework/wcf/feature-details/federation.md)  
 [How to: Configure Credentials on a Federation Service](../../../../docs/framework/wcf/feature-details/how-to-configure-credentials-on-a-federation-service.md)  
 [How to: Create a Federated Client](../../../../docs/framework/wcf/feature-details/how-to-create-a-federated-client.md)  
 [Message Security](../../../../docs/framework/wcf/feature-details/message-security-in-wcf.md)  
 [Bindings and Security](../../../../docs/framework/wcf/feature-details/bindings-and-security.md)
