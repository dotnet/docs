---
title: "Iterators (C#)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: c93f6dd4-e72a-4a06-be1c-a98b3255b734
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
---
# Iterators (C#)
An *iterator* can be used to step through collections such as lists and arrays.  
  
 An iterator method or `get` accessor performs a custom iteration over a collection. An iterator method uses the [yield return](../../../csharp/language-reference/keywords/yield.md) statement to return each element one at a time. When a `yield return` statement is reached, the current location in code is remembered. Execution is restarted from that location the next time the iterator function is called.  
  
 You consume an iterator from client code by using a [foreach](../../../csharp/language-reference/keywords/foreach-in.md) statement or by using a LINQ query.  
  
 In the following example, the first iteration of the `foreach` loop causes execution to proceed  in the `SomeNumbers` iterator method until the first `yield return` statement is reached. This iteration returns a value of 3, and the current location in the iterator method is retained. On the next iteration of the loop, execution in the iterator method continues from where it left off, again stopping when it reaches a `yield return` statement. This iteration returns a value of 5, and the current location in the iterator method is again retained. The loop completes when the end of the iterator method is reached.  
  
```csharp  
static void Main()  
{  
    foreach (int number in SomeNumbers())  
    {  
        Console.Write(number.ToString() + " ");  
    }  
    // Output: 3 5 8  
    Console.ReadKey();  
}  
  
public static System.Collections.IEnumerable SomeNumbers()  
{  
    yield return 3;  
    yield return 5;  
    yield return 8;  
}  
```  
  
 The return type of an iterator method or `get` accessor can be <xref:System.Collections.IEnumerable>, <xref:System.Collections.Generic.IEnumerable%601>, <xref:System.Collections.IEnumerator>, or <xref:System.Collections.Generic.IEnumerator%601>.  
  
 You can use a `yield break` statement to end the iteration.  
  
 Iterators were introduced in C# in Visual Studio 2005.  
  
 **In this topic**  
  
-   [Simple Iterator](#BKMK_SimpleIterator)  
  
-   [Creating a Collection Class](#BKMK_CollectionClass)  
  
-   [Using Iterators with a Generic List](#BKMK_GenericList)  
  
-   [Syntax Information](#BKMK_SyntaxInformation)  
  
-   [Technical Implementation](#BKMK_Technical)  
  
-   [Use of Iterators](#BKMK_UseOfIterators)  
  
> [!NOTE]
>  For all examples in this topic except the Simple Iterator example, include [using](../../../csharp/language-reference/keywords/using-directive.md) directives for the `System.Collections` and `System.Collections.Generic` namespaces.  
  
##  <a name="BKMK_SimpleIterator"></a> Simple Iterator  
 The following example has a single `yield return` statement that is inside a [for](../../../csharp/language-reference/keywords/for.md) loop. In `Main`, each iteration of the `foreach` statement body creates a call to the iterator function, which proceeds to the next `yield return` statement.  
  
```csharp  
static void Main()  
{  
    foreach (int number in EvenSequence(5, 18))  
    {  
        Console.Write(number.ToString() + " ");  
    }  
    // Output: 6 8 10 12 14 16 18  
    Console.ReadKey();  
}  
  
public static System.Collections.Generic.IEnumerable<int>  
    EvenSequence(int firstNumber, int lastNumber)  
{  
    // Yield even numbers in the range.  
    for (int number = firstNumber; number <= lastNumber; number++)  
    {  
        if (number % 2 == 0)  
        {  
            yield return number;  
        }  
    }  
}  
```  
  
##  <a name="BKMK_CollectionClass"></a> Creating a Collection Class  
 In the following example, the `DaysOfTheWeek` class implements the <xref:System.Collections.IEnumerable> interface, which requires a <xref:System.Collections.IEnumerable.GetEnumerator%2A> method. The compiler implicitly calls the `GetEnumerator` method, which returns an <xref:System.Collections.IEnumerator>.  
  
 The `GetEnumerator` method returns each string one at a time by using the `yield return` statement.  
  
```csharp  
static void Main()  
{  
    DaysOfTheWeek days = new DaysOfTheWeek();  
  
    foreach (string day in days)  
    {  
        Console.Write(day + " ");  
    }  
    // Output: Sun Mon Tue Wed Thu Fri Sat  
    Console.ReadKey();  
}  
  
public class DaysOfTheWeek : IEnumerable  
{  
    private string[] days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };  
  
    public IEnumerator GetEnumerator()  
    {  
        for (int index = 0; index < days.Length; index++)  
        {  
            // Yield each day of the week.  
            yield return days[index];  
        }  
    }  
}  
```  
  
 The following example creates a `Zoo` class that contains a collection of animals.  
  
 The `foreach` statement that refers to the class instance (`theZoo`) implicitly calls the `GetEnumerator` method. The `foreach` statements that refer to the `Birds` and `Mammals` properties use the `AnimalsForType` named iterator method.  
  
```csharp  
static void Main()  
{  
    Zoo theZoo = new Zoo();  
  
    theZoo.AddMammal("Whale");  
    theZoo.AddMammal("Rhinoceros");  
    theZoo.AddBird("Penguin");  
    theZoo.AddBird("Warbler");  
  
    foreach (string name in theZoo)  
    {  
        Console.Write(name + " ");  
    }  
    Console.WriteLine();  
    // Output: Whale Rhinoceros Penguin Warbler  
  
    foreach (string name in theZoo.Birds)  
    {  
        Console.Write(name + " ");  
    }  
    Console.WriteLine();  
    // Output: Penguin Warbler  
  
    foreach (string name in theZoo.Mammals)  
    {  
        Console.Write(name + " ");  
    }  
    Console.WriteLine();  
    // Output: Whale Rhinoceros  
  
    Console.ReadKey();  
}  
  
public class Zoo : IEnumerable  
{  
    // Private members.  
    private List<Animal> animals = new List<Animal>();  
  
    // Public methods.  
    public void AddMammal(string name)  
    {  
        animals.Add(new Animal { Name = name, Type = Animal.TypeEnum.Mammal });  
    }  
  
    public void AddBird(string name)  
    {  
        animals.Add(new Animal { Name = name, Type = Animal.TypeEnum.Bird });  
    }  
  
    public IEnumerator GetEnumerator()  
    {  
        foreach (Animal theAnimal in animals)  
        {  
            yield return theAnimal.Name;  
        }  
    }  
  
    // Public members.  
    public IEnumerable Mammals  
    {  
        get { return AnimalsForType(Animal.TypeEnum.Mammal); }  
    }  
  
    public IEnumerable Birds  
    {  
        get { return AnimalsForType(Animal.TypeEnum.Bird); }  
    }  
  
    // Private methods.  
    private IEnumerable AnimalsForType(Animal.TypeEnum type)  
    {  
        foreach (Animal theAnimal in animals)  
        {  
            if (theAnimal.Type == type)  
            {  
                yield return theAnimal.Name;  
            }  
        }  
    }  
  
    // Private class.  
    private class Animal  
    {  
        public enum TypeEnum { Bird, Mammal }  
  
        public string Name { get; set; }  
        public TypeEnum Type { get; set; }  
    }  
}  
```  
  
##  <a name="BKMK_GenericList"></a> Using Iterators with a Generic List  
 In the following example, the `Stack(Of T)` generic class implements the <xref:System.Collections.Generic.IEnumerable%601> generic interface. The `Push` method assigns values to an array of type `T`. The <xref:System.Collections.Generic.IEnumerable%601.GetEnumerator%2A> method returns the array values by using the `yield return` statement.  
  
 In addition to the generic <xref:System.Collections.Generic.IEnumerable%601.GetEnumerator%2A> method, the non-generic <xref:System.Collections.IEnumerable.GetEnumerator%2A> method must also be implemented. This is because <xref:System.Collections.Generic.IEnumerable%601> inherits from <xref:System.Collections.IEnumerable>. The non-generic implementation defers to the generic implementation.  
  
 The example uses named iterators to support various ways of iterating through the same collection of data. These named iterators are the `TopToBottom` and `BottomToTop` properties, and the `TopN` method.  
  
 The `BottomToTop` property uses an iterator in a `get` accessor.  
  
```csharp  
static void Main()  
{  
    Stack<int> theStack = new Stack<int>();  
  
    //  Add items to the stack.  
    for (int number = 0; number <= 9; number++)  
    {  
        theStack.Push(number);  
    }  
  
    // Retrieve items from the stack.  
    // foreach is allowed because theStack implements  
    // IEnumerable<int>.  
    foreach (int number in theStack)  
    {  
        Console.Write("{0} ", number);  
    }  
    Console.WriteLine();  
    // Output: 9 8 7 6 5 4 3 2 1 0  
  
    // foreach is allowed, because theStack.TopToBottom  
    // returns IEnumerable(Of Integer).  
    foreach (int number in theStack.TopToBottom)  
    {  
        Console.Write("{0} ", number);  
    }  
    Console.WriteLine();  
    // Output: 9 8 7 6 5 4 3 2 1 0  
  
    foreach (int number in theStack.BottomToTop)  
    {  
        Console.Write("{0} ", number);  
    }  
    Console.WriteLine();  
    // Output: 0 1 2 3 4 5 6 7 8 9  
  
    foreach (int number in theStack.TopN(7))  
    {  
        Console.Write("{0} ", number);  
    }  
    Console.WriteLine();  
    // Output: 9 8 7 6 5 4 3  
  
    Console.ReadKey();  
}  
  
public class Stack<T> : IEnumerable<T>  
{  
    private T[] values = new T[100];  
    private int top = 0;  
  
    public void Push(T t)  
    {  
        values[top] = t;  
        top++;  
    }  
    public T Pop()  
    {  
        top--;  
        return values[top];  
    }  
  
    // This method implements the GetEnumerator method. It allows  
    // an instance of the class to be used in a foreach statement.  
    public IEnumerator<T> GetEnumerator()  
    {  
        for (int index = top - 1; index >= 0; index--)  
        {  
            yield return values[index];  
        }  
    }  
  
    IEnumerator IEnumerable.GetEnumerator()  
    {  
        return GetEnumerator();  
    }  
  
    public IEnumerable<T> TopToBottom  
    {  
        get { return this; }  
    }  
  
    public IEnumerable<T> BottomToTop  
    {  
        get  
        {  
            for (int index = 0; index <= top - 1; index++)  
            {  
                yield return values[index];  
            }  
        }  
    }  
  
    public IEnumerable<T> TopN(int itemsFromTop)  
    {  
        // Return less than itemsFromTop if necessary.  
        int startIndex = itemsFromTop >= top ? 0 : top - itemsFromTop;  
  
        for (int index = top - 1; index >= startIndex; index--)  
        {  
            yield return values[index];  
        }  
    }  
  
}  
```  
  
##  <a name="BKMK_SyntaxInformation"></a> Syntax Information  
 An iterator can occur as a method or `get` accessor. An iterator cannot occur in an event, instance constructor, static constructor, or static finalizer.  
  
 An implicit conversion must exist from the expression type in the `yield return` statement to the return type of the iterator.  
  
 In C#, an iterator method cannot have any `in`, `ref`, or `out` parameters.  
  
 In C#, "yield" is not a reserved word and has special meaning only when it is used before a `return` or `break` keyword.  
  
##  <a name="BKMK_Technical"></a> Technical Implementation  
 Although you write an iterator as a method, the compiler translates it into a nested class that is, in effect, a state machine. This class keeps track of the position of the iterator as long the `foreach` loop in the client code continues.  
  
 To see what the compiler does, you can use the Ildasm.exe tool to view the Microsoft intermediate language code that is generated for an iterator method.  
  
 When you create an iterator for a [class](../../../csharp/language-reference/keywords/class.md) or [struct](../../../csharp/language-reference/keywords/struct.md), you don't have to implement the whole <xref:System.Collections.IEnumerator> interface. When the compiler detects the iterator, it automatically generates the `Current`, `MoveNext`, and `Dispose` methods of the <xref:System.Collections.IEnumerator> or <xref:System.Collections.Generic.IEnumerator%601> interface.  
  
 On each successive iteration of the `foreach` loop (or the direct call to `IEnumerator.MoveNext`), the next iterator code body resumes after the previous `yield return` statement. It then continues to the next `yield return` statement until the end of the iterator body is reached, or until a `yield break` statement is encountered.  
  
 Iterators don't support the <xref:System.Collections.IEnumerator.Reset%2A?displayProperty=nameWithType> method. To re-iterate from the start, you must obtain a new iterator.  
  
 For additional information, see the [C# Language Specification](../../../csharp/language-reference/language-specification/index.md).  
  
##  <a name="BKMK_UseOfIterators"></a> Use of Iterators  
 Iterators enable you to maintain the simplicity of a `foreach` loop when you need to use complex code to populate a list sequence. This can be useful when you want to do the following:  
  
-   Modify the list sequence after the first `foreach` loop iteration.  
  
-   Avoid fully loading a large list before the first iteration of a `foreach` loop. An example is a paged fetch to load a batch of table rows. Another example is the <xref:System.IO.DirectoryInfo.EnumerateFiles%2A> method, which implements iterators within the .NET Framework.  
  
-   Encapsulate building the list in the iterator. In the iterator method, you can build the list and then yield each result in a loop.  
  
## See Also  
 <xref:System.Collections.Generic>  
 <xref:System.Collections.Generic.IEnumerable%601>  
 [foreach, in](../../../csharp/language-reference/keywords/foreach-in.md)  
 [yield](../../../csharp/language-reference/keywords/yield.md)  
 [Using foreach with Arrays](../../../csharp/programming-guide/arrays/using-foreach-with-arrays.md)  
 [Generics](../../../csharp/programming-guide/generics/index.md)
