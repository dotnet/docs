//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Activities;
using System.Activities.Expressions;
using System.Activities.Statements;
using System.Activities.XamlIntegration;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Samples.DynamicActivityCreation
{

    class Program
    {
        static void Main(string[] args)
        {            
            List<int> numbers = GetInputFromUser(args);

            if (numbers != null)
            {
                Console.WriteLine("Input values:");
                foreach (int i in numbers)
                {
                    Console.WriteLine("\tValue = " + i);
                }
                Console.WriteLine();

                IDictionary<string, object> results;

                // Create the dynamic activity in two different ways and run it.
                // Using code.
                Activity act1 = CreateAverageCalculationWorkflow();
                results = WorkflowInvoker.Invoke(act1, new Dictionary<string, object> { { "Numbers", numbers } });
                Console.WriteLine("The average calculated using the code activity is = " + results["Average"]);

                // Using XAML.  The XAML may be created via the graphical designer.
                // If included in a visual studio project, its Build Action should be set to None.
                Activity act2 = ActivityXamlServices.Load(@"FindAverage.xaml");
                results = WorkflowInvoker.Invoke(act2, new Dictionary<string, object> { { "Numbers", numbers } });
                Console.WriteLine("The average calculated using the XAML activity is = " + results["Average"]);
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();   
        }

        static List<int> GetInputFromUser(string[] args)
        {
            List<int> numbers = new List<int> { 3, 5, 7, 9, 11 };

            // If there are arguments in the command line use them
            if (args.Length > 0)
            {                
                try
                {                    
                    numbers.Clear();

                    foreach (string arg in args)
                    {
                        numbers.Add(Convert.ToInt32(arg));
                    }
                    Console.WriteLine("Using numbers passed in as command line arguments");
                }
                catch // If arguments are wrong show message and return null
                {
                    Console.WriteLine("Incorrect arguments provided. Please provide a list of numbers (example: 1 2 3 4)");
                    numbers = null;
                }
            }
            else // If no arguments are passed, use the default list of numbers
            {
                Console.WriteLine("No numbers passed in as command line arguments. Using default list of numbers...");
            }

            return numbers;
        }


        static Activity CreateAverageCalculationWorkflow()
        {
            // <Snippet0>
            // Variables
            var iterationVariable = new DelegateInArgument<int>() { Name = "iterationVariable" };
            var accumulator = new Variable<int>() { Default = 0, Name = "accumulator" };

            // Define the Input and Output arguments that the DynamicActivity binds to
            var numbers = new InArgument<List<int>>();
            var average = new OutArgument<double>();
            
            var result = new Variable<double>() { Name = "result" };

            return new DynamicActivity()
            {
                DisplayName = "Find average",
                Properties = 
                {
                    // Input argument
                    new DynamicActivityProperty
                    {
                        Name = "Numbers",
                        Type = typeof(InArgument<List<int>>),
                        Value = numbers
                    },
                    // Output argument
                    new DynamicActivityProperty
                    {
                        Name = "Average",
                        Type = typeof(OutArgument<double>),
                        Value = average
                    }
                },
                Implementation = () =>
                    new Sequence
                    {
                        Variables = { result, accumulator },
                        Activities =
                        {
                            new ForEach<int>
                            {
                                Values =  new ArgumentValue<IEnumerable<int>> { ArgumentName = "Numbers" },                                
                                Body = new ActivityAction<int>
                                {
                                    Argument = iterationVariable,
                                    Handler = new Assign<int>
                                    {
                                        To = accumulator,
                                        Value = new InArgument<int>(env => iterationVariable.Get(env) +  accumulator.Get(env))
                                    }
                                }
                            },

                            // Calculate the average and assign to the output argument.
                            new Assign<double>
                            {
                                To = new ArgumentReference<double> { ArgumentName = "Average" },
                                Value = new InArgument<double>(env => accumulator.Get(env) / numbers.Get(env).Count<int>())
                            },
                        }
                    }
                    //</Snippet0>
            };
        }
    }
}
