---
title: "Custom Message Interceptor"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 73f20972-53f8-475a-8bfe-c133bfa225b0
caps.latest.revision: 24
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Custom Message Interceptor
This sample demonstrates the use of the channel extensibility model. In particular, it shows how to implement a custom binding element that creates channel factories and channel listeners to intercept all incoming and outgoing messages at a particular point in the run-time stack. The sample also includes a client and server that demonstrate the use of these custom factories.  
  
 In this sample, both the client and the service are console programs (.exe). The client and service both make use of a common library (.dll) that contains the custom binding element and its associated run-time objects.  
  
> [!NOTE]
>  The setup procedure and build instructions for this sample are located at the end of this topic.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Extensibility\Channels\MessageInterceptor`  
  
 The sample describes the recommended procedure for creating a custom layered channel in [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)], by using the channel framework and following [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] best practices. The steps to create a custom layered channel are as follows:  
  
1.  Decide which of the channel shapes your channel factory and channel listener will support.  
  
2.  Create a channel factory and a channel listener that support your channel shapes.  
  
3.  Add a binding element that adds the custom layered channel to a channel stack.  
  
4.  Add a binding element extension section to expose the new binding element to the configuration system.  
  
## Channel Shapes  
 The first step in writing a custom layered channel is to decide which shapes are required for the channel. For our message inspector, we support any shape that the layer below us supports (for example, if the layer below us can build <xref:System.ServiceModel.Channels.IOutputChannel> and <xref:System.ServiceModel.Channels.IDuplexSessionChannel>, then we also expose <xref:System.ServiceModel.Channels.IOutputChannel> and <xref:System.ServiceModel.Channels.IDuplexSessionChannel>).  
  
## Channel Factory and Listener Factory  
 The next step in writing a custom layered channel is to create an implementation of <xref:System.ServiceModel.Channels.IChannelFactory> for client channels and of <xref:System.ServiceModel.Channels.IChannelListener> for service channels.  
  
 These classes take an inner factory and listener, and delegate all but the `OnCreateChannel` and `OnAcceptChannel` calls to the inner factory and listener.  
  
```  
class InterceptingChannelFactory<TChannel> : ChannelFactoryBase<TChannel>  
{ ... }  
class InterceptingChannelListener<TChannel> : ListenerFactoryBase<TChannel>  
{ ... }  
```  
  
## Adding a Binding Element  
 The sample defines a custom binding element: `InterceptingBindingElement`. `InterceptingBindingElement` takes a `ChannelMessageInterceptor` as an input, and uses this `ChannelMessageInterceptor` to manipulate messages that pass through it. This is the only class that must be public. The factory, listener, and channels can all be internal implementations of the public run-time interfaces.  
  
```  
public class InterceptingBindingElement : BindingElement  
```  
  
## Adding Configuration Support  
 To integrate with binding configuration, the library defines a configuration section handler as a binding element extension section. The client and server configuration files must register the binding element extension with the configuration system. Implementers that want to expose their binding element to the configuration system can derive from this class.  
  
```  
public abstract class InterceptingElement : BindingElementExtensionElement { ... }  
```  
  
## Adding Policy  
 To integrate with our policy system, `InterceptingBindingElement` implements IPolicyExportExtension to signal that we should participate in generating policy. To support importing policy on a generated client, the user can register a derived class of `InterceptingBindingElementImporter` and override `CreateMessageInterceptor`() to generate their policy-enabled `ChannelMessageInterceptor` class.  
  
## Example: Droppable Message Inspector  
 Included in the sample is an example implementation of `ChannelMessageInspector` which drops messages.  
  
```  
class DroppingServerElement : InterceptingElement  
{  
    protected override ChannelMessageInterceptor CreateMessageInterceptor()  
    {  
        return new DroppingServerInterceptor();  
    }  
}  
```  
  
 You can access it from configuration as follows:  
  
```xml  
<configuration>  
    ...  
    <system.serviceModel>  
        ...  
        <extensions>  
            <bindingElementExtensions>  
                <add name="droppingInterceptor"   
                   type=  
          "Microsoft.ServiceModel.Samples.DroppingServerElement, library"/>  
            </bindingElementExtensions>  
        </extensions>  
    </system.serviceModel>  
</configuration>  
```  
  
 The client and server both use this newly created configuration section to insert the custom factories into the lowest-level of their run-time channel stacks (above the transport level).  
  
```xml  
<customBinding>  
  <binding name="sampleBinding">  
    <droppingInterceptor/>  
    <httpTransport/>  
  </binding>  
</customBinding>  
```  
  
 The client uses the `MessageInterceptor` library to add a custom header to even numbered messages. The service on the other hand uses `MessageInterceptor` library to drop any messages that do not have this special header.  
  
 You should see the following client output after running the service and then the client.  
  
```  
Reporting the next 10 wind speed  
100 kph  
Server dropped a message.  
90 kph  
80 kph  
Server dropped a message.  
70 kph  
60 kph  
Server dropped a message.  
50 kph  
40 kph  
Server dropped a message.  
30 kph  
20 kph  
Server dropped a message.  
10 kph  
Press ENTER to shut down client  
```  
  
 The client reports 10 different wind speeds to the service, but only tags half of them with the special header.  
  
 On the service, you should see the following output:  
  
```  
Press ENTER to exit.  
Dangerous wind detected! Reported speed (90) is greater than 64 kph.  
Dangerous wind detected! Reported speed (70) is greater than 64 kph.  
5 wind speed reports have been received.  
```  
  
#### To set up, build, and run the sample  
  
1.  Install [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] 4.0 using the following command.  
  
    ```  
    %windir%\Microsoft.NET\Framework\v4.0.XXXXX\aspnet_regiis.exe /i /enable  
    ```  
  
2.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
3.  To build the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
4.  To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/running-the-samples.md).  
  
5.  Run Service.exe first then run Client.exe and watch both console windows for output.  
  
## See Also
