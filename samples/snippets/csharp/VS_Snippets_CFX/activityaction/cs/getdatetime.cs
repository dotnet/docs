//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
using System;
using System.Activities;

namespace Microsoft.Samples.Activities
{

    public sealed class GetDateTime : CodeActivity
    {
        public OutArgument<string> Date { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            context.SetValue(this.Date, DateTime.Now.ToLongDateString());
        }
    }
}
