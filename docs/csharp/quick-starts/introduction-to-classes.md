---
title: Quick Starts - Introduction to Classes - C# Guide
description: Create your first C# program and explore object oriented concepts
keywords: C#, Get Started, Lessons, Classes, Object Oriented Programming
author: billwagner
ms.author: wiwagn
ms.date: 10/11/2017
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
---
# Introduction to classes

This lesson assumes installed [.NET Core](http://dot.net/core) and [Visual Studio Code](https://code.visualstudio.com/), or [Visual Studio](https://www.visualstudio.com/) on Mac or Windows.

## Create your application

Create a directory named **classes**. You'll build your application tehre. Change to that directory and type `dotnet new console`. This command creates your application. Open **Program.cs**. It should look like this:

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

In this quick start, you're going to create new types that represent a bank account. Typically developers define each class in a different text file. That makes it easier to manage as a program grows in size.  Create a new file named **BankAccount.cs** in the **classes** directory. 

This file will contain the deefinition of a ***bank account***. Object Oriented programming organizes code by creating types in the form of ***classes***. These classes contain the code that represent a concept. The `BankAccount` class represents the responsibilities and properties of a bank account. In this quick start, the bank account supports this behavior:

1. It has a 10-digit number that uniquely identifies the bank account.
1. It has a string that stores the name or names of the owners.
1. The balance can be retrieved.
1. It accepts deposits.
1. It accepts withdrawals.

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

        public void MakeWithdrawal(decimal amount, DateTime date, string payee, string note)
        {
        }
    }
}
```

Before going on, let's take a look at what you've built.  The `namespace` declaration provides a way to logically organize your code. This quick start is relatively small, so you'll put all the code in one namespace. 

The `public class BankAccount` defines the class, or type, you are creating. Everything inside the `{` and `}` that follows the class declaration defines the behavior of the class. There are five ***members*** of the `BankAccount` class. The first three are ***properties***. Properties are data elements, but can have code that enforces validation or other rules. The last two are ***methods***. Methods are blocks of code that peform a single function. Reading the names of each of the members should provide enough information for you or another developer to understand what the class does.

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

Constructors are called when you create an object using `new`. Replace the line `Console.WriteLine("Hello World!");` in ***program.cs*** with the following line (replace `<name>` with your name):

```csharp
var account = new BankAccount("<name", 1000);
Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance".);
```

Type `dotnet run` to see what happens.  

Did you notice that the account number is blank? It's time to fix that. The account number should be assigned when the object is constructed. But, it shouldn't be the responsibility of the caller to create that. The `BankAccount` class code should know how to assign new account numbers.  A simple way to do this is to start with a 10-digit number. Increment it when each new account is created. Finally, store the current account number when an object is constructed.

Add the following member declaration to the `BankAccount` class:

```csharp
private static int accountNumberSeed = 1234567890;
```

This is data member. It's `private`, which means it can only be accessed by code inside the `BankAccount` class. It's a way of separating the public responsibilities (like having an account number) from the private implementation (how account numbers are generated.) Add the following two lines to the constructor to assign the account number:

```csharp
this.Number = accountNumberSeed.ToString();
accountNumberSeed++;
```

Type `dotnet run` to see the results.

## Create deposits and withdrawals

Your bank account class needs to accept deposits and withdrawals to work correctly. Let's implement deposits and withdrawals by creating a journal of every transaction for the account. That has a few advantages or simply updating the balance on each transaction. The history can be used to audit all transactions and manage daily balances. 

Let's start by creating a new type to represent a transaction. This is a simple type that doesn't have any responsibilities. It needs a few properties. Create a new file named ***Transaction.cs***. Add the following code to it:

[!code-csharp[Transaction](../../../samples/csharp/quick-start-classes/Transaction.cs "Transaction declaration")]

Now, let's add a <xref:System.Collections.Generic.List%601> of `Transaction` objects to the `BankAccount` class. Add the following declaration:

[!code-csharp[TransactionDecl](../../../samples/csharp/quick-start-classes/BankAccount.c#TransactionDeclaration "Transaction declaration")]

The <xref:System.Collections.Generic.List%601> class requires you to import a different namespace. Add the following at the beginning of **BankAccount.cs**:

```csharp
using System.Collections.Generic;
```

Now, let's change how the `Balance` is reported.  It can be found by summing the values of all transactions. Modify the declaration of `Balance` in the `BankAccount` class to the following:

[!code-csharp[BalanceComputation](../../../samples/csharp/quick-start-classes/BankAccount.c#BalanceComputatiom "Computing the balance")]

This example shows an important aspect of ***properties***. You're now computing the balance when another programmer asks for the value. Your computation enumerates all transactions, and provides the sum as the current balance.

Next implement the `MakeDeposit` and `MakeWithdrawal` methods:

[!code-csharp[DepositAndWithdrawal](../../../samples/csharp/quick-start-classes/BankAccount.c#DepositAndWithdrawal "Make deposits and withdrawals")]

The constructor should get one change so that it adds an initial transaction, rather than updating the balance directly. Since you already wrote the `MakeDeposit` method, call it from your constructor. The finished constructor should look like this:

[!code-csharp[Constructor](../../../samples/csharp/quick-start-classes/BankAccount.c#Constructor "The final version of the constructor")]

The <xref:System.DateTime.Now> is a property that returns the current date and time. Test this by adding a few deposits and withdrawals in your `Main` method:

```csharp
account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
Console.WriteLine(account.Balance);
account.MakeDeposit(100, DateTime.Now, "friend paid me back");
Console.WriteLine(account.Balance);
```

## Challege - log all transactions

To finish this quick start, you can write the method that creates a `string` for the transaction history. add this method to the `BankAccount` type:

[!code-csharp[DepositAndWithdrawal](../../../samples/csharp/quick-start-classes/BankAccount.c#DepositAndWithdrawal "Make deposits and withdrawals")]

This uses the <xref:System.Text.StringBuilder> class to format a string that contains one line for each transaction. You've seen the string formatting code earlier in these quick starts. One new character is `\t`. That inserts a tab to format the output a little nicer.

Add this line to test it in **Program.cs**:

```csharp
Console.WriteLine(account.GetAccountHistory());
```

Type `dotnet run` to see the results.

## Next Steps

If you got stuck, you can see the source for this quick start [in our GitHub repo](https://github.com/dotnet/docs/tree/master/samples/csharp/classes-quickstart/)

Congratulations, you've finished all our Quick Starts.If you're eager to learn more, try our [tutorials](../tutorials/)