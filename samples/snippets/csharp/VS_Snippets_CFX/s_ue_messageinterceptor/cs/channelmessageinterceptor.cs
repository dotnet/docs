
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.Text;
using System.ServiceModel.Description;

namespace Microsoft.ServiceModel.Samples
{
    public abstract class ChannelMessageInterceptor
    {
        public virtual void OnSend(ref Message message){}
        public virtual void OnReceive(ref Message message){}

        public virtual void OnExportPolicy(MetadataExporter exporter, PolicyConversionContext context){}

        public virtual void OnImportPolicy(MetadataImporter importer, PolicyConversionContext context){}

        public abstract ChannelMessageInterceptor Clone();
    }
}
