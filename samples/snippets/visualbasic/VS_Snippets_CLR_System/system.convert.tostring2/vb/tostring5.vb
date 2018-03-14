' Visual Basic .NET Document
Option Strict On

' <Snippet26>
Public Class Temperature 
   Private m_Temp As Decimal

   Public Sub New(temperature As Decimal)
      Me.m_Temp = temperature
   End Sub
   
   Public ReadOnly Property Celsius() As Decimal
      Get
         Return Me.m_Temp
      End Get   
   End Property
   
   Public ReadOnly Property Kelvin() As Decimal
      Get
         Return Me.m_Temp + 273.15d   
      End Get
   End Property
   
   Public ReadOnly Property Fahrenheit() As Decimal
      Get
         Return Math.Round(CDec(Me.m_Temp * 9 / 5 + 32), 2)
      End Get      
   End Property
   
   Public Overrides Function ToString() As String
      Return m_Temp.ToString("N2") & " °C"
   End Function
End Class

Module Example
   Public Sub Main()
      Dim cold As New Temperature(-40)
      Dim freezing As New Temperature(0)
      Dim boiling As New Temperature(100)
      
      Console.WriteLine(Convert.ToString(cold, Nothing))
      Console.WriteLine(Convert.ToString(freezing, Nothing))
      Console.WriteLine(Convert.ToString(boiling, Nothing))
   End Sub
End Module
' The example displays the following output:
'       -40.00 °C
'       0.00 °C
'       100.00 °C
' </Snippet26>
