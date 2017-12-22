---
title: "How to: Hook Up a Delegate Using Reflection"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "events [.NET Framework], adding event handlers with reflection"
  - "reflection, adding event-handler delegates"
  - "delegates [.NET Framework], adding event handlers with reflection"
ms.assetid: 076ee62d-a964-449e-a447-c31b33518b81
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Hook Up a Delegate Using Reflection
When you use reflection to load and run assemblies, you cannot use language features like the C# `+=` operator or the Visual Basic [AddHandler statement](~/docs/visual-basic/language-reference/statements/addhandler-statement.md) to hook up events. The following procedures show how to hook up an existing method to an event by getting all the necessary types through reflection, and how to create a dynamic method using reflection emit and hook it up to an event.  
  
> [!NOTE]
>  For another way to hook up an event-handling delegate, see the code example for the <xref:System.Reflection.EventInfo.AddEventHandler%2A> method of the <xref:System.Reflection.EventInfo> class.  
  
### To hook up a delegate using reflection  
  
1.  Load an assembly that contains a type that raises events. Assemblies are usually loaded with the <xref:System.Reflection.Assembly.Load%2A?displayProperty=nameWithType> method. To keep this example simple, a derived form in the current assembly is used, so the <xref:System.Reflection.Assembly.GetExecutingAssembly%2A> method is used to load the current assembly.  
  
     [!code-cpp[HookUpDelegate#3](../../../samples/snippets/cpp/VS_Snippets_CLR/HookUpDelegate/cpp/source.cpp#3)]
     [!code-csharp[HookUpDelegate#3](../../../samples/snippets/csharp/VS_Snippets_CLR/HookUpDelegate/cs/source.cs#3)]
     [!code-vb[HookUpDelegate#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/HookUpDelegate/vb/source.vb#3)]  
  
2.  Get a <xref:System.Type> object representing the type, and create an instance of the type. The <xref:System.Activator.CreateInstance%28System.Type%29> method is used in the following code because the form has a default constructor. There are several other overloads of the <xref:System.Activator.CreateInstance%2A> method that you can use if the type you are creating does not have a default constructor. The new instance is stored as type <xref:System.Object> to maintain the fiction that nothing is known about the assembly. (Reflection allows you to get the types in an assembly without knowing their names in advance.)  
  
     [!code-cpp[HookUpDelegate#4](../../../samples/snippets/cpp/VS_Snippets_CLR/HookUpDelegate/cpp/source.cpp#4)]
     [!code-csharp[HookUpDelegate#4](../../../samples/snippets/csharp/VS_Snippets_CLR/HookUpDelegate/cs/source.cs#4)]
     [!code-vb[HookUpDelegate#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/HookUpDelegate/vb/source.vb#4)]  
  
3.  Get an <xref:System.Reflection.EventInfo> object representing the event, and use the <xref:System.Reflection.EventInfo.EventHandlerType%2A> property to get the type of delegate used to handle the event. In the following code, an <xref:System.Reflection.EventInfo> for the <xref:System.Windows.Forms.Control.Click> event is obtained.  
  
     [!code-cpp[HookUpDelegate#5](../../../samples/snippets/cpp/VS_Snippets_CLR/HookUpDelegate/cpp/source.cpp#5)]
     [!code-csharp[HookUpDelegate#5](../../../samples/snippets/csharp/VS_Snippets_CLR/HookUpDelegate/cs/source.cs#5)]
     [!code-vb[HookUpDelegate#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/HookUpDelegate/vb/source.vb#5)]  
  
4.  Get a <xref:System.Reflection.MethodInfo> object representing the method that handles the event. The complete program code in the Example section later in this topic contains a method that matches the signature of the <xref:System.EventHandler> delegate, which handles the <xref:System.Windows.Forms.Control.Click> event, but you can also generate dynamic methods at run time. For details, see the accompanying procedure, for generating an event handler at run time by using a dynamic method.  
  
     [!code-cpp[HookUpDelegate#6](../../../samples/snippets/cpp/VS_Snippets_CLR/HookUpDelegate/cpp/source.cpp#6)]
     [!code-csharp[HookUpDelegate#6](../../../samples/snippets/csharp/VS_Snippets_CLR/HookUpDelegate/cs/source.cs#6)]
     [!code-vb[HookUpDelegate#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/HookUpDelegate/vb/source.vb#6)]  
  
5.  Create an instance of the delegate, using the <xref:System.Delegate.CreateDelegate%2A> method. This method is static (`Shared` in Visual Basic), so the delegate type must be supplied. Using the overloads of <xref:System.Delegate.CreateDelegate%2A> that take a <xref:System.Reflection.MethodInfo> is recommended.  
  
     [!code-cpp[HookUpDelegate#7](../../../samples/snippets/cpp/VS_Snippets_CLR/HookUpDelegate/cpp/source.cpp#7)]
     [!code-csharp[HookUpDelegate#7](../../../samples/snippets/csharp/VS_Snippets_CLR/HookUpDelegate/cs/source.cs#7)]
     [!code-vb[HookUpDelegate#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/HookUpDelegate/vb/source.vb#7)]  
  
6.  Get the `add` accessor method and invoke it to hook up the event. All events have an `add` accessor and a `remove` accessor, which are hidden by the syntax of high-level languages. For example, C# uses the `+=` operator to hook up events, and Visual Basic uses the [AddHandler statement](~/docs/visual-basic/language-reference/statements/addhandler-statement.md). The following code gets the `add` accessor of the <xref:System.Windows.Forms.Control.Click> event and invokes it late-bound, passing in the delegate instance. The arguments must be passed as an array.  
  
     [!code-cpp[HookUpDelegate#8](../../../samples/snippets/cpp/VS_Snippets_CLR/HookUpDelegate/cpp/source.cpp#8)]
     [!code-csharp[HookUpDelegate#8](../../../samples/snippets/csharp/VS_Snippets_CLR/HookUpDelegate/cs/source.cs#8)]
     [!code-vb[HookUpDelegate#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/HookUpDelegate/vb/source.vb#8)]  
  
7.  Test the event. The following code shows the form defined in the code example. Clicking the form invokes the event handler.  
  
     [!code-cpp[HookUpDelegate#12](../../../samples/snippets/cpp/VS_Snippets_CLR/HookUpDelegate/cpp/source.cpp#12)]
     [!code-csharp[HookUpDelegate#12](../../../samples/snippets/csharp/VS_Snippets_CLR/HookUpDelegate/cs/source.cs#12)]
     [!code-vb[HookUpDelegate#12](../../../samples/snippets/visualbasic/VS_Snippets_CLR/HookUpDelegate/vb/source.vb#12)]  
  
<a name="procedureSection1"></a>   
### To generate an event handler at run time by using a dynamic method  
  
1.  Event-handler methods can be generated at run time, using lightweight dynamic methods and reflection emit. To construct an event handler, you need the return type and parameter types of the delegate. These can be obtained by examining the delegate's `Invoke` method. The following code uses the `GetDelegateReturnType` and `GetDelegateParameterTypes` methods to obtain this information. The code for these methods can be found in the Example section later in this topic.  
  
     It is not necessary to name a <xref:System.Reflection.Emit.DynamicMethod>, so the empty string can be used. In the following code, the last argument associates the dynamic method with the current type, giving the delegate access to all the public and private members of the `Example` class.  
  
     [!code-cpp[HookUpDelegate#9](../../../samples/snippets/cpp/VS_Snippets_CLR/HookUpDelegate/cpp/source.cpp#9)]
     [!code-csharp[HookUpDelegate#9](../../../samples/snippets/csharp/VS_Snippets_CLR/HookUpDelegate/cs/source.cs#9)]
     [!code-vb[HookUpDelegate#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR/HookUpDelegate/vb/source.vb#9)]  
  
2.  Generate a method body. This method loads a string, calls the overload of the <xref:System.Windows.Forms.MessageBox.Show%2A?displayProperty=nameWithType> method that takes a string, pops the return value off the stack (because the handler has no return type), and returns. To learn more about emitting dynamic methods, see [How to: Define and Execute Dynamic Methods](../../../docs/framework/reflection-and-codedom/how-to-define-and-execute-dynamic-methods.md).  
  
     [!code-cpp[HookUpDelegate#10](../../../samples/snippets/cpp/VS_Snippets_CLR/HookUpDelegate/cpp/source.cpp#10)]
     [!code-csharp[HookUpDelegate#10](../../../samples/snippets/csharp/VS_Snippets_CLR/HookUpDelegate/cs/source.cs#10)]
     [!code-vb[HookUpDelegate#10](../../../samples/snippets/visualbasic/VS_Snippets_CLR/HookUpDelegate/vb/source.vb#10)]  
  
3.  Complete the dynamic method by calling its <xref:System.Reflection.Emit.DynamicMethod.CreateDelegate%2A> method. Use the `add` accessor to add the delegate to the invocation list for the event.  
  
     [!code-cpp[HookUpDelegate#11](../../../samples/snippets/cpp/VS_Snippets_CLR/HookUpDelegate/cpp/source.cpp#11)]
     [!code-csharp[HookUpDelegate#11](../../../samples/snippets/csharp/VS_Snippets_CLR/HookUpDelegate/cs/source.cs#11)]
     [!code-vb[HookUpDelegate#11](../../../samples/snippets/visualbasic/VS_Snippets_CLR/HookUpDelegate/vb/source.vb#11)]  
  
4.  Test the event. The following code loads the form defined in the code example. Clicking the form invokes both the predefined event handler and the emitted event handler.  
  
     [!code-cpp[HookUpDelegate#12](../../../samples/snippets/cpp/VS_Snippets_CLR/HookUpDelegate/cpp/source.cpp#12)]
     [!code-csharp[HookUpDelegate#12](../../../samples/snippets/csharp/VS_Snippets_CLR/HookUpDelegate/cs/source.cs#12)]
     [!code-vb[HookUpDelegate#12](../../../samples/snippets/visualbasic/VS_Snippets_CLR/HookUpDelegate/vb/source.vb#12)]  
  
## Example  
 The following code example shows how to hook up an existing method to an event using reflection, and also how to use the <xref:System.Reflection.Emit.DynamicMethod> class to emit a method at run time and hook it up to an event.  
  
 [!code-cpp[HookUpDelegate#1](../../../samples/snippets/cpp/VS_Snippets_CLR/HookUpDelegate/cpp/source.cpp#1)]
 [!code-csharp[HookUpDelegate#1](../../../samples/snippets/csharp/VS_Snippets_CLR/HookUpDelegate/cs/source.cs#1)]
 [!code-vb[HookUpDelegate#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/HookUpDelegate/vb/source.vb#1)]  
  
## Compiling the Code  
  
-   The code contains the C# `using` statements (`Imports` in Visual Basic) necessary for compilation.  
  
-   No additional assembly references are required for compiling from the command line. In Visual Studio you must add a reference to System.Windows.Forms.dll because this example is a console application.  
  
-   Compile the code at the command line using csc.exe, vbc.exe, or cl.exe. To compile the code in Visual Studio, place it in a console application project template.  
  
## See Also  
 <xref:System.Reflection.Assembly.Load%2A?displayProperty=nameWithType>  
 <xref:System.Reflection.Emit.DynamicMethod>  
 <xref:System.Activator.CreateInstance%2A>  
 <xref:System.Delegate.CreateDelegate%2A>  
 [How to: Define and Execute Dynamic Methods](../../../docs/framework/reflection-and-codedom/how-to-define-and-execute-dynamic-methods.md)  
 [Reflection](../../../docs/framework/reflection-and-codedom/reflection.md)
