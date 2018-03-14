' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization

Public Class Temperature
   ' Parses the temperature from a string. Temperature scale is 
   ' indicated by 'F (for Fahrenheit) or 'C (for Celcius) at the end
   ' of the string.
   Public Shared Function Parse(s As String, styles As NumberStyles, _
                                provider As IFormatProvider) As Temperature
      Dim temp As New Temperature()
      
      If s.TrimEnd(Nothing).EndsWith("'F") Then
         temp.Value = Double.Parse(s.Remove(s.LastIndexOf("'"c), 2), _
                                   styles, provider)
      Else
         If s.TrimEnd(Nothing).EndsWith("'C") Then
            temp.Celsius = Double.Parse(s.Remove(s.LastIndexOf("'"c), 2), _
                                        styles, provider)
         Else
            temp.Value = Double.Parse(s, styles, provider)         
         End If
      End If
      Return temp      
   End Function 
   
   ' Declare private constructor so Temperature so only Parse method can
   ' create a new instance
   Private Sub New 
   End Sub

   Protected m_value As Double
   
   Public Property Value() As Double
      Get
         Return m_value
      End Get
      
      Private Set
         m_value = Value
      End Set
   End Property
   
   Public Property Celsius() As Double
      Get
         Return (m_value - 32) / 1.8
      End Get
      Private Set
         m_value = Value * 1.8 + 32
      End Set
   End Property
   
   Public ReadOnly Property Fahrenheit() As Double
      Get
         Return m_Value
      End Get   
   End Property   
End Class

Public Module TestTemperature
   Public Sub Main
      Dim value As String
      Dim styles As NumberStyles
      Dim provider As IFormatProvider
      Dim temp As Temperature
      
      value = "25,3'C"
      styles = NumberStyles.Float
      provider = CultureInfo.CreateSpecificCulture("fr-FR")
      temp = Temperature.Parse(value, styles, provider)
      Console.WriteLine("{0} degrees Fahrenheit equals {1} degrees Celsius.", _
                        temp.Fahrenheit, temp.Celsius)
      
      value = " (40) 'C"
      styles = NumberStyles.AllowLeadingWhite Or NumberStyles.AllowTrailingWhite _
               Or NumberStyles.AllowParentheses
      provider = NumberFormatInfo.InvariantInfo
      temp = Temperature.Parse(value, styles, provider)
      Console.WriteLine("{0} degrees Fahrenheit equals {1} degrees Celsius.", _
                        temp.Fahrenheit, temp.Celsius)
      
      value = "5,778E03'C"      ' Approximate surface temperature of the Sun
      styles = NumberStyles.AllowDecimalPoint Or NumberStyles.AllowThousands Or _
               NumberStyles.AllowExponent
      provider = CultureInfo.CreateSpecificCulture("en-GB") 
      temp = Temperature.Parse(value, styles, provider)
      Console.WriteLine("{0} degrees Fahrenheit equals {1} degrees Celsius.", _
                        temp.Fahrenheit.ToString("N"), temp.Celsius.ToString("N"))
                                
   End Sub
End Module   
' </Snippet2>
