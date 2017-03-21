   Ping ^ pingSender = gcnew Ping;
   
   // When the PingCompleted event is raised,
   // the PingCompletedCallback method is called.
   pingSender->PingCompleted += gcnew PingCompletedEventHandler( PingCompletedCallback );
   