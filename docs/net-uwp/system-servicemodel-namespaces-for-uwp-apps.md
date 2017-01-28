---
title: "System.ServiceModel namespaces for UWP apps | Microsoft Docs"
ms.custom: ""
ms.date: "12/14/2016"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d2700a79-53e3-4079-8536-6a2e78f6061f
caps.latest.revision: 5
author: "msatranjr"
ms.author: "misatran"
manager: "markl"
---
# System.ServiceModel namespaces for UWP apps
`System.ServiceModel` and its child namespaces (`System.ServiceModel.Channels`, `System.ServiceModel.Description`, `System.ServiceModel.Dispatcher`, `System.ServiceModel.Security`, and `System.ServiceModel.Security.Tokens`) contain the types necessary to build Windows Communication Foundation (WCF) service and client applications.  
  
 This topic displays the types in the `System.ServiceModel` namespaces that are included in [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]. Note that [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)] does not include all the members of each type. For information about individual types, see the linked topics. The documentation for a type indicates which members are included in [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)].  
  
## System.ServiceModel namespace  
  
|Types supported in [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]|Description|  
|------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.ServiceModel.ActionNotSupportedException>|The exception that is thrown on the client when the action related to the operation invoked does not match any action of operations in the server.|  
|<xref:System.ServiceModel.BasicHttpBinding>|Represents a binding that a  service can use to configure and expose endpoints that are able to communicate with ASMX-based Web services and clients and other services that conform to the WS-I Basic Profile 1.1.|  
|<xref:System.ServiceModel.BasicHttpMessageCredentialType>|Enumerates credential types the client can authenticate with when security is enabled in the BasicHttpBinding binding.|  
|<xref:System.ServiceModel.BasicHttpSecurity>|Configures the security settings of a basicHttpBinding binding.|  
|<xref:System.ServiceModel.BasicHttpSecurityMode>|Specifies the types of security that can be used with the system-provided BasicHttpBinding.|  
|<xref:System.ServiceModel.CallbackBehaviorAttribute>|Configures a callback service implementation in a client application.|  
|<xref:System.ServiceModel.ChannelFactory>|Creates and manages the channels that are used by clients to send messages to service endpoints.|  
|<xref:System.ServiceModel.ChannelFactory%601>|A factory that creates channels of different types that are used by clients to send messages to variously configured service endpoints.|  
|<xref:System.ServiceModel.ClientBase%601>|Provides the base implementation used to create client objects that can call services.|  
|<xref:System.ServiceModel.ClientBase%601.BeginOperationDelegate>|A delegate that is used by InvokeAsync for calling asynchronous operations on the client.|  
|<xref:System.ServiceModel.ClientBase%601.ChannelBase%601>|Generic ChannelBase class.|  
|<xref:System.ServiceModel.ClientBase%601.EndOperationDelegate>|A delegate that is invoked by InvokeAsync on successful completion of the call made by InvokeAsync to BeginOperationDelegate.|  
|<xref:System.ServiceModel.CommunicationException>|Represents a communication error in either the service or client application.|  
|<xref:System.ServiceModel.CommunicationObjectAbortedException>|The exception that is thrown when the call is to an ICommunicationObject object that has aborted.|  
|<xref:System.ServiceModel.CommunicationObjectFaultedException>|The exception that is thrown when a call is made to a communication object that has faulted.|  
|<xref:System.ServiceModel.CommunicationState>|Defines the states in which an ICommunicationObject can exist.|  
|<xref:System.ServiceModel.DataContractFormatAttribute>|Instructs the infrastructure to use the DataContractSerializer.|  
|<xref:System.ServiceModel.DnsEndpointIdentity>|Specifies the DNS identity of the server.|  
|<xref:System.ServiceModel.DuplexChannelFactory%601>|Provides the means to create and manage duplex channels of different types that are used by clients to send and receive messages to and from service endpoints.|  
|<xref:System.ServiceModel.DuplexClientBase%601>|Used to create a channel to a duplex service and associate that channel with a callback object.|  
|<xref:System.ServiceModel.EndpointAddress>|Provides a unique network address that a client uses to communicate with a service endpoint.|  
|<xref:System.ServiceModel.EndpointAddressBuilder>|A factory for producing new (immutable) endpoint addresses with specific property values.|  
|<xref:System.ServiceModel.EndpointIdentity>|An abstract class that when implemented provides an identity that enables the authentication of an endpoint by clients that exchange messages with it.|  
|<xref:System.ServiceModel.EndpointNotFoundException>|The exception that is thrown when a remote endpoint could not be found or reached.|  
|<xref:System.ServiceModel.EnvelopeVersion>|Contains information related to the version of SOAP associated with a message and its exchange.|  
|<xref:System.ServiceModel.ExceptionDetail>|Represents fault detail information.|  
|<xref:System.ServiceModel.FaultCode>|Represents a SOAP fault code.|  
|<xref:System.ServiceModel.FaultContractAttribute>|Specifies one or more SOAP faults that are returned when a service operation encounters processing errors.|  
|<xref:System.ServiceModel.FaultException>|Represents a SOAP fault.|  
|<xref:System.ServiceModel.FaultException%601>|Used in a client application to catch contractually-specified SOAP faults.|  
|<xref:System.ServiceModel.FaultReason>|Provides a text description of a SOAP fault.|  
|<xref:System.ServiceModel.FaultReasonText>|Represents the text of the reason of a SOAP fault.|  
|<xref:System.ServiceModel.HttpBindingBase>|Specifies the base HTTP binding.|  
|<xref:System.ServiceModel.HttpClientCredentialType>|Enumerates the valid credential types for HTTP clients.|  
|<xref:System.ServiceModel.HttpTransportSecurity>|Represents the transport-level security settings for the WSHttpBinding.|  
|<xref:System.ServiceModel.IClientChannel>|Defines the behavior of outbound request and request/reply channels used by client applications.|  
|<xref:System.ServiceModel.ICommunicationObject>|Defines the contract for the basic state machine for all communication-oriented objects in the system, including channels, the channel managers, factories, listeners, and dispatchers, and service hosts.|  
|<xref:System.ServiceModel.IContextChannel>|Defines the interface for the context control of a channel.|  
|<xref:System.ServiceModel.IDefaultCommunicationTimeouts>|Defines the interface for specifying communication timeouts used by channels, channel managers such as channel listeners and channel factories, and service hosts.|  
|<xref:System.ServiceModel.IExtensibleObject%601>|Enable an object to participate in custom behavior, such as registering for events, or watching state transitions.|  
|<xref:System.ServiceModel.IExtension%601>|Enables an object to extend another object through aggregation.|  
|<xref:System.ServiceModel.IExtensionCollection%601>|A collection of the IExtension\<T> objects that allow for retrieving the IExtension\<T> by its type.|  
|<xref:System.ServiceModel.InstanceContext>|Represents the context information for a service instance.|  
|<xref:System.ServiceModel.InvalidMessageContractException>|Represents a message contract that is not valid.|  
|<xref:System.ServiceModel.MessageBodyMemberAttribute>|Specifies that a member is serialized as an element inside the SOAP body.|  
|<xref:System.ServiceModel.MessageContractAttribute>|Defines a strongly-typed class that corresponds to a SOAP message.|  
|<xref:System.ServiceModel.MessageContractMemberAttribute>|Declares the base members for MessageBodyMemberAttribute and MessageHeaderAttribute.|  
|<xref:System.ServiceModel.MessageCredentialType>|Enumerates the valid message credential types.|  
|<xref:System.ServiceModel.MessageHeader%601>|Represents the content of a SOAP header.|  
|<xref:System.ServiceModel.MessageHeaderException>|The exception that is thrown when the expectations regarding headers of a SOAP message are not satisfied when the message is processed.|  
|<xref:System.ServiceModel.MessageParameterAttribute>|Controls the name of the request and response parameter names. Cannot be used with Message or message contracts.|  
|<xref:System.ServiceModel.MessageSecurityOverTcp>|Configures the message-level security for a message sent using the TCP transport.|  
|<xref:System.ServiceModel.MessageSecurityVersion>|An abstract container class that, when implemented by several of its static properties, contains version information for security components.|  
|<xref:System.ServiceModel.NetHttpBinding>|Specifies settings for NetHttpBinding.|  
|<xref:System.ServiceModel.NetHttpMessageEncoding>|Specifies the Net Http message encoding.|  
|<xref:System.ServiceModel.NetTcpBinding>|A secure, reliable binding suitable for cross-machine communication.|  
|<xref:System.ServiceModel.NetTcpSecurity>|Specifies the types of transport-level and message-level security used by an endpoint configured with a NetTcpBinding.|  
|<xref:System.ServiceModel.OperationContext>|Provides access to the execution context of a service method.|  
|<xref:System.ServiceModel.OperationContextScope>|Creates a block within which an OperationContext object is in scope.|  
|<xref:System.ServiceModel.OperationContractAttribute>|Indicates that a method defines an operation that is part of a service contract in an application.|  
|<xref:System.ServiceModel.OperationFormatStyle>|Represents the SOAP style that determines how the WSDL metadata for the service is formatted.|  
|<xref:System.ServiceModel.ProtocolException>|The exception seen on the client that is thrown when communication with the remote party is impossible due to mismatched data transfer protocols.|  
|<xref:System.ServiceModel.QuotaExceededException>|The exception that is thrown when a message quota has been exceeded.|  
|<xref:System.ServiceModel.SecurityMode>|Determines the security settings for a binding.|  
|<xref:System.ServiceModel.ServerTooBusyException>|The exception that is thrown when a server is too busy to accept a message.|  
|<xref:System.ServiceModel.ServiceActivationException>|The exception that is thrown when a service fails to activate.|  
|<xref:System.ServiceModel.ServiceContractAttribute>|Indicates that an interface or a class defines a service contract in an application.|  
|<xref:System.ServiceModel.ServiceKnownTypeAttribute>|Specifies known types to be used by a service when serializing or deserializing.|  
|<xref:System.ServiceModel.SpnEndpointIdentity>|Represents a service principal name (SPN) for an identity when the binding uses Kerberos.|  
|<xref:System.ServiceModel.TcpClientCredentialType>|Enumerates the valid credential types for TCP clients.|  
|<xref:System.ServiceModel.TcpTransportSecurity>|Provides properties that control authentication parameters and protection level for the TCP transport.|  
|<xref:System.ServiceModel.TransferMode>|Indicates whether a channel uses streamed or buffered modes for the transfer of request and response messages.|  
|<xref:System.ServiceModel.UnknownMessageReceivedEventArgs>|Contains the message received by a channel and cannot be associated with any callback operation or pending request.|  
|<xref:System.ServiceModel.UpnEndpointIdentity>|Represents a user principal name (UPN) for an identity which is used when the binding utilizes the SSPINegotiate authentication mode.|  
|<xref:System.ServiceModel.XmlSerializerFormatAttribute>|Instructs the infrastructure to use the XmlSerializer instead of the XmlObjectSerializer.|  
  
## System.ServiceModel.Channels namespace  
  
|Types supported in the [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]|Description|  
|----------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.ServiceModel.Channels.AddressHeader>|Represents a header that encapsulates an address information item used to identify or interact with an endpoint.|  
|<xref:System.ServiceModel.Channels.AddressHeaderCollection>|Represents a thread-safe, read-only collection of address headers.|  
|<xref:System.ServiceModel.Channels.AddressingVersion>|The WS-Addressing version associated with a SOAP message or understood by an endpoint.|  
|<xref:System.ServiceModel.Channels.BinaryMessageEncodingBindingElement>|The binding element that specifies the .NET Binary Format for XML used to encode messages.|  
|<xref:System.ServiceModel.Channels.Binding>|Contains the binding elements that specify the protocols, transports, and message encoders used for communication between clients and services.|  
|<xref:System.ServiceModel.Channels.BindingContext>|Provides information about the addresses, bindings, binding elements and binding parameters required to build the channel listeners and channel factories.|  
|<xref:System.ServiceModel.Channels.BindingElement>|The elements of the bindings that build the channel factories and channel listeners for various types of channels that are used to process outgoing and incoming messages.|  
|<xref:System.ServiceModel.Channels.BindingElementCollection>|Represents the collection of binding elements used in a binding.|  
|<xref:System.ServiceModel.Channels.BindingParameterCollection>|Represents a collection of binding parameters that store information used by binding elements to build factories.|  
|<xref:System.ServiceModel.Channels.BodyWriter>|Represents the writer of the message body.|  
|<xref:System.ServiceModel.Channels.BufferManager>|Many  features require the use of buffers, which are expensive to create and destroy. You can use the BufferManager class to manage a buffer pool. The pool and its buffers are created when you instantiate this class and destroyed when the buffer pool is reclaimed by garbage collection. Every time you need to use a buffer, you take one from the pool, use it, and return it to the pool when done. This process is much faster than creating and destroying a buffer every time you need to use one.|  
|<xref:System.ServiceModel.Channels.ChannelBase>|Provides the base implementation for custom channels.|  
|<xref:System.ServiceModel.Channels.ChannelFactoryBase>|Provides a common base implementation for all custom channel factories.|  
|<xref:System.ServiceModel.Channels.ChannelFactoryBase%601>|Provides a common base implementation for channel factories on the client to create channels of a specified type connected to a specified address.|  
|<xref:System.ServiceModel.Channels.ChannelManagerBase>|Provides a base implementation for managing the default timeouts that are associated with channel and listener factories.|  
|<xref:System.ServiceModel.Channels.ChannelParameterCollection>|Represents a collection of channel parameters.|  
|<xref:System.ServiceModel.Channels.CommunicationObject>|Provides a common base implementation for the basic state machine common to all communication-oriented objects in the system, including channels, listeners, and the channel and listener factories.|  
|<xref:System.ServiceModel.Channels.CompressionFormat>|Specifies the channels compression format.|  
|<xref:System.ServiceModel.Channels.ConnectionOrientedTransportBindingElement>|An abstract class that supplements the base TransportBindingElement with additional properties that are common to connection-oriented transports such as TCP and named pipes.|  
|<xref:System.ServiceModel.Channels.CustomBinding>|Defines a binding from a list of binding elements.|  
|<xref:System.ServiceModel.Channels.FaultConverter>|Converts exceptions thrown by a channel into SOAP fault messages that conform to the channel's protocol.|  
|<xref:System.ServiceModel.Channels.HttpRequestMessageProperty>|Provides access to the HTTP request to access and respond to the additional information made available for requests over the HTTP protocol.|  
|<xref:System.ServiceModel.Channels.HttpResponseMessageProperty>|Provides access to the HTTP response in order to access and respond to the additional information made available for requests over the HTTP protocol.|  
|<xref:System.ServiceModel.Channels.HttpsTransportBindingElement>|Represents the binding element used to specify an HTTPS transport for transmitting messages.|  
|<xref:System.ServiceModel.Channels.HttpTransportBindingElement>|Represents the binding element used to specify an HTTP transport for transmitting messages.|  
|<xref:System.ServiceModel.Channels.IChannel>|Defines the basic interface that all channel objects must implement. It requires that they implement the state machine interface shared by all communication objects and that they implement a method to retrieve objects from the channel stack.|  
|<xref:System.ServiceModel.Channels.IChannelFactory>|Defines the interface that must be implemented by a channel factory to produce channels.|  
|<xref:System.ServiceModel.Channels.IChannelFactory%601>|Defines the interface that must be implemented by channel factories that create type-specific channels.|  
|<xref:System.ServiceModel.Channels.IDuplexChannel>|Defines the interface that a channel must implement to both send and receive messages.|  
|<xref:System.ServiceModel.Channels.IDuplexSession>|Defines the interface for the session implemented on each side of a bi-directional communication between messaging endpoints.|  
|<xref:System.ServiceModel.Channels.IDuplexSessionChannel>|Defines the interface that associates a duplex channel with a session.|  
|<xref:System.ServiceModel.Channels.IHttpCookieContainerManager>|Represents the cookie container manager.|  
|<xref:System.ServiceModel.Channels.IInputChannel>|Defines the interface that a channel must implement to receive a message.|  
|<xref:System.ServiceModel.Channels.IInputSession>|Defines the interface for the session implemented on the receiving side of a one-way communication between messaging endpoints.|  
|<xref:System.ServiceModel.Channels.IInputSessionChannel>|Defines the interface that associates an input channel with a session.|  
|<xref:System.ServiceModel.Channels.IMessageProperty>|Defines an interface that you can implement to describe a set of properties for a message.|  
|<xref:System.ServiceModel.Channels.IOutputChannel>|Defines the interface that a channel must implement to send a message.|  
|<xref:System.ServiceModel.Channels.IOutputSession>|Defines the interface for the session implemented on the sending side of a one-way communication between messaging endpoints.|  
|<xref:System.ServiceModel.Channels.IOutputSessionChannel>|Defines the interface that associates an output channel with a session.|  
|<xref:System.ServiceModel.Channels.IRequestChannel>|Defines the contract that a channel must implement to be on the requesting side of a request-reply communication between messaging endpoints.|  
|<xref:System.ServiceModel.Channels.IRequestSessionChannel>|Defines the interface to associate a request channel with a session.|  
|<xref:System.ServiceModel.Channels.ISession>|Defines the interface to establish a shared context among parties that exchange messages by providing an ID for the communication session.|  
|<xref:System.ServiceModel.Channels.ISessionChannel%601>|Defines the interface that associates a channel with a specific type of session.|  
|<xref:System.ServiceModel.Channels.LocalClientSecuritySettings>|Specifies local client security settings.|  
|<xref:System.ServiceModel.Channels.Message>|Represents the unit of communication between endpoints in a distributed environment.|  
|<xref:System.ServiceModel.Channels.MessageBuffer>|Represents a memory buffer that stores an entire message for future consumption.|  
|<xref:System.ServiceModel.Channels.MessageEncoder>|The encoder is the component that is used to write messages to a stream and to read messages from a stream.|  
|<xref:System.ServiceModel.Channels.MessageEncoderFactory>|An abstract base class that represents the factory for producing message encoders that can read messages from a stream and write them to a stream for various types of message encoding.|  
|<xref:System.ServiceModel.Channels.MessageEncodingBindingElement>|The binding element that specifies the message version used to encode messages.|  
|<xref:System.ServiceModel.Channels.MessageFault>|Represents an in-memory representation of a SOAP fault that can be passed to Message.CreateMessage to create a message that contains a fault.|  
|<xref:System.ServiceModel.Channels.MessageHeader>|Represents the content of a SOAP header.|  
|<xref:System.ServiceModel.Channels.MessageHeaderInfo>|Represents system information regarding a SOAP message header.|  
|<xref:System.ServiceModel.Channels.MessageHeaders>|Represents a collection of message headers for a message. This class cannot be inherited.|  
|<xref:System.ServiceModel.Channels.MessageProperties>|Represents a set of properties for a message. This class cannot be inherited.|  
|<xref:System.ServiceModel.Channels.MessageState>|Specifies the status of a message.|  
|<xref:System.ServiceModel.Channels.MessageVersion>|Specifies the versions of SOAP and WS-Addressing associated with a message and its exchange.|  
|<xref:System.ServiceModel.Channels.RequestContext>|Provides a reply that is correlated to an incoming request.|  
|<xref:System.ServiceModel.Channels.SecurityBindingElement>|An abstract class that, when implemented, represents a binding element that supports channel SOAP message security.|  
|<xref:System.ServiceModel.Channels.SecurityHeaderLayout>|Describes the layout of the security header.|  
|<xref:System.ServiceModel.Channels.SslStreamSecurityBindingElement>|Represents a custom binding element that supports channel security using an SSL stream.|  
|<xref:System.ServiceModel.Channels.TcpConnectionPoolSettings>|Represents properties that control the behavior of the TCP connection pool.|  
|<xref:System.ServiceModel.Channels.TcpTransportBindingElement>|Represents the binding element for the TCP transport.|  
|<xref:System.ServiceModel.Channels.TextMessageEncodingBindingElement>|The binding element that specifies the character encoding and message versioning used for text-based SOAP messages.|  
|<xref:System.ServiceModel.Channels.TransportBindingElement>|An abstract base class that represents a transport binding element.|  
|<xref:System.ServiceModel.Channels.TransportSecurityBindingElement>|Represents a custom binding element that supports mixed-mode security (such as, optimized message security over a secure transport).|  
|<xref:System.ServiceModel.Channels.WebSocketTransportSettings>|Represents settings for web socket transport.|  
|<xref:System.ServiceModel.Channels.WebSocketTransportUsage>|Specifies an enumeration of WebSocket transport usage.|  
|<xref:System.ServiceModel.Channels.WindowsStreamSecurityBindingElement>|Represents the binding element used to specify Windows stream security settings.|  
  
## System.ServiceModel.Description namespace  
  
|Types supported in the [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]|Description|  
|----------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.ServiceModel.Description.ClientCredentials>|Enables the user to configure client and service credentials as well as service credential authentication settings for use on the client side of communication.|  
|<xref:System.ServiceModel.Description.ContractDescription>|Describes a  contract that specifies what an endpoint communicates to the outside world.|  
|<xref:System.ServiceModel.Description.DataContractSerializerOperationBehavior>|Represents the run-time behavior of the DataContractSerializer.|  
|<xref:System.ServiceModel.Description.FaultDescription>|Represents a SOAP fault.|  
|<xref:System.ServiceModel.Description.FaultDescriptionCollection>|A collection of FaultDescription objects that you can use to obtain information about SOAP faults in a contract.|  
|<xref:System.ServiceModel.Description.IContractBehavior>|Implements methods that can be used to extend run-time behavior for a contract in either a service or client application.|  
|<xref:System.ServiceModel.Description.IEndpointBehavior>|Implements methods that can be used to extend run-time behavior for an endpoint in either a service or client application.|  
|<xref:System.ServiceModel.Description.IOperationBehavior>|Implements methods that can be used to extend run-time behavior for an operation in either a service or client application.|  
|<xref:System.ServiceModel.Description.MessageBodyDescription>|Represents the body of a SOAP message.|  
|<xref:System.ServiceModel.Description.MessageDescription>|Represents the description of a message.|  
|<xref:System.ServiceModel.Description.MessageDescriptionCollection>|Provides a collection that is used to store descriptions of the messages that make up an operation that belongs to a contract.|  
|<xref:System.ServiceModel.Description.MessageDirection>|Specifies the direction of the message.|  
|<xref:System.ServiceModel.Description.MessageHeaderDescription>|Represents a SOAP message header.|  
|<xref:System.ServiceModel.Description.MessageHeaderDescriptionCollection>|Represents a collection of MessageHeaderDescription objects.|  
|<xref:System.ServiceModel.Description.MessagePartDescription>|Represents a description of a SOAP message part.|  
|<xref:System.ServiceModel.Description.MessagePartDescriptionCollection>|Represents a collection of MessagePartDescription objects.|  
|<xref:System.ServiceModel.Description.MessagePropertyDescription>|Represents a message property specified by the MessagePropertyAttribute.|  
|<xref:System.ServiceModel.Description.MessagePropertyDescriptionCollection>|Represents a collection of MessagePropertyDescription objects.|  
|<xref:System.ServiceModel.Description.OperationDescription>|Represents the description of a contract operation that provides a description of the messages that make up the operation.|  
|<xref:System.ServiceModel.Description.OperationDescriptionCollection>|Represents a collection that contains operation descriptions.|  
|<xref:System.ServiceModel.Description.ServiceEndpoint>|Represents the endpoint for a service that allows clients of the service to find and communicate with the service.|  
  
## System.ServiceModel.Dispatcher namespace  
  
|Types supported in the [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]|Description|  
|----------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.ServiceModel.Dispatcher.ClientOperation>|Used to modify or extend the execution behavior of a specific contract operation in a client object or client channel object. This class cannot be inherited.|  
|<xref:System.ServiceModel.Dispatcher.ClientRuntime>|The insertion point for classes that extend the functionality of client objects for all messages handled by a client application.|  
|<xref:System.ServiceModel.Dispatcher.DispatchOperation>|Used to modify or extend the execution behavior of a specific service operation in a service endpoint. This class cannot be inherited.|  
|<xref:System.ServiceModel.Dispatcher.DispatchRuntime>|Exposes properties that can be used to modify default service behavior as well as attach custom objects that can modify how incoming messages are transformed into objects and dispatched to operations. This class cannot be inherited.|  
|<xref:System.ServiceModel.Dispatcher.EndpointDispatcher>|The run-time object that exposes properties that enable the insertion of run-time extensions or modifications for messages in service applications.|  
|<xref:System.ServiceModel.Dispatcher.IClientMessageFormatter>|Defines methods that are used to control the conversion of messages into objects and objects into messages for client applications.|  
|<xref:System.ServiceModel.Dispatcher.IClientMessageInspector>|Defines a message inspector object that can be added to the MessageInspectors collection to view or modify messages.|  
|<xref:System.ServiceModel.Dispatcher.IClientOperationSelector>|Defines the contract for an operation selector.|  
|<xref:System.ServiceModel.Dispatcher.IParameterInspector>|Defines the contract implemented by custom parameter inspectors that enables inspection or modification of information prior to and subsequent to calls on either the client or the service.|  
  
## System.ServiceModel.Security namespace  
  
|Types supported in the [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]|Description|  
|----------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.ServiceModel.Security.BasicSecurityProfileVersion>|Provides a message version that corresponds to the Basic Security Profile specification.|  
|<xref:System.ServiceModel.Security.HttpDigestClientCredential>|Used for digest authentication of HTTP clients.|  
|<xref:System.ServiceModel.Security.MessageSecurityException>|Represents an exception that occurred when there is something wrong with the security applied on a message.|  
|<xref:System.ServiceModel.Security.SecureConversationVersion>|Contains the set of supported WS-SecureConversation versions. This is an abstract class.|  
|<xref:System.ServiceModel.Security.SecurityAccessDeniedException>|Represents the security exception that is thrown when a security authorization request fails.|  
|<xref:System.ServiceModel.Security.SecurityPolicyVersion>|Contains the set of supported WS-SecurityPolicy versions. This is an abstract class.|  
|<xref:System.ServiceModel.Security.SecurityVersion>|Contains the set of supported WS-Security versions. This is an abstract class.|  
|<xref:System.ServiceModel.Security.TrustVersion>|Contains the set of supported WS-Trust versions. This is an abstract class.|  
|<xref:System.ServiceModel.Security.UserNamePasswordClientCredential>|Represents a client credential based on user name and password.|  
|<xref:System.ServiceModel.Security.WindowsClientCredential>|Allows you to specify properties related to Windows credentials to be used to represent the client.|  
  
## System.ServiceModel.Security.Tokens namespace  
  
|Types supported in the [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]|Description|  
|----------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.ServiceModel.Security.Tokens.SecureConversationSecurityTokenParameters>|Represents the parameters for a secure conversation security token.|  
|<xref:System.ServiceModel.Security.Tokens.SecurityTokenParameters>|An abstract class that when implemented represents security token parameters.|  
|<xref:System.ServiceModel.Security.Tokens.SupportingTokenParameters>|Represents the parameters for supporting security tokens required by the security binding element.|  
|<xref:System.ServiceModel.Security.Tokens.UserNameSecurityTokenParameters>|Represents the parameters for a user name security token.|  
  
## See Also  
 [.NET for Windows apps](../net-uwp/dotnet-for-windows-apps.md)