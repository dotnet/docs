
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.IO;
using System.Xml;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.ServiceModel.Samples
{
    // <Snippet0>
    public class CustomTextMessageEncoder : MessageEncoder
    {
        private CustomTextMessageEncoderFactory factory;
        private XmlWriterSettings writerSettings;
        private string contentType;
        
        public CustomTextMessageEncoder(CustomTextMessageEncoderFactory factory)
        {
            this.factory = factory;
            
            this.writerSettings = new XmlWriterSettings();
            this.writerSettings.Encoding = Encoding.GetEncoding(factory.CharSet);
            this.contentType = string.Format("{0}; charset={1}", 
                this.factory.MediaType, this.writerSettings.Encoding.HeaderName);
        }

        // <Snippet1>
        public override string ContentType
        {
            get
            {
                return this.contentType;
            }
        }
        // </Snippet1>

        // <Snippet2>
        public override string MediaType
        {
            get 
            {
                return factory.MediaType;
            }
        }
        // </Snippet2>

        // <Snippet3>
        public override MessageVersion MessageVersion
        {
            get 
            {
                return this.factory.MessageVersion;
            }
        }
        // </Snippet3>

        // <Snippet8>
        public override bool IsContentTypeSupported(string contentType) 
        { 
            if (base.IsContentTypeSupported(contentType)) 
            { 
                return true; 
            } 
            if (contentType.Length == this.MediaType.Length) 
            { 
                return contentType.Equals(this.MediaType, StringComparison.OrdinalIgnoreCase); 
            } 
            else 
            { 
                if (contentType.StartsWith(this.MediaType, StringComparison.OrdinalIgnoreCase) 
                    && (contentType[this.MediaType.Length] == ';')) 
                { 
                    return true; 
                } 
            } 
            return false; 
        }
        // </Snippet8>

        // <Snippet4>
        public override Message ReadMessage(ArraySegment<byte> buffer, BufferManager bufferManager, string contentType)
        {   
            byte[] msgContents = new byte[buffer.Count];
            Array.Copy(buffer.Array, buffer.Offset, msgContents, 0, msgContents.Length);
            bufferManager.ReturnBuffer(buffer.Array);

            MemoryStream stream = new MemoryStream(msgContents);
            return ReadMessage(stream, int.MaxValue);
        }
        // </Snippet4>

        // <Snippet5>
        public override Message ReadMessage(Stream stream, int maxSizeOfHeaders, string contentType)
        {
            XmlReader reader = XmlReader.Create(stream);
            return Message.CreateMessage(reader, maxSizeOfHeaders, this.MessageVersion);
        }
        // </Snippet5>

        // <Snippet6>
        public override ArraySegment<byte> WriteMessage(Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset)
        {
            MemoryStream stream = new MemoryStream();
            XmlWriter writer = XmlWriter.Create(stream, this.writerSettings);
            message.WriteMessage(writer);
            writer.Close();
            
            byte[] messageBytes = stream.GetBuffer();
            int messageLength = (int)stream.Position;
            stream.Close();

            int totalLength = messageLength + messageOffset;
            byte[] totalBytes = bufferManager.TakeBuffer(totalLength);
            Array.Copy(messageBytes, 0, totalBytes, messageOffset, messageLength);

            ArraySegment<byte> byteArray = new ArraySegment<byte>(totalBytes, messageOffset, messageLength);
            return byteArray;
        }
        // </Snippet6>

        // <Snippet7>
        public override void WriteMessage(Message message, Stream stream)
        {
            XmlWriter writer = XmlWriter.Create(stream, this.writerSettings);
            message.WriteMessage(writer);
            writer.Close();
        }
        // </Snippet7>
        // </Snippet0>
    }
}
