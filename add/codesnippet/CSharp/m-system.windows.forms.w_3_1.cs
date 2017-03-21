        AxHost.ConnectionPointCookie cookie;
        WebBrowser2EventHelper helper;

        [PermissionSetAttribute(SecurityAction.LinkDemand, Name="FullTrust")]
        protected override void CreateSink()
        {
            base.CreateSink();

            // Create an instance of the client that will handle the event
            // and associate it with the underlying ActiveX control.
            helper = new WebBrowser2EventHelper(this);
            cookie = new AxHost.ConnectionPointCookie(
                this.ActiveXInstance, helper, typeof(DWebBrowserEvents2));
        }

        [PermissionSetAttribute(SecurityAction.LinkDemand, Name="FullTrust")]
        protected override void DetachSink()
        {
            // Disconnect the client that handles the event
            // from the underlying ActiveX control.
            if (cookie != null)
            {
                cookie.Disconnect();
                cookie = null;
            }
            base.DetachSink();
        }