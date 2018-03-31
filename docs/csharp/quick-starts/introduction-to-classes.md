---
title: Introduction to classes tutorial - C# local quickstarts
description: Create your first C# program and explore object oriented concepts
author: billwagner
ms.author: wiwagn
ms.date: 10/11/2017
ms.topic: get-started-article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.custom: mvc
---
# Introduction to classes

This quickstart expects that you have a machine you can use for development. The .NET topic [Get Started in 10 minutes](https://www.microsoft.com/net/core) has instructions for setting up your local development environment on Mac, PC or Linux. A quick overview of the commands you'll use is in the [introduction to the local quickstarts](local-environment.md) with links to more details.

## Create your application

Using a terminal window, create a directory named **classes**. You'll build your application there. Change to that directory and type `dotnet new console` in the console window. This command creates your application. Open **Program.cs**. It should look like this:

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

In this quickstart, you're going to create new types that represent a bank account. Typically developers define each class in a different text file. That makes it easier to manage as a program grows in size.  Create a new file named **BankAccount.cs** in the **classes** directory. 

This file will contain the definition of a ***bank account***. Object Oriented programming organizes code by creating types in the form of ***classes***. These classes contain the code that represents a specific entity. The `BankAccount` class represents a bank account. The code implements specific operations through methods and properties. In this quickstart, the bank account supports this behavior:

1. It has a 10-digit number that uniquely identifies the bank account.
1. It has a string that stores the name or names of the owners.
1. The balance can be retrieved.
1. It accepts deposits.
1. It accepts withdrawals.
1. The initial balance must be positive.
1. Withdrawals cannot result in a negative balance.

## Define the bank account type

You can start by creating the basics of a class that defines that behavior. It would look like this:

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

Before going on, let's take a look at what you've built.  The `namespace` declaration provides a way to logically organize your code. This quickstart is relatively small, so you'll put all the code in one namespace. 

`public class BankAccount` defines the class, or type, you are creating. Everything inside the `{` and `}` that follows the class declaration defines the behavior of the class. There are five ***members*** of the `BankAccount` class. The first three are ***properties***. Properties are data elements and can have code that enforces validation or other rules. The last two are ***methods***. Methods are blocks of code that peform a single function. Reading the names of each of the members should provide enough information for you or another developer to understand what the class does.

## Open a new account

The first feature to implement is to open a bank account. When a customer opens an account, they must supply an initial balance, and information about the owner or owners of that account. 

Creating a new object of the `BankAccount` type means defining a ***constructor*** that assigns those values. A ***constructor*** is a member that has the same name as the class. It is used to initialize objects of that class type. Add the following constructor to the `BankAccount` type:

```csharp
public BankAccount(string name, decimal initialBalance)
{
    this.Owner = name;
    this.Balance = initialBalance;
}
```

Constructors are called when you create an object using [`new`](../language-reference/keywords/new.md). Replace the line `Console.WriteLine("Hello World!");` in ***program.cs*** with the following line (replace `<name>` with your name):

```csharp
var account = new BankAccount("<name>", 1000);
Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");
```

Type `dotnet run` to see what happens.  

Did you notice that the account number is blank? It's time to fix that. The account number should be assigned when the object is constructed. But it shouldn't be the responsibility of the caller to create it. The `BankAccount` class code should know how to assign new account numbers.  A simple way to do this is to start with a 10-digit number. Increment it when each new account is created. Finally, store the current account number when an object is constructed.

Add the following member declaration to the `BankAccount` class:

```csharp
private static int accountNumberSeed = 1234567890;
```

This is a data member. It's `private`, which means it can only be accessed by code inside the `BankAccount` class. It's a way of separating the public responsibilities (like having an account number) from the private implementation (how account numbers are generated.) Add the following two lines to the constructor to assign the account number:

```csharp
this.Number = accountNumberSeed.ToString();
accountNumberSeed++;
```

Type `dotnet run` to see the results.

## Create deposits and withdrawals

Your bank account class needs to accept deposits and withdrawals to work correctly. Let's implement deposits and withdrawals by creating a journal of every transaction for the account. That has a few advantages over simply updating the balance on each transaction. The history can be used to audit all transactions and manage daily balances. By computing the balance from the history of all transactions when needed, any errors in a single transaction that are fixed will be correctly reflected in the balance on the next computation.

Let's start by creating a new type to represent a transaction. This is a simple type that doesn't have any responsibilities. It needs a few properties. Create a new file named ***Transaction.cs***. Add the following code to it:

[!code-csharp[Transaction](../../../samples/csharp/classes-quickstart/Transaction.cs "Transaction declaration")]

Now, let's add a <xref:System.Collections.Generic.List%601> of `Transaction` objects to the `BankAccount` class. Add the following declaration:

[!code-csharp[TransactionDecl](../../../samples/csharp/classes-quickstart/BankAccount.cs#TransactionDeclaration "Transaction declaration")]

The <xref:System.Collections.Generic.List%601> class requires you to import a different namespace. Add the following at the beginning of **BankAccount.cs**:

```csharp
using System.Collections.Generic;
```

Now, let's change how the `Balance` is reported.  It can be found by summing the values of all transactions. Modify the declaration of `Balance` in the `BankAccount` class to the following:

[!code-csharp[BalanceComputation](../../../samples/csharp/classes-quickstart/BankAccount.cs#BalanceComputation "Computing the balance")]

This example shows an important aspect of ***properties***. You're now computing the balance when another programmer asks for the value. Your computation enumerates all transactions, and provides the sum as the current balance.

Next, implement the `MakeDeposit` and `MakeWithdrawal` methods. These methods will enforce the final two rules: that the initial balance must be positive, and that any withdrawal must not create a negative balance. 

This introduces the concept of ***exceptions***. The standard way of indicating that a method cannot complete its work successfully is to throw an exception. The type of exception and the message associated with it describe the error. Here, the `MakeDeposit` method throws an exception if the amount of the deposit is negative. The `MakeWithdrawal` method throws an exception if the withdrawal amount is negative, or if applying the withdrawal results in a negative balance:

[!code-csharp[DepositAndWithdrawal](../../../samples/csharp/classes-quickstart/BankAccount.cs#DepositAndWithdrawal "Make deposits and withdrawals")]

The [`throw`](../language-reference/keywords/throw.md) statement **throws** an exception. Execution of the current method ends, and will resume when a matching `catch` block is found. You'll add a `catch` block to test this code a little later on.

The constructor should get one change so that it adds an initial transaction, rather than updating the balance directly. Since you already wrote the `MakeDeposit` method, call it from your constructor. The finished constructor should look like this:

[!code-csharp[Constructor](../../../samples/csharp/classes-quickstart/BankAccount.cs#Constructor "The final version of the constructor")]

<xref:System.DateTime.Now?displayProperty=nameWithType> is a property that returns the current date and time. Test this by adding a few deposits and withdrawals in your `Main` method:

```csharp
account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
Console.WriteLine(account.Balance);
account.MakeDeposit(100, DateTime.Now, "friend paid me back");
Console.WriteLine(account.Balance);
```

Next, test that you are catching error conditions by trying to create an account with a negative balance:

```csharp
// Test that the initial balances must be positive:
try
{
    var invalidAccount = new BankAccount("invalid", -55);
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine("Exception caught creating account with negative balance");
    Console.WriteLine(e.ToString());
}
```

You use the [`try` and `catch` statements](../language-reference/keywords/try-catch.md) to mark a block of code that may throw exceptions, and to catch those errors that you expect. You can use the same technique to test the code that throws for a negative balance:

```csharp
// Test for a negative balance
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

To finish this quickstart, you can write the `GetAccountHistory` method that creates a `string` for the transaction history. add this method to the `BankAccount` type:

[!code-csharp[History](../../../samples/csharp/classes-quickstart/BankAccount.cs#History "Display transaction history")]

This uses the <xref:System.Text.StringBuilder> class to format a string that contains one line for each transaction. You've seen the string formatting code earlier in these quickstarts. One new character is `\t`. That inserts a tab to format the output.

Add this line to test it in **Program.cs**:

```csharp
Console.WriteLine(account.GetAccountHistory());
```

Type `dotnet run` to see the results.

## Next Steps

If you got stuck, you can see the source for this quickstart [in our GitHub repo](https://github.com/dotnet/samples/tree/master/csharp/classes-quickstart/)

Congratulations, you've finished all our Quickstarts. If you're eager to learn more, try our [tutorials](../tutorials/index.md)
