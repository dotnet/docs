---
title: What's New in C# 6 | C# Guide
description: What's New in C# 6    
keywords: .NET, .NET Core
author:  BillWagner
manager: wpickett
ms.date: 09/08/2016
ms.topic: article
ms.prod: visual-studio-dev-14
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: 4d879f69-f889-4d3f-a781-75194e143400
---

# What's New in C# 6

The 6.0 release of C# contained many features that improves
productivity for developers. Features in this release include:

* [Readonly Auto properties](#readonly-auto-properties)
* [Auto Property Initializers](#auto-property-initializers)
* [Expression Bodied function members](#Expression-bodied-function-members)
* [using static](#using-static)
* [Null - conditional operators](#null-conditional-operators)
* [String Interpolation](#String-Interpolation)
* [Exception filters](#Exception-Filters)
* [nameof Expressions](#nameof-Expressions)
* [await in catch and finally blocks](#Await-in-Catch-and-Finally-blocks)
* [index initializers](Index-Initializers)
* [Extension methods for collection initializers](#Extension-Add-methods-in-collection-initializers)
* [Improved overload resolution](#Improved-overload-resolution)

The overall effect of these features is that you write more concise code
that is also more readable. The syntax contains less ceremony for many
common practices. It's easier to see the design intent with less
ceremony. Learn these features well, and you'll be more productive,
create more readable code, and concentrate more on your core features
than on the constructs of the language.

The remainder of this topic provides an overview of these features, with
links where you can explore more about any of the features. Sub-topics
explore each feature in more detail. 

## Auto Property enhancements 

The syntax for auto-properties made it very easy to create properties
that had simple get and set methods:

[!code-csharp[ClassicAutoProperty](../../samples/snippets/csharp/new-in-6/oldcode.cs#L7-L8)]

However, this simple syntax limited the kinds of designs you could support using
auto properties. C# 6 improves the auto properties capabilities so that ou can use
them in more scenarios. You'll fall back on the more verbose syntax of declaring
the backing field by hand, and manipulating that backing field less often.

The new syntax addresses scenarios for read only properties, and for initializing
the variable storage behind an auto-property.

### Readonly auto-properties

***Readonly auto-properties*** provide a more concise syntax to create
immutable types. The closest you could get to immutable types
in earlier versions of C# was to declare private setters:

[!code-csharp[ClassicReadOnlyAutoProperty](../../samples/snippets/csharp/new-in-6/oldcode.cs#L30-L31)]
 
Using this syntax, the compiler doesn't ensure that the type really is immutable. It only
enforces that the `FirstName` and `LastName` properties are not modified from any
code outisde the class.

Readonly auto-properties enable true readonly behavior. You declare the auto-property
with only a get accessor:

[!code-csharp[ReadOnlyAutoProperty](../../samples/snippets/csharp/new-in-6/newcode.cs#L19-L20)]

The `FirstName` and `LastName` properties can be set only in the body of a constructor:

[!code-csharp[ReadOnlyAutoProperty](../../samples/snippets/csharp/new-in-6/newcode.cs#L11-L20)]

Trying to set `LastName` in another method generates a `CS0200` compilation error:

```csharp
public class Student
{
    public string LastName { get;  }

    public void ChangeName(string newLastName)
    {
        // Generates CS 0200: Property or indexer cannot be assigned to -- it is read only
        LastName = newLastName;
    }
}
```

This features enables true language support for creating immutable types and using
the more concise and convenient auto-property syntax.

### Auto Property Initializers

***Auto Property Initializers*** let you declare the initial value for
an auto property as part of the property declaration.  In earlier versions,
these properties would need to have setters and a class author would need
to use that setter to initialize the data storage used by the backing
field. Consider this class for a student that contains the name and a
list of the student's grades:

[!code-csharp[Construction](../../samples/snippets/csharp/new-in-6/oldcode.cs#L5-L15)]
 
As this class grows, you may include other constructors. Each constructor
needs to initialize this field, or you'll introduce errors.

C# 6 enables you to assign an initial value for the storage used by an
auto property in the auto property declaration:

[!code-csharp[Initialization](../../samples/snippets/csharp/new-in-6/newcode.cs#L21-L21)]

The `grades` member is initialized where it is declared. That makes it
easier to perform the initialization exactly once. The initialization
is part of the property declaration, making it easier to equate the
storage allocation with public interface for `Student` objects.

Property Initializers can be used with read / write properties as well
as read only properties, as shown below.

[!code-csharp[ReadWriteInitialization](../../samples/snippets/csharp/new-in-6/newcode.cs#L22-L22)]

## Expression bodied function members

Many of the members that we write consist of single return statements.
Instead of all that ceremony, write an ***expression bodied member***
instead. For example, an override of `ToString()` is often a great candidate:

[!code-csharp[ToStringExpressionMember](../../samples/snippets/csharp/new-in-6/newcode.cs#L25-L25)]

You can also use expression bodied members in read only properties as well:

[!code-csharp[FullNameExpressionMember](../../samples/snippets/csharp/new-in-6/newcode.cs#L23-L23)]

## Using static

The ***using static*** enhancement enables you to import the static methods
of a single class. Previously, the `using` statement imported all types
from all classes in a namespace. 

Often we use a class and its static methods throughout our code. Repeatedly
typing the class name can obscure the meaning of your code. A common
example is when you write classes that perform many numeric calculations.
Your code will be littered with `Math.Sin`, `Math.Sqrt` and other calls
to different methods in the `Math` class. The new `using static` syntax can make these
classes much cleaner to read. You specify the class you're using:

[!code-csharp[UsingStaticMath](../../samples/snippets/csharp/new-in-6/newcode.cs#L1-L1)]

And now, you can use any static method in the `Math` class without
qualifying the `Math` class. The `Math` class does not contain any
instance methods. You can also use `using static` to import a
class' static methods for a class that has both static
and instance methods. One of the most useful examples 
`System.String`:

[!code-csharp[UsingStatic](../../samples/snippets/csharp/new-in-6/newcode.cs#L2-L2)]

> [!NOTE]
> You must use the fully qualified class name, `System.String`. 
> You can't use the `string` keyword in a static using statement. 

You can now call static methods defined in the `String` class without
qualifying those methods as members of that class:

[!code-csharp[UsingStaticString](../../samples/snippets/csharp/new-in-6/newcode.cs#L13-L14)]

The `static using` feature and extension methods interact in
interesting ways, and the language design included some rules
the specifically address those interactions. The goal is to
minimize any chances of breaking changes in existing codebases,
including yours.

Extension methods are only in scope when called using the
extension method invocation syntax, not when called as a static method.
You'll often see this in LINQ queries. You can import the LINQ pattern
by importing `System.Linq.Enumerable`. 

[!code-csharp[UsingStaticLinq](../../samples/snippets/csharp/new-in-6/newcode.cs#L5-L5)]

This imports all the methods in the `System.Linq.Enumerable` namespace.
However, the extension methods are only in scope when called as extension
methods. They are not in scope if they are called as though they are static
methods:

[!code-csharp[UsingStaticLinq](../../samples/snippets/csharp/new-in-6/newcode.cs#L36-L41)]

This decision is because extension methods are typically called using
extension method invocation expressions. In the rare case where they are
called using the static method call syntax it is to resolve ambiguity.
Requiring the class name as part of the invocation seems wise.

There's one last feature of `static using`. The `static using` directive
also imports any nested types. That enables you to reference any nested
types without qualification.

## Null-conditional operators

Null values complicate code. You need to check every access
of variables to ensure you are not dereferencing `null`. The
***null conditional operator*** makes those checks much easier
and fluid.

Simply replace the member access `.` with `?.`:

```csharp
[!code-csharp[NullConditional](../../samples/snippets/csharp/new-in-6/program.cs#L16-L16)]
```

In the above example, the variable `first` is assigned `null` if the person object
is null. Otherwise, it gets assigned the value of the `FirstName` property. Most importantly,
the `?.` means that the above line of code does not generate a `NullReferenceException` when
the `person` variable is null. Instead, it short-circuits and returns null.

Also, note that this expression returns a `string`, regardless of the value of `person`.
In the case of short circuiting, the null value returned is typed to match the full
expresion.

You can often use this construct with the ***null coalescing*** operator to assign`
default values when one of the properties are null:

[!code-csharp[NullCoalescing](../../samples/snippets/csharp/new-in-6/program.cs#L18-L18)]

The right hand side operand of the `?.` operator is not limited to properties or fields.
You can also use it to conditionally invoke methods. The most common use of member functions
 with the null conditional operator is to safely invoke delegates
(or event handlers) that may be null.  You'll do this by calling the delegate's `Invoke` method
using the `?.` operator to access the member. You can see an example where we discuss 
[delegate patterns](delegates-patterns.md#Handling-Null-Delegates)

The rules of the `?.` operator ensure that the left hand side of the operator is
evaluated only once. This is important and enables many idioms, including the
example using event handlers. Let's start with the event handler usage. In previous
versions of C#, you were encouraged to write code like this:

```csharp
var handler = this.SomethingHappened;
if (handler != null)
    handler(this, eventArgs);
```

This was preferred over a simpler syntax:

```csharp
// Not recommended
// Introduces a race condition
// The SomethingHappened event
// may have subscribers when checked,
// and those subscribers may have been
// removed before the event is raised. 
if (this.SomethingHappened != null)
    this.SomethingHappened(this, eventArgs);
```

In this second version, the `SomethingHappened` event handler might
be non-null when tested, but if other code removes a handler,
it could still be null when the event handler was called.

The compiler generates code for for the `?.` operator that ensures
the left side (`this.SomethingHappened`) below is evaluated once, and the result
is cached:

```csharp
// preferred in C# 6:
this.SomethingHappened?.Invoke(this, eventArgs);
```

Ensuring that the left side is evaluated only once also enables you
to use any expression, including method calls, on the left side of the
`?.` Even if these have side-effects, they are evaluated once, so the
side effects occur only once. You can see an example in our content
on [events](events-overview.md#Language-Support-for-Events)

## String Interpolation

C# 6 contains new syntax for composing strings from a format string
and expressions that can be evaluated to produce other string values.

Traditionally, you needed to use positional parameters in a method
like `string.Format`:

[!code-csharp[stringFormat](../../samples/snippets/csharp/new-in-6/oldcode.cs#L16-L22)]

With C# 6, the new string interpolation feature enables you to embed
the expressions in the format string. Simple preface the string with
`$`:

[!code-csharp[stringInterpolation](../../samples/snippets/csharp/new-in-6/newcode.cs#L23-L23)]

This initial example used variable expressions for the substituted
expressions. You can expand on this syntax to use any expression. For
example, you could compute a student's grade point average as part of
the interpolation:

[!code-csharp[stringInterpolationExpression](../../samples/snippets/csharp/new-in-6/newcode.cs#L27-L28)]

Running the above example, you would find that the output for `Grades.Average()`
might have more decimal places than you would like. The string interpolation
syntax supports all the format strings available using earlier formatting
methods. You add the format strings inside the braces. Add a `:` following
the expression to format:

[!code-csharp[stringInterpolationFormat](../../samples/snippets/csharp/new-in-6/newcode.cs#L30-L31)]

The above line of code will format the value for `Grades.Average()` as
a floating point number with 2 decimal places.

The `:` is always interpreted as the separator between the expression
being formatted and the format string. This can introduce problems when
your expression uses a `:` in another way, such as a conditional operator:

```csharp
public string GetGradePointPercentages() =>
    $"Name: {LastName}, {FirstName}. G.P.A: {Grades.Any() ? Grades.Average() : double.NaN:F2}";
```

Above, the `:` is parsed as the beginning of the format string, not part
of the conditional operator. In all cases where this happens, you can
surround the expression with parentheses to force the compiler to interpret
the expression as you intend:

[!code-csharp[stringInterpolationConditional](../../samples/snippets/csharp/new-in-6/newcode.cs#L33-L34)]

There aren't any limitations on the expressions you can place between
the braces. You can execute a complex LINQ query inside an interpolated
string to perform computations and display the result:

[!code-csharp[stringInterpolationConditional](../../samples/snippets/csharp/new-in-6/newcode.cs#L43-L45)]

You can see from the above sample that you can even nest a string interpolation
expression inside another string interpolation expression. The example
above is very likely more complex than you would want in production code.
Rather, it is illustrative of the breadth of the feature. Any C# expression
can be placed between the curly braces of an interpolated string.

### String Interpolation and Specific Cultures

All the examples shown above will format the strings using the current
culture and language on the machine where the code executes. Often you
may want need to format the string produced using a specific culture.
The object produced from a string interpolation is a type that has an
implicit conversion to either `System.String` or `System.IFormattableString`.

The `FormattableString` type contains the format string, and the results
of evaluating the arguments before converting them to strings. You can
use public methods of `FormattableString` to specify the culture when
formatting a string. For example, the following will produce a string
using German as the language and culture. (It will use the ',' character
to separate the integer portion from the decimal portion of a number,
and the '.' character as the thousands separator.)

```csharp
FormattableString str = @"Average grade is {s.Grades.Average()}";
var gradeStr = string.Format(null, 
    System.Globalization.CultureInfo.CreateSpecificCulture("de-de"),
    str.GetFormat(), str.GetArguments());
```

> [!NOTE]
> The above example is not supported in .NET Core version 1.0.1. It is
> only supported in the full .NET Framework.

In general, string interpolation expressions produce strings as their
output. However, when you want greater control over the culture used to
format the string, you can specify a specific output.  If this is a capability
you often need, you can create convenience methods, as extension methods,
to enable easy formating with specific cultures.

## Exception Filters

Another new feature in C# 6 is ***exception filters***. Exception Filters
are clauses that determine when a given catch clause should be applied.
If the expression used for an exception filter evaluates to `true`, the
catch clause performs its normal procesing on an exception. If the
expression evaluates to `false`, then the `catch` clause is skipped.

One use is to examine information about an exception to determine if a
catch clause can process the exception:

[!code-csharp[ExceptionFilter](../../samples/snippets/csharp/new-in-6/NetworkClient.cs#L8-L20)]

The code generated by exception filters provides better information about
an exception that is thrown and not processed. Before exception filters
were added to the language you would need to create code like the following:

[!code-csharp[ExceptionFilterOld](../../samples/snippets/csharp/new-in-6/NetworkClient.cs#L75-L89)]

The point where the exception is thrown changes between these two examples.
In the previous code, where a `throw` clause is used, any stack trace
analysis or examination of crash dumps will show that the exception was
thrown from the `throw` statement in your catch clause. The actual exception
object will contain the original call stack, but all other information
about any variables in the call stack between this throw point and the
location of the original error has been lost. 

Contrast that with how the code using an exception filter is processed:
The exception filter expression evaluates to `false`. Execution never
enters the `catch` clause. No stack unwinding takes place. The original
throw location is preserved for any debugging activities that would take
place later.

Whenever you need to evaluate fields or properties of an exception, instead
of relying on solely on the exception type, use an exception filter to
preserve more debugging information.

Another recommended pattern with exception filters is to use them for
logging routines. This usage also leverages the manner in which the exception
throw point is preserved when an exception filter evaluates to `false`.

A logging method would be a method whose argument is the exception that
unconditionally returns `false`:

[!code-csharp[ExceptionFilterLogging](../../samples/snippets/csharp/new-in-6/ExceptionFilterHelpers.cs#L7-L11)]

Whenever you want to log an exception, you can add a catch clause, and
use this method as the exception filter:

[!code-csharp[LogException](../../samples/snippets/csharp/new-in-6/program.cs#L36-L44)]

The exceptions are never caught, because the `LogException` method always
returns `false`. That always false exception filte means that you can
place this logging handler before any other exception handlers:

[!code-csharp[LogExceptionRecovery](../../samples/snippets/csharp/new-in-6/program.cs#L46-L61)]

The above example highlights a very important facet of exception filters.
The exception filters enable scenarios where a more general exception
catch clause may appear before a more specific one. It's also possible
to have the same exception type appear in multiple catch clauses:

[!code-csharp[HandleNotChanged](../../samples/snippets/csharp/new-in-6/NetworkClient.cs#L20-L34)]

Another recommended pattern helps prevent catch clauses from processing
exceptions when a debugger is attached. This technique enables you to
run an application with the debugger, and stop execution when an exception
is thrown.

In the code, add an exception filter so that any recovery code executes
only when a debugger is not attached:

[!code-csharp[LogExceptionDebugger](../../samples/snippets/csharp/new-in-6/program.cs#L64-L78)]

After adding this in code, you set your debugger to break on all unhandled
exceptions. Run the program under the debugger, and the debugger breaks
whenever `PerformFailingOperation()` throws a `RecoverableException`.
The debugger breaks your program, because the catch clause won't be executed
due to the false-returning exception filter.

## `nameof` Expressions

The `nameof` expression evaluates to the name of a symbol. It's a great
way to get tools working with you whenever you need the name of a variable,
a property, or a member field.

One of the most common uses for `nameof` is to provide the name of a symbol
that caused an exception:

[!code-csharp[nameof](../../samples/snippets/csharp/new-in-6/NewCode.cs#L13-L14)]

Another use is with XAML based applications that implement the `INotifyPropertyChanged`
interface:

[!code-csharp[nameofNotify](../../samples/snippets/csharp/new-in-6/viewmodel.cs#L5-L23)]

The advantage of using the `nameof` operator over a constant string is
that tools can understand the symbol. If you use refactoring tools to
rename the symbol, it will rename it in the `nameof` expression. Constant
strings don't have that advantage. Try it yourself in your favorite editor:
Rename a variable, and any nameof expressions will update as well.

The `nameof` expression produces the unqualified name of its argument
(`LastName` in the examples above) even if you use the fully qualified
name for the argument:

[!code-csharp[nameofNotify](../../samples/snippets/csharp/new-in-6/viewmodel.cs#L24-L37)]

The above `nameof` expression produces `FirstName`, not `UXComponents.ViewModel.FirstName`.

## Await in Catch and Finally blocks

C# 5 had several limitations around where you could place `await` expressions.
One of those has been removed in C# 6. You can now use `await` in `catch`
or `finally` expressions. 

The addition of await expressions in catch and finally blocks may appear
to complicate how those are processed. Let's add an example to discuss
how this appears. In any async method, you can use an await expression
in a finally clause:

[!code-csharp[AwaitFinally](../../samples/snippets/csharp/new-in-6/NetworkClient.cs#L35-L52)]

With C# 6, you can also await in catch expressions. This is most often
used with logging scenarios:

[!code-csharp[AwaitFinally](../../samples/snippets/csharp/new-in-6/NetworkClient.cs#L41-L48)]

The implementation details for adding `await` support inside `catch`
and `finally` clauses ensures that the behavior is consistent with the
behavior for synchronous code. When code executed in a `catch` or `finally`
clause throws, execution looks for a suitable `catch` clause in the next
surrounding block. If there was a current exception, that exception is
lost. The same happens with `await`ed expressions in `catch` and `finally`
clauses: a suitable `catch` is searched for, and the current exception,
if any, is lost.  

> [!NOTE]
> This behavior is the reason it's recommended to write `catch` and `finally`
> clauses carefully, to avoid introducing new exceptions.

## Index Initializers

***Index Initializers*** is one of two features that make collection
initializers more consistent. In earlier releases of C#, you could use
***collection initializers*** only with sequence style collections:

[!code-csharp[ListInitializer](../../samples/snippets/csharp/new-in-6/initializer.cs#L7-L12)]

Now, you can also use them with `Dictionary` collections and similar types:

[!code-csharp[ListInitializer](../../samples/snippets/csharp/new-in-6/initializer.cs#L14-L18)]

This features means that associative containers can be initialized using
syntax similar to what's been in place for sequence containers for several
versions.

### Extension `Add` methods in collection initializers

Another feature that makes collection initialization easier is the ability
to use an ***extension method*** for the `Add` method. This feature was
added for parity with Visual Basic. 

The feature is most useful when you have a custom collection class that
has a method with a different name to semantically add new items:

For example, consider a collection of students like this:

[!code-csharp[Enrollment](../../samples/snippets/csharp/new-in-6/enrollment.cs#L5-L24)]

The `Enroll` method adds a student. But it doesn't follow the `Add` pattern.
In previous versions of C#, you could not use collection initializers with an
`Enrollment` object:

[!code-csharp[InitializeEnrollment](../../samples/snippets/csharp/new-in-6/classList.cs#L7-L11)]

Now you can, but only if you create an extension method that maps `Add` to
`Enroll`:

[!code-csharp[ExtensionAdd](../../samples/snippets/csharp/new-in-6/classList.cs#L15-L18)]

## Improved overload resolution

This last feature is one you probably won't notice. There were constructs
where the previous version of the C# compiler may have found some method
calls involving lambda expressions ambiguious. Consider this method:

[!code-csharp[AsyncMethod](../../samples/snippets/csharp/new-in-6/overloads.cs#L7-L10)]

In earlier versions of C#, calling that method using the method group
syntax would fail:

[!code-csharp[MethodGroup](../../samples/snippets/csharp/new-in-6/overloads.cs#L14-L14)]
 
The earlier compiler could not distinguish correctly between `Task.Run(Action)`
and `Task.Run(Func<Task>())`. In previous versions, you'd need to use
a lambda expression as an argument:

[!code-csharp[Lambda](../../samples/snippets/csharp/new-in-6/overloads.cs#L16-L16)]

The C# 6 compiler correctly determines that `Task.Run(Func<Task>()` is
a better choice.
