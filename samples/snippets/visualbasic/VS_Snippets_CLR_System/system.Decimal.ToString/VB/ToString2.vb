' Visual Basic .NET Document
Option Strict On

Imports System.Globalization

Module modMain

   Public Sub Main()
      CallDefaultToString()
      Console.WriteLine("-----")
      CallToStringWithSpecificCultures()
      Console.WriteLine("-----")
      CallWithSpecificSpecifiers()
      Console.WriteLine("-----")
      CallWithSpecificSpecifiersAndCultures()
   End Sub
   
   Private Sub CallDefaultToString()
      ' <Snippet2>
      Dim value As Decimal = -16325.62d
      ' Display value using default ToString method.
      Console.WriteLine(value.ToString())            ' Displays -16325.62
      ' Display value using some standard format specifiers.
      Console.WriteLine(value.ToString("G"))         ' Displays -16325.62
      Console.WriteLine(value.ToString("C"))         ' Displays ($16,325.62)
      Console.WriteLine(value.ToString("F"))         ' Displays -16325.62      
      ' </Snippet2>
   End Sub
   
   Private Sub CallToStringWithSpecificCultures()
      ' <Snippet3>
      Dim value As Decimal = -16325.62d
      ' Display value using the invariant culture.
      Console.WriteLine(value.ToString(CultureInfo.InvariantCulture))
      ' Display value using the en-GB culture.
      Console.WriteLine(value.ToString(CultureInfo.CreateSpecificCulture("en-GB")))
      ' Display value using the de-DE culture.
      Console.WriteLine(value.ToString(CultureInfo.CreateSpecificCulture("de-DE")))
      ' This example displays the following output to the console:
      '       -16325.62
      '       -16325.62
      '       -16325,62
      ' </Snippet3>
   End Sub
   
   Private Sub CallWithSpecificSpecifiers()
      ' <Snippet4>
      Dim value As Decimal = 16325.62d
      Dim specifier As String
      
      ' Use standard numeric format specifiers.
      specifier = "G"
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier))
      ' Displays:    G: 16325.62
      specifier = "C"
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier))
      ' Displays:    C: $16,325.62
      specifier = "E04"
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier))
      ' Displays:    E04: 1.6326E+004
      specifier = "F"
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier))
      ' Displays:    F: 16325.62
      specifier = "N"
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier))
      ' Displays:    N: 16,325.62
      specifier = "P"
      Console.WriteLine("{0}: {1}", specifier, (value/10000).ToString(specifier))
      ' Displays:    P: 163.26 %
      
      ' Use custom numeric format specifiers.
      specifier = "0,0.000"
      Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier))
      ' Displays:    0,0.000: 16,325.620
      specifier = "#,#.00#;(#,#.00#)"
      Console.WriteLine("{0}: {1}", specifier, (value*-1).ToString(specifier))
      ' Displays:    #,#.00#;(#,#.00#): (16,325.62)
      ' </Snippet4>
   End Sub
   
   Private Sub CallWithSpecificSpecifiersAndCultures()
      ' <Snippet5>
      Dim value As Decimal = 16325.62d
      Dim specifier As String
      Dim culture As CultureInfo
      
      ' Use standard numeric format specifiers.
      specifier = "G"
      culture = CultureInfo.CreateSpecificCulture("eu-ES")
      Console.WriteLine(value.ToString(specifier, culture))
      ' Displays:    16325,62
      Console.WriteLine(value.ToString(specifier, CultureInfo.InvariantCulture))
      ' Displays:    16325.62
      
      specifier = "C"
      culture = CultureInfo.CreateSpecificCulture("en-US")
      Console.WriteLine(value.ToString(specifier, culture))
      ' Displays:    $16,325.62
      culture = CultureInfo.CreateSpecificCulture("en-GB")
      Console.WriteLine(value.ToString(specifier, culture))
      ' Displays:    £16,325.62
      
      specifier = "E04"
      culture = CultureInfo.CreateSpecificCulture("sv-SE")
      Console.WriteLine(value.ToString(specifier, culture))
      ' Displays: 1,6326E+004   
       culture = CultureInfo.CreateSpecificCulture("en-NZ")
       Console.WriteLine(value.ToString(specifier, culture))
      ' Displays:    1.6326E+004   

      specifier = "F"
      culture = CultureInfo.CreateSpecificCulture("fr-FR")
      Console.WriteLine(value.ToString(specifier, culture))
      ' Displays:    16325,62
      culture = CultureInfo.CreateSpecificCulture("en-CA")
      Console.WriteLine(value.ToString(specifier, culture))
      ' Displays:    16325.62

      specifier = "N"
      culture = CultureInfo.CreateSpecificCulture("es-ES")
      Console.WriteLine(value.ToString(specifier, culture))
      ' Displays:    16.325,62
      culture = CultureInfo.CreateSpecificCulture("fr-CA")
      Console.WriteLine(value.ToString(specifier, culture))
      ' Displays:    16 325,62

      specifier = "P"
      culture = CultureInfo.InvariantCulture
      Console.WriteLine((value/10000).ToString(specifier, culture))
      ' Displays:    163.26 %
      culture = CultureInfo.CreateSpecificCulture("ar-EG")
      Console.WriteLine((value/10000).ToString(specifier, culture))
      ' Displays:    163.256 %
      ' </Snippet5>
   End Sub
End Module







