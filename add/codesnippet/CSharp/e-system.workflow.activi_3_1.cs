        [System.Diagnostics.DebuggerNonUserCode]
        private void InitializeComponent()
        {
            SendActivity sendActivity1 = new SendActivity();
            sendActivity1.BeforeSend += new EventHandler<SendActivityEventArgs>(sendActivity1_BeforeSend);
        }

        void sendActivity1_BeforeSend(object sender, SendActivityEventArgs e)
        {
            Console.WriteLine("SendActivity1 BeforeSend event fired.");
        }

        void sendActivity1_AfterResponse(object sender, SendActivityEventArgs e)
        {
            Console.WriteLine("SendActivity1 AfterResponse event fired.");
        }