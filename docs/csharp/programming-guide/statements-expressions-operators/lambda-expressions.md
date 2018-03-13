---
title: "Lambda Expressions (C# Programming Guide)"
ms.date: 03/03/2017
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "lambda expressions [C#]"
  - "outer variables [C#]"
  - "statement lambda [C#]"
  - "expression lambda [C#]"
  - "expressions [C#], lambda"
ms.assetid: 57e3ba27-9a82-4067-aca7-5ca446b7bf93
caps.latest.revision: 64
author: "BillWagner"
ms.author: "wiwagn"
---
# Lambda Expressions (C# Programming Guide)
A lambda expression is an [anonymous function](../../../csharp/programming-guide/statements-expressions-operators/anonymous-methods.md) that you can use to create [delegates](../../../csharp/programming-guide/delegates/using-delegates.md) or [expression tree](http://msdn.microsoft.com/library/fb1d3ed8-d5b0-4211-a71f-dd271529294b) types. By using lambda expressions, you can write local functions that can be passed as arguments or returned as the value of function calls. Lambda expressions are particularly helpful for writing LINQ query expressions.  
  
 To create a lambda expression, you specify input parameters (if any) on the left side of the lambda operator [=>](../../../csharp/language-reference/operators/lambda-operator.md), and you put the expression or statement block on the other side. For example, the lambda expression `x => x * x` specifies a parameter that’s named `x` and returns the value of `x` squared. You can assign this expression to a delegate type, as the following example shows:  
  
```csharp  
delegate int del(int i);  
static void Main(string[] args)  
{  
    del myDelegate = x => x * x;  
    int j = myDelegate(5); //j = 25  
}  
```  
  
 To create an expression tree type:  
  
```csharp  
using System.Linq.Expressions;  
  
namespace ConsoleApplication1  
{  
    class Program  
    {  
        static void Main(string[] args)  
        {  
            Expression<del> myET = x => x * x;  
        }  
    }  
}  
```  
  
 The `=>` operator has the same precedence as assignment (`=`) and is [right associative](../../../csharp/programming-guide/statements-expressions-operators/operators.md) (see "Associativity" section of the Operators article).  
  
 Lambdas are used in method-based [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)] queries as arguments to standard query operator methods such as <xref:System.Linq.Enumerable.Where%2A>.  
  
 When you use method-based syntax to call the <xref:System.Linq.Enumerable.Where%2A> method in the <xref:System.Linq.Enumerable> class (as you do in [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)] to Objects and [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)]) the parameter is a delegate type <xref:System.Func%602?displayProperty=nameWithType>. A lambda expression is the most convenient way to create that delegate. When you call the same method in, for example, the <xref:System.Linq.Queryable?displayProperty=nameWithType> class (as you do in [!INCLUDE[vbtecdlinq](~/includes/vbtecdlinq-md.md)]) then the parameter type is an <xref:System.Linq.Expressions.Expression?displayProperty=nameWithType><Func\> where Func is any of the Func delegates with up to sixteen input parameters. Again, a lambda expression is just a very concise way to construct that expression tree. The lambdas allow the `Where` calls to look similar although in fact the type of object created from the lambda is different.  
  
 In the previous example, notice that the delegate signature has one implicitly-typed input parameter of type `int`, and returns an `int`. The lambda expression can be converted to a delegate of that type because it also has one input parameter (`x`) and a return value that the compiler can implicitly convert to type `int`. (Type inference is discussed in more detail in the following sections.) When the delegate is invoked by using an input parameter of 5, it returns a result of 25.  
  
 Lambdas are not allowed on the left side of the [is](../../../csharp/language-reference/keywords/is.md) or [as](../../../csharp/language-reference/keywords/as.md) operator.  
  
 All restrictions that apply to anonymous methods also apply to lambda expressions. For more information, see [Anonymous Methods](../../../csharp/programming-guide/statements-expressions-operators/anonymous-methods.md).  
  
## Expression Lambdas  
 A lambda expression with an expression on the right side of the => operator is called an *expression lambda*. Expression lambdas are used extensively in the construction of [Expression Trees](http://msdn.microsoft.com/library/fb1d3ed8-d5b0-4211-a71f-dd271529294b). An expression lambda returns the result of the expression and takes the following basic form:  
  
```csharp
(input-parameters) => expression
```

 The parentheses are optional only if the lambda has one input parameter; otherwise they are required. Two or more input parameters are separated by commas enclosed in parentheses:  
  
```csharp
(x, y) => x == y
```

 Sometimes it is difficult or impossible for the compiler to infer the input types. When this occurs, you can specify the types explicitly as shown in the following example:  
  
```csharp
(int x, string s) => s.Length > x
```

 Specify zero input parameters with empty parentheses:  
  
```csharp
() => SomeMethod()
```

 Note in the previous example that the body of an expression lambda can consist of a method call. However, if you are creating expression trees that are evaluated outside of the .NET Framework, such as in SQL Server, you should not use method calls in lambda expressions. The methods will have no meaning outside the context of the .NET common language runtime.  
  
## Statement Lambdas  
 A statement lambda resembles an expression lambda except that the statement(s) is enclosed in braces:  
  
(input-parameters) => { statement; }

 The body of a statement lambda can consist of any number of statements; however, in practice there are typically no more than two or three.  
  
[!code-csharp[StatementLamba#1](../../../../samples\snippets\csharp\programming-guide\lambda-expressions/statements.cs#1)]

[!code-csharp[StatementLamba#2](../../../../samples\snippets\csharp\programming-guide\lambda-expressions/statements.cs#2)]

 Statement lambdas, like anonymous methods, cannot be used to create expression trees.  
  
## Async Lambdas  
 You can easily create lambda expressions and statements that incorporate asynchronous processing by using the [async](../../../csharp/language-reference/keywords/async.md) and [await](../../../csharp/language-reference/keywords/await.md) keywords. For example, the following Windows Forms example contains an event handler that calls and awaits an async method, `ExampleMethodAsync`.  
  
```csharp
public partial class Form1 : Form  
{  
    public Form1()  
    {  
        InitializeComponent();  
    }  
  
    private async void button1_Click(object sender, EventArgs e)  
    {  
        // ExampleMethodAsync returns a Task.  
        await ExampleMethodAsync();  
        textBox1.Text += "\r\nControl returned to Click event handler.\n";  
    }  
  
    async Task ExampleMethodAsync()  
    {  
        // The following line simulates a task-returning asynchronous process.  
        await Task.Delay(1000);  
    }  
}  
```

 You can add the same event handler by using an async lambda. To add this handler, add an `async` modifier before the lambda parameter list, as the following example shows.  
  
```csharp  
public partial class Form1 : Form  
{  
    public Form1()  
    {  
        InitializeComponent();  
        button1.Click += async (sender, e) =>  
        {  
            // ExampleMethodAsync returns a Task.  
            await ExampleMethodAsync();  
            textBox1.Text += "\nControl returned to Click event handler.\n";  
        };  
    }  
  
    async Task ExampleMethodAsync()  
    {  
        // The following line simulates a task-returning asynchronous process.  
        await Task.Delay(1000);  
    }  
}  
```  

 For more information about how to create and use async methods, see [Asynchronous Programming with async and await](../../../csharp/programming-guide/concepts/async/index.md).  
  
## Lambdas with the Standard Query Operators  
 Many Standard query operators have an input parameter whose type is one of the <xref:System.Func%602> family of generic delegates. These delegates use type parameters to define the number and types of input parameters, and the return type of the delegate. `Func` delegates are very useful for encapsulating user-defined expressions that are applied to each element in a set of source data. For example, consider the following delegate type:  
  
```csharp  
public delegate TResult Func<TArg0, TResult>(TArg0 arg0)  
```  
  
 The delegate can be instantiated as `Func<int,bool> myFunc` where `int` is an input parameter and `bool` is the return value. The return value is always specified in the last type parameter. `Func<int, string, bool>` defines a delegate with two input parameters, `int` and `string`, and a return type of `bool`. The following `Func` delegate, when it is invoked, will return true or false to indicate whether the input parameter is equal to 5:  
  
```csharp  
Func<int, bool> myFunc = x => x == 5;  
bool result = myFunc(4); // returns false of course  
```  
  
 You can also supply a lambda expression when the argument type is an `Expression<Func>`, for example in the standard query operators that are defined in System.Linq.Queryable. When you specify an `Expression<Func>` argument, the lambda will be compiled to an expression tree.  
  
 A standard query operator, the <xref:System.Linq.Enumerable.Count%2A> method, is shown here:  
  
```csharp  
int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };  
int oddNumbers = numbers.Count(n => n % 2 == 1);  
```  
  
 The compiler can infer the type of the input parameter, or you can also specify it explicitly. This particular lambda expression counts those integers (`n`) which when divided by two have a remainder of 1.  
  
 The following line of code produces a sequence that contains all elements in the `numbers` array that are to the left side of the 9 because that's the first number in the sequence that doesn't meet the condition:  
  
```csharp  
var firstNumbersLessThan6 = numbers.TakeWhile(n => n < 6);  
```  
  
 This example shows how to specify multiple input parameters by enclosing them in parentheses. The method returns all the elements in the numbers array until a number is encountered whose value is less than its position. Do not confuse the lambda operator (`=>`) with the greater than or equal operator (`>=`).  
  
```csharp  
var firstSmallNumbers = numbers.TakeWhile((n, index) => n >= index);  
```  
  
## Type Inference in Lambdas  
 When writing lambdas, you often do not have to specify a type for the input parameters because the compiler can infer the type based on the lambda body, the parameter’s delegate type, and other factors as described in the C# Language Specification. For most of the standard query operators, the first input is the type of the elements in the source sequence. So if you are querying an `IEnumerable<Customer>`, then the input variable is inferred to be a `Customer` object, which means you have access to its methods and properties:  
  
```csharp  
customers.Where(c => c.City == "London");  
```  
  
 The general rules for lambdas are as follows:  
  
-   The lambda must contain the same number of parameters as the delegate type.  
  
-   Each input parameter in the lambda must be implicitly convertible to its corresponding delegate parameter.  
  
-   The return value of the lambda (if any) must be implicitly convertible to the delegate's return type.  
  
 Note that lambda expressions in themselves do not have a type because the common type system has no intrinsic concept of "lambda expression." However, it is sometimes convenient to speak informally of the "type" of a lambda expression. In these cases the type refers to the delegate type or <xref:System.Linq.Expressions.Expression> type to which the lambda expression is converted.  
  
## Variable Scope in Lambda Expressions  
 Lambdas can refer to *outer variables* (see [Anonymous Methods](../../../csharp/programming-guide/statements-expressions-operators/anonymous-methods.md)) that are in scope in the method that defines the lambda function, or in scope in the type that contains the lambda expression. Variables that are captured in this manner are stored for use in the lambda expression even if the variables would otherwise go out of scope and be garbage collected. An outer variable must be definitely assigned before it can be consumed in a lambda expression. The following example demonstrates these rules:  
  
```csharp  
delegate bool D();  
delegate bool D2(int i);  
  
class Test  
{  
    D del;  
    D2 del2;  
    public void TestMethod(int input)  
    {  
        int j = 0;  
        // Initialize the delegates with lambda expressions.  
        // Note access to 2 outer variables.  
        // del will be invoked within this method.  
        del = () => { j = 10;  return j > input; };  
  
        // del2 will be invoked after TestMethod goes out of scope.  
        del2 = (x) => {return x == j; };  
  
        // Demonstrate value of j:  
        // Output: j = 0   
        // The delegate has not been invoked yet.  
        Console.WriteLine("j = {0}", j);        // Invoke the delegate.  
        bool boolResult = del();  
  
        // Output: j = 10 b = True  
        Console.WriteLine("j = {0}. b = {1}", j, boolResult);  
    }  
  
    static void Main()  
    {  
        Test test = new Test();  
        test.TestMethod(5);  
  
        // Prove that del2 still has a copy of  
        // local variable j from TestMethod.  
        bool result = test.del2(10);  
  
        // Output: True  
        Console.WriteLine(result);  
  
        Console.ReadKey();  
    }  
}  
```  
  
 The following rules apply to variable scope in lambda expressions:  
  
-   A variable that is captured will not be garbage-collected until the delegate that references it becomes eligible for garbage collection.  
  
-   Variables introduced within a lambda expression are not visible in the outer method.  
  
-   A lambda expression cannot directly capture an `in`, `ref`, or `out` parameter from an enclosing method.  
  
-   A return statement in a lambda expression does not cause the enclosing method to return.  
  
-   A lambda expression cannot contain a `goto` statement, `break` statement, or `continue` statement that is inside the lambda function if the jump statement’s target is outside the block. It is also an error to have a jump statement outside the lambda function block if the target is inside the block.  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## Featured Book Chapter  
 [Delegates, Events, and Lambda Expressions](https://msdn.microsoft.com/library/orm-9780596516109-03-09.aspx) in [C# 3.0 Cookbook, Third Edition: More than 250 solutions for C# 3.0 programmers](https://msdn.microsoft.com/library/orm-9780596516109-03.aspx)  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [LINQ (Language-Integrated Query)](../../../csharp/programming-guide/concepts/linq/index.md)  
 [Anonymous Methods](../../../csharp/programming-guide/statements-expressions-operators/anonymous-methods.md)  
 [is](../../../csharp/language-reference/keywords/is.md)  
 [Expression Trees](../../../csharp/programming-guide/concepts/expression-trees/index.md)  
 [Visual Studio 2008 C# Samples (see LINQ Sample Queries files and XQuery program)](http://code.msdn.microsoft.com/Visual-Studio-2008-C-d295cdba)  
 [Recursive lambda expressions](https://blogs.msdn.microsoft.com/madst/2007/05/11/recursive-lambda-expressions/)
