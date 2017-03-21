            Uri uriAddress = new Uri ("http://user:password@www.contoso.com/index.htm ");
            Console.WriteLine(uriAddress.UserInfo);
            Console.WriteLine("Fully Escaped {0}", uriAddress.UserEscaped ? "yes" : "no");