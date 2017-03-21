        public AxMaskEdBox()
            :
          base("c932ba85-4374-101b-a56c-00aa003668dc") // The ActiveX control's class identifier.
        {
            // Make the AboutBox method the about box delegate.
            this.SetAboutBoxDelegate(new AboutBoxDelegate(AboutBox));
        }

        public virtual void AboutBox()
        {
            // If the instance of the ActiveX control is null when the AboutBox method 
            // is called, raise an InvalidActiveXStateException exception.
            if ((this.ocx == null))
            {
                throw new System.Windows.Forms.AxHost.InvalidActiveXStateException(
                  "AboutBox", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
            }
            // Show the about box if the ActiveX control has one.
            if (this.HasAboutBox)
            {
                this.ocx.AboutBox();
            }
        }

        protected override void AttachInterfaces()
        {
            try
            {
                // Attach the IMSMask interface to the ActiveX control.
                this.ocx = ((MSMask.IMSMask)(this.GetOcx()));
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }