//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Activities;
using System.Activities.Statements;

namespace Microsoft.Samples.PersistenceParticipants
{

    public sealed class EchoPrompt : NativeActivity
    {
        WriteLine output;
        Variable<string> outputText = new Variable<string> { Name = "outputText" };

        [RequiredArgument]
        public InArgument<string> BookmarkName { get; set; }

        protected override bool CanInduceIdle { get { return true; } }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            metadata.AddImplementationVariable(outputText);
            this.output = new WriteLine { Text = new InArgument<string>(outputText) };
            metadata.AddImplementationChild(this.output);
            metadata.SetArgumentsCollection(metadata.GetArgumentsWithReflection());
        }

        protected override void Execute(NativeActivityContext context)
        {
            string name = this.BookmarkName.Get(context);

            this.outputText.Set(context, "Please enter a value: ");
            context.ScheduleActivity(output);
            context.CreateBookmark(name, new BookmarkCallback(OnReadComplete));
        }

        void OnReadComplete(NativeActivityContext context, Bookmark bookmark, object state)
        {
            string input = state as string;

            if (input == null)
            {
                throw new Exception(string.Format("EchoPrompt {0}: EchoPrompt must be resumed with a non-null string", this.DisplayName));
            }

            this.outputText.Set(context, "you said: " + input);
            context.ScheduleActivity(output);
        }
    }
}

