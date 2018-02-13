---
title: "Type Relationships in Query Operations (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "variable relationships [LINQ in Visual Basic]"
  - "type information inferred [LINQ in Visual Basic]"
  - "type relationships [LINQ in Visual Basic]"
  - "queries [LINQ in Visual Basic], type relationships"
  - "data sources [LINQ in Visual Basic], type relationships"
  - "LINQ [Visual Basic], type relationships"
  - "inferring type information [LINQ in Visual Basic]"
  - "relationships [LINQ in Visual Basic]"
ms.assetid: b5ff4da5-f3fd-4a8e-aaac-1cbf52fa16f6
caps.latest.revision: 34
author: dotnet-bot
ms.author: dotnetcontent
---
# Type Relationships in Query Operations (Visual Basic)
Variables used in [!INCLUDE[vbteclinqext](~/includes/vbteclinqext-md.md)] query operations are strongly typed and must be compatible with each other. Strong typing is used in the data source, in the query itself, and in the query execution. The following illustration identifies terms used to describe a [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)] query. For more information about the parts of a query, see [Basic Query Operations (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/basic-query-operations.md).  
  
 ![Pseudocode query with elements highlighted.](../../../../visual-basic/programming-guide/concepts/linq/media/sjltyperels.png "SJLtypeRels")  
Parts of a LINQ query  
  
 The type of the range variable in the query must be compatible with the type of the elements in the data source. The type of the query variable must be compatible with the sequence element defined in the `Select` clause. Finally, the type of the sequence elements also must be compatible with the type of the loop control variable that is used in the `For Each` statement that executes the query. This strong typing facilitates identification of type errors at compile time.  
  
 [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] makes strong typing convenient by implementing local type inference, also known as *implicit typing*. That feature is used in the previous example, and you will see it used throughout the [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)] samples and documentation. In Visual Basic, local type inference is accomplished simply by using a `Dim` statement without an `As` clause. In the following example, `city` is strongly typed as a string.  
  
 [!code-vb[VbLINQTypeRels#1](../../../../visual-basic/programming-guide/concepts/linq/codesnippet/VisualBasic/type-relationships-in-query-operations_1.vb)]  
  
> [!NOTE]
>  Local type inference works only when `Option Infer` is set to `On`. For more information, see [Option Infer Statement](../../../../visual-basic/language-reference/statements/option-infer-statement.md).  
  
 However, even if you use local type inference in a query, the same type relationships are present among the variables in the data source, the query variable, and the query execution loop. It is useful to have a basic understanding of these type relationships when you are writing [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)] queries, or working with the samples and code examples in the documentation.  
  
 You may need to specify an explicit type for a range variable that does not match the type returned from the data source. You can specify the type of the range variable by using an `As` clause. However, this results in an error if the conversion is a [narrowing conversion](../../../../visual-basic/programming-guide/language-features/data-types/widening-and-narrowing-conversions.md) and `Option Strict` is set to `On`. Therefore, we recommend that you perform the conversion on the values retrieved from the data source. You can convert the values from the data source to the explicit range variable type by using the <xref:System.Linq.Enumerable.Cast%2A> method. You can also cast the values selected in the `Select` clause to an explicit type that is different from the type of the range variable. These points are illustrated in the following code.  
  
 [!code-vb[VbLINQTypeRels#4](../../../../visual-basic/programming-guide/concepts/linq/codesnippet/VisualBasic/type-relationships-in-query-operations_2.vb)]  
  
## Queries That Return Entire Elements of the Source Data  
 The following example shows a [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)] query operation that returns a sequence of elements selected from the source data. The source, `names`, contains an array of strings, and the query output is a sequence containing strings that start with the letter M.  
  
 [!code-vb[VbLINQTypeRels#2](../../../../visual-basic/programming-guide/concepts/linq/codesnippet/VisualBasic/type-relationships-in-query-operations_3.vb)]  
  
 This is equivalent to the following code, but is much shorter and easier to write. Reliance on local type inference in queries is the preferred style in Visual Basic.  
  
 [!code-vb[VbLINQTypeRels#3](../../../../visual-basic/programming-guide/concepts/linq/codesnippet/VisualBasic/type-relationships-in-query-operations_4.vb)]  
  
 The following relationships exist in both of the previous code examples, whether the types are determined implicitly or explicitly.  
  
1.  The type of the elements in the data source, `names`, is the type of the range variable, `name`, in the query.  
  
2.  The type of the object that is selected, `name`, determines the type of the query variable, `mNames`. Here `name` is a string, so the query variable is IEnumerable(Of String) in Visual Basic.  
  
3.  The query defined in `mNames` is executed in the `For Each` loop. The loop iterates over the result of executing the query. Because `mNames`, when it is executed, will return a sequence of strings, the loop iteration variable, `nm`, also is a string.  
  
## Queries That Return One Field from Selected Elements  
 The following example shows a [!INCLUDE[vbtecdlinq](~/includes/vbtecdlinq-md.md)] query operation that returns a sequence containing only one part of each element selected from the data source. The query takes a collection of `Customer` objects as its data source and projects only the `Name` property in the result. Because the customer name is a string, the query produces a sequence of strings as output.  
  
```vb  
' Method GetTable returns a table of Customer objects.  
Dim customers = db.GetTable(Of Customer)()  
Dim custNames = From cust In customers   
                Where cust.City = "London"   
                Select cust.Name  
  
For Each custName In custNames  
    Console.WriteLine(custName)  
Next  
```  
  
 The relationships between variables are like those in the simpler example.  
  
1.  The type of the elements in the data source, `customers`, is the type of the range variable, `cust`, in the query. In this example, that type is `Customer`.  
  
2.  The `Select` statement returns the `Name` property of each `Customer` object instead of the whole object. Because `Name` is a string, the query variable, `custNames`, will again be IEnumerable(Of String), not of `Customer`.  
  
3.  Because `custNames` represents a sequence of strings, the `For Each` loop's iteration variable, `custName`, must be a string.  
  
 Without local type inference, the previous example would be more cumbersome to write and to understand, as the following example shows.  
  
```vb  
' Method GetTable returns a table of Customer objects.  
 Dim customers As Table(Of Customer) = db.GetTable(Of Customer)()  
 Dim custNames As IEnumerable(Of String) =  
     From cust As Customer In customers   
     Where cust.City = "London"   
     Select cust.Name  
  
 For Each custName As String In custNames  
     Console.WriteLine(custName)  
 Next  
```  
  
## Queries That Require Anonymous Types  
 The following example shows a more complex situation. In the previous example, it was inconvenient to specify types for all the variables explicitly. In this example, it is impossible. Instead of selecting entire `Customer` elements from the data source, or a single field from each element, the `Select` clause in this query returns two properties of the original `Customer` object: `Name` and `City`. In response to the `Select` clause, the compiler defines an anonymous type that contains those two properties. The result of executing `nameCityQuery` in the `For Each` loop is a collection of instances of the new anonymous type. Because the anonymous type has no usable name, you cannot specify the type of `nameCityQuery` or `custInfo` explicitly. That is, with an anonymous type, you have no type name to use in place of `String` in `IEnumerable(Of String)`. For more information, see [Anonymous Types](../../../../visual-basic/programming-guide/language-features/objects-and-classes/anonymous-types.md).  
  
```vb  
' Method GetTable returns a table of Customer objects.  
Dim customers = db.GetTable(Of Customer)()  
Dim nameCityQuery = From cust In customers   
                    Where cust.City = "London"   
                    Select cust.Name, cust.City  
  
For Each custInfo In nameCityQuery  
    Console.WriteLine(custInfo.Name)  
Next  
```  
  
 Although it is not possible to specify types for all the variables in the previous example, the relationships remain the same.  
  
1.  The type of the elements in the data source is again the type of the range variable in the query. In this example, `cust` is an instance of `Customer`.  
  
2.  Because the `Select` statement produces an anonymous type, the query variable, `nameCityQuery`, must be implicitly typed as an anonymous type. An anonymous type has no usable name, and therefore cannot be specified explicitly.  
  
3.  The type of the iteration variable in the `For Each` loop is the anonymous type created in step 2. Because the type has no usable name, the type of the loop iteration variable must be determined implicitly.  
  
## See Also  
 [Getting Started with LINQ in Visual Basic](../../../../visual-basic/programming-guide/concepts/linq/getting-started-with-linq.md)  
 [Anonymous Types](../../../../visual-basic/programming-guide/language-features/objects-and-classes/anonymous-types.md)  
 [Local Type Inference](../../../../visual-basic/programming-guide/language-features/variables/local-type-inference.md)  
 [Introduction to LINQ in Visual Basic](../../../../visual-basic/programming-guide/language-features/linq/introduction-to-linq.md)  
 [LINQ](../../../../visual-basic/programming-guide/language-features/linq/index.md)  
 [Queries](../../../../visual-basic/language-reference/queries/queries.md)
