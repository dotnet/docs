---
title: Overview of methods
description: Overview of methods, method parameters, and method return values
ms.subservice: fundamentals
ms.date: 04/15/2025
---

# Methods in C\#

A method is a code block that contains a series of statements. A program causes the statements to be executed by calling the method and specifying any required method arguments. In C#, every executed instruction is performed in the context of a method.

> [!NOTE]
> This article discusses named methods. For information about anonymous functions, see [Lambda expressions](language-reference/operators/lambda-expressions.md).

## Method signatures

Methods are declared in a `class`, `record`, or `struct` by specifying:

- An optional access level, such as `public` or `private`. The default is `private`.
- Optional modifiers such as `abstract` or `sealed`.
- The return value, or `void` if the method has none.
- The method name.
- Any method parameters. Method parameters are enclosed in parentheses and are separated by commas. Empty parentheses indicate that the method requires no parameters.

These parts together form the method signature.

> [!IMPORTANT]
> A return type of a method isn't part of the signature of the method for the purposes of method overloading. However, it's part of the signature of the method when determining the compatibility between a delegate and the method that it points to.

The following example defines a class named `Motorcycle` that contains five methods:

:::code language="csharp" source="snippets/methods/methods40.cs" id="snippet40":::

The `Motorcycle` class includes an overloaded method, `Drive`. Two methods have the same name, but their parameter lists differentiate them.

## Method invocation

Methods can be either *instance* or *static*. You must instantiate an object to invoke an instance method on that instance; an instance method operates on that instance and its data. You invoke a static method by referencing the name of the type to which the method belongs; static methods don't operate on instance data. Attempting to call a static method through an object instance generates a compiler error.

Calling a method is like accessing a field. After the object name (if you're calling an instance method) or the type name (if you're calling a `static` method), add a period, the name of the method, and parentheses. Arguments are listed within the parentheses and are separated by commas.

The method definition specifies the names and types of any parameters that are required. When a caller invokes the method, it provides concrete values, called arguments, for each parameter. The arguments must be compatible with the parameter type, but the argument name, if one is used in the calling code, doesn't have to be the same as the parameter named defined in the method. In the following example, the `Square` method includes a single parameter of type `int` named *i*. The first method call passes the `Square` method a variable of type `int` named *num*; the second, a numeric constant; and the third, an expression.

:::code language="csharp" source="snippets/methods/params74.cs" id="snippet74":::

The most common form of method invocation used positional arguments; it supplies arguments in the same order as method parameters. The methods of the `Motorcycle` class can therefore be called as in the following example. The call to the `Drive` method, for example, includes two arguments that correspond to the two parameters in the method's syntax. The first becomes the value of the `miles` parameter. The second becomes the value of the `speed` parameter.

:::code language="csharp" source="snippets/methods/methods40.cs" id="snippet41":::

You can also use *named arguments* instead of positional arguments when invoking a method. When using named arguments, you specify the parameter name followed by a colon (":") and the argument. Arguments to the method can appear in any order, as long as all required arguments are present. The following example uses named arguments to invoke the `TestMotorcycle.Drive` method. In this example, the named arguments are passed in the opposite order from the method's parameter list.

:::code language="csharp" source="snippets/methods/named1.cs" id="snippet45":::

You can invoke a method using both positional arguments and named arguments. However, positional arguments can only follow named arguments when the named arguments are in the correct positions. The following example invokes the `TestMotorcycle.Drive` method from the previous example using one positional argument and one named argument.

:::code language="csharp" source="snippets/methods/named2.cs" id="snippet46":::

## Inherited and overridden methods

In addition to the members that are explicitly defined in a type, a type inherits members defined in its base classes. Since all types in the managed type system inherit directly or indirectly from the <xref:System.Object> class, all types inherit its members, such as <xref:System.Object.Equals(System.Object)>, <xref:System.Object.GetType>, and <xref:System.Object.ToString>. The following example defines a `Person` class, instantiates two `Person` objects, and calls the `Person.Equals` method to determine whether the two objects are equal. The `Equals` method, however, isn't defined in the `Person` class; it's inherited from <xref:System.Object>.

:::code language="csharp" source="snippets/methods/inherited1.cs" id="snippet104":::

Types can override inherited members by using the `override` keyword and providing an implementation for the overridden method. The method signature must be the same as the overridden method. The following example is like the previous one, except that it overrides the <xref:System.Object.Equals(System.Object)> method. (It also overrides the <xref:System.Object.GetHashCode> method, since the two methods are intended to provide consistent results.)

:::code language="csharp" source="snippets/methods/overridden1.cs" id="snippet105":::

## Passing parameters

Types in C# are either *value types* or *reference types*. For a list of built-in value types, see [Types](./language-reference/builtin-types/built-in-types.md). By default, both value types and reference types are passed by value to a method.

### Passing parameters by value

When a value type is passed to a method by value, a copy of the object instead of the object itself is passed to the method. Therefore, changes to the object in the called method have no effect on the original object when control returns to the caller.

The following example passes a value type to a method by value, and the called method attempts to change the value type's value. It defines a variable of type `int`, which is a value type, initializes its value to 20, and passes it to a method named `ModifyValue` that changes the variable's value to 30. When the method returns, however, the variable's value remains unchanged.

:::code language="csharp" source="snippets/methods/byvalue10.cs" id="snippet10":::

When an object of a reference type is passed to a method by value, a reference to the object is passed by value. That is, the method receives not the object itself, but an argument that indicates the location of the object. If you change a member of the object by using this reference, the change is reflected in the object when control returns to the calling method. However, replacing the object passed to the method has no effect on the original object when control returns to the caller.

The following example defines a class (which is a reference type) named `SampleRefType`. It instantiates a `SampleRefType` object, assigns 44 to its `value` field, and passes the object to the `ModifyObject` method. This example does essentially the same thing as the previous example&mdash;it passes an argument by value to a method. But because a reference type is used, the result is different. The modification that is made in `ModifyObject` to the `obj.value` field also changes the `value` field of the argument, `rt`, in the `Main` method to 33, as the output from the example shows.

:::code language="csharp" source="snippets/methods/byvalue42.cs" id="snippet42":::

### Passing parameters by reference

You pass a parameter by reference when you want to change the value of an argument in a method and want to reflect that change when control returns to the calling method. To pass a parameter by reference, you use the [`ref`](language-reference/keywords/ref.md) or [`out`](language-reference/keywords/method-parameters.md#out-parameter-modifier) keyword. You can also pass a value by reference to avoid copying but still prevent modifications using the [`in`](language-reference/keywords/method-parameters.md#in-parameter-modifier) keyword.

The following example is identical to the previous one except the value is passed by reference to the `ModifyValue` method. When the value of the parameter is modified in the `ModifyValue` method, the change in value is reflected when control returns to the caller.

:::code language="csharp" source="snippets/methods/byref106.cs" id="snippet106":::

A common pattern that uses by ref parameters involves swapping the values of variables. You pass two variables to a method by reference, and the method swaps their contents. The following example swaps integer values.

:::code language="csharp" source="snippets/methods/swap107.cs" id="snippet107":::

Passing a reference-type parameter allows you to change the value of the reference itself, rather than the value of its individual elements or fields.

### Parameter collections

Sometimes, the requirement that you specify the exact number of arguments to your method is restrictive. By using the `params` keyword to indicate that a parameter is a parameter collection, you allow your method to be called with a variable number of arguments. The parameter tagged with the `params` keyword must be a collection type, and it must be the last parameter in the method's parameter list.

A caller can then invoke the method in either of four ways for the `params` parameter:

- By passing a collection of the appropriate type that contains the desired number of elements. The example uses a [collection expression](./language-reference/operators/collection-expressions.md) so the compiler creates an appropriate collection type.
- By passing a comma-separated list of individual arguments of the appropriate type to the method. The compiler creates the appropriate collection type.
- By passing `null`.
- By not providing an argument to the parameter collection.

The following example defines a method named `GetVowels` that returns all the vowels from a parameter collection. The `Main` method illustrates all four ways of invoking the method. Callers aren't required to supply any arguments for parameters that include the `params` modifier. In that case, the parameter is an empty collection.

:::code language="csharp" source="snippets/methods/params75.cs" id="snippet75":::

Before C# 13, the `params` modifier can be used only with a single dimensional array.

## Optional parameters and arguments

A method definition can specify that its parameters are required or that they're optional. By default, parameters are required. Optional parameters are specified by including the parameter's default value in the method definition. When the method is called, if no argument is supplied for an optional parameter, the default value is used instead.

You assign the parameter's default value with one of the following kinds of expressions:

- A constant, such as a literal string or number.
- An expression of the form `default(SomeType)`, where `SomeType` can be either a value type or a reference type. If it's a reference type, it's effectively the same as specifying `null`. You can use the `default` literal, as the compiler can infer the type from the parameter's declaration.
- An expression of the form `new ValType()`, where `ValType` is a value type. This expression invokes the value type's implicit parameterless constructor, which isn't an actual member of the type.

  > [!NOTE]
  > When an expression of the form `new ValType()` invokes the explicitly defined parameterless constructor of a value type, the compiler generates an error as the default parameter value must be a compile-time constant. Use the `default(ValType)` expression or the `default` literal to provide the default parameter value. For more information about parameterless constructors, see the [Struct initialization and default values](language-reference/builtin-types/struct.md#struct-initialization-and-default-values) section of the [Structure types](language-reference/builtin-types/struct.md) article.

If a method includes both required and optional parameters, optional parameters are defined at the end of the parameter list, after all required parameters.

The following example defines a method, `ExampleMethod`, that has one required and two optional parameters.

:::code language="csharp" source="snippets/methods/optional1.cs" id="snippet21":::

The caller must supply an argument for all optional parameters up to the last optional parameter for which an argument is supplied. In the `ExampleMethod` method, for example, if the caller supplies an argument for the `description` parameter, it must also supply one for the `optionalInt` parameter. `opt.ExampleMethod(2, 2, "Addition of 2 and 2");` is a valid method call; `opt.ExampleMethod(2, , "Addition of 2 and 0");` generates an "Argument missing" compiler error.

If a method is called using named arguments or a combination of positional and named arguments, the caller can omit any arguments that follow the last positional argument in the method call.

The following example calls the `ExampleMethod` method three times. The first two method calls use positional arguments. The first omits both optional arguments, while the second omits the last argument. The third method call supplies a positional argument for the required parameter but uses a named argument to supply a value to the `description` parameter while omitting the `optionalInt` argument.

:::code language="csharp" source="snippets/methods/optional1.cs" id="snippet22":::

The use of optional parameters affects *overload resolution*, or the way the C# compiler determines which overload to invoke for a method call, as follows:

- A member is a candidate for execution if each of its parameters corresponds by name or by position to a single argument. Furthermore, that argument can be converted to the type of the parameter.
- If more than one candidate is found, overload resolution rules for preferred conversions are applied to the arguments that are explicitly specified. Omitted arguments for optional parameters are ignored.
- If two candidates are judged to be equally good, preference goes to a candidate that doesn't have optional parameters for which arguments were omitted in the call.

## Return values

Methods can return a value to the caller. If the return type (the type listed before the method name) isn't `void`, the method can return the value by using the `return` keyword. A statement with the `return` keyword followed by a variable, constant, or expression that matches the return type returns that value to the method caller. Methods with a nonvoid return type are required to use the `return` keyword to return a value. The `return` keyword also stops the execution of the method.

If the return type is `void`, a `return` statement without a value is still useful to stop the execution of the method. Without the `return` keyword, the method stops executing when it reaches the end of the code block.

For example, these two methods use the `return` keyword to return integers:

:::code language="csharp" source="snippets/methods/return44.cs" id="snippet44":::

The preceding examples are expression bodied members. Expression bodied members return the value returned by the expression.

You can also choose to define your methods with a statement body and a `return` statement:

:::code language="csharp" source="snippets/methods/return44.cs" id="snippet43":::

To use a value returned from a method, you can assign the return value to a variable:

:::code language="csharp" source="snippets/methods/return44.cs" id="snippet47":::

The calling method can also use the method call itself anywhere a value of the same type would be sufficient. For example, the following two code examples accomplish the same goal:

:::code language="csharp" source="snippets/methods/return44.cs" id="snippet45":::

:::code language="csharp" source="snippets/methods/return44.cs" id="snippet46":::

Sometimes, you want your method to return more than a single value. You use *tuple types* and *tuple literals* to return multiple values. The tuple type defines the data types of the tuple's elements. Tuple literals provide the actual values of the returned tuple. In the following example, `(string, string, string, int)` defines the tuple type returned by the `GetPersonalInfo` method. The expression `(per.FirstName, per.MiddleName, per.LastName, per.Age)` is the tuple literal; the method returns the first, middle, and family name, along with the age, of a `PersonInfo` object.

```csharp
public (string, string, string, int) GetPersonalInfo(string id)
{
    PersonInfo per = PersonInfo.RetrieveInfoById(id);
    return (per.FirstName, per.MiddleName, per.LastName, per.Age);
}
```

The caller can then consume the returned tuple using the following code:

```csharp
var person = GetPersonalInfo("111111111");
Console.WriteLine($"{person.Item1} {person.Item3}: age = {person.Item4}");
```

Names can also be assigned to the tuple elements in the tuple type definition. The following example shows an alternate version of the `GetPersonalInfo` method that uses named elements:

```csharp
public (string FName, string MName, string LName, int Age) GetPersonalInfo(string id)
{
    PersonInfo per = PersonInfo.RetrieveInfoById(id);
    return (per.FirstName, per.MiddleName, per.LastName, per.Age);
}
```

The previous call to the `GetPersonalInfo` method can then be modified as follows:

```csharp
var person = GetPersonalInfo("111111111");
Console.WriteLine($"{person.FName} {person.LName}: age = {person.Age}");
```

If a method takes an array as a parameter and modifies the value of individual elements, it isn't necessary for the method to return the array. C# passes all reference types by value, and the value of an array reference is the pointer to the array. In the following example, changes to the contents of the `values` array that are made in the `DoubleValues` method are observable by any code that has a reference to the array.

:::code language="csharp" source="snippets/methods/returnarray1.cs" id="snippet101":::

## Extension methods

Ordinarily, there are two ways to add a method to an existing type:

- Modify the source code for that type. Modifying the source creates a breaking change if you also add any private data fields to support the method.
- Define the new method in a derived class. A method can't be added in this way using inheritance for other types, such as structures and enumerations. Nor can it be used to "add" a method to a sealed class.

Extension members let you "add" members to an existing type without modifying the type itself or implementing the new method in an inherited type. The extension member also doesn't have to reside in the same assembly as the type it extends. You call an extension method as if it were a defined member of a type.

For more information, see [Extension members](programming-guide/classes-and-structs/extension-methods.md).

## Async Methods

By using the async feature, you can invoke asynchronous methods without using explicit callbacks or manually splitting your code across multiple methods or lambda expressions.

If you mark a method with the [async](language-reference/keywords/async.md) modifier, you can use the [await](language-reference/operators/await.md) operator in the method. When control reaches an `await` expression in the async method, control returns to the caller if the awaited task isn't completed, and progress in the method with the `await` keyword is suspended until the awaited task completes. When the task is complete, execution can resume in the method.

> [!NOTE]
> An async method returns to the caller when either it encounters the first awaited object that's not yet complete or it gets to the end of the async method, whichever occurs first.

An async method typically has a return type of <xref:System.Threading.Tasks.Task%601>, <xref:System.Threading.Tasks.Task>, <xref:System.Collections.Generic.IAsyncEnumerable%601>, or `void`. The `void` return type is used primarily to define event handlers, where a `void` return type is required. An async method that returns `void` can't be awaited, and the caller of a void-returning method can't catch exceptions that the method throws. An async method can have [any task-like return type](language-reference/keywords/async.md#return-types).

In the following example, `DelayAsync` is an async method that has a return statement that returns an integer. Because it's an async method, its method declaration must have a return type of `Task<int>`. Because the return type is `Task<int>`, the evaluation of the `await` expression in `DoSomethingAsync` produces an integer, as the following `int result = await delayTask` statement demonstrates.

:::code language="csharp" source="programming-guide/classes-and-structs/snippets/classes-and-structs/methods/Program.cs":::

An async method can't declare any [in](language-reference/keywords/method-parameters.md#in-parameter-modifier), [ref](language-reference/keywords/ref.md), or [out](language-reference/keywords/method-parameters.md#out-parameter-modifier) parameters, but it can call methods that have such parameters.

 For more information about async methods, see [Asynchronous programming with async and await](asynchronous-programming/index.md) and [Async return types](asynchronous-programming/async-return-types.md).

## Expression-bodied members

It's common to have method definitions that return immediately with the result of an expression, or that have a single statement as the body of the method. There's a syntax shortcut for defining such methods using `=>`:

```csharp
public Point Move(int dx, int dy) => new Point(x + dx, y + dy);
public void Print() => Console.WriteLine(First + " " + Last);
// Works with operators, properties, and indexers too.
public static Complex operator +(Complex a, Complex b) => a.Add(b);
public string Name => First + " " + Last;
public Customer this[long id] => store.LookupCustomer(id);
```

If the method returns `void` or is an async method, the body of the method must be a statement expression (same as with lambdas). For properties and indexers, they must be read-only, and you don't use the `get` accessor keyword.

## Iterators

An iterator performs a custom iteration over a collection, such as a list or an array. An iterator uses the [yield return](language-reference/statements/yield.md) statement to return each element one at a time. When a `yield return` statement is reached, the current location is remembered so that the caller can request the next element in the sequence.

The return type of an iterator can be <xref:System.Collections.IEnumerable>, <xref:System.Collections.Generic.IEnumerable%601>, <xref:System.Collections.Generic.IAsyncEnumerable%601>, <xref:System.Collections.IEnumerator>, or <xref:System.Collections.Generic.IEnumerator%601>.

For more information, see [Iterators](programming-guide/concepts/iterators.md).

## See also

- [Access Modifiers](language-reference/keywords/access-modifiers.md)
- [Static Classes and Static Class Members](programming-guide/classes-and-structs/static-classes-and-static-class-members.md)
- [Inheritance](fundamentals/object-oriented/inheritance.md)
- [Abstract and Sealed Classes and Class Members](programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members.md)
- [params](language-reference/keywords/method-parameters.md#params-modifier)
- [out](language-reference/keywords/method-parameters.md#out-parameter-modifier)
- [ref](language-reference/keywords/ref.md)
- [in](language-reference/keywords/method-parameters.md#in-parameter-modifier)
- [Passing Parameters](language-reference/keywords/method-parameters.md)
