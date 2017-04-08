//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------
using System.Activities;
using System.Activities.Presentation;
using System.Windows;

namespace Microsoft.Samples.Activities.Statements.Presentation
{
    // creates a ForEach activity with its Body (ActivityyAction) configured
    public sealed class ParallelForEachWithBodyFactory : IActivityTemplateFactory
    {
        public Activity Create(DependencyObject target)
        {
            return new Microsoft.Samples.Activities.Statements.ParallelForEach()
            {
                Body = new ActivityAction<object>()
                {
                    Argument = new DelegateInArgument<object>()
                    {
                        Name = "item"
                    }
                }
            };
        }
    }
}