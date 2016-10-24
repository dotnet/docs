---
title: "Using Delegates (C# Programming Guide)"
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
  - "delegates [C#], how to use"
ms.assetid: 99a2fc27-a32e-4a34-921c-e65497520eec
caps.latest.revision: 18
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
# Using Delegates (C# Programming Guide)
A [delegate](../keywords/delegate--csharp-reference-.md) is a type that safely encapsulates a method, similar to a function pointer in C and C++. Unlike C function pointers, delegates are object-oriented, type safe, and secure. The type of a delegate is defined by the name of the delegate. The following example declares a delegate named `Del` that can encapsulate a method that takes a [string](../keywords/string--csharp-reference-.md) as an argument and returns [void](../keywords/void--csharp-reference-.md):  
  
 [!code[csProgGuideDelegates#21](../delegates/codesnippet/CSharp/using-delegates--csharp-programming-guide-_1.cs)]  
  
 A delegate object is normally constructed by providing the name of the method the delegate will wrap, or with an [anonymous Method](../statements-expressions-operators/anonymous-methods--csharp-programming-guide-.md). Once a delegate is instantiated, a method call made to the delegate will be passed by the delegate to that method. The parameters passed to the delegate by the caller are passed to the method, and the return value, if any, from the method is returned to the caller by the delegate. This is known as invoking the delegate. An instantiated delegate can be invoked as if it were the wrapped method itself. For example:  
  
 [!code[csProgGuideDelegates#22](../delegates/codesnippet/CSharp/using-delegates--csharp-programming-guide-_2.cs)]  
  
 [!code[csProgGuideDelegates#23](../delegates/codesnippet/CSharp/using-delegates--csharp-programming-guide-_3.cs)]  
  
 Delegate types are derived from the <xref:System.Delegate> class in the .NET Framework. Delegate types are [sealed](../keywords/sealed--csharp-reference-.md)—they cannot be derived from— and it is not possible to derive custom classes from <xref:System.Delegate>. Because the instantiated delegate is an object, it can be passed as a parameter, or assigned to a property. This allows a method to accept a delegate as a parameter, and call the delegate at some later time. This is known as an asynchronous callback, and is a common method of notifying a caller when a long process has completed. When a delegate is used in this fashion, the code using the delegate does not need any knowledge of the implementation of the method being used. The functionality is similar to the encapsulation interfaces provide.  
  
 Another common use of callbacks is defining a custom comparison method and passing that delegate to a sort method. It allows the caller's code to become part of the sort algorithm. The following example method uses the `Del` type as a parameter:  
  
 [!code[csProgGuideDelegates#24](../delegates/codesnippet/CSharp/using-delegates--csharp-programming-guide-_4.cs)]  
  
 You can then pass the delegate created above to that method:  
  
 [!code[csProgGuideDelegates#25](../delegates/codesnippet/CSharp/using-delegates--csharp-programming-guide-_5.cs)]  
  
 and receive the following output to the console:  
  
 `The number is: 3`  
  
 Using the delegate as an abstraction, `MethodWithCallback` does not need to call the console directly—it does not have to be designed with a console in mind. What `MethodWithCallback` does is simply prepare a string and pass the string to another method. This is especially powerful since a delegated method can use any number of parameters.  
  
 When a delegate is constructed to wrap an instance method, the delegate references both the instance and the method. A delegate has no knowledge of the instance type aside from the method it wraps, so a delegate can refer to any type of object as long as there is a method on that object that matches the delegate signature. When a delegate is constructed to wrap a static method, it only references the method. Consider the following declarations:  
  
 [!code[csProgGuideDelegates#26](../delegates/codesnippet/CSharp/using-delegates--csharp-programming-guide-_6.cs)]  
  
 Along with the static `DelegateMethod` shown previously, we now have three methods that can be wrapped by a `Del` instance.  
  
 A delegate can call more than one method when invoked. This is referred to as multicasting. To add an extra method to the delegate's list of methods—the invocation list—simply requires adding two delegates using the addition or addition assignment operators ('+' or '+='). For example:  
  
 [!code[csProgGuideDelegates#27](../delegates/codesnippet/CSharp/using-delegates--csharp-programming-guide-_7.cs)]  
  
 At this point `allMethodsDelegate` contains three methods in its invocation list—`Method1`, `Method2`, and `DelegateMethod`. The original three delegates, `d1`, `d2`, and `d3`, remain unchanged. When `allMethodsDelegate` is invoked, all three methods are called in order. If the delegate uses reference parameters, the reference is passed sequentially to each of the three methods in turn, and any changes by one method are visible to the next method. When any of the methods throws an exception that is not caught within the method, that exception is passed to the caller of the delegate and no subsequent methods in the invocation list are called. If the delegate has a return value and/or out parameters, it returns the return value and parameters of the last method invoked. To remove a method from the invocation list, use the decrement or decrement assignment operator ('-' or '-='). For example:  
  
 [!code[csProgGuideDelegates#28](../delegates/codesnippet/CSharp/using-delegates--csharp-programming-guide-_8.cs)]  
  
 Because delegate types are derived from `System.Delegate`, the methods and properties defined by that class can be called on the delegate. For example, to find the number of methods in a delegate's invocation list, you may write:  
  
 [!code[csProgGuideDelegates#29](../delegates/codesnippet/CSharp/using-delegates--csharp-programming-guide-_9.cs)]  
  
 Delegates with more than one method in their invocation list derive from <xref:System.MulticastDelegate>, which is a subclass of `System.Delegate`. The above code works in either case because both classes support `GetInvocationList`.  
  
 Multicast delegates are used extensively in event handling. Event source objects send event notifications to recipient objects that have registered to receive that event. To register for an event, the recipient creates a method designed to handle the event, then creates a delegate for that method and passes the delegate to the event source. The source calls the delegate when the event occurs. The delegate then calls the event handling method on the recipient, delivering the event data. The delegate type for a given event is defined by the event source. For more, see [Events](../events/events--csharp-programming-guide-.md).  
  
 Comparing delegates of two different types assigned at compile-time will result in a compilation error. If the delegate instances are statically of the type `System.Delegate`, then the comparison is allowed, but will return false at run time. For example:  
  
 [!code[csProgGuideDelegates#30](../delegates/codesnippet/CSharp/using-delegates--csharp-programming-guide-_10.cs)]  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Delegates](../delegates/delegates--csharp-programming-guide-.md)   
 [Using Variance in Delegates](../Topic/Using%20Variance%20in%20Delegates%20\(C%23%20and%20Visual%20Basic\).md)   
 [Variance in Delegates](../Topic/Variance%20in%20Delegates%20\(C%23%20and%20Visual%20Basic\).md)   
 [Using Variance for Func and Action Generic Delegates](../Topic/Using%20Variance%20for%20Func%20and%20Action%20Generic%20Delegates%20\(C%23%20and%20Visual%20Basic\).md)   
 [Events](../events/events--csharp-programming-guide-.md)