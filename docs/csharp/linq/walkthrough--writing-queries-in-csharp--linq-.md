---
title: "Walkthrough: Writing Queries in C# (LINQ)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "get-started-article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "LINQ [C#], walkthroughs"
  - "LINQ [C#], writing queries"
  - "queries [LINQ in C#], writing"
  - "writing LINQ queries"
ms.assetid: 2962a610-419a-4276-9ec8-4b7f2af0c081
caps.latest.revision: 32
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "ru-ru"
  - "zh-cn"
  - "zh-tw"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# Walkthrough: Writing Queries in C# (LINQ)
This walkthrough demonstrates the C# language features that are used to write LINQ query expressions.  
  
## Create a C# Project  
  
> [!NOTE]
>  The following instructions are for Visual Studio. If you are using a different development environment, create a console project with a reference to System.Core.dll and a `using` directive for the <xref:System.Linq?displayProperty=fullName> namespace.  
  
#### To create a project in Visual Studio  
  
1.  Start Visual Studio.  
  
2.  On the menu bar, choose **File**, **New**, **Project**.  
  
     The **New Project** dialog box opens.  
  
3.  Expand **Installed**, expand **Templates**, expand **Visual C#**, and then choose **Console Application**.  
  
4.  In the **Name** text box, enter a different name or accept the default name, and then choose the **OK** button.  
  
     The new project appears in **Solution Explorer**.  
  
5.  Notice that your project has a reference to System.Core.dll and a `using` directive for the <xref:System.Linq?displayProperty=fullName> namespace.  
  
## Create an in-Memory Data Source  
 The data source for the queries is a simple list of `Student` objects. Each `Student` record has a first name, last name, and an array of integers that represents their test scores in the class. Copy this code into your project. Note the following characteristics:  
  
-   The `Student` class consists of auto-implemented properties.  
  
-   Each student in the list is initialized with an object initializer.  
  
-   The list itself is initialized with a collection initializer.  
  
 This whole data structure will be initialized and instantiated without explicit calls to any constructor or explicit member access. For more information about these new features, see [Auto-Implemented Properties](../classes-and-structs/auto-implemented-properties--csharp-programming-guide-.md) and [Object and Collection Initializers](../classes-and-structs/object-and-collection-initializers--csharp-programming-guide-.md).  
  
#### To add the data source  
  
-   Add the `Student` class and the initialized list of students to the `Program` class in your project.  
  
     [!code[CsLinqGettingStarted#11](../linq/codesnippet/CSharp/walkthrough--writing-queries-in-csharp--linq-_1.cs)]  
  
#### To add a new Student to the Students list  
  
1.  Add a new `Student` to the `Students` list and use a name and test scores of your choice. Try typing all the new student information in order to better learn the syntax for the object initializer.  
  
## Create the Query  
  
#### To create a simple query  
  
-   In the application's `Main` method, create a simple query that, when it is executed, will produce a list of all students whose score on the first test was greater than 90. Note that because the whole `Student` object is selected, the type of the query is `IEnumerable<Student>`. Although the code could also use implicit typing by using the [var](../keywords/var--csharp-reference-.md) keyword, explicit typing is used to clearly illustrate results. (For more information about `var`, see [Implicitly Typed Local Variables](../classes-and-structs/implicitly-typed-local-variables--csharp-programming-guide-.md).)  
  
     Note also that the query's range variable, `student`, serves as a reference to each `Student` in the source, providing member access for each object.  
  
 [!code[CsLINQGettingStarted#12](../linq/codesnippet/CSharp/walkthrough--writing-queries-in-csharp--linq-_2.cs)]  
  
## Execute the Query  
  
#### To execute the query  
  
1.  Now write the `foreach` loop that will cause the query to execute. Note the following about the code:  
  
    -   Each element in the returned sequence is accessed through the iteration variable in the `foreach` loop.  
  
    -   The type of this variable is `Student`, and the type of the query variable is compatible, `IEnumerable<Student>`.  
  
2.  After you have added this code, build and run the application to see the results in the **Console** window.  
  
 [!code[CsLINQGettingStarted#13](../linq/codesnippet/CSharp/walkthrough--writing-queries-in-csharp--linq-_3.cs)]  
  
#### To add another filter condition  
  
1.  You can combine multiple Boolean conditions in the `where` clause in order to further refine a query. The following code adds a condition so that the query returns those students whose first score was over 90 and whose last score was less than 80. The `where` clause should resemble the following code.  
  
    ```  
    where student.Scores[0] > 90 && student.Scores[3] < 80  
    ```  
  
     For more information, see [where clause](../keywords/where-clause--csharp-reference-.md).  
  
## Modify the Query  
  
#### To order the results  
  
1.  It will be easier to scan the results if they are in some kind of order. You can order the returned sequence by any accessible field in the source elements. For example, the following `orderby` clause orders the results in alphabetical order from A to Z according to the last name of each student. Add the following `orderby` clause to your query, right after the `where` statement and before the `select` statement:  
  
    ```  
    orderby student.Last ascending  
    ```  
  
2.  Now change the `orderby` clause so that it orders the results in reverse order according to the score on the first test, from the highest score to the lowest score.  
  
    ```  
    orderby student.Scores[0] descending  
    ```  
  
3.  Change the `WriteLine` format string so that you can see the scores:  
  
    ```  
    Console.WriteLine("{0}, {1} {2}", student.Last, student.First, student.Scores[0]);  
    ```  
  
     For more information, see [orderby clause](../keywords/orderby-clause--csharp-reference-.md).  
  
#### To group the results  
  
1.  Grouping is a powerful capability in query expressions. A query with a group clause produces a sequence of groups, and each group itself contains a `Key` and a sequence that consists of all the members of that group. The following new query groups the students by using the first letter of their last name as the key.  
  
     [!code[CsLINQGettingStarted#14](../linq/codesnippet/CSharp/walkthrough--writing-queries-in-csharp--linq-_4.cs)]  
  
2.  Note that the type of the query has now changed. It now produces a sequence of groups that have a `char` type as a key, and a sequence of `Student` objects. Because the type of the query has changed, the following code changes the `foreach` execution loop also:  
  
     [!code[CsLINQGettingStarted#15](../linq/codesnippet/CSharp/walkthrough--writing-queries-in-csharp--linq-_5.cs)]  
  
3.  Run the application and view the results in the **Console** window.  
  
     For more information, see [group clause](../keywords/group-clause--csharp-reference-.md).  
  
#### To make the variables implicitly typed  
  
1.  Explicitly coding `IEnumerables` of `IGroupings` can quickly become tedious. You can write the same query and `foreach` loop much more conveniently by using `var`. The `var` keyword does not change the types of your objects; it just instructs the compiler to infer the types. Change the type of `studentQuery` and the iteration variable `group` to `var` and rerun the query. Note that in the inner `foreach` loop, the iteration variable is still typed as `Student`, and the query works just as before. Change the `s` iteration variable to `var` and run the query again. You see that you get exactly the same results.  
  
     [!code[CsLINQGettingStarted#16](../linq/codesnippet/CSharp/walkthrough--writing-queries-in-csharp--linq-_6.cs)]  
  
     For more information about [var](../keywords/var--csharp-reference-.md), see [Implicitly Typed Local Variables](../classes-and-structs/implicitly-typed-local-variables--csharp-programming-guide-.md).  
  
#### To order the groups by their key value  
  
1.  When you run the previous query, you notice that the groups are not in alphabetical order. To change this, you must provide an `orderby` clause after the `group` clause. But to use an `orderby` clause, you first need an identifier that serves as a reference to the groups created by the `group` clause. You provide the identifier by using the `into` keyword, as follows:  
  
     [!code[csLINQGettingStarted#17](../linq/codesnippet/CSharp/walkthrough--writing-queries-in-csharp--linq-_7.cs)]  
  
     When you run this query, you will see the groups are now sorted in alphabetical order.  
  
#### To introduce an identifier by using let  
  
1.  You can use the `let` keyword to introduce an identifier for any expression result in the query expression. This identifier can be a convenience, as in the following example, or it can enhance performance by storing the results of an expression so that it does not have to be calculated multiple times.  
  
     [!code[csLINQGettingStarted#18](../linq/codesnippet/CSharp/walkthrough--writing-queries-in-csharp--linq-_8.cs)]  
  
     For more information, see [let clause](../keywords/let-clause--csharp-reference-.md).  
  
#### To use method syntax in a query expression  
  
1.  As described in [Query Syntax and Method Syntax in LINQ](../linq/query-syntax-and-method-syntax-in-linq--csharp-.md), some query operations can only be expressed by using method syntax. The following code calculates the total score for each `Student` in the source sequence, and then calls the `Average()` method on the results of that query to calculate the average score of the class. Note the placement of parentheses around the query expression.  
  
     [!code[csLINQGettingStarted#19](../linq/codesnippet/CSharp/walkthrough--writing-queries-in-csharp--linq-_9.cs)]  
  
#### To transform or project in the select clause  
  
1.  It is very common for a query to produce a sequence whose elements differ from the elements in the source sequences. Delete or comment out your previous query and execution loop, and replace it with the following code. Note that the query returns a sequence of strings (not `Students`), and this fact is reflected in the `foreach` loop.  
  
     [!code[csLINQGettingStarted#20](../linq/codesnippet/CSharp/walkthrough--writing-queries-in-csharp--linq-_10.cs)]  
  
2.  Code earlier in this walkthrough indicated that the average class score is approximately 334. To produce a sequence of `Students` whose total score is greater than the class average, together with their `Student ID`, you can use an anonymous type in the `select` statement:  
  
     [!code[csLINQGettingStarted#21](../linq/codesnippet/CSharp/walkthrough--writing-queries-in-csharp--linq-_11.cs)]  
  
## Next Steps  
 After you are familiar with the basic aspects of working with queries in C#, you are ready to read the documentation and samples for the specific type of LINQ provider you are interested in:  
  
 [LINQ to SQL](../Topic/LINQ%20to%20SQL.md)  
  
 [LINQ to DataSet](../Topic/LINQ%20to%20DataSet.md)  
  
 [LINQ to XML (C#)](../linq/linq-to-xml--csharp-.md)  
  
 [LINQ to Objects (C#)](../linq/linq-to-objects--csharp-.md)  
  
## See Also  
 [Language-Integrated Query (LINQ) (C#)](../linq/language-integrated-query--linq---csharp-.md)   
 [Getting Started with LINQ in C#](../linq/getting-started-with-linq-in-csharp.md)   
 [LINQ Query Expressions](../linq-query-expressions/linq-query-expressions--csharp-programming-guide-.md)