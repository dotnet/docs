            // Check whether the underlying stream supports seeking.
            Console.WriteLine("NetworkStream {0} seeking.\n",
                bufStream.CanSeek ? "supports" : "does not support");