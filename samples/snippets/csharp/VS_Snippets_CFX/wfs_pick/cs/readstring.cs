//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using System.Activities;

namespace Microsoft.Samples.PickUsage
{
    public sealed class ReadString : NativeActivity<string>
    {
        [RequiredArgument]
        public InArgument<string> BookmarkName { get; set; }

        protected override bool CanInduceIdle
        {
            get
            {
                return true;
            }
        }

        // The execution logic of this activity is dependent on an external source which
        // waits on the user entering an input. A bookmark is set in the overriden Execute
        // method using a callback delegate indicating to the runtime where the execution
        // should continue when that event completes.

        protected override void Execute(NativeActivityContext context)
        {
            context.CreateBookmark(this.BookmarkName.Get(context), new BookmarkCallback(OnReadComplete));
        }

        void OnReadComplete(NativeActivityContext context, Bookmark bookmark, object state)
        {
            string input = state as string;
            context.SetValue(this.Result, input);
        }
    }
}
