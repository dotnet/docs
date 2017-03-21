            Uri address6 = new Uri("gopher://example.contoso.com/");
            if (address6.Scheme == Uri.UriSchemeGopher)
                Console.WriteLine("Uri is Gopher protocol");