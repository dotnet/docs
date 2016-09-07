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

* Auto Property Initializers
* Getter-only Auto properties
* Expression Bodied function members
* using static
* Null - conditional operators
* String Interpolation
* nameof Expressions
* index initializers
* Extension methods for collection initializers
* Exception filters
* await in catch and finally blocks
* improved overload resolution

The overall effect of these features is that you write more concise code
that is also more readable. The syntax contains less ceremony for many
common practices. It's easier to see the design intent with less
ceremony. Learn these features well, and you'll be more productive,
create more readable code, and concentrate more on your core features
than on the constructs of the language.

The remainder of this topic provides an overview of these features, with
links where you can explore more about any of the features.

## Auto Property enhancements 

The syntax for auto-properties made it very easy to create properties
that had simple get and set methods:

```csharp
public string Name {get;set;}
```

However, this simple syntax left out some common scenarios. C# 6 improves
the capabilities for auto properties so that ou can use them in more
of these scenarios. You'll fall back on the more verbose syntax of declaring
the backing field by hand, and manipulating that backing field less often.

### Initializers for auto-properties

One common scenario is to initialize the value of the property. This is quite
common for properties that expose collections:

```csharp
public IList<int> RecordedValues {get; private set; } = new List<int>();
```

You no longer need to explicitly declare a backing field in order to
initialize a property's value when an object is created. Nor do you need
to write a constructor and write an assignment statement. Simply write
the initial value when you declare the property.

This syntax works for both read write and read only properties.

```csharp
// Does this compile? It's not a constant.
public DateTime LastModified {get; set; } = DateTime.Now; 
```

### Getter only auto-properties

Getter only auto-properties makes it easier to create read only properties
using auto property syntax. You declare an auto-property with only a get
accessor:

```csharp
public string LastName { get;}
```

The `LastName` property can be set only in the body of a constructor:

```csharp
public Person(string lastName)
{
    this.LastName = lastName;
}
```

Trying to set `LastName` in another method generates a `CS0200` compilation error:

```csharp
public class Person
{
    public string LastName { get;  }

    public void ChangeName(string newLastName)
    {
        // Generates CS 0200: Property or indexer cannot be assigned to -- it is read only
        LastName = newLastName;
    }
}
```

Before this feture, you needed to create a private setter, compromising your design. Or,
forego using auto-properties and write the field definition by hand.

## Expression Bodied function members

Many of the members that we write consist of single return statements.
Instead of all that ceremony, write an ***expression bodied member***
instead. For example, an override of `ToString()` is often a great candidate:

```csharp
public override string ToString() => @"{LastName}, {FirstName}";
```

You can also use expression bodied members in read only properties as well:

```csharp
public string FullName => @"{FirstName} {LastName}";
```

## Using static

Often we use a class and its static methods throughout our code. Repeatedly
typing the class name can obscure the meaning of your code. A common example
is when you write classes that perform many numeric calculations. Your code
will be littered with `Math.Sin`, `Math.Sqrt` and other calls to different
methods in the `Math` class. The new `using static` syntax can make these
classes much cleaner to read. You specify the class you're using:

```csharp
using static System.Math;
```

And now, you can use any static method in the `Math` class without
qualifying the `Math` class.

***Need an example here***

The `Math` class contains only static methods, so every method
can now be accessed without qualifying the name using the `Math`
class name. You can reference classes with both instance and
static methods using `static using.` The `String` class has many
static methods. You can include it in a static using:

```csharp
using static System.String;
```

> [!NOTE]
> You must use the fully qualified class name, `System.String`. 
> You can't use the `string` keyword in a static using statement. 

The `static using` feature and extension methods interact in
interesting ways, and the language design included some rules
the specifically address those interactions. The goal is to
minimize any chances of breaking changes in existing codebases,
including yours.

Extension methods are only in scope when called using the
extension method syntax, not when called as a static method.

NOTE TO SELF: Check the spec for correct terminology on calling
style.

For example:

```csharp
// LINQ query example using
// static syntax and extension method syntax.
 
```

## Null-conditional operators

Null values complicate your code. You need to check every access
of a variable to ensure it isn't null. The null conditional operator
makes those checks much easier.

Simply replace the member access `.` with `?.`:

```csharp
var first = person?.FirstName; 
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

```csharp
var first = person?.FirstName ?? "Unspecified";
```

The right hand side operand of the `?.` operator is not limited to properties or fields.
You can also use it to conditionally invoke methods. The most common use of member functions
 with the null conditional operator is to safely invoke delegates
(or event handlers) that may be null:

```csharp
someDelegate?.Invoke(a,b,c);
```
Here, the delegate is invoked if and only if it is not null. In cases where the delegate
is null, nothing happens. 

The rules of the `?.` operator ensure that the left hand side of the operator is
evaluated only once. This is important and enables many idioms, including the
example using event handlers. Let's start with the event handler usage. In previous
versions of C#, you were encouraged to write code like this:

```csharp
var handler = this.OnEvent;
if (handler != null)
    handler(this, eventArgs);
```

This was preferred over a simpler syntax:

```csharp
// Not recommended
if (this.OnEvent != null)
    this.OnEvent(this, eventArgs);
```

In this second version, the `OnEvent` event handler might
be non-null when tested, but if other code removes a handler,
it could still be null when the event handler was called.

The compiler generates code for for the `?.` operator that ensures
the left side (`this.onEvent`) below is evaluated once, and the result
is cached:

```csharp
// preferred in C# 6:
this.OnEvent?.Invoke(this, eventArgs);
```

Ensuring that the left side is evaluated only once also enables you
to use any expression, including method calls, on the left side of the
`?.` Even if these have side-effects, they are evaluated once, so the
side effects occur only once.

```csharp
// Need an example here
```

## String Interpolation

C# 6 contains new syntax for composing strings from a format string
and expressions that can be evaluated to produce other string values.

Traditionally, you needed to use positional parameters in a method
like `string.Format`:

```csharp
var distance = string.Format("The point [{0}, {1}] is {2} from the origin", X, Y, Distance);
```

With C# 6, the new string interpolation feature enables you to embed the expressions in
the format string. Simple preface the string with `@`:

```csharp
var distance = @"the point [{X}, {Y}] is {Distance} from the origin";
```

This initial example used variable expressions for the substituted expressions.
You can expand on this syntax to use any expression. For example, you could
compute the distance as part of the variable substitution:

```csharp
var distance = @"the point [{X}, {Y}] is {Math.Sqrt(X * X + Y + Y)} from the origin";
```

Running the above example, you would find that the output for `Distance` might have
more decimal places than you would like. The string interpolation syntax supports
all the format strings available using earlier formatting methods. You add
the format strings inside the braces. Add a `:` following the expression to format:

```csharp
var distance = @"the point [{X:F2}, {Y:F2}] is {Math.Sqrt(X * X + Y + Y):F2} from the origin";
```

The above line of code will format the values for `X`, `Y` and distance
as a floating point number with 2 decimal places.

The `:` is always interpreted as the separator between the expression being 
formatted and the format string. This can introduce problems when your expression
uses a `:` in another way, such as a conditional operator:

```csharp
// need a better example here.
```

Above, the `:` is parsed as the beginning of the format string, not part
of the conditional operator. In all cases where this happens, you can surround
the expression with parentheses to force the compiler to interpret
the expression as you intend:

```csharp
// also a better example.
```

There aren't any limitations on the expressions you can place between the braces.
You can execute a complex LINQ query inside an interpolated string to perform
computations and display the result:

```csharp
// Dig up the big one from the user group demos.
```

You can also nest interpolated strings inside other interpolated string expressions:

```csharp
// one final difficult example.
```

### String Interpolation and Specific Cultures

All the examples shown above will format the strings using the current
culture and language set on the machine where the code executes. Often you may
want need to format the string produced using a specific culture. The object
produced from a string interpolation is a type that has an implicit conversion
to either `System.String` or `System.IFormattableString`.

The `FormattableString` type contains the format string, and the results of evaluating
the arguments before converting them to strings. You can use public methods of `FormattableString`
to specify the culture when formatting a string. For example, this will produce a string
using German as the language and culture. (It will use the ',' character to separate the integer
portion from the decimal portion, and the '.' character as the thousands separator.)

```csharp
FormattableString str = @"the point [{X}, {Y}] is {Math.Sqrt(X * X + Y + Y)} from the origin";
var distance = string.Format(null, 
    System.Globalization.CultureInfo.CreateSpecificCulture("de-de"),
    str.GetFormat(), str.GetArguments());
```

In general, string interpolation expressions produce strings as their output. However,
when you want greater control over the culture used to format the string, you can
specify a specific output.  If this is a capability you often need, you can create
convenience methods, as extension methods, to enable easy formating with specific 
cultures:

```csharp
// something like:

publist static string AsGerman(this FormattableString src)
{
    return string.Format(...);
}

// call it:
var result = 
@"the point [{X}, {Y}] is {Math.Sqrt(X * X + Y + Y)} from the origin".AsGerman(); 
```

## Exception Filters

Another new feature in C# 6 is ***exception filters***. Exception Filters are
clauses that determine when a given catch clause should be applied. If the 
expression used for an exception filter evaluates to `true`, the catch clause
performs its normal procesing on an exception.

One use is to examine information about an exception to determine if a
catch clause can process the exception:

```csharp
// basic example, using some property of a network exception.
```

The code generated by exception filters provides better information about
an exception that is thrown and not processed. Before exception filters were added to the language
you would need to create code like the following:

```csharp
// old school version of previous example
```

The point where the exception is thrown changes between these two examples. In
the previous code, where a `throw` clause is used, any stack trace analysis or examination
of crash dumps will show that the exception was thrown from the `throw` statement in
your catch clause. The actual exception object will contain the original call stack, but
all other information about any variables in the call stack between this throw point and
the location of the original error has been lost. 

Contrast that with how the code using an exception filter is processed: The exception filter
expression evaluates to `false`. Execution never enters the `catch` clause. No stack
unwinding takes place. The original throw location is preserved for any debugging activities
that would take place later.

Whenever you need to evaluate fields or properties of an exception, instead of
relying on solely on the exception type, use an exception filter to
preserve more debugging information.

Another recommended pattern with exception filters is to use them for
logging routines. This usage also leverages the manner in which the
exception throw point is preserved when an exception filter evaluates to `false`.

A logging method would be a method whose argument is the exception that
unconditionally returns `false`:

```csharp
public static bool LogException(Exception e)
{
    Console.Error.WriteLine(@"Exceptions happen: {e}");
    return false;
}  
```

Whenever you want to log an exception, you can add a catch clause, and
use this method as the exception filter:

```csharp
public void MethodThatFailsSometimes()
{
    try {
        PerformFailingOperation();
    } catch (Exception e) when (LogException(e))
    {
        // This is never reached!
    }
} 
```

The exceptions are never caught, because the `LogException` method always
returns `false`. That always false exception filte means that you can
place this logging handler before any other exception handlers:


```csharp
public void MethodThatFailsSometimes()
{
    try {
        PerformFailingOperation();
    } catch (Exception e) when (LogException(e))
    {
        // This is never reached!
    }
    catch (RecoverableException ex)
    {
        // This can still catch the more specific
        // exception because the exception filter
        // above always returns false.
        // perform recovery here 
    }
} 
```

The above example highlights a very important facet of
exception filters. The exception filters enable scenarios
where a more general exception catch clause may appear before
a more specific one. It's also possible to have the same
exception type appear in multiple catch clauses:

```csharp
// Example that catches an exception with a property. 
// Add a catch clause with different where clauses
// for values of the property.
```

Another recommended pattern is to prevent catch clauses
from processing exceptions when a debugger is attached.
This technique enables you to run an application with
the debugger, and stop execution when an exception is thrown.

In the code, add an exception filter so that any recovery code
executes only when a debugger is not attached:

```csharp
public void MethodThatFailsSometimes()
{
    try {
        PerformFailingOperation();
    } catch (Exception e) when (LogException(e))
    {
        // This is never reached!
    }
    catch (RecoverableException ex) when (!System.Diagnostics.Debugger.IsAttached)
    {
        // Only catch exceptions when a debugger is not attached.
        // Otherwise, this shouls stop in the debugger. 
    }
} 
```

After adding this in code, you set your debugger to break on all
unhandled exceptions. Run the program under the debugger, and the
debugger breaks whenever `PerformFailingOperation()` throws a
`RecoverableException`. The debugger breaks your program, because
the catch clause won't be executed due to the false-returning
exception filter.

## nameof Expressions


The `nameof` expression evaluates to the name of a symbol. It's a great
way to get tools working with you whenever you need the name of a variable,
a property, or a member field.

One of the most common uses for `nameof` is to provide the name of the
argument that caused an `ArgumentNullException`:

```csharp
public void UpdateLabel(string newLabel)
{
    if (newLabel == null)
        throw new ArgumentNullException(nameof(newLabel), "the new label cannot be null");
}
```

Another use is with XAML based applications that implement the `INotifyPropertyChanged`
interface:

```csharp
public string LastName
{
    get { return lastName; }
    set
    {
        if (lastName != value)
        {
            lastName = value;
            OnPropertyChanged?.Invoke(this, nameof(LastName));
        }
    }
}
```

The advantage of using the `nameof` operator over a constant string
is that tools can understand the symbol. If you use refactoring tools
to rename the symbol, it will rename it in the `nameof` expression.
Constant strings don't have that advantage.

## Await in Catch and Finally blocks

C# 5 had several limitations around where you could place `await` expressions.
One of those has been removed in C# 6. You can now use `await` in `catch` or
`finally` expressions. 

The addition of await expressions in catch and finally blocks may
appear to complicate how those are processed. Let's add an example
to discuss how this appears:

```csharp
// Example outline:

// First, add an await in a finally, and show that happens
// upstream: it's just like normal await expressions.

// Now, add an await in the catch clause. Again, not so hard.

// Now, modify the async code so that it does throw a 
// new exception. Explain the flow (how the catch clause throws
// a new exception when the awaited task completed. This results
// in a faulted task upstream.)
```

## Index Initializers

***Index Initializers*** is one of two features that make collection
initializers more consistent. In earlier releases of C#, you could use
***collection initializers*** only with sequence style collections:

```csharp
// example with a List
```

Now, you can also use them with `Dictionary` collections and similar types:

```csharp
// example with a Dictionary collection
```

### Extension add methods in collection initializers

Another feature that makes collection initialization easier is the
ability for an extension method to the accessible `Add` method
that enables collection initializers.

This feature is added for parity with Visual Basic.

For example:

```csharp
// Define custom collection that doesn't implement Add
```

## Improved overload resolution

This last feature is one you probably won't notice. There were
times when the previous version of the C# compiler may have found
some method calls involving lambda expressions ambiguious:

```csharp
// Dig up the one example that failed

static Task DoThings() { return Task.FromResult(0);

Task.Run(DoThings); // failed.
// Could have been Task.Run(Action) or Task.Run(Func<Task>);
// Now, correctly picks Task.Run(Func<Task>()

// Old code needed to use the lambda expression instead of the
// method group name.
```

Constructs such as these will now pick the correct method.

    
For information about new features in C# 6, we suggest you head over to [the Roslyn repository in GitHub](https://github.com/dotnet/roslyn/wiki/New-Language-Features-in-C%23-6).
