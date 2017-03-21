   Ping ^ pingSender = gcnew Ping;
   PingOptions ^ options = gcnew PingOptions;
   
   // Use the default Ttl value which is 128,
   // but change the fragmentation behavior.
   options->DontFragment = true;
   