         ' Get the provider for Microsoft.VisualBasic
            Dim provider = CodeDomProvider.CreateProvider("VisualBasic")
         
         ' Display the Visual Basic language provider information.
         Console.WriteLine("Visual Basic provider is {0}", _
            provider.ToString())
         Console.WriteLine("  Provider hash code:     {0}", _
            provider.GetHashCode().ToString())
         Console.WriteLine("  Default file extension: {0}", _
            provider.FileExtension)
         