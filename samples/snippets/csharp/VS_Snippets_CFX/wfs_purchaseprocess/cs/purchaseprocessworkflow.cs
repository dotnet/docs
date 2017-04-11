//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------
using System;
using System.Activities;
using System.Activities.Expressions;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Globalization;

namespace Microsoft.Samples.WF.PurchaseProcess
{

    /// <summary>
    /// Definition of the Purchase Process workflow
    /// </summary>
    public sealed class PurchaseProcessWorkflow : Activity<VendorProposal>
    {
        public PurchaseProcessWorkflow()
        {
            base.Implementation = new Func<Activity>(CreateBody);
        }

        public InArgument<RequestForProposal> Rfp { get; set; }

        Activity CreateBody()
        {
            // variables declaration. The variables with Modifiers = VariableModifiers.Mapped can participate in schematized persistence
            var requestForProposal = new Variable<RequestForProposal>{ Modifiers = VariableModifiers.Mapped };
            var iterationVariableVendor = new DelegateInArgument<Vendor>();
            var iterationVariableVendorProposal = new DelegateInArgument<VendorProposal>();
            var bestProposal = new Variable<VendorProposal>() { Default = new LambdaValue<VendorProposal>(ctx =>new VendorProposal { Value = double.MaxValue }) };
            var proposalAdjustedValue = new Variable<double>();            
            var tmpValue = new Variable<double>();            
            
            return new Sequence
            {
                Variables = { bestProposal, proposalAdjustedValue, requestForProposal },
                Activities =
                {             
                    // assign the Request for Proposal in argument to a variable visible during the schematized persistence setp
                    new Assign<RequestForProposal>
                    {
                        DisplayName = "Assign the Rpf argument to a variable that is visible in persistence",
                        To = new OutArgument<RequestForProposal>(requestForProposal),
                        Value = new LambdaValue<RequestForProposal>(ctx =>Rfp.Get(ctx))
                    },                    
//<Snippet1>
                    // invite all vendors and wait for their proposals
                    new ParallelForEach<Vendor>
                    {
                        DisplayName = "Get vendor proposals",
                        Values = new InArgument<IEnumerable<Vendor>>(ctx =>this.Rfp.Get(ctx).InvitedVendors),
                        Body = new ActivityAction<Vendor>()
                        {                                    
                            Argument = iterationVariableVendor,
                            Handler = new Sequence
                            {
                                Variables = { tmpValue },
                                Activities =
                                {
                                    // waits for a vendor proposal (creates a bookmark for a vendor)
                                    new WaitForVendorProposal 
                                    { 
                                        VendorId = new LambdaValue<int>(ctx =>iterationVariableVendor.Get(ctx).Id) ,
                                        Result = new OutArgument<double>(tmpValue)
                                    },

                                    // after the vendor proposal is received, it is registered in the Request for Proposals
                                    new InvokeMethod
                                    {
                                        TargetObject = new InArgument<RequestForProposal>(ctx =>this.Rfp.Get(ctx)),
                                        MethodName = "RegisterProposal",
                                        Parameters = 
                                        {
                                            new InArgument<Vendor>(iterationVariableVendor),
                                            new InArgument<double>(tmpValue)
                                        }
                                    },
                                }
                            }                        
                        }
                    },
//</Snippet1>

                    // select the best vendor proposal of all received proposals. The best offer is selected
                    // using a calculation that adjusts the proposal submitted by the vendor using his reputation 
                    new ForEach<VendorProposal>
                    {
                        DisplayName = "Select best proposal",
                        Values = new InArgument<IEnumerable<VendorProposal>>(ctx =>Rfp.Get(ctx).VendorProposals.Values),
                        Body = new ActivityAction<VendorProposal>()
                        {
                            Argument = iterationVariableVendorProposal,
                            Handler = new Sequence
                            {
                                Activities =
                                {
                                    // adjust the value of the proposal using the vendor's reputation
                                    new Assign<double>
                                    {
                                        To = new OutArgument<double>(proposalAdjustedValue),
                                        Value = new LambdaValue<double>(ctx =>iterationVariableVendorProposal.Get(ctx).Value * (1 - (iterationVariableVendorProposal.Get(ctx).Vendor.Reliablity / 100)))
                                    },

                                    // check if the adjusted value is the best proposal
                                    new If
                                    {                                        
                                        Condition = new InArgument<bool>(ctx =>proposalAdjustedValue.Get(ctx) < bestProposal.Get(ctx).Value),
                                        Then = new Assign<VendorProposal>
                                        {
                                            To = bestProposal,
                                            Value = iterationVariableVendorProposal
                                        }
                                    }
                                }
                            }                        
                        }
                    },
                    // set the Request for Proposals best proposal
                    new Assign<VendorProposal> 
                    { 
                        To = new OutArgument<VendorProposal>(ctx =>this.Rfp.Get(ctx).BestProposal),
                        Value = new LambdaValue<VendorProposal>(ctx =>bestProposal.Get(ctx))
                    },            
                    // set the Request for Proposals completion date
                    new Assign<DateTime> 
                    { 
                        To = new OutArgument<DateTime>(ctx =>this.Rfp.Get(ctx).CompletionDate),
                        Value = new LambdaValue<DateTime>(ctx =>DateTime.Now)
                    },
                    // save to persistent storage
                    new Persist(),

                    // return value of the workflow: best proposal
                    new Assign<VendorProposal> 
                    { 
                        To = new OutArgument<VendorProposal>(ctx =>this.Result.Get(ctx)),
                        Value = new LambdaValue<VendorProposal>(ctx =>bestProposal.Get(ctx))
                    }
                }
            };
        }    
    }
    public sealed class WaitForVendorProposal : NativeActivity<double>
    {
        public InArgument<int> VendorId { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            string name = "waitingFor_" + this.VendorId.Get(context).ToString();

            if (VendorId.Get(context) == 0)
            {
                throw new Exception("Vendor identifier is required");
            }

            context.CreateBookmark(name, new BookmarkCallback(OnReadComplete));
        }

        void OnReadComplete(NativeActivityContext context, Bookmark bookmark, object state)
        {
            double input = Convert.ToDouble(state, new CultureInfo("EN-us"));
            context.SetValue(this.Result, input);
        }

        protected override bool CanInduceIdle
        {
            get
            {
                return true;
            }
        }
    }
}
