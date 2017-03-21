                Dim legalKeySizes() As KeySizes = customCrypto.LegalKeySizes
                If (legalKeySizes.Length > 0) Then
                    For i As Integer = 0 To legalKeySizes.Length - 1 Step 1
                        Write("Keysize" + i.ToString() + " min, max, step: ")
                        Write(legalKeySizes(i).MinSize.ToString() + ", ")
                        Write(legalKeySizes(i).MaxSize.ToString() + ", ")
                        Write(legalKeySizes(i).SkipSize.ToString() + ", ")
                        WriteLine("")
                    Next
                End If