---
title: Classes and objects  - C# Fundamentals tutorial
description: Create your first C# program and explore object oriented concepts
ms.date: 05/14/2021
---
# Explore object oriented programming with classes and objects

In this tutorial, you'll build a console application and see the basic object-oriented features that are part of the C# language.

## Prerequisites

The tutorial expects that you have a machine set up for local development. On Windows, Linux, or macOS, you can use the .NET CLI to create, build, and run applications. On Windows, you can use Visual Studio 2019. For setup instructions, see [Set up your local environment](../../tour-of-csharp/tutorials/local-environment.md).

## Create your application

Using a terminal window, create a directory named *classes*. You'll build your application there. Change to that directory and type `dotnet new console` in the console window. This command creates your application. Open *Program.cs*. It should look like this:

```csharp
using System;

namespace classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
```

In this tutorial, you're going to create new types that represent a bank account. Typically developers define each class in a different text file. That makes it easier to manage as a program grows in size. Create a new file named *BankAccount.cs* in the *classes* directory.

This file will contain the definition of a ***bank account***. Object Oriented programming organizes code by creating types in the form of ***classes***. These classes contain the code that represents a specific entity. The `BankAccount` class represents a bank account. The code implements specific operations through methods and properties. In this tutorial, the bank account supports this behavior:

1. It has a 10-digit number that uniquely identifies the bank account.
1. It has a string that stores the name or names of the owners.
1. The balance can be retrieved.
1. It accepts deposits.
1. It accepts withdrawals.
1. The initial balance must be positive.
1. Withdrawals cannot result in a negative balance.

## Define the bank account type

You can start by creating the basics of a class that defines that behavior. Create a new file using the **File:New** command. Name it *BankAccount.cs*. Add the following code to your *BankAccount.cs* file:

```csharp
using System;

namespace classes
{
    public class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance { get; }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
        }
    }
}
```

Before going on, let's take a look at what you've built.  The `namespace` declaration provides a way to logically organize your code. This tutorial is relatively small, so you'll put all the code in one namespace.

`public class BankAccount` defines the class, or type, you are creating. Everything inside the `{` and `}` that follows the class declaration defines the state and behavior of the class. There are five ***members*** of the `BankAccount` class. The first three are ***properties***. Properties are data elements and can have code that enforces validation or other rules. The last two are ***methods***. Methods are blocks of code that perform a single function. Reading the names of each of the members should provide enough information for you or another developer to understand what the class does.

## Open a new account

The first feature to implement is to open a bank account. When a customer opens an account, they must supply an initial balance, and information about the owner or owners of that account.

Creating a new object of the `BankAccount` type means defining a ***constructor*** that assigns those values. A ***constructor*** is a member that has the same name as the class. It is used to initialize objects of that class type. Add the following constructor to the `BankAccount` type. Place the following code above the declaration of `MakeDeposit`:

```csharp
public BankAccount(string name, decimal initialBalance)
{
    this.Owner = name;
    this.Balance = initialBalance;
}
```

Constructors are called when you create an object using [`new`](../../language-reference/operators/new-operator.md). Replace the line `Console.WriteLine("Hello World!");` in *Program.cs* with the following code (replace `<name>` with your name):

```csharp
var account = new BankAccount("<name>", 1000);
Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");
```

Let's run what you've built so far. If you're using Visual Studio, Select **Start without debugging** from the **Debug** menu. If you're using a command line, type `dotnet run` in the directory where you've created your project.

Did you notice that the account number is blank? It's time to fix that. The account number should be assigned when the object is constructed. But it shouldn't be the responsibility of the caller to create it. The `BankAccount` class code should know how to assign new account numbers.  A simple way to do this is to start with a 10-digit number. Increment it when each new account is created. Finally, store the current account number when an object is constructed.

Add a member declaration to the `BankAccount` class. Place the following line of code after the opening brace `{` at the beginning of the `BankAccount` class:

```csharp
private static int accountNumberSeed = 1234567890;
```

This is a data member. It's `private`, which means it can only be accessed by code inside the `BankAccount` class. It's a way of separating the public responsibilities (like having an account number) from the private implementation (how account numbers are generated). It is also `static`, which means it is shared by all of the `BankAccount` objects. The value of a non-static variable is unique to each instance of the `BankAccount` object. Add the following two lines to the constructor to assign the account number. Place them after the line that says `this.Balance = initialBalance`:

```csharp
this.Number = accountNumberSeed.ToString();
accountNumberSeed++;
```

Type `dotnet run` to see the results.

## Create deposits and withdrawals

Your bank account class needs to accept deposits and withdrawals to work correctly. Let's implement deposits and withdrawals by creating a journal of every transaction for the account. That has a few advantages over simply updating the balance on each transaction. The history can be used to audit all transactions and manage daily balances. By computing the balance from the history of all transactions when needed, any errors in a single transaction that are fixed will be correctly reflected in the balance on the next computation.

Let's start by creating a new type to represent a transaction. This is a simple type that doesn't have any responsibilities. It needs a few properties. Create a new file named *Transaction.cs*. Add the following code to it:

:::code language="csharp" source="./snippets/introduction-to-classes/Transaction.cs":::

Now, let's add a <xref:System.Collections.Generic.List%601> of `Transaction` objects to the `BankAccount` class. Add the following declaration after the constructor in your *BankAccount.cs* file:

:::code language="csharp" source="./snippets/introduction-to-classes/BankAccount.cs" id="TransactionDeclaration":::

The <xref:System.Collections.Generic.List%601> class requires you to import a different namespace. Add the following at the beginning of *BankAccount.cs*:

```csharp
using System.Collections.Generic;
```

Now, let's correctly compute the `Balance`. The current balance can be found by summing the values of all transactions. As the code is currently, you can only get the initial balance of the account, so you'll have to update the `Balance` property. Replace the line `public decimal Balance { get; }` in *BankAccount.cs* with the following code:

:::code language="csharp" source="./snippets/introduction-to-classes/BankAccount.cs" id="BalanceComputation":::

This example shows an important aspect of ***properties***. You're now computing the balance when another programmer asks for the value. Your computation enumerates all transactions, and provides the sum as the current balance.

Next, implement the `MakeDeposit` and `MakeWithdrawal` methods. These methods will enforce the final two rules: that the initial balance must be positive, and that any withdrawal must not create a negative balance.

This introduces the concept of ***exceptions***. The standard way of indicating that a method cannot complete its work successfully is to throw an exception. The type of exception and the message associated with it describe the error. Here, the `MakeDeposit` method throws an exception if the amount of the deposit is not greater than 0. The `MakeWithdrawal` method throws an exception if the withdrawal amount is not greater than 0, or if applying the withdrawal results in a negative balance. Add the following code after the declaration of the `allTransactions` list:

:::code language="csharp" source="./snippets/introduction-to-classes/BankAccount.cs" id="DepositAndWithdrawal":::

The [`throw`](../../language-reference/keywords/throw.md) statement **throws** an exception. Execution of the current block ends, and control transfers to the first matching `catch` block found in the call stack. You'll add a `catch` block to test this code a little later on.

The constructor should get one change so that it adds an initial transaction, rather than updating the balance directly. Since you already wrote the `MakeDeposit` method, call it from your constructor. The finished constructor should look like this:

:::code language="csharp" source="./snippets/introduction-to-classes/BankAccount.cs" id="Constructor":::

<xref:System.DateTime.Now?displayProperty=nameWithType> is a property that returns the current date and time. Test this by adding a few deposits and withdrawals in your `Main` method, following the code that creates a new `BankAccount`:

```csharp
account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
Console.WriteLine(account.Balance);
account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
Console.WriteLine(account.Balance);
```

Next, test that you are catching error conditions by trying to create an account with a negative balance. Add the following code after the preceding code you just added:

```csharp
// Test that the initial balances must be positive.
BankAccount invalidAccount;
try
{
    invalidAccount = new BankAccount("invalid", -55);
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine("Exception caught creating account with negative balance");
    Console.WriteLine(e.ToString());
    return;
}
```

You use the [`try` and `catch` statements](../../language-reference/keywords/try-catch.md) to mark a block of code that may throw exceptions and to catch those errors that you expect. You can use the same technique to test the code that throws an exception for a negative balance. Add the following code at the end of your `Main` method:

```csharp
// Test for a negative balance.
try
{
    account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
}
catch (InvalidOperationException e)
{
    Console.WriteLine("Exception caught trying to overdraw");
    Console.WriteLine(e.ToString());
}
```

Save the file and type `dotnet run` to try it.

## Challenge - log all transactions

To finish this tutorial, you can write the `GetAccountHistory` method that creates a `string` for the transaction history. Add this method to the `BankAccount` type:

:::code language="csharp" source="./snippets/introduction-to-classes/BankAccount.cs" id="History":::

This uses the <xref:System.Text.StringBuilder> class to format a string that contains one line for each transaction. You've seen the string formatting code earlier in these tutorials. One new character is `\t`. That inserts a tab to format the output.

Add this line to test it in *Program.cs*:

```csharp
Console.WriteLine(account.GetAccountHistory());
```

Run your program to see the results.

## Next steps

If you got stuck, you can see the source for this tutorial [in our GitHub repo](https://github.com/dotnet/docs/tree/main/docs/csharp/fundamentals/tutorials/snippets/introduction-to-classes).

You can continue with the [object oriented programming](oop.md) tutorial.

You can learn more about these concepts in these articles:

- [If and else statement](../../language-reference/keywords/if-else.md)
- [Iteration statements](../../language-reference/statements/iteration-statements.md)
