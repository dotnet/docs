        //Formats Web request event information.
        public override void FormatCustomEventDetails(
            WebEventFormatter formatter)
        {
            base.FormatCustomEventDetails(formatter);

            // Add custom data.
            formatter.AppendLine("Custom Process Information:");
            formatter.IndentationLevel += 1;

            // Display the process information.
            formatter.AppendLine(GetAccountName());
            formatter.AppendLine(GetProcessId());
            formatter.AppendLine(GetProcessName());
            formatter.IndentationLevel -= 1;
            formatter.AppendLine(eventInfo.ToString());
        }