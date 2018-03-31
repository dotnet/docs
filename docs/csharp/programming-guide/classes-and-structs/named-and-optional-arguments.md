---
title: "Named and Optional Arguments (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "namedParameter_CSharpKeyword"
  - "cs_namedParameter"
helpviewer_keywords: 
  - "parameters [C#], named"
  - "named arguments [C#]"
  - "arguments [C#], named"
  - "optional arguments [C#]"
  - "arguments [C#], optional"
  - "parameters [C#], optional"
  - "named and optional arguments [C#]"
ms.assetid: 839c960c-c2dc-4d05-af4d-ca5428e54008
caps.latest.revision: 43
author: "BillWagner"
ms.author: "wiwagn"
---
# Named and Optional Arguments (C# Programming Guide)
[!INCLUDE[csharp_dev10_long](~/includes/csharp-dev10-long-md.md)] introduces named and optional arguments. *Named arguments* enable you to specify an argument for a particular parameter by associating the argument with the parameter's name rather than with the parameter's position in the parameter list. *Optional arguments* enable you to omit arguments for some parameters. Both techniques can be used with methods, indexers, constructors, and delegates.  
  
 When you use named and optional arguments, the arguments are evaluated in the order in which they appear in the argument list, not the parameter list.  
  
 Named and optional parameters, when used together, enable you to supply arguments for only a few parameters from a list of optional parameters. This capability greatly facilitates calls to COM interfaces such as the Microsoft Office Automation APIs.  
  
## Named Arguments  
 Named arguments free you from the need to remember or to look up the order of parameters in the parameter lists of called methods. The parameter for each argument can be specified by parameter name. For example, a function that prints order details (such as, seller name, order number & product name) can be called in the standard way by sending arguments by position, in the order defined by the function.
  
 `PrintOrderDetails("Gift Shop", 31, "Red Mug");`
  
 If you do not remember the order of the parameters but know their names, you can send the arguments in any order.  
  
 `PrintOrderDetails(orderNum: 31, productName: "Red Mug", sellerName: "Gift Shop");`
  
 `PrintOrderDetails(productName: "Red Mug", sellerName: "Gift Shop", orderNum: 31);`
  
 Named arguments also improve the readability of your code by identifying what each argument represents. In the example method below, the `sellerName` cannot be null or white space. As both `sellerName` and `productName` are string types, instead of sending arguments by position, it makes sense to use named arguments to disambiguate the two and reduce confusion for anyone reading the code.
  
 Named arguments, when used with positional arguments, are valid as long as 

- they're not followed by any positional arguments, or

 `PrintOrderDetails("Gift Shop", 31, productName: "Red Mug");`

- _starting with C# 7.2_, they're used in the correct position. In the example below, the parameter `orderNum` is in the correct position but isn't explicitly named.

 `PrintOrderDetails(sellerName: "Gift Shop", 31, productName: "Red Mug");`
  
 However, out-of-order named arguments are invalid if they're followed by positional arguments.

 ```csharp
 // This generates CS1738: Named argument specifications must appear after all fixed arguments have been specified.
 PrintOrderDetails(productName: "Red Mug", 31, "Gift Shop");
 ```
  
## Example  
 The following code implements the examples from this section along with some additional ones.  
  
 [!code-csharp[csProgGuideNamedAndOptional#1](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/named-and-optional-arguments_1.cs)]  
  
## Optional Arguments  
 The definition of a method, constructor, indexer, or delegate can specify that its parameters are required or that they are optional. Any call must provide arguments for all required parameters, but can omit arguments for optional parameters.  
  
 Each optional parameter has a default value as part of its definition. If no argument is sent for that parameter, the default value is used. A default value must be one of the following types of expressions:  
  
-   a constant expression;  
  
-   an expression of the form `new ValType()`, where `ValType` is a value type, such as an [enum](../../../csharp/language-reference/keywords/enum.md) or a [struct](../../../csharp/programming-guide/classes-and-structs/structs.md);  
  
-   an expression of the form [default(ValType)](../../../csharp/programming-guide/statements-expressions-operators/default-value-expressions.md),  where `ValType` is a value type.  
  
 Optional parameters are defined at the end of the parameter list, after any required parameters. If the caller provides an argument for any one of a succession of optional parameters, it must provide arguments for all preceding optional parameters. Comma-separated gaps in the argument list are not supported. For example, in the following code, instance method `ExampleMethod` is defined with one required and two optional parameters.  
  
 [!code-csharp[csProgGuideNamedAndOptional#15](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/named-and-optional-arguments_2.cs)]  
  
 The following call to `ExampleMethod` causes a compiler error, because an argument is provided for the third parameter but not for the second.  
  
 `//anExample.ExampleMethod(3, ,4);`  
  
 However, if you know the name of the third parameter, you can use a named argument to accomplish the task.  
  
 `anExample.ExampleMethod(3, optionalint: 4);`  
  
 IntelliSense uses brackets to indicate optional parameters, as shown in the following illustration.  
  
 ![IntelliSense Quick Info for method ExampleMethod.](../../../csharp/programming-guide/classes-and-structs/media/optional_parameters.png "Optional_Parameters")  
Optional parameters in ExampleMethod  
  
> [!NOTE]
>  You can also declare optional parameters by using the .NET <xref:System.Runtime.InteropServices.OptionalAttribute> class. `OptionalAttribute` parameters do not require a default value.  
  
## Example  
 In the following example, the constructor for `ExampleClass` has one parameter, which is optional. Instance method `ExampleMethod` has one required parameter, `required`, and two optional parameters, `optionalstr` and `optionalint`. The code in `Main` shows the different ways in which the constructor and method can be invoked.  
  
 [!code-csharp[csProgGuideNamedAndOptional#2](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/named-and-optional-arguments_3.cs)]  
  
## COM Interfaces  
 Named and optional arguments, along with support for dynamic objects and other enhancements, greatly improve interoperability with COM APIs, such as Office Automation APIs.  
  
 For example, the [AutoFormat](https://msdn.microsoft.com/library/microsoft.office.interop.excel.range.autoformat(v=office.15).aspx) method in the Microsoft Office Excel [Range](https://msdn.microsoft.com/library/microsoft.office.interop.excel.range(v=office.15).aspx) interface has seven parameters, all of which are optional. These parameters are shown in the following illustration.  
  
 ![IntelliSense Quick Info for the AutoFormat method.](../../../csharp/programming-guide/classes-and-structs/media/autoformat_parameters.png "AutoFormat_Parameters")  
AutoFormat parameters  
  
 In C# 3.0 and earlier versions, an argument is required for each parameter, as shown in the following example.  
  
 [!code-csharp[csProgGuideNamedAndOptional#3](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/named-and-optional-arguments_4.cs)]  
  
 However, you can greatly simplify the call to `AutoFormat` by using named and optional arguments, introduced in C# 4.0. Named and optional arguments enable you to omit the argument for an optional parameter if you do not want to change the parameter's default value. In the following call, a value is specified for only one of the seven parameters.  
  
 [!code-csharp[csProgGuideNamedAndOptional#13](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/named-and-optional-arguments_5.cs)]  
  
 For more information and examples, see [How to: Use Named and Optional Arguments in Office Programming](../../../csharp/programming-guide/classes-and-structs/how-to-use-named-and-optional-arguments-in-office-programming.md) and [How to: Access Office Interop Objects by Using Visual C# Features](../../../csharp/programming-guide/interop/how-to-access-office-onterop-objects.md).  
  
## Overload Resolution  
 Use of named and optional arguments affects overload resolution in the following ways:  
  
-   A method, indexer, or constructor is a candidate for execution if each of its parameters either is optional or corresponds, by name or by position, to a single argument in the calling statement, and that argument can be converted to the type of the parameter.  
  
-   If more than one candidate is found, overload resolution rules for preferred conversions are applied to the arguments that are explicitly specified. Omitted arguments for optional parameters are ignored.  
  
-   If two candidates are judged to be equally good, preference goes to a candidate that does not have optional parameters for which arguments were omitted in the call. This is a consequence of a general preference in overload resolution for candidates that have fewer parameters.  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [How to: Use Named and Optional Arguments in Office Programming](../../../csharp/programming-guide/classes-and-structs/how-to-use-named-and-optional-arguments-in-office-programming.md)  
 [Using Type dynamic](../../../csharp/programming-guide/types/using-type-dynamic.md)  
 [Using Constructors](../../../csharp/programming-guide/classes-and-structs/using-constructors.md)  
 [Using Indexers](../../../csharp/programming-guide/indexers/using-indexers.md)
