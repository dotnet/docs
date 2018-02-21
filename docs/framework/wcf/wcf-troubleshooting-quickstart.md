---
title: "WCF Troubleshooting Quickstart"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "WCF [WCF], troubleshooting"
  - "Windows Communication Foundation [WCF], troubleshooting"
ms.assetid: a9ea7a53-f31a-46eb-806e-898e465a4992
caps.latest.revision: 22
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WCF Troubleshooting Quickstart
This topic lists a number of known issues customers have run into while developing WCF clients and services. If the issue you are running into is not in this list, we recommend you configure tracing for your service. This will generate a trace file that you can view with the trace file viewer and get detailed information about exceptions that may be occurring within the service. For more information on configuring tracing, see: [Configuring Tracing](../../../docs/framework/wcf/diagnostics/tracing/configuring-tracing.md). For more information on the trace file viewer, see: [Service Trace Viewer Tool (SvcTraceViewer.exe)](../../../docs/framework/wcf/service-trace-viewer-tool-svctraceviewer-exe.md).  
  
1.  [After installing Windows 7 and IIS, when I attempt to browse to a WCF service I get the following error message: HTTP Error 404.3 – Not Found](../../../docs/framework/wcf/wcf-troubleshooting-quickstart.md#bkmk_0)  
  
     HTTP Error 404.3 – Not FoundThe page you are requesting cannot be served because of the extension configuration. If the page is a script, add a handler. If the file should be downloaded, add a MIME map. Detailed Error InformationModule StaticFileModule.  
  
2.  [Sometimes I receive a MessageSecurityException on the second request if my client is idle for a while after the first request. What is happening?](../../../docs/framework/wcf/wcf-troubleshooting-quickstart.md#BKMK_q1)  
  
3.  [My service starts to reject new clients after about 10 clients are interacting with it. What is happening?](../../../docs/framework/wcf/wcf-troubleshooting-quickstart.md#BKMK_q2)  
  
4.  [Can I load my service configuration from somewhere other than the WCF application’s configuration file?](../../../docs/framework/wcf/wcf-troubleshooting-quickstart.md#BKMK_q3)  
  
5.  [My service and client work great, but I can’t get them to work when the client is on another computer? What’s happening?](../../../docs/framework/wcf/wcf-troubleshooting-quickstart.md#BKMK_q4)  
  
6.  [When I throw a FaultException\<Exception> where the type is an exception, I always receive a general FaultException type on the client and not the generic type. What’s happening?](../../../docs/framework/wcf/wcf-troubleshooting-quickstart.md#BKMK_q5)  
  
7.  [It seems like one-way and request-reply operations return at roughly the same speed when the reply contains no data. What's happening?](../../../docs/framework/wcf/wcf-troubleshooting-quickstart.md#BKMK_q6)  
  
8.  [I’m using an X.509 certificate with my service and I get a System.Security.Cryptography.CryptographicException. What’s happening?](../../../docs/framework/wcf/wcf-troubleshooting-quickstart.md#BKMK_q77)  
  
9. [I changed the first parameter of an operation from uppercase to lowercase; now my client throws an exception. What's happening?](../../../docs/framework/wcf/wcf-troubleshooting-quickstart.md#BKMK_q88)  
  
10. [I’m using one of my tracing tools and I get an EndpointNotFoundException. What’s happening?](../../../docs/framework/wcf/wcf-troubleshooting-quickstart.md#BKMK_q99)  
  
11. [When calling a WCF Web HTTP application from a WCF SOAP application the service returns the following error: 405 Method Not Allowed](../../../docs/framework/wcf/wcf-troubleshooting-quickstart.md#BK_MK99)  
  
 [What is the base address? How does it relate to an endpoint address?](../../../docs/framework/wcf/wcf-troubleshooting-quickstart.md#BKMK_q10)  
  
<a name="bkmk_0"></a>   
## After installing Windows 7 and IIS, when I attempt to browse to a WCF service I get the following error message: HTTP Error 404.3 – Not Found  
 The full error message is:  
  
 HTTP Error 404.3 – Not FoundThe page you are requesting cannot be served because of the extension configuration. If the page is a script, add a handler. If the file should be downloaded, add a MIME map. Detailed Error InformationModule StaticFileModule.  
  
 This error message occurs when "Windows Communication Foundation HTTP Activation" is not explicitly set in the Control Panel. To set this go to the Control Panel, click Programs in the lower left hand corner of the window. Click Turn Windows features on or off. Expand Microsoft .NET Framework 3.5.1 and select Windows Communication Foundation HTTP Activation.  
  
<a name="BKMK_q1"></a>   
## Sometimes I receive a MessageSecurityException on the second request if my client is idle for a while after the first request. What is happening?  
 The second request can fail primarily for two reasons: (1) the session has timed out or (2) the Web server that is hosting the service is recycled. In the first case, the session is valid until the service times out. When the service does not receive a request from the client within the period of time specified in the service's binding (<xref:System.ServiceModel.Channels.Binding.ReceiveTimeout%2A>), the service terminates the security session. Subsequent client messages result in the <xref:System.ServiceModel.Security.MessageSecurityException>. The client must re-establish a secure session with the service to send future messages or use a stateful security context token. Stateful security context tokens also allow a secure session to survive a Web server being recycled. [!INCLUDE[crabout](../../../includes/crabout-md.md)] using stateful secure context tokens in a secure session, see [How to: Create a Security Context Token for a Secure Session](../../../docs/framework/wcf/feature-details/how-to-create-a-security-context-token-for-a-secure-session.md). Alternatively, you can disable secure sessions. When you use the [\<wsHttpBinding>](../../../docs/framework/configure-apps/file-schema/wcf/wshttpbinding.md) binding, you can set the `establishSecurityContext` property to `false` to disable secure sessions. To disable secure sessions for other bindings, you must create a custom binding. For details about creating a custom binding, see [How to: Create a Custom Binding Using the SecurityBindingElement](../../../docs/framework/wcf/feature-details/how-to-create-a-custom-binding-using-the-securitybindingelement.md). Before you apply any of these options, you must understand your application's security requirements.  
  
<a name="BKMK_q2"></a>   
## My service starts to reject new clients after about 10 clients are interacting with it. What is happening?  
 By default, services can have only 10 concurrent sessions. Therefore, if the service bindings use sessions, the service accepts new client connections until it reaches that number, after which it refuses new client connections until one of the current sessions ends. You can support more clients in a number of ways. If your service does not require sessions, do not use a sessionful binding. ([!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Using Sessions](../../../docs/framework/wcf/using-sessions.md).) Another option is to increase the session limit by changing the value of the <xref:System.ServiceModel.Description.ServiceThrottlingBehavior.MaxConcurrentSessions%2A> property to the number appropriate to your circumstance.  
  
<a name="BKMK_q3"></a>   
## Can I load my service configuration from somewhere other than the WCF application’s configuration file?  
 Yes, however, you have to create a custom <xref:System.ServiceModel.ServiceHost> class that overrides the <xref:System.ServiceModel.ServiceHostBase.ApplyConfiguration%2A> method. Inside that method, you can call the base to load configuration first (if you want to load the standard configuration information as well) but you can also entirely replace the configuration loading system. Note that if you want to load configuration from a configuration file that is different from the application configuration file, you must parse the configuration file yourself and load the configuration.  
  
 The following code example shows how to override the <xref:System.ServiceModel.ServiceHostBase.ApplyConfiguration%2A> method and directly configure an endpoint.  
  
```csharp
public class MyServiceHost : ServiceHost  
{  
    public MyServiceHost(Type serviceType, params Uri[] baseAddresses)    
      : base(serviceType, baseAddresses)  
    {
        Console.WriteLine("MyServiceHost Constructor");
    }  
  
    protected override void ApplyConfiguration()  
    {  
        string straddress = GetAddress();  
        Uri address = new Uri(straddress);  
        Binding binding = GetBinding();  
        base.AddServiceEndpoint(typeof(IData), binding, address);  
    }  
  
    string GetAddress()  
    {
        return "http://MyMachine:7777/MyEndpointAddress/";
    }  
  
    Binding GetBinding()  
    {  
        WSHttpBinding binding = new WSHttpBinding();  
        binding.Security.Mode = SecurityMode.None;  
        return binding;  
    }  
}  
```  
  
<a name="BKMK_q4"></a>   
## My service and client work great, but I can’t get them to work when the client is on another computer? What’s happening?  
 Depending upon the exception, there may be several issues:  
  
-   You might need to change the client endpoint addresses to the host name and not "localhost".  
  
-   You might need to open the port to the application. For details, see [Firewall Instructions](../../../docs/framework/wcf/samples/firewall-instructions.md) from the SDK samples.  
  
-   For other possible issues, see the samples topic [Running the Samples in a Workgroup and Across Machines](http://msdn.microsoft.com/library/a451a525-e7ce-452d-9da9-620221260113).  
  
-   If your client is using Windows credentials and the exception is a <xref:System.ServiceModel.Security.SecurityNegotiationException>, configure Kerberos as follows.  
  
    1.  Add the identity credentials to the endpoint element in the client’s App.config file:  
  
        ```xml
        <endpoint   
          address="http://MyServer:8000/MyService/"   
          binding="wsHttpBinding"   
          bindingConfiguration="WSHttpBinding_IServiceExample"   
          contract="IServiceExample"   
          behaviorConfiguration="ClientCredBehavior"   
          name="WSHttpBinding_IServiceExample">  
          <identity>  
            <userPrincipalName value="name@corp.contoso.com"/>  
          </identity>  
        </endpoint>  
        ```  
  
    2.  Run the self-hosted service under the System or NetworkService account. You can run this command to create a command window under the System account:  
  
        ```console
        at 12:36 /interactive "cmd.exe"  
        ```  
  
    3.  Host the service under Internet Information Services (IIS), which, by default, uses the service principal name (SPN) account.  
  
    4.  Register a new SPN with the domain using SetSPN. Note that you will need to be a domain administrator in order to do this.  
  
 [!INCLUDE[crabout](../../../includes/crabout-md.md)] the Kerberos protocol, see [Security Concepts Used in WCF](../../../docs/framework/wcf/feature-details/security-concepts-used-in-wcf.md) and:  
  
-   [Debugging Windows Authentication Errors](../../../docs/framework/wcf/feature-details/debugging-windows-authentication-errors.md)  
  
-   [Registering Kerberos Service Principal Names by Using Http.sys](http://go.microsoft.com/fwlink/?LinkId=86943)  
  
-   [Kerberos Explained](http://go.microsoft.com/fwlink/?LinkId=86946)  
  
<a name="BKMK_q5"></a>   
## When I throw a FaultException\<Exception> where the type is an exception, I always receive a general FaultException type on the client and not the generic type. What’s happening?  
 It is highly recommended that you create your own custom error data type and declare that as the detail type in your fault contract. The reason is that using system-provided exception types:  
  
-   Creates a type dependency that removes one of the biggest strengths of service-oriented applications.  
  
-   Cannot depend upon exceptions serializing in a standard way. Some—like <xref:System.Security.SecurityException>—may not be serializable at all.  
  
-   Exposes internal implementation details to clients. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Specifying and Handling Faults in Contracts and Services](../../../docs/framework/wcf/specifying-and-handling-faults-in-contracts-and-services.md).  
  
 If you are debugging an application, however, you can serialize exception information and return it to the client by using the <xref:System.ServiceModel.Description.ServiceDebugBehavior> class.  
  
<a name="BKMK_q6"></a>   
## It seems like one-way and request-reply operations return at roughly the same speed when the reply contains no data. What's happening?  
 Specifying that an operation is one way means only that the operation contract accepts an input message and does not return an output message. In [!INCLUDE[indigo2](../../../includes/indigo2-md.md)], all client invocations return when the outbound data has been written to the wire or an exception is thrown. One-way operations work the same way, and they can throw if the service cannot be located or block if the service is not prepared to accept the data from the network. Typically in [!INCLUDE[indigo2](../../../includes/indigo2-md.md)], this results in one-way calls returning to the client more quickly than request-reply; but any condition that slows the sending of the outbound data over the network slows one-way operations as well as request-reply operations. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [One-Way Services](../../../docs/framework/wcf/feature-details/one-way-services.md) and [Accessing Services Using a WCF Client](../../../docs/framework/wcf/feature-details/accessing-services-using-a-client.md).  
  
<a name="BKMK_q77"></a>   
## I’m using an X.509 certificate with my service and I get a System.Security.Cryptography.CryptographicException. What’s happening?  
 This commonly occurs after changing the user account under which the IIS worker process runs. For example, in [!INCLUDE[wxp](../../../includes/wxp-md.md)], if you change the default user account that the Aspnet_wp.exe runs under from ASPNET to a custom user account, you may see this error. If using a private key, the process that uses it will need to have permissions to access the file storing that key.  
  
 If this is the case, you must give read access privileges to the process's account for the file containing the private key. For example, if the IIS worker process is running under the Bob account, then you will need to give Bob read access to the file containing the private key.  
  
 [!INCLUDE[crabout](../../../includes/crabout-md.md)] how to give the correct user account access to the file that contains the private key for a specific X.509 certificate, see [How to: Make X.509 Certificates Accessible to WCF](../../../docs/framework/wcf/feature-details/how-to-make-x-509-certificates-accessible-to-wcf.md).  
  
<a name="BKMK_q88"></a>   
## I changed the first parameter of an operation from uppercase to lowercase; now my client throws an exception. What's happening?  
 The value of the parameter names in the operation signature are part of the contract and are case-sensitive. Use the <xref:System.ServiceModel.MessageParameterAttribute?displayProperty=nameWithType> attribute when you need to distinguish between the local parameter name and the metadata that describes the operation for client applications.  
  
<a name="BKMK_q99"></a>   
## I’m using one of my tracing tools and I get an EndpointNotFoundException. What’s happening?  
 If you are using a tracing tool that is not the system-provided [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] tracing mechanism and you receive an <xref:System.ServiceModel.EndpointNotFoundException> that indicates that there was an address filter mismatch, you need to use the <xref:System.ServiceModel.Description.ClientViaBehavior> class to direct the messages to the tracing utility and have the utility redirect those messages to the service address. The <xref:System.ServiceModel.Description.ClientViaBehavior> class alters the `Via` addressing header to specify the next network address separately from the ultimate receiver, indicated by the `To` addressing header. When doing this, however, do not change the endpoint address, which is used to establish the `To` value.  
  
 The following code example shows an example client configuration file.  
  
```xml
<endpoint   
  address=http://localhost:8000/MyServer/  
  binding="wsHttpBinding"  
  bindingConfiguration="WSHttpBinding_IMyContract"  
  behaviorConfiguration="MyClient"   
  contract="IMyContract"   
  name="WSHttpBinding_IMyContract">  
</endpoint>  
<behaviors>  
  <endpointBehaviors>  
    <behavior name="MyClient">  
      <clientVia viaUri="http://localhost:8001/MyServer/"/>  
    </behavior>  
  </endpointBehaviors>  
</behaviors>  
```  
  
<a name="BKMK_q10"></a>   
## What is the base address? How does it relate to an endpoint address?  
 A base address is the root address for a <xref:System.ServiceModel.ServiceHost> class. By default, if you add a <xref:System.ServiceModel.Description.ServiceMetadataBehavior> class into your service configuration, the Web Services Description Language (WSDL) for all endpoints the host publishes are retrieved from the HTTP base address, plus any relative address provided to the metadata behavior, plus "?wsdl". If you are familiar with [!INCLUDE[vstecasp](../../../includes/vstecasp-md.md)] and IIS, the base address is equivalent to the virtual directory.  
  
## Sharing a port between a service endpoint and a mex endpoint using the NetTcpBinding  
 If you specify the base address for a service as net.tcp://MyServer:8080/MyService and add the following endpoints:  
  
```xml  
<services>  
  <service name="Microsoft.Samples.NetTcp.CalculatorService">  
    <endpoint address="calcsvc" binding ="netTcpBinding" contract="Microsoft.Samples.NetTcp.ICalculator"/>  
    <endpoint address="mex" binding="mexTcpBinding" contract="IMetadataExchange" />  
  </service>  
</services>  
```  
  
 And if you modify one of the NetTcpBinding settings as shown in the following configuration snippet:  
  
```xml  
<bindings>  
  <netTcpBinding>  
    <binding closeTimeout="00:01:00" openTimeout="00:01:00" receiveTimeout="00:10:00" sendTimeout="00:01:00" transactionFlow="false" transferMode="Buffered" transactionProtocol="OleTransactions" hostNameComparisonMode="StrongWildcard" listenBacklog="10" maxBufferPoolSize="524288" maxBufferSize="65536" maxConnections="11" maxReceivedMessageSize="65536">  
      <readerQuotas maxDepth="32" maxStringContentLength="8192" maxArrayLength="16384" maxBytesPerRead="4096" maxNameTableCharCount="16384"/>  
      <reliableSession ordered="true" inactivityTimeout="00:10:00" enabled="false"/>  
      <security mode="Transport">  
        <transport clientCredentialType="Windows" protectionLevel="EncryptAndSign"/>  
      </security>  
    </binding>  
  </netTcpBinding>  
</bindings>  
```  
  
 You will see an error like the following: Unhandled Exception: System.ServiceModel.AddressAlreadyInUseException: There is already a listener on IP endpoint 0.0.0.0:9000 You can work around this error by specifying a fully qualified URL with a different port for the MEX endpoint as shown in the following configuration snippet:  
  
```xml
<services>  
  <service name="Microsoft.Samples.NetTcp.CalculatorService">  
    <endpoint address="calcsvc" binding ="netTcpBinding" contract="Microsoft.Samples.NetTcp.ICalculator"/>  
    <endpoint address="net.tcp://localhost:9001/servicemodelsamples/mex" binding="mexTcpBinding" contract="IMetadataExchange" />  
  </service>  
</services>  
```  
  
<a name="BK_MK99"></a>   
## When calling a WCF Web HTTP application from a WCF SOAP application the service returns the following error: 405 Method Not Allowed  
 Calling a WCF Web HTTP application (a service that uses the <xref:System.ServiceModel.WebHttpBinding> and <xref:System.ServiceModel.Description.WebHttpBehavior>) from a WCF service may generate the following exception: `Unhandled Exception: System.ServiceModel.FaultException`1[System.ServiceModel.ExceptionDetail]: The remote server returned an unexpected response: (405) Method Not Allowed.` This exception occurs because WCF overwrites the outgoing <xref:System.ServiceModel.OperationContext> with the incoming <xref:System.ServiceModel.OperationContext>. To solve this problem create an <xref:System.ServiceModel.OperationContextScope> within the WCF Web HTTP service operation. For example:  
  
```csharp
public string Echo(string input)  
{  
    using (new OperationContextScope(this.InnerChannel))  
    {  
        return base.Channel.Echo(input);  
    }  
}  
```  
  
## See Also  
 [Debugging Windows Authentication Errors](../../../docs/framework/wcf/feature-details/debugging-windows-authentication-errors.md)
