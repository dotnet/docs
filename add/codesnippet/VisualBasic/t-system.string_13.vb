   Public Overloads Function ToString(fmt As String, provider As IFormatProvider) As String _
                   Implements IFormattable.ToString
      If String.IsNullOrEmpty(fmt) Then fmt = "G"  
      If provider Is Nothing Then provider = CultureInfo.CurrentCulture
      
      Select Case fmt.ToUpperInvariant()
         ' Return degrees in Celsius.    
         Case "G", "C"
            Return temp.ToString("F2", provider) + "°C"
         ' Return degrees in Fahrenheit.
         Case "F" 
            Return (temp * 9 / 5 + 32).ToString("F2", provider) + "°F"
         ' Return degrees in Kelvin.
         Case "K"   
            Return (temp + 273.15).ToString()
         Case Else
            Throw New FormatException(
                  String.Format("The {0} format string is not supported.", 
                                fmt))
       End Select                                   
   End Function