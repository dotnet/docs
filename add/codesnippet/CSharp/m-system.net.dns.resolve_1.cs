     try {
         IPHostEntry hostInfo = Dns.Resolve(hostString);
         // Get the IP address list that resolves to the host names contained in the 
         // Alias property.
         IPAddress[] address = hostInfo.AddressList;
         // Get the alias names of the addresses in the IP address list.
         String[] alias = hostInfo.Aliases;

         Console.WriteLine("Host name : " + hostInfo.HostName);
         Console.WriteLine("\nAliases : ");
         for(int index=0; index < alias.Length; index++) {
           Console.WriteLine(alias[index]);
         } 
         Console.WriteLine("\nIP Address list :");
         for(int index=0; index < address.Length; index++) {
            Console.WriteLine(address[index]);
         }
      }
      catch(SocketException e) 
      {
         Console.WriteLine("SocketException caught!!!");
         Console.WriteLine("Source : " + e.Source);
         Console.WriteLine("Message : " + e.Message);
      }
      catch(ArgumentNullException e)
      {
	 Console.WriteLine("ArgumentNullException caught!!!");
         Console.WriteLine("Source : " + e.Source);
         Console.WriteLine("Message : " + e.Message);
      }
	  catch(NullReferenceException e)
	  {
		  Console.WriteLine("NullReferenceException caught!!!");
		  Console.WriteLine("Source : " + e.Source);
		  Console.WriteLine("Message : " + e.Message);
	  }
	  catch(Exception e)
	  {
		  Console.WriteLine("Exception caught!!!");
		  Console.WriteLine("Source : " + e.Source);
		  Console.WriteLine("Message : " + e.Message);
	  }