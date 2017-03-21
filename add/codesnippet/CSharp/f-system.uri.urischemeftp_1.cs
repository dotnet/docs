            Uri address7 = new Uri("ftp://contoso/files/testfile.txt");
            if (address7.Scheme == Uri.UriSchemeFtp)
                Console.WriteLine("Uri is Ftp protocol");