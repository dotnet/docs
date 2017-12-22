---
title: "Migrating from .NET Remoting to WCF"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 16902a42-ef80-40e9-8c4c-90e61ddfdfe5
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Migrating from .NET Remoting to WCF
This article describes how to migrate an application that uses .NET Remoting to use Windows Communication Foundation (WCF). It compares similar concepts between these products and then describes how to accomplish several common Remoting scenarios in WCF.  
  
 .NET Remoting is a legacy product that is supported only for backward compatibility. It is not secure across mixed-trust environments because it cannot maintain the separate trust levels between client and server. For example, you should never expose a .NET Remoting endpoint to the Internet or to untrusted clients. We recommend existing Remoting applications be migrated to newer and more secure technologies. If the application’s design uses only HTTP and is RESTful, we recommend ASP.NET Web API. For more information, see ASP.NET Web API. If the application is based on SOAP or requires non-Http protocols such as TCP, we recommend WCF.  

## Comparing .NET Remoting to WCF  
 This section compares the basic building blocks of .NET Remoting with their WCF equivalents. We will use these building blocks later to create some common client-server scenarios in WCF.The following chart summarizes the main similarities and differences between .NET Remoting and WCF.  
  
||.NET Remoting|WCF|  
|-|-------------------|---------|  
|Server type|Subclass MarshalByRefObject|Mark with [ServiceContract] attribute|  
|Service operations|Public methods on server type|Mark with [OperationContract] attribute|  
|Serialization|ISerializable or [Serializable]|DataContractSerializer or XmlSerializer|  
|Objects passed|By-value or by-reference|By-value only|  
|Errors/exceptions|Any serializable exception|FaultContract\<TDetail>|  
|Client proxy objects|Strongly typed transparent proxies are created automatically from MarshalByRefObjects|Strongly typed proxies are generated on-demand using ChannelFactory\<TChannel>|  
|Platform required|Both client and server must use Microsoft OS and .NET|Cross-platform|  
|Message format|Private|Industry standards (SOAP, WS-*, etc.)|  
  
### Server Implementation Comparison  
  
#### Creating a Server in .NET Remoting  
 .NET Remoting server types must derive from MarshalByRefObject and define methods the client can call, like the following:  
  
```csharp
public class RemotingServer : MarshalByRefObject  
{  
    public Customer GetCustomer(int customerId) { … }  
}  
```  
  
 The public methods of this server type become the public contract available to clients.  There is no separation between the server’s public interface and its implementation – one type handles both.  
  
 Once the server type has been defined, it can be made available to clients, like in the following example:  
  
```csharp
TcpChannel channel = new TcpChannel(8080);  
ChannelServices.RegisterChannel(channel, ensureSecurity : true);  
RemotingConfiguration.RegisterWellKnownServiceType(  
    typeof(RemotingServer),   
    "RemotingServer",   
    WellKnownObjectMode.Singleton);  
Console.WriteLine("RemotingServer is running.  Press ENTER to terminate...");  
Console.ReadLine();  
```  
  
 There are many ways to make the Remoting type available as a server, including using configuration files. This is just one example.  
  
#### Creating a Server in WCF  
 The equivalent step in WCF involves creating two types -- the public "service contract" and the concrete implementation. The first is declared as an interface marked with [ServiceContract]. Methods available to clients are marked with [OperationContract]:  
  
```csharp
[ServiceContract]  
public interface IWCFServer  
{  
    [OperationContract]  
    Customer GetCustomer(int customerId);  
}  
```  
  
 The server’s implementation is defined in a separate concrete class, like in the following example:  
  
```csharp
public class WCFServer : IWCFServer  
{  
    public Customer GetCustomer(int customerId) { … }  
}  
```  
  
 Once these types have been defined, the WCF server can be made available to clients, like in the following example:  
  
```csharp
NetTcpBinding binding = new NetTcpBinding();  
Uri baseAddress = new Uri("net.tcp://localhost:8000/wcfserver");  
  
using (ServiceHost serviceHost = new ServiceHost(typeof(WCFServer), baseAddress))  
{  
    serviceHost.AddServiceEndpoint(typeof(IWCFServer), binding, baseAddress);  
    serviceHost.Open();  
  
    Console.WriteLine(String.Format("The WCF server is ready at {0}.",  
                                    baseAddress));  
    Console.WriteLine("Press <ENTER> to terminate service...");  
    Console.WriteLine();  
    Console.ReadLine();  
}  
```  
  
> [!NOTE]
>  TCP is used in both examples to keep them as similar as possible. Refer to the scenario walk-throughs later in this topic for examples using HTTP.  
  
 There are many ways to configure and to host WCF services. This is just one example, known as "self-hosted". For more information, see the following topics:  
  
-   [How to: Define a Service Contract](how-to-define-a-wcf-service-contract.md)  
  
-   [Configuring Services Using Configuration Files](configuring-services-using-configuration-files.md)  
  
-   [Hosting Services](hosting-services.md)  
  
### Client Implementation Comparison  
  
#### Creating a Client in .NET Remoting  
 Once a .NET Remoting server object has been made available, it can be consumed by clients, like in the following example:  
  
```csharp
TcpChannel channel = new TcpChannel();  
ChannelServices.RegisterChannel(channel, ensureSecurity : true);  
RemotingServer server = (RemotingServer)Activator.GetObject(  
                            typeof(RemotingServer),   
                            "tcp://localhost:8080/RemotingServer");  
  
RemotingCustomer customer = server.GetCustomer(42);  
Console.WriteLine(String.Format("Customer {0} {1} received.",   
                                 customer.FirstName, customer.LastName));  
```  
  
 The RemotingServer instance returned from Activator.GetObject() is known as a "transparent proxy." It implements the public API for the RemotingServer type on the client, but all the methods call the server object running in a different process or machine.  
  
#### Creating a Client in WCF  
 The equivalent step in WCF involves using a channel factory to create the proxy explicitly. Like Remoting, the proxy object can be used to invoke operations on the server, like in the following example:  
  
```csharp
NetTcpBinding binding = new NetTcpBinding();  
String url = "net.tcp://localhost:8000/wcfserver";  
EndpointAddress address = new EndpointAddress(url);  
ChannelFactory<IWCFServer> channelFactory =   
    new ChannelFactory<IWCFServer>(binding, address);  
IWCFServer server = channelFactory.CreateChannel();  
  
Customer customer = server.GetCustomer(42);  
Console.WriteLine(String.Format("  Customer {0} {1} received.",  
                    customer.FirstName, customer.LastName));  
```  
  
 This example shows programming at the channel level because it is most similar to the Remoting example. Also available is the **Add Service Reference** approach in Visual Studio that generates code to simplify client programming. For more information, see the following topics:  
  
-   [Client Channel-Level Programming](./extending/client-channel-level-programming.md)  
  
-   [How to: Add, Update, or Remove a Service Reference](/visualstudio/data-tools/how-to-add-update-or-remove-a-wcf-data-service-reference)  
  
### Serialization Usage  
 Both .NET Remoting and WCF use serialization to send objects between client and server, but they differ in these important ways:  
  
1.  They use different serializers and conventions to indicate what to serialize.  
  
2.  .NET Remoting supports "by reference" serialization that allows method or property access on one tier to execute code on the other tier, which is across security boundaries. This capability exposes security vulnerabilities and is one of the main reasons why Remoting endpoints should never be exposed to untrusted clients.  
  
3.  Serialization used by Remoting is opt-out (explicitly exclude what not to serialize) and WCF serialization is opt-in (explicitly mark which members to serialize).  
  
#### Serialization in .NET Remoting  
 .NET Remoting supports two ways to serialize and deserialize objects between the client and server:  
  
-   *By value* – the values of the object are serialized across tier boundaries, and a new instance of that object is created on the other tier. Any calls to methods or properties of that new instance execute only locally and do not affect the original object or tier.  
  
-   *By reference* – a special "object reference" is serialized across tier boundaries. When one tier interacts with methods or properties of that object, it communicates back to the original object on the original tier. By-reference objects can flow in either direction – server to client, or client to server.  
  
 By-value types in Remoting are marked with the [Serializable] attribute or implement ISerializable, like in the following example:  
  
```csharp
[Serializable]  
public class RemotingCustomer  
{  
    public string FirstName { get; set; }  
    public string LastName { get; set; }  
    public int CustomerId { get; set; }  
}  
```  
  
 By-reference types derive from the MarshalByRefObject class, like in the following example:  
  
```csharp
public class RemotingCustomerReference : MarshalByRefObject  
{  
    public string FirstName { get; set; }  
    public string LastName { get; set; }  
    public int CustomerId { get; set; }  
}  
```  
  
 It is extremely important to understand the implications of Remoting’s by-reference objects. If either tier (client or server) sends a by-reference object to the other tier, all method calls execute back on the tier owning the object. For example, a client calling methods on a by-reference object returned by the server will execute code on the server. Similarly, a server calling methods on a by-reference object provided by the client will execute code back on the client. For this reason, the use of .NET Remoting is recommended only within fully-trusted environments. Exposing a public .NET Remoting endpoint to untrusted clients will make a Remoting server vulnerable to attack.  
  
#### Serialization in WCF  
 WCF supports only by-value serialization. The most common way to define a type to exchange between client and server is like in the following example:  
  
```csharp
[DataContract]  
public class WCFCustomer  
{  
    [DataMember]  
    public string FirstName { get; set; }  
  
    [DataMember]  
    public string LastName { get; set; }  
  
    [DataMember]  
    public int CustomerId { get; set; }  
}  
```  
  
 The [DataContract] attribute identifies this type as one that can be serialized and deserialized between client and server. The [DataMember] attribute identifies the individual properties or fields to serialize.  
  
 When WCF sends an object across tiers, it serializes only the values and creates a new instance of the object on the other tier. Any interactions with the values of the object occur only locally – they do not communicate with the other tier the way .NET Remoting by-reference objects do. For more information, see the following topics:  
  
-   [Serialization and Deserialization](./feature-details/serialization-and-deserialization.md)  
  
-   [Serialization in Windows Communication Foundation](http://msdn.microsoft.com/magazine/cc163569.aspx)  
  
### Exception Handling Capabilities  
  
#### Exceptions in .NET Remoting  
 Exceptions thrown by a Remoting server are serialized, sent to the client, and thrown locally on the client like any other exception. Custom exceptions can be created by sub-classing the Exception type and marking it with [Serializable].   Most framework exceptions are already marked in this way, allowing most to be thrown by the server, serialized, and re-thrown on the client. Though this design is convenient during development, server-side information can inadvertently be disclosed to the client. This is one of many reasons Remoting should be used only in fully-trusted environments.  
  
#### Exceptions and Faults in WCF  
 WCF does not allow arbitrary exception types to be returned from the server to the client because it could lead to inadvertent information disclosure. If a service operation throws an unexpected exception, it causes a general purpose FaultException to be thrown on the client. This exception does not carry any information why or where the problem occurred, and for some applications this is sufficient. Applications that need to communicate richer error information to the client do this by defining a fault contract.  
  
 To do this, first create a [DataContract] type to carry the fault information.  
  
```csharp
[DataContract]  
public class CustomerServiceFault  
{  
    [DataMember]  
    public string ErrorMessage { get; set; }  
  
    [DataMember]  
    public int CustomerId {get;set;}  
}  
```  
  
 Specify the fault contract to use for each service operation.  
  
```csharp
[ServiceContract]  
public interface IWCFServer  
{  
    [OperationContract]  
    [FaultContract(typeof(CustomerServiceFault))]  
    Customer GetCustomer(int customerId);  
}  
```  
  
 The server reports error conditions by throwing a FaultException.  
  
```csharp
throw new FaultException<CustomerServiceFault>(  
    new CustomerServiceFault() {   
        CustomerId = customerId,   
        ErrorMessage = "Illegal customer Id"   
    });  
```  
  
 And whenever the client makes a request to the server, it can catch faults as normal exceptions.  
  
```csharp
try  
{  
    Customer customer = server.GetCustomer(-1);  
}  
catch (FaultException<CustomerServiceFault> fault)  
{  
    Console.WriteLine(String.Format("Fault received: {0}",  
    fault.Detail.ErrorMessage));  
}  
```  
  
 For more information about fault contracts, see <xref:System.ServiceModel.FaultException>.  
  
### Security Considerations  
  
#### Security in .NET Remoting  
 Some .NET Remoting channels support security features such as authentication and encryption at the channel layer (IPC and TCP). The HTTP channel relies on Internet Information Services (IIS) for both authentication and encryption. Despite this support, you should consider .NET Remoting an unsecure communication protocol and use it only within fully-trusted environments. Never expose a public Remoting endpoint to the Internet or untrusted clients.  
  
#### Security in WCF  
 WCF was designed with security in mind, in part to address the kinds of vulnerabilities found in .NET Remoting. WCF offers security at both the transport and message level, and offers many options for authentication, authorization, encryption, and so on. For more information, see the following topics:  
  
-   [Security](./feature-details/security.md)  
  
-   [WCF Security Guidance](./feature-details/security-guidance-and-best-practices.md)  
  
## Migrating to WCF  
  
### Why Migrate from Remoting to WCF?  
  
-   **.NET Remoting is a legacy product.** As described in [.NET Remoting](http://msdn.microsoft.com/library/vstudio/72x4h507\(v=vs.100\).aspx), it is considered a legacy product and is not recommended for new development. WCF or ASP.NET Web API are recommended for new and existing applications.  
  
-   **WCF uses cross-platform standards.** WCF was designed with cross-platform interoperability in mind and supports many industry standards (SOAP, WS-Security, WS-Trust, etc.). A WCF service can interoperate with clients running on operating systems other than Windows. Remoting was designed primarily for environments where both the server and client applications run using the .NET framework on a Windows operating system.  
  
-   **WCF has built-in security.** WCF was designed with security in mind and offers many options for authentication, transport level security, message level security, etc. Remoting was designed to make it easy for applications to interoperate but was not designed to be secure in non-trusted environments. WCF was designed to work in both trusted and non-trusted environments.  
  
### Migration Recommendations  
 The following are the recommended steps to migrate from .NET Remoting to WCF:  
  
-   **Create the service contract.** Define your service interface types, and mark them with the [ServiceContract] attribute.Mark all the methods the clients will be allowed to call with [OperationContract].  
  
-   **Create the data contract.** Define the data types that will be exchanged between server and client, and mark them with the [DataContract] attribute. Mark all the fields and properties the client will be allowed to use with [DataMember].  
  
-   **Create the fault contract (optional).** Create the types that will be exchanged between server and client when errors are encountered. Mark these types with [DataContract] and [DataMember] to make them serializable. For all service operations you marked with [OperationContract], also mark them with [FaultContract] to indicate which errors they may return.  
  
-   **Configure and host the service.** Once the service contract has been created, the next step is to configure a binding to expose the service at an endpoint. For more information, see [Endpoints: Addresses, Bindings, and Contracts](./feature-details/endpoints-addresses-bindings-and-contracts.md).  
  
 Once a Remoting application has been migrated to WCF, it is still important to remove dependencies on .NET Remoting. This ensures that any Remoting vulnerabilities are removed from the application. These steps include the following:  
  
-   **Discontinue use of MarshalByRefObject.** The MarshalByRefObject type exists only for Remoting and is not used by WCF. Any application types that sub-class MarshalByRefObject should be removed or changed. The MarshalByRefObject type exists only for Remoting and is not used by WCF. Any application types that sub-class MarshalByRefObject should be removed or changed.  
  
-   **Discontinue use of [Serializable] and ISerializable.** The [Serializable] attribute and ISerializable interface were originally designed to serialize types within trusted environments, and they are used by Remoting. WCF serialization relies on types being marked with [DataContract] and [DataMember]. Data types used by an application should be modified to use [DataContract] and not to use ISerializable or [Serializable]. The [Serializable] attribute and ISerializable interface were originally designed to serialize types within trusted environments, and they are used by Remoting. WCF serialization relies on types being marked with [DataContract] and [DataMember]. Data types used by an application should be modified to use [DataContract] and not to use ISerializable or [Serializable].  
  
### Migration Scenarios  
 Now let’s see how to accomplish the following common Remoting scenarios in WCF:  
  
1.  Server returns an object by-value to the client  
  
2.  Server returns an object by-reference to the client  
  
3.  Client sends an object by-value to the server  
  
> [!NOTE]
>  Sending an object by-reference from the client to the server is not allowed in WCF.  
  
 When reading through these scenarios, assume our baseline interfaces for .NET Remoting look like the following example. The .NET Remoting implementation is not important here because we want to illustrate only how to use WCF to implement equivalent functionality.  
  
```csharp
public class RemotingServer : MarshalByRefObject  
{  
    // Demonstrates server returning object by-value  
    public Customer GetCustomer(int customerId) {…}  
  
    // Demonstrates server returning object by-reference  
    public CustomerReference GetCustomerReference(int customerId) {…}  
  
    // Demonstrates client passing object to server by-value  
    public bool UpdateCustomer(Customer customer) {…}  
}  
```  
  
#### Scenario 1: Service Returns an Object by Value  
 This scenario demonstrates a server returning an object to the client by value. WCF always returns objects from the server by value, so the following steps simply describe how to build a normal WCF service.  
  
1.  Start by defining a public interface for the WCF service and mark it with the [ServiceContract] attribute. We use [OperationContract] to identify the server-side methods our client will call.  
  
   ```csharp
   [ServiceContract]  
   public interface ICustomerService  
   {  
       [OperationContract]  
       Customer GetCustomer(int customerId);  
  
       [OperationContract]  
       bool UpdateCustomer(Customer customer);  
   }  
   ```  
  
2.  The next step is to create the data contract for this service. We do this by creating classes (not interfaces) marked with the [DataContract] attribute. The individual properties or fields we want visible to both client and server are marked with [DataMember]. If we want derived types to be allowed, we must use the [KnownType] attribute to identify them. The only types WCF will allow to be serialized or deserialized for this service are those in the service interface and these "known types". Attempting to exchange any other type not in this list will be rejected.  
  
   ```csharp
   [DataContract]  
   [KnownType(typeof(PremiumCustomer))]  
   public class Customer  
   {  
       [DataMember]  
       public string FirstName { get; set; }  
  
       [DataMember]  
       public string LastName { get; set; }  
  
       [DataMember]  
       public int CustomerId { get; set; }  
   }  
  
   [DataContract]  
   public class PremiumCustomer : Customer   
   {  
       [DataMember]  
       public int AccountId { get; set; }  
   }  
   ```  
  
3.  Next, we provide the implementation for the service interface.  
  
   ```csharp  
   public class CustomerService : ICustomerService  
   {  
       public Customer GetCustomer(int customerId)  
       {  
           // read from database  
       }  
  
       public bool UpdateCustomer(Customer customer)  
       {  
           // write to database  
       }  
   }  
   ```  
  
4.  To run the WCF service, we need to declare an endpoint that exposes that service interface at a specific URL using a specific WCF binding. This is typically done by adding the following sections to the server project’s web.config file.  
  
    ```xml  
    <configuration>  
      <system.serviceModel>  
        <services>  
          <service name="Server.CustomerService">  
            <endpoint address="http://localhost:8083/CustomerService"  
                      binding="basicHttpBinding"  
                      contract="Shared.ICustomerService" />  
          </service>  
        </services>  
      </system.serviceModel>  
    </configuration>  
    ```  
  
5.  The WCF service can then be started with the following code:  
  
   ```csharp
   ServiceHost customerServiceHost = new ServiceHost(typeof(CustomerService));  
       customerServiceHost.Open();  
   ```  
  
     When this ServiceHost is started, it uses the web.config file to establish the proper contract, binding and endpoint. For more information about configuration files, see [Configuring Services Using Configuration Files](./configuring-services-using-configuration-files.md). This style of starting the server is known as self-hosting. To learn more about other choices for hosting WCF services, see [Hosting Services](./hosting-services.md).  
  
6.  The client project’s app.config must declare matching binding information for the service’s endpoint. The easiest way to do this in Visual Studio is to use **Add Service Reference**, which will automatically update the app.config file. Alternatively, these same changes can be added manually.  
  
    ```xml  
    <configuration>  
      <system.serviceModel>  
        <client>  
          <endpoint name="customerservice"  
                    address="http://localhost:8083/CustomerService"  
                    binding="basicHttpBinding"  
                    contract="Shared.ICustomerService"/>  
        </client>  
      </system.serviceModel>  
    </configuration>  
    ```  
  
     For more information about using **Add Service Reference**, see [How to: Add, Update, or Remove a Service Reference](/visualstudio/data-tools/how-to-add-update-or-remove-a-wcf-data-service-reference).  
  
7.  Now we can call the WCF service from the client. We do this by creating a channel factory for that service, asking it for a channel, and directly calling the method we want on that channel. We can do this because the channel implements the service’s interface and handles the underlying request/reply logic for us. The return value from that method call is the deserialized copy of the server’s response.  
  
   ```csharp
   ChannelFactory<ICustomerService> factory =  
       new ChannelFactory<ICustomerService>("customerservice");  
   ICustomerService service = factory.CreateChannel();  
   Customer customer = service.GetCustomer(42);  
   Console.WriteLine(String.Format("  Customer {0} {1} received.",  
           customer.FirstName, customer.LastName));  
   ```  
  
 Objects returned by WCF from the server to the client are always by value. The objects are deserialized copies of the data sent by the server. The client can call methods on these local copies without any danger of invoking server code through callbacks.  
  
#### Scenario 2: Server Returns an Object By Reference  
 This scenario demonstrates the server providing an object to the client by reference. In .NET Remoting, this is handled automatically for any type derived from MarshalByRefObject, which is serialized by-reference. An example of this scenario is allowing multiple clients to have independent sessionful server-side objects. As previously mentioned, objects returned by a WCF service are always by value, so there is no direct equivalent of a by-reference object, but it is possible to achieve something similar to by-reference semantics using an <xref:System.ServiceModel.EndpointAddress10> object. This is a serializable by-value object that can be used by the client to obtain a sessionful by-reference object on the server. This enables the scenario of having multiple clients with independent sessionful server-side objects.  
  
1.  First, we need to define a WCF service contract that corresponds to the sessionful object itself.  
  
   ```csharp
   [ServiceContract(SessionMode = SessionMode.Allowed)]  
       public interface ISessionBoundObject  
       {  
           [OperationContract]  
           string GetCurrentValue();  
  
           [OperationContract]  
           void SetCurrentValue(string value);  
       }  
   ```  
  
    > [!TIP]
    >  Notice that the sessionful object is marked with [ServiceContract], making it a normal WCF service interface. Setting the SessionMode property indicates it will be a sessionful service. In WCF, a session is a way of correlating multiple messages sent between two endpoints. This means that once a client obtains a connection to this service, a session will be established between the client and the server. The client will use a single unique instance of the server-side object for all its interactions within this single session.  
  
2.  Next, we need to provide the implementation of this service interface. By denoting it with [ServiceBehavior] and setting the InstanceContextMode, we tell WCF we want to use a unique instance of this type for an each session.  
  
   ```csharp
   [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]  
       public class MySessionBoundObject : ISessionBoundObject  
       {  
           private string _value;  
  
           public string GetCurrentValue()  
           {  
               return _value;  
           }  
  
           public void SetCurrentValue(string val)  
           {  
               _value = val;  
           }  
  
       }  
   ```  
  
3.  Now we need a way to obtain an instance of this sessionful object. We do this by creating another WCF service interface that returns an EndpointAddress10 object. This is a serializable form of an endpoint that the client can use to create the sessionful object.  
  
   ```csharp
   [ServiceContract]  
       public interface ISessionBoundFactory  
       {  
           [OperationContract]  
           EndpointAddress10 GetInstanceAddress();  
       }  
   ```  
  
     And we implement this WCF service:  
  
   ```csharp
   public class SessionBoundFactory : ISessionBoundFactory  
       {  
           public static ChannelFactory<ISessionBoundObject> _factory =   
               new ChannelFactory<ISessionBoundObject>("sessionbound");  
 
           public SessionBoundFactory()  
           {  
           }  
  
           public EndpointAddress10 GetInstanceAddress()  
           {  
               IClientChannel channel = (IClientChannel)_factory.CreateChannel();  
               return EndpointAddress10.FromEndpointAddress(channel.RemoteAddress);  
           }  
       }  
   ```  
  
     This implementation maintains a singleton channel factory to create sessionful objects. When GetInstanceAddress() is called, it creates a channel and creates an EndpointAddress10 object that effectively points to the remote address associated with this channel. EndpointAddress10 is simply a data type that can be returned to the client by-value.  
  
4.  We need to modify the server’s configuration file by doing the following two things as shown in the example below:  
  
    1.  Declare a \<client> section that describes the endpoint for the sessionful object. This is necessary because the server also acts as a client in this situation.  
  
    2.  Declare endpoints for the factory and sessionful object. This is necessary to allow the client to communicate with the service endpoints to acquire the EndpointAddress10 and to create the sessionful channel.  
  
    ```xml  
    <configuration>  
      <system.serviceModel>  
         <client>  
          <endpoint name="sessionbound"  
                    address="net.tcp://localhost:8081/SessionBoundObject"  
                    binding="netTcpBinding"  
                    contract="Shared.ISessionBoundObject"/>  
        </client>  
        <services>  
          <service name="Server.CustomerService">  
            <endpoint address="http://localhost:8083/CustomerService"  
                      binding="basicHttpBinding"  
                      contract="Shared.ICustomerService" />  
          </service>  
          <service name="Server.MySessionBoundObject">  
            <endpoint address="net.tcp://localhost:8081/SessionBoundObject"  
                      binding="netTcpBinding"  
                      contract="Shared.ISessionBoundObject" />  
          </service>  
          <service name="Server.SessionBoundFactory">  
            <endpoint address="net.tcp://localhost:8081/SessionBoundFactory"  
                      binding="netTcpBinding"  
                      contract="Shared.ISessionBoundFactory" />  
          </service>  
        </services>  
      </system.serviceModel>  
    </configuration>  
    ```  
  
     And then we can start these services:  
  
   ```csharp
   ServiceHost factoryHost = new ServiceHost(typeof(SessionBoundFactory));  
   factoryHost.Open();  
  
   ServiceHost sessionHost = new ServiceHost(typeof(MySessionBoundObject));  
   sessionHost.Open();  
   ```  
  
5.  We configure the client by declaring these same endpoints in its project’s app.config file.  
  
    ```xml  
    <configuration>  
      <system.serviceModel>  
        <client>  
          <endpoint name="customerservice"  
                    address="http://localhost:8083/CustomerService"  
                    binding="basicHttpBinding"  
                    contract="Shared.ICustomerService"/>  
          <endpoint name="sessionbound"  
                    address="net.tcp://localhost:8081/SessionBoundObject"  
                    binding="netTcpBinding"  
                    contract="Shared.ISessionBoundObject"/>  
          <endpoint name="factory"  
                    address="net.tcp://localhost:8081/SessionBoundFactory"  
                    binding="netTcpBinding"  
                    contract="Shared.ISessionBoundFactory"/>  
        </client>  
      </system.serviceModel>  
    </configuration>  
    ```  
  
6.  In order to create and use this sessionful object, the client must do the following steps:  
  
    1.  Create a channel to the ISessionBoundFactory service.  
  
    2.  Use that channel to invoke that service to obtain an EndpointAddress10.  
  
    3.  Use the EndpointAddress10 to create a channel to obtain a sessionful object.  
  
    4.  Interact with the sessionful object to demonstrate it remains the same instance across multiple calls.  
  
   ```csharp
   ChannelFactory<ISessionBoundFactory> channelFactory =   
       new ChannelFactory<ISessionBoundFactory>("factory");  
   ISessionBoundFactory sessionFactory = channelFactory.CreateChannel();  
  
   EndpointAddress10 address1 = sessionFactory.GetInstanceAddress();  
   EndpointAddress10 address2 = sessionFactory.GetInstanceAddress();  
  
   ChannelFactory<ISessionBoundObject> sessionObjectFactory1 =   
       new ChannelFactory<ISessionBoundObject>(new NetTcpBinding(),   
                                               address1.ToEndpointAddress());  
   ChannelFactory<ISessionBoundObject> sessionObjectFactory2 =   
       new ChannelFactory<ISessionBoundObject>(new NetTcpBinding(),   
                                               address2.ToEndpointAddress());  
  
   ISessionBoundObject sessionInstance1 = sessionObjectFactory1.CreateChannel();  
   ISessionBoundObject sessionInstance2 = sessionObjectFactory2.CreateChannel();  
  
   sessionInstance1.SetCurrentValue("Hello");  
   sessionInstance2.SetCurrentValue("World");  
  
   if (sessionInstance1.GetCurrentValue() == "Hello" &&  
       sessionInstance2.GetCurrentValue() == "World")  
   {  
       Console.WriteLine("sessionful server object works as expected");  
   }  
   ```  
  
 WCF always returns objects by value, but it is possible to support the equivalent of by-reference semantics through the use of EndpointAddress10. This permits the client to request a sessionful WCF service instance, after which it can interact with it like any other WCF service.  
  
#### Scenario 3: Client Sends Server a By-Value Instance  
 This scenario demonstrates the client sending a non-primitive object instance to the server by value. Because WCF only sends objects by value, this scenario demonstrates normal WCF usage.  
  
1.  Use the same WCF Service from Scenario 1.  
  
2.  Use the client to create a new by-value object (Customer), create a channel to communicate with the ICustomerService service, and send the object to it.  
  
   ```csharp
   ChannelFactory<ICustomerService> factory =  
       new ChannelFactory<ICustomerService>("customerservice");  
   ICustomerService service = factory.CreateChannel();  
   PremiumCustomer customer = new PremiumCustomer {   
   FirstName = "Bob",   
   LastName = "Jones",   
   CustomerId = 43,   
   AccountId = 99};  
   bool success = service.UpdateCustomer(customer);  
   Console.WriteLine(String.Format("  Server returned {0}.", success));  
   ```  
  
     The customer object will be serialized, and sent to the server, where it is deserialized into a new copy of that object.  
  
    > [!NOTE]
    >  This code also illustrates sending a derived type (PremiumCustomer). The service interface expects a Customer object, but the [KnownType] attribute on the Customer class indicated PremiumCustomer was also allowed. WCF will fail any attempt to serialize or deserialize any other type through this service interface.  
  
 Normal WCF exchanges of data are by value. This guarantees that invoking methods on one of these data objects executes only locally – it will not invoke code on the other tier. While it is possible to achieve something like by-reference objects returned *from* the server, it is not possible for a client to pass a by-reference object *to* the server. A scenario that requires a conversation back and forth between client and server can be achieved in WCF using a duplex service. For more information, see [Duplex Services](./feature-details/duplex-services.md).  
  
## Summary  
 .NET Remoting is a communication framework intended to be used only within fully-trusted environments. It is a legacy product and supported only for backward compatibility. It should not be used to build new applications. Conversely, WCF was designed with security in mind and is recommended for new and existing applications. Microsoft recommends that existing Remoting applications be migrated to use WCF or ASP.NET Web API instead.