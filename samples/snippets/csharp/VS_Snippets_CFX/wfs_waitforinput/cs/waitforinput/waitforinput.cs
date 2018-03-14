//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using System.Activities;
using System.ComponentModel;
using Microsoft.Samples.Activities.Statements.Design;

namespace Microsoft.Samples.Activities.Statements
{

    /// <summary>
    /// This activity creates a bookmark of a given type and when the bookmark is resumed,
    /// it stores the value passed to the bookmark api in its Result OutArgument
    /// 
    /// We choose NativeActivity as base type because we need to create bookmarks and this 
    /// is only available through the NativeActivityContext.
    /// 
    /// Arguments decorating this activity:
    ///   - Designer: binds the activity with a designer (WaitForInputDesiger, contained in this project)
    /// </summary>
    [Designer(typeof(WaitForInputDesigner))]
    public class WaitForInput<TResult> : NativeActivity<TResult>
    {
        [RequiredArgument]
        public InArgument<string> BookmarkName { get; set; }
//<Snippet1>
        // indicate to the runtime that this activity can go idle
        protected override bool CanInduceIdle
        {
            get { return true; }
        }
//</Snippet1>
        protected override void Execute(NativeActivityContext context)
        {                        
            context.CreateBookmark(this.BookmarkName.Get(context), new BookmarkCallback(OnReadComplete));
        }

        void OnReadComplete(NativeActivityContext context, Bookmark bookmark, object state)
        {            
            this.Result.Set(context, (TResult)state);
        }
    }
}
