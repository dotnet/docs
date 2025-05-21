---
title: Functional programming vs. imperative programming - LINQ to XML
description: Learn about functional programming and how it differs from traditional imperative (procedural) programming.
ms.date: 07/20/2015
ms.assetid: 5e35c5a0-c949-422a-873b-fca6b2254f57
ms.topic: article
---

# Functional programming vs. imperative programming (LINQ to XML)

This article compares and contrasts functional programming with more traditional imperative (procedural) programming.

## Functional programming vs. imperative programming

The *functional programming* paradigm was explicitly created to support a pure functional approach to problem solving. Functional programming is a form of *declarative programming*. In contrast, most mainstream languages, including object-oriented programming (OOP) languages such as C#, Visual Basic, C++, and Java, were designed to primarily support *imperative* (procedural) programming.

With an imperative approach, a developer writes code that specifies the steps that the computer must take to accomplish the goal. This is sometimes referred to as *algorithmic* programming. In contrast, a functional approach involves composing the problem as a set of functions to be executed. You define carefully the input to each function, and what each function returns. The following table describes some of the general differences between these two approaches.

|Characteristic|Imperative approach|Functional approach|
|--------------------|-------------------------|-------------------------|
|Programmer focus|How to perform tasks (algorithms) and how to track changes in state.|What information is desired and what transformations are required.|
|State changes|Important.|Non-existent.|
|Order of execution|Important.|Low importance.|
|Primary flow control|Loops, conditionals, and function (method) calls.|Function calls, including recursion.|
|Primary manipulation unit|Instances of structures or classes.|Functions as first-class objects and data collections.|

Although most languages were designed to support a specific programming paradigm, many general languages are flexible enough to support multiple paradigms. For example, most languages that contain function pointers can be used to credibly support functional programming. Furthermore, C# and Visual Basic include explicit language extensions to support functional programming, including lambda expressions and type inference. LINQ technology is a form of declarative, functional programming.

## Functional programming using XSLT

Many XSLT developers are familiar with the pure functional approach. The most effective way to develop an XSLT style sheet is to treat each template as an isolated, composable transformation. The order of execution is completely de-emphasized. XSLT doesn't allow side effects (with the exception that escaping mechanisms for executing procedural code can introduce side effects that result in functional impurity). However, although XSLT is an effective tool, some of its characteristics aren't optimal. For example, expressing programming constructs in XML makes code relatively verbose, and therefore difficult to maintain. Also, the heavy reliance on recursion for flow control can result in code that's hard to read. For more information about XSLT, see [XSLT Transformations](../data/xml/xslt-transformations.md).

However, XSLT has proved the value of using a pure functional approach for transforming XML from one shape to another. Pure functional programming with LINQ to XML is similar in many ways to XSLT. However, the programming constructs introduced by LINQ to XML, C#, and Visual Basic allow you to write pure functional transformations that are more readable and maintainable than XSLT.

## Advantages of pure functions

The primary reason to implement functional transformations as pure functions is that pure functions are composable: that is, self-contained and stateless. These characteristics bring a number of benefits, including the following:

- Increased readability and maintainability. This is because each function is designed to accomplish a specific task given its arguments. The function doesn't rely on any external state.
- Easier reiterative development. Because the code is easier to refactor, changes to design are often easier to implement. For example, suppose you write a complicated transformation, and then realize that some code is repeated several times in the transformation. If you refactor through a pure method, you can call your pure method at will without worrying about side effects.
- Easier testing and debugging. Because pure functions can more easily be tested in isolation, you can write test code that calls the pure function with typical values, valid edge cases, and invalid edge cases.

For the reasons outlined above, functional programming is well-suited to the microservices architectural style.

## Transitioning for OOP developers

In traditional object-oriented programming (OOP), most developers are accustomed to programming in the imperative/procedural style. To switch to developing in a pure functional style, they have to make a transition in their thinking and their approach to development.

To solve problems, OOP developers design class hierarchies, focus on proper encapsulation, and think in terms of class contracts. The behavior and state of object types are paramount, and language features, such as classes, interfaces, inheritance, and polymorphism, are provided to address these concerns.

In contrast, functional programming approaches computational problems as an exercise in the evaluation of pure functional transformations of data collections. Functional programming avoids state and mutable data, and instead emphasizes the application of functions.

Fortunately, C# and Visual Basic don't require the full leap to functional programming, because they support both imperative and functional programming approaches. A developer can choose which approach is most appropriate for a particular scenario. In fact, programs often combine both approaches.

## See also

- [Introduction to pure functional transformations](introduction-pure-functional-transformations.md)
- [XSLT Transformations](../data/xml/xslt-transformations.md)
- [Refactor into pure functions](refactor-pure-functions.md)
