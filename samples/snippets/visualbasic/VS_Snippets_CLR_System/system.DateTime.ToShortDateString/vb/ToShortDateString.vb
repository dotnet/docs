' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization
Imports System.Threading

Module Example
   Public Sub Main()
      Dim dateToDisplay As Date = #06/01/2009 8:42:50#
      Dim originalCulture As CultureInfo = Thread.CurrentThread.CurrentCulture
      ' Change culture to en-US.
      Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")
      Console.WriteLine("Displaying short date for {0} culture:", _
                        Thread.CurrentThread.CurrentCulture.Name)
      Console.WriteLine("   {0} (Short Date String)", _
                        dateToDisplay.ToShortDateString())
      ' Display using 'd' standard format specifier to illustrate it is
      ' identical to the string returned by ToShortDateString.
      Console.WriteLine("   {0} ('d' standard format specifier)", _
                        dateToDisplay.ToString("d"))
      Console.WriteLine()
      
      ' Change culture to fr-FR.
      Thread.CurrentThread.CurrentCulture = New CultureInfo("fr-FR")
      Console.WriteLine("Displaying short date for {0} culture:", _
                        Thread.CurrentThread.CurrentCulture.Name)
      Console.WriteLine("   {0}", dateToDisplay.ToShortDateString())
      Console.WriteLine()
  
      ' Change culture to nl-NL.    
      Thread.CurrentThread.CurrentCulture = New CultureInfo("nl-NL")
      Console.WriteLine("Displaying short date for {0} culture:", _
                        Thread.CurrentThread.CurrentCulture.Name)
      Console.WriteLine("   {0}", dateToDisplay.ToShortDateString())
      
      ' Restore original culture.
      Thread.CurrentThread.CurrentCulture = originalCulture
   End Sub
End Module
' The example displays the following output:
'       Displaying short date for en-US culture:
'          6/1/2009 (Short Date String)
'          6/1/2009 ('d' standard format specifier)
'       
'       Displaying short date for fr-FR culture:
'          01/06/2009
'       
'       Displaying short date for nl-NL culture:
'          1-6-2009
' </Snippet1>   
