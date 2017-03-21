        'Output chain element information.
        Console.WriteLine("Chain Element Information")
        Console.WriteLine("Number of chain elements: {0}", ch.ChainElements.Count)
        Console.WriteLine("Chain elements synchronized? {0} {1}", ch.ChainElements.IsSynchronized, Environment.NewLine)

        Dim element As X509ChainElement
        For Each element In ch.ChainElements
            Console.WriteLine("Element issuer name: {0}", element.Certificate.Issuer)
            Console.WriteLine("Element certificate valid until: {0}", element.Certificate.NotAfter)
            Console.WriteLine("Element certificate is valid: {0}", element.Certificate.Verify())
            Console.WriteLine("Element error status length: {0}", element.ChainElementStatus.Length)
            Console.WriteLine("Element information: {0}", element.Information)
            Console.WriteLine("Number of element extensions: {0}{1}", element.Certificate.Extensions.Count, Environment.NewLine)

            If ch.ChainStatus.Length > 1 Then
                Dim index As Integer
                For index = 0 To element.ChainElementStatus.Length
                    Console.WriteLine(element.ChainElementStatus(index).Status)
                    Console.WriteLine(element.ChainElementStatus(index).StatusInformation)
                Next index
            End If
        Next element
        store.Close()