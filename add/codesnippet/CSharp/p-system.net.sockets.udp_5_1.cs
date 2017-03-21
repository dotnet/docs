        public static void GetSetDontFragment(UdpClient u)
        {
            // Set the don't fragment flag for packets emanating from
            // this client.
            u.DontFragment = true;
            Console.WriteLine("DontFragment value is {0}",
                u.DontFragment);
        }