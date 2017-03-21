        ' Create a new CspParameters object.
        Dim cspParams As New CspParameters()
        
        ' Specify an exchange key.
        cspParams.KeyNumber = Fix(KeyNumber.Exchange)
        
        ' Initialize the RSACryptoServiceProvider  
        ' with the CspParameters object.
        Dim RSACSP As New RSACryptoServiceProvider(cspParams)