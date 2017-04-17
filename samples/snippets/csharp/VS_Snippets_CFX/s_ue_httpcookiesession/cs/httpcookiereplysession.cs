
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

namespace Microsoft.ServiceModel.Samples
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Channels;

    class HttpCookieReplySession : IInputSession
    {
        string id;

        public HttpCookieReplySession()
        {
            this.id = string.Format("ASP.NET_SessionId={0}", Guid.NewGuid().ToString());
        }
        public string Id
        {
            get { return this.id; }
        }
    }
}
