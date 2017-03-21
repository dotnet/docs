            'The default iteration count is 1000 so the two methods use the same iteration count.
            Dim myIterations As Integer = 1000
            Try
                Dim k1 As New Rfc2898DeriveBytes(pwd1, salt1, myIterations)
                Dim k2 As New Rfc2898DeriveBytes(pwd1, salt1)
                ' Encrypt the data.
                Dim encAlg As TripleDES = TripleDES.Create()
                encAlg.Key = k1.GetBytes(16)
                Dim encryptionStream As New MemoryStream()
                Dim encrypt As New CryptoStream(encryptionStream, encAlg.CreateEncryptor(), CryptoStreamMode.Write)
                Dim utfD1 As Byte() = New System.Text.UTF8Encoding(False).GetBytes(data1)
                encrypt.Write(utfD1, 0, utfD1.Length)
                encrypt.FlushFinalBlock()
                encrypt.Close()
                Dim edata1 As Byte() = encryptionStream.ToArray()
                k1.Reset()

                ' Try to decrypt, thus showing it can be round-tripped.
                Dim decAlg As TripleDES = TripleDES.Create()
                decAlg.Key = k2.GetBytes(16)
                decAlg.IV = encAlg.IV
                Dim decryptionStreamBacking As New MemoryStream()
                Dim decrypt As New CryptoStream(decryptionStreamBacking, decAlg.CreateDecryptor(), CryptoStreamMode.Write)
                decrypt.Write(edata1, 0, edata1.Length)
                decrypt.Flush()
                decrypt.Close()
                k2.Reset()
                Dim data2 As String = New UTF8Encoding(False).GetString(decryptionStreamBacking.ToArray())

                If Not data1.Equals(data2) Then
                    Console.WriteLine("Error: The two values are not equal.")
                Else
                    Console.WriteLine("The two values are equal.")
                    Console.WriteLine("k1 iterations: {0}", k1.IterationCount)
                    Console.WriteLine("k2 iterations: {0}", k2.IterationCount)
                End If