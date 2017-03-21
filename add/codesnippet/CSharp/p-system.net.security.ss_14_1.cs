         static void DisplayStreamProperties(SslStream stream)
         {
            Console.WriteLine("Can read: {0}, write {1}", stream.CanRead, stream.CanWrite);
            Console.WriteLine("Can timeout: {0}", stream.CanTimeout);
         }