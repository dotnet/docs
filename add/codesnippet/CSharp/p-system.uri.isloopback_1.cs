            Uri uriAddress2 =  new Uri("file://server/filename.ext");
            Console.WriteLine(uriAddress2.LocalPath);
            Console.WriteLine("Uri {0} a UNC path", uriAddress2.IsUnc ? "is" : "is not");
            Console.WriteLine("Uri {0} a local host", uriAddress2.IsLoopback ? "is" : "is not");
            Console.WriteLine("Uri {0} a file", uriAddress2.IsFile ? "is" : "is not");