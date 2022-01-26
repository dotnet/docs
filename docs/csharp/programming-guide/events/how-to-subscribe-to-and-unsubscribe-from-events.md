---
title: "How to subscribe to and unsubscribe from events - C# Programming Guide"
description: Learn how to subscribe to and unsubscribe from events. Subscribe to events using the Visual Studio IDE, programmatically, or using an anonymous method.
ms.topic: how-to
ms.date: 07/20/2015
helpviewer_keywords: 
  - "event handlers [C#], creating"
  - "Code Editor, event handlers"
  - "events [C#], creating using the IDE"
ms.assetid: 6319f39f-282c-4173-8a62-6c4657cf51cd
---
# How to subscribe to and unsubscribe from events (C# Programming Guide)

You subscribe to an event that is published by another class when you want to write custom code that is called when that event is raised. For example, you might subscribe to a button's `click` event in order to make your application do something useful when the user clicks the button.  
  
### To subscribe to events by using the Visual Studio IDE  
  
1. If you cannot see the **Properties** window, in **Design** view, right-click the form or control for which you want to create an event handler, and select **Properties**.  
  
2. On top of the **Properties** window, click the **Events** icon.  
  
3. Double-click the event that you want to create, for example the `Load` event.  
  
     Visual C# creates an empty event handler method and adds it to your code. Alternatively you can add the code manually in **Code** view. For example, the following lines of code declare an event handler method that will be called when the `Form` class raises the `Load` event.  
  
     [!code-csharp[csProgGuideEvents#11](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideEvents/CS/Events.cs#11)]  
  
     The line of code that is required to subscribe to the event is also automatically generated in the `InitializeComponent` method in the Form1.Designer.cs file in your project. It resembles this:  
  
    ```csharp
    this.Load += new System.EventHandler(this.Form1_Load);  
    ```  
  
### To subscribe to events programmatically  
  
1. Define an event handler method whose signature matches the delegate signature for the event. For example, if the event is based on the <xref:System.EventHandler> delegate type, the following code represents the method stub:  
  
    ```csharp
    void HandleCustomEvent(object sender, CustomEventArgs a)  
    {  
       // Do something useful here.  
    }  
    ```  
  
2. Use the addition assignment operator (`+=`) to attach an event handler to the event. In the following example, assume that an object named `publisher` has an event named `RaiseCustomEvent`. Note that the subscriber class needs a reference to the publisher class in order to subscribe to its events.  
  
    ```csharp
    publisher.RaiseCustomEvent += HandleCustomEvent;  
    ```  
  
     You can also use a [lambda expression](../../language-reference/operators/lambda-expressions.md) to specify an event handler:
  
    ```csharp
    public Form1()  
    {  
        InitializeComponent();  
        this.Click += (s,e) =>
            {
                MessageBox.Show(((MouseEventArgs)e).Location.ToString());
            };
    }  
    ```  
  
### To subscribe to events by using an anonymous function  
  
If you don't have to unsubscribe from an event later, you can use the addition assignment operator (`+=`) to attach an anonymous function as an event handler. In the following example, assume that an object named `publisher` has an event named `RaiseCustomEvent` and that a `CustomEventArgs` class has also been defined to carry some kind of specialized event information. Note that the subscriber class needs a reference to `publisher` in order to subscribe to its events.  
  
```csharp
publisher.RaiseCustomEvent += (object o, CustomEventArgs e) =>
{  
  string s = o.ToString() + " " + e.ToString();  
  Console.WriteLine(s);  
};  
```  

You cannot easily unsubscribe from an event if you used an anonymous function to subscribe to it. To unsubscribe in this scenario, go back to the code where you subscribe to the event, store the anonymous function in a delegate variable, and then add the delegate to the event. We recommend that you don't use anonymous functions to subscribe to events if you have to unsubscribe from the event at some later point in your code. For more information about anonymous functions, see [Lambda expressions](../../language-reference/operators/lambda-expressions.md).  
  
## Unsubscribing  

 To prevent your event handler from being invoked when the event is raised, unsubscribe from the event. In order to prevent resource leaks, you should unsubscribe from events before you dispose of a subscriber object. Until you unsubscribe from an event, the multicast delegate that underlies the event in the publishing object has a reference to the delegate that encapsulates the subscriber's event handler. As long as the publishing object holds that reference, garbage collection will not delete your subscriber object.  
  
#### To unsubscribe from an event  
  
- Use the subtraction assignment operator (`-=`) to unsubscribe from an event:  
  
    ```csharp
    publisher.RaiseCustomEvent -= HandleCustomEvent;  
    ```  
  
     When all subscribers have unsubscribed from an event, the event instance in the publisher class is set to `null`.  
  
## See also

- [Events](./index.md)
- [event](../../language-reference/keywords/event.md)
- [How to publish events that conform to .NET Guidelines](./how-to-publish-events-that-conform-to-net-framework-guidelines.md)
- [- and -= operators](../../language-reference/operators/subtraction-operator.md)
- [+ and += operators](../../language-reference/operators/addition-operator.md)
