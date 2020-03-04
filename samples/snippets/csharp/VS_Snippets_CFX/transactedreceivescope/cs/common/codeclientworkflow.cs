//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System.Activities;
using System.Activities.Statements;
using System.ServiceModel.Activities;
using Microsoft.VisualBasic.Activities;

namespace Microsoft.Samples.TransactedReceiveScope
{

    public class CodeClientWorkflow : Activity
    {
        public CodeClientWorkflow()
        {
            this.Implementation = this.InternalImplementation;
        }

        private Activity InternalImplementation()
        {
            Variable<string> reply = new Variable<string> { Name = "replyString" };

            Send send = new Send
            {
                OperationName = "StartSample",
                Content = SendContent.Create(new InArgument<string>("Client side: Send request.")),
                EndpointConfigurationName = "codeServiceEndpoint",
                ServiceContractName = "ITransactedReceiveService",
            };

            return new CorrelationScope
            {
                Body = new Sequence
                {
                    Variables = { reply },
                    Activities = 
                    {
                        new WriteLine { Text = "Client workflow begins." },

                         new TransactionScope
                         {
                            Body = new Sequence
                            {
                                Activities =
                                {
                                    // Transaction DistributedIdentifier will be emtpy until the send activity causes the transaction to promote to MSDTC
                                    new PrintTransactionInfo(),
                                    new WriteLine { Text = new InArgument<string>("Client side: Beginning send.") },
                                    send,
                                    new WriteLine { Text = new InArgument<string>("Client side: Send complete.") },
                                    new ReceiveReply
                                    {
                                      Request = send,
                                      Content = ReceiveContent.Create(new OutArgument<string>(reply))
                                    },
                                    new WriteLine { Text = new InArgument<string>(new VisualBasicValue<string>() { ExpressionText = "\"Client side: Reply received = '\" + replyString.toString() + \"'\"" }) },
                                    new PrintTransactionInfo(),
                                    new WriteLine { Text = new InArgument<string>("Client side: Receive complete.") },
                                },
                            },
                        },
                        new WriteLine { Text = "Client workflow ends." }
                    }
                }
            };
        }
    }
}
