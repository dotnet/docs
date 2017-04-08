
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel.Description;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml;


namespace Microsoft.ServiceModel.Samples
{
    public abstract class InterceptingBindingElementImporter: IPolicyImportExtension
    {
        void IPolicyImportExtension.ImportPolicy(MetadataImporter importer, PolicyConversionContext context)
        {
            ChannelMessageInterceptor messageInterceptor = CreateMessageInterceptor();
            messageInterceptor.OnImportPolicy(importer, context);
        }

        protected abstract ChannelMessageInterceptor CreateMessageInterceptor();
    }
}
