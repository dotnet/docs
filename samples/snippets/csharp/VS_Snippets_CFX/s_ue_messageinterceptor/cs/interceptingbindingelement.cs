
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    public class InterceptingBindingElement 
                 : BindingElement
                 , IPolicyExportExtension
    {
        ChannelMessageInterceptor interceptor;

        public InterceptingBindingElement(ChannelMessageInterceptor interceptor)
        {
            this.interceptor = interceptor;
        }

        protected InterceptingBindingElement(InterceptingBindingElement other) 
            : base(other)
        {
            this.interceptor = other.Interceptor;
        }

        public ChannelMessageInterceptor Interceptor
        {
            get
            {
                if (this.interceptor != null)
                {
                    return this.interceptor.Clone();
                }
                else
                {
                    return new NullMessageInterceptor();
                }
            }
        }

        public override BindingElement Clone()
        {
            return new InterceptingBindingElement(this);
        }

        public override bool CanBuildChannelFactory<TChannel>(BindingContext context)
        {
            return context.CanBuildInnerChannelFactory<TChannel>();
        }

        public override bool CanBuildChannelListener<TChannel>(BindingContext context)
        {
            return context.CanBuildInnerChannelListener<TChannel>();
        }

        public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
        {
            return new InterceptingChannelFactory<TChannel>(this.Interceptor, context);
        }

        public override IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)
        {
            return new InterceptingChannelListener<TChannel>(this.Interceptor, context);
        }

        public override T GetProperty<T>(BindingContext context)
        {
            if (typeof(T) == typeof(ChannelMessageInterceptor))
            {
                return (T)(object)this.Interceptor;
            }

            return context.GetInnerProperty<T>();
        }

        void IPolicyExportExtension.ExportPolicy(MetadataExporter exporter, PolicyConversionContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            this.interceptor.OnExportPolicy(exporter, context);
        }


        class NullMessageInterceptor : ChannelMessageInterceptor
        {
            public override ChannelMessageInterceptor Clone()
            {
                return new NullMessageInterceptor();
            }
        }
    }
}

