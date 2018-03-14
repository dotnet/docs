//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
using System;
using System.Activities;
using System.Activities.Expressions;
using System.Activities.Statements;
using System.Threading;

namespace Microsoft.Samples.ProceduralActivities.GuessingGame
{

    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            
            // create the workflow application and start its execution
            AutoResetEvent syncEvent = new AutoResetEvent(false);
            WorkflowApplication application = new WorkflowApplication(CreateGuessingGameWF());
            application.Completed = delegate(WorkflowApplicationCompletedEventArgs e) { running = false; syncEvent.Set(); };
            application.Idle = delegate(WorkflowApplicationIdleEventArgs e)
            {
                syncEvent.Set();                
            };
            application.Run();

            // main loop (manages bookmarks)            
            while (running)
            {                
                if (!syncEvent.WaitOne(10, false))
                {
                    if (running)
                    {
                        // if there are pending bookmarks...
                        if (HasPendingBookmarks(application))
                        {
                            // get the name of the bookmark
                            string bookmarkName = application.GetBookmarks()[0].BookmarkName;

                            // resume the bookmark (passing the data read from the console)
                            application.ResumeBookmark(bookmarkName, Console.ReadLine());
                            
                            syncEvent.WaitOne();
                        }
                    }
                }
            }

            // wait for user input
            Console.ReadLine();
        }

        // Returns true if the WorkflowApplication has any pending bookmark
        static bool HasPendingBookmarks(WorkflowApplication application)
        {
            try
            {
                return application.GetBookmarks().Count > 0;
            }
            catch(WorkflowApplicationCompletedException)
            {
                return false;
            }
        }

        // Create a number guessing game workflow program. This workflow
        // combines several out of the box activities (Sequence, If, 
        // WriteLine, Assign, While, TryCatch, Switch, Expressions) 
        // and two custom activities included in this project (ReadLine and PromptIt).
        static Activity CreateGuessingGameWF()
        {
            // declare working variables
            Variable<int> attempts = new Variable<int>() { Name = "attempts", Default = 0 };
            Variable<int> numberToGuess = new Variable<int>() { Name = "numberToGuess" };
            Variable<int> numberFromUser = new Variable<int>() { Name = "numberFromUser" };
            Variable<bool> finished = new Variable<bool>() { Name = "finished", Default = false };
            DelegateInArgument<FormatException> formatEx = new DelegateInArgument<FormatException>() { Name = "FormatException" };
            DelegateInArgument<OverflowException> overFlowEx = new DelegateInArgument<OverflowException>() { Name = "OverflowException" };

            return
                new Sequence()
                {
                    DisplayName = "Main Sequence",
                    Variables = { numberToGuess, finished, numberFromUser, attempts },
                    Activities =
                    {
                        // show a welcome message
                        new WriteLine() { Text = "Starting Game..." },

                        // calculate a random number and assign it to the numberToGuess variable
                        new Assign<int>()
                        {
                            DisplayName = "Set Random Number to Guess",
                            To = new OutArgument<int>(numberToGuess),
                            Value = new InArgument<int>(env => new Random().Next(1, 100))
                        },

                        /// while the user does not guess the number correctly...
                        new While()
                        {
                            DisplayName = "Main Loop",
                            Condition = ExpressionServices.Convert<bool>(env => !finished.Get(env)),                        

                            // we will ask the user for a number and check if he guessed it (this is what we do inside this sequence)
                            Body = new Sequence()
                            {
                                Activities = 
                                {
                                    // increase the attempts counter
                                    new Assign<int>()
                                    {
                                        DisplayName = "Increment Attempts",
                                        To = new OutArgument<int>(attempts),
                                        Value = new InArgument<int>(env => attempts.Get(env) + 1)
                                    },

                                    // ask a the user for a number in a TryCatch to handle invalid input
                                    new TryCatch()
                                    {                                        
                                        Try = 
                                        new Sequence
                                        {
                                            DisplayName = "Try Catch (getting valid user input)",
                                            Activities =
                                            {
                                                // ask a number to the user
                                                new PromptInt()
                                                {
                                                    DisplayName = "Prompt Value to User",
                                                    Text = "What is your guess?",
                                                    Result = new OutArgument<int>(numberFromUser)
                                                },
//<Snippet1>
                                                // check if the number is ok...
                                                new Switch<int>()
                                                {
                                                    DisplayName = "Verify Value from User",
                                                    Expression = ExpressionServices.Convert<int>( env => numberFromUser.Get(env).CompareTo(numberToGuess.Get(env)) ),
                                                    Cases = 
                                                    {
                                                        { 0, new Assign<bool>()
                                                            {
                                                                To = new OutArgument<bool>(finished),
                                                                Value = true
                                                            }
                                                        },
                                                        {  1, new WriteLine() { Text = "    Try a lower number number..." } }, 
                                                        { -1, new WriteLine() { Text = "    Try a higher number" } }
                                                    }
                                                }
//</Snippet1>
                                            }
                                        },
                                        // if the user supplied invalid input (e.g. a string instead of a number), we show him an error message
                                        Catches =
                                        {
                                            new Catch<FormatException>()
                                            {
                                                Action = new ActivityAction<FormatException>
                                                {
                                                    Argument = formatEx,
                                                    DisplayName = "Wrong Input",
                                                    Handler = new WriteLine() { Text = "   Hey! You must enter a integer number between 1 and 100." }
                                                }
                                            },
                                            new Catch<OverflowException>()
                                            {
                                                Action = new ActivityAction<OverflowException>
                                                {
                                                    Argument = overFlowEx,
                                                    DisplayName = "Wrong Input",
                                                    Handler = new WriteLine() { Text = "   Hey! The number that you entered is too big...You must enter a integer number between 1 and 100." }
                                                }
                                            }
                                        }
                                    }                                    
                                }
                            }
                        },
                        // final message: if the user guessed the number in less than 7 attempts, we show a congratulation message. 
                        // if otherwise he found it in 7 or more attempts we encourage him to get more practice
                        new If()
                        {
                            DisplayName = "Display Final Message",
                            Condition = ExpressionServices.Convert<bool>(env => attempts.Get(env) < 7),
                            Then = new WriteLine() { Text = new InArgument<string>(env => string.Format("Congratulations, you've found it in {0} attempts!!!", attempts.Get(env))) },
                            Else = new WriteLine() { Text = new InArgument<string>(env => string.Format("You've found it in {0} attempts...You need more practice!", attempts.Get(env))) }
                        }
                    }
            };
        }        
    }
}
