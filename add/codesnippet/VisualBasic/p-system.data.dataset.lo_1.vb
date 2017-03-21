 Private Sub GetCultureInfo()
    Dim culture As System.Globalization.CultureInfo
    culture = DataSet1.Locale
    Console.WriteLine(culture.DisplayName, culture.EnglishName)
 End Sub