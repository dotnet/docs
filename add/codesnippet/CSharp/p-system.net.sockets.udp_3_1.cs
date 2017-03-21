        public static void GetSetEnableBroadcast(UdpClient u)
        {
            // Set the Broadcast flag for this client.
            u.EnableBroadcast = true;
            Console.WriteLine("EnableBroadcast value is {0}",
                u.EnableBroadcast);
        }