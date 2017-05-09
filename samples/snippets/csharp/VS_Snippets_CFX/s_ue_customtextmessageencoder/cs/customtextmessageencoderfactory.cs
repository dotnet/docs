
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.ServiceModel.Samples
{
    // <Snippet8>
    public class CustomTextMessageEncoderFactory : MessageEncoderFactory
    {
        private MessageEncoder encoder;
        private MessageVersion version;
        private string mediaType;
        private string charSet;

        internal CustomTextMessageEncoderFactory(string mediaType, string charSet,
            MessageVersion version)
        {
            this.version = version;
            this.mediaType = mediaType;
            this.charSet = charSet;
            this.encoder = new CustomTextMessageEncoder(this);
        }
    
        // <Snippet9>
        public override MessageEncoder Encoder
        {
            get 
            { 
                return this.encoder;
            }
        }
        // </Snippet9>

        // <Snippet10>
        public override MessageVersion MessageVersion
        {
            get 
            { 
                return this.version;
            }
        }
        // </Snippet10>

        internal string MediaType
        {
            get
            {
                return this.mediaType;
            }
        }

        internal string CharSet
        {
            get
            {
                return this.charSet;
            }
        }
    }
    // </Snippet8>
}
