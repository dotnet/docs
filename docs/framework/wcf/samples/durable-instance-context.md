---
title: "Durable Instance Context"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 97bc2994-5a2c-47c7-927a-c4cd273153df
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Durable Instance Context
This sample demonstrates how to customize the [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] runtime to enable durable instance contexts. It uses SQL Server 2005 as its backing store (SQL Server 2005 Express in this case). However, it also provides a way to access custom storage mechanisms.  
  
> [!NOTE]
>  The setup procedure and build instructions for this sample are located at the end of this topic.  
  
 This sample involves extending both the channel layer and the service model layer of the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. Therefore it is necessary to understand the underlying concepts before going into the implementation details.  
  
 Durable instance contexts can be found in the real world scenarios quite often. A shopping cart application for example, has the ability to pause shopping halfway through and continue it on another day. So that when we visit the shopping cart the next day, our original context is restored. It is important to note that the shopping cart application (on the server) does not maintain the shopping cart instance while we are disconnected. Instead, it persists its state into a durable storage media and uses it when constructing a new instance for the restored context. Therefore the service instance that may service for the same context is not the same as the previous instance (that is, it does not have the same memory address).  
  
 Durable instance context is made possible by a small protocol that exchanges a context ID between the client and service. This context ID is created on the client and transmitted to the service. When the service instance is created, the service runtime tries to load the persisted state that corresponds to this context ID from a persistent storage (by default it is a SQL Server 2005 database). If no state is available the new instance has its default state. The service implementation uses a custom attribute to mark operations that change the state of the service implementation so that the runtime can save the service instance after invoking them.  
  
 By the previous description, two steps can easily be distinguished to achieve the goal:  
  
1.  Change the message that goes on the wire to carry the context ID.  
  
2.  Change the service local behavior to implement custom instancing logic.  
  
 Because the first one in the list affects the messages on the wire it should be implemented as a custom channel and be hooked up to the channel layer. The latter only affects the service local behavior and therefore can be implemented by extending several service extensibility points. In the next few sections, each of these extensions are discussed.  
  
## Durable InstanceContext Channel  
 The first thing to look at is a channel layer extension. The first step in writing a custom channel is to decide the communication structure of the channel. As a new wire protocol is being introduced the channel should work with almost any other channel in the channel stack. Therefore it should support all the message exchange patterns. However, the core functionality of the channel is the same regardless of its communication structure. More specifically, from the client it should write the context ID to the messages and from the service it should read this context ID from the messages and pass it to the upper levels. Because of that, a `DurableInstanceContextChannelBase` class is created that acts as the abstract base class for all durable instance context channel implementations. This class contains the common state machine management functions and two protected members to apply and read the context information to and from messages.  
  
```  
class DurableInstanceContextChannelBase  
{  
  //…  
  protected void ApplyContext(Message message)  
  {  
    //…              
  }  
  protected string ReadContextId(Message message)  
  {  
    //…              
  }  
}  
```  
  
 These two methods make use of `IContextManager` implementations to write and read the context ID to or from the message. (`IContextManager` is a custom interface used to define the contract for all context managers.) The channel can either include the context ID in a custom SOAP header or in a HTTP cookie header. Each context manager implementation inherits from the `ContextManagerBase` class that contains the common functionality for all context managers. The `GetContextId` method in this class is used to originate the context ID from the client. When a context ID is originated for the first time, this method saves it into a text file whose name is constructed by the remote endpoint address (the invalid file name characters in the typical URIs are replaced with @ characters).  
  
 Later when the context ID is required for the same remote endpoint, it checks whether an appropriate file exists. If it does, it reads the context ID and returns. Otherwise it returns a newly generated context ID and saves it to a file. With the default configuration, these files are placed in a directory called ContextStore, which resides in the current user’s temp directory. However this location is configurable using the binding element.  
  
 The mechanism used to transport the context ID is configurable. It could be either written to the HTTP cookie header or to a custom SOAP header. The custom SOAP header approach makes it possible to use this protocol with non-HTTP protocols (for example, TCP or Named Pipes). There are two classes, namely `MessageHeaderContextManager` and `HttpCookieContextManager`, which implement these two options.  
  
 Both of them write the context ID to the message appropriately. For example, the `MessageHeaderContextManager` class writes it to a SOAP header in the `WriteContext` method.  
  
```  
public override void WriteContext(Message message)  
{  
  string contextId = this.GetContextId();  
  
  MessageHeader contextHeader =  
    MessageHeader.CreateHeader(DurableInstanceContextUtility.HeaderName,  
      DurableInstanceContextUtility.HeaderNamespace,  
      contextId,   
      true);  
  
  message.Headers.Add(contextHeader);  
}   
```  
  
 Both the `ApplyContext` and `ReadContextId` methods in the `DurableInstanceContextChannelBase` class invoke the `IContextManager.ReadContext` and `IContextManager.WriteContext`, respectively. However, these context managers are not directly created by the `DurableInstanceContextChannelBase` class. Instead it uses the `ContextManagerFactory` class to do that job.  
  
```  
IContextManager contextManager =  
                ContextManagerFactory.CreateContextManager(contextType,   
                this.contextStoreLocation,   
                this.endpointAddress);  
```  
  
 The `ApplyContext` method is invoked by the sending channels. It injects the context ID to the outgoing messages. The `ReadContextId` method is invoked by the receiving channels. This method ensures that the context ID is available in the incoming messages and adds it to the `Properties` collection of the `Message` class. It also throws a `CommunicationException` in case of a failure to read the context ID and thus causes the channel to be aborted.  
  
```  
message.Properties.Add(DurableInstanceContextUtility.ContextIdProperty, contextId);  
```  
  
 Before proceeding, it is important to understand the usage of the `Properties` collection in the `Message` class. Typically, this `Properties` collection is used when passing data from lower to the upper levels from the channel layer. This way the desired data can be provided to the upper levels in a consistent manner regardless of the protocol details. In other words, the channel layer can send and receive the context ID either as a SOAP header or a HTTP cookie header. But it is not necessary for the upper levels to know about these details because the channel layer makes this information available in the `Properties` collection.  
  
 Now with the `DurableInstanceContextChannelBase` class in place all ten of the necessary interfaces (IOutputChannel, IInputChannel, IOutputSessionChannel, IInputSessionChannel, IRequestChannel, IReplyChannel, IRequestSessionChannel, IReplySessionChannel, IDuplexChannel, IDuplexSessionChannel) must be implemented. They resemble every available message exchange pattern (datagram, simplex, duplex and their sessionful variants). Each of these implementations inherit the base class previously described and calls `ApplyContext` and `ReadContexId` appropriately. For example, `DurableInstanceContextOutputChannel` - which implements the IOutputChannel interface - calls the `ApplyContext` method from each method that sends the messages.  
  
```  
public void Send(Message message, TimeSpan timeout)  
{  
    // Apply the context information before sending the message.  
    this.ApplyContext(message);  
    //…  
}   
```  
  
 On the other hand, `DurableInstanceContextInputChannel` - which implements the `IInputChannel` interface - calls the `ReadContextId` method in each method which receives the messages.  
  
```  
public Message Receive(TimeSpan timeout)  
{  
    //…  
      ReadContextId(message);  
      return message;  
}  
```  
  
 Apart from this, these channel implementations delegate the method invocations to the channel below them in the channel stack. However, sessionful variants have a basic logic to make sure that the context ID is sent and is read only for the first message that causes the session to be created.  
  
```  
if (isFirstMessage)  
{  
//…  
    this.ApplyContext(message);  
    isFirstMessage = false;  
}  
```  
  
 These channel implementations are then added to the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] channel runtime by the `DurableInstanceContextBindingElement` class and `DurableInstanceContextBindingElementSection` class appropriately. See the [HttpCookieSession](../../../../docs/framework/wcf/samples/httpcookiesession.md) channel sample documentation for more details about binding elements and binding element sections.  
  
## Service Model Layer Extensions  
 Now that the context ID has traveled through the channel layer, the service behavior can be implemented to customize the instantiation. In this sample, a storage manager is used to load and save state from or to the persistent store. As explained previously, this sample provides a storage manager that uses SQL Server 2005 as its backing store. However, it is also possible to add custom storage mechanisms to this extension. To do that a public interface is declared, which must be implemented by all storage managers.  
  
```  
public interface IStorageManager  
{  
    object GetInstance(string contextId, Type type);  
    void SaveInstance(string contextId, object state);  
}  
```  
  
 The `SqlServerStorageManager` class contains the default `IStorageManager` implementation. In its `SaveInstance` method the given object is serialized using the XmlSerializer and is saved to the SQL Server database.  
  
```  
XmlSerializer serializer = new XmlSerializer(state.GetType());  
string data;  
  
using (StringWriter writer = new StringWriter(CultureInfo.InvariantCulture))  
{  
    serializer.Serialize(writer, state);  
    data = writer.ToString();  
}  
  
using (SqlConnection connection = new SqlConnection(GetConnectionString()))  
{  
    connection.Open();  
  
    string update = @"UPDATE Instances SET Instance = @instance WHERE ContextId = @contextId";  
  
    using (SqlCommand command = new SqlCommand(update, connection))  
    {  
        command.Parameters.Add("@instance", SqlDbType.VarChar, 2147483647).Value = data;  
        command.Parameters.Add("@contextId", SqlDbType.VarChar, 256).Value = contextId;  
  
        int rows = command.ExecuteNonQuery();  
  
        if (rows == 0)  
        {  
            string insert = @"INSERT INTO Instances(ContextId, Instance) VALUES(@contextId, @instance)";  
            command.CommandText = insert;  
            command.ExecuteNonQuery();  
        }  
    }  
}  
```  
  
 In the `GetInstance` method the serialized data is read for a given context ID and the object constructed from it is returned to the caller.  
  
```  
object data;  
using (SqlConnection connection = new SqlConnection(GetConnectionString()))  
{  
    connection.Open();  
  
    string select = "SELECT Instance FROM Instances WHERE ContextId = @contextId";  
    using (SqlCommand command = new SqlCommand(select, connection))  
    {  
        command.Parameters.Add("@contextId", SqlDbType.VarChar, 256).Value = contextId;  
        data = command.ExecuteScalar();  
    }  
}  
  
if (data != null)  
{  
    XmlSerializer serializer = new XmlSerializer(type);  
    using (StringReader reader = new StringReader((string)data))  
    {  
        object instance = serializer.Deserialize(reader);  
        return instance;  
    }  
}  
```  
  
 Users of these storage managers are not supposed to instantiate them directly. They use the `StorageManagerFactory` class, which abstracts from the storage manager creation details. This class has one static member, `GetStorageManager`, which creates an instance of a given storage manager type. If the type parameter is `null`, this method creates an instance of the default `SqlServerStorageManager` class and returns it. It also validates the given type to make sure that it implements the `IStorageManager` interface.  
  
```  
public static IStorageManager GetStorageManager(Type storageManagerType)  
{  
IStorageManager storageManager = null;  
  
if (storageManagerType == null)  
{  
    return new SqlServerStorageManager();  
}  
else  
{  
    object obj = Activator.CreateInstance(storageManagerType);  
  
    // Throw if the specified storage manager type does not  
    // implement IStorageManager.  
    if (obj is IStorageManager)  
    {  
        storageManager = (IStorageManager)obj;  
    }  
    else  
    {  
        throw new InvalidOperationException(  
                  ResourceHelper.GetString("ExInvalidStorageManager"));  
    }  
  
    return storageManager;  
}                  
}   
```  
  
 The necessary infrastructure to read and write instances from the persistent storage is implemented. Now the necessary steps to change the service behavior have to be taken.  
  
 As the first step of this process we have to save the context ID, which came through the channel layer to the current InstanceContext. InstanceContext is a runtime component that acts as the link between the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] dispatcher and the service instance. It can be used to provide additional state and behavior to the service instance. This is essential because in sessionful communication the context ID is sent only with the first message.  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] allows extending its InstanceContext runtime component by adding a new state and behavior using its extensible object pattern. The extensible object pattern is used in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] to either extend existing runtime classes with new functionality or to add new state features to an object. There are three interfaces in the extensible object pattern - IExtensibleObject\<T>, IExtension\<T>, and IExtensionCollection\<T>:  
  
-   The IExtensibleObject\<T> interface is implemented by objects that allow extensions that customize their functionality.  
  
-   The IExtension\<T> interface is implemented by objects that are extensions of classes of type T.  
  
-   The IExtensionCollection\<T> interface is a collection of IExtensions that allows for retrieving IExtensions by their type.  
  
 Therefore an InstanceContextExtension class should be created that implements the IExtension interface and defines the required state to save the context ID. This class also provides the state to hold the storage manager being used. Once the new state is saved, it should not be possible to modify it. Therefore the state is provided and saved to the instance at the time it is being constructed and then only accessible using read-only properties.  
  
```  
// Constructor  
public DurableInstanceContextExtension(string contextId,   
            IStorageManager storageManager)  
{  
    this.contextId = contextId;  
    this.storageManager = storageManager;              
}  
  
// Read only properties  
public string ContextId  
{  
    get { return this.contextId; }  
}  
  
public IStorageManager StorageManager  
{  
    get { return this.storageManager; }              
}   
```  
  
 The InstanceContextInitializer class implements the IInstanceContextInitializer interface and adds the instance context extension to the Extensions collection of the InstanceContext being constructed.  
  
```  
public void Initialize(InstanceContext instanceContext, Message message)  
{  
    string contextId =   
  (string)message.Properties[DurableInstanceContextUtility.ContextIdProperty];  
  
    DurableInstanceContextExtension extension =  
                new DurableInstanceContextExtension(contextId,   
                     storageManager);  
    instanceContext.Extensions.Add(extension);  
}  
```  
  
 As described earlier the context ID is read from the `Properties` collection of the `Message` class and passed to the constructor of the extension class. This demonstrates how information can be exchanged between the layers in a consistent manner.  
  
 The next important step is overriding the service instance creation process. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] allows implementing custom instantiation behaviors and hooking them up to the runtime using the IInstanceProvider interface. The new `InstanceProvider` class is implemented to do that job. In the constructor the service type expected from the instance provider is accepted. Later this is used to create new instances. In the `GetInstance` implementation an instance of a storage manager is created looking for a persisted instance. If it returns `null` then a new instance of the service type is instantiated and returned to the caller.  
  
```  
public object GetInstance(InstanceContext instanceContext, Message message)  
{  
    object instance = null;  
  
    DurableInstanceContextExtension extension =  
    instanceContext.Extensions.Find<DurableInstanceContextExtension>();  
  
    string contextId = extension.ContextId;  
    IStorageManager storageManager = extension.StorageManager;              
  
    instance = storageManager.GetInstance(contextId, serviceType);          
  
    if (instance == null)  
    {  
        instance = Activator.CreateInstance(serviceType);  
    }  
  
    return instance;  
}  
```  
  
 The next important step is to install the `InstanceContextExtension`, `InstanceContextInitializer` and `InstanceProvider` classes into the service model runtime. A custom attribute could be used to mark the service implementation classes to install the behavior. The `DurableInstanceContextAttribute` contains the implementation for this attribute and it implements the `IServiceBehavior` interface to extend the entire service runtime.  
  
 This class has a property that accepts the type of the storage manager to be used. In this way the implementation enables the users to specify their own `IStorageManager` implementation as parameter of this attribute.  
  
 In the `ApplyDispatchBehavior` implementation the `InstanceContextMode` of the current `ServiceBehavior` attribute is being verified. If this property is set to Singleton, enabling durable instancing is not possible and an `InvalidOperationException` is thrown to notify the host.  
  
```  
ServiceBehaviorAttribute serviceBehavior =  
    serviceDescription.Behaviors.Find<ServiceBehaviorAttribute>();  
  
if (serviceBehavior != null &&  
     serviceBehavior.InstanceContextMode == InstanceContextMode.Single)  
{  
    throw new InvalidOperationException(  
       ResourceHelper.GetString("ExSingeltonInstancingNotSupported"));  
}  
```  
  
 After this the instances of the storage manager, instance context initializer, and the instance provider are created and installed in the `DispatchRuntime` created for every endpoint.  
  
```  
IStorageManager storageManager =   
    StorageManagerFactory.GetStorageManager(storageManagerType);  
  
InstanceContextInitializer contextInitializer =  
    new InstanceContextInitializer(storageManager);  
  
InstanceProvider instanceProvider =  
    new InstanceProvider(description.ServiceType);  
  
foreach (ChannelDispatcherBase cdb in serviceHostBase.ChannelDispatchers)  
{  
    ChannelDispatcher cd = cdb as ChannelDispatcher;  
  
    if (cd != null)  
    {  
        foreach (EndpointDispatcher ed in cd.Endpoints)  
        {  
            ed.DispatchRuntime.InstanceContextInitializers.Add(contextInitializer);  
            ed.DispatchRuntime.InstanceProvider = instanceProvider;  
        }  
    }  
}  
```  
  
 In summary so far, this sample has produced a channel that enabled the custom wire protocol for custom context ID exchange and it also overwrites the default instancing behavior to load the instances from the persistent storage.  
  
 What is left is a way to save the service instance to the persistent storage. As discussed previously, there is already the required functionality to save the state in an `IStorageManager` implementation. We now must integrate this with the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] runtime. Another attribute is required that is applicable to the methods in the service implementation class. This attribute is supposed to be applied to the methods that change the state of the service instance.  
  
 The `SaveStateAttribute` class implements this functionality. It also implements `IOperationBehavior` class to modify the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] runtime for each operation. When a method is marked with this attribute, the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] runtime invokes the `ApplyBehavior` method while the appropriate `DispatchOperation` is being constructed. In this method implementation there is single line of code:  
  
```  
dispatch.Invoker = new OperationInvoker(dispatch.Invoker);  
```  
  
 This instruction creates an instance of `OperationInvoker` type and assigns it to the `Invoker` property of the `DispatchOperation` being constructed. The `OperationInvoker` class is a wrapper for the default operation invoker created for the `DispatchOperation`. This class implements the `IOperationInvoker` interface. In the `Invoke` method implementation the actual method invocation is delegated to the inner operation invoker. However, before returning the results the storage manager in the `InstanceContext` is used to save the service instance.  
  
```  
object result = innerOperationInvoker.Invoke(instance,  
    inputs, out outputs);  
  
// Save the instance using the storage manager saved in the   
// current InstanceContext.  
InstanceContextExtension extension =  
    OperationContext.Current.InstanceContext.Extensions.Find<InstanceContextExtension>();  
  
extension.StorageManager.SaveInstance(extension.ContextId, instance);  
return result;  
```  
  
## Using the Extension  
 Both the channel layer and service model layer extensions are done and they can now be used in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] applications. Services have to add the channel into the channel stack using a custom binding and then mark the service implementation classes with the appropriate attributes.  
  
```  
[DurableInstanceContext]  
[ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession)]  
public class ShoppingCart : IShoppingCart  
{  
//…  
     [SaveState]  
     public int AddItem(string item)  
     {  
         //…  
     }  
//…  
 }  
```  
  
 Client applications must add the DurableInstanceContextChannel into the channel stack using a custom binding. To configure the channel declaratively in the configuration file, the binding element section has to be added to the binding element extensions collection.  
  
```xml  
<system.serviceModel>  
 <extensions>  
   <bindingElementExtensions>  
     <add name="durableInstanceContext"  
type="Microsoft.ServiceModel.Samples.DurableInstanceContextBindingElementSection, DurableInstanceContextExtension, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"/>  
   </bindingElementExtensions>  
 </extensions>  
```  
  
 Now the binding element can be used with a custom binding just like other standard binding elements:  
  
```xml  
<bindings>  
 <customBinding>  
   <binding name="TextOverHttp">  
     <durableInstanceContext contextType="HttpCookie"/>             
     <reliableSession />  
     <textMessageEncoding />  
     <httpTransport />  
   </binding>  
 </customBinding>  
</bindings>  
```  
  
## Conclusion  
 This sample showed how to create a custom protocol channel and how to customize the service behavior to enable it.  
  
 The extension can be further improved by letting users specify the `IStorageManager` implementation using a configuration section. This makes it possible to modify the backing store without recompiling the service code.  
  
 Furthermore you could try to implement a class (for example, `StateBag`), which encapsulates the state of the instance. That class is responsible for persisting the state whenever it changes. This way you can avoid using the `SaveState` attribute and perform the persisting work more accurately (for example, you could persist the state when the state is actually changed rather than saving it each time when a method with the `SaveState` attribute is called).  
  
 When you run the sample, the following output is displayed. The client adds two items to its shopping cart and then gets the list of items in its shopping cart from the service. Press ENTER in each console window to shut down the service and client.  
  
```  
Enter the name of the product: apples  
Enter the name of the product: bananas  
  
Shopping cart currently contains the following items.  
apples  
bananas  
Press ENTER to shut down client  
```  
  
> [!NOTE]
>  Rebuilding the service overwrites the database file. To observe state preserved across multiple runs of the sample, be sure not to rebuild the sample between runs.  
  
#### To set up, build, and run the sample  
  
1.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
2.  To build the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
3.  To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/running-the-samples.md).  
  
> [!NOTE]
>  You must be running SQL Server 2005 or SQL Express 2005 to run this sample. If you are running SQL Server 2005, you must modify the configuration of the service's connection string. When running cross-machine, SQL Server is only required on the server machine.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Extensibility\Instancing\Durable`  
  
## See Also
