      Dim supportedVer1 As New FrameworkName(".NET Framework, Version=4.0")
      Dim actualVersion As New FrameworkName(String.Format(".NET Framework, Version={0}", 
                                             Environment.Version.ToString())) 
      
      Console.WriteLine("Supported Version: {0}", supportedVer1)
      Console.WriteLine("Actual Version:    {0}", actualVersion)
      If supportedVer1 <> actualVersion Then
         Console.WriteLine("The supported and actual Framework versions are different.")
      Else
         Console.WriteLine("The supported and actual Framework versions are the same.")
      End If 
      Console.WriteLine()
      ' The example displays the following output:
      '      Supported Version: .NET Framework,Version=v4.0
      '      Actual Version:    .NET Framework,Version=v4.0.30319.18010
      '      The supported and actual Framework versions are different.