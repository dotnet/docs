
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

namespace Microsoft.ServiceModel.Samples
{
    using System;
    using System.ServiceModel.Channels;
    using System.Configuration;
    using System.ServiceModel;
    using System.ServiceModel.Configuration;

    /// <summary>
    /// Configuration class for InterceptingBindingElement. To make your InterceptingBindingElement
    /// configurable, derive from InterceptingElementInterceptingElement and override CreateMessageInterceptor()
    /// </summary>
    public abstract class InterceptingElement : BindingElementExtensionElement
    {
        protected InterceptingElement()
            : base()
        {
        }

        public override Type BindingElementType
        {
            get
            {
                return typeof(InterceptingBindingElement);
            }
        }

        protected abstract ChannelMessageInterceptor CreateMessageInterceptor();

        protected override BindingElement CreateBindingElement()
        {
            return new InterceptingBindingElement(CreateMessageInterceptor());
        }
    }
}
