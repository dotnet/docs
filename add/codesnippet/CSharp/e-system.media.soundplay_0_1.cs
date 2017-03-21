        // Handler for the SoundLocationChanged event.
        private void player_LocationChanged(object sender, EventArgs e)
        {   
            string message = String.Format("SoundLocationChanged: {0}", 
                player.SoundLocation);
            ReportStatus(message);
        }