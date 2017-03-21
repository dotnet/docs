         public static void ShowActiveTcpListeners()
         {
             Console.WriteLine("Active TCP Listeners");
             IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
             IPEndPoint[] endPoints =  properties.GetActiveTcpListeners();
             foreach (IPEndPoint e in endPoints)
             {
                 Console.WriteLine(e.ToString());
             }
         }