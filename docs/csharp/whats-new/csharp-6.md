---
title: What's New in C# 6 - C# Guide
description: Learn the new features in C# Version 6
ms.date: 12/12/2018
---

# What's New in C# 6

The 6.0 release of C# contained many features that improve productivity for developers. The overall effect of these features is that you write more concise code that is also more readable. The syntax contains less ceremony for many common practices. It's easier to see the design intent with less ceremony. Learn these features well, and you'll be more productive and write more readable code. You can concentrate more on your features than on the constructs of the language.

The rest of this article provides an overview of each of these features, with a link to explore each feature. You can also explore the features in an [interactive exploration on C# 6](../tutorials/exploration/csharp-6.yml) in the tutorials section.

## Read-only auto-properties

*Read-only auto-properties* provide a more concise syntax to create immutable types. You declare the auto-property
with only a get accessor:

[!code-csharp[ReadOnlyAutoProperty](../../../samples/snippets/csharp/new-in-6/newcode.cs#ReadOnlyAutoProperty)]

The `FirstName` and `LastName` properties can be set only in the body of a constructor:

[!code-csharp[ReadOnlyAutoPropertyConstructor](../../../samples/snippets/csharp/new-in-6/newcode.cs#ReadOnlyAutoPropertyConstructor)]

Trying to set `LastName` in another method generates a `CS0200` compilation error:

```csharp
public class Student
{
    public string LastName { get;  }

    public void ChangeName(string newLastName)
    {
        // Generates CS0200: Property or indexer cannot be assigned to -- it is read only
        LastName = newLastName;
    }
}
```

This feature enables true language support for creating immutable types and uses the more concise and convenient auto-property syntax.

If adding this syntax doesn't remove an accessible method, it's a [binary compatible change](version-update-considerations.md#binary-compatible-changes).

## Auto-property initializers

*Auto-property initializers* let you declare the initial value for an auto-property as part of the property declaration.

[!code-csharp[Initialization](../../../samples/snippets/csharp/new-in-6/newcode.cs#Initialization)]

The `Grades` member is initialized where it's declared. That makes it easier to perform the initialization exactly once. The initialization is part of the property declaration, making it easier to equate the storage allocation with the public interface for `Student` objects.

## Expression-bodied function members

Many members that you write are single statements that could be single expressions. Write an expression-bodied member instead. It works for methods and read-only properties. For example, an override of `ToString()` is often a great candidate:

[!code-csharp[ToStringExpressionMember](../../../samples/snippets/csharp/new-in-6/newcode.cs#ToStringExpressionMember)]

You can also use this syntax for read-only properties:

[!code-csharp[FullNameExpressionMember](../../../samples/snippets/csharp/new-in-6/newcode.cs#FullNameExpressionMember)]

Changing an existing member to an expression bodied member is a [binary compatible change](version-update-considerations.md#binary-compatible-changes).

## using static

The *using static* enhancement enables you to import the static methods of a single class. You specify the class you're using:

[!code-csharp[UsingStaticMath](../../../samples/snippets/csharp/new-in-6/newcode.cs#UsingStaticMath)]

The <xref:System.Math> does not contain any instance methods. You can also use `using static` to import a class' static methods for a class that has both static and instance methods. One of the most useful examples is <xref:System.String>:

[!code-csharp[UsingStatic](../../../samples/snippets/csharp/new-in-6/newcode.cs#UsingStatic)]

> [!NOTE]
> You must use the fully qualified class name, `System.String`  in a static using statement.  You cannot use the `string` keyword instead.

When imported from a `static using` statement, extension methods are only in scope when called using the extension method invocation syntax. They aren't in scope when called as a static method. You'll often see this in LINQ queries. You can import the LINQ pattern by importing <xref:System.Linq.Enumerable>, or <xref:System.Linq.Queryable>.

[!code-csharp[UsingStaticLinq](../../../samples/snippets/csharp/new-in-6/newcode.cs#usingStaticLinq)]

You typically call extension methods using extension method invocation expressions. Adding the class name in the rare case where you call them using static method call syntax resolves ambiguity.

The `static using` directive also imports any nested types. You can reference any nested types without qualification.

## Null-conditional operators

The *null conditional operator* makes null checks much easier and fluid. Replace the member access `.` with `?.`:

[!code-csharp[NullConditional](../../../samples/snippets/csharp/new-in-6/program.cs#NullConditional)]

In the preceding example, the variable `first` is assigned `null` if the person object is `null`. Otherwise, it is assigned the value of the `FirstName` property. Most importantly, the `?.` means that this line of code doesn't generate a `NullReferenceException` if the `person` variable is `null`. Instead, it short-circuits and returns `null`. You can also use a null conditional operator for array or indexer access. Replace `[]` with `?[]` in the index expression.

The following expression returns a `string`, regardless of the value of `person`. You often use this construct with the *null coalescing* operator to assign default values when one of the properties is `null`. When the expression short-circuits, the `null` value returned is typed to match the full expression.

[!code-csharp[NullCoalescing](../../../samples/snippets/csharp/new-in-6/program.cs#NullCoalescing)]

You can also use `?.` to conditionally invoke methods. The most common use of member functions  with the null conditional operator is to safely invoke delegates (or event handlers) that may be `null`.  You'll call the delegate's `Invoke` method using the `?.` operator to access the member. You can see an example in the [delegate patterns](../delegates-patterns.md#handling-null-delegates) article.

The rules of the `?.` operator ensure that the left-hand side of the operator is evaluated only once. It enables many idioms, including the following example using event handlers:

```csharp
// preferred in C# 6:
this.SomethingHappened?.Invoke(this, eventArgs);
```

Ensuring that the left side is evaluated only once also enables you to use any expression, including method calls, on the left side of the `?.`

## String interpolation

With C# 6, the new [string interpolation](../language-reference/tokens/interpolated.md) feature enables you to embed expressions in a string. Simply preface the string with `$`and use expressions between `{` and `}` instead of ordinals:

[!code-csharp[stringInterpolation](../../../samples/snippets/csharp/new-in-6/newcode.cs#FullNameExpressionMember)]

This example uses properties for the substituted expressions. You can use any expression. For example, you could compute a student's grade point average as part of the interpolation:

[!code-csharp[stringInterpolationFormat](../../../samples/snippets/csharp/new-in-6/newcode.cs#stringInterpolationFormat)]

The preceding line of code formats the value for `Grades.Average()` as a floating-point number with two decimal places.

Often, you may need to format the string produced using a specific culture. You use the fact that the object produced by a string interpolation can be implicitly converted to <xref:System.FormattableString?displayProperty=nameWithType>. The <xref:System.FormattableString> instance contains the composite format string and the results of evaluating the expressions before converting them to strings. Use the <xref:System.FormattableString.ToString(System.IFormatProvider)?displayProperty=nameWithType> method to specify the culture when formatting a string. The following example produces a string using the German (de-DE) culture. (By default, the German culture uses the ',' character for the decimal separator, and the '.' character as the thousands separator.)

```csharp
FormattableString str = $"Average grade is {s.Grades.Average()}";
var gradeStr = str.ToString(new System.Globalization.CultureInfo("de-DE"));
```

To get started with string interpolation, see the [String interpolation in C#](../tutorials/exploration/interpolated-strings.yml) interactive tutorial, the [String interpolation](../language-reference/tokens/interpolated.md) article, and the [String interpolation in C#](../tutorials/string-interpolation.md) tutorial.

## Exception filters

*Exception Filters* are clauses that determine when a given catch clause should be applied. If the expression used for an exception filter evaluates to `true`, the catch clause performs its normal processing on an exception. If the
expression evaluates to `false`, then the `catch` clause is skipped. One use is to examine information about an exception to determine if a `catch` clause can process the exception:

[!code-csharp[ExceptionFilter](../../../samples/snippets/csharp/new-in-6/NetworkClient.cs#ExceptionFilter)]

## The `nameof` expression

The `nameof` expression evaluates to the name of a symbol. It's a great way to get tools working whenever you need the name of a variable, a property, or a member field. One of the most common uses for `nameof` is to provide the name of a symbol that caused an exception:

[!code-csharp[nameof](../../../samples/snippets/csharp/new-in-6/NewCode.cs#UsingStaticString)]

Another use is with XAML-based applications that implement the `INotifyPropertyChanged` interface:

[!code-csharp[nameofNotify](../../../samples/snippets/csharp/new-in-6/viewmodel.cs#nameofNotify)]

## Await in Catch and Finally blocks

C# 5 had several limitations around where you could place `await` expressions. With C# 6, you can now use `await` in `catch` or `finally` expressions. This is most often used with logging scenarios:

[!code-csharp[AwaitFinally](../../../samples/snippets/csharp/new-in-6/NetworkClient.cs#AwaitFinally)]

The implementation details for adding `await` support inside `catch` and `finally` clauses ensure that the behavior is consistent with the behavior for synchronous code. When code executed in a `catch` or `finally` clause throws, execution looks for a suitable `catch` clause in the next surrounding block. If there was a current exception, that exception is lost. The same happens with awaited expressions in `catch` and `finally` clauses: a suitable `catch` is searched for, and the current exception, if any, is lost.  

> [!NOTE]
> This behavior is the reason it's recommended to write `catch` and `finally` clauses carefully, to avoid introducing new exceptions.

## Initialize associative collections using indexers

*Index Initializers* is one of two features that make collection initializers more consistent with index usage. In earlier releases of C#, you could use *collection initializers* with sequence style collections, including <xref:System.Collections.Generic.Dictionary%602>, by adding braces around key and value pairs:

[!code-csharp[ListInitializer](../../../samples/snippets/csharp/new-in-6/initializers.cs#CollectionInitializer)]

You can use them with <xref:System.Collections.Generic.Dictionary%602> collections and other types where the accessible `Add` method accepts more than one argument. The new syntax supports assignment using an index into the collection:

[!code-csharp[DictionaryInitializer](../../../samples/snippets/csharp/new-in-6/initializers.cs#DictionaryInitializer)]

This feature means that associative containers can be initialized using syntax similar to what's been in place for sequence containers for several versions.

## Extension `Add` methods in collection initializers

Another feature that makes collection initialization easier is the ability to use an *extension method* for the `Add` method. This feature was added for parity with Visual Basic. The feature is most useful when you have a custom collection class that has a method with a different name to semantically add new items.

## Improved overload resolution

This last feature is one you probably won't notice. There were constructs where the previous version of the C# compiler may have found some method calls involving lambda expressions ambiguous. Consider this method:

[!code-csharp[AsyncMethod](../../../samples/snippets/csharp/new-in-6/overloads.cs#AsyncMethod)]

In earlier versions of C#, calling that method using the method group syntax would fail:

[!code-csharp[MethodGroup](../../../samples/snippets/csharp/new-in-6/overloads.cs#MethodGroup)]

The earlier compiler couldn't distinguish correctly between `Task.Run(Action)` and `Task.Run(Func<Task>())`. In previous versions, you'd need to use a lambda expression as an argument:

[!code-csharp[Lambda](../../../samples/snippets/csharp/new-in-6/overloads.cs#Lambda)]

The C# 6 compiler correctly determines that `Task.Run(Func<Task>())` is a better choice.

### Deterministic compiler output

The `-deterministic` option instructs the compiler to produce a byte-for-byte identical output assembly for successive compilations of the same source files.

By default, every compilation produces unique output on each compilation. The compiler adds a timestamp, and a GUID generated from random numbers. You use this option if you want to compare the byte-for-byte output to ensure consistency across builds.

For more information, see the [-deterministic compiler option](../language-reference/compiler-options/deterministic-compiler-option.md) article.
