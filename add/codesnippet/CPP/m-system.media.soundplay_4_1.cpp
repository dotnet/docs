private:
   SoundPlayer^ Player;

   void loadSoundAsync()
   {
      // Note: You may need to change the location specified based on
      // the location of the sound to be played.
      this->Player->SoundLocation = "http://www.tailspintoys.com/sounds/stop.wav";
      this->Player->LoadAsync();
   }

   void Player_LoadCompleted( Object^ /*sender*/, System::ComponentModel::AsyncCompletedEventArgs^ /*e*/ )
   {
      if (this->Player->IsLoadCompleted == true)
      {
         this->Player->PlaySync();
      }
   }