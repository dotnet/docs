---
title: "How to: Define a Generic Type with Reflection Emit"
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
  - "generics [.NET Framework], reflection emit"
  - "generics [.NET Framework], dynamic types"
  - "reflection emit, generic types"
ms.assetid: 07d5f01a-7b5b-40ea-9b15-f21561098fe4
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Define a Generic Type with Reflection Emit
This topic shows how to create a simple generic type with two type parameters, how to apply class constraints, interface constraints, and special constraints to the type parameters, and how to create members that use the type parameters of the class as parameter types and return types.  
  
> [!IMPORTANT]
>  A method is not generic just because it belongs to a generic type and uses the type parameters of that type. A method is generic only if it has its own type parameter list. Most methods on generic types are not generic, as in this example. For an example of emitting a generic method, see [How to: Define a Generic Method with Reflection Emit](../../../docs/framework/reflection-and-codedom/how-to-define-a-generic-method-with-reflection-emit.md).  
  
### To define a generic type  
  
1.  Define a dynamic assembly named `GenericEmitExample1`. In this example, the assembly is executed and saved to disk, so <xref:System.Reflection.Emit.AssemblyBuilderAccess.RunAndSave?displayProperty=nameWithType> is specified.  
  
     [!code-cpp[EmitGenericType#2](../../../samples/snippets/cpp/VS_Snippets_CLR/EmitGenericType/CPP/source.cpp#2)]
     [!code-csharp[EmitGenericType#2](../../../samples/snippets/csharp/VS_Snippets_CLR/EmitGenericType/CS/source.cs#2)]
     [!code-vb[EmitGenericType#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/EmitGenericType/VB/source.vb#2)]  
  
2.  Define a dynamic module. An assembly is made up of executable modules. For a single-module assembly, the module name is the same as the assembly name, and the file name is the module name plus an extension.  
  
     [!code-cpp[EmitGenericType#3](../../../samples/snippets/cpp/VS_Snippets_CLR/EmitGenericType/CPP/source.cpp#3)]
     [!code-csharp[EmitGenericType#3](../../../samples/snippets/csharp/VS_Snippets_CLR/EmitGenericType/CS/source.cs#3)]
     [!code-vb[EmitGenericType#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/EmitGenericType/VB/source.vb#3)]  
  
3.  Define a class. In this example, the class is named `Sample`.  
  
     [!code-cpp[EmitGenericType#4](../../../samples/snippets/cpp/VS_Snippets_CLR/EmitGenericType/CPP/source.cpp#4)]
     [!code-csharp[EmitGenericType#4](../../../samples/snippets/csharp/VS_Snippets_CLR/EmitGenericType/CS/source.cs#4)]
     [!code-vb[EmitGenericType#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/EmitGenericType/VB/source.vb#4)]  
  
4.  Define the generic type parameters of `Sample` by passing an array of strings containing the names of the parameters to the <xref:System.Reflection.Emit.TypeBuilder.DefineGenericParameters%2A?displayProperty=nameWithType> method. This makes the class a generic type. The return value is an array of <xref:System.Reflection.Emit.GenericTypeParameterBuilder> objects representing the type parameters, which can be used in your emitted code.  
  
     In the following code, `Sample` becomes a generic type with type parameters `TFirst` and `TSecond`. To make the code easier to read, each <xref:System.Reflection.Emit.GenericTypeParameterBuilder> is placed in a variable with the same name as the type parameter.  
  
     [!code-cpp[EmitGenericType#5](../../../samples/snippets/cpp/VS_Snippets_CLR/EmitGenericType/CPP/source.cpp#5)]
     [!code-csharp[EmitGenericType#5](../../../samples/snippets/csharp/VS_Snippets_CLR/EmitGenericType/CS/source.cs#5)]
     [!code-vb[EmitGenericType#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/EmitGenericType/VB/source.vb#5)]  
  
5.  Add special constraints to the type parameters. In this example, type parameter `TFirst` is constrained to types that have parameterless constructors, and to reference types.  
  
     [!code-cpp[EmitGenericType#6](../../../samples/snippets/cpp/VS_Snippets_CLR/EmitGenericType/CPP/source.cpp#6)]
     [!code-csharp[EmitGenericType#6](../../../samples/snippets/csharp/VS_Snippets_CLR/EmitGenericType/CS/source.cs#6)]
     [!code-vb[EmitGenericType#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/EmitGenericType/VB/source.vb#6)]  
  
6.  Optionally add class and interface constraints to the type parameters. In this example, type parameter `TFirst` is constrained to types that derive from the base class represented by the <xref:System.Type> object contained in the variable `baseType`, and that implement the interfaces whose types are contained in the variables `interfaceA` and `interfaceB`. See the code example for the declaration and assignment of these variables.  
  
     [!code-cpp[EmitGenericType#7](../../../samples/snippets/cpp/VS_Snippets_CLR/EmitGenericType/CPP/source.cpp#7)]
     [!code-csharp[EmitGenericType#7](../../../samples/snippets/csharp/VS_Snippets_CLR/EmitGenericType/CS/source.cs#7)]
     [!code-vb[EmitGenericType#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/EmitGenericType/VB/source.vb#7)]  
  
7.  Define a field. In this example, the type of the field is specified by type parameter `TFirst`. <xref:System.Reflection.Emit.GenericTypeParameterBuilder> derives from <xref:System.Type>, so you can use generic type parameters anywhere a type can be used.  
  
     [!code-cpp[EmitGenericType#21](../../../samples/snippets/cpp/VS_Snippets_CLR/EmitGenericType/CPP/source.cpp#21)]
     [!code-csharp[EmitGenericType#21](../../../samples/snippets/csharp/VS_Snippets_CLR/EmitGenericType/CS/source.cs#21)]
     [!code-vb[EmitGenericType#21](../../../samples/snippets/visualbasic/VS_Snippets_CLR/EmitGenericType/VB/source.vb#21)]  
  
8.  Define a method that uses the type parameters of the generic type. Note that such methods are not generic unless they have their own type parameter lists. The following code defines a `static` method (`Shared` in Visual Basic) that takes an array of `TFirst` and returns a `List<TFirst>` (`List(Of TFirst)` in Visual Basic) containing all the elements of the array. To define this method, it is necessary to create the type `List<TFirst>` by calling <xref:System.Type.MakeGenericType%2A> on the generic type definition, `List<T>`. (The `T` is omitted when you use the `typeof` operator (`GetType` in Visual Basic) to get the generic type definition.) The parameter type is created by using the <xref:System.Type.MakeArrayType%2A> method.  
  
     [!code-cpp[EmitGenericType#22](../../../samples/snippets/cpp/VS_Snippets_CLR/EmitGenericType/CPP/source.cpp#22)]
     [!code-csharp[EmitGenericType#22](../../../samples/snippets/csharp/VS_Snippets_CLR/EmitGenericType/CS/source.cs#22)]
     [!code-vb[EmitGenericType#22](../../../samples/snippets/visualbasic/VS_Snippets_CLR/EmitGenericType/VB/source.vb#22)]  
  
9. Emit the method body. The method body consists of three opcodes that load the input array onto the stack, call the `List<TFirst>` constructor that takes `IEnumerable<TFirst>` (which does all the work of putting the input elements into the list), and return (leaving the new <xref:System.Collections.Generic.List%601> object on the stack). The difficult part of emitting this code is getting the constructor.  
  
     The <xref:System.Type.GetConstructor%2A> method is not supported on a <xref:System.Reflection.Emit.GenericTypeParameterBuilder>, so it is not possible to get the constructor of `List<TFirst>` directly. First, it is necessary to get the constructor of the generic type definition `List<T>` and then to call a method that converts it to the corresponding constructor of `List<TFirst>`.  
  
     The constructor used for this code example takes an `IEnumerable<T>`. Note, however, that this is not the generic type definition of the <xref:System.Collections.Generic.IEnumerable%601> generic interface; instead, the type parameter `T` from `List<T>` must be substituted for the type parameter `T` of `IEnumerable<T>`. (This seems confusing only because both types have type parameters named `T`. That is why this code example uses the names `TFirst` and `TSecond`.) To get the type of the constructor argument, start with the generic type definition `IEnumerable<T>` and call <xref:System.Type.MakeGenericType%2A> with the first generic type parameter of `List<T>`. The constructor argument list must be passed as an array, with just one argument in this case.  
  
    > [!NOTE]
    >  The generic type definition is expressed as `IEnumerable<>` when you use the `typeof` operator in C#, or `IEnumerable(Of )` when you use the `GetType` operator in Visual Basic.  
  
     Now it is possible to get the constructor of `List<T>` by calling <xref:System.Type.GetConstructor%2A> on the generic type definition. To convert this constructor to the corresponding constructor of `List<TFirst>`, pass `List<TFirst>` and the constructor from `List<T>` to the static <xref:System.Reflection.Emit.TypeBuilder.GetConstructor%28System.Type%2CSystem.Reflection.ConstructorInfo%29?displayProperty=nameWithType> method.  
  
     [!code-cpp[EmitGenericType#23](../../../samples/snippets/cpp/VS_Snippets_CLR/EmitGenericType/CPP/source.cpp#23)]
     [!code-csharp[EmitGenericType#23](../../../samples/snippets/csharp/VS_Snippets_CLR/EmitGenericType/CS/source.cs#23)]
     [!code-vb[EmitGenericType#23](../../../samples/snippets/visualbasic/VS_Snippets_CLR/EmitGenericType/VB/source.vb#23)]  
  
10. Create the type and save the file.  
  
     [!code-cpp[EmitGenericType#8](../../../samples/snippets/cpp/VS_Snippets_CLR/EmitGenericType/CPP/source.cpp#8)]
     [!code-csharp[EmitGenericType#8](../../../samples/snippets/csharp/VS_Snippets_CLR/EmitGenericType/CS/source.cs#8)]
     [!code-vb[EmitGenericType#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/EmitGenericType/VB/source.vb#8)]  
  
11. Invoke the method. `ExampleMethod` is not generic, but the type it belongs to is generic, so in order to get a <xref:System.Reflection.MethodInfo> that can be invoked it is necessary to create a constructed type from the type definition for `Sample`. The constructed type uses the `Example` class, which satisfies the constraints on `TFirst` because it is a reference type and has a default parameterless constructor, and the `ExampleDerived` class which satisfies the constraints on `TSecond`. (The code for `ExampleDerived` can be found in the example code section.) These two types are passed to <xref:System.Type.MakeGenericType%2A> to create the constructed type. The <xref:System.Reflection.MethodInfo> is then obtained using the <xref:System.Type.GetMethod%2A> method.  
  
     [!code-cpp[EmitGenericType#9](../../../samples/snippets/cpp/VS_Snippets_CLR/EmitGenericType/CPP/source.cpp#9)]
     [!code-csharp[EmitGenericType#9](../../../samples/snippets/csharp/VS_Snippets_CLR/EmitGenericType/CS/source.cs#9)]
     [!code-vb[EmitGenericType#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR/EmitGenericType/VB/source.vb#9)]  
  
12. The following code creates an array of `Example` objects, places that array in an array of type <xref:System.Object> representing the arguments of the method to be invoked, and passes them to the <xref:System.Reflection.MethodBase.Invoke%28System.Object%2CSystem.Object%5B%5D%29> method. The first argument of the <xref:System.Reflection.MethodBase.Invoke%2A> method is a null reference because the method is `static`.  
  
     [!code-cpp[EmitGenericType#10](../../../samples/snippets/cpp/VS_Snippets_CLR/EmitGenericType/CPP/source.cpp#10)]
     [!code-csharp[EmitGenericType#10](../../../samples/snippets/csharp/VS_Snippets_CLR/EmitGenericType/CS/source.cs#10)]
     [!code-vb[EmitGenericType#10](../../../samples/snippets/visualbasic/VS_Snippets_CLR/EmitGenericType/VB/source.vb#10)]  
  
## Example  
 The following code example defines a class named `Sample`, along with a base class and two interfaces. The program defines two generic type parameters for `Sample`, turning it into a generic type. Type parameters are the only thing that makes a type generic. The program shows this by displaying a test message before and after the definition of the type parameters.  
  
 The type parameter `TSecond` is used to demonstrate class and interface constraints, using the base class and interfaces, and the type parameter `TFirst` is used to demonstrate special constraints.  
  
 The code example defines a field and a method using the class's type parameters for the field type and for the parameter and return type of the method.  
  
 After the `Sample` class has been created, the method is invoked.  
  
 The program includes a method that lists information about a generic type, and a method that lists the special constraints on a type parameter. These methods are used to display information about the finished `Sample` class.  
  
 The program saves the finished module to disk as `GenericEmitExample1.dll`, so you can open it with the [Ildasm.exe (IL Disassembler)](../../../docs/framework/tools/ildasm-exe-il-disassembler.md) and examine the MSIL for the `Sample` class.  
  
 [!code-cpp[EmitGenericType#1](../../../samples/snippets/cpp/VS_Snippets_CLR/EmitGenericType/CPP/source.cpp#1)]
 [!code-csharp[EmitGenericType#1](../../../samples/snippets/csharp/VS_Snippets_CLR/EmitGenericType/CS/source.cs#1)]
 [!code-vb[EmitGenericType#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/EmitGenericType/VB/source.vb#1)]  
  
## Compiling the Code  
  
-   The code contains the C# `using` statements (`Imports` in Visual Basic) necessary for compilation.  
  
-   No additional assembly references are required.  
  
-   Compile the code at the command line using csc.exe, vbc.exe, or cl.exe. To compile the code in Visual Studio, place it in a console application project template.  
  
## See Also  
 <xref:System.Reflection.Emit.GenericTypeParameterBuilder>  
 [Using Reflection Emit](http://msdn.microsoft.com/library/ccc6540d-0e2c-4d89-b456-eb7353f9e9ac)  
 [Reflection Emit Dynamic Assembly Scenarios](http://msdn.microsoft.com/library/e1cc6750-e20f-473b-bb4e-f43bc66aecce)
