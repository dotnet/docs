        //Formats Web request event information.
        public override void FormatCustomEventDetails(
            WebEventFormatter formatter)
        {
            base.FormatCustomEventDetails(formatter);

            // Add custom data.
            formatter.AppendLine("");
            formatter.AppendLine(
            "Custom Application Information:");
            formatter.IndentationLevel += 1;

            // Display the application information.
            formatter.AppendLine(GetApplicationDomain());
            formatter.AppendLine(GetApplicationPath());
            formatter.AppendLine(GetApplicationVirtualPath());
            formatter.AppendLine(GetApplicationMachineName());
            formatter.AppendLine(GetApplicationTrustLevel());
            formatter.IndentationLevel -= 1;
            formatter.AppendLine(eventInfo.ToString());
        }