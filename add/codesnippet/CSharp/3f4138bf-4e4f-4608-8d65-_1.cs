
        // Formats Web request event information.
        public override void FormatCustomEventDetails(
         WebEventFormatter formatter)
        {

            // Add custom data.

            formatter.AppendLine("");
            formatter.AppendLine(
                "Custom Thread Information:");

            formatter.IndentationLevel += 1;

            // Display the thread information obtained 
            formatter.AppendLine(GetThreadImpersonation());
            formatter.AppendLine(GetThreadStackTrace());
            formatter.AppendLine(GetThreadAccountName());
            formatter.AppendLine(GetThreadId());
            formatter.IndentationLevel -= 1;

            formatter.AppendLine(eventInfo.ToString());

        }
