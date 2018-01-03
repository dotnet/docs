---
title: "How to: Implement Custom Event Accessors (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "accessors [C#], event accessors"
  - "add accessor [C#]"
  - "events [C#], add accessor"
  - "events [C#], remove accessor"
  - "remove accessor [C#]"
ms.assetid: bf903abf-03a4-4f7b-ab6b-b7e59bc2ee1e
caps.latest.revision: 7
author: "BillWagner"
ms.author: "wiwagn"
---
# How to: Implement Custom Event Accessors (C# Programming Guide)
An event is a special kind of multicast delegate that can only be invoked from within the class that  it is declared in. Client code subscribes to the event by providing a reference to a method that should be invoked when the event is fired. These methods are added to the delegate's invocation list through event accessors, which resemble property accessors, except that event accessors are named `add` and `remove`. In most cases, you do not have to supply custom event accessors. When no custom event accessors are supplied in your code, the compiler will add them automatically. However, in some cases you may have to provide custom behavior. One such case is shown in the topic [How to:  Implement Interface Events](../../../csharp/programming-guide/events/how-to-implement-interface-events.md).  
  
## Example  
 The following example shows how to implement custom add and remove event accessors. Although you can substitute any code inside the accessors, we recommend that you lock the event before you add or remove a new event handler method.  
  
```csharp
event EventHandler IDrawingObject.OnDraw  
{  
    add  
    {  
        lock (PreDrawEvent)  
        {  
            PreDrawEvent += value;  
        }  
    }  
    remove  
    {  
        lock (PreDrawEvent)  
        {  
            PreDrawEvent -= value;  
        }  
    }  
}  
```  
  
## See Also  
 [Events](../../../csharp/programming-guide/events/index.md)  
 [event](../../../csharp/language-reference/keywords/event.md)