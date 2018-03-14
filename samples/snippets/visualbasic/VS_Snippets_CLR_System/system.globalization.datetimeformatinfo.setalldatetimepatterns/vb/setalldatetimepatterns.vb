' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Imports System.Globalization

Module Example
   Public Sub Main()
      ' Use standard en-US culture.
      Dim enUS As New CultureInfo("en-US")
      
      Dim values() As String = { "December 2010", "December, 2010",  
                                 "Dec-2010", "December-2010" } 
      
      Console.WriteLine("Supported Y/y patterns for {0} culture:", enUS.Name)
      For Each pattern In enUS.DateTimeFormat.GetAllDateTimePatterns("Y"c)
         Console.WriteLine("   " + pattern)
      Next 
      Console.WriteLine()
      
      ' Try to parse each date string using "Y" format specifier.
      For Each value In values
         Try
            Dim dat As Date = Date.ParseExact(value, "Y", enUS)
            Console.WriteLine(String.Format(enUS, "   Parsed {0} as {1:Y}", value, dat))
         Catch e As FormatException
            Console.WriteLine("   Cannot parse {0}", value)
         End Try   
      Next   
      Console.WriteLine()
      
      'Modify supported "Y" format.
      enUS.DateTimeFormat.SetAllDateTimePatterns( { "MMM-yyyy" } , "Y"c)
      
      Console.WriteLine("New supported Y/y patterns for {0} culture:", enUS.Name)
      For Each pattern In enUS.DateTimeFormat.GetAllDateTimePatterns("Y"c)
         Console.WriteLine("   " + pattern)
      Next 
      Console.WriteLine()

      ' Try to parse each date string using "Y" format specifier.
      For Each value In values
         Try
            Dim dat As Date = Date.ParseExact(value, "Y", enUS)
            Console.WriteLine(String.Format(enUS, "   Parsed {0} as {1:Y}", value, dat))
         Catch e As FormatException
            Console.WriteLine("   Cannot parse {0}", value)
         End Try   
      Next   
   End Sub
End Module
' The example displays the following output:
'       Supported Y/y patterns for en-US culture:
'          MMMM, yyyy
'       
'          Cannot parse December 2010
'          Parsed December, 2010 as December, 2010
'          Cannot parse Dec-2010
'          Cannot parse December-2010
'       
'       New supported Y/y patterns for en-US culture:
'          MMM-yyyy
'       
'          Cannot parse December 2010
'          Cannot parse December, 2010
'          Parsed Dec-2010 as Dec-2010
'          Cannot parse December-2010
' </Snippet1>
