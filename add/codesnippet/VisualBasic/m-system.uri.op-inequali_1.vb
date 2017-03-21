        ' Create some Uris.
        Dim address1 As New Uri("http://www.contoso.com/index.htm#search")
        Dim address2 As New Uri("http://www.contoso.com/index.htm")
        Dim address3 As New Uri("http://www.contoso.com/index.htm?date=today")
        
        ' The first two are equal because the fragment is ignored.
        If address1 = address2 Then
            Console.WriteLine("{0} is equal to {1}", address1.ToString(), address2.ToString())
        End If 
        ' The second two are not equal.
        If address2 <> address3 Then
            Console.WriteLine("{0} is not equal to {1}", address2.ToString(), address3.ToString())
        End If