---
title: "Dataflow (Task Parallel Library)"
ms.date: "03/30/2017"
ms.prod: ".net"
ms.technology: dotnet-standard
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "Task Parallel Library, dataflows"
  - "TPL dataflow library"
ms.assetid: 643575d0-d26d-4c35-8de7-a9c403e97dd6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Dataflow (Task Parallel Library)
<a name="top"></a> The Task Parallel Library (TPL) provides dataflow components to help increase the robustness of concurrency-enabled applications. These dataflow components are collectively referred to as the *TPL Dataflow Library*. This dataflow model promotes actor-based programming by providing in-process message passing for coarse-grained dataflow and pipelining tasks. The dataflow components build on the types and scheduling infrastructure of the TPL and integrate with the C#, [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)], and F# language support for asynchronous programming. These dataflow components are useful when you have multiple operations that must communicate with one another asynchronously or when you want to process data as it becomes available. For example, consider an application that processes image data from a web camera. By using the dataflow model, the application can process image frames as they become available. If the application enhances image frames, for example, by performing light correction or red-eye reduction, you can create a *pipeline* of dataflow components. Each stage of the pipeline might use more coarse-grained parallelism functionality, such as the functionality that is provided by the TPL, to transform the image.  
  
 This document provides an overview of the TPL Dataflow Library. It describes the programming model, the predefined dataflow block types, and how to configure dataflow blocks to meet the specific requirements of your applications.  

[!INCLUDE [tpl-install-instructions](../../../includes/tpl-install-instructions.md)]
  
 This document contains the following sections:  
  
-   [Programming Model](#model)  
  
-   [Predefined Dataflow Block Types](#predefined_types)  
  
-   [Configuring Dataflow Block Behavior](#behavior)  
  
-   [Custom Dataflow Blocks](#custom)  
  
<a name="model"></a>   
## Programming Model  
 The TPL Dataflow Library provides a foundation for message passing and parallelizing CPU-intensive and I/O-intensive applications that have high throughput and low latency. It also gives you explicit control over how data is buffered and moves around the system. To better understand the dataflow programming model, consider an application that asynchronously loads images from disk and creates a composite of those images. Traditional programming models typically require that you use callbacks and synchronization objects, such as locks, to coordinate tasks and access to shared data. By using the dataflow programming model, you can create dataflow objects that process images as they are read from disk. Under the dataflow model, you declare how data is handled when it becomes available, and also any dependencies between data. Because the runtime manages dependencies between data, you can often avoid the requirement to synchronize access to shared data. In addition, because the runtime schedules work based on the asynchronous arrival of data, dataflow can improve responsiveness and throughput by efficiently managing the underlying threads. For an example that uses the dataflow programming model to implement image processing in a Windows Forms application, see [Walkthrough: Using Dataflow in a Windows Forms Application](../../../docs/standard/parallel-programming/walkthrough-using-dataflow-in-a-windows-forms-application.md).  
  
### Sources and Targets  
 The TPL Dataflow Library consists of *dataflow blocks*, which are data structures that buffer and process data. The TPL defines three kinds of dataflow blocks: *source blocks*, *target blocks*, and *propagator blocks*. A source block acts as a source of data and can be read from. A target block acts as a receiver of data and can be written to. A propagator block acts as both a source block and a target block, and can be read from and written to. The TPL defines the <xref:System.Threading.Tasks.Dataflow.ISourceBlock%601?displayProperty=nameWithType> interface to represent sources, <xref:System.Threading.Tasks.Dataflow.ITargetBlock%601?displayProperty=nameWithType> to represent targets, and <xref:System.Threading.Tasks.Dataflow.IPropagatorBlock%602?displayProperty=nameWithType> to represent propagators. <xref:System.Threading.Tasks.Dataflow.IPropagatorBlock%602> inherits from both <xref:System.Threading.Tasks.Dataflow.ISourceBlock%601>, and <xref:System.Threading.Tasks.Dataflow.ITargetBlock%601>.  
  
 The TPL Dataflow Library provides several predefined dataflow block types that implement the <xref:System.Threading.Tasks.Dataflow.ISourceBlock%601>, <xref:System.Threading.Tasks.Dataflow.ITargetBlock%601>, and <xref:System.Threading.Tasks.Dataflow.IPropagatorBlock%602> interfaces. These dataflow block types are described in this document in the section [Predefined Dataflow Block Types](#predefined_types).  
  
### Connecting Blocks  
 You can connect dataflow blocks to form *pipelines*, which are linear sequences of dataflow blocks, or *networks*, which are graphs of dataflow blocks. A pipeline is one form of network. In a pipeline or network, sources asynchronously propagate data to targets as that data becomes available. The <xref:System.Threading.Tasks.Dataflow.ISourceBlock%601.LinkTo%2A?displayProperty=nameWithType> method links a source dataflow block to a target block. A source can be linked to zero or more targets; targets can be linked from zero or more sources. You can add or remove dataflow blocks to or from a pipeline or network concurrently. The predefined dataflow block types handle all thread-safety aspects of linking and unlinking.  
  
 For an example that connects dataflow blocks to form a basic pipeline, see [Walkthrough: Creating a Dataflow Pipeline](../../../docs/standard/parallel-programming/walkthrough-creating-a-dataflow-pipeline.md). For an example that connects dataflow blocks to form a more complex network, see [Walkthrough: Using Dataflow in a Windows Forms Application](../../../docs/standard/parallel-programming/walkthrough-using-dataflow-in-a-windows-forms-application.md). For an example that unlinks a target from a source after the source offers the target a message, see [How to: Unlink Dataflow Blocks](../../../docs/standard/parallel-programming/how-to-unlink-dataflow-blocks.md).  
  
#### Filtering  
 When you call the <xref:System.Threading.Tasks.Dataflow.ISourceBlock%601.LinkTo%2A?displayProperty=nameWithType> method to link a source to a target, you can supply a delegate that determines whether the target block accepts or rejects a message based on the value of that message. This filtering mechanism is a useful way to guarantee that a dataflow block receives only certain values. For most of the predefined dataflow block types, if a source block is connected to multiple target blocks, when a target block rejects a message, the source offers that message to the next target. The order in which a source offers messages to targets is defined by the source and can vary according to the type of the source. Most source block types stop offering a message after one target accepts that message. One exception to this rule is the <xref:System.Threading.Tasks.Dataflow.BroadcastBlock%601> class, which offers each message to all targets, even if some targets reject the message. For an example that uses filtering to process only certain messages, see [Walkthrough: Using Dataflow in a Windows Forms Application](../../../docs/standard/parallel-programming/walkthrough-using-dataflow-in-a-windows-forms-application.md).  
  
> [!IMPORTANT]
>  Because each predefined source dataflow block type guarantees that messages are propagated out in the order in which they are received, every message must be read from the source block before the source block can process the next message. Therefore, when you use filtering to connect multiple targets to a source, make sure that at least one target block receives each message. Otherwise, your application might deadlock.  
  
### Message Passing  
 The dataflow programming model is related to the concept of *message passing*, where independent components of a program communicate with one another by sending messages. One way to propagate messages among application components is to call the <xref:System.Threading.Tasks.Dataflow.DataflowBlock.Post%2A> and <xref:System.Threading.Tasks.Dataflow.DataflowBlock.SendAsync%2A?displayProperty=nameWithType> methods to send messages to target dataflow blocks post (<xref:System.Threading.Tasks.Dataflow.DataflowBlock.Post%2A> acts synchronously; <xref:System.Threading.Tasks.Dataflow.DataflowBlock.SendAsync%2A> acts asynchronously) and the <xref:System.Threading.Tasks.Dataflow.DataflowBlock.Receive%2A>, <xref:System.Threading.Tasks.Dataflow.DataflowBlock.ReceiveAsync%2A>, and <xref:System.Threading.Tasks.Dataflow.DataflowBlock.TryReceive%2A> methods to receive messages from source blocks. You can combine these methods with dataflow pipelines or networks by sending input data to the head node (a target block), and receiving output data from the terminal node of the pipeline or the terminal nodes of the network (one or more source blocks). You can also use the <xref:System.Threading.Tasks.Dataflow.DataflowBlock.Choose%2A> method to read from the first of the provided sources that has data available and perform action on that data.  
  
 Source blocks offer data to target blocks by calling the <xref:System.Threading.Tasks.Dataflow.ITargetBlock%601.OfferMessage%2A?displayProperty=nameWithType> method. The target block responds to an offered message in one of three ways: it can accept the message, decline the message, or postpone the message. When the target accepts the message, the <xref:System.Threading.Tasks.Dataflow.ITargetBlock%601.OfferMessage%2A> method returns <xref:System.Threading.Tasks.Dataflow.DataflowMessageStatus.Accepted>. When the target declines the message, the <xref:System.Threading.Tasks.Dataflow.ITargetBlock%601.OfferMessage%2A> method returns <xref:System.Threading.Tasks.Dataflow.DataflowMessageStatus.Declined>. When the target requires that it no longer receives any messages from the source, <xref:System.Threading.Tasks.Dataflow.ITargetBlock%601.OfferMessage%2A> returns <xref:System.Threading.Tasks.Dataflow.DataflowMessageStatus.DecliningPermanently>. The predefined source block types do not offer messages to linked targets after such a return value is received, and they automatically unlink from such targets.  
  
 When a target block postpones the message for later use, the <xref:System.Threading.Tasks.Dataflow.ITargetBlock%601.OfferMessage%2A> method returns <xref:System.Threading.Tasks.Dataflow.DataflowMessageStatus.Postponed>. A target block that postpones a message can later call the <xref:System.Threading.Tasks.Dataflow.ISourceBlock%601.ReserveMessage%2A?displayProperty=nameWithType> method to try to reserve the offered message. At this point, the message is either still available and can be used by the target block, or the message has been taken by another target. When the target block later requires the message or no longer needs the message, it calls the <xref:System.Threading.Tasks.Dataflow.ISourceBlock%601.ConsumeMessage%2A?displayProperty=nameWithType> or <xref:System.Threading.Tasks.Dataflow.ISourceBlock%601.ReleaseReservation%2A> method, respectively. Message reservation is typically used by the dataflow block types that operate in non-greedy mode. Non-greedy mode is explained later in this document. Instead of reserving a postponed message, a target block can also use the <xref:System.Threading.Tasks.Dataflow.ISourceBlock%601.ConsumeMessage%2A?displayProperty=nameWithType> method to attempt to directly consume the postponed message.  
  
### Dataflow Block Completion  
 Dataflow blocks also support the concept of *completion*. A dataflow block that is in the completed state does not perform any further work. Each dataflow block has an associated <xref:System.Threading.Tasks.Task?displayProperty=nameWithType> object, known as a *completion task*, that represents the completion status of the block. Because you can wait for a <xref:System.Threading.Tasks.Task> object to finish, by using completion tasks, you can wait for one or more terminal nodes of a dataflow network to finish. The <xref:System.Threading.Tasks.Dataflow.IDataflowBlock> interface defines the <xref:System.Threading.Tasks.Dataflow.IDataflowBlock.Complete%2A> method, which informs the dataflow block of a request for it to complete, and the <xref:System.Threading.Tasks.Dataflow.IDataflowBlock.Completion%2A> property, which returns the completion task for the dataflow block. Both <xref:System.Threading.Tasks.Dataflow.ISourceBlock%601> and <xref:System.Threading.Tasks.Dataflow.ITargetBlock%601> inherit the <xref:System.Threading.Tasks.Dataflow.IDataflowBlock> interface.  
  
 There are two ways to determine whether a dataflow block completed without error, encountered one or more errors, or was canceled. The first way is to call the <xref:System.Threading.Tasks.Task.Wait%2A?displayProperty=nameWithType> method on the completion task in a `try`-`catch` block (`Try`-`Catch` in Visual Basic). The following example creates an <xref:System.Threading.Tasks.Dataflow.ActionBlock%601> object that throws <xref:System.ArgumentOutOfRangeException> if its input value is less than zero. <xref:System.AggregateException> is thrown when this example calls <xref:System.Threading.Tasks.Task.Wait%2A> on the completion task. The <xref:System.ArgumentOutOfRangeException> is accessed through the <xref:System.AggregateException.InnerExceptions%2A> property of the <xref:System.AggregateException> object.  
  
 [!code-csharp[TPLDataflow_Overview#10](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_overview/cs/program.cs#10)]
 [!code-vb[TPLDataflow_Overview#10](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_overview/vb/program.vb#10)]  
  
 This example demonstrates the case in which an exception goes unhandled in the delegate of an execution dataflow block. We recommend that you handle exceptions in the bodies of such blocks. However, if you are unable to do so, the block behaves as though it was canceled and does not process incoming messages.  
  
 When a dataflow block is canceled explicitly, the <xref:System.AggregateException> object contains <xref:System.OperationCanceledException> in the <xref:System.AggregateException.InnerExceptions%2A> property. For more information about dataflow cancellation, see Enabling Cancellation later in this document.  
  
 The second way to determine the completion status of a dataflow block is to use a continuation off of the completion task, or to use the asynchronous language features of C# and Visual Basic to asynchronously wait for the completion task. The delegate that you provide to the <xref:System.Threading.Tasks.Task.ContinueWith%2A?displayProperty=nameWithType> method takes a <xref:System.Threading.Tasks.Task> object that represents the antecedent task. In the case of the <xref:System.Threading.Tasks.Dataflow.IDataflowBlock.Completion%2A> property, the delegate for the continuation takes the completion task itself. The following example resembles the previous one, except that it also uses the <xref:System.Threading.Tasks.Task.ContinueWith%2A> method to create a completion task that prints the status of the overall dataflow operation.  
  
 [!code-csharp[TPLDataflow_Overview#11](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_overview/cs/program.cs#11)]
 [!code-vb[TPLDataflow_Overview#11](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_overview/vb/program.vb#11)]  
  
 You can also use properties such as <xref:System.Threading.Tasks.Task.IsCanceled%2A> in the body of the continuation task to determine additional information about the completion status of a dataflow block. For more information about continuation tasks and how they relate to cancellation and error handling, see [Chaining Tasks by Using Continuation Tasks](../../../docs/standard/parallel-programming/chaining-tasks-by-using-continuation-tasks.md), [Task Cancellation](../../../docs/standard/parallel-programming/task-cancellation.md), [Exception Handling](../../../docs/standard/parallel-programming/exception-handling-task-parallel-library.md), and [NIB: How to: Handle Exceptions Thrown by Tasks](https://msdn.microsoft.com/library/d6c47ec8-9de9-4880-beb3-ff19ae51565d).  
  
 [[go to top](#top)]  
  
<a name="predefined_types"></a>   
## Predefined Dataflow Block Types  
 The TPL Dataflow Library provides several predefined dataflow block types. These types are divided into three categories: *buffering blocks*, *execution blocks*, and *grouping blocks*. The following sections describe the block types that make up these categories.  
  
### Buffering Blocks  
 Buffering blocks hold data for use by data consumers. The TPL Dataflow Library provides three buffering block types: <xref:System.Threading.Tasks.Dataflow.BufferBlock%601?displayProperty=nameWithType>, <xref:System.Threading.Tasks.Dataflow.BroadcastBlock%601?displayProperty=nameWithType>, and <xref:System.Threading.Tasks.Dataflow.WriteOnceBlock%601?displayProperty=nameWithType>.  
  
#### BufferBlock(T)  
 The <xref:System.Threading.Tasks.Dataflow.BufferBlock%601> class represents a general-purpose asynchronous messaging structure. This class stores a first in, first out (FIFO) queue of messages that can be written to by multiple sources or read from by multiple targets. When a target receives a message from a <xref:System.Threading.Tasks.Dataflow.BufferBlock%601> object, that message is removed from the message queue. Therefore, although a <xref:System.Threading.Tasks.Dataflow.BufferBlock%601> object can have multiple targets, only one target will receive each message. The <xref:System.Threading.Tasks.Dataflow.BufferBlock%601> class is useful when you want to pass multiple messages to another component, and that component must receive each message.  
  
 The following basic example posts several <xref:System.Int32> values to a <xref:System.Threading.Tasks.Dataflow.BufferBlock%601> object and then reads those values back from that object.  
  
 [!code-csharp[TPLDataflow_Overview#1](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_overview/cs/program.cs#1)]
 [!code-vb[TPLDataflow_Overview#1](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_overview/vb/program.vb#1)]  
  
 For a complete example that demonstrates how to write messages to and read messages from a <xref:System.Threading.Tasks.Dataflow.BufferBlock%601> object, see [How to: Write Messages to and Read Messages from a Dataflow Block](../../../docs/standard/parallel-programming/how-to-write-messages-to-and-read-messages-from-a-dataflow-block.md).  
  
#### BroadcastBlock(T)  
 The <xref:System.Threading.Tasks.Dataflow.BroadcastBlock%601> class is useful when you must pass multiple messages to another component, but that component needs only the most recent value. This class is also useful when you want to broadcast a message to multiple components.  
  
 The following basic example posts a <xref:System.Double> value to a <xref:System.Threading.Tasks.Dataflow.BroadcastBlock%601> object and then reads that value back from that object several times. Because values are not removed from <xref:System.Threading.Tasks.Dataflow.BroadcastBlock%601> objects after they are read, the same value is available every time.  
  
 [!code-csharp[TPLDataflow_Overview#2](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_overview/cs/program.cs#2)]
 [!code-vb[TPLDataflow_Overview#2](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_overview/vb/program.vb#2)]  
  
 For a complete example that demonstrates how to use <xref:System.Threading.Tasks.Dataflow.BroadcastBlock%601> to broadcast a message to multiple target blocks, see [How to: Specify a Task Scheduler in a Dataflow Block](../../../docs/standard/parallel-programming/how-to-specify-a-task-scheduler-in-a-dataflow-block.md).  
  
#### WriteOnceBlock(T)  
 The <xref:System.Threading.Tasks.Dataflow.WriteOnceBlock%601> class resembles the <xref:System.Threading.Tasks.Dataflow.BroadcastBlock%601> class, except that a <xref:System.Threading.Tasks.Dataflow.WriteOnceBlock%601> object can be written to one time only. You can think of <xref:System.Threading.Tasks.Dataflow.WriteOnceBlock%601> as being similar to the C# [readonly](~/docs/csharp/language-reference/keywords/readonly.md) ([ReadOnly](~/docs/visual-basic/language-reference/modifiers/readonly.md) in [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)]) keyword, except that a <xref:System.Threading.Tasks.Dataflow.WriteOnceBlock%601> object becomes immutable after it receives a value instead of at construction. Like the <xref:System.Threading.Tasks.Dataflow.BroadcastBlock%601> class, when a target receives a message from a <xref:System.Threading.Tasks.Dataflow.WriteOnceBlock%601> object, that message is not removed from that object. Therefore, multiple targets receive a copy of the message. The <xref:System.Threading.Tasks.Dataflow.WriteOnceBlock%601> class is useful when you want to propagate only the first of multiple messages.  
  
 The following basic example posts multiple <xref:System.String> values to a <xref:System.Threading.Tasks.Dataflow.WriteOnceBlock%601> object and then reads the value back from that object. Because a <xref:System.Threading.Tasks.Dataflow.WriteOnceBlock%601> object can be written to one time only, after a <xref:System.Threading.Tasks.Dataflow.WriteOnceBlock%601> object receives a message, it discards subsequent messages.  
  
 [!code-csharp[TPLDataflow_Overview#3](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_overview/cs/program.cs#3)]
 [!code-vb[TPLDataflow_Overview#3](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_overview/vb/program.vb#3)]  
  
 For a complete example that demonstrates how to use <xref:System.Threading.Tasks.Dataflow.WriteOnceBlock%601> to receive the value of the first operation that finishes, see [How to: Unlink Dataflow Blocks](../../../docs/standard/parallel-programming/how-to-unlink-dataflow-blocks.md).  
  
### Execution Blocks  
 Execution blocks call a user-provided delegate for each piece of received data. The TPL Dataflow Library provides three execution block types: <xref:System.Threading.Tasks.Dataflow.ActionBlock%601>, <xref:System.Threading.Tasks.Dataflow.TransformBlock%602?displayProperty=nameWithType>, and <xref:System.Threading.Tasks.Dataflow.TransformManyBlock%602?displayProperty=nameWithType>.  
  
#### ActionBlock(T)  
 The <xref:System.Threading.Tasks.Dataflow.ActionBlock%601> class is a target block that calls a delegate when it receives data. Think of a <xref:System.Threading.Tasks.Dataflow.ActionBlock%601> object as a delegate that runs asynchronously when data becomes available. The delegate that you provide to an <xref:System.Threading.Tasks.Dataflow.ActionBlock%601> object can be of type <xref:System.Action> or type `System.Func\<TInput, Task>`. When you use an <xref:System.Threading.Tasks.Dataflow.ActionBlock%601> object with <xref:System.Action>, processing of each input element is considered completed when the delegate returns. When you use an <xref:System.Threading.Tasks.Dataflow.ActionBlock%601> object with `System.Func\<TInput, Task>`, processing of each input element is considered completed only when the returned <xref:System.Threading.Tasks.Task> object is completed. By using these two mechanisms, you can use <xref:System.Threading.Tasks.Dataflow.ActionBlock%601> for both synchronous and asynchronous processing of each input element.  
  
 The following basic example posts multiple <xref:System.Int32> values to an <xref:System.Threading.Tasks.Dataflow.ActionBlock%601> object. The <xref:System.Threading.Tasks.Dataflow.ActionBlock%601> object prints those values to the console. This example then sets the block to the completed state and waits for all dataflow tasks to finish.  
  
 [!code-csharp[TPLDataflow_Overview#4](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_overview/cs/program.cs#4)]
 [!code-vb[TPLDataflow_Overview#4](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_overview/vb/program.vb#4)]  
  
 For complete examples that demonstrate how to use delegates with the <xref:System.Threading.Tasks.Dataflow.ActionBlock%601> class, see [How to: Perform Action When a Dataflow Block Receives Data](../../../docs/standard/parallel-programming/how-to-perform-action-when-a-dataflow-block-receives-data.md).  
  
#### TransformBlock(TInput, TOutput)  
 The <xref:System.Threading.Tasks.Dataflow.TransformBlock%602> class resembles the <xref:System.Threading.Tasks.Dataflow.ActionBlock%601> class, except that it acts as both a source and as a target. The delegate that you pass to a <xref:System.Threading.Tasks.Dataflow.TransformBlock%602> object returns a value of type `TOutput`. The delegate that you provide to a <xref:System.Threading.Tasks.Dataflow.TransformBlock%602> object can be of type `System.Func<TInput, TOutput>` or type `System.Func<TInput, Task>`. When you use a <xref:System.Threading.Tasks.Dataflow.TransformBlock%602> object with `System.Func\<TInput, TOutput>`, processing of each input element is considered completed when the delegate returns. When you use a <xref:System.Threading.Tasks.Dataflow.TransformBlock%602> object used with `System.Func<TInput, Task<TOutput>>`, processing of each input element is considered completed only when the returned <xref:System.Threading.Tasks.Task> object is completed. As with <xref:System.Threading.Tasks.Dataflow.ActionBlock%601>, by using these two mechanisms, you can use <xref:System.Threading.Tasks.Dataflow.TransformBlock%602> for both synchronous and asynchronous processing of each input element.  
  
 The following basic example creates a <xref:System.Threading.Tasks.Dataflow.TransformBlock%602> object that computes the square root of its input. The <xref:System.Threading.Tasks.Dataflow.TransformBlock%602> object takes <xref:System.Int32> values as input and produces <xref:System.Double> values as output.  
  
 [!code-csharp[TPLDataflow_Overview#5](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_overview/cs/program.cs#5)]
 [!code-vb[TPLDataflow_Overview#5](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_overview/vb/program.vb#5)]  
  
 For complete examples that uses <xref:System.Threading.Tasks.Dataflow.TransformBlock%602> in a network of dataflow blocks that performs image processing in a Windows Forms application, see [Walkthrough: Using Dataflow in a Windows Forms Application](../../../docs/standard/parallel-programming/walkthrough-using-dataflow-in-a-windows-forms-application.md).  
  
#### TransformManyBlock(TInput, TOutput)  
 The <xref:System.Threading.Tasks.Dataflow.TransformManyBlock%602> class resembles the <xref:System.Threading.Tasks.Dataflow.TransformBlock%602> class, except that <xref:System.Threading.Tasks.Dataflow.TransformManyBlock%602> produces zero or more output values for each input value, instead of only one output value for each input value. The delegate that you provide to a <xref:System.Threading.Tasks.Dataflow.TransformManyBlock%602> object can be of type `System.Func<TInput, IEnumerable<TOutput>>` or `type System.Func<TInput, Task<IEnumerable<TOutput>>>`. When you use a <xref:System.Threading.Tasks.Dataflow.TransformManyBlock%602> object with `System.Func<TInput, IEnumerable<TOutput>>`, processing of each input element is considered completed when the delegate returns. When you use a <xref:System.Threading.Tasks.Dataflow.TransformManyBlock%602> object with `System.Func<TInput, Task<IEnumerable<TOutput>>>`, processing of each input element is considered complete only when the returned `System.Threading.Tasks.Task<IEnumerable<TOutput>>` object is completed.  
  
 The following basic example creates a <xref:System.Threading.Tasks.Dataflow.TransformManyBlock%602> object that splits strings into their individual character sequences. The <xref:System.Threading.Tasks.Dataflow.TransformManyBlock%602> object takes <xref:System.String> values as input and produces <xref:System.Char> values as output.  
  
 [!code-csharp[TPLDataflow_Overview#6](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_overview/cs/program.cs#6)]
 [!code-vb[TPLDataflow_Overview#6](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_overview/vb/program.vb#6)]  
  
 For complete examples that use <xref:System.Threading.Tasks.Dataflow.TransformManyBlock%602> to produce multiple independent outputs for each input in a dataflow pipeline, see [Walkthrough: Creating a Dataflow Pipeline](../../../docs/standard/parallel-programming/walkthrough-creating-a-dataflow-pipeline.md).  
  
#### Degree of Parallelism  
 Every <xref:System.Threading.Tasks.Dataflow.ActionBlock%601>, <xref:System.Threading.Tasks.Dataflow.TransformBlock%602>, and <xref:System.Threading.Tasks.Dataflow.TransformManyBlock%602> object buffers input messages until the block is ready to process them. By default, these classes process messages in the order in which they are received, one message at a time. You can also specify the degree of parallelism to enable <xref:System.Threading.Tasks.Dataflow.ActionBlock%601>, <xref:System.Threading.Tasks.Dataflow.TransformBlock%602> and <xref:System.Threading.Tasks.Dataflow.TransformManyBlock%602> objects to process multiple messages concurrently. For more information about concurrent execution, see the section Specifying the Degree of Parallelism later in this document. For an example that sets the degree of parallelism to enable an execution dataflow block to process more than one message at a time, see [How to: Specify the Degree of Parallelism in a Dataflow Block](../../../docs/standard/parallel-programming/how-to-specify-the-degree-of-parallelism-in-a-dataflow-block.md).  
  
#### Summary of Delegate Types  
 The following table summarizes the delegate types that you can provide to <xref:System.Threading.Tasks.Dataflow.ActionBlock%601>, <xref:System.Threading.Tasks.Dataflow.TransformBlock%602>, and <xref:System.Threading.Tasks.Dataflow.TransformManyBlock%602> objects. This table also specifies whether the delegate type operates synchronously or asynchronously.  
  
|Type|Synchronous Delegate Type|Asynchronous Delegate Type|  
|----------|-------------------------------|--------------------------------|  
|<xref:System.Threading.Tasks.Dataflow.ActionBlock%601>|`System.Action`|`System.Func<TInput, Task>`|  
|<xref:System.Threading.Tasks.Dataflow.TransformBlock%602>|`System.Func<TInput, TOutput>`|`System.Func<TInput, Task<TOutput>>`|  
|<xref:System.Threading.Tasks.Dataflow.TransformManyBlock%602>|`System.Func<TInput, IEnumerable<TOutput>>`|`System.Func<TInput, Task<IEnumerable<TOutput>>>`|  
  
 You can also use lambda expressions when you work with execution block types. For an example that shows how to use a lambda expression with an execution block, see [How to: Perform Action When a Dataflow Block Receives Data](../../../docs/standard/parallel-programming/how-to-perform-action-when-a-dataflow-block-receives-data.md).  
  
### Grouping Blocks  
 Grouping blocks combine data from one or more sources and under various constraints. The TPL Dataflow Library provides three join block types: <xref:System.Threading.Tasks.Dataflow.BatchBlock%601>, <xref:System.Threading.Tasks.Dataflow.JoinBlock%602>, and <xref:System.Threading.Tasks.Dataflow.BatchedJoinBlock%602>.  
  
#### BatchBlock(T)  
 The <xref:System.Threading.Tasks.Dataflow.BatchBlock%601> class combines sets of input data, which are known as batches, into arrays of output data. You specify the size of each batch when you create a <xref:System.Threading.Tasks.Dataflow.BatchBlock%601> object. When the <xref:System.Threading.Tasks.Dataflow.BatchBlock%601> object receives the specified count of input elements, it asynchronously propagates out an array that contains those elements. If a <xref:System.Threading.Tasks.Dataflow.BatchBlock%601> object is set to the completed state but does not contain enough elements to form a batch, it propagates out a final array that contains the remaining input elements.  
  
 The <xref:System.Threading.Tasks.Dataflow.BatchBlock%601> class operates in either *greedy* or *non-greedy* mode. In greedy mode, which is the default, a <xref:System.Threading.Tasks.Dataflow.BatchBlock%601> object accepts every message that it is offered and propagates out an array after it receives the specified count of elements. In non-greedy mode, a <xref:System.Threading.Tasks.Dataflow.BatchBlock%601> object postpones all incoming messages until enough sources have offered messages to the block to form a batch. Greedy mode typically performs better than non-greedy mode because it requires less processing overhead. However, you can use non-greedy mode when you must coordinate consumption from multiple sources in an atomic fashion. Specify non-greedy mode by setting <xref:System.Threading.Tasks.Dataflow.GroupingDataflowBlockOptions.Greedy%2A> to `False` in the `dataflowBlockOptions` parameter in the <xref:System.Threading.Tasks.Dataflow.BatchBlock%601.%23ctor%2A> constructor.  
  
 The following basic example posts several <xref:System.Int32> values to a <xref:System.Threading.Tasks.Dataflow.BatchBlock%601> object that holds ten elements in a batch. To guarantee that all values propagate out of the <xref:System.Threading.Tasks.Dataflow.BatchBlock%601>, this example calls the <xref:System.Threading.Tasks.Dataflow.IDataflowBlock.Complete%2A> method. The <xref:System.Threading.Tasks.Dataflow.IDataflowBlock.Complete%2A> method sets the <xref:System.Threading.Tasks.Dataflow.BatchBlock%601> object to the completed state, and therefore, the <xref:System.Threading.Tasks.Dataflow.BatchBlock%601> object propagates out any remaining elements as a final batch.  
  
 [!code-csharp[TPLDataflow_Overview#7](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_overview/cs/program.cs#7)]
 [!code-vb[TPLDataflow_Overview#7](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_overview/vb/program.vb#7)]  
  
 For a complete example that uses <xref:System.Threading.Tasks.Dataflow.BatchBlock%601> to improve the efficiency of database insert operations, see [Walkthrough: Using BatchBlock and BatchedJoinBlock to Improve Efficiency](../../../docs/standard/parallel-programming/walkthrough-using-batchblock-and-batchedjoinblock-to-improve-efficiency.md).  
  
#### JoinBlock(T1, T2, ...)  
 The <xref:System.Threading.Tasks.Dataflow.JoinBlock%602> and <xref:System.Threading.Tasks.Dataflow.JoinBlock%603> classes collect input elements and propagate out <xref:System.Tuple%602?displayProperty=nameWithType> or <xref:System.Tuple%603?displayProperty=nameWithType> objects that contain those elements. The <xref:System.Threading.Tasks.Dataflow.JoinBlock%602> and <xref:System.Threading.Tasks.Dataflow.JoinBlock%603> classes do not inherit from <xref:System.Threading.Tasks.Dataflow.ITargetBlock%601>. Instead, they provide properties, <xref:System.Threading.Tasks.Dataflow.JoinBlock%602.Target1%2A>, <xref:System.Threading.Tasks.Dataflow.JoinBlock%602.Target2%2A>, and <xref:System.Threading.Tasks.Dataflow.JoinBlock%603.Target3%2A>, that implement <xref:System.Threading.Tasks.Dataflow.ITargetBlock%601>.  
  
 Like <xref:System.Threading.Tasks.Dataflow.BatchBlock%601>, <xref:System.Threading.Tasks.Dataflow.JoinBlock%602> and <xref:System.Threading.Tasks.Dataflow.JoinBlock%603> operate in either greedy or non-greedy mode. In greedy mode, which is the default, a <xref:System.Threading.Tasks.Dataflow.JoinBlock%602> or <xref:System.Threading.Tasks.Dataflow.JoinBlock%603> object accepts every message that it is offered and propagates out a tuple after each of its targets receives at least one message. In non-greedy mode, a <xref:System.Threading.Tasks.Dataflow.JoinBlock%602> or <xref:System.Threading.Tasks.Dataflow.JoinBlock%603> object postpones all incoming messages until all targets have been offered the data that is required to create a tuple. At this point, the block engages in a two-phase commit protocol to atomically retrieve all required items from the sources. This postponement makes it possible for another entity to consume the data in the meantime, to allow the overall system to make forward progress.  
  
 The following basic example demonstrates a case in which a <xref:System.Threading.Tasks.Dataflow.JoinBlock%603> object requires multiple data to compute a value. This example creates a <xref:System.Threading.Tasks.Dataflow.JoinBlock%603> object that requires two <xref:System.Int32> values and a <xref:System.Char> value to perform an arithmetic operation.  
  
 [!code-csharp[TPLDataflow_Overview#8](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_overview/cs/program.cs#8)]
 [!code-vb[TPLDataflow_Overview#8](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_overview/vb/program.vb#8)]  
  
 For a complete example that uses <xref:System.Threading.Tasks.Dataflow.JoinBlock%602> objects in non-greedy mode to cooperatively share a resource, see [How to: Use JoinBlock to Read Data From Multiple Sources](../../../docs/standard/parallel-programming/how-to-use-joinblock-to-read-data-from-multiple-sources.md).  
  
#### BatchedJoinBlock(T1, T2, ...)  
 The <xref:System.Threading.Tasks.Dataflow.BatchedJoinBlock%602> and <xref:System.Threading.Tasks.Dataflow.BatchedJoinBlock%603> classes collect batches of input elements and propagate out `System.Tuple(IList(T1), IList(T2))` or `System.Tuple(IList(T1), IList(T2), IList(T3))` objects that contain those elements. Think of <xref:System.Threading.Tasks.Dataflow.BatchedJoinBlock%602> as a combination of <xref:System.Threading.Tasks.Dataflow.BatchBlock%601> and <xref:System.Threading.Tasks.Dataflow.JoinBlock%602>. Specify the size of each batch when you create a <xref:System.Threading.Tasks.Dataflow.BatchedJoinBlock%602> object. <xref:System.Threading.Tasks.Dataflow.BatchedJoinBlock%602> also provides properties, <xref:System.Threading.Tasks.Dataflow.BatchedJoinBlock%602.Target1%2A> and <xref:System.Threading.Tasks.Dataflow.BatchedJoinBlock%602.Target2%2A>, that implement <xref:System.Threading.Tasks.Dataflow.ITargetBlock%601>. When the specified count of input elements are received from across all targets, the <xref:System.Threading.Tasks.Dataflow.BatchedJoinBlock%602> object asynchronously propagates out a `System.Tuple(IList(T1), IList(T2))` object that contains those elements.  
  
 The following basic example creates a <xref:System.Threading.Tasks.Dataflow.BatchedJoinBlock%602> object that holds results, <xref:System.Int32> values, and errors that are <xref:System.Exception> objects. This example performs multiple operations and writes results to the <xref:System.Threading.Tasks.Dataflow.BatchedJoinBlock%602.Target1%2A> property, and errors to the <xref:System.Threading.Tasks.Dataflow.BatchedJoinBlock%602.Target2%2A> property, of the <xref:System.Threading.Tasks.Dataflow.BatchedJoinBlock%602> object. Because the count of successful and failed operations is unknown in advance, the <xref:System.Collections.Generic.IList%601> objects enable each target to receive zero or more values.  
  
 [!code-csharp[TPLDataflow_Overview#9](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_overview/cs/program.cs#9)]
 [!code-vb[TPLDataflow_Overview#9](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_overview/vb/program.vb#9)]  
  
 For a complete example that uses <xref:System.Threading.Tasks.Dataflow.BatchedJoinBlock%602> to capture both the results and any exceptions that occur while the program reads from a database, see [Walkthrough: Using BatchBlock and BatchedJoinBlock to Improve Efficiency](../../../docs/standard/parallel-programming/walkthrough-using-batchblock-and-batchedjoinblock-to-improve-efficiency.md).  
  
 [[go to top](#top)]  
  
<a name="behavior"></a>   
## Configuring Dataflow  Block Behavior  
 You can enable additional options by providing a <xref:System.Threading.Tasks.Dataflow.DataflowBlockOptions?displayProperty=nameWithType> object to the constructor of dataflow block types. These options control behavior such the scheduler that manages the underlying task and the degree of parallelism. The <xref:System.Threading.Tasks.Dataflow.DataflowBlockOptions> also has derived types that specify behavior that is specific to certain dataflow block types. The following table summarizes which options type is associated with each dataflow block type.  
  
|Dataflow Block Type|<xref:System.Threading.Tasks.Dataflow.DataflowBlockOptions> type|  
|-------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------|  
|<xref:System.Threading.Tasks.Dataflow.BufferBlock%601>|<xref:System.Threading.Tasks.Dataflow.DataflowBlockOptions>|  
|<xref:System.Threading.Tasks.Dataflow.BroadcastBlock%601>|<xref:System.Threading.Tasks.Dataflow.DataflowBlockOptions>|  
|<xref:System.Threading.Tasks.Dataflow.WriteOnceBlock%601>|<xref:System.Threading.Tasks.Dataflow.DataflowBlockOptions>|  
|<xref:System.Threading.Tasks.Dataflow.ActionBlock%601>|<xref:System.Threading.Tasks.Dataflow.ExecutionDataflowBlockOptions>|  
|<xref:System.Threading.Tasks.Dataflow.TransformBlock%602>|<xref:System.Threading.Tasks.Dataflow.ExecutionDataflowBlockOptions>|  
|<xref:System.Threading.Tasks.Dataflow.TransformManyBlock%602>|<xref:System.Threading.Tasks.Dataflow.ExecutionDataflowBlockOptions>|  
|<xref:System.Threading.Tasks.Dataflow.BatchBlock%601>|<xref:System.Threading.Tasks.Dataflow.GroupingDataflowBlockOptions>|  
|<xref:System.Threading.Tasks.Dataflow.JoinBlock%602>|<xref:System.Threading.Tasks.Dataflow.GroupingDataflowBlockOptions>|  
|<xref:System.Threading.Tasks.Dataflow.BatchedJoinBlock%602>|<xref:System.Threading.Tasks.Dataflow.GroupingDataflowBlockOptions>|  
  
 The following sections provide additional information about the important kinds of dataflow block options that are available through the <xref:System.Threading.Tasks.Dataflow.DataflowBlockOptions?displayProperty=nameWithType>, <xref:System.Threading.Tasks.Dataflow.ExecutionDataflowBlockOptions?displayProperty=nameWithType>, and <xref:System.Threading.Tasks.Dataflow.GroupingDataflowBlockOptions?displayProperty=nameWithType> classes.  
  
### Specifying the Task Scheduler  
 Every predefined dataflow block uses the TPL task scheduling mechanism to perform activities such as propagating data to a target, receiving data from a source, and running user-defined delegates when data becomes available. <xref:System.Threading.Tasks.TaskScheduler> is an abstract class that represents a task scheduler that queues tasks onto threads. The default task scheduler, <xref:System.Threading.Tasks.TaskScheduler.Default%2A>, uses the <xref:System.Threading.ThreadPool> class to queue and execute work. You can override the default task scheduler by setting the <xref:System.Threading.Tasks.Dataflow.DataflowBlockOptions.TaskScheduler%2A> property when you construct a dataflow block object.  
  
 When the same task scheduler manages multiple dataflow blocks, it can enforce policies across them. For example, if multiple dataflow blocks are each configured to target the exclusive scheduler of the same <xref:System.Threading.Tasks.ConcurrentExclusiveSchedulerPair> object, all work that runs across these blocks is serialized. Similarly, if these blocks are configured to target the concurrent scheduler of the same <xref:System.Threading.Tasks.ConcurrentExclusiveSchedulerPair> object, and that scheduler is configured to have a maximum concurrency level, all work from these blocks is limited to that number of concurrent operations. For an example that uses the <xref:System.Threading.Tasks.ConcurrentExclusiveSchedulerPair> class to enable read operations to occur in parallel, but write operations to occur exclusively of all other operations, see [How to: Specify a Task Scheduler in a Dataflow Block](../../../docs/standard/parallel-programming/how-to-specify-a-task-scheduler-in-a-dataflow-block.md). For more information about task schedulers in the TPL, see the <xref:System.Threading.Tasks.TaskScheduler> class topic.  
  
### Specifying the Degree of Parallelism  
 By default, the three execution block types that the TPL Dataflow Library provides, <xref:System.Threading.Tasks.Dataflow.ActionBlock%601>, <xref:System.Threading.Tasks.Dataflow.TransformBlock%602>, and <xref:System.Threading.Tasks.Dataflow.TransformManyBlock%602>, process one message at a time. These dataflow block types also process messages in the order in which they are received. To enable these dataflow blocks to process messages concurrently, set the <xref:System.Threading.Tasks.Dataflow.ExecutionDataflowBlockOptions.MaxDegreeOfParallelism%2A?displayProperty=nameWithType> property when you construct the dataflow block object.  
  
 The default value of <xref:System.Threading.Tasks.Dataflow.ExecutionDataflowBlockOptions.MaxDegreeOfParallelism%2A> is 1, which guarantees that the dataflow block processes one message at a time. Setting this property to a value that is larger than 1 enables the dataflow block to process multiple messages concurrently. Setting this property to <xref:System.Threading.Tasks.Dataflow.DataflowBlockOptions.Unbounded?displayProperty=nameWithType> enables the underlying task scheduler to manage the maximum degree of concurrency.  
  
> [!IMPORTANT]
>  When you specify a maximum degree of parallelism that is larger than 1, multiple messages are processed simultaneously, and therefore, messages might not be processed in the order in which they are received. The order in which the messages are output from the block will, however, be correctly ordered.  
  
 Because the <xref:System.Threading.Tasks.Dataflow.ExecutionDataflowBlockOptions.MaxDegreeOfParallelism%2A> property represents the maximum degree of parallelism, the dataflow block might execute with a lesser degree of parallelism than you specify. The dataflow block might use a lesser degree of parallelism to meet its functional requirements or because there is a lack of available system resources. A dataflow block never chooses more parallelism than you specify.  
  
 The value of the <xref:System.Threading.Tasks.Dataflow.ExecutionDataflowBlockOptions.MaxDegreeOfParallelism%2A> property is exclusive to each dataflow block object. For example, if four dataflow block objects each specify 1 for the maximum degree of parallelism, all four dataflow block objects can potentially run in parallel.  
  
 For an example that sets the maximum degree of parallelism to enable lengthy operations to occur in parallel, see [How to: Specify the Degree of Parallelism in a Dataflow Block](../../../docs/standard/parallel-programming/how-to-specify-the-degree-of-parallelism-in-a-dataflow-block.md).  
  
### Specifying the Number of Messages per Task  
 The predefined dataflow block types use tasks to process multiple input elements. This helps minimize the number of task objects that are required to process data, which enables applications to run more efficiently. However, when the tasks from one set of dataflow blocks are processing data, the tasks from other dataflow blocks might need to wait for processing time by queuing messages. To enable better fairness among dataflow tasks, set the <xref:System.Threading.Tasks.Dataflow.DataflowBlockOptions.MaxMessagesPerTask%2A> property. When <xref:System.Threading.Tasks.Dataflow.DataflowBlockOptions.MaxMessagesPerTask%2A> is set to <xref:System.Threading.Tasks.Dataflow.DataflowBlockOptions.Unbounded?displayProperty=nameWithType>, which is the default, the task used by a dataflow block processes as many messages as are available. When <xref:System.Threading.Tasks.Dataflow.DataflowBlockOptions.MaxMessagesPerTask%2A> is set to a value other than <xref:System.Threading.Tasks.Dataflow.DataflowBlockOptions.Unbounded>, the dataflow block processes at most this number of messages per <xref:System.Threading.Tasks.Task> object. Although setting the <xref:System.Threading.Tasks.Dataflow.DataflowBlockOptions.MaxMessagesPerTask%2A> property can increase fairness among tasks, it can cause the system to create more tasks than are necessary, which can decrease performance.  
  
### Enabling Cancellation  
 The TPL provides a mechanism that enables tasks to coordinate cancellation in a cooperative manner. To enable dataflow blocks to participate in this cancellation mechanism, set the <xref:System.Threading.Tasks.Dataflow.DataflowBlockOptions.CancellationToken%2A> property. When this <xref:System.Threading.CancellationToken> object is set to the canceled state, all dataflow blocks that monitor this token finish execution of their current item but do not start processing subsequent items. These dataflow blocks also clear any buffered messages, release connections to any source and target blocks, and transition to the canceled state. By transitioning to the canceled state, the <xref:System.Threading.Tasks.Dataflow.IDataflowBlock.Completion%2A> property has the <xref:System.Threading.Tasks.Task.Status%2A> property set to <xref:System.Threading.Tasks.TaskStatus.Canceled>, unless an exception occurred during processing. In that case, <xref:System.Threading.Tasks.Task.Status%2A> is set to <xref:System.Threading.Tasks.TaskStatus.Faulted>.  
  
 For an example that demonstrates how to use cancellation in a Windows Forms application, see [How to: Cancel a Dataflow Block](../../../docs/standard/parallel-programming/how-to-cancel-a-dataflow-block.md). For more information about cancellation in the TPL, see [Task Cancellation](../../../docs/standard/parallel-programming/task-cancellation.md).  
  
### Specifying Greedy Versus Non-Greedy Behavior  
 Several grouping dataflow block types can operate in either *greedy* or *non-greedy* mode. By default, the predefined dataflow block types operate in greedy mode.  
  
 For join block types such as <xref:System.Threading.Tasks.Dataflow.JoinBlock%602>, greedy mode means that the block immediately accepts data even if the corresponding data with which to join is not yet available. Non-greedy mode means that the block postpones all incoming messages until one is available on each of its targets to complete the join. If any of the postponed messages are no longer available, the join block releases all postponed messages and restarts the process. For the <xref:System.Threading.Tasks.Dataflow.BatchBlock%601> class, greedy and non-greedy behavior is similar, except that under non-greedy mode, a <xref:System.Threading.Tasks.Dataflow.BatchBlock%601> object postpones all incoming messages until enough are available from distinct sources to complete a batch.  
  
 To specify non-greedy mode for a dataflow block, set <xref:System.Threading.Tasks.Dataflow.GroupingDataflowBlockOptions.Greedy%2A> to `False`. For an example that demonstrates how to use non-greedy mode to enable multiple join blocks to share a data source more efficiently, see [How to: Use JoinBlock to Read Data From Multiple Sources](../../../docs/standard/parallel-programming/how-to-use-joinblock-to-read-data-from-multiple-sources.md).  
  
 [[go to top](#top)]  
  
<a name="custom"></a>   
## Custom Dataflow Blocks  
 Although the TPL Dataflow Library provides many predefined block types, you can create additional block types that perform custom behavior. Implement the <xref:System.Threading.Tasks.Dataflow.ISourceBlock%601> or <xref:System.Threading.Tasks.Dataflow.ITargetBlock%601> interfaces directly or use the  <xref:System.Threading.Tasks.Dataflow.DataflowBlock.Encapsulate%2A> method to build a complex block that encapsulates the behavior of existing block types. For examples that show how to implement custom dataflow block functionality, see [Walkthrough: Creating a Custom Dataflow Block Type](../../../docs/standard/parallel-programming/walkthrough-creating-a-custom-dataflow-block-type.md).  
  
 [[go to top](#top)]  
  
## Related Topics  
  
|Title|Description|  
|-----------|-----------------|  
|[How to: Write Messages to and Read Messages from a Dataflow Block](../../../docs/standard/parallel-programming/how-to-write-messages-to-and-read-messages-from-a-dataflow-block.md)|Demonstrates how to write messages to and read messages from a <xref:System.Threading.Tasks.Dataflow.BufferBlock%601> object.|  
|[How to: Implement a Producer-Consumer Dataflow Pattern](../../../docs/standard/parallel-programming/how-to-implement-a-producer-consumer-dataflow-pattern.md)|Describes how to use the dataflow model to implement a producer-consumer pattern, where the producer sends messages to a dataflow block, and the consumer reads messages from that block.|  
|[How to: Perform Action When a Dataflow Block Receives Data](../../../docs/standard/parallel-programming/how-to-perform-action-when-a-dataflow-block-receives-data.md)|Describes how to provide delegates to the execution dataflow block types, <xref:System.Threading.Tasks.Dataflow.ActionBlock%601>, <xref:System.Threading.Tasks.Dataflow.TransformBlock%602>, and <xref:System.Threading.Tasks.Dataflow.TransformManyBlock%602>.|  
|[Walkthrough: Creating a Dataflow Pipeline](../../../docs/standard/parallel-programming/walkthrough-creating-a-dataflow-pipeline.md)|Describes how to create a dataflow pipeline that downloads text from the web and performs operations on that text.|  
|[How to: Unlink Dataflow Blocks](../../../docs/standard/parallel-programming/how-to-unlink-dataflow-blocks.md)|Demonstrates how to use the <xref:System.Threading.Tasks.Dataflow.ISourceBlock%601.LinkTo%2A> method to unlink a target block from its source after the source offers a message to the target.|  
|[Walkthrough: Using Dataflow in a Windows Forms Application](../../../docs/standard/parallel-programming/walkthrough-using-dataflow-in-a-windows-forms-application.md)|Demonstrates how to create a network of dataflow blocks that perform image processing in a Windows Forms application.|  
|[How to: Cancel a Dataflow Block](../../../docs/standard/parallel-programming/how-to-cancel-a-dataflow-block.md)|Demonstrates how to use cancellation in a Windows Forms application.|  
|[How to: Use JoinBlock to Read Data From Multiple Sources](../../../docs/standard/parallel-programming/how-to-use-joinblock-to-read-data-from-multiple-sources.md)|Explains how to use the <xref:System.Threading.Tasks.Dataflow.JoinBlock%602> class to perform an operation when data is available from multiple sources, and how to use non-greedy mode to enable multiple join blocks to share a data source more efficiently.|  
|[How to: Specify the Degree of Parallelism in a Dataflow Block](../../../docs/standard/parallel-programming/how-to-specify-the-degree-of-parallelism-in-a-dataflow-block.md)|Describes how to set the <xref:System.Threading.Tasks.Dataflow.ExecutionDataflowBlockOptions.MaxDegreeOfParallelism%2A> property to enable an execution dataflow block to process more than one message at a time.|  
|[How to: Specify a Task Scheduler in a Dataflow Block](../../../docs/standard/parallel-programming/how-to-specify-a-task-scheduler-in-a-dataflow-block.md)|Demonstrates how to associate a specific task scheduler when you use dataflow in your application.|  
|[Walkthrough: Using BatchBlock and BatchedJoinBlock to Improve Efficiency](../../../docs/standard/parallel-programming/walkthrough-using-batchblock-and-batchedjoinblock-to-improve-efficiency.md)|Describes how to use the <xref:System.Threading.Tasks.Dataflow.BatchBlock%601> class to improve the efficiency of database insert operations, and how to use the <xref:System.Threading.Tasks.Dataflow.BatchedJoinBlock%602> class to capture both the results and any exceptions that occur while the program reads from a database.|  
|[Walkthrough: Creating a Custom Dataflow Block Type](../../../docs/standard/parallel-programming/walkthrough-creating-a-custom-dataflow-block-type.md)|Demonstrates two ways to create a dataflow block type that implements custom behavior.|  
|[Task Parallel Library (TPL)](../../../docs/standard/parallel-programming/task-parallel-library-tpl.md)|Introduces the TPL, a library that simplifies parallel and concurrent programming in [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] applications.|
