            Try
                Dim k1 As New Rfc2898DeriveBytes(pwd1, salt1, myIterations)
                Dim k2 As New Rfc2898DeriveBytes(pwd1, salt1)
                ' Encrypt the data.
                Dim encAlg As TripleDES = TripleDES.Create()
                encAlg.Key = k1.GetBytes(16)
                Dim encryptionStream As New MemoryStream()
                Dim encrypt As New CryptoStream(encryptionStream, encAlg.CreateEncryptor(), CryptoStreamMode.Write)
                Dim utfD1 As Byte() = New System.Text.UTF8Encoding(False).GetBytes(data1)