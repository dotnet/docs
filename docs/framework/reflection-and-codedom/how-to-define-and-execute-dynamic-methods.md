---
title: "How to: Define and Execute Dynamic Methods"
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
  - "reflection emit, dynamic methods"
  - "dynamic methods"
ms.assetid: 07d08a99-62c5-4254-bce2-2a75e55a18ab
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Define and Execute Dynamic Methods
The following procedures show how to define and execute a simple dynamic method and a dynamic method bound to an instance of a class. For more information on dynamic methods, see the <xref:System.Reflection.Emit.DynamicMethod> class and [Reflection Emit Dynamic Method Scenarios](http://msdn.microsoft.com/library/7c27ea3d-0f24-4bf3-8ceb-f49d33faca5e).  
  
### To define and execute a dynamic method  
  
1.  Declare a delegate type to execute the method. Consider using a generic delegate to minimize the number of delegate types you need to declare. The following code declares two delegate types that could be used for the `SquareIt` method, and one of them is generic.  
  
     [!code-cpp[DynamicMethodHowTo#2](../../../samples/snippets/cpp/VS_Snippets_CLR/DynamicMethodHowTo/cpp/source.cpp#2)]
     [!code-csharp[DynamicMethodHowTo#2](../../../samples/snippets/csharp/VS_Snippets_CLR/DynamicMethodHowTo/cs/source.cs#2)]
     [!code-vb[DynamicMethodHowTo#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/DynamicMethodHowTo/vb/source.vb#2)]  
  
2.  Create an array that specifies the parameter types for the dynamic method. In this example, the only parameter is an `int` (`Integer` in Visual Basic), so the array has only one element.  
  
     [!code-cpp[DynamicMethodHowTo#3](../../../samples/snippets/cpp/VS_Snippets_CLR/DynamicMethodHowTo/cpp/source.cpp#3)]
     [!code-csharp[DynamicMethodHowTo#3](../../../samples/snippets/csharp/VS_Snippets_CLR/DynamicMethodHowTo/cs/source.cs#3)]
     [!code-vb[DynamicMethodHowTo#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/DynamicMethodHowTo/vb/source.vb#3)]  
  
3.  Create a <xref:System.Reflection.Emit.DynamicMethod>. In this example the method is named `SquareIt`.  
  
    > [!NOTE]
    >  It is not necessary to give dynamic methods names, and they cannot be invoked by name. Multiple dynamic methods can have the same name. However, the name appears in call stacks and can be useful for debugging.  
  
     The type of the return value is specified as `long`. The method is associated with the module that contains the `Example` class, which contains the example code. Any loaded module could be specified. The dynamic method acts like a module-level `static` method (`Shared` in Visual Basic).  
  
     [!code-cpp[DynamicMethodHowTo#4](../../../samples/snippets/cpp/VS_Snippets_CLR/DynamicMethodHowTo/cpp/source.cpp#4)]
     [!code-csharp[DynamicMethodHowTo#4](../../../samples/snippets/csharp/VS_Snippets_CLR/DynamicMethodHowTo/cs/source.cs#4)]
     [!code-vb[DynamicMethodHowTo#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/DynamicMethodHowTo/vb/source.vb#4)]  
  
4.  Emit the method body. In this example, an <xref:System.Reflection.Emit.ILGenerator> object is used to emit the Microsoft intermediate language (MSIL). Alternatively, a <xref:System.Reflection.Emit.DynamicILInfo> object can be used in conjunction with unmanaged code generators to emit the method body for a <xref:System.Reflection.Emit.DynamicMethod>.  
  
     The MSIL in this example loads the argument, which is an `int`, onto the stack, converts it to a `long`, duplicates the `long`, and multiplies the two numbers. This leaves the squared result on the stack, and all the method has to do is return.  
  
     [!code-cpp[DynamicMethodHowTo#5](../../../samples/snippets/cpp/VS_Snippets_CLR/DynamicMethodHowTo/cpp/source.cpp#5)]
     [!code-csharp[DynamicMethodHowTo#5](../../../samples/snippets/csharp/VS_Snippets_CLR/DynamicMethodHowTo/cs/source.cs#5)]
     [!code-vb[DynamicMethodHowTo#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/DynamicMethodHowTo/vb/source.vb#5)]  
  
5.  Create an instance of the delegate (declared in step 1) that represents the dynamic method by calling the <xref:System.Reflection.Emit.DynamicMethod.CreateDelegate%2A> method. Creating the delegate completes the method, and any further attempts to change the method — for example, adding more MSIL — are ignored. The following code creates the delegate and invokes it, using a generic delegate.  
  
     [!code-cpp[DynamicMethodHowTo#6](../../../samples/snippets/cpp/VS_Snippets_CLR/DynamicMethodHowTo/cpp/source.cpp#6)]
     [!code-csharp[DynamicMethodHowTo#6](../../../samples/snippets/csharp/VS_Snippets_CLR/DynamicMethodHowTo/cs/source.cs#6)]
     [!code-vb[DynamicMethodHowTo#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/DynamicMethodHowTo/vb/source.vb#6)]  
  
### To define and execute a dynamic method that is bound to an object  
  
1.  Declare a delegate type to execute the method. Consider using a generic delegate to minimize the number of delegate types you need to declare. The following code declares a generic delegate type that can be used to execute any method with one parameter and a return value, or a method with two parameters and a return value if the delegate is bound to an object.  
  
     [!code-cpp[DynamicMethodHowTo#12](../../../samples/snippets/cpp/VS_Snippets_CLR/DynamicMethodHowTo/cpp/source.cpp#12)]
     [!code-csharp[DynamicMethodHowTo#12](../../../samples/snippets/csharp/VS_Snippets_CLR/DynamicMethodHowTo/cs/source.cs#12)]
     [!code-vb[DynamicMethodHowTo#12](../../../samples/snippets/visualbasic/VS_Snippets_CLR/DynamicMethodHowTo/vb/source.vb#12)]  
  
2.  Create an array that specifies the parameter types for the dynamic method. If the delegate representing the method is to be bound to an object, the first parameter must match the type the delegate is bound to. In this example, there are two parameters, of type `Example` and type `int` (`Integer` in Visual Basic).  
  
     [!code-cpp[DynamicMethodHowTo#13](../../../samples/snippets/cpp/VS_Snippets_CLR/DynamicMethodHowTo/cpp/source.cpp#13)]
     [!code-csharp[DynamicMethodHowTo#13](../../../samples/snippets/csharp/VS_Snippets_CLR/DynamicMethodHowTo/cs/source.cs#13)]
     [!code-vb[DynamicMethodHowTo#13](../../../samples/snippets/visualbasic/VS_Snippets_CLR/DynamicMethodHowTo/vb/source.vb#13)]  
  
3.  Create a <xref:System.Reflection.Emit.DynamicMethod>. In this example the method has no name. The type of the return value is specified as `int` (`Integer` in Visual Basic). The method has access to the private and protected members of the `Example` class.  
  
     [!code-cpp[DynamicMethodHowTo#14](../../../samples/snippets/cpp/VS_Snippets_CLR/DynamicMethodHowTo/cpp/source.cpp#14)]
     [!code-csharp[DynamicMethodHowTo#14](../../../samples/snippets/csharp/VS_Snippets_CLR/DynamicMethodHowTo/cs/source.cs#14)]
     [!code-vb[DynamicMethodHowTo#14](../../../samples/snippets/visualbasic/VS_Snippets_CLR/DynamicMethodHowTo/vb/source.vb#14)]  
  
4.  Emit the method body. In this example, an <xref:System.Reflection.Emit.ILGenerator> object is used to emit the Microsoft intermediate language (MSIL). Alternatively, a <xref:System.Reflection.Emit.DynamicILInfo> object can be used in conjunction with unmanaged code generators to emit the method body for a <xref:System.Reflection.Emit.DynamicMethod>.  
  
     The MSIL in this example loads the first argument, which is an instance of the `Example` class, and uses it to load the value of a private instance field of type `int`. The second argument is loaded, and the two numbers are multiplied. If the result is larger than `int`, the value is truncated and the most significant bits are discarded. The method returns, with the return value on the stack.  
  
     [!code-cpp[DynamicMethodHowTo#15](../../../samples/snippets/cpp/VS_Snippets_CLR/DynamicMethodHowTo/cpp/source.cpp#15)]
     [!code-csharp[DynamicMethodHowTo#15](../../../samples/snippets/csharp/VS_Snippets_CLR/DynamicMethodHowTo/cs/source.cs#15)]
     [!code-vb[DynamicMethodHowTo#15](../../../samples/snippets/visualbasic/VS_Snippets_CLR/DynamicMethodHowTo/vb/source.vb#15)]  
  
5.  Create an instance of the delegate (declared in step 1) that represents the dynamic method by calling the <xref:System.Reflection.Emit.DynamicMethod.CreateDelegate%28System.Type%2CSystem.Object%29> method overload. Creating the delegate completes the method, and any further attempts to change the method — for example, adding more MSIL — are ignored.  
  
    > [!NOTE]
    >  You can call the <xref:System.Reflection.Emit.DynamicMethod.CreateDelegate%2A> method multiple times to create delegates bound to other instances of the target type.  
  
     The following code binds the method to a new instance of the `Example` class whose private test field is set to 42. That is, each time the delegate is invoked the instance of `Example` is passed to the first parameter of the method.  
  
     The delegate `OneParameter` is used because the first parameter of the method always receives the instance of `Example`. When the delegate is invoked, only the second parameter is required.  
  
     [!code-cpp[DynamicMethodHowTo#16](../../../samples/snippets/cpp/VS_Snippets_CLR/DynamicMethodHowTo/cpp/source.cpp#16)]
     [!code-csharp[DynamicMethodHowTo#16](../../../samples/snippets/csharp/VS_Snippets_CLR/DynamicMethodHowTo/cs/source.cs#16)]
     [!code-vb[DynamicMethodHowTo#16](../../../samples/snippets/visualbasic/VS_Snippets_CLR/DynamicMethodHowTo/vb/source.vb#16)]  
  
## Example  
 The following code example demonstrates a simple dynamic method and a dynamic method bound to an instance of a class.  
  
 The simple dynamic method takes one argument, a 32-bit integer, and returns the 64-bit square of that integer. A generic delegate is used to invoke the method.  
  
 The second dynamic method has two parameters, of type `Example` and type `int` (`Integer` in Visual Basic). When the dynamic method has been created, it is bound to an instance of `Example`, using a generic delegate that has one argument of type `int`. The delegate does not have an argument of type `Example` because the first parameter of the method always receives the bound instance of `Example`. When the delegate is invoked, only the `int` argument is supplied. This dynamic method accesses a private field of the `Example` class and returns the product of the private field and the `int` argument.  
  
 The code example defines delegates that can be used to execute the methods.  
  
 [!code-cpp[DynamicMethodHowTo#1](../../../samples/snippets/cpp/VS_Snippets_CLR/DynamicMethodHowTo/cpp/source.cpp#1)]
 [!code-csharp[DynamicMethodHowTo#1](../../../samples/snippets/csharp/VS_Snippets_CLR/DynamicMethodHowTo/cs/source.cs#1)]
 [!code-vb[DynamicMethodHowTo#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/DynamicMethodHowTo/vb/source.vb#1)]  
  
## Compiling the Code  
  
-   The code contains the C# `using` statements (`Imports` in Visual Basic) necessary for compilation.  
  
-   No additional assembly references are required.  
  
-   Compile the code at the command line using csc.exe, vbc.exe, or cl.exe. To compile the code in Visual Studio, place it in a console application project template.  
  
## See Also  
 <xref:System.Reflection.Emit.DynamicMethod>  
 [Using Reflection Emit](http://msdn.microsoft.com/library/ccc6540d-0e2c-4d89-b456-eb7353f9e9ac)  
 [Reflection Emit Dynamic Method Scenarios](http://msdn.microsoft.com/library/7c27ea3d-0f24-4bf3-8ceb-f49d33faca5e)
