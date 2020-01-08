---
title: "How to implement interface events - C# Programming Guide"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "interfaces [C#], event implementation in classes"
  - "events [C#], in interfaces"
ms.assetid: 63527447-9535-4880-8e95-35e2075827df
---
# How to implement interface events (C# Programming Guide)
An [interface](../../language-reference/keywords/interface.md) can declare an [event](../../language-reference/keywords/event.md). The following example shows how to implement interface events in a class. Basically the rules are the same as when you implement any interface method or property.  
  
## To implement interface events in a class  
  
Declare the event in your class and then invoke it in the appropriate areas.  
  
```csharp
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
            ShapeChanged?.Invoke(this, e);  
        }  
    }  

}  
```  
  
## Example  
The following example shows how to handle the less-common situation in which your class inherits from two or more interfaces and each interface has an event with the same name. In this situation, you must provide an explicit interface implementation for at least one of the events. When you write an explicit interface implementation for an event, you must also write the `add` and `remove` event accessors. Normally these are provided by the compiler, but in this case the compiler cannot provide them.  
  
By providing your own accessors, you can specify whether the two events are represented by the same event in your class, or by different events. For example, if the events should be raised at different times according to the interface specifications, you can associate each event with a separate implementation in your class. In the following example, subscribers determine which `OnDraw` event they will receive by casting the shape reference to either an `IShape` or an `IDrawingObject`.  
  
 [!code-csharp[csProgGuideEvents#10](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideEvents/CS/Events.cs#10)]
  
## See also

- [C# Programming Guide](../index.md)
- [Events](./index.md)
- [Delegates](../delegates/index.md)
- [Explicit Interface Implementation](../interfaces/explicit-interface-implementation.md)
- [How to raise base class events in derived classes](./how-to-raise-base-class-events-in-derived-classes.md)
