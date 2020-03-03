//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using System.Activities;

namespace Microsoft.Samples.HelloWorld
{
    public sealed class PrependString : CodeActivity<string>
    {
        // Input argument.
        [RequiredArgument]
        public InArgument<string> Name { get; set; }

        // Execute the concatenation, and return the value.
        protected override string Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Name input argument
            return "The honorable " + context.GetValue(this.Name);
        }
    }
}
