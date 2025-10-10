---
title: Generate XML documentation from your source code
description: "Learn to add `///` comments that generate XML documentation directly from your source code. Learn which tags are available and how to add documentation blocks to types and members."
ms.topic: tutorial  #Don't change.
ms.date: 10/10/2025

#customer intent: As a developer, I want to generate XML dcoumentation comments so that other developers can use my code successfully.

---


# Tutorial: Create XML documentation

[Introduce and explain the purpose of the article.]

<!-- Required: Introductory paragraphs (no heading)

Write a brief introduction that can help the user 
decide whether the article is relevant for them and
to describe how reading the article might benefit
them.

-->

In this tutorial, you:

> [!div class="checklist"]
> * [Tell the user what they'll do in the tutorial]
> * [Each of these bullet points align with a key H2]
> * [Use these green checkmarks]

<!-- Required: Outline (no heading)

Before your first H2, use the green checkmark format
for a bulleted list that outlines what you'll cover 
in the tutorial.

-->

If you don't have a service subscription, create a free
trial account . . .

<!-- Required: Free account links (no heading)

Because quickstarts are intended to help new customers
evaluate a product or service, include a link to a 
free trial before the first H2 or in the prerequisites.

-->

## Prerequisites

<!-- Optional: Prerequisites - H2

If included, "Prerequisites" must be the first H2 in the article.

Include any items that are needed for the tutorial,
such as permissions or software.

If you need to sign in to a portal to do the tutorial, 
provide instructions and a link.

-->

Outline and steps:

1. Enable XML documentation
   ```xml
   <GenerateDocumentationFile>True</GenerateDocumentationFile>
   ```
1. Do a build. Note warnings for publicly visible members without docs. Just for fun, open the XML file:
   ```xml
   <?xml version="1.0"?>
   <doc>
       <assembly>
           <name>oo-programming</name>
       </assembly>
       <members>
       </members>
   </doc>
   ```
1. Click on the first number. Type `///` to generate a blank summary. Fill it in. This should be the `BankAccount`. Walk through one example of each type: class, property, amd method. Reader can to others themselves.
1. Build. Look at the XML file now.
```xml
<?xml version="1.0"?>
<doc>
    <assembly>
        <name>oo-programming</name>
    </assembly>
    <members>
        <member name="T:OOProgramming.BankAccount">
            <summary>
            Represents a bank account with basic banking operations including deposits, withdrawals, and transaction history.
            Supports minimum balance constraints and provides extensible month-end processing capabilities.
            </summary>
        </member>
        <member name="P:OOProgramming.BankAccount.Number">
            <summary>
            Gets the unique account number for this bank account.
            </summary>
            <value>A string representation of the account number, generated sequentially.</value>
        </member>
        <member name="P:OOProgramming.BankAccount.Owner">
            <summary>
            Gets or sets the name of the account owner.
            </summary>
            <value>The full name of the person who owns this account.</value>
        </member>
        <member name="P:OOProgramming.BankAccount.Balance">
            <summary>
            Gets the current balance of the account by calculating the sum of all transactions.
            </summary>
            <value>The current account balance as a decimal value.</value>
        </member>
        <member name="M:OOProgramming.BankAccount.#ctor(System.String,System.Decimal)">
            <summary>
            Initializes a new instance of the BankAccount class with the specified owner name and initial balance.
            Uses a default minimum balance of 0.
            </summary>
            <param name="name">The name of the account owner.</param>
            <param name="initialBalance">The initial deposit amount for the account.</param>
            <remarks>
            This constructor is a convenience overload that calls the main constructor with a minimum balance of 0.
            If the initial balance is greater than 0, it will be recorded as the first transaction with the note "Initial balance".
            The account number is automatically generated using a static seed value that increments for each new account.
            </remarks>
        </member>
        <member name="M:OOProgramming.BankAccount.#ctor(System.String,System.Decimal,System.Decimal)">
            <summary>
            Initializes a new instance of the BankAccount class with the specified owner name, initial balance, and minimum balance constraint.
            </summary>
            <param name="name">The name of the account owner.</param>
            <param name="initialBalance">The initial deposit amount for the account.</param>
            <param name="minimumBalance">The minimum balance that must be maintained in the account.</param>
            <remarks>
            This is the primary constructor that sets up all account properties. The account number is generated automatically
            using a static seed value. If an initial balance is provided and is greater than 0, it will be added as the first
            transaction. The minimum balance constraint will be enforced on all future withdrawal operations through the
            <see cref="M:OOProgramming.BankAccount.CheckWithdrawalLimit(System.Boolean)"/> method.
            </remarks>
        </member>
        <member name="M:OOProgramming.BankAccount.MakeDeposit(System.Decimal,System.DateTime,System.String)">
            <summary>
            Makes a deposit to the account by adding a positive transaction.
            </summary>
            <param name="amount">The amount to deposit. Must be positive.</param>
            <param name="date">The date when the deposit is made.</param>
            <param name="note">A descriptive note about the deposit transaction.</param>
            <exception cref="T:System.ArgumentOutOfRangeException">Thrown when the deposit amount is zero or negative.</exception>
            <remarks>
            This method creates a new <see cref="T:OOProgramming.Transaction"/> object with the specified amount, date, and note,
            then adds it to the internal transaction list. The transaction amount must be positive - negative amounts
            are not allowed for deposits. The account balance is automatically updated through the Balance property
            which calculates the sum of all transactions. There are no limits or restrictions on deposit amounts.
            </remarks>
        </member>
        <member name="M:OOProgramming.BankAccount.MakeWithdrawal(System.Decimal,System.DateTime,System.String)">
            <summary>
            Makes a withdrawal from the account by adding a negative transaction.
            Checks withdrawal limits and minimum balance constraints before processing.
            </summary>
            <param name="amount">The amount to withdraw. Must be positive.</param>
            <param name="date">The date when the withdrawal is made.</param>
            <param name="note">A descriptive note about the withdrawal transaction.</param>
            <exception cref="T:System.ArgumentOutOfRangeException">Thrown when the withdrawal amount is zero or negative.</exception>
            <exception cref="T:System.InvalidOperationException">Thrown when the withdrawal would cause the balance to fall below the minimum balance.</exception>
            <remarks>
            This method first validates that the withdrawal amount is positive, then checks if the withdrawal would
            violate the minimum balance constraint by calling <see cref="M:OOProgramming.BankAccount.CheckWithdrawalLimit(System.Boolean)"/>. The withdrawal is
            recorded as a negative transaction amount. If the withdrawal limit check returns an overdraft transaction
            (such as a fee), that transaction is also added to the account. The method enforces business rules through
            the virtual CheckWithdrawalLimit method, allowing derived classes to implement different withdrawal policies.
            </remarks>
        </member>
        <member name="M:OOProgramming.BankAccount.CheckWithdrawalLimit(System.Boolean)">
            <summary>
            Checks whether a withdrawal would violate the account's minimum balance constraint.
            This method can be overridden in derived classes to implement different withdrawal limit policies.
            </summary>
            <param name="isOverdrawn">True if the withdrawal would cause the balance to fall below the minimum balance.</param>
            <returns>A Transaction object representing any overdraft fees or penalties, or null if no additional charges apply.</returns>
            <exception cref="T:System.InvalidOperationException">Thrown when the withdrawal would cause an overdraft and the account type doesn't allow it.</exception>
        </member>
        <member name="M:OOProgramming.BankAccount.GetAccountHistory">
            <summary>
            Generates a detailed account history report showing all transactions with running balance calculations.
            </summary>
            <returns>A formatted string containing the complete transaction history with dates, amounts, running balances, and notes.</returns>
            <remarks>
            This method creates a formatted report that includes a header row followed by all transactions in chronological order.
            Each row shows the transaction date (in short date format), the transaction amount, the running balance after that
            transaction, and any notes associated with the transaction. The running balance is calculated by iterating through
            all transactions and maintaining a cumulative total. The report uses tab characters for column separation and
            is suitable for display in console applications or simple text outputs.
            </remarks>
        </member>
        <member name="M:OOProgramming.BankAccount.PerformMonthEndTransactions">
            <summary>
            Performs month-end processing for the account. This virtual method can be overridden in derived classes
            to implement specific month-end behaviors such as interest calculations, fee assessments, or statement generation.
            </summary>
            <remarks>
            The base implementation of this method does nothing, providing a safe default for basic bank accounts.
            Derived classes such as savings accounts or checking accounts can override this method to implement
            account-specific month-end processing. Examples include calculating and applying interest payments,
            assessing monthly maintenance fees, generating account statements, or performing regulatory compliance checks.
            This method is typically called by banking systems at the end of each month as part of batch processing operations.
            </remarks>
        </member>
    </members>
</doc>
```
1. For derived classes, explain `<inheritdoc/>` to include base docs


## [verb] * [noun]

[Introduce a task and its role in completing the process.]

<!-- Required: Tasks to complete in the process - H2

In one or more H2 sections, describe tasks that 
the user completes in the process the tutorial describes.

-->

1. Procedure step
1. Procedure step
1. Procedure step

<!-- Required: Steps to complete the tasks - H2

Use ordered lists to describe how to complete tasks in 
the process. Be consistent when you describe how to
use a method or tool to complete the task.

Code requires specific formatting. Here are a few useful 
examples of commonly used code blocks. Make sure to 
use the interactive functionality when possible.

For the CLI-based or PowerShell-based procedures,
don't use bullets or numbering.

Here is an example of a code block for Java:

```java
cluster = Cluster.build(new File("src/site.yaml")).create();
...
client = cluster.connect();
```

Here's a code block for the Azure CLI:

```azurecli-interactive 
az vm create --resource-group myResourceGroup --name myVM 
--image win2016datacenter --admin-username azureuser 
--admin-password <password>
```

This is a code block for Azure PowerShell:

```azurepowershell-interactive
New-AzureRmContainerGroup -ResourceGroupName 
myResourceGroup -Name mycontainer 
-Image mcr.microsoft.com/windows/servercore/iis:nanoserver 
-OsType Windows -IpAddressType Public
```
-->

## Clean up resources

<!-- Optional: Steps to clean up resources - H2

Provide steps the user takes to clean up resources that
were created to complete the article.

-->

## Next step -or- Related content

> [!div class="nextstepaction"]
> [Next sequential article title](link.md)

-or-

* [Related article title](link.md)
* [Related article title](link.md)
* [Related article title](link.md)

<!-- Optional: Next step or Related content - H2

Consider adding one of these H2 sections (not both):

A "Next step" section that uses 1 link in a blue box 
to point to a next, consecutive article in a sequence.

-or- 

A "Related content" section that lists links to 
1 to 3 articles the user might find helpful.

-->

<!--

Remove all comments except the customer intent
before you sign off or merge to the main branch.

-->