
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

#region using
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.Collections.ObjectModel;
#endregion
namespace Microsoft.Samples.Channels.ChunkingChannel
{
    public class ChunkingBindingElement : BindingElement
    {
        int maxBufferedChunks;
        public ChunkingBindingElement()
        {
            this.maxBufferedChunks = ChunkingUtils.MaxBufferedChunksDefault;
        }
        #region Build stuff
        public override bool CanBuildChannelFactory<TChannel>(BindingContext context)
        {
            return (typeof(TChannel) == typeof(IDuplexSessionChannel) && context.CanBuildInnerChannelFactory<TChannel>());
        }
        public override bool CanBuildChannelListener<TChannel>(BindingContext context)
        {
            return (typeof(TChannel) == typeof(IDuplexSessionChannel) && context.CanBuildInnerChannelListener<TChannel>());
        }
        public override IChannelFactory<TChannel>  BuildChannelFactory<TChannel>(BindingContext context)
        {
            if (!this.CanBuildChannelFactory<TChannel>(context))
            {
                throw new InvalidOperationException("Unsupported channel type");
            }
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            //get the list of chunkable actions from context
            ICollection<string> operationParams = GetOperationParams(context);

            //pass the list of actions and maxBufferedChunks to ChunkingChannelFactory
            ChunkingChannelFactory factory = 
                new ChunkingChannelFactory(context.BuildInnerChannelFactory<IDuplexSessionChannel>(), operationParams, this.maxBufferedChunks);

            return (IChannelFactory<TChannel>)factory;
        }
        public override IChannelListener<TChannel>  BuildChannelListener<TChannel>(BindingContext context)
        {
            if (!this.CanBuildChannelListener<TChannel>(context))
            {
                throw new InvalidOperationException("Unsupported channel type");
            }

            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            //get the list of chunkable actions from context
            ICollection<string> operationParams = GetOperationParams(context);
            ChunkingChannelListener listener = new ChunkingChannelListener(context.BuildInnerChannelListener<IDuplexSessionChannel>(), operationParams,this.maxBufferedChunks);
            return (IChannelListener<TChannel>)listener;
        }
        private ICollection<string> GetOperationParams(BindingContext context)
        {
            //find ChunkingBindingParameter in context
            ChunkingBindingParameter bparams =
                context.BindingParameters.Find<ChunkingBindingParameter>();
            if (bparams != null)
            {
                //if found, return list of actions from it
                return bparams.OperationParams;
            }
            else
            {
                //else return an empty list
                return new List<string>();
            }
        }
    
        #endregion

        #region Other stuff

        public override BindingElement Clone()
        {
            ChunkingBindingElement clone = new ChunkingBindingElement();
            return clone;

        }
        public int MaxBufferedChunks
        {
            get { return this.maxBufferedChunks; }
            set { this.maxBufferedChunks = value; }
        }

        #endregion

        public override T GetProperty<T>(BindingContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            return context.GetInnerProperty<T>();
        }
    }

}
