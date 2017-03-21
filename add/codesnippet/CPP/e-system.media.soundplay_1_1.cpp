   // Handler for the LoadCompleted event.
   void player_LoadCompleted( Object^ /*sender*/, AsyncCompletedEventArgs^ /*e*/ )
   {
      String^ message = String::Format( "LoadCompleted: {0}", this->filepathTextbox->Text );
      ReportStatus( message );
      EnablePlaybackControls( true );
   }

