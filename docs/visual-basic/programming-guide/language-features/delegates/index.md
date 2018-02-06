---
title: "Delegates (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "delegates [Visual Basic]"
  - "Visual Basic code, delegates"
ms.assetid: 410b60dc-5e60-4ec0-bfae-426755a2ee28
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
---
# Delegates (Visual Basic)
Delegates are objects that refer to methods. They are sometimes described as *type-safe function pointers* because they are similar to function pointers used in other programming languages. But unlike function pointers, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] delegates are a reference type based on the class <xref:System.Delegate?displayProperty=nameWithType>. Delegates can reference both shared methods — methods that can be called without a specific instance of a class — and instance methods.  
  
## Delegates and Events  
 Delegates are useful in situations where you need an intermediary between a calling procedure and the procedure being called. For example, you might want an object that raises events to be able to call different event handlers under different circumstances. Unfortunately, the object raising the events cannot know ahead of time which event handler is handling a specific event. [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] lets you dynamically associate event handlers with events by creating a delegate for you when you use the `AddHandler` statement. At run time, the delegate forwards calls to the appropriate event handler.  
  
 Although you can create your own delegates, in most cases [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] creates the delegate and takes care of the details for you. For example, an `Event` statement implicitly defines a delegate class named `<EventName>EventHandler` as a nested class of the class containing the `Event` statement, and with the same signature as the event. The `AddressOf` statement implicitly creates an instance of a delegate that refers to a specific procedure. The following two lines of code are equivalent. In the first line, you see the explicit creation of an instance of `Eventhandler`, with a reference to method `Button1_Click` sent as the argument. The second line is a more convenient way to do the same thing.  
  
 [!code-vb[VbVbalrDelegates#6](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/delegates_1.vb)]  
  
 You can use the shorthand way of creating delegates anywhere the compiler can determine the delegate's type by the context.  
  
## Declaring Events that Use an Existing Delegate Type  
 In some situations, you may want to declare an event to use an existing delegate type as its underlying delegate. The following syntax demonstrates how:  
  
 [!code-vb[VbVbalrDelegates#7](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/delegates_2.vb)]  
  
 This is useful when you want to route multiple events to the same handler.  
  
## Delegate Variables and Parameters  
 You can use delegates for other, non-event related tasks, such as free threading or with procedures that need to call different versions of functions at run time.  
  
 For example, suppose you have a classified-ad application that includes a list box with the names of cars. The ads are sorted by title, which is normally the make of the car. A problem you may face occurs when some cars include the year of the car before the make. The problem is that the built-in sort functionality of the list box sorts only by character codes; it places all the ads starting with dates first, followed by the ads starting with the make.  
  
 To fix this, you can create a sort procedure in a class that uses the standard alphabetic sort on most list boxes, but is able to switch at run time to the custom sort procedure for car ads. To do this, you pass the custom sort procedure to the sort class at run time, using delegates.  
  
## AddressOf and Lambda Expressions  
 Each delegate class defines a constructor that is passed the specification of an object method. An argument to a delegate constructor must be a reference to a method, or a lambda expression.  
  
 To specify a reference to a method, use the following syntax:  
  
 `AddressOf` [`expression`.]`methodName`  
  
 The compile-time type of the `expression` must be the name of a class or an interface that contains a method of the specified name whose signature matches the signature of the delegate class. The `methodName` can be either a shared method or an instance method. The `methodName` is not optional, even if you create a delegate for the default method of the class.  
  
 To specify a lambda expression, use the following syntax:  
  
 `Function` ([`parm` As `type`, `parm2` As `type2`, ...]) `expression`  
  
 The following example shows both `AddressOf` and lambda expressions used to specify the reference for a delegate.  
  
 [!code-vb[VbVbalrDelegates#15](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/delegates_3.vb)]  
  
 The signature of the function must match that of the delegate type. For more information about lambda expressions, see [Lambda Expressions](../../../../visual-basic/programming-guide/language-features/procedures/lambda-expressions.md). For more examples of lambda expression and `AddressOf` assignments to delegates, see [Relaxed Delegate Conversion](../../../../visual-basic/programming-guide/language-features/delegates/relaxed-delegate-conversion.md).  
  
## Related Topics  
  
|Title|Description|  
|-----------|-----------------|  
|[How to: Invoke a Delegate Method](../../../../visual-basic/programming-guide/language-features/delegates/how-to-invoke-a-delegate-method.md)|Provides an example that shows how to associate a method with a delegate and then invoke that method through the delegate.|  
|[How to: Pass Procedures to Another Procedure in Visual Basic](../../../../visual-basic/programming-guide/language-features/delegates/how-to-pass-procedures-to-another-procedure.md)|Demonstrates how to use delegates to pass one procedure to another procedure.|  
|[Relaxed Delegate Conversion](../../../../visual-basic/programming-guide/language-features/delegates/relaxed-delegate-conversion.md)|Describes how you can assign subs and functions to delegates or handlers even when their signatures are not identical|  
|[Events](../../../../visual-basic/programming-guide/language-features/events/index.md)|Provides an overview of events in Visual Basic.|
