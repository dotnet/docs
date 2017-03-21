        // Handler for the LoadCompleted event.
        private void player_LoadCompleted(object sender, 
            AsyncCompletedEventArgs e)
        {   
            string message = String.Format("LoadCompleted: {0}", 
                this.filepathTextbox.Text);
            ReportStatus(message);
            EnablePlaybackControls(true);
        }