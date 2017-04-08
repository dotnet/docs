//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
using System;
using System.Activities;
using System.Activities.Statements;

namespace Microsoft.Samples.ProceduralActivities.GuessingGame
{

    /// <summary>
    /// This activity presents some text to the user and prompts for an Int value. 
    /// To achieve this goal, this activity leverages other existing activities
    /// (ReadLine and WriteLine).
    /// 
    /// This activity does not contain any imperative instruction: it does its 
    /// work declarativealy by composing other existing activities 
    /// (in this case, a WriteLine and a ReadLine). 
    /// </summary>
    public sealed class PromptInt : Activity
    {
        public PromptInt()
        {
            base.Implementation = new Func<Activity>(CreateBody);
        }

        [RequiredArgument]
        public InArgument<string> Text { get; set; }

        [RequiredArgument]
        public OutArgument<int> Result { get; set; }

        Activity CreateBody()
        {
            Variable<string> tmp = new Variable<string>();
            return
                new Sequence()
                {
                    Variables = { tmp },
                    Activities = 
                    {
                        new WriteLine() { Text = new InArgument<string>(env => this.Text.Get(env)) } ,
                        new ReadLine() 
                        { 
                             BookmarkName = new InArgument<string>(env => "Prompt-" + Text.Get(env)),
                             Result= new OutArgument<string>(tmp)                              
                        },
                        new Assign<int>
                        {
                             Value= new InArgument<int>(env => Convert.ToInt32(tmp.Get(env))),
                             To = new OutArgument<int>(env => this.Result.Get(env))
                        }
                    }
                };
        }
    }
}
