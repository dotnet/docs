
        ' Create the encrypted string according to the Basic authentication format as
        ' follows:
        ' a)Concatenate the username and password separated by colon;
        ' b)Apply ASCII encoding to obtain a stream of bytes;
        ' c)Apply Base64 encoding to this array of bytes to obtain the encoded 
        ' authorization.
        Dim BasicEncrypt As String = MyCreds.UserName + ":" + MyCreds.Password

        Dim BasicToken As String = "Basic " + Convert.ToBase64String(ASCII.GetBytes(BasicEncrypt))

        ' Create an Authorization object using the encoded authorization above.
        Dim resourceAuthorization As New Authorization(BasicToken)

        ' Get the Message property, which contains the authorization string that the 
        ' client returns to the server when accessing protected resources.
        Console.WriteLine(ControlChars.Lf + " Authorization Message:{0}", resourceAuthorization.Message)

        ' Get the Complete property, which is set to true when the authentication process 
        ' between the client and the server is finished.
        Console.WriteLine(ControlChars.Lf + " Authorization Complete:{0}", resourceAuthorization.Complete)

        Console.WriteLine(ControlChars.Lf + " Authorization ConnectionGroupId:{0}", resourceAuthorization.ConnectionGroupId)
