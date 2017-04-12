---
title: "Arrays in Visual Basic | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "vb.Array"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "arrays [Visual Basic]"
  - "Visual Basic, arrays"
ms.assetid: dbf29737-b589-4443-bee6-a27588d9c67e
caps.latest.revision: 47
author: dotnet-bot
ms.author: dotnetcontent

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
# Arrays in Visual Basic
An array is a set of values that are logically related to each other, such as the number of students in each grade in a grammar school.  If you are looking for help on arrays in Visual Basic for Applications (VBA), see the [language reference](https://msdn.microsoft.com/library/office/gg264383\(v=office.14\).aspx).  
  
 By using an array, you can refer to these related values by the same name, and use a number that’s called an index or subscript to tell them apart. The individual values are called the elements of the array. They’re contiguous from index 0 through the highest index value.  
  
 In contrast to an array, a variable that contain a single value is called a *scalar* variable.  
  
 Some quick examples before explanation:  
  
```vb  
  
'Declare a single-dimension array of 5 values  
Dim numbers(4) As Integer   
  
‘Declare a single-dimension array and set array element values  
Dim numbers = New Integer() {1, 2, 4, 8}  
  
 ‘Redefine the size of an existing array retaining the current values  
ReDim Preserve numbers(15)  
  
 ‘Redefine the size of an existing array, resetting the values  
ReDim numbers(15)  
  
‘Declare a multi-dimensional array  
Dim matrix(5, 5) As Double  
  
‘Declare a multi-dimensional array and set array element values  
Dim matrix = New Integer(4, 4) {{1, 2}, {3, 4}, {5, 6}, {7, 8}}  
  
 ‘Declare a jagged array  
Dim sales()() As Double = New Double(11)() {}  
```  
  
 **In this topic**  
  
-   [Array Elements in a Simple Array](#BKMK_ArrayElements)  
  
-   [Creating an Array](#BKMK_CreatingAnArray)  
  
-   [Storing Values in an Array](#BKMK_StoringValues)  
  
-   [Populating an Array with Initial Values](#BKMK_Populating)  
  
    -   [Nested Array Literals](#BKMK_NestedArrayLiterals)  
  
-   [Iterating Through an Array](#BKMK_Iterating)  
  
-   [Arrays as Return Values and Parameters](#BKMK_ReturnValues)  
  
-   [Jagged Arrays](#BKMK_JaggedArrays)  
  
-   [Zero-Length Arrays](#BKMK_ZeroLength)  
  
-   [Array Size](#BKMK_ArraySize)  
  
-   [Array Types and Other Types](#BKMK_ArrayTypes)  
  
-   [Collections as an Alternative to Arrays](#BKMK_Collections)  
  
##  <a name="BKMK_ArrayElements"></a> Array Elements in a Simple Array  
 The following example declares an array variable to hold the number of students in each grade in a grammar school.  
  
 [!code-vb[VbVbalrArrays#2](../../../../visual-basic/programming-guide/language-features/arrays/codesnippet/VisualBasic/index_1.vb)]  
  
 The array `students` in the preceding example contains seven elements. The indexes of the elements range from 0 through 6. Having this array is simpler than declaring seven variables.  
  
 The following illustration shows the array `students`. For each element of the array:  
  
-   The index of the element represents the grade (index 0 represents kindergarten).  
  
-   The value that’s contained in the element represents the number of students in that grade.  
  
 ![Picture of array showing numbers of students](../../../../visual-basic/programming-guide/language-features/arrays/media/arrayexampleschool.gif "ArrayExampleSchool")  
Elements of the "students" array  
  
 The following example shows how to refer to the first, second, and last element of the array `students`.  
  
 [!code-vb[VbVbalrArrays#3](../../../../visual-basic/programming-guide/language-features/arrays/codesnippet/VisualBasic/index_2.vb)]  
  
 You can refer to the array as a whole by using just the array variable name without indexes.  
  
 The array `students` in the preceding example uses one index and is said to be one-dimensional. An array that uses more than one index or subscript is called multidimensional. For more information, see the rest of this topic and [Array Dimensions in Visual Basic](../../../../visual-basic/programming-guide/language-features/arrays/array-dimensions.md).  
  
##  <a name="BKMK_CreatingAnArray"></a> Creating an Array  
 You can define the size of an array several ways. You can supply the size when the array is declared, as the following example shows.  
  
 [!code-vb[VbVbalrArrays#12](../../../../visual-basic/programming-guide/language-features/arrays/codesnippet/VisualBasic/index_3.vb)]  
  
 You can also use a `New` clause to supply the size of an array when it’s created, as the following example shows.  
  
 [!code-vb[VbVbalrArrays#11](../../../../visual-basic/programming-guide/language-features/arrays/codesnippet/VisualBasic/index_4.vb)]  
  
 If you have an existing array, you can redefine its size by using the `Redim` statement. You can specify that the `Redim` statement should keep the values that are in the array, or you can specify that it create an empty array. The following example shows different uses of the `Redim` statement to modify the size of an existing array.  
  
 [!code-vb[VbVbalrArrays#13](../../../../visual-basic/programming-guide/language-features/arrays/codesnippet/VisualBasic/index_5.vb)]  
  
 For more information, see [ReDim Statement](../../../../visual-basic/language-reference/statements/redim-statement.md).  
  
##  <a name="BKMK_StoringValues"></a> Storing Values in an Array  
 You can access each location in an array by using an index of type `Integer`. You can store and retrieve values in an array by referencing each array location by using its index enclosed in parentheses. Indexes for multi-dimensional arrays are separated by commas (,). You need one index for each array dimension. The following example shows some statements that store values in arrays.  
  
 [!code-vb[VbVbalrArrays#5](../../../../visual-basic/programming-guide/language-features/arrays/codesnippet/VisualBasic/index_6.vb)]  
  
 The following example shows some statements that get values from arrays.  
  
 [!code-vb[VbVbalrArrays#6](../../../../visual-basic/programming-guide/language-features/arrays/codesnippet/VisualBasic/index_7.vb)]  
  
##  <a name="BKMK_Populating"></a> Populating an Array with Initial Values  
 By using an array literal, you can create an array that contains an initial set of values. An array literal consists of a list of comma-separated values that are enclosed in braces (`{}`).  
  
 When you create an array by using an array literal, you can either supply the array type or use type inference to determine the array type. The following code shows both options.  
  
 [!code-vb[VbVbalrCollectionInitializers#3](../../../../visual-basic/programming-guide/language-features/arrays/codesnippet/VisualBasic/index_8.vb)]  
  
 When you use type inference, the type of the array is determined by the dominant type in the list of values that’s supplied for the array literal. The dominant type is a unique type to which all other types in the array literal can widen. If this unique type can’t be determined, the dominant type is the unique type to which all other types in the array can narrow. If neither of these unique types can be determined, the dominant type is `Object`. For example, if the list of values that’s supplied to the array literal contains values of type `Integer`, `Long`, and `Double`, the resulting array is of type `Double`. Both `Integer` and `Long` widen only to `Double`. Therefore, `Double` is the dominant type. For more information, see [Widening and Narrowing Conversions](../../../../visual-basic/programming-guide/language-features/data-types/widening-and-narrowing-conversions.md). These inference rules apply to types that are inferred for arrays that are local variables that are defined in a class member. Although you can use array literals when you create class-level variables, you can’t use type inference at the class level. As a result, array literals that are specified at the class level infer the values that are supplied for the array literal as type `Object`.  
  
 You can explicitly specify the type of the elements in an array that’s created by using an array literal. In this case, the values in the array literal must widen to the type of the elements of the array. The following code example creates an array of type `Double` from a list of integers.  
  
 [!code-vb[VbVbalrCollectionInitializers#4](../../../../visual-basic/programming-guide/language-features/arrays/codesnippet/VisualBasic/index_9.vb)]  
  
###  <a name="BKMK_NestedArrayLiterals"></a> Nested Array Literals  
 You can create a multidimensional array by using nested array literals. Nested array literals must have a dimension and number of dimensions, or rank, that’s consistent with the resulting array. The following code example creates a two-dimensional array of integers by using an array literal.  
  
 [!code-vb[VbVbalrCollectionInitializers#7](../../../../visual-basic/programming-guide/language-features/arrays/codesnippet/VisualBasic/index_10.vb)]  
  
 In the previous example, an error would occur if the number of elements in the nested array literals didn’t match. An error would also occur if you explicitly declared the array variable to be other than two-dimensional.  
  
> [!NOTE]
>  You can avoid an error when you supply nested array literals of different dimensions by enclosing the inner array literals in parentheses. The parentheses force the array literal expression to be evaluated, and the resulting values are used with the outer array literal, as the following code shows.  
  
 [!code-vb[VbVbalrCollectionInitializers#11](../../../../visual-basic/programming-guide/language-features/arrays/codesnippet/VisualBasic/index_11.vb)]  
  
 When you create a multidimensional array by using nested array literals, you can use type inference. When you use type inference, the inferred type is the dominant type for all the values in all the array literals for a nesting level. The following code example creates a two-dimensional array of type `Double` from values that are of type `Integer` and `Double`.  
  
 [!code-vb[VbVbalrCollectionInitializers#8](../../../../visual-basic/programming-guide/language-features/arrays/codesnippet/VisualBasic/index_12.vb)]  
  
 For additional examples, see [How to: Initialize an Array Variable in Visual Basic](../../../../visual-basic/programming-guide/language-features/arrays/how-to-initialize-an-array-variable.md).  
  
##  <a name="BKMK_Iterating"></a> Iterating Through an Array  
 When you iterate through an array, you access each element in the array from the lowest index to the highest index.  
  
 The following example iterates through a one-dimensional array by using the [For...Next Statement](../../../../visual-basic/language-reference/statements/for-next-statement.md). The <xref:System.Array.GetUpperBound%2A> method returns the highest value that the index can have. The lowest index value is always 0.  
  
 [!code-vb[VbVbalrArrays#41](../../../../visual-basic/programming-guide/language-features/arrays/codesnippet/VisualBasic/index_13.vb)]  
  
 The following example iterates through a multidimensional array by using a `For...Next` statement. The <xref:System.Array.GetUpperBound%2A> method has a parameter that specifies the dimension. `GetUpperBound(0)` returns the high index value for the first dimension, and `GetUpperBound(1)` returns the high index value for the second dimension.  
  
 [!code-vb[VbVbalrArrays#42](../../../../visual-basic/programming-guide/language-features/arrays/codesnippet/VisualBasic/index_14.vb)]  
  
 The following example iterates through a one-dimensional array by using a [For Each...Next Statement](../../../../visual-basic/language-reference/statements/for-each-next-statement.md).  
  
 [!code-vb[VbVbalrArrays#43](../../../../visual-basic/programming-guide/language-features/arrays/codesnippet/VisualBasic/index_15.vb)]  
  
 The following example iterates through a multidimensional array by using a `For Each...Next` statement. However, you have more control over the elements of a multidimensional array if you use a nested `For…Next` statement, as in a previous example, instead of a `For Each…Next` statement.  
  
 [!code-vb[VbVbalrArrays#44](../../../../visual-basic/programming-guide/language-features/arrays/codesnippet/VisualBasic/index_16.vb)]  
  
##  <a name="BKMK_ReturnValues"></a> Arrays as Return Values and Parameters  
 To return an array from a `Function` procedure, specify the array data type and the number of dimensions as the return type of the [Function Statement](../../../../visual-basic/language-reference/statements/function-statement.md). Within the function, declare a local array variable with same data type and number of dimensions. In the [Return Statement](../../../../visual-basic/language-reference/statements/return-statement.md), include the local array variable without parentheses.  
  
 To specify an array as a parameter to a `Sub` or `Function` procedure, define the parameter as an array with a specified data type and number of dimensions. In the call to the procedure, send an array variable with the same data type and number of dimensions.  
  
 In the following example, the `GetNumbers` function returns an `Integer()`. This array type is a one dimensional array of type `Integer`. The `ShowNumbers` procedure accepts an `Integer()` argument.  
  
 [!code-vb[VbVbalrArrays#51](../../../../visual-basic/programming-guide/language-features/arrays/codesnippet/VisualBasic/index_17.vb)]  
  
 In the following example, the `GetNumbersMultiDim` function returns an `Integer(,)`. This array type is a two dimensional array of type `Integer`.  The `ShowNumbersMultiDim` procedure accepts an `Integer(,)` argument.  
  
 [!code-vb[VbVbalrArrays#52](../../../../visual-basic/programming-guide/language-features/arrays/codesnippet/VisualBasic/index_18.vb)]  
  
##  <a name="BKMK_JaggedArrays"></a> Jagged Arrays  
 An array that holds other arrays as elements is known as an array of arrays or a jagged array. A jagged array and each element in a jagged array can have one or more dimensions. Sometimes the data structure in your application is two-dimensional but not rectangular.  
  
 The following example has an array of months, each element of which is an array of days. Because different months have different numbers of days, the elements don’t form a rectangular two-dimensional array. Therefore, a jagged array is used instead of a multidimensional array.  
  
 [!code-vb[VbVbalrArrays#21](../../../../visual-basic/programming-guide/language-features/arrays/codesnippet/VisualBasic/index_19.vb)]  
  
##  <a name="BKMK_ZeroLength"></a> Zero-Length Arrays  
 An array that contains no elements is also called a zero-length array. A variable that holds a zero-length array doesn’t have the value `Nothing`. To create an array that has no elements, declare one of the array's dimensions to be -1, as the following example shows.  
  
 [!code-vb[VbVbalrArrays#14](../../../../visual-basic/programming-guide/language-features/arrays/codesnippet/VisualBasic/index_20.vb)]  
  
 You might need to create a zero-length array under the following circumstances:  
  
-   Without risking a <xref:System.NullReferenceException> exception, your code must access members of the <xref:System.Array> class, such as <xref:System.Array.Length%2A> or <xref:System.Array.Rank%2A>, or call a [!INCLUDE[vbprvb](../../../../csharp/programming-guide/concepts/linq/includes/vbprvb_md.md)] function such as <xref:Microsoft.VisualBasic.Information.UBound%2A>.  
  
-   You want to keep the consuming code simpler by not having to check for `Nothing` as a special case.  
  
-   Your code interacts with an application programming interface (API) that either requires you to pass a zero-length array to one or more procedures or returns a zero-length array from one or more procedures.  
  
##  <a name="BKMK_ArraySize"></a> Array Size  
 The size of an array is the product of the lengths of all its dimensions. It represents the total number of elements currently contained in the array.  
  
 The following example declares a three-dimensional array.  
  
```  
Dim prices(3, 4, 5) As Long  
```  
  
 The overall size of the array in variable `prices` is (3 + 1) x (4 + 1) x (5 + 1) = 120.  
  
 You can find the size of an array by using the <xref:System.Array.Length%2A> property. You can find the length of each dimension of a multi-dimensional array by using the <xref:System.Array.GetLength%2A> method.  
  
 You can resize an array variable by assigning a new array object to it or by using the `ReDim` statement.  
  
 There are several things to keep in mind when dealing with the size of an array.  
  
|||  
|---|---|  
|Dimension Length|The index of each dimension is 0-based, which means it ranges from 0 through its upper bound. Therefore, the length of a given dimension is greater by 1 than the declared upper bound for that dimension.|  
|Length Limits|The length of every dimension of an array is limited to the maximum value of the `Integer` data type, which is (2 ^ 31) - 1. However, the total size of an array is also limited by the memory available on your system. If you attempt to initialize an array that exceeds the amount of available RAM, the common language runtime throws an <xref:System.OutOfMemoryException> exception.|  
|Size and Element Size|An array's size is independent of the data type of its elements. The size always represents the total number of elements, not the number of bytes that they consume in storage.|  
|Memory Consumption|It is not safe to make any assumptions regarding how an array is stored in memory. Storage varies on platforms of different data widths, so the same array can consume more memory on a 64-bit system than on a 32-bit system. Depending on system configuration when you initialize an array, the common language runtime (CLR) can assign storage either to pack elements as close together as possible, or to align them all on natural hardware boundaries. Also, an array requires a storage overhead for its control information, and this overhead increases with each added dimension.|  
  
##  <a name="BKMK_ArrayTypes"></a> Array Types and Other Types  
 Every array has a data type, but it differs from the data type of its elements. There is no single data type for all arrays. Instead, the data type of an array is determined by the number of dimensions, or *rank*, of the array, and the data type of the elements in the array. Two array variables are considered to be of the same data type only when they have the same rank and their elements have the same data type. The lengths of the dimensions in an array do not influence the array data type.  
  
 Every array inherits from the <xref:System.Array?displayProperty=fullName> class, and you can declare a variable to be of type `Array`, but you cannot create an array of type `Array`. Also, the [ReDim Statement](../../../../visual-basic/language-reference/statements/redim-statement.md) cannot operate on a variable declared as type `Array`. For these reasons, and for type safety, it is advisable to declare every array as a specific type, such as `Integer` in the preceding example.  
  
 You can find out the data type of either an array or its elements in several ways.  
  
-   You can call the <xref:System.Object.GetType%2A?displayProperty=fullName> method on the variable to receive a <xref:System.Type> object for the run-time type of the variable. The <xref:System.Type> object holds extensive information in its properties and methods.  
  
-   You can pass the variable to the <xref:Microsoft.VisualBasic.Information.TypeName%2A> function to receive a `String` containing the name of run-time type.  
  
-   You can pass the variable to the <xref:Microsoft.VisualBasic.Information.VarType%2A> function to receive a `VariantType` value representing the type classification of the variable.  
  
 The following example calls the `TypeName` function to determine the type of the array and the type of the elements in the array. The array type is `Integer(,)` and the elements in the array are of type `Integer`.  
  
 [!code-vb[VbVbalrArrays#15](../../../../visual-basic/programming-guide/language-features/arrays/codesnippet/VisualBasic/index_21.vb)]  
  
##  <a name="BKMK_Collections"></a> Collections as an Alternative to Arrays  
 Arrays are most useful for creating and working with a fixed number of strongly typed objects. Collections provide a more flexible way to work with groups of objects. Unlike arrays, the group of objects that you work with can grow and shrink dynamically as the needs of the application change.  
  
 If you need to change the size of an array, you must use the [ReDim Statement](../../../../visual-basic/language-reference/statements/redim-statement.md). When you do this, [!INCLUDE[vbprvb](../../../../csharp/programming-guide/concepts/linq/includes/vbprvb_md.md)] creates a new array and releases the previous array for disposal. This takes execution time. Therefore, if the number of items you are working with changes frequently, or you cannot predict the maximum number of items you need, you might obtain better performance using a collection.  
  
 For some collections, you can assign a key to any object that you put into the collection so that you can quickly retrieve the object by using the key.  
  
 If your collection contains elements of only one data type, you can use one of the classes in the <xref:System.Collections.Generic?displayProperty=fullName> namespace. A generic collection enforces type safety so that no other data type can be added to it. When you retrieve an element from a generic collection, you do not have to determine its data type or convert it.  
  
 For more information about collections, see [Collections](http://msdn.microsoft.com/library/e76533a9-5033-4a0b-b003-9c2be60d185b).  
  
### Example  
 The following example uses the [!INCLUDE[dnprdnshort](../../../../csharp/getting-started/includes/dnprdnshort_md.md)] generic class <xref:System.Collections.Generic.List%601?displayProperty=fullName> to create a list collection of `Customer` objects.  
  
 [!code-vb[VbVbalrArrays#1](../../../../visual-basic/programming-guide/language-features/arrays/codesnippet/VisualBasic/index_22.vb)]  
  
 The declaration of the `CustomerFile` collection specifies that it can contain elements only of type `Customer`. It also provides for an initial capacity of 200 elements. The procedure `AddNewCustomer` checks the new element for validity and then adds it to the collection. The procedure `PrintCustomers` uses a `For Each` loop to traverse the collection and display its elements.  
  
## Related Topics  
  
|Term|Definition|  
|----------|----------------|  
|[Array Dimensions in Visual Basic](../../../../visual-basic/programming-guide/language-features/arrays/array-dimensions.md)|Explains rank and dimensions in arrays.|  
|[How to: Initialize an Array Variable in Visual Basic](../../../../visual-basic/programming-guide/language-features/arrays/how-to-initialize-an-array-variable.md)|Describes how to populate arrays with initial values.|  
|[How to: Sort An Array in Visual Basic](../../../../visual-basic/programming-guide/language-features/arrays/how-to-sort-an-array.md)|Shows how to sort the elements of an array alphabetically.|  
|[How to: Assign One Array to Another Array](../../../../visual-basic/programming-guide/language-features/arrays/how-to-assign-one-array-to-another-array.md)|Describes the rules and steps for assigning an array to another array variable.|  
|[Troubleshooting Arrays](../../../../visual-basic/programming-guide/language-features/arrays/troubleshooting-arrays.md)|Discusses some common problems that arise when working with arrays.|  
  
## See Also  
 <xref:System.Array>   
 [Dim Statement](../../../../visual-basic/language-reference/statements/dim-statement.md)   
 [ReDim Statement](../../../../visual-basic/language-reference/statements/redim-statement.md)