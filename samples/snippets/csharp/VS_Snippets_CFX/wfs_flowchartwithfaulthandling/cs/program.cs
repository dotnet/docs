//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Activities;
using System.Activities.Expressions;
using System.Activities.Statements;

namespace Microsoft.Samples.FlowChartWithFaultHandling
{

    // Show how to create a FlowChart that handles faults using a TryCatch activity.
    // To demonstrate this scenario, a Flowchart workflow to handle promotions is created
    // in CreateFlowchartWithFaults method. The following Promotion Codes are used: 
    //      Single: Single
    //      MNK:    Married (No Kids)
    //      MWK:    Married (With Kids)
    class Program
    {
        static void Main(string[] args)
        {   
            // no fault expected
            Console.WriteLine("Invoke with Promo Code {0}, number of kids {1}", "Single", 0);
            WorkflowInvoker.Invoke(CreateFlowchartWithFaults("Single", 0));

            // no fault expected
            Console.WriteLine();
            Console.WriteLine("Invoke with Promo Code {0}, number of kids {1}", "MNK", 0);
            WorkflowInvoker.Invoke(CreateFlowchartWithFaults("MNK", 0));

            // no fault expected
            Console.WriteLine();
            Console.WriteLine("Invoke with Promo Code {0}, number of kids {1}", "MWK", 2);
            WorkflowInvoker.Invoke(CreateFlowchartWithFaults("MWK", 2));

            // fault expected
            Console.WriteLine();
            Console.WriteLine("Invoke with Promo Code {0}, number of kids {1}", "MWK", 0);
            WorkflowInvoker.Invoke(CreateFlowchartWithFaults("MWK", 0));

            // wait for user input
            Console.WriteLine("\nPress Enter to exit");
            Console.ReadLine();
        }

        private static Activity CreateFlowchartWithFaults(string promoCode, int numKids)
        {
            Variable<string> promo = new Variable<string> { Default = promoCode };
            Variable<int> numberOfKids = new Variable<int> { Default = numKids };
            Variable<double> discount = new Variable<double>();
            DelegateInArgument<DivideByZeroException> ex = new DelegateInArgument<DivideByZeroException>();

            FlowStep discountNotApplied = new FlowStep
            {
                Action = new WriteLine 
                { 
                    DisplayName = "WriteLine: Discount not applied", 
                    Text = "Discount not applied" 
                },
                Next = null
            };

            FlowStep discountApplied = new FlowStep
            {
                Action = new WriteLine 
                {
                    DisplayName = "WriteLine: Discount applied",
                    Text = "Discount applied " 
                },
                Next = null
            };
//<Snippet3>            
            FlowDecision flowDecision = new FlowDecision 
            {
                Condition = ExpressionServices.Convert<bool>((ctx) => discount.Get(ctx) > 0),
                True = discountApplied,
                False = discountNotApplied
            };
//</Snippet3>
//<Snippet4>
            FlowStep singleStep = new FlowStep
            {
                Action = new Assign
                {
                    DisplayName = "discount = 10.0",
                    To = new OutArgument<double> (discount),
                    Value = new InArgument<double> (10.0)
                },
                Next = flowDecision
            };
//</Snippet4>

            FlowStep mnkStep = new FlowStep
            {
                Action = new Assign
                {
                    DisplayName = "discount = 15.0",
                    To = new OutArgument<double> (discount),
                    Value = new InArgument<double> (15.0)
                },
                Next = flowDecision
            };

//<Snippet1>
            FlowStep mwkStep = new FlowStep
            {
                Action = new TryCatch
                {
                    DisplayName = "Try/Catch for Divide By Zero Exception",
                    Try = new Assign
                    {
                        DisplayName = "discount = 15 + (1 - 1/numberOfKids)*10",
                        To = new OutArgument<double>(discount),
                        Value = new InArgument<double>((ctx) => (15 + (1 - 1 / numberOfKids.Get(ctx)) * 10))
                    },
                    Catches = 
                    {
                         new Catch<System.DivideByZeroException>
                         {
                             Action = new ActivityAction<System.DivideByZeroException>
                             {
                                 Argument = ex,
                                 DisplayName = "ActivityAction - DivideByZeroException",
                                 Handler =
                                     new Sequence
                                     {
                                         DisplayName = "Divide by Zero Exception Workflow",
                                         Activities =
                                         {
                                            new WriteLine() 
                                            { 
                                                DisplayName = "WriteLine: DivideByZeroException",
                                                Text = "DivideByZeroException: Promo code is MWK - but number of kids = 0" 
                                            },
                                            new Assign<double>
                                            {
                                                DisplayName = "Exception - discount = 0", 
                                                To = discount,
                                                Value = new InArgument<double>(0)
                                            }
                                         }
                                     }
                             }
                         }
                    }
                },
                Next = flowDecision
            };
//</Snippet1>

            FlowStep discountDefault = new FlowStep
            {
                Action = new Assign<double>
                {
                    DisplayName = "Default discount assignment: discount = 0",
                    To = discount,
                    Value = new InArgument<double>(0)
                },
                Next = flowDecision
            };
//<Snippet5>
            FlowSwitch<string> promoCodeSwitch = new FlowSwitch<string>
            {
                Expression = promo,
                Cases =
                {
                   { "Single", singleStep },
                   { "MNK", mnkStep },
                   { "MWK", mwkStep }
                },
                Default = discountDefault
            };
//</Snippet5>
//<Snippet2>
            Flowchart flowChart = new Flowchart
            {
                DisplayName = "Promotional Discount Calculation",
                Variables = {discount, promo, numberOfKids},
                StartNode = promoCodeSwitch,
                Nodes = 
                { 
                    promoCodeSwitch, 
                    singleStep, 
                    mnkStep, 
                    mwkStep, 
                    discountDefault, 
                    flowDecision, 
                    discountApplied, 
                    discountNotApplied
                }
            };
//</Snippet2>
            return flowChart;
        }
    }
}
