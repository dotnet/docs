		private SoundPlayer Player = new SoundPlayer();
		private void loadSoundAsync()
		{
			// Note: You may need to change the location specified based on
			// the location of the sound to be played.
			this.Player.SoundLocation = "http://www.tailspintoys.com/sounds/stop.wav";
			this.Player.LoadAsync();
		}
		
		private void Player_LoadCompleted (
            object sender, 
            System.ComponentModel.AsyncCompletedEventArgs e)
		{
		    if (this.Player.IsLoadCompleted)
		    {
		        this.Player.PlaySync();
		    }
		}