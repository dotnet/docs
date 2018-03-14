
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
    internal class ChunkingReader : XmlDictionaryReader
    {
        #region Member variables
        private XmlDictionaryReader innerReader;
        private bool isLastChunk;
        private SynchronizedQueue<Message> bufferedChunks;
        private int nextChunkNum;
        private object lockobject;
        private Guid messageId;
        TimeoutHelper receiveTimeout;
        #endregion

        #region Interesting stuff
        internal ChunkingReader(Message startMessage, int maxBufferedChunks, TimeoutHelper receiveTimeout)
        {
            //set innerReader
            this.innerReader = startMessage.GetReaderAtBodyContents();
            this.lockobject = new object();
            this.messageId = ChunkingUtils.GetMessageHeader<Guid>(startMessage,
                ChunkingUtils.MessageIdHeader, ChunkingUtils.ChunkNs);
            this.bufferedChunks = new SynchronizedQueue<Message>(maxBufferedChunks);
            this.receiveTimeout = receiveTimeout;
            this.nextChunkNum = 1;
        }

        public override int ReadContentAsBase64(byte[] buffer, int index, int count)
        {
            int readCount = innerReader.ReadContentAsBase64(buffer, index, count);
            if (readCount == 0)
            {
                //GetReaderFromNextChunk will wait for chunks to be queued
                //then set this.innerReader to the received message's reader
                //it will throw TimeoutException if the next chunk is not received within specified timeout
                GetReaderFromNextChunk(receiveTimeout);               
                if (!isLastChunk)
                {
                    readCount = innerReader.ReadContentAsBase64(buffer,
                        index, count);
                    if (readCount == 0)
                    {
                        throw new CommunicationException(
                            "Received chunk contains no data");
                    }
                    else
                    {
                        return readCount;
                    }
                }
                else //lastChunk
                {
                    return 0;
                }

            }
            else
            {
                return readCount;
            }
        }
        public override XmlNodeType NodeType
        {
            get
            {

                if (innerReader.NodeType == XmlNodeType.EndElement && !isLastChunk) //we're at the end of some message but there are more chunks
                {
                    GetReaderFromNextChunk(this.receiveTimeout);
                    return innerReader.NodeType;
                }
                else
                {
                    return innerReader.NodeType;
                }

            }
        }
        public override bool Read()
        {
            if (innerReader.NodeType != XmlNodeType.None)
            {
                return innerReader.Read();
            }
            else
            {
                return false;
            }
        }


        #endregion

        #region Implementation stuff
        internal void AddMessage(Message message)
        {
            
            if (!this.bufferedChunks.TryEnqueue(this.receiveTimeout, message))
            {
                //caller should not tell us to buffer another chunk
                QuotaExceededException qeException = new QuotaExceededException(
                    String.Format("Number of buffered chunks exceeded MaxBufferedChunks setting which is {0}. Consider increasing the setting or processing received data faster", this.bufferedChunks.MaxLength));
                throw new CommunicationException("Quota error while receiving message", qeException);
            }
        }
        internal XmlDictionaryReader InnerReader
        {
            set { innerReader = value; }
        }
        internal bool IsLastChunk
        {
            set { isLastChunk = true; }
        }
        private void GetReaderFromNextChunk(TimeoutHelper timeouthelper)
        {
            Message chunk = null;
            if(this.bufferedChunks.TryDequeue(timeouthelper,out chunk))
            {
                int chunkNum = chunk.Headers.GetHeader<int>(ChunkingUtils.ChunkNumberHeader, ChunkingUtils.ChunkNs);
                Console.WriteLine(" < Received chunk {0} of message {1}", chunkNum, this.messageId);
                if (chunkNum != nextChunkNum)
                {
                    throw new CommunicationException(String.Format("Received chunk number {0} but expected chunk number {1}", chunkNum, nextChunkNum));
                }
                this.isLastChunk = (chunk.Headers.FindHeader(ChunkingUtils.ChunkingEndHeader, ChunkingUtils.ChunkNs) > -1);
                this.innerReader = chunk.GetReaderAtBodyContents();
                if (this.isLastChunk)
                {
                    this.innerReader.ReadStartElement(); //operation
                    this.innerReader.ReadStartElement(); //parameter
                }
                else
                {
                    //position reader at Base64 content
                    this.innerReader.ReadStartElement(ChunkingUtils.ChunkElement, ChunkingUtils.ChunkNs);
                }
                lock (lockobject)
                {
                    nextChunkNum++;
                }

            }
            else
            {
                throw new TimeoutException(String.Format("ChunkingReader timed out while waiting for chunk message number {0}", nextChunkNum));
            }

        }
        #endregion

        #region Other overrides
        public override int ReadValueChunk(char[] buffer, int index, int count)
        {
            throw new NotImplementedException("Operation not implemented");
        }
        public override byte[] ReadContentAsBase64()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override int AttributeCount
        {
            get { return innerReader.AttributeCount; }
        }

        public override string BaseURI
        {
            get { return innerReader.BaseURI; }
        }

        public override void Close()
        {
            innerReader.Close();
        }

        public override int Depth
        {
            get { return innerReader.Depth; }
        }

        public override bool EOF
        {
            get { return innerReader.EOF; }
        }

        public override string GetAttribute(int i)
        {
            return innerReader.GetAttribute(i);
        }

        public override string GetAttribute(string name, string namespaceURI)
        {
            return innerReader.GetAttribute(name, namespaceURI);
        }

        public override string GetAttribute(string name)
        {
            return innerReader.GetAttribute(name);
        }

        public override bool HasValue
        {
            get { return innerReader.HasValue; }
        }

        public override bool IsEmptyElement
        {
            get { return innerReader.IsEmptyElement; }
        }

        public override string LocalName
        {
            get { return innerReader.LocalName; }
        }

        public override string LookupNamespace(string prefix)
        {
            return innerReader.LookupNamespace(prefix);
        }

        public override bool MoveToAttribute(string name, string ns)
        {
            return innerReader.MoveToAttribute(name, ns);
        }

        public override bool MoveToAttribute(string name)
        {
            return innerReader.MoveToAttribute(name);
        }

        public override bool MoveToElement()
        {
            return innerReader.MoveToElement();
        }

        public override bool MoveToFirstAttribute()
        {
            return innerReader.MoveToFirstAttribute();
        }

        public override bool MoveToNextAttribute()
        {
            return innerReader.MoveToNextAttribute();
        }

        public override XmlNameTable NameTable
        {
            get { return innerReader.NameTable; }
        }

        public override string NamespaceURI
        {
            get { return innerReader.NamespaceURI; }
        }
        public override string Prefix
        {
            get { return innerReader.Prefix; }
        }


        public override void ReadStartElement(string localname, string ns) { innerReader.ReadStartElement(localname, ns); }

        public override bool ReadAttributeValue()
        {
            return innerReader.ReadAttributeValue();
        }

        public override ReadState ReadState
        {
            get { return innerReader.ReadState; }
        }

        public override void ResolveEntity()
        {
            innerReader.ResolveEntity();
        }

        public override string Value
        {
            get { return innerReader.Value; }
        }

        public override bool CanReadValueChunk { get { return false; } }

        public override void EndCanonicalization() { throw new NotImplementedException("not implemented"); }
        public override string GetAttribute(XmlDictionaryString localName, XmlDictionaryString namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override int IndexOfLocalName(string[] localNames, string namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override int IndexOfLocalName(XmlDictionaryString[] localNames, XmlDictionaryString namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override bool IsLocalName(string localName) { throw new NotImplementedException("not implemented"); }
        public override bool IsLocalName(XmlDictionaryString localName) { throw new NotImplementedException("not implemented"); }
        public override bool IsNamespaceUri(string namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override bool IsNamespaceUri(XmlDictionaryString namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override bool IsStartArray(out Type type) { return innerReader.IsStartArray(out type); }
        public override bool IsStartElement(XmlDictionaryString localName, XmlDictionaryString namespaceUri) { throw new NotImplementedException("not implemented"); }
        protected new bool IsTextNode(XmlNodeType nodeType) { throw new NotImplementedException("not implemented"); }
        public override void MoveToStartElement() { throw new NotImplementedException("not implemented"); }
        public override void MoveToStartElement(string name) { throw new NotImplementedException("not implemented"); }
        public override void MoveToStartElement(string localName, string namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override void MoveToStartElement(XmlDictionaryString localName, XmlDictionaryString namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override int ReadArray(string localName, string namespaceUri, bool[] array, int offset, int count) { throw new NotImplementedException("not implemented"); }
        public override int ReadArray(string localName, string namespaceUri, DateTime[] array, int offset, int count) { throw new NotImplementedException("not implemented"); }
        public override int ReadArray(string localName, string namespaceUri, decimal[] array, int offset, int count) { throw new NotImplementedException("not implemented"); }
        public override int ReadArray(string localName, string namespaceUri, double[] array, int offset, int count) { throw new NotImplementedException("not implemented"); }
        public override int ReadArray(string localName, string namespaceUri, float[] array, int offset, int count) { throw new NotImplementedException("not implemented"); }
        public override int ReadArray(string localName, string namespaceUri, Guid[] array, int offset, int count) { throw new NotImplementedException("not implemented"); }
        public override int ReadArray(string localName, string namespaceUri, int[] array, int offset, int count) { throw new NotImplementedException("not implemented"); }
        public override int ReadArray(string localName, string namespaceUri, long[] array, int offset, int count) { throw new NotImplementedException("not implemented"); }
        public override int ReadArray(string localName, string namespaceUri, short[] array, int offset, int count) { throw new NotImplementedException("not implemented"); }
        public override int ReadArray(string localName, string namespaceUri, TimeSpan[] array, int offset, int count) { throw new NotImplementedException("not implemented"); }
        public override int ReadArray(XmlDictionaryString localName, XmlDictionaryString namespaceUri, bool[] array, int offset, int count) { throw new NotImplementedException("not implemented"); }
        public override int ReadArray(XmlDictionaryString localName, XmlDictionaryString namespaceUri, DateTime[] array, int offset, int count) { throw new NotImplementedException("not implemented"); }
        public override int ReadArray(XmlDictionaryString localName, XmlDictionaryString namespaceUri, decimal[] array, int offset, int count) { throw new NotImplementedException("not implemented"); }
        public override int ReadArray(XmlDictionaryString localName, XmlDictionaryString namespaceUri, double[] array, int offset, int count) { throw new NotImplementedException("not implemented"); }
        public override int ReadArray(XmlDictionaryString localName, XmlDictionaryString namespaceUri, float[] array, int offset, int count) { throw new NotImplementedException("not implemented"); }
        public override int ReadArray(XmlDictionaryString localName, XmlDictionaryString namespaceUri, Guid[] array, int offset, int count) { throw new NotImplementedException("not implemented"); }
        public override int ReadArray(XmlDictionaryString localName, XmlDictionaryString namespaceUri, int[] array, int offset, int count) { throw new NotImplementedException("not implemented"); }
        public override int ReadArray(XmlDictionaryString localName, XmlDictionaryString namespaceUri, long[] array, int offset, int count) { throw new NotImplementedException("not implemented"); }
        public override int ReadArray(XmlDictionaryString localName, XmlDictionaryString namespaceUri, short[] array, int offset, int count) { throw new NotImplementedException("not implemented"); }
        public override int ReadArray(XmlDictionaryString localName, XmlDictionaryString namespaceUri, TimeSpan[] array, int offset, int count) { throw new NotImplementedException("not implemented"); }
        public override bool[] ReadBooleanArray(string localName, string namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override bool[] ReadBooleanArray(XmlDictionaryString localName, XmlDictionaryString namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override byte[] ReadContentAsBinHex() { throw new NotImplementedException("not implemented"); }
        protected new byte[] ReadContentAsBinHex(int maxByteArrayContentLength) { throw new NotImplementedException("not implemented"); }
        public override int ReadContentAsChars(char[] chars, int offset, int count) { throw new NotImplementedException("not implemented"); }
        public override decimal ReadContentAsDecimal() { throw new NotImplementedException("not implemented"); }
        public override Guid ReadContentAsGuid() { throw new NotImplementedException("not implemented"); }
        public override void ReadContentAsQualifiedName(out string localName, out string namespaceUri) { throw new NotImplementedException("not implemented"); }
        //public override float ReadContentAsSingle() { throw new NotImplementedException("not implemented"); }
        public override string ReadContentAsString() { throw new NotImplementedException("not implemented"); }
        protected new string ReadContentAsString(int maxStringContentLength) { throw new NotImplementedException("not implemented"); }
        public override string ReadContentAsString(string[] strings, out int index) { throw new NotImplementedException("not implemented"); }
        public override string ReadContentAsString(XmlDictionaryString[] strings, out int index) { throw new NotImplementedException("not implemented"); }
        public override TimeSpan ReadContentAsTimeSpan() { throw new NotImplementedException("not implemented"); }
        public override UniqueId ReadContentAsUniqueId() { throw new NotImplementedException("not implemented"); }
        public override DateTime[] ReadDateTimeArray(string localName, string namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override DateTime[] ReadDateTimeArray(XmlDictionaryString localName, XmlDictionaryString namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override decimal[] ReadDecimalArray(string localName, string namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override decimal[] ReadDecimalArray(XmlDictionaryString localName, XmlDictionaryString namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override double[] ReadDoubleArray(string localName, string namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override double[] ReadDoubleArray(XmlDictionaryString localName, XmlDictionaryString namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override byte[] ReadElementContentAsBase64() { throw new NotImplementedException("not implemented"); }
        public override byte[] ReadElementContentAsBinHex() { throw new NotImplementedException("not implemented"); }
        public override bool ReadElementContentAsBoolean() { throw new NotImplementedException("not implemented"); }
        public override DateTime ReadElementContentAsDateTime() { throw new NotImplementedException("not implemented"); }
        public override decimal ReadElementContentAsDecimal() { throw new NotImplementedException("not implemented"); }
        public override double ReadElementContentAsDouble() { throw new NotImplementedException("not implemented"); }
        public override Guid ReadElementContentAsGuid() { throw new NotImplementedException("not implemented"); }
        public override int ReadElementContentAsInt() { throw new NotImplementedException("not implemented"); }
        public override long ReadElementContentAsLong() { throw new NotImplementedException("not implemented"); }
        public override string ReadElementContentAsString() { throw new NotImplementedException("not implemented"); }
        public override TimeSpan ReadElementContentAsTimeSpan() { throw new NotImplementedException("not implemented"); }
        public override UniqueId ReadElementContentAsUniqueId() { throw new NotImplementedException("not implemented"); }
        public override void ReadFullStartElement() { throw new NotImplementedException("not implemented"); }
        public override void ReadFullStartElement(string name) { throw new NotImplementedException("not implemented"); }
        public override void ReadFullStartElement(string localName, string namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override void ReadFullStartElement(XmlDictionaryString localName, XmlDictionaryString namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override Guid[] ReadGuidArray(string localName, string namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override Guid[] ReadGuidArray(XmlDictionaryString localName, XmlDictionaryString namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override short[] ReadInt16Array(string localName, string namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override short[] ReadInt16Array(XmlDictionaryString localName, XmlDictionaryString namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override int[] ReadInt32Array(string localName, string namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override int[] ReadInt32Array(XmlDictionaryString localName, XmlDictionaryString namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override long[] ReadInt64Array(string localName, string namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override long[] ReadInt64Array(XmlDictionaryString localName, XmlDictionaryString namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override float[] ReadSingleArray(string localName, string namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override float[] ReadSingleArray(XmlDictionaryString localName, XmlDictionaryString namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override void ReadStartElement(XmlDictionaryString localName, XmlDictionaryString namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override string ReadString() { throw new NotImplementedException("not implemented"); }
        protected new string ReadString(int maxStringContentLength) { throw new NotImplementedException("not implemented"); }
        public override TimeSpan[] ReadTimeSpanArray(string localName, string namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override TimeSpan[] ReadTimeSpanArray(XmlDictionaryString localName, XmlDictionaryString namespaceUri) { throw new NotImplementedException("not implemented"); }
        public override int ReadValueAsBase64(byte[] buffer, int offset, int count) { throw new NotImplementedException("not implemented"); }
        //public override int ReadValueAsBinHex(byte[] buffer, int offset, int count) { throw new NotImplementedException("not implemented"); }
        //public override void StartCanonicalization(XmlCanonicalWriter writer) { throw new NotImplementedException("not implemented"); }
        public override bool TryGetArrayLength(out int count) { throw new NotImplementedException("not implemented"); }
        public override bool TryGetBase64ContentLength(out int length) { throw new NotImplementedException("not implemented"); }
        public override bool TryGetLocalNameAsDictionaryString(out XmlDictionaryString localName) { return innerReader.TryGetLocalNameAsDictionaryString(out localName); }
        public override bool TryGetNamespaceUriAsDictionaryString(out XmlDictionaryString namespaceUri) { throw new NotImplementedException("not implemented"); }

        #endregion
    }
}
