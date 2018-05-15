---
title: "Custom lifetime"
ms.date: "05/14/2018"
ms.assetid: 52806c07-b91c-48fe-b992-88a41924f51f
---
# Custom lifetime

This sample demonstrates how to write a Windows Communication Foundation (WCF) extension to provide custom lifetime services for shared WCF service instances.

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this article.

## Shared instancing

WCF offers several instancing modes for your service instances. The shared instancing mode covered in this article provides a way to share a service instance between multiple channels. Clients can contact a factory method in the service and create a new channel to start communication. The following code snippet shows how a client application creates a new channel to an existing service instance:

```csharp
// Create the first channel.
IEchoService proxy = channelFactory.CreateChannel();

//...

// Close the first channel
((IChannel)proxy).Close();

// Send another request from a different channel using the same instance.
proxy = channelFactory.CreateChannel();
```

Unlike other instancing modes, the shared instancing mode has a unique way of releasing the service instances. When all the channels are closed for an instance, the service WCF runtime starts a timer. If nobody makes a connection before the timeout expires, WCF releases the instance and claims the resources. As a part of the teardown procedure WCF invokes the <xref:System.ServiceModel.Dispatcher.IInstanceContextProvider.IsIdle%2A> method of all <xref:System.ServiceModel.Dispatcher.IInstanceContextProvider> implementations before releasing the instance. If all of them return `true` the instance is released. Otherwise the <xref:System.ServiceModel.Dispatcher.IInstanceContextProvider> implementation is responsible for notifying the `Dispatcher` of the idle state by using a callback method.

By default, the idle timeout value of <xref:System.ServiceModel.InstanceContext> is one minute. However, this sample demonstrates how you can extend this using a custom extension.

## Extending the InstanceContext

In WCF, <xref:System.ServiceModel.InstanceContext> is the link between the service instance and the `Dispatcher`. WCF allows you to extend this runtime component by adding new state or behavior by using its extensible object pattern. The extensible object pattern is used in WCF to either extend existing runtime classes with new functionality or to add new state features to an object. There are three interfaces in the extensible object pattern: <xref:System.ServiceModel.IExtensibleObject%601>, <xref:System.ServiceModel.IExtension%601>, and <xref:System.ServiceModel.IExtensionCollection%601>.

The <xref:System.ServiceModel.IExtensibleObject%601> interface is implemented by objects to allow extensions that customize their functionality.

The <xref:System.ServiceModel.IExtension%601> interface is implemented by objects that can be extensions of classes of type `T`.

And finally, the <xref:System.ServiceModel.IExtensionCollection%601> interface is a collection of [IExtensions](xref:System.ServiceModel.IExtension%601) that allows for retrieving [IExtensions](xref:System.ServiceModel.IExtension%601) by their type.

Therefore, in order to extend the <xref:System.ServiceModel.InstanceContext>, you must implement the `IExtension` interface. In this sample project, the `CustomLeaseExtension` class contains this implementation.

```csharp
class CustomLeaseExtension : IExtension<InstanceContext>
{
}
```

The <xref:System.ServiceModel.IExtension%601> interface has two methods <xref:System.ServiceModel.IExtension%601.Attach%2A> and <xref:System.ServiceModel.IExtension%601.Detach%2A>. As their names imply, these two methods are called when the runtime attaches and detaches the extension to an instance of the <xref:System.ServiceModel.InstanceContext> class. In this sample, the `Attach` method is used to keep track of the <xref:System.ServiceModel.InstanceContext> object that belongs to the current instance of the extension.

```csharp
InstanceContext owner;

public void Attach(InstanceContext owner)
{
    this.owner = owner;
}
```

In addition, you must add the necessary implementation to the extension to provide the extended lifetime support. Therefore, the `ICustomLease` interface is declared with the desired methods and is implemented in the `CustomLeaseExtension` class.

```csharp
interface ICustomLease
{
    bool IsIdle { get; }
    InstanceContextIdleCallback Callback { get; set; }
}

class CustomLeaseExtension : IExtension<InstanceContext>, ICustomLease
{
}
```

When WCF invokes the <xref:System.ServiceModel.Dispatcher.IInstanceContextProvider.IsIdle%2A> method in the <xref:System.ServiceModel.Dispatcher.IInstanceContextProvider> implementation, this call is routed to the <xref:System.ServiceModel.Dispatcher.IInstanceContextProvider.IsIdle%2A> method of the `CustomLeaseExtension`. Then, the `CustomLeaseExtension` checks its private state to see whether the <xref:System.ServiceModel.InstanceContext> is idle. If it is idle, it returns `true`. Otherwise, it starts a timer for a specified amount of extended lifetime.

```csharp
public bool IsIdle
{
  get
  {
    lock (thisLock)
    {
      if (isIdle)
      {
        return true;
      }
      else
      {
        StartTimer();
        return false;
      }
    }
  }
}
```

In the timer’s `Elapsed` event, the callback function in the Dispatcher is called in order to start another clean-up cycle.

```csharp
void idleTimer_Elapsed(object sender, ElapsedEventArgs args)
{
    lock (thisLock)
    {
        StopTimer();
        isIdle = true;
        Utility.WriteMessageToConsole(
            ResourceHelper.GetString("MsgLeaseExpired"));
        callback(owner);
    }
}
```

There is no way to renew the running timer when a new message arrives for the instance being moved to the idle state.

The sample implements <xref:System.ServiceModel.Dispatcher.IInstanceContextProvider> to intercept the calls to the <xref:System.ServiceModel.Dispatcher.IInstanceContextProvider.IsIdle%2A> method and route them to the `CustomLeaseExtension`. The <xref:System.ServiceModel.Dispatcher.IInstanceContextProvider> implementation is contained in `CustomLifetimeLease` class. The <xref:System.ServiceModel.Dispatcher.IInstanceContextProvider.IsIdle%2A> method is invoked when WCF is about to release the service instance. However, there is only one instance of a particular `ISharedSessionInstance` implementation in the ServiceBehavior’s <xref:System.ServiceModel.Dispatcher.IInstanceContextProvider> collection. This means there is no way of knowing the <xref:System.ServiceModel.InstanceContext> being closed at the time WCF checks the <xref:System.ServiceModel.Dispatcher.IInstanceContextProvider.IsIdle%2A> method. Therefore this sample uses thread locking to serialize requests to the <xref:System.ServiceModel.Dispatcher.IInstanceContextProvider.IsIdle%2A> method.

> [!IMPORTANT]
> Using thread locking is not a recommended approach because serialization can severely affect the performance of your application.

A private member variable is used in the `CustomLifetimeLease` class to track the `IsIdle` value. Each time the value of <xref:System.ServiceModel.Dispatcher.IInstanceContextProvider> is retrieved, the `IsIdle` private member is returned and reset to `false`. It is essential to set this value to `false` in order to make sure the Dispatcher calls the <xref:System.ServiceModel.Dispatcher.IInstanceContextProvider.NotifyIdle%2A> method.

```csharp
public bool IsIdle(InstanceContext instanceContext)
{
    get
    {
        lock (thisLock)
        {
            //...
            bool idleCopy = isIdle;
            isIdle = false;
            return idleCopy;
        }
    }
}
```

If the `IInstanceContextProvider.IsIdle` property returns `false`, the Dispatcher registers a callback function by using the `NotifyIdle` method. This method receives a reference to the <xref:System.ServiceModel.InstanceContext> being released. Therefore, the sample code can query the `ICustomLease` type extension and check the `ICustomLease.IsIdle` property in the extended state.

```csharp
public void NotifyIdle(InstanceContextIdleCallback callback,
            InstanceContext instanceContext)
{
    lock (thisLock)
    {
       ICustomLease customLease =
           instanceContext.Extensions.Find<ICustomLease>();
       customLease.Callback = callback;
       isIdle = customLease.IsIdle;
       if (isIdle)
       {
             callback(instanceContext);
       }
    }
}
```

Before the `ICustomLease.IsIdle` property is checked, the Callback property needs to be set as this is essential for `CustomLeaseExtension` to notify the Dispatcher when it becomes idle. If `ICustomLease.IsIdle` returns `true`, the `isIdle` private member is simply set in `CustomLifetimeLease` to `true` and calls the callback method. Because the code holds a lock, other threads cannot change the value of this private member. And the next time Dispatcher checks the `IInstanceContextProvider.IsIdle`, it returns `true` and lets Dispatcher release the instance.

Now that the groundwork for the custom extension is completed, it has to be hooked up to the service model. To hook up the `CustomLeaseExtension` implementation to the <xref:System.ServiceModel.InstanceContext>, WCF provides the <xref:System.ServiceModel.Dispatcher.IInstanceContextInitializer> interface to perform the bootstrapping of <xref:System.ServiceModel.InstanceContext>. In the sample, the `CustomLeaseInitializer` class implements this interface and adds an instance of `CustomLeaseExtension` to the <xref:System.ServiceModel.InstanceContext.Extensions%2A> collection from the only method initialization. This method is called by Dispatcher while initializing the <xref:System.ServiceModel.InstanceContext>.

```csharp
public void InitializeInstanceContext(InstanceContext instanceContext,
    System.ServiceModel.Channels.Message message, IContextChannel channel)

    //...

    IExtension<InstanceContext> customLeaseExtension =
        new CustomLeaseExtension(timeout, headerId);
    instanceContext.Extensions.Add(customLeaseExtension);
}
```

 Finally the <xref:System.ServiceModel.Dispatcher.IInstanceContextProvider> implementation is hooked up to the service model by using the <xref:System.ServiceModel.Description.IServiceBehavior> implementation. This implementation is placed in the `CustomLeaseTimeAttribute` class and it also derives from the `Attribute` base class to expose this behavior as an attribute.

```csharp
public void ApplyDispatchBehavior(ServiceDescription description,
           ServiceHostBase serviceHostBase)
{
    CustomLifetimeLease customLease = new CustomLifetimeLease(timeout);

    foreach (ChannelDispatcherBase cdb in serviceHostBase.ChannelDispatchers)
    {
        ChannelDispatcher cd = cdb as ChannelDispatcher;

        if (cd != null)
        {
            foreach (EndpointDispatcher ed in cd.Endpoints)
            {
                ed.DispatchRuntime.InstanceContextProvider = customLease;
            }
        }
    }
}
```

This behavior can be added to a sample service class by annotating it with the `CustomLeaseTime` attribute.

```csharp
[CustomLeaseTime(Timeout = 20000)]
public class EchoService : IEchoService
{
  //…
}
```

When you run the sample, the operation requests and responses are displayed in both the service and client console windows. Press ENTER in each console window to shut down the service and client.

### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).

> [!IMPORTANT]
> The samples may already be installed on your machine. Check for the following (default) directory before continuing.
>
> `<InstallDrive>:\WF_WCF_Samples`
>
> If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all Windows Communication Foundation (WCF) and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.
>
> `<InstallDrive>:\WF_WCF_Samples\WCF\Extensibility\Instancing\Lifetime`