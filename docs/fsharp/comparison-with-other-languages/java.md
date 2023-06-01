---
title: Comparing F# with Java - Syntax Comparison
description: Learn about the similarities and differences between F# and Java in terms of syntax and coding examples.
ms.date: [Date]
---

# Hello world 🚀

Java

```java
public class Main {  
  public static void main(String\[\] args) {  
    System.out.println("Hello World");  
  }  
}
```

F#

Much shorter, now C# also has top-level statements and global using, so you could achieve a similar succinctness in C# (with some magic). But note this has always been the case for F#, nothing new or fancy.

```fsharp
printfn "Hello world"
```

# Static method 🏛

And here is how to define and use a static method in Java

```java
public class StringUtils {  
  
  public static String magic(String inputString){  
       return inputString.replace("magic","wow");  
  }  
}  
  
//usage in some other class/method..  
StringUtils.magic("this is magic!"); // prints \`this is wow!\`

```

In F#, a **static class** corresponds 1:1 to a **module**, and all of its methods will be public and static, unless you provide a module interface (advanced). F# also has **classes** for encapsulation in addition to modules, but in the case of an helper function, a module is just right.

```fsharp
module StringUtils  
  
    let magic inputString \=   
        inputString.Replace("magic", "wow")  
  
//usage in some other class/method...  
StringUtils.magic "this is magic!" // wrapping (...) is not required here
```

# Defining a DTO Class (~ POJO/Bean) 📎

Java (with [Lombok](https://projectlombok.org/features/))

```java
@Builder  
@Data  
public class Person {  
     private int age;  
     private String name;  
     private String surname;  
}
```

Or as an alternative again in Java, to have it immutable with copy mutation..

```java
@Value  
public class Person {  
   @With int age;  
   @With String name;  
   @With String surname;  
}
```

Yet, for the case without Lombok or “basic” Java, here we have a regular POJO: for a bean is a slightly different class, but you get the idea..

```java
public class Person {  
  
    private final int age;  
    private final String name;  
    private final String surname;  
  
    public int getAge(){ return age; }  
    public String getName(){ return name; }  
    public String getSurname(){ return surname; }  
      
    public Person(int age, String name, String surname) {  
        this.age = age;  
        this.name = name;  
        this.surname = surname;  
    }  
}
```

ps: here using the recent Java [Record](https://medium.com/@jkone27-3876/baeldung.com/java-record-keyword) feature,

[Sergiy Yevtushenko](https://medium.com/u/910badbeb75c?source=post_page-----d360d26dadbc--------------------------------)

, thanks for your comments:

```java
public record Person (int age, String name, String surname) {}
```

Here in F# as an immutable Record.

```fsharp
[<CLIMutable>] // can be useful for .NET interop, not required  
type Person = {   
   Age: Int  
   Name: String  
   Surname: String  
}
```

In F# [records](https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/records) come as actually **Value types** with **With** copy capabilities embedded in them, so that’s the default! They are **immutable** so they can be used both for DTOs but also for domain modeling.

Both C# and Java are **late Record adopters** following the ML-languages / immutability FP trend.

Note that ML languages always had records (even before having classes), for example they are present even in the relatively old [**standard ML**](https://en.wikibooks.org/wiki/Standard_ML_Programming/Types#Records).

[OCaml](https://dev.realworldocaml.org/classes.html) later introduced OO programming in ML, thus adding **classes**, but Records are still the main data construct for all ML languages.

Thus unlike C#/Java **in F# Records** are the **default** **way to model data**, not a “good” practice, this is why F# is often and rightly called a functional-**first** language.

Below another example in F#, using a regular **class** **type** with setters, though most of times the record version is preferred. Indeed you can use classes and they will be quite **succint** and **readeable** too!

```fsharp
type Person(age,name,surname) = // class   
    member val Age = age with get  
    member val Name = name with get  
    member val Surname = surname with set
```

# Creating an Object 🐼

Java

```java
Person john \= new Person(31,"john","kennedy");  
  
Person john \= Person.builder() // with lombok @Builder attribute  
                    .age(31)  
                    .name("john")    
                    .surname("kennedy")  
                    .build();
```

F#

```fsharp
let john = {   
        Age = 31  
        Name = "john"  
        Surname = "kennedy"   
    } // record  
  
let mary = new Person(31, "mary", "kennedy") // when using a class type
```

# Working with Streams 💦

Java (Stream)

```java
var x \= List.of(1,2,3)  
            .stream()  
            .filter(...)  
            .map(...);
```

in F#, the [**seq**](https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/sequences) module is an alias for the .NET [IEnumerable](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-7.0) interface. This means that standard [**L**](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/)**INQ** can be adopted as well. We also have a [List](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html) and an [Array](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html) module with similar functions.

```fsharp
let x =   
   \[1;2;3\]   
   |> Seq.filter (...)   
   |> Seq.map (...)
```

In F# the [**pipe**](https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/symbol-and-operator-reference/) **operator |>** makes working with data **elegant** and **beautiful!** plus it’s also functional and can be applied to virtually anything, e.g.  
The **beauty** of this approach, is that code “flows” from **top** to **bottom**, and from **left** to **right**, quite easilly and without occupying much brain space.