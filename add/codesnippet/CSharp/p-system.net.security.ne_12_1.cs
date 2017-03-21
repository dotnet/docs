         static void DisplayStreamProperties(NegotiateStream stream)
        {
             Console.WriteLine("Can read: {0}", stream.CanRead);
             Console.WriteLine("Can write: {0}", stream.CanWrite);
             Console.WriteLine("Can seek: {0}", stream.CanSeek);
             try 
             {
                 // If the underlying stream supports it, display the length.
                 Console.WriteLine("Length: {0}", stream.Length);
             } catch (NotSupportedException)
             {
                     Console.WriteLine("Cannot get the length of the underlying stream.");
             }
             
             if (stream.CanTimeout)
             {
                 Console.WriteLine("Read time-out: {0}", stream.ReadTimeout);
                 Console.WriteLine("Write time-out: {0}", stream.WriteTimeout);
             }
        }