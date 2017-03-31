
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

namespace Microsoft.ServiceModel.Samples
{
    using System;
    using System.ServiceModel.Channels;
    using System.ServiceModel;
    using System.ServiceModel.Configuration;
    using System.Configuration;

    // Configuration for HttpCookieSessionBinding.
    public class HttpCookieSessionBindingCollectionElement  : 
        StandardBindingCollectionElement<HttpCookieSessionBinding, 
        HttpCookieSessionBindingConfigurationElement>
    {     
    }
}
