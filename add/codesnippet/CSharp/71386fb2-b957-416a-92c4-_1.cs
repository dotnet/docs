        // Initializes the provider.
        public override void Initialize(string name,
         NameValueCollection config)
        {
            base.Initialize(name, config);

            // Get the configuration information.
            providerName = name;
            buffer = SampleUseBuffering.ToString();
            bufferModality = SampleBufferMode;

            customInfo.AppendLine(string.Format(
                "Provider name: {0}", providerName));
            customInfo.AppendLine(string.Format(
                "Buffering: {0}", buffer));
            customInfo.AppendLine(string.Format(
                "Buffering modality: {0}", bufferModality));

        }