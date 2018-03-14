---
title: "Methods (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "methods [C#]"
  - "C# language, methods"
ms.assetid: cc738f07-e8cd-4683-9585-9f40c0667c37
caps.latest.revision: 41
author: "BillWagner"
ms.author: "wiwagn"
---
# Methods (C# Programming Guide)
A method is a code block that contains a series of statements. A program causes the statements to be executed by calling the method and specifying any required method arguments. In C#, every executed instruction is performed in the context of a method. The Main method is the entry point for every C# application and it is called by the common language runtime (CLR) when the program is started.  
  
> [!NOTE]
>  This topic discusses named methods. For information about anonymous functions, see [Anonymous Functions](../../../csharp/programming-guide/statements-expressions-operators/anonymous-functions.md).  
  
## Method Signatures  
 Methods are declared in a [class](../../../csharp/language-reference/keywords/class.md) or [struct](../../../csharp/language-reference/keywords/struct.md) by specifying the access level such as `public` or `private`, optional modifiers such as `abstract` or `sealed`, the return value, the name of the method, and any method parameters. These parts together are the signature of the method.  
  
> [!NOTE]
>  A return type of a method is not part of the signature of the method for the purposes of method overloading. However, it is part of the signature of the method when determining the compatibility between a delegate and the method that it points to.  
  
 Method parameters are enclosed in parentheses and are separated by commas. Empty parentheses indicate that the method requires no parameters. This class contains three methods:  
  
 [!code-csharp[csProgGuideObjects#40](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/methods_1.cs)]  
  
## Method Access  
 Calling a method on an object is like accessing a field. After the object name, add a period, the name of the method, and parentheses. Arguments are listed within the parentheses, and are separated by commas. The methods of the `Motorcycle` class can therefore be called as in the following example:  
  
 [!code-csharp[csProgGuideObjects#41](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/methods_2.cs)]  
  
## Method Parameters vs. Arguments  
 The method definition specifies the names and types of any parameters that are required. When calling code calls the method, it provides concrete values called arguments for each parameter. The arguments must be compatible with the parameter type but the argument name (if any) used in the calling code does not have to be the same as the parameter named defined in the method. For example:  
  
 [!code-csharp[csProgGuideObjects#74](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/methods_3.cs)]  
  
## Passing by Reference vs. Passing by Value  
 By default, when a value type is passed to a method, a copy is passed instead of the object itself. Therefore, changes to the argument have no effect on the original copy in the calling method. You can pass a value-type by reference by using the ref keyword. For more information, see [Passing Value-Type Parameters](../../../csharp/programming-guide/classes-and-structs/passing-value-type-parameters.md). For a list of built-in value types, see [Value Types Table](../../../csharp/language-reference/keywords/value-types-table.md).  
  
 When an object of a reference type is passed to a method, a reference to the object is passed. That is, the method receives not the object itself but an argument that indicates the location of the object. If you change a member of the object by using this reference, the change is reflected in the argument in the calling method, even if you pass the object by value.  
  
 You create a reference type by using the `class` keyword, as the following example shows.  
  
 [!code-csharp[csProgGuideObjects#42](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/methods_4.cs)]  
  
 Now, if you pass an object that is based on this type to a method, a reference to the object is passed. The following example passes an object of type `SampleRefType` to method `ModifyObject`.  
  
 [!code-csharp[csProgGuideObjects#75](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/methods_5.cs)]  
  
 The example does essentially the same thing as the previous example in that it passes an argument by value to a method. But, because a reference type is used, the result is different. The modification that is made in `ModifyObject` to the `value` field of the parameter, `obj`, also changes the `value` field of the argument, `rt`, in the `TestRefType` method. The `TestRefType` method displays 33 as the output.  
  
 For more information about how to pass reference types by reference and by value, see [Passing Reference-Type Parameters](../../../csharp/programming-guide/classes-and-structs/passing-reference-type-parameters.md) and [Reference Types](../../../csharp/language-reference/keywords/reference-types.md).  
  
## Return Values  
Methods can return a value to the caller. If the return type, the type listed before the method name, is not `void`, the method can return the value by using the `return` keyword. A statement with the `return` keyword followed by a value that matches the return type will return that value to the method caller. 

The value can be returned to the caller by value or, starting with C# 7, [by reference](ref-returns.md). Values are returned to the caller by reference if the `ref` keyword is used in the method signature and it follows each `return` keyword. For example, the following method signature and return statement indicate that the method returns a variable names `estDistance` by reference to the caller.

```csharp
public ref double GetEstimatedDistance()
{
   return ref estDistance;
}
```

The `return` keyword also stops the execution of the method. If the return type is `void`, a `return` statement without a value is still useful to stop the execution of the method. Without the `return` keyword, the method will stop executing when it reaches the end of the code block. Methods with a non-void return type are required to use the `return` keyword to return a value. For example, these two methods use the `return` keyword to return integers:  
  
 [!code-csharp[csProgGuideObjects#44](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/methods_6.cs)]  
  
 To use a value returned from a method, the calling method can use the method call itself anywhere a value of the same type would be sufficient. You can also assign the return value to a variable. For example, the following two code examples accomplish the same goal:  
  
 [!code-csharp[csProgGuideObjects#45](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/methods_7.cs)]  
  
 [!code-csharp[csProgGuideObjects#46](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/methods_8.cs)]  
  
 Using a local variable, in this case, `result`, to store a value is optional. It may help the readability of the code, or it may be necessary if you need to store the original value of the argument for the entire scope of the method.  

To use a value returned by reference from a method, you must declare a [ref local](ref-returns.md#ref-locals) variable if you intend to modify its value. For example, if the `Planet.GetEstimatedDistance` method returns a <xref:System.Double> value by reference, you can define it as a ref local variable with code like the following:

```csharp
ref int distance = plant 
```

Returning a multi-dimensional array from a method, `M`, that modifies the array's contents is not necessary if the calling function passed the array into `M`.  You may return the resulting array from `M` for good style or functional flow of values, but it is not necessary because C# passes all reference types by value, and the value of an array reference is the pointer to the array. In the method `M`, any changes to the array's contents are observable by any code that has a reference to the array, as shown in the following example.  
  
```csharp  
static void Main(string[] args)  
        {  
            int[,] matrix = new int[2, 2];  
            FillMatrix(matrix);  
            // matrix is now full of -1  
        }  
  
        public static void FillMatrix(int[,] matrix)  
        {  
            for (int i = 0; i < matrix.GetLength(0); i++)  
            {  
                for (int j = 0; j < matrix.GetLength(1); j++)  
                {  
                    matrix[i, j] = -1;  
                }  
            }  
        }  
```  
  
 For more information, see [return](../../../csharp/language-reference/keywords/return.md).  
  
## Async Methods  
 By using the async feature, you can invoke asynchronous methods without using explicit callbacks or manually splitting your code across multiple methods or lambda expressions. 
  
 If you mark a method with the [async](../../../csharp/language-reference/keywords/async.md) modifier, you can use the [await](../../../csharp/language-reference/keywords/await.md) operator in the method. When control reaches an await expression in the async method, control returns to the caller, and progress in the method is suspended until the awaited task completes. When the task is complete, execution can resume in the method.  
  
> [!NOTE]
>  An async method returns to the caller when either it encounters the first awaited object that’s not yet complete or it gets to the end of the async method, whichever occurs first.  
  
 An async method can have a return type of <xref:System.Threading.Tasks.Task%601>, <xref:System.Threading.Tasks.Task>, or void. The void return type is used primarily to define event handlers, where a void return type is required. An async method that returns void can't be awaited, and the caller of a void-returning method can't catch exceptions that the method throws.  
  
 In the following example, `DelayAsync` is an async method that has a return type of <xref:System.Threading.Tasks.Task%601>. `DelayAsync` has a `return` statement that returns an integer. Therefore the method declaration of `DelayAsync` must have a return type of `Task<int>`. Because the return type is `Task<int>`, the evaluation of the `await` expression in `DoSomethingAsync` produces an integer as the following statement demonstrates: `int result = await delayTask`.  
  
 The `startButton_Click` method is an example of an async method that has a return type of void. Because `DoSomethingAsync` is an async method, the task for the call to `DoSomethingAsync` must be awaited, as the following statement shows: `await DoSomethingAsync();`. The `startButton_Click` method must be defined with the `async` modifier because the method has an `await` expression.  
  
 [!code-csharp[csAsyncMethod#2](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/methods_9.cs)]  
  
 An async method can't declare any [ref](../../../csharp/language-reference/keywords/ref.md) or [out](../../../csharp/language-reference/keywords/out-parameter-modifier.md) parameters, but it can call methods that have such parameters.  
  
 For more information about async methods, see [Asynchronous Programming with async and await](../../../csharp/programming-guide/concepts/async/index.md), [Control Flow in Async Programs](../../../csharp/programming-guide/concepts/async/control-flow-in-async-programs.md), and [Async Return Types](../../../csharp/programming-guide/concepts/async/async-return-types.md).  
  
## Expression Body Definitions  
 It is common to have method definitions that simply return immediately with the result of an expression, or that have a single statement as the body of the method.  There is a syntax shortcut for defining such methods using `=>`:  
  
```csharp  
public Point Move(int dx, int dy) => new Point(x + dx, y + dy);   
public void Print() => Console.WriteLine(First + " " + Last);  
// Works with operators, properties, and indexers too.  
public static Complex operator +(Complex a, Complex b) => a.Add(b);  
public string Name => First + " " + Last;   
public Customer this[long id] => store.LookupCustomer(id);  
```  
  
 If the method returns `void` or is an async method, then the body of the method must be a statement expression (same as with lambdas).  For properties and indexers, they must be read only, and you don't use the `get` accessor keyword.  
  
## Iterators  
 An iterator performs a custom iteration over a collection, such as a list or an array. An iterator uses the [yield return](../../../csharp/language-reference/keywords/yield.md) statement to return each element one at a time. When a [yield return](../../../csharp/language-reference/keywords/yield.md) statement is reached, the current location in code is remembered. Execution is restarted from that location when the iterator is called the next time.  
  
 You call an iterator from client code by using a [foreach](../../../csharp/language-reference/keywords/foreach-in.md) statement.  
  
 The return type of an iterator can be <xref:System.Collections.IEnumerable>, <xref:System.Collections.Generic.IEnumerable%601>, <xref:System.Collections.IEnumerator>, or <xref:System.Collections.Generic.IEnumerator%601>.  
  
 For more information, see [Iterators](http://msdn.microsoft.com/library/f45331db-d595-46ec-9142-551d3d1eb1a7).  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Classes and Structs](index.md)  
 [Access Modifiers](access-modifiers.md)  
 [Static Classes and Static Class Members](static-classes-and-static-class-members.md)  
 [Inheritance](inheritance.md)  
 [Abstract and Sealed Classes and Class Members](abstract-and-sealed-classes-and-class-members.md)  
 [params](../../../csharp/language-reference/keywords/params.md)  
 [return](../../../csharp/language-reference/keywords/return.md)  
 [out](../../../csharp/language-reference/keywords/out.md)  
 [ref](../../../csharp/language-reference/keywords/ref.md)  
 [Passing Parameters](passing-parameters.md)
