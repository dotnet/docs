
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
namespace Microsoft.Samples.Channels.ChunkingChannel
{
    #region ChunkingAppliesTo enum
    [Flags]
    public enum ChunkingAppliesTo
    {
        InMessage = 1,
        OutMessage = 2,
        Both = InMessage | OutMessage
    }
    #endregion

    #region ChunkingBehavior
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class ChunkingBehavior : Attribute, IOperationBehavior
    {
        ChunkingAppliesTo appliesTo;

        //constructor and property for setting AppliesTo
        public ChunkingBehavior(ChunkingAppliesTo appliesTo)
        {
            this.appliesTo = appliesTo;
        }

        public ChunkingAppliesTo AppliesTo
        {
            get
            {
                return appliesTo;
            }
        }


        #region IOperationBehavior Members

        public void AddBindingParameters(OperationDescription description, BindingParameterCollection parameters)
        {
            //see if ChunkingBindingParameter already exists
            ChunkingBindingParameter param =
                parameters.Find<ChunkingBindingParameter>();
            if (param == null)
            {
                param = new ChunkingBindingParameter();
                parameters.Add(param);
            }

            if ((appliesTo & ChunkingAppliesTo.InMessage)
                          == ChunkingAppliesTo.InMessage)
            {
                //add input message's action to ChunkingBindingParameter
                param.AddAction(description.Messages[0].Action);
            }
            if (!description.IsOneWay &&
                ((appliesTo & ChunkingAppliesTo.OutMessage)
                            == ChunkingAppliesTo.OutMessage))
            {
                //add output message's action to ChunkingBindingParameter
                param.AddAction(description.Messages[1].Action);
            }
     
        }

        public void ApplyClientBehavior(OperationDescription description, System.ServiceModel.Dispatcher.ClientOperation proxy)
        {
            //nothing to do
        }

        public void ApplyDispatchBehavior(OperationDescription description, System.ServiceModel.Dispatcher.DispatchOperation dispatch)
        {
            //nothing to do
        }

        public void Validate(OperationDescription description)
        {
            //nothing to do
        }

        #endregion
    }
    #endregion

    #region ChunkingBindingParameter
    class ChunkingBindingParameter
    {
        ICollection<string> operationParams;

        internal ChunkingBindingParameter()
        {
            operationParams=new System.Collections.Generic.List<string>();
        }
        internal void AddAction(string action)
        {
            if (!operationParams.Contains(action))
            {
                operationParams.Add(action);
            }
        }
        internal ICollection<string> OperationParams
        {
            get { return operationParams; }
        }
    }
    #endregion

}
