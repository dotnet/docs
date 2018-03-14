
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

namespace Microsoft.ServiceModel.Samples
{
    using System;
    using System.ServiceModel.Channels;
    using System.ServiceModel;
    using System.ServiceModel.Configuration;
    using System.Configuration;

    public class HttpCookieSessionBinding : Binding
    {
        HttpCookieSessionBindingElement sessionElement;
        HttpTransportBindingElement transportElement;
        TextMessageEncodingBindingElement encodingElement;

        public HttpCookieSessionBinding()
            : base()
        {
            sessionElement = new HttpCookieSessionBindingElement();

            transportElement = new HttpTransportBindingElement();
            transportElement.AllowCookies = true;

            encodingElement = new TextMessageEncodingBindingElement();
            encodingElement.MessageVersion = MessageVersion.Soap11WSAddressing10;
        }

        public HttpCookieSessionBinding(string configurationName) 
            : this()
        {
            ApplyConfiguration(configurationName);
        }

        public TimeSpan SessionTimeout
        {
            get { return sessionElement.SessionTimeout; }
            set { sessionElement.SessionTimeout = value; }
        }

        public bool ExchangeTerminateMessage
        {
            get { return sessionElement.ExchangeTerminateMessage; }
            set { sessionElement.ExchangeTerminateMessage = value; }
        }

        public override string Scheme
        {
            // Read the scheme from the transport.
            get { return transportElement.Scheme; }
        }

        public override BindingElementCollection CreateBindingElements()
        {

            BindingElementCollection bindingElements = new BindingElementCollection();
            
            bindingElements.Add(sessionElement);
            bindingElements.Add(encodingElement);
            bindingElements.Add(transportElement);
            
            return bindingElements.Clone();
        }

        void ApplyConfiguration(string configurationName)
        {
            HttpCookieSessionBindingCollectionElement section =
                (HttpCookieSessionBindingCollectionElement)ConfigurationManager.GetSection(
                    HttpCookieConfigurationStrings.HttpCookieSessionBindingSectionName);

            HttpCookieSessionBindingConfigurationElement element = section.Bindings[configurationName];
            element.ApplyConfiguration(this);
        }
    }
}
