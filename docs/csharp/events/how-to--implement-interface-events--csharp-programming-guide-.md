---
title: "How to: Implement Interface Events (C# Programming Guide)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "interfaces [C#], event implementation in classes"
  - "events [C#], in interfaces"
ms.assetid: 63527447-9535-4880-8e95-35e2075827df
caps.latest.revision: 21
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# How to: Implement Interface Events (C# Programming Guide)
An [interface](../keywords/interface--csharp-reference-.md) can declare an [event](../keywords/event--csharp-reference-.md). The following example shows how to implement interface events in a class. Basically the rules are the same as when you implement any interface method or property.  
  
### To implement interface events in a class  
  
-   Declare the event in your class and then invoke it in the appropriate areas.  
  
    ```  
    namespace ImplementInterfaceEvents  
    {  
        public interface IDrawingObject  
        {  
            event EventHandler ShapeChanged;  
        }  
        public class MyEventArgs : EventArgs   
        {  
            // class members  
        }  
        public class Shape : IDrawingObject  
        {  
            public event EventHandler ShapeChanged;  
            void ChangeShape()  
            {  
                // Do something here before the event…  
  
                OnShapeChanged(new MyEventArgs(/*arguments*/));  
  
                // or do something here after the event.   
            }  
            protected virtual void OnShapeChanged(MyEventArgs e)  
            {  
                if(ShapeChanged != null)  
                {  
                   ShapeChanged(this, e);  
                }  
            }  
        }  
  
    }  
    ```  
  
## Example  
 The following example shows how to handle the less-common situation in which your class inherits from two or more interfaces and each interface has an event with the same name. In this situation, you must provide an explicit interface implementation for at least one of the events. When you write an explicit interface implementation for an event, you must also write the `add` and `remove` event accessors. Normally these are provided by the compiler, but in this case the compiler cannot provide them.  
  
 By providing your own accessors, you can specify whether the two events are represented by the same event in your class, or by different events. For example, if the events should be raised at different times according to the interface specifications, you can associate each event with a separate implementation in your class. In the following example, subscribers determine which `OnDraw` event they will receive by casting the shape reference to either an `IShape` or an `IDrawingObject`.  
  
 [!code[csProgGuideEvents#10](../events/codesnippet/CSharp/how-to--implement-interface-events--csharp-programming-guide-_1.cs)]  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Events](../events/events--csharp-programming-guide-.md)   
 [Delegates](../delegates/delegates--csharp-programming-guide-.md)   
 [Explicit Interface Implementation](../interfaces/explicit-interface-implementation--csharp-programming-guide-.md)   
 [How to: Raise Base Class Events in Derived Classes](../events/how-to--raise-base-class-events-in-derived-classes--csharp-programming-guide-.md)