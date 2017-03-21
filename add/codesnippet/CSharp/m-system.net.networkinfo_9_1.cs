         public static void ShowActiveTcpConnections()
         {
                    Console.WriteLine("Active TCP Connections");
                    IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
                    TcpConnectionInformation[] connections = properties.GetActiveTcpConnections(); 
                    foreach (TcpConnectionInformation c in connections)
                    {
                        Console.WriteLine("{0} <==> {1}", 
                            c.LocalEndPoint.ToString(), 
                            c.RemoteEndPoint.ToString());
                    }
         }