' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Public Enum Continent As Integer
   Africa = 0
   Antarctica = 1
   Asia = 2
   Australia = 3
   Europe = 4
   NorthAmerica = 5
   SouthAmerica = 6
End Enum

Module Example
   Public Sub Main()
      ' Convert a Continent to a Double.
      Dim cont As Continent = Continent.NorthAmerica
      Console.WriteLine("{0:N2}", 
                        Convert.ChangeType(cont, GetType(Double)))
   
      ' Convert a Double to a Continent.
      Dim number As Double = 6.0
      Try
         Console.WriteLine("{0}", 
                           Convert.ChangeType(number, GetType(Continent)))
      Catch e As InvalidCastException
         Console.WriteLine("Cannot convert a Double to a Continent")
      End Try
      
      Console.WriteLine("{0}", CType(number, Continent))   
   End Sub
End Module
' The example displays the following output:
'    5.00
'    Cannot convert a Double to a Continent
'    SouthAmerica
' </Snippet5>
