
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;
using System.Xml;
using System.Runtime.Serialization;
using System.Collections;


namespace Microsoft.Samples.Channels.ChunkingChannel
{
    public class ChunkingMessage : Message
    {

        #region Member variables
        MessageVersion version;
        ChunkingReader chunkReader;
        MessageProperties properties;
        MessageHeaders headers;
        Guid messageId;

        internal ChunkingMessage(MessageVersion version, string action, ChunkingReader reader, Guid messageId)
        {
            this.version = version;
            this.chunkReader = reader;
            this.properties = new MessageProperties();
            this.headers = new MessageHeaders(this.version);
            this.headers.Action = action;
            this.messageId = messageId;
        }
        #endregion

        #region Interesting overrides
        protected override XmlDictionaryReader OnGetReaderAtBodyContents()
        {
            return chunkReader;
        }
        protected override void OnClose()
        {
            this.chunkReader.Close();
        }
        #endregion

        #region Other overrides
        public override MessageHeaders Headers
        {
            get { return headers; }
        }

        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            //nothing to do
        }
        public override MessageProperties Properties
        {
            get { return properties; }
        }

        public override MessageVersion Version
        {
            get { return version; }
        }

        #endregion
        public Guid MessageId
        {
            get { return messageId; }
        }
        internal ChunkingReader UnderlyingReader
        {
            get { return this.chunkReader; }
        }

    }
}
