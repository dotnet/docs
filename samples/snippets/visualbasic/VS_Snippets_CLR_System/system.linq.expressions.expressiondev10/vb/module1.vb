Option Strict On
Imports System.Linq.Expressions
Imports System.Collections.Generic

Module Module1

    ' Add(Expression, Expression)
    Public Sub Add1()
        '<Snippet1>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  

        ' This expression adds the values of its two arguments.
        ' Both arguments must be of the same type.
        Dim sumExpr As Expression = Expression.Add(
            Expression.Constant(1),
            Expression.Constant(2)
            )

        ' Print the expression.
        Console.WriteLine(sumExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.            
        Console.WriteLine(Expression.Lambda(Of Func(Of Integer))(sumExpr).Compile()())

        ' This code example produces the following output:
        '
        ' (1 + 2)
        ' 3
        '</Snippet1>
    End Sub

    'Expression.And(Expression, Expression)
    Public Sub And1()

        '<Snippet2>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions 

        ' This expression performs a logical AND operation
        ' on its two arguments. Both arguments must be of the same type,
        ' which can be Boolean or integer.             
        Dim andExpr As Expression = Expression.And(
            Expression.Constant(True),
            Expression.Constant(False)
            )

        ' Print the expression.
        Console.WriteLine(andExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.       
        Console.WriteLine(
            Expression.Lambda(Of Func(Of Boolean))(andExpr).Compile()())
        ' This code example produces the following output:
        '
        ' (True And False)
        ' False
        '</Snippet2>
    End Sub

    'Expression.Condition(Expression, Expression, Expression)
    Public Sub Condition1()
        '<Snippet3>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  

        Dim num As Integer = 100

        ' This expression represents a conditional operation; 
        ' it will evaluate the test (first expression) and
        ' execute the ifTrue block (second argument) if the test evaluates to true, 
        ' or the ifFalse block (third argument) if the test evaluates to false.
        Dim conditionExpr As Expression = Expression.Condition(
                                    Expression.Constant(num > 10),
                                    Expression.Constant("n is greater than 10"),
                                    Expression.Constant("n is smaller than 10")
                                )

        ' Print the expression.
        Console.WriteLine(conditionExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.       
        Console.WriteLine(
            Expression.Lambda(Of Func(Of String))(conditionExpr).Compile()())

        ' This code example produces the following output:
        '
        ' IIF("True", "num is greater than 10", "num is smaller than 10")
        ' num is greater than 10
        '</Snippet3>        
    End Sub

    'Expression.Constant(Object)
    Public Sub Constant1()
        '<Snippet4>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions 

        ' This expression represents a constant value.
        Dim constantExpr As Expression = Expression.Constant(5.5)

        ' Print the expression.
        Console.WriteLine(constantExpr.ToString())

        ' You can also use variables.
        Dim num As Double = 3.5
        constantExpr = Expression.Constant(num)
        Console.WriteLine(constantExpr.ToString())

        ' This code example produces the following output:
        '
        ' 5.5
        ' 3.5
        '</Snippet4>  
    End Sub

    Public Sub Decrement1()
        '<Snippet5>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions   

        Dim num As Double = 5.5

        ' This expression represents a decrement operation 
        ' that subtracts 1 from a value. 
        Dim decrementExpr As Expression = Expression.Decrement(
                                    Expression.Constant(num)
                                )

        ' Print the expression.
        Console.WriteLine(decrementExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.
        Console.WriteLine(
            Expression.Lambda(Of Func(Of Double))(decrementExpr).Compile()())

        ' The value of the variable did not change,
        ' because the expression is functional.
        Console.WriteLine("object: " & num)

        ' This code example produces the following output:
        '
        ' Decrement(5.5)
        ' 4.5
        ' object: 5.5
        '</Snippet5>
    End Sub

    'Expression.Default(Type)
    Public Sub Default1()
        '<Snippet6>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  

        ' This expression represents the default value of a type
        ' (0 for integer, null for a string, and so on).
        Dim defaultExpr As Expression = Expression.Default(
                                                GetType(Byte)
                                            )

        ' Print the expression.
        Console.WriteLine(defaultExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.
        Console.WriteLine(
            Expression.Lambda(Of Func(Of Byte))(defaultExpr).Compile()())

        ' This code example produces the following output:
        '
        ' default(Byte)
        ' 0
        '</Snippet6>        
    End Sub

    'Divide(Expression, Expression)
    Public Sub Divide1()
        '<Snippet7>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions   

        ' This expression divides its first argument by its second argument.
        ' Both arguments must be of the same type.
        Dim divideExpr As Expression = Expression.Divide(
            Expression.Constant(10.0),
            Expression.Constant(4.0)
        )

        ' Print the expression.
        Console.WriteLine(divideExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.
        Console.WriteLine(
            Expression.Lambda(Of Func(Of Double))(divideExpr).Compile()())

        ' This code example produces the following output:
        '
        ' (10/4)
        ' 2.5
        '</Snippet7>
    End Sub

    Public Sub Equal1()
        '<Snippet8>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  

        ' This expression compares the values of its two arguments.
        ' Both arguments must be of the same type.
        Dim equalExpr As Expression = Expression.Equal(
            Expression.Constant(42),
            Expression.Constant(45)
        )

        ' Print the expression.
        Console.WriteLine(equalExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.
        Console.WriteLine(
            Expression.Lambda(Of Func(Of Boolean))(equalExpr).Compile()())

        ' This code example produces the following output:
        '
        ' (42 == 45)
        ' False
        '</Snippet8>
    End Sub

    'Expression.ExclusiveOr(Expression, Expression)
    Public Sub ExclusiveOr1()
        '<Snippet9>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions   

        ' This expression represents an exclusive OR operation for its two arguments.
        ' Both arguments must be of the same type, 
        ' which can be either integer or Boolean.

        Dim exclusiveOrExpr As Expression = Expression.ExclusiveOr(
             Expression.Constant(5),
             Expression.Constant(3)
         )

        ' Print the expression.
        Console.WriteLine(exclusiveOrExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.           
        Console.WriteLine(
            Expression.Lambda(Of Func(Of Integer))(exclusiveOrExpr).Compile()())

        ' The XOR operation is performed as follows:
        ' 101 xor 011 = 110

        ' This code example produces the following output:
        '
        ' (5 ^ 3)
        ' 6
        '</Snippet9>
    End Sub

    'GreaterThan(Expression, Expression)
    Public Sub GreaterThan1()
        '<Snippet10>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions 

        ' This expression compares the values of its two arguments.
        ' Both arguments must be of the same type.
        Dim greaterThanExpr As Expression = Expression.GreaterThan(
            Expression.Constant(42),
            Expression.Constant(45)
        )

        ' Print the expression.
        Console.WriteLine(greaterThanExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.    
        Console.WriteLine(
            Expression.Lambda(Of Func(Of Boolean))(greaterThanExpr).Compile()())

        ' This code example produces the following output:
        '
        ' (42 > 45)
        ' False
        '</Snippet10>
    End Sub

    'GreaterThanOrEqual(Expression, Expression)
    Public Sub GreaterThanOrEqual1()
        '<Snippet11>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions 

        ' This expression compares the values of its two arguments.
        ' Both arguments must be of the same type.
        Dim greaterThanOrEqual As Expression = Expression.GreaterThanOrEqual(
             Expression.Constant(42),
             Expression.Constant(45)
         )

        ' Print the expression.
        Console.WriteLine(greaterThanOrEqual.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it. 
        Console.WriteLine(
            Expression.Lambda(Of Func(Of Boolean))(greaterThanOrEqual).Compile()())

        ' This code example produces the following output:
        '
        ' (42 >= 45)
        ' False
        '</Snippet11>        
    End Sub

    Public Sub Assign1()
        '<Snippet12>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions 

        ' To demonstrate the assignment operation, create a variable.
        Dim variableExpr As ParameterExpression = Expression.Variable(GetType(String), "sampleVar")

        ' This expression represents the assignment of a value
        ' to a variable expression.
        ' It copies a value for value types, and it
        ' copies a reference for reference types.
        Dim assignExpr As Expression = Expression.Assign(
            variableExpr,
            Expression.Constant("Hello World!")
            )

        ' The block expression allows for executing several expressions sequentually.
        ' In this block, you pass the variable expression as a parameter,
        ' and then assign this parameter a value in the assign expression.
        Dim blockExpr As Expression = Expression.Block(
              New ParameterExpression() {variableExpr}, assignExpr
              )

        ' Print the assign expression.
        Console.WriteLine(assignExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it. 
        Console.WriteLine(Expression.Lambda(Of Func(Of String))(blockExpr).Compile()())

        ' This code example produces the following output:
        '
        ' (sampleVar = "Hello World!")
        ' Hello World!
        '</Snippet12>
    End Sub

    'Expression.Block(Expression[])
    Public Sub BlockNoParameters()
        '<Snippet13>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions

        ' The block expression enables you to execute several expressions sequentually.
        ' When the block expression is executed,
        ' it returns the value of the last expression in the sequence.
        Dim blockExpr As BlockExpression = Expression.Block(
            Expression.Call(
                Nothing,
                GetType(Console).GetMethod("Write", New Type() {GetType(String)}),
                Expression.Constant("Hello ")
               ),
            Expression.Call(
                Nothing,
                GetType(Console).GetMethod("WriteLine", New Type() {GetType(String)}),
                Expression.Constant("World!")
                ),
            Expression.Constant(42)
        )

        Console.WriteLine("The result of executing the expression tree:")
        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.           
        Dim result = Expression.Lambda(Of Func(Of Integer))(blockExpr).Compile()()

        ' Print the expressions from the block expression.
        Console.WriteLine("The expressions from the block expression:")
        For Each expr In blockExpr.Expressions
            Console.WriteLine(expr.ToString())
        Next

        ' Print the result of the tree execution.
        Console.WriteLine("The return value of the block expression:")
        Console.WriteLine(result)

        ' This code example produces the following output:
        '
        ' The result of executing the expression tree:
        ' Hello World!

        ' The expressions from the block expression:
        ' Write("Hello ")
        ' WriteLine("World!")
        ' 42

        ' The return value of the block expression:
        ' 42
        '</Snippet13>
    End Sub

    'Expression.Block(IEnumerable<ParameterExpression>, Expression[])
    Public Sub BlockWithParameter()
        '<Snippet14>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  


        ' This block has a parameter expression
        ' that represents a variable within the block scope.
        ' It assigns a value to the variable,
        ' and then adds a constant to the assigned value. 

        Dim varExpr As ParameterExpression = Expression.Variable(GetType(Integer), "sampleVar")
        Dim blockExpr As BlockExpression = Expression.Block(
            New ParameterExpression() {varExpr},
            Expression.Assign(varExpr, Expression.Constant(1)),
            Expression.Add(varExpr, Expression.Constant(5))
        )

        ' Print the expressions from the block expression.

        Console.WriteLine("The expressions from the block expression:")
        For Each expr In blockExpr.Expressions
            Console.WriteLine(expr.ToString())
        Next

        Console.WriteLine("The result of executing the expression tree:")

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.
        Console.WriteLine(
            Expression.Lambda(Of Func(Of Integer))(blockExpr).Compile()())

        ' This code example produces the following output:
        '
        ' The expressions from the block expression:
        ' (sampleVar = 1)
        ' (sampleVar + 5)
        ' The result of executing the expression tree:
        ' 6
        '</Snippet14>
    End Sub

    'Call(Expression, MethodInfo)
    Public Sub CallInstnaceNoArguments()
        '<Snippet15>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions   

        ' This expression represents a call to an instance method without arguments.
        Dim callExpr As Expression = Expression.Call(
            Expression.Constant("sample string"), GetType(String).GetMethod("ToUpper", New Type() {}))

        ' Print the expression.
        Console.WriteLine(callExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.  
        Console.WriteLine(Expression.Lambda(Of Func(Of String))(callExpr).Compile()())

        ' This code example produces the following output:
        '
        ' "sample string".ToUpper
        ' SAMPLE STRING

        '</Snippet15>        
    End Sub

    'Call(MethodInfo, Expression)
    Public Class CallStaticOneArgument
        '<Snippet16>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  
        Public Class SampleClass
            Shared Function Increment(ByVal arg1 As Integer) As Integer
                Return arg1 + 1
            End Function
        End Class
        Shared Sub TestCall()
            'This expression represents a call to an instance method with one argument.
            Dim callExpr As Expression = Expression.Call(
                GetType(SampleClass).GetMethod("Increment"),
                Expression.Constant(2))

            ' Print the expression.
            Console.WriteLine(callExpr.ToString())

            ' The following statement first creates an expression tree,
            ' then compiles it, and then executes it.
            Console.WriteLine(Expression.Lambda(Of Func(Of Integer))(callExpr).Compile()())
        End Sub

        ' This code example produces the following output:
        '
        ' Increment(2)
        ' 3

        '</Snippet16>
    End Class

    'Call(Expression, MethodInfo, Expression, Expression)
    Public Class CallInstanceTwoArguments
        '<Snippet17>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  
        Public Class SampleClass
            Public Function AddIntegers(ByVal arg1 As Integer, ByVal arg2 As Integer) As Integer
                Return (arg1 + arg2)
            End Function
        End Class
        Public Shared Sub TestCall()
            ' This expression represents a call to an instance method that has two arguments.
            ' The first argument is an expression that creates a new object of the specified type.
            Dim callExpr As Expression = Expression.Call(
                Expression.[New](GetType(SampleClass)),
                GetType(SampleClass).GetMethod("AddIntegers", New Type() {GetType(Integer), GetType(Integer)}),
                Expression.Constant(1),
                Expression.Constant(2)
              )

            ' Print the expression.
            Console.WriteLine(callExpr.ToString())

            ' The following statement first creates an expression tree,
            ' then compiles it, and then executes it.
            Console.WriteLine(Expression.Lambda(Of Func(Of Integer))(callExpr).Compile()())
        End Sub

        ' This code example produces the following output:
        '
        ' new SampleClass().AddIntegers(1, 2)
        ' 3
        '</Snippet17>
    End Class

    'AddAssign(Expression, Expression)
    Public Sub AddAssign1()
        '<Snippet18>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions 

        ' The parameter expression is used to create a variable.
        Dim variableExpr As ParameterExpression = Expression.Variable(GetType(Integer), "sampleVar")

        ' The block expression enables you to execute several expressions sequentually.
        ' In this block, the variable is first initialized with 1. 
        ' Then the AddAssign method adds 2 to the variable and assigns the result to the variable.
        Dim addAssignExpr As BlockExpression = Expression.Block(
            New ParameterExpression() {variableExpr},
            Expression.Assign(variableExpr, Expression.Constant(1)),
            Expression.AddAssign(
                variableExpr,
                Expression.Constant(2)
            )
        )

        ' Print the expression from the block expression.
        Console.WriteLine("The expressions from the block expression:")
        For Each expr As Expression In addAssignExpr.Expressions
            Console.WriteLine(expr.ToString())
        Next

        Console.WriteLine("The result of executing the expression tree:")
        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.
        Console.WriteLine(Expression.Lambda(Of Func(Of Integer))(addAssignExpr).Compile()())

        ' This code example produces the following output:
        '
        ' The expressions from the block expression:
        ' (sampleVar = 1)
        ' (sampleVar += 2)

        ' The result of executing the expression tree:
        ' 3
        '</Snippet18>
    End Sub

    'Expression.AndAlso(Expression, Expression)
    Public Sub AndAlso1()
        '<Snippet19>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  

        ' This expression performs a logical AND operation
        ' on its two arguments, but if the first argument is false,
        ' the second argument is not evaluated.
        ' Both arguments must be of the Boolean type.
        Dim andAlsoExpr As Expression = Expression.AndAlso(
             Expression.Constant(False),
             Expression.Constant(True)
         )

        ' Print the expression.
        Console.WriteLine(andAlsoExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it. 
        Console.WriteLine(Expression.Lambda(Of Func(Of Boolean))(andAlsoExpr).Compile()())

        ' This code example produces the following output:
        '
        ' (False AndAlso True)
        ' False

        '</Snippet19>        
    End Sub

    'ArrayAccess(Expression, Expression[])
    Public Sub ArrayAccessOneDimensional()
        '<Snippet20>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  

        ' This parameter expression represents a variable that will hold the array.
        Dim arrayExpr As ParameterExpression = Expression.Parameter(GetType(Integer()), "Array")

        ' This parameter expression represents an array index.
        ' For multidimensional arrays, you can define several indexes. 
        Dim indexExpr As ParameterExpression = Expression.Parameter(GetType(Integer), "Index")

        ' This parameter represents the value that will be added to a corresponding array element.
        Dim valueExpr As ParameterExpression = Expression.Parameter(GetType(Integer), "Value")

        ' This expression represents an array access operation.
        ' It can be used for assigning to, or reading from, an array element.
        Dim arrayAccessExpr As Expression = Expression.ArrayAccess(
            arrayExpr,
            indexExpr
        )

        ' This lambda expression assigns a value provided to it to a specified array element.
        ' The array, the index of the array element, and the value to be added to the element
        ' are parameters of the lambda expression.
        Dim lambdaExpr As Expression(Of Func(Of Integer(), Integer, Integer, Integer)) =
            Expression.Lambda(Of Func(Of Integer(), Integer, Integer, Integer))(
                Expression.Assign(arrayAccessExpr, Expression.Add(arrayAccessExpr, valueExpr)),
            arrayExpr,
            indexExpr,
            valueExpr
          )

        ' Print expressions.
        Console.WriteLine("Array Access Expression:")
        Console.WriteLine(arrayAccessExpr.ToString())

        Console.WriteLine("Lambda Expression:")
        Console.WriteLine(lambdaExpr.ToString())

        Console.WriteLine("The result of executing the lambda expression:")

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.
        ' Parameters passed to the Invoke method are passed to the lambda expression.
        Console.WriteLine(lambdaExpr.Compile().Invoke(New Integer() {10, 20, 30}, 0, 5))

        ' This code example produces the following output:
        '
        ' Array Access Expression:
        ' Array[Index]

        ' Lambda Expression:
        ' (Array, Index, Value) => (Array[Index] = (Array[Index] + Value))

        ' The result of executing the lambda expression:
        ' 15
        '</Snippet20>
    End Sub

    'ArrayAccess(Expression, IEnumerable<Expression>)
    Public Sub ArrayAccessMultidimensional()
        '<Snippet21>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  

        ' This parameter expression represents a variable that will hold the two-dimensional array.
        Dim arrayExpr As ParameterExpression = Expression.Parameter(GetType(Integer(,)), "Array")

        ' This parameter expression represents a first array index.            
        Dim firstIndexExpr As ParameterExpression = Expression.Parameter(GetType(Integer), "FirstIndex")
        ' This parameter expression represents a second array index.            
        Dim secondIndexExpr As ParameterExpression = Expression.Parameter(GetType(Integer), "SecondIndex")

        ' The list of indexes.
        Dim indexes As List(Of Expression) = New List(Of Expression) From
            {firstIndexExpr, secondIndexExpr}

        ' This parameter represents the value that will be added to a corresponding array element.
        Dim valueExpr As ParameterExpression = Expression.Parameter(GetType(Integer), "Value")

        ' This expression represents an access operation to a multidimensional array.
        ' It can be used for assigning to, or reading from, an array element.
        Dim arrayAccessExpr As Expression = Expression.ArrayAccess(
            arrayExpr,
            indexes
        )

        ' This lambda expression assigns a value provided to it to a specified array element.
        ' The array, the index of the array element, and the value to be added to the element
        ' are parameters of the lambda expression.
        Dim lambdaExpr As Expression(Of Func(Of Integer(,), Integer, Integer, Integer, Integer)) =
            Expression.Lambda(Of Func(Of Integer(,), Integer, Integer, Integer, Integer))(
                Expression.Assign(arrayAccessExpr, Expression.Add(arrayAccessExpr, valueExpr)),
                arrayExpr,
                firstIndexExpr,
                secondIndexExpr,
                valueExpr
        )

        ' Print expressions.
        Console.WriteLine("Array Access Expression:")
        Console.WriteLine(arrayAccessExpr.ToString())

        Console.WriteLine("Lambda Expression:")
        Console.WriteLine(lambdaExpr.ToString())

        Console.WriteLine("The result of executing the lambda expression:")

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.
        ' Parameters passed to the Invoke method are passed to the lambda expression.
        Dim sampleArray = {{10, 20, 30},
                               {100, 200, 300}}
        Console.WriteLine(lambdaExpr.Compile().Invoke(sampleArray, 1, 1, 5))

        ' This code example produces the following output:
        '
        ' Array Access Expression:
        ' Array[FirstIndex, SecondIndex]

        ' Lambda Expression:
        ' (Array, FirstIndex, SecondIndex Value) => 
        ' (Array[FirstIndex, SecondIndex] = (Array[FirstIndex, SecondIndex] + Value))

        ' The result of executing the lambda expression:
        ' 205

        '</Snippet21>
    End Sub

    'Expression.Constant(Object, Type)
    Public Sub ConstantNull()
        '<Snippet22>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions   

        ' This expression represents a constant value, 
        ' for which you can explicitly specify the type. 
        ' This can be used, for example, for defining constants of a nullable type.
        Dim constantExpr As Expression = Expression.Constant(
                                    Nothing,
                                    GetType(Double?)
                                )

        ' Print the expression.
        Console.WriteLine(constantExpr.ToString())

        ' This code example produces the following output:
        '
        ' null
        '</Snippet22>
    End Sub

    Public Sub Convert1()
        '<Snippet23>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions 

        ' This expression represents a type convertion operation.        
        Dim convertExpr As Expression = Expression.Convert(
                                    Expression.Constant(5.5),
                                    GetType(Int16)
                                )

        ' Print the expression.
        Console.WriteLine(convertExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.
        Console.WriteLine(Expression.Lambda(Of Func(Of Int16))(convertExpr).Compile()())

        ' This code example produces the following output:
        '
        ' Convert(5.5)
        ' 5

        '</Snippet23>
    End Sub

    'Expression.Increment(Expression)
    Public Sub Increment1()
        '<Snippet24>
        'Add the following directive to your file:
        ' Imports System.Linq.Expressions   
        Dim num As Double = 5.5
        ' This expression represents an increment operation. 
        Dim incrementExpr As Expression = Expression.Increment(
                                    Expression.Constant(num)
                                )

        ' Print the expression.
        Console.WriteLine(incrementExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.
        Console.WriteLine(Expression.Lambda(Of Func(Of Double))(incrementExpr).Compile()())

        ' The value of the variable did not change,
        ' because the expression is functional.
        Console.WriteLine("object: " & num)

        ' This code example produces the following output:
        '
        ' Increment(5.5)
        ' 6.5
        ' object: 5.5
        '</Snippet24>
    End Sub

    'LessThan(Expression, Expression)
    Public Sub LessThan1()
        '<Snippet25>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions 

        ' This expression compares the values of its two arguments.
        ' Both arguments must be of the same type.
        Dim lessThanExpr As Expression = Expression.LessThan(
            Expression.Constant(42),
            Expression.Constant(45)
        )

        ' Print the expression.
        Console.WriteLine(lessThanExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.    
        Console.WriteLine(
            Expression.Lambda(Of Func(Of Boolean))(lessThanExpr).Compile()())

        ' This code example produces the following output:
        '
        ' (42 < 45)
        ' True
        '</Snippet25>
    End Sub

    'LessThanOrEqual(Expression, Expression)
    Public Sub LessThanOrEqual1()
        '<Snippet26>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions 

        ' This expression compares the values of its two arguments.
        ' Both arguments must be of the same type.
        Dim lessThanOrEqual As Expression = Expression.LessThanOrEqual(
             Expression.Constant(42),
             Expression.Constant(45)
         )

        ' Print the expression.
        Console.WriteLine(lessThanOrEqual.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it. 
        Console.WriteLine(
            Expression.Lambda(Of Func(Of Boolean))(lessThanOrEqual).Compile()())

        ' This code example produces the following output:
        '
        ' (42 <= 45)
        ' True
        '</Snippet26>        
    End Sub

    'Multiply(Expression, Expression)
    Public Sub Multiply1()
        '<Snippet27>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  

        ' This expression multiplies its two arguments.
        ' Both arguments must be of the same type.
        Dim multiplyExpr As Expression = Expression.Multiply(
            Expression.Constant(10),
            Expression.Constant(4)
        )

        ' Print the expression.
        Console.WriteLine(multiplyExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.
        Console.WriteLine(
            Expression.Lambda(Of Func(Of Integer))(multiplyExpr).Compile()())

        ' This code example produces the following output:
        '
        ' (10*4)
        ' 40
        '</Snippet27>
    End Sub

    'Expression.Or(Expression, Expression)
    Public Sub Or1()
        '<Snippet28>        
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  

        ' This expression perfroms a logical OR operation
        ' on its two arguments. Both arguments must be of the same type,
        ' which can be Boolean or integer.             
        Dim orExpr As Expression = Expression.Or(
             Expression.Constant(True),
             Expression.Constant(False)
         )

        ' Print the expression.
        Console.WriteLine(orExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.       
        Console.WriteLine(Expression.Lambda(Of Func(Of Boolean))(orExpr).Compile()())

        ' This code example produces the following output:
        '
        ' (True Or False)
        ' True
        '</Snippet28>
    End Sub

    'Expression.OrElse(Expression, Expression)
    Public Sub OrElse1()
        '<Snippet29>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  

        ' This expression perfroms a logical OR operation
        ' on its two arguments, but if the first argument is true,
        ' the second arument is not evaluated.
        ' Both arguments must be of the Boolean type.
        Dim orElseExpr As Expression = Expression.OrElse(
             Expression.Constant(False),
             Expression.Constant(True)
         )

        ' Print the expression.
        Console.WriteLine(orElseExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it. 
        Console.WriteLine(Expression.Lambda(Of Func(Of Boolean))(orElseExpr).Compile()())

        ' This code example produces the following output:
        '
        ' (False OrElse True)
        ' True

        '</Snippet29>
    End Sub

    'Substract(Expression, Expression)
    Public Sub Subtract1()
        '<Snippet30>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  

        ' This expression subtracts the second argument 
        ' from the first argument.
        ' Both arguments must be of the same type.
        Dim subtractExpr As Expression = Expression.Subtract(
             Expression.Constant(12),
             Expression.Constant(3)
         )

        ' Print the expression.
        Console.WriteLine(subtractExpr.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it.            
        Console.WriteLine(Expression.Lambda(Of Func(Of Integer))(subtractExpr).Compile()())

        ' This code example produces the following output:
        '
        ' (12 - 3)
        ' 9
        '</Snippet30>
    End Sub

    'Expression.Empty()
    Public Sub Empty1()
        '<Snippet31>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions 

        ' This statement creates an empty expression.
        Dim emptyExpr As DefaultExpression = Expression.Empty()

        ' An empty expression can be used where an expression is expected but no action is desired.
        ' For example, you can use an empty expression as the last expression in a block expression.
        ' In this case, the block expression's return value is void.
        Dim emptyBlock = Expression.Block(emptyExpr)
        '</Snippet31>
    End Sub

    'Expression.IfThen1
    Public Sub IfThen1()
        '<Snippet32>
        ' Add the following directive to the file:
        ' Imports System.Linq.Expressions
        Dim test As Boolean = True

        ' This expression represents the conditional block.
        Dim ifThenExpr As Expression = Expression.IfThen(
             Expression.Constant(test),
             Expression.Call(
                 Nothing,
                 GetType(Console).GetMethod("WriteLine", New Type() {GetType(String)}),
                 Expression.Constant("The condition is true.")
             )
        )

        ' The following statement first creates an expression tree,
        ' then compiles it, and then runs it.
        Expression.Lambda(Of Action)(ifThenExpr).Compile()()

        ' This code example produces the following output:
        '
        ' The condition is true.
        '</Snippet32>
    End Sub

    'Expression.IfThenElse
    Public Sub IfThenElse1()
        '<Snippet33>
        ' Add the following directive to the file:
        ' Imports System.Linq.Expressions
        Dim test As Boolean = True

        ' This expression represents the conditional block.
        Dim ifThenElseExpr As Expression = Expression.IfThenElse(
             Expression.Constant(test),
             Expression.Call(
                 Nothing,
                 GetType(Console).GetMethod("WriteLine", New Type() {GetType(String)}),
                 Expression.Constant("The condition is true.")
             ),
             Expression.Call(
                 Nothing,
                 GetType(Console).GetMethod("WriteLine", New Type() {GetType(String)}),
                 Expression.Constant("The condition is false.")
             )
        )

        ' The following statement first creates an expression tree,
        ' then compiles it, and then runs it.
        Expression.Lambda(Of Action)(ifThenElseExpr).Compile()()

        ' This code example produces the following output:
        '
        ' The condition is true.
        '</Snippet33>
    End Sub

    'Expression.Switch with no default case
    Public Sub SwitchNoDefault()
        '<Snippet34>
        ' Add the following directive to the file:
        ' Imports System.Linq.Expressions

        ' An expression that represents the switch value.
        Dim switchValue As ConstantExpression = Expression.Constant(2)

        ' This expression represents a switch statement 
        ' without a default case.
        Dim switchExpr As SwitchExpression =
        Expression.Switch(
            switchValue,
            New SwitchCase() {
                Expression.SwitchCase(
                    Expression.Call(
                        Nothing,
                        GetType(Console).GetMethod("WriteLine", New Type() {GetType(String)}),
                        Expression.Constant("First")
                    ),
                    Expression.Constant(1)
                ),
                Expression.SwitchCase(
                    Expression.Call(
                        Nothing,
                        GetType(Console).GetMethod("WriteLine", New Type() {GetType(String)}),
                        Expression.Constant("Second")
                    ),
                    Expression.Constant(2)
                )
            }
        )

        ' The following statement first creates an expression tree,
        ' then compiles it, and then runs it.
        Expression.Lambda(Of Action)(switchExpr).Compile()()

        ' This code example produces the following output:
        '
        ' Second
        '</Snippet34>
    End Sub

    'Expression.Switch with default case
    Public Sub SwitchWithDefault()
        '<Snippet35>
        ' Add the following directive to the file:
        ' Imports System.Linq.Expressions

        ' An expression that represents the switch value.
        Dim switchValue As ConstantExpression = Expression.Constant(3)

        ' This expression represents a switch statement 
        ' that has a default case.
        Dim switchExpr As SwitchExpression =
        Expression.Switch(
            switchValue,
            Expression.Call(
                        Nothing,
                        GetType(Console).GetMethod("WriteLine", New Type() {GetType(String)}),
                        Expression.Constant("Default")
                    ),
            New SwitchCase() {
                Expression.SwitchCase(
                    Expression.Call(
                        Nothing,
                        GetType(Console).GetMethod("WriteLine", New Type() {GetType(String)}),
                        Expression.Constant("First")
                    ),
                    Expression.Constant(1)
                ),
                Expression.SwitchCase(
                    Expression.Call(
                        Nothing,
                        GetType(Console).GetMethod("WriteLine", New Type() {GetType(String)}),
                        Expression.Constant("Second")
                    ),
                    Expression.Constant(2)
                )
            }
        )

        ' The following statement first creates an expression tree,
        ' then compiles it, and then runs it.
        Expression.Lambda(Of Action)(switchExpr).Compile()()

        ' This code example produces the following output:
        '
        ' Default
        '</Snippet35>
    End Sub

    Sub Type1()
        '<Snippet36>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  

        Dim constExpr As ConstantExpression = Expression.Constant(5)
        Console.WriteLine("NodeType: " & constExpr.NodeType.ToString())
        Console.WriteLine("Type: " & constExpr.Type.ToString())

        Dim binExpr As BinaryExpression = Expression.Add(constExpr, constExpr)
        Console.WriteLine("NodeType: " & binExpr.NodeType.ToString())
        Console.WriteLine("Type: " & binExpr.Type.ToString())

        ' This code example produces the following output:
        '
        ' NodeType: Constant
        ' Type: System.Int32
        ' NodeType: Add
        ' Type: System.Int32
        '</Snippet36>
    End Sub

    '<Snippet37>
    ' Add the following directive to your file:
    ' Imports System.Linq.Expressions

    Class TestFieldClass
        Dim sample As Integer = 40
    End Class

    Sub TestField()

        Dim obj As New TestFieldClass()

        ' This expression represents accessing a field.
        ' For static fields, the first parameter must be Nothing.
        Dim fieldExpr As Expression = Expression.Field(
              Expression.Constant(obj),
              "sample"
          )

        ' The following statement first creates an expression tree,
        ' then compiles it, and then runs it.
        Console.WriteLine(Expression.Lambda(Of Func(Of Integer))(fieldExpr).Compile()())
    End Sub

    ' This code example produces the following output:
    '
    ' 40
    '</Snippet37>

    '<Snippet38>
    ' Add the following directive to your file:
    ' Imports System.Linq.Expressions  

    Class TestPropertyClass
        Public Property Sample As Integer
    End Class

    Sub TestProperty()

        Dim obj As New TestPropertyClass()
        obj.Sample = 40

        ' This expression represents accessing a property.
        ' For static properties, the first parameter must be Nothing.
        Dim propertyExpr As Expression = Expression.Property(
              Expression.Constant(obj),
              "sample"
          )

        ' The following statement first creates an expression tree,
        ' then compiles it, and then runs it.
        Console.WriteLine(Expression.Lambda(Of Func(Of Integer))(propertyExpr).Compile()())
    End Sub

    ' This code example produces the following output:
    '
    ' 40
    '</Snippet38>

    '<Snippet39>
    ' Add the following directive to your file:
    ' Imports System.Linq.Expressions  

    Class TestClass
        Public Property Sample As Integer
    End Class

    Sub TestPropertyOrField()

        Dim obj As New TestClass()
        obj.Sample = 40

        ' This expression represents accessing a property or field.
        ' For static properties or fields, the first parameter must be Nothing.
        Dim memberExpr As Expression = Expression.PropertyOrField(
              Expression.Constant(obj),
              "Sample"
          )

        ' The following statement first creates an expression tree,
        ' then compiles it, and then runs it.
        Console.WriteLine(Expression.Lambda(Of Func(Of Integer))(memberExpr).Compile()())
    End Sub

    ' This code example produces the following output:
    '
    ' 40
    '</Snippet39>

    '<Snippet40>
    ' Add the following directive to your file:
    ' Imports System.Linq.Expressions  

    Class TestMemberInitClass
        Public Property Sample As Integer
    End Class

    Sub MemberInit()
        ' This expression creates a new TestMemberInitClass object
        ' and assigns 10 to its Sample property.
        Dim testExpr As Expression = Expression.MemberInit(
            Expression.[New](GetType(TestMemberInitClass)),
            New List(Of MemberBinding)() From {
                Expression.Bind(GetType(TestMemberInitClass).GetMember("Sample")(0), Expression.Constant(10))
            }
        )

        ' The following statement first creates an expression tree,
        ' then compiles it, and then runs it.
        Dim test = Expression.Lambda(Of Func(Of TestMemberInitClass))(testExpr).Compile()()
        Console.WriteLine(test.Sample)
    End Sub

    ' This code example produces the following output:
    '
    ' 10
    '</Snippet40>

    'Expression.Lambda
    Sub TestLambda()
        '<Snippet42>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  

        ' A parameter for the lambda expression.
        Dim paramExpr As ParameterExpression = Expression.Parameter(GetType(Integer), "arg")

        ' This expression represents a lambda expression
        ' that adds 1 to the parameter value.
        Dim lambdaExpr As LambdaExpression = Expression.Lambda(
                Expression.Add(
                    paramExpr,
                    Expression.Constant(1)
                ),
                New List(Of ParameterExpression)() From {paramExpr}
            )

        ' Print out the expression.
        Console.WriteLine(lambdaExpr)

        ' Compile and run the lamda expression.
        ' The value of the parameter is 1.
        Console.WriteLine(lambdaExpr.Compile().DynamicInvoke(1))

        ' This code example produces the following output:
        '
        ' arg => (arg +1)
        ' 2
        '</Snippet42>
    End Sub

    Sub TestReturn()
        '<Snippet43>
        ' Add the following directive to the file:
        ' Imports System.Linq.Expressions  
        ' A label expression of the void type that is the target for Expression.Return().
        Dim returnTarget As LabelTarget = Expression.Label()

        ' This block contains a GotoExpression that represents a return statement with no value.
        ' It transfers execution to a label expression that is initialized with the same LabelTarget as the GotoExpression.
        ' The types of the GotoExpression, label expression, and LabelTarget must match.
        Dim blockExpr As BlockExpression =
              Expression.Block(
                  Expression.Call(GetType(Console).GetMethod("WriteLine", New Type() {GetType(String)}), Expression.Constant("Return")),
                  Expression.Return(returnTarget),
                  Expression.Call(GetType(Console).GetMethod("WriteLine", New Type() {GetType(String)}), Expression.Constant("Other Work")),
                  Expression.Label(returnTarget)
              )

        ' The following statement first creates an expression tree,
        ' then compiles it, and then runs it.
        Expression.Lambda(Of Action)(blockExpr).Compile()()

        ' This code example produces the following output:
        '
        ' Return

        ' "Other Work" is not printed because 
        ' the Return expression transfers execution from Return(returnTarget)
        ' to Expression.Label(returnTarget).
        '</Snippet43>
    End Sub

    Sub TestLoop()
        '<Snippet44>
        ' Add the following directive to the file:
        ' Imports System.Linq.Expressions  
        ' Creating a parameter expression.
        Dim value As ParameterExpression =
            Expression.Parameter(GetType(Integer), "value")

        ' Creating an expression to hold a local variable. 
        Dim result As ParameterExpression =
            Expression.Parameter(GetType(Integer), "result")

        ' Creating a label to jump to from a loop.
        Dim label As LabelTarget = Expression.Label(GetType(Integer))

        ' Creating a method body.
        Dim block As BlockExpression = Expression.Block(
            New ParameterExpression() {result},
            Expression.Assign(result, Expression.Constant(1)),
            Expression.Loop(
                Expression.IfThenElse(
                    Expression.GreaterThan(value, Expression.Constant(1)),
                    Expression.MultiplyAssign(result,
                        Expression.PostDecrementAssign(value)),
                    Expression.Break(label, result)
                ),
                label
            )
        )

        ' Compile an expression tree and return a delegate.
        Dim factorial As Integer =
            Expression.Lambda(Of Func(Of Integer, Integer))(block, value).Compile()(5)

        Console.WriteLine(factorial)

        ' This code example produces the following output:
        '
        ' 120
        '</Snippet44>
    End Sub

    Sub TestGoTo()
        '<Snippet45>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  

        ' A label expression of the void type that is the target for the GoToExpression.
        Dim returnTarget As LabelTarget = Expression.Label()

        ' This block contains a GotoExpression.
        ' It transfers execution to a label expression that is initialized with the same LabelTarget as the GotoExpression.
        ' The types of the GotoExpression, label expression, and LabelTarget must match.
        Dim blockExpr As BlockExpression =
              Expression.Block(
                  Expression.Call(GetType(Console).GetMethod("WriteLine", New Type() {GetType(String)}), Expression.Constant("GoTo")),
                  Expression.Goto(returnTarget),
                  Expression.Call(GetType(Console).GetMethod("WriteLine", New Type() {GetType(String)}), Expression.Constant("Other Work")),
                  Expression.Label(returnTarget)
              )

        ' The following statement first creates an expression tree,
        ' then compiles it, and then runs it.
        Expression.Lambda(Of Action)(blockExpr).Compile()()

        ' This code example produces the following output:
        '
        ' GoTo

        ' "Other Work" is not printed because 
        ' the Return expression transfers execution from Expression.GoTo(returnTarget)
        ' to Expression.Label(returnTarget).
        '</Snippet45>
    End Sub

    Public Sub TestContinue()
        '<Snippet46>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  

        ' A label that is used by a break statement and a loop. 
        Dim breakLabel As LabelTarget = Expression.Label()

        ' A label that is used by the Continue statement and the loop it refers to.
        Dim continueLabel As LabelTarget = Expression.Label()

        ' This expression represents a Continue statement.
        Dim continueExpr As Expression = Expression.Continue(continueLabel)

        ' A variable that triggers the exit from the loop.
        Dim count As ParameterExpression = Expression.Parameter(GetType(Integer))

        ' A loop statement.
        Dim loopExpr As Expression = Expression.Loop(
               Expression.Block(
                   Expression.IfThen(
                       Expression.GreaterThan(count, Expression.Constant(3)),
                       Expression.Break(breakLabel)
                   ),
                   Expression.PreIncrementAssign(count),
                   Expression.Call(
                               Nothing,
                               GetType(Console).GetMethod("WriteLine", New Type() {GetType(String)}),
                               Expression.Constant("Loop")
                           ),
                   continueExpr,
                   Expression.PreDecrementAssign(count)
               ),
               breakLabel,
               continueLabel
           )

        ' The following statement first creates an expression tree,
        ' then compiles it, and then runs it.
        ' Without the Continue statement, the loop would go on forever.
        Expression.Lambda(Of Action(Of Integer))(loopExpr, count).Compile()(1)

        ' This code example produces the following output:
        '
        ' Loop
        ' Loop
        ' Loop
        '</Snippet46>
    End Sub

    Sub TestTryCatch()
        '<Snippet47>
        ' Add the following directive to the file:
        ' Imports System.Linq.Expressions 

        ' A TryExpression object that has a Catch statement.
        ' The return types of the Try block and all Catch blocks must be the same.
        Dim tryCatchExpr As TryExpression =
               Expression.TryCatch(
                   Expression.Block(
                       Expression.Throw(Expression.Constant(New DivideByZeroException())),
                       Expression.Constant("Try block")
                   ),
                   Expression.Catch(
                       GetType(DivideByZeroException),
                       Expression.Constant("Catch block")
                   )
               )

        ' The following statement first creates an expression tree,
        ' then compiles it, and then runs it.
        ' If the exception is caught, 
        ' the result of the TryExpression is the last statement 
        ' of the corresponding Catch statement.
        Console.WriteLine(Expression.Lambda(Of Func(Of String))(tryCatchExpr).Compile()())

        ' This code example produces the following output:
        '
        ' Catch block
        '</Snippet47>
    End Sub

    Sub TryCatchFinallyTest()
        '<Snippet48>
        ' Add the following directive to the file:
        ' Imports System.Linq.Expressions 

        ' A TryExpression object that has a catch statement and a finally statement.
        ' The return types of the try block and all catch blocks must be the same.
        Dim tryCatchExpr As TryExpression =
            Expression.TryCatchFinally(
                Expression.Block(
                    Expression.Throw(Expression.Constant(New DivideByZeroException())),
                    Expression.Constant("Try block")
                 ),
            Expression.Call(
                GetType(Console).GetMethod("WriteLine", New Type() {GetType(String)}),
                Expression.Constant("Finally block")
            ),
            Expression.Catch(
                GetType(DivideByZeroException),
                Expression.Constant("Catch block")
            )
        )

        ' The following statement first creates an expression tree,
        ' then compiles it, and then runs it.
        ' If the exception is caught, 
        ' the result of the TryExpression is the last statement 
        ' of the corresponding catch statement.
        Console.WriteLine(Expression.Lambda(Of Func(Of String))(tryCatchExpr).Compile()())

        ' This code example produces the following output:
        '
        ' Finally block
        ' Catch block

        '</Snippet48>
    End Sub

    Sub TestParam()
        '<Snippet49>
        ' Add the following directive to the file:
        ' Imports System.Linq.Expressions 

        ' Creating a parameter for the expression tree.
        Dim param As ParameterExpression = Expression.Parameter(GetType(Integer))

        ' Creating an expression for the method call and specifying its parameter.
        Dim methodCall As MethodCallExpression = Expression.Call(
                GetType(Console).GetMethod("WriteLine", New Type() {GetType(Integer)}),
                param
            )

        ' Compiling and invoking the methodCall expression.
        Expression.Lambda(Of Action(Of Integer))(
            methodCall,
            New ParameterExpression() {param}
        ).Compile()(10)
        ' This code example produces the following output:
        '
        ' 10
        '</Snippet49>
    End Sub

    Sub TestNegate()
        '<Snippet50>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions 

        ' This expression represents a negation operation.
        Dim negateExpr As Expression = Expression.Negate(Expression.Constant(5))

        ' The following statement first creates an expression tree,
        ' then compiles it, and then runs it.
        Console.WriteLine(Expression.Lambda(Of Func(Of Integer))(negateExpr).Compile()())

        ' This code example produces the following output:
        '
        ' -5
        '</Snippet50>
    End Sub

    Sub TestNot()
        '<Snippet51>
        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions 

        ' This expression represents a NOT operation.
        Dim notExpr As Expression = Expression.Not(Expression.Constant(True))

        Console.WriteLine(notExpr)
        ' The following statement first creates an expression tree,
        ' then compiles it, and then runs it.
        Console.WriteLine(Expression.Lambda(Of Func(Of Boolean))(notExpr).Compile()())

        ' This code example produces the following output:
        '
        ' Not(True)
        ' False
        '</Snippet51>
    End Sub

    Sub Main()
        'Add1()
        'And1()
        'Condition1()
        'Constant1()
        'Decrement1()
        'Default1()
        'Divide1()
        'Equal1()
        'ExclusiveOr1()
        'GreaterThan1()
        'GreaterThanOrEqual1()
        'Assign1()
        'BlockNoParameters()
        'BlockWithParameter()
        'CallInstnaceNoArguments()
        'CallStaticOneArgument.TestCall()
        'CallInstanceTwoArguments.TestCall()
        'AddAssign1()
        'AndAlso1()
        'ArrayAccessOneDimensional()
        'ArrayAccessMultidimensional()
        'ConstantNull()
        'Increment1()
        'LessThan1()
        'LessThanOrEqual1()
        'Multiply1()
        'Or1()
        'OrElse1()
        'Subtract1()
        'Empty1()
        'IfThen1()
        'IfThenElse1()
        'SwitchNoDefault()
        'SwitchWithDefault()
        'Type1()
        'TestField()
        'TestProperty()
        'TestPropertyOrField()
        'MemberInit()
        'MemberBind???
        'TestLambda()
        'TestReturn()
        'TestLoop()
        'TestGoTo()
        'TestContinue()
        TestTryCatch()
        TryCatchFinallyTest()
        TestParam()
        TestNegate()
        TestNot()
        Console.WriteLine("Visual Basic")
        Console.ReadLine()
    End Sub
End Module
