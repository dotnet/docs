         public static void ShowActiveUdpListeners()
         {
             Console.WriteLine("Active UDP Listeners");
             IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
             IPEndPoint[] endPoints =  properties.GetActiveUdpListeners();
             foreach (IPEndPoint e in endPoints)
             {
                 Console.WriteLine(e.ToString());
             }
         }