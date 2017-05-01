
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;
namespace Microsoft.Samples.Channels.ChunkingChannel
{
    public class ChunkingUtils
    {
        public const int ChunkSize = 4 * 1024; //4KB
        public const int MaxBufferedChunksDefault = 10;
        public const string ChunkElement = "chunk";
        public const string ChunkHeaderWrapperElement = "OriginalHeaders";
        public const string ChunkNs = "http://samples.microsoft.com/chunking";
        public const string ChunkNumberHeader = "ChunkNumber";
        public const string ChunkingEndHeader = "ChunkingEnd";
        public const string MessageIdHeader = "MessageId";
        public const string ChunkingStartHeader = "ChunkingStart";
        public const string OriginalAction = "OriginalAction";
        public const string ChunkAction = "http://samples.microsoft.com/chunkingAction";
        public const string WsAddressing10Ns = "http://www.w3.org/2005/08/addressing";
        public const string WsAddressingAugust2004Ns = "http://schemas.xmlsoap.org/ws/2004/08/addressing";
        public static readonly TimeSpan ChunkReceiveTimeout = TimeSpan.FromMinutes(3);

        public static T GetMessageHeader<T>(Message message,string name, string ns)
        {
            int index=message.Headers.FindHeader(name,ns);
            if (index > -1)
            {
                T val= message.Headers.GetHeader<T>(index);
                return val;
            }
            else
            {
                return default(T);
            }

        }
        public static string GetAddressingNamespace(MessageVersion version)
        {
            if(version.Addressing == AddressingVersion.WSAddressing10)
            {
                
                    return ChunkingUtils.WsAddressing10Ns;
            }
            else
            {
                    return ChunkingUtils.WsAddressingAugust2004Ns;
            }
        }
    }
}
