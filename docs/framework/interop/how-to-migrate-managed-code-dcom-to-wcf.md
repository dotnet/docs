---
title: "How to: Migrate Managed-Code DCOM to WCF"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 52961ffc-d1c7-4f83-832c-786444b951ba
caps.latest.revision: 6
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Migrate Managed-Code DCOM to WCF
Windows Communication Foundation (WCF) is the recommended and secure choice over Distributed Component Object Model (DCOM) for managed code calls between servers and clients in a distributed environment. This article shows how you to migrate code from DCOM to WCF for the following scenarios.  
  
-   The remote service returns an object by-value to the client  
  
-   The client sends an object by-value to the remote service  
  
-   The remote service returns an object by-reference to the client  
  
 For security reasons, sending an object by-reference from the client to the service is not allowed in WCF. A scenario that requires a conversation back and forth between client and server can be achieved in WCF using a duplex service.  For more information about duplex services, see [Duplex Services](../../../docs/framework/wcf/feature-details/duplex-services.md).  
  
 For more details about creating WCF services and clients for those services, see [Basic WCF Programming](../../../docs/framework/wcf/basic-wcf-programming.md), [Designing and Implementing Services](../../../docs/framework/wcf/designing-and-implementing-services.md), and [Building Clients](../../../docs/framework/wcf/building-clients.md).  
  
## DCOM example code  
 For these scenarios, the DCOM interfaces that are illustrated using WCF have the following structure:  
  
```  
[ComVisible(true)]  
[Guid("AA9C4CDB-55EA-4413-90D2-843F1A49E6E6")]  
public interface IRemoteService  
{  
   Customer GetObjectByValue();  
   IRemoteObject GetObjectByReference();  
   void SendObjectByValue(Customer customer);  
}  
  
[ComVisible(true)]  
[Guid("A12C98DE-B6A1-463D-8C24-81E4BBC4351B")]  
public interface IRemoteObject  
{  
}  
  
public class Customer  
{  
}  
```  
  
## The service returns an object by-value  
 For this scenario, you make a call to a service and it method returns an object, which is passed by-value from the server to the client. This scenario represents the following COM call:  
  
```  
public interface IRemoteService  
{  
    Customer GetObjectByValue();  
}  
```  
  
 In this scenario, the client receives a deserialized copy of an object from the remote service. The client can interact with this local copy without calling back to the service.  In other words, the client is guaranteed the service will not be involved in any way when methods on the local copy are called. WCF always returns objects from the service by value, so the following steps describe creating a regular WCF service.  
  
### Step 1: Define the WCF service interface  
 Define a public interface for the WCF service and mark it with the [<xref:System.ServiceModel.ServiceContractAttribute>] attribute.  Mark the methods you want to expose to clients with the [<xref:System.ServiceModel.OperationContractAttribute>] attribute. The following example shows using these attributes to identify the server-side interface and interface methods a client can call. The method used for this scenario is shown in bold.  
  
```  
using System.Runtime.Serialization;  
using System.ServiceModel;  
using System.ServiceModel.Web;   
. . .  
[ServiceContract]  
public interface ICustomerManager  
{  
    [OperationContract]  
    void StoreCustomer(Customer customer);  
  
    [OperationContract]     Customer GetCustomer(string firstName, string lastName);   
  
}  
```  
  
### Step 2: Define the data contract  
 Next you should create a data contract for the service, which will describe how the data will be exchanged between the service and its clients.  Classes described in the data contract should be marked with the [<xref:System.Runtime.Serialization.DataContractAttribute>] attribute. The individual properties or fields you want visible to both client and server should be marked with the [<xref:System.Runtime.Serialization.DataMemberAttribute>] attribute.If you want types derived from a class in the data contract to be allowed, you must identify them with the [<xref:System.Runtime.Serialization.KnownTypeAttribute>] attribute. WCF will only serialize or deserialize types in the service interface and types identified as known types. If you attempt to use a type that is not a known type, an exception will occur.  
  
 For more information about data contracts, see [Data Contracts](../../../docs/framework/wcf/samples/data-contracts.md).  
  
```  
[DataContract]  
[KnownType(typeof(PremiumCustomer))]  
public class Customer  
{  
    [DataMember]  
    public string Firstname;  
    [DataMember]  
    public string Lastname;  
    [DataMember]  
    public Address DefaultDeliveryAddress;  
    [DataMember]  
    public Address DefaultBillingAddress;  
}  
 [DataContract]  
public class PremiumCustomer : Customer  
{  
    [DataMember]  
    public int AccountID;  
}  
  
 [DataContract]  
public class Address  
{  
    [DataMember]  
    public string Street;  
    [DataMember]  
    public string Zipcode;  
    [DataMember]  
    public string City;  
    [DataMember]  
    public string State;  
    [DataMember]  
    public string Country;  
}  
```  
  
### Step 3: Implement the WCF service  
 Next, you should implement the WCF service class that implements the interface you defined in the previous step.  
  
```  
public class CustomerService: ICustomerManager    
{  
    public void StoreCustomer(Customer customer)  
    {  
        // write to a database  
    }  
    public Customer GetCustomer(string firstName, string lastName)  
    {  
        // read from a database  
    }  
}  
```  
  
### Step 4: Configure the service and the client  
 To run a WCF service, you need to declare an endpoint that exposes that service interface at a specific URL using a specific WCF binding. A binding specifies the transport, encoding and protocol details for the clients and server to communicate. You typically add bindings to the service project’s configuration file (web.config). The following shows a binding entry for the example service:  
  
```xml  
<configuration>  
  <system.serviceModel>  
    <services>  
      <service name="Server.CustomerService">  
        <endpoint address="http://localhost:8083/CustomerManager"   
                  binding="basicHttpBinding"  
                  contract="Shared.ICustomerManager" />  
      </service>  
    </services>  
  </system.serviceModel>  
</configuration>  
```  
  
 Next, you need to configure the client to match the binding information specified by the service. To do so, add the following to the client’s application configuration (app.config) file.  
  
```xml  
<configuration>  
  <system.serviceModel>  
    <client>  
      <endpoint name="customermanager"   
                address="http://localhost:8083/CustomerManager"   
                binding="basicHttpBinding"   
                contract="Shared.ICustomerManager"/>  
  </system.serviceModel>  
</configuration>  
```  
  
### Step 5: Run the service  
 Finally, you can self-host it in a console application by adding the following lines to the service app, and starting the app. For more information about other ways to host a WCF service application, [Hosting Services](../../../docs/framework/wcf/hosting-services.md).  
  
```  
ServiceHost customerServiceHost = new ServiceHost(typeof(CustomerService));  
customerServiceHost.Open();  
```  
  
### Step 6: Call the service from the client  
 To call the service from the client, you need to create a channel factory for the service, and request a channel, which will enable you to directly call the `GetCustomer` method directly from the client. The channel implements the service’s interface and handles the underlying request/reply logic for you.  The return value from that method call is the deserialized copy of the service response.  
  
```  
ChannelFactory<ICustomerManager> factory =   
     new ChannelFactory<ICustomerManager>("customermanager");  
ICustomerManager service = factory.CreateChannel();  
Customer customer = service.GetCustomer("Mary", "Smith");  
```  
  
## The client sends a by-value object to the server  
 In this scenario, the client sends an object to the server, by-value. This means that the server will receive a deserialized copy of the object.  The server can call methods on that copy and be guaranteed there is no callback into client code. As mentioned previously, normal WCF exchanges of data are by-value.  This guarantees that calling methods on one of these objects executes locally only – it will not invoke code on the client.  
  
 This scenario represents the following COM method call:  
  
```  
public interface IRemoteService  
{  
    void SendObjectByValue(Customer customer);  
}  
```  
  
 This scenario uses the same service interface and data contract as shown in the first example. In addition, the client and service will be configured in the same way. In this example, a channel is created to send the object and run the same way. However, for this example, you will create a client that calls the service, passing an object by-value. The service method the client will call in the service contract is shown in bold:  
  
```  
[ServiceContract]  
public interface ICustomerManager  
{  
    [OperationContract]     void StoreCustomer(Customer customer);  
  
    [OperationContract]  
    Customer GetCustomer(string firstName, string lastName);  
}  
```  
  
### Add code to the client that sends a by-value object  
 The following code shows how the client creates a new by-value customer object, creates a channel to communicate with the `ICustomerManager` service, and sends the customer object to it.  
  
 The customer object will be serialized, and sent to the service, where it is deserialized by the service into a new copy of that object.  Any methods the service calls on this object will execute only locally on the server.It’s important to note that this code illustrates sending a derived type (`PremiumCustomer`).  The service contract expects a `Customer` object, but the service data contract uses the [<xref:System.Runtime.Serialization.KnownTypeAttribute>] attribute to indicate that `PremiumCustomer` is also allowed.  WCF will fail attempts to serialize or deserialize any other type via this service interface.  
  
```  
PremiumCustomer customer = new PremiumCustomer();  
customer.Firstname = "John";  
customer.Lastname = "Doe";  
customer.DefaultBillingAddress = new Address();  
customer.DefaultBillingAddress.Street = "One Microsoft Way";  
customer.DefaultDeliveryAddress = customer.DefaultBillingAddress;  
customer.AccountID = 42;  
  
ChannelFactory<ICustomerManager> factory =  
   new ChannelFactory<ICustomerManager>("customermanager");  
ICustomerManager customerManager = factory.CreateChannel();  
customerManager.StoreCustomer(customer);  
```  
  
## The service returns an object by reference  
 For this scenario, the client app makes a call to the remote service and the method returns an object, which is passed by reference from the service to the client.  
  
 As mentioned previously, WCF services always return object by value.  However, you can achieve a similar result by using the <xref:System.ServiceModel.EndpointAddress10> class.  The <xref:System.ServiceModel.EndpointAddress10> is a serializable by-value object that can be used by the client to obtain a sessionful by-reference object on the server.  
  
 The behavior of the by-reference object in WCF shown in this scenario is different than DCOM.  In DCOM, the server can return a by-reference object to the client directly, and the client can call that object’s methods, which execute on the server.  In WCF, however, the object returned is always by-value.  The client must take that by-value object, represented by <xref:System.ServiceModel.EndpointAddress10> and use it to create its own sessionful by-reference object.  The client method calls on the sessionful object execute on the server.In other words, this by-reference object in WCF is a normal WCF service that is configured to be sessionful.  
  
 In WCF, a session is a way of correlating multiple messages sent between two endpoints.  This means that once a client obtains a connection to this service, a session will be established between the client and the server.  The client will use a single unique instance of the server-side object for all its interactions within this single session. Sessionful WCF contracts are similar to connection-oriented network request/response patterns.  
  
 This scenario is represented by the following DCOM method.  
  
```  
public interface IRemoteService  
{  
    IRemoteObject GetObjectByReference();  
}  
```  
  
### Step 1: Define the Sessionful WCF service interface and implementation  
 First, define a WCF service interface that contains the sessionful object.  
  
 In this code, the sessionful object is marked with the `ServiceContract` attribute, which identifies it as a regular WCF service interface.  In addition, the <xref:System.ServiceModel.ServiceContractAttribute.SessionMode%2A> property is set to indicate it will be a sessionful service.  
  
```  
[ServiceContract(SessionMode = SessionMode.Allowed)]  
public interface ISessionBoundObject  
{  
    [OperationContract]  
    string GetCurrentValue();  
  
    [OperationContract]  
    void SetCurrentValue(string value);  
}  
```  
  
 The following code shows the service implementation.  
  
 The service is marked with the [ServiceBehavior] attribute, and its InstanceContextMode property set to InstanceContextMode.PerSessions to indicate that a unique instance of this type should be created for each session.  
  
```  
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
  
### Step 2: Define the WCF factory service for the sessionful object  
 The service that creates the sessionful object must be defined and implemented. The following code shows how to do this. This code creates another WCF service that returns an <xref:System.ServiceModel.EndpointAddress10> object.  This is a serializable form of an endpoint the can use to create the session-full object.  
  
```  
[ServiceContract]  
    public interface ISessionBoundFactory  
    {  
        [OperationContract]  
        EndpointAddress10 GetInstanceAddress();  
    }  
```  
  
 Following is the implementation of this service. This implementation maintains a singleton channel factory to create sessionful objects.  When `GetInstanceAddress` is called, it creates a channel and creates an <xref:System.ServiceModel.EndpointAddress10> object that points to the remote address associated with this channel.   <xref:System.ServiceModel.EndpointAddress10> is a data type that can be returned to the client by-value.  
  
```  
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
  
### Step 3: Configure and start the WCF services  
 To host these services, you will need to make the following additions to the server’s configuration file (web.config).  
  
1.  Add a `<client>` section that describes the endpoint for the sessionful object.  In this scenario, the server also acts as a client and must be configured to enable this.  
  
2.  In the `<services>` section, declare service endpoints for the factory and sessionful object.  This enables the client to communicate with the service endpoints, acquire the <xref:System.ServiceModel.EndpointAddress10> and create the sessionful channel.  
  
 Following is an example configuration file with these settings:  
  
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
  
 Add the following lines to a console application, to self-host the service, and start the app.  
  
```  
ServiceHost factoryHost = new ServiceHost(typeof(SessionBoundFactory));  
factoryHost.Open();  
  
ServiceHost sessionBoundServiceHost = new ServiceHost(  
typeof(MySessionBoundObject));  
sessionBoundServiceHost.Open();  
```  
  
### Step 4: Configure the client and call the service  
 Configure the client to communicate with the WCF services by making the following entries in the project’s application configuration file (app.config).  
  
```xml  
<configuration>  
  <system.serviceModel>  
    <client>  
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
  
 To call the service, add the code to the client to do the following:  
  
1.  Create a channel to the `ISessionBoundFactory` service.  
  
2.  Use the channel to invoke the `ISessionBoundFactory` service an obtain an <xref:System.ServiceModel.EndpointAddress10> bbject.  
  
3.  Use the <xref:System.ServiceModel.EndpointAddress10> to create a channel to obtain a sessionful object.  
  
4.  Call the `SetCurrentValue` and `GetCurrentValue` methods to demonstrate it remains the same object instance is used across multiple calls.  
  
```  
ChannelFactory<ISessionBoundFactory> factory =  
        new ChannelFactory<ISessionBoundFactory>("factory");  
  
ISessionBoundFactory sessionBoundFactory = factory.CreateChannel();  
  
EndpointAddress10 address = sessionBoundFactory.GetInstanceAddress();  
  
ChannelFactory<ISessionBoundObject> sessionBoundObjectFactory =  
    new ChannelFactory<ISessionBoundObject>(  
        new NetTcpBinding(),  
        address.ToEndpointAddress());  
  
ISessionBoundObject sessionBoundObject =  
        sessionBoundObjectFactory.CreateChannel();  
  
sessionBoundObject.SetCurrentValue("Hello");  
if (sessionBoundObject.GetCurrentValue() == "Hello")  
{  
    Console.WriteLine("Session-full instance management works as expected");  
}  
```  
  
## See Also  
 [Basic WCF Programming](../../../docs/framework/wcf/basic-wcf-programming.md)  
 [Designing and Implementing Services](../../../docs/framework/wcf/designing-and-implementing-services.md)  
 [Building Clients](../../../docs/framework/wcf/building-clients.md)  
 [Duplex Services](../../../docs/framework/wcf/feature-details/duplex-services.md)
