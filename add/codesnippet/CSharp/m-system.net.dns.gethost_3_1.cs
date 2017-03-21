   public void DisplayLocalHostName()
   {
      try {
         // Get the local computer host name.
         String hostName = Dns.GetHostName();
         Console.WriteLine("Computer name :" + hostName);
      }
      catch(SocketException e) {
         Console.WriteLine("SocketException caught!!!");
         Console.WriteLine("Source : " + e.Source);
         Console.WriteLine("Message : " + e.Message);
      }
	  catch(Exception e)
	  {
		  Console.WriteLine("Exception caught!!!");
		  Console.WriteLine("Source : " + e.Source);
		  Console.WriteLine("Message : " + e.Message);
	  }
   }