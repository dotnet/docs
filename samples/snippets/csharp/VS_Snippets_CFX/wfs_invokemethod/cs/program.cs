//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Activities;
using System.Activities.Expressions;
using System.Activities.Statements;

namespace Microsoft.Samples.InvokeMethodUsage
{

    class Program
    {
        static void Main(string[] args)
        {
            WorkflowInvoker.Invoke(CreateWf());

            // Wait for confirmation to exit             
            Console.WriteLine("Press <return> to continue...");
            Console.ReadLine();
        }

        // Create a workflow that shows different ways of using InvokeMethod.         
        // All instances of the InvokeMethod activity in this workflow 
        // are invoking methods from TestClass class (file TestClass.cs)
        static Activity CreateWf()
        {
            TestClass testClass = new TestClass();
            Variable<string> outParam = new Variable<string>() { Default = "this is an out param" };
            Variable<int> resultValue = new Variable<int>();
            Variable<TestClass> varTestClass = new Variable<TestClass>( ctx => new TestClass() );

            return new Sequence
            {
                Variables = { outParam, resultValue, varTestClass },
                Activities =
                {
                    // use InvokeMethod to call an instance method without parameters
                    new WriteLine { Text = "Instance Method Call" },
                    new InvokeMethod
                    {
                        TargetObject = new InArgument<TestClass>(ctx => testClass),
                        MethodName = "InstanceMethod"
                    },

                    // use InvokeMethod to call an instance method with two parameters (string and int)
                    new WriteLine(),
                    new WriteLine { Text = "Instance Method Call with Parameters" },
                    new InvokeMethod
                    {
                        TargetObject = new InArgument<TestClass>(ctx => testClass),
                        MethodName = "InstanceMethod",
                        Parameters =
                        {
                            new InArgument<string>("My favorite number is"),
                            new InArgument<int>(42)
                        }
                    },

                    // use InvokeMethod to call an instance method with two parameters (string and int) 
                    // and a parameter array of type string[].                    
                    new WriteLine(),
                    new WriteLine { Text = "Instance Method Call with Parameter Arrays" },
//<Snippet1>
                    new InvokeMethod
                    {
                        TargetObject = new InArgument<TestClass>(ctx => testClass),
                        MethodName = "InstanceMethod",
                        Parameters =
                        {
                            new InArgument<string>("My favorite number is"),
                            new InArgument<int>(42),
                            new InArgument<string>("first item of the param array"),
                            new InArgument<string>("second item of the param array"),
                            new InArgument<string>("third item of the param array")
                        }
                    },
//</Snippet1>

                    // use InvokeMethod to call an instance method with two parameters (two int numbers)
                    // and a result of type int. In this case, the result value is bound to a variable
                    // and used in another activity (is displayed in the console using WriteLine)
                    new WriteLine {},
                    new WriteLine { Text = "Instance Method Call with Parameters and Return Value" }, 
//<Snippet2>
                    new InvokeMethod<int>
                    {
                        TargetObject = new InArgument<TestClass>(ctx => testClass),
                        MethodName = "InstanceMethodWithResult",
                        Parameters =
                        {
                            new InArgument<int>(20),
                            new InArgument<int>(22)
                        },
                        Result = resultValue
                    },
//</Snippet2>
                    new WriteLine { Text = new InArgument<string>(ctx => string.Format("....Result: {0}", resultValue.Get(ctx))) },

                    // use InvokeMethod to call a static method with two parameters (string and int). All options 
                    // for calling instance methods are also available for static methods.
                    new WriteLine(),
                    new WriteLine { Text = "Static Method Call with Parameters" },
                    new InvokeMethod
                    {
                        TargetType = typeof(TestClass),
                        MethodName = "StaticMethod",
                        Parameters =
                        {
                            new InArgument<string>("My favorite number is"),
                            new InArgument<int>(42)
                        }
                    },

                    // use InvokeMethod to call an instance method with one generic parameter (int this case, <string>)                    
                    new WriteLine(),
                    new WriteLine { Text = "Generic Instance Method Call with Generic Parameters" },
//<Snippet5>
                    new InvokeMethod
                    {
                        TargetObject = new InArgument<TestClass>(ctx => testClass),
                        MethodName = "GenericInstanceMethod",
                        GenericTypeArguments = { typeof(string) },
                        Parameters =
                        {
                            new InArgument<string>("Hello world")                            
                        }
                    },
//</Snippet5>

                    // use InvokeMethod to call a static method with two generic parameters (int this case, <string> and <int>)                  
                    new WriteLine(),
                    new WriteLine { Text = "Generic Static Method Call with Two Generic Parameters" },
                    new InvokeMethod
                    {
                        TargetType = typeof(TestClass),
                        MethodName = "GenericStaticMethod",
                        GenericTypeArguments = 
                        { 
                            typeof(string), 
                            typeof(int)
                        },
                        Parameters =
                        {
                            new InArgument<string>("Favorite Number"),                            
                            new InArgument<int>(42)     
                        }
                    },                

                    // use InvokeMethod to call an instance method that has one parameter
                    // passed by reference (a string param). In this case, the reference parameter is bound 
                    // to a variable (outParam) and used in another activity (is displayed in the console using WriteLine)
                    new WriteLine(),
                    new WriteLine { Text = "Instance Method Call with Parameters by Reference" },
                    new InvokeMethod
                    {
                        TargetObject = new InArgument<TestClass>(ctx => testClass),
                        MethodName = "InstanceMethod",
                        Parameters =
                            {
                                new InArgument<string>("My favorite number is"),
                                new InArgument<int>(42),
                                new InOutArgument<string>(outParam)
                            }
                    },
                    new WriteLine { Text = ExpressionServices.Convert<string>(ctx => string.Format("....out param changed to: {0}", outParam.Get(ctx))) },

                     // use InvokeMethod to call an asynchronous instance method
                    new WriteLine(),
                    new WriteLine { Text = "Async Instance Method Call" },
//<Snippet3>
                    new InvokeMethod
                    {
                        TargetObject = new InArgument<TestClass>(ctx => testClass),
                        MethodName = "AsyncMethodSample",
                        RunAsynchronously = true,
                        Parameters =
                        {
                            new InArgument<string>("Hello async"),
                        }
                    },  
//</Snippet3>                 

                    // use InvokeMethod to call an instance method in varTestClass
                    // store a value into the TestClass Variable
                    new WriteLine(),
                    new WriteLine { Text = "Store a Value" },
                    new InvokeMethod
                    {
                        TargetObject = new InArgument<TestClass>(varTestClass),
                        MethodName = "StoreValue",
                        Parameters =
                        {
                            new InArgument<int>(42),
                        }
                    },

                    // use InvokeMethod to call another instance method in varTestClass
                    // retrieve it back
                    new WriteLine(),
                    new WriteLine { Text = "Get a Value" },
                    new InvokeMethod<int>
                    {
                        TargetObject = new InArgument<TestClass>(varTestClass),
                        MethodName = "GetValue",
                        Result = resultValue,
                    },

                    // a different way of printing it out
//<Snippet4>
                    new InvokeMethod
                    {
                        TargetType = typeof(Console),
                        MethodName = "WriteLine",
                        Parameters =
                        {
                            new InArgument<string>(ctx => String.Format("....the stored value is {0}", resultValue.Get(ctx))),
                        }
                    },
//</Snippet4>
                }
            };
        }
    }
}
