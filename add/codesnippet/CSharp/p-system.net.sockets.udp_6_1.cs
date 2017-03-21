        public static void GetSetTtl(UdpClient u)
        {
            // Set the Time To Live (TTL) for this client.
            u.Ttl = 42;
            Console.WriteLine("Ttl value is {0}",
                u.Ttl);
        }