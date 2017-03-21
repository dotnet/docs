Imports System.Globalization

Public Class Temperature : Implements IFormattable
   Private temp As Decimal
   
   Public Sub New(temperature As Decimal)
      If temperature < -273.15 Then _ 
        Throw New ArgumentOutOfRangeException(String.Format("{0} is less than absolute zero.", _
                                              temperature))
      Me.temp = temperature
   End Sub
   
   Public ReadOnly Property Celsius As Decimal
      Get
         Return temp
      End Get
   End Property
   
   Public ReadOnly Property Fahrenheit As Decimal
      Get
         Return temp * 9 / 5 + 32
      End Get
   End Property
   
   Public ReadOnly Property Kelvin As Decimal
      Get
         Return temp + 273.15d
      End Get
   End Property

   Public Overrides Function ToString() As String
      Return Me.ToString("G", CultureInfo.CurrentCulture)
   End Function
      
   Public Overloads Function ToString(fmt As String) As String
      Return Me.ToString(fmt, CultureInfo.CurrentCulture)
   End Function
   
   Public Overloads Function ToString(fmt As String, provider As IFormatProvider) _
                   As String _
                   Implements IFormattable.ToString
      If String.IsNullOrEmpty(fmt) Then fmt = "G"
      If provider Is Nothing Then provider = CultureInfo.CurrentCulture
      
      Select Case fmt.ToUpperInvariant()
         Case "G", "C"
            Return temp.ToString("F2", provider) + " °C" 
         Case "F"
            Return Fahrenheit.ToString("F2", provider) + " °F"
         Case "K"
            Return Kelvin.ToString("F2", provider) + " K"
         Case Else
            Throw New FormatException(String.Format("The {0} format string is not supported.", fmt))
      End Select
   End Function
End Class