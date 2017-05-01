
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

namespace Microsoft.ServiceModel.Samples
{
    using System;
    using System.ServiceModel.Dispatcher;
    using System.ServiceModel;
    using System.ServiceModel.Channels;

    class HttpCookieSessionChannelFactory
        : ChannelFactoryBase<IRequestSessionChannel>
    {
        bool exchangeTerminateMessage;
        IChannelFactory<IRequestChannel> innerChannelFactory;

        public HttpCookieSessionChannelFactory(
            HttpCookieSessionBindingElement bindingElement, BindingContext context)
            : base(context.Binding)
        {
            this.exchangeTerminateMessage = bindingElement.ExchangeTerminateMessage;
            this.innerChannelFactory = context.BuildInnerChannelFactory<IRequestChannel>();
        }

        public bool ExchangeTerminateMessage
        {
            get { return this.exchangeTerminateMessage; }
        }

        public override T GetProperty<T>()
        {
            if (typeof(T) == typeof(IChannelFactory<IRequestSessionChannel>))
            {
                return (T)(object)this;
            }

            T baseProperty = base.GetProperty<T>();
            if (baseProperty != null)
            {
                return baseProperty;
            }

            return this.innerChannelFactory.GetProperty<T>();
        }

        protected override IRequestSessionChannel OnCreateChannel(EndpointAddress remoteAddress, Uri via)
        {
            IRequestChannel innerChannel =
                this.innerChannelFactory.CreateChannel(remoteAddress, via);

            return new HttpCookieRequestSessionChannel(this, innerChannel);
        }

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.innerChannelFactory.BeginOpen(timeout, callback, state);
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
            this.innerChannelFactory.EndOpen(result);
        }

        protected override void OnOpen(TimeSpan timeout)
        {
            this.innerChannelFactory.Open(timeout);
        }

        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return new ChainedAsyncResult(timeout, callback, state, base.OnBeginClose, base.OnEndClose, innerChannelFactory.BeginClose, innerChannelFactory.EndClose);
        }

        protected override void OnEndClose(IAsyncResult result)
        {
            ChainedAsyncResult.End(result);
        }

        protected override void OnClose(TimeSpan timeout)
        {
            TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
            base.OnClose(timeoutHelper.RemainingTime());
            this.innerChannelFactory.Close(timeoutHelper.RemainingTime());
        }

        protected override void OnAbort()
        {
            this.innerChannelFactory.Abort();
            base.OnAbort();
        }
    }
}
