//  Copyright (c) Microsoft Corporation. All rights reserved.

using System;
using System.Runtime.Serialization;

namespace Microsoft.Syndication.Samples
{
    [DataContract]
    public class DataContractExtension
    {
        [DataMember]
        public string Key;

        [DataMember]
        public int Value;

        public override string ToString()
        {
            return String.Format("DataContractExtension: Key={0}, Value={1}", Key, Value);
        }
    }

    public class XmlSerializerExtension
    {
        public string Key
        { get; set; }
        public int Value
        { get; set; }

        public override string ToString()
        {
            return String.Format("XmlSerializerExtension: Key={0}, Value={1}", Key, Value);
        }
    }
}
