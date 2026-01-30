---
title: "Design patterns in C#"
description: Provides an overview of common design patterns and their use in C# applications.
ms.date: 01/30/2026
helpviewer_keywords: 
  - "design patterns [C#]"
  - "creational patterns"
  - "structural patterns"
  - "behavioral patterns"
  - "software design"
  - "object-oriented design"
  - "C# architecture"
---

# Overview of design patterns in C#

Design patterns are proven solutions to recurring problems in software design. Rather than providing finished code, a design pattern offers a general template that can be adapted to solve a particular design problem in a given context.

In C#, design patterns are commonly used to improve code readability, maintainability, testability, and extensibility. They are especially valuable in large applications where change is expected over time.

This article provides a high-level overview of the most commonly used design patterns and their purpose.

## What is a design pattern

A *design pattern* describes:

- A common problem in software design  
- The context in which the problem occurs  
- A reusable solution structure  
- The consequences and trade-offs of using that solution  

Design patterns do not depend on a specific programming language, but their implementation can vary depending on language features. C# provides strong support for design patterns through interfaces, inheritance, delegates, generics, and dependency injection.

## Categories of design patterns

Design patterns are traditionally grouped into three main categories.

### Creational patterns

Creational patterns focus on *object creation mechanisms*. They help control how and when objects are created, reducing tight coupling between code components.

Common creational patterns include:

- Factory Method
- Abstract Factory
- Builder
- Singleton
- Prototype

These patterns are often used when object creation involves complex logic or when the exact type of object should be determined at runtime.

## Structural patterns

Structural patterns deal with *object composition*. They help define how classes and objects are combined to form larger structures while keeping the system flexible.

Common structural patterns include:

- Adapter
- Bridge
- Composite
- Decorator
- Facade
- Flyweight
- Proxy

These patterns are useful when integrating legacy code, adding behavior dynamically, or simplifying complex subsystems.

## Behavioral patterns

Behavioral patterns focus on *communication and responsibility* between objects.

Common behavioral patterns include:

- Strategy
- Observer
- Command
- Iterator
- Mediator
- State
- Template Method
- Chain of Responsibility

These patterns help reduce coupling by defining clear interaction rules between components.

## Benefits of using design patterns

Using design patterns can provide several advantages:

- Improved code readability and structure
- Reduced coupling between components
- Better separation of concerns
- Easier testing and mocking
- Improved long-term maintainability

Design patterns also make code easier to understand for other developers, as many patterns are widely recognized across the software industry.

## Design patterns and SOLID principles

Design patterns often work hand-in-hand with the SOLID principles:

- **Single Responsibility Principle** encourages small, focused classes
- **Open/Closed Principle** promotes extension without modification
- **Liskov Substitution Principle** ensures safe polymorphism
- **Interface Segregation Principle** avoids large, monolithic interfaces
- **Dependency Inversion Principle** encourages abstraction over concretion

Many patterns, such as Strategy, Factory Method, and Dependency Injection, naturally support these principles.

## When not to use design patterns

Design patterns should not be applied automatically. Overusing patterns can lead to unnecessary complexity.

Avoid design patterns when:

- The problem is simple
- The solution is unlikely to change
- The added abstraction provides no clear benefit

Patterns should solve real problems, not be used for their own sake.

## Design patterns in modern C#

Modern C# features simplify many pattern implementations:

- Records reduce boilerplate for immutable objects
- Dependency injection is built into ASP.NET Core
- Delegates and lambdas simplify behavioral patterns
- Pattern matching improves readability
- Minimal APIs reduce structural overhead

These features often replace or simplify classic implementations found in older examples.

## Next steps

The following articles in this series describe individual design patterns with practical C# examples:

- Creational patterns
- Structural patterns
- Behavioral patterns

Each article explains when to use the pattern, how it works, and its advantages and disadvantages.

## C# Language Specification  

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]