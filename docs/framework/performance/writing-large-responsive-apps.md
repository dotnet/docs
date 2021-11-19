---
title: "Writing Large, Responsive .NET Framework Apps"
description: Write large, responsive .NET apps, or apps that process a large amount of data, such as files or databases.
ms.date: "03/30/2017"
ms.assetid: 123457ac-4223-4273-bb58-3bc0e4957e9d
author: "BillWagner"
ms.author: "wiwagn"
---
# Writing Large, Responsive .NET Framework Apps

This article provides tips for improving the performance of large .NET Framework apps, or apps that process a large amount of data such as files or databases. These tips come from rewriting the C# and Visual Basic compilers in managed code, and this article includes several real examples from the C# compiler.
  
The .NET Framework is highly productive for building apps. Powerful and safe languages and a rich collection of libraries make app building highly fruitful. However, with great productivity comes responsibility. You should use all the power of the .NET Framework, but be prepared to tune your code’s performance when needed.
  
## Why the new compiler performance applies to your app  

 The .NET Compiler Platform ("Roslyn") team rewrote the C# and Visual Basic compilers in managed code to provide new APIs for modeling and analyzing code, building tools, and enabling much richer, code-aware experiences in Visual Studio. Rewriting the compilers and building Visual Studio experiences on the new compilers revealed useful performance insights that are applicable to any large .NET Framework app or any app that processes a lot of data. You don't need to know about compilers to take advantage of the insights and examples from the C# compiler.
  
 Visual Studio uses the compiler APIs to build all the IntelliSense features that users love, such as colorization of identifiers and keywords, syntax completion lists, squiggles for errors, parameter tips, code issues, and code actions. Visual Studio provides this help while developers are typing and changing their code, and Visual Studio must remain responsive while the compiler continually models the code developers edit.
  
 When your end users interact with your app, they expect it to be responsive. Typing or command handling should never be blocked. Help should pop up quickly or give up if the user continues typing. Your app should avoid blocking the UI thread with long computations that make the app feel sluggish.
  
 For more information about Roslyn compilers, see [The .NET Compiler Platform SDK](../../csharp/roslyn-sdk/index.md).
  
## Just the Facts  

 Consider these facts when tuning performance and creating responsive .NET Framework apps.
  
### Fact 1: Premature optimizations are not always worth the hassle

 Writing code that is more complex than it needs to be incurs maintenance, debugging, and polishing costs. Experienced programmers have an intuitive grasp of how to solve coding problems and write more efficient code. However, they sometimes prematurely optimize their code. For example, they use a hash table when a simple array would suffice, or use complicated caching that may leak memory instead of simply recomputing values. Even if you’re an experience programmer, you should test for performance and analyze your code when you find issues.
  
### Fact 2: If you’re not measuring, you’re guessing  

 Profiles and measurements don’t lie. Profiles show you whether the CPU is fully loaded or whether you’re blocked on disk I/O. Profiles tell you what kind and how much memory you’re allocating and whether your CPU is spending a lot of time in [garbage collection](../../standard/garbage-collection/index.md) (GC).
  
 You should set performance goals for key customer experiences or scenarios in your app and write tests to measure performance. Investigate failing tests by applying the scientific method: use profiles to guide you, hypothesize what the issue might be, and test your hypothesis with an experiment or code change. Establish baseline performance measurements over time with regular testing, so you can isolate changes that cause regressions in performance. By approaching performance work in a rigorous way, you’ll avoid wasting time with code updates you don’t need.
  
### Fact 3: Good tools make all the difference  

 Good tools let you drill quickly into the biggest performance issues (CPU, memory, or disk) and help you locate the code that causes those bottlenecks. Microsoft ships a variety of performance tools such as [Visual Studio Profiler](/visualstudio/profiling/beginners-guide-to-performance-profiling) and [PerfView](https://www.microsoft.com/download/details.aspx?id=28567).
  
 PerfView is a free and amazingly powerful tool that helps you focus on deep issues such as disk I/O, GC events, and memory. You can capture performance-related [Event Tracing for Windows](../wcf/samples/etw-tracing.md) (ETW) events and view easily per app, per process, per stack, and per thread information. PerfView shows you how much and what kind of memory your app allocates, and which functions or call stacks contribute how much to the memory allocations. For details, see the rich help topics, demos, and videos included with the tool (such as the [PerfView tutorials](https://channel9.msdn.com/Series/PerfView-Tutorial) on Channel 9).
  
### Fact 4: It’s all about allocations  

 You might think that building a responsive .NET Framework app is all about algorithms, such as using quick sort instead of bubble sort, but that's not the case. The biggest factor in building a responsive app is allocating memory, especially when your app is very large or processes large amounts of data.
  
 Almost all the work to build responsive IDE experiences with the new compiler APIs involved avoiding allocations and managing caching strategies. PerfView traces show that the performance of the new C# and Visual Basic compilers is rarely CPU bound. The compilers can be I/O bound when reading hundreds of thousands or millions of lines of code, reading metadata, or emitting generated code. The UI thread delays are nearly all due to garbage collection. The .NET Framework GC is highly tuned for performance and does much of its work concurrently while app code executes. However, a single allocation can trigger an expensive [gen2](../../standard/garbage-collection/fundamentals.md) collection, stopping all threads.
  
## Common allocations and examples  

 The example expressions in this section have hidden allocations that appear small. However, if a large app executes the expressions enough times, they can causes hundreds of megabytes, even gigabytes, of allocations. For example, one-minute tests that simulated a developer’s typing in the editor allocated gigabytes of memory and led the performance team to focus on typing scenarios.
  
### Boxing  

 [Boxing](../../csharp/programming-guide/types/boxing-and-unboxing.md) occurs when value types that normally live on the stack or in data structures are wrapped in an object. That is, you allocate an object to hold the data, and then return a pointer to the object. The .NET Framework sometimes boxes values due to the signature of a method or the type of a storage location. Wrapping a value type in an object causes memory allocation. Many boxing operations can contribute megabytes or gigabytes of allocations to your app, which means that your app will cause more GCs. The .NET Framework and the language compilers avoid boxing when possible, but sometimes it happens when you least expect it.
  
 To see boxing in PerfView, open a trace and look at GC Heap Alloc Stacks under your app’s process name (remember, PerfView reports on all processes). If you see types like <xref:System.Int32?displayProperty=nameWithType> and <xref:System.Char?displayProperty=nameWithType> under allocations, you are boxing value types. Choosing one of these types will show the stacks and functions in which they are boxed.
  
 **Example 1: string methods and value type arguments**  
  
 This sample code illustrates potentially unnecessary and excessive boxing:  
  
```csharp  
public class Logger  
{  
    public static void WriteLine(string s) { /*...*/ }  
}  
  
public class BoxingExample  
{  
    public void Log(int id, int size)  
    {  
        var s = string.Format("{0}:{1}", id, size);  
        Logger.WriteLine(s);  
    }  
}  
```  
  
 This code provides logging functionality, so an app may call the `Log` function frequently, maybe millions of times. The problem is that the call to `string.Format` resolves to the <xref:System.String.Format%28System.String%2CSystem.Object%2CSystem.Object%29> overload.
  
 This overload requires the .NET Framework to box the `int` values into objects to pass them to this method call. A partial fix is to call `id.ToString()` and `size.ToString()` and pass all strings (which are objects) to the `string.Format` call. Calling `ToString()` does allocate a string, but that allocation will happen anyway inside `string.Format`.
  
 You might consider that this basic call to `string.Format` is just string concatenation, so you might write this code instead:  
  
```csharp  
var s = id.ToString() + ':' + size.ToString();  
```  
  
 However, that line of code introduces a boxing allocation because it compiles to <xref:System.String.Concat%28System.Object%2CSystem.Object%2CSystem.Object%29>. The .NET Framework must box the character literal to invoke `Concat`  
  
 **Fix for example 1**  
  
 The complete fix is simple. Just replace the character literal with a string literal, which incurs no boxing because strings are already objects:  
  
```csharp  
var s = id.ToString() + ":" + size.ToString();  
```  
  
 **Example 2: enum boxing**  
  
 This example was responsible for a huge amount of allocation in the new C# and Visual Basic compilers due to frequent use of enumeration types, especially in dictionary lookup operations.
  
```csharp  
public enum Color  
{  
    Red, Green, Blue  
}  
  
public class BoxingExample  
{  
    private string name;  
    private Color color;  
    public override int GetHashCode()  
    {  
        return name.GetHashCode() ^ color.GetHashCode();  
    }  
}  
```  
  
 This problem is very subtle. PerfView would report this as <xref:System.Enum.GetHashCode> boxing because the method boxes the underlying representation of the enumeration type, for implementation reasons. If you look closely in PerfView, you may see two boxing allocations for each call to <xref:System.Enum.GetHashCode>. The compiler inserts one, and the .NET Framework inserts the other.
  
 **Fix for example 2**  
  
 You can easily avoid both allocations by casting to the underlying representation before calling <xref:System.Enum.GetHashCode>:  
  
```csharp  
((int)color).GetHashCode()  
```  
  
 Another common source of boxing on enumeration types is the <xref:System.Enum.HasFlag%28System.Enum%29?displayProperty=nameWithType> method. The argument passed to <xref:System.Enum.HasFlag%28System.Enum%29> has to be boxed. In most cases, replacing calls to <xref:System.Enum.HasFlag%28System.Enum%29?displayProperty=nameWithType> with a bitwise test is simpler and allocation-free.
  
 Keep the first performance fact in mind (that is, don’t prematurely optimize) and don’t start rewriting all your code in this way. Be aware of these boxing costs, but change your code only after profiling your app and finding the hot spots.
  
### Strings  

 String manipulations are some of the biggest culprits for allocations, and they often show up in PerfView in the top five allocations. Programs use strings for serialization, JSON, and REST APIs. You can use strings as programmatic constants for interoperating with systems when you can’t use enumeration types. When your profiling shows that strings are highly affecting performance, look for calls to <xref:System.String> methods such as <xref:System.String.Format%2A>, <xref:System.String.Concat%2A>, <xref:System.String.Split%2A>, <xref:System.String.Join%2A>, <xref:System.String.Substring%2A>, and so on. Using <xref:System.Text.StringBuilder> to avoid the cost of creating one string from many pieces helps, but even allocating the <xref:System.Text.StringBuilder> object might become a bottleneck that you need to manage.
  
 **Example 3: string operations**  
  
 The C# compiler had this code that writes the text of a formatted XML doc comment:  
  
```csharp  
public void WriteFormattedDocComment(string text)  
{  
    string[] lines = text.Split(new[] { "\r\n", "\r", "\n" },  
                                StringSplitOptions.None);  
    int numLines = lines.Length;  
    bool skipSpace = true;  
    if (lines[0].TrimStart().StartsWith("///"))  
    {  
        for (int i = 0; i < numLines; i++)  
        {  
            string trimmed = lines[i].TrimStart();  
            if (trimmed.Length < 4 || !char.IsWhiteSpace(trimmed[3]))  
            {  
                skipSpace = false;  
                break;  
            }  
        }  
        int substringStart = skipSpace ? 4 : 3;  
        for (int i = 0; i < numLines; i++)  
            WriteLine(lines[i].TrimStart().Substring(substringStart));  
    }  
    else { /* ... */ }  
```  
  
 You can see that this code does a lot of string manipulation. The code uses library methods to split lines into separate strings, to trim white space, to check whether the argument `text` is an XML documentation comment, and to extract substrings from lines.
  
 On the first line inside `WriteFormattedDocComment`, the `text.Split` call allocates a new three-element array as the argument every time it’s called. The compiler has to emit code to allocate this array each time. That’s because the compiler doesn’t know if <xref:System.String.Split%2A> stores the array somewhere where the array might be modified by other code, which would affect later calls to `WriteFormattedDocComment`. The call to <xref:System.String.Split%2A> also allocates a string for every line in `text` and allocates other memory to perform the operation.
  
 `WriteFormattedDocComment` has three calls to the <xref:System.String.TrimStart%2A> method. Two are in inner loops that duplicate work and allocations. To make matters worse, calling the <xref:System.String.TrimStart%2A> method with no arguments allocates an empty array (for the `params` parameter) in addition to the string result.
  
 Lastly, there is a call to the <xref:System.String.Substring%2A> method, which usually allocates a new string.
  
 **Fix for example 3**  
  
 Unlike the earlier examples, small edits cannot fix these allocations. You need to step back, look at the problem, and approach it differently. For example, you'll notice that the argument to `WriteFormattedDocComment()` is a string that has all the information that the method needs, so the code could do more indexing instead of allocating many partial strings.
  
 The compiler’s performance team tackled all these allocations with code like this:  
  
```csharp  
private int IndexOfFirstNonWhiteSpaceChar(string text, int start) {  
    while (start < text.Length && char.IsWhiteSpace(text[start])) start++;  
    return start;  
}  
  
private bool TrimmedStringStartsWith(string text, int start, string prefix) {  
    start = IndexOfFirstNonWhiteSpaceChar(text, start);  
    int len = text.Length - start;  
    if (len < prefix.Length) return false;  
    for (int i = 0; i < len; i++)  
    {  
        if (prefix[i] != text[start + i]) return false;  
    }  
    return true;  
}  
  
// etc...
```  
  
 The first version of `WriteFormattedDocComment()` allocated an array, several substrings, and a trimmed substring along with an empty `params` array. It also checked for "///". The revised code uses only indexing and allocates nothing. It finds the first character that is not white space, and then checks character by character to see if the string starts with "///". The new code uses `IndexOfFirstNonWhiteSpaceChar` instead of <xref:System.String.TrimStart%2A> to return the first index (after a specified start index) where a non-white-space character occurs. The fix is not complete, but you can see how to apply similar fixes for a complete solution. By applying this approach throughout the code, you can remove all allocations in `WriteFormattedDocComment()`.
  
 **Example 4: StringBuilder**  
  
 This example uses a <xref:System.Text.StringBuilder> object. The following function generates a full type name for generic types:  
  
```csharp  
public class Example  
{  
    // Constructs a name like "SomeType<T1, T2, T3>"  
    public string GenerateFullTypeName(string name, int arity)  
    {  
        StringBuilder sb = new StringBuilder();  
  
        sb.Append(name);  
        if (arity != 0)  
        {  
            sb.Append("<");  
            for (int i = 1; i < arity; i++)  
            {  
                sb.Append("T"); sb.Append(i.ToString()); sb.Append(", ");  
            }  
            sb.Append("T"); sb.Append(i.ToString()); sb.Append(">");  
        }  
  
        return sb.ToString();  
    }  
}  
```  
  
 The focus is on the line that creates a new <xref:System.Text.StringBuilder> instance. The code causes an allocation for `sb.ToString()` and internal allocations within the <xref:System.Text.StringBuilder> implementation, but you cannot control those allocations if you want the string result.
  
 **Fix for example 4**  
  
 To fix the `StringBuilder` object allocation, cache the  object. Even caching a single instance that might get thrown away can improve performance significantly. This is the function’s new implementation, omitting all the code except for the new first and last lines:  
  
```csharp  
// Constructs a name like "MyType<T1, T2, T3>"  
public string GenerateFullTypeName(string name, int arity)  
{  
    StringBuilder sb = AcquireBuilder();  
    /* Use sb as before */  
    return GetStringAndReleaseBuilder(sb);  
}  
```  
  
 The key parts are the new `AcquireBuilder()` and `GetStringAndReleaseBuilder()` functions:  
  
```csharp  
[ThreadStatic]  
private static StringBuilder cachedStringBuilder;  
  
private static StringBuilder AcquireBuilder()  
{  
    StringBuilder result = cachedStringBuilder;  
    if (result == null)  
    {  
        return new StringBuilder();  
    }  
    result.Clear();  
    cachedStringBuilder = null;  
    return result;  
}  
  
private static string GetStringAndReleaseBuilder(StringBuilder sb)  
{  
    string result = sb.ToString();  
    cachedStringBuilder = sb;  
    return result;  
}  
```  
  
 Because the new compilers use threading, these implementations use a thread-static field (<xref:System.ThreadStaticAttribute> attribute) to cache the <xref:System.Text.StringBuilder>, and you likely can forgo the `ThreadStatic` declaration. The thread-static field holds a unique value for each thread that executes this code.
  
 `AcquireBuilder()` returns the cached <xref:System.Text.StringBuilder> instance if there is one, after clearing it and setting the field or cache to null. Otherwise, `AcquireBuilder()` creates a new instance and returns it, leaving the field or cache set to null.
  
 When you’re done with <xref:System.Text.StringBuilder> , you call `GetStringAndReleaseBuilder()` to get the string result, save the <xref:System.Text.StringBuilder> instance in the field or cache, and then return the result. It is possible for execution to re-enter this code and to create multiple <xref:System.Text.StringBuilder> objects (although that rarely happens). The code saves only the last released <xref:System.Text.StringBuilder> instance for later use. This simple caching strategy significantly reduced allocations in the new compilers. Parts of the .NET Framework and MSBuild ("MSBuild") use a similar technique to improve performance.
  
 This simple caching strategy adheres to good cache design because it has a size cap. However, there is more code now than in the original, which means more maintenance costs. You should adopt the caching strategy only if you’ve found a performance problem, and PerfView has shown that <xref:System.Text.StringBuilder> allocations are a significant contributor.
  
### LINQ and lambdas  

Language-Integrated Query (LINQ), in conjunction with lambda expressions, is an example of a productivity feature. However, its use may have a significant impact on performance over time, and you might find you need to rewrite your code.
  
 **Example 5: Lambdas, List\<T>, and IEnumerable\<T>**  
  
 This example uses [LINQ and functional style code](/archive/blogs/charlie/anders-hejlsberg-on-linq-and-functional-programming) to find a symbol in the compiler’s model, given a name string:  
  
```csharp  
class Symbol {  
    public string Name { get; private set; }  
    /*...*/  
}  
  
class Compiler {  
    private List<Symbol> symbols;  
    public Symbol FindMatchingSymbol(string name)  
    {  
        return symbols.FirstOrDefault(s => s.Name == name);  
    }  
}  
```  
  
 The new compiler and the IDE experiences built on it call `FindMatchingSymbol()` very frequently, and there are several hidden allocations in this function’s single line of code. To examine those allocations, first split the function’s single line of code into two lines:  
  
```csharp  
Func<Symbol, bool> predicate = s => s.Name == name;  
     return symbols.FirstOrDefault(predicate);  
```  
  
 In the first line, the [lambda expression](../../csharp/language-reference/operators/lambda-expressions.md) `s => s.Name == name` [closes over](/archive/blogs/ericlippert/what-are-closures) the local variable `name`. This means that in addition to allocating an object for the [delegate](../../csharp/language-reference/builtin-types/reference-types.md#the-delegate-type) that `predicate` holds, the code allocates a static class to hold the environment that captures the value of `name`. The compiler generates code like the following:  
  
```csharp  
// Compiler-generated class to hold environment state for lambda  
private class Lambda1Environment  
{  
    public string capturedName;  
    public bool Evaluate(Symbol s)  
    {  
        return s.Name == this.capturedName;  
    }  
}  
  
// Expanded Func<Symbol, bool> predicate = s => s.Name == name;  
Lambda1Environment l = new Lambda1Environment() { capturedName = name };  
var predicate = new Func<Symbol, bool>(l.Evaluate);  
```  
  
 The two `new` allocations (one for the environment class and one for the delegate) are explicit now.
  
 Now look at the call to `FirstOrDefault`. This extension method on the <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType> type incurs an allocation too. Because `FirstOrDefault` takes an <xref:System.Collections.Generic.IEnumerable%601> object as its first argument, you can expand the call to the following code (simplified a bit for discussion):  
  
```csharp  
// Expanded return symbols.FirstOrDefault(predicate) ...
     IEnumerable<Symbol> enumerable = symbols;  
     IEnumerator<Symbol> enumerator = enumerable.GetEnumerator();  
     while(enumerator.MoveNext())  
     {  
         if (predicate(enumerator.Current))  
             return enumerator.Current;  
     }  
     return default(Symbol);  
```  
  
 The `symbols` variable has type <xref:System.Collections.Generic.List%601>. The <xref:System.Collections.Generic.List%601> collection type implements <xref:System.Collections.Generic.IEnumerable%601> and cleverly defines an enumerator (<xref:System.Collections.Generic.IEnumerator%601> interface) that <xref:System.Collections.Generic.List%601> implements with a `struct`. Using a structure instead of a class means that you usually avoid any heap allocations, which, in turn, can affect garbage collection performance. Enumerators are typically used with the language’s `foreach` loop, which uses the enumerator structure as it is returned on the call stack. Incrementing the call stack pointer to make room for an object does not affect GC the way a heap allocation does.
  
 In the case of the expanded `FirstOrDefault` call, the code needs to call `GetEnumerator()` on an <xref:System.Collections.Generic.IEnumerable%601>. Assigning `symbols` to the `enumerable` variable of type `IEnumerable<Symbol>` loses the information that the actual object is a <xref:System.Collections.Generic.List%601>. This means that when the code fetches the enumerator with `enumerable.GetEnumerator()`, the .NET Framework has to box the returned structure to assign it to the `enumerator` variable.
  
 **Fix for example 5**  
  
 The fix is to rewrite `FindMatchingSymbol` as follows, replacing its single line of code with six lines of code that are still concise, easy to read and understand, and easy to maintain:  
  
```csharp  
public Symbol FindMatchingSymbol(string name)  
    {  
        foreach (Symbol s in symbols)  
        {  
            if (s.Name == name)  
                return s;  
        }  
        return null;  
    }  
```  
  
 This code doesn’t use LINQ extension methods, lambdas, or enumerators, and it incurs no allocations. There are no allocations because the compiler can see that the `symbols` collection is a <xref:System.Collections.Generic.List%601> and can bind the resulting enumerator (a structure) to a local variable with the right type to avoid boxing. The original version of this function was a great example of the expressive power of C# and the productivity of the .NET Framework. This new and more efficient version preserves those qualities without adding any complex code to maintain.
  
### Async method caching  

The next example shows a common problem when you try to use cached results in an [async](../../csharp/programming-guide/concepts/async/index.md) method.
  
 **Example 6: caching in async methods**  
  
 The Visual Studio IDE features built on the new C# and Visual Basic compilers frequently fetch syntax trees, and the compilers use async when doing so to keep Visual Studio responsive. Here’s the first version of the code you might write to get a syntax tree:  
  
```csharp  
class SyntaxTree { /*...*/ }  
  
class Parser { /*...*/  
    public SyntaxTree Syntax { get; }  
    public Task ParseSourceCode() { /*...*/ }  
}  
  
class Compilation { /*...*/  
    public async Task<SyntaxTree> GetSyntaxTreeAsync()  
    {  
        var parser = new Parser(); // allocation  
        await parser.ParseSourceCode(); // expensive  
        return parser.Syntax;  
    }  
}  
```  
  
 You can see that calling `GetSyntaxTreeAsync()` instantiates a `Parser`, parses the code, and then returns a <xref:System.Threading.Tasks.Task> object, `Task<SyntaxTree>`. The expensive part is allocating the `Parser` instance and parsing the code. The function returns a <xref:System.Threading.Tasks.Task> so that callers can await the parsing work and free the UI thread to be responsive to user input.
  
 Several Visual Studio features might try to get the same syntax tree, so you might write the following code to cache the parsing result to save time and allocations. However, this code incurs an allocation:  
  
```csharp  
class Compilation { /*...*/  
  
    private SyntaxTree cachedResult;  
  
    public async Task<SyntaxTree> GetSyntaxTreeAsync()  
    {  
        if (this.cachedResult == null)  
        {  
            var parser = new Parser(); // allocation  
            await parser.ParseSourceCode(); // expensive  
            this.cachedResult = parser.Syntax;  
        }  
        return this.cachedResult;  
    }  
}  
```  
  
 You see that the new code with caching has a `SyntaxTree` field named `cachedResult`. When this field is null, `GetSyntaxTreeAsync()` does the work and saves the result in the cache. `GetSyntaxTreeAsync()` returns the `SyntaxTree` object. The problem is that when you have an `async` function of type `Task<SyntaxTree>`, and you return a value of type `SyntaxTree`, the compiler emits code to allocate a Task to hold the result (by using `Task<SyntaxTree>.FromResult()`). The Task is marked as completed, and the result is immediately available. In the code for the new compilers, <xref:System.Threading.Tasks.Task> objects that were already completed occurred so often that fixing these allocations improved responsiveness noticeably.
  
 **Fix for example 6**  
  
 To remove the completed <xref:System.Threading.Tasks.Task> allocation, you can cache the Task object with the completed result:  
  
```csharp  
class Compilation { /*...*/  
  
    private Task<SyntaxTree> cachedResult;  
  
    public Task<SyntaxTree> GetSyntaxTreeAsync()  
    {  
        return this.cachedResult ??
               (this.cachedResult = GetSyntaxTreeUncachedAsync());  
    }  
  
    private async Task<SyntaxTree> GetSyntaxTreeUncachedAsync()  
    {  
        var parser = new Parser(); // allocation  
        await parser.ParseSourceCode(); // expensive  
        return parser.Syntax;  
    }  
}  
```  
  
 This code changes the type of `cachedResult` to `Task<SyntaxTree>` and employs an `async` helper function that holds the original code from `GetSyntaxTreeAsync()`. `GetSyntaxTreeAsync()` now uses the [null coalescing operator](../../csharp/language-reference/operators/null-coalescing-operator.md) to return `cachedResult` if it isn't null. If `cachedResult` is null, then `GetSyntaxTreeAsync()` calls `GetSyntaxTreeUncachedAsync()` and caches the result. Notice that `GetSyntaxTreeAsync()` doesn’t await the call to `GetSyntaxTreeUncachedAsync()` as the code would normally. Not using await means that when `GetSyntaxTreeUncachedAsync()` returns its <xref:System.Threading.Tasks.Task> object, `GetSyntaxTreeAsync()` immediately returns the <xref:System.Threading.Tasks.Task>. Now, the cached result is a <xref:System.Threading.Tasks.Task>, so there are no allocations to return the cached result.
  
### Additional considerations  

 Here are a few more points about potential problems in large apps or apps that process a lot of data.
  
 **Dictionaries**  
  
 Dictionaries are used ubiquitously in many programs, and though dictionaries are very convenient and inherently efficient. However, they’re often used inappropriately. In Visual Studio and the new compilers, analysis shows that many of the dictionaries contained a single element or were empty. An empty <xref:System.Collections.Generic.Dictionary%602> has ten fields and occupies 48 bytes on the heap on an x86 machine. Dictionaries are great when you need a mapping or associative data structure with constant-time lookup. However, when you have only a few elements, you waste a lot of space by using a dictionary. Instead, for example, you could iteratively look through a `List<KeyValuePair\<K,V>>`, just as fast. If you use a dictionary only to load it with data and then read from it (a very common pattern), using a sorted array with an N(log(N)) lookup might be nearly as fast, depending on the number of elements you're using.
  
 **Classes vs. structures**  
  
 In a way, classes and structures provide a classic space/time tradeoff for tuning your apps. Classes incur 12 bytes of overhead on an x86 machine even if they have no fields, but they are inexpensive to pass around because it only takes a pointer to refer to a class instance. Structures incur no heap allocations if they aren’t boxed, but when you pass large structures as function arguments or return values, it takes CPU time to atomically copy all the data members of the structures. Watch out for repeated calls to properties that return structures, and cache the property’s value in a local variable to avoid excessive data copying.
  
 **Caches**  
  
 A common performance trick is to cache results. However, a cache without a size cap or disposal policy can be a memory leak. When processing large amounts of data, if you hold on to a lot of memory in caches, you can cause garbage collection to override the benefits of your cached lookups.
  
 In this article, we discussed how you should be aware of performance bottleneck symptoms that can affect your app's responsiveness, especially for large systems or systems that process a large amount of data. Common culprits include boxing, string manipulations, LINQ and lambda, caching in async methods, caching without a size limit or disposal policy, inappropriate use of dictionaries, and passing around structures. Keep in mind the four facts for tuning your apps:  
  
- Don’t prematurely optimize – be productive and tune your app when you spot problems.
  
- Profiles don’t lie – you’re guessing if you’re not measuring.
  
- Good tools make all the difference – download PerfView and try it out.
  
- It's all about allocations – that is where the compiler platform team spent most of their time improving the performance of the new compilers.
  
## See also

- [Video of presentation of this topic](https://channel9.msdn.com/Events/TechEd/NorthAmerica/2013/DEV-B333)
- [Beginners Guide to Performance Profiling](/visualstudio/profiling/beginners-guide-to-performance-profiling)
- [Performance](index.md)
- [.NET Performance Tips](/previous-versions/dotnet/articles/ms973839(v=msdn.10))
- [Channel 9 PerfView tutorials](https://channel9.msdn.com/Series/PerfView-Tutorial)
- [The .NET Compiler Platform SDK](../../csharp/roslyn-sdk/index.md)
- [dotnet/roslyn repo on GitHub](https://github.com/dotnet/roslyn)
