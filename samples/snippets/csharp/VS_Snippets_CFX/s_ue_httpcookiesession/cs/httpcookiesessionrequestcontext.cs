
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

#region using

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Net;

#endregion

namespace Microsoft.ServiceModel.Samples
{
    /// <summary>
    /// This class contains the RequestContext 
    /// implementation used by 
    /// HttpCookieSessionExtension. This gives a 
    /// wrapper to an RequestContext coming from 
    /// the lower channels. 
    /// </summary>
    class HttpCookieSessionRequestContext : RequestContext
    {
        // A Boolean value to indicate whether this request 
        // is the initial request for the session.
        bool isInitial;

        RequestContext innerRequestContext;
        string sessionId;

        public HttpCookieSessionRequestContext(
            RequestContext innerRequestContext, 
            string sessionId, 
            bool isInitial)
        {
            this.sessionId = sessionId;
            this.innerRequestContext = innerRequestContext;
            this.isInitial = isInitial;
        }

        public override Message RequestMessage
        {
            get { return innerRequestContext.RequestMessage; }
        }

        public override IAsyncResult BeginReply(Message message, AsyncCallback callback, object state)
        {
            AddSessionData(message);
            return innerRequestContext.BeginReply(
                message, callback, state);
        }

        public override IAsyncResult BeginReply(Message message, TimeSpan timeout, 
            AsyncCallback callback, object state)
        {
            // Add the session metadata.
            AddSessionData(message);    

            return innerRequestContext.BeginReply(
                message, timeout, callback, state);
        }

        public override void EndReply(IAsyncResult result)
        {
            innerRequestContext.EndReply(result);
        }

        public override void Reply(Message message, TimeSpan timeout)
        {
            AddSessionData(message);
            innerRequestContext.Reply(message, timeout);
        }

        public override void Reply(Message message)
        {
            AddSessionData(message);            
            innerRequestContext.Reply(message);
        }

        public override void Abort()
        {
            innerRequestContext.Abort();
        }

        public override void Close()
        {
            innerRequestContext.Close();
        }

        public override void Close(TimeSpan timeout)
        {
            innerRequestContext.Close(timeout);
        }

        public void Dispose()
        {
            ((IDisposable)innerRequestContext).Dispose();
        }

        /// <summary>
        /// Adds session id to the out going HTTP response header.
        /// </summary>        
        void AddSessionData(Message message)
        {
            // Add the HTTP response header only. 
            // if this is the first request.
            if (isInitial)
            {
                string sessionCookie = 
                    string.Format("{0}", this.sessionId);

                HttpResponseMessageProperty httpResponse;

                if (message.Properties.ContainsKey(HttpResponseMessageProperty.Name))
                {
                    httpResponse =
                        (HttpResponseMessageProperty)message.Properties[HttpResponseMessageProperty.Name];
                }
                else
                {
                    httpResponse = 
                        new HttpResponseMessageProperty();

                    message.Properties.Add(HttpResponseMessageProperty.Name, httpResponse);
                }
                
                httpResponse.Headers[HttpResponseHeader.SetCookie] = sessionCookie;
            }
        }
    }
}
