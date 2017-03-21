        [System.Diagnostics.DebuggerNonUserCode]
        private void InitializeComponent()
        {
            SendActivity sendActivity1 = new SendActivity();
            sendActivity1.AfterResponse += new EventHandler<SendActivityEventArgs>(sendActivity1_AfterResponse);
        }

        void sendActivity1_AfterResponse(object sender, SendActivityEventArgs e)
        {
            Console.WriteLine("SendActivity1 AfterResponse event fired.");
        }
            