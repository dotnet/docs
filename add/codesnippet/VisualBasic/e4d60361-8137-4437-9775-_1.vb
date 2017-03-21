        Dim parameters As New CspParameters
        parameters.KeyContainerName = "TestContainer"
        Dim argsArray() = New Object() {parameters}

        ' Instantiate the RSA provider instance accessing the key container
        '  TestContainer.
        Dim rsaProvider As New RSACryptoServiceProvider
        rsaProvider = CType(cryptoConfig.CreateFromName( _
            "RSA", argsArray), _
            RSACryptoServiceProvider)