//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System.Activities;
using System.Activities.Statements;
using System.ServiceModel.Activities;
using Microsoft.VisualBasic.Activities;

namespace Microsoft.Samples.TransactedReceiveScope
{

    public class CodeServiceWorkflow : Activity
    {
        public CodeServiceWorkflow()
        {
            this.Implementation = this.InternalImplementation;
        }

        private Activity InternalImplementation()
        {
            Variable<string> requestMessage = new Variable<string> { Name = "requestString" };
            Variable<string> replyMessage = new Variable<string> { Name = "replyString" };

            Receive receive = new Receive
            {
                OperationName = "StartSample",
                CanCreateInstance = true,
                Content = ReceiveContent.Create(new OutArgument<string>(requestMessage)),
                ServiceContractName = "ITransactedReceiveService",
            };

            // <Snippet0>
            return new Sequence
            {
                Activities = 
                {
                    new WriteLine { Text = "Service workflow begins." },

                    new System.ServiceModel.Activities.TransactedReceiveScope
                    {
                        Variables = { requestMessage, replyMessage },
                        Request = receive,
                        Body = new Sequence
                        {
                            Activities =
                            {
                                new WriteLine { Text = new InArgument<string>("Server side: Receive complete.") },
                                
                                new WriteLine { Text = new InArgument<string>(new VisualBasicValue<string>() { ExpressionText = "\"Server side: Received = '\" + requestString.toString() + \"'\"" }) },

                                new PrintTransactionInfo(),

                                new Assign<string>
                                {
                                    Value = new InArgument<string>("Server side: Sending reply."),
                                    To = new OutArgument<string>(replyMessage)
                                },

                                new WriteLine { Text = new InArgument<string>("Server side: Begin reply.") },

                                new SendReply
                                {
                                    Request = receive,
                                    Content = SendContent.Create(new InArgument<string>(replyMessage)),                                    
                                },

                                new WriteLine { Text = new InArgument<string>("Server side: Reply sent.") },
                            },
                        },
                    },

                    new WriteLine { Text = "Server workflow ends." },
                },
            };
            // </Snippet0>
        }
    }
}
