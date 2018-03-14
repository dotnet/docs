
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
using Microsoft.Samples.ChannelHelpers;
namespace Microsoft.Samples.Channels.ChunkingChannel
{

    internal class ChunkingWriter : XmlDictionaryWriter
    {
        StartChunkState startState;
        ChunkState chunkState;
        Message startMessage;
        MessageVersion version;
        Message originalMessage;
        MessageHeader messageIdHeader;
        Guid messageId;
        int chunkNum;
        XmlQualifiedName currentElementName;
        TimeoutHelper chunkingTimeout;
        IOutputChannel outputChannel;
        internal ChunkingWriter(Message originalMessage,TimeoutHelper chunkingTimeout, IOutputChannel outputChannel) : base()
        {
            this.version = originalMessage.Version;
            this.originalMessage = originalMessage;
            this.chunkingTimeout = chunkingTimeout;
            this.outputChannel = outputChannel;
            this.startState = new StartChunkState();
            chunkNum = 1;
        }
        void WriteChunkCallback(XmlDictionaryWriter writer, object state)
        {
            ChunkState chunkState = (ChunkState)state;
            writer.WriteStartElement(ChunkingUtils.ChunkElement, ChunkingUtils.ChunkNs);
            writer.WriteBase64(chunkState.Buffer, 0, chunkState.Count);
            writer.WriteEndElement();
        }
        private void SetStartMessageHeaders(Message message, Message chunk)
        {
            this.messageId = Guid.NewGuid();
            //create messageId header
            this.messageIdHeader = MessageHeader.CreateHeader(
                ChunkingUtils.MessageIdHeader,
                ChunkingUtils.ChunkNs,
                this.messageId.ToString(),
                true);
            chunk.Headers.Add(this.messageIdHeader);

            //create chunkStart header
            MessageHeader chunkStartHeader = MessageHeader.CreateHeader(
                ChunkingUtils.ChunkingStartHeader,
                ChunkingUtils.ChunkNs,
                null,
                true);
            chunk.Headers.Add(chunkStartHeader);

            //write out original headers as new message's headers
            MessageHeaders headers = message.Headers;
            string addressingNs = ChunkingUtils.GetAddressingNamespace(message.Version);
            for (int i = 0; i < headers.Count; i++)
            {
                //look for Action header and write it out as OriginalAction

                if (headers[i].Name == "Action" && headers[i].Namespace == addressingNs)
                {
                    //write out original action
                    string originalAction = message.Headers.Action; //headers.GetHeader<string>(i);
                    MessageHeader originalActionHeader = MessageHeader.CreateHeader(ChunkingUtils.OriginalAction, ChunkingUtils.ChunkNs, originalAction);
                    chunk.Headers.Add(originalActionHeader);
                }
                else
                {
                    //copying a header
                    chunk.Headers.CopyHeaderFrom(headers, i);
                }
            }

        }
        void CreateStartChunk()
        {
            ChunkBodyWriter startBodyWriter = new ChunkBodyWriter(this.WriteStartChunkCallback,startState);
            startMessage = Message.CreateMessage(
                            this.version,
                            ChunkingUtils.ChunkAction,
                            startBodyWriter);
            SetStartMessageHeaders(this.originalMessage, startMessage);
            this.outputChannel.Send(startMessage, chunkingTimeout.RemainingTime());

        }
        void WriteStartChunkCallback(XmlDictionaryWriter writer, object state)
        {
            StartChunkState startState = (StartChunkState)state;
            writer.WriteStartElement(startState.OperationName, startState.OperationNs);
            writer.WriteStartElement(startState.ParamName, startState.ParamNs);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
        public override void Close()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void Flush()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override string LookupPrefix(string ns)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void WriteBase64(byte[] buffer, int index, int count)
        {
            if (chunkState == null)
            {
                chunkState = new ChunkState();
            }
            int remaining = chunkState.AppendBytes(buffer, index, count);
            if (chunkState.Count == ChunkingUtils.ChunkSize)
            {
                CreateChunkMessage();
            }
            int end=index + count - 1;
            while (remaining > 0)
            {
                int start = end - remaining + 1;
                remaining=chunkState.AppendBytes(buffer,start,remaining);
                if (chunkState.Count == ChunkingUtils.ChunkSize)
                {
                    CreateChunkMessage();
                }
            }
        
        }
        void CreateChunkMessage()
        {
            ChunkBodyWriter bodyWriter = new ChunkBodyWriter(this.WriteChunkCallback, this.chunkState);
            Message chunk = Message.CreateMessage(this.version, ChunkingUtils.ChunkAction, bodyWriter);
            chunk.Headers.Add(this.messageIdHeader);
            chunk.Headers.Add(MessageHeader.CreateHeader(ChunkingUtils.ChunkNumberHeader, ChunkingUtils.ChunkNs, this.chunkNum, true));
            this.outputChannel.Send(chunk, chunkingTimeout.RemainingTime());
            Console.WriteLine(" > Sent chunk {0} of message {1}", chunkNum, this.messageId);
            this.chunkNum++;
            this.chunkState = new ChunkState();

        }
        public override void WriteCData(string text)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void WriteCharEntity(char ch)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void WriteChars(char[] buffer, int index, int count)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void WriteComment(string text)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void WriteDocType(string name, string pubid, string sysid, string subset)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void WriteEndAttribute()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void WriteEndDocument()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void WriteEndElement()
        {
            if (this.currentElementName.Name == this.startState.ParamName && this.currentElementName.Namespace == this.startState.ParamNs)
            
            {
                this.currentElementName = new XmlQualifiedName(this.startState.OperationName, this.startState.OperationNs);
            }
            else if (this.currentElementName.Name == this.startState.OperationName && this.currentElementName.Namespace == this.startState.OperationNs)
            {
                //flush out remaining buffer in chunkState
                CreateChunkMessage();
                //create the end message
                CreateEndChunk();
            }
            else
            {
                throw new InvalidOperationException("Chunking channel supports only messages with the format ...<soap:Body><operationElement><paramElement>data to be chunked</paramElement></operationElement></soap:Body>. Check that the service operation has one input parameter and/or one output parameter or return value.");
            }
        }
        void CreateEndChunk()
        {
            ChunkBodyWriter endBodyWriter = new ChunkBodyWriter(
                                this.WriteStartChunkCallback,
                                startState);

            Message endMessage = Message.CreateMessage(this.version, ChunkingUtils.ChunkAction, endBodyWriter);
            endMessage.Headers.Add(this.messageIdHeader);
            endMessage.Headers.Add(MessageHeader.CreateHeader(ChunkingUtils.ChunkingEndHeader, ChunkingUtils.ChunkNs, null, true));
            endMessage.Headers.Add(MessageHeader.CreateHeader(ChunkingUtils.ChunkNumberHeader, ChunkingUtils.ChunkNs, this.chunkNum, true));
            this.outputChannel.Send(endMessage, chunkingTimeout.RemainingTime());
            Console.WriteLine(" > Sent chunk {0} of message {1}", chunkNum, this.messageId);
            
        }
        public override void WriteEntityRef(string name)
        {
            throw new NotImplementedException();
        }

        public override void WriteFullEndElement()
        {
            throw new NotImplementedException();
        }

        public override void WriteProcessingInstruction(string name, string text)
        {
            throw new NotImplementedException();
        }

        public override void WriteRaw(string data)
        {
            throw new NotImplementedException();
        }

        public override void WriteRaw(char[] buffer, int index, int count)
        {
            throw new NotImplementedException();
        }

        public override void WriteStartAttribute(string prefix, string localName, string ns)
        {
            throw new NotImplementedException();
        }

        public override void WriteStartDocument(bool standalone)
        {
            throw new NotImplementedException();
        }

        public override void WriteStartDocument()
        {
            throw new NotImplementedException();
        }

        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            if (startState.OperationName == null)
            {
                startState.OperationName = localName;
                startState.OperationNs = ns;
                this.currentElementName = new XmlQualifiedName(localName, ns);
            }
            else if (startState.ParamName == null)
            {
                startState.ParamName = localName;
                startState.ParamNs = ns;
                CreateStartChunk();
                this.currentElementName = new XmlQualifiedName(localName, ns);
            }
            else
            {
                throw new InvalidOperationException("Chunking channel supports only messages with the format ...<soap:Body><operationElement><paramElement>data to be chunked</paramElement></operationElement></soap:Body>. Check that the service operation has one input parameter and/or one output parameter or return value.");
            }

        }

        public override WriteState WriteState
        {
            get { throw new NotImplementedException(); }
        }

        public override void WriteString(string text)
        {
            throw new NotImplementedException();
        }

        public override void WriteSurrogateCharEntity(char lowChar, char highChar)
        {
            throw new NotImplementedException();
        }

        public override void WriteWhitespace(string ws)
        {
            throw new NotImplementedException();
        }
    }
}
