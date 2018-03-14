' Visual Basic .NET Document
Option Strict On

' <Snippet30>
Public Class Temperature : Implements IFormattable 
   Private m_Temp As Decimal 

   Public Sub New(temperature As Decimal)
      Me.m_Temp = temperature
   End Sub 

   Public ReadOnly Property Celsius As Decimal 
      Get 
         Return Me.m_Temp
      End Get    
   End Property 

   Public ReadOnly Property Kelvin As Decimal 
      Get 
         Return Me.m_Temp + 273.15d   
      End Get 
   End Property 

   Public ReadOnly Property Fahrenheit As Decimal 
      Get 
         Return Math.Round(CDec(Me.m_Temp * 9 / 5 + 32), 2)
      End Get       
   End Property 

   Public Overrides Function ToString() As String 
      Return ToString("G", Nothing) 
   End Function 
   
   Public Overloads Function ToString(fmt As String, 
                                      provider As IFormatProvider) As String _
                             Implements IFormattable.ToString
      Dim formatter As TemperatureProvider = Nothing
      If provider IsNot Nothing Then formatter = TryCast(provider.GetFormat(GetType(TemperatureProvider)),
                                                         TemperatureProvider)

      If String.IsNullOrWhiteSpace(fmt) Then
         If formatter IsNot Nothing Then
            fmt = formatter.Format
         Else
            fmt = "G"
         End If
      End If

      Select Case fmt.ToUpper()
         Case "G", "C"
            Return m_Temp.ToString("N2") & " °C" 
         Case "F"
            Return Fahrenheit.ToString("N2") + " °F"
         Case "K"
            Return Kelvin.ToString("N2") + " K"
         Case Else
            Throw New FormatException(String.Format("'{0}' is not a valid format specifier.", fmt))
      End Select
   End Function                             
End Class 

Public Class TemperatureProvider : Implements IFormatProvider
   Private fmtStrings() As String = { "C", "G", "F", "K" }
   Private rnd As New Random()
   
   Public Function GetFormat(formatType As Type) As Object _
                   Implements IFormatProvider.GetFormat 
      Return Me 
   End Function
   
   Public ReadOnly Property Format As String
      Get
         Return fmtStrings(rnd.Next(0, fmtStrings.Length))
      End Get
   End Property
End Class

Module Example
   Public Sub Main()
      Dim cold As New Temperature(-40)
      Dim freezing As New Temperature(0)
      Dim boiling As New Temperature(100)

      Dim tp As New TemperatureProvider()
      
      Console.WriteLine(Convert.ToString(cold, tp))
      Console.WriteLine(Convert.ToString(freezing, tp))
      Console.WriteLine(Convert.ToString(boiling, tp))
   End Sub 
End Module 
' The example displays output like the following:
'       -40.00 °C
'       273.15 K
'       100.00 °C
' </Snippet30>
