        Public Overrides Sub SetKey(ByVal key As AsymmetricAlgorithm)
            If (Not key Is Nothing) Then
                rsaKey = CType(key, RSA)
            Else
                Throw New ArgumentNullException("key")
            End If
        End Sub