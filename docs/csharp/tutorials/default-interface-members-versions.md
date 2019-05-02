---
title: Safely update interfaces using default interface members in C#
description: This advanced tutorial explores how you can safely add new capabilities to existing interface definitions without breaking all classes and structs that implement that interface.
ms.date: 05/02/2019
ms.custom: mvc
---
# Tutorial: Learn how to use default interface members in C# 8 to safely update interface definitions to add functionality to all implementations

Beginning in C# 8 on .NET Core 3.0 you can define an implementation when you declare a member of an interface. The most common scenario is to safely add members to an interface already released and used by innumerable clients.

In this tutorial, you'll learn how to:

> [!div class="checklist"]
> * Create a data source that generates a sequence of data elements asynchronously.
> * Consume that data source asynchronously.
> * Recognize when the new interface and data source are preferred to earlier synchronous data sequences.

## Prerequisites

You’ll need to set up your machine to run .NET Core, including the C# 8.0 beta compiler. The C# 8 beta compiler is available starting with [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019), or the latest [.NET Core 3.0 preview SDK](https://dotnet.microsoft.com/download/dotnet-core/3.0). Async streams are first available in .NET Core 3.0 preview 3.

The starter application models an eCommerce library that defines interfaces that applications implement in the classes that implement their specific business needs. The unit test library exercises the core functionality with a reference implementation of these classes.

## Scenario overview

Now, it's time to upgrade his product for the next release. One of the features requested is to enable a loyalty discount for customers that have lots of orders. This new loyalty discount gets applied whenever a customer makes an order. The system should retrieve any loyalty discount from the customer as part of processing the order. Each implementation of ICustomer can set different rules for the loyalty discount. 

The most natural way to add this functionality is to enhance the `ICustomer` interface with a method to apply any loyalty discount. The problem with that plan is that it break all the existing customers' code. That's a bad experience for the very customers that would use the loyalty discount feature on its initial rollout. If this new functionality were added in the initial release, you would have added it to the ICustomer interface. Each implementation would set their business rules, expressed through the implementation of ICustomer.

## Upgrade with default interface members

If every implementation of ICustomer would use the same rules, you could create an extension method for this new feature. The requirements include letting each implementation set their own rules for loyalty discounts, so that design won't work. There is one implementation that is more likely: a loyalty discount that has a minimum number of orders to be eligible, and provides a constant 

The upgrade should provide the functionality to set two properties: the number of orders needed to be eligible for the discount, and the percentage of the discount. This makes it a perfect scenario for default interface members. You can add a method to the ICustomer interface, and provide the most likely implementation. All existing, and any new implementations can use the default implementation, or provide their own.

First, add the new method to the implementation:

```csharp
// code
```

That's a good start. But, the default implementation is too restrictive. Many consumers of this system may choose different thresholds for number of purchases, or a different percentage discount. You can provide a better upgrade experience for more customers by providing a way to set those parameters. Let's add a static method that sets those two parameters controlling the default implementation:

```csharp
// more code.
```

Now any customer whose loyalty program depends on those two constants can use this static method to set the parameters of the loyalty program.  Those customers that use different formulas for a loyalty program can still provide their own implementation. For example, here's a version that provides a loyalty discount for shopping on Monday:

```csharp
// code
```

These new features mean that interfaces can be updated safely when there is a reasonable default implementation for those new members. You should carefully design interfaces to express single functional ideas that can be implemented by multiple classes. That will make it easier to upgrade those interface definitions when new requirements are discovered for that same funtional idea.

