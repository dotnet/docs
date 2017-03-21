
		

			IPAddress hostIPAddress1 = (Dns.Resolve(hostString1)).AddressList[0];
			Console.WriteLine(hostIPAddress1.ToString());
			IPEndPoint hostIPEndPoint = new IPEndPoint(hostIPAddress1,80);
			Console.WriteLine("\nIPEndPoint information:" + hostIPEndPoint.ToString());
			Console.WriteLine("\n\tMaximum allowed Port Address :" + IPEndPoint.MaxPort);
			Console.WriteLine("\n\tMinimum allowed Port Address :" + IPEndPoint.MinPort);
			Console.WriteLine("\n\tAddress Family :" + hostIPEndPoint.AddressFamily);