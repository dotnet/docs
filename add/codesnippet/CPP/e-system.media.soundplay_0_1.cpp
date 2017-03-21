   // Handler for the SoundLocationChanged event.
   void player_LocationChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      String^ message = String::Format( "SoundLocationChanged: {0}", player->SoundLocation );
      ReportStatus( message );
   }

