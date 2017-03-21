 Dim random() As Byte = New Byte(100) {}
        
 'RNGCryptoServiceProvider is an implementation of an RNG
 Dim rng As New RNGCryptoServiceProvider()
 rng.GetBytes(random) ' bytes in random are now random