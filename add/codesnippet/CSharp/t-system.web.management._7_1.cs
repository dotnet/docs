        //Formats Web request event information.
        public override void FormatCustomEventDetails(
            WebEventFormatter formatter)
        {
            base.FormatCustomEventDetails(formatter);

            // Add custom data.
            formatter.AppendLine("");

            formatter.IndentationLevel += 1;

            formatter.TabSize = 4;

            formatter.AppendLine(
                 "*SampleWebBaseEvent Start *");

            // Display custom event information.
            formatter.AppendLine(customCreatedMsg);
            formatter.AppendLine(customRaisedMsg);
            formatter.AppendLine(firingRecordInfo);

            formatter.AppendLine(
          "* SampleWebBaseEvent End *");


            formatter.IndentationLevel -= 1;

        }