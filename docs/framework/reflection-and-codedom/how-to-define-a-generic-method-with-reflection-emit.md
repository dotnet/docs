---
title: "How to: Define a Generic Method with Reflection Emit"
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
helpviewer_keywords: 
  - "generics [.NET Framework], reflection emit"
  - "reflection emit, generic methods"
  - "generics [.NET Framework], dynamic types"
ms.assetid: 93892fa4-90b3-4ec4-b147-4bec9880de2b
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Define a Generic Method with Reflection Emit
The first procedure shows how to create a simple generic method with two type parameters, and how to apply class constraints, interface constraints, and special constraints to the type parameters.  
  
 The second procedure shows how to emit the method body, and how to use the type parameters of the generic method to create instances of generic types and to call their methods.  
  
 The third procedure shows how to invoke the generic method.  
  
> [!IMPORTANT]
>  A method is not generic just because it belongs to a generic type and uses the type parameters of that type. A method is generic only if it has its own type parameter list. A generic method can appear on a nongeneric type, as in this example. For an example of a nongeneric method on a generic type, see [How to: Define a Generic Type with Reflection Emit](../../../docs/framework/reflection-and-codedom/how-to-define-a-generic-type-with-reflection-emit.md).  
  
### To define a generic method  
  
1.  Before beginning, it is useful to look at how the generic method appears when written using a high-level language. The following code is included in the example code for this topic, along with code to call the generic method. The method has two type parameters, `TInput` and `TOutput`, the second of which must be a reference type (`class`), must have a parameterless constructor (`new`), and must implement `ICollection(Of TInput)` (`ICollection<TInput>` in C#). This interface constraint ensures that the <xref:System.Collections.Generic.ICollection%601.Add%2A?displayProperty=nameWithType> method can be used to add elements to the `TOutput` collection that the method creates. The method has one formal parameter, `input`, which is an array of `TInput`. The method creates a collection of type `TOutput` and copies the elements of `input` to the collection.  
  
     [!code-csharp[GenericMethodHowTo#20](../../../samples/snippets/csharp/VS_Snippets_CLR/GenericMethodHowTo/CS/source.cs#20)]
     [!code-vb[GenericMethodHowTo#20](../../../samples/snippets/visualbasic/VS_Snippets_CLR/GenericMethodHowTo/VB/source.vb#20)]  
  
2.  Define a dynamic assembly and a dynamic module to contain the type the generic method belongs to. In this case, the assembly has only one module, named `DemoMethodBuilder1`, and the module name is the same as the assembly name plus an extension. In this example, the assembly is saved to disk and also executed, so <xref:System.Reflection.Emit.AssemblyBuilderAccess.RunAndSave?displayProperty=nameWithType> is specified. You can use the [Ildasm.exe (IL Disassembler)](../../../docs/framework/tools/ildasm-exe-il-disassembler.md) to examine DemoMethodBuilder1.dll and to compare it to the Microsoft intermediate language (MSIL) for the method shown in step 1.  
  
     [!code-csharp[GenericMethodHowTo#2](../../../samples/snippets/csharp/VS_Snippets_CLR/GenericMethodHowTo/CS/source.cs#2)]
     [!code-vb[GenericMethodHowTo#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/GenericMethodHowTo/VB/source.vb#2)]  
  
3.  Define the type the generic method belongs to. The type does not have to be generic. A generic method can belong to either a generic or nongeneric type. In this example, the type is a class, is not generic, and is named `DemoType`.  
  
     [!code-csharp[GenericMethodHowTo#3](../../../samples/snippets/csharp/VS_Snippets_CLR/GenericMethodHowTo/CS/source.cs#3)]
     [!code-vb[GenericMethodHowTo#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/GenericMethodHowTo/VB/source.vb#3)]  
  
4.  Define the generic method. If the types of a generic method's formal parameters are specified by generic type parameters of the generic method, use the <xref:System.Reflection.Emit.TypeBuilder.DefineMethod%28System.String%2CSystem.Reflection.MethodAttributes%29> method overload to define the method. The generic type parameters of the method are not yet defined, so you cannot specify the types of the method's formal parameters in the call to <xref:System.Reflection.Emit.TypeBuilder.DefineMethod%2A>. In this example, the method is named `Factory`. The method is public and `static` (`Shared` in Visual Basic).  
  
     [!code-csharp[GenericMethodHowTo#4](../../../samples/snippets/csharp/VS_Snippets_CLR/GenericMethodHowTo/CS/source.cs#4)]
     [!code-vb[GenericMethodHowTo#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/GenericMethodHowTo/VB/source.vb#4)]  
  
5.  Define the generic type parameters of `DemoMethod` by passing an array of strings containing the names of the parameters to the <xref:System.Reflection.Emit.MethodBuilder.DefineGenericParameters%2A?displayProperty=nameWithType> method. This makes the method a generic method. The following code makes `Factory` a generic method with type parameters `TInput` and `TOutput`. To make the code easier to read, variables with these names are created to hold the <xref:System.Reflection.Emit.GenericTypeParameterBuilder> objects representing the two type parameters.  
  
     [!code-csharp[GenericMethodHowTo#5](../../../samples/snippets/csharp/VS_Snippets_CLR/GenericMethodHowTo/CS/source.cs#5)]
     [!code-vb[GenericMethodHowTo#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/GenericMethodHowTo/VB/source.vb#5)]  
  
6.  Optionally add special constraints to the type parameters. Special constraints are added using the <xref:System.Reflection.Emit.GenericTypeParameterBuilder.SetGenericParameterAttributes%2A> method. In this example, `TOutput` is constrained to be a reference type and to have a parameterless constructor.  
  
     [!code-csharp[GenericMethodHowTo#6](../../../samples/snippets/csharp/VS_Snippets_CLR/GenericMethodHowTo/CS/source.cs#6)]
     [!code-vb[GenericMethodHowTo#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/GenericMethodHowTo/VB/source.vb#6)]  
  
7.  Optionally add class and interface constraints to the type parameters. In this example, type parameter `TOutput` is constrained to types that implement the `ICollection(Of TInput)` (`ICollection<TInput>` in C#) interface. This ensures that the <xref:System.Collections.Generic.ICollection%601.Add%2A> method can be used to add elements.  
  
     [!code-csharp[GenericMethodHowTo#7](../../../samples/snippets/csharp/VS_Snippets_CLR/GenericMethodHowTo/CS/source.cs#7)]
     [!code-vb[GenericMethodHowTo#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/GenericMethodHowTo/VB/source.vb#7)]  
  
8.  Define the formal parameters of the method, using the <xref:System.Reflection.Emit.MethodBuilder.SetParameters%2A> method. In this example, the `Factory` method has one parameter, an array of `TInput`. This type is created by calling the <xref:System.Type.MakeArrayType%2A> method on the <xref:System.Reflection.Emit.GenericTypeParameterBuilder> that represents `TInput`. The argument of <xref:System.Reflection.Emit.MethodBuilder.SetParameters%2A> is an array of <xref:System.Type> objects.  
  
     [!code-csharp[GenericMethodHowTo#8](../../../samples/snippets/csharp/VS_Snippets_CLR/GenericMethodHowTo/CS/source.cs#8)]
     [!code-vb[GenericMethodHowTo#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/GenericMethodHowTo/VB/source.vb#8)]  
  
9. Define the return type for the method, using the <xref:System.Reflection.Emit.MethodBuilder.SetReturnType%2A> method. In this example, an instance of `TOutput` is returned.  
  
     [!code-csharp[GenericMethodHowTo#9](../../../samples/snippets/csharp/VS_Snippets_CLR/GenericMethodHowTo/CS/source.cs#9)]
     [!code-vb[GenericMethodHowTo#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR/GenericMethodHowTo/VB/source.vb#9)]  
  
10. Emit the method body, using <xref:System.Reflection.Emit.ILGenerator>. For details, see the accompanying procedure for emitting the method body.  
  
    > [!IMPORTANT]
    >  When you emit calls to methods of generic types, and the type arguments of those types are type parameters of the generic method, you must use the `static`<xref:System.Reflection.Emit.TypeBuilder.GetConstructor%28System.Type%2CSystem.Reflection.ConstructorInfo%29>, <xref:System.Reflection.Emit.TypeBuilder.GetMethod%28System.Type%2CSystem.Reflection.MethodInfo%29>, and <xref:System.Reflection.Emit.TypeBuilder.GetField%28System.Type%2CSystem.Reflection.FieldInfo%29> method overloads of the <xref:System.Reflection.Emit.TypeBuilder> class to obtain constructed forms of the methods. The accompanying procedure for emitting the method body demonstrates this.  
  
11. Complete the type that contains the method and save the assembly. The accompanying procedure for invoking the generic method shows two ways to invoke the completed method.  
  
     [!code-csharp[GenericMethodHowTo#14](../../../samples/snippets/csharp/VS_Snippets_CLR/GenericMethodHowTo/CS/source.cs#14)]
     [!code-vb[GenericMethodHowTo#14](../../../samples/snippets/visualbasic/VS_Snippets_CLR/GenericMethodHowTo/VB/source.vb#14)]  
  
<a name="procedureSection1"></a>   
### To emit the method body  
  
1.  Get a code generator and declare local variables and labels. The <xref:System.Reflection.Emit.ILGenerator.DeclareLocal%2A> method is used to declare local variables. The `Factory` method has four local variables: `retVal` to hold the new `TOutput` that is returned by the method, `ic` to hold the `TOutput` when it is cast to `ICollection(Of TInput)` (`ICollection<TInput>` in C#), `input` to hold the input array of `TInput` objects, and `index` to iterate through the array. The method also has two labels, one to enter the loop (`enterLoop`) and one for the top of the loop (`loopAgain`), defined using the <xref:System.Reflection.Emit.ILGenerator.DefineLabel%2A> method.  
  
     The first thing the method does is to load its argument using <xref:System.Reflection.Emit.OpCodes.Ldarg_0> opcode and to store it in the local variable `input` using <xref:System.Reflection.Emit.OpCodes.Stloc_S> opcode.  
  
     [!code-csharp[GenericMethodHowTo#10](../../../samples/snippets/csharp/VS_Snippets_CLR/GenericMethodHowTo/CS/source.cs#10)]
     [!code-vb[GenericMethodHowTo#10](../../../samples/snippets/visualbasic/VS_Snippets_CLR/GenericMethodHowTo/VB/source.vb#10)]  
  
2.  Emit code to create an instance of `TOutput`, using the generic method overload of the <xref:System.Activator.CreateInstance%2A?displayProperty=nameWithType> method. Using this overload requires the specified type to have a parameterless constructor, which is the reason for adding that constraint to `TOutput`. Create the constructed generic method by passing `TOutput` to <xref:System.Reflection.MethodInfo.MakeGenericMethod%2A>. After emitting code to call the method, emit code to store it in the local variable `retVal` using <xref:System.Reflection.Emit.OpCodes.Stloc_S>  
  
     [!code-csharp[GenericMethodHowTo#11](../../../samples/snippets/csharp/VS_Snippets_CLR/GenericMethodHowTo/CS/source.cs#11)]
     [!code-vb[GenericMethodHowTo#11](../../../samples/snippets/visualbasic/VS_Snippets_CLR/GenericMethodHowTo/VB/source.vb#11)]  
  
3.  Emit code to cast the new `TOutput` object to `ICollection(Of TInput)` and store it in the local variable `ic`.  
  
     [!code-csharp[GenericMethodHowTo#31](../../../samples/snippets/csharp/VS_Snippets_CLR/GenericMethodHowTo/CS/source.cs#31)]
     [!code-vb[GenericMethodHowTo#31](../../../samples/snippets/visualbasic/VS_Snippets_CLR/GenericMethodHowTo/VB/source.vb#31)]  
  
4.  Get a <xref:System.Reflection.MethodInfo> representing the <xref:System.Collections.Generic.ICollection%601.Add%2A?displayProperty=nameWithType> method. The method is acting on an `ICollection(Of TInput)` (`ICollection<TInput>` in C#), so it is necessary to get the `Add` method specific to that constructed type. You cannot use the <xref:System.Type.GetMethod%2A> method to get this <xref:System.Reflection.MethodInfo> directly from `icollOfTInput`, because <xref:System.Type.GetMethod%2A> is not supported on a type that has been constructed with a <xref:System.Reflection.Emit.GenericTypeParameterBuilder>. Instead, call <xref:System.Type.GetMethod%2A> on `icoll`, which contains the generic type definition for the <xref:System.Collections.Generic.ICollection%601> generic interface. Then use the <xref:System.Reflection.Emit.TypeBuilder.GetMethod%28System.Type%2CSystem.Reflection.MethodInfo%29>`static` method to produce the <xref:System.Reflection.MethodInfo> for the constructed type. The following code demonstrates this.  
  
     [!code-csharp[GenericMethodHowTo#12](../../../samples/snippets/csharp/VS_Snippets_CLR/GenericMethodHowTo/CS/source.cs#12)]
     [!code-vb[GenericMethodHowTo#12](../../../samples/snippets/visualbasic/VS_Snippets_CLR/GenericMethodHowTo/VB/source.vb#12)]  
  
5.  Emit code to initialize the `index` variable, by loading a 32-bit integer 0 and storing it in the variable. Emit code to branch to the label `enterLoop`. This label has not yet been marked, because it is inside the loop. Code for the loop is emitted in the next step.  
  
     [!code-csharp[GenericMethodHowTo#32](../../../samples/snippets/csharp/VS_Snippets_CLR/GenericMethodHowTo/CS/source.cs#32)]
     [!code-vb[GenericMethodHowTo#32](../../../samples/snippets/visualbasic/VS_Snippets_CLR/GenericMethodHowTo/VB/source.vb#32)]  
  
6.  Emit code for the loop. The first step is to mark the top of the loop, by calling <xref:System.Reflection.Emit.ILGenerator.MarkLabel%2A> with the `loopAgain` label. Branch statements that use the label will now branch to this point in the code. The next step is to push the `TOutput` object, cast to `ICollection(Of TInput)`, onto the stack. It is not needed immediately, but needs to be in position for calling the `Add` method. Next the input array is pushed onto the stack, then the `index` variable containing the current index into the array. The <xref:System.Reflection.Emit.OpCodes.Ldelem> opcode pops the index and the array off the stack and pushes the indexed array element onto the stack. The stack is now ready for the call to the <xref:System.Collections.Generic.ICollection%601.Add%2A?displayProperty=nameWithType> method, which pops the collection and the new element off the stack and adds the element to the collection.  
  
     The rest of the code in the loop increments the index and tests to see whether the loop is finished: The index and a 32-bit integer 1 are pushed onto the stack and added, leaving the sum on the stack; the sum is stored in `index`. <xref:System.Reflection.Emit.ILGenerator.MarkLabel%2A> is called to set this point as the entry point for the loop. The index is loaded again. The input array is pushed on the stack, and <xref:System.Reflection.Emit.OpCodes.Ldlen> is emitted to get its length. The index and the length are now on the stack, and <xref:System.Reflection.Emit.OpCodes.Clt> is emitted to compare them. If the index is less than the length, <xref:System.Reflection.Emit.OpCodes.Brtrue_S> branches back to the beginning of the loop.  
  
     [!code-csharp[GenericMethodHowTo#13](../../../samples/snippets/csharp/VS_Snippets_CLR/GenericMethodHowTo/CS/source.cs#13)]
     [!code-vb[GenericMethodHowTo#13](../../../samples/snippets/visualbasic/VS_Snippets_CLR/GenericMethodHowTo/VB/source.vb#13)]  
  
7.  Emit code to push the `TOutput` object onto the stack and return from the method. The local variables `retVal` and `ic` both contain references to the new `TOutput`; `ic` is used only to access the <xref:System.Collections.Generic.ICollection%601.Add%2A?displayProperty=nameWithType> method.  
  
     [!code-csharp[GenericMethodHowTo#33](../../../samples/snippets/csharp/VS_Snippets_CLR/GenericMethodHowTo/CS/source.cs#33)]
     [!code-vb[GenericMethodHowTo#33](../../../samples/snippets/visualbasic/VS_Snippets_CLR/GenericMethodHowTo/VB/source.vb#33)]  
  
<a name="procedureSection2"></a>   
### To invoke the generic method  
  
1.  `Factory` is a generic method definition. In order to invoke it, you must assign types to its generic type parameters. Use the <xref:System.Reflection.MethodInfo.MakeGenericMethod%2A> method to do this. The following code creates a constructed generic method, specifying <xref:System.String> for `TInput` and `List(Of String)` (`List<string>` in C#) for `TOutput`, and displays a string representation of the method.  
  
     [!code-csharp[GenericMethodHowTo#21](../../../samples/snippets/csharp/VS_Snippets_CLR/GenericMethodHowTo/CS/source.cs#21)]
     [!code-vb[GenericMethodHowTo#21](../../../samples/snippets/visualbasic/VS_Snippets_CLR/GenericMethodHowTo/VB/source.vb#21)]  
  
2.  To invoke the method late-bound, use the <xref:System.Reflection.MethodBase.Invoke%2A> method. The following code creates an array of <xref:System.Object>, containing as its only element an array of strings, and passes it as the argument list for the generic method. The first parameter of <xref:System.Reflection.MethodBase.Invoke%2A> is a null reference because the method is `static`. The return value is cast to `List(Of String)`, and its first element is displayed.  
  
     [!code-csharp[GenericMethodHowTo#22](../../../samples/snippets/csharp/VS_Snippets_CLR/GenericMethodHowTo/CS/source.cs#22)]
     [!code-vb[GenericMethodHowTo#22](../../../samples/snippets/visualbasic/VS_Snippets_CLR/GenericMethodHowTo/VB/source.vb#22)]  
  
3.  To invoke the method using a delegate, you must have a delegate that matches the signature of the constructed generic method. An easy way to do this is to create a generic delegate. The following code creates an instance of the generic delegate `D` defined in the example code, using the <xref:System.Delegate.CreateDelegate%28System.Type%2CSystem.Reflection.MethodInfo%29?displayProperty=nameWithType> method overload, and invokes the delegate. Delegates perform better than late-bound calls.  
  
     [!code-csharp[GenericMethodHowTo#23](../../../samples/snippets/csharp/VS_Snippets_CLR/GenericMethodHowTo/CS/source.cs#23)]
     [!code-vb[GenericMethodHowTo#23](../../../samples/snippets/visualbasic/VS_Snippets_CLR/GenericMethodHowTo/VB/source.vb#23)]  
  
4.  The emitted method can also be called from a program that refers to the saved assembly.  
  
## Example  
 The following code example creates a nongeneric type, `DemoType`, with a generic method, `Factory`. This method has two generic type parameters, `TInput` to specify an input type and `TOutput` to specify an output type. The `TOutput` type parameter is constrained to implement `ICollection<TInput>` (`ICollection(Of TInput)` in Visual Basic), to be a reference type, and to have a parameterless constructor.  
  
 The method has one formal parameter, which is an array of `TInput`. The method returns an instance of `TOutput` that contains all the elements of the input array. `TOutput` can be any generic collection type that implements the <xref:System.Collections.Generic.ICollection%601> generic interface.  
  
 When the code is executed, the dynamic assembly is saved as DemoGenericMethod1.dll, and can be examined using the [Ildasm.exe (IL Disassembler)](../../../docs/framework/tools/ildasm-exe-il-disassembler.md).  
  
> [!NOTE]
>  A good way to learn how to emit code is to write a Visual Basic, C#, or Visual C++ program that performs the task you are trying to emit, and use the disassembler to examine the MSIL produced by the compiler.  
  
 The code example includes source code that is equivalent to the emitted method. The emitted method is invoked late-bound and also by using a generic delegate declared in the code example.  
  
 [!code-csharp[GenericMethodHowTo#1](../../../samples/snippets/csharp/VS_Snippets_CLR/GenericMethodHowTo/CS/source.cs#1)]
 [!code-vb[GenericMethodHowTo#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/GenericMethodHowTo/VB/source.vb#1)]  
  
## Compiling the Code  
  
-   The code contains the C# `using` statements (`Imports` in Visual Basic) necessary for compilation.  
  
-   No additional assembly references are required.  
  
-   Compile the code at the command line using csc.exe, vbc.exe, or cl.exe. To compile the code in Visual Studio, place it in a console application project template.  
  
## See Also  
 <xref:System.Reflection.Emit.MethodBuilder>  
 [How to: Define a Generic Type with Reflection Emit](../../../docs/framework/reflection-and-codedom/how-to-define-a-generic-type-with-reflection-emit.md)
