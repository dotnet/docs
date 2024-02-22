' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization
Imports System.IO

Module Example
   Public Sub Main()
      ' Persist the date and time data.
      Dim sw As New StreamWriter(".\DateData.dat")
      
      ' Create a DateTime value.      
      Dim dtIn As DateTime = DateTime.Now
      ' Retrieve a CultureInfo object.
      Dim invC As CultureInfo = CultureInfo.InvariantCulture
      
      ' Convert the date to a string and write it to a file.
      sw.WriteLine(dtIn.ToString("r", invC))
      sw.Close()

      ' Restore the date and time data.
      Dim sr As New StreamReader(".\DateData.dat")
      Dim input As String = String.Empty
      Do While sr.Peek() >= 0 
         input = sr.ReadLine()
         Console.WriteLine("Stored data: {0}" , input)    
         Console.WriteLine()
         
         ' Parse the stored string.
         Dim dtOut As DateTime = DateTime.Parse(input, invC, DateTimeStyles.RoundtripKind)

         ' Create a French (France) CultureInfo object.
         Dim frFr As New CultureInfo("fr-FR")
         ' Displays the date formatted for the "fr-FR" culture.
         Console.WriteLine("Date formatted for the {0} culture: {1}" , 
                           frFr.Name, dtOut.ToString("f", frFr))

         ' Creates a German (Germany) CultureInfo object.
         Dim deDe As New CultureInfo("de-De")
         ' Displays the date formatted for the "de-DE" culture.
         Console.WriteLine("Date formatted for {0} culture: {1}" , 
                           deDe.Name, dtOut.ToString("f", deDe))
      Loop
      sr.Close()
   End Sub
End Module
' The example displays the following output:
'    Stored data: Tue, 15 May 2012 16:34:16 GMT
'    
'    Date formatted for the fr-FR culture: mardi 15 mai 2012 16:34
'    Date formatted for de-DE culture: Dienstag, 15. Mai 2012 16:34
' </Snippet1>
