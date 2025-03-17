---
title: Handling and raising events
description: Learn to handle and raise .NET events, which are based on the delegate model. This model lets subscribers register with or receive notifications from providers.
ms.date: 03/17/2025
ms.topic: concept-article
ms.custom: devdivchpfy22
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "delegate model for events"
  - "application development [.NET], events"
  - "application development [.NET], events"
  - "application development [.NET Core], events"
  - "events [.NET]"
  - "events [.NET Core]"
  - "events [.NET]"
ms.assetid: b6f65241-e0ad-4590-a99f-200ce741bb1f
#customer intent: As a .NET developer, I want to raise and handle .NET events based on the delegate model, so I can enable subscribers to register with or receive notifications from providers.

---
# Handle and raise events

Events in .NET are based on the delegate model. The delegate model follows the [observer design pattern](observer-design-pattern.md), which enables a subscriber to register with and receive notifications from a provider. An event sender pushes a notification when an event occurs, and an event receiver receives the notification and defines a response. This article describes the major components of the delegate model, how to consume events in applications, and how to implement events in your code.
  
## Raise events with an event sender

An event is a message sent by an object to signal the occurrence of an action. The action might be user interaction, such as a button press, or it might result from other program logic, such as a property value change. The object that raises the event is called the *event sender*. The event sender doesn't know the object or method that receives (handles) the events it raises. The event is typically a member of the event sender. For example, the <xref:System.Web.UI.WebControls.Button.Click> event is a member of the <xref:System.Web.UI.WebControls.Button> class, and the <xref:System.ComponentModel.INotifyPropertyChanged.PropertyChanged> event is a member of the class that implements the <xref:System.ComponentModel.INotifyPropertyChanged> interface.  
  
To define an event, you use the C# [event](../../csharp/language-reference/keywords/event.md) or the Visual Basic [Event](../../visual-basic/language-reference/statements/event-statement.md) keyword in the signature of your event class, and specify the type of delegate for the event. Delegates are described in the next section.  
  
Typically, to raise an event, you add a method that is marked as `protected` and `virtual` (in C#) or `Protected` and `Overridable` (in Visual Basic). The naming convention for the method is `On<EventName>`, such as `OnDataReceived`. The method should take one parameter that specifies an event data object, which is an object of type <xref:System.EventArgs> or a derived type. You provide this method to enable derived classes to override the logic for raising the event. A derived class should always call the `On<EventName>` method of the base class to ensure registered delegates receive the event.  

The following example shows how to declare an event named `ThresholdReached`. The event is associated with the <xref:System.EventHandler> delegate and raised in a method named `OnThresholdReached`:
  
[!code-csharp[EventsOverview#1](~/samples/snippets/csharp/VS_Snippets_CLR/eventsoverview/cs/programtruncated.cs#1)]
[!code-vb[EventsOverview#1](~/samples/snippets/visualbasic/VS_Snippets_CLR/eventsoverview/vb/module1truncated.vb#1)]  
  
## Declare delegate references for methods

A delegate is a type that holds a reference to a method. A delegate is declared with a signature that shows the return type and parameters for the methods it references. It can hold references only to methods that match its signature. A delegate is equivalent to a type-safe function pointer or a callback. A delegate declaration is sufficient to define a delegate class.  
  
Delegates have many uses in .NET. In the context of events, a delegate is an intermediary (or pointer-like mechanism) between the event source and the code that handles the event. You associate a delegate with an event by including the delegate type in the event declaration, as shown in the example in the previous section. For more information about delegates, see the <xref:System.Delegate> class.  
  
.NET provides the <xref:System.EventHandler> and <xref:System.EventHandler%601> delegates to support most event scenarios. Use the <xref:System.EventHandler> delegate for all events that don't include event data. Use the <xref:System.EventHandler%601> delegate for events that include data about the event. These delegates have no return type value and take two parameters (an object for the source of the event and an object for event data).  
  
Delegates are [multicast](xref:System.MulticastDelegate) class objects, which means they can hold references to more than one event-handling method. For more information, see the <xref:System.Delegate> reference page. Delegates provide flexibility and fine-grained control in event handling. A delegate acts as an event dispatcher for the class that raises the event by maintaining a list of registered event handlers for the event.  
  
For scenarios where the <xref:System.EventHandler> and <xref:System.EventHandler%601> delegates don't work, you can define a delegate. Scenarios that require you to define a delegate are rare, such as when you must work with code that doesn't recognize generics. You mark a delegate with the `delegate` type in [C#]](../../csharp/language-reference/builtin-types/reference-types.md#the-delegate-type) or the `Delegate` type in [Visual Basic](../../visual-basic/language-reference/statements/delegate-statement.md) in the declaration. The following example shows how to declare a delegate named `ThresholdReachedEventHandler`:  
  
[!code-csharp[EventsOverview#4](~/samples/snippets/csharp/VS_Snippets_CLR/eventsoverview/cs/programtruncated.cs#4)]
[!code-vb[EventsOverview#4](~/samples/snippets/visualbasic/VS_Snippets_CLR/eventsoverview/vb/module1truncated.vb#4)]  
  
## Work with event data classes

Data associated with an event can be provided through an event data class. .NET provides many event data classes that you can use in your applications. For example, the <xref:System.IO.Ports.SerialDataReceivedEventArgs> class is the event data class for the <xref:System.IO.Ports.SerialPort.DataReceived?displayProperty=nameWithType> event. .NET follows a naming pattern where all event data classes end with the `EventArgs` suffix. You determine which event data class is associated with an event by looking at the delegate for the event. For example, the <xref:System.IO.Ports.SerialDataReceivedEventHandler> delegate includes the <xref:System.IO.Ports.SerialDataReceivedEventArgs> class as a parameter.  
  
The <xref:System.EventArgs> class is the base type for all event data classes. You also use this class if an event doesn't have any data associated with it. When you create an event that has the single purpose of notifying other classes that something happened and there's no data to pass, include the <xref:System.EventArgs> class as the second parameter in the delegate. You can pass the <xref:System.EventArgs.Empty?displayProperty=nameWithType> value when no data is provided. The <xref:System.EventHandler> delegate includes the <xref:System.EventArgs> class as a parameter.  
  
When you want to create a customized event data class, create a class that derives from the <xref:System.EventArgs> class, and then provide any members needed to pass data related to the event. Typically, you should use the same naming pattern as .NET and end your event data class name with the `EventArgs` suffix.  
  
The following example shows an event data class named `ThresholdReachedEventArgs` that contains properties that are specific to the event being raised:
  
[!code-csharp[EventsOverview#3](~/samples/snippets/csharp/VS_Snippets_CLR/eventsoverview/cs/programtruncated.cs#3)]
[!code-vb[EventsOverview#3](~/samples/snippets/visualbasic/VS_Snippets_CLR/eventsoverview/vb/module1truncated.vb#3)]  
  
## Respond to events with handlers

To respond to an event, you define an event handler method in the event receiver. This method must match the signature of the delegate for the event you're handling. In the event handler, you perform the actions that are required when the event is raised, such as collecting user input after the user presses a button. To receive notifications when the event occurs, your event handler method must subscribe to the event.  
  
The following example shows an event handler method named `c_ThresholdReached` that matches the signature for the <xref:System.EventHandler> delegate. The method subscribes to the `ThresholdReached` event:
  
[!code-csharp[EventsOverview#2](~/samples/snippets/csharp/VS_Snippets_CLR/eventsoverview/cs/programtruncated.cs#2)]
[!code-vb[EventsOverview#2](~/samples/snippets/visualbasic/VS_Snippets_CLR/eventsoverview/vb/module1truncated.vb#2)]  

## Use static and dynamic event handlers  

.NET allows subscribers to register for event notifications either statically or dynamically. Static event handlers are in effect for the entire life of the class whose events they handle. Dynamic event handlers are explicitly activated and deactivated during program execution, usually in response to some conditional program logic. You can use dynamic handlers when event notifications are needed only under certain conditions, or when run-time conditions determine the specific handler to call. The example in the previous section shows how to dynamically add an event handler. For more information, see [Events](../../visual-basic/programming-guide/language-features/events/index.md) (in Visual Basic) and [Events](../../csharp/programming-guide/events/index.md) (in C#).  
  
## Raise multiple events

If your class raises multiple events, the compiler generates one field per event delegate instance. If the number of events is large, the storage cost of one field per delegate might not be acceptable. For these scenarios, .NET provides event properties that you can use with another data structure of your choice to store event delegates.  
  
Event properties consist of event declarations accompanied by event accessors. Event accessors are methods that you define to add or remove event delegate instances from the storage data structure.

> [!NOTE]
> The event properties are slower than the event fields because each event delegate must be retrieved before it can be invoked.

The trade-off is between memory and speed. If your class defines many events that are infrequently raised, you should implement event properties. For more information, see [Handle multiple events by using event properties](how-to-handle-multiple-events-using-event-properties.md).  
  
## Explore related tasks

The following table lists resources for other tasks and concepts related to working with events:

| Subject | Description |  
| --- | --- |
| [Raise and consume events](how-to-raise-and-consume-events.md) | Find examples for raising and consuming events. |  
| [Handle multiple events with event properties](how-to-handle-multiple-events-using-event-properties.md) | Discover how to use event properties to handle multiple events. |  
| [Explore the observer design pattern](observer-design-pattern.md) | Review a design pattern that enables a subscriber to register with and receive notifications from a provider. |

## Review specification reference

Specification reference documentation is available for the APIs that support event handling:

| API name | API type | Reference |  
| --- | --- | --- |
| EventHandler | Delegate | <xref:System.EventHandler> |
| EventHandler<TEventArgs> | Delegate | <xref:System.EventHandler%601> |
| EventArgs | Class |<xref:System.EventArgs> |
| Delegate  | Class | <xref:System.Delegate> |

## Related content

- [Events (Visual Basic)](../../visual-basic/programming-guide/language-features/events/index.md)
- [Events (C# Programming Guide)](../../csharp/programming-guide/events/index.md)
- [Events and routed events overview - Universal Windows Platform (UWP) apps](/windows/uwp/xaml-platform/events-and-routed-events-overview)
- [Events in Windows Store 8.x apps](/previous-versions/windows/apps/hh758286(v=win.10))
