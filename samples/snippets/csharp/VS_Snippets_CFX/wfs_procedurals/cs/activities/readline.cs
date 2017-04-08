//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System.Activities;

namespace Microsoft.Samples.ProceduralActivities.GuessingGame
{

    /// <summary>
    /// This activity reads a line of text. To achieve its goal, this activity 
    /// creates a bookmark that will be resumed by the host when the text 
    /// is entered by the user. 
    /// </summary>
    public sealed class ReadLine : NativeActivity<string>
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

        protected override void Execute(NativeActivityContext context)
        {
            // bookmark creation
            context.CreateBookmark(this.BookmarkName.Get(context), new BookmarkCallback(OnReadComplete));
        }

        void OnReadComplete(NativeActivityContext context, Bookmark bookmark, object state)
        {            
            string input = state as string;
            context.SetValue(this.Result, input);
        }
    }
}
