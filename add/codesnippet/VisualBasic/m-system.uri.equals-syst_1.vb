        ' Create some Uris.
        Dim address1 As New Uri("http://www.contoso.com/index.htm#search")
        Dim address2 As New Uri("http://www.contoso.com/index.htm")
        If address1.Equals(address2) Then
            Console.WriteLine("The two addresses are equal")
        Else
            Console.WriteLine("The two addresses are not equal")
        End If