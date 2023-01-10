---
title: Communicating Between Components
description: Providing loosely-coupled messaging for a .NET MAUI application 
author: michaelstonis
no-loc: [MAUI]
ms.date: 07/02/2022
---

# Communicating between loosely coupled components

[!INCLUDE [download-alert](includes/download-alert.md)]

The publish-subscribe pattern is a messaging pattern in which publishers send messages without having knowledge of any receivers, known as subscribers. Similarly, subscribers listen for specific messages, without having knowledge of any publishers.

Events in .NET implement the publish-subscribe pattern, and are the most simple and straightforward approach for a communication layer between components if loose coupling is not required, such as a control and the page that contains it. However, the publisher and subscriber lifetimes are coupled by object references to each other, and the subscriber type must have a reference to the publisher type. This can create memory management issues, especially when there are short lived objects that subscribe to an event of a static or long-lived object. If the event handler isn't removed, the subscriber will be kept alive by the reference to it in the publisher, and this will prevent or delay the garbage collection of the subscriber.

## Introduction to MessagingCenter

The .NET MAUI `MessagingCenter` class implements the publish-subscribe pattern, allowing message-based communication between components that are inconvenient to link by object and type references. This mechanism allows publishers and subscribers to communicate without having a direct reference to each other, helping to reduce dependencies between components, while also allowing components to be independently developed and tested.

The `MessagingCenter` class provides multicast publish-subscribe functionality. This means that there can be multiple publishers that publish a single message, and there can be multiple subscribers listening for the same message. The image below illustrates this relationship:

![Multicast publish-subscribe functionality.](./media/messaging-center.png)

Publishers send messages using the `MessagingCenter.Send` method, while subscribers listen for messages using the `MessagingCenter.Subscribe` method. In addition, subscribers can also unsubscribe from message subscriptions, if required, with the `MessagingCenter.Unsubscribe` method.

Internally, the `MessagingCenter` class uses weak references. This means that it will not keep objects alive, and will allow them to be garbage collected. Therefore, it should only be necessary to unsubscribe from a message when a class no longer wishes to receive the message.

The eShopOnContainers multi-platform app uses the `MessagingCenter` class to communicate between loosely coupled components. The app defines a single message. The `AddProduct` message is published by the `CatalogViewModel` class when an item is added to the shopping basket. In return, the `CatalogView` class subscribes to the message and uses this to highlight the product adds with an animation in response.

> [!NOTE]
> While the `MessagingCenter` class permits communication between loosely-coupled classes, it does not offer the only architectural solution to this issue. For example, communication between a view model and a view can also be achieved by the binding engine and through property change notifications. In addition, communication between two view models can also be achieved by passing data during navigation.

In the eShopOnContainers multi-platform app, `MessagingCenter` is used to update in the UI in response to an action occurring in another class. Therefore, messages are published on the UI thread, with subscribers receiving the message on the same thread.

> [!TIP]
> Marshal to the UI or main thread when performing UI updates. If updates to user interfaces are not made on this thread, it can cause the application to crash or become unstable.

If a message that's sent from a background thread is required to update the UI, process the message on the UI thread in the subscriber by invoking the `MainThread.BeginInvokeOnMainThread` method.

For more information about `MessagingCenter`, see [MessagingCenter](/dotnet/maui/fundamentals/messagingcenter) on the Microsoft Developer Center.

## Defining a message

`MessagingCenter` messages are strings that are used to identify messages. The following code example shows the messages defined within the eShopOnContainers multi-platform app:

```csharp
public static class MessengerKeys
{
    // Add product to basket
    public const string AddProduct = nameof(AddProduct);
}
```

In this example, messages are defined using constants. The advantage of this approach is that it provides compile-time type safety and refactoring support.

## Publishing a message

Publishers notify subscribers of a message with one of the `MessagingCenter.Send` overloads. The following code example demonstrates publishing the `AddProduct` message:

```csharp
MessagingCenter.Send(this, MessengerKeys.AddProduct);
```

In this example, the Send method specifies three arguments:

- The first argument specifies the sender class. The sender class must be specified by any subscribers who wish to receive the message.
- The second argument specifies the message.

If needed, a third argument can specify the payload data to be sent to the subscriber. This payload can be any `object` type. It will be important that the subscriber of the message knows the expected payload type.

The Send method will publish the message, and its payload data, using a fire-and-forget approach. Therefore, the message is sent even if there are no subscribers registered to receive the message. In this situation, the sent message is ignored.

> [!NOTE]
> The `MessagingCenter.Send` method can use generic parameters to control how messages are delivered. Therefore, multiple messages that share a message identity but send different payload data types can be received by different subscribers.

## Subscribing to a message

Subscribers can register to receive a message using one of the `MessagingCenter.Subscribe` overloads. The following code example demonstrates how the eShopOnContainers multi-platform app subscribes to, and processes, the `AddProduct` message:

```csharp
MessagingCenter.Subscribe<CatalogViewModel>(
    this,
    MessengerKeys.AddProduct,
    _ =>
    {
        MainThread.BeginInvokeOnMainThread(
            async () =>
            {
                await badge.ScaleTo(1.2);
                await badge.ScaleTo(1.0);
            });
    });
```

In the preceding example, the Subscribe method subscribes to the `AddProduct` message, and executes a callback delegate in response to receiving the message. This callback delegate, specified as a lambda expression, executes code that updates the UI.

If payload data is supplied, don't attempt to modify the payload data from within a callback delegate because several threads could be accessing the received data simultaneously. In this scenario, the payload data should be immutable to avoid concurrency errors.

A subscriber might not need to handle every instance of a published message, and this can be controlled by the generic type arguments that are specified on the Subscribe method. In this example, the subscriber will only receive `AddProduct` messages that are sent from the `CatalogViewModel` class.

## Unsubscribing from a message

Subscribers can unsubscribe from messages they no longer want to receive. This is achieved with one of the `MessagingCenter`.Unsubscribe overloads, as demonstrated in the following code example:

```csharp
MessagingCenter.Unsubscribe<CatalogViewModel>(
    this, MessengerKeys.AddProduct);
```

In this example, the Unsubscribe method syntax reflects the type arguments specified when subscribing to receive the AddProduct message.

## Summary

The .NET MAUI `MessagingCenter` class implements the publish-subscribe pattern, allowing message-based communication between components that are inconvenient to link by object and type references. This mechanism allows publishers and subscribers to communicate without having a reference to each other, helping to reduce dependencies between components, while also allowing components to be independently developed and tested.
