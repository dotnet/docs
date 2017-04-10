
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml;
namespace Microsoft.Samples.Channels.ChunkingChannel
{
    internal class ChunkBodyWriter : BodyWriter
    {
        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            //this is where we write the message content
            //this particular implementation calls a delegate to write the content
            this.writeBodyCallback(writer, this.state);
        }

        internal ChunkBodyWriter(WriteBody writeBodyCallback, object state)
            : base(true)
        {
            this.writeBodyCallback = writeBodyCallback;
            this.state = state;
        }

        private WriteBody writeBodyCallback;
        private object state;
        internal delegate void WriteBody(XmlDictionaryWriter writer, object state);
    }
 
}
