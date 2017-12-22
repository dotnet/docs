---
title: "Asynchronous Programming Patterns"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "asynchronous design patterns, .NET Framework"
  - ".NET Framework, asynchronous design patterns"
ms.assetid: 4ece5c0b-f8fe-4114-9862-ac02cfe5a5d7
caps.latest.revision: 5
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---

# Asynchronous Programming Patterns

The .NET Framework provides three patterns for performing asynchronous operations:  
  
- Asynchronous Programming Model (APM) pattern (also called the <xref:System.IAsyncResult> pattern), where asynchronous operations require `Begin` and `End` methods (for example, `BeginWrite` and `EndWrite` for asynchronous write operations). This pattern is no longer recommended for new development. For more information, see [Asynchronous Programming Model (APM)](../../../docs/standard/asynchronous-programming-patterns/asynchronous-programming-model-apm.md).  
  
- Event-based Asynchronous Pattern (EAP), which requires a method that has the `Async` suffix, and also requires one or more events, event handler delegate types, and `EventArg`-derived types. EAP was introduced in the .NET Framework 2.0. It is no longer recommended for new development. For more information, see [Event-based Asynchronous Pattern (EAP)](../../../docs/standard/asynchronous-programming-patterns/event-based-asynchronous-pattern-eap.md).  
  
- Task-based Asynchronous Pattern (TAP), which uses a single method to represent the initiation and completion of an asynchronous operation. TAP was introduced in the .NET Framework 4 and is the recommended approach to asynchronous programming in the .NET Framework. The [async](~/docs/csharp/language-reference/keywords/async.md) and [await](~/docs/csharp/language-reference/keywords/await.md) keywords in C# and the [Async](~/docs/visual-basic/language-reference/modifiers/async.md) and [Await](~/docs/visual-basic/language-reference/operators/await-operator.md) operators in Visual Basic Language add language support for TAP. For more information, see [Task-based Asynchronous Pattern (TAP)](../../../docs/standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap.md).  
  
## Comparing Patterns  

For a quick comparison of how the three patterns model asynchronous operations, consider a `Read` method that reads a specified amount of data into a provided buffer starting at a specified offset:  
  
```csharp  
public class MyClass  
{  
    public int Read(byte [] buffer, int offset, int count);  
}  
```  
  
The APM counterpart of this method would expose the `BeginRead` and `EndRead` methods:  
  
```csharp  
public class MyClass  
{  
    public IAsyncResult BeginRead(  
        byte [] buffer, int offset, int count,   
        AsyncCallback callback, object state);  
    public int EndRead(IAsyncResult asyncResult);  
}  
```  
  
The EAP counterpart would expose the following set of types and members:  
  
```csharp  
public class MyClass  
{  
    public void ReadAsync(byte [] buffer, int offset, int count);  
    public event ReadCompletedEventHandler ReadCompleted;  
}  
```  
  
The TAP counterpart would expose the following single `ReadAsync` method:  
  
```csharp  
public class MyClass  
{  
    public Task<int> ReadAsync(byte [] buffer, int offset, int count);  
}  
```  
  
For a comprehensive discussion of TAP, APM, and EAP, see the links provided in the next section.  
  
## Related topics

| Title | Description |
| ----- | ----------- |
| [Asynchronous Programming Model (APM)](../../../docs/standard/asynchronous-programming-patterns/asynchronous-programming-model-apm.md) | Describes the legacy model that uses the <xref:System.IAsyncResult> interface to provide asynchronous behavior. This model is no longer recommended for new development. |
| [Event-based Asynchronous Pattern (EAP)](../../../docs/standard/asynchronous-programming-patterns/event-based-asynchronous-pattern-eap.md) | Describes the event-based legacy model for providing asynchronous behavior. This model is no longer recommended for new development. |
| [Task-based Asynchronous Pattern (TAP)](../../../docs/standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap.md) | Describes the new asynchronous pattern based on the <xref:System.Threading.Tasks> namespace. This model is the recommended approach to asynchronous programming in the .NET Framework 4 and later versions. |

## See also

[Asynchronous programming in C#](~/docs/csharp/async.md)   
[Async Programming in F#](~/docs/fsharp/tutorials/asynchronous-and-concurrent-programming/async.md)   
[Asynchronous Programming with Async and Await (Visual Basic)](~/docs/visual-basic/programming-guide/concepts/async/index.md)
