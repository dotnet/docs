
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

namespace Microsoft.ServiceModel.Samples
{
    using System;
    using System.ServiceModel.Channels;

    static class HttpCookieSessionDefaults
    {
        public static TimeSpan SessionTimeout { get { return TimeSpan.FromMinutes(10); } }
        public const string SessionTimeoutString = "00:10:00";

        // Do not exchange the terminate message by default.
        public const bool ExchangeTerminateMessage = false;

        // Name of the resource file.
        public const string ResourceFileName =
            "Microsoft.ServiceModel.Samples.Properties.Resources";
    }

    static class HttpCookieConfigurationStrings
    {
        public const string ExchangeTerminateMessageProperty = "exchangeTerminateMessage";
        public const string SessionTimeoutProperty = "sessionTimeout";
        public const string HttpCookieSessionBindingSectionName =
            "system.serviceModel/bindings/httpCookieSessionBinding";
    }

    static class HttpCookiePolicyStrings
    {
        public const string Prefix = "hc";
        public const string Namespace = "http://samples.microsoft.com/wcf/session/policy";
        public const string HttpCookiePolicyElement = "httpCookie";
        public const string ExchangeTerminateAttribute = "exchangeTerminate";
    }
}
