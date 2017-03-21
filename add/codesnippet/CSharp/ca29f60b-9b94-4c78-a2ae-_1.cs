
        // Formats Web request event information.
        public override void FormatCustomEventDetails(
         WebEventFormatter formatter)
        {

            // Add custom data.

            formatter.AppendLine("");
            formatter.AppendLine(
                "Custom Request Information:");

            formatter.IndentationLevel += 1;

            // Display the request information obtained 
            // using the WebRequestInformation object.
            formatter.AppendLine(GetRequestPath());
            formatter.AppendLine(GetRequestUrl());
            formatter.AppendLine(GetRequestUserHostAdddress());
            formatter.AppendLine(GetRequestPrincipal());

            formatter.IndentationLevel -= 1;

            formatter.AppendLine(eventInfo.ToString());

        }
