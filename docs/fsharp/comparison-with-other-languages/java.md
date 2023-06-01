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

# Dependency Injection 📩

Spring has quite smooth **registration** **annotations** that makes the process of registering a dependency quite nice and neat. One divergent note is that in spring “interfaces” are not really used that much, so registration happens direcly on the **concrete** **class** and in unit tests concrete classes are mocked by mockito framework.

```java
@Component
@RequiredArgsConstructor
public class FulfillmentService {        
    private final OrderClient orderClient;    
    private final ProductClient productClient;
}
```

in .NET on the other hand it’s common sense to **register** dependencies as **interfaces** to reduce coupling and also because usually mocking frameworks like **Moq** don’t allow you to mock concrete classes, so that makes the dependency inversion principle apply in a slightly more explicit way in .NET.

This how we would **register a dependency in .NET** (both in C# or F#) in this case for a web application builder (but would work also for a normal application builder).

```fsharp
let builder = WebApplication.CreateBuilder(args)

builder.Services.AddTransient<IMyDependency,MyDependency>() 
|> ignore

let app = builder.Build()app.Run()
```

And this is how you would consume that dependency via **constructor** **injection**, or via DI resolution: service “locator” pattern kind of flavor, not shown here..

```fsharp
type SomeService(myDependency: IMyDependency) =      
// ... service body using myDependency (constructor injection)
```

In F# **functional** **dependency** **injection** can also be used, using [**partial** **application**](https://fsharpforfunandprofit.com/posts/partial-application/) and higher order functions. In C# this would require tons of `Func<Func<…>>` code, not sure about Java, but I am quite confident that it would look ugly if even possible. Best to keep this approach to F# code.

All F#/ML functions can be **partially** applied: **one argument** **at a time** can be passed instead of all required arguments, making injection a natural skill. A function requiring any dependency can be partially applied to any number of arguments, before applying additional arguments required for the final invocation, for example:

```fsharp
let dispatchOrder orderClient productClient orderNumber = () 
// ... SOME IMPLEMENTATION

let app = dispatchOrder orderClient productClient

// final invocation
app "ORDER-001"

let test = dispatchOrder orderClientMock productClientMock

// test invocation
test "ORDER-001"
```

# Service (or Component) 🚚

Java

Here we see an example with **Springboot DI** and **Lombok** annotations, and the **reactive** **concurrent** model of Spring **webflux**. Sadly async/await model for concurrency is not yet supported in Java, if not with some extension libraries like [EA async](https://github.com/electronicarts/ea-async), which though is not mantained anymore. The reactive model has both **benefits** and **drawbacks** for concurrency modeling in my view, it **abstracts away the concurrency at “scheduler” level**, but can also make code harder to read and compose: why? there is a pletora of non super easy abstractions for observable composition and ingestion, so the **API of the reactive model is quite wide** an not easy to learn.

```java
@Component@RequiredArgsConstructorpublic class FulfillmentService {        private final OrderClient orderClient;    private final ProductClient productClient;    private bool isFinalizedOrder(OrderDto order) {        return order.Status == OrderStatus.Finalized;    }    public Flux<OrderDto> getFinalizedOrders() {            return orderClient                .getOrders()                .filter(isFinalizedOrder);    }    public Flux<ProductDto> getProductsForOrder(String orderNumber) {            return orderClient                .getOrder(orderNumber)                .flatMap(o -> o.productIds)                .map(id -> productClient.getProduct(id));    }}
```

.NET languages support [reactive programming via RX.NET package](http://introtorx.com/Content/v1.0.10621.0/01_WhyRx.html), but this approach is **not** the most common in the .net web programming world, though maybe **could feel easier for Java devs**, or if they wanted to migrate a codebase “almost as-is”, even though async/await does seem easier for everyone I think.

Anyways as a nice side note [F# natively supports Observables](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-observablemodule.html) from event and other sources (even without RX library). Hereafter we see F# **Reactive** style, hipster hat on… I must admit async/await synthax is a bit terser than rx after trying both worlds.

```fsharp
type FulfillmentService(orderClient, productClient) =    let isFinalizedOrder order =         order.Status = OrderStatus.Finalized    member this.GetFinalizedOrdersObservable(orderNumber) =         orderClient.getAllOrdersAsync          |> Observable.FromAsync          |> Observable.flatmapSeq (fun o -> o)          |> Observable.filter isFinalizedOrder    member this.GetProductsFromOrderObservable(orderNumber) =         (orderClient.getOrderAsync orderNumber)            |> Observable.FromAsync            |> Observable.flatmapSeq(fun o -> o.ProductIds)            |> Observable.flatmapTask productClient.getProductAsync
```

F# and .NET in general can make use of **async/await as well** using [Task builder CE](https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/task-expressions)… in F# a regular .NET async (Task) is expressed using the **task** computation expression and an await is expressed using the **bang operator !** within the expression (within the curly braces). It’s worth noting that **F# already had async** computatons way long before C# and many other languages, [**since** version 1.0](https://fsharp.org/history/hopl-final/hopl-fsharp.pdf) actually in **2007**.

**Curly braces** in F# are used only for [**CEs**](https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/computation-expressions) , as opposed to indentation that is adopted for variable scoping (like python and ruby)

```fsharp
type FulfillmentService(orderClient, productClient) =    let isFinalizedOrder order =         order.Status = OrderStatus.Finalized    member this.GetFinalizedOrdersAsync() =         task {             let! orders = orderClient.GetOrdersAsync()                           return orders |> Seq.filter isFinalizedOrder         }    member this.GetProductsFromOrder(orderNumber) =         task {             let! order = orderClient.GetOrderAsync(orderNumber)                          let! products =                   order.ProductIds                  |> Seq.map productClient.GetProductAsync                  |> Task.WhenAll             return products         }
```

F# supports **async** **await** **as well as reactive pipelines**, so we can chose whatever we fancy the most, wheras java doesn’t have yet async/await support. In general async/await is a bit **simpler** to understand and to use with pleasure.

# Inheritance VS Union types 🐲

Both **Java** and **C#** (as well as Kotlin) do **not\*** support union types - except maybe recent version of Java, see later for a comment on Java sealed types - but mostly plain **inheritance**, so I will start with some Java inheritance example

```java
//Animal
public class Animal { 
// abstract animal interface     
void eat();     
void sleep();     
String getName(); }

//Dog 
@RequiredArgsConstructor
public class Dog implements Animal {     
@Override     public void eat() {...}     @Override     public void sleep() {...}      @Getter     private final String name;
}

//Cat
@RequiredArgsConstructor
public class Cat implements Animal {     
@Override     public void eat() {...}     @Override     public void sleep() {...}      @Getter     private final String name;
}
```

Now imagine having a **realistic situation** baring more **complexity**, having **10–100** animal **classes** or maybe more, and potentially more levels of inheritance. Ok, multiple inheritance should be avoided to favour object composition according to “good design principles”, but not all of us are “good” developers unfortunately. Unless strictly prevented by some external tool, an exponential complexity explosion is likely to happen.

Here is how a more complex scenario could look like in UML.

![](https://miro.medium.com/v2/resize:fit:1400/1*jENVQeblni71ebJlan3PwA.png)

UML class hierarchy diagram, [source](https://www.researchgate.net/figure/Class-diagram-Animal-1_fig1_263655486)

OO Developers need to resort to **external tools** such as **UML** to **visualize** the whole **type hierarchy.** This is to be able to understand a **complex domain** and make things “easier” while changing or refactoring classes, or looking at changing requirements or for simple **documentation** purposes.

**F# Union Types to the rescue!** With union (or sum) types and product types (record or tuples..) we can create a **beautiful, compact**, **self-documenting type hierarchy** in very little lines of code!

Easier documentation and decreased maintenance!

```fsharp
module Animals   

type Animal =       
    | Dog of name:string      
    | Cat of name:string    
    
let eat animal =      
    match animal with      
    | Cat -> ...      
    | Dog -> ...    

let sleep animal =      
    match animal with      
    | Cat -> ...      
    | Dog -> ...
```

We can **encapsulate** and separate **data** from **functions** in the same domain using **modules.**

PS: recently a similar concept of [**Sealed Classes**](https://www.infoq.com/articles/java-sealed-classes/) have been added to **Java**, which also models in a similar way the idea of union ADT, even though from what I can tell they are not much in use yet, thanks

[Sergiy Yevtushenko](https://medium.com/u/910badbeb75c?source=post_page-----d360d26dadbc--------------------------------)

for spotting this! Seems **atm is not yet possible to have compiler checks** in Java on required cases for matching though, but possibly this will be introduced [in future versions of Java](https://www.baeldung.com/java-sealed-classes-interfaces).

In future versions of Java, the client code will be able to use a _switch_ statement instead of i_f-else_ ([JEP 375](https://openjdk.java.net/jeps/375)).

By using [type test patterns](https://openjdk.java.net/jeps/8213076), the compiler will be able to check that every permitted subclass is covered. Thus, there will be no more need for a _default_ clause/case.

# Testing

**F#** unlike many other languages lets you **name things the way you like**, how so? Using **double back-ticks**, test names can actually be decent again!

```fsharp
open XUnit // similar to JUnit...

[<Fact>]let ``GIVEN i have dotnet-sdk WHEN i try F# THEN i might give it a go!`` () =    
    Assert.True()
```

There would be much more to cover on testing, but this is not the main topic here.