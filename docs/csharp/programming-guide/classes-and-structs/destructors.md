---
title: "Finalizers - C# Programming Guide"
ms.custom: seodec18
ms.date: 10/08/2018
helpviewer_keywords: 
  - "~ [C#], in finalizers"
  - "C# language, finalizers"
  - "finalizers [C#]"
ms.assetid: 1ae6e46d-a4b1-4a49-abe5-b97f53d9e049
---
# Finalizers (C# Programming Guide)
Finalizers (which are also called **destructors**) are used to perform any necessary final clean-up when a class instance is being collected by the garbage collector.  
  
## Remarks  
  
- Finalizers cannot be defined in structs. They are only used with classes.  
  
- A class can only have one finalizer.  
  
- Finalizers cannot be inherited or overloaded.  
  
- Finalizers cannot be called. They are invoked automatically.  
  
- A finalizer does not take modifiers or have parameters.  
  
 For example, the following is a declaration of a finalizer for the `Car` class.
  
 [!code-csharp[csProgGuideObjects#86](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideObjects/CS/Objects.cs#86)]  

A finalizer can also be implemented as an expression body definition, as the following example shows.

[!code-csharp[expression-bodied-finalizer](../../../../samples/snippets/csharp/programming-guide/classes-and-structs/expr-bodied-destructor.cs#1)]  
  
 The finalizer implicitly calls <xref:System.Object.Finalize%2A> on the base class of the object. Therefore, a call to a finalizer is implicitly translated to the following code:  
  
```csharp  
protected override void Finalize()  
{  
    try  
    {  
        // Cleanup statements...  
    }  
    finally  
    {  
        base.Finalize();  
    }  
}  
```  
  
 This means that the `Finalize` method is called recursively for all instances in the inheritance chain, from the most-derived to the least-derived.  
  
> [!NOTE]
>  Empty finalizers should not be used. When a class contains a finalizer, an entry is created in the `Finalize` queue. When the finalizer is called, the garbage collector is invoked to process the queue. An empty finalizer just causes a needless loss of performance.  
  
 The programmer has no control over when the finalizer is called because this is determined by the garbage collector. The garbage collector checks for objects that are no longer being used by the application. If it considers an object eligible for finalization, it calls the finalizer (if any) and reclaims the memory used to store the object. 
 
 In .NET Framework applications (but not in .NET Core applications), finalizers are also called when the program exits. 
  
 It is possible to force garbage collection by calling <xref:System.GC.Collect%2A>, but most of the time, this should be avoided because it may create performance issues.  
  
## Using finalizers to release resources  
 In general, C# does not require as much memory management as is needed when you develop with a language that does not target a runtime with garbage collection. This is because the .NET Framework garbage collector implicitly manages the allocation and release of memory for your objects. However, when your application encapsulates unmanaged resources such as windows, files, and network connections, you should use finalizers to free those resources. When the object is eligible for finalization, the garbage collector runs the `Finalize` method of the object.  
  
## Explicit release of resources  
 If your application is using an expensive external resource, we also recommend that you provide a way to explicitly release the resource before the garbage collector frees the object. You do this by implementing a `Dispose` method from the <xref:System.IDisposable> interface that performs the necessary cleanup for the object. This can considerably improve the performance of the application. Even with this explicit control over resources, the finalizer becomes a safeguard to clean up resources if the call to the `Dispose` method failed.  
  
 For more details about cleaning up resources, see the following topics:  
  
- [Cleaning Up Unmanaged Resources](../../../standard/garbage-collection/unmanaged.md)  
  
- [Implementing a Dispose Method](../../../standard/garbage-collection/implementing-dispose.md)  
  
- [using Statement](../../language-reference/keywords/using-statement.md)  
  
## Example  
 The following example creates three classes that make a chain of inheritance. The class `First` is the base class, `Second` is derived from `First`, and `Third` is derived from `Second`. All three have finalizers. In `Main`, an instance of the most-derived class is created. When the program runs, notice that the finalizers for the three classes are called automatically, and in order, from the most-derived to the least-derived.  
  
 [!code-csharp[csProgGuideObjects#85](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideObjects/CS/Objects.cs#85)]  
  
## C# language specification  

For more information, see the [Destructors](~/_csharplang/spec/classes.md#destructors) section of the [C# language specification](../../language-reference/language-specification/index.md).
  
## See also

- <xref:System.IDisposable>
- [C# Programming Guide](../index.md)
- [Constructors](./constructors.md)
- [Garbage Collection](../../../standard/garbage-collection/index.md)
