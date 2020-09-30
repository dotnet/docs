---
title: "Object-Oriented Programming (C#)"
description: C# provides full support for object-oriented programming including abstraction, encapsulation, inheritance, and polymorphism.
ms.date: 09/16/2020
---
# Object-Oriented programming (C#)

C# provides full support for object-oriented programming including abstraction, encapsulation, inheritance, and polymorphism.

- *Abstraction* means hiding the unnecessary details from type consumers.
- *Encapsulation* means that a group of related properties, methods, and other members are treated as a single unit or object.
- *Inheritance* describes the ability to create new classes based on an existing class.
- *Polymorphism* means that you can have multiple classes that can be used interchangeably, even though each class implements the same properties or methods in different ways.

In the preceding tutorial, [introduction to classes](introduction-to-classes.md) you saw both *abstraction* and *encapsulation*. The `BankAccount` class provided an abstraction for the concept of a bank account. You could modify its implementation without affecting any of the code that used the `BankAccount` class. Both the `BankAccount` and `Transaction` classes provide encapsulation of the components needed to describe those concepts in code.

In this tutorial, you'll extend that application to make use of *inheritance* and *polymorphism* to add new features.

## Create different types of accounts

After building this program, you get requests to add features to it. It works great in the situation where there is only one kind of bank account, but needs change, and related account types are requested:

- An interest earning account that accrues at the end of each month.
- A line of credit that can have a negative balance, but when there is a balance, there's an interest charge each month.
- A pre-paid gift card account that starts with a single deposit, and only can be paid down. It can be re-filled once at the start of each month.

All of these different accounts are similar to `BankAccount` class defined in the earlier tutorial. You could copy that code, rename the classes, and make modifications. That would work in the short term, but it would be more work over time. Any changes would need to be replicated across all the affected classes.

Instead, you can create new bank account types that inherit methods and data from the `BankAccount` class created in the preceding tutorial. These new classes can extend the `BankAccount` class with the specific behavior needed for each type:

```csharp
public class InterestEarningAccount : BankAccount
{
}

public class LineOfCreditAccount : BankAccount
{
}

public class GiftCardAccount : BankAccount
{
}
```

Each of these classes *inherit* the shared behavior from their shared *base class*, the `BankAccount` class. You need to write the implementations for new and different functionality in each of the *derived classes*.  

It's a good practice to create each new class in a different source file. In [Visual Studio](https://visualstudio.com), you can right-click on the project, and select *add class* to add a new class in a new file. In [Visual Studio Code](https://code.visualstudio.com), select *file* then *new* to create a new source file. In either tool, name the file to match the class.

When you create the classes as shown in the preceding sample, you'll find that none of your derived classes compile. The `BankAccount` class declares one public constructor with the following signature:

```csharp
public BankAccount(string name, decimal initialBalance)
```

Each derived class must call a base class constructor from its own constructor. In many cases, you don't need to write code for this to work. If you don't write any constructors, the compiler generates a *parameterless constructor*. Any derived class generates a call to the base class's parameterless constructor. In this case, the doesn't generate a parameterless constructor for the `BankAccount` class because it has a constructor defined. In those cases, you must declare a constructor that can pass arguments to the base class constructor.  The following code shows the constructor for the `InterestEarningAccount`:

:::code language="csharp" source="./snippets/object-oriented-programming/InterestEarningAccount.cs" id="DerivedConstructor":::

The parameters to this new constructor match the type and names of the base class. You use the `: base()` syntax to indicate a call to a base class constructor. Some classes define multiple constructors, and this syntax enables you to pick which base class constructor you call. Once you've updated the constructors, you can develop the code for each of the derived classes. The requirements for the new classes can be stated as follows:

- An interest earning account:
  - Will get a credit of 2% of the month-ending-balance.
- A line of credit:
  - Can have a negative balance, but not be greater in absolute value than the credit limit.
  - Will incur an interest charge each month where the end of month balance is not 0.
- A gift card account:
  - Can be refilled with a specified amount once each month, on the last day of the month.

You can see that all three of these account types have an action that take places at the end of each month. However, each account type does different tasks. You use *polymorphism* to implement this code. You'll create a single `virtual` method in the `BankAccount` class:

:::code language="csharp" source="./snippets/object-oriented-programming/BankAccount.cs" id="DeclareMonthEndTransactions":::

The preceding code shows how you use the `virtual` keyword to declare a method in the base class that a derived class may provide a different implementation for. A `virtual` method is a method where any derived class may chose to re-implement. The derived classes use the `override` keyword to define the new implementation. Typically you refer to this as "overridng the base class implementation". You chose the `virtual` keyword and provide an empty implementation because you still want to use the basic `BankAccount` type for some bank accounts. The `BankAccount` class doesn't perform any actions at month end because no actions are needed. Often, creating a `virtual` function that has no implementation should make you consider an `abstract` method instead. If you didn't want to create instances of `BankAccount` objects, you could declare the `PerformMonthEndTransactions` method as `abstract`. You would make the `BankAccount` class `abstract` as well.

Next, you need to define the implementation for two of the new classes you've created. Start with the `InterestEarningAccount`:

:::code language="csharp" source="./snippets/object-oriented-programming/InterestEarningAccount.cs" id="ApplyMonthendInterest":::

Add the following code to the `LineOfCreditAccount`. The code negates the balance to compute a positive interest charge:

:::code language="csharp" source="./snippets/object-oriented-programming/LineOfCreditAccount.cs" id="ApplyMonthendInterest":::

The `GiftCardAccount` class needs two changes to implement its month-end functionality. First, modify the constructor to include an optional amount to add each month:

:::code language="csharp" source="./snippets/object-oriented-programming/GiftCardAccount.cs" id="GiftCardAccountConstruction":::

The constructor provides a default value for the `monthlyDeposit` value so callers don't need to provide one for zero. Next, override the `PerformMonthEndTransactions` method to add the monthly deposit, if it was set to a non-zero value in the constructor:

:::code language="csharp" source="./snippets/object-oriented-programming/GiftCardAccount.cs" id="AddMonthlyDeposit":::

The override applies the monthly deposit if it was set in the constructor.

Add the following code to the `Main` method to test these changes for the `GiftCardAccount` and the `InterestEarningAccount`:

:::code language="csharp" source="./snippets/object-oriented-programming/Program.cs" id="FirstTests":::

Those work fine. Now, add a similar set of test code for the `LineOfCreditAccount`:

:::code language="csharp" source="./snippets/object-oriented-programming/Program.cs" id="TestLineOfCredit":::

When you add the preceding code and run the program, you'll see something like the following error:

```console
Unhandled exception. System.ArgumentOutOfRangeException: Amount of deposit must be positive (Parameter 'amount')
   at OOProgramming.BankAccount.MakeDeposit(Decimal amount, DateTime date, String note) in BankAccount.cs:line 42
   at OOProgramming.BankAccount..ctor(String name, Decimal initialBalance) in BankAccount.cs:line 31
   at OOProgramming.LineOfCreditAccount..ctor(String name, Decimal initialBalance) in LineOfCreditAccount.cs:line 9
   at OOProgramming.Program.Main(String[] args) in Program.cs:line 29
```

> [!NOTE]
> The actual output includes the full path to the folder with the project. The folder names were omitted for brevity. Also, depending on your code format, the line numbers may be slightly different.

This code fails because the `BankAccount` assumes that the initial balance must be greater than 0. Another assumption baked into the `BankAccount` class is that the balance cannot go negative. Instead, any withdrawal that overdraws the account is rejected. Both of those assumptions need to change. The line of credit account starts at 0, and generally will have a negative balance. Also, if a customer borrows too much money, they incur a fee. The transaction is accepted, it just costs more. The first rule can be implemented by adding an optional argument to the `BankAccount` constructor that specifies the minimum balance. The default is `0`. The second rule requires a mechanism that enables derived classes to modify the default algorithm. In a sense, the base class "asks" the derived type what should happen when there's an overdraft. The default behavior is to reject the transaction by throwing an exception.

Let's start by adding a second constructor that includes an optional `minimumBalance` parameter. This new constructor performs all the actions performed by the existing constructor. In addition, it sets the minimum balance property. You could copy the body of the existing constructor. but that means two locations to change in the future. Instead, you can use *constructor chaining* to have one constructor call another. The following code shows the two constructors and the new additional field:

 :::code language="csharp" source="./snippets/object-oriented-programming/BankAccount.cs" id="ConstructorModifications":::

The preceding code shows two new techniques. First, the `minimumBalance` field is marked as `readonly`. That means the value cannot be changed after the object is constructed. Once a `BankAccount` is created, the `minimumBalance` cannot change. Second, the constructor that takes two parameters uses `: this(name, initialBalance, 0) { }` as its implementation. The `: this()` expression calls the other constructor, the one with three parameters. This technique allows you to have a single implementation for initializing an object even though client code can choose one of many constructors.

This implementation calls `MakeDeposit` only if the initial balance is greater than `0`. That preserves the rule that deposits must be positive, yet lets the credit account open with a `0` balance.

Now that the `BankAccount` class has a read-only field for the minimum balance, the final change is to change the hard code `0` to `minimumBalance` in the `MakeWithdrawal` method:

```csharp
if (Balance - amount < minimumBalance)
```

After extending the `BankAccount` class, you can modify the `LineOfCreditAccount` constructor to call the new base constructor, as shown in the following code:

:::code language="csharp" source="./snippets/object-oriented-programming/LineOfCreditAccount.cs" id="ConstructLineOfCredit":::

Notice that the `LineOfCreditAccount` constructor changes the sign of the `creditLimit` parameter so it matches the meaning of the `minimumBalance` parameter.

## Different overdraft rules

The last feature to add enables the `LineOfCreditAccount` to charge a fee for going over the credit limit instead of refusing the transaction.

One technique is to define a virtual function where you implement the desired behavior. The `Bank Account` class refactors the `MakeWithdrawal` method into two methods. The new method performs the specified action when the withdrawal takes the balance below the minimum. The existing `MakeWithdrawal` method has the following code:

```csharp
public void MakeWithdrawal(decimal amount, DateTime date, string note)
{
    if (amount <= 0)
    {
        throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
    }
    if (Balance - amount < minimumBalance)
    {
        throw new InvalidOperationException("Not sufficient funds for this withdrawal");
    }
    var withdrawal = new Transaction(-amount, date, note);
    allTransactions.Add(withdrawal);
}
```

Replace it with the following:

:::code language="csharp" source="./snippets/object-oriented-programming/BankAccount.cs" id="RefactoredMakeWithdrawal":::

The added method is `protected` which means that it can be called only from derived classes. That declaration prevents other clients from calling the method. It's also `virtual` so that derived classes can change the behavior. The return type is a `Transaction?`. The `?` annotation indicates that the method may return `null`. Add the following implementation in the `LineOfCreditAccount` to charge a fee when the withdrawal limit is exceeded:

:::code language="csharp" source="./snippets/object-oriented-programming/LineOfCreditAccount.cs" id="AddOverdraftFee":::

The override returns a fee transaction when the account is overdrawn. If the withdrawal doesn't go over the limit, the method returns a `null` transaction. That indicates there's no fee. Test these changes by adding the following code to your `Main` method in the `Program` class:

:::code language="csharp" source="./snippets/object-oriented-programming/Program.cs" id="TestLineOfCredit":::

Run the program, and check the results.

## Summary

This tutorial demonstrated many of the techniques used in Object Oriented programming:

- You used *Abstraction* when you kept many details `private` in each class.
- You used *Encapsulation* when you defined classes for each of the different account types. Those described the behavior for that type of account.
- You used *Inheritance* when you leveraged the implementation already created in the `BankAccount` class to save code.
- You used *Polymorphism* when you created `virtual` methods that derived classes could override to create specific behavior for that account type.

Congratulations, you've finished all our introduction to C# tutorials. If you're eager to learn more, try more of our [tutorials](../index.md).
