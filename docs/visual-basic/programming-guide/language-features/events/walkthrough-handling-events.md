---
title: "Handling Events (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "event handling [Visual Basic], walkthroughs"
  - "walkthroughs [Visual Basic], event handling"
  - "variables [Visual Basic], WithEvents"
  - "events [Visual Basic], walkthroughs"
  - "WithEvents keyword [Visual Basic], walkthroughs"
  - "event handlers [Visual Basic], walkthroughs"
ms.assetid: f145b3fc-5ae0-4509-a2aa-1ff6934706bd
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
---
# Walkthrough: Handling Events (Visual Basic)
This is the second of two topics that demonstrate how to work with events. The first topic, [Walkthrough: Declaring and Raising Events](../../../../visual-basic/programming-guide/language-features/events/walkthrough-declaring-and-raising-events.md), shows how to declare and raise events. This section uses the form and class from that walkthrough to show how to handle events when they take place.  
  
 The `Widget` class example uses traditional event-handling statements. [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] provides other techniques for working with events. As an exercise, you can modify this example to use the `AddHandler` and `Handles` statements.  
  
### To handle the PercentDone event of the Widget class  
  
1.  Place the following code in `Form1`:  
  
     [!code-vb[VbVbcnWalkthroughDeclaringAndRaisingEvents#4](../../../../visual-basic/programming-guide/language-features/events/codesnippet/VisualBasic/walkthrough-handling-events_1.vb)]  
  
     The `WithEvents` keyword specifies that the variable `mWidget` is used to handle an object's events. You specify the kind of object by supplying the name of the class from which the object will be created.  
  
     The variable `mWidget` is declared in `Form1` because `WithEvents` variables must be class-level. This is true regardless of the type of class you place them in.  
  
     The variable `mblnCancel` is used to cancel the `LongTask` method.  
  
## Writing Code to Handle an Event  
 As soon as you declare a variable using `WithEvents`, the variable name appears in the left drop-down list of the class's **Code Editor**. When you select `mWidget`, the `Widget` class's events appear in the right drop-down list. Selecting an event displays the corresponding event procedure, with the prefix `mWidget` and an underscore. All the event procedures associated with a `WithEvents` variable are given the variable name as a prefix.  
  
#### To handle an event  
  
1.  Select `mWidget` from the left drop-down list in the **Code Editor**.  
  
2.  Select the `PercentDone` event from the right drop-down list. The **Code Editor** opens the `mWidget_PercentDone` event procedure.  
  
    > [!NOTE]
    >  The **Code Editor** is useful, but not required, for inserting new event handlers. In this walkthrough, it is more direct to just copy the event handlers directly into your code.  
  
3.  Add the following code to the `mWidget_PercentDone` event handler:  
  
     [!code-vb[VbVbcnWalkthroughDeclaringAndRaisingEvents#5](../../../../visual-basic/programming-guide/language-features/events/codesnippet/VisualBasic/walkthrough-handling-events_2.vb)]  
  
     Whenever the `PercentDone` event is raised, the event procedure displays the percent complete in a `Label` control. The `DoEvents` method allows the label to repaint, and also gives the user the opportunity to click the **Cancel** button.  
  
4.  Add the following code for the `Button2_Click` event handler:  
  
     [!code-vb[VbVbcnWalkthroughDeclaringAndRaisingEvents#6](../../../../visual-basic/programming-guide/language-features/events/codesnippet/VisualBasic/walkthrough-handling-events_3.vb)]  
  
 If the user clicks the **Cancel** button while `LongTask` is running, the `Button2_Click` event is executed as soon as the `DoEvents` statement allows event processing to occur. The class-level variable `mblnCancel` is set to `True`, and the `mWidget_PercentDone` event then tests it and sets the `ByRef Cancel` argument to `True`.  
  
## Connecting a WithEvents Variable to an Object  
 `Form1` is now set up to handle a `Widget` object's events. All that remains is to find a `Widget` somewhere.  
  
 When you declare a variable `WithEvents` at design time, no object is associated with it. A `WithEvents` variable is just like any other object variable. You have to create an object and assign a reference to it with the `WithEvents` variable.  
  
#### To create an object and assign a reference to it  
  
1.  Select **(Form1 Events)** from the left drop-down list in the **Code Editor**.  
  
2.  Select the `Load` event from the right drop-down list. The **Code Editor** opens the `Form1_Load` event procedure.  
  
3.  Add the following code for the `Form1_Load` event procedure to create the `Widget`:  
  
     [!code-vb[VbVbcnWalkthroughDeclaringAndRaisingEvents#7](../../../../visual-basic/programming-guide/language-features/events/codesnippet/VisualBasic/walkthrough-handling-events_4.vb)]  
  
 When this code executes, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] creates a `Widget` object and connects its events to the event procedures associated with `mWidget`. From that point on, whenever the `Widget` raises its `PercentDone` event, the `mWidget_PercentDone` event procedure is executed.  
  
#### To call the LongTask method  
  
-   Add the following code to the `Button1_Click` event handler:  
  
     [!code-vb[VbVbcnWalkthroughDeclaringAndRaisingEvents#8](../../../../visual-basic/programming-guide/language-features/events/codesnippet/VisualBasic/walkthrough-handling-events_5.vb)]  
  
 Before the `LongTask` method is called, the label that displays the percent complete must be initialized, and the class-level `Boolean` flag for canceling the method must be set to `False`.  
  
 `LongTask` is called with a task duration of 12.2 seconds. The `PercentDone` event is raised once every one-third of a second. Each time the event is raised, the `mWidget_PercentDone` event procedure is executed.  
  
 When `LongTask` is done, `mblnCancel` is tested to see if `LongTask` ended normally, or if it stopped because `mblnCancel` was set to `True`. The percent complete is updated only in the former case.  
  
#### To run the program  
  
1.  Press F5 to put the project in run mode.  
  
2.  Click the **Start Task** button. Each time the `PercentDone` event is raised, the label is updated with the percentage of the task that is complete.  
  
3.  Click the **Cancel** button to stop the task. Notice that the appearance of the **Cancel** button does not change immediately when you click it. The `Click` event cannot happen until the `My.Application.DoEvents` statement allows event processing.  
  
    > [!NOTE]
    >  The `My.Application.DoEvents` method does not process events in exactly the same way as the form does. For example, in this walkthrough, you must click the **Cancel** button twice. To allow the form to handle the events directly, you can use multithreading. For more information, see [Threading](http://msdn.microsoft.com/library/552f6c68-dbdb-4327-ae36-32cf9063d88c).  
  
 You may find it instructive to run the program with F11 and step through the code a line at a time. You can clearly see how execution enters `LongTask`, and then briefly re-enters `Form1` each time the `PercentDone` event is raised.  
  
 What would happen if, while execution was back in the code of `Form1`, the `LongTask` method were called again? At worst, a stack overflow might occur if `LongTask` were called every time the event was raised.  
  
 You can cause the variable `mWidget` to handle events for a different `Widget` object by assigning a reference to the new `Widget` to `mWidget`. In fact, you can make the code in `Button1_Click` do this every time you click the button.  
  
#### To handle events for a different widget  
  
-   Add the following line of code to the `Button1_Click` procedure, immediately preceding the line that reads `mWidget.LongTask(12.2, 0.33)`:  
  
     [!code-vb[VbVbcnWalkthroughDeclaringAndRaisingEvents#9](../../../../visual-basic/programming-guide/language-features/events/codesnippet/VisualBasic/walkthrough-handling-events_6.vb)]  
  
 The code above creates a new `Widget` each time the button is clicked. As soon as the `LongTask` method completes, the reference to the `Widget` is released, and the `Widget` is destroyed.  
  
 A `WithEvents` variable can contain only one object reference at a time, so if you assign a different `Widget` object to `mWidget`, the previous `Widget` object's events will no longer be handled. If `mWidget` is the only object variable containing a reference to the old `Widget`, the object is destroyed. If you want to handle events from several `Widget` objects, use the `AddHandler` statement to process events from each object separately.  
  
> [!NOTE]
>  You can declare as many `WithEvents` variables as you need, but arrays of `WithEvents` variables are not supported.  
  
## See Also  
 [Walkthrough: Declaring and Raising Events](../../../../visual-basic/programming-guide/language-features/events/walkthrough-declaring-and-raising-events.md)  
 [Events](../../../../visual-basic/programming-guide/language-features/events/index.md)
