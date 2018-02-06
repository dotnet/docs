---
title: "Writing Queries in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "get-started-article"
helpviewer_keywords: 
  - "queries [LINQ in Visual Basic], writing"
  - "LINQ [Visual Basic], walkthroughs"
  - "LINQ [Visual Basic], writing queries"
  - "writing LINQ queries [Visual Basic]"
ms.assetid: f0045808-b9fe-4d31-88d1-473d9957211e
caps.latest.revision: 70
author: dotnet-bot
ms.author: dotnetcontent
---
# Walkthrough: Writing Queries in Visual Basic
This walkthrough demonstrates how you can use Visual Basic language features to write [!INCLUDE[vbteclinqext](~/includes/vbteclinqext-md.md)] query expressions. The walkthrough demonstrates how to create queries on a list of Student objects, how to run the queries, and how to modify them. The queries incorporate several features including object initializers, local type inference, and anonymous types.  
  
 After completing this walkthrough, you will be ready to move on to the samples and documentation for the specific [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)] provider you are interested in. [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)] providers include [!INCLUDE[vbtecdlinq](~/includes/vbtecdlinq-md.md)], [!INCLUDE[linq_dataset](~/includes/linq-dataset-md.md)], and [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)].  
  
## Create a Project  
  
#### To create a console application project  
  
1.  Start Visual Studio.  
  
2.  On the **File** menu, point to **New**, and then click **Project**.  
  
3.  In the **Installed Templates** list, click **Visual Basic**.  
  
4.  In the list of project types, click **Console Application**. In the **Name** box, type a name for the project, and then click **OK**.  
  
     A project is created. By default, it contains a reference to System.Core.dll. Also, the **Imported namespaces** list on the [References Page, Project Designer (Visual Basic)](/visualstudio/ide/reference/references-page-project-designer-visual-basic) includes the <xref:System.Linq?displayProperty=nameWithType> namespace.  
  
5.  On the [Compile Page, Project Designer (Visual Basic)](/visualstudio/ide/reference/compile-page-project-designer-visual-basic), ensure that **Option infer** is set to **On**.  
  
## Add an In-Memory Data Source  
 The data source for the queries in this walkthrough is a list of `Student` objects. Each `Student` object contains a first name, a last name, a class year, and an academic rank in the student body.  
  
#### To add the data source  
  
-   Define a `Student` class, and create a list of instances of the class.  
  
    > [!IMPORTANT]
    >  The code needed to define the `Student` class and create the list used in the walkthrough examples is provided in [How to: Create a List of Items](../../../../visual-basic/programming-guide/concepts/linq/how-to-create-a-list-of-items.md). You can copy it from there and paste it into your project. The new code replaces the code that appeared when you created the project.  
  
#### To add a new student to the students list  
  
-   Follow the pattern in the `getStudents` method to add another instance of the `Student` class to the list. Adding the student will introduce you to object initializers. For more information, see [Object Initializers: Named and Anonymous Types](../../../../visual-basic/programming-guide/language-features/objects-and-classes/object-initializers-named-and-anonymous-types.md).  
  
## Create a Query  
 When executed, the query added in this section produces a list of the students whose academic rank puts them in the top ten. Because the query selects the complete `Student` object each time, the type of the query result is `IEnumerable(Of Student)`. However, the type of the query typically is not specified in query definitions. Instead, the compiler uses local type inference to determine the type. For more information, see [Local Type Inference](../../../../visual-basic/programming-guide/language-features/variables/local-type-inference.md). The query's range variable, `currentStudent`, serves as a reference to each `Student` instance in the source, `students`, providing access to the properties of each object in `students`.  
  
#### To create a simple query  
  
1.  Find the place in the `Main` method of the project that is marked as follows:  
  
     [!code-vb[VbLINQWalkthrough#1](../../../../visual-basic/programming-guide/concepts/linq/codesnippet/VisualBasic/walkthrough-writing-queries_1.vb)]  
  
     Copy the following code and paste it in.  
  
     [!code-vb[VbLINQWalkthrough#2](../../../../visual-basic/programming-guide/concepts/linq/codesnippet/VisualBasic/walkthrough-writing-queries_2.vb)]  
  
2.  Rest the mouse pointer over `studentQuery` in your code to verify that the compiler-assigned type is `IEnumerable(Of Student)`.  
  
## Run the Query  
 The variable `studentQuery` contains the definition of the query, not the results of running the query. A typical mechanism for running a query is a `For Each` loop. Each element in the returned sequence is accessed through the loop iteration variable. For more information about query execution, see [Writing Your First LINQ Query](../../../../visual-basic/programming-guide/concepts/linq/writing-your-first-linq-query.md).  
  
#### To run the query  
  
1.  Add the following `For Each` loop below the query in your project.  
  
     [!code-vb[VbLINQWalkthrough#3](../../../../visual-basic/programming-guide/concepts/linq/codesnippet/VisualBasic/walkthrough-writing-queries_3.vb)]  
  
2.  Rest the mouse pointer over the loop control variable `studentRecord` to see its data type. The type of `studentRecord` is inferred to be `Student`, because `studentQuery` returns a collection of `Student` instances.  
  
3.  Build and run the application by pressing CTRL+F5. Note the results in the console window.  
  
## Modify the Query  
 It is easier to scan query results if they are in a specified order. You can sort the returned sequence based on any available field.  
  
#### To order the results  
  
1.  Add the following `Order By` clause between the `Where` statement and the `Select` statement of the query. The `Order By` clause will order the results alphabetically from A to Z, according to the last name of each student.  
  
    ```  
    Order By currentStudent.Last Ascending   
    ```  
  
2.  To order by last name and then first name, add both fields to the query:  
  
    ```  
    Order By currentStudent.Last Ascending, currentStudent.First Ascending   
    ```  
  
     You can also specify `Descending` to order from Z to A.  
  
3.  Build and run the application by pressing CTRL+F5. Note the results in the console window.  
  
#### To introduce a local identifier  
  
1.  Add the code in this section to introduce a local identifier in the query expression. The local identifier will hold an intermediate result. In the following example, `name` is an identifier that holds a concatenation of the student's first and last names. A local identifier can be used for convenience, or it can enhance performance by storing the results of an expression that would otherwise be calculated multiple times.  
  
     [!code-vb[VbLINQWalkthrough#4](../../../../visual-basic/programming-guide/concepts/linq/codesnippet/VisualBasic/walkthrough-writing-queries_4.vb)]  
  
2.  Build and run the application by pressing CTRL+F5. Note the results in the console window.  
  
#### To project one field in the Select clause  
  
1.  Add the query and `For Each` loop from this section to create a query that produces a sequence whose elements differ from the elements in the source. In the following example, the source is a collection of `Student` objects, but only one member of each object is returned: the first name of students whose last name is Garcia. Because `currentStudent.First` is a string, the data type of the sequence returned by `studentQuery3` is `IEnumerable(Of String)`, a sequence of strings. As in earlier examples, the assignment of a data type for `studentQuery3` is left for the compiler to determine by using local type inference.  
  
     [!code-vb[VbLINQWalkthrough#5](../../../../visual-basic/programming-guide/concepts/linq/codesnippet/VisualBasic/walkthrough-writing-queries_5.vb)]  
  
2.  Rest the mouse pointer over `studentQuery3` in your code to verify that the assigned type is `IEnumerable(Of String)`.  
  
3.  Build and run the application by pressing CTRL+F5. Note the results in the console window.  
  
#### To create an anonymous type in the Select clause  
  
1.  Add the code from this section to see how anonymous types are used in queries. You use them in queries when you want to return several fields from the data source rather than complete records (`currentStudent` records in previous examples) or single fields (`First` in the preceding section). Instead of defining a new named type that contains the fields you want to include in the result, you specify the fields in the `Select` clause and the compiler creates an anonymous type with those fields as its properties. For more information, see [Anonymous Types](../../../../visual-basic/programming-guide/language-features/objects-and-classes/anonymous-types.md).  
  
     The following example creates a query that returns the name and rank of seniors whose academic rank is between 1 and 10, in order of academic rank. In this example, the type of `studentQuery4` must be inferred because the `Select` clause returns an instance of an anonymous type, and an anonymous type has no usable name.  
  
     [!code-vb[VbLINQWalkthrough#6](../../../../visual-basic/programming-guide/concepts/linq/codesnippet/VisualBasic/walkthrough-writing-queries_6.vb)]  
  
2.  Build and run the application by pressing CTRL+F5. Note the results in the console window.  
  
## Additional Examples  
 Now that you understand the basics, the following is a list of additional examples to illustrate the flexibility and power of [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)] queries. Each example is preceded by a brief description of what it does. Rest the mouse pointer over the query result variable for each query to see the inferred type. Use a `For Each` loop to produce the results.  
  
 [!code-vb[VbLINQWalkthrough#7](../../../../visual-basic/programming-guide/concepts/linq/codesnippet/VisualBasic/walkthrough-writing-queries_7.vb)]  
  
## Additional Information  
 After you are familiar with the basic concepts of working with queries, you are ready to read the documentation and samples for the specific type of [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)] provider that you are interested in:  
  
 [LINQ to Objects](http://msdn.microsoft.com/library/73cafe73-37cf-46e7-bfa7-97c7eea7ced9)  
  
 [LINQ to SQL](../../../../framework/data/adonet/sql/linq/index.md)  
  
 [LINQ to XML](http://msdn.microsoft.com/library/f0fe21e9-ee43-4a55-b91a-0800e5782c13)  
  
 [LINQ to DataSet](../../../../framework/data/adonet/linq-to-dataset.md)  
  
## See Also  
 [Language-Integrated Query (LINQ) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/index.md)  
 [Getting Started with LINQ in Visual Basic](../../../../visual-basic/programming-guide/concepts/linq/getting-started-with-linq.md)  
 [Local Type Inference](../../../../visual-basic/programming-guide/language-features/variables/local-type-inference.md)  
 [Object Initializers: Named and Anonymous Types](../../../../visual-basic/programming-guide/language-features/objects-and-classes/object-initializers-named-and-anonymous-types.md)  
 [Anonymous Types](../../../../visual-basic/programming-guide/language-features/objects-and-classes/anonymous-types.md)  
 [Introduction to LINQ in Visual Basic](../../../../visual-basic/programming-guide/language-features/linq/introduction-to-linq.md)  
 [LINQ](../../../../visual-basic/programming-guide/language-features/linq/index.md)  
 [Queries](../../../../visual-basic/language-reference/queries/queries.md)
