' Visual Basic .NET Document
Option Strict On

Imports System.Text.RegularExpressions

' <Snippet1>
Module Example
   Public Sub Main()
      Dim pattern As String = "\b(\w+?)([\u00AE\u2122])"
      Dim input As String = "Microsoft® Office Professional Edition combines several office " + _
                            "productivity products, including Word, Excel®, Access®, Outlook®, " + _
                            "PowerPoint®, and several others. Some guidelines for creating " + _
                            "corporate documents using these productivity tools are available " + _
                            "from the documents created using Silverlight™ on the corporate " + _
                            "intranet site."
      
      Dim matches As MatchCollection = Regex.Matches(input, pattern)
      For Each match As Match In matches
         Dim groups As GroupCollection = match.Groups
         Console.WriteLine("{0}: {1}", groups(2), groups(1))
      Next                               
      Console.WriteLine()
      Console.WriteLine("Found {0} trademarks or registered trademarks.", matches.Count)
   End Sub
End Module
' The example displays the following output:
'       r: Microsoft
'       r: Excel
'       r: Access
'       r: Outlook
'       r: PowerPoint
'       T: Silverlight
' </Snippet1>



