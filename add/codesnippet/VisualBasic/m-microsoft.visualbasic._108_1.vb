    Function matchLanguage(ByVal cityName As String) As String
        Return CStr(Microsoft.VisualBasic.Switch( 
            cityName = "London", "English", 
            cityName = "Rome", "Italian", 
            cityName = "Paris", "French"))
    End Function