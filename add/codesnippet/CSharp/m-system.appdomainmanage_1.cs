        public override void InitializeNewDomain(AppDomainSetup appDomainInfo)
        {
            Console.Write("Initialize new domain called:  ");
            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);
            InitializationFlags = 
                AppDomainManagerInitializationOptions.RegisterWithHost;
        }