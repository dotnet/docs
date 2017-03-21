            ' A New 'HttpWebRequest' object is created.
            Dim myHttpWebRequest1 As HttpWebRequest = WebRequest.Create("http://www.contoso.com")
            myHttpWebRequest1.AddRange(1000)
            Console.WriteLine("Call AddRange(1000)")
			      Console.Write("Resulting Headers: ")
			      Console.WriteLine(myHttpWebRequest1.Headers.ToString())

            Dim myHttpWebRequest2 As HttpWebRequest = WebRequest.Create("http://www.contoso.com")
            myHttpWebRequest2.AddRange(-1000)
            Console.WriteLine("Call AddRange(-1000)")
			      Console.Write("Resulting Headers: ")
			      Console.WriteLine(myHttpWebRequest2.Headers.ToString())