//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
using System.Activities;

namespace Microsoft.Samples.Activities
{
    // <Snippet0>
    public sealed class MessageBox : CodeActivity
    {
        public InArgument<string> Text{ get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            System.Windows.Forms.MessageBox.Show(this.Text.Get(context));
        }
    }
     //</Snippet0>
}
