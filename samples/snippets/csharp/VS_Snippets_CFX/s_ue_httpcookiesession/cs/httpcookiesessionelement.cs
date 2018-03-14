
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

namespace Microsoft.ServiceModel.Samples
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Configuration;
    using System.ServiceModel.Channels;
    using System.Configuration;

    // Implements the configuration for HttpCookieSessionBindingElement.
    public sealed class HttpCookieSessionElement 
        : BindingElementExtensionElement
    {
        bool exchangeTerminateMessage;
        ConfigurationPropertyCollection properties;
        TimeSpan sessionTimeout;

        public HttpCookieSessionElement()
        {
        }

        public override Type BindingElementType
        {
            get { return typeof(HttpCookieSessionBindingElement); }
        }

        public TimeSpan SessionTimeout
        {
            get { return this.sessionTimeout; }
            set { this.sessionTimeout = value; }
        }

        public bool ExchangeTerminateMessage
        {
            get { return this.exchangeTerminateMessage; }
            set { this.exchangeTerminateMessage = value; }
        }

        public override void ApplyConfiguration(BindingElement bindingElement)
        {
            base.ApplyConfiguration(bindingElement);
            
            HttpCookieSessionBindingElement typedBindingElement = 
                (HttpCookieSessionBindingElement)bindingElement;
            
            this.sessionTimeout = typedBindingElement.SessionTimeout; 
            
            this.exchangeTerminateMessage = 
                typedBindingElement.ExchangeTerminateMessage;
        }        

        protected override BindingElement CreateBindingElement()
        {
            HttpCookieSessionBindingElement bindingElement = 
                new HttpCookieSessionBindingElement();
            
            bindingElement.ExchangeTerminateMessage = exchangeTerminateMessage;
            bindingElement.SessionTimeout = sessionTimeout;
            ApplyConfiguration(bindingElement);
            
            return bindingElement;
        }
        
        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                if (properties == null)
                {
                    properties = new ConfigurationPropertyCollection();
                    
                    properties.Add(
                        new ConfigurationProperty(
                            HttpCookieConfigurationStrings.SessionTimeoutProperty,
                            typeof(TimeSpan), TimeSpan.FromSeconds(10)));

                    properties.Add(
                        new ConfigurationProperty(
                            HttpCookieConfigurationStrings.ExchangeTerminateMessageProperty,
                            typeof(bool), "false"));
                }

                return properties;
            }
        }

        protected override void InitializeFrom(BindingElement bindingElement)
        {
            base.InitializeFrom(bindingElement);

            HttpCookieSessionBindingElement httpCookieBindingElement = (HttpCookieSessionBindingElement)bindingElement;
            this.SessionTimeout = httpCookieBindingElement.SessionTimeout;
            this.ExchangeTerminateMessage = httpCookieBindingElement.ExchangeTerminateMessage;
        }
    }
}
