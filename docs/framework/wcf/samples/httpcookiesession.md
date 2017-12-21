---
title: "HttpCookieSession"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 101cb624-8303-448a-a3af-933247c1e109
caps.latest.revision: 31
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# HttpCookieSession
This sample demonstrates how to build a custom protocol channel to use HTTP cookies for session management. This channel enables communication between [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] services and ASMX clients or between [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] clients and ASMX services.  
  
 When a client calls a Web method in an ASMX Web service that is session-based, the [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] engine does the following:  
  
-   Generates a unique ID (session ID).  
  
-   Generates the session object and associates it with the unique ID.  
  
-   Adds the unique ID to a Set-Cookie HTTP response header and sends it to the client.  
  
-   Identifies the client on subsequent calls based on the session ID it sends to it.  
  
 The client includes this session ID in its subsequent requests to the server. The server uses the session ID from the client to load the appropriate session object for the current HTTP context.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Extensibility\Channels\HttpCookieSession`  
  
## HttpCookieSession Channel Message Exchange Pattern  
 This sample enables sessions for ASMX-like scenarios. At the bottom of our channel stack, we have the HTTP transport that supports <xref:System.ServiceModel.Channels.IRequestChannel> and <xref:System.ServiceModel.Channels.IReplyChannel>. It is the job of the channel to provide sessions to the higher levels of the channel stack. The sample implements two channels, (<xref:System.ServiceModel.Channels.IRequestSessionChannel> and <xref:System.ServiceModel.Channels.IReplySessionChannel>) that support sessions.  
  
## Service Channel  
 The sample provides a service channel in the `HttpCookieReplySessionChannelListener` class. This class implements the <xref:System.ServiceModel.Channels.IChannelListener> interface and converts the <xref:System.ServiceModel.Channels.IReplyChannel> channel from lower in the channel stack to a <xref:System.ServiceModel.Channels.IReplySessionChannel>. This process can be divided into the following parts:  
  
-   When the channel listener is opened, it accepts an inner channel from its inner listener. Because the inner listener is a datagram listener and the lifetime of an accepted channel is decoupled from the lifetime of the listener, we can close the inner listener and only hold on to the inner channel  
  
    ```  
                this.innerChannelListener.Open(timeoutHelper.RemainingTime());  
    this.innerChannel = this.innerChannelListener.AcceptChannel(timeoutHelper.RemainingTime());  
    this.innerChannel.Open(timeoutHelper.RemainingTime());  
    this.innerChannelListener.Close(timeoutHelper.RemainingTime());  
    ```  
  
-   When the open process completes, we set up a message loop to receive messages from the inner channel.  
  
    ```  
    IAsyncResult result = BeginInnerReceiveRequest();  
    if (result != null && result.CompletedSynchronously)  
    {  
       // do not block the user thread  
       if (this.completeReceiveCallback == null)  
       {  
          this.completeReceiveCallback = new WaitCallback(CompleteReceiveCallback);  
       }  
       ThreadPool.QueueUserWorkItem(this.completeReceiveCallback, result);  
    }  
    ```  
  
-   When a message arrives, the service channel examines the session identifier and de-multiplexes to the appropriate session channel. The channel listener maintains a dictionary that maps the session identifiers to the session channel instances.  
  
    ```  
    Dictionary<string, IReplySessionChannel> channelMapping;  
    ```  
  
 The `HttpCookieReplySessionChannel` class implements <xref:System.ServiceModel.Channels.IReplySessionChannel>. Higher levels of the channel stack call the <xref:System.ServiceModel.Channels.IReplyChannel.ReceiveRequest%2A> method to read requests for this session. Each session channel has a private message queue that is populated by the service channel.  
  
```  
InputQueue<RequestContext> requestQueue;  
```  
  
 In the case when someone calls the <xref:System.ServiceModel.Channels.IReplyChannel.ReceiveRequest%2A> method and there are no messages in the message queue, the channel waits for a specified amount of time before shutting itself down. This cleans up the session channels created for non-[!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] clients.  
  
 We use the `channelMapping` to track the `ReplySessionChannels`, and we do not close our underlying `innerChannel` until all the accepted channels have been closed. This way `HttpCookieReplySessionChannel` can exist beyond the lifetime of `HttpCookieReplySessionChannelListener`. We also do not have to worry about the listener getting garbage collected underneath us because the accepted channels keep a reference to their listener through the `OnClosed` callback.  
  
## Client channel  
 The corresponding client channel is in the `HttpCookieSessionChannelFactory` class. During channel creation, the channel factory wraps the inner request channel with an `HttpCookieRequestSessionChannel`. The `HttpCookieRequestSessionChannel` class forwards the calls to the underlying request channel. When the client closes the proxy, `HttpCookieRequestSessionChannel` sends a message to the service that indicates that the channel is being closed. Thus, the service channel stack can gracefully shutdown the session channel that is in use.  
  
## Binding and Binding Element  
 After creating the service and client channels, the next step is to integrate them into the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] runtime. Channels are exposed to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] through bindings and binding elements. A binding consists of one or many binding elements. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] offers several system-defined bindings; for example, BasicHttpBinding or WSHttpBinding. The `HttpCookieSessionBindingElement` class contains the implementation for the binding element. It overrides the channel listener and channel factory creation methods to do the necessary channel listener or channel factory instantiations.  
  
 The sample uses policy assertions for the service description. This allows the sample to publish its channel requirements to other clients that can consume the service. For example, this binding element publishes policy assertions to let potential clients know that it supports sessions. Because the sample enables the `ExchangeTerminateMessage` property in the binding element configuration, it adds the necessary assertions to show that the service supports an extra message exchange action to terminate the session conversation. Clients can then use this action. The following WSDL code shows the policy assertions created from the `HttpCookieSessionBindingElement`.  
  
```xml  
<wsp:Policy wsu:Id="HttpCookieSessionBinding_IWcfCookieSessionService_policy" xmlns:wsp="http://schemas.xmlsoap.org/ws/2004/09/policy" xmlns:wsu="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd">  
<wsp:ExactlyOne>  
<wsp:All>  
<wspe:Utf816FFFECharacterEncoding xmlns:wspe="http://schemas.xmlsoap.org/ws/2004/09/policy/encoding"/>  
<mhsc:httpSessionCookie xmlns:mhsc="http://samples.microsoft.com/wcf/mhsc/policy"/>  
</wsp:All>  
</wsp:ExactlyOne>  
</wsp:Policy>  
```  
  
 The `HttpCookieSessionBinding` class is a system-provided binding that uses the binding element described previously.  
  
## Adding the Channel to the Configuration System  
 The sample provides two classes that expose the sample channel through configuration. The first is a <xref:System.ServiceModel.Configuration.BindingElementExtensionElement> for the `HttpCookieSessionBindingElement`. The bulk of the implementation is delegated to the `HttpCookieSessionBindingConfigurationElement`, which derives from <xref:System.ServiceModel.Configuration.StandardBindingElement>. The `HttpCookieSessionBindingConfigurationElement` has properties that correspond to the properties on `HttpCookieSessionBindingElement`.  
  
### Binding Element Extension Section  
 The section `HttpCookieSessionBindingElementSection` is a <xref:System.ServiceModel.Configuration.BindingElementExtensionElement> that exposes `HttpCookieSessionBindingElement` to the configuration system. With a few overrides the configuration section name, the type of the binding element and how to create the binding element are defined. We can then register the extension section in a configuration file as follows:  
  
```xml  
<configuration>        
    <system.serviceModel>        
      <extensions>          
        <bindingElementExtensions>            
          <add name="httpCookieSession"   
               type=  
"Microsoft.ServiceModel.Samples.HttpCookieSessionBindingElementElement,   
                    HttpCookieSessionExtension, Version=1.0.0.0,   
                    Culture=neutral, PublicKeyToken=null"/>  
        </bindingElementExtensions >  
      </extensions>  
  
      <bindings>  
      <customBinding>  
        <binding name="allowCookiesBinding">  
          <textMessageEncoding messageVersion="Soap11WSAddressing10" />  
          <httpCookieSession sessionTimeout="10" exchangeTerminateMessage="true" />  
          <httpTransport allowCookies="true" />  
        </binding>  
      </customBinding>  
      </bindings>        
    </system.serviceModel>    
</configuration>  
```  
  
## Test Code  
 Test code for using this sample transport is available in the Client and Service directories. It consists of two tests—one test uses a binding with `allowCookies` set to `true` on the client. The second test enables explicit shutdown (using the terminate message exchange) on the binding.  
  
 When you run the sample, you should see the following output:  
  
```  
Simple binding:  
AddItem(10000,2): ItemCount=2  
AddItem(10550,5): ItemCount=7  
RemoveItem(10550,2): ItemCount=5  
Items  
10000, 2  
10550, 3  
Smart binding:  
AddItem(10000,2): ItemCount=2  
AddItem(10550,5): ItemCount=7  
RemoveItem(10550,2): ItemCount=5  
Items  
10000, 2  
10550, 3  
  
Press <ENTER> to terminate client.  
```  
  
#### To set up, build, and run the sample  
  
1.  Install [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] 4.0 using the following command.  
  
    ```  
    %windir%\Microsoft.NET\Framework\v4.0.XXXXX\aspnet_regiis.exe /i /enable  
    ```  
  
2.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
3.  To build the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
4.  To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/running-the-samples.md).  
  
## See Also
