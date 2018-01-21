---
title: "Transport: UDP"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 738705de-ad3e-40e0-b363-90305bddb140
caps.latest.revision: 48
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Transport: UDP
The UDP Transport sample demonstrates how to implement UDP unicast and multicast as a custom [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] transport. The sample describes the recommended procedure for creating a custom transport in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], by using the channel framework and following [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] best practices. The steps to create a custom transport are as follows:  
  
1.  Decide which of the channel [Message Exchange Patterns](#MessageExchangePatterns) (IOutputChannel, IInputChannel, IDuplexChannel, IRequestChannel, or IReplyChannel) your ChannelFactory and ChannelListener will support. Then decide whether you will support the sessionful variations of these interfaces.  
  
2.  Create a channel factory and listener that support your Message Exchange Pattern.  
  
3.  Ensure that any network-specific exceptions are normalized to the appropriate derived class of <xref:System.ServiceModel.CommunicationException>.  
  
4.  Add a [\<binding>](../../../../docs/framework/misc/binding.md) element that adds the custom transport to a channel stack. For more information, see [Adding a Binding Element](#AddingABindingElement).  
  
5.  Add a binding element extension section to expose the new binding element to the configuration system.  
  
6.  Add metadata extensions to communicate capabilities to other endpoints.  
  
7.  Add a binding that pre-configures a stack of binding elements according to a well-defined profile. For more information, see [Adding a Standard Binding](#AddingAStandardBinding).  
  
8.  Add a binding section and binding configuration element to expose the binding to the configuration system. For more information, see [Adding Configuration Support](#AddingConfigurationSupport).  
  
<a name="MessageExchangePatterns"></a>   
## Message Exchange Patterns  
 The first step in writing a custom transport is to decide which Message Exchange Patterns (MEPs) are required for the transport. There are three MEPs to choose from:  
  
-   Datagram (IInputChannel/IOutputChannel)  
  
     When using a datagram MEP, a client sends a message using a "fire and forget" exchange. A fire and forget exchange is one that requires out-of-band confirmation of successful delivery. The message might be lost in transit and never reach the service. If the send operation completes successfully at the client end, it does not guarantee that the remote endpoint has received the message. The datagram is a fundamental building block for messaging, as you can build your own protocols on top of it—including reliable protocols and secure protocols. Client datagram channels implement the <xref:System.ServiceModel.Channels.IOutputChannel> interface and service datagram channels implement the <xref:System.ServiceModel.Channels.IInputChannel> interface.  
  
-   Request-Response (IRequestChannel/IReplyChannel)  
  
     In this MEP, a message is sent, and a reply is received. The pattern consists of request-response pairs. Examples of request-response calls are remote procedure calls (RPC) and browser GETs. This pattern is also known as Half-Duplex. In this MEP, client channels implement <xref:System.ServiceModel.Channels.IRequestChannel> and service channels implement <xref:System.ServiceModel.Channels.IReplyChannel>.  
  
-   Duplex (IDuplexChannel)  
  
     The duplex MEP allows an arbitrary number of messages to be sent by a client and received in any order. The duplex MEP is like a phone conversation, where each word being spoken is a message. Because both sides can send and receive in this MEP, the interface implemented by the client and service channels is <xref:System.ServiceModel.Channels.IDuplexChannel>.  
  
 Each of these MEPs can also support sessions. The added functionality provided by a session-aware channel is that it correlates all messages sent and received on a channel. The Request-Response pattern is a stand-alone two-message session, as the request and reply are correlated. In contrast, the Request-Response pattern that supports sessions implies that all request/response pairs on that channel are correlated with each other. This gives you a total of six MEPs—Datagram, Request-Response, Duplex, Datagram with sessions, Request-Response with sessions, and Duplex with sessions—to choose from.  
  
> [!NOTE]
>  For the UDP transport, the only MEP that is supported is Datagram, because UDP is inherently a "fire and forget" protocol.  
  
### The ICommunicationObject and the WCF object lifecycle  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] has a common state machine that is used for managing the lifecycle of objects like <xref:System.ServiceModel.Channels.IChannel>, <xref:System.ServiceModel.Channels.IChannelFactory>, and <xref:System.ServiceModel.Channels.IChannelListener> that are used for communication. There are five states in which these communication objects can exist. These states are represented by the <xref:System.ServiceModel.CommunicationState> enumeration, and are as follows:  
  
-   Created: This is the state of a <xref:System.ServiceModel.ICommunicationObject> when it is first instantiated. No input/output (I/O) occurs in this state.  
  
-   Opening: Objects transition to this state when <xref:System.ServiceModel.ICommunicationObject.Open%2A> is called. At this point properties are made immutable, and input/output can begin. This transition is valid only from the Created state.  
  
-   Opened: Objects transition to this state when the open process completes. This transition is valid only from the Opening state. At this point, the object is fully usable for transfer.  
  
-   Closing: Objects transition to this state when <xref:System.ServiceModel.ICommunicationObject.Close%2A> is called for a graceful shutdown. This transition is valid only from the Opened state.  
  
-   Closed: In the Closed state objects are no longer usable. In general, most configuration is still accessible for inspection, but no communication can occur. This state is equivalent to being disposed.  
  
-   Faulted: In the Faulted state, objects are accessible to inspection but no longer usable. When a non-recoverable error occurs, the object transitions into this state. The only valid transition from this state is into the `Closed` state.  
  
 There are events that fire for each state transition. The <xref:System.ServiceModel.ICommunicationObject.Abort%2A> method can be called at any time, and causes the object to transition immediately from its current state into the Closed state. Calling <xref:System.ServiceModel.ICommunicationObject.Abort%2A> terminates any unfinished work.  
  
<a name="ChannelAndChannelListener"></a>   
## Channel Factory and Channel Listener  
 The next step in writing a custom transport is to create an implementation of <xref:System.ServiceModel.Channels.IChannelFactory> for client channels and of <xref:System.ServiceModel.Channels.IChannelListener> for service channels. The channel layer uses a factory pattern for constructing channels. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides base class helpers for this process.  
  
-   The <xref:System.ServiceModel.Channels.CommunicationObject> class implements <xref:System.ServiceModel.ICommunicationObject> and enforces the state machine previously described in Step 2. 

-   The``<xref:System.ServiceModel.Channels.ChannelManagerBase> class implements <xref:System.ServiceModel.Channels.CommunicationObject> and provides a unified base class for <xref:System.ServiceModel.Channels.ChannelFactoryBase> and <xref:System.ServiceModel.Channels.ChannelListenerBase>. The <xref:System.ServiceModel.Channels.ChannelManagerBase> class works in conjunction with <xref:System.ServiceModel.Channels.ChannelBase>, which is a base class that implements <xref:System.ServiceModel.Channels.IChannel>.  
  
-   The``<xref:System.ServiceModel.Channels.ChannelFactoryBase> class implements <xref:System.ServiceModel.Channels.ChannelManagerBase> and <xref:System.ServiceModel.Channels.IChannelFactory> and consolidates the `CreateChannel` overloads into one `OnCreateChannel` abstract method.  
  
-   The <xref:System.ServiceModel.Channels.ChannelListenerBase> class implements <xref:System.ServiceModel.Channels.IChannelListener>. It takes care of basic state management.  
  
 In this sample, the factory implementation is contained in UdpChannelFactory.cs and the listener implementation is contained in UdpChannelListener.cs. The <xref:System.ServiceModel.Channels.IChannel> implementations are in UdpOutputChannel.cs and UdpInputChannel.cs.  
  
### The UDP Channel Factory  
 The `UdpChannelFactory` derives from <xref:System.ServiceModel.Channels.ChannelFactoryBase>. The sample overrides <xref:System.ServiceModel.Channels.ChannelFactoryBase.GetProperty%2A> to provide access to the message version of the message encoder. The sample also overrides <xref:System.ServiceModel.Channels.ChannelFactoryBase.OnClose%2A> so that we can tear down our instance of <xref:System.ServiceModel.Channels.BufferManager> when the state machine transitions.  
  
#### The UDP Output Channel  
 The `UdpOutputChannel` implements <xref:System.ServiceModel.Channels.IOutputChannel>. The constructor validates the arguments and constructs a destination <xref:System.Net.EndPoint> object based on the <xref:System.ServiceModel.EndpointAddress> that is passed in.  
  
```csharp
this.socket = new Socket(this.remoteEndPoint.AddressFamily, SocketType.Dgram, ProtocolType.Udp);  
```  
  
 The channel can be closed gracefully or ungracefully. If the channel is closed gracefully the socket is closed and a call is made to the base class `OnClose` method. If this throws an exception, the infrastructure calls `Abort` to ensure the channel is cleaned up.  
  
```csharp
this.socket.Close(0);  
```  
  
 We then implement `Send()` and `BeginSend()`/`EndSend()`. This breaks down into two main sections. First we serialize the message into a byte array.  
  
```csharp
ArraySegment<byte> messageBuffer = EncodeMessage(message);  
```  
  
 Then we send the resulting data on the wire.  
  
```csharp
this.socket.SendTo(messageBuffer.Array, messageBuffer.Offset, messageBuffer.Count, SocketFlags.None, this.remoteEndPoint);  
```  
  
### The UdpChannelListener  
 The``UdpChannelListener that the sample implements derives from the <xref:System.ServiceModel.Channels.ChannelListenerBase> class. It uses a single UDP socket to receive datagrams. The `OnOpen` method receives data using the UDP socket in an asynchronous loop. The data are then converted into messages using the Message Encoding Framework.  
  
```csharp
message = MessageEncoderFactory.Encoder.ReadMessage(new ArraySegment<byte>(buffer, 0, count), bufferManager);  
```  
  
 Because the same datagram channel represents messages that arrive from a number of sources, the `UdpChannelListener` is a singleton listener. There is, at most, one active <xref:System.ServiceModel.Channels.IChannel>``associated with this listener at a time. The sample generates another one only if a channel that is returned by the `AcceptChannel` method is subsequently disposed. When a message is received, it is enqueued into this singleton channel.  
  
#### UdpInputChannel  
 The `UdpInputChannel` class implements `IInputChannel`. It consists of a queue of incoming messages that is populated by the `UdpChannelListener`'s socket. These messages are dequeued by the `IInputChannel.Receive` method.  
  
<a name="AddingABindingElement"></a>   
## Adding a Binding Element  
 Now that the factories and channels are built, we must expose them to the ServiceModel runtime through a binding. A binding is a collection of binding elements that represents the communication stack associated with a service address. Each element in the stack is represented by a [\<binding>](../../../../docs/framework/misc/binding.md) element.  
  
 In the sample, the binding element is `UdpTransportBindingElement`, which derives from <xref:System.ServiceModel.Channels.TransportBindingElement>. It overrides the following methods to build the factories associated with our binding.  
  
```csharp
public IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)  
{  
    return (IChannelFactory<TChannel>)(object)new UdpChannelFactory(this, context);  
}  
  
public IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)  
{  
    return (IChannelListener<TChannel>)(object)new UdpChannelListener(this, context);  
}  
```  
  
 It also contains members for cloning the `BindingElement` and returning our scheme (soap.udp).  
  
## Adding Metadata Support for a Transport Binding Element  
 To integrate our transport into the metadata system, we must support both the import and export of policy. This allows us to generate clients of our binding through the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md).  
  
### Adding WSDL Support  
 The transport binding element in a binding is responsible for exporting and importing addressing information in metadata. When using a SOAP binding, the transport binding element should also export a correct transport URI in metadata.  
  
#### WSDL Export  
 To export addressing information the `UdpTransportBindingElement` implements the `IWsdlExportExtension` interface. The `ExportEndpoint` method adds the correct addressing information to the WSDL port.  
  
```csharp
if (context.WsdlPort != null)  
{  
    AddAddressToWsdlPort(context.WsdlPort, context.Endpoint.Address, encodingBindingElement.MessageVersion.Addressing);  
}  
```  
  
 The `UdpTransportBindingElement` implementation of the `ExportEndpoint` method also exports a transport URI when the endpoint uses a SOAP binding.  
  
```csharp
WsdlNS.SoapBinding soapBinding = GetSoapBinding(context, exporter);  
if (soapBinding != null)  
{  
    soapBinding.Transport = UdpPolicyStrings.UdpNamespace;  
}  
```  
  
#### WSDL Import  
 To extend the WSDL import system to handle importing the addresses, we must add the following configuration to the configuration file for Svcutil.exe as shown in the Svcutil.exe.config file.  
  
```xml
<configuration>  
  <system.serviceModel>  
    <client>  
      <metadata>  
        <wsdlImporters>  
          <extension type=" Microsoft.ServiceModel.Samples.UdpBindingElementImporter, UdpTransport" />  
        </policyImporters>  
      </metadata>  
    </client>  
  </system.serviceModel>  
</configuration>  
```  
  
 When running Svcutil.exe, there are two options for getting Svcutil.exe to load the WSDL import extensions:  
  
1.  Point Svcutil.exe to our configuration file using the /SvcutilConfig:\<file>.  
  
2.  Add the configuration section to Svcutil.exe.config in the same directory as Svcutil.exe.  
  
 The `UdpBindingElementImporter` type implements the `IWsdlImportExtension` interface. The `ImportEndpoint` method imports the address from the WSDL port.  
  
```csharp
BindingElementCollection bindingElements = context.Endpoint.Binding.CreateBindingElements();  
TransportBindingElement transportBindingElement = bindingElements.Find<TransportBindingElement>();  
if (transportBindingElement is UdpTransportBindingElement)  
{  
    ImportAddress(context);  
}  
```  
  
### Adding Policy Support  
 The custom binding element can export policy assertions in the WSDL binding for a service endpoint to express the capabilities of that binding element.  
  
#### Policy Export  
 The `UdpTransportBindingElement` type implements `IPolicyExportExtension` to add support for exporting policy. As a result, `System.ServiceModel.MetadataExporter` includes `UdpTransportBindingElement` in the generation of policy for any binding that includes it.  
  
 In `IPolicyExportExtension.ExportPolicy`, we add an assertion for UDP and another assertion if we are in multicast mode. This is because multicast mode affects how the communication stack is constructed, and thus must be coordinated between both sides.  
  
```csharp
ICollection<XmlElement> bindingAssertions = context.GetBindingAssertions();  
XmlDocument xmlDocument = new XmlDocument();  
bindingAssertions.Add(xmlDocument.CreateElement(  
UdpPolicyStrings.Prefix, UdpPolicyStrings.TransportAssertion, UdpPolicyStrings.UdpNamespace));  
if (Multicast)  
{  
    bindingAssertions.Add(xmlDocument.CreateElement(
        UdpPolicyStrings.Prefix, 
        UdpPolicyStrings.MulticastAssertion, 
        UdpPolicyStrings.UdpNamespace));  
}  
```  
  
 Because custom transport binding elements are responsible for handling addressing, the `IPolicyExportExtension` implementation on the `UdpTransportBindingElement` must also handle exporting the appropriate WS-Addressing policy assertions to indicate the version of WS-Addressing being used.  
  
```csharp
AddWSAddressingAssertion(context, encodingBindingElement.MessageVersion.Addressing);  
```  
  
#### Policy Import  
 To extend the Policy Import system, we must add the following configuration to the configuration file for Svcutil.exe as shown in the Svcutil.exe.config file.  
  
```xml
<configuration>  
  <system.serviceModel>  
    <client>  
      <metadata>  
        <policyImporters>  
          <extension type=" Microsoft.ServiceModel.Samples.UdpBindingElementImporter, UdpTransport" />  
        </policyImporters>  
      </metadata>  
    </client>  
  </system.serviceModel>  
</configuration>  
```  
  
 Then we implement `IPolicyImporterExtension` from our registered class (`UdpBindingElementImporter`). In `ImportPolicy()`, we look through the assertions in our namespace, and process the ones for generating the transport and check whether it is multicast. We also must remove the assertions we handle from the list of binding assertions. Again, when running Svcutil.exe, there are two options for integration:  
  
1.  Point Svcutil.exe to our configuration file using the /SvcutilConfig:\<file>.  
  
2.  Add the configuration section to Svcutil.exe.config in the same directory as Svcutil.exe.  
  
<a name="AddingAStandardBinding"></a>   
## Adding a Standard Binding  
 Our binding element can be used in the following two ways:  
  
-   Through a custom binding: A custom binding allows the user to create their own binding based on an arbitrary set of binding elements.  
  
-   By using a system-provided binding that includes our binding element. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides a number of these system-defined bindings, such as `BasicHttpBinding`, `NetTcpBinding`, and `WsHttpBinding`. Each of these bindings is associated with a well-defined profile.  
  
 The sample implements profile binding in `SampleProfileUdpBinding`, which derives from <xref:System.ServiceModel.Channels.Binding>. The `SampleProfileUdpBinding` contains up to four binding elements within it: `UdpTransportBindingElement`, `TextMessageEncodingBindingElement CompositeDuplexBindingElement`, and `ReliableSessionBindingElement`.  
  
```csharp
public override BindingElementCollection CreateBindingElements()  
{     
    BindingElementCollection bindingElements = new BindingElementCollection();  
    if (ReliableSessionEnabled)  
    {  
        bindingElements.Add(session);  
        bindingElements.Add(compositeDuplex);  
    }  
    bindingElements.Add(encoding);  
    bindingElements.Add(transport);  
    return bindingElements.Clone();  
}  
```  
  
### Adding a Custom Standard Binding Importer  
 Svcutil.exe and the `WsdlImporter` type, by default, recognizes and imports system-defined bindings. Otherwise, the binding gets imported as a `CustomBinding` instance. To enable Svcutil.exe and the `WsdlImporter` to import the `SampleProfileUdpBinding` the `UdpBindingElementImporter` also acts as a custom standard binding importer.  
  
 A custom standard binding importer implements the `ImportEndpoint` method on the `IWsdlImportExtension` interface to examine the `CustomBinding` instance imported from metadata to see whether it could have been generated by a specific standard binding.  
  
```csharp
if (context.Endpoint.Binding is CustomBinding)  
{  
    Binding binding;  
    if (transportBindingElement is UdpTransportBindingElement)  
    {  
        //if TryCreate is true, the CustomBinding will be replace by a SampleProfileUdpBinding in the  
        //generated config file for better typed generation.  
        if (SampleProfileUdpBinding.TryCreate(bindingElements, out binding))  
        {  
            binding.Name = context.Endpoint.Binding.Name;  
            binding.Namespace = context.Endpoint.Binding.Namespace;  
            context.Endpoint.Binding = binding;  
        }  
    }  
}  
```  
  
 Generally, implementing a custom standard binding importer involves checking the properties of the imported binding elements to verify that only properties that could have been set by the standard binding have changed and all other properties are their defaults. A basic strategy for implementing a standard binding importer is to create an instance of the standard binding, propagate the properties from the binding elements to the standard binding instance that the standard binding supports, and the compare the binding elements from the standard binding with the imported binding elements.  
  
<a name="AddingConfigurationSupport"></a>   
## Adding Configuration Support  
 To expose our transport through configuration, we must implement two configuration sections. The first is a `BindingElementExtensionElement` for `UdpTransportBindingElement`. This is so that `CustomBinding` implementations can reference our binding element. The second is a `Configuration` for our `SampleProfileUdpBinding`.  
  
### Binding Element Extension Element  
 The section `UdpTransportElement` is a `BindingElementExtensionElement` that exposes `UdpTransportBindingElement` to the configuration system. With a few basic overrides, we define our configuration section name, the type of our binding element and how to create our binding element. We can then register our extension section in a configuration file as shown in the following code.  
  
```xml
<configuration>  
  <system.serviceModel>  
    <extensions>  
      <bindingElementExtensions>  
        <add name="udpTransport" type="Microsoft.ServiceModel.Samples.UdpTransportElement, UdpTransport />  
      </bindingElementExtensions>  
    </extensions>  
  </system.serviceModel>  
</configuration>  
```  
  
 The extension can be referenced from custom bindings to use UDP as the transport.  
  
```xml
<configuration>  
  <system.serviceModel>  
    <bindings>  
      <customBinding>  
       <binding configurationName="UdpCustomBinding">  
         <udpTransport/>  
       </binding>  
      </customBinding>  
    </bindings>  
  </system.serviceModel>  
</configuration>  
```  
  
### Binding Section  
 The section `SampleProfileUdpBindingCollectionElement` is a `StandardBindingCollectionElement` that exposes `SampleProfileUdpBinding` to the configuration system. The bulk of the implementation is delegated to the `SampleProfileUdpBindingConfigurationElement`, which derives from `StandardBindingElement`. The `SampleProfileUdpBindingConfigurationElement` has properties that correspond to the properties on `SampleProfileUdpBinding`, and functions to map from the `ConfigurationElement` binding. Finally, override the `OnApplyConfiguration` method in our `SampleProfileUdpBinding`, as shown in the following sample code.  
  
```csharp
protected override void OnApplyConfiguration(string configurationName)  
{  
    if (binding == null)
        throw new ArgumentNullException("binding");

    if (binding.GetType() != typeof(SampleProfileUdpBinding))
    {
        throw new ArgumentException(string.Format(CultureInfo.CurrentCulture,
            "Invalid type for binding. Expected type: {0}. Type passed in: {1}.",
            typeof(SampleProfileUdpBinding).AssemblyQualifiedName,
            binding.GetType().AssemblyQualifiedName));
    }
    SampleProfileUdpBinding udpBinding = (SampleProfileUdpBinding)binding;

    udpBinding.OrderedSession = this.OrderedSession;
    udpBinding.ReliableSessionEnabled = this.ReliableSessionEnabled;
    udpBinding.SessionInactivityTimeout = this.SessionInactivityTimeout;
    if (this.ClientBaseAddress != null)
        udpBinding.ClientBaseAddress = ClientBaseAddress;
}
```  
  
 To register this handler with the configuration system, we add the following section to the relevant configuration file.  
  
```xml
<configuration>  
  <configSections>  
     <sectionGroup name="system.serviceModel">  
        <sectionGroup name="bindings">  
          <section name="sampleProfileUdpBinding" type="Microsoft.ServiceModel.Samples.SampleProfileUdpBindingCollectionElement, UdpTransport />  
        </sectionGroup>  
     </sectionGroup>  
  </configSections>  
</configuration>  
```  
  
 It can then be referenced from the serviceModel configuration section.  
  
```xml
<configuration>  
  <system.serviceModel>  
    <client>  
      <endpoint configurationName="calculator"  
                address="soap.udp://localhost:8001/"   
                bindingConfiguration="CalculatorServer"  
                binding="sampleProfileUdpBinding"   
                contract= "Microsoft.ServiceModel.Samples.ICalculatorContract">  
      </endpoint>  
    </client>  
  </system.serviceModel>  
</configuration>  
```  
  
## The UDP Test Service and Client  
 Test code for using this sample transport is available in the UdpTestService and UdpTestClient directories. The service code consists of two tests—one test sets up bindings and endpoints from code and the other does it through configuration. Both tests use two endpoints. One endpoint uses the `SampleUdpProfileBinding` with [\<reliableSession>](http://msdn.microsoft.com/library/9c93818a-7dfa-43d5-b3a1-1aafccf3a00b) set to `true`. The other endpoint uses a custom binding with `UdpTransportBindingElement`. This is equivalent to using `SampleUdpProfileBinding` with [\<reliableSession>](http://msdn.microsoft.com/library/9c93818a-7dfa-43d5-b3a1-1aafccf3a00b) set to `false`. Both tests create a service, add an endpoint for each binding, open the service and then wait for the user to hit ENTER before closing the service.  
  
 When you start the service test application you should see the following output.  
  
```console
Testing Udp From Code.  
Service is started from code...  
Press <ENTER> to terminate the service and start service from config...  
```  
  
 You can then run the test client application against the published endpoints. The client test application creates a client for each endpoint and sends five messages to each endpoint. The following output is on the client.  
  
```console
Testing Udp From Imported Files Generated By SvcUtil.  
0  
3  
6  
9  
12  
Press <ENTER> to complete test.  
```  
  
 The following is the full output on the service.  
  
```console
Service is started from code...  
Press <ENTER> to terminate the service and start service from config...  
Hello, world!  
Hello, world!  
Hello, world!  
Hello, world!  
Hello, world!  
   adding 0 + 0  
   adding 1 + 2  
   adding 2 + 4  
   adding 3 + 6  
   adding 4 + 8  
```  
  
 To run the client application against endpoints published using configuration, hit ENTER on the service and then run the test client again. You should see the following output on the service.  
  
```console
Testing Udp From Config.  
Service is started from config...  
Press <ENTER> to terminate the service and exit...  
```  
  
 Running the client again yields the same as the preceding results.  
  
 To regenerate the client code and configuration using Svcutil.exe, start the service application and then run the following Svcutil.exe from the root directory of the sample.  
  
```console
svcutil http://localhost:8000/udpsample/ /reference:UdpTranport\bin\UdpTransport.dll /svcutilConfig:svcutil.exe.config  
```  
  
 Note that Svcutil.exe does not generate the binding extension configuration for the `SampleProfileUdpBinding`, so you must add it manually.  
  
```xml
<configuration>  
  <system.serviceModel>      
    <extensions>  
      <!-- This was added manually because svcutil.exe does not add this extension to the file -->  
      <bindingExtensions>  
        <add name="sampleProfileUdpBinding" type="Microsoft.ServiceModel.Samples.SampleProfileUdpBindingCollectionElement, UdpTransport" />  
      </bindingExtensions>  
    </extensions>  
  </system.serviceModel>  
</configuration>  
```  
  
#### To set up, build, and run the sample  
  
1.  To build the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
2.  To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/running-the-samples.md).  
  
3.  Refer to the preceding "The UDP Test Service and Client" section.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Extensibility\Transport\Udp`
