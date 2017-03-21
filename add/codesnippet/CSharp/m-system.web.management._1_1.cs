        // Raises the SampleWebBaseEvent.
        public override void Raise()
        {
            // Perform custom processing. 
            customRaisedMsg =
              string.Format("Event raised at: {0}",
              EventTime.ToString());

            // Raise the event.
            base.Raise();
        }