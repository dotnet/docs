
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

namespace Microsoft.ServiceModel.Samples
{
    using System;
    using System.ServiceModel.Description;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.Xml;

    public class HttpCookieSessionBindingElement 
        : BindingElement
        , IPolicyExportExtension
    {
        internal const string TerminateAction = "http://samples.microsoft.com/wcf/httpcookiesession/terminate";
        internal const string TerminateReplyAction = "http://samples.microsoft.com/wcf/httpcookiesession/terminateReply";

        TimeSpan sessionTimeout;

        // Indicates whether the terminate message is 
        // exchanged when the client closes the request 
        // channel.
        bool exchangeTerminateMessage;
        
        // XmlDocument is used to generate the Policy assertion elements.        
        static XmlDocument xmlDocument = new XmlDocument();

        public HttpCookieSessionBindingElement()
            : base()
        {
            sessionTimeout = HttpCookieSessionDefaults.SessionTimeout;
            exchangeTerminateMessage = HttpCookieSessionDefaults.ExchangeTerminateMessage;
        }

        protected HttpCookieSessionBindingElement(HttpCookieSessionBindingElement other) 
            : base(other)
        {
            sessionTimeout = other.sessionTimeout;
            exchangeTerminateMessage = other.exchangeTerminateMessage;
        }

        public TimeSpan SessionTimeout
        {
            get { return this.sessionTimeout; }
            set { this.sessionTimeout = value; }
        }

        /// <summary>
        /// Checks whehter the terminate message should be exchanged when the 
        /// client closes the request channel.
        /// </summary>        
        public bool ExchangeTerminateMessage
        {
            get { return this.exchangeTerminateMessage; }
            set { this.exchangeTerminateMessage = value; }
        }

        public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            ThrowIfNotHttpTransport(context.Binding);

            if (typeof(TChannel) != typeof(IRequestSessionChannel))
            {
                throw new ArgumentException("HttpCookieSessionBindingElement only supports IRequestSessionChannel Factories.", "TChannel");
            }

            if (!context.CanBuildInnerChannelFactory<IRequestChannel>())
            {
                throw new InvalidOperationException(
                    "HttpCookieSessionBindingElement must be stacked on top of a channel that supports IRequestChannel.");
            }

            return (IChannelFactory<TChannel>)(object)new HttpCookieSessionChannelFactory(this, context);
        }

        public override IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            ThrowIfNotHttpTransport(context.Binding);
            if (typeof(TChannel) != typeof(IReplySessionChannel))
            {
                throw new ArgumentException("HttpCookieSessionBindingElement only supports IReplySessionChannel Listeners.", "TChannel");
            }

            if (!context.CanBuildInnerChannelListener<IReplyChannel>())
            {
                throw new InvalidOperationException(
                    "HttpCookieSessionBindingElement must be stacked on top of a channel that supports IReplyChannel Listeners.");
            }

            return (IChannelListener<TChannel>)(object)new HttpCookieReplySessionChannelListener(this, context);
        }

        /// <summary>
        /// Used by the higher layers to determine what types of channel factories this
        /// binding element supports. 
        /// </summary>
        public override bool CanBuildChannelFactory<TChannel>(BindingContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (IsBindingHttp(context.Binding)
                && typeof(TChannel) == typeof(IRequestSessionChannel)
                && context.CanBuildInnerChannelFactory<IRequestChannel>())
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Used by the higher layers to determine what types of channel listeners this
        /// binding element supports. 
        /// </summary>
        public override bool CanBuildChannelListener<TChannel>(BindingContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (IsBindingHttp(context.Binding)
                && typeof(TChannel) == typeof(IReplySessionChannel)
                && context.CanBuildInnerChannelListener<IReplyChannel>())
            {
                return true;
            }

            return false;
        }

        public override BindingElement Clone()
        {
            return new HttpCookieSessionBindingElement(this);
        }

        public override T GetProperty<T>(BindingContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            return context.GetInnerProperty<T>();
        }

        bool IsBindingHttp(Binding binding)
        {
            return (string.Compare(binding.Scheme, "http", StringComparison.OrdinalIgnoreCase) == 0
                 || string.Compare(binding.Scheme, "https", StringComparison.OrdinalIgnoreCase) == 0);
        }

        void ThrowIfNotHttpTransport(CustomBinding binding)
        {
            if (!IsBindingHttp(binding))
            {
                throw new InvalidOperationException(
                    "HttpCookieSessionBindingElement can only be used in conjunction with an HTTP-based channel stack.");
            }
        }

        void IPolicyExportExtension.ExportPolicy(MetadataExporter exporter, PolicyConversionContext context)
        {
            if (exporter == null)
            {
                throw new NullReferenceException("exporter");
            }

            if (context == null)
            {
                throw new NullReferenceException("context");
            }

            XmlElement mhscElement = xmlDocument.CreateElement(HttpCookiePolicyStrings.Prefix,
                HttpCookiePolicyStrings.HttpCookiePolicyElement, 
                HttpCookiePolicyStrings.Namespace);

            if (exchangeTerminateMessage)
            {
                XmlAttribute attribute = xmlDocument.CreateAttribute(
                    HttpCookiePolicyStrings.ExchangeTerminateAttribute);
                
                attribute.Value = "true";

                mhscElement.Attributes.Append(attribute);
            }

            context.GetBindingAssertions().Add(mhscElement);            
        }
    }
}
