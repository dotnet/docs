            Uri address2 =  new Uri("file://server/filename.ext");
            if (address2.Scheme == Uri.UriSchemeFile) 
                Console.WriteLine("Uri is a file");