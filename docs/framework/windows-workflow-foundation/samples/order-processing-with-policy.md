---
title: "Order Processing with Policy"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 66833724-dc36-4fad-86b0-59ffeaa3ba6a
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Order Processing with Policy
The Order Processing Policy sample demonstrates some of the key features introduced in the [!INCLUDE[netfx35_long](../../../../includes/netfx35-long-md.md)] of the Windows Workflow Foundation (WF). The following functionality is new for the WF rules engine:  
  
-   Support for operator overloading.  
  
-   Support for the `new` operator, allowing users to create new objects and arrays from WF rules.  
  
-   Support for extension methods to make the user experience in calling extension methods from WF rules compatible with C# coding styles.  
  
> [!NOTE]
>  This sample requires that [!INCLUDE[netfx35_long](../../../../includes/netfx35-long-md.md)] is installed to build and run. [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] is required to open the project and solution files.  
  
 The sample demonstrates an `OrderProcessingPolicy` project in which a customer order, which consists of a numbered list of available items and a zip code, is entered. The order is processed successfully if both entries are correct; otherwise, the policy creates error objects, utilizing an overloaded `+` operator and a predefined extension method to inform the user of the errors.  
  
> [!NOTE]
>  [!INCLUDE[crabout](../../../../includes/crabout-md.md)] extension methods, see [C# Version 3.0 Specification](http://go.microsoft.com/fwlink/?LinkId=95402).  
  
 The sample is comprised of the following projects:  
  
-   `OrderErrorLibrary`  
  
     The `OrderErrorLibrary` is a class library that defines `OrderError` and `OrderErrorCollection` classes. An `OrderError` instance is created when an invalid input is entered. The library also provides an extension method on the `OrderErrorCollection` class that outputs the `ErrorText` property on all `OrderError` objects in the `OrderErrorCollection`.  
  
-   `OrderProcessingPolicy`  
  
     The `OrderProcessingPolicy` project is a WF console application that defines a single `PolicyFromFile` activity. The activity has the following rules:  
  
    -   `invalidItemNum`  
  
         This rule validates that the item number is between 1 and 6, inclusive. If the item number is within the valid range, the rule does nothing (other than printing to the console). If the item number is not between 1 and 6, the `invalidItemNum` rule does the following:  
  
        1.  Creates a new `OrderError` object, passing it the item number entered, and sets the `ErrorText` and `CustomerName` properties on the object.  
  
        2.  Creates an `invalidItemNumErrorCollection` object.  
  
        3.  Adds the newly-created `OrderError` instance to the `invalidItemNumErrorCollection`.  
  
         This demonstrates support for the `new` operator, with which you can instantiate objects inside rules.  
  
    -   `invalidZip`  
  
         This rule validates that the zip code has 5 digits, and is within the range 600 to 99998. If the zip code is within the valid range, the rule does nothing (other than printing to the console). If the length of the zip code is less than 5, or the zip code is not between 00600 and 99998, the `invalidZip` rule does the following:  
  
        1.  Creates an `OrderError` object, passing it the zip code entered, and sets the `ErrorText` and `CustomerName` properties on the object.  
  
        2.  Creates an `invalidZipCodeErrorCollection` object.  
  
        3.  Adds the newly-created `OrderError` instance to the newly-created `invalidZipCodeErrorCollection`.  
  
         This rule again demonstrates support for the `new` operator, which allows you to instantiate objects inside rules.  
  
    -   `displayErrors`  
  
         This rule checks to see if there were any errors added by the previous two rules in the two `OrderErrorCollection` objects `invalidItemNumErrorCollection` and `invalidIZipCodeErrorCollection`. If there were errors (either `invalidItemNumErrorCollection` or `invalidZipCodeErrorCollection` is not `null`), the rule does the following:  
  
        1.  Calls the overloaded `+` operator to copy the contents of `invalidItemNumErrorCollection` and `invalidZipCodeErrorCollection` to an `invalidOrdersCollection``OrderErrorCollection` instance.  
  
        2.  Calls the `PrintOrderErrors` extension method on `invalidOrdersCollection` and outputs the `ErrorText` property on all `orderError` objects in `invalidOrdersCollection`.  
  
 The overloaded operator `+` on the `OrderErrorCollection` is defined in the `OrderErrorCollection` class, in the `OrderErrorLibrary` project. It takes two `OrderErrorCollection` objects and combines them into one `OrderErrorCollection` object.  
  
 The `PrintOrderErrors` extension method is also defined in the `OrderErrorLibrary` project. Extension methods are a new C# feature that enables developers to add new methods to the public contract of an existing CLR type, without having to derive a class from it or recompile the original type.  
  
 When you run the sample you are prompted to enter a name, the item number of the item to be purchased, and a zip code. This information is then verified by the rules defined in the policy activity. The following is sample output from the program.  
  
```  
Please enter your name: John  
  
What would you like to purchase?  
        (1) Vista Ultimate DVD  
        (2) Vista Ultimate Upgrade DVD  
        (3) Vista Home Premium DVD  
        (4) Vista Home Premium Upgrade DVD  
        (5) Vista Home Basic DVD  
        (6) Vista Home Basic Upgrade DVD  
  
Please enter an item number: 1  
  
Please enter your 5-Digit zip code: 98102  
  
        Executing Rule: invalidItemNum  
        Executing Rule: invalidZip  
        Executing Rule: displayErrors  
  
                              Thank you for your order, it has been processed.  
  
Workflow Completed  
Another Order? (Y/N): y  
  
Please enter your name: Joel  
  
What would you like to purchase?  
        (1) Vista Ultimate DVD  
        (2) Vista Ultimate Upgrade DVD  
        (3) Vista Home Premium DVD  
        (4) Vista Home Premium Upgrade DVD  
        (5) Vista Home Basic DVD  
        (6) Vista Home Basic Upgrade DVD  
  
Please enter an item number: 8  
  
Please enter your 5-Digit zip code: 0000  
  
        Executing Rule: invalidItemNum  
        Executing Rule: invalidZip  
        Executing Rule: displayErrors  
  
                              Your order contains the following error(s)  
  
Error: No item number found. Please choose an available item.  
Error: Invalid zip code. Please choose a zip code between 00600 and 99998.  
  
Workflow Completed  
Another Order? (Y/N): n  
```  
  
### To set up, build, and run the sample  
  
1.  Open the OrderProcessingPolicy.sln project file in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)].  
  
2.  There are two different projects in the solution: `OrderErrorLibrary` and `OrderProcessingPolicy`. The `OrderProcessingPolicy` project uses classes and methods defined in the `OrderErrorLibrary`.  
  
3.  Build all projects.  
  
4.  Click **Run**.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing:  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory:  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Rules\Policy\OrderProcessingPolicy`