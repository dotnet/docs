Imports System.Globalization

Module Example
   Private Const LOCALE_CUSTOM_UNSPECIFIED As Integer = &H1000

   Sub Main()
      ' <Snippet2>
      Dim cultures() As CultureInfo = CultureInfo.GetCultures(CultureTypes.UserCustomCulture Or
                                                              CultureTypes.SpecificCultures)
      ' </Snippet2>
      Console.WriteLine("Specific Custom Cultures")
      For Each culture In cultures
         If (culture.CultureTypes And CultureTypes.UserCustomCulture) = CultureTypes.UserCustomCulture Then
            Console.WriteLine("   {0}, LCID {1:X8}: {2}", culture.Name, culture.LCID, culture.EnglishName)
            Console.WriteLine("        {0:G}", culture.CultureTypes)
         End If
      Next
      Console.WriteLine(vbCrLf + "Press Enter to continue...")
      Console.ReadLine()
      Main2()
   End Sub
   
   Private Sub Main2()
      Console.Clear()

      ' <Snippet3>
      Dim cultures() As CultureInfo = CultureInfo.GetCultures(CultureTypes.UserCustomCulture Or
                                                              CultureTypes.NeutralCultures)
      ' </Snippet3>
      For Each culture In cultures
         If culture.LCID = LOCALE_CUSTOM_UNSPECIFIED Then Console.WriteLine("{0}, LCID 0x{1:X8}: {2}{3}     {4:G}",
                                                                            culture.Name, culture.LCID, culture.EnglishName,
                                                                            vbCrLf, culture.CultureTypes)
      Next
   End Sub
End Module
