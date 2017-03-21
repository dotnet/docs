   
   public void GetIpAddressList(String hostString)
   {
	   try 
	   {
		   // Get 'IPHostEntry' object containing information like host name, IP addresses, aliases for a host.
		   IPHostEntry hostInfo = Dns.GetHostByName(hostString);
		   Console.WriteLine("Host name : " + hostInfo.HostName);
		   Console.WriteLine("IP address List : ");
		   for(int index=0; index < hostInfo.AddressList.Length; index++)
		   {
			   Console.WriteLine(hostInfo.AddressList[index]);
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
	   catch(Exception e)
	   {
		   Console.WriteLine("Exception caught!!!");
		   Console.WriteLine("Source : " + e.Source);
		   Console.WriteLine("Message : " + e.Message);
	   }
   }