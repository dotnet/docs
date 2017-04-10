//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using System.Activities;
using System.Activities.Expressions;
using System.Activities.Statements;

namespace Microsoft.Samples.HelloWorld
{
    // <Snippet0>
    public sealed class AppendString : Activity<string>
    {
        // Input argument.
        [RequiredArgument]
        public InArgument<string> Name { get; set; }

        public AppendString()
        {
            // Define the implementation of this activity.
            this.Implementation = () => new Assign<string>
            {
                Value = new LambdaValue<string>(ctx => Name.Get(ctx) + " says hello world"),
                To = new LambdaReference<string>(ctx => Result.Get(ctx)),
            };
        }
    }
    // </Snippet0>
}
