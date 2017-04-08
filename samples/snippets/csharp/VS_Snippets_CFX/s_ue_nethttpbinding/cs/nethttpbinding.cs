
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Net;
using System.Net.Security;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.Text;
using System.Xml;

namespace Microsoft.Samples.Channels
{
    public class NetHttpBinding : Binding, ISecurityCapabilities
    {
        HttpTransportBindingElement httpTransport;
        HttpsTransportBindingElement httpsTransport;
        BinaryMessageEncodingBindingElement binaryEncoding;

        NetHttpSecurityMode securityMode;

        public NetHttpBinding() : this(NetHttpSecurityMode.Transport)
        {
        }
        public NetHttpBinding(string configurationName) : this()
        {
            ApplyConfiguration(configurationName);
        }
        public NetHttpBinding(NetHttpSecurityMode securityMode)
        {
            if (securityMode != NetHttpSecurityMode.Transport &&
                securityMode != NetHttpSecurityMode.TransportCredentialOnly &&
                securityMode != NetHttpSecurityMode.None)
            {
                throw new ArgumentOutOfRangeException("securityMode");
            }

            this.securityMode = securityMode;   
            this.httpTransport = new HttpTransportBindingElement();
            this.httpsTransport = new HttpsTransportBindingElement();
            this.binaryEncoding = new BinaryMessageEncodingBindingElement();
        }

        public bool BypassProxyOnLocal
        {
            get { return httpTransport.BypassProxyOnLocal; }
            set
            {
                httpTransport.BypassProxyOnLocal = value;
                httpsTransport.BypassProxyOnLocal = value;
            }
        }

        public HostNameComparisonMode HostNameComparisonMode
        {
            get { return httpTransport.HostNameComparisonMode; }
            set
            {
                httpTransport.HostNameComparisonMode = value;
                httpsTransport.HostNameComparisonMode = value;
            }
        }

        public int MaxBufferSize
        {
            get { return httpTransport.MaxBufferSize; }
            set
            {
                httpTransport.MaxBufferSize = value;
                httpsTransport.MaxBufferSize = value;
            }
        }

        public long MaxBufferPoolSize
        {
            get { return httpTransport.MaxBufferPoolSize; }
            set
            {
                httpTransport.MaxBufferPoolSize = value;
                httpsTransport.MaxBufferPoolSize = value;
            }
        }

        public long MaxReceivedMessageSize
        {
            get { return httpTransport.MaxReceivedMessageSize; }
            set
            {
                httpTransport.MaxReceivedMessageSize = value;
                httpsTransport.MaxReceivedMessageSize = value;
            }
        }

        public Uri ProxyAddress
        {
            get { return httpTransport.ProxyAddress; }
            set
            {
                httpTransport.ProxyAddress = value;
                httpsTransport.ProxyAddress = value;
            }
        }

        public NetHttpSecurityMode SecurityMode
        {
            get { return this.securityMode; }
            set
            {
                if (value != NetHttpSecurityMode.Transport &&
                    value != NetHttpSecurityMode.TransportCredentialOnly &&
                    value != NetHttpSecurityMode.None)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                this.securityMode = value;
            }
        }

        public TransferMode TransferMode
        {
            get { return httpTransport.TransferMode; }
            set
            {
                httpTransport.TransferMode = value;
                httpsTransport.TransferMode = value;
            }
        }

        public bool UseDefaultWebProxy
        {
            get { return httpTransport.UseDefaultWebProxy; }
            set
            {
                httpTransport.UseDefaultWebProxy = value;
                httpsTransport.UseDefaultWebProxy = value;
            }
        }

        public XmlDictionaryReaderQuotas ReaderQuotas
        {
            get { return binaryEncoding.ReaderQuotas; }
            set
            {
                if (value != null)
                {
                    value.CopyTo(binaryEncoding.ReaderQuotas);
                }
            }
        }

        public EnvelopeVersion EnvelopeVersion
        {
            get { return EnvelopeVersion.Soap12; }
        }

        public override string Scheme
        {
            get
            {
                if (securityMode == NetHttpSecurityMode.Transport)
                {
                    return httpsTransport.Scheme;
                }
                else
                {
                    return httpTransport.Scheme;
                }
            }
        }

        public override BindingElementCollection CreateBindingElements()
        {   // return collection of BindingElements
            BindingElementCollection bindingElements = new BindingElementCollection();
            bindingElements.Add(binaryEncoding);

            if (this.securityMode == NetHttpSecurityMode.Transport)
            {
                bindingElements.Add(this.httpsTransport);
            }
            else
            {
                if (this.securityMode == NetHttpSecurityMode.TransportCredentialOnly)
                {
                    this.httpTransport.AuthenticationScheme = AuthenticationSchemes.Negotiate;
                }
                else
                {
                    this.httpTransport.AuthenticationScheme = AuthenticationSchemes.Anonymous;
                }
                bindingElements.Add(this.httpTransport);
            }

            return bindingElements.Clone();
        }

        #region ISecurityCapabilities Members

        System.Net.Security.ProtectionLevel ISecurityCapabilities.SupportedRequestProtectionLevel
        {
            get
            {
                if (securityMode == NetHttpSecurityMode.Transport)
                {
                    return ProtectionLevel.EncryptAndSign;
                }
                else
                {
                    return ProtectionLevel.None;
                }
            }
        }

        System.Net.Security.ProtectionLevel ISecurityCapabilities.SupportedResponseProtectionLevel
        {
            get
            {
                if (securityMode == NetHttpSecurityMode.Transport)
                {
                    return ProtectionLevel.EncryptAndSign;
                }
                else
                {
                    return ProtectionLevel.None;
                }
            }
        }

        bool ISecurityCapabilities.SupportsClientAuthentication
        {
            get
            {
                if (securityMode == NetHttpSecurityMode.None)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        bool ISecurityCapabilities.SupportsClientWindowsIdentity
        {
            get
            {
                if (securityMode == NetHttpSecurityMode.None)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        bool ISecurityCapabilities.SupportsServerAuthentication
        {
            get
            {
                if (securityMode == NetHttpSecurityMode.None)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        #endregion

        private void ApplyConfiguration(string configurationName)
        {
            BindingsSection bindings = ((BindingsSection)(ConfigurationManager.GetSection("system.serviceModel/bindings")));
            NetHttpBindingCollectionElement section = (NetHttpBindingCollectionElement)bindings["netHttpBinding"];
            NetHttpBindingElement element = section.Bindings[configurationName];
            if ((element == null))
            {
                throw new System.Configuration.ConfigurationErrorsException(string.Format(CultureInfo.CurrentCulture, "There is no binding named {0} at {1}.", configurationName, section.BindingName));
            }
            else
            {
                element.ApplyConfiguration(this);
            }
        }
    }
}
