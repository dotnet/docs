using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace ExpressionTreesCSharp
{
    class Program
    {
        //Add(Expression, Expression)
        static public void Add1()
        {
            //<Snippet1>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression adds the values of its two arguments.
            // Both arguments must be of the same type.
            Expression sumExpr = Expression.Add(
                Expression.Constant(1),
                Expression.Constant(2)
            );

            // Print out the expression.
            Console.WriteLine(sumExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.            
            Console.WriteLine(Expression.Lambda<Func<int>>(sumExpr).Compile()());

            // This code example produces the following output:
            //
            // (1 + 2)
            // 3
            //</Snippet1>
        }

        //Expression.And(Expression, Expression)
        static public void And1()
        {
            //<Snippet2>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression perfroms a logical AND operation
            // on its two arguments. Both arguments must be of the same type,
            // which can be boolean or integer.             
            Expression andExpr = Expression.And(
                Expression.Constant(true),
                Expression.Constant(false)
            );

            // Print out the expression.
            Console.WriteLine(andExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.       
            Console.WriteLine(Expression.Lambda<Func<bool>>(andExpr).Compile()());

            // This code example produces the following output:
            //
            // (True And False)
            // False
            //</Snippet2>
        }

        //Expression.Condition(Expression, Expression, Expression)
        static public void Condition1()
        {
            //<Snippet3>
            // Add the following directive to your file:
            // using System.Linq.Expressions; 

            int num = 100;

            // This expression represents a conditional operation. 
            // It evaluates the test (first expression) and
            // executes the iftrue block (second argument) if the test evaluates to true, 
            // or the iffalse block (third argument) if the test evaluates to false.
            Expression conditionExpr = Expression.Condition(
                                       Expression.Constant(num > 10),
                                       Expression.Constant("num is greater than 10"),
                                       Expression.Constant("num is smaller than 10")
                                     );

            // Print out the expression.
            Console.WriteLine(conditionExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.       
            Console.WriteLine(
                Expression.Lambda<Func<string>>(conditionExpr).Compile()());

            // This code example produces the following output:
            //
            // IIF("True", "num is greater than 10", "num is smaller than 10")
            // num is greater than 10
            //</Snippet3>
        }

        //Expression.Constant(Object)
        static public void Constant1()
        {
            //<Snippet4>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression represents a Constant value.
            Expression constantExpr = Expression.Constant(5.5);

            // Print out the expression.
            Console.WriteLine(constantExpr.ToString());

            // You can also use variables.
            double num = 3.5;
            constantExpr = Expression.Constant(num);
            Console.WriteLine(constantExpr.ToString());

            // This code example produces the following output:
            //
            // 5.5
            // 3.5
            //</Snippet4>
        }

        //Expression.Decrement(Expression)
        static public void Decrement1()
        {
            //<Snippet5>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            double num = 5.5;

            // This expression represents a decrement operation 
            // that subtracts 1 from a value. 
            Expression decrementExpr = Expression.Decrement(
                                        Expression.Constant(num)
                                    );

            // Print expression.
            Console.WriteLine(decrementExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.
            Console.WriteLine(
                Expression.Lambda<Func<double>>(decrementExpr).Compile()());

            // The value of the variable did not change,
            // because the expression is functional.
            Console.WriteLine("object: " + num);

            // This code example produces the following output:
            //
            // Decrement(5.5)
            // 4.5
            // object: 5.5
            //</Snippet5>
        }

        //Expression.Default(Type)
        static public void Default1()
        {
            //<Snippet6>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression represents the default value of a type
            // (0 for integer, null for a string, etc.)
            Expression defaultExpr = Expression.Default(
                                        typeof(byte)
                                    );

            // Print out the expression.
            Console.WriteLine(defaultExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.
            Console.WriteLine(
                Expression.Lambda<Func<byte>>(defaultExpr).Compile()());

            // This code example produces the following output:
            //
            // default(Byte)
            // 0
            //</Snippet6>
        }

        //Divide(Expression, Expression)
        public static void Divide1()
        {
            //<Snippet7>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression divides its first argument by its second argument.
            // Both arguments must be of the same type.
            Expression divideExpr = Expression.Divide(
                Expression.Constant(10.0),
                Expression.Constant(4.0)
            );

            // Print out the expression.
            Console.WriteLine(divideExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.
            Console.WriteLine(
                Expression.Lambda<Func<double>>(divideExpr).Compile()());

            // This code example produces the following output:
            //
            // (10/4)
            // 2.5
            //</Snippet7>
        }

        static public void Equal1()
        {
            //<Snippet8>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression compares the values of its two arguments.
            // Both arguments need to be of the same type.
            Expression equalExpr = Expression.Equal(
                Expression.Constant(42),
                Expression.Constant(45)
            );

            // Print out the expression.
            Console.WriteLine(equalExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.
            Console.WriteLine(
                Expression.Lambda<Func<bool>>(equalExpr).Compile()());

            // This code example produces the following output:
            //
            // (42 == 45)
            // False
            //</Snippet8>
        }

        //Expression.ExclusiveOr(Expression, Expression)
        static public void ExclusiveOr1()
        {
            //<Snippet9>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression represents an exclusive OR operation for its two arguments.
            // Both arguments must be of the same type, 
            // which can be either integer or boolean.

            Expression exclusiveOrExpr = Expression.ExclusiveOr(
                Expression.Constant(5),
                Expression.Constant(3)
            );

            // Print out the expression.
            Console.WriteLine(exclusiveOrExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.           
            Console.WriteLine(
                Expression.Lambda<Func<int>>(exclusiveOrExpr).Compile()());

            // The XOR operation is performed as follows:
            // 101 xor 011 = 110

            // This code example produces the following output:
            //
            // (5 ^ 3)
            // 6
            //</Snippet9>

        }

        //GreaterThan(Expression, Expression)
        static public void GreaterThan1()
        {
            //<Snippet10>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression compares the values of its two arguments.
            // Both arguments must be of the same type.
            Expression greaterThanExpr = Expression.GreaterThan(
                Expression.Constant(42),
                Expression.Constant(45)
            );

            // Print out the expression.
            Console.WriteLine(greaterThanExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.    
            Console.WriteLine(
                Expression.Lambda<Func<bool>>(greaterThanExpr).Compile()());

            // This code example produces the following output:
            //
            // (42 > 45)
            // False
            //</Snippet10>
        }

        //GreaterThanOrEqual(Expression, Expression)
        static public void GreaterThanOrEqual1()
        {
            //<Snippet11>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression compares the values of its two arguments.
            // Both arguments must be of the same type.
            Expression greaterThanOrEqual = Expression.GreaterThanOrEqual(
                Expression.Constant(42),
                Expression.Constant(45)
            );

            // Print out the expression.
            Console.WriteLine(greaterThanOrEqual.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it. 
            Console.WriteLine(Expression.Lambda<Func<bool>>(greaterThanOrEqual).Compile()());

            // This code example produces the following output:
            //
            // (42 >= 45)
            // False
            //</Snippet11>
        }

        static public void Assign1()
        {
            //<Snippet12>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // To demonstrate the assignment operation, we create a variable.
            ParameterExpression variableExpr = Expression.Variable(typeof(String), "sampleVar");

            // This expression represents the assignment of a value
            // to a variable expression.
            // It copies a value for value types, and
            // copies a reference for reference types.
            Expression assignExpr = Expression.Assign(
                variableExpr,
                Expression.Constant("Hello World!")
                );

            // The block expression allows for executing several expressions sequentually.
            // In this block, we pass the variable expression as a parameter,
            // and then assign this parameter a value in the assign expression.
            Expression blockExpr = Expression.Block(
                new ParameterExpression[] { variableExpr },
                assignExpr
                );

            // Print out the assign expression.
            Console.WriteLine(assignExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.  
            Console.WriteLine(Expression.Lambda<Func<String>>(blockExpr).Compile()());

            // This code example produces the following output:
            //
            // (sampleVar = "Hello World!")
            // Hello World!

            //</Snippet12>
        }

        //Expression.Block(Expression[])
        static public void BlockNoParameters()
        {
            //<Snippet13>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // The block expression allows for executing several expressions sequentually.
            // When the block expression is executed,
            // it returns the value of the last expression in the sequence.
            BlockExpression blockExpr = Expression.Block(
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("Write", new Type[] { typeof(String) }),
                    Expression.Constant("Hello ")
                   ),
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
                    Expression.Constant("World!")
                    ),
                Expression.Constant(42)
            );

            Console.WriteLine("The result of executing the expression tree:");
            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.           
            var result = Expression.Lambda<Func<int>>(blockExpr).Compile()();

            // Print out the expressions from the block expression.
            Console.WriteLine("The expressions from the block expression:");
            foreach (var expr in blockExpr.Expressions)
                Console.WriteLine(expr.ToString());

            // Print out the result of the tree execution.
            Console.WriteLine("The return value of the block expression:");
            Console.WriteLine(result);

            // This code example produces the following output:
            //
            // The result of executing the expression tree:
            // Hello World!

            // The expressions from the block expression:
            // Write("Hello ")
            // WriteLine("World!")
            // 42

            // The return value of the block expression:
            // 42
            //</Snippet13>
        }

        //Expression.Block(IEnumerable<ParameterExpression>, Expression[])
        static public void BlockWithParameter()
        {
            //<Snippet14>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  


            // This block has a parameter expression
            // that represents a variable within the block scope.
            // It assigns a value to the variable,
            // and then adds a constant to the assigned value. 

            ParameterExpression varExpr = Expression.Variable(typeof(int), "sampleVar");
            BlockExpression blockExpr = Expression.Block(
                new ParameterExpression[] { varExpr },
                Expression.Assign(varExpr, Expression.Constant(1)),
                Expression.Add(varExpr, Expression.Constant(5))
            );

            // Print out the expressions from the block expression.
            Console.WriteLine("The expressions from the block expression:");
            foreach (var expr in blockExpr.Expressions)
                Console.WriteLine(expr.ToString());

            Console.WriteLine("The result of executing the expression tree:");
            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.
            Console.WriteLine(
                Expression.Lambda<Func<int>>(blockExpr).Compile()());

            // This code example produces the following output:
            // The expressions from the block expression:
            // (sampleVar = 1)
            // (sampleVar + 5)
            // The result of executing the expression tree:
            // 6

            //</Snippet14>
        }

        //Call(Expression, MethodInfo)
        static public void CallInstnaceNoArguments()
        {
            //<Snippet15>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression represents a call to an instance method without arguments.
            Expression callExpr = Expression.Call(
                Expression.Constant("sample string"), typeof(String).GetMethod("ToUpper", new Type[] { }));

            // Print out the expression.
            Console.WriteLine(callExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.  
            Console.WriteLine(Expression.Lambda<Func<String>>(callExpr).Compile()());

            // This code example produces the following output:
            //
            // "sample string".ToUpper
            // SAMPLE STRING

            //</Snippet15>
        }

        //Call(MethodInfo, Expression)
        public class CallStaticOneArgument
        {
            //<Snippet16>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            public class SampleClass
            {
                public static int Increment(int arg1)
                {
                    return arg1 + 1;
                }
            }

            static public void TestCall()
            {

                //This expression represents a call to an instance method with one argument.
                Expression callExpr = Expression.Call(
                                        typeof(SampleClass).GetMethod("Increment"),
                                        Expression.Constant(2)
                                    );

                // Print out the expression.
                Console.WriteLine(callExpr.ToString());

                // The following statement first creates an expression tree,
                // then compiles it, and then executes it.
                Console.WriteLine(Expression.Lambda<Func<int>>(callExpr).Compile()());

                // This code example produces the following output:
                //
                // Increment(2)
                // 3
            }
            //</Snippet16>
        }

        //Call(Expression, MethodInfo, Expression, Expression)
        public class CallInstanceTwoArguments
        {
            //<Snippet17>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  
            public class SampleClass
            {
                public int AddIntegers(int arg1, int arg2)
                {
                    return arg1 + arg2;
                }
            }

            static public void TestCall()
            {
                // This expression represents a call to an instance method that has two arguments.
                // The first argument is an expression that creates a new object of the specified type.
                Expression callExpr = Expression.Call(
                    Expression.New(typeof(SampleClass)),
                    typeof(SampleClass).GetMethod("AddIntegers", new Type[] { typeof(int), typeof(int) }),
                    Expression.Constant(1),
                    Expression.Constant(2)
                    );

                // Print out the expression.
                Console.WriteLine(callExpr.ToString());

                // The following statement first creates an expression tree,
                // then compiles it, and then executes it.
                Console.WriteLine(Expression.Lambda<Func<int>>(callExpr).Compile()());

                // This code example produces the following output:
                //
                // new SampleClass().AddIntegers(1, 2)
                // 3
            }
            //</Snippet17>
        }

        //AddAssign(Expression, Expression)
        public static void AddAssign1()
        {
            //<Snippet18>
            // Add the following directive to your file:
            // using System.Linq.Expressions;

            // The Parameter expression is used to create a variable.
            ParameterExpression variableExpr = Expression.Variable(typeof(int), "sampleVar");

            // The block expression enables you to execute several expressions sequentually.
            // In this bloc, the variable is first initialized with 1. 
            // Then the AddAssign method adds 2 to the variable and assigns the result to the variable.
            BlockExpression addAssignExpr = Expression.Block(
                new ParameterExpression[] { variableExpr },
                Expression.Assign(variableExpr, Expression.Constant(1)),
                Expression.AddAssign(
                    variableExpr,
                    Expression.Constant(2)
                )
            );

            // Print out the expression from the block expression.
            Console.WriteLine("The expressions from the block expression:");
            foreach (var expr in addAssignExpr.Expressions)
                Console.WriteLine(expr.ToString());

            Console.WriteLine("The result of executing the expression tree:");
            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.
            Console.WriteLine(Expression.Lambda<Func<int>>(addAssignExpr).Compile()());

            // This code example produces the following output:
            //
            // The expressions from the block expression:
            // (sampleVar = 1)
            // (sampleVar += 2)

            // The result of executing the expression tree:
            // 3
            //</Snippet18>

        }

        //Expression.AndAlso(Expression, Expression)
        static public void AndAlso1()
        {
            //<Snippet19>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression perfroms a logical AND operation
            // on its two arguments, but if the first argument is false,
            // then the second arument is not evaluated.
            // Both arguments must be of the boolean type.
            Expression andAlsoExpr = Expression.AndAlso(
                Expression.Constant(false),
                Expression.Constant(true)
            );

            // Print out the expression.
            Console.WriteLine(andAlsoExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it. 
            Console.WriteLine(Expression.Lambda<Func<bool>>(andAlsoExpr).Compile()());

            // This code example produces the following output:
            //
            // (False AndAlso True)
            // False

            //</Snippet19>
        }

        //ArrayAccess(Expression, Expression[])
        static public void ArrayAccessOneDimensional()
        {
            //<Snippet20>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This parameter expression represents a variable that will hold the array.
            ParameterExpression arrayExpr = Expression.Parameter(typeof(int[]), "Array");

            // This parameter expression represents an array index.            
            ParameterExpression indexExpr = Expression.Parameter(typeof(int), "Index");

            // This parameter represents the value that will be added to a corresponding array element.
            ParameterExpression valueExpr = Expression.Parameter(typeof(int), "Value");

            // This expression represents an array access operation.
            // It can be used for assigning to, or reading from, an array element.
            Expression arrayAccessExpr = Expression.ArrayAccess(
                arrayExpr,
                indexExpr
            );

            // This lambda expression assigns a value provided to it to a specified array element.
            // The array, the index of the array element, and the value to be added to the element
            // are parameters of the lambda expression.
            Expression<Func<int[], int, int, int>> lambdaExpr = Expression.Lambda<Func<int[], int, int, int>>(
                Expression.Assign(arrayAccessExpr, Expression.Add(arrayAccessExpr, valueExpr)),
                arrayExpr,
                indexExpr,
                valueExpr
            );

            // Print out expressions.
            Console.WriteLine("Array Access Expression:");
            Console.WriteLine(arrayAccessExpr.ToString());

            Console.WriteLine("Lambda Expression:");
            Console.WriteLine(lambdaExpr.ToString());

            Console.WriteLine("The result of executing the lambda expression:");

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.
            // Parameters passed to the Invoke method are passed to the lambda expression.
            Console.WriteLine(lambdaExpr.Compile().Invoke(new int[] { 10, 20, 30 }, 0, 5));

            // This code example produces the following output:
            //
            // Array Access Expression:
            // Array[Index]

            // Lambda Expression:
            // (Array, Index, Value) => (Array[Index] = (Array[Index] + Value))

            // The result of executing the lambda expression:
            // 15

            //</Snippet20>
        }

        //ArrayAccess(Expression, IEnumerable<Expression>)
        static public void ArrayAccessMultidimensional()
        {
            //<Snippet21>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This parameter expression represents a variable that will hold the two-dimensional array.
            ParameterExpression arrayExpr = Expression.Parameter(typeof(int[,]), "Array");

            // This parameter expression represents a first array index.            
            ParameterExpression firstIndexExpr = Expression.Parameter(typeof(int), "FirstIndex");
            // This parameter expression represents a second array index.            
            ParameterExpression secondIndexExpr = Expression.Parameter(typeof(int), "SecondIndex");

            // The list of indexes.
            List<Expression> indexes = new List<Expression> { firstIndexExpr, secondIndexExpr };


            // This parameter represents the value that will be added to a corresponding array element.
            ParameterExpression valueExpr = Expression.Parameter(typeof(int), "Value");

            // This expression represents an access operation to a multidimensional array.
            // It can be used for assigning to, or reading from, an array element.
            Expression arrayAccessExpr = Expression.ArrayAccess(
                arrayExpr,
                indexes
            );

            // This lambda expression assigns a value provided to it to a specified array element.
            // The array, the index of the array element, and the value to be added to the element
            // are parameters of the lambda expression.
            Expression<Func<int[,], int, int, int, int>> lambdaExpr =
                Expression.Lambda<Func<int[,], int, int, int, int>>(
                    Expression.Assign(arrayAccessExpr, Expression.Add(arrayAccessExpr, valueExpr)),
                    arrayExpr,
                    firstIndexExpr,
                    secondIndexExpr,
                    valueExpr
            );

            // Print out expressions.
            Console.WriteLine("Array Access Expression:");
            Console.WriteLine(arrayAccessExpr.ToString());

            Console.WriteLine("Lambda Expression:");
            Console.WriteLine(lambdaExpr.ToString());

            Console.WriteLine("The result of executing the lambda expression:");

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.
            // Parameters passed to the Invoke method are passed to the lambda expression.
            int[,] sampleArray = { {10,  20,   30},
                                   {100, 200, 300}};
            Console.WriteLine(lambdaExpr.Compile().Invoke(sampleArray, 1, 1, 5));

            // This code example produces the following output:
            //
            // Array Access Expression:
            // Array[FirstIndex, SecondIndex]

            // Lambda Expression:
            // (Array, FirstIndex, SecondIndex Value) => 
            // (Array[FirstIndex, SecondIndex] = (Array[FirstIndex, SecondIndex] + Value))

            // The result of executing the lambda expression:
            // 205

            //</Snippet21>
        }

        //Expression.Constant(Object, Type)
        static public void ConstantNull()
        {
            //<Snippet22>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression represents a constant value, 
            // for which you can explicitly specify the type. 
            // This can be used, for example, for defining constants of a nullable type.
            Expression constantExpr = Expression.Constant(
                                        null,
                                        typeof(double?)
                                    );

            // Print out the expression.
            Console.WriteLine(constantExpr.ToString());

            // This code example produces the following output:
            //
            // null

            //</Snippet22>

        }

        //Expression.Convert(Expression, Type)
        static public void Convert1()
        {
            //<Snippet23>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression represents a type convertion operation. 
            Expression convertExpr = Expression.Convert(
                                        Expression.Constant(5.5),
                                        typeof(Int16)
                                    );

            // Print out the expression.
            Console.WriteLine(convertExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.
            Console.WriteLine(Expression.Lambda<Func<Int16>>(convertExpr).Compile()());

            // This code example produces the following output:
            //
            // Convert(5.5)
            // 5

            //</Snippet23>
        }

        //Expression.Increment(Expression)
        static public void Increment1()
        {
            //<Snippet24>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression represents an increment operation. 
            double num = 5.5;
            Expression incrementExpr = Expression.Increment(
                                        Expression.Constant(num)
                                    );


            // Print out the expression.
            Console.WriteLine(incrementExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.
            Console.WriteLine(Expression.Lambda<Func<double>>(incrementExpr).Compile()());

            // The value of the variable did not change,
            // because the expression is functional.
            Console.WriteLine("object: " + num);

            // This code example produces the following output:
            //
            // Increment(5.5)
            // 6.5
            // object: 5.5
            //</Snippet24>
        }

        //LessThan(Expression, Expression)
        static public void LessThan1()
        {
            //<Snippet25>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression compares the values of its two arguments.
            // Both arguments must be of the same type.
            Expression lessThanExpr = Expression.LessThan(
                Expression.Constant(42),
                Expression.Constant(45)
            );

            // Print out the expression.
            Console.WriteLine(lessThanExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.    
            Console.WriteLine(
                Expression.Lambda<Func<bool>>(lessThanExpr).Compile()());

            // This code example produces the following output:
            //
            // (42 < 45)
            // True
            //</Snippet25>
        }

        //LessThanOrEqual(Expression, Expression)
        static public void LessThanOrEqual1()
        {
            //<Snippet26>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression compares the values of its two arguments.
            // Both arguments must be of the same type.
            Expression lessThanOrEqual = Expression.LessThanOrEqual(
                Expression.Constant(42),
                Expression.Constant(45)
            );

            // Print out the expression.
            Console.WriteLine(lessThanOrEqual.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it. 
            Console.WriteLine(Expression.Lambda<Func<bool>>(lessThanOrEqual).Compile()());

            // This code example produces the following output:
            //
            // (42 <= 45)
            // True
            //</Snippet26>
        }

        //Multiply(Expression, Expression)
        public static void Multiply1()
        {
            //<Snippet27>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression multiplies its two arguments.
            // Both arguments must be of the same type.
            Expression multiplyExpr = Expression.Multiply(
                Expression.Constant(10),
                Expression.Constant(4)
            );

            // Print out the expression.
            Console.WriteLine(multiplyExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.
            Console.WriteLine(
                Expression.Lambda<Func<int>>(multiplyExpr).Compile()());

            // This code example produces the following output:
            //
            // (10*4)
            // 40
            //</Snippet27>
        }

        //Expression.Or(Expression, Expression)
        static public void Or1()
        {
            //<Snippet28>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression perfroms a logical OR operation
            // on its two arguments. Both arguments must be of the same type,
            // which can be boolean or integer.             
            Expression orExpr = Expression.Or(
                Expression.Constant(true),
                Expression.Constant(false)
            );

            // Print out the expression.
            Console.WriteLine(orExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.       
            Console.WriteLine(Expression.Lambda<Func<bool>>(orExpr).Compile()());

            // This code example produces the following output:
            //
            // (True Or False)
            // True
            //</Snippet28>
        }

        //Expression.OrElse(Expression, Expression)
        static public void OrElse1()
        {
            //<Snippet29>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression perfroms a logical OR operation
            // on its two arguments, but if the first argument is true,
            // then the second arument is not evaluated.
            // Both arguments must be of the boolean type.
            Expression orElseExpr = Expression.OrElse(
                Expression.Constant(false),
                Expression.Constant(true)
            );

            // Print out the expression.
            Console.WriteLine(orElseExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it. 
            Console.WriteLine(Expression.Lambda<Func<bool>>(orElseExpr).Compile().Invoke());

            // This code example produces the following output:
            //
            // (False OrElse True)
            // True

            //</Snippet29>
        }

        //Substract(Expression, Expression)
        static public void Subtract1()
        {
            //<Snippet30>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression subtracts the second argument 
            // from the first argument.
            // Both arguments must be of the same type.
            Expression subtractExpr = Expression.Subtract(
                Expression.Constant(12),
                Expression.Constant(3)
            );

            // Print out the expression.
            Console.WriteLine(subtractExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.            
            Console.WriteLine(Expression.Lambda<Func<int>>(subtractExpr).Compile().Invoke());

            // This code example produces the following output:
            //
            // (12 - 3)
            // 9
            //</Snippet30>
        }

        //Expression.Empty()
        static public void Empty1()
        {
            //<Snippet31>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This statement creates an empty expression.
            DefaultExpression emptyExpr = Expression.Empty();

            // The empty expression can be used where an expression is expected, but no action is desired.
            // For example, you can use the empty expression as the last expression in the block expression.
            // In this case the block expression's return value is void.
            var emptyBlock = Expression.Block(emptyExpr);

            //</Snippet31>

        }

        //Expression.IfThen
        static public void IfThen1()
        {
            //<Snippet32>
            // Add the following directive to the file:
            // using System.Linq.Expressions;  
            bool test = true;

            // This expression represents the conditional block.
            Expression ifThenExpr = Expression.IfThen(
                Expression.Constant(test),
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
                    Expression.Constant("The condition is true.")
                   )
            );

            // The following statement first creates an expression tree,
            // then compiles it, and then runs it.
            Expression.Lambda<Action>(ifThenExpr).Compile()();

            // This code example produces the following output:
            //
            // The condition is true.
            //</Snippet32>
        }

        //Expression.IfThenElse
        static public void IfThenElse1()
        {
            //<Snippet33>
            // Add the following directive to the file:
            // using System.Linq.Expressions;  
            bool test = true;

            // This expression represents the conditional block.
            Expression ifThenElseExpr = Expression.IfThenElse(
                Expression.Constant(test),
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
                    Expression.Constant("The condition is true.")
                ),
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
                    Expression.Constant("The condition is false.")
                )
            );

            // The following statement first creates an expression tree,
            // then compiles it, and then runs it.
            Expression.Lambda<Action>(ifThenElseExpr).Compile()();

            // This code example produces the following output:
            //
            // The condition is true.
            //</Snippet33>
        }

        //Expression.SwitchCase - no default case
        public static void SwitchCaseNoDefault()
        {
            //<Snippet34>
            // Add the following directive to the file:
            // using System.Linq.Expressions;  

            // An expression that represents the switch value.
            ConstantExpression switchValue = Expression.Constant(2);

            // This expression represents a switch statement 
            // without a default case.
            SwitchExpression switchExpr =
                Expression.Switch(
                    switchValue,
                    new SwitchCase[] {
                        Expression.SwitchCase(
                            Expression.Call(
                                null,
                                typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
                                Expression.Constant("First")
                            ),
                            Expression.Constant(1)
                        ),
                        Expression.SwitchCase(
                            Expression.Call(
                                null,
                                typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
                                Expression.Constant("Second")
                            ),
                            Expression.Constant(2)
                        )
                    }
                );

            // The following statement first creates an expression tree,
            // then compiles it, and then runs it.
            Expression.Lambda<Action>(switchExpr).Compile()();

            // This code example produces the following output:
            //
            // Second
            //</Snippet34>
        }

        //Expression.SwitchCase - with default case
        public static void SwitchCaseWithDefault()
        {
            //<Snippet35>
            // Add the following directive to the file:
            // using System.Linq.Expressions;  

            // An expression that represents the switch value.
            ConstantExpression switchValue = Expression.Constant(3);

            // This expression represents a switch statement 
            // that has a default case.
            SwitchExpression switchExpr =
                Expression.Switch(
                    switchValue,
                    Expression.Call(
                                null,
                                typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
                                Expression.Constant("Default")
                            ),
                    new SwitchCase[] {
                        Expression.SwitchCase(
                            Expression.Call(
                                null,
                                typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
                                Expression.Constant("First")
                            ),
                            Expression.Constant(1)
                        ),
                        Expression.SwitchCase(
                            Expression.Call(
                                null,
                                typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
                                Expression.Constant("Second")
                            ),
                            Expression.Constant(2)
                        )
                    }
                );

            // The following statement first creates an expression tree,
            // then compiles it, and then runs it.
            Expression.Lambda<Action>(switchExpr).Compile()();

            // This code example produces the following output:
            //
            // Default
            //</Snippet35>
        }

        // Expression.Type
        public static void Type1()
        {
            //<Snippet36>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            ConstantExpression constExpr = Expression.Constant(5);
            Console.WriteLine("NodeType: " + constExpr.NodeType);
            Console.WriteLine("Type: " + constExpr.Type);

            BinaryExpression binExpr = Expression.Add(constExpr, constExpr);
            Console.WriteLine("NodeType: " + binExpr.NodeType);
            Console.WriteLine("Type: " + binExpr.Type);

            // This code example produces the following output:
            //
            // NodeType: Constant
            // Type: System.Int32
            // NodeType: Add
            // Type: System.Int32
            //</Snippet36>
        }
    
        // Expression.Field
        //<Snippet37>
        // Add the following directive to your file:
        // using System.Linq.Expressions;  

        class TestFieldClass
        {
            int sample = 40;
        }

        static void TestField()
        {       
            TestFieldClass obj = new TestFieldClass();
          
            // This expression represents accessing a field.
            // For static fields, the first parameter must be null.
            Expression fieldExpr = Expression.Field(
                Expression.Constant(obj),
                "sample"
            );

            // The following statement first creates an expression tree,
            // then compiles it, and then runs it.
            Console.WriteLine(Expression.Lambda<Func<int>>(fieldExpr).Compile()());
        }

        // This code example produces the following output:
        //
        // 40
        //</Snippet37>


        //Expression.Property
        //<Snippet38>
        // Add the following directive to your file:
        // using System.Linq.Expressions;  

         class TestPropertyClass
         {
             public int sample {get; set;}
         }

         static void TestProperty()
         {
             TestPropertyClass obj = new TestPropertyClass();
             obj.sample = 40;

             // This expression represents accessing a property.
             // For static fields, the first parameter must be null.
             Expression propertyExpr = Expression.Property(
                 Expression.Constant(obj),
                 "sample"
             );

             // The following statement first creates an expression tree,
             // then compiles it, and then runs it.
             Console.WriteLine(Expression.Lambda<Func<int>>(propertyExpr).Compile()());            
         }

         // This code example produces the following output:
         //
         // 40

        //</Snippet38>

         //Expression.PropertyOrField
         //<Snippet39>
         // Add the following directive to your file:
         // using System.Linq.Expressions;  

         class TestClass
         {
             public int sample { get; set; }
         }

         static void TestPropertyOrField()
         {
             TestClass obj = new TestClass();
             obj.sample = 40;

             // This expression represents accessing a property or field.
             // For static properties or fields, the first parameter must be null.
             Expression memberExpr = Expression.PropertyOrField(
                 Expression.Constant(obj),
                 "sample"
             );

             // The following statement first creates an expression tree,
             // then compiles it, and then runs it.
             Console.WriteLine(Expression.Lambda<Func<int>>(memberExpr).Compile()());
         }

         // This code example produces the following output:
         //
         // 40

         //</Snippet39>

         //Expression.MemberInit
         //<Snippet40>

         // Add the following directive to your file:
         // using System.Linq.Expressions;  

         class TestMemberInitClass
         {
             public int sample { get; set; }
         }

         static void MemberInit()
         {   
             // This expression creates a new TestMemberInitClass object
             // and assigns 10 to its sample property.
             Expression testExpr = Expression.MemberInit(
                 Expression.New(typeof(TestMemberInitClass)),
                 new List<MemberBinding>() {
                     Expression.Bind(typeof(TestMemberInitClass).GetMember("sample")[0], Expression.Constant(10))
                 }
             );

             // The following statement first creates an expression tree,
             // then compiles it, and then runs it.
             var test = Expression.Lambda<Func<TestMemberInitClass>>(testExpr).Compile()();
             Console.WriteLine(test.sample);
         }

         // This code example produces the following output:
         //
         // 10
        //</Snippet40>


        //Expression.MemberBind
        //<Snippet41>
        // Add the following directive to your file
        // using System.Linq.Expressions;  

        public class Circle
        {
            public double Radius;
             public Point Center;
        }

        public struct Point
        {
            public int x;
            public int y;
        }
 
        public static void MemberBind()
        {
             // This variable represents the result of the MemberInit expression.
            ParameterExpression Variable = Expression.Variable(typeof(Circle), "Variable");

            // This expression represents the recursive initialization of the members 
            // of a new class instance.
            Expression memberBindExpr =
                Expression.Block(
                    new ParameterExpression[] { Variable },
                    Expression.Assign(
                        Variable,
                        Expression.MemberInit(
                            Expression.New(typeof(Circle)),
                            new MemberBinding[] { 
                                Expression.Bind(typeof(Circle).GetMember("Radius")[0], Expression.Constant(5.2)),                               
                                Expression.MemberBind(
                                    typeof(Circle).GetField("Center"),
                                    new MemberBinding[] {
                                        Expression.Bind(typeof(Point).GetField("x"), Expression.Constant(1)),
                                        Expression.Bind(typeof(Point).GetField("y"), Expression.Constant(2))
                                    }
                                )
                            }
                        )
                    ),
                    Expression.Field(Expression.Field(Variable, "Center"), "y")
                );
        
            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.
            // It prints the value of the Circle.Center.y member which is set to 2.
            Console.WriteLine(Expression.Lambda<Func<int>>(memberBindExpr).Compile()());                      
        }
        // This code example produces the following output:
        //
        // 2
        //</Snippet41>

        //Expression.Lambda
        public static void TestLambda()
        {
            //<Snippet42>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // A parameter for the lambda expression.
            ParameterExpression paramExpr = Expression.Parameter(typeof(int), "arg");

            // This expression represents a lambda expression
            // that adds 1 to the parameter value.
            LambdaExpression lambdaExpr = Expression.Lambda(
                Expression.Add(
                    paramExpr,
                    Expression.Constant(1)
                ),
                new List<ParameterExpression>() { paramExpr }
            );
            
            // Print out the expression.
            Console.WriteLine(lambdaExpr);

            // Compile and run the lamda expression.
            // The value of the parameter is 1.
            Console.WriteLine(lambdaExpr.Compile().DynamicInvoke(1));

            // This code example produces the following output:
            //
            // arg => (arg +1)
            // 2
            //</Snippet42>
    }

        public static void TestReturn()
        {
            //<Snippet43>
            // Add the following directive to the file:
            // using System.Linq.Expressions;  

            // A label expression of the void type that is the target for Expression.Return().
            LabelTarget returnTarget = Expression.Label();

            // This block contains a GotoExpression that represents a return statement with no value.
            // It transfers execution to a label expression that is initialized with the same LabelTarget as the GotoExpression.
            // The types of the GotoExpression, label expression, and LabelTarget must match.
            BlockExpression blockExpr =
                Expression.Block(
                    Expression.Call(typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), Expression.Constant("Return")),
                    Expression.Return(returnTarget),
                    Expression.Call(typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), Expression.Constant("Other Work")),
                    Expression.Label(returnTarget)
                );

            // The following statement first creates an expression tree,
            // then compiles it, and then runs it.
            Expression.Lambda<Action>(blockExpr).Compile()();

            // This code example produces the following output:
            //
            // Return

            // "Other Work" is not printed because 
            // the Return expression transfers execution from Expression.Return(returnTarget)
            // to Expression.Label(returnTarget).
            //</Snippet43>
        }

        public static void TestLoop()
        {
            //<Snippet44> 
            // Add the following directive to the file:
            // using System.Linq.Expressions;  

            // Creating a parameter expression.
            ParameterExpression value = Expression.Parameter(typeof(int), "value");

            // Creating an expression to hold a local variable. 
            ParameterExpression result = Expression.Parameter(typeof(int), "result");

            // Creating a label to jump to from a loop.
            LabelTarget label = Expression.Label(typeof(int));

            // Creating a method body.
            BlockExpression block = Expression.Block(
                new[] { result },
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
            );

            // Compile and run an expression tree.
            int factorial = Expression.Lambda<Func<int, int>>(block, value).Compile()(5);

            Console.WriteLine(factorial);

            // This code example produces the following output:
            //
            // 120
            //</Snippet44>
        }

        public static void TestGoTo()
        {
            //<Snippet45>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // A label expression of the void type that is the target for the GotoExpression.
            LabelTarget returnTarget = Expression.Label();

            // This block contains a GotoExpression.
            // It transfers execution to a label expression that is initialized with the same LabelTarget as the GotoExpression.
            // The types of the GotoExpression, label expression, and LabelTarget must match.
            BlockExpression blockExpr =
                Expression.Block(
                    Expression.Call(typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), Expression.Constant("GoTo")),
                    Expression.Goto(returnTarget),
                    Expression.Call(typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), Expression.Constant("Other Work")),
                    Expression.Label(returnTarget)
                );

            // The following statement first creates an expression tree,
            // then compiles it, and then runs it.
            Expression.Lambda<Action>(blockExpr).Compile()();

            // This code example produces the following output:
            //
            // GoTo

            // "Other Work" is not printed because 
            // the GoTo expression transfers execution from Expression.GoTo(returnTarget)
            // to Expression.Label(returnTarget).
            //</Snippet45>
        }

        public static void TestContinue()
        {
            //<Snippet46>
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // A label that is used by a break statement and a loop. 
            LabelTarget breakLabel = Expression.Label();

            // A label that is used by the Continue statement and the loop it refers to.
            LabelTarget continueLabel = Expression.Label();

            // This expression represents a Continue statement.
            Expression continueExpr = Expression.Continue(continueLabel);

            // A variable that triggers the exit from the loop.
            ParameterExpression count = Expression.Parameter(typeof(int));

            // A loop statement.
            Expression loopExpr = Expression.Loop(
                Expression.Block(
                    Expression.IfThen(
                        Expression.GreaterThan(count, Expression.Constant(3)),
                        Expression.Break(breakLabel)
                    ),
                    Expression.PreIncrementAssign(count),
                    Expression.Call(
                                null,
                                typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
                                Expression.Constant("Loop")
                            ),
                    continueExpr,
                    Expression.PreDecrementAssign(count)
                ),
                breakLabel,
                continueLabel
            );

            // The following statement first creates an expression tree,
            // then compiles it, and then runs it.
            // Without the Continue statement, the loop would go on forever.
            Expression.Lambda<Action<int>>(loopExpr, count).Compile()(1);

            // This code example produces the following output:
            //
            // Loop
            // Loop
            // Loop
            //</Snippet46>
        }

        public static void TryCatchTest()
        {
            //<Snippet47>
            // Add the following directive to the file:
            // using System.Linq.Expressions;  

            // A TryExpression object that has a Catch statement.
            // The return types of the Try block and all Catch blocks must be the same.
            TryExpression tryCatchExpr =
                Expression.TryCatch(
                    Expression.Block(
                        Expression.Throw(Expression.Constant(new DivideByZeroException())),
                        Expression.Constant("Try block")
                    ),
                    Expression.Catch(
                        typeof(DivideByZeroException),
                        Expression.Constant("Catch block")
                    )
                );

            // The following statement first creates an expression tree,
            // then compiles it, and then runs it.
            // If the exception is caught, 
            // the result of the TryExpression is the last statement 
            // of the corresponding Catch statement.
            Console.WriteLine(Expression.Lambda<Func<string>>(tryCatchExpr).Compile()());

            // This code example produces the following output:
            //
            // Catch block
            //</Snippet47>
        }

        public static void TryCatchFinallyTest()
        {
            //<Snippet48>
            // Add the following directive to the file.
            // using System.Linq.Expressions;  

            // A TryExpression object that has a catch statement and a finally statement.
            // The return types of the try block and all catch blocks must be the same.
            TryExpression tryCatchExpr =
                Expression.TryCatchFinally(
                    Expression.Block(
                        Expression.Throw(Expression.Constant(new DivideByZeroException())),
                        Expression.Constant("Try block")
                    ),
                    Expression.Call(typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), Expression.Constant("Finally block")),
                    Expression.Catch(
                        typeof(DivideByZeroException),
                        Expression.Constant("Catch block")
                    )
                );

            // The following statement first creates an expression tree,
            // then compiles it, and then runs it.
            // If the exception is caught, 
            // the result of the TryExpression is the last statement 
            // of the corresponding catch statement.
            Console.WriteLine(Expression.Lambda<Func<string>>(tryCatchExpr).Compile()());

            // This code example produces the following output:
            //
            // Finally block
            // Catch block
            //</Snippet48>
        }

        static void TestParam()
        {
            //<Snippet49>
            // Add the following directive to the file:
            // using System.Linq.Expressions;  

            // Creating a parameter for the expression tree.
            ParameterExpression param = Expression.Parameter(typeof(int));

            // Creating an expression for the method call and specifying its parameter.
            MethodCallExpression methodCall = Expression.Call(
                typeof(Console).GetMethod("WriteLine", new Type[] { typeof(int) }),
                param
            );

            // The following statement first creates an expression tree,
            // then compiles it, and then runs it.
            Expression.Lambda<Action<int>>(
                methodCall,
                new ParameterExpression[] { param }
            ).Compile()(10);

            // This code example produces the following output:
            //
            // 10
            //</Snippet49>
        }

        public static void TestNegate()
        {
            //<Snippet50>
            // Add the following directive to your file:
            // using System.Linq.Expressions; 

            // This expression represents a negation operation.
            Expression negateExpr = Expression.Negate(Expression.Constant(5));

            // The following statement first creates an expression tree,
            // then compiles it, and then runs it.
            Console.WriteLine(Expression.Lambda<Func<int>>(negateExpr).Compile()());

            // This code example produces the following output:
            //
            // -5

            //</Snippet50>
        }

        public static void TestNot()
        {
            //<Snippet51>
            // Add the following directive to your file:
            // using System.Linq.Expressions; 

            // This expression represents a NOT operation.
            Expression notExpr = Expression.Not(Expression.Constant(true));

            Console.WriteLine(notExpr);

            // The following statement first creates an expression tree,
            // then compiles it, and then runs it.
            Console.WriteLine(Expression.Lambda<Func<bool>>(notExpr).Compile()());

            // This code example produces the following output:
            //
            // Not(True)
            // False
            // </Snippet51>
        }

        static void Main(string[] args)
        {
            //Add1();
            //And1();
            //Condition1();
            //Constant1();
            //Decrement1();
            //Default1();
            //Divide1();
            //Equal1();
            //ExclusiveOr1();
            //GreaterThanOrEqual1();
            //Assign1();
            //BlockNoParameters();
            //BlockWithParameter();
            //CallInstnaceNoArguments();
            //CallStaticOneArgument.TestCall();
            //CallInstanceTwoArguments.TestCall();
            //AddAssign1();
            //AndAlso1();
            //ArrayAccessOneDimensional();
            //ArrayAccessMultidimensional();
            //ConstantNull();
            //Convert1();            
            //Increment1();
            //LessThan1();
            //LessThanOrEqual1();
            //Multiply1();
            //Or1();
            //OrElse1();
            //Subtract1();
            //Empty1();
            //IfThen1();
            //IfThenElse1();
            //SwitchCaseNoDefault();
            //SwitchCaseWithDefault();
            //Type1();
            //TestField();
            //TestProperty();
            //TestPropertyOrField();
            //MemberInit();
            //MemberBind();
            //TestLambda();
            //TestReturn();
            //TestLoop();
            //TestGoTo();
            //TestContinue();
            TryCatchTest();
            TryCatchFinallyTest();
            TestParam();
            TestNegate();
            TestNot();

            Console.WriteLine("C#");
            Console.ReadLine();
        }

    }
}
